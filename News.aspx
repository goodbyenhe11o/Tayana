<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="TayanaSystem.News" %><%@ Register Src="~/Pagination.ascx" TagPrefix="uc1" TagName="Pagination" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/pagination.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--------------------------------左邊選單開始---------------------------------------------------->
    <div class="left">
        <div class="left1">
            <p><span>News</span></p>
            <ul>
                <li><a href="News.aspx">News & Events</a></li>
            </ul>
        </div>
    </div>


    <!--------------------------------左邊選單結束---------------------------------------------------->

    <!--------------------------------右邊選單開始---------------------------------------------------->
    <div id="crumb"><a href="#">Home</a> >> <a href="#">News </a>>> <a href="News.aspx"><span class="on1">News & Events</span></a></div>
    <div class="right">
        <div class="right1">
            <div class="title"><span>News & Events</span></div>

            <!--------------------------------內容開始---------------------------------------------------->

            <div class="box2_list">
                <asp:Repeater ID="rpContnet" runat="server">
                    <HeaderTemplate>
                        <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li>
                            <div class="list01">
                                <ul>
                                    <li>
                                        <div>
                                            <p>
                                                <img src='<%#Eval("MainPicture") %>' height="209px" width="209px" alt="&quot;&quot;" /></p>
                                        </div>
                                    </li>
                                    <li>
                                        <asp:Label ID="lbDate" runat="server" Text='<%#Eval("initdate","{0:yyyy/MM/dd}") %>'></asp:Label>
                                        <br />
                                        <a href="NewsDetail.aspx?id=<%#Eval("id") %>">
                                        <asp:Literal ID="lrTitle" runat="server" Text='<%#Eval("Title") %>'></asp:Literal>
                                        </a>
                                        <br />
                                        
                                        </li>
                                    <li>
                                        <asp:Literal ID="lrSummary" runat="server" Text='<%#Eval("Summary") %>'></asp:Literal>
                                    </li>
                                </ul>
                            </div>
                        </li>

                    </ItemTemplate>
                    <FooterTemplate>
                        </ul>
                    </FooterTemplate>

                </asp:Repeater>



                <%--<div class="pagenumber">| <span>1</span> | <a href="#">2</a> | <a href="#">3</a> | <a href="#">4</a> | <a href="#">5</a> |  <a href="#">Next</a>  <a href="#">LastPage</a></div>
                <div class="pagenumber1">Items：<span>89</span>  |  Pages：<span>1/9</span></div>--%>
                
                <div class="pagenumber">
                    <uc1:Pagination runat="server" id="Pagination1" />

                </div>

                

            </div>


            <!--------------------------------內容結束------------------------------------------------------>
        </div>
    </div>

    <!--------------------------------右邊選單結束---------------------------------------------------->

</asp:Content>
