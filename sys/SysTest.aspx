<%@ Page Title="" Language="C#" MasterPageFile="~/sys/Site.Master" AutoEventWireup="true" CodeBehind="SysTest.aspx.cs" Inherits="TayanaSystem.sys.SysTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    <form runat="server" id="Form1">
    <div class="col-lg-12  mt-3">
    <div class="card">
    <div class="card-body">
    
        <asp:DropDownList ID="ddlYachtName" runat="server">
        </asp:DropDownList>
        
        <%-- 用repeater抓ddl的value????抓圖片 --%>
        
        
        

    </div>
        </div>
    </div>
</form>    

</asp:Content>
