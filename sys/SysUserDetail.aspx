<%@ Page Title="" Language="C#" MasterPageFile="~/sys/Site.Master" AutoEventWireup="true" CodeBehind="SysUserDetail.aspx.cs" Inherits="TayanaSystem.sys.SysUserDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <form runat="server" id="Form1">

        <div class="col-lg-12  mt-3">
            <div class="card">
                <div class="card-body">
                    <h3>會員中心</h3>
                    <br>

                    
                    用戶名稱：
                    <asp:Label ID="lbName" runat="server" Text='<%#Eval("UserName") %>'></asp:Label>
                    <br>
                    <br>
                    帳號：
                    <asp:Label ID="lbAccount" runat="server" Text='<%#Eval("Account") %>'></asp:Label>
                    <br>
                    <br>
                    前台權限：
                    <asp:Label ID="lbAuthority" runat="server" Text='<%#Eval("MenuAuthority") %>'></asp:Label>
                    <br>
                    <br>
                    
                    
                    <asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_OnClick"/>


                </div>
            </div>
        </div>
    </form>

</asp:Content>
