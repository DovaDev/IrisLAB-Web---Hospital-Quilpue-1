/// <reference path="../js/webform.ts" />
/// <reference path="../scripts/typings/jquery/math.d.ts" />
///// <reference path="D:\Repos\IRIS_HOLANDA_MULTIPLE\iris_holanda_multiple\Presentacion\js/Galletas.js" />

import { fillExamenesSeccionArea } from "../js/es6-modules/Examenes.js";
import fetcher from "../js/es6-modules/FetcherV1.js";
import IrisResponse from "../js/es6-modules/IrisResponse.js";
import fillSeccionesAreas, { fillAreas, fillSecciones } from "../js/es6-modules/SeccionesAreas.js";
import fillTiposCritico from "../js/es6-modules/TiposCritico.js";

var ATE_RES;
let ID_ATE;

let Mx_Check_C = [];
let Mx_Check_NC = [];
let Mx_Check_Guardar = [];
let ACTIVA_PENDIENTES = 0;
let ACTIVA_PENDIENTES_R = 0;

const perfilesValidadores = [1, 401]

var ID_ATENCHION = 0;
var ID_PERRRRRRCH = 0;
var ID_FONASSSAAAA = 0;

let objAJAX_Pac_Data;

let flagMsgTrigliceridos = false;
let noMostrarCritsDe = { 0: [] };


//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
let updateEdad = true;
let foliosEdadLista = [];
let filaPruebasEdad = [];

//@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

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

    const cargaCheckExamActivo = () => {

        //const idAreaClicExaPendiente = getParameterByNameMaster("AR");
        //if (idAreaClicExaPendiente > 0) {
        //    if (areasCargadas.some(item => item.ID_AREA == idAreaClicExaPendiente)) {
        //        $("#slct-area-main").val(idAreaClicExaPendiente);
        //    }
        //}
        //const idSeccionClicExaPendiente = getParameterByNameMaster("SC");
        //if (idSeccionClicExaPendiente > 0) {
        //    if (seccionesCargadas.some(item => item.ID_SECCION == idSeccionClicExaPendiente)) {
        //        $("#slct-seccion-main").val(idSeccionClicExaPendiente);
        //    }
        //}
        const idRlsLsClicExaPendiente = getParameterByNameMaster("RLS");
        if (idRlsLsClicExaPendiente > 0) {
            if (seccionesAreasCargadas.some(item => item.ID_RLS_LS == idRlsLsClicExaPendiente)) {
                $("#slct-rls-area-seccion-main").val(idRlsLsClicExaPendiente);
            }
        }
        const idCodFonaClicExaPendiente = getParameterByNameMaster("CF");
        if (idCodFonaClicExaPendiente > 0) {
            if (examenesCargados.some(item => item.ID_CODIGO_FONASA == idCodFonaClicExaPendiente)) {
                $("#slct-examen-main").val(idCodFonaClicExaPendiente);
            }
        }
        if (idCodFonaClicExaPendiente > 0 && !document.getElementById("cb-examen")?.checked) {
            $("#cb-examen").trigger("click");
        }
        if (idSeccionClicExaPendiente > 0 && !document.getElementById("cb-seccion")?.checked) {
            $("#cb-seccion").trigger("click");
        }
        if (idAreaClicExaPendiente > 0 && !document.getElementById("cb-area")?.checked) {
            $("#cb-area").trigger("click");
        }
        //if (idRlsLsClicExaPendiente > 0 && !document.getElementById("cb-rls-area-seccion")?.checked) {
        //    console.log("VALORES IMPORTANTES: ", $("#slct-rls-area-seccion-main").val())
        //    console.log("Entro a cb-rls-area-seccion: ", document.getElementById("cb-rls-area-seccion"))
        //    $("#cb-rls-area-seccion").trigger("click");
        //}
        if (idRlsLsClicExaPendiente > 0 && $("#slct-rls-area-seccion").val() != 0) {
            if (!document.getElementById("cb-rls-area-seccion")?.checked) {
                $("#cb-rls-area-seccion").trigger("click");
            }
        }
        if ($("#cb-rls-area-seccion").is(':checked') && $("#slct-rls-area-seccion").val() == 0) {
            $("#cb-rls-area-seccion").trigger("click");
        }

        if ($("#Ddl_Proc_Ate_pendiente").val() != 0 && !$('#cb-procedencia').is(':checked')) {
            $('#cb-procedencia').trigger("click")
        }
        if ($("#Ddl_Proc_Ate_pendiente").val() == 0) {
            if ($('#cb-procedencia').is(':checked')) {
                $('#cb-procedencia').trigger("click")
            }
        }


        let recargarTabla = true;
        if (document.getElementById("cb-examen").checked) {
            recargarTabla && $("#slct-examen-main").trigger("change");
            recargarTabla = false;
        }
        //if (document.getElementById("cb-seccion").checked) {
        //    recargarTabla && $("#slct-seccion-main").trigger("change");
        //    recargarTabla = false;
        //}
        //if (document.getElementById("cb-area").checked) {
        //    recargarTabla && $("#slct-area-main").trigger("change");
        //    recargarTabla = false;
        //}
        if (document.getElementById("cb-rls-area-seccion").checked) {
            recargarTabla && $("#slct-rls-area-seccion-main").trigger("change");
            recargarTabla = false;
        }
    }

    let glob_con = 0;
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
            //Eventos
            switch (this.count) {
                case 2:
                    if (strUrlQuery == null || strUrlQuery == "ID=Znpvy0y6YSQ=") {
                        console.log('strUrl igual a null o igual a ID=Znpvy0y6YSQ', strUrlQuery)
                        await objAJAX_Sel_Prev.requestNow({
                            ID_PROC: Sel_Proc.getValue().value
                        });
                        await objAJAX_Sel_Prog.requestNow({
                            ID_PREV: Sel_Prev.getValue().value
                        });
                        //console.log('aca esta el prog (FONASA EJEM)', ID_PREV);

                        clearInterval(num_title_loop);
                        document.title = "Visor de Resultados";
                        Dtt_Exam.cleanTable("Por favor introduzca un Nro de Atención, en la casilla correspondiente, y presione Enter para Iniciar la búsqueda.");
                        Hide_Modal();
                        return;
                    }
                    objAJAX_Pac_Data.queryString = strUrlQuery;
                    await objAJAX_Pac_Data.requestNow();
                    break;
                case 4:
                    if (strUrlQuery == null) {
                        return;
                    }
                    Sel_Proc.setValue(objData_Pac.ID_PROCEDENCIA);
                    objAJAX_Sel_Prev.requestNow({
                        ID_PROC: objData_Pac.ID_PROCEDENCIA
                    }, () => {
                    });
                    break;
                case 5:
                    if (strUrlQuery == null) {
                        return;
                    }
                    Sel_Prev.setValue(objData_Pac.ID_PREVE);
                    objAJAX_Sel_Prog.requestNow({
                        ID_PREV: objData_Pac.ID_PREVE
                    });
                    console.log('aca esta el prog (FONASA EJEM) desde case 5', objData_Pac);

                    break;
                case 6:
                    if (strUrlQuery == null) {
                        return;
                    }
                    Sel_Prog.setValue(objData_Pac.ID_PROGRA);

                    objAJAX_Fill_Table.queryString = strUrlQuery;

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
                    cargaCheckExamActivo();
                    break;
                case 7:
                    if (strUrlQuery == null) {
                        return;
                    }
                    await fn_Make_Table();

                    await fn_Calc();
                    clearInterval(num_title_loop);
                    document.title = `Res ATE N°${objData_Pac.ATE_NUM}`;
                    Hide_Modal();
                    this.loaded = true;
                    this.count = 2;
            }
            return this.count;
        }
    }

    function Ajax_Ate_Seccion(pendientes = false) { // enviar este pendiente al pa si piden habilitar el botón pendiente para la busqueda de atenciones
        var strParam = JSON.stringify({
            DESDE: $("#fecha11").val(),
            HASTA: $("#fecha22").val(),
            ID_SEC: $("#Ddl_Seccion")?.val() || 0,
            ID_AREA: $("#Ddl_Area")?.val() || 0,
            ID_PROC: $("#Ddl_Proc_Ate").val(),
            ID_RLS_LS: $("#Ddl_Area_Seccion")?.val() || 0,
        });

        $.ajax({
            "type": "POST",
            "url": "Ate_Resultados_2.aspx/Busca_Ate_Por_Sec_Area",
            "data": strParam,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": function (response) {
                var json_receiver = response.d;
                if (json_receiver != "null") {
                    let Mx_Ate_Sec = json_receiver;
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
                            $("#Txt_NumAte").val($(ev.currentTarget).attr("value"));
                            let e = $.Event("keypress", { which: 13 });
                            $('#Txt_NumAte').trigger(e);
                        });
                        $("#Dtt_Ate").addClass("cell-border")
                    } else {

                        $("#Div_Dtt").empty();
                    }

                } else {
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


    //Declaración de Elem--------------------------------------------------------------------------
    let Txt_NumAte = new WEBFORM.class_Input("Txt_NumAte");

    let Txt_ResCod_Det = new WEBFORM.class_Input("Txt_ResCod_Det");
    let Txt_ResCod_Out = new WEBFORM.class_Input("Txt_ResCod_Out");
    Txt_ResCod_Det.readOnly = true;
    let Sel_Prev = new WEBFORM.class_Select("Sel_Prev");
    let Sel_Proc = new WEBFORM.class_Select("Sel_Proc");
    let Sel_Prog = new WEBFORM.class_Select("Sel_Prog");
    let Chk_Filther = new WEBFORM.class_Checkbox("Chk_Filther"); // este es uno de los constructores mas sacowea que he visto wn dios bendiga al que lo hizo
    let Btn_Audit = new WEBFORM.class_Button("Btn_Audit");
    let Btn_Validar = new WEBFORM.class_Button("Btn_Validar");
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
    let blurEventInProgress = false;
    //let resultadosCriticosMostrados = [];

    let criticosAltos = [];
    let criticosBajos = [];
    let criticosAltosSecciones = [];
    let criticosBajosSecciones = [];
    filaPruebasEdad = [];
    let fn_Make_Table = async () => {
        blurEventInProgress = true;
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
        Dtt_Exam.addTHead("Result. Hist.", "left");
        Dtt_Exam.addTHead("T", "left");

        let Cont_Loop = 1;
        let Cont_Int = 2;
        let Curr_Exa = "";
        let Bg_Arr = [];

        let text_BG = "";

        criticosAltos = [];
        criticosBajos = [];
        criticosAltosSecciones = [];
        criticosBajosSecciones = [];
        filaPruebasEdad = [];
        let _Z = 1050;
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
            text_BG = objData_Dtt[i].Rechazado ? "rechazado" : "";
            const estadoRecepcion = text_BG === "rechazado" ? text_BG : !objData_Dtt[i].Recepcionado ? "sin-recep" : !objData_Dtt[i].RecepcionadoSec ? "sin-recep-sec" : "";
            Bg_Arr = ["bg-white", "bg-white", text_BG, estadoRecepcion, text_BG, text_BG, text_BG, text_BG, text_BG, text_BG, text_BG];
            //Cont_Loop+=1;

            var index = i;
            const idExamenSeleccionado = parseInt($("#slct-examen-main").val());
            if (idExamenSeleccionado != 0 && objData_Dtt[i].Exam.ID_CF != idExamenSeleccionado) continue;


            Dtt_Exam.addRow(index, [

                objData_Dtt[index].TT.DESC_TD,
                (function () {
                    if (objData_Dtt[index].EE.value == 11 && objData_Dtt[index].EE.estado == "") {
                        objData_Dtt[index].EE.estado = "T";
                    }
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
                    const valueAsFloat = parseFloat(`${value}`.replaceAll(",", "."))
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
                        value = objData_Pac.EDAD.split(" ")[0]; //.match(/^[0-9]+(?=\saños)/gi)[0]
                        objData_Dtt[index].Res.value = value;
                        filaPruebasEdad.push(index)
                    }
                    if ((TOOL.fn_IsNumeric(objData_Dtt[index].Res.b1) == true) &&
                        (TOOL.fn_IsNumeric(objData_Dtt[index].Res.a1) == true) &&
                        (stat != "n") && (value != null) && (value != "") && (TOOL.fn_IsNumeric(`${value}`.replace(/\,/gi, ".")) == true)) {


                        objData_Dtt[index].Res.a1 = math.round(parseFloat(objData_Dtt[index].Res.a1), objData_Dtt[index].Res.pruDecimal);
                        objData_Dtt[index].Res.b1 = math.round(parseFloat(objData_Dtt[index].Res.b1), objData_Dtt[index].Res.pruDecimal);


                        if ((objData_Dtt[index].Res.b1 > parseFloat(value.toString().replace(/,/gi, "."))) || (objData_Dtt[index].Res.a1 < parseFloat(value.toString().replace(/,/gi, ".")))) {

                            //var lista_filtrada = lista_criticos.filter((critico) => critico.Res.ID_RES === objData_Dtt[index].Res.ID_RES)

                            //if (lista_filtrada.length == 0) {
                            //    lista_criticos.push(objData_Dtt[index]);
                            //    fill_modal_criticos();
                            //}

                            xParam += ` class="input_error"`;

                        }
                        else if ((TOOL.fn_IsNumeric(value.toString().replace(/,/gi, ".")) == false) &&
                            (objData_Dtt[index].TT.ID_TD != 1)) {
                            xParam += ` class="input_error"`;
                        }
                    } else if ((objData_Dtt[index].ValorCritico) || (parseFloat(value) <= parseFloat(objData_Dtt[index].Res.b2) && (objData_Dtt[index].Res.b2 != 0) && (objData_Dtt[index].Res.a1 != null) && (objData_Dtt[index].Res.b1 != null))) {

                        xParam += ` class="input_error"`;

                    }
                    if ((Stat_Valid == 6) || (Stat_Valid == 14) || (objData_Dtt[index].TT.ID_TD == 4)) {
                        xParam += ` readonly`;
                    }
                    //problema
                    if ((value == null || value == "") && objData_Dtt[index].Res.pruCero == true) {
                        value = "";     //PONE VALOR 0 AUTOMÁTICO le quite el 0 estaba  
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
                    // console.log("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@")
                    //if (parseFloat(value) >= parseFloat(objData_Dtt[index].Res.a2) && (objData_Dtt[index].Res.arft NULL2 != 0) && (objData_Dtt[index].Res.a1 != null) && (objData_Dtt[index].Res.b1 != null)) {

                    //    criticosAltos.push(objData_Dtt[index].Res.ID_RES)


                    //    const setSeccionesAlto = new Set(criticosAltosSecciones);
                    //    setSeccionesAlto.add(objData_Dtt[index].Exam.ID_SECCION);
                    //    criticosAltosSecciones = Array.from(setSeccionesAlto);

                    //} else if (objData_Dtt[index].ValorCritico || (parseFloat(value) <= parseFloat(objData_Dtt[index].Res.b2) && (objData_Dtt[index].Res.b2 != 0) && (objData_Dtt[index].Res.a1 != null) && (objData_Dtt[index].Res.b1 != null))) {


                    //    criticosBajos.push(objData_Dtt[index].Res.ID_RES)
                    //    const setSeccionesBajo = new Set(criticosBajosSecciones);
                    //    setSeccionesBajo.add(objData_Dtt[index].Exam.ID_SECCION);
                    //    criticosBajosSecciones = Array.from(setSeccionesBajo);

                    //}

                    //console.group();
                    //console.log(value);
                    //console.log(objData_Dtt[index].Res.a2);
                    //console.log(objData_Dtt[index].Res.b2);
                    //console.groupEnd();
                    //console.log("@@@@@@@@@@@@@@@@@@@@@ CARGAR MDLS @@@@@@@@@@@@@@@@@@@@@");

                    if (objData_Dtt[index].Exam.ID_EXA) {

                    }
                    if (valueAsFloat >= parseFloat(objData_Dtt[index].Res.a2) && (objData_Dtt[index].Res.a2 != 0) && (objData_Dtt[index].Res.a1 != null) && (objData_Dtt[index].Res.b1 != null)) { // TODO: sacar el null??? es por el bug de irispc
                        //console.log("@@@@@@@@@@@@@@@@@@@@@ ALTO @@@@@@@@@@@@@@@@@@@@@");
                        //var obj_exam_asoc;
                        //if (objSel_Secc != null) {
                        //    obj_exam_asoc = objSel_Exam.find((item) => {
                        //        if (item.ID == objData_Dtt[index].Exam.ID_CF) {
                        //            return item
                        //        }
                        //    });
                        //}

                        let m_ID_RES = objData_Dtt[index].Res.ID_RES;
                        let m_Title = "Valor Crítico Alto";
                        let m_Text_Body = "Estimado usuario, se detecto un valor crítico alto: " +
                            //"<br>Examen: <b class='text-danger'>" + obj_exam_asoc?.DESC + "</b>" +
                            "<br> Descripción: <b class='text-danger'>" + objData_Dtt[index].Desc + " : " + value + "</b>";
                        modal_Crit(m_ID_RES, m_Title, _Z, m_Text_Body);
                        _Z -= 1;
                    } else if (valueAsFloat <= parseFloat(objData_Dtt[index].Res.b2) && (objData_Dtt[index].Res.b2 != 0) && (objData_Dtt[index].Res.a1 != null) && (objData_Dtt[index].Res.b1 != null)) { // TODO: sacar el null??? es por el bug de irispc
                        //console.log("@@@@@@@@@@@@@@@@@@@@@ BAJO @@@@@@@@@@@@@@@@@@@@@");
                        //var obj_exam_asoc;
                        //if (objSel_Secc != null) {
                        //    obj_exam_asoc = objSel_Exam.find((item) => {
                        //        if (item.ID == objData_Dtt[index].Exam.ID_CF) {
                        //            return item
                        //        }
                        //    });
                        //}
                        let m_ID_RES = objData_Dtt[index].Res.ID_RES;
                        let m_Title = "Valor Crítico Bajo";
                        let m_Text_Body = "Estimado usuario, se detecto un valor crítico bajo:" +
                            //"<br>Examen: <b class='text-danger'>" + obj_exam_asoc?.DESC + "</b>" +
                            "<br> Descripción: <b class='text-danger'>" + objData_Dtt[index].Desc + " : " + value + "</b>";
                        modal_Crit(m_ID_RES, m_Title, _Z, m_Text_Body);
                        _Z -= 1;
                    }


                    return `<input type="text" ${xParam} value="${value}" />`;
                }()),
                objData_Dtt[index].Unit,
                (function () {

                    let xVal = objData_Dtt[index].Stat;


                    if (xVal == null) {
                        xVal = "";
                    } else {
                        // Expresión regular para encontrar números (enteros o flotantes) en el texto
                        var regex = /[-+]?\b\d+(\.\d+)?\b/g;
                        var numerosEncontrados = xVal.match(regex);
                        var numerosParseados = [];

                        // Verificar si se encontraron números
                        if (numerosEncontrados !== null) {
                            // Si se encontraron números, asignar cadena vacía a xVal
                            xVal = "";
                        }
                    }

                    if ((xVal.toUpperCase().trim() == "N") || (xVal.toUpperCase() == "")) {//Se agrego trim por los espacios en blanco que traen algunos datos

                        return `<span class="td_stat">${xVal}</span>`;
                    }
                    else {

                        return `<span class="td_stat" style="color: #d30000;">${xVal}</span>`;
                    }
                }()),
                (function () {

                    // console.log("el if res rft", objData_Dtt[index].Res.rfT)
                    let value;
                    if (objData_Dtt[index].EE.value == 6 || objData_Dtt[index].EE.value == 14) {
                        value = objData_Dtt[index].Res.b1;
                    } else {
                        value = objData_Dtt[index].Res.b1;
                    }

                    let dec = objData_Dtt[index].Res.pruDecimal;

                    //if (value == null) {
                    //    return ".";
                    //}
                    //else if ((TOOL.fn_IsNumeric(value) == true) && (TOOL.fn_IsNumeric(dec) == true) && (objData_Dtt[index].Res.rfT == "" || objData_Dtt[index].Res.rfT == "NULL" || objData_Dtt[index].Res.rfT == null)) {
                    //    value = String(TOOL.fn_cutDecimals(value, dec));
                    //    return String(value).replace(/\./gi, ",");
                    //}
                    //else if ((objData_Dtt[index].Res.rfT != "" && objData_Dtt[index].Res.rfT != "NULL" && objData_Dtt[index].Res.rfT != null) && (objData_Dtt[index].EE.value != 6 && objData_Dtt[index].EE.value != 14)) {
                    //    return objData_Dtt[index].Res.rfT;
                    //}
                    //else {
                    //    return value;
                    //}
                    if ([null, undefined, "", "null", "NULL"].includes(objData_Dtt[index].Res.b1) && objData_Dtt[index].Res.rfT != null) {
                        ////console.log("Val Null");
                        ////console.groupEnd();
                        console.log("el if res rft", objData_Dtt[index].Res.rfT)
                        return objData_Dtt[index].Res.rfT;

                    }
                    else if ((TOOL.fn_IsNumeric(value) == true) && (TOOL.fn_IsNumeric(dec) == true) && (objData_Dtt[index].Res.rfT == "" || objData_Dtt[index].Res.rfT == "NULL" || objData_Dtt[index].Res.rfT == null)) {
                        value = String(TOOL.fn_cutDecimals(value, dec));
                        ////console.log("Val Numeric");
                        ////console.groupEnd();
                        return String(value).replace(/\./gi, ",");
                    }
                    else if ((objData_Dtt[index].Res.rfT != "" && objData_Dtt[index].Res.rfT != "NULL" && objData_Dtt[index].Res.rfT != null) && (objData_Dtt[index].EE.value != 6 && objData_Dtt[index].EE.value != 14)) {
                        ////console.log("Val Text");
                        ////console.groupEnd();
                        return objData_Dtt[index].Res.rfT;
                    }
                    else {

                        ////console.log("Val All");
                        ////console.groupEnd();
                        return value;
                    }

                }()),
                (function () {
                    //let value;

                    //if (objData_Dtt[index].EE.value == 6 || objData_Dtt[index].EE.value == 14) {
                    //    value = objData_Dtt[index].Res.a1;
                    //} else {
                    //    value = objData_Dtt[index].Res.a1;
                    //}

                    //let dec = objData_Dtt[index].Res.pruDecimal;

                    //if (value == null) {
                    //    return ".";
                    //}
                    //else if ((TOOL.fn_IsNumeric(value) == true) && (TOOL.fn_IsNumeric(dec) == true) && (objData_Dtt[index].Res.rfT == "" || objData_Dtt[index].Res.rfT == "NULL" || objData_Dtt[index].Res.rfT == null)) {
                    //    value = String(TOOL.fn_cutDecimals(value, dec));
                    //    return String(value).replace(/\./gi, ",");
                    //} else if ((objData_Dtt[index].Res.rfT != "" && objData_Dtt[index].Res.rfT != "NULL" && objData_Dtt[index].Res.rfT != null) && (objData_Dtt[index].EE.value != 6 && objData_Dtt[index].EE.value != 14)) {
                    //    return ".";
                    //}
                    //else {
                    //    return value;
                    //}

                    let value;

                    if (objData_Dtt[index].EE.value == 6 || objData_Dtt[index].EE.value == 14) {
                        value = objData_Dtt[index].Res.a1;
                    } else {
                        value = objData_Dtt[index].Res.a1;
                        ////console.log("ALTO: "+value);
                    }

                    let dec = objData_Dtt[index].Res.pruDecimal;

                    if (value == null) {
                        ////console.log("Val Null");
                        ////console.groupEnd();
                        return ".";
                    }
                    else if ((TOOL.fn_IsNumeric(value) == true) && (TOOL.fn_IsNumeric(dec) == true) && (objData_Dtt[index].Res.rfT == "" || objData_Dtt[index].Res.rfT == "NULL" || objData_Dtt[index].Res.rfT == null)) {
                        value = String(TOOL.fn_cutDecimals(value, dec));
                        return String(value).replace(/\./gi, ",");
                    } else if ((objData_Dtt[index].Res.rfT != "" && objData_Dtt[index].Res.rfT != "NULL" && objData_Dtt[index].Res.rfT != null) && (objData_Dtt[index].EE.value != 6 && objData_Dtt[index].EE.value != 14)) {
                        return ".";
                    }
                    else {
                        return value;
                    }
                }()),
                (function () {
                    const textAreaPrinter = (value) => `<textarea disabled class="form-control" rows="1" style="max-width:80%;background-color:#c0ffc0 ">${value}</textarea>`
                    if (objData_Dtt[i].ReHi != null && objData_Dtt[i].ReHi != "") {
                        return textAreaPrinter(objData_Dtt[i].ReHi); //`<span class="sp-hist v_green"">${objData_Dtt[i].ReHi}</span>`;
                    } else {
                        return "";
                    }
                }()),
                objData_Dtt[i].cDia
            ], null, Bg_Arr, [, , , , , , , , , "max-width:300px;",]);
        }
        Btn_Graph.setActive(false);
        Btn_Crit.setActive(false);
        Btn_Audit.setActive(false);
        Dtt_Exam.isClickeable = true;
        //Dtt_Exam.isDataTable = true;

        Dtt_Exam.updateTable("No se han encontrado exámenes.", 100);


        $("#Dtt_Exam input[type=text]").focusin((Me) => {
            $("#Dtt_Exam tbody tr").removeClass("tr_selected");
            $(Me.currentTarget).parents("tr").addClass("tr_selected");

        });
        $("#Dtt_Exam input[type=text]").on("keydown", event => {
            if (event.key === "Escape") {
                const currentTarget = document.activeElement;

                if (currentTarget instanceof HTMLInputElement) {
                    currentTarget.blur();
                }
            }
        });

        //$("#Dtt_Exam input[type=text]").blur(async (Me) => {
        //    blurEventInProgress = true;
        //    if ($(Me.currentTarget).attr("readonly") == null) {
        //        let xValue = $(Me.currentTarget).val();
        //        let xIndex = parseInt(Dtt_Exam.tr_value);

        //        if (TOOL.fn_IsNumeric(xValue.replace(/,/gi, ".")) == true) {
        //            xValue = TOOL.fn_cutDecimals(xValue.replace(/,/gi, "."), objData_Dtt[xIndex].Res.pruDecimal, true);
        //            xValue = parseFloat(xValue);
        //        }
        //        objData_Dtt[xIndex].Res.value = xValue;

        //        await fn_Write(Me)
        //        await fn_Calc()

        //        if (keyEnter == false) {
        //            let xItem = objData_Dtt[parseInt($(Me.currentTarget).parents("tr").attr("data-index"))];
        //            console.log('aca esta el xitem de objdata_dtt ', xItem)
        //            let strOut;
        //            if (xItem.Res.value == null && xItem.Res.pruCero == false) {
        //                strOut = "";
        //            }
        //            else if (xItem.Res.value == null && xItem.Res.pruCero == true) {
        //                strOut = "" + TOOL.fn_cutDecimals(0, xItem.Res.pruDecimal, false);
        //            }
        //            else {
        //                if (TOOL.fn_IsNumeric(xItem.Res.value) == true) {
        //                    strOut = "" + TOOL.fn_cutDecimals(xItem.Res.value, xItem.Res.pruDecimal, false);
        //                }
        //                else {
        //                    strOut = `${xItem.Res.value}`;
        //                }
        //                strOut = `${strOut}`.replace(/\./gi, ",");
        //            }
        //            $(Me.currentTarget).val(strOut);
        //        }
        //    }

        //    keyEnter = false;
        //    blurEventInProgress = false;
        //});
        $("#Dtt_Exam input[type=text]").blur(async (Me) => {
            blurEventInProgress = true;

            if ($(Me.currentTarget).attr("readonly") == null) {
                let xValue = $(Me.currentTarget).val();
                //let xIndex = parseInt(Dtt_Exam.tr_value);
                let xIndex = parseInt(Me.currentTarget.parentElement.parentElement.getAttribute("data-index"));

                // Verificar si objData_Dtt[xIndex] está definido
                if (objData_Dtt[xIndex]) {
                    if (TOOL.fn_IsNumeric(xValue.replace(/,/gi, ".")) == true) {
                        xValue = TOOL.fn_cutDecimals(xValue.replace(/,/gi, "."), objData_Dtt[xIndex].Res.pruDecimal, true);
                        xValue = parseFloat(xValue);
                    }
                    objData_Dtt[xIndex].Res.value = xValue;

                    await fn_Write(Me);
                    await fn_Calc();

                    if (keyEnter == false) {
                        let xItem = objData_Dtt[parseInt($(Me.currentTarget).parents("tr").attr("data-index"))];
                        console.log('aca esta el xitem de objdata_dtt ', xItem);

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
                            } else {
                                strOut = `${xItem.Res.value}`;
                            }
                            strOut = `${strOut}`.replace(/\./gi, ",");
                        }
                        $(Me.currentTarget).val(strOut);
                    }
                } else {
                    console.error("El índice " + xIndex + " no existe en objData_Dtt.");
                }
            }

            keyEnter = false;
            blurEventInProgress = false;
        });

        //$("#Dtt_Exam input[type=text]").focusout(async (Me) => {

        //    if ($(Me.currentTarget).attr("readonly") == null) {
        //        let xValue = $(Me.currentTarget).val();
        //        let xIndex = parseInt(Dtt_Exam.tr_value);

        //        if (TOOL.fn_IsNumeric(xValue.replace(/,/gi, ".")) == true) {
        //            xValue = TOOL.fn_cutDecimals(xValue.replace(/,/gi, "."), objData_Dtt[xIndex].Res.pruDecimal, true);
        //            xValue = parseFloat(xValue);
        //        }
        //        objData_Dtt[xIndex].Res.value = xValue;


        //        // Check for critical values
        //        const valueAsFloat = parseFloat(xValue);
        //        if (valueAsFloat >= parseFloat(objData_Dtt[xIndex].Res.a2) && (objData_Dtt[xIndex].Res.a2 != 0) && (objData_Dtt[xIndex].Res.a1 != null) && (objData_Dtt[xIndex].Res.b1 != null)) {
        //            let m_ID_RES = objData_Dtt[xIndex].Res.ID_RES;
        //            let m_Title = "Valor Crítico Alto";
        //            let m_Text_Body = "Estimado usuario, se detectó un valor crítico alto: " +
        //                "<br> Descripción: <b class='text-danger'>" + objData_Dtt[xIndex].Desc + " : " + xValue + "</b>";
        //            modal_Crit(m_ID_RES, m_Title, 1050, m_Text_Body);
        //        } else if (valueAsFloat <= parseFloat(objData_Dtt[xIndex].Res.b2) && (objData_Dtt[xIndex].Res.b2 != 0) && (objData_Dtt[xIndex].Res.a1 != null) && (objData_Dtt[xIndex].Res.b1 != null)) {
        //            let m_ID_RES = objData_Dtt[xIndex].Res.ID_RES;
        //            let m_Title = "Valor Crítico Bajo";
        //            let m_Text_Body = "Estimado usuario, se detectó un valor crítico bajo:" +
        //                "<br> Descripción: <b class='text-danger'>" + objData_Dtt[xIndex].Desc + " : " + xValue + "</b>";
        //            modal_Crit(m_ID_RES, m_Title, 1050, m_Text_Body);
        //        }
        //    }
        //});
        $("#Dtt_Exam input[type=text]").focusout(async (Me) => {
            if ($(Me.currentTarget).attr("readonly") == null) {
                let xValue = $(Me.currentTarget).val();
                //let xIndex = parseInt(Dtt_Exam.tr_value);
                let xIndex = parseInt(Me.currentTarget.parentElement.parentElement.getAttribute("data-index"));

                console.log("Me.currentTarget", Me.currentTarget)

                // Verificar si objData_Dtt[xIndex] está definido
                if (objData_Dtt[xIndex]) {
                    if (TOOL.fn_IsNumeric(xValue.replace(/,/gi, ".")) == true) {
                        xValue = TOOL.fn_cutDecimals(xValue.replace(/,/gi, "."), objData_Dtt[xIndex].Res.pruDecimal, true);
                        xValue = parseFloat(xValue);
                    }
                    objData_Dtt[xIndex].Res.value = xValue;

                    // Check for critical values
                    const valueAsFloat = parseFloat(xValue);
                    if (valueAsFloat >= parseFloat(objData_Dtt[xIndex].Res.a2) && (objData_Dtt[xIndex].Res.a2 != 0) && (objData_Dtt[xIndex].Res.a1 != null) && (objData_Dtt[xIndex].Res.b1 != null)) {
                        let m_ID_RES = objData_Dtt[xIndex].Res.ID_RES;
                        let m_Title = "Valor Crítico Alto";
                        let m_Text_Body = "Estimado usuario, se detectó un valor crítico alto: " +
                            "<br> Descripción: <b class='text-danger'>" + objData_Dtt[xIndex].Desc + " : " + xValue + "</b>";
                        modal_Crit(m_ID_RES, m_Title, 1050, m_Text_Body);
                    } else if (valueAsFloat <= parseFloat(objData_Dtt[xIndex].Res.b2) && (objData_Dtt[xIndex].Res.b2 != 0) && (objData_Dtt[xIndex].Res.a1 != null) && (objData_Dtt[xIndex].Res.b1 != null)) {
                        let m_ID_RES = objData_Dtt[xIndex].Res.ID_RES;
                        let m_Title = "Valor Crítico Bajo";
                        let m_Text_Body = "Estimado usuario, se detectó un valor crítico bajo:" +
                            "<br> Descripción: <b class='text-danger'>" + objData_Dtt[xIndex].Desc + " : " + xValue + "</b>";
                        modal_Crit(m_ID_RES, m_Title, 1050, m_Text_Body);
                    }
                } else {
                    console.error("El índice " + xIndex + " no existe en objData_Dtt.");
                }
            }
        });

        $("#Dtt_Exam input[type=text]").keypress(async (Me) => {
            //clearTimeout(fucusTimeout)
            if (Me.which == 13) {
                if ($(Me.currentTarget).attr("readonly") == null) {

                    let xValue = $(Me.currentTarget).val();
                    let xIndex = parseInt(Dtt_Exam.tr_value);
                    console.log('este es mi xIndex que tiene el tr_value del Dtt_exam', xIndex)
                    if (TOOL.fn_IsNumeric(xValue.replace(/,/gi, ".")) == true) {
                        xValue = TOOL.fn_cutDecimals(xValue.replace(/,/gi, "."), objData_Dtt[xIndex].Res.pruDecimal, true);
                        xValue = parseFloat(xValue);
                    }
                    objData_Dtt[xIndex].Res.value = xValue;

                    blurEventInProgress = false;
                    await fn_Write(Me);
                    await fn_Calc();
                    keyEnter = true;
                    $(Me.currentTarget).parents("tr").next().find("input[type=text]").focus();
                    blurEventInProgress = false;

                }
            }
        });

        $("#Dtt_Exam input[type=text]").keydown(async (Me) => {
            if (Me.which == 38) {
                $(Me.currentTarget).parents("tr").prev().find("input[type=text]").focus();
            }
            else if (Me.which == 40) {
                $(Me.currentTarget).parents("tr").next().find("input[type=text]").focus();
                //} else if (Me.which == 13) {  // Mostrar el modal al precionar enter
                //    if ($(Me.currentTarget).attr("readonly") == null) {
                //        let xValue = $(Me.currentTarget).val();
                //        let xIndex = parseInt(Dtt_Exam.tr_value);

                //        if (TOOL.fn_IsNumeric(xValue.replace(/,/gi, ".")) == true) {
                //            xValue = TOOL.fn_cutDecimals(xValue.replace(/,/gi, "."), objData_Dtt[xIndex].Res.pruDecimal, true);
                //            xValue = parseFloat(xValue);
                //        }
                //        objData_Dtt[xIndex].Res.value = xValue;

                //        // Check for critical values
                //        const valueAsFloat = parseFloat(xValue);
                //        if (valueAsFloat >= parseFloat(objData_Dtt[xIndex].Res.a2) && (objData_Dtt[xIndex].Res.a2 != 0) && (objData_Dtt[xIndex].Res.a1 != null) && (objData_Dtt[xIndex].Res.b1 != null)) {
                //            let m_ID_RES = objData_Dtt[xIndex].Res.ID_RES;
                //            let m_Title = "Valor Crítico Alto";
                //            let m_Text_Body = "Estimado usuario, se detectó un valor crítico alto: " +
                //                "<br> Descripción: <b class='text-danger'>" + objData_Dtt[xIndex].Desc + " : " + xValue + "</b>";
                //            modal_Crit(m_ID_RES, m_Title, 1050, m_Text_Body);
                //        } else if (valueAsFloat <= parseFloat(objData_Dtt[xIndex].Res.b2) && (objData_Dtt[xIndex].Res.b2 != 0) && (objData_Dtt[xIndex].Res.a1 != null) && (objData_Dtt[xIndex].Res.b1 != null)) {
                //            let m_ID_RES = objData_Dtt[xIndex].Res.ID_RES;
                //            let m_Title = "Valor Crítico Bajo";
                //            let m_Text_Body = "Estimado usuario, se detectó un valor crítico bajo:" +
                //                "<br> Descripción: <b class='text-danger'>" + objData_Dtt[xIndex].Desc + " : " + xValue + "</b>";
                //            modal_Crit(m_ID_RES, m_Title, 1050, m_Text_Body);
                //        }

                //        blurEventInProgress = false;
                //        keyEnter = true;
                //        $(Me.currentTarget).parents("tr").next().find("input[type=text]").focus();
                //        blurEventInProgress = false;
                //    }
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
        $("#DataTables_Table_0").addClass("cell-border").colResizable();


        Hide_Modal();

        const atencionActual = noMostrarCritsDe?.[ID_ATE];
        if (!atencionActual) {
            noMostrarCritsDe[ID_ATE] = []
        }
        // un array con los ID_SECCION que contienen críticos
        const criticosSecciones = Array.from(new Set([...criticosBajosSecciones, ...criticosAltosSecciones]));

        for (let i = 0; i < criticosSecciones.length; i++) {

            const idSeccion = criticosSecciones[i];

            const resultadosDeSeccion = objData_Dtt
                .filter(item => item.Exam.ID_SECCION == idSeccion && [...criticosBajos, ...criticosAltos].includes(parseInt(item.Res.ID_RES)));

            // el denyButton es el para notificar se muestra solo si hay alguno validado
            const showDenyButton = resultadosDeSeccion.some(item => [6, 14].includes(item.EE.value));

            //un array con los ID_ATE_RES en la sección
            const idAteResEnSeccion = resultadosDeSeccion.map(item => item.Res.ID_RES);

            // hay resultados sin notificaciones
            const haySinNotificar = resultadosDeSeccion.some(item => !item.fueNotificado);

            // hay resultados que no se han mostrado en el popup
            const yaSeMostroTodo = idAteResEnSeccion.every(idAteResSec => noMostrarCritsDe?.[ID_ATE.toString()].includes(idAteResSec));

            noMostrarCritsDe[ID_ATE] = Array.from(new Set([...idAteResEnSeccion]));

            if (!haySinNotificar || yaSeMostroTodo) continue;
            const { isDenied } = await Swal.fire({
                icon: 'warning',
                title: 'Valor Crítico',
                html: `Se detectó uno o más resultados crítico en sección 
                       <br>
                       <span style="color:red;font-weight:bold;">
                           ${seccionesCargadas.find(item => item.ID_SECCION == idSeccion).SECC_DESC}:
                       </span>
                       <br/>
                       ${resultadosDeSeccion
                        .filter(item => !item.fueNotificado)
                        .map(analito => `• <b>${analito.Desc}: ${analito.Res.value} ${analito.Unit} </b> <br/>`).join(" ")}
                       `,
                showDenyButton,
                confirmButtonText: 'Ok',
                denyButtonText: 'Notificar',
            });
            if (isDenied) {
                const idAteResNotificables = resultadosDeSeccion.filter(item => [6, 14].includes(item.EE.value)).map(item => item.Res.ID_RES);
                Call_Data_Table_Detalle(idAteResNotificables);
            }
        }


        //await addCritsToObs(criticosAltos, criticosBajos);
        console.warn(updateEdad && filaPruebasEdad.length > 0 && foliosEdadLista.includes($("#Txt_NumAte").val()));

        if (updateEdad && filaPruebasEdad.length > 0 && !foliosEdadLista.includes($("#Txt_NumAte").val())) {

            filaPruebasEdad.forEach(fila => {

                const resultadosExaEdad = objData_Dtt.filter(item => item.Exam.ID_CF == objData_Dtt[fila].Exam.ID_CF);

                if (resultadosExaEdad.includes(item => [6, 14].includes(item.EE.value))) return;

                foliosEdadLista.push($("#Txt_NumAte").val());

                const data = JSON.stringify({
                    ID_RES: objData_Dtt[fila].Res.ID_RES,
                    RES: objData_Dtt[fila].Res.value,
                })
                $.ajax({
                    "type": "POST",
                    "url": "Ate_Resultados_2.aspx/IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_TEXTO",
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

        blurEventInProgress = false;
    };

    //FUNCION MODAL CRITICO
    function modal_Crit(ID_RES, TITLE, Z, TEXT) {

        $("#mdl" + ID_RES).remove();

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


        $("#mdl_title" + ID_RES).text(TITLE);
        $("#mdl_text" + ID_RES).html(TEXT);
        Hide_Modal();

        $("#mdl" + ID_RES).modal({ backdrop: false }).one();


        //$("#mdl"+ID_RES).modal({backdrop: false});
    }








    const addCritsToObs = async (altos, bajos) => {
        const altosMap = altos.map(idAteRes => objData_Dtt.find(item => item.Res.ID_RES == idAteRes));
        const bajosMap = bajos.map(idAteRes => objData_Dtt.find(item => item.Res.ID_RES == idAteRes));

        const criticos = [...bajosMap, ...altosMap];

        criticos.forEach(item => {
            const rangoCriticoAlto = parseFloat(item.Res.a2);
            const rangoCriticoBajo = parseFloat(item.Res.b2);

            const res = parseFloat(item.Res.value);
            console.log('este es mi resultado desde criticos', res)
            item.Res.esCritico = rangoCriticoAlto < res || res < rangoCriticoBajo;
        })

        const groupByIdCf = criticos.reduce((result, item) => {
            const examId = item.Exam.ID_CF;
            if (!result[examId]) {
                result[examId] = [];
            }
            result[examId].push(item);
            return result;
        }, {});

        const listaExamenesYObservacion = []

        for (const idCf in groupByIdCf) {

            const group = groupByIdCf[idCf];

            const observacion = {
                idAtencion: ID_ATE,
                idCf,
                idPer: group[0].Exam.ID_PER,
                texto: "",
                idAteResList: [],
            }

            for (const obj of group) {
                if (obj.Res.esCritico) {
                    if (observacion.texto == "") {
                        observacion.texto += "Valor Crítico:";
                    }
                    observacion.texto += ` -> ${obj.Desc}: ${obj.Res.value} ${obj.Unit}`;
                }

                if ((!obj.critAddedToObs || obj.critAddedToObsValue != obj.Res.value)) {
                    observacion.idAteResList.push(obj.Res.ID_RES);
                }
            }
            if (observacion.idAteResList.length > 0) {
                listaExamenesYObservacion.push(observacion);
            }
            if (observacion.idAteResList.length == 0) {
                observacion.texto = "";
            }
        }

        if (listaExamenesYObservacion.length == 0) {
            return
        }
        const body = { listaExamenesYObservacion };
        const respuesta = new IrisResponse(await fetcher('Ate_Resultados_2.aspx/Guarda_Observacion_Criticos', { body }));
        if (respuesta.data !== null) {
            if (respuesta.data.length > 0) {
                await cargarTablaNewParams();
                document.getElementById("Txt_NumAte").dispatchEvent(new KeyboardEvent('keyup', { key: 'Enter' }));
            }
        }

    }


    let fn_Write = async (Me) => {
        blurEventInProgress = true;
        let xValue = $(Me.currentTarget).val();
        //let xIndex = parseInt(Dtt_Exam.tr_value);
        let xIndex = parseInt(Me.currentTarget.parentElement.parentElement.getAttribute("data-index"));
        let xStat;
        let xParam;
        //Evaluar Valor

        xValue = String(xValue).trim();

        if (TOOL.fn_IsNumeric(xValue.replace(/,/gi, ".")) == true) {
            xValue = TOOL.fn_cutDecimals(xValue.replace(/,/gi, "."), objData_Dtt[xIndex].Res.pruDecimal, true);
            xValue = parseFloat(xValue);
        }
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


                    //xValue = parseFloat(xValue);

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
        }
        else {
            $(Me.currentTarget).parents("tr").find(".td_stat").css({
                color: "#212529"
            });
        }
        if (objData_Dtt[xIndex].TT.ID_TD != 1) {
            objWrite.URL = `Ate_Resultados_2.aspx/IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_NUMERICO`;
            objWrite.Param = {
                ID_RES: objData_Dtt[xIndex].Res.ID_RES,
                RES: xValue,
                EVAL: xValue
            };
        }
        else {
            objWrite.URL = `Ate_Resultados_2.aspx/IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_TEXTO`;
            objWrite.Param = {
                ID_RES: objData_Dtt[xIndex].Res.ID_RES,
                RES: xValue
            };
        }

        objAJAX_Write.URL = objWrite.URL;
        await objAJAX_Write.requestNow(objWrite.Param);

        const rangoCriticoAlto = objData_Dtt[xIndex].Res.a2;
        const rangoCriticoBajo = objData_Dtt[xIndex].Res.b2;

        const res = objData_Dtt[xIndex].Res.value;

        const esCritAlto = rangoCriticoAlto < res;
        const esCritBajo = res < rangoCriticoBajo;

        const esCritico = esCritAlto || esCritBajo;

        objData_Dtt[xIndex].Res.esCritico = esCritico;

        const critAltoSet = new Set(criticosAltos);
        const critBajoSet = new Set(criticosBajos);

        if (esCritAlto) {
            critAltoSet.add(parseInt(objData_Dtt[xIndex].Res.ID_RES));
        }

        if (esCritBajo) {
            critBajoSet.add(parseInt(objData_Dtt[xIndex].Res.ID_RES));
        }

        criticosAltos = Array.from(critAltoSet);
        criticosBajos = Array.from(critBajoSet);

        await addCritsToObs(criticosAltos, criticosBajos);



    };
    let fn_Write_2 = async (Me_Ind, Me_Val) => {
        blurEventInProgress = true;
        let xValue = Me_Val;
        let xIndex = Me_Ind;
        let xStat;
        let xParam;
        //Evaluar Valor
        xValue = String(xValue).trim();
        if (TOOL.fn_IsNumeric(xValue.replace(/,/gi, ".")) == true) {
            xValue = TOOL.fn_cutDecimals(xValue.replace(/,/gi, "."), objData_Dtt[xIndex].Res.pruDecimal, true);
            xValue = parseFloat(xValue);
        }

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
        }
        else {
            if ((objData_Dtt[xIndex].Stat == "") && (xStat == null)) {
            }
            else if (objData_Dtt[xIndex].Stat == "N") {
            }
            else {
            }
        }
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
            objWrite.URL = `Ate_Resultados_2.aspx/IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_NUMERICO`;
            objWrite.Param = {
                ID_RES: objData_Dtt[xIndex].Res.ID_RES,
                RES: xValue,
                EVAL: xValue
            };
        }
        else {
            objWrite.URL = `Ate_Resultados_2.aspx/IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_TEXTO`;
            objWrite.Param = {
                ID_RES: objData_Dtt[xIndex].Res.ID_RES,
                RES: xValue
            };
        }

        objAJAX_Write.URL = objWrite.URL;
        await objAJAX_Write.requestNow(objWrite.Param);
        blurEventInProgress = false;
    };

    let fn_Calc = async () => {
        blurEventInProgress = true;
        let fn_Proc = async (xItem, miii) => {
            //console.log('xItem: ', xItem)
            //console.log('miii: ', miii)

            let calc = xItem.vector;
            //console.log('calc: ', calc)

            let arrREE = [];
            let xInput = "";
            if (calc.match(/\[([a-z]|[a-z.]|[0-9]|-|_)+\]/gi) != null) {
                calc.match(/\[([a-z]|[a-z.]|[0-9]|-|_)+\]/gi).forEach((lol) => {
                    let _text = lol;
                    let _value = null;
                    // console.log('objeto de la data table', objData_Dtt)
                    objData_Dtt.forEach((kek, index) => {
                        if (_text == `[${kek.Res.PRU_COD}]`) {
                            _value = parseFloat(`${kek.Res.value}`.replace(/,/gi, "."));
                            if ([11100, 11244].includes(kek.Exam.ID_EXA) && _value > 400) {
                                _value = ""
                            }
                            if ((_value == "" || _value == null || isNaN(_value) == true) && kek.Res.pruCero == true) {
                                _value = parseFloat("0");
                                let reg = new RegExp(`\\[${kek.Res.PRU_COD}\\]`, `gi`);
                                calc = calc.replace(reg, `${_value}`);
                                calc = calc.replace(/,/gi, ".");
                            }
                            else if (TOOL.fn_IsNumeric(_value) == false && kek.Res.pruCero == false) {
                                _value = null;
                            }
                            else {
                                let reg = new RegExp(`\\[${kek.Res.PRU_COD}\\]`, `gi`);
                                calc = calc.replace(reg, `${_value}`);
                                calc = calc.replace(/,/gi, ".");
                            }
                            arrREE.push({
                                string: `${_text} -> ${kek.Exam.Descrp} - ${kek.Desc}`,
                                value: `${_value}`
                            });
                        }
                    });
                });
                xInput = $(`#Dtt_Exam table tbody tr[data-index="${miii}"] input`);
            }

            if (calc.match(/\[([a-z]|[a-z.]|[0-9]|-|_)+\]/gi) == null) {

                let result = `${math.evaluate(calc)}`;
                let res_raw = result;
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
                objWrite.URL = `Ate_Resultados_2.aspx/IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_NUMERICO`;
                objWrite.Param = {
                    ID_RES: objData_Dtt[miii].Res.ID_RES,
                    RES: result.replace(/\./gi, ","),
                    EVAL: result
                };
                objAJAX_Write.URL = objWrite.URL;
                await objAJAX_Write.requestNow(objWrite.Param);
            }
            else {
                xInput.val("");
                objData_Dtt[miii].Res.value = null;
            }
        };

        async function processItems(items) {
            for (let i = 0; i < items.length; i++) {
                const item = items[i];
                if (item.TT.ID_TD == 4) {
                    await (async () => {
                        await fn_Proc(item.Res, i);
                    })();
                }
            }
        }


        const contieneTriglicerido = objData_Dtt.some(item => [11100, 11244].includes(item.Exam.ID_EXA) && ![6, 14].includes(item.EE.value));
        const trigMayor400 = objData_Dtt.some(item => [11100, 11244].includes(item.Exam.ID_EXA) && parseFloat(item.Res.value) > 400);
        const mostrarAlertaTriglicerido = contieneTriglicerido && trigMayor400;
        if (mostrarAlertaTriglicerido) {
            const esPerfilBioquimico = objData_Dtt.some(item => item.Exam.ID_EXA == 465);
            const mensajeTriglicerido = `Resultado de triglicéridos mayor a 400 mg/dL. <br/> No se calcula LDL${esPerfilBioquimico ? " ni VLDL" : ""}.`
            flagMsgTrigliceridos || Swal.fire({ title: "Información", html: mensajeTriglicerido, icon: "warning" });
            flagMsgTrigliceridos = true;
        } else {
            flagMsgTrigliceridos = false;
        }

        //{
        //    LDL LIP: 464,
        //    VLDL LIP: 462,
        //    LDL BIO: 699
        //}
        //const itemsProcesar = objData_Dtt.filter(item => ![464, 462, 699].includes(item.Exam.ID_EXA) || !trigMayor400 || !contieneTriglicerido)

        await processItems(objData_Dtt);
        blurEventInProgress = false;
    };
    let fn_Activate_Validator = () => {
        if ($("#slct-examen-main").val() == 0) {
            //Btn_Validar.setActive(false);
            //Btn_Desvalidar.setActive(false);
            Btn_Graph.setActive(false);
            Btn_Crit.setActive(false);
            return;
        }
        Btn_Validar.setActive(true);
        Btn_Desvalidar.setActive(true);
    };

    function Check_Valida(Id_Ate, id_CF) {
        let ret;
        var strParam = JSON.stringify({
            "ID_ATE": Id_Ate,
            "ID_CF": id_CF
        });
        console.log('data enviada a check valida', strParam)
        $.ajax({
            "type": "POST",
            "url": "Ate_Resultados_2.aspx/Check_Valida",
            "data": strParam,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": data => {
                console.log('response de check valida', data)
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
        let v_Id_Cf = "";
        let v_Cons;

        const examenesConTuboRechazado = objData_Dtt.filter(item => item.Rechazado).map(item => item.Exam.ID_CF);
        const indicesRechazado = [];
        objData_Dtt.forEach((item, index) => examenesConTuboRechazado.includes(item.Exam.ID_CF) && indicesRechazado.push(index));
        //if (indicesRechazado.length > 0) {
        //    Swal.fire({
        //        icon: "info",
        //        title: `Se detectaron muestras rechazadas`,
        //        html: `Los siguientes exámenes tienen muestras que fueron rechazadas y no se validarán: <br/><br/>
        //               ${examenesConTuboRechazado.map(id_cf => "• " + objData_Dtt.find(item => item.Exam.ID_CF == id_cf).Desc + " <br/>").join(" ")} <br/>`
        //    });
        //}
        for (let i = 0; i < xTR.length; i++) {
            //if (indicesRechazado.includes(i)) continue;
            let xIndex = parseInt(xTR.eq(i).attr("data-index"));
            var xItem = objData_Dtt[xIndex];



            // BUSCA SI ESTA VALIDADO

            if (v_Id_Cf == "") {
                v_Id_Cf = xItem.Exam.ID_CF;
                v_Cons = Check_Valida(ID_ATE, v_Id_Cf);

            } else if (v_Id_Cf != xItem.Exam.ID_CF) {
                v_Id_Cf = xItem.Exam.ID_CF;
                v_Cons = Check_Valida(ID_ATE, v_Id_Cf);

            }

            if (v_Id_Cf == xItem.Exam.ID_CF && v_Cons == 0) {
                if (((xItem.Res.value == null) || (xItem.Res.value.toString().trim() == "")) && (xItem.Res.pruCero == true)) {
                    xItem.Res.value = TOOL.fn_cutDecimals(0, xItem.Res.pruDecimal, false);
                    let Me_Val = xTR[xIndex].children[4].children[0].value;
                    let Me_Ind = xIndex
                    await fn_Write_2(Me_Ind, Me_Val);
                }

                if ((xItem.EE.value != 6) && (xItem.EE.value != 14)) {
                    let bolHasValue = false;
                    if ((xItem.Res.value != null) && (xItem.Res.value.toString().trim() != "")) {
                        bolHasValue = true;
                    }
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
            }

        }
        if (arrErr.length > 0) {
            arrErr = arrErr.map(item => item.arrParam).flat();
            Hide_Modal();

            Swal.fire({
                icon: 'info',
                title: 'Resultados Obligatorios',
                html: `Se han encontrado parámetros obligatorios sin valor. <br>
                       Los siguientes Exámenes no pueden ser validados mientras tales parámetros no tengan valor asignado:<br><br>
                       ${arrErr.map(item => `<span style="text-align:left;">&#x2022; ${item.DESCR}</span> <br/>`).join('')}`
            });
            return;
        }
        let Obj_Valid = [];
        // se busca la prueba TOTAL en el examen hemograma y si es distinto de 100 no deja validar
        const hemograma = objData_Dtt.find(item => item.Exam.ID_EXA == 10107 && item.Exam.ID_CF == 1457);
        if (hemograma && hemograma.Exam.ID_EXA === 10107 && hemograma.Res.value != "100" && !hemograma.Rechazado) {
            Swal.fire({
                icon: "warning",
                title: "Advertencia Hemograma",
                text: "el TOTAL de un hemograma debe ser igual a 100",
            });

            Hide_Modal();
            return;
        }

        const faltaRecepcionSeccion = objData_Dtt.some(item => !item.RecepcionadoSec);
        const noFueRechazado = objData_Dtt.some(item => !item.Rechazado);

        if (faltaRecepcionSeccion && noFueRechazado) {
            Swal.fire({
                icon: "warning",
                title: "Advertencia Recepción",
                html: "Para validar un resultado, es necesario que haya sido recepcionado tanto en el Laboratorio como en la Sección correspondiente. <br/>¡Por favor, asegúrate de que ambos pasos se hayan completado antes de validar el resultado!"
            });

            Hide_Modal();
            return;
        }



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

                let Item_Valid;

                Item_Valid = {
                    ID_ATE_RES: objData_Dtt[i].Res.ID_RES,
                    DESDE: (function () {
                        let xVal = objData_Dtt[i].Res.b1;
                        if (TOOL.fn_IsNumeric(xVal) == true) {
                            let dec = objData_Dtt[i].Res.pruDecimal;
                            xVal = TOOL.fn_cutDecimals(xVal, dec, true);
                            xVal = `${xVal}`.replace(/\./gi, ",");
                            //console.log(objData_Dtt[i].Res.rfT)
                        }
                        if (objData_Dtt[i].Res.rfT != "" && objData_Dtt[i].Res.rfT != "NULL" && objData_Dtt[i].Res.rfT != null) {
                            xVal = objData_Dtt[i].Res.rfT;
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
                            xVal = ".";
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
                        let value = String(objData_Dtt[i].Res.value)?.replace(',', '.');
                        let output = 0;
                        let b2 = objData_Dtt[i].Res.b2;
                        let a2 = objData_Dtt[i].Res.a2;
                        if (TOOL.fn_IsNumeric(b2) == true) {
                            if (b2 > parseFloat(`${value}`) && (objData_Dtt[i].Res.b2 != 0)) {
                                output = 1;
                            }
                        }
                        if (TOOL.fn_IsNumeric(a2) == true) {
                            if (a2 < parseFloat(`${value}`) && (objData_Dtt[i].Res.a2 != 0)) {
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
        objAJAX_Validate.requestNow({ "Obj_Valid": Obj_Valid });
    };
    let fn_Unvalidate = () => {

        modal_show();

        let xTR = $("#Dtt_Exam tbody tr");
        let arrIndex_Success = [];
        let arrErr = [];
        for (let i = 0; i < xTR.length; i++) {
            let xIndex = parseInt(xTR.eq(i).attr("data-index"));
            var xItem = objData_Dtt[xIndex];

            if (((xItem.Res.value == null) || (xItem.Res.value.toString().trim() == "")) && (xItem.Res.pruCero == true)) {
                xItem.Res.value = TOOL.fn_cutDecimals(0, xItem.Res.pruDecimal, false);
            }

            if ((xItem.EE.value == 6) || (xItem.EE.value == 14)) {
                let bolHasValue = false;
                if ((xItem.Res.value != null) && (xItem.Res.value.toString().trim() != "")) {
                    bolHasValue = true;
                }

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
            $(`#mdlValidateError .modal-body ul`).empty();
            for (let riii of arrErr) {
                for (let reee of riii.arrParam) {
                    $(`#mdlValidateError .modal-body ul`).append($(`<li>`).text(reee.DESCR));
                }
            }
            $(`#mdlValidateError`).modal();
        }

        let Obj_Unvalid = [];

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


    };
    //Declaración AJAX-----------------------------------------------------------------------------
    objAJAX_Pac_Data = new TOOL.class_AJAX("Ate_Resultados_2.aspx/Page_Load", async (resp) => {
        objData_Pac = resp.d;
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
        //ID_ATE = `${objData_Pac.ID_ATENCION}`
        let r_FUR;

        if (objData_Pac.ATE_FUR != null && objData_Pac.ATE_FUR != "") {
            r_FUR = " | Fur: " + objData_Pac.ATE_FUR;
        } else {
            r_FUR = "";
        }

        Txt_NumAte.setValue(objData_Pac.ATE_NUM);
        //Txt_DateAte.setValue(moment(objData_Pac.ATE_FECHA).format("DD/MM/YYYY"));
        //$("#chk_Nombre label span").text(`${objData_Pac.PAC_NOMBRE} ${objData_Pac.PAC_APELLIDO}`);
        //Txt_Nombre.setValue(`${objData_Pac.PAC_RUT},  ${objData_Pac.EDAD},  ${objData_Pac.SEXO_DESC}${r_FUR}`);
        //Ajax_DataTable_Antiguos(objData_Pac.ID_PACIENTE);

        $("#txtNombrePaciente").val(objData_Pac.PAC_NOMBRE + " " + objData_Pac.PAC_APELLIDO);
        $("#txtRutDni").val(objData_Pac.PAC_RUT == "" ? objData_Pac?.PAC_RUT_VIH : objData_Pac.PAC_RUT);
        $("#txtFechaAtencion").val(moment(objData_Pac.ATE_FECHA).format("DD/MM/YYYY HH:mm:ss"));
        $("#txtEdad").val(objData_Pac.EDAD);
        $("#txtSexo").val(objData_Pac.SEXO_DESC);
        $("#txtFUR").val(r_FUR);
        $("#txtIngresadoPor").val(objData_Pac.USU_NIC);
        $("#txtOrdenDeAtención").val(objData_Pac.ORD_DESC);

        if (objData_Pac.ORD_DESC == "Urgencia") {
            $("#txtOrdenDeAtención").css({
                "border-color": "red",
                "border-width": "3px",
                "background-color": "#ffd6d6"
            });
        } else {
            $("#txtOrdenDeAtención").css({
                "border-color": "",
                "border-width": "",
                "background-color": ""
            });
        }
        $("#txtOrdenDeAtención").removeClass("bg-color-info-ate");
        if ($("#txtOrdenDeAtención").val() !== "Urgencia") {
            $("#txtOrdenDeAtención").addClass("bg-color-info-ate");
        }

        $("#txtObsAtencion").val(objData_Pac.ATE_OBS_FICHA);
        $("#txtObsTomaMuestra").val(objData_Pac.ATE_OBS_TM);
        $("#txtObsPermanente").val(objData_Pac.PAC_OBS_PERMA);
        $("#txtNumeroAvis").val(objData_Pac.ATE_AVIS);
        $("#txtAccuChekBasal").val(objData_Pac.ACCU_CHEK_BASAL);
        $("#txtAccuChek120").val(objData_Pac.ACCU_CHEK_120);
        $("#txtTalla").val(objData_Pac.TALLA);
        $("#txtHgt").val(objData_Pac.HGT);
        $("#txtPeso").val(objData_Pac.PESO);


        let v_Obs;

        v_Obs = objData_Pac.ATE_OBS_TM;

        if (v_Obs != "" && v_Obs != null) {
            v_Obs = " | Obs: " + objData_Pac.ATE_OBS_TM;

        } else {
            v_Obs = "";
        }



        $("#title_Det_Ate_2").html("<i class='fa fa-edit mr-2'></i> | Sector: " + objData_Pac.SECTOR_DESC.replace("<", "").replace(">", "") + " | Médico: " + objData_Pac.DOC_NOMBRE + " " + objData_Pac.DOC_APELLIDO);

        objAJAX_Pac_GenHist.queryString = strUrlQuery;
        await objAJAX_Pac_GenHist.requestNow();

        ID_ATE = objData_Pac.ID_ATENCION;

        //areasCargadas = await fillAreas({
        //    idSelect: "slct-area-main",
        //    placeholder: true,
        //    placeholderText: "Todas Áreas",
        //    idAtencion: ID_ATE || 0,

        //    defaultValue: idAreaClicExaPendiente,
        //});
        //seccionesCargadas = await fillSecciones($("#slct-area-main").val(),
        //    {
        //        idSelect: "slct-seccion-main",
        //        placeholderText: "Todas Secciones",
        //        idAtencion: ID_ATE || 0,
        //        defaultValue: idSeccionClicExaPendiente,
        //    });

        seccionesAreasCargadas = await fillSeccionesAreas({
            idSelect: "slct-rls-area-seccion-main",
            placeholderText: "Todas Áreas-Secciones",
            idAtencion: ID_ATE || 0,
            defaultValue: idRlsLsClicExaPendiente,

        });
        examenesCargados = await fillExamenesSeccionArea({
            idSelect: "slct-examen-main",
            idSeccion: $("#slct-seccion-main")?.val() || 0,
            idArea: $("#slct-area-main")?.val() || 0,
            idRlsLs: $("#slct-rls-area-seccion-main")?.val() || 0,
            placeholderText: "Todos Exámenes",
            idAtencion: ID_ATE || 0,
            defaultValue: idCodFonaClicExaPendiente,
        });
        await cargarTablaNewParams();


        if (objData_Pac.CANT_HIST > 1) {
            Btn_Hist.setActive(true);
        }
        else {
            Btn_Hist.setActive(false);
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
        }
    });
    let objAJAX_Pac_GenHist = new TOOL.class_AJAX("Ate_Resultados_2.aspx/Get_Hist_General_Info", (resp) => {
        objData_HistGen = resp.d;

        let _txt_Nom_His = "<i class='fa fa-user mr-2'></i>" + $("#title_Det_Ate").text();

        $("#txtCantidadAtenciones").val(objData_HistGen.CANT_ATE);
        $("#txtCantidadExamenes").val(objData_HistGen.CANT_EXA);

        $("#title_Det_Ate").html(_txt_Nom_His);
        //Txt_Nombre.setValue(_txt_Nom_His);

        //Txt_Hist.value = `Ate: ${objData_HistGen.CANT_ATE}; Exa: ${objData_HistGen.CANT_EXA}`;
        Mdl_Init_Load.endLoad()
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
        }
    });
    let objAJAX_Sel_Proc = new TOOL.class_AJAX("Ate_Resultados_2.aspx/Sel_Proc", (resp) => {
        let xData;
        xData = resp.d;
        Sel_Proc.cleanAll();
        Sel_Proc.insertElem("<< Todos >>", 0);
        $("#Ddl_Proc_Ate, #Ddl_Proc_Ate_pendiente").empty();
        $("<option>", { "value": 0 }).text("TODOS PROCEDENCIA").appendTo("#Ddl_Proc_Ate, #Ddl_Proc_Ate_pendiente");

        for (let i in xData) {
            Sel_Proc.insertElem(xData[i].DESC, xData[i].ID);
            $("<option>", { "value": xData[i].ID }).text(xData[i].DESC).appendTo("#Ddl_Proc_Ate, #Ddl_Proc_Ate_pendiente");
        }



        objAJAX_Sel_Prev.requestNow({
            ID_PROC: parseInt(`${Sel_Proc.getValue().value}`)
        })
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
        }
    });
    let objAJAX_Sel_Prev = new TOOL.class_AJAX("Ate_Resultados_2.aspx/Sel_Prev_Activo", (resp) => {
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
        console.log('este es el prev desde Sel_Prev_Activo:', Sel_Prev);
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
        }
    });
    let objAJAX_Sel_Prog = new TOOL.class_AJAX("Ate_Resultados_2.aspx/Sel_Prog", (resp) => {
        let xData;
        xData = resp.d;
        Sel_Prog.cleanAll();
        Sel_Prog.insertElem("<< Todos >>", 0);
        for (let i in xData) {
            Sel_Prog.insertElem(xData[i].DESC, xData[i].ID);
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
        }
    });


    //Lista para guardar los criticos
    let lista_criticos = [];
    //Desactivamos el boton de guardar cambios en modal de criticos
    $("#btn_guardar_crit").attr("disabled", true);
    // Tabla para valores criticos del modal
    var tabla_criticos = $("#datatable_criticos").DataTable({
        "retrieve": true,
        "iDisplayLength": 10,
        "bSort": false,
        "info": false,
        "bPaginate": true,
        "language": {
            "lengthMenu": "Mostrar: _MENU_",
            "zeroRecords": "No hay coincidencias",
            "info": "Mostrando Pagina _PAGE_ de _PAGES_",
            "infoEmpty": "No hay concidencias",
            "infoFiltered": "(Se busco en _MAX_ registros )",
            "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>",
            "paginate": {
                "previous": "Anterior",
                "next": "Siguiente"
            }
        }
    });


    let objAJAX_Fill_Table = new TOOL.class_AJAX("Ate_Resultados_2.aspx/Json_DataTable_Area", (resp) => {
        objData_Dtt = [];

        objData_Dtt = resp.d;



        //const vfg = objData_Dtt.find(item => [6173, 6189].includes(item.Exam.ID_EXA)); //CAMBIAR ID VFG
        //if (vfg) {
        //    vfg.Res.value = vfg.Res.value ? vfg.Res.value : objData_Pac.ATE_AÑO;
        //}

        //const ptgo = objData_Dtt.some(item => item.Exam.ID_CF === -1);
        //document.querySelectorAll(".accu-chek-input").forEach(item => {
        //    if (ptgo) {
        //        item.removeAttribute("hidden");
        //    } else {
        //        item.setAttribute("hidden", "");
        //    }
        //});
        //const vihChagas = objData_Dtt.find(item => [-1].includes(item.Exam.ID_EXA));
        //if (vihChagas) {
        //    const numericValue = parseFloat(vihChagas.Res.value?.replace(",", ".")) || -1;

        //    if (numericValue >= 0.9 && numericValue < 1) {
        //        Swal.fire({
        //            icon: "warning",
        //            title: `Alerta ${vihChagas.Exam.Descrp}`,
        //            text: "Índice de CUT-OFF limítrofe, Repetir."
        //        });
        //    }
        //}




        Mdl_Init_Load.endLoad();
        //objData_Dtt.forEach((li) => {
        //    if (li.ValorCritico === true) {
        //        lista_criticos.push(li)
        //    }
        //});




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
        }
    });

    function fill_modal_criticos() {
        console.log("function: ", lista_criticos)
        if (lista_criticos.length > 0) {
            tabla_criticos.clear().draw();

            lista_criticos.forEach((crit, index) => {
                var i = index + 1;
                var row = $("<tr>", {
                    "class": "manito",
                    "click": function () {

                    },

                });
                //Hacemos un filter para buscar la seccion asociada al critico
                const [{ ID_SECCION, RLS_LS_DESC }] = seccionesAreasCargadas.filter((item) => item.ID_SECCION === crit.Exam.ID_SECCION)

                row.append(
                    $("<td>").addClass("text-center align-middle font-weight-bold").text(i),
                    $("<td>").addClass("text-left align-middle h1").text(crit.Desc),
                    $("<td>").addClass("text-left align-middle font-weight-bold text-danger h1").text(crit.Res.value),
                    $("<td>").addClass("text-left align-middle font-weight-bold h5").text(crit.Exam.Descrp),
                    $("<td>").addClass("text-left align-middle h3").text(RLS_LS_DESC),
                    $("<td>").addClass("text-center align-middle").html("<input type='checkbox' style='pointer-events: none;' class='form-check-input mx-auto' id='chk_Notif" + i + "' value='" + crit.fueNotificado + "' />"),
                );

                tabla_criticos.row.add(row).draw();

                i += 1;
            });

            //Mostramos el modal
            $("#mdlCritico").modal('hide');
            $("#mdlCritico").modal('show');
        }
    }


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
        }
    });
    let objAJAX_Fill_Audit = new TOOL.class_AJAX("Ate_Resultados_2.aspx/Fill_Audit", (resp) => {
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

        $("#Dtt_Audit table tr td").css("text-wrap", "balance");
        $("#Dtt_Audit table tr td").css("white-space", "normal");

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
        }
    });

    let objAJAX_Validate = new TOOL.class_AJAX("Ate_Resultados_2.aspx/Set_Validate", (resp) => {
        console.log('Data sent in the AJAX request:', objAJAX_Validate.param);

        const idAteResValidadosArray = JSON.parse(objAJAX_Validate.param).Obj_Valid.map(item => item.ID_ATE_RES);
        noMostrarCritsDe[ID_ATE] = noMostrarCritsDe[ID_ATE].filter(res => !idAteResValidadosArray.includes(res))
        console.log('array resultados validados', idAteResValidadosArray.param)
        $("#slct-examen-main").trigger("change");
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
            console.log(fail);
        }
    });


    let objAJAX_Critico_Manual = new TOOL.class_AJAX("Ate_Resultados_2.aspx/Critico_Manual", (resp) => {
        $("#mdlCritManual").modal("hide");
    }, (fail) => { });

    let objAJAX_Unvalidate = new TOOL.class_AJAX("Ate_Resultados_2.aspx/Set_Unvalidate", (resp) => {
        $("#slct-examen-main").trigger("change");
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
        }
    });
    let objAJAX_Get_Res_Cod = new TOOL.class_AJAX("Ate_Resultados_2.aspx/Get_Result_Cod", (resp) => {
        objData_ResCod = resp.d;
        let objTable = $("<table>", {
            class: "w-100 table-striped"
        });
        objTable.append($("<thead>").append($("<tr>").append($("<th>").text("Descripción"), $("<th>").text(""))), $("<tbody>"));
        objData_ResCod.forEach(xItem => {
            objTable.find("tbody").append($("<tr>").append($("<td>").text(xItem.RES_COD_DESC.replace(/\./gi, "")), $("<td>").append($("<button>", {
                type: "button",
                class: "btn btn-primary btn-sm"
            }).append($("<i>", {
                class: "fa fa-arrow-right",
                "aria-hidden": true
            })))));
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
        $("#mdlResCodificados .dataTables_wrapper table th").css({
            "display": "none"
        });
        //Evento Click
        $("#mdlResCodificados .mini-table button").click((Me) => {
            Me.stopImmediatePropagation();
            let strSelVal = $(Me.currentTarget).parents("tr").children("td:nth-child(1)").text();
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
        }
    });
    let objAJAX_Get_Other_Ate = new TOOL.class_AJAX("Ate_Resultados_2.aspx/Change_Ate_L_or_R_Area", (resp) => {
        const ate_num_enviado = JSON.parse(objAJAX_Get_Other_Ate.param).ATE_NUM;

        if (ate_num_enviado == resp.d) {
            Swal.fire({ icon: "info", title: "Sin Resultados", text: "No hay coincidencias para la solicitud ingresada." });
            Hide_Modal();
            document.getElementById("Txt_NumAte").value = ate_num_enviado
            return;
        }
        objAJAX_Get_ID_ATE.requestNow({
            NUM_ATE: resp.d,
            USU_ID_PROC: Galletas.getGalleta("USU_ID_PROC")
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
        }
    });
    let objAJAX_Get_ID_ATE = new TOOL.class_AJAX("Ate_Resultados_2.aspx/Get_ID_ATE_by_NUM_ATE", (resp) => {

        let response = resp.d;

        console.log("RESPONSE: ", response)
        if (response == "0") {
            Hide_Modal();
            $(`#mdlLimit .modal-body > p`).hide();
            $(`#mdlLimit .modal-body > p[data-status=none]`).show();
            $(`#mdlLimit`).modal();
            $("#title_Det_Ate").text("Sin Resultados");
            $("#title_Det_Ate_2").text("Sin Resultados");
            $("#Dtt_Exam table tbody").empty();
            $("#Btn_Hist").attr("disabled", "disabled");
            $("#Btn_Print").attr("disabled", "disabled");
            $("#Btn_Validar").attr("disabled", "disabled");
            $("#Btn_Desvalidar").attr("disabled", "disabled");
            return;
        }
        $("#Btn_Hist").removeAttr("disabled");
        $("#Btn_Print").removeAttr("disabled");
        $("#Btn_Validar").removeAttr("disabled");
        $("#Btn_Desvalidar").removeAttr("disabled");
        modal_show();
        strUrlQuery = `ID=${resp.d}&AR=${idAreaClicExaPendiente || 0}&SC=${idSeccionClicExaPendiente || 0}&CF=${idCodFonaClicExaPendiente || 0}&RLS=${idRlsLsClicExaPendiente || 0}`;
        let strURL = `Ate_Resultados_2.aspx?${strUrlQuery}`;
        window.history.pushState({ path: strURL }, '', strURL);
        Mdl_Init_Load.count = 1;
        Mdl_Init_Load.loaded = false;
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
        }
    });
    let objAJAX_Get_Hist_Graph = new TOOL.class_AJAX("Ate_Resultados_2.aspx/Draw_Graph_Hist", (resp) => {
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
        }
    });
    let objAJAX_Get_Hist_Exam = new TOOL.class_AJAX("Ate_Resultados_2.aspx/Get_Table_Historico_Examenes", (resp) => {
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
        }
    });
    let objAJAX_Get_Hist_Pruebas = new TOOL.class_AJAX("Ate_Resultados_2.aspx/Get_Table_Historico_Pruebas_Por_Examen", (resp) => {
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
        if (Me.which == 13 || Me.keyCode == 13) {
            if ($("#Txt_NumAte").val() != "") {
                $("#Dtt_Exam table tbody").empty();
                $("#mError_AAH_Consulta").modal("hide");
                document.title = `CARGANDO`;
                num_title_loop = setInterval(fn_title_loop, 250);
                objAJAX_Get_ID_ATE.requestNow({
                    NUM_ATE: $(Me.currentTarget).val(),
                    USU_ID_PROC: Galletas.getGalleta("USU_ID_PROC")
                });
            } else {
                alert_ate_num();
            }

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
    Dtt_Exam.evclick_tr = (Me) => {
        $(Me.currentTarget).find("input").focus();
        Btn_Audit.setActive(true);
        Btn_Graph.setActive(true);
        Btn_Crit.setActive(true);
        let index = parseInt(`${Dtt_Exam.tr_value}`);
    };
    Btn_Validar.click(async (Me) => {
        if ($("#slct-rls-area-seccion-main").val() == 0 && $("#slct-examen-main").val() == 0) {
            $(`#mdlAlert .modal-header .modal-title`).text("Seleccione Examen o Sección");
            $(`#mdlAlert .modal-body`).empty();
            $(`#mdlAlert .modal-body`).append($(`<span>`).text("Estimado usuario, para poder validar un examen, deberá seleccionar un Examen o Sección"));
            $(`#mdlAlert`).modal();
        } else {
            modal_show();
            const waitForBlurCompletion = async () => {
                if (blurEventInProgress) {
                    setTimeout(waitForBlurCompletion, 1000);
                } else {
                    await fn_Validate();
                }
            };

            await waitForBlurCompletion();
        }
    });

    btn_consulta.click((Me) => {
        let e = $.Event("keypress", { which: 13 });
        $("#mError_AAH_Consulta").modal("hide");
        $('#Txt_NumAte').trigger(e);
    });

    Btn_Desvalidar.click((Me) => {
        if ($("#slct-examen-main").val() == 0 && $("#slct-rls-area-seccion-main").val() == 0) {
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

        if (xSelItem.EE.value == 6 || xSelItem.EE.value == 14) {
            fn_Modal_Crit(xSelItem.Res.ID_RES, xSelItem.Desc, xSelItem.Res.value);
        }
    });

    btn_Acept_CM.click((Me) => {

        let ID_ATE_RES_CRIT = $(Me.currentTarget).attr("data-id-res");


        objAJAX_Critico_Manual.requestNow({
            ID_ATE_RES: ID_ATE_RES_CRIT
        });



        //let ID_ATE_RES_CRIT = Me.currentTarget.attr("data-id-res");


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
            let body = {
                ATE_NUM: parseInt($("#Txt_NumAte").val()),
                DIRECTION: bol_direction,
                ID_PROC: 0,
                ID_PREV: 0,
                ID_PROG: 0,
                ID_AREA: 0,
                ID_SECC: 0,
                ID_EXAM: 0,
                ID_SECT: 0,
                ID_PACI: document.getElementById("cb-paciente").checked ? objData_Pac.ID_PACIENTE : 0,
                USU_ID_PROC: 0,
                ACTIVA_PENDIENTES: 0,
                ACTIVA_PENDIENTES_R: document.getElementById("cb-pendiente").checked ? 1 : 0
            };
            modal_show();

            const checkboxes = [
                { id: "cb-procedencia", bodyKey: "ID_PROC", selectId: "Sel_Proc" },
                { id: "cb-prevision", bodyKey: "ID_PREV", selectId: "Sel_Prev" },
                { id: "cb-programa", bodyKey: "ID_PROG", selectId: "Sel_Prog" },
                { id: "cb-area", bodyKey: "ID_AREA", selectId: "slct-area-main" },
                { id: "cb-seccion", bodyKey: "ID_SECC", selectId: "slct-seccion-main" },
                { id: "cb-examen", bodyKey: "ID_EXAM", selectId: "slct-examen-main" },
                { id: "cb-rls-area-seccion", bodyKey: "ID_RLS_LS", selectId: "slct-rls-area-seccion-main" },
            ];
            const procesaCheckbox = (checkbox) => {
                const isChecked = document.getElementById(checkbox.id)?.checked;
                const selectValue = isChecked ? parseInt($(`#${checkbox.selectId}`).val()) : 0;
                body[checkbox.bodyKey] = selectValue;
                $(`#${checkbox.selectId}`).val(isChecked ? selectValue : 0);
            }
            checkboxes.forEach(checkbox => procesaCheckbox(checkbox));

            $("#Txt_NumAte").val(parseInt($("#Txt_NumAte").val()) + (body.DIRECTION ? 1 : -1));

            let USU_ID_PROC = Galletas.getGalleta("USU_ID_PROC");
            body.USU_ID_PROC = USU_ID_PROC;

            idAreaClicExaPendiente = body.ID_AREA;
            idSeccionClicExaPendiente = body.ID_SECC;
            idRlsLsClicExaPendiente = body.ID_RLS_LS;
            idCodFonaClicExaPendiente = body.ID_EXAM;
            await objAJAX_Get_Other_Ate.requestNow(body);
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
        Mdl_Init_Load.count = 1;
        Mdl_Init_Load.loaded = false;
        Mdl_Init_Load.endLoad();
    });
    let idAreaClicExaPendiente = 0;
    let idSeccionClicExaPendiente = 0;
    let idRlsLsClicExaPendiente = 0;
    let idCodFonaClicExaPendiente = 0;
    async function Ajax_examen_Pendientes() {
        var strParam = JSON.stringify({
            DESDE: $("#txt-desde-pendiente").val(),
            HASTA: $("#txt-hasta-pendiente").val(),
            ID_AREA: 0, //$("#slct-area").val(),
            ID_SEC: 0, //$("#slct-seccion").val(),
            ID_PROC: $("#Ddl_Proc_Ate_pendiente").val(),
            ID_CODIGO_FONASA: $("#Ddl_Examen_Ate_pendiente").val(),
            ID_RLS_LS: $("#slct-rls-area-seccion").val(),
        });

        return await $.ajax({
            "type": "POST",
            "url": "Ate_Resultados_2.aspx/busca_examenes_pendientes_area_seccion",
            "data": strParam,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": res => {
                let Mx_Ate_Sec = res.d;

                $("#Div_Dtt_pendiente").empty().append($("<table>", { id: "Dtt_Ate_pendiente", cellspacing: "0", class: "table table-hover table-striped table-iris" }).css({ "width": "100%", "border-collapse": "collapse", "font-size": "1px" }));
                $("#Dtt_Ate_pendiente").append($("<thead>"), $("<tbody>"));
                $("#Dtt_Ate_pendiente thead").append($("<tr>").append(
                    $("<th>").text("Folio"),
                    $("<th>").text("Fecha"),
                    $("<th>").text("Sección"),
                    $("<th>").text("TdeM"),
                    $("<th>").text("Examen"),
                ));
                const style = "cursor:pointer; text-align:left;-align:left;";
                Mx_Ate_Sec.forEach(aah => {
                    $("<tr>").css("cursor", "pointer")
                        .attr("value", aah.ATE_NUM)
                        .attr("data-id-seccion", aah.ID_SECCION)
                        .attr("data-id-area", aah.ID_AREA)
                        .attr("data-id-area-seccion", aah.ID_RLS_LS)
                        .attr("data-id-codigo-fonasa", aah.ID_CODIGO_FONASA).append(
                            $("<td>", { style }).text(aah.ATE_NUM),
                            $("<td>", { style }).text(aah.ATE_FECHA),
                            $("<td>", { style }).text(aah.SECC_COD),
                            $("<td>", { style }).text(aah.PROC_DESC),
                            $("<td>", { style }).text(aah.CF_DESC),
                        ).appendTo("#Dtt_Ate_pendiente tbody");
                });

                $("#Dtt_Ate_pendiente tbody tr").click(e => {
                    $('#modal-pendientes').modal('hide');
                    const checkPendientes = document.getElementById("cb-pendiente");
                    if (!checkPendientes.checked) {
                        checkPendientes.dispatchEvent(new Event("click"));
                    }

                    //idAreaClicExaPendiente = $(e.currentTarget).attr("data-id-area");
                    idRlsLsClicExaPendiente = $(e.currentTarget).attr("data-id-area-seccion");

                    $("#Txt_NumAte").val($(e.currentTarget).attr("value"));
                    let evento = $.Event("keypress", { which: 13 });
                    $('#Txt_NumAte').trigger(evento);
                });
            }
        });
    }


    modal_show();
    await fillTiposCritico({
        idSelect: "Ddl_Stat_aviso2",
        placeholder: false,
    });
    //await fillAreas({
    //    idSelect: ["slct-area", "Ddl_Area", "slct-area-main"],
    //    placeholder: true,
    //    placeholderText: "Todas Áreas",
    //});
    //await fillSecciones($("#slct-area").val(), {
    //    idSelect: ["slct-seccion", "Ddl_Seccion", "slct-seccion-main"],
    //    placeholderText: "Todas Secciones",
    //});
    await fillSeccionesAreas({
        idSelect: ["slct-rls-area-seccion", "Ddl_Area_Seccion", "slct-rls-area-seccion-main"],
        placeholderText: "Todas Áreas-Secciones",
    });
    await fillExamenesSeccionArea({
        idSelect: "Ddl_Examen_Ate_pendiente",
        idRlsLs: $("#slct-rls-area-seccion-main").val(),
        placeholderText: "Todos Exámenes",
    });

    //si trae id de atención la url se cargan area y seccion de nuevo porque ya se llenan arriba
    const paramIdAte = getParameterByNameMaster("ID");
    console.log("QUE TRAE EL PARAM ID ATE", paramIdAte)


    let areasCargadas = [];
    let seccionesCargadas = [];
    let seccionesAreasCargadas = [];
    if (paramIdAte == '') {
        //areasCargadas = await fillAreas({
        //    idSelect: "slct-area-main",
        //    placeholder: true,
        //    placeholderText: "Todas Áreas",
        //    idAtencion: ID_ATE || 0,
        //});
        //seccionesCargadas = await fillSecciones($("#slct-area-main").val(),
        //    {
        //        idSelect: "slct-seccion-main",
        //        placeholderText: "Todas Secciones",
        //        idAtencion: ID_ATE || 0,
        //    });
        seccionesAreasCargadas = await fillSeccionesAreas({
            idSelect: "slct-rls-area-seccion-main",
            placeholderText: "Todas Áreas-Secciones",
            idAtencion: ID_ATE || 0,
        });
    }
    idCodFonaClicExaPendiente = parseInt(getParameterByNameMaster("CF")) || 0;
    if (idCodFonaClicExaPendiente > 0 && !document.getElementById("cb-examen").checked) {
        idCodFonaClicExaPendiente = 0
    }

    let examenesCargados = await fillExamenesSeccionArea({
        idSelect: "slct-examen-main",
        idRlsLs: parseInt($("#slct-rls-area-seccion-main").val()),
        placeholderText: "Todos Exámenes",
        idAtencion: ID_ATE || 0,
        defaultValue: idCodFonaClicExaPendiente,
    });


    ////eventos selects del modal de exámenes pendientes
    //$("#slct-area").on("change", async () => {
    //    modal_show();
    //    await fillSecciones($("#slct-area").val(),
    //        {
    //            idSelect: "slct-seccion",
    //            placeholderText: "Todas Secciones",

    //        });
    //    await fillExamenesSeccionArea({
    //        idSelect: "Ddl_Examen_Ate_pendiente",
    //        idSeccion: $("#slct-seccion").val(),
    //        idArea: $("#slct-area").val(),
    //        placeholderText: "Todos Exámenes",
    //    });
    //    await Ajax_examen_Pendientes();
    //    Hide_Modal();
    //});
    //$("#slct-seccion").on("change", async () => {
    //    modal_show();
    //    await fillExamenesSeccionArea({
    //        idSelect: "Ddl_Examen_Ate_pendiente",
    //        idSeccion: $("#slct-seccion").val(),
    //        idArea: $("#slct-area").val(),
    //        placeholderText: "Todos Exámenes",
    //    });
    //    await Ajax_examen_Pendientes();
    //    Hide_Modal();
    //});
    $("#slct-rls-area-seccion").on("change", async () => {
        modal_show();
        await fillExamenesSeccionArea({
            idSelect: "Ddl_Examen_Ate_pendiente",
            idRlsLs: $("#slct-rls-area-seccion").val(),
            placeholderText: "Todos Exámenes",
        });
        await Ajax_examen_Pendientes();
        Hide_Modal();
    });

    //eventos selects del modal de buscar atenciones
    $("#Ddl_Area").on("change", async () => {
        modal_show();
        await fillSecciones($("#Ddl_Area").val(), { idSelect: "Ddl_Seccion", placeholderText: "Todas Secciones" });
        Hide_Modal();
    });
    const cargarTablaNewParams = async () => {
        modal_show();
        objData_Dtt = [];
        Dtt_Exam.cleanTable();

        objAJAX_Fill_Table.queryString = strUrlQuery;

        ACTIVA_PENDIENTES_R = Chk_Filther.getValues().indexOf(8) != -1 ? 1 : 0;

        await objAJAX_Fill_Table.requestNow({
            R_ID_AREA: parseInt($("#slct-area-main")?.val()) || 0,
            R_ID_SECC: parseInt($("#slct-seccion-main")?.val()) || 0,
            R_ID_RLS_LS: parseInt($("#slct-rls-area-seccion-main").val()),
            R_ID_EXAM: parseInt($("#slct-examen-main").val()),
            R_ID_PAC: objData_Pac.ID_PACIENTE,
            R_FNAC: moment(objData_Pac.PAC_FNAC).toDate(),
            R_SEXO: objData_Pac.SEXO_DESC,
            R_DIA: objData_Pac.ATE_DIA,
            R_MES: objData_Pac.ATE_MES,
            R_AÑO: objData_Pac.ATE_AÑO,
            ACTIVA_PENDIENTES,
            ACTIVA_PENDIENTES_R
        }, async () => {
            fn_Activate_Validator();
            //flagMsgTrigliceridos = true;
            await fn_Make_Table();
            await fn_Calc();
            Hide_Modal();
        });
    }

    const updateUrlParams = () => {
        let currentURL = window.location.href;
        let url = new URL(currentURL);


        //const arChecked = document.getElementById("cb-area").checked;
        //idAreaClicExaPendiente = arChecked ? $("#slct-area-main").val() : 0;
        //url.searchParams.set("AR", idAreaClicExaPendiente);

        //const scChecked = document.getElementById("cb-seccion").checked;
        //idSeccionClicExaPendiente = scChecked ? $("#slct-seccion-main").val() : 0;
        //url.searchParams.set("SC", idSeccionClicExaPendiente);

        const rlsChecked = document.getElementById("cb-rls-area-seccion").checked;
        idRlsLsClicExaPendiente = rlsChecked ? $("#slct-rls-area-seccion-main").val() : 0;
        url.searchParams.set("RLS", idRlsLsClicExaPendiente);

        const cfChecked = document.getElementById("cb-examen").checked;
        idCodFonaClicExaPendiente = cfChecked ? $("#slct-examen-main").val() : 0;
        url.searchParams.set("CF", idCodFonaClicExaPendiente);
        history.replaceState(null, null, url);
    }

    ////eventos selects de la ventana principal
    //$("#cb-area").on("click", e => {
    //    const areaChecked = e.currentTarget.checked;
    //    document.getElementById("slct-area-main").disabled = areaChecked;
    //    updateUrlParams();
    //});
    //$("#slct-area-main").on("change", async () => {
    //    modal_show();
    //    seccionesCargadas = await fillSecciones($("#slct-area-main").val(), { idSelect: "slct-seccion-main", placeholderText: "Todas Secciones", idAtencion: ID_ATE || 0, });

    //    idCodFonaClicExaPendiente = parseInt(getParameterByNameMaster("CF")) || 0;
    //    if (idCodFonaClicExaPendiente > 0 && !document.getElementById("cb-examen").checked) {
    //        idCodFonaClicExaPendiente = 0
    //    }
    //    examenesCargados = await fillExamenesSeccionArea({
    //        idSelect: "slct-examen-main",
    //        idSeccion: $("#slct-seccion-main").val(),
    //        idArea: $("#slct-area-main").val(),
    //        placeholderText: "Todos Exámenes",
    //        idAtencion: ID_ATE || 0,
    //        defaultValue: idCodFonaClicExaPendiente,
    //    });
    //    Hide_Modal();
    //    if ($("#Txt_NumAte").val() == "" || isNaN($("#Txt_NumAte").val())) {
    //        return;
    //    }
    //    cargarTablaNewParams();
    //});

    //$("#cb-seccion").on("click", e => {
    //    const seccionChecked = e.currentTarget.checked;
    //    document.getElementById("slct-seccion-main").disabled = seccionChecked;
    //    updateUrlParams();
    //})
    //$("#slct-seccion-main").on("change", async () => {
    //    modal_show();

    //    idCodFonaClicExaPendiente = parseInt(getParameterByNameMaster("CF")) || 0;
    //    if (idCodFonaClicExaPendiente > 0 && !document.getElementById("cb-examen").checked) {
    //        idCodFonaClicExaPendiente = 0
    //    }
    //    examenesCargados = await fillExamenesSeccionArea({
    //        idSelect: "slct-examen-main",
    //        idSeccion: $("#slct-seccion-main").val(),
    //        idArea: $("#slct-area-main").val(),
    //        placeholderText: "Todos Exámenes",
    //        idAtencion: ID_ATE || 0,
    //        defaultValue: idCodFonaClicExaPendiente,
    //    });

    //    Hide_Modal();
    //    if ($("#Txt_NumAte").val() == "" || isNaN($("#Txt_NumAte").val())) {
    //        return;
    //    }
    //    cargarTablaNewParams();
    //});
    $("#cb-rls-area-seccion").on("click", e => {
        const rlsChecked = e.currentTarget.checked;
        document.getElementById("slct-rls-area-seccion-main").disabled = rlsChecked;
        updateUrlParams();
    })
    $("#slct-rls-area-seccion-main").on("change", async () => {
        modal_show();

        idCodFonaClicExaPendiente = parseInt(getParameterByNameMaster("CF")) || 0;
        if (idCodFonaClicExaPendiente > 0 && !document.getElementById("cb-examen").checked) {
            idCodFonaClicExaPendiente = 0
        }
        examenesCargados = await fillExamenesSeccionArea({
            idSelect: "slct-examen-main",
            idRlsLs: parseInt($("#slct-rls-area-seccion-main").val()),
            placeholderText: "Todos Exámenes",
            idAtencion: ID_ATE || 0,
            defaultValue: idCodFonaClicExaPendiente,
        });

        Hide_Modal();
        if ($("#Txt_NumAte").val() == "" || isNaN($("#Txt_NumAte").val())) {
            return;
        }
        cargarTablaNewParams();
    });
    $("#cb-examen").on("click", e => {
        document.getElementById("slct-examen-main").disabled = e.currentTarget.checked;
        updateUrlParams();
    });
    $("#slct-examen-main").on("change", async () => {
        if ($("#Txt_NumAte").val() == "" || isNaN($("#Txt_NumAte").val())) {
            return;
        }
        cargarTablaNewParams();
    });


    $("#Ddl_Proc_Ate_pendiente").on("change", async () => {
        modal_show();
        await Ajax_examen_Pendientes();
        Hide_Modal();
    });

    $(document).ready(async () => {
        const checkPendiente = document.getElementById("objChk_Filther_0");
        checkPendiente.id = "cb-pendiente";
        checkPendiente.nextElementSibling.setAttribute('for', 'cb-pendiente');
        const checkPaciente = document.getElementById("objChk_Filther_1");
        checkPaciente.id = "cb-paciente";
        checkPaciente.nextElementSibling.setAttribute('for', 'cb-paciente');
        const checkProcedencia = document.getElementById("objChk_Filther_2");
        checkProcedencia.id = "cb-procedencia";
        checkProcedencia.nextElementSibling.setAttribute('for', 'cb-procedencia');
        const checkPrevision = document.getElementById("objChk_Filther_3");
        checkPrevision.id = "cb-prevision";
        checkPrevision.nextElementSibling.setAttribute('for', 'cb-prevision');
        const checkPrograma = document.getElementById("objChk_Filther_4");
        checkPrograma.id = "cb-programa";
        checkPrograma.nextElementSibling.setAttribute('for', 'cb-programa');
        let ID_USU_ADMIN = parseInt(Galletas.getGalleta("P_ADMIN"));

        if (!perfilesValidadores.includes(ID_USU_ADMIN)) {
            $("#Btn_Validar").parent().attr("hidden", "hidden");
            $("#Btn_Desvalidar").parent().attr("hidden", "hidden");
        }

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
            } else {
                alert_ate_num();
            }
        });

        $("#btnAgregaDeter").click(() => {
            if (ID_ATENCHION == 0 || ID_PERRRRRRCH == 0) {
            } else {
                $("#Div_Exam_Agrega2").empty();
                fn_Busca_Deter_soli_o_no_soli();

            }
        });
        //AJAX GUARDAR EN EL MODAL MARCAR
        $("#btnGuardaObsExam2").click(function () {
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

        $("#Btn_PDF").click(() => {

            if ($("#slct-examen-main").val() != 0 && $("#Txt_NumAte").val() != "") {
                const contieneValidado = objData_Dtt.some(exa => [6, 14].includes(exa.EE.value));
                if (!contieneValidado) {
                    Swal.fire("Información", "Debe seleccionar un exámen que esté validado", "info");
                    return
                }

                let BID = btoa(objData_Pac.ID_ATENCION);
                let BPE = btoa(objData_Dtt[0].Exam.ID_PER);


                window.open(`http://186.67.178.5:10103/Pacientes/iris_gen_pdf_solo.aspx?id_cliente=${BID}&ID_PERFIL_NUEVO=${BPE}`, "_blank");


                return
            }
            $("#mError_AAH h4").text("Seleccione Examen");
            $("#mError_AAH button").attr("class", "btn btn-danger");
            $("#mError_AAH p").text("Estimado usuario, debe seleccionar un examen para generar una vista previa.");
            $("#mError_AAH").modal();
            $("#Id_Conte").hide();

        });

        $("#btn-pendientes").click(() => {
            $("#btn_Busca_Ate_Sec_pendiente").trigger("click");
            $("#modal-pendientes").modal();
        });
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
            const filasAlteradas = await fetcher('Ate_Resultados_2.aspx/Guarda_Critico_Manual', { body });
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

        $("#btn-agregar-quitar-examenes").on("click", () => {
            const id = getParameterByNameMaster("ID");
            console.log('aca esta el id de mi sujeto a agregar examenes', id)
            if (id) {
                $("#modal-agregar-quitar-examenes").modal();
                $("#Naten")
                    .val($("#Txt_NumAte").val())
                    .trigger($.Event('keypress', { keyCode: 13 }));
            } else {
                alert_ate_num()
            }
        });

        let tableQuita;
        $("#btn-quitar-estado").on("click", async () => {
            const id = getParameterByNameMaster("ID");
            if (id) {
                $("#modal-quitar-estado").modal();

                modal_show();
                let examenesDeLaAtencion = await fillExamenesSeccionArea({ idAtencion: ID_ATE || 0 });
                Hide_Modal();

                const checkBoxPrinter = (value) => `<input type="checkbox" 
                            class="form-check-input manitos2" 
                            style="width:20px;height:20px;"
                            type='checkbox'
                            value='${value}'
                            name='cbQuitarEstado'>`
                tableQuita?.destroy();
                $("#Div_DataTable_Quitar_Estado").empty().append($("<table>", { id: "DataTable_Quita_Estado", class: "display table table-hover table-striped table-iris", width: "100%", cellspacing: "0" }))
                $("#Div_DataTable_Quitar_Estado").css({
                    "max-height": "300px",
                    "overflow-y": "auto"
                });
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
            }
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


            const respuesta = new IrisResponse(await fetcher('Ate_Resultados_2.aspx/Quitar_Estado_Examen', { body }));
            if (respuesta.code !== 200) {
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





        $("#btn-modal-paciente").click(() => {
            const id = getParameterByNameMaster("ID");
            if (id) {
                $("#modal-editar-paciente").modal();
            }
        });

        $("#btn_Busca_Ate_Sec").click(() => {
            Ajax_Ate_Seccion();
        });

        $("#btn_Busca_Ate_Sec_Pendientes").click(() => {
            Ajax_Ate_Seccion(true);
        });

        $("#btn_Busca_Ate_Sec_pendiente").click(() => Ajax_examen_Pendientes());
        let USU_PROF = Galletas.getGalleta("ID_PROF");

        if (USU_PROF == 1) {
            $("#Btn_Validar").removeAttr("disabled");
            $("#Btn_Desvalidar").removeAttr("disabled");
        } else {
            $("#Btn_Validar").attr("disabled", true);
            $("#Btn_Desvalidar").attr("disabled", true);
        }
        //General
        modal_show();
        Btn_Audit.setActive(false);
        document.title = `CARGANDO`;
        num_title_loop = setInterval(fn_title_loop, 250);
        //Primera Carga
        //objAJAX_Sel_IntExt.requestNow();
        await objAJAX_Sel_Proc.requestNow();
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
    //Comportamiento Botones Inferiores------------------------------------------------------------
    let fn_Redim_Bottom_Bar = () => {
        let x = window.innerWidth;
        let y = window.innerHeight;
        let bolClass = $("body").hasClass("sidenav-toggled");
        if (bolClass == true) {
            $(".float_buttons").addClass("float_buttons_toggled");
        }
        else {
            $(".float_buttons").removeClass("float_buttons_toggled");
        }
    };

    function alert_ate_num() {
        return Swal.fire({
            title: "¡CAMPO VACIO!",
            text: "Ingrese primero el N° de la atención",
            icon: "warning",
            showCancelButton: false
        });
    }
    $(document).ready(() => {

        $("#Btn_P_Anti").click(() => {


            if ($("#Txt_NumAte").val() != "") {
                $("#mdlPanel").modal("show");
                fn_Busca_Dtt_Cultivos();
            } else {
                alert_ate_num();
            }

        });


        //$("#btnTrazabilidadAtencion").click(() => {
        //    const id = getParameterByNameMaster("ID");
        //    if (id) {
        //        window.open("/Check_List/Check_Point/Traza_Env_RecepLab2.aspx?aWRBdGVuY2lvbg===" + id, '_blank');
        //    } else {
        //        alert_ate_num();
        //    }
        //});
        //$("#btnTrazabilidadAtencion").click(() => {
        //    const id = getParameterByNameMaster("ID");
        //    if (id) {
        //        const url = "/Check_List/Check_Point/Traza_Env_RecepLab_V2.aspx?aWRBdGVuY2lvbg===" + id;
        //        $("#trazabilidadFrame").attr("src", url);
        //        $("#trazabilidadModal").modal("show");
        //    } else {
        //        alert_ate_num();
        //    }
        //});
        $("#btnTrazabilidadAtencion").click(() => {
            const id = getParameterByNameMaster("ID");
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


        $("#btn_Agregar").click(() => {
            fn_Agrega_Panel();
        });

        $("#btn_Quitar").click(() => {
            fn_Quita_Panel();
        });

        $("#btn_Guardar_Panel").click(() => {
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
            "url": "Ate_Resultados_2.aspx/Busca_Exa_Cultivo",
            "data": strParam,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": data => {
                Mx_CF_Cult = data.d;

                if (Mx_CF_Cult != null) {
                    fn_Fill_Dtt_Cultivos();
                }

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
            "url": "Ate_Resultados_2.aspx/IRIS_WEBF_BUSCA_EXAMENES_OBSERVACION_H2M",
            "data": strParam,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": data => {
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
        $("#Div_Exam_Agrega").css({
            "max-height": "300px",
            "overflow-y": "auto"
        });
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

        for (let i = 0; i < Mx_Obs_Exam_agrega.length; i++) {
            $("#DataTable_Exam_Agrega tbody").append(
                $("<tr>", { "class": "manito", id: Mx_Obs_Exam_agrega[i].ID_CODIGO_FONASA }).append(
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
        $("#DataTable_Exam_Agrega tbody tr").click(e => {
            const filaComoObjeto = Mx_Obs_Exam_agrega.find(item => item.ID_CODIGO_FONASA == e.currentTarget.id);

            ID_ATENCHION = filaComoObjeto.ID_ATENCION;
            ID_PERRRRRRCH = filaComoObjeto.ID_PER;
            ID_FONASSSAAAA = filaComoObjeto.ID_CODIGO_FONASA;

            $("#btnAgregaDeter").removeAttr("disabled");
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
            "url": "Ate_Resultados_2.aspx/IRIS_WEBF_BUSCA_PRUEBA_NO_SOLICITADA_Y_SOLICITADA_TODOS",
            "data": strParam,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": data => {
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
        $("<table>", {
            "id": "DataTable_Exam_Agrega2",
            "class": "display",
            "width": "100%",
            "cellspacing": "0"
        }).appendTo("#Div_Exam_Agrega2");

        $("#DataTable_Exam_Agrega2").append(
            $("<thead>"),
            $("<tbody>")
        );
        $("#DataTable_Exam_Agrega2").attr("class", "table table-hover table-striped table-iris");
        $("#DataTable_Exam_Agrega2 thead").attr("class", "cabzera");
        $("#DataTable_Exam_Agrega2 thead").append(
            $("<tr>").append(
                $("<th>", { "class": "textoReducido" }).text("#"),
                $("<th>", { "class": "textoReducido" }).text("Código"),
                $("<th>", { "class": "textoReducido" }).text("Descripción"),
                $("<th>", { "class": "textoReducido" }).text("Tipo Resultado"),
                $("<th>", { "class": "textoReducido" }).text("Unidad"),
                $("<th>", { "class": "textoReducido" }).text("Tipo Muestra"),
                $("<th>", { "class": "textoReducido" }).text("Cargar")

            )
        );
        const checkBoxPrinter = (id, value) => `<input type="checkbox" 
                                class="form-check-input manitos2" 
                                style="width:20px;height:20px;"
                                type='checkbox'
                                id='Hasdasd${id}'
                                value='${value}'
                                name='observacionesAgregar'>`
        for (let i = 0; i < Mx_Obs_Deter_soli_o_no_soli.length; i++) {
            $("#DataTable_Exam_Agrega2 tbody").append(
                $("<tr>").append(
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Obs_Deter_soli_o_no_soli[i].PRU_COD),
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Obs_Deter_soli_o_no_soli[i].PRU_DESC),
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Obs_Deter_soli_o_no_soli[i].TP_RESUL_DESC),
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Obs_Deter_soli_o_no_soli[i].UM_DESC),
                    $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Obs_Deter_soli_o_no_soli[i].T_MUESTRA_DESC),
                    $("<td>").css("text-align", "center").html(
                        (Mx_Obs_Deter_soli_o_no_soli[i].IN_ATENCION == 1) ? "Cargada" : checkBoxPrinter(i, Mx_Obs_Deter_soli_o_no_soli[i].ID_PRUEBA)
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
        })

        setTimeout(function () {
            tablaObs.columns.adjust().draw();
        }, 200);

        //active_tr();

    }
    // graba resultado por defecto determinacion solicitada o no
    function fn_Graba_resultado_defecto_deter_solicitada(IDS_PRUEBAS) {
        var strParam = JSON.stringify({
            ID_ATENCION: ID_ATENCHION,
            ID_PER: ID_PERRRRRRCH,
            ID_CF: ID_FONASSSAAAA,
            IDS_PRUEBAS
        });
        $.ajax({
            "type": "POST",
            "url": "Ate_Resultados_2.aspx/IRIS_WEBF_GRABA_RESULTADO_ATENCION_DEFECTO_H2M",
            "data": strParam,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": data => {
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
            "url": "Ate_Resultados_2.aspx/Busca_Exa_Ant_No_Cargado",
            "data": strParam,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": data => {
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
                } else {
                    Mx_Check_NC.push({ "index": index, "type": type });
                }
            } else {
                let Mx_Index = Mx_Check_NC.findIndex(x => x.index === index && x.type === type);
                Mx_Check_NC.splice(Mx_Index, 1);
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
            "url": "Ate_Resultados_2.aspx/Busca_Exa_Ant_Cargado",
            "data": strParam,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": data => {
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
                } else {
                    Mx_Check_C.push({ "index": index, "type": type });
                }
            } else {
                let Mx_Index = Mx_Check_C.findIndex(x => x === index && x.type === type);
                Mx_Check_C.splice(Mx_Index, 1);
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
                } else {
                    Mx_Check_C.push({ "index": index, "type": type });
                }
            } else {
                let Mx_Index = Mx_Check_C.findIndex(x => x === index && x.type === type);
                Mx_Check_C.splice(Mx_Index, 1);
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
                    } else {
                        Mx_Check_NC.push({ "index": index, "type": type });
                    }
                } else {
                    let Mx_Index = Mx_Check_NC.findIndex(x => x.index === index && x.type === type);
                    Mx_Check_NC.splice(Mx_Index, 1);
                }
            }).one();

            Mx_Check_C = [];
            Hide_Modal();
        } else {
            Hide_Modal();
            $(`#mdlAlert .modal-header .modal-title`).text("Examen Validado o Impreso");
            $(`#mdlAlert .modal-body`).empty();
            $(`#mdlAlert .modal-body`).append($(`<span>`).text("Estimado usuario, No puede quitar paneles asociados a exámenes validados o impresos."));
            $(`#mdlAlert`).modal();
        }
    }

    // Guardar Panel

    function fn_Guarda_Panel() {


        let NCar = [];
        let Car = [];
        let Mx_Guarda_Panel = [];

        Car = $("tr[name='p_C']");
        NCar = $("tr[name='p_No_C']");
        console.log('MI CARGADOS', Car)
        console.log('MI NO CARGADOS', Car)

        console.log(Car.length);
        let c_index = $("tr[name='p_Anti'][class='manito active']").attr("data-index");
        if (isNaN(c_index)) {
            $("#mdlPanel").modal("hide")
            return;
        };
        let ID_CF_CULT = Mx_CF_Cult[c_index].ID_CODIGO_FONASA;

        // Buscar data-type Cargado
        for (let i = 0; i < Car.length; i++) {
            let _type = Car[i].getAttribute("data-type");
            let _index = Car[i].getAttribute("data-index");
            let _prev = objData_Pac.ID_PREVE;
            //let _prev = $("#Sel_Prev").val();
            console.log('mi prevision', _type)
            console.log('mi prevision', _index)
            console.log('mi prevision', _prev)

            if (_type == "No_Cargado") {
                Mx_Guarda_Panel.push({ "ID_PANEL": Mx_Ant_No_Cargado[_index].ID_CODIGO_FONASA, "ID_ATE": ID_ATE, "ID_CF_CULT": ID_CF_CULT, "ID_PREVE": _prev, "TYPE": "Crea" });
            }
        }

        // Buscar data-type No_Cargado
        for (let i = 0; i < NCar.length; i++) {
            let _type = NCar[i].getAttribute("data-type");
            let _index = NCar[i].getAttribute("data-index");
            let _prev = $("#Sel_Prev").val();


            if (_type == "Cargado") {
                Mx_Guarda_Panel.push({ "ID_PANEL": Mx_Ant_Cargado[_index].ID_CF_ANTIBIOGRAMA, "ID_ATE": Mx_Ant_Cargado[_index].ID_ATENCION, "ID_CF_CULT": ID_CF_CULT, "ID_PREVE": _prev, "TYPE": "Quita" });
                console.log('ESTO SE ENVIA A PANEL CULTIVO', Mx_Guarda_Panel)
            }
        }

        if (Mx_Guarda_Panel.length > 0) {
            modal_show();
            var strParam = JSON.stringify({
                "Mx_Panel": Mx_Guarda_Panel
            });
            console.log("LISTAAAAA: ", Mx_Guarda_Panel)
            $.ajax({
                "type": "POST",
                "url": "Ate_Resultados_2.aspx/Guarda_Panel_Cultivo",
                "data": strParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    $("tr[name='p_Anti'][class='manito active']").trigger("click");

                    objAJAX_Get_ID_ATE.requestNow({
                        NUM_ATE: $("#Txt_NumAte").val(),
                        USU_ID_PROC: Galletas.getGalleta("USU_ID_PROC")
                    });

                    Hide_Modal();
                },
                "error": data => {
                    Hide_Modal();
                }
            });

        }
    }



    let JSON_Data_Table_det = [];

    const idUserCookie = parseInt(Galletas.getGalleta("ID_USER"));
    const idAdminCookie = parseInt(Galletas.getGalleta("P_ADMIN"));

    function Call_Data_Table_Detalle(id_ate_ressss) {
        //si el perfil es tens o si es dpereira o rorellana

        const esTM = perfilesValidadores.includes(idAdminCookie)

        if (!esTM && idUserCookie != 1) { // es TM o dpereira

            Swal.fire("Error", "Este usuario no está autorizado para notificar valores críticos", "error")

            return
        }
        modal_show();
        var Data_Par = JSON.stringify({
            ID_ATE_RES: id_ate_ressss
        });

        $(".block_wait").fadeIn(500);
        $.ajax({
            "type": "POST",
            "url": "/Check_List/Val_Criticos_Notif.aspx/Call_DataTable_Det",
            "data": Data_Par,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": function (response) {
                if (response.d.length > 0) {
                    JSON_Data_Table_det = response.d;
                    Hide_Modal();
                    $("#divTableDet2").empty();


                    Call_Data_Table_Detalle_Past(id_ate_ressss);
                } else {
                    Hide_Modal();
                    $("#Id_Conte").hide();
                    $("#mError_AAH h4").text("Sin resultados");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("No se han encontrado resultados para la búsqueda solicitada.");
                    $("#mError_AAH").modal();
                }

            },
            "error": function (response) {

                Hide_Modal();
            }
        });
    }



    let JSON_Data_Table_det2 = [];
    function Call_Data_Table_Detalle_Past(idAteRes) {
        modal_show();

        var Data_Par = JSON.stringify({
            ID_ATE_RES: idAteRes
        });

        $(".block_wait").fadeIn(500);
        $.ajax({
            "type": "POST",
            "url": "/Check_List/Val_Criticos_Notif.aspx/Call_DataTable_Det_past",
            "data": Data_Par,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": function (response) {
                JSON_Data_Table_det2.length = 0;
                if (response.d.length > 0) {
                    JSON_Data_Table_det2 = response.d;
                    $("#divTableDet").empty();
                    $("#divTableDet2").empty();

                    Fill_DataTable_Det(idAteRes);

                } else {
                    Fill_DataTable_Det(idAteRes);
                }
                Hide_Modal();

            },
            "error": function (response) {

                Hide_Modal();
            }
        });
    }
    //---------------------------------------------------- TABLA DETALLE -------------------------------------------------------------|
    function Fill_DataTable_Det(ID_ATE_RES = 0) {
        $("#divTableDet").empty().append($("<table>", { id: "DataTable_det", class: "display table table-hover table-striped table-iris", width: "100%", cellspacing: "0" }).append($("<thead>"), $("<tbody>")))

        $("#DataTable_det thead").append($("<tr>").append(
            $("<th>").text("#"),
            $("<th>").text("N° Atención"),
            $("<th>").text("Nombre Paciente"),
            $("<th>").text("Edad"),
            $("<th>").text("Fecha"),
            $("<th>").text("Lugar TM"),
            $("<th>").text("Determinación"),
            $("<th>").text("Resultado"),
            $("<th>").text("Alarma"),
            $("<th>", { style: "text-align:end" }).text("Muy Bajo"),
            $("<th>", { style: "text-align:end" }).text("Bajo"),
            $("<th>", { style: "text-align:end" }).text("Alto"),
            $("<th>", { style: "text-align:end" }).text("Muy Alto")
        ))

        JSON_Data_Table_det.forEach((item, i) => {
            $("#DataTable_det tbody").append($("<tr>", { "class": "manito" }).append(
                $("<td>").text(i + 1),
                $("<td>").text(item.ATE_NUM),
                $("<td>").text(item.PAC_NOMBRE + " " + item.PAC_APELLIDO),
                $("<td>").text(item.ATE_AÑO + " A"),
                $("<td>").text(moment(item.ATE_FECHA).format("DD-MM-YYYY")),
                $("<td>").text(item.PROC_DESC),
                $("<td>").text(item.PRU_DESC),
                $("<td>").text(item.ATE_RESULTADO),
                $("<td>").text(item.ATE_RESULTADO_ALT),
                $("<td>", { align: "right" }).text(item.ATE_RR_DESDE),
                $("<td>", { align: "right" }).text(item.ATE_R_DESDE),
                $("<td>", { align: "right" }).text(item.ATE_R_HASTA),
                $("<td>", { align: "right" }).text(item.ATE_RR_HASTA)
            ));
        });
        $("#divTableDet2").empty();
        let notificado = true;
        $("#btn-guardar-notificacion");
        $("#btn-guardar-notificacion").off('click').on('click', () => {
            Call_Guardar(ID_ATE_RES);
        });

        $("#btn-guardar-notificacion, #row-estado-fecha, #row-avisado-a").attr("hidden", notificado);
        $("#h5-log-registros").attr("hidden", !notificado);
        if (JSON_Data_Table_det2.length < JSON_Data_Table_det.length) {
            const divTableDet2 = document.getElementById("divTableDet2");

            notificado = false;
            $("#btn-guardar-notificacion, #row-estado-fecha, #row-avisado-a").attr("hidden", notificado);



            $("#mdlDet").modal("show");

        }
        $("<table>", {
            "id": "DataTable_det_2",
            "class": "display",
            "width": "100%",
            "cellspacing": "0"
        }).appendTo("#divTableDet2");

        $("#DataTable_det_2").append(
            $("<thead>"),
            $("<tbody>")
        );
        $("#DataTable_det_2").attr("class", "table table-hover table-striped table-iris");
        $("#DataTable_det_2 thead").attr("class", "cabezera");
        $("#DataTable_det_2 thead").append(
            $("<tr>").append(
                $("<th>", { class: "textoReducido" }).text("#"),
                $("<th>", { class: "textoReducido " }).text("Fecha"),
                $("<th>", { class: "textoReducido" }).text("Tipo de Aviso"),
                $("<th>", { class: "textoReducido" }).text("Usuario"),
                $("<th>", { class: "textoReducido" }).text("Estado"),
                $("<th>", { class: "textoReducido " }).text("Descripción")

            )
        );

        JSON_Data_Table_det2.forEach((item, i) => {
            $("#DataTable_det_2 tbody").append(
                $("<tr>", { "class": "manito" }).append(
                    $("<td>").text(i + 1),
                    $("<td>").text(item.DET_CRITICO_FECHA_MANUAL),
                    $("<td>").text(item.TP_CRITICO_DESC),
                    $("<td>").text(item.USU_NIC),
                    $("<td>").text(item.EST_DESCRIPCION),
                    $("<td>").text(item.DET_CRITICO_DESC)
                )
            );
        });
        $("#mdlDet").modal("show");

    }
    let isNotifSwalOpen = false
    function Call_Guardar(ID_ATE_RES_SUPREME) {
        //const fechaAvisado = $("#txt-fecha-avisado").val();
        //if (fechaAvisado == "") {
        //    Swal.fire({ icon: "info", title: "Información", text: "Ingrese una fecha y hora válida" });
        //}

        const idUser = parseInt(Galletas.getGalleta("ID_USER"));
        if (!idUser) {
            return;
        }

        modal_show();

        var Data_Par = JSON.stringify({
            ID_ATE_RES_SUPREME,
            S_Id_User: Galletas.getGalleta("ID_USER"),
            //DATE_str01: fechaAvisado,
            NOTIFICADO: $("#txt-avisado").val(),
            ID_TP_CRITICO: $("#Ddl_Stat_aviso2").val(),
            CAUSA: "Crítico"
        });

        $.ajax({
            "type": "POST",
            "url": "/Check_List/Val_Criticos_Notif.aspx/Call_Guardar",
            "data": Data_Par,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": res => {
                switch (res.d) {
                    case "1":
                        Swal.fire({ icon: "success", title: "Éxito", text: "Notificación creada correctamente." });
                        break;
                    case "-1":
                        Swal.fire({ icon: "info", title: "Información", text: "El valor crítico ya fue informado." });
                        break;
                    case "10":
                        Swal.fire({ icon: "info", title: "Información", text: "Ocurrió un error con la fecha, intente de nuevo." });
                        $("#txt-fecha-avisado").val("")
                        break;
                }
                Hide_Modal();
            },
            "error": function (response) {
                var str_Error = response.responseJSON.ExceptionType + "\n \n";
                str_Error = response.responseJSON.Message;
                alert(str_Error);
                Hide_Modal();
            }
        });
    }



    //Modal Resultados Codificados-----------------------------------------------------------------
    $(document).ready(() => {

        $(`#Btn_RC_Add`).click(async (Me) => {
            let xVal = Txt_ResCod_Out.value.replace(/\./gi, ",");
            $("#Dtt_Exam .tr_selected input[type=text]").val(xVal);
            let xEvent = $.Event("keypress");
            let objInput = document.querySelector("#Dtt_Exam .tr_selected input[type=text]");
            xEvent.currentTarget = objInput;
            xEvent.which = 13;
            xEvent.keyCode = 13;
            await fn_Write(xEvent);
            await fn_Calc();
            keyEnter = true;
            $(objInput).parents("tr").next().find("input[type=text]").focus();
        });
    });
})(ATE_RES || (ATE_RES = {}));
//# sourceMappingURL=Ate_Resultados_2.js.map
