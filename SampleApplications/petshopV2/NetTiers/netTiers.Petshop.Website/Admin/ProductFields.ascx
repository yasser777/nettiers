<%@ Control Language="C#" ClassName="ProductFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
				<td>Id:</td>
				<td><asp:TextBox runat="server" id="dataId" Text='<%# Bind("Id") %>' MaxLength="36"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataId" runat="server" Display="Dynamic" ControlToValidate="dataId" ErrorMessage="Required"></asp:RequiredFieldValidator><br /></td>
			</tr>				
			<tr>
				<td>Name:</td>
				<td><asp:TextBox runat="server" id="dataName" Text='<%# Bind("Name") %>' MaxLength="255"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataName" runat="server" Display="Dynamic" ControlToValidate="dataName" ErrorMessage="Required"></asp:RequiredFieldValidator><br /></td>
			</tr>				
			<tr>
				<td>Description:</td>
				<td><asp:TextBox runat="server" id="dataDescription" Text='<%# Bind("Description") %>' MaxLength="255"></asp:TextBox><br /></td>
			</tr>				
			<tr>
				<td>CategoryId:</td>
				<td><asp:DropDownList runat="server" id="dataCategoryId" DataSourceID="CategoryDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("CategoryId") %>'></asp:DropDownList>
		<data:EntityDataSource ID="CategoryDataSource" runat="server"
 				ProviderName="CategoryProvider"
 				EntityTypeName="Entities.Category, Entities"
 				EntityKeyTypeName="System.String"
 				EntityKeyName="Id"
 				SelectMethod="GetAll"
 		>
		</data:EntityDataSource>
<br /></td>
			</tr>				
			
		</table>

	</ItemTemplate>
</asp:FormView>


