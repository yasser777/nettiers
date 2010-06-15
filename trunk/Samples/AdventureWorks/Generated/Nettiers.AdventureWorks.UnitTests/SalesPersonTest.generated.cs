﻿

/*
	File Generated by NetTiers templates [www.nettiers.com]
	Important: Do not modify this file. Edit the file SalesPersonTest.cs instead.
*/

#region Using directives

using System;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;
using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data;
using Nettiers.AdventureWorks.Data.Bases;

#endregion

namespace Nettiers.AdventureWorks.UnitTests
{
    /// <summary>
    /// Provides tests for the and <see cref="SalesPerson"/> objects (entity, collection and repository).
    /// </summary>
   public partial class SalesPersonTest
    {
    	// the SalesPerson instance used to test the repository.
		protected SalesPerson mock;
		
		// the TList<SalesPerson> instance used to test the repository.
		protected TList<SalesPerson> mockCollection;
		
		protected static TransactionManager CreateTransaction()
		{
			TransactionManager transactionManager = null;
			if (DataRepository.Provider.IsTransactionSupported)
			{
				transactionManager = DataRepository.Provider.CreateTransaction();
				transactionManager.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
			}			
			return transactionManager;
		}
		       
        /// <summary>
		/// This method is used to construct the test environment prior to running the tests.
		/// </summary>        
        static public void Init_Generated()
        {		
        	System.Console.WriteLine(new String('-', 75));
			System.Console.WriteLine("-- Testing the SalesPerson Entity with the {0} --", Nettiers.AdventureWorks.Data.DataRepository.Provider.Name);
			System.Console.WriteLine(new String('-', 75));
        }
    
    	/// <summary>
		/// This method is used to restore the environment after the tests are completed.
		/// </summary>
		static public void CleanUp_Generated()
        {   		
			System.Console.WriteLine("All Tests Completed");
			System.Console.WriteLine();
        }
    
    
		/// <summary>
		/// Inserts a mock SalesPerson entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.SalesPersonProvider.Insert(tm, mock), "Insert failed");
										
				System.Console.WriteLine("DataRepository.SalesPersonProvider.Insert(mock):");			
				System.Console.WriteLine(mock);			
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Selects all SalesPerson objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Find
				int count = -1;
				
				mockCollection = DataRepository.SalesPersonProvider.Find(tm, null, "", 0, 10, out count );
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue Find Command.");
				
				System.Console.WriteLine("DataRepository.SalesPersonProvider.Find():");			
				System.Console.WriteLine(mockCollection);
				
				// GetPaged
				count = -1;
				
				mockCollection = DataRepository.SalesPersonProvider.GetPaged(tm, 0, 10, out count);
				Assert.IsTrue(count >= 0 && mockCollection != null, "Query Failed to issue GetPaged Command.");
				System.Console.WriteLine("#get paged count: " + count.ToString());
			}
		}
		
		
		
		
		/// <summary>
		/// Deep load all SalesPerson children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				int count = -1;
				mock =  CreateMockInstance(tm);
				mockCollection = DataRepository.SalesPersonProvider.GetPaged(tm, 0, 10, out count);
			
				DataRepository.SalesPersonProvider.DeepLoading += new EntityProviderBaseCore<SalesPerson, SalesPersonKey>.DeepLoadingEventHandler(
						delegate(object sender, DeepSessionEventArgs e)
						{
							if (e.DeepSession.Count > 3)
								e.Cancel = true;
						}
					);

				if (mockCollection.Count > 0)
				{
					
					DataRepository.SalesPersonProvider.DeepLoad(tm, mockCollection[0]);
					System.Console.WriteLine("SalesPerson instance correctly deep loaded at 1 level.");
									
					mockCollection.Add(mock);
					// DataRepository.SalesPersonProvider.DeepSave(tm, mockCollection);
				}
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		/// <summary>
		/// Updates a mock SalesPerson entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				SalesPerson mock = CreateMockInstance(tm);
				Assert.IsTrue(DataRepository.SalesPersonProvider.Insert(tm, mock), "Insert failed");
				
				UpdateMockInstance(tm, mock);
				Assert.IsTrue(DataRepository.SalesPersonProvider.Update(tm, mock), "Update failed.");			
				
				System.Console.WriteLine("DataRepository.SalesPersonProvider.Update(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		
		/// <summary>
		/// Delete the mock SalesPerson entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  (SalesPerson)CreateMockInstance(tm);
				DataRepository.SalesPersonProvider.Insert(tm, mock);
			
				Assert.IsTrue(DataRepository.SalesPersonProvider.Delete(tm, mock), "Delete failed.");
				System.Console.WriteLine("DataRepository.SalesPersonProvider.Delete(mock):");			
				System.Console.WriteLine(mock);
				
				//normally one would commit here
				//tm.Commit();
				//IDisposable will Rollback Transaction since it's left uncommitted
			}
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock SalesPerson entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{	
			using (TransactionManager tm = CreateTransaction())
			{
				mock =  CreateMockInstance(tm);
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_SalesPerson.xml");
			
				EntityHelper.SerializeXml(mock, fileName);
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock not found");
					
				System.Console.WriteLine("mock correctly serialized to a temporary file.");			
			}
		}
		
		/// <summary>
		/// Deserialize the mock SalesPerson entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_SalesPerson.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			using (System.IO.StreamReader sr = System.IO.File.OpenText(fileName))
			{
				object item = EntityHelper.DeserializeEntityXml<SalesPerson>(sr.ReadToEnd());
				sr.Close();
			}
			System.IO.File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a SalesPerson collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_SalesPersonCollection.xml");
				
				mock = CreateMockInstance(tm);
				TList<SalesPerson> mockCollection = new TList<SalesPerson>();
				mockCollection.Add(mock);
			
				EntityHelper.SerializeXml(mockCollection, fileName);
				
				Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock collection not found");
				System.Console.WriteLine("TList<SalesPerson> correctly serialized to a temporary file.");					
			}
		}
		
		
		/// <summary>
		/// Deserialize a SalesPerson collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "temp_SalesPersonCollection.xml");
			Assert.IsTrue(System.IO.File.Exists(fileName), "Serialized mock file not found to deserialize");
			
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<SalesPerson>)); 
			using (System.IO.FileStream myFileStream = new System.IO.FileStream(fileName,  System.IO.FileMode.Open))
			{
				TList<SalesPerson> mockCollection = (TList<SalesPerson>) mySerializer.Deserialize(myFileStream);
				myFileStream.Close();
			}
			
			System.IO.File.Delete(fileName);
			System.Console.WriteLine("TList<SalesPerson> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				SalesPerson entity = CreateMockInstance(tm);
				bool result = DataRepository.SalesPersonProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test FK, Insert Failed");
				
				TList<SalesPerson> t1 = DataRepository.SalesPersonProvider.GetByTerritoryId(tm, entity.TerritoryId, 0, 10);
			}
		}
		
		
		/// <summary>
		/// Check the indexes dal methods.
		/// </summary>
		private void Step_11_IX_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				SalesPerson entity = CreateMockInstance(tm);
				bool result = DataRepository.SalesPersonProvider.Insert(tm, entity);
				
				Assert.IsTrue(result, "Could Not Test IX, Insert Failed");

			
				SalesPerson t0 = DataRepository.SalesPersonProvider.GetByRowguid(tm, entity.Rowguid);
				SalesPerson t1 = DataRepository.SalesPersonProvider.GetBySalesPersonId(tm, entity.SalesPersonId);
			}
		}
		
		/// <summary>
		/// Test methods exposed by the EntityHelper class.
		/// </summary>
		private void Step_20_TestEntityHelper_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				mock = CreateMockInstance(tm);
				
				SalesPerson entity = mock.Copy() as SalesPerson;
				entity = (SalesPerson)mock.Clone();
				Assert.IsTrue(SalesPerson.ValueEquals(entity, mock), "Clone is not working");
			}
		}
		
		/// <summary>
		/// Test Find using the Query class
		/// </summary>
		private void Step_30_TestFindByQuery_Generated()
		{
			using (TransactionManager tm = CreateTransaction())
			{
				//Insert Mock Instance
				SalesPerson mock = CreateMockInstance(tm);
				bool result = DataRepository.SalesPersonProvider.Insert(tm, mock);
				
				Assert.IsTrue(result, "Could Not Test FindByQuery, Insert Failed");

				SalesPersonQuery query = new SalesPersonQuery();
			
				query.AppendEquals(SalesPersonColumn.SalesPersonId, mock.SalesPersonId.ToString());
				if(mock.TerritoryId != null)
					query.AppendEquals(SalesPersonColumn.TerritoryId, mock.TerritoryId.ToString());
				if(mock.SalesQuota != null)
					query.AppendEquals(SalesPersonColumn.SalesQuota, mock.SalesQuota.ToString());
				query.AppendEquals(SalesPersonColumn.Bonus, mock.Bonus.ToString());
				query.AppendEquals(SalesPersonColumn.CommissionPct, mock.CommissionPct.ToString());
				query.AppendEquals(SalesPersonColumn.SalesYtd, mock.SalesYtd.ToString());
				query.AppendEquals(SalesPersonColumn.SalesLastYear, mock.SalesLastYear.ToString());
				query.AppendEquals(SalesPersonColumn.Rowguid, mock.Rowguid.ToString());
				query.AppendEquals(SalesPersonColumn.ModifiedDate, mock.ModifiedDate.ToString());
				
				TList<SalesPerson> results = DataRepository.SalesPersonProvider.Find(tm, query);
				
				Assert.IsTrue(results.Count == 1, "Find is not working correctly.  Failed to find the mock instance");
			}
		}
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed SalesPerson Entity with mock values.
		///</summary>
		static public SalesPerson CreateMockInstance_Generated(TransactionManager tm)
		{		
			SalesPerson mock = new SalesPerson();
						
			mock.SalesQuota = TestUtility.Instance.RandomShort();
			mock.Bonus = TestUtility.Instance.RandomShort();
			mock.CommissionPct = TestUtility.Instance.RandomShort();
			mock.SalesYtd = TestUtility.Instance.RandomShort();
			mock.SalesLastYear = TestUtility.Instance.RandomShort();
			mock.ModifiedDate = TestUtility.Instance.RandomDateTime();
			
			//OneToOneRelationship
			Employee mockEmployeeBySalesPersonId = EmployeeTest.CreateMockInstance(tm);
			DataRepository.EmployeeProvider.Insert(tm, mockEmployeeBySalesPersonId);
			mock.SalesPersonId = mockEmployeeBySalesPersonId.EmployeeId;
			int count1 = 0;
			TList<SalesTerritory> _collection1 = DataRepository.SalesTerritoryProvider.GetPaged(tm, 0, 10, out count1);
			//_collection1.Shuffle();
			if (_collection1.Count > 0)
			{
				mock.TerritoryId = _collection1[0].TerritoryId;
						
			}
		
			// create a temporary collection and add the item to it
			TList<SalesPerson> tempMockCollection = new TList<SalesPerson>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (SalesPerson)mock;
		}
		
		
		///<summary>
		///  Update the Typed SalesPerson Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance_Generated(TransactionManager tm, SalesPerson mock)
		{
			mock.SalesQuota = TestUtility.Instance.RandomShort();
			mock.Bonus = TestUtility.Instance.RandomShort();
			mock.CommissionPct = TestUtility.Instance.RandomShort();
			mock.SalesYtd = TestUtility.Instance.RandomShort();
			mock.SalesLastYear = TestUtility.Instance.RandomShort();
			mock.ModifiedDate = TestUtility.Instance.RandomDateTime();
			
			//OneToOneRelationship
			Employee mockEmployeeBySalesPersonId = EmployeeTest.CreateMockInstance(tm);
			DataRepository.EmployeeProvider.Insert(tm, mockEmployeeBySalesPersonId);
			mock.SalesPersonId = mockEmployeeBySalesPersonId.EmployeeId;
					
			int count1 = 0;
			TList<SalesTerritory> _collection1 = DataRepository.SalesTerritoryProvider.GetPaged(tm, 0, 10, out count1);
			//_collection1.Shuffle();
			if (_collection1.Count > 0)
			{
				mock.TerritoryId = _collection1[0].TerritoryId;
			}
		}
		#endregion
    }
}