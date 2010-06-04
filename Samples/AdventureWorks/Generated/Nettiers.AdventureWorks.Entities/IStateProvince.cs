﻿using System;
using System.ComponentModel;

namespace Nettiers.AdventureWorks.Entities
{
	/// <summary>
	///		The data structure representation of the 'StateProvince' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IStateProvince 
	{
		/// <summary>			
		/// StateProvinceID : Primary key for StateProvince records.
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "StateProvince"</remarks>
		System.Int32 StateProvinceId { get; set; }
				
		
		
		/// <summary>
		/// StateProvinceCode : ISO standard state or province code.
		/// </summary>
		System.String  StateProvinceCode  { get; set; }
		
		/// <summary>
		/// CountryRegionCode : ISO standard country or region code. Foreign key to CountryRegion.CountryRegionCode. 
		/// </summary>
		System.String  CountryRegionCode  { get; set; }
		
		/// <summary>
		/// IsOnlyStateProvinceFlag : 0 = StateProvinceCode exists. 1 = StateProvinceCode unavailable, using CountryRegionCode.
		/// </summary>
		System.Boolean  IsOnlyStateProvinceFlag  { get; set; }
		
		/// <summary>
		/// Name : State or province description.
		/// </summary>
		System.String  Name  { get; set; }
		
		/// <summary>
		/// TerritoryID : ID of the territory in which the state or province is located. Foreign key to SalesTerritory.SalesTerritoryID.
		/// </summary>
		System.Int32  TerritoryId  { get; set; }
		
		/// <summary>
		/// rowguid : ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.
		/// </summary>
		System.Guid  Rowguid  { get; set; }
		
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


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _addressStateProvinceId
		/// </summary>	
		TList<Address> AddressCollection {  get;  set;}	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _salesTaxRateStateProvinceId
		/// </summary>	
		TList<SalesTaxRate> SalesTaxRateCollection {  get;  set;}	

		#endregion Data Properties

	}
}


