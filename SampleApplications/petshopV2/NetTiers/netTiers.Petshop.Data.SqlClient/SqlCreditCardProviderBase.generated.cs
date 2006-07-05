﻿
/*
	File Generated by NetTiers templates [www.nettiers.com]
	Generated on : Monday, July 03, 2006
	Important: Do not modify this file. Edit the file SqlCreditCardProvider.cs instead.
*/

#region using directives

using System;
using System.Data;
using System.Data.Common;

using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

using System.Collections;
using System.Collections.Specialized;

using System.Diagnostics;
using netTiers.Petshop.Entities;
using netTiers.Petshop.Data;
using netTiers.Petshop.Data.Bases;

#endregion

namespace netTiers.Petshop.Data.SqlClient
{
	///<summary>
	/// This class is the SqlClient Data Access Logic Component implementation for the <see cref="CreditCard"/> entity.
	///</summary>
	public partial class SqlCreditCardProviderBase : CreditCardProviderBase
	{
		#region Declarations
		
		string _connectionString;
	    bool _useStoredProcedure;
	    string _providerInvariantName;
			
		#endregion "Declarations"
			
		#region Constructors
		
		/// <summary>
		/// Creates a new <see cref="SqlCreditCardProviderBase"/> instance.
		/// </summary>
		public SqlCreditCardProviderBase()
		{
		}
	
	/// <summary>
	/// Creates a new <see cref="SqlCreditCardProviderBase"/> instance.
	/// Uses connection string to connect to datasource.
	/// </summary>
	/// <param name="connectionString">The connection string to the database.</param>
	/// <param name="useStoredProcedure">A boolean value that indicates if we use the stored procedures or embedded queries.</param>
	/// <param name="providerInvariantName">Name of the invariant provider use by the DbProviderFactory.</param>
	public SqlCreditCardProviderBase(string connectionString, bool useStoredProcedure, string providerInvariantName)
	{
		this._connectionString = connectionString;
		this._useStoredProcedure = useStoredProcedure;
		this._providerInvariantName = providerInvariantName;
	}
		
	#endregion "Constructors"
	
		#region Public properties
	/// <summary>
    /// Gets or sets the connection string.
    /// </summary>
    /// <value>The connection string.</value>
    public string ConnectionString
	{
		get {return this._connectionString;}
		set {this._connectionString = value;}
	}
	
	/// <summary>
    /// Gets or sets a value indicating whether to use stored procedures.
    /// </summary>
    /// <value><c>true</c> if we choose to use use stored procedures; otherwise, <c>false</c>.</value>
	public bool UseStoredProcedure
	{
		get {return this._useStoredProcedure;}
		set {this._useStoredProcedure = value;}
	}
	
	/// <summary>
    /// Gets or sets the invariant provider name listed in the DbProviderFactories machine.config section.
    /// </summary>
    /// <value>The name of the provider invariant.</value>
    public string ProviderInvariantName
    {
        get { return this._providerInvariantName; }
        set { this._providerInvariantName = value; }
    }
	#endregion
	
		#region Get Many To Many Relationship Functions
	#endregion
	
	
		#region Delete Functions
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="id">. Primary Key.</param>	
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="timestamp">The timestamp field used for concurrency check.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
        /// <exception cref="DBConcurrencyException">The record has been modified by an other user. Please reload the instance before deleting.</exception>
		public override bool Delete(TransactionManager transactionManager, System.String id, byte[] timestamp)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.CreditCard_Delete", _useStoredProcedure);
			database.AddInParameter(commandWrapper, "@Id", DbType.AnsiStringFixedLength, id);
			database.AddInParameter(commandWrapper, "@Timestamp", DbType.Binary, timestamp);
			
			int results = 0;
			
			if (transactionManager != null)
			{	
				results = Utility.ExecuteNonQuery(transactionManager, commandWrapper);
			}
			else
			{
				results = Utility.ExecuteNonQuery(database,commandWrapper);
			}
			
			//Stop Tracking Now that it has been updated and persisted.
			if (DataRepository.Provider.EnableEntityTracking)
			{
				string entityKey = EntityLocator.ConstructKeyFromPkItems(typeof(CreditCard)
					,id);
				EntityManager.StopTracking(entityKey);
			}
			
			if (results == 0)
			{
				throw new DBConcurrencyException ("The record has been modified by an other user. Please reload the instance before deleting.");
			}
			
			return Convert.ToBoolean(results);
		}//end Delete
		#endregion

		#region Find Functions
		/// <summary>
		/// 	Returns rows meeting the whereclause condition from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <remarks>Operators must be capitalized (OR, AND)</remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.CreditCard objects.</returns>
		public override netTiers.Petshop.Entities.TList<CreditCard> Find(TransactionManager transactionManager, string whereClause, int start, int pageLength, out int count)
		{
			count = -1;
			if (whereClause.IndexOf(";") > -1)
				return new netTiers.Petshop.Entities.TList<CreditCard>();
	
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.CreditCard_Find", _useStoredProcedure);

		bool searchUsingOR = false;
		if (whereClause.IndexOf("OR") > 0) // did they want to do "a=b OR c=d OR..."?
			searchUsingOR = true;
		
		database.AddInParameter(commandWrapper, "@SearchUsingOR", DbType.Boolean, searchUsingOR);
		
		database.AddInParameter(commandWrapper, "@Id", DbType.AnsiStringFixedLength, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Number", DbType.AnsiString, DBNull.Value);
		database.AddInParameter(commandWrapper, "@CardType", DbType.AnsiString, DBNull.Value);
		database.AddInParameter(commandWrapper, "@ExpiryMonth", DbType.AnsiString, DBNull.Value);
		database.AddInParameter(commandWrapper, "@ExpiryYear", DbType.AnsiString, DBNull.Value);
		database.AddInParameter(commandWrapper, "@Timestamp", DbType.Binary, DBNull.Value);
	
			// replace all instances of 'AND' and 'OR' because we already set searchUsingOR
			whereClause = whereClause.Replace("AND", "|").Replace("OR", "|") ; 
			string[] clauses = whereClause.ToLower().Split('|');
		
			// Here's what's going on below: Find a field, then to get the value we
			// drop the field name from the front, trim spaces, drop the '=' sign,
			// trim more spaces, and drop any outer single quotes.
			// Now handles the case when two fields start off the same way - like "Friendly='Yes' AND Friend='john'"
				
			char[] equalSign = {'='};
			char[] singleQuote = {'\''};
	   		foreach (string clause in clauses)
			{
				if (clause.Trim().StartsWith("id ") || clause.Trim().StartsWith("id="))
				{
					database.SetParameterValue(commandWrapper, "@Id", 
						clause.Replace("id","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("number ") || clause.Trim().StartsWith("number="))
				{
					database.SetParameterValue(commandWrapper, "@Number", 
						clause.Replace("number","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("cardtype ") || clause.Trim().StartsWith("cardtype="))
				{
					database.SetParameterValue(commandWrapper, "@CardType", 
						clause.Replace("cardtype","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("expirymonth ") || clause.Trim().StartsWith("expirymonth="))
				{
					database.SetParameterValue(commandWrapper, "@ExpiryMonth", 
						clause.Replace("expirymonth","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("expiryyear ") || clause.Trim().StartsWith("expiryyear="))
				{
					database.SetParameterValue(commandWrapper, "@ExpiryYear", 
						clause.Replace("expiryyear","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
				if (clause.Trim().StartsWith("timestamp ") || clause.Trim().StartsWith("timestamp="))
				{
					database.SetParameterValue(commandWrapper, "@Timestamp", 
						clause.Replace("timestamp","").Trim().TrimStart(equalSign).Trim().Trim(singleQuote));
					continue;
				}
	
				throw new ArgumentException("Unable to use this part of the where clause in this version of Find: " + clause);
			}
					
			IDataReader reader = null;
			//Create Collection
			netTiers.Petshop.Entities.TList<CreditCard> rows = new netTiers.Petshop.Entities.TList<CreditCard>();
	
				
			try
			{
				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}		
				
				Fill(reader, rows, start, pageLength);
				
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
			}
			finally
			{
				if (reader != null) 
					reader.Close();				
			}
			return rows;
		}
		
		#endregion "Find Functions"
	
		#region GetList Functions
				
		/// <summary>
		/// 	Gets All rows from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out. The number of rows that match this query.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.CreditCard objects.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override netTiers.Petshop.Entities.TList<CreditCard> GetAll(TransactionManager transactionManager, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.CreditCard_Get_List", _useStoredProcedure);
			
			IDataReader reader = null;
		
			//Create Collection
			netTiers.Petshop.Entities.TList<CreditCard> rows = new netTiers.Petshop.Entities.TList<CreditCard>();
			
			try
			{
				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}		
		
				Fill(reader, rows, start, pageLength);
				count = -1;
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
			}
			finally 
			{
				if (reader != null) 
					reader.Close();
			}
			return rows;
		}//end getall
		
		#endregion
				
		#region Paged Recordset
				
		/// <summary>
		/// Gets a page of rows from the DataSource.
		/// </summary>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">Number of rows in the DataSource.</param>
		/// <param name="whereClause">Specifies the condition for the rows returned by a query (Name='John Doe', Name='John Doe' AND Id='1', Name='John Doe' OR Id='1').</param>
		/// <param name="orderBy">Specifies the sort criteria for the rows in the DataSource (Name ASC; BirthDay DESC, Name ASC);</param>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of netTiers.Petshop.Entities.CreditCard objects.</returns>
		public override netTiers.Petshop.Entities.TList<CreditCard> GetPaged(TransactionManager transactionManager, string whereClause, string orderBy, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.CreditCard_GetPaged", _useStoredProcedure);
			
			database.AddInParameter(commandWrapper, "@WhereClause", DbType.String, whereClause);
			database.AddInParameter(commandWrapper, "@OrderBy", DbType.String, orderBy);
			database.AddInParameter(commandWrapper, "@PageIndex", DbType.Int32, start);
			database.AddInParameter(commandWrapper, "@PageSize", DbType.Int32, pageLength);
		
			IDataReader reader = null;
			//Create Collection
			netTiers.Petshop.Entities.TList<CreditCard> rows = new netTiers.Petshop.Entities.TList<CreditCard>();
			
			try
			{
				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}
				
				Fill(reader, rows, 0, int.MaxValue);
				count = rows.Count;

				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
			}
			catch(Exception)
			{			
				throw;
			}
			finally
			{
				if (reader != null) 
					reader.Close();
			}
			
			return rows;
		}
		
		#endregion	
		
		#region Get By Foreign Key Functions
	#endregion
	
		#region Get By Index Functions

		#region GetById
					
		/// <summary>
		/// 	Gets rows from the datasource based on the PK_CreditCard index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="id"></param>
		/// <param name="start">Row number at which to start reading.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <returns>Returns an instance of the <see cref="netTiers.Petshop.Entities.CreditCard"/> class.</returns>
		/// <remarks></remarks>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override netTiers.Petshop.Entities.CreditCard GetById(TransactionManager transactionManager, System.String id, int start, int pageLength, out int count)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.CreditCard_GetById", _useStoredProcedure);
			
				database.AddInParameter(commandWrapper, "@Id", DbType.AnsiStringFixedLength, id);
			
			IDataReader reader = null;
			netTiers.Petshop.Entities.TList<CreditCard> tmp = new netTiers.Petshop.Entities.TList<CreditCard>();
			try
			{
				if (transactionManager != null)
				{
					reader = Utility.ExecuteReader(transactionManager, commandWrapper);
				}
				else
				{
					reader = Utility.ExecuteReader(database, commandWrapper);
				}		
		
				//Create collection and fill
				Fill(reader, tmp, start, pageLength);
				count = -1;
				if(reader.NextResult())
				{
					if(reader.Read())
					{
						count = reader.GetInt32(0);
					}
				}
			}
			finally 
			{
				if (reader != null) 
					reader.Close();
			}
			
			if (tmp.Count == 1)
			{
				return tmp[0];
			}
			else if (tmp.Count == 0)
			{
				return null;
			}
			else
			{
				throw new DataException("Cannot find the unique instance of the class.");
			}
			
			//return rows;
		}
		
		#endregion

	#endregion Get By Index Functions

		#region Insert Functions
		/// <summary>
		/// Lets you efficiently bulk many entity to the database.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entities">The entities.</param>
		/// <remarks>
		///		After inserting into the datasource, the netTiers.Petshop.Entities.CreditCard object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		public override void BulkInsert(TransactionManager transactionManager, TList<netTiers.Petshop.Entities.CreditCard> entities)
		{
			//System.Data.SqlClient.SqlBulkCopy bulkCopy = new System.Data.SqlClient.SqlBulkCopy(this._connectionString, System.Data.SqlClient.SqlBulkCopyOptions.CheckConstraints); //, null);
			
			System.Data.SqlClient.SqlBulkCopy bulkCopy = null;
	
			if (transactionManager != null && transactionManager.IsOpen)
			{			
				System.Data.SqlClient.SqlConnection cnx = transactionManager.TransactionObject.Connection as System.Data.SqlClient.SqlConnection;
				System.Data.SqlClient.SqlTransaction transaction = transactionManager.TransactionObject as System.Data.SqlClient.SqlTransaction;
				bulkCopy = new System.Data.SqlClient.SqlBulkCopy(cnx, System.Data.SqlClient.SqlBulkCopyOptions.CheckConstraints, transaction); //, null);
			}
			else
			{
				bulkCopy = new System.Data.SqlClient.SqlBulkCopy(this._connectionString, System.Data.SqlClient.SqlBulkCopyOptions.CheckConstraints); //, null);
			}
			
			bulkCopy.BulkCopyTimeout = 360;
			bulkCopy.DestinationTableName = "CreditCard";
			
			DataTable dataTable = new DataTable();
			DataColumn col0 = dataTable.Columns.Add("Id", typeof(System.String));
			col0.AllowDBNull = false;		
			DataColumn col1 = dataTable.Columns.Add("Number", typeof(System.String));
			col1.AllowDBNull = false;		
			DataColumn col2 = dataTable.Columns.Add("CardType", typeof(System.String));
			col2.AllowDBNull = false;		
			DataColumn col3 = dataTable.Columns.Add("ExpiryMonth", typeof(System.String));
			col3.AllowDBNull = false;		
			DataColumn col4 = dataTable.Columns.Add("ExpiryYear", typeof(System.String));
			col4.AllowDBNull = false;		
			DataColumn col5 = dataTable.Columns.Add("Timestamp", typeof(System.Byte[]));
			col5.AllowDBNull = false;		
			
			bulkCopy.ColumnMappings.Add("Id", "Id");
			bulkCopy.ColumnMappings.Add("Number", "Number");
			bulkCopy.ColumnMappings.Add("CardType", "CardType");
			bulkCopy.ColumnMappings.Add("ExpiryMonth", "ExpiryMonth");
			bulkCopy.ColumnMappings.Add("ExpiryYear", "ExpiryYear");
			bulkCopy.ColumnMappings.Add("Timestamp", "Timestamp");
			
			foreach(netTiers.Petshop.Entities.CreditCard entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;
					
				DataRow row = dataTable.NewRow();
				
					row["Id"] = entity.Id;
							
				
					row["Number"] = entity.Number;
							
				
					row["CardType"] = entity.CardType;
							
				
					row["ExpiryMonth"] = entity.ExpiryMonth;
							
				
					row["ExpiryYear"] = entity.ExpiryYear;
							
				
					row["Timestamp"] = entity.Timestamp;
							
				
				dataTable.Rows.Add(row);
			}		
			
			// send the data to the server		
			bulkCopy.WriteToServer(dataTable);		
			
			// update back the state
			foreach(netTiers.Petshop.Entities.CreditCard entity in entities)
			{
				if (entity.EntityState != EntityState.Added)
					continue;
			
				entity.AcceptChanges();
			}
		}
				
		/// <summary>
		/// 	Inserts a netTiers.Petshop.Entities.CreditCard object into the datasource using a transaction.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">netTiers.Petshop.Entities.CreditCard object to insert.</param>
		/// <remarks>
		///		After inserting into the datasource, the netTiers.Petshop.Entities.CreditCard object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>	
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Insert(TransactionManager transactionManager, netTiers.Petshop.Entities.CreditCard entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.CreditCard_Insert", _useStoredProcedure);
			
			database.AddInParameter(commandWrapper, "@Id", DbType.AnsiStringFixedLength, entity.Id );
			database.AddInParameter(commandWrapper, "@Number", DbType.AnsiString, entity.Number );
			database.AddInParameter(commandWrapper, "@CardType", DbType.AnsiString, entity.CardType );
			database.AddInParameter(commandWrapper, "@ExpiryMonth", DbType.AnsiString, entity.ExpiryMonth );
			database.AddInParameter(commandWrapper, "@ExpiryYear", DbType.AnsiString, entity.ExpiryYear );
			database.AddOutParameter(commandWrapper, "@Timestamp", DbType.Binary, 8);
			
			int results = 0;
			
				
			if (transactionManager != null)
			{
				results = Utility.ExecuteNonQuery(transactionManager, commandWrapper);
			}
			else
			{
				results = Utility.ExecuteNonQuery(database,commandWrapper);
			}
					
			entity.Timestamp = (System.Byte[])database.GetParameterValue(commandWrapper, "@Timestamp");
			entity.OriginalId = entity.Id;
			
			entity.AcceptChanges();
	
			return Convert.ToBoolean(results);
		}	
		#endregion

		#region Update Functions
				
		/// <summary>
		/// 	Update an existing row in the datasource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">netTiers.Petshop.Entities.CreditCard object to update.</param>
		/// <remarks>
		///		After updating the datasource, the netTiers.Petshop.Entities.CreditCard object will be updated
		/// 	to refelect any changes made by the datasource. (ie: identity or computed columns)
		/// </remarks>
		/// <returns>Returns true if operation is successful.</returns>
        /// <exception cref="System.Exception">The command could not be executed.</exception>
        /// <exception cref="System.Data.DataException">The <paramref name="transactionManager"/> is not open.</exception>
        /// <exception cref="System.Data.Common.DbException">The command could not be executed.</exception>
		public override bool Update(TransactionManager transactionManager, netTiers.Petshop.Entities.CreditCard entity)
		{
			SqlDatabase database = new SqlDatabase(this._connectionString);
			DbCommand commandWrapper = StoredProcedureProvider.GetCommandWrapper(database, "dbo.CreditCard_Update", _useStoredProcedure);
			
			database.AddInParameter(commandWrapper, "@Id", DbType.AnsiStringFixedLength, entity.Id );
			database.AddInParameter(commandWrapper, "@OriginalId", DbType.AnsiStringFixedLength, entity.OriginalId);
			database.AddInParameter(commandWrapper, "@Number", DbType.AnsiString, entity.Number );
			database.AddInParameter(commandWrapper, "@CardType", DbType.AnsiString, entity.CardType );
			database.AddInParameter(commandWrapper, "@ExpiryMonth", DbType.AnsiString, entity.ExpiryMonth );
			database.AddInParameter(commandWrapper, "@ExpiryYear", DbType.AnsiString, entity.ExpiryYear );
			database.AddInParameter(commandWrapper, "@Timestamp", DbType.Binary, entity.Timestamp );
			database.AddOutParameter(commandWrapper, "@ReturnedTimestamp", DbType.Binary, 8);
			
			int results = 0;
			
			
			if (transactionManager != null)
			{
				results = Utility.ExecuteNonQuery(transactionManager, commandWrapper);
			}
			else
			{
				results = Utility.ExecuteNonQuery(database,commandWrapper);
			}
			
			//Stop Tracking Now that it has been updated and persisted.
			if (DataRepository.Provider.EnableEntityTracking)
				EntityManager.StopTracking(entity.EntityTrackingKey);
			
			if (results == 0)
			{
				throw new DBConcurrencyException("Concurrency exception");
			}
		
			entity.Timestamp = (System.Byte[])database.GetParameterValue(commandWrapper, "@ReturnedTimestamp");
			entity.OriginalId = entity.Id;
			
			entity.AcceptChanges();
	
			return Convert.ToBoolean(results);
		}
			
		#endregion
		
		#region Custom Methods
	
		#endregion
	}//end class
} // end namespace
