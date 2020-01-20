<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="Dealers.aspx.cs" Inherits="TayanaSystem.Dealers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <!--------------------------------左邊選單開始---------------------------------------------------->
        <div class="left">
            <div class="left1">
                <p><span>DEALERS</span></p>
                <asp:Repeater ID="rpMenu" runat="server">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li><a href="Dealers.aspx?id=<%#Eval("id") %>">
                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Area") %>'></asp:Label></a></li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>


        <!--------------------------------左邊選單結束---------------------------------------------------->

        <!--------------------------------右邊選單開始---------------------------------------------------->
        <div id="crumb"><a href="#">Home</a> >> <a href="#">Dealers </a>>> <a href="#"><span class="on1">
            <asp:Literal ID="lrAreaName" runat="server" ></asp:Literal></span></a></div>
        <div class="right">
            <div class="right1">
                <div class="title">
                    <asp:Label ID="lbDealerTitle" runat="server"></asp:Label></div>

                <!--------------------------------內容開始---------------------------------------------------->
                <div class="box2_list">
                    <asp:Repeater ID="rpContent" runat="server">
                        <HeaderTemplate>

                            <ul>
                        </HeaderTemplate>
                        <ItemTemplate>

                            <li>
                                <div class="list02">
                                    <ul>
                                        <li class="list02li">
                                            <div class="DealerPic">
                                                <p>
                                                    <img src='<%#Eval("Picture") %>' width="209px"  height="209px"/>
                                                </p>
                                            </div>
                                        </li>
                                        <li>
                                            <asp:Label ID="lbTitle" runat="server" Text='<%#Eval("Title") %>'></asp:Label><br />
                                            <asp:Literal ID="lrContent" runat="server" Text='<%#Symbol(Eval("Content").ToString()) %>'></asp:Literal>
                                        </ul>
                                </div>
                            </li>

                        </ItemTemplate>
                        <FooterTemplate>
                            </ul>
                        </FooterTemplate>

                    </asp:Repeater>

                    <div class="pagenumber">| <span>1</span> | <a href="#">2</a> | <a href="#">3</a> | <a href="#">4</a> | <a href="#">5</a> |  <a href="#">Next</a>  <a href="#">LastPage</a></div>
                    <div class="pagenumber1">Items：<span>89</span>  |  Pages：<span>1/9</span></div>


                </div>

                <!--------------------------------內容結束------------------------------------------------------>
            </div>
        </div>

        <!--------------------------------右邊選單結束---------------------------------------------------->

</asp:Content>
