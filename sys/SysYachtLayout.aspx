<%@ Page Title="" Language="C#" MasterPageFile="~/sys/Site.Master" AutoEventWireup="true" CodeBehind="SysYachtLayout.aspx.cs" Inherits="TayanaSystem.sys.SysYachtLayout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        
        <div class="col-lg-12  mt-3">
        <div class="card">
        <div class="card-body">

        <h3>Layout & desk plan</h3>
            <br>

    <asp:FileUpload ID="fuLayout01" runat="server" AllowMultiple="True" ></asp:FileUpload>
            <br>
            
            <asp:Label ID="lbPictureForm" runat="server" Text="※圖片格式支援 jpg、png" Font-Bold="True"></asp:Label>
            <asp:Label ID="lbPictureResult" runat="server"></asp:Label>
            <br>
            <br>
            <asp:Button runat="server" ID="btnSubmit" Text="上傳照片" OnClick="btnSubmit_OnClick" />
            <asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_OnClick" />
            </div>
            </div>
        
        
        <div class="card">
        <div class="card-body">

        <asp:Repeater ID="rpLayout" runat="server" OnItemCommand="rpLayout_OnItemCommand">
            
            

                        <HeaderTemplate>
                            <div class="table-responsive">
                                <asp:Button ID="btnDelete" CssClass="btn mb-1 btn-rounded btn-outline-warning" runat="server" Text="Delete" CommandName="delCmd" OnClientClick="javascript:if(!window.confirm('確定要刪除?')) window.event.returnValue = false;" />
                                <table class="table table-hover">
                                    <thead>
                                        <tr>
                                            <th>選取</th>
                                            <th>Layout圖片</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>

                            <tr>
                                <td>
                                    <asp:CheckBox ID="cb" runat="server" />
                                    <asp:HiddenField ID="HiddenField1" Value='<%# Eval("id") %>' runat="server" />
                                </td>
                                <td>

                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Picture") %>' Width="150px" Height="150px" />
                                </td>
                            </tr>
                        </ItemTemplate>

                        <FooterTemplate>
                            </tbody></table></div>
                        </FooterTemplate>

        </asp:Repeater>
        
        
            </div>
        </div>
        </div>
            
    </form>
    </asp:Content>
