<%@ Page Title="" Language="C#" MasterPageFile="~/sys/Site.Master" AutoEventWireup="true" CodeBehind="SysNews.aspx.cs" Inherits="TayanaSystem.sys.News" %>

<%@ Register Src="~/Pagination.ascx" TagPrefix="uc1" TagName="Pagination" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/pagination.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="col-lg-12  mt-3">
        <div class="card">
        <div class="card-body">
            <h3>新聞列表
            </h3>
            <div class="form-group">
            <i class="mdi mdi-magnify"></i>
            <asp:Label ID="lbSearchDate" runat="server" Text="選擇區間"></asp:Label>
            <asp:TextBox ID="tbDateFrom" runat="server" TextMode="Date"></asp:TextBox>至
                <asp:TextBox ID="tbDateTo" runat="server" TextMode="Date"></asp:TextBox>
                <asp:Button ID="btnSearchDate" runat="server" Text="尋找" OnClick="btnSearchDate_OnClick" />
                <asp:Button ID="btnClear" runat="server" Text="清除條件" OnClick="btnClear_OnClick" />
 </div>
            <br>
                <asp:GridView ID="GridView1" CssClass="table table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="GridView1_OnRowCommand">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="資料庫編號" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="Title" HeaderText="新聞標題" SortExpression="Title" />
                <asp:BoundField DataField="initdate" HeaderText="建立時間" SortExpression="initdate" />
                <asp:TemplateField HeaderText="建立者"></asp:TemplateField>
                <asp:TemplateField ShowHeader="False" HeaderText="操作">
                    <ItemTemplate>
                        <asp:HiddenField ID="HiddenFieldDel" Value='<%# Eval("id") %>' runat="server" />

                        <asp:Button ID="btnDel" runat="server" Text="刪除" CommandName="btnDel" OnClientClick="javascript:if(!window.confirm('確定要刪除?')) window.event.returnValue = false;" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="置頂">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("TopNews") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="編輯">
                    <ItemTemplate>
                        <asp:HyperLink ID="hlEdit" Text="編輯" runat="server" NavigateUrl='<%# "SysEditNews.aspx?id="+Eval("id") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
            <br>
            <br>
        <asp:Button ID="EditNews" runat="server" Text="新增新聞"  OnClick="EditNews_OnClick"/>
            </div>
            </div>
            </div>
       
    </form>
    <uc1:Pagination runat="server" ID="Pagination1" />

</asp:Content>
