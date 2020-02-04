<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TayanaSystem.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>--%>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width,initial-scale=1">
    <title>Tayana System Login</title>

    <!-- Favicon icon -->
    <%--<link rel="icon" type="image/png" sizes="16x16" href="../../assets/images/favicon.png">--%>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.5.0/css/all.css" integrity="sha384-B4dIYHKNBt8Bc12p+WXckhzcICo0wtJAoU8YZTY5qE0Id1GSseTk6S+L3BlXeVIU" crossorigin="anonymous">
    <link href="template/css/style.css" rel="stylesheet" />


</head>
<body class="h-100">
    <form id="form1" runat="server">

        <!--*******************
        Preloader start
    ********************-->
        <div id="preloader">
            <div class="loader">
                <svg class="circular" viewBox="25 25 50 50">
                    <circle class="path" cx="50" cy="50" r="20" fill="none" stroke-width="3" stroke-miterlimit="10" />
                </svg>
            </div>
        </div>
        <!--*******************
        Preloader end
    ********************-->





        <div class="login-form-bg h-100">
            <div class="container h-100">
                <div class="row justify-content-center h-100">
                    <div class="col-xl-6">
                        <div class="form-input-content">
                            <div class="card login-form mb-0">
                                <div class="card-body pt-5">

                                    <a class="text-center" href="#">
                                        <h4>TAYANA SYSTEM</h4>
                                    </a>

                                    <form class="mt-5 mb-5 login-input">
                                        <div class="form-group">
                                            <input type="text" class="form-control" placeholder="Name" required>
                                        </div>
                                        <div class="form-group">
                                            <input type="email" class="form-control" placeholder="Email" required>
                                        </div>
                                        <div class="form-group">
                                            <input type="password" class="form-control" placeholder="Password" required>
                                        </div>
                                        <button class="btn login-form__btn submit w-100">Sign in</button>
                                    </form>
                                    <p class="mt-5 login-form__footer">Have account <a href="Login.aspx" class="text-primary">Sign Up </a>now</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    

    

    <!--**********************************
        Scripts
    ***********************************-->
        <script src="template/plugins/common/common.min.js"></script>
        <script src="template/js/custom.min.js"></script>
        <script src="template/js/settings.js"></script>
        <script src="template/js/gleek.js"></script>
        <script src="template/js/styleSwitcher.js"></script>
    </form>
</body>
</html>
