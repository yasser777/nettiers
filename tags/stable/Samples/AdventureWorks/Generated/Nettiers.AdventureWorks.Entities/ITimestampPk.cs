﻿using System;
using System.ComponentModel;

namespace Nettiers.AdventureWorks.Entities
{
	/// <summary>
	///		The data structure representation of the 'TimestampPK' table via interface.
	/// </summary>
	/// <remarks>
	/// 	This struct is generated by a tool and should never be modified.
	/// </remarks>
	public interface ITimestampPk 
	{
		/// <summary>			
		/// TimestampPK : 
		/// </summary>
		/// <remarks>Member of the primary key of the underlying table "TimestampPK"</remarks>
		System.Byte[] TimestampPk { get; set; }
				
		
		
		/// <summary>
		/// SomeText : 
		/// </summary>
		System.String  SomeText  { get; set; }
			
		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		System.Object Clone();
		
		#region Data Properties

		#endregion Data Properties

	}
}

