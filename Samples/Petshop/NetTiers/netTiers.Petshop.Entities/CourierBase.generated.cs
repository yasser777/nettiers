﻿	
/*
	File generated by NetTiers templates [www.nettiers.com]
	Generated on : Monday, July 24, 2006
	Important: Do not modify this file. Edit the file Courier.cs instead.
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
	#region CourierEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="Courier"/> object.
	/// </remarks>
	public class CourierEventArgs : System.EventArgs
	{
		private CourierColumn column;
		
		///<summary>
		/// Initalizes a new Instance of the CourierEventArgs class.
		///</summary>
		public CourierEventArgs(CourierColumn column)
		{
			this.column = column;
		}
		
		
		///<summary>
		/// The CourierColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="CourierColumn" />
		public CourierColumn Column { get { return this.column; } }
	}
	#endregion
	
	
	///<summary>
	/// Define a delegate for all Courier related events.
	///</summary>
	public delegate void CourierEventHandler(object sender, CourierEventArgs e);
	
	///<summary>
	/// An object representation of the 'Courier' table. [No description found the database]	
	///</summary>
	[Serializable, DataObject]
	[CLSCompliant(true)]
	//[ToolboxItem(typeof(Courier))]
	public abstract partial class CourierBase : EntityBase, IEntityId<CourierKey>, System.IComparable, System.ICloneable, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		/// 	Old the inner data of the entity.
		/// </summary>
		private CourierEntityData entityData;
		
		// <summary>
		// 	Old the original data of the entity.
		// </summary>
		//CourierEntityData originalData;
		
		/// <summary>
		/// 	Old a backup of the inner data of the entity.
		/// </summary>
		private CourierEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		[NonSerialized]
		private TList<Courier> parentCollection;
		private bool inTxn = false;

		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>	
		[field:NonSerialized]
		public event CourierEventHandler ColumnChanging;
		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event CourierEventHandler ColumnChanged;		
		#endregion "Variable Declarations"
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="CourierBase"/> instance.
		///</summary>
		public CourierBase()
		{
			this.entityData = new CourierEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="CourierBase"/> instance.
		///</summary>
		///<param name="courierCourierId"></param>
		///<param name="courierCourierName"></param>
		///<param name="courierCourierDescription"></param>
		///<param name="courierMinItems"></param>
		///<param name="courierMaxItems"></param>
		public CourierBase(System.Guid courierCourierId, System.String courierCourierName, System.String courierCourierDescription, 
			System.Int32 courierMinItems, System.Int32 courierMaxItems)
		{
			this.entityData = new CourierEntityData();
			this.backupData = null;

			this.CourierId = courierCourierId;
			this.CourierName = courierCourierName;
			this.CourierDescription = courierCourierDescription;
			this.MinItems = courierMinItems;
			this.MaxItems = courierMaxItems;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="Courier"/> instance.
		///</summary>
		///<param name="courierCourierId"></param>
		///<param name="courierCourierName"></param>
		///<param name="courierCourierDescription"></param>
		///<param name="courierMinItems"></param>
		///<param name="courierMaxItems"></param>
		public static Courier CreateCourier(System.Guid courierCourierId, System.String courierCourierName, System.String courierCourierDescription, 
			System.Int32 courierMinItems, System.Int32 courierMaxItems)
		{
			Courier newCourier = new Courier();
			newCourier.CourierId = courierCourierId;
			newCourier.CourierName = courierCourierName;
			newCourier.CourierDescription = courierCourierDescription;
			newCourier.MinItems = courierMinItems;
			newCourier.MaxItems = courierMaxItems;
			return newCourier;
		}
				
		#endregion Constructors
		
		
		#region Events trigger
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="CourierColumn"/> which has raised the event.</param>
		public void OnColumnChanging(CourierColumn column)
		{
			if(IsEntityTracked && EntityState != EntityState.Added)
				EntityManager.StopTracking(EntityTrackingKey);
				
			if (!SuppressEntityEvents)
			{
				CourierEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new CourierEventArgs(column));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="CourierColumn"/> which has raised the event.</param>
		public void OnColumnChanged(CourierColumn column)
		{
			if (!SuppressEntityEvents)
			{
				CourierEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new CourierEventArgs(column));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
				
		#region Properties	
				
		/// <summary>
		/// 	Gets or sets the CourierId property. 
		///		
		/// </summary>
		/// <value>This type is uniqueidentifier.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(true,false,false)]
		public virtual System.Guid CourierId
		{
			get
			{
				return this.entityData.CourierId; 
			}
			
			set
			{
				if (this.entityData.CourierId == value)
					return;
					
					
				OnColumnChanging(CourierColumn.CourierId);
				this.entityData.CourierId = value;
				this.EntityId.CourierId = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(CourierColumn.CourierId);
				OnPropertyChanged("CourierId");
			}
		}
		
		/// <summary>
		/// 	Get the original value of the CourierId property.
		///		
		/// </summary>
		/// <remarks>This is the original value of the CourierId property.</remarks>
		/// <value>This type is uniqueidentifier</value>
		[BrowsableAttribute(false)/*, XmlIgnoreAttribute()*/]
		public  virtual System.Guid OriginalCourierId
		{
			get { return this.entityData.OriginalCourierId; }
			set { this.entityData.OriginalCourierId = value; }
		}
		
		/// <summary>
		/// 	Gets or sets the CourierName property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false,false,false, 30)]
		public virtual System.String CourierName
		{
			get
			{
				return this.entityData.CourierName; 
			}
			
			set
			{
				if (this.entityData.CourierName == value)
					return;
					
					
				OnColumnChanging(CourierColumn.CourierName);
				this.entityData.CourierName = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(CourierColumn.CourierName);
				OnPropertyChanged("CourierName");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the CourierDescription property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false,false,true, 60)]
		public virtual System.String CourierDescription
		{
			get
			{
				return this.entityData.CourierDescription; 
			}
			
			set
			{
				if (this.entityData.CourierDescription == value)
					return;
					
					
				OnColumnChanging(CourierColumn.CourierDescription);
				this.entityData.CourierDescription = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(CourierColumn.CourierDescription);
				OnPropertyChanged("CourierDescription");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the MinItems property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false,false,false)]
		public virtual System.Int32 MinItems
		{
			get
			{
				return this.entityData.MinItems; 
			}
			
			set
			{
				if (this.entityData.MinItems == value)
					return;
					
					
				OnColumnChanging(CourierColumn.MinItems);
				this.entityData.MinItems = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(CourierColumn.MinItems);
				OnPropertyChanged("MinItems");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the MaxItems property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false,false,false)]
		public virtual System.Int32 MaxItems
		{
			get
			{
				return this.entityData.MaxItems; 
			}
			
			set
			{
				if (this.entityData.MaxItems == value)
					return;
					
					
				OnColumnChanging(CourierColumn.MaxItems);
				this.entityData.MaxItems = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(CourierColumn.MaxItems);
				OnPropertyChanged("MaxItems");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the Timestamp property. 
		///		
		/// </summary>
		/// <value>This type is timestamp.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false,false,false)]
		public virtual System.Byte[] Timestamp
		{
			get
			{
				return this.entityData.Timestamp; 
			}
			
			set
			{
				if (this.entityData.Timestamp == value)
					return;
					
					
				OnColumnChanging(CourierColumn.Timestamp);
				this.entityData.Timestamp = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(CourierColumn.Timestamp);
				OnPropertyChanged("Timestamp");
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
			get { return "Courier"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"CourierId", "CourierName", "CourierDescription", "MinItems", "MaxItems", "Timestamp"};
			}
		}
		#endregion 
		
	
		/// <summary>
		///	Holds a collection of Orders objects
		///	which are related to this object through the relation FK_Orders_Courier
		/// </summary>	
		[BindableAttribute()]
		public TList<Orders> OrdersCollection
		{
			get { return entityData.OrdersCollection; }
			set { entityData.OrdersCollection = value; }	
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
	            this.backupData = this.entityData.Clone() as CourierEntityData;
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
						this.parentCollection.Remove( (Courier) this ) ;
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
	            this.parentCollection = (TList<Courier>)value;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as Courier);
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
		///  Returns a Typed Courier Entity 
		///</summary>
		public virtual Courier Copy()
		{
			//shallow copy entity
			Courier copy = new Courier();
			copy.CourierId = this.CourierId;
			copy.OriginalCourierId = this.OriginalCourierId;
			copy.CourierName = this.CourierName;
			copy.CourierDescription = this.CourierDescription;
			copy.MinItems = this.MinItems;
			copy.MaxItems = this.MaxItems;
			copy.Timestamp = this.Timestamp;
					
			copy.AcceptChanges();
			return (Courier)copy;
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
		///  Returns a Typed Courier Entity which is a deep copy of the current entity.
		///</summary>
		public virtual Courier DeepCopy()
		{
			return EntityHelper.Clone<Courier>(this as Courier);	
		}
		#endregion
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="CourierBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(CourierBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="CourierBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="CourierBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="CourierBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(CourierBase Object1, CourierBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;
				
			bool equal = true;
			if (Object1.CourierId != Object2.CourierId)
				equal = false;
			if (Object1.CourierName != Object2.CourierName)
				equal = false;
			if ( Object1.CourierDescription != null && Object2.CourierDescription != null )
			{
				if (Object1.CourierDescription != Object2.CourierDescription)
					equal = false;
			}
			else if (Object1.CourierDescription == null ^ Object1.CourierDescription == null )
			{
				equal = false;
			}
			if (Object1.MinItems != Object2.MinItems)
				equal = false;
			if (Object1.MaxItems != Object2.MaxItems)
				equal = false;
			if (Object1.Timestamp != Object2.Timestamp)
				equal = false;
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
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name) .CompareTo(((CourierBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name));
		}
		
		/*
		// static method to get a Comparer object
        public static CourierComparer GetComparer()
        {
            return new CourierComparer();
        }
        */

        // Comparer delegates back to Courier
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
        public int CompareTo(Courier rhs, CourierColumn which)
        {
            switch (which)
            {
            	
            	
            	case CourierColumn.CourierId:
            		return this.CourierId.CompareTo(rhs.CourierId);
            		
            		                 
            	
            	
            	case CourierColumn.CourierName:
            		return this.CourierName.CompareTo(rhs.CourierName);
            		
            		                 
            	
            	
            	case CourierColumn.CourierDescription:
            		return this.CourierDescription.CompareTo(rhs.CourierDescription);
            		
            		                 
            	
            	
            	case CourierColumn.MinItems:
            		return this.MinItems.CompareTo(rhs.MinItems);
            		
            		                 
            	
            	
            	case CourierColumn.MaxItems:
            		return this.MaxItems.CompareTo(rhs.MaxItems);
            		
            		                 
            	
            		                 
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
				
		#region IEntityKey<CourierKey> Members
		
		// member variable for the EntityId property
		private CourierKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public CourierKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new CourierKey(this);
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
					entityTrackingKey = @"Courier" 
					+ this.CourierId.ToString();
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
				"{7}{6}- CourierId: {0}{6}- CourierName: {1}{6}- CourierDescription: {2}{6}- MinItems: {3}{6}- MaxItems: {4}{6}- Timestamp: {5}{6}", 
				this.CourierId,
				this.CourierName,
				(this.CourierDescription == null) ? string.Empty : this.CourierDescription.ToString(),
				this.MinItems,
				this.MaxItems,
				this.Timestamp,
				Environment.NewLine, 
				this.GetType());
		}
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'Courier' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal class CourierEntityData : ICloneable
	{
		#region Variable Declarations
		
		#region Primary key(s)
			/// <summary>			
			/// CourierId : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "Courier"</remarks>
			public System.Guid CourierId;
				
			/// <summary>
			/// keep a copy of the original so it can be used for editable primary keys.
			/// </summary>
			public System.Guid OriginalCourierId;
			
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// CourierName : 
		/// </summary>
		public System.String		  CourierName = string.Empty;
		
		/// <summary>
		/// CourierDescription : 
		/// </summary>
		public System.String		  CourierDescription = null;
		
		/// <summary>
		/// MinItems : 
		/// </summary>
		public System.Int32		  MinItems = (int)0;
		
		/// <summary>
		/// MaxItems : 
		/// </summary>
		public System.Int32		  MaxItems = (int)0;
		
		/// <summary>
		/// Timestamp : 
		/// </summary>
		public System.Byte[]		  Timestamp = new byte[] {};
		#endregion
			
		#endregion "Variable Declarations"
		
		public Object Clone()
		{
			CourierEntityData _tmp = new CourierEntityData();
						
			_tmp.CourierId = this.CourierId;
			_tmp.OriginalCourierId = this.OriginalCourierId;
			
			_tmp.CourierName = this.CourierName;
			_tmp.CourierDescription = this.CourierDescription;
			_tmp.MinItems = this.MinItems;
			_tmp.MaxItems = this.MaxItems;
			_tmp.Timestamp = this.Timestamp;
			
			return _tmp;
		}
		

		private TList<Orders> orders;
      public TList<Orders> OrdersCollection
      {
         get
         {
            if (orders == null)
            {
               orders = new TList<Orders>();
            }

            return orders;
         }
         set { orders = value; }
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
			ValidationRules.AddRule(Validation.CommonRules.NotNull,"CourierName");
			ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("CourierName",30));
			ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("CourierDescription",60));
			ValidationRules.AddRule(Validation.CommonRules.NotNull,"Timestamp");
		}
   		#endregion
	
	} // End Class
	
	#region CourierComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class CourierComparer : System.Collections.Generic.IComparer<Courier>
	{
		CourierColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:CourierComparer"/> class.
        /// </summary>
		public CourierComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:%=className%>Comparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public CourierComparer(CourierColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <c cref="Courier"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <c cref="Courier"/> to compare.</param>
        /// <param name="b">The second <c>Courier</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(Courier a, Courier b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(Courier entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(Courier a, Courier b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public CourierColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region CourierKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="Courier"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class CourierKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the CourierKey class.
		/// </summary>
		public CourierKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the CourierKey class.
		/// </summary>
		public CourierKey(CourierBase entity)
		{
			Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.courierId = entity.CourierId;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the CourierKey class.
		/// </summary>
		public CourierKey(System.Guid courierId)
		{
			#region Init Properties

			this.courierId = courierId;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private CourierBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public CourierBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the CourierId property
		private System.Guid courierId;
		
		/// <summary>
		/// Gets or sets the CourierId property.
		/// </summary>
		public System.Guid CourierId
		{
			get { return courierId; }
			set
			{
				if ( Entity != null )
				{
					Entity.CourierId = value;
				}
				
				courierId = value;
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
				CourierId = ( values["CourierId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["CourierId"], typeof(System.Guid)) : Guid.Empty;
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

			values.Add("CourierId", CourierId);

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("CourierId: {0}{1}",
								CourierId,
								Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	
	
	/// <summary>
	/// Enumerate the Courier columns.
	/// </summary>
	[Serializable]
	public enum CourierColumn
	{
		/// <summary>
		/// CourierId : 
		/// </summary>
		[EnumTextValue("CourierId")]
		CourierId,
		/// <summary>
		/// CourierName : 
		/// </summary>
		[EnumTextValue("CourierName")]
		CourierName,
		/// <summary>
		/// CourierDescription : 
		/// </summary>
		[EnumTextValue("CourierDescription")]
		CourierDescription,
		/// <summary>
		/// MinItems : 
		/// </summary>
		[EnumTextValue("MinItems")]
		MinItems,
		/// <summary>
		/// MaxItems : 
		/// </summary>
		[EnumTextValue("MaxItems")]
		MaxItems,
		/// <summary>
		/// Timestamp : 
		/// </summary>
		[EnumTextValue("Timestamp")]
		Timestamp
	}//End enum

} // end namespace

