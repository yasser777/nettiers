﻿
/*
	File Generated by NetTiers templates [www.nettiers.com]
	Generated on : Monday, July 24, 2006
	Important: Do not modify this file. Edit the file netTiers.Petshop.Entities.LineItem.cs instead.
*/

#region "Using directives"

using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using netTiers.Petshop.Entities;
using netTiers.Petshop.Data.Bases;

#endregion

namespace netTiers.Petshop.Data.WebServiceClient
{

	///<summary>
	/// This class is the webservice client implementation that exposes CRUD methods for netTiers.Petshop.Entities.LineItem objects.
	///</summary>
	public partial class WsLineItemProvider : LineItemProviderBase
	{
		#region "Declarations"	
	
		/// <summary>
		/// the Url of the webservice.
		/// </summary>
		protected string _url;
			
		#endregion "Declarations"
		
		#region "Constructors"
	
		/// <summary>
		/// Creates a new <see cref="WsLineItemProvider"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		public WsLineItemProvider()
		{		
		}
		
		/// <summary>
		/// Creates a new <see cref="WsLineItemProvider"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		/// <param name="url">The url to the nettiers webservice.</param>
		public WsLineItemProvider(string url)
		{
			this._url = url;
		}
			
		#endregion "Constructors"
		
		public string Url
        {
        	get {return this._url;}
        	set {this._url = value;}
        }
		
		#region "Convertion utility"
		
		/// <summary>
		/// Convert a collection from the ws proxy to a nettiers collection.
		/// </summary>
		public static netTiers.Petshop.Entities.TList<LineItem> Convert(WsProxy.LineItem[] items)
		{
			netTiers.Petshop.Entities.TList<LineItem> outItems = new netTiers.Petshop.Entities.TList<LineItem>();
			foreach(WsProxy.LineItem item in items)
			{
				outItems.Add(Convert(item));
			}
			return outItems;
		}
		
		/// <summary>
		/// Convert a nettiers collection to the ws proxy collection.
		/// </summary>
		public static netTiers.Petshop.Entities.LineItem Convert(WsProxy.LineItem item)
		{	
			netTiers.Petshop.Entities.LineItem outItem = new netTiers.Petshop.Entities.LineItem();
			Convert(outItem, item);					
			return outItem;
		}
		
		/// <summary>
		/// Convert a nettiers collection to the ws proxy collection.
		/// </summary>
		public static netTiers.Petshop.Entities.LineItem Convert(netTiers.Petshop.Entities.LineItem outItem , WsProxy.LineItem item)
		{	
			outItem.OrderId = item.OrderId;
			outItem.LineNum = item.LineNum;
			outItem.ItemId = item.ItemId;
			outItem.Quantity = item.Quantity;
			outItem.UnitPrice = item.UnitPrice;
			outItem.Timestamp = item.Timestamp;
			
			outItem.OriginalOrderId = item.OrderId;
			outItem.OriginalLineNum = item.LineNum;
							
			outItem.AcceptChanges();			
			return outItem;
		}
		
		/// <summary>
		/// Convert a nettiers entity to the ws proxy entity.
		/// </summary>
		public static WsProxy.LineItem Convert(netTiers.Petshop.Entities.LineItem item)
		{			
			WsProxy.LineItem outItem = new WsProxy.LineItem();			
			outItem.OrderId = item.OrderId;
			outItem.LineNum = item.LineNum;
			outItem.ItemId = item.ItemId;
			outItem.Quantity = item.Quantity;
			outItem.UnitPrice = item.UnitPrice;
			outItem.Timestamp = item.Timestamp;

			outItem.OriginalOrderId = item.OriginalOrderId;
			outItem.OriginalLineNum = item.OriginalLineNum;
							
			return outItem;
		}
		
		/// <summary>
		/// Convert a collection from  to a nettiers collection to a the ws proxy collection.
		/// </summary>
		public static WsProxy.LineItem[] Convert(netTiers.Petshop.Entities.TList<LineItem> items)
		{
			WsProxy.LineItem[] outItems = new WsProxy.LineItem[items.Count];
			int count = 0;
		
			foreach (netTiers.Petshop.Entities.LineItem item in items)
			{
				outItems[count++] = Convert(item);
			}
			return outItems;
		}

		
		#endregion
		
		#region "Get from  Many To Many Relationship Functions"
		#endregion	
		
		
		#region "Delete Functions"			
			
			/// <summary>
			/// 	Deletes a row from the DataSource.
			/// </summary>
			/// <param name="OrderId">. Primary Key.</param>	
			/// <param name="LineNum">. Primary Key.</param>	
			/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
			/// <remarks>Deletes based on primary key(s).</remarks>
			/// <returns>Returns true if operation suceeded.</returns>
			public override bool Delete(TransactionManager transactionManager, System.Int32 orderId, System.Int32 lineNum, byte[] timestamp)
			{
				// call the proxy
				WsProxy.petshopDBServices proxy = new WsProxy.petshopDBServices();
				proxy.Url = this._url;
				
				bool result = proxy.LineItemProvider_Delete(orderId, lineNum, timestamp);				
				return result;
			}
			
			#endregion
	
		
		#region "Find Functions"
		
		
		/// <summary>
		/// 	Returns rows meeting the whereclause condition from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pagelen">Number of rows to return.</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <remarks>Operators must be capitalized (OR, AND)</remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.LineItem objects.</returns>
		public override netTiers.Petshop.Entities.TList<LineItem> Find(TransactionManager transactionManager, string whereClause, int start, int pagelen, out int count)
		{
			WsProxy.petshopDBServices proxy = new WsProxy.petshopDBServices();
			proxy.Url = this._url;
			
			WsProxy.LineItem[] items = proxy.LineItemProvider_Find(whereClause, start, pagelen, out count);
			
			return Convert(items); 
		}
		
		#endregion "Find Functions"
		
		
		#region "GetList Functions"
				
		/// <summary>
		/// 	Gets All rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>			
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.LineItem objects.</returns>
		public override netTiers.Petshop.Entities.TList<LineItem> GetAll(TransactionManager transactionManager, int start, int pageLength, out int count)
		{
			WsProxy.petshopDBServices proxy = new WsProxy.petshopDBServices();
			proxy.Url = this._url;
				
			WsProxy.LineItem[] items = proxy.LineItemProvider_GetAll(start, pageLength, out count);
			
			return Convert(items); 
		}
		
		#endregion
		
		#region Get Paged
						
		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.LineItem objects.</returns>
		public override netTiers.Petshop.Entities.TList<LineItem> GetPaged(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			WsProxy.petshopDBServices proxy = new WsProxy.petshopDBServices();
			proxy.Url = this._url;
			
			WsProxy.LineItem[] items = proxy.LineItemProvider_GetPaged(whereClause, orderBy, start, pageLength, out count);
			
			// Create a collection and fill it with the dataset
			return Convert(items); 
		}
		
		#endregion		
	
		
		#region "Get By Foreign Key Functions"
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK__LineItem__OrderI__1367E606 key.
		///		FK__LineItem__OrderI__1367E606 Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="orderId"></param>
		/// <param name="count">out parameter to get total records for query</param>	
		/// <remarks></remarks>		
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.LineItem objects.</returns>
		public override netTiers.Petshop.Entities.TList<LineItem> GetByOrderId(TransactionManager transactionManager, System.Int32 orderId, int start, int pageLength, out int count)
		{
			WsProxy.petshopDBServices proxy = new WsProxy.petshopDBServices();
			proxy.Url = this._url;
			WsProxy.LineItem[] items = proxy.LineItemProvider_GetByOrderId(orderId, start, pageLength, out count);
			
			return Convert(items); 
		}
			
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_LineItem_Item key.
		///		FK_LineItem_Item Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="itemId"></param>
		/// <param name="count">out parameter to get total records for query</param>	
		/// <remarks></remarks>		
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.LineItem objects.</returns>
		public override netTiers.Petshop.Entities.TList<LineItem> GetByItemId(TransactionManager transactionManager, System.Guid itemId, int start, int pageLength, out int count)
		{
			WsProxy.petshopDBServices proxy = new WsProxy.petshopDBServices();
			proxy.Url = this._url;
			WsProxy.LineItem[] items = proxy.LineItemProvider_GetByItemId(itemId, start, pageLength, out count);
			
			return Convert(items); 
		}
			
		#endregion
		
		
		#region "Get By Index Functions"
					
		/// <summary>
		/// 	Gets rows from the datasource based on the PkLineItem index.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="orderId"></param>
		/// <param name="lineNum"></param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="count">out parameter to get total records for query</param>	
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.LineItem"/> class.</returns>
		public override netTiers.Petshop.Entities.LineItem GetByLineNumOrderId(TransactionManager transactionManager, System.Int32 orderId, System.Int32 lineNum, int start, int pageLength, out int count)
		{
			WsProxy.petshopDBServices proxy = new WsProxy.petshopDBServices();
			proxy.Url = this._url;
			WsProxy.LineItem items = proxy.LineItemProvider_GetByLineNumOrderId(orderId, lineNum, start, pageLength, out count);
			
			return Convert(items); 
		}
		
		#endregion "Get By Index Functions"
	
	
		#region "Insert Functions"
		/// <summary>
		/// 	Inserts a netTiers.Petshop.Entities.LineItem object into the datasource using a transaction.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">netTiers.Petshop.Entities.LineItem object to insert.</param>		
		/// <remarks></remarks>		
		/// <returns>Returns true if operation is successful.</returns>
		public override bool Insert(TransactionManager transactionManager, netTiers.Petshop.Entities.LineItem entity)
		{
			WsProxy.petshopDBServices proxy = new WsProxy.petshopDBServices();
			proxy.Url = this._url;
			
			try
			{
				WsProxy.LineItem result = proxy.LineItemProvider_Insert(Convert(entity));
				Convert(entity, result);
				return true;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				return false;
			}
		}
	
		/// <summary>
		/// Lets you efficiently bulk many entity to the database.
		/// </summary>
		/// <param name="transactionManager">NOTE: The transaction manager should be null for the web service client implementation.</param>
		/// <param name="entities">The entities.</param>
		/// <remarks>
		/// After inserting into the datasource, the netTiers.Petshop.Entities.LineItem object will be updated
		/// to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		public override void BulkInsert(TransactionManager transactionManager, TList<netTiers.Petshop.Entities.LineItem> entityList)
		{
			WsProxy.petshopDBServices proxy = new WsProxy.petshopDBServices();
			proxy.Url = this._url;
			try
			{
				proxy.LineItemProvider_BulkInsert(Convert(entityList));
			}
			catch (Exception ex)
			{	
				System.Diagnostics.Debug.WriteLine(ex);
			}
		}

		#endregion
	
	
		#region "Update Functions"
						
		/// <summary>
		/// 	Update an existing row in the datasource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">netTiers.Petshop.Entities.LineItem object to update.</param>		
		/// <remarks></remarks>
		/// <returns>Returns true if operation is successful.</returns>
		public override bool Update(TransactionManager transactionManager, netTiers.Petshop.Entities.LineItem entity)
		{
			WsProxy.petshopDBServices proxy = new WsProxy.petshopDBServices();
			proxy.Url = this._url;
			
			try
			{
				WsProxy.LineItem result = proxy.LineItemProvider_Update(Convert(entity));
				Convert(entity, result);
				entity.AcceptChanges();
				return true;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				return false;
			}
		}
		
		#endregion
			
		#region "Custom Methods"
		
		
		#endregion
					
	}//end class
} // end namespace