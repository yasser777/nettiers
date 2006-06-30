
using System;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.Serialization;
using System.Text;
using Microsoft.Practices.ObjectBuilder;

namespace netTiers.Petshop.Entities
{
	
	/// <summary>
	/// Entity Manager provides the management of entity location and creation.
	/// This is responsible for providing the health and validity of entities as a whole.
	/// </summary>
    public static class EntityManager
    {
        #region Fields
        private static object syncObject = new object();
        private static Dictionary<string, IEntityFactory> entityFactoryList = new Dictionary<string, IEntityFactory>();
        private static EntityLocator entityLocator = new EntityLocator();
        #endregion

        #region LocateOrCreate<Entity>
        /// <summary>
        /// Locates an entity for retrieval from the <see cref="Locator"/>, or instatiates a new instance 
        /// of the entity if not currently being tracked.
        /// </summary>
        /// <typeparam name="Entity">Must implement <see cref="IEntity"/> and is the default type to create, and will be the return type.</typeparam>
        /// <param name="key">primary key representation</param>
        /// <param name="typeString">type string to create</param>
        /// <param name="entityFactoryType">factory used to try to create this entity.</param>
        /// <returns>Created entity of T</returns>
        public static Entity LocateOrCreate<Entity>(string key, string typeString, Type entityFactoryType) where Entity : class, IEntity, new()
        {
			return LocateOrCreate<Entity>(key, typeString, entityFactoryType, true);
		}
		
		/// <summary>
        /// Locates an entity for retrieval from the <see cref="Locator"/>, or instatiates a new instance 
        /// of the entity if not currently being tracked.
        /// </summary>
        /// <typeparam name="Entity">Must implement <see cref="IEntity"/> and is the default type to create, and will be the return type.</typeparam>
        /// <param name="key">primary key representation</param>
        /// <param name="typeString">type string to create</param>
        /// <param name="entityFactoryType">factory used to try to create this entity.</param>
        /// <param name="isLocatorEnabled">bool determining whether to use Entity Locating.</param>
        /// <returns>Created entity of T</returns>
        public static Entity LocateOrCreate<Entity>(string key, string typeString, Type entityFactoryType, bool isLocatorEnabled) where Entity : class, IEntity, new()
        {
            #region Validation
            if (string.IsNullOrEmpty(typeString))
                throw new ArgumentException("typeString");

            if (entityFactoryType == null)
                throw new ArgumentException("entityFactoryType");
            #endregion 

            Entity entity = default(Entity);
            
            //Generated Table Entities Type
            Type defaultType = typeof(Entity);
            bool isCacheable = defaultType.GetInterface("IEntityCacheItem") != null;

            //see if entity is cachable, if IEntityCacheItem
            //retrieve from cache.
            if (isCacheable)
                entity = EntityCache.GetItem<Entity>(key.ToString());

            if (entity != null)
                return entity;
            
            IEntityFactory factory = null;
            if (EntityFactories.ContainsKey(entityFactoryType.FullName))
                factory = EntityFactories[entityFactoryType.FullName];
            else
                factory = TryAddEntityFactory(entityFactoryType);

            
            //attempt to locate
            if (key != null && isLocatorEnabled)
            {
                if (EntityLocator.Contains(key))
                {
                    entity = EntityLocator.Get(key) as Entity;
                }
            }

            //if not found try create from factory
            if (entity == null)
                entity = factory.CreateEntity(typeString, defaultType) as Entity;

            //add to locator and start tracking.
            if (!entity.IsEntityTracked)
                StartTracking(key, entity, isLocatorEnabled);

            //add entity to Cache if IEntityCacheItem
            if (entity.GetType().GetInterface("IEntityCacheItem") != null)
                EntityCache.AddCache(key, entity);

            return entity;
        }
        #endregion 

		#region LocateEntity
		/// <summary>
        /// Locates an entity for retrieval from the <see cref="Locator"/> if tracking is enabled.
        /// </summary>
        /// <typeparam name="Entity">Must implement <see cref="IEntity"/> and is the default type to create, and will be the return type.</typeparam>
        /// <param name="key">primary key representation</param>
        /// <param name="isLocatorEnabled">bool determining whether to use Entity Locating.</param>
        /// <returns>found entity of T, or null</returns>
		public static Entity LocateEntity<Entity>(string key, bool isLocatorEnabled) where Entity : class, IEntity, new()
        {
			Entity entity = null;
			
			//attempt to locate
            if (key != null && isLocatorEnabled)
            {
                if (EntityLocator.Contains(key))
                {
                    entity = EntityLocator.Get(key) as Entity;
                }
            }
			return entity;
		}
		#endregion 
		
        #region StopTracking
        /// <summary>
        /// Stops Tracking an Entity, it will be re-added in the next round.
        /// </summary>
        /// <param name="key">Entity Key used in the Locator's Bucket</param>
        /// <returns>true if found, false if not found</returns>
        public static bool StopTracking(string key)
        {
            if (key == null)
                throw new ArgumentNullException("key");
            
            return EntityLocator.Remove(key);
        }
        #endregion 
        
		#region StartTracking
        /// <summary>
        /// Starts Tracking an Entity, it will be tracked until modified or persisted.
        /// </summary>
        /// <param name="key">Entity Key used in the Locator's Bucket</param>
        /// <param name="entity">entity to be tracked</param>
        /// <param name="isTrackingEnabled">Determines whether tracking is enabled</param>
        public static void StartTracking(string key, IEntity entity, bool isTrackingEnabled)
        {
            if (key == null)
                throw new ArgumentNullException("key");
            
			if (entity == null)
                throw new ArgumentNullException("entity");
            
			if (!entity.IsEntityTracked && isTrackingEnabled)
			{
                EntityLocator.Add(key, entity);
				entity.IsEntityTracked = true;
				entity.EntityTrackingKey = key;
			}
					
            return;
        }
        #endregion 

        #region EntityFactories
        /// <summary>
        /// Exposes the current entity factory instance.
        /// </summary>
        /// <value>The entity factories.</value>
        public static Dictionary<string, IEntityFactory> EntityFactories
        {
            get { return entityFactoryList; }
            set
            {
                if (value != null)
                {
                    lock (syncObject)
                    {
                        entityFactoryList = value;
                    }
                }
            }
        }
        #endregion 

        #region EntityLocator
        /// <summary>
        /// Expose the current entity locator for consumption by the API.
        /// </summary>
        /// <value>The entity locator.</value>
        public static EntityLocator EntityLocator
        {
            get 
            { 
                //readonly
                return entityLocator; 
            }
        }
        #endregion 

        #region TryAddEntityFactory
        /// <summary>
        /// Adds a factory to the EntityFactories property if the parameter type is valid.
        /// </summary>
        /// <param name="entityFactoryTypeToCreate">The entity factory type to create.</param>
        /// <returns>true if successful.</returns>
        public static IEntityFactory TryAddEntityFactory(Type entityFactoryTypeToCreate)
        {
            lock (syncObject)
            {
                if (entityFactoryTypeToCreate == null)
                    throw new ArgumentException("entityFactoryTypeToCreate");

                IEntityFactory createdFactory = Activator.CreateInstance(entityFactoryTypeToCreate) as IEntityFactory;

                if (createdFactory == null)
                    throw new ArgumentException("This factory can not be found.  Please ensure that you are using a valid Entity Factory.", "entityFactoryType");

                EntityFactories.Add(entityFactoryTypeToCreate.FullName, (IEntityFactory)createdFactory);
            }
            return EntityFactories[entityFactoryTypeToCreate.FullName];
        }
        #endregion 
    }

	
	#region EntityNotValidException
    /// <summary>
    /// Exception used to pass information along to the UI when an entity is not valid. <see cref="EntityBase"/>.IsValid.
    /// </summary>
	public class EntityNotValidException : Exception
	{
		private EntityBase entity;
		private IList entityList;
		private string executingMethod;
		private static readonly string defaultMessage = "One or more entities is in an invalid state while trying to persist the entity";

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotValidException"/> class.
        /// </summary>
		public EntityNotValidException() : base(defaultMessage)
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotValidException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
		public EntityNotValidException(string message) : base(message)
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotValidException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
		public EntityNotValidException(string message, Exception exception) : base(message, exception)
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotValidException"/> class.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="method">The method.</param>
		public EntityNotValidException(EntityBase entity, string method)
            : this(entity, method, string.Format(defaultMessage + " for {0} during {1}.", (entity != null ? entity.GetType().Name : ""), method))
		{
		}
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotValidException"/> class.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="method">The method.</param>
        /// <param name="message">The message.</param>
		public EntityNotValidException(EntityBase entity, string method, string message) : base(message)
		{
			this.entity = entity;
            this.executingMethod = method;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotValidException"/> class.
        /// </summary>
        /// <param name="entityList">The entity list.</param>
        /// <param name="method">The method.</param>
        /// <param name="message">The message.</param>
		public EntityNotValidException(IList entityList, string method, string message) : base(message)
		{
			this.entityList = entityList;
            this.executingMethod = method;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotValidException"/> class.
        /// </summary>
        /// <param name="entityList">The entity list.</param>
        /// <param name="method">The method.</param>
		public EntityNotValidException(IList entityList, string method)
            : this(entityList, method, string.Format(defaultMessage + " for {0} during {1}.", (entityList != null ? entityList.GetType().Name : ""), method))
		{
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityNotValidException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
        /// <exception cref="T:System.Runtime.Serialization.SerializationException">The class name is null or <see cref="P:System.Exception.HResult"></see> is zero (0). </exception>
        /// <exception cref="T:System.ArgumentNullException">The info parameter is null. </exception>
		public EntityNotValidException(SerializationInfo info, StreamingContext context): base(info, context)
		{
            this.Entity = (EntityBase)info.GetValue("Entity", typeof(EntityBase));
			this.EntityList = (IList)info.GetValue("EntityList", typeof(IList));
			this.ExecutingMethod = info.GetString("ExecutingMethod");
		}

        /// <summary>
        /// Gets or sets the entity.
        /// </summary>
        /// <value>The entity.</value>
		public EntityBase Entity
		{
			get{ return entity;	}
			set {entity = value;}
		}

        /// <summary>
        /// Gets or sets the entity list.
        /// </summary>
        /// <value>The entity list.</value>
		public IList EntityList
		{
			get{ return entityList;	}
			set {entityList = value;}
		}

        /// <summary>
        /// Gets or sets the executing method.
        /// </summary>
        /// <value>The executing method.</value>
		public string ExecutingMethod
		{
			get {	return executingMethod;   }
            set { executingMethod = value; }
		}
	}
	#endregion 
}
