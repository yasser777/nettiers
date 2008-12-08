﻿	
/*
	File generated by NetTiers templates [www.nettiers.com]
	Generated on : Monday, July 24, 2006
	Important: Do not modify this file. Edit the file Inventory.cs instead.
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
	#region InventoryEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="Inventory"/> object.
	/// </remarks>
	public class InventoryEventArgs : System.EventArgs
	{
		private InventoryColumn column;
		
		///<summary>
		/// Initalizes a new Instance of the InventoryEventArgs class.
		///</summary>
		public InventoryEventArgs(InventoryColumn column)
		{
			this.column = column;
		}
		
		
		///<summary>
		/// The InventoryColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="InventoryColumn" />
		public InventoryColumn Column { get { return this.column; } }
	}
	#endregion
	
	
	///<summary>
	/// Define a delegate for all Inventory related events.
	///</summary>
	public delegate void InventoryEventHandler(object sender, InventoryEventArgs e);
	
	///<summary>
	/// An object representation of the 'Inventory' table. [No description found the database]	
	///</summary>
	[Serializable, DataObject]
	[CLSCompliant(true)]
	//[ToolboxItem(typeof(Inventory))]
	public abstract partial class InventoryBase : EntityBase, IEntityId<InventoryKey>, System.IComparable, System.ICloneable, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		/// 	Old the inner data of the entity.
		/// </summary>
		private InventoryEntityData entityData;
		
		// <summary>
		// 	Old the original data of the entity.
		// </summary>
		//InventoryEntityData originalData;
		
		/// <summary>
		/// 	Old a backup of the inner data of the entity.
		/// </summary>
		private InventoryEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		[NonSerialized]
		private TList<Inventory> parentCollection;
		private bool inTxn = false;

		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>	
		[field:NonSerialized]
		public event InventoryEventHandler ColumnChanging;
		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event InventoryEventHandler ColumnChanged;		
		#endregion "Variable Declarations"
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="InventoryBase"/> instance.
		///</summary>
		public InventoryBase()
		{
			this.entityData = new InventoryEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="InventoryBase"/> instance.
		///</summary>
		///<param name="inventoryItemId"></param>
		///<param name="inventorySuppId"></param>
		///<param name="inventoryQty"></param>
		public InventoryBase(System.Guid inventoryItemId, System.Guid inventorySuppId, System.Int32 inventoryQty)
		{
			this.entityData = new InventoryEntityData();
			this.backupData = null;

			this.ItemId = inventoryItemId;
			this.SuppId = inventorySuppId;
			this.Qty = inventoryQty;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="Inventory"/> instance.
		///</summary>
		///<param name="inventoryItemId"></param>
		///<param name="inventorySuppId"></param>
		///<param name="inventoryQty"></param>
		public static Inventory CreateInventory(System.Guid inventoryItemId, System.Guid inventorySuppId, System.Int32 inventoryQty)
		{
			Inventory newInventory = new Inventory();
			newInventory.ItemId = inventoryItemId;
			newInventory.SuppId = inventorySuppId;
			newInventory.Qty = inventoryQty;
			return newInventory;
		}
				
		#endregion Constructors
		
		
		#region Events trigger
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="InventoryColumn"/> which has raised the event.</param>
		public void OnColumnChanging(InventoryColumn column)
		{
			if(IsEntityTracked && EntityState != EntityState.Added)
				EntityManager.StopTracking(EntityTrackingKey);
				
			if (!SuppressEntityEvents)
			{
				InventoryEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new InventoryEventArgs(column));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="InventoryColumn"/> which has raised the event.</param>
		public void OnColumnChanged(InventoryColumn column)
		{
			if (!SuppressEntityEvents)
			{
				InventoryEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new InventoryEventArgs(column));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
				
		#region Properties	
				
		/// <summary>
		/// 	Gets or sets the ItemId property. 
		///		
		/// </summary>
		/// <value>This type is uniqueidentifier.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(true,false,false)]
		public virtual System.Guid ItemId
		{
			get
			{
				return this.entityData.ItemId; 
			}
			
			set
			{
				if (this.entityData.ItemId == value)
					return;
					
					
				OnColumnChanging(InventoryColumn.ItemId);
				this.entityData.ItemId = value;
				this.EntityId.ItemId = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(InventoryColumn.ItemId);
				OnPropertyChanged("ItemId");
			}
		}
		
		/// <summary>
		/// 	Get the original value of the ItemId property.
		///		
		/// </summary>
		/// <remarks>This is the original value of the ItemId property.</remarks>
		/// <value>This type is uniqueidentifier</value>
		[BrowsableAttribute(false)/*, XmlIgnoreAttribute()*/]
		public  virtual System.Guid OriginalItemId
		{
			get { return this.entityData.OriginalItemId; }
			set { this.entityData.OriginalItemId = value; }
		}
		
		/// <summary>
		/// 	Gets or sets the SuppId property. 
		///		
		/// </summary>
		/// <value>This type is uniqueidentifier.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(true,false,false)]
		public virtual System.Guid SuppId
		{
			get
			{
				return this.entityData.SuppId; 
			}
			
			set
			{
				if (this.entityData.SuppId == value)
					return;
					
					
				OnColumnChanging(InventoryColumn.SuppId);
				this.entityData.SuppId = value;
				this.EntityId.SuppId = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(InventoryColumn.SuppId);
				OnPropertyChanged("SuppId");
			}
		}
		
		/// <summary>
		/// 	Get the original value of the SuppId property.
		///		
		/// </summary>
		/// <remarks>This is the original value of the SuppId property.</remarks>
		/// <value>This type is uniqueidentifier</value>
		[BrowsableAttribute(false)/*, XmlIgnoreAttribute()*/]
		public  virtual System.Guid OriginalSuppId
		{
			get { return this.entityData.OriginalSuppId; }
			set { this.entityData.OriginalSuppId = value; }
		}
		
		/// <summary>
		/// 	Gets or sets the Qty property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false,false,false)]
		public virtual System.Int32 Qty
		{
			get
			{
				return this.entityData.Qty; 
			}
			
			set
			{
				if (this.entityData.Qty == value)
					return;
					
					
				OnColumnChanging(InventoryColumn.Qty);
				this.entityData.Qty = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(InventoryColumn.Qty);
				OnPropertyChanged("Qty");
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
					
					
				OnColumnChanging(InventoryColumn.Timestamp);
				this.entityData.Timestamp = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(InventoryColumn.Timestamp);
				OnPropertyChanged("Timestamp");
			}
		}
		

		#region Source Foreign Key Property
				
		private Item _itemIdSource = null;
		
		/// <summary>
		/// Gets or sets the source <see cref="Item"/>.
		/// </summary>
		/// <value>The source Item for ItemId.</value>
		[Browsable(false), BindableAttribute()]
		public virtual Item ItemIdSource
      	{
            get { return this._itemIdSource; }
            set { this._itemIdSource = value; }
      	}
		private Supplier _suppIdSource = null;
		
		/// <summary>
		/// Gets or sets the source <see cref="Supplier"/>.
		/// </summary>
		/// <value>The source Supplier for SuppId.</value>
		[Browsable(false), BindableAttribute()]
		public virtual Supplier SuppIdSource
      	{
            get { return this._suppIdSource; }
            set { this._suppIdSource = value; }
      	}
		#endregion
			
		#region Table Meta Data
		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string TableName
		{
			get { return "Inventory"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"ItemId", "SuppId", "Qty", "Timestamp"};
			}
		}
		#endregion 
		
		
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
	            this.backupData = this.entityData.Clone() as InventoryEntityData;
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
						this.parentCollection.Remove( (Inventory) this ) ;
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
	            this.parentCollection = (TList<Inventory>)value;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as Inventory);
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
		///  Returns a Typed Inventory Entity 
		///</summary>
		public virtual Inventory Copy()
		{
			//shallow copy entity
			Inventory copy = new Inventory();
			copy.ItemId = this.ItemId;
			copy.OriginalItemId = this.OriginalItemId;
			copy.SuppId = this.SuppId;
			copy.OriginalSuppId = this.OriginalSuppId;
			copy.Qty = this.Qty;
			copy.Timestamp = this.Timestamp;
					
			copy.AcceptChanges();
			return (Inventory)copy;
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
		///  Returns a Typed Inventory Entity which is a deep copy of the current entity.
		///</summary>
		public virtual Inventory DeepCopy()
		{
			return EntityHelper.Clone<Inventory>(this as Inventory);	
		}
		#endregion
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="InventoryBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(InventoryBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="InventoryBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="InventoryBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="InventoryBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(InventoryBase Object1, InventoryBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;
				
			bool equal = true;
			if (Object1.ItemId != Object2.ItemId)
				equal = false;
			if (Object1.SuppId != Object2.SuppId)
				equal = false;
			if (Object1.Qty != Object2.Qty)
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
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name) .CompareTo(((InventoryBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name));
		}
		
		/*
		// static method to get a Comparer object
        public static InventoryComparer GetComparer()
        {
            return new InventoryComparer();
        }
        */

        // Comparer delegates back to Inventory
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
        public int CompareTo(Inventory rhs, InventoryColumn which)
        {
            switch (which)
            {
            	
            	
            	case InventoryColumn.ItemId:
            		return this.ItemId.CompareTo(rhs.ItemId);
            		
            		                 
            	
            	
            	case InventoryColumn.SuppId:
            		return this.SuppId.CompareTo(rhs.SuppId);
            		
            		                 
            	
            	
            	case InventoryColumn.Qty:
            		return this.Qty.CompareTo(rhs.Qty);
            		
            		                 
            	
            		                 
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
				
		#region IEntityKey<InventoryKey> Members
		
		// member variable for the EntityId property
		private InventoryKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public InventoryKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new InventoryKey(this);
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
					entityTrackingKey = @"Inventory" 
					+ this.ItemId.ToString()
					+ this.SuppId.ToString();
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
				"{5}{4}- ItemId: {0}{4}- SuppId: {1}{4}- Qty: {2}{4}- Timestamp: {3}{4}", 
				this.ItemId,
				this.SuppId,
				this.Qty,
				this.Timestamp,
				Environment.NewLine, 
				this.GetType());
		}
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'Inventory' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal class InventoryEntityData : ICloneable
	{
		#region Variable Declarations
		
		#region Primary key(s)
			/// <summary>			
			/// ItemId : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "Inventory"</remarks>
			public System.Guid ItemId;
				
			/// <summary>
			/// keep a copy of the original so it can be used for editable primary keys.
			/// </summary>
			public System.Guid OriginalItemId;
			
			/// <summary>			
			/// SuppId : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "Inventory"</remarks>
			public System.Guid SuppId;
				
			/// <summary>
			/// keep a copy of the original so it can be used for editable primary keys.
			/// </summary>
			public System.Guid OriginalSuppId;
			
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// Qty : 
		/// </summary>
		public System.Int32		  Qty = (int)0;
		
		/// <summary>
		/// Timestamp : 
		/// </summary>
		public System.Byte[]		  Timestamp = new byte[] {};
		#endregion
			
		#endregion "Variable Declarations"
		
		public Object Clone()
		{
			InventoryEntityData _tmp = new InventoryEntityData();
						
			_tmp.ItemId = this.ItemId;
			_tmp.OriginalItemId = this.OriginalItemId;
			_tmp.SuppId = this.SuppId;
			_tmp.OriginalSuppId = this.OriginalSuppId;
			
			_tmp.Qty = this.Qty;
			_tmp.Timestamp = this.Timestamp;
			
			return _tmp;
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
			ValidationRules.AddRule(Validation.CommonRules.NotNull,"Timestamp");
		}
   		#endregion
	
	} // End Class
	
	#region InventoryComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class InventoryComparer : System.Collections.Generic.IComparer<Inventory>
	{
		InventoryColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:InventoryComparer"/> class.
        /// </summary>
		public InventoryComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:%=className%>Comparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public InventoryComparer(InventoryColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <c cref="Inventory"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <c cref="Inventory"/> to compare.</param>
        /// <param name="b">The second <c>Inventory</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(Inventory a, Inventory b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(Inventory entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(Inventory a, Inventory b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public InventoryColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region InventoryKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="Inventory"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class InventoryKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the InventoryKey class.
		/// </summary>
		public InventoryKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the InventoryKey class.
		/// </summary>
		public InventoryKey(InventoryBase entity)
		{
			Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.itemId = entity.ItemId;
				this.suppId = entity.SuppId;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the InventoryKey class.
		/// </summary>
		public InventoryKey(System.Guid itemId, System.Guid suppId)
		{
			#region Init Properties

			this.itemId = itemId;
			this.suppId = suppId;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private InventoryBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public InventoryBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the ItemId property
		private System.Guid itemId;
		
		/// <summary>
		/// Gets or sets the ItemId property.
		/// </summary>
		public System.Guid ItemId
		{
			get { return itemId; }
			set
			{
				if ( Entity != null )
				{
					Entity.ItemId = value;
				}
				
				itemId = value;
			}
		}
		
		// member variable for the SuppId property
		private System.Guid suppId;
		
		/// <summary>
		/// Gets or sets the SuppId property.
		/// </summary>
		public System.Guid SuppId
		{
			get { return suppId; }
			set
			{
				if ( Entity != null )
				{
					Entity.SuppId = value;
				}
				
				suppId = value;
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
				ItemId = ( values["ItemId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["ItemId"], typeof(System.Guid)) : Guid.Empty;
				SuppId = ( values["SuppId"] != null ) ? (System.Guid) EntityUtil.ChangeType(values["SuppId"], typeof(System.Guid)) : Guid.Empty;
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

			values.Add("ItemId", ItemId);
			values.Add("SuppId", SuppId);

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("ItemId: {0}{2}SuppId: {1}{2}",
								ItemId,
								SuppId,
								Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	
	
	/// <summary>
	/// Enumerate the Inventory columns.
	/// </summary>
	[Serializable]
	public enum InventoryColumn
	{
		/// <summary>
		/// ItemId : 
		/// </summary>
		[EnumTextValue("ItemId")]
		ItemId,
		/// <summary>
		/// SuppId : 
		/// </summary>
		[EnumTextValue("SuppId")]
		SuppId,
		/// <summary>
		/// Qty : 
		/// </summary>
		[EnumTextValue("Qty")]
		Qty,
		/// <summary>
		/// Timestamp : 
		/// </summary>
		[EnumTextValue("Timestamp")]
		Timestamp
	}//End enum

} // end namespace

