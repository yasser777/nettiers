﻿
/*
	File Generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file Nettiers.AdventureWorks.Entities.Individual.cs instead.
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
	/// This class is the webservice client implementation that exposes CRUD methods for Nettiers.AdventureWorks.Entities.Individual objects.
	///</summary>
	public abstract partial class WsIndividualProviderBase : IndividualProviderBase
	{
		#region Declarations	
	
		/// <summary>
		/// the Url of the webservice.
		/// </summary>
		private string url;
			
		#endregion Declarations
		
		#region Constructors
	
		/// <summary>
		/// Creates a new <see cref="WsIndividualProviderBase"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		public WsIndividualProviderBase()
		{		
		}
		
		/// <summary>
		/// Creates a new <see cref="WsIndividualProviderBase"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		/// <param name="url">The url to the nettiers webservice.</param>
		public WsIndividualProviderBase(string url)
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
		public static Nettiers.AdventureWorks.Entities.TList<Individual> Convert(WsProxy.Individual[] items)
		{
			Nettiers.AdventureWorks.Entities.TList<Individual> outItems = new Nettiers.AdventureWorks.Entities.TList<Individual>();
			foreach(WsProxy.Individual item in items)
			{
				outItems.Add(Convert(item));
			}
			return outItems;
		}
		
		/// <summary>
		/// Convert a nettiers collection to the ws proxy collection.
		/// </summary>
		public static Nettiers.AdventureWorks.Entities.Individual Convert(WsProxy.Individual item)
		{	
			Nettiers.AdventureWorks.Entities.Individual outItem = item == null ? null : new Nettiers.AdventureWorks.Entities.Individual();
			Convert(outItem, item);					
			return outItem;
		}
		
		/// <summary>
		/// Convert a nettiers collection to the ws proxy collection.
		/// </summary>
		public static Nettiers.AdventureWorks.Entities.Individual Convert(Nettiers.AdventureWorks.Entities.Individual outItem , WsProxy.Individual item)
		{	
			if (item != null && outItem != null)
			{
				outItem.CustomerId = item.CustomerId;
				outItem.ContactId = item.ContactId;
				outItem.Demographics = item.Demographics;
				outItem.ModifiedDate = item.ModifiedDate;
				
				outItem.OriginalCustomerId = item.CustomerId;
				outItem.AcceptChanges();			
			}
							
			return outItem;
		}
		
		/// <summary>
		/// Convert a nettiers entity to the ws proxy entity.
		/// </summary>
		public static WsProxy.Individual Convert(Nettiers.AdventureWorks.Entities.Individual item)
		{			
			WsProxy.Individual outItem = new WsProxy.Individual();			
			outItem.CustomerId = item.CustomerId;
			outItem.ContactId = item.ContactId;
			outItem.Demographics = item.Demographics;
			outItem.ModifiedDate = item.ModifiedDate;

			outItem.OriginalCustomerId = item.OriginalCustomerId;
							
			return outItem;
		}
		
		/// <summary>
		/// Convert a collection from  to a nettiers collection to a the ws proxy collection.
		/// </summary>
		public static WsProxy.Individual[] Convert(Nettiers.AdventureWorks.Entities.TList<Individual> items)
		{
			WsProxy.Individual[] outItems = new WsProxy.Individual[items.Count];
			int count = 0;
		
			foreach (Nettiers.AdventureWorks.Entities.Individual item in items)
			{
				outItems[count++] = Convert(item);
			}
			return outItems;
		}

		
		#endregion
		
		#region Get from  Many To Many Relationship Functions
		#endregion	
		
		
		#region Delete Methods
			
			/// <summary>
			/// 	Deletes a row from the DataSource.
			/// </summary>
			/// <param name="_customerId">Unique customer identification number. Foreign key to Customer.CustomerID.. Primary Key.</param>	
            
			/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
			/// <remarks>Deletes based on primary key(s).</remarks>
			/// <returns>Returns true if operation suceeded.</returns>
			public override bool Delete(TransactionManager transactionManager, System.Int32 _customerId)
			{
				try
				{
				// call the proxy
				WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
				proxy.Url = Url;
				
				bool result = proxy.IndividualProvider_Delete(_customerId);				
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
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Individual objects.</returns>
		public override Nettiers.AdventureWorks.Entities.TList<Individual> Find(TransactionManager transactionManager, string whereClause, int start, int pagelen, out int count)
		{
			try
			{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = Url;
			
			WsProxy.Individual[] items = proxy.IndividualProvider_Find(whereClause, start, pagelen, out count);
			
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
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Individual objects.</returns>
		public override Nettiers.AdventureWorks.Entities.TList<Individual> GetAll(TransactionManager transactionManager, int start, int pageLength, out int count)
		{
			try
			{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = Url;
				
			WsProxy.Individual[] items = proxy.IndividualProvider_GetAll(start, pageLength, out count);
			
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
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Individual objects.</returns>
		public override Nettiers.AdventureWorks.Entities.TList<Individual> GetPaged(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			try
			{
			whereClause = whereClause ?? string.Empty;
			orderBy = orderBy ?? string.Empty;
			
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = Url;
			
			WsProxy.Individual[] items = proxy.IndividualProvider_GetPaged(whereClause, orderBy, start, pageLength, out count);
			
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
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_Individual_Contact_ContactID key.
		///		FK_Individual_Contact_ContactID Description: Foreign key constraint referencing Contact.ContactID.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_contactId">Identifies the customer in the Contact table. Foreign key to Contact.ContactID.</param>
		/// <param name="count">out parameter to get total records for query</param>	
		/// <remarks></remarks>		
		/// <returns>Returns a typed collection of Nettiers.AdventureWorks.Entities.Individual objects.</returns>
		public override Nettiers.AdventureWorks.Entities.TList<Individual> GetByContactId(TransactionManager transactionManager, System.Int32 _contactId, int start, int pageLength, out int count)
		{
			try
			{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = Url;
			WsProxy.Individual[] items = proxy.IndividualProvider_GetByContactId(_contactId, start, pageLength, out count);
			
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
			
		#endregion
		
		
		#region Get By Index Functions
					
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_Individual_CustomerID index.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_customerId">Unique customer identification number. Foreign key to Customer.CustomerID.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="count">out parameter to get total records for query</param>	
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.Individual"/> class.</returns>
		public override Nettiers.AdventureWorks.Entities.Individual GetByCustomerId(TransactionManager transactionManager, System.Int32 _customerId, int start, int pageLength, out int count)
		{
			try
			{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = Url;
			WsProxy.Individual items = proxy.IndividualProvider_GetByCustomerId(_customerId, start, pageLength, out count);
			
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
		/// 	Gets rows from the datasource based on the PXML_Individual_Demographics index.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_demographics">Personal information such as hobbies, and income collected from online shoppers. Used for sales analysis.</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="count">out parameter to get total records for query</param>	
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="Nettiers.AdventureWorks.Entities.TList&lt;Individual&gt;"/> class.</returns>
		public override Nettiers.AdventureWorks.Entities.TList<Individual> GetByDemographics(TransactionManager transactionManager, string _demographics, int start, int pageLength, out int count)
		{
			try
			{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = Url;
			WsProxy.Individual[] items = proxy.IndividualProvider_GetByDemographics(_demographics, start, pageLength, out count);
			
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
		/// 	Inserts a Nettiers.AdventureWorks.Entities.Individual object into the datasource using a transaction.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">Nettiers.AdventureWorks.Entities.Individual object to insert.</param>		
		/// <remarks></remarks>		
		/// <returns>Returns true if operation is successful.</returns>
		public override bool Insert(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Individual entity)
		{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = Url;
			
			try
			{
				WsProxy.Individual result = proxy.IndividualProvider_Insert(Convert(entity));
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
		/// After inserting into the datasource, the Nettiers.AdventureWorks.Entities.Individual object will be updated
		/// to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		public override void BulkInsert(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.TList<Individual> entityList)
		{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = Url;
			try
			{
				proxy.IndividualProvider_BulkInsert(Convert(entityList));
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
		/// <param name="entity">Nettiers.AdventureWorks.Entities.Individual object to update.</param>		
		/// <remarks></remarks>
		/// <returns>Returns true if operation is successful.</returns>
		public override bool Update(TransactionManager transactionManager, Nettiers.AdventureWorks.Entities.Individual entity)
		{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = Url;
			
			try
			{
				WsProxy.Individual result = proxy.IndividualProvider_Update(Convert(entity));
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
