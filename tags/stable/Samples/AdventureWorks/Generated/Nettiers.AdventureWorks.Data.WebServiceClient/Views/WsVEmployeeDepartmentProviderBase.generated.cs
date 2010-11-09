﻿
/*
	File Generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file VEmployeeDepartment.cs instead.
*/

#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Web.Services.Protocols;
using System.Diagnostics;
using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data.Bases;

#endregion

namespace Nettiers.AdventureWorks.Data.WebServiceClient
{

	/// <summary>
	///	This class is the base repository for the CRUD operations on the VEmployeeDepartment objects.
	/// </summary>
	public partial class WsVEmployeeDepartmentProviderBase : VEmployeeDepartmentProviderBase
	{
		#region Declarations	
			
		/// <summary>
		/// the Url of the webservice.
		/// </summary>
		private string url;
			
		#endregion 
		
		#region Constructors
	
		/// <summary>
		/// Creates a new <see cref="WsVEmployeeDepartmentProviderBase"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		public WsVEmployeeDepartmentProviderBase()
		{		
		}
		
		/// <summary>
		/// Creates a new <see cref="WsVEmployeeDepartmentProviderBase"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		/// <param name="url">The url to the webservice.</param>
		public WsVEmployeeDepartmentProviderBase(string url)
		{
			this.url = url;
		}
			
		#endregion Constructors
		
		#region Url
		///<summary>
		/// Current URL for webservice endpoint. 
		///</summary>
		public string Url
        {
        	get {return this.url;}
        	set {this.url = value;}
        }
		#endregion 
	
		#region Convertion utility
		
		/// <summary>
		/// Convert a collection from the ws proxy to a nettiers collection.
		/// </summary>
		public static VList<VEmployeeDepartment> Convert(WsProxy.VEmployeeDepartment[] items)
		{
			VList<VEmployeeDepartment> outItems = new VList<VEmployeeDepartment>();
			foreach(WsProxy.VEmployeeDepartment item in items)
			{
				outItems.Add(Convert(item));
			}
			return outItems;
		}
		
		/// <summary>
		/// Convert a nettiers collection to the ws proxy collection.
		/// </summary>
		public static VEmployeeDepartment Convert(WsProxy.VEmployeeDepartment item)
		{			
			VEmployeeDepartment outItem = new VEmployeeDepartment();			
			outItem.EmployeeId = item.EmployeeId;
			outItem.Title = item.Title;
			outItem.FirstName = item.FirstName;
			outItem.MiddleName = item.MiddleName;
			outItem.LastName = item.LastName;
			outItem.Suffix = item.Suffix;
			outItem.JobTitle = item.JobTitle;
			outItem.Department = item.Department;
			outItem.GroupName = item.GroupName;
			outItem.StartDate = item.StartDate;
							
			outItem.AcceptChanges();			
			return outItem;
		}
		
		/// <summary>
		/// Convert a nettiers entity to the ws proxy entity.
		/// </summary>
		public static WsProxy.VEmployeeDepartment Convert(VEmployeeDepartment item)
		{			
			WsProxy.VEmployeeDepartment outItem = new WsProxy.VEmployeeDepartment();			
			outItem.EmployeeId = item.EmployeeId;
			outItem.Title = item.Title;
			outItem.FirstName = item.FirstName;
			outItem.MiddleName = item.MiddleName;
			outItem.LastName = item.LastName;
			outItem.Suffix = item.Suffix;
			outItem.JobTitle = item.JobTitle;
			outItem.Department = item.Department;
			outItem.GroupName = item.GroupName;
			outItem.StartDate = item.StartDate;
							
			return outItem;
		}
		
		#endregion
	
		#region Get Methods
		/// <summary>
		/// 	Gets All rows from the DataSource by a specific predicate filter.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of total rows.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of VEmployeeDepartment objects.</returns>
		public override VList<VEmployeeDepartment> Get(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			try
			{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = this.url;
				
			WsProxy.VEmployeeDepartment[] items = proxy.VEmployeeDepartmentProvider_Get(whereClause, orderBy, start, pageLength, out count);
			
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
		#endregion Get Methods
		
		#region GetAll Methods
						
		/// <summary>
		/// 	Gets All rows from the DataSource a specific predicate filter.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of VEmployeeDepartment objects.</returns>
		public override VList<VEmployeeDepartment> GetAll(TransactionManager transactionManager, int start, int pageLength)
		{
			try
			{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = this.url;
				
			WsProxy.VEmployeeDepartment[] items = proxy.VEmployeeDepartmentProvider_GetAll(start, pageLength);			
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
		/// 	Gets All rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">count of records returned</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of VEmployeeDepartment objects.</returns>
		public override VList<VEmployeeDepartment> GetAll(TransactionManager transactionManager, int start, int pageLength, out int count)
		{
			try
			{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = this.url;
				
			WsProxy.VEmployeeDepartment[] items = proxy.VEmployeeDepartmentProvider_GetAll(start, pageLength);   
			
			count = items.Length;
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
	
		#region Get Methods
			
		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of VEmployeeDepartment objects.</returns>
		public override VList<VEmployeeDepartment> Get(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength)
		{
			try
			{
			WsProxy.AdventureWorksServices proxy = new WsProxy.AdventureWorksServices();
			proxy.Url = this.url;
					
			int count;
			WsProxy.VEmployeeDepartment[] items = proxy.VEmployeeDepartmentProvider_Get(whereClause, orderBy, start, pageLength, out count);
				
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
		
		#endregion Get Methods
	
	#region Custom Methods
	

	#endregion

	
	
	}//end class
} // end namespace
