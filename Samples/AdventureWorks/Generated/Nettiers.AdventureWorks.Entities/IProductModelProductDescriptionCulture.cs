﻿using System;
using System.ComponentModel;

namespace Nettiers.AdventureWorks.Entities
{
	/// <summary>
	///		The data structure representation of the 'ProductModelProductDescriptionCulture' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IProductModelProductDescriptionCulture 
	{
		/// <summary>			
		/// ProductModelID : Primary key. Foreign key to ProductModel.ProductModelID.
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "ProductModelProductDescriptionCulture"</remarks>
		System.Int32 ProductModelId { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.Int32 OriginalProductModelId { get; set; }
			
		/// <summary>			
		/// ProductDescriptionID : Primary key. Foreign key to ProductDescription.ProductDescriptionID.
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "ProductModelProductDescriptionCulture"</remarks>
		System.Int32 ProductDescriptionId { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.Int32 OriginalProductDescriptionId { get; set; }
			
		/// <summary>			
		/// CultureID : Culture identification number. Foreign key to Culture.CultureID.
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "ProductModelProductDescriptionCulture"</remarks>
		System.String CultureId { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.String OriginalCultureId { get; set; }
			
		
		
		/// <summary>
		/// ModifiedDate : Date and time the record was last updated.
		/// </summary>
		System.DateTime  ModifiedDate  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}


