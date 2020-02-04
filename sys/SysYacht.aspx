<%@ Page Title="" Language="C#" MasterPageFile="~/sys/Site.Master" AutoEventWireup="true" CodeBehind="SysYacht.aspx.cs" Inherits="TayanaSystem.sys.SysYacht" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="col-lg-12  mt-3">
    <div class="card">
    <div class="card-body">
    <h3>遊艇清單</h3>
        <div class="table-responsive">
        <asp:GridView CssClass="table table-hover" ID="gvYacht" runat="server" AutoGenerateColumns="False" DataKeyNames="id" OnRowCommand="gvYacht_OnRowCommand">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="資料庫編號" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="YachtName" HeaderText="遊艇名稱" SortExpression="YachtName" />
                <%--<asp:BoundField DataField="OverviewContent" HeaderText="OverviewContent" SortExpression="OverviewContent" />--%>
                <%--<asp:BoundField DataField="Layout" HeaderText="Layout" SortExpression="Layout" />--%>
                <%--<asp:BoundField DataField="Specification" HeaderText="Specification" SortExpression="Specification" />--%>
                <asp:BoundField DataField="initdate" HeaderText="建立時間" SortExpression="initdate" />
                <%--<asp:BoundField DataField="NewBuilding" HeaderText="備註" SortExpression="NewBuilding" />--%>
                <asp:TemplateField HeaderText="Overview" ShowHeader="False">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl='<%# "SysYachtOverview.aspx?id="+ Eval("id") %>' Text="編輯"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Layout" ShowHeader="False" >
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<% #"SysYachtLayout.aspx?id="+ Eval("id") %>' Text="編輯"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Specification" ShowHeader="False">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%# "SysYachtSpecification.aspx?id="+ Eval("id") %>' Text="編輯"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="備註" ShowHeader="False">
                    <ItemTemplate>
                        <asp:Label ID="lbNB" runat="server" Text='<%#Eval("NewBuilding") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="相簿" ShowHeader="False">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink4" runat="server" Text="相簿" NavigateUrl='<%# "SysAlbum.aspx?id="+ Eval("id") %>'  ></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="附檔" ShowHeader="False">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink5" runat="server" Text="檔案" NavigateUrl='<%# "SysYachtFile.aspx?id="+ Eval("id") %>'  ></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="刪除遊艇" ShowHeader="False">
                    <ItemTemplate>
                        <asp:HiddenField ID="HiddenFieldDel" Value='<%# Eval("id") %>' runat="server" />
                        <asp:Button ID="btnDel" runat="server" Text="刪除" CommandName="btnDel" OnClientClick="javascript:if(!window.confirm('確定要刪除?')) window.event.returnValue = false;" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
        
        </div>
        <br>
        <br>
        <asp:Button ID="btnNew" runat="server" Text="新增遊艇" OnClick="btnNew_OnClick" />
        
        
        

        </div>
        </div>
    </div>
</form>    
    

</asp:Content>
