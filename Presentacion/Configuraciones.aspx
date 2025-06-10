<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Configuraciones.aspx.vb" Inherits="Presentacion.Configuraciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script>
        $(function () {
            $('.list-group-item').on('click', function () {
                $('.fa-chng', this)
                  .toggleClass('fa-chevron-right')
                  .toggleClass('fa-chevron-down');
            });
        });
    </script>
   <style>
        @media screen and (min-width:992px) {
            .xmb-3 {
                margin-bottom: 1rem !important;
            }
        }

        .fa-minus, .fa-chevron-right, .fa-chevron-down {
            margin-right: .25rem;
        }

        .card > .list-group:first-child .list-group-item:first-child {
            border-top-left-radius: 0;
            border-top-right-radius: 0;
        }

        .ttl {
            background-color: #00738e !important;
            color: white;
            border-top-right-radius: .25rem !important;
            border-top-left-radius: .25rem !important;
        }

        .subb > a:hover {
            background-color: #11819b;
            color: white;
        }

        .minn > a:hover, .minn0 > a:hover {
            background-color: #d1edf0;
            color: black;
        }

        .fa-minus {
            font-size: 12px;
        }

        .fa-chng {
            font-size: 14px;
        }

        .ttl:hover {
            color: white;
        }

        .subb > a {
            padding-left: 2em;
            background-color: #1d96b2;
            color: white;
        }

        .minn0 > a {
            padding-left: 2em;
            color: #212529;
        }

        .minn > a {
            padding-left: 3.5em;
            color: #212529;
        }


        .list-group.list-group-root {
            padding: 0;
            overflow: hidden;
        }

            .list-group.list-group-root .list-group {
                margin-bottom: 0;
            }

            .list-group.list-group-root .list-group-item {
                border-radius: 0;
                border-width: 1px 0 0 0;
            }

            .list-group.list-group-root > .list-group-item:first-child {
                border-top-width: 0;
            }

            .list-group.list-group-root > .list-group > .list-group-item {
                padding-left: 30px;
            }

            .list-group.list-group-root > .list-group > .list-group > .list-group-item {
                padding-left: 45px;
            }

        .list-group-item .glyphicon {
            margin-right: 5px;
        }



        .list-group.list-group-root .list-group-item {
            border-width: 1px 1px 1px 1px;
            border-color: #00738e !important;
        }
        /*//////////////////*/
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="card border-bar">
        <div class="card-header bg-bar">
            <h4 class="text-center m-0"><i class="fa fa-cog fa-fw"></i>Configuraciones</h4>
        </div>
        <div class="card-body">
            <div class="row xmb-3">
                <div class="col-lg mb-1">
                    <div class="card ">
                        <div class="list-group list-group-root well">
                            <h5 class="m-0">
                                <a href="#item-2" class="list-group-item ttl" data-toggle="collapse" style="background-color: #cf3d4c !important">
                                    <i class="fa fa-fw fa-chng fa-chevron-right"></i>Código Fonasa
                                </a></h5>
                            <div class="collapse paddd minn0" id="item-2">
                                <a href="/Configuraciones/Codigo_Fonasa/Codigos_Fonasa.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Código Fonasa</a>
                                <%--<a href="#" class="list-group-item">
                            <i class="fa fa-fw fa-minus"></i>Relación Analizador-Fonasa</a>--%>
                            </div>

                        </div>

                    </div>

                </div>
                <div class="col-lg mb-1">
                    <div class="card ">
                        <div class="list-group list-group-root well">
                            <h5 class="m-0">
                                <a href="#item-1" class="list-group-item ttl" data-toggle="collapse" style="background-color: #923b6c !important">
                                    <i class="fa fa-fw fa-chng fa-chevron-right"></i>Exámenes
                                </a></h5>
                            <div class="collapse paddd subb" id="item-1">

                                <a href="#item-1-1" class="list-group-item" data-toggle="collapse">
                                    <i class="fa fa-fw fa-chng fa-chevron-right"></i>Estudios
                                </a>
                                    <div class="collapse  paxxx" id="item-1-1">
                                    <%--  <a href="#" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Item 1.1.1</a>
                            <a href="#" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Item 1.1.2</a>
                            <a href="#" class="list-group-item">
                                <i class="fa fa-fw fa-minus"></i>Item 1.1.3</a>--%>
                                    <a href="/Configuraciones/Estudios/Estudio_Crea_Modifica.aspx" class="list-group-item">
                                        <i class="fa fa-fw fa-minus"></i>Crear / Modificar / Estudios</a>
                                </div>

                                <a href="#item-1-2" class="list-group-item" data-toggle="collapse">
                                    <i class="fa fa-fw fa-chng fa-chevron-right"></i>Determinaciones
                                </a>
                                <div class="collapse  paxxx minn" id="item-1-2">
                                    <a href="/Configuraciones/Determinaciones/Unidades_Medida.aspx" class="list-group-item">
                                        <i class="fa fa-fw fa-minus"></i>Unidades de Medida</a>
                                    <a href="/Configuraciones/Determinaciones/T_Recipiente.aspx" class="list-group-item">
                                        <i class="fa fa-fw fa-minus"></i>Tipo de Recipientes</a>
                                    <a href="/Configuraciones/Determinaciones/T_Resultado.aspx" class="list-group-item">
                                        <i class="fa fa-fw fa-minus"></i>Tipo de Resultado</a>
                                    <a href="/Configuraciones/Determinaciones/Resultados_Codificados.aspx" class="list-group-item">
                                        <i class="fa fa-fw fa-minus"></i>Result. Codificados</a>
                                </div>
                            </div>

                        </div>
                    </div>

                </div>
                <div class="col-lg mb-1">
                    <div class="card ">
                        <div class="list-group list-group-root well">
                            <h5 class="m-0">
                                <a href="#item-3" class="list-group-item ttl" data-toggle="collapse" style="background-color: #5e3d8f !important">
                                    <i class="fa fa-fw fa-chng fa-chevron-right"></i>Laboratorio
                                </a></h5>
                            <div class="collapse paddd minn0" id="item-3">

                                <a href="/Configuraciones/Laboratorio/Agrupacion_Exa.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Agrupación de Exámenes</a>
                                <a href="/Configuraciones/Laboratorio/Area_Trabajo.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Area de Trabajo</a>
                                <a href="/Configuraciones/Laboratorio/Lugar_TM.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Lugar de Toma de Muestra</a>
                                <a href="/Configuraciones/Laboratorio/T_Atencion.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Tipo de Atención</a>
                                <a href="/Configuraciones/Laboratorio/T_Rechazo.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Tipo de Rechazo</a>
                                <a href="/Configuraciones/Laboratorio/Orden_Ate.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Orden de Atención</a>
                                <a href="/Configuraciones/Laboratorio/Seccion_Trabajo.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus"></i>Sección de Trabajo</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg mb-1">
                    <div class="card ">
                        <div class="list-group list-group-root well">
                            <h5 class="m-0">
                                <a href="#item-4" class="list-group-item ttl" data-toggle="collapse" style="background-color: #155ac2 !important">
                                    <i class="fa fa-fw fa-chng fa-chevron-right"></i>Previsión
                                </a></h5>
                            <div class="collapse paddd minn0" id="item-4">
                                <a href="/Configuraciones/Prevision/Asoc_Pre_Pre.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Asociar Precios - Previsión</a>
                                <a href="/Configuraciones/Prevision/Copiar_Val_Prevision.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Copiar Precios - Previsión</a>
                                <a href="/Configuraciones/Prevision/Asoc_Pre_Pre_2.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Asociar Precios - Previsión-Bonificación</a>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
            <div class="row xmb-3">
                <div class="col-lg mb-1">
                    <div class="card ">
                        <div class="list-group list-group-root well">
                            <h5 class="m-0">
                                <a href="#item-5" class="list-group-item ttl" data-toggle="collapse" style="background-color: #923b6c !important">
                                    <i class="fa fa-fw fa-chng fa-chevron-right"></i>Pacientes
                                </a></h5>
                            <div class="collapse paddd" id="item-5">
                                <a href="/Configuraciones/Pacientes/Crear_Edit_Pac.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Crear/Editar Paciente</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg mb-1">
                    <div class="card ">
                        <div class="list-group list-group-root well">
                            <h5 class="m-0">
                                <a href="#item-6" class="list-group-item ttl" data-toggle="collapse" style="background-color: #5e3d8f !important">
                                    <i class="fa fa-fw fa-chng fa-chevron-right"></i>Médicos
                                </a></h5>

                            <div class="collapse paddd minn0" id="item-6">
                                <a href="/Configuraciones/Medicos/Crea_Edita_Med.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Crea/Modifica Médico</a>
                                <a href="/Configuraciones/Medicos/Especialidades_Medicas.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Especialidades Médicas</a>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg mb-1">
                    <div class="card ">
                        <div class="list-group list-group-root well">
                            <h5 class="m-0">
                                <a href="#item-7" class="list-group-item ttl" data-toggle="collapse" style="background-color: #155ac2  !important">
                                    <i class="fa fa-fw fa-chng fa-chevron-right"></i>Usuarios
                                </a></h5>
                            <div class="collapse paddd minn0" id="item-7">
                                <a href="/Account/Conf_User.aspx" class="list-group-item">
                                <%--<a href="/Account/Perm_Usu.aspx" class="list-group-item">--%>
                                    <i class="fa fa-fw fa-minus "></i>Crear / Modificar Usuario</a>
                                <a href="/Configuraciones/Usuarios/Cargo.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Cargos</a>
                                <a href="/Configuraciones/Usuarios/Permiso_Usuario.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Permisos de Usuarios</a>
                                <a href="/Configuraciones/Usuarios/Profesiones_Usuarios.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Profesiones de Usuarios</a>
                                <a href="/Configuraciones/Usuarios/Crear_Edit_Usu_Convenio.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Crear / Modificar Usuario Convenio</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg mb-1">
                    <div class="card ">
                        <div class="list-group list-group-root well">
                            <h5 class="m-0">
                                <a href="#item-8" class="list-group-item ttl" data-toggle="collapse" style="background-color: #cf3d4c  !important">
                                    <i class="fa fa-fw fa-chng fa-chevron-right"></i>Mantenedores
                                </a></h5>
                            <div class="collapse paddd minn0" id="item-8">
                                <a href="/Configuraciones/Mantenedores/Bancos.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Bancos</a>
                                <a href="/Configuraciones/Mantenedores/Ciudad.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Ciudad</a>
                                <a href="/Configuraciones/Mantenedores/Comunas.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Comunas</a>
                                <a href="/Configuraciones/Mantenedores/Documentos_Ver.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Documentos</a>
                                <a href="/Configuraciones/Mantenedores/Documentos.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Documentos Administrador</a>
                                <a href="/Configuraciones/Mantenedores/Metod_Anali.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Método Analítico</a>
                                <a href="/Configuraciones/Mantenedores/Indica_Medicas.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Indicaciones Médicas</a>
                                <a href="/Configuraciones/Mantenedores/Nacionalidad.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Nacionalidad</a>
                                <a href="/Configuraciones/Mantenedores/Tipo_Muestra.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Tipo de Muestra</a>
                                <a href="/Configuraciones/Mantenedores/Sector.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Sector</a>
                                <a href="/Configuraciones/Mantenedores/Lugar_TM_2.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Lugar TM</a>
                                <a href="/Configuraciones/Mantenedores/M_Prevision.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Previsión</a>
                                <a href="/Configuraciones/Mantenedores/Programa.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Programa</a>
                                <a href="/Configuraciones/Mantenedores/M_Sub_Programa.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Sub-Programa</a>
                                <a href="/Configuraciones/Mantenedores/Rel_Prev_Prog_SubProg.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Relación Previsión-Programa-SubPrograma</a>
                                <a href="/Configuraciones/Mantenedores/Rela_Pack_Cf.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Relación Pack-Codigo Fonasa</a>
                                <a href="/Configuraciones/Mantenedores/TipoAtencion.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Tipo de Atenciónes</a>
                                <a href="/Configuraciones/Mantenedores/Diagnostico.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Diagnóstico</a>
                                <a href="/Configuraciones/Mantenedores/TipoMuestraSangre.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Tipo de Muestra Sangre</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row ">
                <div class="col-lg mb-1">
                    <div class="card">
                        <div class="list-group list-group-root well">
                            <h5 class="m-0">
                                <a href="#item-10" class="list-group-item ttl" data-toggle="collapse" style="background-color: #5e3d8f  !important">
                                    <i class="fa fa-fw fa-chng fa-chevron-right"></i>Costos
                                </a></h5>
                            <div class="collapse paddd minn0" id="item-10">
                                <a href="/Configuraciones/Costos/CrModCos.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Crear / Modificar Costos</a>
                                <a href="/Configuraciones/Costos/Asoc_Costo_Exa.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Asociar Costo a Exámen</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg mb-1">
                    <div class="card ">
                        <div class="list-group list-group-root well">
                            <h5 class="m-0">
                                <a href="#item-11" class="list-group-item ttl" data-toggle="collapse" style="background-color: #155ac2   !important">
                                    <i class="fa fa-fw fa-chng fa-chevron-right"></i>Agendamiento
                                </a></h5>
                            <div class="collapse paddd minn0" id="item-11">
                                <a href="/Fecha_Conf/Config_Ate_LM_4.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Configurar Fecha</a>
                            </div>
                        </div>
                    </div>
                </div>
                        <div class="col-lg-3 mb-1">
                    <div class="card ">
                        <div class="list-group list-group-root well">
                            <h5 class="m-0">
                                <a href="#item-12" class="list-group-item ttl" data-toggle="collapse" style="background-color: #cf3d4c   !important">
                                    <i class="fa fa-fw fa-chng fa-chevron-right"></i>Notificaciones
                                </a></h5>
                            <div class="collapse paddd minn0" id="item-12">
                                <a href="/Configuraciones/Notificaciones/Notificaciones.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Crear Notificación</a>
<%--                                <a href="/Configuraciones/Notificaciones/Lista_Notificaciones.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Lista Notificaciones</a>--%>
                                <a href="/Configuraciones/Notificaciones/Edita_Notificaciones.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>Editar Notificaciones</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 mb-1">
                    <div class="card ">
                        <div class="list-group list-group-root well">
                            <h5 class="m-0">
                                <a href="#item-13" class="list-group-item ttl" data-toggle="collapse" style="background-color: #cf3d4c   !important">
                                    <i class="fa fa-fw fa-chng fa-chevron-right"></i>Reportes
                                </a></h5>
                            <div class="collapse paddd minn0" id="item-13">
                                <a href="/Configuraciones/REM/Rem.aspx" class="list-group-item">
                                    <i class="fa fa-fw fa-minus "></i>REM</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>





</asp:Content>
