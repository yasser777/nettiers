﻿#region Using directives

using System;
using System.Data;
using System.Collections;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.ComponentModel;
using Nettiers.AdventureWorks.Entities;
using Nettiers.AdventureWorks.Data;

#endregion

namespace Nettiers.AdventureWorks.Data.WebServiceClient
{
	///<summary>
	/// This class is the WebServiceClient Data Access Logic Component implementation for the <see cref="TestIssue117Tablea"/> entity.
	///</summary>
	[DataObject]
	[CLSCompliant(true)]
	public partial class WsTestIssue117TableaProvider: WsTestIssue117TableaProviderBase
	{		
		/// <summary>
		/// Creates a new <see cref="WsTestIssue117TableaProvider"/> instance.
		/// Uses connection string to connect to datasource.
		/// </summary>
		/// <param name="url">The url to the nettiers webservice.</param>
		public WsTestIssue117TableaProvider(string url): base(url){}
	}
}
