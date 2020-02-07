<%@ Page Title="" Language="C#" MasterPageFile="~/sys/Site.Master" AutoEventWireup="true" CodeBehind="SysEditNews.aspx.cs" Inherits="TayanaSystem.sys.NewNews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../javascript/ckeditor/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="col-lg-12  mt-3">
        <div class="card">
        <div class="card-body">
            <h3>新增新聞</h3>
                    <asp:Label ID="lbNewTitle" runat="server" Text="新增標題"></asp:Label>
        <br>
                    <asp:TextBox ID="txbNewTitle" runat="server" TextMode="MultiLine" Width="100%"></asp:TextBox>
            <br>
        <br>
            新聞縮圖
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br>
            <asp:Label ID="lbPictureForm" runat="server" Text="※圖片格式支援 jpg、png" Font-Bold="True"></asp:Label>
            <asp:Label ID="lbPictureResult" runat="server"></asp:Label><br>
            <asp:Label ID="lbPic" runat="server" Visible="False" Text="目前新聞縮圖如下"></asp:Label><br>
            <asp:Image ID="imgPic" runat="server" Width="200px"/>
            <br>
            <br>

                    <asp:Label ID="lbNewSummary" runat="server" Text="簡短內文"></asp:Label>
        <br>
                    <asp:TextBox ID="txbNewSummary" runat="server" TextMode="MultiLine"  Height="200px" Width="100%"></asp:TextBox>
            <br>
        <br>
                    <asp:Label ID="lbNewContent" runat="server" Text="新增內文"></asp:Label>
        <br>
                    <asp:TextBox ID="txbNewContent"  runat="server" TextMode="MultiLine" ClientIDMode="Static" ></asp:TextBox>
            <script>
                CKEDITOR.replace('txbNewContent', {height:800,});

            </script>
            <br>
            是否置頂<asp:Label ID="lbTopWarn" runat="server"></asp:Label>
            <asp:RadioButtonList ID="rdblTop" runat="server" >
                <asp:ListItem Text="是" Value="1"></asp:ListItem> 
                <asp:ListItem Text="否" Value="0" Selected="True"></asp:ListItem>
            </asp:RadioButtonList>
        <br>
        <asp:Button ID="Submit" runat="server" Text="發佈新聞" OnClick="Submit_OnClick" />
        <asp:Button ID="Return" runat="server" Text="回上一頁" OnClick="Return_OnClick" />

</div>
            </div>
</div>
    </form>
</asp:Content>
