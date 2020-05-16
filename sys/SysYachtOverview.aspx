<%@ Page Title="" Language="C#" MasterPageFile="~/sys/Site.Master" AutoEventWireup="true" CodeBehind="SysYachtOverview.aspx.cs" Inherits="TayanaSystem.sys.SysYachtOverview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../javascript/ckeditor/ckeditor.js"></script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <form id="form1" runat="server">
        <div class="col-lg-12  mt-3">
            <div class="card">
                <div class="card-body">

                    <h3>新增Yacht遊艇
                    </h3>
                    Yacht遊艇名稱
                    <br>
                    <asp:TextBox ID="tbYachtName" runat="server" Width="100%" Height="50px" TextMode="MultiLine"></asp:TextBox>
                    <br>
                    <br>
                    
                    <asp:Label ID="lbNewBuilding" runat="server">是否顯示為新遊艇(New Building)</asp:Label>
                    <asp:RadioButtonList ID="rdblNewBuilding" runat="server">
                        <asp:ListItem Text="是" Value="1" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="否" Value="0"></asp:ListItem>
                    </asp:RadioButtonList>
                        <br>
                        <br>

                    新增遊艇內容
                    <br>
                    <asp:TextBox ID="tbOverviewContent" runat="server" CssClass="ckeditor" TextMode="MultiLine" Width="100%" Height="500px"></asp:TextBox>
                    <br>
                    <br>
                    新增遊艇規格(DIMENSIONS)(請填入文字即可，勿修改格式)
                    
                    <asp:TextBox ID="tbOverviewDimensions" runat="server" TextMode="MultiLine" ClientIDMode="Static">
                        
                        <table class="table02">
                            <tr>
                                <td class="table02td01">
                                    <table>
                                        <tr>
                                            <th>L.O.A.</th>
                                            <td>0000000</td>
                                        </tr>
                                        <tr class="tr003">
                                            <th>L.W.L.</th>
                                            <td>0000000</td>
                                        </tr>
                                        <tr>
                                            <th>Beam</th>
                                            <td>0000000</td>
                                        </tr>
                                        <tr class="tr003">
                                            <th>Draft (Fin Keel)</th>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <th>Displacement</th>
                                            <td></td>
                                        </tr>
                                        <tr class="tr003">
                                            <th>Ballast (Fin Keel)</th>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <th>Sail Area (Main + 150% Triangle)<br />
                                                Main (9.0 oz)<br />
                                                Stays (9.0 oz)<br />
                                                No. 1 Genoa (7.2 oz)<br />
                                                Genoa (150%) (7.2 oz)<br />
                                                I :<br />
                                                J :<br />
                                                P :<br />
                                                E :</th>
                                            <td></td>
                                        </tr>
                                        <tr class="tr003">
                                            <th>D/L=191.47Ballast/Displacement</th>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <th>Exterior Style, Interior Designer</th>
                                            <td></td>
                                        </tr>
                                        <tr class="tr003">
                                            <th>Naval Architect Designer</th>
                                            <td></td>
                                        </tr>
                                    </table>
                        </td>
                            <td>
                                
                    請上傳遊艇格式圖，並刪除此行
                                <br>

                            </td>
                            </tr>
                        </table>
                        
                        

                    </asp:TextBox>
                    <script>

                        CKEDITOR.replace('tbOverviewDimensions', {
                            height: 450,
                            removeButtons: 'Subscript,Superscript,Scayt,Link,Unlink,Anchor,HorizontalRule,SpecialChar,Maximize,Blockquote,About,Styles,Format'
                        }
                        )
                    </script>

                    <br>
                    <br>
                    
                    
                    <br>
                    <asp:Button ID="btnUploadOverview" runat="server" Text="上傳內容" OnClick="btnUploadOverview_OnClick" />
                    <asp:Button ID="btnReturn" runat="server" Text="取消返回" OnClick="btnReturn_OnClick" />
                    <br>
                    
                    
                    
                </div>
            </div>
        </div>
    </form>





</asp:Content>
