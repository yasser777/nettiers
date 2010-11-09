﻿
/*
	File Generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file Nettiers.AdventureWorks.Entities.ProductDescription.cs instead.
*/

#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using System.Web.Services.Protocols;
using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data.Bases;

#endregion

namespace Nettiers.AdventureWorks.Data.WebServiceClient
{

	///<summary>
	/// This class is the webservice client implementation that exposes CRUD methods for Nettiers.AdventureWorks.Entities.ProductDescription objects.
	///</summary>
	public abstract partial class WsProductDescriptionProviderBase : ProductDescriptionProviderBase
	{
		#region Declarations	
	
		/// <summary>
		/// the Url of the webservice.
		/// </summary>
		private string url;
			
		#endregion Declarations
		
		#region Constructors
	
		/// <summary>
		/// Creates a new <see cref="WsProductDescriptionProviderBase"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		public WsProductDescriptionProviderBase()
		{		
		}
		
		/// <summary>
		/// Creates a new <see cref="WsProductDescriptionProviderBase"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		/// <param name="url">The url to the nettiers webservice.</param>
		public WsProductDescriptionProviderBase(string url)
		{
			this.Url = url;
		}
			
		#endregion Constructors
		
		#region Url
		///<summary>
		/// Current URL for webservice endpoint. 
		///</summary>
		public string Url
        {
        	get {return url;}
        	set {url = value;}
        }
		#endregion 
		
		#region Convertion utility
		
		/// <summary>
		/// Convert a collection from the ws proxy to a nettiers collection.
		/// </summary>
		public static Nettiers.AdventureWorks.Entities.TList<ProductDescription> Convert(WsProxy.ProductDescription[] items)
		{
			Nettiers.AdventureWorks.Entities.TList<ProductDescription> outItems = new Nettiers.AdventureWorks.Entities.TList<ProductDescription>();
			foreach(WsProxy.ProductDescription item in items)
			{
				outItems.Add(Convert(item));
			}
			return outItems;
		}
		
		/// <summary>
		/// Convert a nettiers collection to the ws proxy collection.
		/// </summary>
		public static Nettiers.AdventureWorks.Entities.ProductDescription Convert(WsProxy.ProductDescription item)
		{	
			Nettiers.AdventureWorks.Entities.ProductDescription outItem = item == null ? null : new Nettiers.AdventureWorks.Entities.ProductDescription();
			Convert(outItem, item);					
			return outItem;
		}
		
		/// <summary>
		/// Convert a nettiers collection to the ws proxy collection.
		/// </summary>
		public static Nettiers.AdventureWorks.Entities.ProductDescription Convert(Nettiers.AdventureWorks.Entities.ProductDescription outItem , WsProxy.ProductDescription item)
		{	
			if (item != null && outItem != null)
			{
				outItem.ProductDescriptionId = item.ProductDescriptionId;
				outItem.Description = item.Description;
				outItem.Rowguid = item.Rowguid;
				outItem.ModifiedDate = item.ModifiedDate;
				
				outItem.AcceptChanges();			
			}
							
			return outItem;
		}
		
		/// <summary>
		/// Convert a nettiers entity to the ws proxy entity.
		/// </summary>
		public static WsProxy.ProductDescription Convert(Nettiers.AdventureWorks.Entities.ProductDescription item)
		{			
			WsProxy.ProductDescription outItem = new WsProxy.ProductDescription();			
			outItem.ProductDescriptionId = item.ProductDescriptionId;
			outItem.Description = item.Description;
			outItem.Rowguid = item.Rowguid;
			outItem.ModifiedDate = item.ModifiedDate;

							
			return outItem;
		}
		
		/// <summary>
		/// Convert a collection from  to a nettiers collection to a the ws proxy collection.
		/// </summary>
		public static WsProxy.ProductDescription[] Convert(Nettiers.AdventureWorks.Entities.TList<ProductDescription> items)
		{
			WsProxy.ProductDescription[] outItems = new WsProxy.ProductDescription[items.Count];
			int count = 0;
		
			foreach (Nettiers.AdventureWorks.Entities.ProductDescription item in items)
			{
				outItems[count++] = Convert(item);
			}
			return outItems;
		}

		
		#endregion
		
		#region Get from  Many To Many Relationship Functions
		#region GetByCultureIdFromProductModelProductDescriptionCulture
		
		/// <summary>
		///		Gets ProductDescription objects from the datasource by CultureID in the
		///		ProductModelProductDescriptionCulture table. Table ProductDescription is related to table Culture
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pagelen">Number of rows to return.</param>
		/// <param name="_cultureId">Culture identification number. Foreign key to Culture.CultureID.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ProductDescription objects.</returns>
		public override TList<ProductDescription> GetByCultureIdFromProductModelProductDescriptionCulture(TransactionManager transactionManager, System.String _cultureId, int start, int pagelen, out int count)
		{
			try
			{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = Url;
				
			WsProxy.ProductDescription[] items = proxy.ProductDescriptionProvider_GetByCultureIdFromProductModelProductDescriptionCulture(_cultureId, start, pagelen, out count);
	
			return Convert(items); 
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}
		
		#endregion GetByCultureIdFromProductModelProductDescriptionCulture
		
		#region GetByProductModelIdFromProductModelProductDescriptionCulture
		
		/// <summary>
		///		Gets ProductDescription objects from the datasource by ProductModelID in the
		///		ProductModelProductDescriptionCulture table. Table ProductDescription is related to table ProductModel
		///		through the (M:N) relationship defined in the ProductModelProductDescriptionCulture table.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pagelen">Number of rows to return.</param>
		/// <param name="_productModelId">Primary key. Foreign key to ProductModel.ProductModelID.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of ProductDescription objects.</returns>
		public override TList<ProductDescription> GetByProductModelIdFromProductModelProductDescriptionCulture(TransactionManager transactionManager, System.Int32 _productModelId, int start, int pagelen, out int count)
		{
			try
			{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = Url;
				
			WsProxy.ProductDescription[] items = proxy.ProductDescriptionProvider_GetByProductModelIdFromProductModelProductDescriptionCulture(_productModelId, start, pagelen, out count);
	
			return Convert(items); 
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}
		
		#endregion GetByProductModelIdFromProductModelProductDescriptionCulture
		
		#endregion	
		
		
		#region Delete Methods
			
			/// <summary>
			/// 	Deletes a row from the DataSource.
			/// </summary>
			/// <param name="_productDescriptionId">Primary key for ProductDescription records.. Primary Key.</param>	
            
			/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
			/// <remarks>Deletes based on primary key(s).</remarks>
			/// <returns>Returns true if operation suceeded.</returns>
			public override bool Delete(TransactionManager transactionManager, System.Int32 _productDescriptionId)
			{
				try
				{
				// call the proxy
				WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
				proxy.Url = Url;
				
				bool result = proxy.ProductDescriptionProvider_Delete(_productDescriptionId);				
				return result;
				}
				catch(SoapException soex)
				{
					System.Diagnostics.Debug.WriteLine(soex);
					throw soex;
				}
				catch(Exception ex)
				{
					System.Diagnostics.Debug.WriteLine(ex);
					throw ex;
				}
			}
			
			#endregion Delete Methods
	
		
		#region Find Methods
		
		
		/// <summary>
		/// 	Returns rows meeting the whereclause condition from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pagelen">Number of rows to return.</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <remarks>Operators must be capitalized (OR, AND)</remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductDescription objects.</returns>
		public override Nettiers.AdventureWorks.Entities.TList<ProductDescription> Find(TransactionManager transactionManager, string whereClause, int start, int pagelen, out int count)
		{
			try
			{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = Url;
			
			WsProxy.ProductDescription[] items = proxy.ProductDescriptionProvider_Find(whereClause, start, pagelen, out count);
			
			return Convert(items); 
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}
		
		#endregion Find Methods
		
		
		#region GetAll Methods
				
		/// <summary>
		/// 	Gets All rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>			
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductDescription objects.</returns>
		public override Nettiers.AdventureWorks.Entities.TList<ProductDescription> GetAll(TransactionManager transactionManager, int start, int pageLength, out int count)
		{
			try
			{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = Url;
				
			WsProxy.ProductDescription[] items = proxy.ProductDescriptionProvider_GetAll(start, pageLength, out count);
			
			return Convert(items); 
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}
		
		#endregion GetAll Methods
		
		#region GetPaged Methods
						
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
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.ProductDescription objects.</returns>
		public override Nettiers.AdventureWorks.Entities.TList<ProductDescription> GetPaged(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			try
			{
			whereClause = whereClause ?? string.Empty;
			orderBy = orderBy ?? string.Empty;
			
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = Url;
			
			WsProxy.ProductDescription[] items = proxy.ProductDescriptionProvider_GetPaged(whereClause, orderBy, start, pageLength, out count);
			
			// Create a collection and fill it with the dataset
			return Convert(items); 
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}
		
		#endregion GetPaged Methods
	
		
		#region Get By Foreign Key Functions
		#endregion
		
		
		#region Get By Index Functions
					
		/// <summary>
		/// 	Gets rows from the datasource based on the AK_ProductDescription_rowguid index.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_rowguid">ROWGUIDCOL number uniquely identifying the record. Used to support a merge replication sample.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="count">out parameter to get total records for query</param>	
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductDescription"/> class.</returns>
		public override Nettiers.AdventureWorks.Entities.ProductDescription GetByRowguid(TransactionManager transactionManager, System.Guid _rowguid, int start, int pageLength, out int count)
		{
			try
			{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = Url;
			WsProxy.ProductDescription items = proxy.ProductDescriptionProvider_GetByRowguid(_rowguid, start, pageLength, out count);
			
			return Convert(items); 
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}
		
					
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_ProductDescription_ProductDescriptionID index.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_productDescriptionId">Primary key for ProductDescription records.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="count">out parameter to get total records for query</param>	
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.ProductDescription"/> class.</returns>
		public override Nettiers.AdventureWorks.Entities.ProductDescription GetByProductDescriptionId(TransactionManager transactionManager, System.Int32 _productDescriptionId, int start, int pageLength, out int count)
		{
			try
			{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = Url;
			WsProxy.ProductDescription items = proxy.ProductDescriptionProvider_GetByProductDescriptionId(_productDescriptionId, start, pageLength, out count);
			
			return Convert(items); 
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}
		
		#endregion Get By Index Functions
	
	
		#region Insert Methods
		/// <summary>
		/// 	Inserts a Nettiers.AdventureWorks.Entities.ProductDescription object into the datasource using a transaction.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.ProductDescription object to insert.</param>		
		/// <remarks></remarks>		
		/// <returns>Returns true if operation is successful.</returns>
		public override bool Insert(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductDescription entity)
		{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = Url;
			
			try
			{
				WsProxy.ProductDescription result = proxy.ProductDescriptionProvider_Insert(Convert(entity));
				Convert(entity, result);
				return true;
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}
	
		/// <summary>
		/// Lets you efficiently bulk many entity to the database.
		/// </summary>
		/// <param name="transactionManager">NOTE: The transaction manager should be null for the web service client implementation.</param>
		/// <param name="entityList">The entities.</param>
		/// <remarks>
		/// After inserting into the datasource, the Nettiers.AdventureWorks.Entities.ProductDescription object will be updated
		/// to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		public override void BulkInsert(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.TList<ProductDescription> entityList)
		{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = Url;
			try
			{
				proxy.ProductDescriptionProvider_BulkInsert(Convert(entityList));
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch (Exception ex)
			{	
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}

		#endregion Insert Methods
	
	
		#region Update Methods
						
		/// <summary>
		/// 	Update an existing row in the datasource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.ProductDescription object to update.</param>		
		/// <remarks></remarks>
		/// <returns>Returns true if operation is successful.</returns>
		public override bool Update(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.ProductDescription entity)
		{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = Url;
			
			try
			{
				WsProxy.ProductDescription result = proxy.ProductDescriptionProvider_Update(Convert(entity));
				Convert(entity, result);
				entity.AcceptChanges();
				return true;
			}
			catch(SoapException soex)
			{
				System.Diagnostics.Debug.WriteLine(soex);
				throw soex;
			}
			catch(Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
				throw ex;
			}
		}
		
		#endregion Update Methods
			
		#region Custom Methods
		
		
		#endregion
					
	}//end class
} // end namespace
