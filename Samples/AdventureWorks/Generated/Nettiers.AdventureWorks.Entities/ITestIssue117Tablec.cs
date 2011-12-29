﻿using System;
using System.ComponentModel;

namespace Nettiers.AdventureWorks.Entities
{
	/// <summary>
	///		The data structure representation of the 'TestIssue117TableC' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface ITestIssue117Tablec 
	{
		/// <summary>			
		/// TestIssue117TableAId : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "TestIssue117TableC"</remarks>
		System.Int32 TestIssue117TableAid { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.Int32 OriginalTestIssue117TableAid { get; set; }
			
		/// <summary>			
		/// TestIssue117TableBId : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "TestIssue117TableC"</remarks>
		System.Int32 TestIssue117TableBid { get; set; }
				
		/// <summary>
		/// keep a copy of the original so it can be used for editable primary keys.
		/// </summary>
		System.Int32 OriginalTestIssue117TableBid { get; set; }
			
		
		
		/// <summary>
		/// DumbField : 
		/// </summary>
		System.Boolean?  DumbField  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}

