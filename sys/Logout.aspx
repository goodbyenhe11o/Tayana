<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="TayanaSystem.sys.Logout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            
            <%
                //Session.Abandon();
                
                Response.Write("<script>alert('您已登出');location.href='Login.aspx';</script>");

            %>
        </div>
    </form>
</body>
</html>
