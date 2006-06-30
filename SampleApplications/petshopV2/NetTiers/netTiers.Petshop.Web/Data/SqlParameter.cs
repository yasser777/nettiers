#region Using Directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using netTiers.Petshop.Entities;
using netTiers.Petshop.Data;
using netTiers.Petshop.Web.UI;
#endregion

namespace netTiers.Petshop.Web.Data
{
	/// <summary>
	/// Binds SQL filter expressions to a parameter object.
	/// </summary>
	[CLSCompliant(true)]
	[ParseChildren(true), PersistChildren(false)]
	public class SqlParameter : Parameter
	{
		/// <summary>
		/// Initializes a new instance of the SqlParameter class.
		/// </summary>
		public SqlParameter() : base()
		{
		}

		#region Properties

		/// <summary>
		/// The Filters member variable.
		/// </summary>
		private IList filters;

		/// <summary>
		/// Gets or sets the Filters property.
		/// </summary>
		[PersistenceMode(PersistenceMode.InnerProperty)]
		public IList Filters
		{
			get
			{
				if ( filters == null )
				{
					filters = new ArrayList();
				}

				return filters;
			}
		}

		/// <summary>
		/// The CallbackControlID member variable.
		/// </summary>
		private String callbackControlID;

		/// <summary>
		/// Gets or sets the CallbackControlID property.
		/// </summary>
		public String CallbackControlID
		{
			get { return callbackControlID; }
			set { callbackControlID = value; }
		}

		#endregion Properties

		#region Evaluate

		/// <summary>
		/// Updates and returns the value of the SqlParameter object.
		/// </summary>
		/// <param name="context">The current System.Web.HttpContext of the request.</param>
		/// <param name="control">The System.Web.UI.Control that the parameter is bound to.</param>
		/// <returns>A System.Object that represents the updated and current value of the parameter.</returns>
		protected override object Evaluate(HttpContext context, Control control)
		{
			String sql = String.Empty;
			bool isCallback = false;

			if ( !String.IsNullOrEmpty(CallbackControlID) )
			{
				IList<Control> controls = FormUtil.GetControls(control.Page, CallbackControlID);
				if ( controls != null && controls.Count > 0 )
				{
					try
					{
						isCallback = (bool) EntityUtil.GetPropertyValue(controls[0], "IsCallback");
					}
					catch ( Exception ) { /* ignore */ }
				}
			}
			if ( filters != null && filters.Count > 0 )
			{
				sql = (filters[0] as ISqlFilter).GetSqlString(control, filters, isCallback);
			}

			return sql;
		}

		#endregion Evaluate
	}

	/// <summary>
	/// Provides SQL filter expressions for the <see cref="SqlParameter"/> class.
	/// </summary>
	/// <typeparam name="EntityColumn">An enumeration of entity column names.</typeparam>
	[CLSCompliant(true)]
	public class SqlFilter<EntityColumn> : ISqlFilter
	{
		#region Properties

		/// <summary>
		/// The Column member variable.
		/// </summary>
		private EntityColumn column;

		/// <summary>
		/// Gets or sets the Column property.
		/// </summary>
		public EntityColumn Column
		{
			get { return column; }
			set { column = value; }
		}

		/// <summary>
		/// The ControlID member variable.
		/// </summary>
		private String controlID;

		/// <summary>
		/// Gets or sets the ControlID property.
		/// </summary>
		public String ControlID
		{
			get { return controlID; }
			set { controlID = value; }
		}

		/// <summary>
		/// The PropertyName member variable.
		/// </summary>
		private String propertyName;

		/// <summary>
		/// Gets or sets the PropertyName property.
		/// </summary>
		public String PropertyName
		{
			get { return propertyName; }
			set { propertyName = value; }
		}

		#endregion Properties

		#region Methods

		/// <summary>
		/// Gets the filter value.
		/// </summary>
		/// <param name="control">The <see cref="System.Web.UI.Control"/> that the parameter is bound to.</param>
		/// <param name="isCallback">Indicates whether this is a callback request.</param>
		protected virtual String GetFilterValue(Control control, bool isCallback)
		{
			IList<Control> controls = FormUtil.GetControls(control.Page, ControlID);
			//Control input = FormUtil.FindControl(control, ControlID);
			Control input = null;
			Object value = null;

			if ( controls != null && controls.Count > 0 )
			{
				input = controls[0];
			}
			if ( input != null )
			{
				if ( isCallback )
				{
					value = HttpContext.Current.Request[input.UniqueID];
				}
				else
				{
					value = FormUtil.GetValue(input, PropertyName);
				}
			}

			return String.Format("{0}", value);
		}

		/// <summary>
		/// Creates a new instance of a <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
		/// that can be used to generate a SQL filter expression for this filter.
		/// </summary>
		/// <returns></returns>
		protected virtual SqlFilterBuilder<EntityColumn> GetFilterBuilder()
		{
			return new SqlFilterBuilder<EntityColumn>();
		}

		#endregion Methods

		#region Events

		/// <summary>
		/// Occurs when the filter expression is to be created.
		/// </summary>
		public event SqlFilterEventHandler<EntityColumn> ApplyFilter;

		#endregion Events

		#region ISqlFilter Members

		/// <summary>
		/// Gets the SQL filter expression that is represented by the specified filters.
		/// </summary>
		/// <param name="control">The <see cref="System.Web.UI.Control"/> that the parameter is bound to.</param>
		/// <param name="filters">A collection of <see cref="ISqlFilter"/> objects.</param>
		/// <param name="isCallback">Indicates whether this is a callback request.</param>
		/// <returns>A SQL filter expression.</returns>
		public String GetSqlString(Control control, IList filters, bool isCallback)
		{
			SqlFilterBuilder<EntityColumn> sql = GetFilterBuilder();
			String value;

			foreach ( SqlFilter<EntityColumn> filter in filters )
			{
				value = filter.GetFilterValue(control, isCallback);

				if ( filter.ApplyFilter != null )
				{
					SqlFilterEventArgs<EntityColumn> args = new SqlFilterEventArgs<EntityColumn>(sql, filter.Column, value);
					filter.ApplyFilter(this, args);
				}
				else
				{
					sql.Append(filter.Column, value);
				}
			}

			return sql.ToString();
		}

		#endregion ISqlFilter Members
	}

	#region SqlFilterEventHandler

	/// <summary>
	/// Represents the method that will handle the <see cref="SqlFilter&lt;EntityColumn&gt;.ApplyFilter"/> event.
	/// </summary>
	/// <typeparam name="EntityColumn">An enumeration of entity column names.</typeparam>
	/// <param name="sender">The data source control that the filter is bound to.</param>
	/// <param name="e">The event data.</param>
	public delegate void SqlFilterEventHandler<EntityColumn>(object sender, SqlFilterEventArgs<EntityColumn> e);

	/// <summary>
	/// Provides data for the <see cref="SqlFilter&lt;EntityColumn&gt;.ApplyFilter"/> event.
	/// </summary>
	/// <typeparam name="EntityColumn">An enumeration of entity column names.</typeparam>
	public class SqlFilterEventArgs<EntityColumn> : EventArgs
	{
		/// <summary>
		/// Initializes a new instance of the SqlFilterEventArgs class.
		/// </summary>
		/// <param name="builder">An <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> object.</param>
		/// <param name="column">The current column.</param>
		/// <param name="filter">The column filter value.</param>
		public SqlFilterEventArgs(SqlFilterBuilder<EntityColumn> builder, EntityColumn column, String filter)
		{
			this.filterBuilder = builder;
			this.column = column;
			this.filter = filter;
		}

		#region Properties

		/// <summary>
		/// The FilterBuilder member variable.
		/// </summary>
		private SqlFilterBuilder<EntityColumn> filterBuilder;

		/// <summary>
		/// Gets or sets the FilterBuilder property.
		/// </summary>
		public SqlFilterBuilder<EntityColumn> FilterBuilder
		{
			get { return filterBuilder; }
		}

		/// <summary>
		/// The Column member variable.
		/// </summary>
		private EntityColumn column;

		/// <summary>
		/// Gets or sets the Column property.
		/// </summary>
		public EntityColumn Column
		{
			get { return column; }
		}

		/// <summary>
		/// The Filter member variable.
		/// </summary>
		private String filter;

		/// <summary>
		/// Gets or sets the Filter property.
		/// </summary>
		public String Filter
		{
			get { return filter; }
		}

		#endregion Properties
	}

	#endregion SqlFilterEventHandler

	#region ISqlFilter
	
	/// <summary>
	/// Provides the ability to construct a valid SQL filter expression.
	/// </summary>
	[CLSCompliant(true)]
	public interface ISqlFilter
	{
		/// <summary>
		/// Gets the SQL filter expression that is represented by the specified filters.
		/// </summary>
		/// <param name="control">The <see cref="System.Web.UI.Control"/> that the parameter is bound to.</param>
		/// <param name="filters">A collection of <see cref="ISqlFilter"/> objects.</param>
		/// <param name="isCallback">Indicates whether this is a callback request.</param>
		/// <returns>A SQL filter expression.</returns>
		String GetSqlString(Control control, IList filters, bool isCallback);
	}

	#endregion ISqlFilter
}
