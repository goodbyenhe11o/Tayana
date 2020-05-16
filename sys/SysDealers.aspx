<%@ Page Title="" Language="C#" MasterPageFile="~/sys/Site.Master" AutoEventWireup="true" CodeBehind="SysDealers.aspx.cs" Inherits="TayanaSystem.sys.SysDealers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/homestyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" id="Form1">

        <div class="col-lg-12  mt-3">
            <div class="card">
                <div class="card-body">
                    <h3>代理商國家
                    </h3>
                    <div class="table-responsive">

                        <asp:GridView CssClass="table table-hover" ID="gvDealers" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderText="編號" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                                <asp:TemplateField HeaderText="地區" SortExpression="Area">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "SysDealers.aspx?id="+Eval("id") %>' Text='<%# Eval("Area") %>'></asp:HyperLink>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="tbArea" runat="server"
                                            Text='<%# Bind("Area") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField EditText="編輯名稱" HeaderText="操作" ShowEditButton="True" />
                                <asp:CommandField ShowDeleteButton="True" />
                                <%--<asp:BoundField DataField="number" HeaderText="代理商數量" SortExpression="number" />--%>

                                <asp:TemplateField HeaderText="代理商數量" SortExpression="number">

                                    <ItemTemplate>
                                        <asp:Label ID="lbNumber" runat="server" Text='<%# Bind("number") %>'></asp:Label>
                                    </ItemTemplate>

                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TayanaConnectionString %>" DeleteCommand="DELETE FROM [DealersArea] WHERE [id] = @id" InsertCommand="INSERT INTO [DealersArea] ([Area], [initdate]) VALUES (@Area, @initdate)" SelectCommand="SELECT *,(select count(*) from Dealers where Area_Id = DealersArea.id) as number  FROM [DealersArea]" UpdateCommand="UPDATE [DealersArea] SET [Area] = @Area, [initdate] = @initdate WHERE [id] = @id">
                            <DeleteParameters>
                                <asp:Parameter Name="id" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="Area" Type="String" />
                                <asp:Parameter Name="initdate" Type="DateTime" />
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="Area" Type="String" />
                                <asp:Parameter Name="initdate" Type="DateTime" />
                                <asp:Parameter Name="id" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                        <br>
                    </div>
                    <asp:Button ID="btnNewDealer" runat="server" Text="新增代理商" OnClick="btnNewDealer_OnClick" />
                    <br>
                    <br>
                    <br>
                </div>
            </div>
        </div>
        <div class="col-lg-12  mt-3">
            <div class="card">
                <div class="card-body">
                    <asp:Panel ID="Panel1" runat="server" Visible="False">
                        <h4>地區代理商：</h4>
                        <asp:Repeater ID="rp" runat="server" OnItemCommand="rp_OnItemCommand">

                            <HeaderTemplate>
                                <div class="table-responsive">
                                    <asp:Button ID="btnDelete" CssClass="btn mb-1 btn-rounded btn-outline-warning" runat="server" Text="Delete" CommandName="delCmd" OnClientClick="javascript:if(!window.confirm('確定要刪除?')) window.event.returnValue = false;" />
                                    <table class="table table-hover">
                                        <thead>
                                            <tr>
                                                <th>選取</th>
                                                <th>代理商圖片</th>
                                                <th>代理商標題及內文</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>

                                <tr>
                                    <td>
                                        <asp:CheckBox ID="cb" runat="server" />
                                    </td>
                                    <td>

                                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Picture") %>' Width="150px" Height="150px" />
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Symbol(Eval("Title").ToString()) %>' Font-Bold="True" ForeColor="#34A9D4"></asp:Label>
                                        <br>

                                        <asp:Literal ID="Literal2" runat="server" Text='<%# Symbol(Eval("Content").ToString()) %>'></asp:Literal>
                                        <asp:HiddenField ID="HiddenField1" Value='<%# Eval("id") %>' runat="server" />
                                    </td>
                            </ItemTemplate>

                            <FooterTemplate>
                                </tbody></table></div>
                            </FooterTemplate>

                        </asp:Repeater>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
