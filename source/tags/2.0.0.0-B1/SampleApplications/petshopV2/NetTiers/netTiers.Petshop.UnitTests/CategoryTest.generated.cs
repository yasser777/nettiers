﻿

/*
	File Generated by NetTiers templates [www.nettiers.com]
	Generated on : Monday, July 03, 2006
	Important: Do not modify this file. Edit the file CategoryTest.cs instead.
*/

#region Using directives

using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using NUnit.Framework;
using netTiers.Petshop.Entities;
using netTiers.Petshop.Data;

#endregion

namespace netTiers.Petshop.UnitTests
{
    /// <summary>
    /// Provides tests for the and <see cref="Category"/> objects (entity, collection and repository).
    /// </summary>
   public partial class CategoryTest
    {
    	// the Category instance used to test the repository.
		static private Category mock;
		
		// the TList<Category> instance used to test the repository.
		static TList<Category> mockCollection;
		
		static TransactionManager transactionManager = null;
        
        /// <summary>
		/// This method is used to construct the test environment prior to running the tests.
		/// </summary>        
        static public void Init_Generated()
        {
			mock = (Category)CreateMockInstance();						
			
        	if (DataRepository.Provider.IsTransactionSupported)
			{
				transactionManager = DataRepository.Provider.CreateTransaction();
				transactionManager.BeginTransaction();
			}
			
			System.Console.WriteLine(new String('-', 75));
			System.Console.WriteLine("-- Testing the Category Entity with the {0} --", netTiers.Petshop.Data.DataRepository.Provider.Name);
			System.Console.WriteLine(new String('-', 75));
        }
    
    	/// <summary>
		/// This method is used to restore the environment after the tests are completed.
		/// </summary>
		static public void CleanUp_Generated()
        {   
        	if (DataRepository.Provider.IsTransactionSupported && transactionManager!=null && transactionManager.IsOpen)
			{
				transactionManager.Rollback();
			}
			
			System.Console.WriteLine();
			System.Console.WriteLine();
        }
    
    
		/// <summary>
		/// Inserts a mock Category entity into the database.
		/// </summary>
		private void Step_01_Insert_Generated()
		{
			Assert.IsTrue(DataRepository.CategoryProvider.Insert(transactionManager, mock), "Insert failed");
									
			System.Console.WriteLine("DataRepository.CategoryProvider.Insert(mock):");			
			System.Console.WriteLine(mock);			
		}
		
		
		/// <summary>
		/// Selects all Category objects of the database.
		/// </summary>
		private void Step_02_SelectAll_Generated()
		{
			mockCollection = DataRepository.CategoryProvider.GetAll(transactionManager);
			Assert.IsTrue(mockCollection.Count > 0, "No records returned.");
			System.Console.WriteLine("DataRepository.CategoryProvider.GetAll():");			
			System.Console.WriteLine(mockCollection);
					
			
			// get paged
			int count = 0;
			DataRepository.CategoryProvider.GetPaged(transactionManager, 0, 10, out count);
			System.Console.WriteLine("#get paged count: " + count.ToString());
		}
		
		
		
		
		/// <summary>
		/// Deep load all Category children.
		/// </summary>
		private void Step_03_DeepLoad_Generated()
		{
			if (mockCollection.Count > 0)
			{
				//mockCollection.Shuffle();			
				DataRepository.CategoryProvider.DeepLoad(mockCollection[0]);
				System.Console.WriteLine("Category instance correctly deep loaded at 1 level.");
								
				mockCollection.Add(mock);
				DataRepository.CategoryProvider.DeepSave(transactionManager, mockCollection);
				
			}			
		}
		
		/// <summary>
		/// Updates a mock Category entity into the database.
		/// </summary>
		private void Step_04_Update_Generated()
		{
			UpdateMockInstance(mock);
			Assert.IsTrue(DataRepository.CategoryProvider.Update(transactionManager, mock), "Update failed.");			
		
			// TODO : select sur l'id
			// TODO : verif si l'object recup? est egal
			
			System.Console.WriteLine("DataRepository.CategoryProvider.Update(mock):");			
			System.Console.WriteLine(mock);
		}
		
		
		/// <summary>
		/// Delete the mock Category entity into the database.
		/// </summary>
		private void Step_05_Delete_Generated()
		{
			Assert.IsTrue(DataRepository.CategoryProvider.Delete(transactionManager, mock), "Delete failed.");
			System.Console.WriteLine("DataRepository.CategoryProvider.Delete(mock):");			
			System.Console.WriteLine(mock);
		}
		
		#region Serialization tests
		
		/// <summary>
		/// Serialize the mock Category entity into a temporary file.
		/// </summary>
		private void Step_06_SerializeEntity_Generated()
		{
			string fileName = "temp_Category.xml";
		
			//XmlSerializer mySerializer = new XmlSerializer(typeof(Category)); 
			//StreamWriter myWriter = new StreamWriter(fileName); 
			//mySerializer.Serialize(myWriter, this.mock); 
			//myWriter.Close();
			EntityHelper.SerializeXml(mock, fileName);
			System.Console.WriteLine("mock correctly serialized to a temporary file.");			
		}
		
		/// <summary>
		/// Deserialize the mock Category entity from a temporary file.
		/// </summary>
		private void Step_07_DeserializeEntity_Generated()
		{
			string fileName = "temp_Category.xml";
		
			//XmlSerializer mySerializer = new XmlSerializer(typeof(Category)); 
			//FileStream myFileStream = new FileStream(fileName,  FileMode.Open); 
			//this.mock = (Category) mySerializer.Deserialize(myFileStream);
			//myFileStream.Close();
			StreamReader sr = File.OpenText(fileName);
			object item = EntityHelper.DeserializeEntityXml<Category>(sr.ReadToEnd());
			sr.Close();
			File.Delete(fileName);
			
			System.Console.WriteLine("mock correctly deserialized from a temporary file.");
		}
		
		/// <summary>
		/// Serialize a Category collection into a temporary file.
		/// </summary>
		private void Step_08_SerializeCollection_Generated()
		{
			string fileName = "temp_CategoryCollection.xml";
		
			TList<Category> mockCollection = new TList<Category>();
			mockCollection.Add(mock);
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<Category>)); 
			StreamWriter myWriter = new StreamWriter(fileName); 
			mySerializer.Serialize(myWriter, mockCollection); 
			myWriter.Close();
			
			System.Console.WriteLine("TList<Category> correctly serialized to a temporary file.");					
		}
		
		
		/// <summary>
		/// Deserialize a Category collection from a temporary file.
		/// </summary>
		private void Step_09_DeserializeCollection_Generated()
		{
			string fileName = "temp_CategoryCollection.xml";
		
			XmlSerializer mySerializer = new XmlSerializer(typeof(TList<Category>)); 
			FileStream myFileStream = new FileStream(fileName,  FileMode.Open); 
			TList<Category> mockCollection = (TList<Category>) mySerializer.Deserialize(myFileStream);
			myFileStream.Close();
			File.Delete(fileName);
			System.Console.WriteLine("TList<Category> correctly deserialized from a temporary file.");	
		}
		#endregion
		
		
		
		/// <summary>
		/// Check the foreign key dal methods.
		/// </summary>
		private void Step_10_FK_Generated()
		{
			Category entity = mockCollection[0].Clone() as Category;
			
		}
		
		
		/// <summary>
		/// Check the indexes dal methods.
		/// </summary>
		private void Step_11_IX_Generated()
		{
			Category entity = mockCollection[0].Clone() as Category;
			
			Category t0 = DataRepository.CategoryProvider.GetById(transactionManager, entity.Id);
		}
		
		/// <summary>
		/// Test methods exposed by the EntityHelper class.
		/// </summary>
		private void Step_20_TestEntityHelper_Generated()
		{
			Category entity = mock.Copy() as Category;
			//Assert.IsTrue(EntityHelper.AreObjectsEqual(entity, mock), "Copy is working");

			entity = (Category)mock.Clone();
			//Assert.IsTrue(EntityHelper.AreObjectsEqual(entity, mock), "Clone is working");
			
			Assert.IsTrue(entity.Equals(mock), "Clone is working");


			//Assert.IsTrue(EntityHelper.AreObjectsEqual(mockCollection[0], mockCollection[0]), "AreObjectEqual");
		}
		
		
						
		#region Mock Instance
		///<summary>
		///  Returns a Typed Category Entity with mock values.
		///</summary>
		static public Category CreateMockInstance()
		{		
			Category mock = new Category();
						
			mock.Id = "QVRFXLOZCOVTIIXRA";
			mock.Name = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
			mock.AdvicePhoto = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS";
			
		
			// create a temporary collection and add the item to it
			TList<Category> tempMockCollection = new TList<Category>();
			tempMockCollection.Add(mock);
			tempMockCollection.Remove(mock);
			
		
		   return (Category)mock;
		}
		
		
		///<summary>
		///  Update the Typed Category Entity with modified mock values.
		///</summary>
		static public void UpdateMockInstance(Category mock)
		{
			mock.Id = "QVRFXLOZCOVTIIXRA2";
			mock.Name = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS2";
			mock.AdvicePhoto = "OUWMCRJRPTDWHBFTWDCDPUHBBPHUJOSRZERGKGYNGTFOJUFLMXBNFELVNVKOLQIABMXDKZIPFPXWOUSIJWIMNFMVTWTQWKCQLFNWXDBNOMIQIPGTCDEPIWNWBCKOGS2";
			
		}

		#endregion
    }
}
