<%@ Page Title="" Language="C#" MasterPageFile="~/sys/Site.Master" AutoEventWireup="true" CodeBehind="SysYachtSpecification.aspx.cs" Inherits="TayanaSystem.sys.SysYachtSpecification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../javascript/ckeditor/ckeditor.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="col-lg-12  mt-3">
        <div class="card">
        <div class="card-body">
            <h4>新增遊艇Specification欄位</h4>
            DETAIL SPECIFICATION
            <br>
            <br>
        <div class="box5">
    <asp:TextBox ID="tbSpecification" runat="server" ClientIDMode="Static" TextMode="MultiLine">
        <p>標題1</p>
        <ul>
            <li>項目1</li>
            <li>項目2</li>
            <li>項目3</li>
        </ul>
        <p>標題2</p>
        <ul>
            <li>項目1</li>
            <li>項目2</li>
            <li>項目3</li>
        </ul>

    </asp:TextBox>


    
        </div>
    <script>

        CKEDITOR.replace('tbSpecification', {
                height: 850,
                removeButtons: 'Subscript,Superscript,Scayt,Link,Unlink,Anchor,HorizontalRule,SpecialChar,Maximize,Blockquote,About,Styles,Format'
            }
        )
    </script>
            <br>
    
    <asp:Button ID="btnSubmit" runat="server" Text="更新內容" OnClick="btnSubmit_OnClick"/>
            <asp:Button ID="btnReturn" runat="server" Text="取消返回" OnClick="btnReturn_OnClick" />
            
            </div>
            </div>
            </div>
    </form>
</asp:Content>
