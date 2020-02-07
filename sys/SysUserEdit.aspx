<%@ Page Title="" Language="C#" MasterPageFile="~/sys/Site.Master" AutoEventWireup="true" CodeBehind="SysUserEdit.aspx.cs" Inherits="TayanaSystem.sys.SysUserEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="col-lg-12  mt-3">
            <div class="card">
                <div class="card-body">

                    <h3>新增使用者</h3>

                    <br>
                    <asp:Label ID="lbName" runat="server" Text="使用者名稱" AssociatedControlID="tbName"></asp:Label>
                    <asp:TextBox ID="tbName" runat="server" required="" aria-required="true" oninput="setCustomValidity('');"
                        oninvalid="setCustomValidity('請填入使用者暱稱')"></asp:TextBox>
                    <br>
                    <br>
                    <asp:Label ID="lbAccount" runat="server" Text="使用者帳戶" AssociatedControlID="tbAccount"></asp:Label>
                    <asp:TextBox ID="tbAccount" runat="server" required="" aria-required="true" oninput="setCustomValidity('');"
                        oninvalid="setCustomValidity('請填入使用者帳戶')"></asp:TextBox>
                    <br>
                    <br>
                    <asp:Label ID="lbPwdOld" runat="server" Text="請輸入使用者密碼"  ></asp:Label>
                    <asp:TextBox ID="tbPwdOld" runat="server" TextMode="Password" required="" aria-required="true" oninput="setCustomValidity('');"
                        oninvalid="setCustomValidity('請填入使用者密碼')" CssClass="mb-3"></asp:TextBox>
                    <br>

                    <br>
                    後台權限(Menu)
        <br>
                    <table>

                        <tr>
                            <td>
                                <input id="choose_all" type="checkbox" />
                            </td>
                            <td>
                                <label for="choose_all">全選</label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input id="authority_01" name="item" type="checkbox" class="tick" value="01" />

                            </td>
                            <td>
                                <label for="authority_01">權限01：遊艇管理</label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input id="authority_02" name="item" type="checkbox" class="tick" value="02" />

                            </td>
                            <td>
                                <label for="authority_02">權限02：新聞管理</label>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input id="authority_03" name="item" type="checkbox" class="tick" value="03" />

                            </td>
                            <td>
                                <label for="authority_03">權限03：代理商管理</label>
                            </td>
                        </tr>

                        <input id="hidden_authority" type="hidden" name="authority" runat="server" clientidmode="Static" />

                    </table>



                    <br>
                    帳戶權限
        <asp:RadioButtonList ID="rdblUserManage" runat="server">
            <asp:ListItem Text="帳號管理員(可管理帳戶與後台)" Value="1"></asp:ListItem>
            <asp:ListItem Text="一般使用者(只能管理後台)" Value="2" Selected="True"></asp:ListItem>
        </asp:RadioButtonList>


                    <br>
                    <br>


                    <asp:Button ID="btnSubmit" runat="server" Text="確認新增帳戶" class="btn btn-primary" OnClick="btnSubmit_OnClick" />
                    <input id="Reset1" type="reset" value="重設" class="btn btn-danger px-5 " />
                    <asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_OnClick" CssClass="btn btn-default  px-5" />

                </div>
            </div>
        </div>

        <script>
            let all = document.getElementById("choose_all");
            let tick = document.querySelectorAll(".tick");
            let arr = [];
            all.addEventListener("click", fun, false);
            //全選
            function fun() {
                for (let i = 0; i < tick.length; i++) {
                    if (all.checked) {
                        tick[i].checked = true;
                    } else {
                        tick[i].checked = false;
                    }
                }
                document.getElementById("hidden_authority").value = getData();
            }
            //單選
            for (let i = 0; i < tick.length; i++) {
                tick[i].addEventListener("click", function () {
                    document.getElementById("hidden_authority").value = getData();
                    all.checked = false;
                }, false);
            }
            function getData() {
                arr = [];
                for (let i = 0; i < tick.length; i++) {
                    if (tick[i].checked === true) {
                        arr.push(tick[i].value)
                    }
                }
                return arr.join()
            }
            window.onload = function () {
                let str = document.getElementById("hidden_authority").value;
                for (let i = 0; i < tick.length; i++) {
                    if (str.indexOf(tick[i].value) !== -1) {
                        tick[i].checked = true;
                    }
                }
            }
        </script>


    </form>
</asp:Content>
