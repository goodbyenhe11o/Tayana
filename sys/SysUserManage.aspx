<%@ Page Title="" Language="C#" MasterPageFile="~/sys/Site.Master" AutoEventWireup="true" CodeBehind="SysUserManage.aspx.cs" Inherits="TayanaSystem.sys.SysUserManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="col-lg-12  mt-3">
    <div class="card">
    <div class="card-body">
    <h3>遊艇清單</h3>
        <div class="table-responsive">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
            <asp:BoundField DataField="Account" HeaderText="Account" SortExpression="Account" />
            <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
            <asp:BoundField DataField="Manage_Id" HeaderText="Manage_Id" SortExpression="Manage_Id" />
            <asp:BoundField DataField="MenuAuthority" HeaderText="MenuAuthority" SortExpression="MenuAuthority" />
            <asp:BoundField DataField="UserPicture" HeaderText="UserPicture" SortExpression="UserPicture" />
            <asp:BoundField DataField="initdate" HeaderText="initdate" SortExpression="initdate" />
        </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TayanaConnectionString %>" SelectCommand="SELECT * FROM [User]"></asp:SqlDataSource>
            </div>
            </div>
            </div>
            </div>
            </form>
</asp:Content>
