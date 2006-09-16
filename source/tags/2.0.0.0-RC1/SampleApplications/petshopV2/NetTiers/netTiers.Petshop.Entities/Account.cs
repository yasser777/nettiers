﻿#region Using directives

using System;
using System.ComponentModel;
using System.Collections;
using System.Xml.Serialization;

#endregion

namespace netTiers.Petshop.Entities
{	
	///<summary>
	/// An object representation of the 'Account' table. [No description found the database]	
	///</summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>	
	[Serializable]
	[CLSCompliant(true)]
	public partial class Account:  AccountBase
	{		
		
		#region Constructors
		///<summary>
		/// Creates a new <see cref="Account"/> instance.
		///</summary>
		public Account():base(){}	
		
		#endregion
	}
}
