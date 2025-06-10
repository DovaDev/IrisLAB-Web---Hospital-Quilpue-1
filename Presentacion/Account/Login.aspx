<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="Presentacion.Login1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>LOGIN</title>
    <!-- Bootstrap core CSS-->
    <link href="/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Custom fonts for this template-->
    <link href="/vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Custom styles for this template-->
    <link href="/css/sb-admin.css" rel="stylesheet" />
    <link href="/css/Iris_Css.css" rel="stylesheet" />
</head>

<body>
    <div class="container">
                <style>
            @media screen and (min-width: 600px) {
                body {
                    background: url(/Imagenes/IMAGEN_IRISHIS.jpg) no-repeat center center fixed;
                    background-size: cover;
                    display: flex;
                    justify-content: center;
                    align-items: center;
                    height: 100vh;
                    margin: 0;
                }
            }

            html {
                height: 100%;
            }

            .card-transparent {
                background: none;
            }

                .card-transparent .card-header {
                    background: rgba(122, 130, 136, 0.7) !important;
                    color: white;
                }

                .card-transparent .card-body {
                    background: rgba(46, 51, 56, 0.7) !important;
                    color: white;
                }

            .card-body a {
                color: white;
            }

            .card-login {
                max-width: 25rem;
            }

            .centerx {
                display: flex;
                display: -webkit-flex;
                flex-flow: column nowrap;
                justify-content: center;
                align-items: center;
            }
        </style>

        <div class="row mt-3">
            <div class="col-md-4">
            </div>
            <div class="col-md-4 text-center">
                <img src="../Imagenes/logohospquilpue_new.jpg" style="max-height: 300px; width: auto"  class="img-fluid" alt="Responsive image" />
            </div>
            <div class="col-md-4 text-center centerx">
                <%--<img src="../Imagenes/00_logo_holanda_full.png" style="height: auto; max-width: 270px; background-color: white" class="img-fluid" alt="Responsive image" />--%>
            </div>
        </div>
        <div class="container">
            <div class="card card-login mx-auto mt-5 border-bar">
                <div class="card-header bg-bar"><h5>Iniciar Sesión</h5></div>
                <div class="card-body">
                    <form>
                        <div class="form-group">
                            <label for="Txt_User">Usuario:</label>
                            <input class="form-control" id="Txt_User" type="text" aria-describedby="emailHelp" placeholder="Ingrese Usuario">
                        </div>
                        <div class="form-group">
                            <label for="Txt_Pass">Contraseña:</label>
                            <input class="form-control" id="Txt_Pass" type="password" placeholder="Ingrese Contraseña">
                        </div>
                        <!--
                    <div class="form-group">
                        <div class="form-check">
                            <label class="form-check-label">
                                <input class="form-check-input" type="checkbox">
                                Remember Password</label>
                        </div>
                    </div>-->
                        <button id="Btn_Login" type="button" class="btn btn-info btn-block">Ingresar</button>                        
                    </form>
                    <!--
                <div class="text-center">
                    <a class="d-block small mt-3" href="register.html">Registrar una Cuenta</a>
                    <a class="d-block small" href="forgot-password.html">¿Olvidó su contraseña?</a>
                </div>-->
                </div>
            </div>
            <div id="mdlAlert" class="alert alert-danger card-login mx-auto mt-2">
                <strong>ERROR:</strong> Usuario/Contraseña incorrecto.
       
            </div>
        </div>
        <div class="row">
            <div class="col-12 text-center">
                 <img src="../Imagenes/logo_largo_irislab.png" style="max-height: 150px" class="img-fluid" alt="Responsive image" />
            </div>
        </div>

    </div>
    <!-- Bootstrap core JavaScript-->
    <script src="/vendor/jquery/jquery.min.js"></script>
    <script src="/vendor/popper/popper.min.js"></script>
    <script src="/vendor/bootstrap/js/bootstrap.min.js"></script>
    <!-- Core plugi JavaScript-->
    <script src="/vendor/jquery-easing/jquery.easing.min.js"></script>
    <script src="/js/Galletas.js"></script>
    <script src="/Account/Login.js"></script>
    <script src="/js/Base64.js"></script>
</body>
</html>
