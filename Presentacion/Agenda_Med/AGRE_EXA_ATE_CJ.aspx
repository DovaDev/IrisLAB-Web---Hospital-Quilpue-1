<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="AGRE_EXA_ATE_CJ.aspx.vb" Inherits="Presentacion.AGRE_EXA_ATE_CJ" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script src="../js/Deep-Copy.js"></script>
    <script src="AGRE_EXA_ATE_CJ.js"></script>
    
    <!--ClockPicker-->
    <link href="../css/ClockPicker.css" rel="stylesheet" />
    <script src="/js/ClockPicker.js"></script>
    <script src="/js/highlight.js"></script>
    <%@ OutputCache Location="None" NoStore="true" %>

    <style>
          .selectSize {
            /*height:calc(1.89rem + 1px);*/
            height: 1000px;
        }


        .negrita {
        font-weight:700;
        }


        .borderRound {
            border-radius:.25rem;
        }

        .carlos_sama {
            width: 5vw;
        }

        .dark_text {
            font-weight: 700;
        }
        .alertas {
            margin-top: 180px;
            text-align: center;
        }
        .manito {
            cursor: pointer;
        }
        .manitos2 {
            cursor: pointer;
        }

        .textoReducido {
            font-size: 11px;
        }
        .textDerecho {
            text-align: right;
        }

        .ancho-columna {
            height: 10%;
            padding: -35px;
        }

        .highlights {
            width: 100%;
            /*height: 300px; /* Ancho y alto fijo */ */ overflow: auto; /* Se oculta el contenido desbordado */
            /* background-color: #efefef;*/
            /*border: 2px solid #46963f;*/
        }

        .highlights2 {
            width: 100%;
            height: 300px; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
            /* background-color: #efefef;*/
            /*border: 2px solid #46963f;*/
        }

        .topbuttom {
            display: block;
            height: 80px;
            width: 100%;
        }

        .topbuttom2 {
            display: block;
            height: 80px;
        }

        .textbot {
            display: block;
            height: 22px;
            width: 100%;
        }

        .textbotLeft {
            display: block;
            height: 28px;
            width: 100%;
        }

        .cabzera {
            background: #46963f;
            color: white;
        }

        .espera {
            background: #c7ff00;
        }

        .atendido {
            background: #1fc12c;
            color: white;
        }

        #XXXXXXXX {
            z-index: 9000;
            width: 100%;
            position: fixed;
            left: 0px;
            top: 0px;
            display: flex;
            display: -webkit-flex;
            flex-flow: row nowrap;
            justify-content: center;
            color: #444;
            border: 0;
            border-radius: 2px;
            text-decoration: none;
            transition: opacity 0.2s ease-out;
            opacity: 0;
            margin-top: 60px;
        }

            #XXXXXXXX div {
                font-size: 18px;
                border: none;
                outline: none;
                background-color: #014B5D;
                color: white;
                padding: 8px;
                border-radius: 4px;
                font-size: 15px;
            }



            #XXXXXXXX.show {
                opacity: 1;
            }

        #content {
            height: 2000px;
        }

        @media screen and (min-width: 558px) {
            .topbuttom2 {
                width: 100%;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
            <!-- Modal NUEVO SELECCION DE PAGO-->
    <div id="MOdal_NUEVO_SELECCION" class="modal fade" role="dialog">
        <div class="modal-dialog" role="document" style="max-width:60vw">

            <!-- Modal content-->
            <div class="modal-content">
                <br />
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 id="title2NuevoSeleccion" class="modal-title" style="margin-top:65px; text-align:center;">¿Cómo pagará el copago el paciente?</h4>
                <div id="modalpcccNuevoSeleccion" class="modal-body">
                    <div class="row">
                        <div class="col-lg">
                            <label>Forma de Pago</label>
                        </div> 
                        <div class="col-lg-5">
                            <label>Tarjeta (N° Operación) y Cheque (Nom. y Número)</label>
                        </div>
                        <div class="col-lg">
                            <label id="lbl_tot_copago"></label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg">
                            <select id="Ddl_Ttp_Modal" class="form-control">
                                <option value="1">Efectivo</option>
                                <option value="2">Cheque</option>
                                <option value="19">Convenio</option>
                                <option value="3">Pendiente de Pago</option>
                                <option value="11">Sin Costo</option>
                                <option value="21">Tarjeta Débito</option>
                                <option value="9">Tarjeta Crédito</option>
                            </select>
                        </div>
                        <div class="col-lg-5">
                            <input type="text" id="txt_nTarjeta_1_modal" class="form-control"/>
                        </div>
                        <div class="col-lg">
                            <input type="text" id="lbl_Tot_Fonasa_Modal" class="form-control" disabled="disabled" onkeydown="return jsDecimals(event)" maxlength="9"/>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-8">
                        </div>
                        <div class="col-lg-4 text-right">
                            <span id="spanAgregaMedioPago" style="font-weight:600;">Agregar Medio de Pago <i id="agregaMedioPago" class="fa fa-plus" style="color:#039921; cursor:pointer"></i></span>                          
                        </div>
                    </div>
                    <%--NUEVO TIPO DE PAGO--%>
                    <div id="divNewPaymen" style="display:none;">
                        <div class="row">
                        <div class="col-lg">
                            <label>Forma de Pago</label>
                        </div> 
                        <div class="col-lg-5">
                            <label>Tarjeta (N° Operación) y Cheque (Nom. y Número)</label>
                        </div>
                        <div class="col-lg">
                            <label>VALOR (Fonasa)</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg">
                            <select id="Ddl_Ttp_Modal_2" class="form-control">
                                <option value="1">Efectivo</option>
                                <option value="2">Cheque</option>
                                <option value="19">Convenio</option>
                                <option value="3">Pendiente de Pago</option>
                                <option value="11">Sin Costo</option>
                                <option value="21">Tarjeta Débito</option>
                                <option value="9">Tarjeta Crédito</option>
                            </select>
                        </div>
                        <div class="col-lg-5">
                            <input type="text" id="txt_nTarjeta_1_modal_2" class="form-control"/>
                        </div>
                        <div class="col-lg">
                            <input type="text" id="lbl_Tot_Fonasa_Modal_2" value="0" class="form-control" disabled="disabled" onkeydown="return jsDecimals(event)"/>
                        </div>
                    </div>
                        <div class="row">
                        <div class="col-lg-8">
                        </div>
                        <div class="col-lg-4 text-right">
                            <span  style="font-weight:600;">Quitar Medio de Pago <i id="quitaMedioPago" class="fa fa-minus" style="color:#e02619; cursor:pointer"></i></span>                          
                        </div>
                    </div>
                    </div>
                    <%--FIN NUEVO TIPO DE PAGO--%>
                    <br />
                    <div>
                        <div class="row">
                            <div class="col-lg">
                                <label>Forma de Pago</label>
                            </div>
                            <div class="col-lg-5">
                                <div>
                                    <label>Tarjeta (N° Operación) y Cheque (Nom. y Número)</label>
                                </div>
                            </div>
                            <div class="col-lg">
                                <div>
                                    <label id="lbl_valor_parti"></label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg">
                                <select id="Ddl_Ttp_Modal2" class="form-control">
                                    <option value="1">Efectivo</option>
                                    <option value="21">Tarjeta Débito</option>
                                    <option value="9">Tarjeta Crédito</option>
                                </select>
                            </div>
                            <div class="col-lg-5">                   
                                <input type="text" id="txt_nTarjeta_2_modal" class="form-control"/>
                            </div>
                            <div class="col-lg">
                                <input type="text" id="lbl_Tot_Pagar_Insumos_Particul_Modal" class="form-control" disabled="disabled" onkeydown="return jsDecimals(event)"/>
                            </div>
                        </div>
                        <div class="row">
                        <div class="col-lg-8">
                        </div>
                        <div class="col-lg-4 text-right">
                            <span id="spanAgregaMedioPago_Parti" style="font-weight:600;">Agregar Medio de Pago Particular <i id="agregaMedioPago_Parti" class="fa fa-plus" style="color:#039921; cursor:pointer"></i></span>                          
                        </div>
                        <br />
                    </div>
                    <%--NUEVO TIPO DE PAGO PARTI--%>
                    <div id="divNewPaymen_Parti" style="display:none;">
                        <div class="row">
                        <div class="col-lg">
                            <label>Forma de Pago</label>
                        </div> 
                        <div class="col-lg-5">
                            <label>Tarjeta (N° Operación) y Cheque (Nom. y Número)</label>
                        </div>
                        <div class="col-lg">
                            <label>VALOR (Particular)</label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg">
                            <select id="Ddl_Ttp_Modal_2_Parti" class="form-control">
                                <option value="1">Efectivo</option>
                                <option value="21">Tarjeta Débito</option>
                                <option value="9">Tarjeta Crédito</option>                 
                            </select>
                        </div>
                        <div class="col-lg-5">
                            <input type="text" id="txt_nTarjeta_1_modal_2_Parti" class="form-control"/>
                        </div>
                        <div class="col-lg">
                            <input type="text" id="lbl_Tot_Fonasa_Modal_2_Parti" value="0" class="form-control" disabled="disabled" onkeydown="return jsDecimals(event)"/>
                        </div>
                    </div>
                        <div class="row">
                        <div class="col-lg-8">
                        </div>
                        <div class="col-lg-4 text-right">
                            <span style="font-weight:600;">Quitar Medio de Pago <i id="quitaMedioPago_Parti" class="fa fa-minus" style="color:#e02619; cursor:pointer"></i></span>                          
                        </div>
                    </div>
                    </div>
                    <%--FIN NUEVO TIPO DE PAGO PARTI--%>
                        <br />
                        <div class="row">
                            <div class="col-lg-6">
                            </div>
                            <div class="col-lg-3">
                                <label style="font-weight:700">N° Boleta</label>
                                <input type="text" id="txt_nBoleta_2_modal" class="form-control" onkeydown="return jsDecimals(event)"/>
                            </div>
                            <div class="col-lg-3">
                                <label style="font-weight:700">Total a Pagar</label>
                                <input type="text" class="form-control" disabled="disabled" id="lbl_Tot_Pagar_Modal" style="font-weight:700; font-size:19px;" height:"calc(1.89rem + 1px);"/>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" id="button_modal_pagoNuevoSeleccion" class="btn btn-success">Guardar</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>                  
                </div>
            </div>
        </div>
    </div>
        <!-- Modal_Eliminar -->
    <div id="Modal_Eliminar" class="modal fade" role="dialog">
        <div class="modal-dialog ml-xl-auto">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 class="modal-title">Eliminar Examen</h4>
                </div>
                <div class="modal-body">
                    <span>Estimado usuario: ¿Confirma eliminación de exámen?</span>
                </div>
                <div class="modal-footer">
                    <button type="button" id="btn_Eliminar_Confirma" class="btn btn-danger">Eliminar</button>
                    <button type="button" class="btn btn-warning" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Modal -->
    <div id="MOdal_PAGO" class="modal fade" role="dialog">
        <div class="modal-dialog ml-xl-auto">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 id="title2" class="modal-title">Error</h4>
                </div>
                <div id="modalpccc" class="modal-body">
                </div>
                <div class="modal-footer">
                    <button type="button" id="b" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                    <button type="button" id="bb" class="btn btn-success" data-dismiss="modal">Aceptar</button>
                </div>
            </div>
        </div>
    </div>
    <div id="XXXXXXXX" class="tobackinfo">
        <div id="xxx_xxx">
        </div>
    </div>

    <!-- Modal -->
    <div id="mError_AAH" class="modal fade" role="dialog">
        <div class="modal-dialog ml-xl-auto">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 id="title" class="modal-title">Error</h4>
                </div>
                <div class="modal-body">
                    <p></p>
                </div>
                <div class="modal-footer">
                    <button type="button" id="button_modal" class="btn btn-danger" data-dismiss="modal">Aceptar</button>
                </div>
            </div>
        </div>
    </div>

    <div id="mdlCheck_Print" class="modal fade" role="dialog">
        <div class="modal-dialog ml-xl-auto">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 class="modal-title">Aviso</h4>
                </div>
                <div class="modal-body">
                    <p>¿Desea Imprimir los Vouchers y Etiquetas de la atención generada?</p>
                </div>
                <div class="modal-footer">
                    <button type="button" id="Btn_Print_Mdl" class="btn btn-success" data-dismiss="modal">
                        <i class="fa fa-print" aria-hidden="true"></i>
                        <span>Imprimir</span>
                    </button>
                    <button type="button" class="btn btn-primary" data-dismiss="modal">
                        <i class="fa fa-times" aria-hidden="true"></i>
                        <span>Cancelar</span>
                    </button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="eModal3" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="sss5">Agregar Exámenes</h4>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="col-md-12">
                            <div id="Div_Tabla4" style="width: 100%;" class="highlights2"></div>
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <button type="button" id="btnexarepetido" class="btn btn-success">Cargar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="eModal2" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="sss">Agregar Exámenes</h4>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="col-md-12">
                            <div id="Div_Tabla2" style="width: 100%;" class="highlights2"></div>
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <button type="button" id="btnguardar" class="btn btn-success">Cargar</button>
                </div>
            </div>
        </div>
    </div>

    <!-- Breadcrumbs -->
    <div class="card border-bar">
        <div class="card-header bg-bar p-2">
            <h5 style="text-align: center; padding: 5px;">
                <i class="fa fa-sign-in"></i>
                Atención
            </h5>
        </div>
        <div class="card-body p-3">
            <div class="container" style="max-width: 100%;">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="row">
                            <div class="col-md checkbox checkbox-success">
                                <input id="checkBox999" value="rutee" type="checkbox" />
                                <label class="textoReducido" style="padding-left: 0px !important;" for="checkBox999">RUT</label><input id="checkBox888" value="DNI" type="checkbox" /><label style="margin-left: 15px; padding-left: 0px !important;" class="textoReducido" for="checkBox888">DNI:</label><input id="checkBox8887" value="DNI" type="checkbox" /><label style="margin-left: 15px; padding-left: 0px !important;" class="textoReducido" for="checkBox8887">N°Ate:</label>

                                <input type='text' id="rut" class="form-control textoReducido" placeholder="12.345.789-0" />
                                <input type='text' id="dni" class="form-control textoReducido" placeholder="D.N.I" />
                                <input type='text' id="Naten" class="form-control textoReducido" placeholder="N° Atención" />

                            </div>
                            <%--<div class="col-lg">
                                <label class="textoReducido">N° OMI:</label>
                                <div class="input-group" style="height: 31.75px;">
                                    <input type="text" id="Avis" class="form-control textoReducido" placeholder="Numero OMI" />
                                    <span class="input-group-btn">
                                        <button id="agregar_op" type="button" class="btn btn-info" data-toggle="tooltip" data-placement="right" title="Agregar nuevo folio al paciente actual" style="font-size: 12px;"><i class="fa fa-plus-circle"></i></button>

                                    </span>

                                </div>
                            </div>--%>
                            <div class="col-lg">
                                <label class="textoReducido">RUT:</label>
                                <input type='text' id="Rut_2m" class="form-control textoReducido" readonly="true" placeholder="" style="text-align: center;" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Nombres:</label>
                                <input type='text' id="Nom" class="form-control textoReducido" placeholder="" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Apellidos:</label>
                                <input type='text' id="Ape" class="form-control textoReducido" placeholder="" />
                            </div>
                            <%--     </div>
                        <div class="row">--%>
                            <div class="col-lg">
                                <label class="textoReducido">F.Nacimiento:</label>
                                <div class='input-group date' id='datetimepicker1' style="margin-bottom: 1vh;">
                                    <input type="date" min="0001-01-01" max="2018-12-01" id="fecha" class="form-control textoReducido" placeholder="Fecha" />
                                    <span class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </span>
                                </div>
                                <style>
                                    .glyphicon {
                                        display: inline-block;
                                        font-family: FontAwesome;
                                        font-style: normal;
                                        font-weight: normal;
                                        line-height: 1;
                                        -webkit-font-smoothing: antialiased;
                                        -moz-osx-font-smoothing: grayscale;
                                    }

                                    .glyphicon-arrow-left:before {
                                        content: "\f053";
                                    }

                                    .glyphicon-arrow-right:before {
                                        content: "\f054";
                                    }
                                </style>
                                <%--<script type="text/javascript">
                 
                                    $(function () {
                                        $('#datetimepicker1').datetimepicker(
                                            {
                                                debug: true,
                                                icons: {
                                                    previous: 'fa fa-arrow-left',
                                                    next: 'fa fa-arrow-right'
                                                },
                                                format: 'dd-mm-yyyy',
                                                language: 'es',
                                                weekStart: 1,
                                                autoclose: true,
                                                minDate: Date.now(),
                                                minView: 2,
                                                useCurrent: true

                                            })
                                    });
                                </script>--%>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Edad:</label>
                                <input type='text' id="Edad" class="form-control textoReducido" readonly="true" placeholder="" disabled="disabled" style="text-align: center;" />
                            </div>




                        </div>
                        <div class="row">
                            <%--<div class="col-lg">
                                <label class="textoReducido">Edad:</label>
                                <input type='text' id="Edad" class="form-control textoReducido" readonly="true" placeholder="" disabled="disabled" style="text-align: center;" />
                            </div>--%>
                            <div class="col-lg">
                                <label class="textoReducido">Sexo:</label>
                                <select id="sex" class="form-control textoReducido" style="height: 31.75px;">
                                </select>
                            </div>
                            <div class="col-lg checkbox checkbox-success">
                                <input id="checkBox2" type="checkbox" value="SoyFur" />
                                <label for="checkBox2" class="textoReducido">F.U.R:</label>
                                <div class='input-group date' id='datetimepicker3' style="margin-bottom: 1vh;">
                                    <input type='text' id="FUR" class="form-control textoReducido" readonly="true" placeholder="Fecha" />
                                    <span id="fur" class="input-group-addon">
                                        <i class="fa fa-calendar"></i>
                                    </span>
                                </div>
                                <style>
                                    .glyphicon {
                                        display: inline-block;
                                        font-family: FontAwesome;
                                        font-style: normal;
                                        font-weight: normal;
                                        line-height: 1;
                                        -webkit-font-smoothing: antialiased;
                                        -moz-osx-font-smoothing: grayscale;
                                    }

                                    .glyphicon-arrow-left:before {
                                        content: "\f053";
                                    }

                                    .glyphicon-arrow-right:before {
                                        content: "\f054";
                                    }
                                </style>
                                <script type="text/javascript">
                                    ////////////////////////////////////
                                    ////////////////////////////////////
                                    $(function () {
                                        $('#datetimepicker3').datetimepicker(
                                            {
                                                debug: true,
                                                icons: {
                                                    previous: 'fa fa-arrow-left',
                                                    next: 'fa fa-arrow-right'
                                                },
                                                format: 'dd-mm-yyyy',
                                                language: 'es',
                                                weekStart: 1,
                                                autoclose: true,
                                                minDate: Date.now(),
                                                minView: 2,
                                                useCurrent: true

                                            })
                                    });
                                </script>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Nacionalidad:</label>
                                <select id="Nacio" class="form-control textoReducido" style="height: 31.75px;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Tel. Fijo:</label>
                                <input type='text' id="telfijo" class="form-control textoReducido" placeholder="" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Celular:</label>
                                <input type='text' id="Celular" class="form-control textoReducido" placeholder="" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Dirección:</label>
                                <input type='text' id="direccion" class="form-control textoReducido" placeholder="" />
                            </div>
                        </div>
                        <div>
                            <div class="row" style="margin-bottom: 10px;">
                                <div class="col-lg">
                                    <label class="textoReducido">Ciudad:</label>
                                    <select id="Cuidad" class="form-control textoReducido" style="height: 31.75px;">
                                        <option value="0">Seleccionar</option>
                                    </select>
                                </div>
                                <div class="col-lg">
                                    <label class="textoReducido">Comuna:</label>
                                    <select id="Comuna" class="form-control textoReducido" style="height: 31.75px;">
                                        <option value="0">Seleccionar</option>
                                    </select>
                                </div>
                                <div class="col-lg">
                                    <label class="textoReducido">Email:</label>
                                    <input type='text' id="Email" class="form-control textoReducido" placeholder="Irislab@irislab.cl" />
                                </div>
                                <div class="col-lg-3">
                                    <label class="textoReducido">observaciones permanentes del paciente:</label>
                                    <input type='text' id="obdser" class="form-control textoReducido" placeholder="" />
                                </div>
                                <div class="col-lg">
                                    <label class="textoReducido">Diagnostico N° 1</label>
                                    <select id="DdlDiagnostico" class="form-control textoReducido" style="height: 31.75px;">
                                        <option value="0">Seleccionar</option>
                                    </select>
                                </div>
                                <div class="col-lg">
                                    <label class="textoReducido">Diagnostico N° 2</label>
                                    <select id="DdlDiagnostico2" class="form-control textoReducido" style="height: 31.75px;">
                                        <option value="0">Seleccionar</option>
                                    </select>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <hr />
            <hr />
            <h5 style="text-align: center; padding: 5px;" id="titulooo"></h5>
            <div class="container" style="max-width: 100%;">
                <div class="row">
                    <div class="col-sm">
                        <%--                    <div id="Div_Tabla" style="width: 100%;" class="highlights">                     
                         <table style="width:100%" class="table table-bordered">
                              <tr>
                                <th style="width: 20%;">Codigo Fonasa</th>
                                <th style="width: 100%;">Descripcion</th>
                                <th style="width: 50%;">Dias Proceso</th>
                              </tr>
                              <tr>
                                <td> <input type='text' id="Examen01" class="form-control textoReducido" placeholder=""/></td>
                                <td ><label id="desc1" style="margin-top:8px;"></label></td>
                                <td ><label id="dias1" style="margin-top:8px;"></label></td>
                              </tr>
                        </table> 
                    </div>--%>
                        <div id="Div_Tabla78" style="width: 100%;" class="highlights"></div>
                    </div>
                </div>

            </div>
            <hr />
            <hr />
            <h5 style="text-align: center; padding: 5px;">Agregar nuevos exámenes a la atención actual </h5>
            <div class="container" style="max-width: 100%;">
                <div class="row">
                    <div class="col-sm">
                        <%--                    <div id="Div_Tabla" style="width: 100%;" class="highlights">                     
                         <table style="width:100%" class="table table-bordered">
                              <tr>
                                <th style="width: 20%;">Codigo Fonasa</th>
                                <th style="width: 100%;">Descripcion</th>
                                <th style="width: 50%;">Dias Proceso</th>
                              </tr>
                              <tr>
                                <td> <input type='text' id="Examen01" class="form-control textoReducido" placeholder=""/></td>
                                <td ><label id="desc1" style="margin-top:8px;"></label></td>
                                <td ><label id="dias1" style="margin-top:8px;"></label></td>
                              </tr>
                        </table> 
                    </div>--%>
                        <div id="Div_Tabla3" style="width: 100%;" class="highlights"></div>
                    </div>
                </div>

            </div>
            <div class="container" style="max-width: 100%; border: 0px solid #fff;">
                <div class="row">
                    <div class="col-sm-3">
                        <button id="Examen" type="button" class="btn btn-danger btn-block">
                            <br />
                            <i class="fa fa-align-left" aria-hidden="true" style="font-size: 30px;"></i>
                            <p style="margin-top: 2px;">Examen</p>
                        </button>
                    </div>
                    <div class="col-sm-2">
                        <button id="Btn_Print" type="button" class="btn btn-success btn-block">
                            <br />
                            <i class="fa fa-fw fa-print" aria-hidden="true" style="font-size: 30px; margin-top: 2px;"></i>
                            <p style="margin-top: 2px;">Imprimir</p>
                        </button>
                    </div>
                    <div class="col-sm-3">
                        <button id="BtnSaveAll" type="button" class="btn btn-primary btn-block">
                            <br />
                            <i class="fa fa-fw fa-save" aria-hidden="true" style="font-size: 30px; margin-top: 2px;"></i>
                            <p style="margin-top: 2px;">Guardar</p>
                        </button>
                    </div>
                                        <div class="col-sm-4">
                        <div class="row">
                            <div class="col-sm-6" style="font-size:13px">
                                <label>T. Copa Fonasa</label>
                            </div>
                            <div class="col-sm-6" style="font-size:13px">
                                <label>Total Particular</label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                                <input type="text" id="Lbl_tot_copa_fonasa" style="font-weight:700" class="form-control" disabled="disabled"/>
                            </div>
                            <div class="col-sm-6">
                                <input type="text" id="Lbl_tot_copa_particular" style="font-weight:700" class="form-control" disabled="disabled"/>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-4" style="font-size:13px">
                                <label>T. Fonasa/Particular</label>
                            </div>
                            <div class="col-sm-4" style="font-size:13px">
                                <label>Seguro Complementario</label>
                            </div>
                            <div class="col-sm-4" style="font-size:13px">
                                <label>Total a Pagar</label>
                            </div>
                        </div>
                        <div class="row">
                            <div  class="col-sm-4">
                                <input type="text" id="Lbl_tot_prevision" style="font-weight:700" class="form-control" disabled="disabled"/>
                            </div>
                            <div class="col-sm-4">
                                <input type="text" id="Lbl_tot_beneficiario" style="font-weight:700" class="form-control" onkeydown="return jsDecimals(event)"/>
                            </div>
                            <div class="col-sm-4">
                                <input type="text" id="Lbl_tot_a_pagar" style="font-weight:900; border:solid" class="form-control" disabled="disabled"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
