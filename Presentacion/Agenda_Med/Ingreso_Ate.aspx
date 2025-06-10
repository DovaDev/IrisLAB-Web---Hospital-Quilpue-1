<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Ingreso_Ate.aspx.vb" Inherits="Presentacion.Ingreso_Ate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
        <script src="../js/Deep-Copy.js"></script>
        <script type="module" src="Ingreso_Ate.js?<%= DateAndTime.Now.ToString() %>"></script>
        <%--<script src="js/Deep-Copy.js"></script>--%>
        <%-- Colocar esto para forzar el evento load --%>
        <%@ OutputCache Location="None" NoStore="true" %>
        <style>
            .input-error {
                border: 2px solid red;
                background-color: #ffe6e6;
            }


    .negrita {
    font-weight:700;
    }
    .alertas {
        margin-top: 180px;
        text-align: center;
    }
    .manitos2 {
        cursor: pointer;
    }
    .textoReducido {
        font-size: 11px;
    }
    .ancho-columna {
        height: 10%;
        padding: -35px;
    }
    .highlights {
        width: 100%;
        height: 300px; /* Ancho y alto fijo */
        overflow: auto; /* Se oculta el contenido desbordado */
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
        z-index: 100;
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
    /*CHECKBOX DE FELIPE*/
    .div-chk-cont {
        display: flex;
        display: -webkit-flex;
        flex-flow: row wrap;

        justify-content: space-between;
        align-items: center;
    }
    .div-chk-cont > * {
        height: 12px;
        margin-bottom: 0.3rem;
    }
    input[type=checkbox] ~ .div-chk {
        -webkit-user-select: none;
        -moz-user-select: none;
        -ms-user-select: none;
        user-select: none;
        display: inline;
        min-height: 23.5px;
    }
    input[type=checkbox] ~ .div-chk i {
        font-size: 15px;
        color: #46963f;
    }
    input[type=checkbox] ~ .div-chk span {
        font-size: 10px;
    }
    
    input[type=checkbox] ~ .div-chk i:nth-child(1) {
        display: inline-block;
    }

    input[type=checkbox] ~ .div-chk i:nth-child(2) {
        display: none;
    }

    input[type=checkbox]:checked ~ .div-chk i:nth-child(1) {
        display: none;
    }

    input[type=checkbox]:checked ~ .div-chk i:nth-child(2) {
        display: inline-block;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
       <%--        <!-- modal Datos Extras -->
    <div id="modal_Datos_extras" class="modal fade" role="dialog">
        <div class="modal-dialog ml-xl-auto">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Datos Adicionales</h4>
                </div>
                <div class="modal-body">
                    <div id="rowDigoxina" class="row" style="padding-right: 5px; padding-left: 2px;">
                        <div class="col-md-4">
                            <label style="padding-left: 0px !important; font-weight:800">Digoxina: </label>
                        </div>                   
                        <div class="col-md-4">
                            <label class="textoReducido" style="padding-left: 0px !important;"> Dosis en mg:</label>
                            <input type='text' id="txtDosisDigoxina" class="form-control textoReducido"/>              
                        </div>
                        <div class="col-md-4">
                            <label class="textoReducido" style="padding-left: 0px !important;"> Hora de Dosis:</label>
                            <input type='text' id="txtHoraDigoxina" class="form-control textoReducido"/>  
                        </div>
                    </div>
                    <div id="rowTeofilina" class="row" style="padding-right: 5px; padding-left: 5px;">
                        <div class="col-md-4">
                            <label style="padding-left: 0px !important; font-weight:800">Teofilina: </label>
                        </div>  
                        <div class="col-md-4">
                            <label class="textoReducido" style="padding-left: 0px !important;"> Dosis en mg:</label>
                            <input type='text' id="txtDosisTeofilina" class="form-control textoReducido"/>              
                        </div>
                        <div class="col-md-4">
                            <label class="textoReducido" style="padding-left: 0px !important;"> Hora de Dosis:</label>
                            <input type='text' id="txtHoraTeofilina" class="form-control textoReducido"/>  
                        </div>
                    </div>
                    <div id="rowAminofilina" class="row" style="padding-right: 5px; padding-left: 5px;">
                        <div class="col-md-4">
                            <label style="padding-left: 0px !important; font-weight:800">Aminofilina: </label>
                        </div> 
                        <div class="col-md-4">
                            <label class="textoReducido" style="padding-left: 0px !important;"> Dosis en mg:</label>
                            <input type='text' id="txtDosisAminofilina" class="form-control textoReducido"/>              
                        </div>
                        <div class="col-md-4">
                            <label class="textoReducido" style="padding-left: 0px !important;"> Hora de Dosis:</label>
                            <input type='text' id="txtHoraAminofilina" class="form-control textoReducido"/>  
                        </div>
                    </div>
                    <div id="rowPrimidona" class="row" style="padding-right: 5px; padding-left: 5px;">
                        <div class="col-md-4">
                            <label style="padding-left: 0px !important; font-weight:800">Primidona: </label>
                        </div> 
                        <div class="col-md-4">
                            <label class="textoReducido" style="padding-left: 0px !important;"> Dosis en mg:</label>
                            <input type='text' id="txtDosisPrimidona" class="form-control textoReducido"/>              
                        </div>
                        <div class="col-md-4">
                            <label class="textoReducido" style="padding-left: 0px !important;"> Hora de Dosis:</label>
                            <input type='text' id="txtHoraPrimidona" class="form-control textoReducido"/>  
                        </div>
                    </div>
                    <div id="rowTeofilinaBK" class="row" style="padding-right: 5px; padding-left: 5px;">
                        <div class="col-md-4">
                            <label style="padding-left: 0px !important; font-weight:800">Teofilina BK: </label>
                        </div> 
                        <div class="col-md-4">
                            <label class="textoReducido" style="padding-left: 0px !important;"> Dosis en mg:</label>
                            <input type='text' id="txtDosisTeofilinaBK" class="form-control textoReducido"/>              
                        </div>
                        <div class="col-md-4">
                            <label class="textoReducido" style="padding-left: 0px !important;"> Hora de Dosis:</label>
                            <input type='text' id="txtHoraTeofilinaBK" class="form-control textoReducido"/>  
                        </div>
                    </div>
                    <div id="rowTiempo_De_Protrombina" class="row" style="padding-right: 5px; padding-left: 5px;">
                        <div class="col-md-4">
                            <label style="padding-left: 0px !important; font-weight:800">Tiempo de Protrombina: </label>
                        </div>
                        <div class="col-md-4"></div> 
                        <div class="col-md-4">
                            <label class="textoReducido" style="padding-left: 0px !important;"> Paciente con Taco:</label>
                            <input type='text' id="txtDosisTiempo_De_Protrombina" class="form-control textoReducido"/>              
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                    <button type="button" id="button_modal_Datos_extras" class="btn btn-success" data-dismiss="modal">Guardar</button>
                </div>
            </div>
        </div>
    </div>--%>
    	<!-- Modal -->
        <div id="mdl_Doc" class="modal fade" role="dialog">
	        <div class="modal-dialog modal-lg">

		        <!-- Modal content-->
		        <div class="modal-content">
			        <div class="modal-header">
				
				        <h4 class="modal-title">Seleccione un Médico</h4>
				        <button type="button" id="btn_close_med" class="btn btn-danger"><i class="fa fa-times"></i></button>
			        </div>
			        <div class="modal-body">
				        <div class="row" style="max-height: 70vh; overflow: auto">
					        <div class="col-lg-12">
						        <table id="dtt_Doc" style="width: 100%; border-collapse: collapse;" class="table table-hover table-striped table-iris dataTable no-footer" role="grid" cellspacing="0">
							        <thead>
								        <tr>
									        <th>RUT Médico</th>
									        <th>Nombre Médico</th>
									        <th class="text-center">Seleccionar</th>
								        </tr>
							        </thead>
							        <tbody>
							        </tbody>
						        </table>
					        </div>
				        </div>
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
                    <button type="button" id="button_modal_pago" class="btn btn-success" data-dismiss="modal">Imprimir</button>
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
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 id="title" class="modal-title">Error</h4>
                </div>
                <div class="modal-body">
                    <p></p>
                </div>
                <div class="modal-footer">
                    <button type="button" id="button_modal" class="btn btn-danger" data-dismiss="modal">
                        <span>Aceptar</span>
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
    <div class="modal fade" id="mdl_Actu_Exa" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header border-bar bg-bar">
                    <h4 class="modal-title">Actualizar Datos Paciente Examed</h4>
                </div>
                <div class="modal-body">
                    <h4>Datos Actuales</h4>
                    <div class="row">
                        <div class="col-md-6">
                           <div class="row">
                               <div class="col-lg-12">
                                   RUT/DNI: <label id="ADE_RUT" class="text-success"></label>
                               </div>
                           </div>
                            <div class="row">
                               <div class="col-lg-12">
                                  Nombre: <label id="ADE_NOM" class="text-success"></label>
                               </div>
                           </div>
                            <div class="row">
                               <div class="col-lg-12">
                                   Sexo: <label id="ADE_SEX" class="text-success"></label>
                               </div>
                           </div>
                            <div class="row">
                               <div class="col-lg-12">
                                   Dirección: <label id="ADE_DIR" class="text-success"></label>
                               </div>
                           </div>
                        </div>
                        <div class="col-md-6">
                           <div class="row">
                               <div class="col-lg-12">
                                    Fecha Nacimiento: <label id="ADE_FNAC" class="text-success"></label>
                               </div>
                           </div>
                            <div class="row">
                               <div class="col-lg-12">
                                   Apellido: <label id="ADE_APE" class="text-success"></label>
                               </div>
                           </div>
                            <div class="row">
                               <div class="col-lg-12">
                                   Teléfono: <label id="ADE_FONO" class="text-success"></label>
                               </div>
                           </div>
                            <div class="row">
                               <div class="col-lg-12">
                                   Correo: <label id="ADE_CORR" class="text-success"></label>
                               </div>
                           </div>
                        </div>
                    </div>
                    <hr />
                    <h4>Datos Nuevos</h4>
                    <div class="row">
                        <div class="col-md-6">
                           <div class="row">
                               <div class="col-lg-12">
                                   RUT/DNI: <label id="NDE_RUT" class="text-primary"></label>
                               </div>
                           </div>
                            <div class="row">
                               <div class="col-lg-12">
                                  Nombre: <label id="NDE_NOM" class="text-primary"></label>
                               </div>
                           </div>
                            <div class="row">
                               <div class="col-lg-12">
                                   Sexo: <label id="NDE_SEX" class="text-primary"></label>
                               </div>
                           </div>
                            <div class="row">
                               <div class="col-lg-12">
                                   Dirección: <label id="NDE_DIR" class="text-primary"></label>
                               </div>
                           </div>
                        </div>
                        <div class="col-md-6">
                           <div class="row">
                               <div class="col-lg-12">
                                    Fecha Nacimiento: <label id="NDE_FNAC" class="text-primary"></label>
                               </div>
                           </div>
                            <div class="row">
                               <div class="col-lg-12">
                                   Apellido: <label id="NDE_APE" class="text-primary"></label>
                               </div>
                           </div>
                            <div class="row">
                               <div class="col-lg-12">
                                   Teléfono: <label id="NDE_FONO" class="text-primary"></label>
                               </div>
                           </div>
                            <div class="row">
                               <div class="col-lg-12">
                                   Correo: <label id="NDE_CORR" class="text-primary"></label>
                               </div>
                           </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    <button type="button" id="btn_Actu_Exa_DNI" class="btn btn-success">Actualizar</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Breadcrumbs -->
    <div class="card border-bar">
        <div class="card-header bg-bar p-2">
            <h5 style="text-align: center; padding: 5px;">
                <i class="fa fa-sign-in"></i>
                Ingreso de Atención
            </h5>
        </div>
        <div class="card-body p-3">
            <div class="container" style="max-width: 100%;">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="row">
                        <div class="col-md checkbox checkbox-success">                    
                            <input id="checkBox999" value="rutee" type="checkbox"/> <label class="textoReducido" style="padding-left: 0px !important;" for="checkBox999">RUT</label>
                            <input id="checkBox888" value="DNI" type="checkbox"/><label style="margin-left: 15px; padding-left: 0px !important;" class="textoReducido" for="checkBox888">DNI:</label>
                            <input id="checkBox8887" value="DNI" type="checkbox"/><label style="margin-left: 15px; padding-left: 0px !important;" class="textoReducido" for="checkBox8887">N°Ate:</label>
                            <%--<input id="chk_Examed" type="checkbox"/><label style="margin-left: 15px; padding-left: 0px !important;" class="textoReducido" for="chk_Examed">Exa:</label>--%>
                            <input type='text' id="rut" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="12.345.789-0" />
                            <input type='text' id="dni" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="D.N.I" />
                            <%--<input type='text' id="examed" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="Examed" />--%>
                            <input type='text' id="Naten" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="N° Atención" />
                                 
                        </div>
                            <div class="col-lg">
                                <label class="textoReducido">RUT/DNI:</label>
                                <input type='text' id="txtrut" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="" disabled="disabled"/>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Nombres:</label>
                                <input type='text' id="Nom" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Apellidos:</label>
                                <input type='text' id="Ape" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="" />
                            </div>
                             <div class="col-lg">
                                 <label class="textoReducido">Nombre Social:</label>
                                 <input type='text' id="txtNombreSocial" class="form-control textoReducido negrita" style="height: 31.75px;" placeholder="" />
                             </div>
                            <%--     </div>
                        <div class="row">--%>
                            <div class="col-lg">
                                <label class="textoReducido">F.Nacimiento:</label>
                                <label class="textoReducido" for="chk_neo">Neo:</label>
                                <input type="checkbox" id="chk_neo" />
                                 <div class='input-group date' id='datetimepicker1' style="margin-bottom: 1vh;">
                                    <input type="date" min="0001-01-01"  id="fecha" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="Fecha"/>
                                </div>
                               <%-- <div class='input-group date' id='datetimepicker1' style="margin-bottom: 1vh;">
                                    <input type="datetime-local" min="1900-01-01T00:00" id="fecha" class="form-control textoReducido negrita" style="font-size: 14px;" placeholder="Fecha" max="" />
                                </div>--%>
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
                                <input type='text' id="Edad" class="form-control textoReducido negrita" style="font-size:14px; text-align:center" readonly="true" placeholder="" disabled="disabled"/>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Sexo:</label>
                                <select id="sex" class="form-control textoReducido negrita" style="font-size:14px;">
                                </select>
                            </div>

                            <div class="col-lg">
                                <label class="textoReducido">Genero:</label>
                                <select id="Genero" class="form-control textoReducido negrita" style="font-size: 14px;">
                                </select>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg checkbox checkbox-success">
                                <input id="checkBox2" type="checkbox" value="SoyFur" />
                                <label for="checkBox2" class="textoReducido">F.U.R:</label>
                                <div class='input-group date' id='datetimepicker3' style="margin-bottom: 1vh;">
                                    <input type='text' id="FUR" class="form-control textoReducido negrita" style="font-size:14px;"" readonly="true" placeholder="Fecha" />
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
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Nacionalidad:</label>
                                <select id="Nacio" class="form-control textoReducido negrita" style="font-size:14px;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Fono 1:</label>
                                <input type='text' id="Celular" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Fono 2:</label>
                                <input type='text' id="telfijo" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Dirección:</label>
                                <input type='text' id="direccion" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="" />
                            </div>

                            <div class="col-lg">
                                <label class="textoReducido">Región:</label>
                                <select id="Cuidad" class="form-control textoReducido negrita" style="font-size:14px;">
                                    <option value="0">Seleccionar</option>
                                </select>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Comuna:</label>
                                <select id="Comuna" class="form-control textoReducido negrita" style="font-size:14px;">
                                    <option value="0">Seleccionar</option>
                                </select>
                            </div>
                        </div>
                        <div>
                            <div class="row" style="margin-bottom: 10px;">
                                <div class="col-lg">
                                    <label class="textoReducido">Email:</label>
                                    <input type='text' id="Email" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="Irislab@irislab.cl" />
                                </div>
<%--                                <div class="col-lg">
                                    <label class="textoReducido">Nº Interno:</label>
                                    <input type='text' id="Interno" class="form-control textoReducido" placeholder="" />
                                </div>--%>
                                <div class="col-lg-5">
                                    <label class="textoReducido">Observaciones permanentes del paciente:</label>
                                    <input type='text' id="obdser" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="" />
                                </div>
                                <div class="col-lg">
                                    <label class="textoReducido">Diagnostico N° 1</label>
                                    <select id="DdlDiagnostico" class="form-control textoReducido negrita" style="font-size:14px;">
                                        <option value="0">Seleccionar</option>
                                    </select>
                                </div>
                               <div class="col-lg">
                                    <label class="textoReducido">Diagnostico N° 2</label>
                                    <select id="DdlDiagnostico2" class="form-control textoReducido negrita" style="font-size:14px;">
                                        <option value="0">Seleccionar</option>
                                    </select>
                                </div>
                                <div class="col-lg">
                                    <label class="textoReducido">Pueblos originarios: </label>
                                    <select id="ddlEtnia" class="form-control textoReducido negrita">
                                        <option value="0">Seleccionar</option>
                                    </select>
                                </div>

                               


                            </div>
                        </div>

                    </div>
                </div>
            </div>
            <hr />
            <h5 style="text-align: center; padding: 5px;">Antecedentes de la Atención  </h5>
            <div class="container" style="max-width: 100%;">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="row">
                            <div class="col-lg">
                                <div class="div-chk-cont">
                                    <label class="textoReducido">Procedencia:</label>
                                    <input name="chkMant" class="m-0 negrita" style="font-size:14px; display:none;" id="chkMant_0" value="0" type="checkbox" />
                                    <label class="div-chk" for="chkMant_0">
                                        <i class="fa fa-square"></i>
                                        <i class="fa fa-check-square"></i>
                                        <span>Mantener</span>
                                    </label>
                                </div>
                                <select id="Procedencia" class="form-control textoReducido negrita" style="font-size:14px;">
                                    <option value="0">Seleccionar</option>
                                </select>
                            </div>
                            <div class="col-sm">
                                <div class="div-chk-cont">
                                    <label class="textoReducido">Previsión:</label>
                                    <input name="chkMant" class="m-0 negrita" style="font-size:14px; display:none" id="chkMant_3" value="3" type="checkbox" />
                                    <label class="div-chk" for="chkMant_3">
                                        <i class="fa fa-square"></i>
                                        <i class="fa fa-check-square"></i>
                                        <span>Mantener</span>
                                    </label>
                                </div>
                                <select id="Prevision" class="form-control textoReducido negrita" style="font-size:14px;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>
                            <%--<div class="col-lg">
                                <label class="textoReducido">Doctor:</label>
                                <select id="Doctor" class="form-control textoReducido negrita" style="font-size:14px;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>--%>

                            <div class="col-lg">
                                <label class="textoReducido">Rut Profesional:</label>
                                <input id="RUT_Doctor" class="form-control textoReducido negrita" style="font-size: 14px;" placeholder="12.345.789-0" data-toggle="tooltip" data-placement="top" title="Deje el campo vacío y presione Enter para limpiar" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Nombre Profesional:</label>
                                <input id="Doctor" class="form-control textoReducido negrita" style="font-size: 14px;" data-id="0" data-toggle="tooltip" data-placement="top" title="Para buscar presione Enter" />
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">G.P. VIH</label>
                                <select id="slctGrupoPesquisaVIH" class="form-control textoReducido negrita" style="height: 31.75px;">
                                    <option value="0">No Aplica</option>
                                </select>
                            </div>

                            <div class="col-lg">
                                <label class="textoReducido">G.P. R.P.R/Chagas</label>
                                <select id="slctGrupoPesquisaRPRChagas" class="form-control textoReducido negrita" style="height: 31.75px;">
                                    <option value="0">No Aplica</option>
                                </select>
                            </div>
                            <div class="col-lg">
                                <label class="textoReducido">Tipo de Atención:</label>
                                <select id="TipoAtencion" class="form-control textoReducido negrita" style="font-size: 14px;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>
                            <%--                     <div class="col-sm">
                            <label class="textoReducido">Cupo Normal:</label>
                            <input type='text' id="Total" class="form-control textoReducido" readonly="true" placeholder="" disabled="disabled" style="background-color: yellow; text-align: center;" />
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Prioritario:</label>
                            <input type='text' id="Actuales" class="form-control textoReducido" readonly="true" placeholder="" disabled="disabled" style="background-color: #f4abe7; text-align: center;" />
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Espontáneo:</label>
                            <input type='text' id="Disponibles" class="form-control textoReducido" readonly="true" placeholder="" disabled="disabled" style="background-color: chartreuse; text-align: center;" />
                        </div>
                        <div class="col-sm">
                            <label class="textoReducido">Sub-Atención:</label>
                            <select id="sub_atencion" class="form-control textoReducido" style="height: 31.75px;">
                                <option value="0">Seleccionar</option>
                                <option value="1">Agendado Cupo normal</option>
                                <option value="2">Agendado Prioritario</option>
                                <option value="3">Agendado Espontáneo</option>
                                
                            </select>
                        </div>--%>
                            <div class="col-lg" hidden>
                                <div class="div-chk-cont">
                                    <label class="textoReducido">Programa:</label>
                                    <input name="chkMant" class="m-0 negrita" style="font-size:14px; display:none" id="chkMant_1" value="1" checked="checked" type="checkbox" />
                                    <label class="div-chk" for="chkMant_1">
                                        <i class="fa fa-square"></i>
                                        <i class="fa fa-check-square"></i>
                                        <span>Mantener</span>
                                    </label>
                                </div>
                                <select id="Programa" class="form-control textoReducido negrita" style="font-size:14px;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>
                            <div class="col-lg" hidden>
                                <div class="div-chk-cont">
                                    <label class="textoReducido">Sub Programa:</label>
                                    <input name="chkMant" class="m-0 negrita" style="font-size:14px; display:none;" id="chkMant_2" value="2" checked="checked" type="checkbox" />
                                    <label class="div-chk" for="chkMant_2">
                                        <i class="fa fa-square"></i>
                                        <i class="fa fa-check-square"></i>
                                        <span>Mantener</span>
                                    </label>
                                </div>
                                <select id="Ddl_Prog02" class="form-control textoReducido negrita" style="font-size:14px;">
                                    <option value="1">Seleccionar</option>
                                </select>
                            </div>
                            <div class="col-lg" hidden="">
                                <label class="textoReducido">Sector:</label>
                                <select id="Sector" class="form-control textoReducido negrita" style="font-size:14px;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>
                            <div class="col-lg" hidden>
                                <div class="div-chk-cont">
                                <label class="textoReducido">Empresa:</label>
                                <input name="chkMant" class="m-0 negrita" style="font-size:14px; display:none;" id="chkMant_4" value="2" checked="checked" type="checkbox" />
                                <label class="div-chk" for="chkMant_4">
                                    <i class="fa fa-square"></i>
                                    <i class="fa fa-check-square"></i>
                                    <span>Mantener</span>
                                </label>
                            </div>
                            <%--<label class="textoReducido">Empresa:</label>--%>
                            <select id="Empresa" class="form-control textoReducido negrita"  style="font-size:14px;">
                                <option value="volvo">Seleccionar</option>
                            </select>
                        </div>
                        </div>
                        <div class="row" style="margin-bottom: 10px;">
                            <div class="col-lg">
                                <label class="textoReducido">Localizacion:</label>
                                <select id="Localizacion" class="form-control textoReducido negrita" style="font-size:14px;"disabled="disabled">
                                    <option value="volvo">TOMA DE MUESTRA</option>
                                </select>
                            </div>
                            <div class="col-lg-1" hidden>
                                <label class="textoReducido">Cama:</label>
                                <input type='text' id="cama" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="0" disabled="disabled" value="0" />
                            </div>
                     <%-- <div class="col-sm">
                            <label class="textoReducido">V.I.H:</label>
                            <input type='text' id="vih" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="" text-align: center;" />
                        </div>--%>
                            <div class="col-lg">
                                <label class="textoReducido">Observacion de ingreso de paciente:</label>
                                <input type='text' id="obs_ate" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="" />
                            </div>
                            <%--<div class="col-lg">
                                <label class="textoReducido">Autorizo a Retirar:</label>
                                <input type='text' id="Autorizo_retirar" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="" />
                            </div>--%>
                            <div class="col-lg">
                                <label class="textoReducido">Prioridad TM:</label>
                                <select id="PrioridadTM" class="form-control textoReducido negrita" style="font-size:14px;">
                                    <option value="volvo">Seleccionar</option>
                                </select>
                            </div>
                             <div class="col-lg" hidden>
                                <label class="textoReducido">Epivigila:</label>
                                <input type='text' id="txt_Epivigila" class="form-control textoReducido negrita" style="font-size:14px;" placeholder="" />
                            </div>
                            <div class="col-lg" hidden>
                                <label class="textoReducido">Búsqueda Activa:</label><br />
                                <input id="chk_Busq_A" type="checkbox" checked="checked"/> <label class="textoReducido" style="padding-left: 0px !important;" for="chk_Busq_A">Con Búsqueda Activa</label>
                            </div>
                          <%--<div class="col-sm">
                                <label class="textoReducido">N° Orden Clínica</label>
                                     <input type='text' id="NumeroClinico" class="form-control textoReducido negrita" style="font-size:14px;text-align:center;" placeholder=""/>
                            </div>--%>


                            <%--   </div>
                         <div class="row">--%>
                            
                        </div>
                    </div>
                </div>
            </div>
            <hr />
            <h5 style="text-align: center; padding: 5px;">Agregar Exámenes </h5>
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
                <div id="totalContainer" style="display: none;">
                    Total a Pagar: $ <span id="totalValue">0</span>
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
                   <%-- <div class="col-sm-1">
                        <button id="btnInstructivos" type="button" class="btn btn-limpiar btn-block">
                            <br />
                            <%--<i class="fa fa-align-left" aria-hidden="true" style="font-size: 30px;"></i>
                            <p style="margin-top: 2px; font-size:13px">Indicaciones</p>
                            <p style="margin-top: 0px; font-size:13px">Exámenes</p>
                        </button>
                    </div>--%>
                    <div class="col-sm-2">
                    </div>
                    <div class="col-sm-3" style="justify-content: flex-end;">
                        <button id="Btnnew" type="button" class="btn btn-info btn-block">
                            <br />
                            <i class="fa fa-plus-square" aria-hidden="true" style="font-size: 30px; margin-top: 2px;"></i>
                            <p style="margin-top: 2px;">Nuevo</p>
                        </button>
                    </div>
                    <div class="col-sm-3">
                        <button id="BtnSaveAll" type="button" class="btn btn-primary btn-block">
                            <br />
                            <i class="fa fa-fw fa-save" aria-hidden="true" style="font-size: 30px; margin-top: 2px;"></i>
                            <p style="margin-top: 2px;">Guardar</p>
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>

            <!-- Modal -->
    <div id="mdl_Determinaciones_Glucosa" class="modal fade" role="dialog">
        <div class="modal-dialog modal-lg">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">                    
                    <h4 class="modal-title">Seleccionar Determinaciones Glucosa</h4>
                </div>
                <div class="modal-body">
                    <form>
                        <div class="col-md-12">
                            <div id="Div_TablaDeterminaciones" style="width: 100%;" class="highlights2"></div>
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" id="button_carga_determinaciones" class="btn btn-success">Agregar</button>
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
