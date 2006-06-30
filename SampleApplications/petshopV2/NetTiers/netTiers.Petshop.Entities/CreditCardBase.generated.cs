﻿	
/*
	File generated by NetTiers templates [www.nettiers.com]
	Generated on : Wednesday, June 28, 2006
	Important: Do not modify this file. Edit the file CreditCard.cs instead.
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
	#region CreditCardEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="CreditCard"/> object.
	/// </remarks>
	public class CreditCardEventArgs : System.EventArgs
	{
		private CreditCardColumn column;
		
		///<summary>
		/// Initalizes a new Instance of the CreditCardEventArgs class.
		///</summary>
		public CreditCardEventArgs(CreditCardColumn column)
		{
			this.column = column;
		}
		
		
		///<summary>
		/// The CreditCardColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="CreditCardColumn" />
		public CreditCardColumn Column { get { return this.column; } }
	}
	#endregion
	
	
	///<summary>
	/// Define a delegate for all CreditCard related events.
	///</summary>
	public delegate void CreditCardEventHandler(object sender, CreditCardEventArgs e);
	
	///<summary>
	/// An object representation of the 'CreditCard' table. [No description found the database]	
	///</summary>
	[Serializable, DataObject]
	[CLSCompliant(true)]
	//[ToolboxItem(typeof(CreditCard))]
	public abstract partial class CreditCardBase : EntityBase, IEntityId<CreditCardKey>, System.IComparable, System.ICloneable, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		/// 	Old the inner data of the entity.
		/// </summary>
		private CreditCardEntityData entityData;
		
		// <summary>
		// 	Old the original data of the entity.
		// </summary>
		//CreditCardEntityData originalData;
		
		/// <summary>
		/// 	Old a backup of the inner data of the entity.
		/// </summary>
		private CreditCardEntityData backupData; 
		
		/// <summary>
		/// 	Key used if Tracking is Enabled for the <see cref="EntityLocator" />.
		/// </summary>
		private string entityTrackingKey;
		
		[NonSerialized]
		private TList<CreditCard> parentCollection;
		private bool inTxn = false;

		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>	
		[field:NonSerialized]
		public event CreditCardEventHandler ColumnChanging;
		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event CreditCardEventHandler ColumnChanged;		
		#endregion "Variable Declarations"
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="CreditCardBase"/> instance.
		///</summary>
		public CreditCardBase()
		{
			this.entityData = new CreditCardEntityData();
			this.backupData = null;
		}		
		
		///<summary>
		/// Creates a new <see cref="CreditCardBase"/> instance.
		///</summary>
		///<param name="creditCardId"></param>
		///<param name="creditCardNumber"></param>
		///<param name="creditCardCardType"></param>
		///<param name="creditCardExpiryMonth"></param>
		///<param name="creditCardExpiryYear"></param>
		public CreditCardBase(System.String creditCardId, System.String creditCardNumber, System.String creditCardCardType, 
			System.String creditCardExpiryMonth, System.String creditCardExpiryYear)
		{
			this.entityData = new CreditCardEntityData();
			this.backupData = null;

			this.Id = creditCardId;
			this.Number = creditCardNumber;
			this.CardType = creditCardCardType;
			this.ExpiryMonth = creditCardExpiryMonth;
			this.ExpiryYear = creditCardExpiryYear;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="CreditCard"/> instance.
		///</summary>
		///<param name="creditCardId"></param>
		///<param name="creditCardNumber"></param>
		///<param name="creditCardCardType"></param>
		///<param name="creditCardExpiryMonth"></param>
		///<param name="creditCardExpiryYear"></param>
		public static CreditCard CreateCreditCard(System.String creditCardId, System.String creditCardNumber, System.String creditCardCardType, 
			System.String creditCardExpiryMonth, System.String creditCardExpiryYear)
		{
			CreditCard newCreditCard = new CreditCard();
			newCreditCard.Id = creditCardId;
			newCreditCard.Number = creditCardNumber;
			newCreditCard.CardType = creditCardCardType;
			newCreditCard.ExpiryMonth = creditCardExpiryMonth;
			newCreditCard.ExpiryYear = creditCardExpiryYear;
			return newCreditCard;
		}
				
		#endregion Constructors
		
		
		#region Events trigger
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="CreditCardColumn"/> which has raised the event.</param>
		public void OnColumnChanging(CreditCardColumn column)
		{
			if(IsEntityTracked && EntityState != EntityState.Added)
				EntityManager.StopTracking(EntityTrackingKey);
				
			if (!SuppressEntityEvents)
			{
				CreditCardEventHandler handler = ColumnChanging;
				if(handler != null)
				{
					handler(this, new CreditCardEventArgs(column));
				}
			}
		}
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="CreditCardColumn"/> which has raised the event.</param>
		public void OnColumnChanged(CreditCardColumn column)
		{
			if (!SuppressEntityEvents)
			{
				CreditCardEventHandler handler = ColumnChanged;
				if(handler != null)
				{
					handler(this, new CreditCardEventArgs(column));
				}
			
				// warn the parent list that i have changed
				OnEntityChanged();
			}
		} 
		#endregion
				
		#region Properties	
				
		/// <summary>
		/// 	Gets or sets the Id property. 
		///		
		/// </summary>
		/// <value>This type is char.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(true,false,false, 36)]
		public override System.String Id
		{
			get
			{
				return this.entityData.Id; 
			}
			
			set
			{
				if (this.entityData.Id == value)
					return;
					
					
				OnColumnChanging(CreditCardColumn.Id);
				this.entityData.Id = value;
				this.EntityId.Id = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(CreditCardColumn.Id);
				OnPropertyChanged("Id");
			}
		}
		
		/// <summary>
		/// 	Get the original value of the Id property.
		///		
		/// </summary>
		/// <remarks>This is the original value of the Id property.</remarks>
		/// <value>This type is char</value>
		[BrowsableAttribute(false)/*, XmlIgnoreAttribute()*/]
		public  virtual System.String OriginalId
		{
			get { return this.entityData.OriginalId; }
			set { this.entityData.OriginalId = value; }
		}
		
		/// <summary>
		/// 	Gets or sets the Number property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false,false,false, 255)]
		public virtual System.String Number
		{
			get
			{
				return this.entityData.Number; 
			}
			
			set
			{
				if (this.entityData.Number == value)
					return;
					
					
				OnColumnChanging(CreditCardColumn.Number);
				this.entityData.Number = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(CreditCardColumn.Number);
				OnPropertyChanged("Number");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the CardType property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false,false,false, 255)]
		public virtual System.String CardType
		{
			get
			{
				return this.entityData.CardType; 
			}
			
			set
			{
				if (this.entityData.CardType == value)
					return;
					
					
				OnColumnChanging(CreditCardColumn.CardType);
				this.entityData.CardType = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(CreditCardColumn.CardType);
				OnPropertyChanged("CardType");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the ExpiryMonth property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false,false,false, 255)]
		public virtual System.String ExpiryMonth
		{
			get
			{
				return this.entityData.ExpiryMonth; 
			}
			
			set
			{
				if (this.entityData.ExpiryMonth == value)
					return;
					
					
				OnColumnChanging(CreditCardColumn.ExpiryMonth);
				this.entityData.ExpiryMonth = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(CreditCardColumn.ExpiryMonth);
				OnPropertyChanged("ExpiryMonth");
			}
		}
		
		/// <summary>
		/// 	Gets or sets the ExpiryYear property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), BindableAttribute()]
		[DataObjectField(false,false,false, 255)]
		public virtual System.String ExpiryYear
		{
			get
			{
				return this.entityData.ExpiryYear; 
			}
			
			set
			{
				if (this.entityData.ExpiryYear == value)
					return;
					
					
				OnColumnChanging(CreditCardColumn.ExpiryYear);
				this.entityData.ExpiryYear = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(CreditCardColumn.ExpiryYear);
				OnPropertyChanged("ExpiryYear");
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
		public override System.Byte[] Timestamp
		{
			get
			{
				return this.entityData.Timestamp; 
			}
			
			set
			{
				if (this.entityData.Timestamp == value)
					return;
					
					
				OnColumnChanging(CreditCardColumn.Timestamp);
				this.entityData.Timestamp = value;
				if (this.EntityState == EntityState.Unchanged)
				{
					this.EntityState = EntityState.Changed;
				}
				OnColumnChanged(CreditCardColumn.Timestamp);
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
			get { return "CreditCard"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"Id", "Number", "CardType", "ExpiryMonth", "ExpiryYear", "Timestamp"};
			}
		}
		#endregion 
		
	
		/// <summary>
		///	Holds a collection of Account objects
		///	which are related to this object through the relation FK_Account_CreditCard
		/// </summary>	
		[BindableAttribute()]
		public TList<Account> AccountCollection
		{
			get { return entityData.AccountCollection; }
			set { entityData.AccountCollection = value; }	
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
	            this.backupData = this.entityData.Clone() as CreditCardEntityData;
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
						this.parentCollection.Remove( (CreditCard) this ) ;
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
	            this.parentCollection = (TList<CreditCard>)value;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!SuppressEntityEvents && !inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as CreditCard);
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
		///  Returns a Typed CreditCard Entity 
		///</summary>
		public virtual CreditCard Copy()
		{
			//shallow copy entity
			CreditCard copy = new CreditCard();
			copy.Id = this.Id;
			copy.OriginalId = this.OriginalId;
			copy.Number = this.Number;
			copy.CardType = this.CardType;
			copy.ExpiryMonth = this.ExpiryMonth;
			copy.ExpiryYear = this.ExpiryYear;
			copy.Timestamp = this.Timestamp;
					
			copy.AcceptChanges();
			return (CreditCard)copy;
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
		///  Returns a Typed CreditCard Entity which is a deep copy of the current entity.
		///</summary>
		public virtual CreditCard DeepCopy()
		{
			return EntityHelper.Clone<CreditCard>(this as CreditCard);	
		}
		#endregion
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="CreditCardBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(CreditCardBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="CreditCardBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="CreditCardBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="CreditCardBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(CreditCardBase Object1, CreditCardBase Object2)
		{
			// both are null
			if (Object1 == null && Object2 == null)
				return true;

			// one or the other is null, but not both
			if (Object1 == null ^ Object2 == null)
				return false;
				
			bool equal = true;
			if (Object1.Id != Object2.Id)
				equal = false;
			if (Object1.Number != Object2.Number)
				equal = false;
			if (Object1.CardType != Object2.CardType)
				equal = false;
			if (Object1.ExpiryMonth != Object2.ExpiryMonth)
				equal = false;
			if (Object1.ExpiryYear != Object2.ExpiryYear)
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
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name) .CompareTo(((CreditCardBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name));
		}
		
		/*
		// static method to get a Comparer object
        public static CreditCardComparer GetComparer()
        {
            return new CreditCardComparer();
        }
        */

        // Comparer delegates back to CreditCard
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
        public int CompareTo(CreditCard rhs, CreditCardColumn which)
        {
            switch (which)
            {
            	
            	
            	case CreditCardColumn.Id:
            		return this.Id.CompareTo(rhs.Id);
            		
            		                 
            	
            	
            	case CreditCardColumn.Number:
            		return this.Number.CompareTo(rhs.Number);
            		
            		                 
            	
            	
            	case CreditCardColumn.CardType:
            		return this.CardType.CompareTo(rhs.CardType);
            		
            		                 
            	
            	
            	case CreditCardColumn.ExpiryMonth:
            		return this.ExpiryMonth.CompareTo(rhs.ExpiryMonth);
            		
            		                 
            	
            	
            	case CreditCardColumn.ExpiryYear:
            		return this.ExpiryYear.CompareTo(rhs.ExpiryYear);
            		
            		                 
            	
            		                 
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
				
		#region IEntityKey<CreditCardKey> Members
		
		// member variable for the EntityId property
		private CreditCardKey _entityId;

		/// <summary>
		/// Gets or sets the EntityId property.
		/// </summary>
		[XmlIgnore]
		public CreditCardKey EntityId
		{
			get
			{
				if ( _entityId == null )
				{
					_entityId = new CreditCardKey(this);
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
					entityTrackingKey = @"CreditCard" 
					+ this.Id.ToString();
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
				"{7}{6}- Id: {0}{6}- Number: {1}{6}- CardType: {2}{6}- ExpiryMonth: {3}{6}- ExpiryYear: {4}{6}- Timestamp: {5}{6}", 
				this.Id,
				this.Number,
				this.CardType,
				this.ExpiryMonth,
				this.ExpiryYear,
				this.Timestamp,
				Environment.NewLine, 
				this.GetType());
		}
		
		#region Inner data class
		
	/// <summary>
	///		The data structure representation of the 'CreditCard' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal class CreditCardEntityData : ICloneable
	{
		#region Variable Declarations
		
		#region Primary key(s)
			/// <summary>			
			/// Id : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "CreditCard"</remarks>
			public System.String Id;
				
			/// <summary>
			/// keep a copy of the original so it can be used for editable primary keys.
			/// </summary>
			public System.String OriginalId;
			
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// Number : 
		/// </summary>
		public System.String		  Number = string.Empty;
		
		/// <summary>
		/// CardType : 
		/// </summary>
		public System.String		  CardType = string.Empty;
		
		/// <summary>
		/// ExpiryMonth : 
		/// </summary>
		public System.String		  ExpiryMonth = string.Empty;
		
		/// <summary>
		/// ExpiryYear : 
		/// </summary>
		public System.String		  ExpiryYear = string.Empty;
		
		/// <summary>
		/// Timestamp : 
		/// </summary>
		public System.Byte[]		  Timestamp = new byte[] {};
		#endregion
			
		#endregion "Variable Declarations"
		
		public Object Clone()
		{
			CreditCardEntityData _tmp = new CreditCardEntityData();
						
			_tmp.Id = this.Id;
			_tmp.OriginalId = this.OriginalId;
			
			_tmp.Number = this.Number;
			_tmp.CardType = this.CardType;
			_tmp.ExpiryMonth = this.ExpiryMonth;
			_tmp.ExpiryYear = this.ExpiryYear;
			_tmp.Timestamp = this.Timestamp;
			
			return _tmp;
		}
		

		private TList<Account> account;
      public TList<Account> AccountCollection
      {
         get
         {
            if (account == null)
            {
               account = new TList<Account>();
            }

            return account;
         }
         set { account = value; }
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
			ValidationRules.AddRule(Validation.CommonRules.NotNull,"Id");
			ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("Id",36));
			ValidationRules.AddRule(Validation.CommonRules.NotNull,"Number");
			ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("Number",255));
			ValidationRules.AddRule(Validation.CommonRules.NotNull,"CardType");
			ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("CardType",255));
			ValidationRules.AddRule(Validation.CommonRules.NotNull,"ExpiryMonth");
			ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("ExpiryMonth",255));
			ValidationRules.AddRule(Validation.CommonRules.NotNull,"ExpiryYear");
			ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("ExpiryYear",255));
			ValidationRules.AddRule(Validation.CommonRules.NotNull,"Timestamp");
		}
   		#endregion
	
	} // End Class
	
	#region CreditCardComparer
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class CreditCardComparer : System.Collections.Generic.IComparer<CreditCard>
	{
		CreditCardColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:CreditCardComparer"/> class.
        /// </summary>
		public CreditCardComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:%=className%>Comparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public CreditCardComparer(CreditCardColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <c cref="CreditCard"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <c cref="CreditCard"/> to compare.</param>
        /// <param name="b">The second <c>CreditCard</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(CreditCard a, CreditCard b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(CreditCard entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(CreditCard a, CreditCard b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public CreditCardColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	#region CreditCardKey Class

	/// <summary>
	/// Wraps the unique identifier values for the <see cref="CreditCard"/> object.
	/// </summary>
	[Serializable]
	[CLSCompliant(true)]
	public class CreditCardKey : EntityKeyBase
	{
		#region Constructors
		
		/// <summary>
		/// Initializes a new instance of the CreditCardKey class.
		/// </summary>
		public CreditCardKey()
		{
		}
		
		/// <summary>
		/// Initializes a new instance of the CreditCardKey class.
		/// </summary>
		public CreditCardKey(CreditCardBase entity)
		{
			Entity = entity;

			#region Init Properties

			if ( entity != null )
			{
				this.id = entity.Id;
			}

			#endregion
		}
		
		/// <summary>
		/// Initializes a new instance of the CreditCardKey class.
		/// </summary>
		public CreditCardKey(System.String id)
		{
			#region Init Properties

			this.id = id;

			#endregion
		}
		
		#endregion Constructors

		#region Properties
		
		// member variable for the Entity property
		private CreditCardBase _entity;
		
		/// <summary>
		/// Gets or sets the Entity property.
		/// </summary>
		public CreditCardBase Entity
		{
			get { return _entity; }
			set { _entity = value; }
		}
		
		// member variable for the Id property
		private System.String id;
		
		/// <summary>
		/// Gets or sets the Id property.
		/// </summary>
		public System.String Id
		{
			get { return id; }
			set
			{
				if ( Entity != null )
				{
					Entity.Id = value;
				}
				
				id = value;
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

			Id = (System.String) EntityUtil.ChangeType(values["Id"], typeof(System.String));

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

			values.Add("Id", Id);

			#endregion Init Dictionary

			return values;
		}
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return String.Format("Id: {0}{1}",
								Id,
								Environment.NewLine);
		}

		#endregion Methods
	}
	
	#endregion	
	
	/// <summary>
	/// Enumerate the CreditCard columns.
	/// </summary>
	[Serializable]
	public enum CreditCardColumn
	{
		/// <summary>
		/// Id : 
		/// </summary>
		[EnumTextValue("Id")]
		Id,
		/// <summary>
		/// Number : 
		/// </summary>
		[EnumTextValue("Number")]
		Number,
		/// <summary>
		/// CardType : 
		/// </summary>
		[EnumTextValue("CardType")]
		CardType,
		/// <summary>
		/// ExpiryMonth : 
		/// </summary>
		[EnumTextValue("ExpiryMonth")]
		ExpiryMonth,
		/// <summary>
		/// ExpiryYear : 
		/// </summary>
		[EnumTextValue("ExpiryYear")]
		ExpiryYear,
		/// <summary>
		/// Timestamp : 
		/// </summary>
		[EnumTextValue("Timestamp")]
		Timestamp
	}//End enum

} // end namespace


