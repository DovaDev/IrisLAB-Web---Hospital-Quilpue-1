<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Acc_Pac.aspx.vb" Inherits="Resultados.Acc_Pac" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%@ OutputCache Location="None" NoStore="true" %>

    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <link href="vendor/bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="vendor/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="js/datepicker/css/bootstrap-datepicker3.css" rel="stylesheet" />

    <script src="vendor/jquery/jquery.js"></script>
    <script src="vendor/popper/popper.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.js"></script>
    <script src="js/datepicker/js/bootstrap-datepicker.js"></script>
    <script src="js/datepicker/locales/bootstrap-datepicker.es.min.js"></script>
    <script src="js/moment.js"></script>
    <script src="js/moment_es.js"></script>
    <script src="js/RUT.js"></script>
    <script src="Acc_Pac.js"></script>
    <link href="css/Iris_Css.css" rel="stylesheet" />
    <style>
        body {
            background: url(/Imagenes/IMAGEN_IRISHIS.jpg);
            background-size: cover;
            background-repeat: no-repeat;
        }

        .vali {
            text-align: center;
        }

                        #red_examed2:hover {
  background-color: #e6e3e3;
}

        @media only screen and (max-width: 720px) {
            body {
                background: none;
            }

            .vali {
                text-align: left;
            }
        }
    </style>
</head>

    <script>
        function Ajax_Ver_Documento() {
            var xURL = "http://irislabexterno.cl:9991/uploads/Prestaciones.pdf";
            window.open(xURL, "_blank");
        };

        function Ajax_Ver_Documento2() {
            var xURL = "http://irislabexterno.cl:9991/uploads/Preparacion.pdf";
            window.open(xURL, "_blank");
        };
    </script>
<body>

    <div class="modal" tabindex="-1" role="dialog" id="mdl_No_Conf">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Términos y Condiciones de uso</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body vali" style="overflow:auto; max-height:75vh;">
                    <p class="text-justify">
                        Estimado Usuario, debe aceptar los Términos y Condiciones de uso para poder visualizar los resultados.
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal" tabindex="-1" role="dialog" id="mdl_Term_Cond">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Términos y Condiciones de uso</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body vali" style="overflow:auto; max-height:75vh;">
                    <div class="text-left mb-4">
                        <img src="./Imagenes/Logo-cmvm_valpo.jpg" style="max-height:100px" class="img-fluid" alt="Responsive image" />
                    </div>

                    <h4>Términos y condiciones de uso</h4>

                    <p class="text-justify">
                        Estimado Usuario:
                    </p>
                    <p class="text-justify">
                        Usted va a acceder a información confidencial y expresamente clasificada como datos sensibles por la
                        Legislación vigente.
                    </p>
                    <p class="text-justify">
                        Si los resultados de exámenes de laboratorio que aquí se entregan no le pertenecen, le informamos que la
                        copia, difusión o cualquier mal uso de esta información está sancionada por la ley.
                    </p>
                    <p class="text-justify">
                        La entrega de resultados de exámenes por internet está sujeta a la Ley N° 19.628, que regula la protección
                        de datos de carácter personal y a la Ley N°20.584 que regula los DERECHOS Y DEBERES que tienen las
                        personas en relación con acciones vinculadas a su atención en salud.
                    </p>
                    <p class="text-justify">
                        Los resultados únicamente se podrán consultar mediante el uso del:
                    </p>
                    <img src="voucher.JPG" />
                    <p class="text-justify">
                        La Orden de Atención es un documento de carácter personal que le será entregado al momento de la toma
                        de muestras en su consultorio
                    </p>
                    <p class="text-justify">
                        No es necesario que Ud. imprima estos resultados para acudir a su consulta o control médico, ya que éstos
                        resultados se encuentran disponibles en la intranet de su Consultorio, asegurando que el médico acceda a
                        sus exámenes de laboratorio on line para su atención clínica.
                    </p>
                    <p class="text-justify">
                        No todos los resultados de exámenes pueden ser consultados a través de internet.
                    </p>
                    <p class="text-justify">
                        Si su examen NO esta disponible por internet, deberá retirar sus resultados personalmente en su
                        Consultorio, sin perjuicio las dependencias de la Unidad de Toma de Muestra en que lo haya realizado.
                    </p>
                    <p class="text-justify" style="color: #194996">
                        Los exámenes que no están disponibles vía web son:

                    </p>
                    <p class="text-justify" style="color: #194996">
                        - Test VIH
                    </p>
                    <p class="text-justify" style="color: #194996">
                        - Screening Sifilis
                    </p>
<%--                    <p class="text-justify" style="color: #194996">
                        - Examen Papanicolau
                    </p>
                    <p class="text-justify" style="color: #194996">
                        - Cultivos de Koch
                    </p>--%>
                    <p class="text-justify">
                        El Laboratorio Clinico CMV no es responsable por las interpretaciones que los pacientes hagan de sus
                        resultados, los que deberán ser revisados e interpretados por un médico.
                    </p>
                    <p class="text-justify">
                        Le informamos que este sistema está certificado para acceder desde su computador de escritorio y
                        dispositivos Android, con navegadores Internet Explorer, Chrome y Firefox en las versiones certificadas por
                        nuestra Red.
                    </p>
                    <p class="text-justify">
                        Para poder ver los informes PDF, usted debe tener instalado Acrobat Reader.
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row mt-3">
            <div class="col-lg-2">
            </div>
            <%--<div class="col-lg-4 text-center">
                <img src="../Imagenes/IrisLab%20logito.png" style="width: 350px !important" />
            </div>--%>
            <div class="col-lg-8 text-center">
                <img src="./Imagenes/Logo-cmvm_valpo.jpg" style="height: auto; max-width: 300px; background-color: white" class="img-fluid" alt="Responsive image" />
            </div>
            <div class="col-lg-2">
            </div>
        </div>


        <div class="row">
            <div class="col-lg-3"></div>
            <div class="col-lg-6">
                <div class="card m-3 border-bar">
                    <div class="card-header bg-bar">
                        <h4 class="text-center m-0">ACCESO RESULTADOS PACIENTES</h4>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-12">
                                <div class="form-group">
                                    <label>RUT:</label>
                                    <input type="text" id="Txt_RUT" class="form-control form-control-sm" placeholder="12.345.678-9" tabindex="1" />
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="form-group">
                                    <label>N° Folio:</label>
                                    <input type="text" id="Txt_AteNum" class="form-control form-control-sm" placeholder="123456789" tabindex="2" />
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="form-group">
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
                                <div class="form-check">
                                    <input class="form-check-input ml-0" type="checkbox" value="" id="chk_valida" style="margin-top:0.4rem">
                                    <label class="form-check-label" for="defaultCheck1">
                                        Declaro conocer los <a data-toggle="modal" href="#" data-target="#mdl_Term_Cond" id="acepto">Términos y Condiciones de uso.</a>
                                    </label>
                                </div>
                            </div>
                            <div class="col-12">
                                <div class="form-group mb-0">
                                    <button type="button" id="Btn_Login" class="btn btn-block btn-buscar btn-group-sm mt-1" tabindex="4">
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
            <div class="col-lg-3">
            </div>
        </div>
        <div id="red_examed" class="row text-center" style="margin-right:40px;margin-left:10px">
            <div class="col-md-3"></div>
            <div id="red_examed2" class="col-md-6 card m-3 border-bar" style="cursor:pointer;">
                <span style="font-weight:700; color:#009639;">Solicitar hora para exámenes de Laboratorio <i class="fa fa-flask" style="color:dodgerblue"></i></span>
            </div>
            <div class="col-md-3"></div>
        </div>
        <div class="text-center">

            <img src="../Imagenes/IrisLab_Logo_LARGO.png" style="max-height: 150px" class="img-fluid" alt="Responsive image" />

        </div>
        
    </div>
</body>
</html>
