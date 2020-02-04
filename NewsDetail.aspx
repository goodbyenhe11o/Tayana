<%@ Page Title="" Language="C#" MasterPageFile="~/Web.Master" AutoEventWireup="true" CodeBehind="NewsDetail.aspx.cs" Inherits="TayanaSystem.NewsDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

            <div class="box3">
                
                <h4>
                <asp:Literal ID="lrTitle" runat="server" Text='<%#Eval("Title") %>'></asp:Literal>

                </h4>
                
                
                <asp:Literal ID="lrContent" runat="server" Text='<%#Eval("Content") %>'></asp:Literal>
            <br>
            <br>
            <br>
            <br>
            <asp:Button ID="btnReturn" runat="server" Text="返回上一頁"  OnClick="btnReturn_OnClick"/>
            </div>

            <!--------------------------------內容結束------------------------------------------------------>
        </div>
    </div>

    <!--------------------------------右邊選單結束---------------------------------------------------->

</asp:Content>
