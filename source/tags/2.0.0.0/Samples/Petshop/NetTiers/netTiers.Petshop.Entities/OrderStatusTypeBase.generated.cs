﻿	
/*
	File generated by NetTiers templates [www.nettiers.com]
	Generated on : Monday, July 24, 2006
	Important: Do not modify this file. Edit the file OrderStatusType.cs instead.
*/

#region using directives

using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Runtime.Serialization;

#endregion

namespace netTiers.Petshop.Entities
{
	#region OrderStatusTypeEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="OrderStatusType"/> object.
	/// </remarks>
	public class OrderStatusTypeEventArgs : System.EventArgs
	{
		private OrderStatusTypeColumn column;
		
		///<summary>
		/// Initalizes a new Instance of the OrderStatusTypeEventArgs class.
		///</summary>
		public OrderStatusTypeEventArgs(OrderStatusTypeColumn column)
		{
			this.column = column;
		}
		
		
		///<summary>
		/// The OrderStatusTypeColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="OrderStatusTypeColumn" />
		public OrderStatusTypeColumn Column { get { return this.column; } }
	}
	#endregion
	
	
	///<summary>
	/// Define a delegate for all OrderStatusType related events.
	///</summary>
	public delegate void OrderStatusTypeEventHandler(object sender, OrderStatusTypeEventArgs e);
	
	///<summary>
	/// An object representation of the 'OrderStatusType' table. [No description found the database]	
	///</summary>
	[Serializable, DataObject]
	[CLSCompliant(true)]
	//[ToolboxItem(typeof(OrderStatusType))]
	public abstract partial class OrderStatusTypeBase : EntityBase, IEntityId<OrderStatusTypeKey>, System.IComparable, System.ICloneable, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		/// 	Old the inner data of the entity.
		/// </summary>
		private OrderStatusTypeEntityData entityData;
		
		// <summary>
		// 	Old the original data of the entity.
		// </summary>
		//OrderStatusTypeEntityData originalData;
		
		/// <summary>
		/// 	Old a backup of the inner data of the entity.
		/// </summary>
		private OrderStatusTypeEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		[NonSerialized]
		private TList<OrderStatusType> parentCollection;
		private bool inTxn = false;

		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>	
		[field:NonSerialized]
		public event OrderStatusTypeEventHandler ColumnChanging;
		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event OrderStatusTypeEventHandler ColumnChanged;		
		#endregion "Variable Declarations"
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="OrderStatusTypeBase"/> instance.
		///</summary>
		public OrderStatusTypeBase()
		{
			this.entityData = new OrderStatusTypeEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="OrderStatusTypeBase"/> instance.
		///</summary>
		///<param name="orderStatusTypeOrderStatus"></param>
		///<param name="orderStatusTypeOrderStatusDescription"></param>
		public OrderStatusTypeBase(System.String orderStatusTypeOrderStatus, System.String orderStatusTypeOrderStatusDescription)
		{
			this.entityData = new OrderStatusTypeEntityData();
			this.backupData = null;

			this.OrderStatus = orderStatusTypeOrderStatus;
			this.OrderStatusDescription = orderStatusTypeOrderStatusDescription;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="OrderStatusType"/> instance.
		///</summary>
		///<param name="orderStatusTypeOrderStatus"></param>
		///<param name="orderStatusTypeOrderStatusDescription"></param>
		public static OrderStatusType CreateOrderStatusType(System.String orderStatusTypeOrderStatus, System.String orderStatusTypeOrderStatusDescription)
		{
			OrderStatusType newOrderStatusType = new OrderStatusType();
			newOrderStatusType.OrderStatus = orderStatusTypeOrderStatus;
			newOrderStatusType.OrderStatusDescription = orderStatusTypeOrderStatusDescription;
			return newOrderStatusType;
		}
				
		#endregion Constructors
		
		
		#region Events trigger
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="OrderStatusTypeColumn"/> which has raised the event.</param>
		public void OnColumnChanging(OrderStatusTypeColumn column)
		{
			if(IsEntityTracked && EntityState != EntityState.Added)
				EntityManager.StopTracking(EntityTrackingKey);
				
			if (!SuppressEntityEvents)
			{
				OrderStatusTypeEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new OrderStatusTypeEventArgs(column));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="OrderStatusTypeColumn"/> which has raised the event.</param>
		public void OnColumnChanged(OrderStatusTypeColumn column)
		{
			if (!SuppressEntityEvents)
			{
				OrderStatusTypeEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new OrderStatusTypeEventArgs(column));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
				
		#region Properties	
				
		/// <summary>
		/// 	Gets or sets the OrderStatusId property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[ReadOnlyAttribute(false)/*, XmlIgnoreAttribute()*/, DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(true,true,false)]
		public virtual System.Int32 OrderStatusId
		{
			get
			{
				return this.entityData.OrderStatusId; 
			}
			
			set
			{
				if (this.entityData.OrderStatusId == value)
					return;
					
					
				OnColumnChanging(OrderStatusTypeColumn.OrderStatusId);
				this.entityData.OrderStatusId = value;
				this.EntityId.OrderStatusId = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(OrderStatusTypeColumn.OrderStatusId);
				OnPropertyChanged("OrderStatusId");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the OrderStatus property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false,false,false, 24)]
		public virtual System.String OrderStatus
		{
			get
			{
				return this.entityData.OrderStatus; 
			}
			
			set
			{
				if (this.entityData.OrderStatus == value)
					return;
					
					
				OnColumnChanging(OrderStatusTypeColumn.OrderStatus);
				this.entityData.OrderStatus = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(OrderStatusTypeColumn.OrderStatus);
				OnPropertyChanged("OrderStatus");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the OrderStatusDescription property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false,false,true, 300)]
		public virtual System.String OrderStatusDescription
		{
			get
			{
				return this.entityData.OrderStatusDescription; 
			}
			
			set
			{
				if (this.entityData.OrderStatusDescription == value)
					return;
					
					
				OnColumnChanging(OrderStatusTypeColumn.OrderStatusDescription);
				this.entityData.OrderStatusDescription = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(OrderStatusTypeColumn.OrderStatusDescription);
				OnPropertyChanged("OrderStatusDescription");
			}
		}
		

		#region Source Foreign Key Property
				
		#endregion
			
		#region Table Meta Data
		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string TableName
		{
			get { return "OrderStatusType"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"OrderStatusId", "OrderStatus", "OrderStatusDescription"};
			}
		}
		#endregion 
		
	
		/// <summary>
		///	Holds a collection of OrderStatus objects
		///	which are related to this object through the relation FK_OrderStatus_OrderStatusType
		/// </summary>	
		[BindableAttribute()]
		public TList<OrderStatus> OrderStatusCollection
		{
			get { return entityData.OrderStatusCollection; }
			set { entityData.OrderStatusCollection = value; }	
		}
		
		#endregion
		
		#region IEditableObject
		
		#region  CancelAddNew Event
		/// <summary>
        /// The delegate for the CancelAddNew event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		public delegate void CancelAddNewEventHandler(object sender, EventArgs e);
    
    	/// <summary>
		/// The CancelAddNew event.
		/// </summary>
		[field:NonSerialized]
		public event CancelAddNewEventHandler CancelAddNew ;

		/// <summary>
        /// Called when [cancel add new].
        /// </summary>
        public void OnCancelAddNew()
        {    
			if (!SuppressEntityEvents)
			{
	            CancelAddNewEventHandler handler = CancelAddNew ;
            	if (handler != null)
	            {    
    	            handler(this, EventArgs.Empty) ;
        	    }
	        }
        }
		#endregion 
		
		/// <summary>
		/// Begins an edit on an object.
		/// </summary>
		void IEditableObject.BeginEdit() 
	    {
	        //Console.WriteLine("Start BeginEdit");
	        if (!inTxn) 
	        {
	            this.backupData = this.entityData.Clone() as OrderStatusTypeEntityData;
	            inTxn = true;
	            //Console.WriteLine("BeginEdit");
	        }
	        //Console.WriteLine("End BeginEdit");
	    }
	
		/// <summary>
		/// Discards changes since the last <c>BeginEdit</c> call.
		/// </summary>
	    void IEditableObject.CancelEdit() 
	    {
	        //Console.WriteLine("Start CancelEdit");
	        if (this.inTxn) 
	        {
	            this.entityData = this.backupData;
	            this.backupData = null;
				this.inTxn = false;

				if (this.bindingIsNew)
	        	//if (this.EntityState == EntityState.Added)
	        	{
					if (this.parentCollection != null)
						this.parentCollection.Remove( (OrderStatusType) this ) ;
				}	            
	        }
	        //Console.WriteLine("End CancelEdit");
	    }
	
		/// <summary>
		/// Pushes changes since the last <c>BeginEdit</c> or <c>IBindingList.AddNew</c> call into the underlying object.
		/// </summary>
	    void IEditableObject.EndEdit() 
	    {
	        //Console.WriteLine("Start EndEdit" + this.custData.id + this.custData.lastName);
	        if (this.inTxn) 
	        {
	            this.backupData = null;
				if (this.IsDirty) 
				{
					if (this.bindingIsNew) {
						this.EntityState = EntityState.Added;
						this.bindingIsNew = false ;
					}
					else
						if (this.EntityState == EntityState.Unchanged) 
							this.EntityState = EntityState.Changed ;
				}

				this.bindingIsNew = false ;
	            this.inTxn = false;	            
	        }
	        //Console.WriteLine("End EndEdit");
	    }
	    
	    /// <summary>
        /// Gets or sets the parent collection.
        /// </summary>
        /// <value>The parent collection.</value>
	    [XmlIgnore]
		[Browsable(false)]
	    public override object ParentCollection
	    {
	        get 
	        {
	            return (object)this.parentCollection;
	        }
	        set 
	        {
	            this.parentCollection = (TList<OrderStatusType>)value;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as OrderStatusType);
	        }
	    }


		#endregion
		
		#region Methods	
			
		///<summary>
		///  TODO: Revert all changes and restore original values.
		///  Currently not supported.
		///</summary>
		/// <exception cref="NotSupportedException">This method is not currently supported and always throws this exception.</exception>
		public override void CancelChanges()
		{
			throw new NotImplementedException("Method currently not Supported.");
		}	
		
		#region ICloneable Members
		///<summary>
		///  Returns a Typed OrderStatusType Entity 
		///</summary>
		public virtual OrderStatusType Copy()
		{
			//shallow copy entity
			OrderStatusType copy = new OrderStatusType();
			copy.OrderStatusId = this.OrderStatusId;
			copy.OrderStatus = this.OrderStatus;
			copy.OrderStatusDescription = this.OrderStatusDescription;
					
			copy.AcceptChanges();
			return (OrderStatusType)copy;
		}
		
		///<summary>
		/// ICloneable.Clone() Member, returns the Shallow Copy of this entity.
		///</summary>
		public object Clone()
		{
			return this.Copy();
		}
		
		///<summary>
		/// Returns a deep copy of the child collection object passed in.
		///</summary>
		public static object MakeCopyOf(object x)
		{
			if (x is ICloneable)
			{
				// Return a deep copy of the object
				return ((ICloneable)x).Clone();
			}
			else
				throw new System.NotSupportedException("Object Does Not Implement the ICloneable Interface.");
		}
		
		///<summary>
		///  Returns a Typed OrderStatusType Entity which is a deep copy of the current entity.
		///</summary>
		public virtual OrderStatusType DeepCopy()
		{
			return EntityHelper.Clone<OrderStatusType>(this as OrderStatusType);	
		}
		#endregion
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="OrderStatusTypeBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(OrderStatusTypeBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="OrderStatusTypeBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="OrderStatusTypeBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="OrderStatusTypeBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(OrderStatusTypeBase Object1, OrderStatusTypeBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;
				
			bool equal = true;
			if (Object1.OrderStatusId != Object2.OrderStatusId)
				equal = false;
			if (Object1.OrderStatus != Object2.OrderStatus)
				equal = false;
			if ( Object1.OrderStatusDescription != null && Object2.OrderStatusDescription != null )
			{
				if (Object1.OrderStatusDescription != Object2.OrderStatusDescription)
					equal = false;
			}
			else if (Object1.OrderStatusDescription == null ^ Object1.OrderStatusDescription == null )
			{
				equal = false;
			}
			return equal;
		}
		
		#endregion
		
		#region IComparable Members
		///<summary>
		/// Compares this instance to a specified object and returns an indication of their relative values.
		///<param name="obj">An object to compare to this instance, or a null reference (Nothing in Visual Basic).</param>
		///</summary>
		///<returns>A signed integer that indicates the relative order of this instance and obj.</returns>
		public virtual int CompareTo(object obj)
		{
			throw new NotImplementedException();
			// TODO -> generate a strongly typed IComparer in the concrete class
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name) .CompareTo(((OrderStatusTypeBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name));
		}
		
		/*
		// static method to get a Comparer object
        public static OrderStatusTypeComparer GetComparer()
        {
            return new OrderStatusTypeComparer();
        }
        */

        // Comparer delegates back to OrderStatusType
        // Employee uses the integer's default
        // CompareTo method
        /*
        public int CompareTo(Item rhs)
        {
            return this.Id.CompareTo(rhs.Id);
        }
        */

/*
        // Special implementation to be called by custom comparer
        public int CompareTo(OrderStatusType rhs, OrderStatusTypeColumn which)
        {
            switch (which)
            {
            	
            	
            	case OrderStatusTypeColumn.OrderStatusId:
            		return this.OrderStatusId.CompareTo(rhs.OrderStatusId);
            		
            		                 
            	
            	
            	case OrderStatusTypeColumn.OrderStatus:
            		return this.OrderStatus.CompareTo(rhs.OrderStatus);
            		
            		                 
            	
            	
            	case OrderStatusTypeColumn.OrderStatusDescription:
            		return this.OrderStatusDescription.CompareTo(rhs.OrderStatusDescription);
            		
            		                 
            }
            return 0;
        }
        */
	
		#endregion
		
		#region IComponent Members
		
		private ISite _site = null;

		/// <summary>
		/// Gets or Sets the site where this data is located.
		/// </summary>
		[XmlIgnore]
		[SoapIgnore]
		[Browsable(false)]
		public ISite Site
		{
			get{ return this._site; }
			set{ this._site = value; }
		}

		#endregion

		#region IDisposable Members
		
		/// <summary>
		/// Notify those that care when we dispose.
		/// </summary>
		[field:NonSerialized]
		public event System.EventHandler Disposed;

		/// <summary>
		/// Clean up. Nothing here though.
		/// </summary>
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		
		/// <summary>
		/// Clean up.
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				EventHandler handler = Disposed;
				if (handler != null)
					handler(this, EventArgs.Empty);
			}
		}
		
		#endregion
				
		#region IEntityKey<OrderStatusTypeKey> Members
		
		// member variable for the EntityId property
		private OrderStatusTypeKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public OrderStatusTypeKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new OrderStatusTypeKey(this);
				}

				return _entityId;
			}
			set
			{
				if ( value != null )
				{
					value.Entity = this;
				}
				
				_entityId = value;
			}
		}
		
		#endregion
		
		#region EntityTrackingKey
		///<summary>
		/// Provides the tracking key for the <see cref="EntityLocator"/>
		///</summary>
		[XmlIgnore]
		public override string EntityTrackingKey
		{
			get
			{
				if(entityTrackingKey == null)
					entityTrackingKey = @"OrderStatusType" 
					+ this.OrderStatusId.ToString();
				return entityTrackingKey;
			}
			set
		    {
		        if (value != null)
                    entityTrackingKey = value;
		    }
		}
		#endregion 
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return string.Format(System.Globalization.CultureInfo.InvariantCulture,
				"{4}{3}- OrderStatusId: {0}{3}- OrderStatus: {1}{3}- OrderStatusDescription: {2}{3}", 
				this.OrderStatusId,
				this.OrderStatus,
				(this.OrderStatusDescription == null) ? string.Empty : this.OrderStatusDescription.ToString(),
				Environment.NewLine, 
				this.GetType());
		}
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'OrderStatusType' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal class OrderStatusTypeEntityData : ICloneable
	{
		#region Variable Declarations
		
		#region Primary key(s)
			/// <summary>			
			/// OrderStatusId : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "OrderStatusType"</remarks>
			public System.Int32 OrderStatusId;
				
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// OrderStatus : 
		/// </summary>
		public System.String		  OrderStatus = string.Empty;
		
		/// <summary>
		/// OrderStatusDescription : 
		/// </summary>
		public System.String		  OrderStatusDescription = null;
		#endregion
			
		#endregion "Variable Declarations"
		
		public Object Clone()
		{
			OrderStatusTypeEntityData _tmp = new OrderStatusTypeEntityData();
						
			_tmp.OrderStatusId = this.OrderStatusId;
			
			_tmp.OrderStatus = this.OrderStatus;
			_tmp.OrderStatusDescription = this.OrderStatusDescription;
			
			return _tmp;
		}
		

		private TList<OrderStatus> orderStatus;
      public TList<OrderStatus> OrderStatusCollection
      {
         get
         {
            if (orderStatus == null)
            {
               orderStatus = new TList<OrderStatus>();
            }

            return orderStatus;
         }
         set { orderStatus = value; }
      }
	}//End struct


		#endregion
		
		#region Validation
		
		/// <summary>
		/// Assigns validation rules to this object based on model definition.
		/// </summary>
		/// <remarks>This method overrides the base class to add schema related validation.</remarks>
		protected override void AddValidationRules()
		{
			//Validation rules based on database schema.
			ValidationRules.AddRule(Validation.CommonRules.NotNull,"OrderStatus");
			ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("OrderStatus",24));
			ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("OrderStatusDescription",300));
		}
   		#endregion
	
	} // End Class
	
	#region OrderStatusTypeComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class OrderStatusTypeComparer : System.Collections.Generic.IComparer<OrderStatusType>
	{
		OrderStatusTypeColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:OrderStatusTypeComparer"/> class.
        /// </summary>
		public OrderStatusTypeComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:%=className%>Comparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public OrderStatusTypeComparer(OrderStatusTypeColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <c cref="OrderStatusType"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <c cref="OrderStatusType"/> to compare.</param>
        /// <param name="b">The second <c>OrderStatusType</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(OrderStatusType a, OrderStatusType b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(OrderStatusType entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(OrderStatusType a, OrderStatusType b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public OrderStatusTypeColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region OrderStatusTypeKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="OrderStatusType"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class OrderStatusTypeKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the OrderStatusTypeKey class.
		/// </summary>
		public OrderStatusTypeKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the OrderStatusTypeKey class.
		/// </summary>
		public OrderStatusTypeKey(OrderStatusTypeBase entity)
		{
			Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.orderStatusId = entity.OrderStatusId;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the OrderStatusTypeKey class.
		/// </summary>
		public OrderStatusTypeKey(System.Int32 orderStatusId)
		{
			#region Init Properties

			this.orderStatusId = orderStatusId;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private OrderStatusTypeBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public OrderStatusTypeBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the OrderStatusId property
		private System.Int32 orderStatusId;
		
		/// <summary>
		/// Gets or sets the OrderStatusId property.
		/// </summary>
		public System.Int32 OrderStatusId
		{
			get { return orderStatusId; }
			set
			{
				if ( Entity != null )
				{
					Entity.OrderStatusId = value;
				}
				
				orderStatusId = value;
			}
		}
		
		#endregion

		#region Methods
		
		/// <summary>
		/// Reads values from the supplied <see cref="IDictionary"/> object into
		/// properties of the current object.
		/// </summary>
		/// <param name="values">An <see cref="IDictionary"/> instance that contains
		/// the key/value pairs to be used as property values.</param>
		public override void Load(IDictionary values)
		{
			#region Init Properties

			if ( values != null )
			{
				OrderStatusId = ( values["OrderStatusId"] != null ) ? (System.Int32) EntityUtil.ChangeType(values["OrderStatusId"], typeof(System.Int32)) : (int)0;
			}

			#endregion
		}

		/// <summary>
		/// Creates a new <see cref="IDictionary"/> object and populates it
		/// with the property values of the current object.
		/// </summary>
		/// <returns>A collection of name/value pairs.</returns>
		public override IDictionary ToDictionary()
		{
			IDictionary values = new Hashtable();

			#region Init Dictionary

			values.Add("OrderStatusId", OrderStatusId);

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("OrderStatusId: {0}{1}",
								OrderStatusId,
								Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	
	
	/// <summary>
	/// Enumerate the OrderStatusType columns.
	/// </summary>
	[Serializable]
	public enum OrderStatusTypeColumn
	{
		/// <summary>
		/// OrderStatusId : 
		/// </summary>
		[EnumTextValue("OrderStatusId")]
		OrderStatusId,
		/// <summary>
		/// OrderStatus : 
		/// </summary>
		[EnumTextValue("OrderStatus")]
		OrderStatus,
		/// <summary>
		/// OrderStatusDescription : 
		/// </summary>
		[EnumTextValue("OrderStatusDescription")]
		OrderStatusDescription
	}//End enum

} // end namespace

