<%@ Page Title="" Language="C#" MasterPageFile="~/sys/Site.Master" AutoEventWireup="true" CodeBehind="SysUserManage.aspx.cs" Inherits="TayanaSystem.sys.SysUserManage" %>
<%@ Import Namespace="TayanaSystem.sys" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="col-lg-12  mt-3">
    <div class="card">
    <div class="card-body">
    <h3>使用者列表</h3>
        <div class="table-responsive">
    <asp:GridView CssClass="table table-hover" ID="gvUser" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="gvUser_OnRowCommand">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="資料庫編號" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="UserName" HeaderText="使用者名稱" SortExpression="UserName" />
            <asp:BoundField DataField="Account" HeaderText="使用者帳戶" SortExpression="Account" />
            <%--<asp:BoundField DataField="Password" HeaderText="使用者密碼" SortExpression="Password" />--%>
            <asp:BoundField DataField="Manage_Id" HeaderText="帳號管理權限" SortExpression="Manage_Id" />
            <asp:BoundField DataField="MenuAuthority" HeaderText="前台管理權限" SortExpression="MenuAuthority" />
            <asp:BoundField DataField="initdate" HeaderText="建立時間" SortExpression="initdate" />
            <asp:TemplateField HeaderText="編輯" ShowHeader="False">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" Text="編輯" runat="server" NavigateUrl='<%# "SysUserEdit.aspx?id="+Eval("id") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="刪除" ShowHeader="False">
                <ItemTemplate>
                    <asp:HiddenField ID="HiddenFieldDel" Value='<%# Eval("id") %>' runat="server" />
                    <asp:Button ID="btnDel" runat="server" Text="刪除" CommandName="btnDel" OnClientClick="javascript:if(!window.confirm('確定要刪除?')) window.event.returnValue = false;" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
            </asp:GridView>
            </div>
            </div>
            </div>
            </div>
            </form>
</asp:Content>
