/// <reference path="../js/webform.ts" />
/// <reference path="../scripts/typings/jquery/math.d.ts" />
/// <reference path="D:\Repos\IRIS_HOLANDA_MULTIPLE\iris_holanda_multiple\Presentacion\js/Galletas.js" />

import { formatJSONDate } from "../js/es6-modules/Edad.js";
import { fillExamenesSeccion, fillExamenesRlsAreaSeccPrev, fillExamenesRlsAreaSeccPrevs } from "../js/es6-modules/Examenes.js";
import fetcher from "../js/es6-modules/Fetcher.js";
import IrisResponse from "../js/es6-modules/IrisResponse.js";
import fillSeccionesAreas from "../js/es6-modules/Secciones.js";
//import buscaNumeroAtencionFlecha from "../js/es6-modules/VisorResultados.js";

var ATE_RES;
let ID_ATE;
let idPrevisionChecked;
let idProgramaChecked;
let idSeccionChecked;

let Mx_Check_C = [];
let Mx_Check_NC = [];
let Mx_Check_Guardar = [];
let ACTIVA_PENDIENTES = 0;
let ACTIVA_PENDIENTES_R = 0;

var ID_ATENCHION = 0;
var ID_PERRRRRRCH = 0;
var ID_FONASSSAAAA = 0;

let objAJAX_Pac_Data;

let updateEdad = true;
let foliosEdadLista = [];
function Ajax_Get_values_to_Pendiente(CBB, ATE_NUMM, CODI_FONISI, ATE_COD_TEST, ID_ATEEEEEEECX, ID_CEEFEEE, PARA_CF_DESQQQ, MULTIPLICADOSSSSSTTTTTTTT) {
    ID_ATENCHION = CBB;
    ID_PERRRRRRCH = ATE_NUMM;
    ID_FONASSSAAAA = CODI_FONISI;
    $("#btnAgregaDeter").removeAttr("disabled");
};

(async function (ATE_RES) {
    //---------------------------------------------------------------------------------------------
    //Declaración de Variables Internas------------------------------------------------------------
    let num_title_loop;
    let fn_title_loop = () => {
        let arr_dot = document.title.match(/\.+$/gi);
        if (arr_dot == null) {
            document.title = document.title.replace(/\.*$/i, ".");
        }
        else {
            if (arr_dot[0].length == 1) {
                document.title = document.title.replace(/\.*$/i, "..");
            }
            else if (arr_dot[0].length == 2) {
                document.title = document.title.replace(/\.*$/i, "...");
            }
            else {
                document.title = document.title.replace(/\.*$/i, "");
            }
        }
    };
    let strUrlQuery = (function () {
        //Comprobar URL
        let REE;
        let strURL = location.href.match(/([a-z]|[0-9]|-|_)\.aspx\?ID\=/gi);
        if (strURL == null) {
            //location.href = "/index.aspx"
            REE = null;
        }
        else {
            REE = location.href.match(/\?ID\=.+/gi)[0];
            REE = REE.replace(/\?(?=(ID\=.+))/gi, "");
        }
        return REE;
    }());
    let objWrite = {
        URL: null,
        Param: null,
    };
    //let fucusTimeout: number
    let keyEnter = false;
    let objData_Pac;
    let objData_HistGen;
    let objData_Dtt;
    let objData_Audit;
    let objData_ResCod;
    let objSel_Secc;
    let objSel_Exam;
    let objSel_IntExt;
    class class_Count_Load {
        constructor() {
            this.loaded = false;
            this.count = 0;
        }
        async endLoad() {
            if (this.loaded == true) {
                return this.count;
            }
            else {
                this.count += 1;
            }
            switch (this.count) {
                case 3:
                    //console.warn("log entra count 3");
                    if (Sel_Secc.getValue().value != null) {
                        this.ID_SECC_Now = JSON.parse(decodeURI(atob(`${Sel_Secc.getValue().value}`))).ID_SECC;
                        this.ID_EXAM_Now = parseInt(`${Sel_Exam.getValue().value}`);
                        this.ID_INEX_Now = 0;
                    }
                    if (strUrlQuery == null || strUrlQuery == "ID=Znpvy0y6YSQ=") {
                        objAJAX_Sel_Prev.requestNow({
                            ID_PROC: Sel_Proc.getValue().value
                        }, () => {
                            fn_Charge_Exam();
                            objAJAX_Sel_Prog.requestNow({
                                ID_PREV: Sel_Prev.getValue().value
                            });
                        });
                        objAJAX_Sel_Secc.requestNow();
                        clearInterval(num_title_loop);
                        document.title = "Visor de Resultados";
                        Dtt_Exam.cleanTable("Por favor introduzca un Nro de Atención, en la casilla correspondiente, y presione Enter para Iniciar la búsqueda.");
                        Hide_Modal();
                        return;
                    }
                    objAJAX_Sel_Prev.requestNow({
                        ID_PROC: Sel_Proc.getValue().value
                    }, () => {
                        objAJAX_Sel_Prog.requestNow({
                            ID_PREV: Sel_Prev.getValue().value
                        }, () => {
                            objAJAX_Pac_Data.queryString = strUrlQuery;
                            objAJAX_Pac_Data.requestNow({
                                NUM_ATE: $("#Txt_NumAte").val() || 0,
                                USU_ID_PROC: Galletas.getGalleta("USU_TM")
                            });
                        });
                    });

                    break;
                case 5:
                    //console.warn("log entra count 5")
                    if (strUrlQuery == null) {
                        return;
                    }
                    Sel_Proc.setValue(objData_Pac.ID_PROCEDENCIA);
                    objAJAX_Sel_Prev.requestNow({
                        ID_PROC: objData_Pac.ID_PROCEDENCIA
                    }, () => {
                        fn_Charge_Exam();
                    });
                    break;
                case 6:
                    //console.warn("log entra count 6")
                    // console.log("Join 6");
                    if (strUrlQuery == null) {
                        // console.log("-->Se ha ingresado directamente al formulario...");
                        // console.log("   Carga finalizada.-\n");
                        return;
                    }
                    Sel_Prev.setValue(objData_Pac.ID_PREVE);
                    objAJAX_Sel_Prog.requestNow({
                        ID_PREV: objData_Pac.ID_PREVE
                    });
                    break;
                case 7:
                    //console.warn("log entra count 7")
                    // console.log("Join 7");
                    if (strUrlQuery == null) {
                        return;
                    }
                    //// console.log("ID PROGGG "+objData_Pac.ID_PROGRA);
                    Sel_Prog.setValue(objData_Pac.ID_PROGRA);
                    //if (this.loaded == true) {
                    this.locateSecc();
                    //}
                    objAJAX_Fill_Table.queryString = strUrlQuery;

                    let exa_Val = $("#Sel_Exam").val();

                    if (exa_Val == null) {
                        exa_Val = 0;
                        $("#Sel_Exam").val(exa_Val);
                    }

                    let sec_Val = null
                    if (Sel_Secc.getValue().value) {
                        sec_Val = JSON.parse(decodeURI(atob(`${Sel_Secc.getValue().value}`))).ID_SECC;
                    }

                    if (sec_Val == null) {
                        sec_Val = 0;
                    }

                    if (Chk_Filther.getValues().indexOf(7) != -1) {
                        ACTIVA_PENDIENTES = 1;
                    }
                    else {
                        ACTIVA_PENDIENTES = 0;
                    }
                    if (Chk_Filther.getValues().indexOf(8) != -1) {
                        ACTIVA_PENDIENTES_R = 1;
                    }
                    else {
                        ACTIVA_PENDIENTES_R = 0;
                    }
                    const idCodigoFonasa = getParameterByNameMaster("CF");
                    if (idCodigoFonasa > 0 && idCodigoFonasa) {
                        const examenesCargados = Sel_Exam.data.map(item => item.value);
                        if (examenesCargados.includes(idCodigoFonasa)) {
                            Sel_Exam.setValue(idCodigoFonasa);
                            if (Chk_Filther.getValues().indexOf(4) == -1) {
                                $("#objChk_Filther_6").trigger("click");
                            }
                        }
                    }
                    const idRlsLs = parseInt(getParameterByNameMaster("AS"));
                    if (idRlsLs > 0 && idRlsLs) {
                        const areaSeccionCargados = Array.from($("#Sel_Secc option")).map(item => JSON.parse(decodeURI(atob(item.value))).ID_SECC);
                        if (areaSeccionCargados.includes(idRlsLs)) {
                            const indexSelectedRls = areaSeccionCargados.indexOf(idRlsLs)
                            document.getElementById("Sel_Secc").selectedIndex = indexSelectedRls
                            if (Chk_Filther.getValues().indexOf(3) == -1) {
                                $("#objChk_Filther_5").trigger("click");
                            }
                        }
                    }

                    objAJAX_Fill_Table.requestNow({
                        R_ID_SECC: sec_Val,
                        R_ID_EXAM: parseInt(`${Sel_Exam.getValue().value}`),
                        R_ID_PAC: objData_Pac.ID_PACIENTE,
                        R_FNAC: moment(objData_Pac.PAC_FNAC).toDate(),
                        R_SEXO: objData_Pac.SEXO_DESC,
                        R_DIA: objData_Pac.ATE_DIA,
                        R_MES: objData_Pac.ATE_MES,
                        R_AÑO: objData_Pac.ATE_AÑO,
                        ACTIVA_PENDIENTES,
                        ACTIVA_PENDIENTES_R,
                    });
                    break;
                case 8:
                    //console.warn("log entra count 8")
                    // console.log("Join 8");
                    if (strUrlQuery == null) {
                        return;
                    }
                    // console.log("make table 1");
                    fn_Make_Table();
                    fn_Calc();
                    clearInterval(num_title_loop);
                    document.title = `Res ATE N°${objData_Pac.ATE_NUM}`;
                    Hide_Modal();
                    this.loaded = true;
                    this.count = 2;
            }
            return this.count;
        }
        locateSecc() {
            if (this.ID_SECC_Now == null) {
                return;
            }
            if (this.ID_EXAM_Now == null) {
                return;
            }
            //Asignar Sección
            let xValue = "";
            for (let i = 0; i < objSel_Secc.length; i++) {
                let ID_SECC_then = JSON.parse(decodeURI(atob(`${objSel_Secc[i].ID}`))).ID_SECC;
                if (ID_SECC_then == this.ID_SECC_Now) {
                    xValue = objSel_Secc[i].ID;
                    break;
                }
            }
            if (this.ID_EXAM_Now != 0) {
                Sel_Exam.setValue(this.ID_EXAM_Now);
            }
            if (xValue != "") {
                Sel_Secc.setValue(xValue);
            }
        }
    }

    function IRIS_WEBF_CMVM_BUSCA_ID_PER_BY_ID_CF(id_per) {
        var Mx_Previa = [
            {
                "ID_PER": "",
                "ID_ATENCION": "",
                "ENCRYPTED_ID_USER": ""
            }
        ];


        var strParam = JSON.stringify({
            "ID_CF": ID_CFFFFFFF,
            "ATE_NUM": $("#Txt_NumAte").val()
        });

        $.ajax({
            "type": "POST",
            "url": "Ate_Resultados_3.aspx/IRIS_WEBF_CMVM_BUSCA_ID_PER_BY_ID_CF",
            "data": strParam,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": function (response) {
                var json_receiver = response.d;
                if (json_receiver != "null") {
                    Mx_Previa = json_receiver;
                    // console.log(Mx_Previa);
                    if (Mx_Previa.length > 0) {
                        var loc = location.origin;

                        window.open(loc + "/Print_Ate/VerExamenesSolo.asp?dato1=" + (objData_Pac.ID_ATENCION * 2) + "&dato2=" + (objData_Pac.ID_ATENCION * 5) + "&dato3=" + (id_per) + "&dato4=" + (id_per * 5));
                    } else {

                    }

                } else {

                }
            },
            "error": function (response) {

            }
        });
    }

    function Ajax_Ate_Seccion() {
        var strParam = JSON.stringify({
            "DESDE": $("#fecha11").val(),
            "HASTA": $("#fecha22").val(),
            "ID_SEC": $("#Ddl_Seccion").val(),
            "ID_PROC": $("#Ddl_Proc_Ate").val()
        });

        $.ajax({
            "type": "POST",
            "url": "Ate_Resultados_3.aspx/Busca_Ate_Por_Sec",
            "data": strParam,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": function (response) {
                var json_receiver = response.d;
                if (json_receiver != "null") {
                    let Mx_Ate_Sec = json_receiver;
                    // console.log(Mx_Ate_Sec);
                    if (Mx_Ate_Sec.length > 0) {

                        $("#Div_Dtt").empty();
                        $("#Div_Dtt").append(
                            $("<table>", {
                                "id": "Dtt_Ate",
                                "cellspacing": "0"
                            }).css({
                                "width": "100%",
                                "border-collapse": "collapse",
                                "font-size": "1px"
                            })
                        );
                        $("#Div_Dtt table").attr("class", "table table-hover table-striped table-iris");
                        //Crear cabeceras
                        $("#Dtt_Ate").append(
                            $("<thead>"),
                            $("<tbody>")
                        );
                        $("#Dtt_Ate thead").append(
                            $("<tr>").append(
                                $("<th>").text("Folio"),
                                $("<th>").text("Fecha"),
                                $("<th>").text("Sección"),
                                $("<th>").text("TdeM")
                            )
                        );
                        //$("#Div_Dtt table thead tr th").addClass("text-center");
                        //Recorrer JSON
                        Mx_Ate_Sec.forEach(aah => {
                            $("<tr>").css("cursor", "pointer").attr("value", aah.ATE_NUM).append(
                                $("<td>").css("text-align", "left").text(aah.ATE_NUM),
                                $("<td>").css("text-align", "left").text(moment(aah.ATE_FECHA).format("DD-MM-YYYY")),
                                $("<td>").css("text-align", "left").text(aah.SECC_COD.toUpperCase()),
                                $("<td>").css("text-align", "left").text(aah.PROC_DESC.toUpperCase())
                            ).appendTo("#Dtt_Ate tbody");
                        });
                        $("#Dtt_Ate").DataTable({
                            "bSort": false,
                            "iDisplayLength": 100,
                            "info": false,
                            "bPaginate": false,
                            "bFilter": false,
                            "language": {
                                "lengthMenu": "Mostrar: _MENU_",
                                "zeroRecords": "No hay coincidencias",
                                "info": "Mostrando Pagina _PAGE_ de _PAGES_",
                                "infoEmpty": "No hay concidencias",
                                "infoFiltered": "(Se busco en _MAX_ registros )",
                                "search": "<strong><i class='fa fa-search'></i>Buscar: </strong>",
                                "paginate": {
                                    "previous": "Anterior",
                                    "next": "Siguiente"
                                }
                            }
                        });

                        $("#Dtt_Ate tbody tr").click(ev => {

                            $('#modal-atenciones').modal('hide');
                            //alert($(ev.currentTarget).attr("value"));
                            $("#Txt_NumAte").val($(ev.currentTarget).attr("value"));
                            let e = $.Event("keypress", { which: 13 });
                            $('#Txt_NumAte').trigger(e);
                        });
                        $("#Dtt_Ate").addClass("cell-border")
                    } else {

                        // console.log("ELSE");
                        $("#Div_Dtt").empty();
                    }

                } else {
                    // console.log("ELSE");
                    $("#Div_Dtt").empty();
                }
            },
            "error": function (response) {

            }
        });
    }

    function Ajax_Ate_Seccion_Pendientes() {

        if (Chk_Filther.getValues().indexOf(7) != -1) {
            ACTIVA_PENDIENTES = 1;
        }
        else {
            ACTIVA_PENDIENTES = 0;
        }
        if (Chk_Filther.getValues().indexOf(8) != -1) {
            ACTIVA_PENDIENTES_R = 1;
        }
        else {
            ACTIVA_PENDIENTES_R = 0;
        }

        var strParam = JSON.stringify({
            "DESDE": $("#fecha11").val(),
            "HASTA": $("#fecha22").val(),
            "ID_SEC": $("#Ddl_Seccion").val(),
            "ID_PROC": $("#Ddl_Proc_Ate").val(),
            ACTIVA_PENDIENTES,
            ACTIVA_PENDIENTES_R
        });

        $.ajax({
            "type": "POST",
            "url": "Ate_Resultados_3.aspx/Busca_Ate_Por_Sec_Pendientes",
            "data": strParam,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": function (response) {
                var json_receiver = response.d;
                if (json_receiver != "null") {
                    let Mx_Ate_Sec = json_receiver;
                    // console.log(Mx_Ate_Sec);
                    if (Mx_Ate_Sec.length > 0) {

                        $("#Div_Dtt").empty();
                        $("#Div_Dtt").append(
                            $("<table>", {
                                "id": "Dtt_Ate",
                                "cellspacing": "0"
                            }).css({
                                "width": "100%",
                                "border-collapse": "collapse",
                                "font-size": "1px"
                            })
                        );
                        $("#Div_Dtt table").attr("class", "table table-hover table-striped table-iris");
                        //Crear cabeceras
                        $("#Dtt_Ate").append(
                            $("<thead>"),
                            $("<tbody>")
                        );
                        $("#Dtt_Ate thead").append(
                            $("<tr>").append(
                                $("<th>").text("Folio"),
                                $("<th>").text("Fecha"),
                                $("<th>").text("Sección"),
                                $("<th>").text("TdeM")
                            )
                        );
                        //$("#Div_Dtt table thead tr th").addClass("text-center");
                        //Recorrer JSON
                        Mx_Ate_Sec.forEach(aah => {
                            $("<tr>").css("cursor", "pointer").attr("value", aah.ATE_NUM).append(
                                $("<td>").css("text-align", "left").text(function () {
                                    $(this).css("cssText", "background-color:#fcbbbb !important; cursor:pointer; text-align:center;").text(aah.ATE_NUM);
                                }),
                                $("<td>").css("text-align", "left").text(function () {
                                    $(this).css("cssText", "background-color:#fcbbbb !important; cursor:pointer; text-align:center;").text(moment(aah.ATE_FECHA).format("DD-MM-YYYY"));

                                }),
                                $("<td>").css("text-align", "left").text(function () {
                                    $(this).css("cssText", "background-color:#fcbbbb !important; cursor:pointer; text-align:center;").text(aah.SECC_COD.toUpperCase());

                                }),
                                $("<td>").css("text-align", "left").text(function () {
                                    $(this).css("cssText", "background-color:#fcbbbb !important; cursor:pointer; text-align:center;").text(aah.PROC_DESC.toUpperCase());

                                })
                            ).appendTo("#Dtt_Ate tbody");
                        });
                        $("#Dtt_Ate").DataTable({
                            "bSort": false,
                            "iDisplayLength": 100,
                            "info": false,
                            "bPaginate": false,
                            "bFilter": false,
                            "language": {
                                "lengthMenu": "Mostrar: _MENU_",
                                "zeroRecords": "No hay coincidencias",
                                "info": "Mostrando Pagina _PAGE_ de _PAGES_",
                                "infoEmpty": "No hay concidencias",
                                "infoFiltered": "(Se busco en _MAX_ registros )",
                                "search": "<strong><i class='fa fa-search'></i>Buscar: </strong>",
                                "paginate": {
                                    "previous": "Anterior",
                                    "next": "Siguiente"
                                }
                            }
                        });

                        $("#Dtt_Ate tbody tr").click(ev => {

                            //alert($(ev.currentTarget).attr("value"));
                            $("#Txt_NumAte").val($(ev.currentTarget).attr("value"));
                            let e = $.Event("keypress", { which: 13 });
                            $('#Txt_NumAte').trigger(e);
                        });
                    } else {

                        // console.log("ELSE");
                        $("#Div_Dtt").empty();
                    }

                } else {
                    // console.log("ELSE");
                    $("#Div_Dtt").empty();
                }
            },
            "error": function (response) {

            }
        });
    }



    function Ajax_Busca_Ate_Tabla(ATE_NUM) {
        $("#Txt_NumAte").val(ATE_NUM);
        let e = $.Event("keypress", { which: 13 });
        $('#Txt_NumAte').trigger(e);
    }

    var Mx_Seccion = [
        {
            "ID_RLS_LS": 0,
            "RLS_LS_DESC": 0
        }
    ];
    function Ajax_Seccion() {
        //modal_show();

        $(".block_wait").fadeIn(500);
        $.ajax({
            "type": "POST",
            "url": "Ate_Resultados_3.aspx/Llenar_Ddl_Seccion",
            //"data": Data_Par,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": function (response) {
                var json_receiver = response.d;
                if (json_receiver != "null") {
                    Mx_Seccion = JSON.parse(json_receiver);
                    Fill_Ddl_Seccion();
                    //Hide_Modal();

                } else {

                    //Hide_Modal();
                    //$("#mError_AAH h4").text("Sin resultados");
                    //$("#mError_AAH button").attr("class", "btn btn-danger");
                    //$("#mError_AAH p").text("No se han encontrado resultados");
                    //$("#mError_AAH").modal();
                }
                $(".block_wait").fadeOut(500);
            },
            "error": function (response) {
                //var str_Error = response.responseJSON.ExceptionType + "\n \n";
                //str_Error = response.responseJSON.Message;
                //alert(str_Error);

            }
        });
    }
    function Fill_Ddl_Seccion() {

        $("#Ddl_Seccion").empty();
        $("<option>", { "value": 0 }).text("TODOS SECCIÓN").appendTo("#Ddl_Seccion");
        for (let y = 0; y < Mx_Seccion.length; ++y) {
            $("<option>", {
                "value": Mx_Seccion[y].ID_RLS_LS
            }).text(Mx_Seccion[y].RLS_LS_DESC).appendTo("#Ddl_Seccion");
        }
    };

    //Declaración de Elem--------------------------------------------------------------------------
    let Txt_NumAte = new WEBFORM.class_Input("Txt_NumAte");
    //let Txt_DateAte = new WEBFORM.class_Input("Txt_DateAte");
    //let Txt_Nombre = new WEBFORM.class_Input("Txt_Nombre");
    //let Txt_Edad = new WEBFORM.class_Input("Txt_Edad");
    //let Txt_Sexo = new WEBFORM.class_Input("Txt_Sexo");
    //let Txt_FUR = new WEBFORM.class_Input("Txt_FUR");
    let Txt_ResCod_Det = new WEBFORM.class_Input("Txt_ResCod_Det");
    let Txt_ResCod_Out = new WEBFORM.class_Input("Txt_ResCod_Out");
    //let Txt_Sector = new WEBFORM.class_Input("Txt_Sector");
    //let Txt_Med = new WEBFORM.class_Input("Txt_Med");
    //let Txt_Hist = new WEBFORM.class_Input("Txt_Hist");
    //Txt_NumAte.numeric = {
    //    value: true,
    //    default: 1,
    //    min: 1,
    //    max: (10 ^ 8)
    //}
    //Txt_DateAte.setReadOnly(true);
    //Txt_Nombre.setReadOnly(true);
    //Txt_Edad.setReadOnly(true);
    //Txt_Sexo.setReadOnly(true);
    //Txt_FUR.setReadOnly(true);
    Txt_ResCod_Det.readOnly = true;
    //Txt_Sector.readOnly = true;
    //Txt_Med.readOnly = true;
    //Txt_Hist.readOnly = true;
    let Sel_Prev = new WEBFORM.class_Select("Sel_Prev");
    let Sel_Proc = new WEBFORM.class_Select("Sel_Proc");
    let Sel_Prog = new WEBFORM.class_Select("Sel_Prog");
    let Sel_Secc = new WEBFORM.class_Select("Sel_Secc");
    let Sel_Exam = new WEBFORM.class_Select("Sel_Exam");
    let Sel_IntExt = new WEBFORM.class_Select("Sel_IntExt");
    let Chk_Filther = new WEBFORM.class_Checkbox("Chk_Filther");
    let Btn_Audit = new WEBFORM.class_Button("Btn_Audit");
    let Btn_Validar = new WEBFORM.class_Button("Btn_Validar");
    let Btn_Revisar = new WEBFORM.class_Button("Btn_Revisar");
    let Btn_Not_Revisar = new WEBFORM.class_Button("Btn_Not_Revisar");
    let Btn_Desvalidar = new WEBFORM.class_Button("Btn_Desvalidar");
    let Btn_Print = new WEBFORM.class_Button("Btn_Print");
    let Btn_Graph = new WEBFORM.class_Button("Btn_Graph");
    let btn_consulta = new WEBFORM.class_Button("btn_consulta");

    let Btn_Crit = new WEBFORM.class_Button("Btn_Crit");
    let btn_Acept_CM = new WEBFORM.class_Button("btn_Acept_CM");

    let Btn_GraphAlt = new WEBFORM.class_Button("Btn_GraphAlt");
    let Btn_Hist = new WEBFORM.class_Button("Btn_Hist");
    let Btn_HistPruExit = new WEBFORM.class_Button("Btn_HistPruExit");
    let Btn_RC_Add = new WEBFORM.class_Button("Btn_RC_Add");
    let Btn_RC_New = new WEBFORM.class_Button("Btn_RC_New");
    let Btn_AteL = new WEBFORM.class_Button("Btn_AteL");
    let Btn_AteR = new WEBFORM.class_Button("Btn_AteR");
    let Mdl_Init_Load = new class_Count_Load();
    let Dtt_Exam = new WEBFORM.class_Table("Dtt_Exam", "Cargando...");
    let Dtt_Audit = new WEBFORM.class_Table("Dtt_Audit", "Cargando...");
    let filaPruebasEdad = [];
    let filaVFGMayorA60 = [];
    let fn_Make_Table = () => {

        $("#mdls").empty();

        Dtt_Exam.cleanTable();
        Dtt_Exam.addTHead("T", "center");
        Dtt_Exam.addTHead("E", "center");
        Dtt_Exam.addTHead("Examen", "left");
        Dtt_Exam.addTHead("Descripción", "left");
        Dtt_Exam.addTHead("Resultado", "left");
        Dtt_Exam.addTHead("Unidad", "left");
        Dtt_Exam.addTHead("", "left");
        Dtt_Exam.addTHead("Desde", "center");
        Dtt_Exam.addTHead("Hasta", "center");
        Dtt_Exam.addTHead("Result. Hist.", "center");
        Dtt_Exam.addTHead("Fecha Hist.", "center");
        Dtt_Exam.addTHead(`<i class="fa fa-clock-o" aria-hidden="true"></i>`, "center");


        let Cont_Loop = 1;
        let Cont_Int = 2;
        let Curr_Exa = "";
        let Bg_Arr = [];

        let text_BG = "";



        filaPruebasEdad = [];
        filaVFGMayorA60 = [];
        let _Z = 1050;
        //// console.log(objData_Dtt);
        for (let i in objData_Dtt) {

            if (Curr_Exa == "") {
                Curr_Exa = objData_Dtt[i].Exam.ID_CF;
            } else if (Curr_Exa != objData_Dtt[i].Exam.ID_CF) {
                Curr_Exa = objData_Dtt[i].Exam.ID_CF;

                if (Cont_Loop == 3) {
                    Cont_Loop = 1;
                } else {
                    Cont_Loop += 1;
                }
            }
            if (Cont_Int == 1) {
                Cont_Int = 2;
            } else {
                Cont_Int = 1;
            }

            if (Cont_Loop == 1) {
                if (Cont_Int == 1) {
                    text_BG = "odd_C1";
                } else {
                    text_BG = "even_C1";
                }
            } else if (Cont_Loop == 2) {
                if (Cont_Int == 1) {
                    text_BG = "odd_C2";
                } else {
                    text_BG = "even_C2";
                }
            } else {
                if (Cont_Int == 1) {
                    text_BG = "odd_C3";
                } else {
                    text_BG = "even_C3";
                }
            }
            const pruebaRechazada = objData_Dtt[i].rechazado;
            text_BG = pruebaRechazada ? "rechazado" : "";


            const pruebaRevisada = objData_Dtt[i].Res.ATE_REV_ID_ESTADO;

            if (pruebaRevisada == 1) {
                text_BG = "revisado";
                console.log("Revisado")
            } 

            Bg_Arr = ["bg-white", "bg-white", text_BG, text_BG, text_BG, text_BG, text_BG, text_BG, text_BG, text_BG, text_BG];
            //Cont_Loop+=1;

            var index = i;
            let SeccInit = JSON.parse(decodeURI(atob(`${Sel_Secc.data[0].value}`)));
            let SeccNow = JSON.parse(decodeURI(atob(`${Sel_Secc.getValue().value}`)));
            let xCF = parseInt(String(Sel_Exam.getValue().value));
            if ((SeccInit.ID_SECC != SeccNow.ID_SECC) || (xCF != 0)) {
                if (xCF == 0) {
                    var xFound = false;
                    SeccNow.ARR_ID.forEach((xElem) => {
                        if (objData_Dtt[i].Exam.ID_CF == xElem) {
                            xFound = true;
                        }
                    });
                    if (xFound == false) {
                        continue;
                    }
                }
                else {
                    if (objData_Dtt[i].Exam.ID_CF != xCF) {
                        continue;
                    }
                }
            }
            //// console.log(objData_Dtt);

            Dtt_Exam.addRow(index, [

                objData_Dtt[index].TT.DESC_TD,
                (function () {
                    if (objData_Dtt[index].EE.value == 11 && objData_Dtt[index].EE.estado == "") {
                        objData_Dtt[index].EE.estado = "T";
                    }
                    //// console.log(objData_Dtt[index]);
                    //// console.log(objData_Dtt[index].Exam.Descrp);
                    let strClass;
                    switch (objData_Dtt[index].EE.value) {
                        case 10:
                            strClass = "yellow";
                            break;
                        case 11:
                            strClass = "v_green";
                            break;
                        case 6:
                            strClass = "v_pink";
                            break;
                        case 14:
                            strClass = "v_blue";
                            break;
                        default:
                            strClass = "";
                            break;
                    }
                    return `<span class="EE ${strClass}">${objData_Dtt[index].EE.estado}</span>`;
                }()),
                objData_Dtt[index].Exam.Descrp,
                objData_Dtt[index].Desc,
                (function () {

                    let value = objData_Dtt[index].Res.value;
                    const valueAsFloat = parseFloat(`${value}`.replaceAll(",", "."));
                    //if(!isNaN(value)){
                    //    value = parseFloat(value);
                    //}

                    //value = value.toString;
                    //value = math.round(value);
                    let Stat_Valid = objData_Dtt[index].EE.value;
                    let stat = objData_Dtt[index].Stat;
                    let xParam;

                    if (objData_Dtt[index].Stat != null) {
                        stat = objData_Dtt[index].Stat.toLowerCase();
                    }
                    if (objData_Dtt[index].Desc.trim().toUpperCase() == `EDAD`) {
                        value = objData_Pac.EDAD.split(" ")[0];
                        objData_Dtt[index].Res.value = value;
                        filaPruebasEdad.push(index)
                    }
                    // obj con llave id prueba VFG mayor a 60 (VFG 2) y value VFG Formula (VFG
                    // si el paciente es mayor o igual a 60 años se guarda "Mayor a 60" en la prueba VFG mayor a 60
                    const idPruebasVFGMayorA60 = { "4232": 4230, "4237": 4236, "4465": 4464, "4470": 4469 };

                    const idPruebaActual = String(objData_Dtt[index].Exam.ID_EXA);

                    if (Object.keys(idPruebasVFGMayorA60).includes(idPruebaActual)) {

                        const vfgFormula = objData_Dtt.find(item => item.Exam.ID_EXA == idPruebasVFGMayorA60[idPruebaActual]);

                        const mayorA60 = vfgFormula.Res.value >= 60

                        value = mayorA60 ? 'Mayor a 60' : vfgFormula.Res.value || "";

                        objData_Dtt[index].Res.value = value;

                        filaVFGMayorA60.push(index);
                    }


                    if ((TOOL.fn_IsNumeric(objData_Dtt[index].Res.b1) == true) &&
                        (TOOL.fn_IsNumeric(objData_Dtt[index].Res.a1) == true) &&
                        (stat != "n") && (value != null) && (value != "") && (TOOL.fn_IsNumeric(`${value}`.replace(/\,/gi, ".")) == true)) {

                        //// console.log(objData_Dtt[index].Res.a1);

                        objData_Dtt[index].Res.a1 = math.round(parseFloat(objData_Dtt[index].Res.a1), objData_Dtt[index].Res.pruDecimal);
                        objData_Dtt[index].Res.b1 = math.round(parseFloat(objData_Dtt[index].Res.b1), objData_Dtt[index].Res.pruDecimal);

                        //// console.log(objData_Dtt[index].Res.a1);

                        if ((objData_Dtt[index].Res.b1 > parseFloat(value.toString().replace(/,/gi, "."))) ||
                            (objData_Dtt[index].Res.a1 < parseFloat(value.toString().replace(/,/gi, ".")))) {
                            xParam += ` class="input_error"`;
                        }
                        else if ((TOOL.fn_IsNumeric(value.toString().replace(/,/gi, ".")) == false) &&
                            (objData_Dtt[index].TT.ID_TD != 1)) {
                            xParam += ` class="input_error"`;
                        }
                    }
                    if ((Stat_Valid == 6) || (Stat_Valid == 14) || (objData_Dtt[index].TT.ID_TD == 4)) {
                        xParam += ` readonly`;
                    }
                    if ((value == null || value == "") && objData_Dtt[index].Res.pruCero == true) {
                        value = 0;     //PONE VALOR 0 AUTOMÁTICO
                    } else if (value == null && objData_Dtt[index].Res.pruCero == false) {
                        value = "";
                    }
                    else {
                        if (TOOL.fn_IsNumeric(value) == true) {
                            value = TOOL.fn_cutDecimals(math.round(String(value).replace(/\,/gi, "."), objData_Dtt[index].Res.pruDecimal), objData_Dtt[index].Res.pruDecimal);
                        }
                        value = String(value).replace(/\./gi, ",");
                    }
                    xParam += ` rows="1"`;
                    if (objData_Dtt[index].TT.ID_TD == 4) {
                        xParam += ` data-calc="true"`;
                    }

                    if (valueAsFloat >= parseFloat(objData_Dtt[index].Res.a2) && (objData_Dtt[index].Res.a2 != 0) && (objData_Dtt[index].Res.a1 != null) && (objData_Dtt[index].Res.b1 != null)) {
                        //// console.log("@@@@@@@@@@@@@@@@@@@@@ ALTO @@@@@@@@@@@@@@@@@@@@@");
                        let m_ID_RES = objData_Dtt[index].Res.ID_RES;
                        let m_Title = "Valor Crítico Alto";
                        let m_Text = "Estimado usuario, se detecto un valor crítico alto: <br> <b class='text-danger'>" + objData_Dtt[index].Desc + " : " + value + "</b>";
                        modal_Crit(m_ID_RES, m_Title, m_Text, _Z);
                        _Z -= 1;
                    } else if (valueAsFloat <= parseFloat(objData_Dtt[index].Res.b2) && (objData_Dtt[index].Res.b2 != 0) && (objData_Dtt[index].Res.a1 != null) && (objData_Dtt[index].Res.b1 != null)) {
                        //// console.log("@@@@@@@@@@@@@@@@@@@@@ BAJO @@@@@@@@@@@@@@@@@@@@@");
                        let m_ID_RES = objData_Dtt[index].Res.ID_RES;
                        let m_Title = "Valor Crítico Bajo";
                        let m_Text = "Estimado usuario, se detecto un valor crítico bajo: <br> <b class='text-danger'>" + objData_Dtt[index].Desc + " : " + value + "</b>";
                        modal_Crit(m_ID_RES, m_Title, m_Text, _Z);
                        _Z -= 1;
                    }

                    return `<input type="text" ${xParam} value="${value}" />`;
                }()),
                objData_Dtt[index].Unit,
                (function () {
                    let xVal = objData_Dtt[index].Stat;
                    if (xVal == null) {
                        xVal = "";
                    }
                    if ((xVal.toUpperCase() == "N") || (xVal.toUpperCase() == "")) {
                        return `<span class="td_stat">${xVal}</span>`;
                    }
                    else {
                        return `<span class="td_stat" style="color: #d30000;">${xVal}</span>`;
                    }
                }()),
                (function () {
                    let value = objData_Dtt[index].Res.b1;
                    let dec = objData_Dtt[index].Res.pruDecimal;
                    const text = objData_Dtt[index].Res.rfT;

                    if ([null, undefined, "", "null", "NULL"].includes(value) && text != null && text != "NULL") {
                        return ".";
                    }
                    else if ((TOOL.fn_IsNumeric(value) == true) && (TOOL.fn_IsNumeric(dec) == true) && (objData_Dtt[index].Res.rfT == "" || objData_Dtt[index].Res.rfT == "NULL" || objData_Dtt[index].Res.rfT == null)) {
                        value = String(TOOL.fn_cutDecimals(value, dec));
                        return String(value).replace(/\./gi, ",");
                    }
                    else if ((objData_Dtt[index].Res.rfT != "" && objData_Dtt[index].Res.rfT != "NULL" && objData_Dtt[index].Res.rfT != null) && (objData_Dtt[index].EE.value != 6 && objData_Dtt[index].EE.value != 14)) {
                        return '.';
                    }
                    else {
                        return value;
                    }

                }()),
                (function () {
                    let value = objData_Dtt[index].Res.a1;
                    const text = objData_Dtt[index].Res.rfT;
                    let dec = objData_Dtt[index].Res.pruDecimal;
                    const estVal = objData_Dtt[index].EE.value;

                    if (text && text != "NULL") {
                        return text;
                    } else if ((TOOL.fn_IsNumeric(value) == true) && (TOOL.fn_IsNumeric(dec) == true) && (text == "" || text == "NULL" || text == null)) {
                        value = String(TOOL.fn_cutDecimals(value, dec));
                        return String(value).replace(/\./gi, ",");
                    } else if ((text != "" && text != "NULL" && text != null) && [6, 14].includes(estVal)) {
                        return text;
                    } else {
                        return value;
                    }
                }()),
                (function () {
                    if (objData_Dtt[i].ReHi != null && objData_Dtt[i].ReHi != "") {
                        return `<span class="sp-hist" style="background-color: #34ebeb !important;">${objData_Dtt[i].ReHi}</span>`;
                    } else {
                        return "";
                    }
                }()),
                objData_Dtt[i].ReHi != null && objData_Dtt[i].ReHi != "" ? objData_Dtt[i].cDia.split(" ")[0] : "",
                objData_Dtt[i].cantidadDeHistoricos > 1 ? `<button type="button" class="btn btn-dark btn-sm"><i class="fa fa-clock-o" aria-hidden="true"></i></button>` : ""
            ], null, Bg_Arr);
            //// console.log(objData_Dtt);
        }
        Btn_Graph.setActive(false);
        Btn_Crit.setActive(false);
        Btn_Audit.setActive(false);
        Dtt_Exam.isClickeable = true;
        //Dtt_Exam.isDataTable = true;

        Dtt_Exam.updateTable("No se han encontrado exámenes.", 100);

        $("#Dtt_Exam button").on("click", () => {
            setTimeout(() => $("#Btn_Graph").trigger("click"), 100)
        });

        $("#Dtt_Exam input[type=text]").focusin((Me) => {
            $("#Dtt_Exam tbody tr").removeClass("tr_selected");
            // console.log("Focus In");
            $(Me.currentTarget).parents("tr").addClass("tr_selected");
            //$(Me.currentTarget).select();

        });

        $("#Dtt_Exam input[type=text]").on("blur", async (Me) => {
            flagSaveEnProceso = true;
            // console.log("Blur");
            if ($(Me.currentTarget).attr("readonly") == null) {
                //// console.log("Beep!")
                let xValue = $(Me.currentTarget).val();
                let xIndex = parseInt(Me.currentTarget.parentElement.parentElement.getAttribute("data-index"));

                if (TOOL.fn_IsNumeric(xValue.replace(/,/gi, ".")) == true) {
                    xValue = TOOL.fn_cutDecimals(xValue.replace(/,/gi, "."), objData_Dtt[xIndex].Res.pruDecimal, true);
                    xValue = parseFloat(xValue);
                }
                objData_Dtt[xIndex].Res.value = xValue;

                if (objData_Dtt[xIndex].Exam.ID_EXA == 4111 && objData_Dtt[xIndex].Res.value > 400) {

                    if ($("#mError_AAH_Trigliceridos").is(":visible") == false) {
                        $("#mError_AAH_Trigliceridos").modal();
                    }
                } else {
                    await fn_Write(Me)
                    await fn_Calc()

                }
            }

            if ($(Me.currentTarget).attr("readonly") == null) {
                if (keyEnter == false) {
                    let xItem = objData_Dtt[parseInt($(Me.currentTarget).parents("tr").attr("data-index"))];
                    let strOut;
                    if (xItem.Res.value == null && xItem.Res.pruCero == false) {
                        strOut = "";
                    }
                    else if (xItem.Res.value == null && xItem.Res.pruCero == true) {
                        strOut = "" + TOOL.fn_cutDecimals(0, xItem.Res.pruDecimal, false);
                    }
                    else {
                        if (TOOL.fn_IsNumeric(xItem.Res.value) == true) {
                            strOut = "" + TOOL.fn_cutDecimals(xItem.Res.value, xItem.Res.pruDecimal, false);
                        }
                        else {
                            strOut = `${xItem.Res.value}`;
                        }
                        strOut = `${strOut}`.replace(/\./gi, ",");
                    }
                    $(Me.currentTarget).val(strOut);
                }
            }

            keyEnter = false;
            flagSaveEnProceso = false;
        });

        $("#Dtt_Exam input[type=text]").keypress((Me) => {
            if (Me.which == 13) {
                if ($(Me.currentTarget).attr("readonly") == null) {

                    let xValue = $(Me.currentTarget).val();
                    let xIndex = parseInt(Dtt_Exam.tr_value);

                    if (TOOL.fn_IsNumeric(xValue.replace(/,/gi, ".")) == true) {
                        xValue = TOOL.fn_cutDecimals(xValue.replace(/,/gi, "."), objData_Dtt[xIndex].Res.pruDecimal, true);
                        xValue = parseFloat(xValue);
                    }
                    objData_Dtt[xIndex].Res.value = xValue;

                    if (objData_Dtt[xIndex].Exam.ID_EXA == 4111 && objData_Dtt[xIndex].Res.value > 400) {

                        if ($("#mError_AAH_Trigliceridos").is(":visible") == false) {
                            $("#mError_AAH_Trigliceridos").modal();
                        }
                    } else {
                        fn_Write(Me);
                        fn_Calc();
                        keyEnter = true;
                        $(Me.currentTarget).parents("tr").next().find("input[type=text]").focus();
                    }

                }
            }
        });

        $("#Dtt_Exam input[type=text]").keydown((Me) => {
            if (Me.which == 38) {
                //// console.log("KEY PRESS: "+Me.which);
                $(Me.currentTarget).parents("tr").prev().find("input[type=text]").focus();
            }
            else if (Me.which == 40) {
                //// console.log("KEY PRESS: "+Me.which);
                $(Me.currentTarget).parents("tr").next().find("input[type=text]").focus();
            } else {
                //// console.log("KEY PRESS: "+Me.which);
            }
        });
        $("#Dtt_Exam tbody tr").dblclick((Me) => {
            let xi = parseInt($(Me.currentTarget).attr("data-index"));
            let xItem = objData_Dtt[xi];
            if ((xItem.EE.value == 6) || (xItem.EE.value == 14)) {
                return;
            }
            //Llenado de Datos para el Modal
            $("#mdlResCodificados h4").html(function () {
                let strOut;
                switch (xItem.TT.ID_TD) {
                    case 1:
                        strOut = "Alfanumérico";
                        break;
                    case 2:
                        strOut = "Numérico";
                        break;
                    default:
                        strOut = "Fórmula";
                        break;
                }
                //return `<small>Opciones para Tipo de Dato</small> ${strOut}`
                //return `Opciones para Tipo de Dato <small>${strOut}</small>`
                return `Opciones para Tipo de Dato ${strOut}`;
            }());
            $("#mdlResCodificados .mini-table").empty();
            $("#mdlResCodificados").modal();
            Txt_ResCod_Det.value = xItem.Desc;
            if (xItem.Res.value != null) {
                Txt_ResCod_Out.value = `${xItem.Res.value}`;
            }
            else {
                Txt_ResCod_Out.value = "";
            }
            objAJAX_Get_Res_Cod.requestNow({
                ID_PRUEBA: xItem.Exam.ID_EXA
            });
        });
        $("#Dtt_Exam table").DataTable({
            //"iDisplayLength": 10,
            "info": false,
            "bPaginate": false,
            "bFilter": false,
            "bSort": false,
            "language": {
                "lengthMenu": "Mostrar: _MENU_",
                "zeroRecords": "No hay concidencias",
                "info": "Mostrando Página _PAGE_ de _PAGES_",
                "infoEmpty": "No hay concidencias",
                "infoFiltered": "(Se busco en _MAX_ registros )",
                "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>",
                "paginate": {
                    "previous": "Anterior",
                    "next": "Siguiente"
                }
            },
            fixedColumns: {
                heightMatch: 'none'
            }
        });
        filaVFGMayorA60.forEach(fila => {
            const resultadosExaEdad = objData_Dtt.filter(item => item.Exam.ID_CF == objData_Dtt[fila].Exam.ID_CF);
            if (!resultadosExaEdad) return;

            if (resultadosExaEdad.includes(item => [6, 14].includes(item.EE.value))) return;

            const selector = 'tr[data-index="' + fila + '"] td:nth-child(5) input[type="text"]';
            const inputElement = document.querySelector(selector);
            if (inputElement) {
                inputElement.dispatchEvent(new Event('blur'));
            }
        });
        if (updateEdad && filaPruebasEdad.length > 0) {

            filaPruebasEdad.forEach(fila => {

                const resultadosExaEdad = objData_Dtt.filter(item => item.Exam.ID_CF == objData_Dtt[fila].Exam.ID_CF);

                const idAteRes = objData_Dtt[fila].Res.ID_RES

                if (resultadosExaEdad.includes(item => [6, 14].includes(item.EE.value))) return;

                const idAtencion = objData_Pac.ID_ATENCION;

                let atencion = foliosEdadLista.find(item => item.idAtencion == idAtencion);

                if (!atencion) {
                    foliosEdadLista.push({ idAtencion, idAteRes: [] });
                }
                atencion = foliosEdadLista.find(item => item.idAtencion == idAtencion);

                if (atencion.idAteRes.includes(idAteRes)) return;

                atencion.idAteRes.push(idAteRes);

                const data = JSON.stringify({
                    ID_RES: idAteRes,
                    RES: objData_Dtt[fila].Res.value,
                })
                $.ajax({
                    "type": "POST",
                    "url": "Ate_Resultados_3.aspx/IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_TEXTO",
                    data,
                    "contentType": "application/json;  charset=utf-8",
                    "dataType": "json",
                });
                const selector = 'tr[data-index="' + fila + '"] td:nth-child(5) input[type="text"]';
                const inputElement = document.querySelector(selector);
                if (inputElement) {
                    inputElement.dispatchEvent(new Event('blur'));
                }
            });
            updateEdad = false;
        }
        $("#DataTables_Table_0").addClass("cell-border").colResizable();
    };
    function IRIS_WEBF_BUSCA_RESULTADO_ESTADO_ANTES_DE_VALIDAR(xIndex) {
        var strParam = JSON.stringify({
            "ID_ATE_RES": objData_Dtt[xIndex].Res.ID_RES
        });
        $.ajax({
            "type": "POST",
            "url": "Ate_Resultados_3.aspx/IRIS_WEBF_BUSCA_RESULTADO_ESTADO_ANTES_DE_VALIDAR",
            "data": strParam,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": function (response) {
                var json_receiver = response.d;
                // console.log(json_receiver);
                if (json_receiver != "null") {
                    if (json_receiver != 0) {
                        // console.log("VALIDADO!");
                        if ($("#mError_AAH_Consulta").is(":visible") == false) {
                            $("#mError_AAH_Consulta").modal();
                        }
                    } else {
                        // console.log("DISPONIBLE");
                    }
                }
            }
        });
    }
    let fn_Write = async (Me) => {
        flagSaveEnProceso = true;
        let xIndex = parseInt(Me.currentTarget.parentElement.parentElement.getAttribute("data-index"));

        let xValue = String($(Me.currentTarget).val()).trim();

        let xStat;
        let xParam;

        if (TOOL.fn_IsNumeric(xValue.replace(/,/gi, ".")) == true) {
            xValue = TOOL.fn_cutDecimals(xValue.replace(/,/gi, "."), objData_Dtt[xIndex].Res.pruDecimal, true);
            xValue = parseFloat(xValue);
        }
        objData_Dtt[xIndex].Res.value = xValue;

        if (objData_Dtt[xIndex].Exam.ID_EXA == 4111 && objData_Dtt[xIndex].Res.value > 400) {
            //console.log("triglicéridos > 400!");

            if ($("#mError_AAH_Trigliceridos").is(":visible") == false) {
                $("#mError_AAH_Trigliceridos").modal();
            }
        } else {
            // console.log("triglicéridos menor");
            const objRes = objData_Dtt[xIndex];
            xStat = (function () {

                // console.log("ID_TD: "+objData_Dtt[xIndex].TT.ID_TD);
                if (objData_Dtt[xIndex].TT.ID_TD == 1) {
                    if ((TOOL.fn_IsNumeric(xValue) == true) &&
                        ((TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.b2) == true) ||
                            (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.b1) == true) ||
                            (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.a1) == true) ||
                            (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.a2) == true)) &&
                        (objData_Dtt[xIndex].Res.b2 < objData_Dtt[xIndex].Res.b1) &&
                        ((objData_Dtt[xIndex].Res.a2 > objData_Dtt[xIndex].Res.a1))) {

                        if (objData_Dtt[xIndex].Res.b2 > xValue) {
                            // CRIT BAJO
                            return -2;
                        } else if (objData_Dtt[xIndex].Res.a2 < xValue) {
                            // CRIT ALTO
                            return 2;
                        } else if (objData_Dtt[xIndex].Res.b1 > xValue) {
                            // BAJO
                            return -1;
                        } else if (objData_Dtt[xIndex].Res.a1 < xValue) {
                            // ALTO
                            return 1;
                        } else {
                            // NORMAL
                            return 0;
                        }
                    }
                    else if ((TOOL.fn_IsNumeric(xValue) == true) &&
                        (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.b1) == true) &&
                        (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.a1) == true)) {
                        if (objData_Dtt[xIndex].Res.b1 > xValue) {
                            return -1;
                        } else if (objData_Dtt[xIndex].Res.a1 < xValue) {
                            return 1;
                        } else {
                            return 0;
                        }
                    }
                    else {
                        return null;
                    }
                }
                else if (objData_Dtt[xIndex].TT.ID_TD == 2) {
                    if ((TOOL.fn_IsNumeric(xValue) == true) &&
                        (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.b2) == true) &&
                        (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.b1) == true) &&
                        (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.a1) == true) &&
                        (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.a2) == true) &&
                        (objData_Dtt[xIndex].Res.b2 < objData_Dtt[xIndex].Res.b1) &&
                        ((objData_Dtt[xIndex].Res.a2 > objData_Dtt[xIndex].Res.a1))) {
                        if (objData_Dtt[xIndex].Res.b2 > xValue) {
                            // CRIT BAJO
                            return -2;
                        } else if (objData_Dtt[xIndex].Res.a2 < xValue) {
                            // CRIT ALTO
                            return 2;
                        } else if (objData_Dtt[xIndex].Res.b1 > xValue) {
                            // BAJO
                            return -1;
                        } else if (objData_Dtt[xIndex].Res.a1 < xValue) {
                            // ALTO
                            return 1;
                        } else {
                            // NORMAL
                            return 0;
                        }
                    }
                    else if ((TOOL.fn_IsNumeric(xValue) == true) &&
                        (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.b1) == true) &&
                        (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.a1) == true)) {
                        if (objData_Dtt[xIndex].Res.b1 > xValue) {
                            return -1;
                        }
                        else if (objData_Dtt[xIndex].Res.a1 < xValue) {
                            return 1;
                        }
                        else {
                            return 0;
                        }
                    }
                    else {
                        return null;
                    }
                }
                else if (objData_Dtt[xIndex].TT.ID_TD == 4) {
                    return;
                }
            }());
            if (xStat == 9000) {
                objData_Dtt[xIndex].Stat = "";
            }
            else if (xStat < 0) {
                objData_Dtt[xIndex].Stat = "B";
            }
            else if (xStat > 0) {
                objData_Dtt[xIndex].Stat = "A";
            }
            else if (xStat == 0) {
                objData_Dtt[xIndex].Stat = "N";
            }
            else {
                objData_Dtt[xIndex].Stat = "";
            }
            let _Z = 1100;
            if (xStat === 2) {
                let m_ID_RES = objRes.Res.ID_RES;
                let m_Title = "Valor Crítico Alto";
                let m_Text = "Estimado usuario, se detecto un valor crítico alto: <br> <b class='text-danger'>" + objRes.Desc + " : " + xValue + "</b>";
                modal_Crit(m_ID_RES, m_Title, m_Text, _Z);
                _Z -= 1;
            } else if (xStat === -2) {
                let m_ID_RES = objRes.Res.ID_RES;
                let m_Title = "Valor Crítico Bajo";
                let m_Text = "Estimado usuario, se detecto un valor crítico bajo: <br> <b class='text-danger'>" + objRes.Desc + " : " + xValue + "</b>";
                modal_Crit(m_ID_RES, m_Title, m_Text, _Z);
                _Z -= 1;
            }


            xValue = TOOL.fn_cutDecimals(String(xValue), objData_Dtt[xIndex].Res.pruDecimal, true).trim().replace(/\./gi, ",");
            const esCero = parseFloat(TOOL.fn_cutDecimals(parseFloat(`${xValue}`.replace(/,/gi, ".")), objData_Dtt[xIndex].Res.pruDecimal, true)) === 0;
            const esNumerico = !isNaN(`${xValue}`.replace(/,/gi, "."))

            if (objData_Dtt[xIndex].Res.pruCero == false && esCero && esNumerico) {
                xValue = "";
                objData_Dtt[xIndex].Stat = "";
                $(Me.currentTarget).attr("class", "input_error");
            }
            else {
                if ((objData_Dtt[xIndex].Stat == "") && (xStat == null)) {
                    $(Me.currentTarget).removeAttr("class");
                }
                else if (objData_Dtt[xIndex].Stat == "N") {
                    $(Me.currentTarget).removeAttr("class");
                }
                else {
                    $(Me.currentTarget).attr("class", "input_error");
                }
            }

            $(Me.currentTarget).val(xValue);
            $(Me.currentTarget).parents("tr").find(".td_stat").text(objData_Dtt[xIndex].Stat);
            if ((objData_Dtt[xIndex].Stat.toLocaleUpperCase() != "N") && (objData_Dtt[xIndex].Stat.trim() != "")) {
                $(Me.currentTarget).parents("tr").find(".td_stat").css({
                    color: "#d50000"
                });
            } else {
                $(Me.currentTarget).parents("tr").find(".td_stat").css({
                    color: "#212529"
                });
            }
            if (objData_Dtt[xIndex].TT.ID_TD != 1) {
                objWrite.URL = `Ate_Resultados_3.aspx/IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_NUMERICO`;
                objWrite.Param = {
                    ID_RES: objData_Dtt[xIndex].Res.ID_RES,
                    RES: xValue,
                };
            } else {
                objWrite.URL = `Ate_Resultados_3.aspx/IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_TEXTO`;
                objWrite.Param = {
                    ID_RES: objData_Dtt[xIndex].Res.ID_RES,
                    RES: xValue
                };
            }

            //11111111111111111111111111111111111111111111111111111111111   
            //IRIS_WEBF_BUSCA_RESULTADO_ESTADO_ANTES_DE_VALIDAR(xIndex);
            // console.log("111");
            //11111111111111111111111111111111111111111111111111111111111

            objAJAX_Write.URL = objWrite.URL;
            await objAJAX_Write.requestNow(objWrite.Param);
            flagSaveEnProceso = false
        }
    };

    let fn_Write_2 = async (Me_Ind, Me_Val) => {

        let xValue = Me_Val;
        //// console.log("@@@@@ Val: "+xValue);
        let xIndex = Me_Ind;
        //// console.log("@@@@@ Ind: "+xIndex);
        let xStat;
        let xParam;
        //Evaluar Valor
        xValue = String(xValue).trim();
        if (TOOL.fn_IsNumeric(xValue.replace(/,/gi, ".")) == true) {
            xValue = TOOL.fn_cutDecimals(xValue.replace(/,/gi, "."), objData_Dtt[xIndex].Res.pruDecimal, true);
            xValue = parseFloat(xValue);
        }

        // console.log(xValue);
        objData_Dtt[xIndex].Res.value = xValue;
        var objItem = objData_Dtt[xIndex].Res;
        xStat = (function () {
            if (objData_Dtt[xIndex].TT.ID_TD == 1) {
                if ((TOOL.fn_IsNumeric(xValue) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.b2) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.b1) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.a1) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.a2) == true) &&
                    (objData_Dtt[xIndex].Res.b2 < objData_Dtt[xIndex].Res.b1) &&
                    ((objData_Dtt[xIndex].Res.a2 > objData_Dtt[xIndex].Res.a1))) {
                    if (objData_Dtt[xIndex].Res.b2 > xValue) {
                        return -2;
                    }
                    else if (objData_Dtt[xIndex].Res.a2 < xValue) {
                        return 2;
                    }
                    else if (objData_Dtt[xIndex].Res.b1 > xValue) {
                        return -1;
                    }
                    else if (objData_Dtt[xIndex].Res.a1 < xValue) {
                        return 1;
                    }
                    else {
                        return 0;
                    }
                }
                else if ((TOOL.fn_IsNumeric(xValue) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.b1) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.a1) == true)) {
                    if (objData_Dtt[xIndex].Res.b1 > xValue) {
                        return -1;
                    }
                    else if (objData_Dtt[xIndex].Res.a1 < xValue) {
                        return 1;
                    }
                    else {
                        return 0;
                    }
                }
                else {
                    return null;
                }
            }
            else if (objData_Dtt[xIndex].TT.ID_TD == 2) {
                if ((TOOL.fn_IsNumeric(xValue) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.b2) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.b1) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.a1) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.a2) == true) &&
                    (objData_Dtt[xIndex].Res.b2 < objData_Dtt[xIndex].Res.b1) &&
                    ((objData_Dtt[xIndex].Res.a2 > objData_Dtt[xIndex].Res.a1))) {
                    if (objData_Dtt[xIndex].Res.b2 > xValue) {
                        return -2;
                    }
                    else if (objData_Dtt[xIndex].Res.a2 > xValue) {
                        return 2;
                    }
                    else if (objData_Dtt[xIndex].Res.b1 < xValue) {
                        return -1;
                    }
                    else if (objData_Dtt[xIndex].Res.a1 < xValue) {
                        return 1;
                    }
                    else {
                        return 0;
                    }
                }
                else if ((TOOL.fn_IsNumeric(xValue) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.b1) == true) &&
                    (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.a1) == true)) {
                    if (objData_Dtt[xIndex].Res.b1 > xValue) {
                        return -1;
                    }
                    else if (objData_Dtt[xIndex].Res.a1 < xValue) {
                        return 1;
                    }
                    else {
                        return 0;
                    }
                }
                else {
                    return null;
                }
            }
            else if (objData_Dtt[xIndex].TT.ID_TD == 4) {
                //Fórmulaaaaaaaaaaaaaaaa
                return;
            }
        }());
        if (xStat == 9000) {
            objData_Dtt[xIndex].Stat = "";
        }
        else if (xStat < 0) {
            objData_Dtt[xIndex].Stat = "B";
        }
        else if (xStat > 0) {
            objData_Dtt[xIndex].Stat = "A";
        }
        else if (xStat == 0) {
            objData_Dtt[xIndex].Stat = "N";
        }
        else {
            objData_Dtt[xIndex].Stat = "";
        }
        //Validar ceros
        xValue = TOOL.fn_cutDecimals(String(xValue), objData_Dtt[xIndex].Res.pruDecimal, true).trim().replace(/\./gi, ",");
        if ((objData_Dtt[xIndex].Res.pruCero == false) &&
            (parseFloat(TOOL.fn_cutDecimals(parseFloat(`${xValue}`.replace(/,/gi, ".")), objData_Dtt[xIndex].Res.pruDecimal, true)) === 0)) {
            xValue = "";
            objData_Dtt[xIndex].Stat = "";
            //$(Me.currentTarget).attr("class", "input_error");
        }
        else {
            if ((objData_Dtt[xIndex].Stat == "") && (xStat == null)) {
                //$(Me.currentTarget).removeAttr("class");
            }
            else if (objData_Dtt[xIndex].Stat == "N") {
                //$(Me.currentTarget).removeAttr("class");
            }
            else {
                //$(Me.currentTarget).attr("class", "input_error");
            }
        }
        //// console.clear();

        //// console.log(Me);

        // console.log(`Val REF: [${objData_Dtt[xIndex].Res.PRU_COD}] -> ${objData_Dtt[xIndex].Desc}\nB2 = ${objData_Dtt[xIndex].Res.b2}\nB1 = ${objData_Dtt[xIndex].Res.b1}\nA1 = ${objData_Dtt[xIndex].Res.a1}\nA2 = ${objData_Dtt[xIndex].Res.a2}`);
        //// console.log(`Value = ${$(Me.currentTarget).val()}; ValueParsed = ${TOOL.fn_cutDecimals(xValue, objData_Dtt[xIndex].Res.pruDecimal, true)}; Stat = ${xStat}\nTipo Dato = ${objData_Dtt[xIndex].TT.ID_TD}\nDecimales = ${objData_Dtt[xIndex].Res.pruDecimal}\nAcepta Ceros = ${objData_Dtt[xIndex].Res.pruCero}\n\n`);
        //$(Me.currentTarget).val(xValue);
        //$(Me.currentTarget).parents("tr").find(".td_stat").text(objData_Dtt[xIndex].Stat);
        if ((objData_Dtt[xIndex].Stat.toLocaleUpperCase() != "N") && (objData_Dtt[xIndex].Stat.trim() != "")) {
            //$(Me.currentTarget).parents("tr").find(".td_stat").css({
            //    color: "#d50000"
            //});
        }
        else {
            //$(Me.currentTarget).parents("tr").find(".td_stat").css({
            //    color: "#212529"
            //});
        }
        if (objData_Dtt[xIndex].TT.ID_TD != 1) {
            objWrite.URL = `Ate_Resultados_3.aspx/IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_NUMERICO`;
            objWrite.Param = {
                ID_RES: objData_Dtt[xIndex].Res.ID_RES,
                RES: xValue,
            };
        }
        else {
            objWrite.URL = `Ate_Resultados_3.aspx/IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_TEXTO`;
            objWrite.Param = {
                ID_RES: objData_Dtt[xIndex].Res.ID_RES,
                RES: xValue
            };
        }

        //222222222222222222222222222222222222222222222222222222
        //IRIS_WEBF_BUSCA_RESULTADO_ESTADO_ANTES_DE_VALIDAR(xIndex);
        // console.log("222");
        //222222222222222222222222222222222222222222222222222222

        objAJAX_Write.URL = objWrite.URL;
        await objAJAX_Write.requestNow(objWrite.Param);
    };

    let flagSaveEnProceso = false;
    let fn_Calc = async () => {
        flagSaveEnProceso = true;
        const formulasConFormulas = [];
        let fn_Proc = async (xItem, miii) => {
            let calc = xItem.vector;

            let arrREE = [];
            let xInput = "";
            if (calc.match(/\[([a-z]|[a-z.]|[0-9]|-|_)+\]/gi) != null) {
                calc.match(/\[([a-z]|[a-z.]|[0-9]|-|_)+\]/gi).forEach((lol) => {
                    let _text = lol;
                    let _value = null;
                    objData_Dtt.forEach((kek, index) => {

                        if (kek.Exam.ID_EXA == 4111 && kek.Res.value > 400) {
                            if ($("#mError_AAH_Trigliceridos").is(":visible") == false) {
                                $("#mError_AAH_Trigliceridos").modal();
                            }
                            return
                        }

                        if (_text == `[${kek.Res.PRU_COD}]`) {
                            _value = parseFloat(`${kek.Res.value}`.replace(/,/gi, "."));

                            if ((_value == "" || _value == null || isNaN(_value) == true) && kek.Res.pruCero == true) {
                                // console.log("If 1");
                                _value = parseFloat("0");
                                let reg = new RegExp(`\\[${kek.Res.PRU_COD}\\]`, `gi`);
                                calc = calc.replace(reg, `${_value}`);
                                calc = calc.replace(/,/gi, ".");
                            }
                            else if (TOOL.fn_IsNumeric(_value) == false && kek.Res.pruCero == false) {
                                _value = null;
                                // console.log("If 2");
                            }
                            else {
                                let reg = new RegExp(`\\[${kek.Res.PRU_COD}\\]`, `gi`);
                                calc = calc.replace(reg, `${_value}`);
                                calc = calc.replace(/,/gi, ".");
                                // console.log("If 3");
                            }
                            // console.log(_value);
                            arrREE.push({
                                string: `${_text} -> ${kek.Exam.Descrp} - ${kek.Desc}`,
                                value: `${_value}`
                            });
                        }
                    });
                });
                // console.log(`Fórmula Position ${miii}:`);
                // console.log(`Fórmula RAW: ${xItem.vector}`);
                // console.log(arrREE);
                xInput = $(`#Dtt_Exam table tbody tr[data-index="${miii}"] input`);
            }

            // console.log(calc);
            if (calc.match(/\[([a-z]|[a-z.]|[0-9]|-|_)+\]/gi) == null) {

                let result = `${math.eval(calc)}`;

                if (isNaN(result)) return;
                result = TOOL.fn_cutDecimals(math.round(result, objData_Dtt[miii].Res.pruDecimal), objData_Dtt[miii].Res.pruDecimal, true);
                result = `${result}`.replace(/\./gi, ",");
                objData_Dtt[miii].Res.value = parseFloat(result.replace(/,/gi, "."));
                xInput.val(result);
                //Comparar con Rangos de Referencia
                if ((TOOL.fn_IsNumeric(objData_Dtt[miii].Res.b1) == true) || (TOOL.fn_IsNumeric(objData_Dtt[miii].Res.a1) == true)) {
                    if (objData_Dtt[miii].Res.b1 > objData_Dtt[miii].Res.value) {
                        xInput.parents("tr").find(".td_stat").text("B");
                        xInput.parents("tr").find(".td_stat").css({ "color": "rgb(213, 0, 0)" });
                        xInput.addClass("input_error");
                    }
                    else if (objData_Dtt[miii].Res.a1 < objData_Dtt[miii].Res.value) {
                        xInput.parents("tr").find(".td_stat").text("A");
                        xInput.parents("tr").find(".td_stat").css({ "color": "rgb(213, 0, 0)" });
                        xInput.addClass("input_error");
                    }
                    else {
                        xInput.parents("tr").find(".td_stat").text("N");
                        xInput.parents("tr").find(".td_stat").removeAttr("style");
                        xInput.removeClass("input_error");
                    }
                }
                objWrite.URL = `Ate_Resultados_3.aspx/IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_NUMERICO`;
                objWrite.Param = {
                    ID_RES: objData_Dtt[miii].Res.ID_RES,
                    RES: result.replace(/\./gi, ","),
                    EVAL: result
                };
                objAJAX_Write.URL = objWrite.URL;
                await objAJAX_Write.requestNow(objWrite.Param);



                // obj con llave id prueba VFG mayor a 60 (VFG 2) y value VFG Formula (VFG
                // si el paciente es mayor o igual a 60 años se guarda "Mayor a 60" en la prueba VFG mayor a 60
                const idPruebasVFGMayorA60 = { "4232": 4230, "4237": 4236, "4465": 4464, "4470": 4469 };

                const idPruebaFormulaUpdated = objData_Dtt[miii].Exam.ID_EXA;
                if (Object.values(idPruebasVFGMayorA60).includes(idPruebaFormulaUpdated)) {
                    const vfgFormula = objData_Dtt[miii];

                    const idMayorA60 = Object.keys(idPruebasVFGMayorA60).find(item => idPruebasVFGMayorA60[item] == vfgFormula.Exam.ID_EXA);

                    const resultadoMayor60 = objData_Dtt.find(item => item.Exam.ID_EXA == idMayorA60);

                    const formulaEsMayorA60 = vfgFormula.Res.value >= 60;
                    let valorVFGFormula = formulaEsMayorA60 ? 'Mayor a 60' : vfgFormula.Res.value || "";

                    if (typeof valorVFGFormula === "number") {
                        valorVFGFormula = valorVFGFormula.toLocaleString("es-CL").replaceAll(".", "")
                    }

                    resultadoMayor60.Res.value = valorVFGFormula;
                    //console.log(resultadoMayor60);
                    if (!resultadoMayor60) return;
                    const data = JSON.stringify({
                        ID_RES: resultadoMayor60.Res.ID_RES,
                        RES: resultadoMayor60.Res.value,
                    });
                    $.ajax({
                        "type": "POST",
                        "url": "Ate_Resultados_3.aspx/IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_TEXTO",
                        data,
                        "contentType": "application/json;  charset=utf-8",
                        "dataType": "json",
                        success: () => {
                            const indiceDeMayor60 = objData_Dtt.findIndex(item => item.Exam.ID_EXA == idMayorA60);
                            const inputDelMayorA60 = $(`#Dtt_Exam table [data-index="${indiceDeMayor60}"] input[type="text"]`)[0];
                            inputDelMayorA60.value = resultadoMayor60.Res.value
                        }
                    });

                }
            }
            else {
                //// console.log(`\n`);
                xInput.val("");
                objData_Dtt[miii].Res.value = null;
                return { objetoRes: objData_Dtt[miii], indice: miii };
            }
        };

        for (let i = 0; i < objData_Dtt.length; i++) {
            if (objData_Dtt[i].TT.ID_TD == 4) {
                const sinCalcular = await fn_Proc(objData_Dtt[i].Res, i);
                sinCalcular && formulasConFormulas.push(sinCalcular);
            }
        }

        for (let i = 0; i < formulasConFormulas.length; i++) {
            await fn_Proc(formulasConFormulas[i].objetoRes.Res, formulasConFormulas[i].indice);
        }

        flagSaveEnProceso = false
    };
    let fn_Activate_Validator = () => {
        if ((Sel_Secc.getValue().text == "<< Todos >>") && (Sel_Exam.getValue().value == 0)) {

            Btn_Graph.setActive(false);
            Btn_Crit.setActive(false);
            return;
        }
        Btn_Validar.setActive(true);
        Btn_Desvalidar.setActive(true);
        Btn_Print.setActive(true);

        Btn_Revisar.setActive(true);
        Btn_Not_Revisar.setActive(true);
    };

    function Check_Valida(Id_Ate, id_CF) {
        let ret;
        var strParam = JSON.stringify({
            "ID_ATE": Id_Ate,
            "ID_CF": id_CF
        });
        $.ajax({
            "type": "POST",
            "url": "Ate_Resultados_3.aspx/Check_Valida",
            "data": strParam,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": data => {
                //// console.log(data.d);
                ret = data.d;
            },
            "async": false,
            "error": data => {
            }
        });
        return ret;
    }

    let fn_Validate = async () => {
        modal_show();

        let xTR = $("#Dtt_Exam tbody tr");
        let arrIndex_Success = [];
        let arrErr = [];
        //// console.clear();
        // console.log(`Exámenes por Validar:`);
        let v_Id_Cf = "";
        let v_Cons;
        for (let i = 0; i < xTR.length; i++) {

            let xIndex = parseInt(xTR.eq(i).attr("data-index"));
            var xItem = objData_Dtt[xIndex];

            // BUSCA SI ESTA VALIDADO

            if (v_Id_Cf == "") {
                v_Id_Cf = xItem.Exam.ID_CF;
                v_Cons = 0; // Check_Valida(ID_ATE,v_Id_Cf);

                // console.log("ID_CF "+v_Id_Cf+" v_Cons: "+v_Cons);

            } else if (v_Id_Cf != xItem.Exam.ID_CF) {
                v_Id_Cf = xItem.Exam.ID_CF;
                v_Cons = 0; // Check_Valida(ID_ATE,v_Id_Cf);

                // console.log("ID_CF "+v_Id_Cf+" v_Cons: "+v_Cons);
            }

            if (v_Id_Cf == xItem.Exam.ID_CF && v_Cons == 0) {
                // console.log("Se puede validar ["+xItem.Exam.Descrp+"] - "+xItem.Desc);
                //// console.log(xItem);

                if (((xItem.Res.value == null) || (xItem.Res.value.toString().trim() == "")) && (xItem.Res.pruCero == true)) {
                    xItem.Res.value = TOOL.fn_cutDecimals(0, xItem.Res.pruDecimal, false);
                    // console.log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> IF GUARDAR RESULTADO");
                    let Me_Val = xTR[xIndex].children[4].children[0].value;
                    let Me_Ind = xIndex
                    await fn_Write_2(Me_Ind, Me_Val);
                }

                if ((xItem.EE.value != 6) && (xItem.EE.value != 14)) {
                    let bolHasValue = false;
                    if ((xItem.Res.value != null) && (xItem.Res.value.toString().trim() != "")) {
                        bolHasValue = true;
                    }
                    // console.groupCollapsed(`[${xItem.Exam.ID_CF}] => ${xItem.Exam.Descrp} - ${xItem.Desc}`);
                    // console.log(`Obligatorio = ${xItem.Res.NEED_VALIDATE}\nTiene Valor = ${bolHasValue}\n`);
                    // console.groupEnd();
                    if (bolHasValue == true) {
                        arrIndex_Success.push(xIndex);
                    }
                    else {
                        if (xItem.Res.NEED_VALIDATE == true) {
                            let fn_Add_CF_Error = () => {
                                arrErr.push({
                                    ID_CF: xItem.Exam.ID_CF,
                                    arrParam: [
                                        {
                                            ID_RES: xItem.Res.ID_RES,
                                            DESCR: `${xItem.Exam.Descrp} - ${xItem.Desc}`
                                        }
                                    ]
                                });
                            };
                            if (arrErr.length == 0) {
                                fn_Add_CF_Error();
                            }
                            else {
                                let Index_E = arrErr.DeepSearch("ID_CF", xItem.Exam.ID_CF);
                                if (Index_E == null) {
                                    fn_Add_CF_Error();
                                }
                                else {
                                    arrErr[Index_E].arrParam.push({
                                        ID_RES: xItem.Res.ID_RES,
                                        DESCR: `${xItem.Exam.Descrp} - ${xItem.Desc}`
                                    });
                                }
                            }
                        }
                    }
                }

                $(document).scrollTop(100);
            } else {
                // console.log("No se puede validar ["+xItem.Exam.Descrp+"] - "+xItem.Desc);
            }


        }
        if (arrErr.length > 0) {
            // console.error(`<<ERROR - VALIDACIÓN DENEGADA>>`);
            $(`#mdlValidateError .modal-body ul`).empty();
            for (let riii of arrErr) {
                for (let reee of riii.arrParam) {
                    $(`#mdlValidateError .modal-body ul`).append($(`<li>`).text(reee.DESCR));
                }
            }
            $(`#mdlValidateError`).modal();
        }

        const { recepcionado, rechazado } = objData_Dtt[0];

        //if (!recepcionado) {
        //    Swal.fire({
        //        icon: "warning",
        //        title: "Advertencia Recepción",
        //        html: "Para validar un resultado, es necesario que haya sido recepcionado tanto en el Laboratorio como en la Sección correspondiente. <br/>¡Por favor, asegúrate de que ambos pasos se hayan completado antes de validar el resultado!"
        //    });

        //    Hide_Modal();
        //    return;
        //}



        let Obj_Valid = [];
        for (let i of arrIndex_Success) {
            let fn_UltraSearch = () => {
                for (let riii of arrErr) {
                    if (riii.ID_CF == objData_Dtt[i].Exam.ID_CF) {
                        return true;
                    }
                }
                return false;
            };
            if (fn_UltraSearch() == false) {
                //objAJAX_Validate.requestNow({

                //});

                let Item_Valid;

                Item_Valid = {
                    ID_ATE_RES: objData_Dtt[i].Res.ID_RES,
                    DESDE: (function () {
                        let xVal = objData_Dtt[i].Res.b1;
                        if (TOOL.fn_IsNumeric(xVal) == true) {
                            let dec = objData_Dtt[i].Res.pruDecimal;
                            xVal = TOOL.fn_cutDecimals(xVal, dec, true);
                            xVal = `${xVal}`.replace(/\./gi, ",");
                        }
                        if (objData_Dtt[i].Res.rfT != "" && objData_Dtt[i].Res.rfT != "NULL" && objData_Dtt[i].Res.rfT != null) {
                            xVal = ".";
                        }
                        return xVal;
                    }()),
                    HASTA: (function () {
                        let xVal = objData_Dtt[i].Res.a1;
                        if (TOOL.fn_IsNumeric(xVal) == true) {
                            let dec = objData_Dtt[i].Res.pruDecimal;
                            xVal = TOOL.fn_cutDecimals(xVal, dec, true);
                            xVal = `${xVal}`.replace(/\./gi, ",");
                        }
                        if (objData_Dtt[i].Res.rfT != "" && objData_Dtt[i].Res.rfT != "NULL" && objData_Dtt[i].Res.rfT != null) {
                            xVal = objData_Dtt[i].Res.rfT;
                        }
                        return xVal;
                    }()),
                    AB: objData_Dtt[i].Stat,
                    MUY_DESDE: (function () {
                        let xVal = objData_Dtt[i].Res.b2;
                        if (TOOL.fn_IsNumeric(xVal) == true) {
                            let dec = objData_Dtt[i].Res.pruDecimal;
                            xVal = TOOL.fn_cutDecimals(xVal, dec, true);
                            xVal = `${xVal}`.replace(/\./gi, ",");
                        }
                        return xVal;
                    }()),
                    MUY_HASTA: (function () {
                        let xVal = objData_Dtt[i].Res.a2;
                        if (TOOL.fn_IsNumeric(xVal) == true) {
                            let dec = objData_Dtt[i].Res.pruDecimal;
                            xVal = TOOL.fn_cutDecimals(xVal, dec, true);
                            xVal = `${xVal}`.replace(/\./gi, ",");
                        }
                        return xVal;
                    }()),
                    MUY_AB: (function () {

                        // RR ALTOBAJO
                        let value = `${objData_Dtt[i].Res.value}`.replaceAll(",", ".");
                        let output = 0;
                        let b2 = objData_Dtt[i].Res.b2;
                        let a2 = objData_Dtt[i].Res.a2;
                        if (TOOL.fn_IsNumeric(b2) == true) {
                            if (b2 >= parseFloat(`${value}`.trim()) && (objData_Dtt[i].Res.b2 != 0)) {
                                output = 1;
                            }
                        }
                        if (TOOL.fn_IsNumeric(a2) == true) {
                            if (a2 <= parseFloat(`${value}`.trim()) && (objData_Dtt[i].Res.a2 != 0)) {
                                output = 2;
                            }
                        }
                        return output;
                    }()),
                    UNIDADES: objData_Dtt[i].Unit,
                    VALUE: objData_Dtt[i].Res.value
                };
                Obj_Valid.push(Item_Valid);
                objData_Dtt[i].EE.value = 6;
                objData_Dtt[i].EE.estado = "V";
                $(`tr[data-index=${i}] td`).eq(1).html(objData_Dtt[i].EE.estado);
            }
        }
        //// console.log(Obj_Valid);
        await objAJAX_Validate.requestNow({ "Obj_Valid": Obj_Valid });
        // console.log("make table 2");

    };
    let fn_Unvalidate = () => {

        modal_show();

        let xTR = $("#Dtt_Exam tbody tr");
        let arrIndex_Success = [];
        let arrErr = [];
        //// console.clear();
        // console.log(`Exámenes por Desvalidar:`);
        let is_revised = false;
        for (let i = 0; i < xTR.length; i++) {
            let xIndex = parseInt(xTR.eq(i).attr("data-index"));
            var xItem = objData_Dtt[xIndex];

            if (((xItem.Res.value == null) || (xItem.Res.value.toString().trim() == "")) && (xItem.Res.pruCero == true)) {
                xItem.Res.value = TOOL.fn_cutDecimals(0, xItem.Res.pruDecimal, false);
            }

            if (xItem.Exam.EST_REV == 1) {
                is_revised = true;
            }

            if ((xItem.EE.value == 6 || xItem.EE.value == 14) && xItem.Exam.EST_REV != 1) {
                console.log("xItem", xItem)
                let bolHasValue = false;
                if ((xItem.Res.value != null) && (xItem.Res.value.toString().trim() != "")) {
                    bolHasValue = true;
                }
                // console.groupCollapsed(`[${xItem.Exam.ID_CF}] => ${xItem.Exam.Descrp} - ${xItem.Desc}`);
                // console.log(`Obligatorio = ${xItem.Res.NEED_VALIDATE}\nTiene Valor = ${bolHasValue}\n`);
                // console.groupEnd();

                arrIndex_Success.push(xIndex);

                //if (bolHasValue == true) {
                //    arrIndex_Success.push(xIndex);
                //}
                //else {
                //    if (xItem.Res.NEED_VALIDATE == true) {
                //        let fn_Add_CF_Error = () => {
                //            arrErr.push({
                //                ID_CF: xItem.Exam.ID_CF,
                //                arrParam: [
                //                    {
                //                        ID_RES: xItem.Res.ID_RES,
                //                        DESCR: `${xItem.Exam.Descrp} - ${xItem.Desc}`
                //                    }
                //                ]
                //            });
                //        };
                //        if (arrErr.length == 0) {
                //            fn_Add_CF_Error();
                //        }
                //        else {
                //            let Index_E = arrErr.DeepSearch("ID_CF", xItem.Exam.ID_CF);
                //            if (Index_E == null) {
                //                fn_Add_CF_Error();
                //            }
                //            else {
                //                arrErr[Index_E].arrParam.push({
                //                    ID_RES: xItem.Res.ID_RES,
                //                    DESCR: `${xItem.Exam.Descrp} - ${xItem.Desc}`
                //                });
                //            }
                //        }
                //    }
                //}
            }
        }


        if (is_revised) {
            Hide_Modal();
           return Swal.fire({
                icon: "warning",
                title: "Aviso",
                text: "Estimado usuario este examen no se puede desvalidar por que se encuentra revisado"
            });
        }

        if (arrErr.length > 0) {
            // console.error(`<<ERROR - DESVALIDACIÓN DENEGADA>>`);
            $(`#mdlValidateError .modal-body ul`).empty();
            for (let riii of arrErr) {
                for (let reee of riii.arrParam) {
                    $(`#mdlValidateError .modal-body ul`).append($(`<li>`).text(reee.DESCR));
                }
            }
            $(`#mdlValidateError`).modal();
        }

        let Obj_Unvalid = [];

        console.log("index", arrIndex_Success.length);
        for (let i of arrIndex_Success) {

            let Item_Unvalid;

            let fn_UltraSearch = () => {
                for (let riii of arrErr) {
                    if (riii.ID_CF == objData_Dtt[i].Exam.ID_CF) {
                        return true;
                    }
                }
                return false;
            };
            if (fn_UltraSearch() == false) {

                Item_Unvalid = {
                    ID_ATE_RES: objData_Dtt[i].Res.ID_RES,
                    VALUE: objData_Dtt[i].Res.value
                };

                objData_Dtt[i].EE.value = 7;
                objData_Dtt[i].EE.estado = "";
                $(`tr[data-index=${i}] td`).eq(1).html(objData_Dtt[i].EE.estado);
            }
            Obj_Unvalid.push(Item_Unvalid);
        }
        objAJAX_Unvalidate.requestNow({
            "Obj_Unvalid": Obj_Unvalid
        });

        // console.log("make table 3");

    };



    let fn_Remove_Revision = () => {

        modal_show();

        let xTR = $("#Dtt_Exam tbody tr");
        let arrIndex_Success = [];
        let arrErr = [];
        //// console.clear();
        // console.log(`Exámenes por Desvalidar:`);

        for (let i = 0; i < xTR.length; i++) {
            let xIndex = parseInt(xTR.eq(i).attr("data-index"));
            var xItem = objData_Dtt[xIndex];

            if (((xItem.Res.value == null) || (xItem.Res.value.toString().trim() == "")) && (xItem.Res.pruCero == true)) {
                xItem.Res.value = TOOL.fn_cutDecimals(0, xItem.Res.pruDecimal, false);
            }

            if ((xItem.EE.value == 6 || xItem.EE.value == 14) && xItem.Res.ATE_REV_ID_ESTADO == 1) {
                console.log("xItem", xItem)
                let bolHasValue = false;
                if ((xItem.Res.value != null) && (xItem.Res.value.toString().trim() != "")) {
                    bolHasValue = true;
                }
                // console.groupCollapsed(`[${xItem.Exam.ID_CF}] => ${xItem.Exam.Descrp} - ${xItem.Desc}`);
                // console.log(`Obligatorio = ${xItem.Res.NEED_VALIDATE}\nTiene Valor = ${bolHasValue}\n`);
                // console.groupEnd();

                arrIndex_Success.push(xIndex);

                //if (bolHasValue == true) {
                //    arrIndex_Success.push(xIndex);
                //}
                //else {
                //    if (xItem.Res.NEED_VALIDATE == true) {
                //        let fn_Add_CF_Error = () => {
                //            arrErr.push({
                //                ID_CF: xItem.Exam.ID_CF,
                //                arrParam: [
                //                    {
                //                        ID_RES: xItem.Res.ID_RES,
                //                        DESCR: `${xItem.Exam.Descrp} - ${xItem.Desc}`
                //                    }
                //                ]
                //            });
                //        };
                //        if (arrErr.length == 0) {
                //            fn_Add_CF_Error();
                //        }
                //        else {
                //            let Index_E = arrErr.DeepSearch("ID_CF", xItem.Exam.ID_CF);
                //            if (Index_E == null) {
                //                fn_Add_CF_Error();
                //            }
                //            else {
                //                arrErr[Index_E].arrParam.push({
                //                    ID_RES: xItem.Res.ID_RES,
                //                    DESCR: `${xItem.Exam.Descrp} - ${xItem.Desc}`
                //                });
                //            }
                //        }
                //    }
                //}
            }
        }


        if (arrErr.length > 0) {
            // console.error(`<<ERROR - DESVALIDACIÓN DENEGADA>>`);
            $(`#mdlValidateError .modal-body ul`).empty();
            for (let riii of arrErr) {
                for (let reee of riii.arrParam) {
                    $(`#mdlValidateError .modal-body ul`).append($(`<li>`).text(reee.DESCR));
                }
            }
            $(`#mdlValidateError`).modal();
        }

        let Obj_Remove_Revision = [];

        console.log("index", arrIndex_Success.length);
        for (let i of arrIndex_Success) {

            let Item_Remove_Revision;

            let fn_UltraSearch = () => {
                for (let riii of arrErr) {
                    if (riii.ID_CF == objData_Dtt[i].Exam.ID_CF) {
                        return true;
                    }
                }
                return false;
            };
            if (fn_UltraSearch() == false) {

                Item_Remove_Revision = {
                    "ID_DET_ATE": objData_Dtt[i].ID_DET_ATE,
                    "ID_ATE_RES": objData_Dtt[i].Res.ID_RES
                };

            }
            Obj_Remove_Revision.push(Item_Remove_Revision);
            objData_Dtt[i].Res.ATE_REV_ID_ESTADO = 0
        }
        objAJAX_Remove_Revision.requestNow({
            "Obj_Remove_Revision": Obj_Remove_Revision
        });

        // console.log("make table 3");

    };


    //Parte para revisar un examen
    let fn_Revision = async () => {
        //modal_show();

        let xTR = $("#Dtt_Exam tbody tr");
        let arrIndex_Success = [];
        let arrErr = [];
        //// console.clear();
        // console.log(`Exámenes por Validar:`);
        let v_Id_Cf = "";
        let v_Cons;
        for (let i = 0; i < xTR.length; i++) {

            let xIndex = parseInt(xTR.eq(i).attr("data-index"));
            var xItem = objData_Dtt[xIndex];

            // BUSCA SI ESTA VALIDADO

            if (v_Id_Cf == "") {
                v_Id_Cf = xItem.Exam.ID_CF;
                v_Cons = 0; // Check_Valida(ID_ATE,v_Id_Cf);

                // console.log("ID_CF "+v_Id_Cf+" v_Cons: "+v_Cons);

            } else if (v_Id_Cf != xItem.Exam.ID_CF) {
                v_Id_Cf = xItem.Exam.ID_CF;
                v_Cons = 0; // Check_Valida(ID_ATE,v_Id_Cf);

                // console.log("ID_CF "+v_Id_Cf+" v_Cons: "+v_Cons);
            }

            if (v_Id_Cf == xItem.Exam.ID_CF && v_Cons == 0) {
                // console.log("Se puede validar ["+xItem.Exam.Descrp+"] - "+xItem.Desc);
                console.log(xItem);




                //if (((xItem.Res.value == null) || (xItem.Res.value.toString().trim() == "")) && (xItem.Res.pruCero == true)) {
                //    xItem.Res.value = TOOL.fn_cutDecimals(0, xItem.Res.pruDecimal, false);
                //    // console.log(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> IF GUARDAR RESULTADO");
                //    let Me_Val = xTR[xIndex].children[4].children[0].value;
                //    let Me_Ind = xIndex
                //    await fn_Write_2(Me_Ind, Me_Val);
                //}

                if ((xItem.EE.value == 6) && (xItem.EE.value != 14) && (xItem.Res.ATE_REV_ID_ESTADO != 1)) {
                    let bolHasValue = false;
                    if ((xItem.Res.value != null) && (xItem.Res.value.toString().trim() != "")) {
                        bolHasValue = true;
                    }
                    // console.groupCollapsed(`[${xItem.Exam.ID_CF}] => ${xItem.Exam.Descrp} - ${xItem.Desc}`);
                    // console.log(`Obligatorio = ${xItem.Res.NEED_VALIDATE}\nTiene Valor = ${bolHasValue}\n`);
                    // console.groupEnd();
                    if (bolHasValue == true) {
                        arrIndex_Success.push(xIndex);
                    }
                    else {
                        if (xItem.Res.NEED_VALIDATE == false) {
                            let fn_Add_CF_Error = () => {
                                arrErr.push({
                                    ID_CF: xItem.Exam.ID_CF,
                                    arrParam: [
                                        {
                                            ID_RES: xItem.Res.ID_RES,
                                            DESCR: `${xItem.Exam.Descrp} - ${xItem.Desc}`
                                        }
                                    ]
                                });
                            };
                            if (arrErr.length == 0) {
                                fn_Add_CF_Error();
                            }
                            else {
                                let Index_E = arrErr.DeepSearch("ID_CF", xItem.Exam.ID_CF);
                                if (Index_E == null) {
                                    fn_Add_CF_Error();
                                }
                                else {
                                    arrErr[Index_E].arrParam.push({
                                        ID_RES: xItem.Res.ID_RES,
                                        DESCR: `${xItem.Exam.Descrp} - ${xItem.Desc}`
                                    });
                                }
                            }
                        }
                    }
                }

                //$(document).scrollTop(100);
            } else {
                // console.log("No se puede validar ["+xItem.Exam.Descrp+"] - "+xItem.Desc);
            }


        }
        if (arrErr.length > 0) {
            // console.error(`<<ERROR - VALIDACIÓN DENEGADA>>`);
            $(`#mdlValidateError .modal-body ul`).empty();
            for (let riii of arrErr) {
                for (let reee of riii.arrParam) {
                    $(`#mdlValidateError .modal-body ul`).append($(`<li>`).text(reee.DESCR));
                }
            }
            $(`#mdlValidateError`).modal();
        }

        //const { recepcionado, rechazado } = objData_Dtt[0];

        //if (!recepcionado) {
        //    Swal.fire({
        //        icon: "warning",
        //        title: "Advertencia Recepción",
        //        html: "Para validar un resultado, es necesario que haya sido recepcionado tanto en el Laboratorio como en la Sección correspondiente. <br/>¡Por favor, asegúrate de que ambos pasos se hayan completado antes de validar el resultado!"
        //    });

        //    Hide_Modal();
        //    return;
        //}



        let Obj_Rev = [];
        for (let i of arrIndex_Success) {
            let fn_UltraSearch = () => {
                for (let riii of arrErr) {
                    if (riii.ID_CF == objData_Dtt[i].Exam.ID_CF) {
                        return true;
                    }
                }
                return false;
            };
            if (fn_UltraSearch() == false) {
                //objAJAX_Validate.requestNow({

                //});

                let Item_Rev;

                Item_Rev = {
                    "ID_DET_ATE": objData_Dtt[i].ID_DET_ATE,
                    "ID_ATE_RES" : objData_Dtt[i].Res.ID_RES

                };

                Obj_Rev.push(Item_Rev);
                objData_Dtt[i].Res.ATE_REV_ID_ESTADO = 1
            }
        }
        //// console.log(Obj_Valid);
        await objAJAX_Revision.requestNow({ "Obj_Rev": Obj_Rev });
        // console.log("make table 2");

    };

    const callbackDatosLoad = datos => {

        objData_Pac = datos.d

        strUrlQuery = `ID=${objData_Pac.ID_ATE_ENCODED}&CF=${idCodigoFonasa}&AS=${idRlsLs}`;
        let strURL = `Ate_Resultados_3.aspx?${strUrlQuery}`;
        window.history.pushState({ path: strURL }, '', strURL);

        objAJAX_Sel_Prev.queryString = strUrlQuery;
        objAJAX_Sel_Prog.queryString = strUrlQuery;
        objAJAX_Sel_Secc.queryString = strUrlQuery;

        updateEdad = true;
        if (objData_Pac.USUARIO_ELIMINACION !== '') {
            Hide_Modal();
            Swal.fire({
                icon: 'info',
                title: 'Atención Eliminada',
                html: `Usuario Eliminador: <b>${objData_Pac.USUARIO_ELIMINACION}</b> 
                        <br/> <br/> 
                        Causa Eliminación: <b>${objData_Pac.CAUSA_ELIMINACION || "Sin Comentario"}</b>`
            });
            Mdl_Init_Load.endLoad();
            return;
        }

        let r_FUR;

        if (objData_Pac.ATE_FUR != null && objData_Pac.ATE_FUR != "") {
            r_FUR = " | Fur: " + objData_Pac.ATE_FUR;
        } else {
            r_FUR = "";
        }

        Txt_NumAte.setValue(objData_Pac.ATE_NUM);

        $("#txtNombrePaciente").val(objData_Pac.PAC_NOMBRE + " " + objData_Pac.PAC_APELLIDO);
        $("#txtNombreSocial").val(objData_Pac.PAC_NOM_SOCIAL);
        $("#txtGenero").val(objData_Pac.GENERO_DESC);
        $("#txtRutDni").val(objData_Pac.PAC_RUT);
        $("#txtFechaAtencion").val(moment(objData_Pac.ATE_FECHA).format("DD/MM/YYYY HH:mm:ss"));
        $("#txtEdad").val(objData_Pac.EDAD);
        $("#txtSexo").val(objData_Pac.SEXO_DESC);
        $("#txtFUR").val(r_FUR);
        $("#txtIngresadoPor").val(objData_Pac.USU_NIC);
        $("#txtOrdenDeAtención").val(objData_Pac.ORD_DESC);

      

        if (objData_Pac.ID_TP_ATENCION == 3) {
            $("#txtTipoAtencion").val(objData_Pac.TP_ATENCION_DESC.toUpperCase());
            $("#txtTipoAtencion").css({
                "color": "red",
                "font-weight": "bold",
                "border": "2px solid red"
            });
        } else {
            $("#txtTipoAtencion").val("NO URGENTE");
            $("#txtTipoAtencion").css({
                "color": "",
                "font-weight": "",
                "border": ""
            });
        }

        $("#txtTipoAtención").val(objData_Pac.ORD_DESC);

        if (objData_Pac.ORD_DESC == "Urgencia") {
            $("#txtOrdenDeAtención").css({ "border-color": "red", "border-width": "3px", "background-color": "#ffd6d6" });
        } else {
            $("#txtOrdenDeAtención").css({ "border-color": "", "border-width": "", "background-color": "" });
        }
        $("#txtOrdenDeAtención").removeClass("bg-color-info-ate");
        if ($("#txtOrdenDeAtención").val() !== "Urgencia") {
            $("#txtOrdenDeAtención").addClass("bg-color-info-ate");
        }

        $("#txtObsTomaMuestra").val(objData_Pac.ATE_OBS_TM);
        $("#txtObsPermanente").val(objData_Pac.PAC_OBS_PERMA);
        $("#txtObsAtencion").val(objData_Pac.ATE_OBS_FICHA);
        $("#txtNumeroAvis").val(objData_Pac.ATE_AVIS);
        $("#txtHoraUltimaDosis").val(objData_Pac.ULTIMA_DOSIS_DROGA);
        $("#txtHGT").val(objData_Pac.HGT);

        const fechaNacimientoPaciente = new Date(parseInt(objData_Pac.PAC_FNAC.replace("\/Date(", "").replace(")\/", "")));
        fechaNacimientoPaciente.setHours(fechaNacimientoPaciente.getHours() + 3);
        $("#txtFechaNacimientoPaciente").val(fechaNacimientoPaciente.toLocaleDateString("es-CL"));

        $("#txtCantidadAtenciones").val(objData_Pac.CANT_ATENCIONES);
        $("#txtCantidadExamenes").val(objData_Pac.CANT_EXAMENES);

        let v_Obs;

        v_Obs = objData_Pac.ATE_OBS_TM;

        if (v_Obs != "" && v_Obs != null) {
            v_Obs = " | Obs: " + objData_Pac.ATE_OBS_TM;

        } else {
            v_Obs = "";
        }



        $("#title_Det_Ate_2").html("<i class='fa fa-edit mr-2'></i>Profesional solicitante: " + objData_Pac.DOC_NOMBRE + " " + objData_Pac.DOC_APELLIDO + " | Orden: " + objData_Pac.ORD_DESC + v_Obs);

        ID_ATE = objData_Pac.ID_ATENCION;
        if (objData_Pac.CANT_ATENCIONES > 1) {
            Btn_Hist.setActive(true);
        }
        else {
            Btn_Hist.setActive(false);
        }

        //console.log(objData_Pac);

        $("#Sel_Proc").val(objData_Pac.ID_PROCEDENCIA);

        //objAJAX_Sel_Prev.requestNow({
        //    ID_PROC: Sel_Proc.getValue().value
        //}, () => {

        //});


        $("#Sel_Prev").val(objData_Pac.ID_PREVE);
        //objAJAX_Sel_Prog.requestNow({
        //    ID_PREV: Sel_Prev.getValue().value
        //}, () => {
        $("#Sel_Prog").val(objData_Pac.ID_PROGRA);
        //});


        objAJAX_Sel_Secc.requestNow().then(() => {
            Mdl_Init_Load.loaded = false;
            Mdl_Init_Load.count = 6
            Mdl_Init_Load.endLoad();
        });

    }

    //Declaración AJAX-----------------------------------------------------------------------------
    objAJAX_Pac_Data = new TOOL.class_AJAX("Ate_Resultados_3.aspx/Page_Load", (resp) => {
        callbackDatosLoad(resp);
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            // console.log(fail);
        }
    });

    let objAJAX_Sel_Proc = new TOOL.class_AJAX("Ate_Resultados_3.aspx/Sel_Proc", (resp) => {
        let xData;
        xData = resp.d;
        Sel_Proc.cleanAll();
        Sel_Proc.insertElem("<< Todos >>", 0);
        $("#Ddl_Proc_Ate, #Ddl_Proc_Ate_pendiente").empty();

        if (xData.length > 1) {
            $("<option>", { "value": 0 }).text("TODOS PROCEDENCIA").appendTo("#Ddl_Proc_Ate, #Ddl_Proc_Ate_pendiente");
        }
        for (let i in xData) {
            Sel_Proc.insertElem(xData[i].DESC, xData[i].ID);
            $("<option>", { "value": xData[i].ID }).text(xData[i].DESC).appendTo("#Ddl_Proc_Ate, #Ddl_Proc_Ate_pendiente");
        }



        Mdl_Init_Load.endLoad();
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            // console.log(fail);
        }
    });
    let objAJAX_Sel_Prev = new TOOL.class_AJAX("Ate_Resultados_3.aspx/Sel_Prev_Activo", (resp) => {
        let xData;
        xData = resp.d;
        Sel_Prev.cleanAll();
        Sel_Prev.insertElem("<< Todos >>", 0);
        let bolFound = false;
        for (let i in xData) {
            Sel_Prev.insertElem(xData[i].DESC, xData[i].ID);
        }
        //objAJAX_Sel_Prog.requestNow({
        //    ID_PREV: 0
        //})
        // console.log("Sel Prev");
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            // console.log(fail);
        }
    });
    let objAJAX_Sel_Prog = new TOOL.class_AJAX("Ate_Resultados_3.aspx/Sel_Prog", (resp) => {
        let xData;
        xData = resp.d;
        Sel_Prog.cleanAll();
        Sel_Prog.insertElem("<< Todos >>", 0);
        for (let i in xData) {
            Sel_Prog.insertElem(xData[i].DESC, xData[i].ID);
        }
        // console.log("Sel Prog");
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            // console.log(fail);
        }
    });
    let objAJAX_Sel_Secc = new TOOL.class_AJAX("Ate_Resultados_3.aspx/Sel_Secc", (resp) => {
        let xData_In;
        objSel_Secc = [];
        Sel_Secc.cleanAll();
        xData_In = resp.d;
        xData_In.forEach((xItem, i) => {
            let strArray = encodeURI(JSON.stringify({
                ID_SECC: xItem.ID_SECC,
                ARR_ID: xItem.arrID
            }));
            objSel_Secc.push({
                ID: btoa(strArray),
                DESC: xItem.Descr
            });
        });
        for (let i = 0; i < objSel_Secc.length; ++i) {
            let sel_Item = {
                text: objSel_Secc[i].DESC,
                value: objSel_Secc[i].ID
            };
            Sel_Secc.data.push(sel_Item);
        }
        Sel_Secc.updateSelect();
        if (Mdl_Init_Load.loaded == false) {
            $(`#Sel_Secc`).off('eventChange');
            Sel_Secc.eventChange((Me) => {
                if (Chk_Filther.getValues().indexOf(3) != -1) {
                    $("#objChk_Filther_5").trigger("click");
                }
                let strVal = `${Sel_Secc.getValue().value}`;
                let arrInt = [];
                try {
                    arrInt = JSON.parse(decodeURI(atob(strVal))).ARR_ID;
                }
                catch (err) {
                    objSel_Secc.forEach((xElem) => {
                        let item_array = JSON.parse(decodeURI(atob(`${xElem.ID}`))).ARR_ID;
                        item_array.forEach((xiii) => {
                            arrInt.push(xiii);
                        });
                    });
                }
                //// console.log(`Array del elemento seleccionado:`)
                //// console.log(arrInt)
                //// console.log(`\n`)
                Sel_Exam.cleanAll();
                Sel_Exam.insertElem("<< Todos >>", 0);
                //// console.group("Llenando Select de Exámenes")
                arrInt = arrInt.map(idCf => structuredClone(objSel_Exam.find(exa => exa.ID == idCf)));
                arrInt.sort((a, b) => a.DESC.localeCompare(b.DESC));
                arrInt = arrInt.map(item => parseInt(item.ID));

                objSel_Exam.forEach((xElem, i) => {
                    let bolExist = false;
                    arrInt.forEach((xInt) => {
                        if (xInt == xElem.ID) {
                            bolExist = true;
                        }
                    });
                    if (bolExist) {
                        //// console.log(`Este elemento existe:`)
                        //// console.log(xElem)
                        let x_string = xElem.DESC;
                        let x_number = parseInt(`${xElem.ID}`);
                        Sel_Exam.insertElem(x_string, x_number);
                    }
                });
                // console.groupEnd();
                // console.log("make table 4 Sección");
                //fn_Make_Table();
            });
        }
        // console.log("Sel Secc");
        // console.log(">>> End Sel Secc");

        fn_Charge_Exam();
        //seleccionarExaDeURL()
        //Sel_Secc.eventChange();

        Mdl_Init_Load.endLoad();
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            // console.log(fail);
        }
    });

    const seleccionarExaDeURL = () => {
        const idRlsLs = parseInt(getParameterByNameMaster("AS"));
        if (idRlsLs > 0 && idRlsLs) {
            const areaSeccionCargados = Array.from($("#Sel_Secc option")).map(item => JSON.parse(decodeURI(atob(item.value))).ID_SECC);
            if (areaSeccionCargados.includes(idRlsLs)) {
                const indexSelectedRls = areaSeccionCargados.indexOf(idRlsLs)
                document.getElementById("Sel_Secc").selectedIndex = indexSelectedRls
                if (Chk_Filther.getValues().indexOf(3) == -1) {
                    $("#objChk_Filther_5").trigger("click");
                }
            }
        }
        const idCfParametro = getParameterByNameMaster("CF");
        if (idCfParametro > 0 && idCfParametro) {
            const examenesCargados = Sel_Exam.data.map(item => item.value);
            if (examenesCargados.includes(idCfParametro)) {
                Sel_Exam.setValue(idCfParametro);
                if (Chk_Filther.getValues().indexOf(4) == -1) {
                    $("#objChk_Filther_6").trigger("click");
                }
            }
            const selectExamen = document.getElementById("Sel_Exam");
            if (selectExamen.selectedIndex == -1) {
                selectExamen.selectedIndex = 0
            }
        }
    }
    let objAJAX_Sel_Exam = new TOOL.class_AJAX("Ate_Resultados_3.aspx/Sel_Exam", (resp) => {
        objSel_Exam = resp.d;
        Sel_Exam.cleanAll();
        Sel_Exam.insertElem("<< Todos >>", 0);
        for (let i in objSel_Exam) {
            Sel_Exam.insertElem(objSel_Exam[i].DESC, objSel_Exam[i].ID);
        }

        fn_Charge_Exam();
        //seleccionarExaDeURL(); 
        //if (Mdl_Init_Load.loaded == false) {
        //    Sel_Secc.eventChange();
        //}


        // console.log("Sel Exam");    
        Mdl_Init_Load.endLoad();
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            // console.log(fail);
        }
    });

    let objAJAX_Sel_IntExt = new TOOL.class_AJAX("Ate_Resultados_3.aspx/Sel_IntExt", (resp) => {
        objSel_IntExt = resp.d;
        //Sel_IntExt.cleanAll();
        //Sel_IntExt.insertElem("<< Todos >>", 0);
        //for (let  i in objSel_IntExt) {
        //    Sel_IntExt.insertElem(objSel_IntExt[i].DESC, objSel_IntExt[i].ID);
        //}
        // console.log("Sel IntExt");
        Mdl_Init_Load.endLoad();
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            // console.log(fail);
        }
    });
    let objAJAX_Fill_Table = new TOOL.class_AJAX("Ate_Resultados_3.aspx/Json_DataTable", (resp) => {
        objData_Dtt = [];
        objData_Dtt = resp.d;
        const vdrlSeleccionado = $("#Sel_Exam").val() == 315;
        revisarPermisosValidacion(vdrlSeleccionado);
        //// console.log(objData_Dtt);
        // console.log("Json DTT");
        Mdl_Init_Load.endLoad();
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            // console.log(fail);
        }
    });
    let objAJAX_Write = new TOOL.class_AJAX(objWrite.URL, (resp) => {
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            // console.log(fail);
        }
    });
    let objAJAX_Fill_Audit = new TOOL.class_AJAX("Ate_Resultados_3.aspx/Fill_Audit", (resp) => {
        objData_Audit = resp.d;
        Dtt_Audit.isClickeable = true;
        Dtt_Audit.isDataTable = false;
        Dtt_Audit.cleanTable();
        Dtt_Audit.addTHead("", "right");
        Dtt_Audit.addTHead("Forma", "left");
        Dtt_Audit.addTHead("Acción", "left");
        Dtt_Audit.addTHead("Fecha", "center");
        Dtt_Audit.addTHead("Hora", "center");
        Dtt_Audit.addTHead("Usuario", "center");
        objData_Audit.forEach((xItem, xIndex) => {
            Dtt_Audit.addRow(xIndex, [
                (function () {
                    let strOut = `${xIndex + 1}`;
                    while (strOut.length < `${objData_Audit.length}`.length) {
                        strOut = `0${strOut}`;
                    }
                    return strOut;
                }()),
                xItem.AUDI_FORMA,
                xItem.AUDI_ACCION,
                moment(xItem.AUDI_FECHA).format("DD/MM/YYYY"),
                moment(xItem.AUDI_FECHA).format("HH:mm"),
                xItem.USU_NIC
            ]);
        });
        Dtt_Audit.updateTable("No hay eventos asociados a la determinación seleccionada.");
        $("#mdlAudit").modal();
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            // console.log(fail);
        }
    });

    let objAJAX_Validate = new TOOL.class_AJAX("Ate_Resultados_3.aspx/Set_Validate", (resp) => {
        //Hide_Modal();
        //fn_Make_Table();

        const pendChecked = document.getElementById("objChk_Filther_0").checked;
        const seccionOExamenChecked = document.getElementById("objChk_Filther_5").checked || document.getElementById("objChk_Filther_6").checked;

        if (pendChecked && seccionOExamenChecked) {
            $("#Btn_AteR").trigger("click");
        } else {
            $("#Sel_Exam").trigger("change");
        }

    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            // console.log(fail);
        }
    });

    let objAJAX_Revision = new TOOL.class_AJAX("Ate_Resultados_3.aspx/Set_Revision", (resp) => {
        //Hide_Modal();
        //fn_Make_Table();

        const pendChecked = document.getElementById("objChk_Filther_0").checked;
        const seccionOExamenChecked = document.getElementById("objChk_Filther_5").checked || document.getElementById("objChk_Filther_6").checked;

        if (pendChecked && seccionOExamenChecked) {
            $("#Btn_AteR").trigger("click");
        } else {
            $("#Sel_Exam").trigger("change");
        }

    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            // console.log(fail);
        }
    });


    let objAJAX_Critico_Manual = new TOOL.class_AJAX("Ate_Resultados_3.aspx/Critico_Manual", (resp) => {
        //Hide_Modal();
        //fn_Make_Table();
        //$("#Sel_Exam").trigger("change");
        $("#mdlCritManual").modal("hide");
    }, (fail) => {
        //Hide_Modal();
        //$("#mdlError").modal("show");
        //try {
        //    $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
        //    $("#mdlTxt_Descr").text(fail.responseJSON.Message);
        //    $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        //}
        //catch (err) {
        //    $("#mdlTxt_Type").text("Error Genérico");
        //    $("#mdlTxt_Descr").text("Error en el Front End");
        //    $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
        //    // console.log(fail);
        //}
    });

    let objAJAX_Remove_Revision = new TOOL.class_AJAX("Ate_Resultados_3.aspx/Set_Remove_Revision", (resp) => {
        //Hide_Modal();
        //fn_Make_Table();
        $("#Sel_Exam").trigger("change");
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            // console.log(fail);
        }
    });

    let objAJAX_Unvalidate = new TOOL.class_AJAX("Ate_Resultados_3.aspx/Set_Unvalidate", (resp) => {
        //Hide_Modal();
        //fn_Make_Table();
        $("#Sel_Exam").trigger("change");
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            // console.log(fail);
        }
    });
    let objAJAX_Get_Res_Cod = new TOOL.class_AJAX("Ate_Resultados_3.aspx/Get_Result_Cod", (resp) => {
        objData_ResCod = resp.d;
        let objTable = $("<table>", {
            class: "w-100 table-striped"
        });
        objTable.append($("<thead>").append($("<tr>").append($("<th>", { style: "max-width:0px;" }).text(""), $("<th>").text(""))), $("<tbody>"));
        objData_ResCod.forEach(xItem => {
            objTable.find("tbody").append($("<tr>").append($("<td>", { style: "max-width:0px;" }).append($("<button>", {
                type: "button",
                class: "btn btn-primary btn-sm"
            }).append($('<i class="fa fa-arrow-right">'))), $("<td>").text(xItem.RES_COD_DESC.replace(/\./gi, ""))));
        });
        $("#mdlResCodificados .mini-table").append(objTable);
        objTable.DataTable({
            //"iDisplayLength": 10,
            "info": false,
            "bPaginate": false,
            "bFilter": true,
            "bSort": false,
            "language": {
                "lengthMenu": "Mostrar: _MENU_",
                "zeroRecords": "No hay concidencias",
                "info": "Mostrando Página _PAGE_ de _PAGES_",
                "infoEmpty": "No hay concidencias",
                "infoFiltered": "(Se busco en _MAX_ registros )",
                "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>",
                "paginate": {
                    "previous": "Anterior",
                    "next": "Siguiente"
                }
            }
        });
        $("#mdlResCodificados .dataTables_wrapper > .row:nth-child(1) > div:nth-child(2)").attr("class", "col-12");
        $("#mdlResCodificados .dataTables_wrapper > .row:nth-child(1) > div:nth-child(1)").remove();
        $("#mdlResCodificados .dataTables_wrapper > .row:nth-child(1) > div input").attr("placeholder");
        $("#mdlResCodificados .dataTables_wrapper > .row:nth-child(1) > div").css({
            "display": "flex",
            "justify-content": "flex-start",
            "align-items": "flex-start",
            "padding-top": "1rem"
        });

        //Evento Click
        $("#mdlResCodificados .mini-table button").click((Me) => {
            Me.stopImmediatePropagation();
            let strSelVal = $(Me.currentTarget).parents("tr").children("td:nth-child(2)").text();
            if (Txt_ResCod_Out.value == "") {
                //En caso de que el Txt de salida esté vacío...
                Txt_ResCod_Out.value = `${strSelVal}`;
            }
            else {
                //Buscar el ítem a ingresar en la cadena de destino
                let arrStr = Txt_ResCod_Out.value.replace(/\,\s+/gi, "☼").split("☼");
                arrStr.forEach((item, i) => {
                    if (item == strSelVal) {
                        arrStr.splice(i, 1); //Quitar elemento Repetido
                        return;
                    }
                });
                let strOut = "";
                arrStr.forEach((item, i) => {
                    if (i > 0) {
                        //Agregar "," solo cuando exista más un 1 elem en el arr
                        strOut = `${strOut}, `;
                    }
                    //Concatenar
                    strOut = `${strOut}${item}`;
                });
                //Enviar Cadena procesada al txt de Salida
                Txt_ResCod_Out.value = `${strOut}, ${strSelVal}`;
            }
            Txt_ResCod_Out.value = Txt_ResCod_Out.value.trim();
        });
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            aah.PROC_DESC.toUpperCase()
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            // console.log(fail);
        }
    });
    let objAJAX_Get_Other_Ate = new TOOL.class_AJAX("Ate_Resultados_3.aspx/Change_Ate_L_or_R", (resp) => {
        // console.log("Get Other Ate");
        // console.log(resp);
        if (resp.d == 0) {
            Swal.fire({ icon: "info", title: "Fin", text: "Se ha llegado a la última atención" });
            Hide_Modal();
            Mdl_Init_Load.endLoad();
            return;
        }
        callbackDatosLoad(resp);

    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            // console.log(fail);
        }
    });

    let objAJAX_Get_Hist_Graph = new TOOL.class_AJAX("Ate_Resultados_3.aspx/Draw_Graph_Hist", (resp) => {
        let str_examen;
        let str_parameter;
        if (xSelItem != null) {
            str_examen = xSelItem.Exam.Descrp;
            str_parameter = xSelItem.Desc;
        }
        else {
            str_examen = $(`#mdlHistExam table tbody tr.tr_selected td`).eq(1).text();
            str_parameter = $(`#mdlHistPruebas table tbody tr.tr_selected td`).eq(0).text();
        }
        let arr_Data = resp.d;
        $("#divGraph").empty();
        $("#divGraphData").empty();
        if (arr_Data.length == 0) {
            $("#divGraph").parent().find(".modal-header .modal-title").text(`Aviso`);
            $("#divGraph").append($("<p>", { class: "text-justify" }).html(`La determinación actualmente seleccionada no posee valores históricos graficables. Por favor seleccione otro parámetro para examinar.`));
            $("#divGraph").attr({ class: "col-12" });
            $("#divGraphData").attr({ class: "col-12" });
            $("#mdlGraph > div").removeClass("modal-lg");
            $("#mdlGraph > div").addClass("modal-md");
        }
        else {
            $("#mdlGraph > div").removeClass("modal-md");
            $("#mdlGraph > div").addClass("modal-lg");
            $("#divGraph").attr({ class: "col-12 col-md-8" });
            $("#divGraphData").attr({ class: "col-12 col-md-4" });
            $("#divGraph").parent().find(".modal-header .modal-title").text(`Historial de la Determinación`);
            let objTable = $("<table>", { class: "w-100 table-striped" });
            objTable.append($("<thead>").append($("<tr>").append($("<th>", { class: "text-center" }).text("Nro Atención"), $("<th>", { class: "text-center" }).text("Fecha"), $("<th>", { class: "text-center" }).text("Resultado"), $("<th>", { class: "text-center" }).text("E"))), $("<tbody>"));
            let arrEtiq = [];
            let arrRangoA = [];
            let arrValues = [];
            let arrRangoB = [];
            arr_Data.forEach((xItem, i) => {
                arrEtiq.push(moment(xItem.ATE_FECHA).format("DD/MM/YYYY"));
                arrRangoA.push(xItem.ATE_R_HASTA);
                arrValues.push(xItem.ATE_R_VALUE);
                arrRangoB.push(xItem.ATE_R_DESDE);
                objTable.children("tbody").append($("<tr>").append($("<td>", { class: "text-right" }).text(xItem.NN_ATE), $("<td>", { class: "text-center" }).text(moment(xItem.ATE_FECHA).format("DD/MM/YYYY")), $("<td>", { class: "text-right" }).text(`${xItem.ATE_R_VALUE}`.replace(/\./gi, ',')), $("<td>", { class: "text-center" }).text(function () {
                    switch (xItem.ATE_EST_VALIDA) {
                        case 6:
                            return "V";
                        case 14:
                            return "I";
                        case 16:
                            return "R";
                        default:
                            return "";
                    }
                }())));
            });
            Highcharts.chart("divGraph", {
                title: {
                    text: `Examen: ${str_examen}`
                },
                subtitle: {
                    text: `Determinación: ${str_parameter}`
                },
                xAxis: {
                    categories: arrEtiq
                },
                yAxis: {
                    title: {
                        text: `Valores de la Determinación.`
                    }
                },
                legend: {
                    layout: 'vertical',
                    align: 'right',
                    verticalAlign: 'middle'
                },
                plotOptions: {
                    line: {
                        dataLabels: {
                            enabled: true
                        },
                        enableMouseTracking: false
                    }
                },
                series: [
                    {
                        name: 'Rango Ref Desde',
                        data: arrRangoB
                    },
                    {
                        name: 'Valor',
                        data: arrValues
                    },
                    {
                        name: 'Rango Ref Hasta',
                        data: arrRangoA
                    }
                ]
            });
            objTable.appendTo("#divGraphData");
            let moreThan10 = false;
            if (arr_Data.length > 10) {
                moreThan10 = true;
            }
            let obj_dtt = objTable.DataTable({
                "iDisplayLength": 10,
                "info": moreThan10,
                "bPaginate": moreThan10,
                "bFilter": true,
                "bSort": true,
                "language": {
                    "lengthMenu": "Mostrar: _MENU_",
                    "zeroRecords": "No hay concidencias",
                    "info": "Mostrando Página _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay concidencias",
                    "infoFiltered": "(Se busco en _MAX_ registros )",
                    "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>",
                    "paginate": {
                        "previous": "Anterior",
                        "next": "Siguiente"
                    }
                }
            });
            $(`#divGraphData .dataTables_filter`).addClass("pull-right");
            $(`#divGraphData .dataTables_paginate`).addClass("pull-right");
            $(`#divGraphData .dataTables_filter`).parent().attr({ "class": "col-12" });
            //$(`#divGraphData .dataTables_length`).parent().attr({ "class": "col-3" })
            $(`#divGraphData table`).parent().addClass("table-responsive");
        }
        $("#mdlGraph").modal("show");
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            // console.log(fail);
        }
    });
    let objAJAX_Get_Hist_Exam = new TOOL.class_AJAX("Ate_Resultados_3.aspx/Get_Table_Historico_Examenes", (resp) => {
        let arr_Data = resp.d;
        $(`#mdlHistExam .modal-body`).empty();
        $(`#mdlHistExam .modal-footer`).empty();
        if (arr_Data.length == 0) {
            $(`#mdlHistExam > div`).attr({ class: `modal-dialog modal-sm` });
            $(`#mdlHistExam .modal-body`).append($("<p>", { class: "text-justify" }).html(`El paciente actual no posee exámenes históricos registrados en el sistema.`));
        }
        else {
            $(`#mdlHistExam > div`).attr({ class: `modal-dialog modal-lg` });
            let _div1 = $("<div>", { class: "col-12" });
            let _div2 = $("<div>", { class: "col-12" });
            //Input con el nombre del paciente
            _div1.append($("<div>", {
                class: "form-group"
            }).append($("<label>").text("Nombre Paciente:"), $("<input>", {
                type: "text",
                class: "form-control",
                readonly: "readonly"
            }).val(`${objData_Pac.PAC_NOMBRE} ${objData_Pac.PAC_APELLIDO}`)));
            //Tabla con Datos
            let _table = $("<table>", { class: "w-100 table-striped" });
            _table.append($("<thead>").append($("<tr>").append($("<th>", { class: "text-center" }).text("Código"), $("<th>", { class: "text-center" }).text("Descripción"), $("<th>", { class: "text-center" }).text("Cantidad"), $("<th>", { class: "text-center" }).text("Ver"))));
            _table.append($("<tbody>"));
            //Agregar datos a la tabla
            arr_Data.forEach((xItem, i) => {
                let _tr = $("<tr>", { "data-value": xItem.ID_CODIGO_FONASA });
                _tr.append($("<td>", { class: "text-right" }).html(xItem.CF_COD));
                _tr.append($("<td>", { class: "text-left" }).html(xItem.CF_DESC));
                _tr.append($("<td>", { class: "text-right" }).html(`${xItem.EXA_COUNT}`));
                _tr.append($("<td>", { class: "text-center" }).html("<button type='button' class='btn btn-success btn-sm' name='btn_ver_hist'><i class='fa fa-search fa-fw'></i>Ver</button>"));
                _tr.appendTo(_table.find("tbody"));
            });
            //Evento Click
            _table.find("tbody").find("tr").click((Me) => {
                _table.find("tbody").find("tr").removeClass("tr_selected");
                $(Me.currentTarget).addClass("tr_selected");
            });
            //Evento Doble Click
            _table.find("tbody").find("tr").dblclick((Me) => {
                let numID_CF = parseInt($(Me.currentTarget).attr("data-value"));
                //Limpiar Modal de Pruebas
                let _div111 = $("#mdlHistPruebas .modal-body > .text-center");
                let _div222 = $("#mdlHistPruebas .modal-body > .text-left");
                _div111.show();
                _div222.hide();
                _div222.empty();
                _div222.append($("<input>", {
                    type: "text",
                    class: "form-control pb-2",
                    readonly: "readonly"
                }).val($(Me.currentTarget).find("td").eq(1).text()));
                $("#mdlHistExam").modal("hide");
                setTimeout(() => {
                    $("#mdlHistPruebas").modal();
                }, 500);
                objAJAX_Get_Hist_Pruebas.requestNow({
                    ID_ATE: objData_Pac.ID_ATENCION,
                    ID_CF: numID_CF
                });
            });
            //Meter todo en el Modal
            _table.appendTo(_div2);

            $(`#mdlHistExam .modal-body`).append($("<div>", { class: "row" }).append(_div1, _div2));

            $("button[name='btn_ver_hist']").click((Me) => {
                //// console.log($(Me.currentTarget));
                $(Me.currentTarget).parent().trigger("dblclick");
            });

            //Armar DataTable
            let moreThan10 = false;
            if (arr_Data.length > 10) {
                moreThan10 = true;
            }
            _table.DataTable({
                "iDisplayLength": 10,
                "info": moreThan10,
                "bPaginate": moreThan10,
                "bFilter": true,
                "bSort": true,
                "language": {
                    "lengthMenu": "Mostrar: _MENU_",
                    "zeroRecords": "No hay concidencias",
                    "info": "Mostrando Página _PAGE_ de _PAGES_",
                    "infoEmpty": "No hay concidencias",
                    "infoFiltered": "(Se busco en _MAX_ registros )",
                    "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>",
                    "paginate": {
                        "previous": "Anterior",
                        "next": "Siguiente"
                    }
                }
            });
            $(`#mdlHistExam .dataTables_filter`).addClass("pull-right");
            $(`#mdlHistExam .dataTables_paginate`).addClass("pull-right");
            $(`#mdlHistExam .dataTables_filter`).parent().attr({ "class": "col-9" });
            $(`#mdlHistExam .dataTables_length`).parent().attr({ "class": "col-3" });
            $(`#mdlHistExam table`).parent().addClass("table-responsive");
        }
        let _btnExit = $(`<button>`, {
            type: `button`,
            class: `btn btn-primary`,
            "data-dismiss": "modal"
        });
        _btnExit.append($(`<i>`, { class: "fa fa-check" }));
        _btnExit.append($(`<span>`).text("Aceptar"));
        $(`#mdlHistExam .modal-footer`).append(_btnExit);
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            // console.log(fail);
        }
    });
    let objAJAX_Get_Hist_Pruebas = new TOOL.class_AJAX("Ate_Resultados_3.aspx/Get_Table_Historico_Pruebas_Por_Examen", (resp) => {
        let arr_Data = resp.d;
        let _div1 = $("#mdlHistPruebas .modal-body > .text-center");
        let _div2 = $("#mdlHistPruebas .modal-body > .text-left");
        //Tabla con Datos
        let _table = $("<table>", { class: "w-100 table-striped table-bordered" });
        let _headers = $("<tr>");
        _headers.append($("<th>", { class: "text-center" }).text("Determinación"));
        _table.append($("<thead>"), $("<tbody>"));
        //Llenar Tabla con Datos
        //Identificar Atenciones
        let arr_ID_ATE = [];
        arr_Data.forEach(xItem => {
            let bol_found = false;
            arr_ID_ATE.forEach(yItem => {
                if (xItem.ID_ATENCION == yItem.ID_ATE) {
                    bol_found = true;
                    return;
                }
            });
            if (bol_found == false) {
                //Agregar Atención
                arr_ID_ATE.push({
                    ID_ATE: xItem.ID_ATENCION,
                    VALUE: null
                });
                _headers.append($("<th>", { class: "text-center" }).html(`N° ${xItem.ATE_NUM}<br />${moment(xItem.ATE_FECHA).format("DD/MM/YYYY")}`));
            }
        });
        //Crear Filas
        let _row;
        for (let i in arr_Data) {
            let fn_new_row = () => {
                //Crear Nueva Fila
                arr_ID_ATE.forEach(item => {
                    item.VALUE = null;
                });
                _row = $("<tr>", {
                    "data-id_pru": arr_Data[i].ID_PRUEBA
                });
                _row.append($("<td>", { class: "text-left" }).text(arr_Data[i].PRU_DESC));
            };
            let fn_Add_Name = () => {
                //Agregar valores a la Fila
                if ((i != 0) || (i == arr_Data.length - 1)) {
                    if (i == arr_Data.length - 1) {
                        if (i == 0) {
                            fn_new_row();
                        }
                        fn_Add_Data();
                    }
                    arr_ID_ATE.forEach(item => {
                        if ((item.VALUE == null) || (item.VALUE == "")) {
                            item.VALUE = " - ";
                        }
                        _row.append($("<td>", {
                            class: (function () {
                                if (TOOL.fn_IsNumeric(item.VALUE.replace(/,/gi, ".")) == true) {
                                    return "text-right";
                                }
                                else if (item.VALUE == " - ") {
                                    return "text-center";
                                }
                                else {
                                    return "text-left";
                                }
                            }())
                        }).text(item.VALUE));
                    });
                    _table.find("tbody").append(_row);
                }
                fn_new_row();
            };
            let fn_Add_Data = () => {
                arr_ID_ATE.forEach(item => {
                    if (arr_Data[i].ID_ATENCION == item.ID_ATE) {
                        item.VALUE = arr_Data[i].ATE_RESULTADO;
                    }
                });
            };
            if (i == 0) {
                fn_Add_Name();
                fn_Add_Data();
            }
            else {
                if (arr_Data[i].ID_PRUEBA != arr_Data[i - 1].ID_PRUEBA) {
                    fn_Add_Name();
                    fn_Add_Data();
                }
                else if (i == arr_Data.length - 1) {
                    fn_Add_Name();
                }
                else {
                    fn_Add_Data();
                }
            }
        }
        //Evento Click
        _table.find("tbody tr").click((Me) => {
            _table.find("tbody tr").removeClass("tr_selected");
            $(Me.currentTarget).addClass("tr_selected");
            Btn_GraphAlt.setActive(true);
            Btn_Crit.setActive(true);
        });
        //Meter todo en la tabla
        _table.find("thead").append(_headers);
        _div2.append(_table);
        _div1.fadeOut(250, () => {
            _div2.fadeIn(250);
        });
    }, (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");
        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        }
        catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            // console.log(fail);
        }
    });
    //---------------------------------------------------------------------------------------------
    //Eventos de Inputs----------------------------------------------------------------------------
    Txt_NumAte.evFocusOut((Me) => {
        if (strUrlQuery != null) {
            Txt_NumAte.value = `${objData_Pac.ATE_NUM}`;
        }
    });
    Txt_NumAte.evKeypress((Me) => {
        if (Me.which == 13) {
            $("#Dtt_Exam table tbody").empty();
            $("#mError_AAH_Consulta").modal("hide");
            document.title = `CARGANDO`;
            num_title_loop = setInterval(fn_title_loop, 250);

            objAJAX_Pac_Data.requestNow({
                NUM_ATE: $("#Txt_NumAte").val() || 0,
                USU_ID_PROC: Galletas.getGalleta("USU_TM")
            });
        }
    });
    Txt_NumAte.evKeyup((Me) => {
        let strVal = $(Me.currentTarget).val();
        let arrNum = strVal.match(/[0-9]/gi);
        strVal = "";
        if (arrNum != null) {
            arrNum.forEach((xItem) => {
                if (strVal.length < 10) {
                    strVal = `${strVal}${xItem}`;
                }
            });
        }
        $(Me.currentTarget).val(strVal);
    });
    Sel_Proc.eventChange((Me) => {
        objAJAX_Sel_Prev.requestNow({
            ID_PROC: Sel_Proc.getValue().value
        });
    });
    Sel_Prev.eventChange((Me) => {
        objAJAX_Sel_Prog.requestNow({
            ID_PREV: Sel_Prev.getValue().value
        });
    });
    Sel_Secc.eventChange((Me) => {
        if (Mdl_Init_Load.loaded == true) {
            fn_Charge_Exam();
            Mdl_Init_Load.loaded = false;
            Mdl_Init_Load.count = 7;
            objData_Dtt = [];
            Dtt_Exam.cleanTable();
            modal_show();
            let ID_SECC_Now = Sel_Secc.getValue().value;
            let ID_EXAM_Now = parseInt(`${Sel_Exam.getValue().value}`);
            let ID_INEX_Now = 0;

            if (Chk_Filther.getValues().indexOf(7) != -1) {
                ACTIVA_PENDIENTES = 1;
            }
            else {
                ACTIVA_PENDIENTES = 0;
            }
            if (Chk_Filther.getValues().indexOf(8) != -1) {
                ACTIVA_PENDIENTES_R = 1;
            }
            else {
                ACTIVA_PENDIENTES_R = 0;
            }

            objAJAX_Fill_Table.queryString = strUrlQuery;
            objAJAX_Fill_Table.requestNow({
                R_ID_SECC: (JSON.parse(decodeURI(atob(`${Sel_Secc.getValue().value}`))).ID_SECC),
                R_ID_EXAM: parseInt(`${Sel_Exam.getValue().value}`),
                R_ID_PAC: objData_Pac.ID_PACIENTE,
                R_FNAC: moment(objData_Pac.PAC_FNAC).toDate(),
                R_SEXO: objData_Pac.SEXO_DESC,
                R_DIA: objData_Pac.ATE_DIA,
                R_MES: objData_Pac.ATE_MES,
                R_AÑO: objData_Pac.ATE_AÑO,
                ACTIVA_PENDIENTES: ACTIVA_PENDIENTES,
                ACTIVA_PENDIENTES_R: ACTIVA_PENDIENTES_R

            }, () => {
                Sel_Secc.setValue(ID_SECC_Now);
                Sel_Exam.setValue(ID_EXAM_Now);
                fn_Activate_Validator();
                fn_Make_Table();
                fn_Calc();
                //Hide_Modal()
            });
        }
        else {
            fn_Activate_Validator();
        }
    });
    const revisarPermisosValidacion = esVDRL => {

        let USU_PROF = Galletas.getGalleta("ID_PROF");
        let P_ADMIN = Galletas.getGalleta("P_ADMIN");

        if (USU_PROF == 1 || P_ADMIN == 8 || P_ADMIN == 1 || (P_ADMIN == 10 && esVDRL)) {
            $("#Btn_Validar").removeAttr("disabled");
            $("#Btn_Desvalidar").removeAttr("disabled");
            $("#Btn_Print").removeAttr("disabled");
            $("#Btn_Validar").parent().removeAttr("hidden");
            $("#Btn_Desvalidar").parent().removeAttr("hidden");
            $("#Btn_Print").parent().removeAttr("hidden");
            $("#Btn_Revisar").parent().removeAttr("hidden");
            $("#Btn_Not_Revisar").parent().removeAttr("hidden");
        } else {
            $("#Btn_Validar").attr("disabled", true);
            $("#Btn_Desvalidar").attr("disabled", true);
            $("#Btn_Print").attr("disabled", true);
            $("#Btn_Revisar").attr("disabled", true);
            $("#Btn_Not_Revisar").attr("disabled", true);
            $("#Btn_Validar").parent().attr("hidden", "hidden");
            $("#Btn_Desvalidar").parent().attr("hidden", "hidden");
            $("#Btn_Print").parent().attr("hidden", "hidden");
            $("#Btn_Revisar").parent().attr("hidden", "hidden");
            $("#Btn_Not_Revisar").parent().attr("hidden", "hidden");
        }
    }
    Sel_Exam.eventChange((Me) => {
        const vdrlSeleccionado = Me.currentTarget.value === "315";
        revisarPermisosValidacion(vdrlSeleccionado);
        if (Mdl_Init_Load.loaded == true) {
            Mdl_Init_Load.loaded = false;
            Mdl_Init_Load.count = 7;
            objData_Dtt = [];
            Dtt_Exam.cleanTable();
            modal_show();
            let ID_SECC_Now = Sel_Secc.getValue().value;
            let ID_EXAM_Now = parseInt(`${Sel_Exam.getValue().value}`);
            let ID_INEX_Now = 0;

            if (Chk_Filther.getValues().indexOf(7) != -1) {
                ACTIVA_PENDIENTES = 1;
            }
            else {
                ACTIVA_PENDIENTES = 0;
            }
            if (Chk_Filther.getValues().indexOf(8) != -1) {
                ACTIVA_PENDIENTES_R = 1;
            }
            else {
                ACTIVA_PENDIENTES_R = 0;
            }

            objAJAX_Fill_Table.queryString = strUrlQuery;
            objAJAX_Fill_Table.requestNow({
                R_ID_SECC: (JSON.parse(decodeURI(atob(`${Sel_Secc.getValue().value}`))).ID_SECC),
                R_ID_EXAM: parseInt(`${Sel_Exam.getValue().value}`),
                R_ID_PAC: objData_Pac.ID_PACIENTE,
                R_FNAC: moment(objData_Pac.PAC_FNAC).toDate(),
                R_SEXO: objData_Pac.SEXO_DESC,
                R_DIA: objData_Pac.ATE_DIA,
                R_MES: objData_Pac.ATE_MES,
                R_AÑO: objData_Pac.ATE_AÑO,
                ACTIVA_PENDIENTES,
                ACTIVA_PENDIENTES_R
            }, () => {
                Sel_Secc.setValue(ID_SECC_Now);
                Sel_Exam.setValue(ID_EXAM_Now);
                fn_Activate_Validator();
                // console.log("make table 5 Examen");
                //fn_Make_Table();
                fn_Calc();
                //Hide_Modal()
            });
        }
        else {
            fn_Activate_Validator();
        }
    });
    Dtt_Exam.evclick_tr = (Me) => {
        $(Me.currentTarget).find("input").focus();
        Btn_Audit.setActive(true);
        Btn_Graph.setActive(true);
        Btn_Crit.setActive(true);
        let index = parseInt(`${Dtt_Exam.tr_value}`);
    };
    Btn_Desvalidar.click((Me) => {
        if ((Sel_Secc.getValue().text == "<< Todos >>") && (Sel_Exam.getValue().value == 0)) {
            $(`#mdlAlert .modal-header .modal-title`).text("Seleccione Examen o Sección");
            $(`#mdlAlert .modal-body`).empty();
            $(`#mdlAlert .modal-body`).append($(`<span>`).text("Estimado usuario, para poder desvalidar un examen, deberá seleccionar un Examen o Sección"));
            $(`#mdlAlert`).modal();
        } else {
            fn_Unvalidate();
        }
    });
    Btn_Validar.click(async (Me) => {
        let mostrarSwal = true;
        const waitForBlurCompletion = async () => {
            if (flagSaveEnProceso) {
                if (mostrarSwal) {
                    mostrarSwal = false;
                    Swal.fire({
                        icon: "info",
                        title: "Información",
                        text: "Intentó validar mientras el sistema guardaba los resultados en la base de datos, por favor intente de nuevo."
                    });
                }
                //setTimeout(waitForBlurCompletion, 100);
            } else {
                if ((Sel_Secc.getValue().text == "<< Todos >>") && (Sel_Exam.getValue().value == 0)) {
                    $(`#mdlAlert .modal-header .modal-title`).text("Seleccione Examen o Sección");
                    $(`#mdlAlert .modal-body`).empty();
                    $(`#mdlAlert .modal-body`).append($(`<span>`).text("Estimado usuario, para poder validar un examen, deberá seleccionar un Examen o Sección"));
                    $(`#mdlAlert`).modal();
                } else {
                    modal_show();
                    await fn_Validate();
                }
              
            }
        };

        await waitForBlurCompletion();
    });

    Btn_Revisar.click(async (Me) => {
        let mostrarSwal = true;
        const waitForBlurCompletion = async () => {
            if (flagSaveEnProceso) {
                if (mostrarSwal) {
                    mostrarSwal = false;
                    Swal.fire({
                        icon: "info",
                        title: "Información",
                        text: "Intentó revisar mientras el sistema guardaba los resultados en la base de datos, por favor intente de nuevo."
                    });
                }
                //setTimeout(waitForBlurCompletion, 100);
            } else {
                //modal_show();
                await fn_Revision();
                
            }
        };

        await waitForBlurCompletion();
    });

    Btn_Not_Revisar.click(async (Me) => {
        let mostrarSwal = true;
        const waitForBlurCompletion = async () => {
            if (flagSaveEnProceso) {
                if (mostrarSwal) {
                    mostrarSwal = false;
                    Swal.fire({
                        icon: "info",
                        title: "Información",
                        text: "Intentó quitar revisión mientras el sistema guardaba los resultados en la base de datos, por favor intente de nuevo."
                    });
                }
                //setTimeout(waitForBlurCompletion, 100);
            } else {
                //modal_show();
                if ((Sel_Secc.getValue().text == "<< Todos >>") && (Sel_Exam.getValue().value == 0)) {
                    $(`#mdlAlert .modal-header .modal-title`).text("Seleccione Examen o Sección");
                    $(`#mdlAlert .modal-body`).empty();
                    $(`#mdlAlert .modal-body`).append($(`<span>`).text("Estimado usuario, para poder quitar la revisión de un examen, deberá seleccionar un Examen o Sección"));
                    $(`#mdlAlert`).modal();
                } else {
                await fn_Remove_Revision();
                }
                
            }
        };

        await waitForBlurCompletion();
    });



    btn_consulta.click((Me) => {
        let e = $.Event("keypress", { which: 13 });
        // console.log(e);
        $("#mError_AAH_Consulta").modal("hide");
        $('#Txt_NumAte').trigger(e);
    });

    Btn_Desvalidar.click((Me) => {
        if ((Sel_Secc.getValue().text == "<< Todos >>") && (Sel_Exam.getValue().value == 0)) {
            $(`#mdlAlert .modal-header .modal-title`).text("Seleccione Examen o Sección");
            $(`#mdlAlert .modal-body`).empty();
            $(`#mdlAlert .modal-body`).append($(`<span>`).text("Estimado usuario, para poder desvalidar un examen, deberá seleccionar un Examen o Sección"));
            $(`#mdlAlert`).modal();
        } else {
            fn_Unvalidate();
        }
    });
    Btn_Audit.click((Me) => {
        let objItem = objData_Dtt[parseInt($(`#Dtt_Exam tbody .tr_selected`).attr("data-index"))];
        let mdlTitle = $("#mdlAudit .modal-title");
        mdlTitle.text(`Auditoría ${objItem.Desc}`);
        objAJAX_Fill_Audit.requestNow({
            ID_RES: objItem.Res.ID_RES
        });
    });
    Btn_RC_New.click((Me) => {
        Txt_ResCod_Out.value = "";
    });
    Btn_Print.click((Me) => {
        let xUrl = "/Buscar_Ate/Atencion_Det.aspx?ID_ATE=";
        xUrl = `${xUrl}${strUrlQuery.replace(/^ID=/gi, "")}`;
        window.open(xUrl, "_blank");
    });



    Btn_Graph.click((Me) => {
        let xIndex = parseInt(Dtt_Exam.tr_value);
        xSelItem = objData_Dtt[xIndex];
        // console.log(`DATOS DEL RESULTADO:`);
        // console.log(`   ID_ATEN = ${objData_Pac.ID_ATENCION}`);
        // console.log(`   ATE_NUM = ${objData_Pac.ATE_NUM}`);
        // console.log(`   ID_RESU = ${xSelItem.Res.ID_RES}\n\n`);
        bol_toHistCf = false;
        bol_toHistPru = false;
        objAJAX_Get_Hist_Graph.requestNow({
            ID_ATE: objData_Pac.ID_ATENCION,
            ID_PRU: xSelItem.Exam.ID_EXA,
            BL_ALL: false
        });
    });

    Btn_Crit.click((Me) => {
        let xIndex = parseInt(Dtt_Exam.tr_value);
        xSelItem = objData_Dtt[xIndex];
        // console.log(`CRIT MANUAL:`);
        // console.log(`   ID_ATEN = ${objData_Pac.ID_ATENCION}`);
        // console.log(`   ATE_NUM = ${objData_Pac.ATE_NUM}`);
        // console.log(`   ID_RESU = ${xSelItem.Res.ID_RES}`);
        // console.log(`   ESTADO = ${xSelItem.EE.value}\n\n`);

        //// console.log(xSelItem);

        if (xSelItem.EE.value == 6 || xSelItem.EE.value == 14) {
            fn_Modal_Crit(xSelItem.Res.ID_RES, xSelItem.Desc, xSelItem.Res.value);
        }
    });

    btn_Acept_CM.click((Me) => {

        //// console.log(Me.currentTarget.attributes.data-id-index);
        let ID_ATE_RES_CRIT = $(Me.currentTarget).attr("data-id-res");

        //// console.log($(Me.currentTarget).attr("data-id-res")); 

        objAJAX_Critico_Manual.requestNow({
            ID_ATE_RES: ID_ATE_RES_CRIT
        });


        //// console.log(Me.getAttribute("data-id-res"));

        //let ID_ATE_RES_CRIT = Me.currentTarget.attr("data-id-res");

        //// console.log("confirm id res "+ID_ATE_RES_CRIT);

    });

    let bol_toHistCf = false;
    let bol_toHistPru = false;
    let xSelItem;
    Btn_GraphAlt.click((Me) => {
        let id_pru = parseInt($("#mdlHistPruebas table .tr_selected").attr("data-id_pru"));
        //$("#mdlHistPruebas").modal("hide");
        bol_toHistCf = false;
        bol_toHistPru = true;
        xSelItem = null;
        objData_Dtt.forEach((item, i) => {
            if (item.Exam.ID_EXA == id_pru) {
                xSelItem = item;
                return;
            }
        });

        objAJAX_Get_Hist_Graph.requestNow({
            ID_ATE: objData_Pac.ID_ATENCION,
            ID_PRU: id_pru,
            BL_ALL: true
        });
    });
    Btn_Hist.click((Me) => {
        objAJAX_Get_Hist_Exam.requestNow({
            ID_ATE: objData_Pac.ID_ATENCION
        }, () => {
            $("#mdlHistExam").modal();
        });
    });
    Btn_HistPruExit.click((Me) => {
        bol_toHistCf = true;
        bol_toHistPru = false;
    });
    let bolDir = false;
    let fn_Change_Ate = (bol_direction) => {
        $("#Dtt_Exam table tbody").empty();
        bolDir = bol_direction;
        return async (Me) => {
            if (strUrlQuery == null) {
                Txt_NumAte.value = "";
                return;
            }
            document.title = `CARGANDO`;
            num_title_loop = setInterval(fn_title_loop, 250);
            let response = {
                ATE_NUM: parseInt($("#Txt_NumAte").val()),
                DIRECTION: bol_direction,
                ID_PROC: 0,
                ID_PREV: 0,
                ID_PROG: 0,
                ID_SECC: 0,
                ID_EXAM: 0,
                ID_SECT: 0,
                ID_PACI: 0,
                USU_ID_PROC: 0,
                ACTIVA_PENDIENTES: 0,
                ACTIVA_PENDIENTES_R: 0
            };
            modal_show();

            // console.log("IFs");

            if (Chk_Filther.getValues().indexOf(0) != -1) {
                response.ID_PROC = parseInt(`${Sel_Proc.getValue().value}`);
                // console.log(response.ID_PROC);
            }
            else {
                Sel_Proc.setValue(0);
            }
            if (Chk_Filther.getValues().indexOf(1) != -1) {
                response.ID_PREV = parseInt(`${Sel_Prev.getValue().value}`);
            }
            else {
                Sel_Prev.setValue(0);
            }
            if (Chk_Filther.getValues().indexOf(2) != -1) {
                response.ID_PROG = parseInt(`${Sel_Prog.getValue().value}`);
            }
            else {
                Sel_Prog.setValue(0);
            }
            if (Chk_Filther.getValues().indexOf(3) != -1) {
                let xItem = JSON.parse(decodeURI(atob(`${Sel_Secc.getValue().value}`)));
                response.ID_SECC = parseInt(`${xItem.ID_SECC}`);
            }
            else {
                Sel_Secc.setValue(Sel_Secc.data[0].value);
            }
            if (Chk_Filther.getValues().indexOf(4) != -1) {
                response.ID_EXAM = parseInt(`${Sel_Exam.getValue().value}`);
            }
            else {
                Sel_Exam.setValue(0);
            }
            if (Chk_Filther.getValues().indexOf(5) != -1) {
                response.ID_SECT = 0;
            }
            else {
                Sel_IntExt.setValue(0);
            }
            if (Chk_Filther.getValues().indexOf(6) != -1) {
                response.ID_PACI = objData_Pac.ID_PACIENTE;
            }
            if (Chk_Filther.getValues().indexOf(7) != -1) {
                response.ACTIVA_PENDIENTES = 1;
            }
            else {
                response.ACTIVA_PENDIENTES = 0;
            }
            if (Chk_Filther.getValues().indexOf(8) != -1) {
                response.ACTIVA_PENDIENTES_R = 1;
            }
            else {
                response.ACTIVA_PENDIENTES_R = 0;
            }
            let USU_ID_PROC = Galletas.getGalleta("USU_TM");
            if (USU_ID_PROC != "null") response.USU_ID_PROC = USU_ID_PROC || 0;
            objAJAX_Get_Other_Ate.requestNow(response);

        };
    };
    Btn_AteL.click(fn_Change_Ate(false));
    Btn_AteR.click(fn_Change_Ate(true));
    //Evento de carga------------------------------------------------------------------------------
    window.addEventListener('popstate', () => {
        modal_show();
        let matched = location.href.match(/(ID.+)/gi);
        if (matched != null) {
            strUrlQuery = location.href.match(/(ID.+)/gi)[0];
        }
        else {
            strUrlQuery = null;
            clearInterval(num_title_loop);
            document.title = "Visor de Resultados";
            Dtt_Exam.cleanTable("Por favor introduzca un Nro de Atención, en la casilla correspondiente, y presione Enter para Iniciar la búsqueda.");

            Hide_Modal();
            return;
        }
        document.title = `CARGANDO`;
        num_title_loop = setInterval(fn_title_loop, 250);
        Mdl_Init_Load.count = 2;
        Mdl_Init_Load.loaded = false;
        Mdl_Init_Load.endLoad();
    });


    const urlParameters = new URLSearchParams(window.location.search);

    const idCfDeURL = parseInt(urlParameters.get('CF'));
    const idASDeURL = parseInt(urlParameters.get('AS')); // AS es área sección

    let idCodigoFonasa = idCfDeURL || 0;
    let idRlsLs = idASDeURL || 0;
    function Ajax_examen_Pendientes() {
        var strParam = JSON.stringify({
            DESDE: $("#txt-desde-pendiente").val(),
            HASTA: $("#txt-hasta-pendiente").val(),
            ID_SEC: $("#Ddl_Seccion_pendiente").val(),
            ID_PROC: $("#Ddl_Proc_Ate_pendiente").val(),
            ID_CODIGO_FONASA: $("#Ddl_Examen_Ate_pendiente").val(),
        });

        $.ajax({
            "type": "POST",
            "url": "Ate_Resultados_3.aspx/busca_examenes_pendientes",
            "data": strParam,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": res => {
                let Mx_Ate_Sec = res.d;

                $("#Div_Dtt_pendiente").empty();
                $("#Div_Dtt_pendiente").append(
                    $("<table>", {
                        "id": "Dtt_Ate_pendiente",
                        "cellspacing": "0"
                    }).css({
                        "width": "100%",
                        "border-collapse": "collapse",
                        "font-size": "1px"
                    })
                );
                $("#Div_Dtt_pendiente table").attr("class", "table table-hover table-striped table-iris");
                //Crear cabeceras
                $("#Dtt_Ate_pendiente").append(
                    $("<thead>"),
                    $("<tbody>")
                );
                $("#Dtt_Ate_pendiente thead").append(
                    $("<tr>").append(
                        $("<th>").text("Folio"),
                        $("<th>").text("Fecha"),
                        $("<th>").text("Sección"),
                        $("<th>").text("TdeM"),
                        $("<th>").text("Examen"),
                    )
                );
                //$("#Div_Dtt_pendiente table thead tr th").addClass("text-center");
                //Recorrer JSON
                const style = "cursor:pointer; text-align:left;-align:left;";
                Mx_Ate_Sec.forEach(aah => {
                    $("<tr>").css("cursor", "pointer").attr("value", aah.ATE_NUM).attr("data-id-seccion", aah.ID_RLS_LS).attr("data-id-codigo-fonasa", aah.ID_CODIGO_FONASA).append(
                        $("<td>", { style }).text(aah.ATE_NUM),
                        $("<td>", { style }).text(aah.ATE_FECHA),
                        $("<td>", { style }).text(aah.SECC_COD),
                        $("<td>", { style }).text(aah.PROC_DESC),
                        $("<td>", { style }).text(aah.CF_DESC),
                    ).appendTo("#Dtt_Ate_pendiente tbody");
                });

                $("#Dtt_Ate_pendiente tbody tr").on("click", e => {

                    $('#modal-pendientes').modal('hide');
                    const checkPendientes = document.getElementById("objChk_Filther_0");
                    if (!checkPendientes.checked) {
                        checkPendientes.dispatchEvent(new Event("click"));
                    }

                    $("#Txt_NumAte").val($(e.currentTarget).attr("value"));
                    let evento = $.Event("keypress", { which: 13 });
                    $('#Txt_NumAte').trigger(evento);
                    idCodigoFonasa = $(e.currentTarget).attr("data-id-codigo-fonasa");
                });
            },
            "error": function (response) {

            }
        });
    }
    await fillSeccionesAreas({ idSelect: "Ddl_Seccion_pendiente", placeholderText: "Todas Secciones" });

    $("#Ddl_Seccion_pendiente").on("click", async () => {
        await fillExamenesSeccion({ idSelect: "Ddl_Examen_Ate_pendiente", idSeccion: $("#Ddl_Seccion_pendiente").val(), placeholderText: "Todos Exámenes" });
    });

    await fillExamenesSeccion({ idSelect: "Ddl_Examen_Ate_pendiente", idSeccion: $("#Ddl_Seccion_pendiente").val(), placeholderText: "Todos Exámenes" });



    $(document).ready(() => {

        $("#Sel_Exam").on("change", e => {
            const checked = document.getElementById("objChk_Filther_6").checked;

            idCodigoFonasa = checked ? e.currentTarget.value : 0;

            const urlParams = new URLSearchParams(window.location.search);

            const idCodificado = urlParams.get('ID');

            if (idCodificado) {
                strUrlQuery = `ID=${idCodificado}&CF=${idCodigoFonasa}&AS=${idRlsLs}`;

                let strURL = `Ate_Resultados_3.aspx?${strUrlQuery}`;
                window.history.pushState({ path: strURL }, '', strURL);
            }
        });

        $("#objChk_Filther_6").on("change", e => {
            const checked = e.currentTarget.checked;
            idCodigoFonasa = checked ? $("#Sel_Exam").val() : 0;
            const urlParams = new URLSearchParams(window.location.search);

            const idCodificado = urlParams.get('ID');

            if (idCodificado) {
                strUrlQuery = `ID=${idCodificado}&CF=${idCodigoFonasa}&AS=${idRlsLs}`;

                let strURL = `Ate_Resultados_3.aspx?${strUrlQuery}`;
                window.history.pushState({ path: strURL }, '', strURL);
            }

        });

        $("#Sel_Secc").on("change", e => {

            const checked = document.getElementById("objChk_Filther_5").checked;

            idRlsLs = checked ? JSON.parse(decodeURI(atob(e.currentTarget.value))).ID_SECC : 0;

            const urlParams = new URLSearchParams(window.location.search);

            const idCodificado = urlParams.get('ID');

            if (idCodificado) {
                strUrlQuery = `ID=${idCodificado}&CF=${idCodigoFonasa}&AS=${idRlsLs}`;

                let strURL = `Ate_Resultados_3.aspx?${strUrlQuery}`;
                window.history.pushState({ path: strURL }, '', strURL);
            }
        });

        $("#objChk_Filther_5").on("change", e => {
            if (!$("#Sel_Secc").val()) return;

            const checked = e.currentTarget.checked;
            idRlsLs = checked ? JSON.parse(decodeURI(atob($("#Sel_Secc").val()))).ID_SECC : 0;

            const urlParams = new URLSearchParams(window.location.search);

            const idCodificado = urlParams.get('ID');

            if (idCodificado) {
                strUrlQuery = `ID=${idCodificado}&CF=${idCodigoFonasa}&AS=${idRlsLs}`;
                let strURL = `Ate_Resultados_3.aspx?${strUrlQuery}`;
                window.history.pushState({ path: strURL }, '', strURL);
            }

        });

        $("#modal-agregar-quitar-examenes").on("hidden.bs.modal", () => {
            // console.log("yapo");
            $("#Dtt_Exam table tbody").empty();
            $("#mError_AAH_Consulta").modal("hide");
            document.title = `CARGANDO`;
            num_title_loop = setInterval(fn_title_loop, 250);

            objAJAX_Pac_Data.requestNow({
                NUM_ATE: $("#Txt_NumAte").val() || 0,
                USU_ID_PROC: Galletas.getGalleta("USU_TM")
            });
        });

        var dateNow = moment().format("DD-MM-YYYY");
        $("#Txt_Date11 input, #Txt_Date22 input, #txt-desde-pendiente, #txt-hasta-pendiente").val(dateNow);
        $('#Txt_Date11, #Txt_Date22, #div-desde-pendiente, #div-hasta-pendiente').datetimepicker({
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
            minView: 2
        });


        $("#Btn_Obs_Exam").click(() => {
            if ($("#Txt_NumAte").val() != "") {
                fn_Busca_Obs_Exam();
            }
        });

        $("#btnAgregaDeter").click(() => {
            if (ID_ATENCHION == 0 || ID_PERRRRRRCH == 0) {
                // console.log(ID_ATENCHION);
                // console.log(ID_PERRRRRRCH);
            } else {
                $("#Div_Exam_Agrega2").empty();
                fn_Busca_Deter_soli_o_no_soli();

            }
        });
        //AJAX GUARDAR EN EL MODAL MARCAR
        $("#btnGuardaObsExam2").on("click", function () {
            const selected = new Array();
            $("input:checkbox[name='observacionesAgregar']:checked").each(function () {
                selected.push($(this).val());
            });
            if (selected.length == 0) {
                $("#mError_AAH h4").text("Sin Selección");
                $("#mError_AAH button").attr("class", "btn btn-danger");
                $("#mError_AAH p").text("No se ha seleccionado ninguna determinación.");
                $("#mError_AAH").modal();
            } else {
                fn_Graba_resultado_defecto_deter_solicitada(selected);
            }
        });

        let tableQuita;
        $("#btn-quitar-estado").on("click", async () => {
            const id = getParameterByNameMaster("ID");

            if (!id) return;

            $("#modal-quitar-estado").modal();

            modal_show();
            let examenesDeLaAtencion = await fillExamenesRlsAreaSeccPrevs({ idAtencion: ID_ATE || 0 });
            Hide_Modal();

            const checkBoxPrinter = (value) => `<input type="checkbox" 
                                                class="form-check-input manitos2" 
                                                style="width:20px;height:20px;"
                                                type='checkbox'
                                                value='${value}'
                                                name='cbQuitarEstado'>`
            tableQuita?.destroy();
            $("#Div_DataTable_Quitar_Estado").empty().append($("<table>", { id: "DataTable_Quita_Estado", class: "display table table-hover table-striped table-iris", width: "100%", cellspacing: "0" }));
            $("#DataTable_Quita_Estado").append($("<thead>", { class: "cabzera" }), $("<tbody>"));

            $("#DataTable_Quita_Estado thead").append($("<tr>").append(
                $("<th>", { style: "text-align: center;" }).text("Examen"),
                $("<th>", { style: "text-align: center;" }).text("Quitar Estado")
            ));
            examenesDeLaAtencion.forEach(item => {
                $("#DataTable_Quita_Estado tbody").append($("<tr>").append(
                    $("<td>").text(item.CF_DESC),
                    $("<td>").html(checkBoxPrinter(item.ID_CODIGO_FONASA))
                ));
            });
        });

        $("#btn-guardar-quitar-estado").on("click", async () => {
            const examenesSeleccionados = [];
            $("input:checkbox[name='cbQuitarEstado']:checked").each(function () {
                examenesSeleccionados.push($(this).val());
            });

            if (examenesSeleccionados.length === 0) {
                Swal.fire({
                    title: 'Información',
                    text: 'Debe seleccionar un examen haciendo clic en las cajas de selección en la columna Quitar Estado de la tabla.',
                    icon: 'info',
                });
                return;
            }

            const body = {
                ID_ATENCION: ID_ATE,
                ID_CODIGO_FONASA: examenesSeleccionados,
                ID_USUARIO: parseInt(Galletas.getGalleta("ID_USER")),
            };

            if (!body.ID_USUARIO) {
                window.location.href = "/";
                return;
            }


            const respuesta = new IrisResponse(await fetcher('Ate_Resultados_3.aspx/Quitar_Estado_Examen', { body }));
            if (respuesta.code < 200 && respuesta.code > 299) {
                Swal.fire({
                    title: 'Información',
                    text: 'Ocurrió un error al intentar quitar los estados.',
                    icon: 'warning',
                });
                return;
            }
            Swal.fire({
                title: 'Éxito',
                text: 'Estados quitados con éxito.',
                icon: 'success',
            });
        })

        $("#btn-critico-manual").on("click", async () => {
            const resultadoSeleccionado = objData_Dtt[parseInt($(`#Dtt_Exam tbody .tr_selected`).attr("data-index"))]?.Res.ID_RES || 0;
            if (resultadoSeleccionado === 0) {
                Swal.fire({
                    title: 'Información',
                    text: 'Debe seleccionar un resultado haciendo clic en la tabla.',
                    icon: 'info',
                });
                return;
            }
            const body = { ID_ATE_RES: resultadoSeleccionado };
            const filasAlteradas = await fetcher('Ate_Resultados_3.aspx/Guarda_Critico_Manual', { body });
            if (filasAlteradas === 0) {
                Swal.fire({
                    title: 'Información',
                    text: 'No se pudo guardar el valor cómo Crítico porque no ha sido validado.',
                    icon: 'warning',
                });
                return;
            }
            Swal.fire({
                title: 'Éxito',
                text: 'Crítico guardado con éxito.',
                icon: 'success',
            });
        });

        $("#Btn_PDF").click(() => {
            // console.log("click!");
            if ($("#Sel_Exam").val() != 0 && $("#Txt_NumAte").val() != "") {
                // console.log("A");


                window.open("http://172.20.19.200/presentacion/Pacientes/verexamenessolo.asp?dato1=" + (objData_Pac.ID_ATENCION * 2) + "&dato2=" + (objData_Pac.ID_ATENCION * 5) + "&dato3=" + (objData_Dtt[0].Exam.ID_PER) + "&dato4=" + (objData_Dtt[0].Exam.ID_PER * 5));


                //IRIS_WEBF_CMVM_BUSCA_ID_PER_BY_ID_CF(objData_Dtt[0].Exam.ID_PER);

            } else {
                // console.log("B");
                $("#mError_AAH h4").text("Seleccione Examen");
                $("#mError_AAH button").attr("class", "btn btn-danger");
                $("#mError_AAH p").text("Estimado usuario, debe seleccionar un examen para generar una vista previa.");
                $("#mError_AAH").modal();
                $("#Id_Conte").hide();
            }


        });

        $("#btn-pendientes").click(() => {

            $("#modal-pendientes").modal();
        });

        $("#btn-agregar-quitar-examenes").click(() => {
            const id = getParameterByNameMaster("ID");
            if (id) {
                $("#modal-agregar-quitar-examenes").modal();
                $("#Naten")
                    .val($("#Txt_NumAte").val())
                    .trigger($.Event('keydown', { keyCode: 13 }));
            }
        });


        $("#eModal2").on("shown.bs.modal", function () {
            // dibuja la tabla cuando termina la animación del show modal para que las columnas se ajusten
            $("#DataTable_pac").DataTable().draw();
        });



        $("#btn_Busca_Ate_Sec").click(() => {
            Ajax_Ate_Seccion();
        });

        $("#btn_Busca_Ate_Sec_Pendientes").click(() => {
            Ajax_Ate_Seccion_Pendientes();
        });

        $("#btn_Busca_Ate_Sec_pendiente").click(() => Ajax_examen_Pendientes());

        revisarPermisosValidacion();
        Ajax_Seccion();
        //General
        modal_show();
        Btn_Audit.setActive(false);
        document.title = `CARGANDO`;
        num_title_loop = setInterval(fn_title_loop, 250);
        //Primera Carga
        objAJAX_Sel_Exam.requestNow();
        objAJAX_Sel_IntExt.requestNow();
        objAJAX_Sel_Proc.requestNow();
        //Modal Históricos
        $("#mdlHistPruebas").on("hidden.bs.modal", (e) => {
            if (bol_toHistCf == true) {
                Btn_GraphAlt.setActive(false);
                $("#mdlHistExam").modal("show");
            }
            if (bol_toHistPru == true) {
                //$("#mdlGraph").modal();
            }
        });
        //Modal Gráfico
        Btn_GraphAlt.setActive(false);
        $("#mdlGraph").on("hidden.bs.modal", (e) => {
            if (bol_toHistPru == true) {
                //$("#mdlHistPruebas").modal();
            }
        });
    });
    let fn_Charge_Exam = (option = 0) => {
        Sel_Exam.cleanAll();
        Sel_Exam.data = [];
        //Desarmar Array
        Sel_Exam.insertElem("<< Todos >>", 0);
        if (objSel_Secc != null) {
            objSel_Secc.forEach(ayyy => {
                let xItem = JSON.parse(decodeURI(atob(`${ayyy.ID}`)));

                xItem.ARR_ID = xItem.ARR_ID.map(idCf => structuredClone(objSel_Exam.find(exa => exa.ID == idCf)));
                xItem.ARR_ID.sort((a, b) => a.DESC.localeCompare(b.DESC));


                xItem.ARR_ID = xItem.ARR_ID.map(item => parseInt(item.ID));

                if (xItem.ID_SECC == 0) {
                    objSel_Exam.forEach(lmao => {
                        xItem.ARR_ID.forEach(ID_CF => {
                            if (lmao.ID == ID_CF) {
                                Sel_Exam.insertElem(lmao.DESC, lmao.ID);
                            }
                        });
                    });
                }
            });
        }
        Sel_Exam.setValue(option);
        seleccionarExaDeURL();
    };
    //Comportamiento Botones Inferiores------------------------------------------------------------
    let fn_Redim_Bottom_Bar = () => {
        let x = window.innerWidth;
        let y = window.innerHeight;
        let bolClass = $("body").hasClass("sidenav-toggled");
        // console.log(`Width: ${x}\nHeight: ${y}\nHasClass: ${bolClass}`);
        if (bolClass == true) {
            $(".float_buttons").addClass("float_buttons_toggled");
        }
        else {
            $(".float_buttons").removeClass("float_buttons_toggled");
        }
    };
    $(document).ready(() => {

        $("#Btn_P_Anti").click(() => {
            if (ID_ATE != "") {
                fn_Busca_Dtt_Cultivos();
            }

        });


        //$("#btnTrazabilidadAtencion").click(() => {
        //    const id = getParameterByNameMaster("ID");
        //    if (id) {
        //        window.open("/Check_List/Check_Point/Traza_Env_RecepLab.aspx?aWRBdGVuY2lvbg===" + id, '_blank');
        //    }
        //});

        $("#btnTrazabilidadAtencion").click(() => {
            const id = getParameterByNameMaster("ID");

            console.log(`ID: ${id}`)
            if (id) {
                const url = "/Check_List/Check_Point/Traza_Env_RecepLab_V2.aspx?aWRBdGVuY2lvbg===" + id;
                $("#trazabilidadFrame").attr("src", url);

                $("#trazabilidadFrame").on("load", function () {
                    const iframeContent = $(this).contents();
                    iframeContent.find("nav").css("display", "none"); // Oculta el elemento <nav> con CSS
                    iframeContent.find("body").removeClass("fixed-nav"); // Elimina la clase "fixed-nav" del body
                    iframeContent.find("body").removeClass("sidenav-toggled"); // Elimina la clase "sidenav-toggled" del body
                    iframeContent.find("#con_wra").css("margin", "0"); // Establece el margen a 0 para el elemento #con_wra
                });


                $("#trazabilidadModal").modal("show");
            } else {
                alert_ate_num();
            }
        });


        $("#btn-modal-paciente").on("click", async () => {
            const id = getParameterByNameMaster("ID");
            if (id) {
                $("#modal-editar-paciente").modal();
            } else {
                return
            }

            await Ajax_Diagnostico_pac();
            await Ajax_Sexo_pac();
            await Ajax_Nacionalidad_pac();
            await Ajax_DataTable_Antiguos(objData_Pac.ID_PACIENTE);

        });


        $("#btn_Agregar").click(() => {
            fn_Agrega_Panel();
        });

        $("#btn_Quitar").click(() => {
            fn_Quita_Panel();
        });

        $("#btn_Guardar_Panel").click(() => {
            // console.log("btn guarda panel");
            fn_Guarda_Panel();
        });

        fn_Redim_Bottom_Bar();
        $(window).resize(() => {
            fn_Redim_Bottom_Bar();
        });
        $("#sidenavToggler").click(() => {
            fn_Redim_Bottom_Bar();
        });
    });

    //MODAL CRIT
    function fn_Modal_Crit(ID_RES, CF_DESC, ATE_RES) {

        $("#mdlCritManual .modal-body p").html("");
        $("#btn_Acept_CM").attr("data-id-res", "");

        // console.log("mdl Crit: "+ID_RES+" "+CF_DESC+" "+ATE_RES);

        $("#mdlCritManual .modal-body p").html("Estimado usuario, ¿desea marcar <b>" + CF_DESC + " : " + ATE_RES + "</b> como valor crítico manual?");
        $("#btn_Acept_CM").attr("data-id-res", ID_RES);
        $("#mdlCritManual").modal();

    }


    // BUSCA CULTIVOS

    let Mx_CF_Cult = [{
        "ID_CODIGO_FONASA": "",
        "CF_COD": "",
        "CF_DESC": "",
        "USU_NIC": "",
        "ID_DET_ATE": "",
        "ATE_DET_V_ID_ESTADO": "",
        "ATE_DET_V_FECHA": ""
    }];

    function fn_Busca_Dtt_Cultivos() {
        $("#table_Cultivos tbody").empty();
        $("#table_Cargado tbody").empty();
        $("#table_No_Cargado tbody").empty();
        $("#dat_Ate").empty();
        Mx_CF_Cult = [];
        modal_show();
        var strParam = JSON.stringify({
            "ID_ATE": ID_ATE
        });
        $.ajax({
            "type": "POST",
            "url": "Ate_Resultados_3.aspx/Busca_Exa_Cultivo",
            "data": strParam,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": data => {
                Hide_Modal();
                // console.log(data.d);
                Mx_CF_Cult = data.d;
                if (Mx_CF_Cult.length === 0) {
                    Swal.fire({ icon: "info", title: "Información", text: "Esta atención no contiene exámenes que estén configurados para usar el panel de antibiogramas." });
                    return
                }

                $("#mdlPanel").modal("show");
                fn_Fill_Dtt_Cultivos();


            },
            "error": data => {
                Hide_Modal();
            }
        });

    }
    // Busca Exam agrega deter

    let Mx_Obs_Exam_agrega = [{
        "ID_CODIGO_FONASA": 0,
        "ID_PER": 0,
        "CF_COD": 0,
        "CF_DESC": 0,
        "ATE_DET_V_ID_ESTADO": 0,
        "ATE_DET_V_ID_USU": 0,
        "ATE_DET_V_FECHA": 0,
        "USU_NIC": 0,
        "ID_ATENCION": 0
    }];

    function fn_Busca_Obs_Exam() {
        var strParam = JSON.stringify({
            "ATE_NUM": $("#Txt_NumAte").val()
        });
        $.ajax({
            "type": "POST",
            "url": "Ate_Resultados_3.aspx/IRIS_WEBF_BUSCA_EXAMENES_OBSERVACION_H2M",
            "data": strParam,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": data => {
                // console.log(data.d);
                Mx_Obs_Exam_agrega = data.d;
                $("#Div_Exam_Agrega").empty();
                ID_ATENCHION = 0;
                ID_PERRRRRRCH = 0;
                $("#btnAgregaDeter").attr("disabled", true)
                if (Mx_Obs_Exam_agrega != null) {
                    Fill_DataTable_Exam_Agrega()
                }

            },
            "error": data => {
                //Hide_Modal();
            }
        });
    }



    function Fill_DataTable_Exam_Agrega() {
        $("<table>", {
            "id": "DataTable_Exam_Agrega",
            "class": "display",
            "width": "100%",
            "cellspacing": "0"
        }).appendTo("#Div_Exam_Agrega");

        $("#DataTable_Exam_Agrega").append(
            $("<thead>"),
            $("<tbody>")
        );
        $("#DataTable_Exam_Agrega").attr("class", "table table-hover table-striped table-iris");
        $("#DataTable_Exam_Agrega thead").attr("class", "cabzera");
        $("#DataTable_Exam_Agrega thead").append(
            $("<tr>").append(
                $("<th>", { "class": "textoReducido" }).text("#"),
                $("<th>", { "class": "textoReducido" }).text("Código"),
                $("<th>", { "class": "textoReducido" }).text("Descripción"),
                $("<th>", { "class": "textoReducido" }).text("Fecha"),
                $("<th>", { "class": "textoReducido" }).text("Hora"),
                $("<th>", { "class": "textoReducido" }).text("Usuario validación"),
                $("<th>", { "class": "textoReducido" }).text("validado")
                //$("<th>", { "class": "textoReducido" }).text("Imprimir")

            )
        );
        // console.log(Mx_Obs_Exam_agrega);
        for (let i = 0; i < Mx_Obs_Exam_agrega.length; i++) {
            $("#DataTable_Exam_Agrega tbody").append(
                $("<tr>", {
                    "data-id-cf": Mx_Obs_Exam_agrega[i].ID_CODIGO_FONASA,
                    "class": "manito"
                }).append(
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Obs_Exam_agrega[i].CF_COD),
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Obs_Exam_agrega[i].CF_DESC),
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                        if (Mx_Obs_Exam_agrega[i].ATE_DET_V_ID_ESTADO == 6 || Mx_Obs_Exam_agrega[i].ATE_DET_V_ID_ESTADO == 14) {
                            return moment(Mx_Obs_Exam_agrega[i].ATE_DET_V_FECHA).format("DD/MM/YYYY");
                        } else {
                            return "";
                        }
                    }),
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                        if (Mx_Obs_Exam_agrega[i].ATE_DET_V_ID_ESTADO == 6 || Mx_Obs_Exam_agrega[i].ATE_DET_V_ID_ESTADO == 14) {
                            return moment(Mx_Obs_Exam_agrega[i].ATE_DET_V_FECHA).format("HH:mm");
                        } else {
                            return "";
                        }
                    }),
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                        if (Mx_Obs_Exam_agrega[i].ATE_DET_V_ID_ESTADO == 6 || Mx_Obs_Exam_agrega[i].ATE_DET_V_ID_ESTADO == 14) {
                            return Mx_Obs_Exam_agrega[i].USU_NIC;
                        } else {
                            return "";
                        }
                    }),
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(function () {
                        if (Mx_Obs_Exam_agrega[i].ATE_DET_V_ID_ESTADO == 6 || Mx_Obs_Exam_agrega[i].ATE_DET_V_ID_ESTADO == 14) {
                            return "SI";
                        } else {
                            return "";
                        }
                    })
                )
            );
        }
        $("#DataTable_Exam_Agrega tbody tr").on("click", e => {

            const idCf = e.currentTarget.getAttribute("data-id-cf");

            const objetoCliqueado = Mx_Obs_Exam_agrega.find(item => item.ID_CODIGO_FONASA == idCf);

            const idAte = objetoCliqueado.ID_ATENCION;
            const idPer = objetoCliqueado.ID_PER;

            Ajax_Get_values_to_Pendiente(idAte, idPer, idCf, idPer, idPer, idPer, idPer, idPer)

        });

        active_tr();
        $("#mdlObsExam").modal();
    }
    // Busca Derrminación solicitada o NO solicitada

    let Mx_Obs_Deter_soli_o_no_soli = [{
        "ID_PRUEBA": 0,
        "PRU_COD": 0,
        "PRU_DESC": 0,
        "ID_U_MEDIDA": 0,
        "ID_TP_RESULTADO": 0,
        "ID_T_MUESTRA": 0,
        "ID_PER": 0,
        "PRU_SOLICITADO": 0,
        "T_MUESTRA_DESC": 0,
        "UM_DESC": 0,
        "TP_RESUL_DESC": 0,
        "IN_ATENCION": 0
    }];

    function fn_Busca_Deter_soli_o_no_soli() {
        var strParam = JSON.stringify({
            "ID_ATENCION": ID_ATENCHION,
            "ID_PER": ID_PERRRRRRCH,
            "SOLICITADA": 0,//$("#slc_soli_o_no_soli").val(),
            "ID_ESTADO": 1
        });
        $.ajax({
            "type": "POST",
            "url": "Ate_Resultados_3.aspx/IRIS_WEBF_BUSCA_PRUEBA_NO_SOLICITADA_Y_SOLICITADA_TODOS",
            "data": strParam,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": data => {
                // console.log(data.d);
                Mx_Obs_Deter_soli_o_no_soli = data.d;

                $("#btnAgregaDeter").attr("disabled", true)
                $("#Div_Exam_Agrega2").empty();
                if (Mx_Obs_Deter_soli_o_no_soli != null) {
                    Fill_DataTable_Exam_Agrega_deter_soli_o_no_soli()
                    $("#mdlObsExa2").modal();
                }

            },
            "error": data => {
                //Hide_Modal();
            }
        });
    }

    let tablaObs;
    function Fill_DataTable_Exam_Agrega_deter_soli_o_no_soli() {
        tablaObs?.destroy();
        $("<table>", { id: "DataTable_Exam_Agrega2", class: "display", width: "100%", cellspacing: "0" }).appendTo("#Div_Exam_Agrega2");
        $("#DataTable_Exam_Agrega2").append($("<thead>"), $("<tbody>"));
        $("#DataTable_Exam_Agrega2").attr("class", "table table-hover table-striped table-iris");
        $("#DataTable_Exam_Agrega2 thead").attr("class", "cabzera");
        $("#DataTable_Exam_Agrega2 thead").append($("<tr>").append(
            $("<th>", { "class": "textoReducido" }).text("#"),
            $("<th>", { "class": "textoReducido" }).text("Código"),
            $("<th>", { "class": "textoReducido" }).text("Descripción"),
            $("<th>", { "class": "textoReducido" }).text("Tipo Resultado"),
            $("<th>", { "class": "textoReducido" }).text("Unidad"),
            $("<th>", { "class": "textoReducido" }).text("Tipo Muestra"),
            $("<th>", { "class": "textoReducido" }).text("Cargar")
        ));
        const checkBoxPrinter = (id, value) => `<input type="checkbox" 
                                class="form-check-input manitos2" 
                                style="width:20px;height:20px;"
                                type='checkbox'
                                id='Hasdasd${id}'
                                value='${value}'
                                name='observacionesAgregar'>`
        for (let i = 0; i < Mx_Obs_Deter_soli_o_no_soli.length; i++) {
            const cargado = Mx_Obs_Deter_soli_o_no_soli[i].IN_ATENCION == 1;
            $("#DataTable_Exam_Agrega2 tbody").append(
                $("<tr>").append(
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Obs_Deter_soli_o_no_soli[i].PRU_COD),
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Obs_Deter_soli_o_no_soli[i].PRU_DESC),
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Obs_Deter_soli_o_no_soli[i].TP_RESUL_DESC),
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Obs_Deter_soli_o_no_soli[i].UM_DESC),
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Obs_Deter_soli_o_no_soli[i].T_MUESTRA_DESC),
                    $("<td>", { style: `text-align: center; background-color: ${cargado ? "#88f588" : "#ff6969"};` }).html(
                        cargado ? "Cargada" : checkBoxPrinter(i, Mx_Obs_Deter_soli_o_no_soli[i].ID_PRUEBA)
                    )
                )
            );
        }


        tablaObs = $("#DataTable_Exam_Agrega2").DataTable({
            "iDisplayLength": 100,
            "info": true,
            "bPaginate": true,
            "bFilter": true,
            "bSort": true,
            "language": {
                "lengthMenu": "Mostrar: _MENU_",
                "zeroRecords": "No hay concidencias",
                "info": "Mostrando Página _PAGE_ de _PAGES_",
                "infoEmpty": "No hay concidencias",
                "infoFiltered": "(Se busco en _MAX_ registros )",
                "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>",
                "paginate": {
                    "previous": "Anterior",
                    "next": "Siguiente"
                },
            },
            "scrollY": "50vh",
            "scrollCollapse": true,
        });
        setTimeout(function () {
            tablaObs.columns.adjust().draw();
        }, 200);


        //active_tr();

    }
    // graba resultado por defecto determinacion solicitada o no
    function fn_Graba_resultado_defecto_deter_solicitada(seleccionados) {
        var strParam = JSON.stringify({
            "ID_ATENCION": ID_ATENCHION,
            "ID_PER": ID_PERRRRRRCH,
            "ID_CF": ID_FONASSSAAAA,
            "IDS_PRUEBAS": seleccionados
        });
        $.ajax({
            "type": "POST",
            "url": "Ate_Resultados_3.aspx/IRIS_WEBF_GRABA_RESULTADO_ATENCION_DEFECTO_H2M",
            "data": strParam,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": data => {
                // console.log(data.d);
                //Mx_Obs_Deter_soli_o_no_soli = data.d;

                $("#btnAgregaDeter").attr("disabled", true)
                $("#Div_Exam_Agrega2").empty();
                var e = jQuery.Event("keypress");
                e.which = 13; // Enter key
                e.keyCode = 13;
                $("#Txt_NumAte").trigger(e)
                //$("#mError_AAH h4").text("Determinaciones Cargadas");
                //$("#mError_AAH button").attr("class", "btn btn-success");
                //$("#mError_AAH p").text("Las determinaciones se han agregado correctamente.");
                //$("#mError_AAH").modal();

                if ($("#mError_AAH_Recarga_deter_Defecto").is(":visible") == false) {
                    $("#mError_AAH_Recarga_deter_Defecto").modal();
                }

            },
            "error": data => {
                //Hide_Modal();
            }
        });
    }

    function fn_Fill_Dtt_Cultivos() {

        $("#dat_Ate").html("<span class='w-100 text-center mb-3' style='color:#014b5d !important'><b>Folio: " + objData_Pac.ATE_NUM + " | " + objData_Pac.PAC_NOMBRE + " " + objData_Pac.PAC_APELLIDO + " | " + objData_Pac.PAC_RUT + " | F. Ate: " + moment(objData_Pac.ATE_FECHA).format("DD/MM/YYYY") + " | " + objData_Pac.EDAD + " | " + objData_Pac.SEXO_DESC + "</b></span>");
        // console.log("FILL DTT CULTIVOS");
        let i = 0;
        Mx_CF_Cult.forEach(aah => {
            $("#table_Cultivos tbody").append(
                $("<tr>", { "class": "manito", "name": "p_Anti", "data-index": i }).append(
                    $("<td>").css("height", "0").text(aah.CF_COD),
                    $("<td>").css("height", "0").text(aah.CF_DESC),
                    $("<td>").css("height", "0").text(moment(aah.ATE_DET_V_FECHA).format("DD-MM-YYYY HH:mm:ss")),
                    $("<td>").css("height", "0").text(aah.USU_NIC),
                    $("<td>").css("height", "0").html(() => {
                        if (aah.ATE_DET_V_ID_ESTADO == 6 || aah.ATE_DET_V_ID_ESTADO == 14) {
                            return "<input type='checkbox' checked/>";
                        } else {
                            return "<input type='checkbox'/>";
                        }
                    }),
                    $("<td>").css("height", "0").html(() => {
                        if (aah.ATE_DET_V_ID_ESTADO == 14) {
                            return "<input type='checkbox' checked/>";
                        } else {
                            return "<input type='checkbox'/>";
                        }
                    })
                )
            );
            i += 1;
        });

        $("tr[name='p_Anti']").click(e => {
            let d_index = $(e.currentTarget).attr("data-index");
            fn_Busca_Dtt_No_Cargados(Mx_CF_Cult[d_index].ID_CODIGO_FONASA, ID_ATE);
            fn_Busca_Dtt_Cargados(Mx_CF_Cult[d_index].ID_CODIGO_FONASA, ID_ATE);
        });
        Hide_Modal();
    }

    // Busca Panel No Cargado

    let Mx_Ant_No_Cargado = [{
        "ID_CODIGO_FONASA": "",
        "CF_DESC": ""
    }];

    function fn_Busca_Dtt_No_Cargados(_ID_CF, _ID_ATE) {
        $("#table_No_Cargado tbody").empty();
        Mx_Ant_No_Cargado = [];
        //modal_show();
        var strParam = JSON.stringify({
            "ID_CF": _ID_CF,
            "ID_ATE": _ID_ATE
        });

        $.ajax({
            "type": "POST",
            "url": "Ate_Resultados_3.aspx/Busca_Exa_Ant_No_Cargado",
            "data": strParam,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": data => {
                // console.log(data.d);
                Mx_Ant_No_Cargado = data.d;

                if (Mx_Ant_No_Cargado != null) {
                    fn_Fill_Dtt_No_Cargados();
                }
            },
            "error": data => {
                //Hide_Modal();
            }
        });
    }

    function fn_Fill_Dtt_No_Cargados() {
        // console.log("FILL DTT NO CARGADOS");
        let i = 0;
        Mx_Ant_No_Cargado.forEach(aah => {
            $("#table_No_Cargado tbody").append(
                $("<tr>", { "class": "manito", "name": "p_No_C", "data-index": i, "data-type": "No_Cargado" }).append(
                    $("<td>").css("height", "0").text(aah.CF_DESC),
                    $("<td>").css("height", "0").html(() => {
                        return "<input type='checkbox' name='chk_No_Cargado'/>";
                    })
                )
            );
            i += 1;
        });

        $("input[name='chk_No_Cargado']").click((e) => {
            //e.stopImmediatePropagation();
            let index = $(e.currentTarget).parent().parent().attr("data-index");
            let checked = $(e.currentTarget).prop("checked");
            let type = $(e.currentTarget).parent().parent().attr("data-type");
            // console.log(index+" "+checked);
            if (checked == true) {
                if (Mx_Check_NC.length > 0) {
                    let cnt = 0;
                    Mx_Check_NC.forEach(aah => {
                        if (aah == index) {
                            cnt = 1;
                        }
                    });
                    if (cnt == 0) {
                        Mx_Check_NC.push({ "index": index, "type": type });
                    }
                    // console.log(Mx_Check_NC);
                } else {
                    Mx_Check_NC.push({ "index": index, "type": type });
                    // console.log(Mx_Check_NC);
                }
            } else {
                let Mx_Index = Mx_Check_NC.findIndex(x => x.index === index && x.type === type);
                Mx_Check_NC.splice(Mx_Index, 1);
                // console.log(Mx_Check_NC);
            }
        }).one();
    }

    // Busca Panel Cargado

    let Mx_Ant_Cargado = [{
        "ID_REL_CF_ANTIB": "",
        "ID_CODIGO_FONASA": "",
        "ID_ATENCION": "",
        "ID_DET_ATE": "",
        "ID_CF_ANTIBIOGRAMA": "",
        "CF_DESC": "",
        "CF_COD": "",
        "CF_DESC_CULT": "",
        "ATE_NUM": ""
    }];

    function fn_Busca_Dtt_Cargados(_ID_CF, _ID_ATE) {
        $("#table_Cargado tbody").empty();
        Mx_Ant_Cargado = [];
        //modal_show();
        var strParam = JSON.stringify({
            "ID_CF": _ID_CF,
            "ID_ATE": _ID_ATE
        });
        $.ajax({
            "type": "POST",
            "url": "Ate_Resultados_3.aspx/Busca_Exa_Ant_Cargado",
            "data": strParam,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": data => {
                // console.log(data.d);
                Mx_Ant_Cargado = data.d;

                if (Mx_Ant_Cargado != null) {
                    fn_Fill_Dtt_Cargados();
                }

            },
            "error": data => {
                //Hide_Modal();
            }
        });
    }

    function fn_Fill_Dtt_Cargados() {
        // console.log("FILL DTT CARGADOS");
        let i = 0;
        Mx_Ant_Cargado.forEach(aah => {
            $("#table_Cargado tbody").append(
                $("<tr>", { "class": "manito", "name": "p_C", "data-index": i, "data-type": "Cargado" }).append(
                    $("<td>").css("height", "0").text(aah.CF_DESC),
                    $("<td>").css("height", "0").html(() => {
                        return "<input type='checkbox' name='chk_Cargado'/>";
                    }),
                    $("<td>").css("height", "0").text(aah.CF_DESC_CULT),
                    $("<td>").css("height", "0").text(aah.ATE_NUM)
                )
            );
            i += 1;
        });

        $("input[name='chk_Cargado']").click((e) => {
            //e.stopImmediatePropagation();
            let index = $(e.currentTarget).parent().parent().attr("data-index");
            let checked = $(e.currentTarget).prop("checked");
            let type = $(e.currentTarget).parent().parent().attr("data-type");
            // console.log(index+" "+checked);
            if (checked == true) {
                if (Mx_Check_C.length > 0) {
                    let cnt = 0;
                    Mx_Check_C.forEach(aah => {
                        if (aah == index) {
                            cnt = 1;
                        }
                    });
                    if (cnt == 0) {
                        Mx_Check_C.push({ "index": index, "type": type });
                    }
                    // console.log(Mx_Check_C);
                } else {
                    Mx_Check_C.push({ "index": index, "type": type });
                    // console.log(Mx_Check_C);
                }
            } else {
                let Mx_Index = Mx_Check_C.findIndex(x => x === index && x.type === type);
                Mx_Check_C.splice(Mx_Index, 1);
                // console.log(Mx_Check_C);
            }
        }).one();
    }

    // Agregar Quitar Panel

    function fn_Agrega_Panel() {
        modal_show();
        Mx_Check_NC.forEach(aah => {
            $("tr[name='p_No_C'][data-index='" + aah.index + "'][data-type='" + aah.type + "']").remove();

            $("#table_Cargado tbody").append(
                $("<tr>", { "class": "manito", "name": "p_C", "data-index": aah.index, "data-type": aah.type }).append(
                    $("<td>").css("height", "0").text(() => {
                        if (aah.type == "No_Cargado") {
                            return Mx_Ant_No_Cargado[aah.index].CF_DESC;
                        } else {
                            return Mx_Ant_Cargado[aah.index].CF_DESC;
                        }

                    }),
                    $("<td>").css("height", "0").html(() => {
                        return "<input type='checkbox' name='chk_Cargado'/>";
                    }),
                    $("<td>").css("height", "0").text(""),
                    $("<td>").css("height", "0").text("")
                )
            );


        });
        $("input[name='chk_Cargado']").unbind();
        $("input[name='chk_Cargado']").click((e) => {
            //e.stopImmediatePropagation();
            let index = $(e.currentTarget).parent().parent().attr("data-index");
            let checked = $(e.currentTarget).prop("checked");
            let type = $(e.currentTarget).parent().parent().attr("data-type");
            //// console.log(index+" "+checked);
            if (checked == true) {
                if (Mx_Check_C.length > 0) {
                    let cnt = 0;
                    Mx_Check_C.forEach(aah => {
                        if (aah == index) {
                            cnt = 1;
                        }
                    });
                    if (cnt == 0) {
                        Mx_Check_C.push({ "index": index, "type": type });
                    }
                    //// console.log(Mx_Check_C);
                } else {
                    Mx_Check_C.push({ "index": index, "type": type });
                    //// console.log(Mx_Check_C);
                }
            } else {
                let Mx_Index = Mx_Check_C.findIndex(x => x === index && x.type === type);
                Mx_Check_C.splice(Mx_Index, 1);
                //// console.log(Mx_Check_C);
            }
        }).one();

        Mx_Check_NC = [];
        Hide_Modal();
    }

    function fn_Quita_Panel() {
        modal_show();
        let c_index = $("tr[name='p_Anti'][class='manito active']").attr("data-index");
        let _EST_VALIDA = Mx_CF_Cult[c_index].ATE_DET_V_ID_ESTADO;

        if (_EST_VALIDA != 6 && _EST_VALIDA != 14) {
            Mx_Check_C.forEach(aah => {
                $("tr[name='p_C'][data-index='" + aah.index + "'][data-type='" + aah.type + "']").remove();

                $("#table_No_Cargado tbody").append(
                    $("<tr>", { "class": "manito", "name": "p_No_C", "data-index": aah.index, "data-type": aah.type }).append(
                        $("<td>").css("height", "0").text(() => {
                            if (aah.type == "No_Cargado") {
                                return Mx_Ant_No_Cargado[aah.index].CF_DESC;
                            } else {
                                return Mx_Ant_Cargado[aah.index].CF_DESC;
                            }

                        }),
                        $("<td>").css("height", "0").html(() => {
                            return "<input type='checkbox' name='chk_No_Cargado'/>";
                        })
                    )
                );
            });
            $("input[name='chk_No_Cargado']").unbind();
            $("input[name='chk_No_Cargado']").click((e) => {
                //e.stopImmediatePropagation();
                let index = $(e.currentTarget).parent().parent().attr("data-index");
                let checked = $(e.currentTarget).prop("checked");
                let type = $(e.currentTarget).parent().parent().attr("data-type");
                //// console.log(index+" "+checked);
                if (checked == true) {
                    if (Mx_Check_NC.length > 0) {
                        let cnt = 0;
                        Mx_Check_NC.forEach(aah => {
                            if (aah == index) {
                                cnt = 1;
                            }
                        });
                        if (cnt == 0) {
                            Mx_Check_NC.push({ "index": index, "type": type });
                        }
                        //// console.log(Mx_Check_NC);
                    } else {
                        Mx_Check_NC.push({ "index": index, "type": type });
                        //// console.log(Mx_Check_NC);
                    }
                } else {
                    let Mx_Index = Mx_Check_NC.findIndex(x => x.index === index && x.type === type);
                    Mx_Check_NC.splice(Mx_Index, 1);
                    //// console.log(Mx_Check_NC);
                }
            }).one();

            Mx_Check_C = [];
            Hide_Modal();
        } else {
            // console.log("CF VALIDADO O IMPRESO");
            Hide_Modal();
            $(`#mdlAlert .modal-header .modal-title`).text("Examen Validado o Impreso");
            $(`#mdlAlert .modal-body`).empty();
            $(`#mdlAlert .modal-body`).append($(`<span>`).text("Estimado usuario, No puede quitar paneles asociados a exámenes validados o impresos."));
            $(`#mdlAlert`).modal();
        }
    }

    // Guardar Panel

    function fn_Guarda_Panel() {

        //// console.clear();
        // console.log("GUARDA PANEL");

        let NCar = [];
        let Car = [];
        let Mx_Guarda_Panel = [];

        Car = $("tr[name='p_C']");
        NCar = $("tr[name='p_No_C']");

        let c_index = $("tr[name='p_Anti'][class='manito active']").attr("data-index");
        let ID_CF_CULT = Mx_CF_Cult[c_index].ID_CODIGO_FONASA;

        //// console.log(Mx_Ant_Cargado);
        //// console.log(Mx_Ant_No_Cargado);

        // Buscar data-type Cargado
        for (var i = 0; i < Car.length; i++) {
            let _type = Car[i].getAttribute("data-type");
            let _index = Car[i].getAttribute("data-index");
            let _prev = $("#Sel_Prev").val();

            if (_type == "No_Cargado") {
                //// console.log(_index+" "+_type);
                Mx_Guarda_Panel.push({ "ID_PANEL": Mx_Ant_No_Cargado[_index].ID_CODIGO_FONASA, "ID_ATE": ID_ATE, "ID_CF_CULT": ID_CF_CULT, "ID_PREVE": _prev, "TYPE": "Crea" });
            }
        }

        // Buscar data-type No_Cargado
        for (i = 0; i < NCar.length; i++) {
            let _type = NCar[i].getAttribute("data-type");
            let _index = NCar[i].getAttribute("data-index");
            let _prev = $("#Sel_Prev").val();


            if (_type == "Cargado") {
                //// console.log(_index+" "+_type);
                Mx_Guarda_Panel.push({ "ID_PANEL": Mx_Ant_Cargado[_index].ID_CF_ANTIBIOGRAMA, "ID_ATE": Mx_Ant_Cargado[_index].ID_ATENCION, "ID_CF_CULT": ID_CF_CULT, "ID_PREVE": _prev, "TYPE": "Quita" });
            }
        }

        if (Mx_Guarda_Panel.length > 0) {
            // console.log(Mx_Guarda_Panel);
            modal_show();
            var strParam = JSON.stringify({
                "Mx_Panel": Mx_Guarda_Panel
            });
            $.ajax({
                "type": "POST",
                "url": "Ate_Resultados_3.aspx/Guarda_Panel_Cultivo",
                "data": strParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    // console.log(data.d);
                    $("tr[name='p_Anti'][class='manito active']").trigger("click");

                    objAJAX_Pac_Data.requestNow({
                        NUM_ATE: $("#Txt_NumAte").val() || 0,
                        USU_ID_PROC: Galletas.getGalleta("USU_TM")
                    });

                    Hide_Modal();
                },
                "error": data => {
                    Hide_Modal();
                }
            });

        }
    }


    function modal_Crit(ID_RES, TITLE, TEXT, Z) {

        const existeModal = document.getElementById("mdl" + ID_RES);
        if (existeModal === null) {
            $("#mdls").append(
                $("<div>", {
                    "id": "mdl" + ID_RES,
                    "class": "modal fade",
                    "data-backdrop": "static",
                    "style": "z-index:" + Z + " !important"
                })
            );

            $("<div>", {
                "class": "modal-dialog modal-md"
            }
            ).append(
                $("<div>", {
                    "id": "mdl_cont" + ID_RES,
                    "class": "modal-content border-danger"
                })
            ).appendTo($("#mdl" + ID_RES));

            $("<div>", {
                "class": "modal-header bg-danger text-white text-center"
            }
            ).append(
                $("<h4>", {
                    "id": "mdl_title" + ID_RES,
                    "class": "modal-title w-100"
                })
            ).appendTo($("#mdl_cont" + ID_RES));

            $("<div>", {
                "id": "mdl_text" + ID_RES,
                "class": "modal-body pt-6 pb-6 text-left"
            }
            ).appendTo($("#mdl_cont" + ID_RES));

            $("<div>", {
                "class": "modal-footer"
            }
            ).html("<button type='button' class='btn btn-primary' data-dismiss='modal'><i class='fa fa-check' aria-hidden='true'></i><span>Aceptar</span></button>").appendTo($("#mdl_cont" + ID_RES));
        }

        $("#mdl_title" + ID_RES).text(TITLE);
        $("#mdl_text" + ID_RES).html(TEXT);
        Hide_Modal();

        $("#mdl" + ID_RES).modal({ backdrop: false }).one();


        //$("#mdl"+ID_RES).modal({backdrop: false});
    }


    //Modal Resultados Codificados-----------------------------------------------------------------
    $(document).ready(() => {

        $(`#Btn_RC_Add`).click((Me) => {
            let xVal = Txt_ResCod_Out.value.replace(/\./gi, ",");
            $("#Dtt_Exam .tr_selected input[type=text]").val(xVal);
            let xEvent = $.Event("keypress");
            let objInput = document.querySelector("#Dtt_Exam .tr_selected input[type=text]");
            xEvent.currentTarget = objInput;
            xEvent.which = 13;
            xEvent.keyCode = 13;
            fn_Write(xEvent);
            fn_Calc();
            keyEnter = true;
            $(objInput).parents("tr").next().find("input[type=text]").focus();
        });
    });
})(ATE_RES || (ATE_RES = {}));
//# sourceMappingURL=Ate_Resultados_3.js.map
