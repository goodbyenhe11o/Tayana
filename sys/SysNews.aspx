<%@ Page Title="" Language="C#" MasterPageFile="~/sys/Site.Master" AutoEventWireup="true" CodeBehind="SysNews.aspx.cs" Inherits="TayanaSystem.sys.News" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="col-lg-12  mt-3">
        <div class="card">
        <div class="card-body">
            <h3>新聞列表
            </h3>
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
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("[Top]") %>'></asp:Label>
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
    

</asp:Content>
