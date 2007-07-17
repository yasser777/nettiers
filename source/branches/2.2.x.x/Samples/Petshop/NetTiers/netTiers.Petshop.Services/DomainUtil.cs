using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using netTiers.Petshop.Entities;
using netTiers.Petshop.Data;
using netTiers.Petshop.Data.Bases;

using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace netTiers.Petshop.Services
{
	/// <summary>
	/// DomainUtil class.
	/// </summary>
    [Serializable]
    public static class DomainUtil
	{
		
        /// <summary>
        /// Validates the or create transaction.
        /// </summary>
        /// <param name="transactionManager">The transaction manager.</param>
        /// <param name="dataProvider">The data provider.</param>
        /// <param name="isBorrowedTransaction">if set to <c>true</c> [is borrowed transaction].</param>
        /// <returns>a valid TransactionManager</returns>
		public static TransactionManager ValidateOrCreateTransaction(TransactionManager transactionManager, NetTiersProvider dataProvider, bool isBorrowedTransaction)
		{
			if (isBorrowedTransaction && !dataProvider.IsTransactionSupported)
			{
				if (transactionManager != null)
					throw new Exception("Transaction Support is not included with the current DataRepository provider.  If using a provider that doesn't support transactions, such as a webservice, you should turn off transaction management.");
			}
			else if (isBorrowedTransaction && dataProvider.IsTransactionSupported)
			{
				if (transactionManager == null || !transactionManager.IsOpen )
					throw new ArgumentException("The transactionManager is in an invalid state for this method.  \nYou must begin the tranasction prior to using this method.");

			}
			else if (!isBorrowedTransaction && dataProvider.IsTransactionSupported)
			{
					transactionManager = dataProvider.CreateTransaction();
					transactionManager.BeginTransaction();
			}
			
			return transactionManager;
		}
		
        /// <summary>
        /// Gets the data provider.
        /// </summary>
        /// <param name="connectionStringKey">The connection string key.</param>
        /// <param name="dynamicConnectionString">The dynamic connection string.</param>
        /// <param name="defaultDataProvider">returns the default instance of the date provider for caller.</param>
        /// <returns></returns>
		public static NetTiersProvider GetDataProvider(string connectionStringKey, string dynamicConnectionString, NetTiersProvider defaultDataProvider)
		{
			if (connectionStringKey == null)
				return defaultDataProvider;
			
			if (!DataRepository.Connections.ContainsKey(connectionStringKey) && dynamicConnectionString != null)
			{
				DataRepository.AddConnection(connectionStringKey, dynamicConnectionString);
				return DataRepository.Connections[connectionStringKey].Provider;
			}
			else if (DataRepository.Connections.ContainsKey(connectionStringKey)) 
			{
				return DataRepository.Connections[connectionStringKey].Provider;
			}
			
			return defaultDataProvider;
		}
		
		/// <summary>
		/// Wraps call to tohe <see cref="ExceptionPolicy"/> class which handles all exceptions based on the security policy.
		/// </summary>
		public static bool HandleException(Exception e, string policyName)
		{
			return ExceptionPolicy.HandleException(e, policyName);
		}
	}
}