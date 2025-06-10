<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Index.aspx.vb" Inherits="Presentacion.Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">

    <script type="module">
        const btn_datas = [
                {  //# 01
                    "href": "Agenda_Med/N_Ver_Disponibilidad_3.aspx", "icon": "book",   "textn1": "Agenda",  "textn2": "Médica"
                },
                {   //# 02
                    "href": "Agenda_Med/Lis_Pac_TDM.aspx",   "icon": "list",  "textn1": "Listar", "textn2": "Paciente"
                },
                {   //# 03
                    "href": "#",   "icon": "user",  "textn1": "Ingreso de",    "textn2": "Atención"
                },
                {   //# 04
                    "href": "Ate_Pac/Busca_Paciente.aspx",  "icon": "search", "textn1": "Búsqueda de",  "textn2": "Pacientes"
                },
                {   //# 05
                    "href": "Buscar_Ate/Buscar_Atencion.aspx", "icon": "search",  "textn1": "Búsqueda de",   "textn2": "Atenciones"
                },
                {   //# 06
                    "href": "Toma_Muestra/Adm_TM.aspx",   "icon": "eyedropper",    "textn1": "Toma de",    "textn2": "Muestras"
                },
                {   //# 07
                    "href": "Recep_Mue/Recep_Mue_PENDIENTES_2.aspx",    "icon": "flask",  "textn1": "Recepción de",   "textn2": "Muestras"
                },
                {   //# 08
                    "href": "#",   "icon": "users",    "textn1": "Grupo de",   "textn2": "Trabajo"
                },
                {   //# 09
                    "href": "Imp_Etiquetas/Impr_Etiq.aspx",   "icon": "barcode",  "textn1": "Impresión de",  "textn2": "Etiquetas"
                },
                {   //# 10
                    "href": "/Resultados/Ate_Resultados_3.aspx",   "icon": "area-chart", "textn1": "Visor de", "textn2": "Resultados"
                },
                {   //# 11
                    "href": "/Ate_Pac/Busca_Paciente.aspx",  "icon": "print",  "textn1": "Impresión de", "textn2": "Resultados"
                },
                {   //# 12
                    "href": "/Imp_Etiquetas/Impr_Dcto.aspx",  "icon": "print","textn1": "Reimpresión", "textn2": "Documentos"
                },
                {   //# 13
                    "href": "Repor_check.aspx",  "icon": "area-chart", "textn1": "Reportes","textn2": ""
                },
                {   //# 14
                    "href": "Gest_Financ/Estadisticas/Resumen/Cupo_Tot_ate.aspx",  "icon": "area-chart", "textn1": "Ver Cupos","textn2": "Agendados"
                },
                {   //# 15
                    "href": "Env_Mues_Lab/Env_Mues_Lab_PENDIENTES_2.aspx",   "icon": "random",  "textn1": "Envío de",  "textn2": "Muestras"
                },
                {   //# 16
                    "href": "Env_Mues_Lab/Lis_Env_Mues_Lab_2.aspx",  "icon": "flask", "textn1": "Muestras Env.", "textn2": "por Tubo"
                },
                {   //# 17
                    "href": "Reporte/Laboratorio/REP_LAB_EXA.aspx",  "icon": "table",  "textn1": "Listado de", "textn2": "Usu. por Examen"
                },
                {   //# 18
                    "href": "Exa_Esp_V.aspx",  "icon": "edit","textn1": "Cambiar Estado",  "textn2": "Examen"
                },
                {   //# 19
                    "href": "Env_Mues_Lab/Lis_Env_Mues_Lab_3.aspx",     "icon": "flask",   "textn1": "Muestras Env.",  "textn2": "por Lote"
                },
                {   //# 20
                    "href": "Recha_Mues/Lis_recha_Mues.aspx",  "icon": "flask",   "textn1": "Listado de",  "textn2": "Exa. Rechazados"
                },
                {   //# 21
                    "href": "Ate_Pac/Busca_Paciente_Agendado.aspx",   "icon": "search",  "textn1": "Bús Pac.",  "textn2": "Agendado"
                },
                {  //# 22
                    "href": "Ate_Pac/AVIS_C_D.aspx", "icon": "book", "textn1": "Número", "textn2": "Avis"
                },
                {  //# 23
                    "href": "Configuraciones/Mantenedores/Documentos_Ver2.aspx", "icon": "list", "textn1": "Biblioteca", "textn2": ""
                },
                {  //# 24
                    "href": "Check_List/Rev_Deter_Exa__Scre_Sif.aspx","icon": "flask", "textn1": "Resul. Deter","textn2": "Screening Sífilis"
                },
                {   //# 25
                    "href": "Recha_Mues/Lis_recha_Mues_2.aspx","icon": "window-close","textn1": "Listado de","textn2": "Tubos Rechazados"
                },
                {   //# 26
                    "href": "Check_List/Check_Point/Chk_Tubo_Proce_2.aspx", "icon": "flask", "textn1": "Estados", "textn2": "de Tubos"
                },
                {   //# 27
                    "href": "Gest_Financ/Estadisticas/Resumen/Cupo_Tot_ate_2.aspx",  "icon": "area-chart",  "textn1": "Ver Cupos",  "textn2": "Agendados"
                },
                {   //# 28
                    "href": "Agenda_Med/Lis_Pac_TDM_2.aspx",  "icon": "list",   "textn1": "Listar Paciente","textn2": "Iris PC"
                },
                {  //# 29
                    "href": "/Excel_TP_Real_adm_2.aspx",  "icon": "list", "textn1": "Trazabilidad PAP",  "textn2": "Administrador"
                },
                {  //# 30
                    "href": "/Excel_TP_Real_2.aspx",   "icon": "list",    "textn1": "Trazabilidad", "textn2": "PAP"
                },
                {  //# 31
                    "href": "/Reg_Residuos_ADM.aspx",   "icon": "trash", "textn1": "Registro",  "textn2": "REAS Admin"
                },
                {  //# 32
                    "href": "/Reg_Residuos.aspx",  "icon": "trash", "textn1": "Registro", "textn2": "REAS"
                },
                {  //# 33
                    "href": "/Lis_Env_Avis.aspx",  "icon": "list",  "textn1": "Listado", "textn2": "Envíos Avis"
                },
                {  //# 34
                    "href": "/Lis_Tot_Exams.aspx", "icon": "list","textn1": "Listado","textn2": "Exá./Resultados"
                },
                {  //# 35
                    "href": "Reporte/Hoja_de_trabajo/HT_exa.aspx", "icon": "list","textn1": "Total","textn2": "Exám Procesados"
                },
                {  //# 36
                    "href": "Reporte/Hoja_de_trabajo/Ate_LTM_Detalle.aspx","icon": "list","textn1": "Detalle de", "textn2": "Exám Procesados"
                },
                {  //# 37
                    "href": "Reg_Pap/Excel_TP_Real_adm_avis.aspx", "icon": "list", "textn1": "Detalle",  "textn2": "Muestras PAP"
                },
                {  //# 38
                    "href": "Reg_pap/traza_pap.aspx", "icon": "list",  "textn1": "Traza", "textn2": "Contenedor PAP"
                },
                {  //# 39
                    "href": "Reg_pap/Excel_TP_Real_adm_avis_VER.aspx","icon": "list", "textn1": "Listado", "textn2": "Muestras PAP"
                },
                {   //#40
                    "href": "Ate_Pac/AVIS_C_D_VER.aspx","icon": "list", "textn1": "Consulta","textn2": "N AVIS"
                },
                {   //#41
                    "href": "Env_Mues_Lab/Lis_Env_Mues_Lab_4.aspx",  "icon": "list",  "textn1": "Total", "textn2": "de Tubos"
                },
                {   //#42
                    "href": "Check_List/Check_Point/Traza_Folio_Avis.aspx", "icon": "list", "textn1": "Trazabilidad", "textn2": "Folio Avis"
                },
                {   //#43 //REPORTES SOLO USUARIO GESTION 
                    "href": "Repor_check_2.aspx",        "icon": "area-chart", "textn1": "Reportes",  "textn2": ""
                },
                {//#44                                // SOLO PARA USUARIO NORMAL O USUARO TM
                    "href": "Reporte/Laboratorio/REP_LAB_CANT_EXA_TOT.aspx",   "icon": "list", "textn1": "Total", "textn2": "Exám Procesados"
                },
                {//#45                               //SOLO PARA USUARIO NORMAL O USUARIO TM
                    "href": "Env_Mues_Lab/Lis_Env_Mues_Lab_5.aspx",  "icon": "flask", "textn1": "Muestras Env.", "textn2": "por Tubo"
                },
                {//#46                               //SOLO PARA USUARIO NORMAL O USUARIO TM
                    "href": "QC/Menu_QC.aspx",  "icon": "area-chart",  "textn1": "Iris", "textn2": "QC"
                },
                {//#47                              //INGRESO TEST
                    "href": "/Agenda_Med/Ingreso_Ate.aspx","icon": "user",  "textn1": "Ingreso",  "textn2": "TEST"
                },
                {//#48                              //BE
                    "href": "/Boleta_Electronica/B_Elec.aspx",  "icon": "file-text-o", "textn1": "Boleta", "textn2": "Electónica"
                },
                {//#49                              //VIH - SIFILIS
                    "href": "/Check_List/Rev_Deter_Exa_GR.aspx", "icon": "user",  "textn1": "Resultados", "textn2": "VIH - Sífilis"
                },
                {//#50                              //PCR USUARIO PCR
                    "href": "/Check_List/Rev_Deter_Exa_PCR.aspx", "icon": "user", "textn1": "Resultados", "textn2": "PCR"
                },
                {//#51                              //VIH USUARIO PDF
                    "href": "/Check_List/Rev_Deter_Exa_VIH_Res.aspx","icon": "user",  "textn1": "Resultados",  "textn2": "VIH - PDF"
                },
                {//#52                              //Cultivo Streptococcus Grupo B
                    "href": "/Check_List/Rev_Deter_Exa_CC.aspx", "icon": "user", "textn1": "Resultados",  "textn2": "C. Streptococcus"
                }  ,
                {//#53                             //Valorización por RUT
                    "href": "/Gest_Financ/Administracion/Cobro_RUT.aspx",  "icon": "usd",    "textn1": "Valor",  "textn2": "RUT"
                },
                {//#54                             //Valorización por Preve
                    "href": "/Gest_Financ/Estadisticas/Detalle/Prevision_Det.aspx",  "icon": "usd",  "textn1": "Valor", "textn2": "Prevision"
                },
                {//#55                             //REV EST EXA
                    "href": "/Check_List/Rev_Est_Exa_New.aspx",  "icon": "list",   "textn1": "Revisión", "textn2": "Exámenes"
                } ,
                {//#56                             //REV EXA USU
                    "href": "/Check_List/Rev_Exa_Usu.aspx", "icon": "list",   "textn1": "Revisión", "textn2": "Validados"
                },
                //{//#57                             //REM
                //  "href": "/Reporte/Laboratorio/REP_LAB_CANT_EXA_ARE_SECC_2_2.aspx", //    "icon": "list", //    "textn1": "REM", //    "textn2": "Procedencias"
                //},
                {//#57                             //REM
                    "href": "/Reporte/Laboratorio/REP_LAB_CANT_EXA_REM_PROC.aspx",   "icon": "list",   "textn1": "REM", "textn2": "Procedencias"
                },
                {//#58                             //REV EXA USU
                    "href": "/Check_List/Rev_Exa_Usu_Todos.aspx",  "icon": "list","textn1": "Revisión","textn2": "Validados Todos"
                },
                {//59
                    "href": "/iaas/iaas.aspx", "icon": "list", "textn1": "IAAS","textn2": ""
                }  ,
                {//60
                    href: `/Check_List/Val_Criticos_Notif.aspx?id=5feceb66ffc86f38d952786c6d696c79c2dbc239dd4e91b46729d73a27fb57e9`,icon: "list", textn1: "Notificar", textn2: "Val Críticos" //${await hashString("0")}
                },
                {       //61
                    "href": "/Scan_Docs/Ver_Orden.aspx", "icon": "file-text-o", "textn1": "Ver", "textn2": "Ordenes"
                },
                {      //62
                    "href": "/Check_List/Check_Point/Traza_Env_RecepLab_V2.aspx", "icon": "exclamation-triangle", "textn1": "Traza.Env/Rec", "textn2": "Rec.Lab V2.0"
                },
                      // 63
                {
                    "href": "/Reporte/Laboratorio/REP_LAB_CANT_EXA_REM_PROC_25.aspx", "icon": "list", "textn1": "REM", "textn2": "2025"
                }
                    ];
        
        const PERFILES = {
            0: "normal", //USU NORMAL          //LE DICEN USUARIO TOMA DE MUESTRA
            1: "admin",
            2: "usuClinico",
            3: "gestion",
            4: "agenda",
            5: "usuWeb",
            6: "reas",
            //  CASE 7 SE ELIMINÓ
            8: "estafeta",
            9: "matrona",
            10: "monitoreoPCR",
            11: "cobro"
        };
        const BOTONES = {
            PRE_ANALITICA: "preAnalitica",
            ANALITICA: "analitica",
            POS_ANALITICA: "posAnalitica",
            MENU: "categorias"
        };
        const perfiles = {
            normal: {
                preAnalitica: [48, 21, 49, 4, 5, 17, 6, 7, 9, 26, 15, 16, 19, 3, 2, 58, 59, 61, 62],
                analitica: [10, 13, 18, 35, 55, 56, 57, 63],
                posAnalitica: [50, 20, 25, 11, 12, 43, 46, 23, 44, 53, 60]
            },
            admin: {
                preAnalitica: [3,6, 15,7, 9, 26, 45, 4,5,2, 62, 61],
                analitica: [10, 13, 18, 35, 55, 56, 57, 63],
                posAnalitica: [50, 20, 25, 11, 12, 43, 46, 23, 44, 53, 60, 49, 59, 58]
            },
            gestion: {
                preAnalitica: [4,5,23,13],
                analitica: [10, 13, 18, 35, 55, 57, 63],
                posAnalitica: [50, 20, 25, 11, 12, 43, 46, 23, 44, 53]
            },
            agenda: {
                preAnalitica: [1,2,21,27,4,5,12,23,40],
                analitica: [35, 57, 63],
                posAnalitica: [11, 12],
            },
            usuWeb: {
                preAnalitica: [1, 2, 3, 4, 21, 5, 7, 9, 12, 22, 23, 27, 39, 37, 38],
                analitica: [35, 57, 63],
                posAnalitica: [11, 12],
            },
            reas: {
                preAnalitica: [32, 23],
                analitica: [35, 57, 63],
                posAnalitica: [11, 12],
            },
            estafeta: {
                preAnalitica: [38],
                analitica: [35, 57, 63],
                posAnalitica: [11, 12],
            },
            matrona: {
                preAnalitica: [4, 5, 13, 23, 51, 52],
                analitica: [35, 57, 63],
                posAnalitica: [11, 12],
            },
            monitoreoPCR: {
                preAnalitica: [50],
                analitica: [35, 57, 63],
                posAnalitica: [11, 12],
            },
            cobro: {
                preAnalitica: [53],
                analitica: [35, 57, 63],
                posAnalitica: [11, 12],
            }
        }
        const categorias = [
            {   //# 01
                id: "preAnalitica",
                icon: "cogs",
                textn1: "Pre-Analítica"
            },
            {   //# 02
                id: "analitica",
                icon: "flask",
                textn1: "Analítica"
            },
            {   //# 03
                id: "posAnalitica",
                icon: "list",
                textn1: "Pos-Analítica"
            }
        ];

        const asignaColor = i => ["success", "danger", "warning", "primary"][i % 4]
        const llenarBotonesSeccion = boton => {
            $("#amed").empty();
            $("#amed2").empty();

            if (boton === BOTONES.MENU) {
                $("#botonesSecciones").css("display", "flex");
                $("#volverASecciones").css("display", "none");
                return;
            }

            $("#botonesSecciones").css("display", "none");

            const perfilActual = PERFILES[Galletas.getGalleta("P_ADMIN")];
            console.log("perfilActual", perfilActual)
            $("#volverASecciones").css("display", "flex");
            const botones = perfiles[perfilActual][boton];

            var btn_count = botones.length;
            var max_cant = Math.round(btn_count / 2);
            var nrow1 = 1;
            var nrow2 = 1;
            // se pone config agenda solo a usuario con id 1 o 328 y solo si el botn que se selecciona es el de preanalitica
            if (["1", "328"].includes(Galletas.getGalleta("ID_USER") || 0) && boton === BOTONES.PRE_ANALITICA && !botones.includes(48)) {
                botones.unshift(48);
            }
            botones.forEach((aaa, i) => {
                let y = aaa - 1;
                let rows = "";
                let idxx = "";
                let hreff = btn_datas[y].href;
                let icon = btn_datas[y].icon;
                let text1 = btn_datas[y].textn1;
                let text2 = btn_datas[y].textn2;
                if (y == 2) {
                    idxx = "id='btnderivar'";
                }
                else if (y == 11) {
                    idxx = "id='btnreimp'";
                }
                else {
                    idxx = "";
                }
                if (botones.length > 6 && nrow1 <= max_cant) {
                    rows = "#amed";
                    nrow1 += 1;
                    if (nrow1 == max_cant + 1) {
                        nrow1 += 1;
                    }
                }
                else if (botones.length > 6 && nrow2 <= max_cant) {
                    rows = "#amed2";
                    nrow2 += 1;
                }
                else {
                    rows = "#amed";
                    nrow1 += 1;
                }
                $("<div>", { "class": "col-lg" }).append("<a href='" + hreff + "' " + idxx + " class='btn btn-sq btn-" + asignaColor(i) + " btnx'><i class='fa fa-" + icon + " fa-3x'></i><b><br />" + text1 + "<br>" + text2 + "</b></a>").appendTo(rows);

            });
            ////////////////////BTN PRUEBA
            $("#btnderivar").on("click", function () {
                $('#Manual').attr("onclick", "window.location.href='/Agenda_Med/Ingreso_Ate.aspx'");
                $('#AVIS').attr("onclick", "window.location.href='/Agenda_Med/Ingreso_Ate_Avis.aspx'");
                var admin2 = Galletas.getGalleta("P_ADMIN");
                //if (admin2 == 1) {
                $("#Manual").removeAttr('disabled');
                //} else {
                //    $('#Manual').attr("disabled", true);
                //}
                $('#eModal').modal('show');
            });
        }
        $(function () {

            $('#1').attr("onclick", '(window.location.href="/ate_pac/busca_paciente.aspx")');
            $('#2').attr("onclick", '(window.location.href="/agenda_med/in_pac_man.aspx")');

            $('#3').attr("onclick", '(window.location.href="/ate_pac/Imp_Ate_P.aspx")');
            $('#4').attr("onclick", '(window.location.href="/agenda_med/Imp_Ate_Directo.aspx")');

            AJAX_CANT();
            AJAX_EXA();

            if ($(window).width() < 975) {
                $(".btnx").removeClass("btn-sq");
                $(".btnx").addClass("btn-block");
            }

            $(window).on('resize', function () {
                if ($(window).width() < 975) {
                    $(".btnx").addClass("btn-block");
                    $(".btnx").removeClass("btn-sq");

                }
                else {
                    $(".btnx").addClass("btn-sq");
                    $(".btnx").removeClass("btn-block");

                }
            });
            var Nom = Galletas.getGalleta("NAME");
            var Ape = Galletas.getGalleta("SURNAME");
            $("#spn_Usr").text(Nom + " " + Ape);

            ////////////////////BTN PRUEBA
            ///// SPLIT CADENA NUMEROS POR , 
            Call_AJAX_Ddl();

            //$("#btnreimp").click(function () {
            //    $('#ATENCION').attr("onclick", "window.location.href='/agenda_med/Imp_Ate_P.aspx'");
            //    $('#ATENCION_DIREC').attr("onclick", "window.location.href='/agenda_med/Imp_Ate_Directo.aspx'");
            //    $('#eModal_321').modal('show');
            //});

            $("#amed").empty();
            $("#amed2").empty();
            categorias.forEach((item, i) => {
                $("<div>", { "class": "col-lg" })
                    .append("<a id='" + item.id + "' class='btn btn-sq btn-" + asignaColor(i) + " btnx'><i class='fa fa-" + item.icon + " fa-3x'></i><b><br />" + item.textn1 + "</b></a>").appendTo($("#botonesSecciones"));
            })
            $("#botonesSecciones").css("display", "flex");
            $("#volverASecciones").css("display", "none");

            $("#preAnalitica").on("click", () => llenarBotonesSeccion(BOTONES.PRE_ANALITICA));
            $("#analitica").on("click", () => llenarBotonesSeccion(BOTONES.ANALITICA));
            $("#posAnalitica").on("click", () => llenarBotonesSeccion(BOTONES.POS_ANALITICA));

            $("#btnVolverASecciones").on("click", () => llenarBotonesSeccion(BOTONES.MENU));

        });

        //´buscar lista de procendecia maz agenda disponible
        let Mx_Cant = [{
            "TOTAL_ATE": "",
            "TOT_FONASA": "",
            "ID_ESTADO": "",
            "Expr1": ""
        }];

        function AJAX_CANT() {
            $.ajax({
                "type": "POST",
                "url": "Index.aspx/Bus_Cant",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug

                    Mx_Cant = JSON.parse(data.d);

                    if (Mx_Cant != null) {
                        Fill_Cant();
                    }

                },
                "error": data => {
                    //Debug



                }
            });
        }
        let Mx_Exa = [{
            "TOTAL_PREVE": "",
            "EST_DESCRIPCION": "",
            "ID_ESTADO": "",
            "ATE_DET_V_ID_ESTADO": ""
        }];
        function AJAX_EXA() {
            $.ajax({
                "type": "POST",
                "url": "Index.aspx/Bus_Exa",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug

                    Mx_Exa = JSON.parse(data.d);

                    if (Mx_Exa != null) {
                        Fill_Exa();
                    }

                },
                "error": data => {
                    //Debug



                }
            });
        }

        //AJAX DroDownList
        function Call_AJAX_Ddl() {
            //Debug


            $.ajax({
                "type": "POST",
                "url": "Index.aspx/Llenar_Ddl_LugarTM",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    var vv = Galletas.getGalleta("P_ADMIN");
                    var vv2 = Galletas.getGalleta("USU_TM");
                    if (vv == 1) {
                        $("#spn_tm").text("");

                    } else {

                        JSON.parse(data.d).forEach(aaa => {
                            if (aaa.ID_PROCEDENCIA == vv2) {
                                $("#spn_tm").text(aaa.PROC_DESC);
                            }
                        });
                    }
                },
                "error": data => {
                    //Debug
                }
            });
        }
        function Fill_Cant() {
            Mx_Cant.forEach(function (cant) {
                $("#txt_Ate").text(cant.TOTAL_ATE);
                $("#txt_Exa").text(cant.TOT_FONASA);
            });

        }
        function Fill_Exa() {
            Mx_Exa.forEach(function (Exam) {
                if (Exam.ATE_DET_V_ID_ESTADO == 7) {
                    $("#txt_Esp").text(Exam.TOTAL_PREVE);
                }
                if (Exam.ATE_DET_V_ID_ESTADO == 6) {
                    $("#txt_Val").text(Exam.TOTAL_PREVE);
                }
                if (Exam.ATE_DET_V_ID_ESTADO == 14) {
                    $("#txt_Imp").text(Exam.TOTAL_PREVE);
                }
            });
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <style>
        .btn-warning:hover {
            color: white;
        }

        .btnx {
            color: white !important;
            min-width: 131px !important;
        }

        .hd {
            display: none;
        }

        .fa-3x {
            margin-top: 7px;
        }

        .btn-warning {
            color: white;
            background: #ffa837;
        }

        .col-lg {
            margin-bottom: 1rem;
        }

        .btn-sq-lg {
            width: 150px !important;
            height: 150px !important;
        }

        .btn-sq {
            width: 112px !important;
            height: 112px !important;
            font-size: 15px;
        }

        .btn-sq-sm {
            width: 50px !important;
            height: 50px !important;
            font-size: 10px;
        }

        .btn-sq-xs {
            width: 25px !important;
            height: 25px !important;
            padding: 2px;
        }

        .mrgs {
            margin-left: 5rem;
            margin-right: 5rem;
        }

        @media screen and (max-width:320px) {
            .mrgs {
                margin-left: 3rem;
                margin-right: 3rem;
            }
        }

        #imgx {
            width: 55vw;
        }

        @media screen and (max-width:992px) {
            #imgx {
                width: 80vw;
            }

            #usr {
                display: none;
            }
        }

        a:hover, button:hover {
            cursor: pointer
        }
    </style>


    <div class="row ml-3 mr-3 mb-3">
        <div class="col-lg" style="text-align: center">
            <img src="Imagenes/logo_largo_irislab.png" id="imgx" />
        </div>
        <div class="col-lg">
            <div class="card mt-lg-5 mb-3 p-3 border-info">
                <div class="row">
                    <div class="col-12 text-center">
                        <h5 style="color: #007e9e"><b><span id="spn_tm"></span></b></h5>
                    </div>
                    <div class="col-lg mb-0">
                        <h5>N° de Atenciones</h5>
                        <div class="row">
                            <div class="col-8">
                                <label for="txt_Ate">N° Atenciones:</label>
                            </div>
                            <div class="col-4 text-primary">
                                <b>
                                    <label id="txt_Ate">0</label></b>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-8">
                                <label for="txt_Exa">N° Exámenes:</label>
                            </div>
                            <div class="col-4 text-success">
                                <b>
                                    <label id="txt_Exa">0</label></b>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg mb-0 ">
                        <h5>Estado de Exámenes</h5>
                        <div class="row">
                            <div class="col-8">
                                <label for="txt_Esp">N° Espera:</label>
                            </div>
                            <div class="col-4 text-danger">
                                <b>
                                    <label id="txt_Esp">0</label></b>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-8">
                                <label for="txt_Val">N° Validados:</label>
                            </div>
                            <div class="col-4 text-primary">
                                <b>
                                    <label id="txt_Val">0</label></b>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-8">
                                <label for="txt_Imp">N° Impresos:</label>
                            </div>
                            <div class="col-4 text-success">
                                <b>
                                    <label id="txt_Imp">0</label></b>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div id="volverASecciones" style="display: none; justify-content: center; margin-bottom: 2rem;">
        <button class="btn btn-info" style="display: flex; align-items: center; gap: 1rem;" id="btnVolverASecciones">
            <i class="fa fa-hand-o-left fa-2x" aria-hidden="true"></i>
            <b>Volver a Secciones</b>
            <i class="fa fa-hand-o-left fa-2x" aria-hidden="true"></i>

        </button>
    </div>
    <div class="row text-center mrgs mb-3" id="amed"></div>
    <div class="row text-center mrgs mb-3" id="amed2"></div>
    <div class="row text-center mrgs mb-3" id="botonesSecciones"></div>

    <div class="mt-5 text-center" id="usr">
        <h3 style="color: #015368"><b>BIENVENIDO(A)  <span id="spn_Usr"></span></b></h3>
    </div>

    <%-- <div class="modal fade" id="eModal" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content p-3">
                <div class="modal-header">
                    <h5 class="modal-title" id="sss">OPCIONES DE INGRESO DE ATENCIÓN</h5>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-6" style="text-align: center;">
                            <button type="button" id="Manual" class="btn btn-primary" style="height: 120px; width: 75%;" disabled="disabled"><b>PACIENTE MANUAL</b></button>
                        </div>
<                       <div class="col-md-6" style="text-align: center;">
                            <button  type="button" id="AVIS" class="btn btn-info" style="height: 120px; width: 75%;"><b>PACIENTE SISMAULE</b></button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>

    <div class="modal fade" id="eModal" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content p-3">
                <div class="modal-header">
                    <h5 class="modal-title" id="sss">OPCIONES DE INGRESO DE ATENCIÓN</h5>
                </div>
                <div class="modal-body text-center">
                    <div class="row justify-content-center">
                        <div class="col-md-6">
                            <button type="button" id="Manual" class="btn btn-primary" style="height: 120px; width: 75%;" disabled="disabled">
                                <b>PACIENTE MANUAL</b>
                            </button>
                        </div>
                        <!-- Agrega tus otros elementos si es necesario -->
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="eModal_321" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content p-3">
                <div class="modal-header">
                    <h5 class="modal-title" id="55555">OPCIONES DE REIMPRESIÓN</h5>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-6" style="text-align: center;">
                            <button type="button" id="ATENCION" class="btn btn-primary" style="height: 120px; width: 75%;"><b>PRE-INGRESO Y ATENCÍON</b></button>
                        </div>
                        <div class="col-md-6" style="text-align: center;">
                            <button type="button" id="ATENCION_DIREC" class="btn btn-info" style="height: 120px; width: 75%;"><b>ATENCIÓN DIRECTA</b></button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
