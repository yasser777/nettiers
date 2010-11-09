﻿
/*
	File generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file Inventory.cs instead.
*/

#region using directives
using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using PetShop.Business.Validation;
#endregion

namespace PetShop.Business
{
	///<summary>
	/// An object representation of the 'Inventory' table. [No description found the database]	
	///</summary>
	[Serializable]
	[DataObject, CLSCompliant(true)]
	public abstract partial class InventoryBase : EntityBase, IInventory, IEntityId<InventoryKey>, System.IComparable, System.ICloneable, ICloneableEx, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		///  Hold the inner data of the entity.
		/// </summary>
		private InventoryEntityData entityData;
		
		/// <summary>
		/// 	Hold the original data of the entity, as loaded from the repository.
		/// </summary>
		private InventoryEntityData _originalData;
		
		/// <summary>
		/// 	Hold a backup of the inner data of the entity.
		/// </summary>
		private InventoryEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		/// <summary>
		/// 	Hold the parent TList&lt;entity&gt; in which this entity maybe contained.
		/// </summary>
		/// <remark>Mostly used for databinding</remark>
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
		
		#endregion Variable Declarations
		
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
		///<param name="_itemId"></param>
		///<param name="_qty"></param>
		public InventoryBase(string _itemId, int _qty)
		{
			this.entityData = new InventoryEntityData();
			this.backupData = null;

			this.ItemId = _itemId;
			this.Qty = _qty;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="Inventory"/> instance.
		///</summary>
		///<param name="_itemId"></param>
		///<param name="_qty"></param>
		public static Inventory CreateInventory(string _itemId, int _qty)
		{
			Inventory newInventory = new Inventory();
			newInventory.ItemId = _itemId;
			newInventory.Qty = _qty;
			return newInventory;
		}
				
		#endregion Constructors
			
		#region Properties	
		
		#region Data Properties		
		/// <summary>
		/// 	Gets or sets the ItemId property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>




		[DescriptionAttribute(@""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(true, false, false, 10)]
		public virtual string ItemId
		{
			get
			{
				return this.entityData.ItemId; 
			}
			
			set
			{
				if (this.entityData.ItemId == value)
					return;
					
				OnColumnChanging(InventoryColumn.ItemId, this.entityData.ItemId);
				this.entityData.ItemId = value;
				this.EntityId.ItemId = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(InventoryColumn.ItemId, this.entityData.ItemId);
				OnPropertyChanged("ItemId");
			}
		}
		
		/// <summary>
		/// 	Get the original value of the ItemId property.
		///		
		/// </summary>
		/// <remarks>This is the original value of the ItemId property.</remarks>
		/// <value>This type is varchar</value>
		[BrowsableAttribute(false)/*, XmlIgnoreAttribute()*/]
		public  virtual string OriginalItemId
		{
			get { return this.entityData.OriginalItemId; }
			set { this.entityData.OriginalItemId = value; }
		}
		
		/// <summary>
		/// 	Gets or sets the Qty property. 
		///		
		/// </summary>
		/// <value>This type is int.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>




		[DescriptionAttribute(@""), System.ComponentModel.Bindable( System.ComponentModel.BindableSupport.Yes)]
		[DataObjectField(false, false, false)]
		public virtual int Qty
		{
			get
			{
				return this.entityData.Qty; 
			}
			
			set
			{
				if (this.entityData.Qty == value)
					return;
					
				OnColumnChanging(InventoryColumn.Qty, this.entityData.Qty);
				this.entityData.Qty = value;
				if (this.EntityState == EntityState.Unchanged)
					this.EntityState = EntityState.Changed;
				OnColumnChanged(InventoryColumn.Qty, this.entityData.Qty);
				OnPropertyChanged("Qty");
			}
		}
		
		#endregion Data Properties		

		#region Source Foreign Key Property
				
		#endregion
		
		#region Children Collections
		#endregion Children Collections
		
		#endregion
		#region Validation
		
		/// <summary>
		/// Assigns validation rules to this object based on model definition.
		/// </summary>
		/// <remarks>This method overrides the base class to add schema related validation.</remarks>
		protected override void AddValidationRules()
		{
			//Validation rules based on database schema.
			ValidationRules.AddRule( CommonRules.NotNull,
				new ValidationRuleArgs("ItemId", "Item Id"));
			ValidationRules.AddRule( CommonRules.StringMaxLength, 
				new CommonRules.MaxLengthRuleArgs("ItemId", "Item Id", 10));
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
				return new string[] {"ItemId", "Qty"};
			}
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
        /// Gets or sets the parent collection of this current entity, if available.
        /// </summary>
        /// <value>The parent collection.</value>
	    [XmlIgnore]
		[Browsable(false)]
	    public override object ParentCollection
	    {
	        get 
	        {
	            return this.parentCollection;
	        }
	        set 
	        {
	            this.parentCollection = value as TList<Inventory>;
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
		
		#region ICloneable Members
		///<summary>
		///  Returns a Typed Inventory Entity 
		///</summary>
		protected virtual Inventory Copy(IDictionary existingCopies)
		{
			if (existingCopies == null)
			{
				// This is the root of the tree to be copied!
				existingCopies = new Hashtable();
			}

			//shallow copy entity
			Inventory copy = new Inventory();
			existingCopies.Add(this, copy);
			copy.SuppressEntityEvents = true;
				copy.ItemId = this.ItemId;
					copy.OriginalItemId = this.OriginalItemId;
				copy.Qty = this.Qty;
			
		
			copy.EntityState = this.EntityState;
			copy.SuppressEntityEvents = false;
			return copy;
		}		
		
		
		
		///<summary>
		///  Returns a Typed Inventory Entity 
		///</summary>
		public virtual Inventory Copy()
		{
			return this.Copy(null);	
		}
		
		///<summary>
		/// ICloneable.Clone() Member, returns the Shallow Copy of this entity.
		///</summary>
		public object Clone()
		{
			return this.Copy(null);
		}
		
		///<summary>
		/// ICloneableEx.Clone() Member, returns the Shallow Copy of this entity.
		///</summary>
		public object Clone(IDictionary existingCopies)
		{
			return this.Copy(existingCopies);
		}
		
		///<summary>
		/// Returns a deep copy of the child collection object passed in.
		///</summary>
		public static object MakeCopyOf(object x)
		{
			if (x == null)
				return null;
				
			if (x is ICloneable)
			{
				// Return a deep copy of the object
				return ((ICloneable)x).Clone();
			}
			else
				throw new System.NotSupportedException("Object Does Not Implement the ICloneable Interface.");
		}
		
		///<summary>
		/// Returns a deep copy of the child collection object passed in.
		///</summary>
		public static object MakeCopyOf(object x, IDictionary existingCopies)
		{
			if (x == null)
				return null;
			
			if (x is ICloneableEx)
			{
				// Return a deep copy of the object
				return ((ICloneableEx)x).Clone(existingCopies);
			}
			else if (x is ICloneable)
			{
				// Return a deep copy of the object
				return ((ICloneable)x).Clone();
			}
			else
				throw new System.NotSupportedException("Object Does Not Implement the ICloneable or IClonableEx Interface.");
		}
		
		
		///<summary>
		///  Returns a Typed Inventory Entity which is a deep copy of the current entity.
		///</summary>
		public virtual Inventory DeepCopy()
		{
			return EntityHelper.Clone<Inventory>(this as Inventory);	
		}
		#endregion
		
		#region Methods	
			
		///<summary>
		/// Revert all changes and restore original values.
		///</summary>
		public override void CancelChanges()
		{
			IEditableObject obj = (IEditableObject) this;
			obj.CancelEdit();

			this.entityData = null;
			if (this._originalData != null)
			{
				this.entityData = this._originalData.Clone() as InventoryEntityData;
			}
			else
			{
				//Since this had no _originalData, then just reset the entityData with a new one.  entityData cannot be null.
				this.entityData = new InventoryEntityData();
			}
		}	
		
		/// <summary>
		/// Accepts the changes made to this object.
		/// </summary>
		/// <remarks>
		/// After calling this method, properties: IsDirty, IsNew are false. IsDeleted flag remains unchanged as it is handled by the parent List.
		/// </remarks>
		public override void AcceptChanges()
		{
			base.AcceptChanges();

			// we keep of the original version of the data
			this._originalData = null;
			this._originalData = this.entityData.Clone() as InventoryEntityData;
		}
		
		#region Comparision with original data
		
		/// <summary>
		/// Determines whether the property value has changed from the original data.
		/// </summary>
		/// <param name="column">The column.</param>
		/// <returns>
		/// 	<c>true</c> if the property value has changed; otherwise, <c>false</c>.
		/// </returns>
		public bool IsPropertyChanged(InventoryColumn column)
		{
			switch(column)
			{
					case InventoryColumn.ItemId:
					return entityData.ItemId != _originalData.ItemId;
					case InventoryColumn.Qty:
					return entityData.Qty != _originalData.Qty;
			
				default:
					return false;
			}
		}
		
		/// <summary>
		/// Determines whether the property value has changed from the original data.
		/// </summary>
		/// <param name="columnName">The column name.</param>
		/// <returns>
		/// 	<c>true</c> if the property value has changed; otherwise, <c>false</c>.
		/// </returns>
		public override bool IsPropertyChanged(string columnName)
		{
			return 	IsPropertyChanged(EntityHelper.GetEnumValue< InventoryColumn >(columnName));
		}
		
		/// <summary>
		/// Determines whether the data has changed from original.
		/// </summary>
		/// <returns>
		/// 	<c>true</c> if data has changed; otherwise, <c>false</c>.
		/// </returns>
		public bool HasDataChanged()
		{
			bool result = false;
			result = result || entityData.ItemId != _originalData.ItemId;
			result = result || entityData.Qty != _originalData.Qty;
			return result;
		}	
		
		///<summary>
		///  Returns a Inventory Entity with the original data.
		///</summary>
		public Inventory GetOriginalEntity()
		{
			if (_originalData != null)
				return CreateInventory(
				_originalData.ItemId,
				_originalData.Qty
				);
				
			return (Inventory)this.Clone();
		}
		#endregion
	
	#region Value Semantics Instance Equality
        ///<summary>
        /// Returns a value indicating whether this instance is equal to a specified object using value semantics.
        ///</summary>
        ///<param name="Object1">An object to compare to this instance.</param>
        ///<returns>true if Object1 is a <see cref="InventoryBase"/> and has the same value as this instance; otherwise, false.</returns>
        public override bool Equals(object Object1)
        {
			// Cast exception if Object1 is null or DbNull
			if (Object1 != null && Object1 != DBNull.Value && Object1 is InventoryBase)
				return ValueEquals(this, (InventoryBase)Object1);
			else
				return false;
        }

        /// <summary>
		/// Serves as a hash function for a particular type, suitable for use in hashing algorithms and data structures like a hash table.
        /// Provides a hash function that is appropriate for <see cref="InventoryBase"/> class 
        /// and that ensures a better distribution in the hash table
        /// </summary>
        /// <returns>number (hash code) that corresponds to the value of an object</returns>
        public override int GetHashCode()
        {
			return this.ItemId.GetHashCode() ^ 
					this.Qty.GetHashCode();
        }
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object using value semantics.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="InventoryBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(InventoryBase toObject)
		{
			if (toObject == null)
				return false;
			return ValueEquals(this, toObject);
		}
		#endregion
		
		///<summary>
		/// Determines whether the specified <see cref="InventoryBase"/> instances are considered equal using value semantics.
		///</summary>
		///<param name="Object1">The first <see cref="InventoryBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="InventoryBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool ValueEquals(InventoryBase Object1, InventoryBase Object2)
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
			if (Object1.Qty != Object2.Qty)
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
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0]) .CompareTo(((InventoryBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0]));
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
		public virtual void Dispose()
		{
			this.parentCollection = null;
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
		public virtual InventoryKey EntityId
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
		
		#region EntityState
		/// <summary>
		///		Indicates state of object
		/// </summary>
		/// <remarks>0=Unchanged, 1=Added, 2=Changed</remarks>
		[BrowsableAttribute(false) , XmlIgnoreAttribute()]
		public override EntityState EntityState 
		{ 
			get{ return entityData.EntityState;	 } 
			set{ entityData.EntityState = value; } 
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
					entityTrackingKey = new System.Text.StringBuilder("Inventory")
					.Append("|").Append( this.ItemId.ToString()).ToString();
				return entityTrackingKey;
			}
			set
		    {
		        if (value != null)
                    entityTrackingKey = value;
		    }
		}
		#endregion 
		
		#region ToString Method
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return string.Format(System.Globalization.CultureInfo.InvariantCulture,
				"{3}{2}- ItemId: {0}{2}- Qty: {1}{2}{4}", 
				this.ItemId,
				this.Qty,
				System.Environment.NewLine, 
				this.GetType(),
				this.Error.Length == 0 ? string.Empty : string.Format("- Error: {0}\n",this.Error));
		}
		
		#endregion ToString Method
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'Inventory' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal protected class InventoryEntityData : ICloneable, ICloneableEx
	{
		#region Variable Declarations
		private EntityState currentEntityState = EntityState.Added;
		
		#region Primary key(s)
		/// <summary>			
		/// ItemId : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "Inventory"</remarks>
		public string ItemId;
			
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		public string OriginalItemId;
		
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// Qty : 
		/// </summary>
		public int		  Qty = (int)0;
		#endregion
			
		#region Source Foreign Key Property
				
		#endregion
		#endregion Variable Declarations
	
		#region Data Properties

		#endregion Data Properties
		
		#region Clone Method

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public Object Clone()
		{
			InventoryEntityData _tmp = new InventoryEntityData();
						
			_tmp.ItemId = this.ItemId;
			_tmp.OriginalItemId = this.OriginalItemId;
			
			_tmp.Qty = this.Qty;
			
			#region Source Parent Composite Entities
			#endregion
		
			#region Child Collections
			#endregion Child Collections
			
			//EntityState
			_tmp.EntityState = this.EntityState;
			
			return _tmp;
		}
		
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		public object Clone(IDictionary existingCopies)
		{
			if (existingCopies == null)
				existingCopies = new Hashtable();
				
			InventoryEntityData _tmp = new InventoryEntityData();
						
			_tmp.ItemId = this.ItemId;
			_tmp.OriginalItemId = this.OriginalItemId;
			
			_tmp.Qty = this.Qty;
			
			#region Source Parent Composite Entities
			#endregion
		
			#region Child Collections
			#endregion Child Collections
			
			//EntityState
			_tmp.EntityState = this.EntityState;
			
			return _tmp;
		}
		
		#endregion Clone Method
		
		/// <summary>
		///		Indicates state of object
		/// </summary>
		/// <remarks>0=Unchanged, 1=Added, 2=Changed</remarks>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public EntityState	EntityState
		{
			get { return currentEntityState;  }
			set { currentEntityState = value; }
		}
	
	}//End struct











		#endregion
		
				
		
		#region Events trigger
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="InventoryColumn"/> which has raised the event.</param>
		public virtual void OnColumnChanging(InventoryColumn column)
		{
			OnColumnChanging(column, null);
			return;
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="InventoryColumn"/> which has raised the event.</param>
		public virtual void OnColumnChanged(InventoryColumn column)
		{
			OnColumnChanged(column, null);
			return;
		} 
		
		
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="InventoryColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public virtual void OnColumnChanging(InventoryColumn column, object value)
		{
			if(IsEntityTracked && EntityState != EntityState.Added && !EntityManager.TrackChangedEntities)
				EntityManager.StopTracking(entityTrackingKey);
				
			if (!SuppressEntityEvents)
			{
				InventoryEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new InventoryEventArgs(column, value));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="InventoryColumn"/> which has raised the event.</param>
		/// <param name="value">The changed value.</param>
		public virtual void OnColumnChanged(InventoryColumn column, object value)
		{
			if (!SuppressEntityEvents)
			{
				InventoryEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new InventoryEventArgs(column, value));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
			
	} // End Class
	
	
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
		private object value;
		
		///<summary>
		/// Initalizes a new Instance of the InventoryEventArgs class.
		///</summary>
		public InventoryEventArgs(InventoryColumn column)
		{
			this.column = column;
		}
		
		///<summary>
		/// Initalizes a new Instance of the InventoryEventArgs class.
		///</summary>
		public InventoryEventArgs(InventoryColumn column, object value)
		{
			this.column = column;
			this.value = value;
		}
		
		///<summary>
		/// The InventoryColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="InventoryColumn" />
		public InventoryColumn Column { get { return this.column; } }
		
		/// <summary>
        /// Gets the current value of the column.
        /// </summary>
        /// <value>The current value of the column.</value>
		public object Value{ get { return this.value; } }

	}
	#endregion
	
	///<summary>
	/// Define a delegate for all Inventory related events.
	///</summary>
	public delegate void InventoryEventHandler(object sender, InventoryEventArgs e);
	
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
        /// Initializes a new instance of the <see cref="T:InventoryComparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public InventoryComparer(InventoryColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <see cref="Inventory"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <see cref="Inventory"/> to compare.</param>
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
			this.Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.ItemId = entity.ItemId;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the InventoryKey class.
		/// </summary>
		public InventoryKey(string _itemId)
		{
			#region Init Properties

			this.ItemId = _itemId;

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
		private string _itemId;
		
		/// <summary>
		/// Gets or sets the ItemId property.
		/// </summary>
		public string ItemId
		{
			get { return _itemId; }
			set
			{
				if ( this.Entity != null )
					this.Entity.ItemId = value;
				
				_itemId = value;
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
				ItemId = ( values["ItemId"] != null ) ? (string) EntityUtil.ChangeType(values["ItemId"], typeof(string)) : string.Empty;
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

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("ItemId: {0}{1}",
								ItemId,
								System.Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	

	#region InventoryColumn Enum
	
	/// <summary>
	/// Enumerate the Inventory columns.
	/// </summary>
	[Serializable]
	public enum InventoryColumn : int
	{
		/// <summary>
		/// ItemId : 
		/// </summary>
		[EnumTextValue("ItemId")]
		[ColumnEnum("ItemId", typeof(string), System.Data.DbType.AnsiString, true, false, false, 10)]
		ItemId = 1,
		/// <summary>
		/// Qty : 
		/// </summary>
		[EnumTextValue("Qty")]
		[ColumnEnum("Qty", typeof(int), System.Data.DbType.Int32, false, false, false)]
		Qty = 2
	}//End enum

	#endregion InventoryColumn Enum

} // end namespace
