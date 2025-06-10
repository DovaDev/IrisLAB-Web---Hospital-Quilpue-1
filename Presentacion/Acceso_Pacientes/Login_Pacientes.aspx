<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login_Pacientes.aspx.vb" Inherits="Presentacion.Login_Pacientes" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%@ OutputCache Location="None" NoStore="true" %>

    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <link href="/vendor/bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="/vendor/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="/js/datepicker/css/bootstrap-datepicker3.css" rel="stylesheet" />

    <script src="/vendor/jquery/jquery.js"></script>
    <script src="/vendor/popper/popper.js"></script>
    <script src="/vendor/bootstrap/js/bootstrap.js"></script>
    <script src="/js/datepicker/js/bootstrap-datepicker.js"></script>
    <script src="/js/datepicker/locales/bootstrap-datepicker.es.min.js"></script>
    <script src="/js/moment.js"></script>
    <script src="/js/moment_es.js"></script>
    <script src="/js/RUT.js"></script>
    <script src="Login_Pacientes.js"></script>
    <link href="../css/Iris_Css.css" rel="stylesheet" />
    <style>
        body {
            background: url(/Imagenes/IMAGEN_IRISHIS.jpg);
        }

        .flex-box {
            display: flex;
            display: -webkit-flex;
            flex-flow: column nowrap;
            width: 100%;
            min-height: 100vh;
            justify-content: center;
            align-items: center;
        }

            .flex-box > .cardcito {
                min-width: 200px;
                width: 60%;
                max-width: 450px;
                /*box-shadow: 0 0 6px 6px rgba(0, 0, 0, 0.3);*/
            }

            .flex-box > img {
                display: block;
                max-height: 150px;
                width: 30%;
                max-width: 150px;
                height: auto;
            }

            .flex-box > .alert {
                display: flex;
                display: -webkit-flex;
                flex-flow: row nowrap;
                justify-content: space-around;
                align-items: center;
            }

                .flex-box > .alert > i {
                    width: 32px;
                    margin: 0px;
                    padding: 0px;
                }

                .flex-box > .alert > p {
                    width: calc(100% - 36px - 40px);
                    margin: 0px;
                    padding: 0px;
                    text-align: justify;
                }

        input[type=text] {
            color: #495057 !important;
            background: #ffffff !important;
        }

        @media (max-width: 575.98px) {
            .flex-box > .alert {
                flex-flow: column nowrap;
                padding: 10px;
            }

                .flex-box > .alert > i {
                    margin-bottom: 5px;
                }

                .flex-box > .alert > p {
                    width: calc(100% - 20px);
                    margin: 0px;
                    padding: 0px;
                    text-align: center;
                }
        }
    </style>
</head>
<body>

    <div class="container">
        <div class="row mt-3">
            <div class="col-lg-2">
            </div>
            <div class="col-lg-4 text-center">
                <img src="../Imagenes/IrisLab%20logito.png" style="width: 350px !important" />
            </div>
            <div class="col-lg-4 text-center">
                <img src="/Imagenes/CMVM.png" id="imgx2" style="width: 170px !important; background-color: white" />
            </div>
            <div class="col-lg-2">
            </div>
        </div>


        <div class="row">
            <div class="col-md-3"></div>
            <div class="col-md-6">
                <div class="card m-3 cardcito border-bar">
                    <div class="card-header bg-bar">
                        <h4 class="text-center m-0">ACCESO PACIENTES</h4>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-12">
                                <div class="form-group text-sm-left">
                                    <label>RUT:</label>
                                    <input type="text" id="Txt_RUT" class="form-control form-control-sm" placeholder="12.345.678-9" tabindex="1" />
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="form-group text-sm-left">
                                    <label>N° Atención:</label>
                                    <input type="text" id="Txt_AteNum" class="form-control form-control-sm" placeholder="123456789" tabindex="2" />
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="form-group text-sm-left">
                                    <label>Fecha:</label>
                                    <div class="input-group date">
                                        <input type="text" id="Txt_Date" class="form-control form-control-sm" readonly tabindex="3" />
                                        <span class="input-group-addon">
                                            <i class="fa fa-calendar"></i>
                                        </span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="form-group text-sm-left">
                                    <button type="button" id="Btn_Login" class="btn btn-block btn-buscar mt-4" tabindex="4">
                                        <i class="fa fa-sign-in"></i>
                                        <span>Ingresar</span>
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="errRUT_1" class="alert alert-danger m-3" style="display: none;">
                    <i class="fa fa-exclamation-circle fa-2x"></i>
                    <p>El RUT que ha ingresado no corresponde a un formato válido.</p>
                </div>
                <div id="errRUT_2" class="alert alert-danger m-3" style="display: none;">
                    <i class="fa fa-exclamation-circle fa-2x"></i>
                    <p>El RUT que ha ingresado no puede quedar vacío.</p>
                </div>
                <div id="errFolio" class="alert alert-danger m-3" style="display: none;">
                    |
            <i class="fa fa-exclamation-circle fa-2x"></i>
                    <p>El Campo N° de Atención no puede quedar vacío.</p>
                </div>
                <div id="errNotFound" class="alert alert-danger m-3" style="display: none;">
                    <i class="fa fa-exclamation-circle fa-2x"></i>
                    <p>No se ha encontrado el Paciente o la Atención ingresada.</p>
                </div>
            </div>
            <div class="col-md-3"></div>
        </div>
    </div>




</body>
</html>
