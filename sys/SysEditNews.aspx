<%@ Page Title="" Language="C#" MasterPageFile="~/sys/Site.Master" AutoEventWireup="true" CodeBehind="SysEditNews.aspx.cs" Inherits="TayanaSystem.sys.NewNews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/ckeditor/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <asp:Label ID="lbNew" runat="server" Text="新增新聞"></asp:Label>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbNewTitle" runat="server" Text="新增標題"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txbNewTitle" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbNewSummary" runat="server" Text="簡短內文"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txbNewSummary" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbNewContent" runat="server" Text="新增內文"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txbNewContent" runat="server" TextMode="MultiLine" CssClass="ckeditor"></asp:TextBox>
<%--                    <script>
                        CKEDITOR.replace('txbNewContent');
                    </script>--%>
                </td>
            </tr>
        </table>
        <br>
        <asp:Button ID="Submit" runat="server" Text="發佈新聞" OnClick="Submit_OnClick" />
        <asp:Button ID="Return" runat="server" Text="回上一頁" OnClick="Return_OnClick" />


    </form>
</asp:Content>
