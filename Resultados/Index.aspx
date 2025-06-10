<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Paciente.Master" CodeBehind="Index.aspx.vb" Inherits="Resultados.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <style>
                body {
            background: url(/Imagenes/IMAGEN_IRISHIS.jpg);
            background-size: cover;
            background-repeat: no-repeat;
        }
                #red_examed2:hover {
  background-color: #e6e3e3;
}
    </style>
    <script>

        $(document).ready(function () {            
            $("#Btn_Pacc").click(() => {

                window.location = "/Acc_Pac.aspx";;
            });

            $("#Btn_Consultas").click(() => {

                window.location = "/Reg_Solicitud.aspx";;
            });

            $("#Btn_Examenes").click(() => {

                window.location = "/Construccion.aspx";;
            });
            $("#red_examed2").click(() => {
                window.open("http://examed.cl/ExamedInicio/ExamedInicio/agendaMedico.aspx?med=10046");
            });
        });


    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
        <!-- Modal -->
    <div id="mError_AAH" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 class="modal-title">Rut NO Válido</h4>
                </div>
                <div class="modal-body">
                    <p>AAAHAHHHHH</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
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
                <img src="./Imagenes/Logo-cmvm_valpo.jpg" style="height: auto; max-width: 300px;" class="img-fluid" alt="Responsive image" />
            </div>
            <div class="col-lg-2">
            </div>
        </div>
            <br />

        <div class="row">
            <div class="col-lg-1"></div>
            <div class="col-lg-10">
                <div class="card m-3 border-bar">
            <div class="card-header bg-bar text-center">
                <%--<h4><i class="fa fa-plane fa-fw"></i>BIENVENIDOS A:</h4>--%>
                <h4>BIENVENIDOS A:</h4>
                <h5>LABORATORIO CLÍNICO CORPORACIÓN MUNICIPAL DE VALPARAÍSO </h5>
                <%--<h6>Campos obligatorios(*)</h6>--%>
            </div>
            <div class="card-body">
                <div class="row mt-3" style="text-align:center;">
                    <div class="col-lg text-center">
                        <h4>RESULTADOS</h4>
                        <h6>Revise los resultados de sus exámenes de laboratorio</h6>
                        <button type="button" class="btn btn-print" id="Btn_Pacc" style="width:100px;margin-top:70px; cursor:pointer;"><i class="fa fa-book fa-fw"></i>Ir</button>   
                    </div>
                    <div class="col-lg text-center">
                        <h4>CONSULTAS, SUGERENCIAS, RECLAMOS</h4>
                        <h6>Comuníquese con nosotros y cuéntenos su experiencia</h6>
                        <button type="button" class="btn btn-pendiente" id="Btn_Consultas" style="width:100px;margin-top:15px; cursor:pointer;"><i class="fa fa-exclamation fa-fw"></i>Ir</button>                       
                    </div>
                    <div class="col-lg text-center">
                        <h4>EXÁMENES DE LABORATORIO DISPONIBLES</h4>
                        <h6>Consulte por los exámenes disponibles y como debe prepararse para ello</h6>
                        <button type="button" class="btn btn-success" id="Btn_Examenes" style="width:100px; cursor:pointer;"><i class="fa fa-flask fa-fw"></i>Ir</button>
                    </div>
                </div>
<%--                <div class="row mt-3">
                    <div class="col-lg text-center">
                        <h5>Revise los resultados de sus exámenes de laboratorio</h5>
                    </div>
                    <div class="col-lg text-center">
                        <h5>Comuníquese con nosotros y cuéntenos su experiencia</h5>
                    </div>
                    <div class="col-lg text-center">
                        <h5>Consulte por los exámenes de laboratorio disponibles y como debe prepararse para ello</h5>
                    </div>
                </div>
                <div class="row mt-3">
                    <div class="col-lg text-center">
                        <button type="button" class="btn btn-print" id="Btn_Pacc" style="width:100px;"><i class="fa fa-book fa-fw"></i>Ir</button>
                    </div>
                    <div class="col-lg text-center">
                        <button type="button" class="btn btn-pendiente" id="Btn_Consultas" style="width:100px;"><i class="fa fa-exclamation fa-fw"></i>Ir</button>
                    </div>
                    <div class="col-lg text-center">
                        <button type="button" class="btn btn-success" id="Btn_Examenes" style="width:100px;"><i class="fa fa-flask fa-fw"></i>Ir</button>
                    </div>
                </div>--%>
                </div>
            </div>


            </div>
            <div class="col-lg-1"></div>
        </div>
        <div id="red_examed" class="row text-center"  style="margin-right:20px;">
            <div class="col-lg-2"></div>
            <div id="red_examed2" class="col-lg-8 card m-3 border-bar" style="cursor:pointer;">
                <span style="font-weight:700; color:#009639;">Solicitar hora para exámenes de Laboratorio <i class="fa fa-flask" style="color:dodgerblue"></i></span>
            </div>
            <div class="col-lg-2"></div>
        </div>
        <div class="text-center">

            <img src="../Imagenes/IrisLab_Logo_LARGO.png" style="max-height: 150px" class="img-fluid" alt="Responsive image" />

        </div>


</asp:Content>