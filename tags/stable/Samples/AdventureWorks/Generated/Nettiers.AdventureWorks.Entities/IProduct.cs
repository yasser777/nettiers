﻿using System;
using System.ComponentModel;

namespace Nettiers.AdventureWorks.Entities
{
	/// <summary>
	///		The data structure representation of the 'Product' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface IProduct 
	{
		/// <summary>			
		/// ProductID : Primary key for Product records.
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "Product"</remarks>
		System.Int32 ProductId { get; set; }
				
		
		
		/// <summary>
		/// Name : Name of the product.
		/// </summary>
		System.String  Name  { get; set; }
		
		/// <summary>
		/// ProductNumber : Unique product identification number.
		/// </summary>
		System.String  ProductNumber  { get; set; }
		
		/// <summary>
		/// MakeFlag : 0 = Product is purchased, 1 = Product is manufactured in-house.
		/// </summary>
		System.Boolean  MakeFlag  { get; set; }
		
		/// <summary>
		/// FinishedGoodsFlag : 0 = Product is not a salable item. 1 = Product is salable.
		/// </summary>
		System.Boolean  FinishedGoodsFlag  { get; set; }
		
		/// <summary>
		/// Color : Product color.
		/// </summary>
		System.String  Color  { get; set; }
		
		/// <summary>
		/// SafetyStockLevel : Minimum inventory quantity. 
		/// </summary>
		System.Int16  SafetyStockLevel  { get; set; }
		
		/// <summary>
		/// ReorderPoint : Inventory level that triggers a purchase order or work order. 
		/// </summary>
		System.Int16  ReorderPoint  { get; set; }
		
		/// <summary>
		/// StandardCost : Standard cost of the product.
		/// </summary>
		System.Decimal  StandardCost  { get; set; }
		
		/// <summary>
		/// ListPrice : Selling price.
		/// </summary>
		System.Decimal  ListPrice  { get; set; }
		
		/// <summary>
		/// Size : Product size.
		/// </summary>
		System.String  Size  { get; set; }
		
		/// <summary>
		/// SizeUnitMeasureCode : Unit of measure for Size column.
		/// </summary>
		System.String  SizeUnitMeasureCode  { get; set; }
		
		/// <summary>
		/// WeightUnitMeasureCode : Unit of measure for Weight column.
		/// </summary>
		System.String  WeightUnitMeasureCode  { get; set; }
		
		/// <summary>
		/// Weight : Product weight.
		/// </summary>
		System.Decimal?  Weight  { get; set; }
		
		/// <summary>
		/// DaysToManufacture : Number of days required to manufacture the product.
		/// </summary>
		System.Int32  DaysToManufacture  { get; set; }
		
		/// <summary>
		/// ProductLine : R = Road, M = Mountain, T = Touring, S = Standard
		/// </summary>
		System.String  ProductLine  { get; set; }
		
		/// <summary>
		/// Class : H = High, M = Medium, L = Low
		/// </summary>
		System.String  SafeNameClass  { get; set; }
		
		/// <summary>
		/// Style : W = Womens, M = Mens, U = Universal
		/// </summary>
		System.String  Style  { get; set; }
		
		/// <summary>
		/// ProductSubcategoryID : Product is a member of this product subcategory. Foreign key to ProductSubCategory.ProductSubCategoryID. 
		/// </summary>
		System.Int32?  ProductSubcategoryId  { get; set; }
		
		/// <summary>
		/// ProductModelID : Product is a member of this product model. Foreign key to ProductModel.ProductModelID.
		/// </summary>
		System.Int32?  ProductModelId  { get; set; }
		
		/// <summary>
		/// SellStartDate : Date the product was available for sale.
		/// </summary>
		System.DateTime  SellStartDate  { get; set; }
		
		/// <summary>
		/// SellEndDate : Date the product was no longer available for sale.
		/// </summary>
		System.DateTime?  SellEndDate  { get; set; }
		
		/// <summary>
		/// DiscontinuedDate : Date the product was discontinued.
		/// </summary>
		System.DateTime?  DiscontinuedDate  { get; set; }
		
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
		///	which are related to this object through the relation _productProductPhotoProductId
		/// </summary>	
		TList<ProductProductPhoto> ProductProductPhotoCollection {  get;  set;}	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _transactionHistoryProductId
		/// </summary>	
		TList<TransactionHistory> TransactionHistoryCollection {  get;  set;}	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _productVendorProductId
		/// </summary>	
		TList<ProductVendor> ProductVendorCollection {  get;  set;}	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _billOfMaterialsProductAssemblyIdGetByProductAssemblyId
		/// </summary>	
		TList<BillOfMaterials> BillOfMaterialsCollectionGetByProductAssemblyId {  get;  set;}	

		
		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the junction table documentIdDocumentCollectionFromProductDocument
		/// </summary>	
		TList<Document> DocumentIdDocumentCollection_From_ProductDocument { get; set; }	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _specialOfferProductProductId
		/// </summary>	
		TList<SpecialOfferProduct> SpecialOfferProductCollection {  get;  set;}	

		
		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the junction table productPhotoIdProductPhotoCollectionFromProductProductPhoto
		/// </summary>	
		TList<ProductPhoto> ProductPhotoIdProductPhotoCollection_From_ProductProductPhoto { get; set; }	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _billOfMaterialsProductAssemblyIdGetByComponentId
		/// </summary>	
		TList<BillOfMaterials> BillOfMaterialsCollectionGetByComponentId {  get;  set;}	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _productInventoryProductId
		/// </summary>	
		TList<ProductInventory> ProductInventoryCollection {  get;  set;}	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _productDocumentProductId
		/// </summary>	
		TList<ProductDocument> ProductDocumentCollection {  get;  set;}	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _productReviewProductId
		/// </summary>	
		TList<ProductReview> ProductReviewCollection {  get;  set;}	

		
		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the junction table vendorIdVendorCollectionFromProductVendor
		/// </summary>	
		TList<Vendor> VendorIdVendorCollection_From_ProductVendor { get; set; }	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _workOrderProductId
		/// </summary>	
		TList<WorkOrder> WorkOrderCollection {  get;  set;}	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _purchaseOrderDetailProductId
		/// </summary>	
		TList<PurchaseOrderDetail> PurchaseOrderDetailCollection {  get;  set;}	

		
		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the junction table locationIdLocationCollectionFromProductInventory
		/// </summary>	
		TList<Location> LocationIdLocationCollection_From_ProductInventory { get; set; }	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _productListPriceHistoryProductId
		/// </summary>	
		TList<ProductListPriceHistory> ProductListPriceHistoryCollection {  get;  set;}	

		
		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the junction table specialOfferIdSpecialOfferCollectionFromSpecialOfferProduct
		/// </summary>	
		TList<SpecialOffer> SpecialOfferIdSpecialOfferCollection_From_SpecialOfferProduct { get; set; }	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _shoppingCartItemProductId
		/// </summary>	
		TList<ShoppingCartItem> ShoppingCartItemCollection {  get;  set;}	


		/// <summary>
		///	Holds a collection of entity objects
		///	which are related to this object through the relation _productCostHistoryProductId
		/// </summary>	
		TList<ProductCostHistory> ProductCostHistoryCollection {  get;  set;}	

		#endregion Data Properties

	}
}


