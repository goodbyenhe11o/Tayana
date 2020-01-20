<%@ Page Title="" Language="C#" MasterPageFile="~/sys/Site.Master" AutoEventWireup="true" CodeBehind="SysDealersEdit.aspx.cs" Inherits="TayanaSystem.sys.SysDealersEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/ckeditor/ckeditor.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server" id="Form1">
        <div class="col-lg-12">
            <div class="card-header">
                <h3>新增代理商</h3>
            </div>
            <div class="card-body">
                選擇地區
        <asp:DropDownList ID="ddlArea" runat="server" DataSourceID="SqlDataSource1" DataTextField="Area" DataValueField="id"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TayanaConnectionString %>" SelectCommand="SELECT * FROM [DealersArea]"></asp:SqlDataSource>
                <br>
                <br>
                新增代理商圖片
        <asp:FileUpload ID="FileUpload1" runat="server" />
                <br>
                <asp:Label ID="ibPictureForm" runat="server" Text="※圖片格式支援 jpg、png" Font-Bold="True"></asp:Label>
                <asp:Label ID="lbPictureResult" runat="server"></asp:Label>
                <br>
                <br>
                新增代理商地區(標題)<br>
                <asp:TextBox ID="txbNewTitle" runat="server" TextMode="MultiLine" Height="25px" Width="600px"></asp:TextBox>
                <br>
                <br>
                新增內容<br>
                <asp:TextBox ID="txbNewContent" runat="server" TextMode="MultiLine" Height="200px" Width="600px"></asp:TextBox>
                <br>
                <asp:Button ID="Submit" runat="server" Text="送出" OnClick="Submit_OnClick" CssClass="btn mb-1 btn-outline-primary" />
                <asp:Button ID="Returm" runat="server" Text="返回" OnClick="Returm_OnClick" CssClass="btn mb-1 btn-outline-secondary" />

            </div>
        </div>
    </form>
</asp:Content>
