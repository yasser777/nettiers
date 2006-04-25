﻿	
/*
	File generated by NetTiers templates [www.nettiers.com]
	Generated on : mercredi 15 mars 2006
	Important: Do not modify this file. Edit the file Category.cs instead.
*/

#region using directives

using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;
using System.Runtime.Serialization;

#endregion

namespace netTiers.PetShop
{
	#region CategoryEventArgs class
	/// <summary>
	/// Provides data for the ColumnChanging and ColumnChanged events.
	/// </summary>
	/// <remarks>
	/// The ColumnChanging and ColumnChanged events occur when a change is made to the value 
	/// of a property of a <see cref="Category"/> object.
	/// </remarks>
	public class CategoryEventArgs : System.EventArgs
	{
		private CategoryColumn column;
		
		///<summary>
		/// Initalizes a new Instance of the CategoryEventArgs class.
		///</summary>
		public CategoryEventArgs(CategoryColumn column)
		{
			this.column = column;
		}
		
		
		///<summary>
		/// The CategoryColumn that was modified, which has raised the event.
		///</summary>
		///<value cref="CategoryColumn" />
		public CategoryColumn Column { get { return this.column; } }
	}
	#endregion
	
	
	///<summary>
	/// Define a delegate for all Category related events.
	///</summary>
	public delegate void CategoryEventHandler(object sender, CategoryEventArgs e);
			
	[Serializable]
	[CLSCompliant(true)]
	//[ToolboxItem(typeof(Category))]
	public abstract partial class CategoryBase : EntityBase, System.IComparable, System.ICloneable, IEditableObject, IComponent, INotifyPropertyChanged
	{		
		#region Variable Declarations
		
		/// <summary>
		/// 	Old the inner data of the entity.
		/// </summary>
		private CategoryData entityData;
		
		// <summary>
		// 	Old the original data of the entity.
		// </summary>
		//CategoryData originalData;
		
		/// <summary>
		/// 	Old a backup of the inner data of the entity.
		/// </summary>
		private CategoryData backupData; 
		
		[NonSerialized]
		private TList<Category> parentCollection;
		private bool inTxn = false;

		
		/// <summary>
		/// Occurs when a value is being changed for the specified column.
		/// </summary>	
		[field:NonSerialized]
		public event CategoryEventHandler ColumnChanging;
		
		
		/// <summary>
		/// Occurs after a value has been changed for the specified column.
		/// </summary>
		[field:NonSerialized]
		public event CategoryEventHandler ColumnChanged;		
		#endregion "Variable Declarations"
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="CategoryBase"/> instance.
		///</summary>
		public CategoryBase()
		{
			this.entityData = new CategoryData();
			this.backupData = null;
			
			AddValidationRules();
		}		
		
		///<summary>
		/// Creates a new <see cref="CategoryBase"/> instance.
		///</summary>
		///<param name="categoryId"></param>
		///<param name="categoryName"></param>
		///<param name="categoryAdvicePhoto"></param>
		public CategoryBase(System.String categoryId, System.String categoryName, System.String categoryAdvicePhoto)
		{
			this.entityData = new CategoryData();
			this.backupData = null;
			
			AddValidationRules();
			
			this.Id = categoryId;
			this.Name = categoryName;
			this.AdvicePhoto = categoryAdvicePhoto;
		}
		
		///<summary>
		/// A simple factory method to create a new <see cref="Category"/> instance.
		///</summary>
		///<param name="categoryId"></param>
		///<param name="categoryName"></param>
		///<param name="categoryAdvicePhoto"></param>
		public static Category CreateCategory(System.String categoryId, System.String categoryName, System.String categoryAdvicePhoto)
		{
			Category newCategory = new Category();
			newCategory.Id = categoryId;
			newCategory.Name = categoryName;
			newCategory.AdvicePhoto = categoryAdvicePhoto;
			return newCategory;
		}
				
		#endregion Constructors
		
		#region Events trigger
		/// <summary>
		/// Raises the <see cref="ColumnChanging" /> event.
		/// </summary>
		/// <param name="column">The <see cref="CategoryColumn"/> which has raised the event.</param>
		public void OnColumnChanging(CategoryColumn column)
		{
			CategoryEventHandler handler = ColumnChanging;
			if(handler != null)
			{
				handler(this, new CategoryEventArgs(column));
			}
	
		}
		
		
		/// <summary>
		/// Raises the <see cref="ColumnChanged" /> event.
		/// </summary>
		/// <param name="column">The <see cref="CategoryColumn"/> which has raised the event.</param>
		public void OnColumnChanged(CategoryColumn column)
		{
			CategoryEventHandler handler = ColumnChanged;
			if(handler != null)
			{
				handler(this, new CategoryEventArgs(column));
			}
			
			// warn the parent list that i have changed
			OnEntityChanged();
	
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
		public override System.String Id
		{
			get
			{
				return this.entityData.Id; 
			}
			
			set
			{
				//if ( value == null )
				//	throw new ArgumentNullException("value", "Id does not allow null values.");
				if (this.entityData.Id == value)
					return;
					
				//if (value.Length > 36)
				//{
    			//	throw new ArgumentOutOfRangeException("Id", "Id maximum length is 36.");
				//}
					
				OnColumnChanging(CategoryColumn.Id);
				this.entityData.Id = value;
				//this._isDirty = true;
				if (this.state == EntityState.Unchanged)
				{
					this.state = EntityState.Changed;
				}
				OnColumnChanged(CategoryColumn.Id);
				OnPropertyChanged(CategoryColumn.Id.ToString());
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
		/// 	Gets or sets the Name property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can not be set to null. 
		/// </remarks>
		/// <exception cref="ArgumentNullException">If you attempt to set to null.</exception>
		[DescriptionAttribute(""), BindableAttribute()]
		public virtual System.String Name
		{
			get
			{
				return this.entityData.Name; 
			}
			
			set
			{
				//if ( value == null )
				//	throw new ArgumentNullException("value", "Name does not allow null values.");
				if (this.entityData.Name == value)
					return;
					
				//if (value.Length > 255)
				//{
    			//	throw new ArgumentOutOfRangeException("Name", "Name maximum length is 255.");
				//}
					
				OnColumnChanging(CategoryColumn.Name);
				this.entityData.Name = value;
				//this._isDirty = true;
				if (this.state == EntityState.Unchanged)
				{
					this.state = EntityState.Changed;
				}
				OnColumnChanged(CategoryColumn.Name);
				OnPropertyChanged(CategoryColumn.Name.ToString());
			}
		}
		
		/// <summary>
		/// 	Gets or sets the AdvicePhoto property. 
		///		
		/// </summary>
		/// <value>This type is varchar.</value>
		/// <remarks>
		/// This property can be set to null. 
		/// </remarks>
		[DescriptionAttribute(""), BindableAttribute()]
		public virtual System.String AdvicePhoto
		{
			get
			{
				return this.entityData.AdvicePhoto; 
			}
			
			set
			{
				if (this.entityData.AdvicePhoto == value)
					return;
					
				//if (value != null &&value.Length > 255)
				//{
    			//	throw new ArgumentOutOfRangeException("AdvicePhoto", "AdvicePhoto maximum length is 255.");
				//}
					
				OnColumnChanging(CategoryColumn.AdvicePhoto);
				this.entityData.AdvicePhoto = value;
				//this._isDirty = true;
				if (this.state == EntityState.Unchanged)
				{
					this.state = EntityState.Changed;
				}
				OnColumnChanged(CategoryColumn.AdvicePhoto);
				OnPropertyChanged(CategoryColumn.AdvicePhoto.ToString());
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
		public virtual System.Byte[] Timestamp
		{
			get
			{
				return this.entityData.Timestamp; 
			}
			
			set
			{
				//if ( value == null )
				//	throw new ArgumentNullException("value", "Timestamp does not allow null values.");
				if (this.entityData.Timestamp == value)
					return;
					
				//if (value.Length > 8)
				//{
    			//	throw new ArgumentOutOfRangeException("Timestamp", "Timestamp maximum length is 8.");
				//}
					
				OnColumnChanging(CategoryColumn.Timestamp);
				this.entityData.Timestamp = value;
				//this._isDirty = true;
				if (this.state == EntityState.Unchanged)
				{
					this.state = EntityState.Changed;
				}
				OnColumnChanged(CategoryColumn.Timestamp);
				OnPropertyChanged(CategoryColumn.Timestamp.ToString());
			}
		}
		

		#region "Source Foreign Key Property"
				
		#endregion
			

		/// <summary>
		///		The name of the underlying database table.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string TableName
		{
			get { return "Category"; }
		}
		
		/// <summary>
		///		The name of the underlying database table's columns.
		/// </summary>
		[BrowsableAttribute(false), XmlIgnoreAttribute()]
		public override string[] TableColumns
		{
			get
			{
				return new string[] {"Id", "Name", "AdvicePhoto", "Timestamp"};
			}
		}

		private TList<Account> _AccountCollection = new TList<Account>();
		
		/// <summary>
		///	Holds a collection of Account objects
		///	which are related to this object through the relation FK_Account_Category
		/// </summary>	
		public TList<Account> AccountCollection
		{
			get { return _AccountCollection; }
			set { _AccountCollection = value; }	
		}

		private TList<Product> _ProductCollection = new TList<Product>();
		
		/// <summary>
		///	Holds a collection of Product objects
		///	which are related to this object through the relation FK_Product_Category
		/// </summary>	
		public TList<Product> ProductCollection
		{
			get { return _ProductCollection; }
			set { _ProductCollection = value; }	
		}
		
		#endregion
		
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
            CancelAddNewEventHandler handler = CancelAddNew ;
            if (handler != null)
            {    
                handler(this, EventArgs.Empty) ;
            }
        }

		
		#region IEditableObject
		
		
		/// <summary>
		/// Begins an edit on an object.
		/// </summary>
		void IEditableObject.BeginEdit() 
	    {
	        //Console.WriteLine("Start BeginEdit");
	        if (!inTxn) 
	        {
	            this.backupData = this.entityData.Clone() as CategoryData;
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
	        	//if (this.state == EntityState.Added)
	        	{
					if (this.parentCollection != null)
						this.parentCollection.Remove( (Category) this ) ;
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
						this.state = EntityState.Added ;
						this.bindingIsNew = false ;
					}
					else
						if (this.EntityState == EntityState.Unchanged) this.state = EntityState.Changed ;
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
	            this.parentCollection = (TList<Category>)value;
	        }
	    }
	    
	    /// <summary>
        /// Called when the entity is changed.
        /// </summary>
	    private void OnEntityChanged() 
	    {
	        if (!inTxn && this.parentCollection != null) 
	        {
	            this.parentCollection.EntityChanged(this as Category);
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
		///  Returns a Typed CategoryBase Entity 
		///</summary>
		public virtual CategoryBase Copy()
		{
			//shallow copy entity
			Category copy = new Category();
			copy.Id = this.Id;
			copy.OriginalId = this.OriginalId;
			copy.Name = this.Name;
			copy.AdvicePhoto = this.AdvicePhoto;
			copy.Timestamp = this.Timestamp;
					
			copy.AcceptChanges();
			return (Category)copy;
		}
		
		///<summary>
		/// ICloneable.Clone() Member, returns the Deep Copy of this entity.
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
		#endregion
		
		
		///<summary>
		/// Returns a value indicating whether this instance is equal to a specified object.
		///</summary>
		///<param name="toObject">An object to compare to this instance.</param>
		///<returns>true if toObject is a <see cref="CategoryBase"/> and has the same value as this instance; otherwise, false.</returns>
		public virtual bool Equals(CategoryBase toObject)
		{
			if (toObject == null)
				return false;
			return Equals(this, toObject);
		}
		
		
		///<summary>
		/// Determines whether the specified <see cref="CategoryBase"/> instances are considered equal.
		///</summary>
		///<param name="Object1">The first <see cref="CategoryBase"/> to compare.</param>
		///<param name="Object2">The second <see cref="CategoryBase"/> to compare. </param>
		///<returns>true if Object1 is the same instance as Object2 or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
		public static bool Equals(CategoryBase Object1, CategoryBase Object2)
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
			if (Object1.Name != Object2.Name)
				equal = false;
			if ( Object1.AdvicePhoto != null && Object2.AdvicePhoto != null )
			{
				if (Object1.AdvicePhoto != Object2.AdvicePhoto)
					equal = false;
			}
			else if (Object1.AdvicePhoto == null ^ Object1.AdvicePhoto == null )
			{
				equal = false;
			}
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
			//return this. GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name) .CompareTo(((CategoryBase)obj).GetPropertyName(SourceTable.PrimaryKey.MemberColumns[0].Name));
		}
		
		/*
		// static method to get a Comparer object
        public static CategoryComparer GetComparer()
        {
            return new CategoryComparer();
        }
        */

        // Comparer delegates back to Category
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
        public int CompareTo(Category rhs, CategoryColumn which)
        {
            switch (which)
            {
            	
            	
            	case CategoryColumn.Id:
            		return this.Id.CompareTo(rhs.Id);
            		
            		                 
            	
            	
            	case CategoryColumn.Name:
            		return this.Name.CompareTo(rhs.Name);
            		
            		                 
            	
            	
            	case CategoryColumn.AdvicePhoto:
            		return this.AdvicePhoto.CompareTo(rhs.AdvicePhoto);
            		
            		                 
            	
            		                 
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
				
		
		
		///<summary>
		/// Returns a String that represents the current object.
		///</summary>
		public override string ToString()
		{
			return string.Format(System.Globalization.CultureInfo.InvariantCulture,
				"{5}{4}- Id: {0}{4}- Name: {1}{4}- AdvicePhoto: {2}{4}- Timestamp: {3}{4}", 
				this.Id,
				this.Name,
				(this.AdvicePhoto == null) ? string.Empty : this.AdvicePhoto.ToString(),
				this.Timestamp,
				Environment.NewLine, 
				this.GetType());
		}
		
		#region "Inner data class "
		
	/// <summary>
	///		The data structure representation of the 'Category' table.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Serializable]
	internal class CategoryData : ICloneable
	{
		#region Variable Declarations
		
		#region Primary key(s)
			/// <summary>			
			/// Id : 
			/// </summary>
			/// <remarks>Member of the primary key of the underlying table "Category"</remarks>
			public System.String Id;
				
			/// <summary>
			/// keep a copy of the original so it can be used for editable primary keys.
			/// </summary>
			public System.String OriginalId;
			
		#endregion
		
		#region Non Primary key(s)
		
		
		/// <summary>
		/// Name : 
		/// </summary>
		public System.String		  Name = string.Empty;
		
		/// <summary>
		/// AdvicePhoto : 
		/// </summary>
		public System.String		  AdvicePhoto = null;
		
		/// <summary>
		/// Timestamp : 
		/// </summary>
		public System.Byte[]		  Timestamp = new byte[] {};
		#endregion
			
		#endregion "Variable Declarations"
		
		public Object Clone()
		{
			CategoryData _tmp = new CategoryData();
						
			_tmp.Id = this.Id;
			_tmp.OriginalId = this.OriginalId;
			
			_tmp.Name = this.Name;
			_tmp.AdvicePhoto = this.AdvicePhoto;
			_tmp.Timestamp = this.Timestamp;
			
			return _tmp;
		}
		

		public TList<Account> AccountCollection = new TList<Account>();

		public TList<Product> ProductCollection = new TList<Product>();
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
			ValidationRules.AddRule(Validation.CommonRules.NotNull,"Name");
			ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("Name",255));
			ValidationRules.AddRule(Validation.CommonRules.StringMaxLength,new Validation.CommonRules.MaxLengthRuleArgs("AdvicePhoto",255));
			ValidationRules.AddRule(Validation.CommonRules.NotNull,"Timestamp");
		}
   		#endregion
	
	} // End Class
	
	#region "CategoryComparer"
		
	/// <summary>
	///	Strongly Typed IComparer
	/// </summary>
	public class CategoryComparer : System.Collections.Generic.IComparer<Category>
	{
		CategoryColumn whichComparison;
		
		/// <summary>
        /// Initializes a new instance of the <see cref="T:CategoryComparer"/> class.
        /// </summary>
		public CategoryComparer()
        {            
        }               
        
        /// <summary>
        /// Initializes a new instance of the <see cref="T:%=className%>Comparer"/> class.
        /// </summary>
        /// <param name="column">The column to sort on.</param>
        public CategoryComparer(CategoryColumn column)
        {
            this.whichComparison = column;
        }

		/// <summary>
        /// Determines whether the specified <c cref="Category"/> instances are considered equal.
        /// </summary>
        /// <param name="a">The first <c cref="Category"/> to compare.</param>
        /// <param name="b">The second <c>Category</c> to compare.</param>
        /// <returns>true if objA is the same instance as objB or if both are null references or if objA.Equals(objB) returns true; otherwise, false.</returns>
        public bool Equals(Category a, Category b)
        {
            return this.Compare(a, b) == 0;
        }

		/// <summary>
        /// Gets the hash code of the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public int GetHashCode(Category entity)
        {
            return entity.GetHashCode();
        }

        /// <summary>
        /// Performs a case-insensitive comparison of two objects of the same type and returns a value indicating whether one is less than, equal to, or greater than the other.
        /// </summary>
        /// <param name="a">The first object to compare.</param>
        /// <param name="b">The second object to compare.</param>
        /// <returns></returns>
        public int Compare(Category a, Category b)
        {
        	EntityPropertyComparer entityPropertyComparer = new EntityPropertyComparer(this.whichComparison.ToString());
        	return entityPropertyComparer.Compare(a, b);
        }

		/// <summary>
        /// Gets or sets the column that will be used for comparison.
        /// </summary>
        /// <value>The comparison column.</value>
        public CategoryColumn WhichComparison
        {
            get { return this.whichComparison; }
            set { this.whichComparison = value; }
        }
	}
	
	#endregion
	
	
	/// <summary>
	/// Enumerate the Category columns.
	/// </summary>
	[Serializable]
	public enum CategoryColumn
	{
		/// <summary>
		/// Id : 
		/// </summary>
		Id,
		/// <summary>
		/// Name : 
		/// </summary>
		Name,
		/// <summary>
		/// AdvicePhoto : 
		/// </summary>
		AdvicePhoto,
		/// <summary>
		/// Timestamp : 
		/// </summary>
		Timestamp
	}//End enum

} // end namespace


