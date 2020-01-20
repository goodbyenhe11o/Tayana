<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="TayanaSystem.test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
  

    <asp:Repeater ID="rp" runat="server">

        <HeaderTemplate>
            <div class="right">
            <div class="right1">
            <div class="box2_list"><ul>
        </HeaderTemplate>

        <ItemTemplate>
            <li>
                <div class="list02" ClientIDMode="Static">
                    <ul>
                        <li class="list02li" ClientIDMode="Static">
                            <div>
                                <p>
                                    <asp:Image  ID="Image1" runat="server" ImageUrl='<%# Eval("Picture") %>' Width="200px" Height="200px" />
                                </p>
                            </div>
                        </li>
                        <li>
                            <asp:Label  ID="Label2" runat="server" Text='<%# Symbol(Eval("Title").ToString()) %>'></asp:Label>
                            <br>

                            <asp:Literal  ID="Literal2" runat="server" Text='<%# Symbol(Eval("Content").ToString()) %>'></asp:Literal>

                        </li>
                    </ul>
                </div>
            </li>


        </ItemTemplate>

        <FooterTemplate>
        </ul></div></div></div>
        </FooterTemplate>

    </asp:Repeater>
</asp:Content>
