/// <reference path="../js/webform.ts" />
namespace ATE_RES {
    //Declaración de Interfaces
    namespace FORM_INT {
        export interface Data_Pac {
            ID_ATE: number;
            ID_Pac: number;
            fNac: string;
            nAte: number;
            Fecha: string;
            Nombre: string;
            Edad: string;
            Sexo: string;
            FUR: string;
            NAME_MED: string;
        }

        export interface Data_Sel_Response {
            ID: number;
            DESC: string;
        }

        export interface Data_Table {
            Desc: string;
            EE: Data_Table_EE;
            Exam: {
                Descrp: string;
                ID_EXA: number;
                ID_CF: number;
            };
            ReHi: string | number;
            Res: Data_Table_Res;
            Stat: string;
            TT: Data_Table_TT;
            Unit: string;
            cDia: string;
        }

        export interface Data_Table_EE {
            estado: string;
            value: number;
        }

        export interface Data_Table_Exam {
            Descrp: string;
            ID_EXA: number;
            ID_CF: number;
        }

        export interface Data_Table_Res {
            ID_RES: number;
            a1: string | number;
            a2: string | number;
            b1: string | number;
            b2: string | number;
            value: string | number;
            pruDecimal: number;
            pruCero: boolean;
        }

        export interface Data_Table_TT {
            ID_TD: number;
            DESC_TD: string;
        }
    }

    //---------------------------------------------------------------------------------------------
    //Declaración de Variables Internas------------------------------------------------------------
    let strUrlQuery: string = (function () {
        //Comprobar URL
        let REE: string

        let strURL: string[] = location.href.match(/([a-z]|[0-9]|-|_)\.aspx\?ID\=/gi)
        if (strURL == null) {
            location.href = "/index.aspx"
            REE = ""
        } else {
            REE = location.href.match(/\?ID\=.+/gi)[0]
        }

        return REE
    } ())
    let objWrite: {
        URL: string;
        Param: Object;
    } = {
        URL: null,
        Param: null,
    }

    let fucusTimeout: number
    let objData_Pac: FORM_INT.Data_Pac
    let objData_Dtt: FORM_INT.Data_Table[]
    
    //Declaración de Funciones---------------------------------------------------------------------
    declare var modal_show: () => void
    declare var Hide_Modal: () => void

    class class_Count_Load {
        private count: number
        public maxCount: number

        constructor() {
            this.count = 0
            this.maxCount = 6
        }
        
        public endLoad():number {
            this.count += 1

            if (this.count >= this.maxCount) {
                Hide_Modal()
            }

            return this.count
        }
    }

    //Declaración de Elem--------------------------------------------------------------------------
    let Txt_NumAte = new WEBFORM.class_Input("Txt_NumAte")
    let Txt_DateAte = new WEBFORM.class_Input("Txt_DateAte")
    let Txt_Nombre = new WEBFORM.class_Input("Txt_Nombre")
    let Txt_Edad = new WEBFORM.class_Input("Txt_Edad")
    let Txt_Sexo = new WEBFORM.class_Input("Txt_Sexo")
    let Txt_FUR = new WEBFORM.class_Input("Txt_FUR")

    Txt_NumAte.setReadOnly(true)
    Txt_DateAte.setReadOnly(true)
    Txt_Nombre.setReadOnly(true)
    Txt_Edad.setReadOnly(true)
    Txt_Sexo.setReadOnly(true)
    Txt_FUR.setReadOnly(true)

    let Sel_Prev = new WEBFORM.class_Select("Sel_Prev")
    let Sel_Proc = new WEBFORM.class_Select("Sel_Proc")
    let Sel_Prog = new WEBFORM.class_Select("Sel_Prog")
    let Sel_Secc = new WEBFORM.class_Select("Sel_Secc")
    let Sel_Exam = new WEBFORM.class_Select("Sel_Exam")

    let Mdl_Init_Load = new class_Count_Load()
    let Dtt_Exam = new WEBFORM.class_Table("Dtt_Exam", "Cargando...")
    let fn_Make_Table = (): void => {
        Dtt_Exam.addTHead("T", "left")
        Dtt_Exam.addTHead("E", "left")
        Dtt_Exam.addTHead("Exámen", "left")
        Dtt_Exam.addTHead("Descripción", "left")
        Dtt_Exam.addTHead("Resultado", "left")
        Dtt_Exam.addTHead("Unidad", "left")
        Dtt_Exam.addTHead("", "left")
        Dtt_Exam.addTHead("Desde", "left")
        Dtt_Exam.addTHead("Hasta", "left")
        Dtt_Exam.addTHead("Result. Hist.", "left")
        Dtt_Exam.addTHead("T", "left")

        for (let i in objData_Dtt) {
            var index = i

            let xSc = parseInt(String(Sel_Secc.getValue().value))
            let xCF = parseInt(String(Sel_Exam.getValue().value))

            if ((xSc != 0) && (xCF != 0)) {
                if (objData_Dtt[index].Exam.ID_CF != xCF) {
                    continue
                }
            }

            Dtt_Exam.addRow(
                index,
                [
                    objData_Dtt[index].TT.DESC_TD,
                    objData_Dtt[index].EE.estado,
                    objData_Dtt[index].Exam.Descrp,
                    objData_Dtt[index].Desc,
                    (function () {
                        let value = objData_Dtt[index].Res.value
                        let Stat_Valid = objData_Dtt[index].EE.value
                        let stat: string = objData_Dtt[index].Stat
                        let xParam: string

                        if (objData_Dtt[index].Stat != null) {
                            stat = objData_Dtt[index].Stat.toLowerCase()
                        }

                        if ((TOOL.fn_IsNumeric(objData_Dtt[index].Res.b1) == true) &&
                            (TOOL.fn_IsNumeric(objData_Dtt[index].Res.a1) == true) &&
                            (stat != "n") && (value != null) && (value != "")) {

                            if ((objData_Dtt[index].Res.b1 > parseFloat(value.toString().replace(/,/gi, "."))) ||
                                (objData_Dtt[index].Res.a1 < parseFloat(value.toString().replace(/,/gi, ".")))) {
                                xParam += ` class="input_error"`
                            } else if ((TOOL.fn_IsNumeric(value.toString().replace(/,/gi, ".")) == false) &&
                                       (objData_Dtt[index].TT.ID_TD != 1)) {
                                xParam += ` class="input_error"`
                            }

                        }

                        if ((Stat_Valid == 6) || (Stat_Valid == 14) || (objData_Dtt[index].TT.ID_TD == 4)) {
                            xParam += ` readonly`
                        }

                        if (value == null) {
                            value = ""
                        } else {
                            if (TOOL.fn_IsNumeric(value) == true) {
                                value = TOOL.fn_cutDecimals(value, objData_Dtt[index].Res.pruDecimal)
                            }

                            value = String(value).replace(/\./gi, ",")
                        }

                        xParam += ` rows="1"`
                        return `<input type="text" ${xParam} value="${value}" />`
                    }()),
                    objData_Dtt[index].Unit,
                    (function () {
                        let xVal: string = objData_Dtt[index].Stat
                        if (xVal == null) {
                            xVal = ""
                        }

                        if ((xVal.toUpperCase() == "N") || (xVal.toUpperCase() == "")) {
                            return `<span class="td_stat">${xVal}</span>`
                        } else {
                            return `<span class="td_stat" style="color: #d30000;">${xVal}</span>`
                        }
                    }()),
                    (function () {
                        let value = objData_Dtt[index].Res.b1
                        let dec = objData_Dtt[index].Res.pruDecimal

                        if (value == null) {
                            return "-"
                        } else if ((TOOL.fn_IsNumeric(value) == true) && (TOOL.fn_IsNumeric(dec) == true)) {
                            value = String(TOOL.fn_cutDecimals(value, dec))

                            return String(value).replace(/\./gi, ",")
                        } else {
                            return value
                        }
                    }()),
                    (function () {
                        let value = objData_Dtt[index].Res.a1
                        let dec = objData_Dtt[index].Res.pruDecimal

                        if (value == null) {
                            return "-"
                        } else if ((TOOL.fn_IsNumeric(value) == true) && (TOOL.fn_IsNumeric(dec) == true)) {
                            value = String(TOOL.fn_cutDecimals(value, dec))

                            return String(value).replace(/\./gi, ",")
                        } else {
                            return value
                        }
                    }()),
                    objData_Dtt[i].ReHi,
                    objData_Dtt[i].cDia
                ]
            )
        }

        Dtt_Exam.isClickeable = true
        Dtt_Exam.isDataTable = true
        Dtt_Exam.updateTable("No se han encontrado exámenes.", 100)

        $("table input[type=text]").focusin((Me: JQueryEventObject) => {
            $(Me.currentTarget).select()
        })
        $("table input[type=text]").focusout((Me: JQueryEventObject) => {
            if ($(Me.currentTarget).attr("readonly") == null) {
                fn_Write(Me)
            }
            
            clearTimeout(fucusTimeout)
        })
        $("table input[type=text]").keypress((Me: JQueryEventObject) => {
            clearTimeout(fucusTimeout)

            if (Me.which == 13) {
                if ($(Me.currentTarget).attr("readonly") == null) {
                    fn_Write(Me)
                }
            } else {
                if ($(Me.currentTarget).attr("readonly") == null) {
                    fucusTimeout = setTimeout(() => {
                        fn_Write(Me)
                    }, 1500)
                }
            }
        })

        let fn_Write = (Me: JQueryEventObject) => {
            let xValue = $(Me.currentTarget).val()
            let xIndex: number = parseInt(Dtt_Exam.tr_value)
            let xStat: number
            let xParam: string

            //Evaluar Valor
            xValue = String(xValue).trim().replace(/,/gi, ".")
            if (TOOL.fn_IsNumeric(xValue) == true) {
                xValue = TOOL.fn_cutDecimals(xValue, objData_Dtt[xIndex].Res.pruDecimal)
                xValue = parseFloat(xValue)
            }
            
            objData_Dtt[xIndex].Res.value = xValue
            var objItem = objData_Dtt[xIndex].Res
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
                            return -2
                        } else if (objData_Dtt[xIndex].Res.a2 < xValue) {
                            return 2
                        } else if (objData_Dtt[xIndex].Res.b1 > xValue) {
                            return -1
                        } else if (objData_Dtt[xIndex].Res.a1 < xValue) {
                            return 1
                        } else {
                            return 0
                        }
                    } else if ((TOOL.fn_IsNumeric(xValue) == true) &&
                        (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.b1) == true) &&
                        (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.a1) == true)) {

                        if (objData_Dtt[xIndex].Res.b1 > xValue) {
                            return -1
                        } else if (objData_Dtt[xIndex].Res.a1 < xValue) {
                            return 1
                        } else {
                            return 0
                        }
                    } else {
                        return null
                    }
                } else {
                    if ((TOOL.fn_IsNumeric(xValue) == true) &&
                        (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.b2) == true) &&
                        (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.b1) == true) &&
                        (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.a1) == true) &&
                        (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.a2) == true) &&
                        (objData_Dtt[xIndex].Res.b2 < objData_Dtt[xIndex].Res.b1) &&
                        ((objData_Dtt[xIndex].Res.a2 > objData_Dtt[xIndex].Res.a1))) {

                        if (objData_Dtt[xIndex].Res.b2 > xValue) {
                            return -2
                        } else if (objData_Dtt[xIndex].Res.a2 > xValue) {
                            return 2
                        } else if (objData_Dtt[xIndex].Res.b1 < xValue) {
                            return -1
                        } else if (objData_Dtt[xIndex].Res.a1 < xValue) {
                            return 1
                        } else {
                            return 0
                        }
                    } else if ((TOOL.fn_IsNumeric(xValue) == true) &&
                        (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.b1) == true) &&
                        (TOOL.fn_IsNumeric(objData_Dtt[xIndex].Res.a1) == true)) {

                        if (objData_Dtt[xIndex].Res.b1 > xValue) {
                            return -1
                        } else if (objData_Dtt[xIndex].Res.a1 < xValue) {
                            return 1
                        } else {
                            return 0
                        }
                    } else {
                        return null
                    }
                }
            } ())
            
            if (xStat == 9000) {
                objData_Dtt[xIndex].Stat = ""
            } else if (xStat < 0) {
                objData_Dtt[xIndex].Stat = "B"
            } else if (xStat > 0) {
                objData_Dtt[xIndex].Stat = "A"
            } else if (xStat == 0) {
                objData_Dtt[xIndex].Stat = "N"
            } else {
                objData_Dtt[xIndex].Stat = ""
            }

            //Validar ceros
            xValue = TOOL.fn_cutDecimals(String(xValue), objData_Dtt[xIndex].Res.pruDecimal).trim().replace(/\./gi, ",")
            if ((objData_Dtt[xIndex].Res.pruCero == false) &&
                (parseFloat(TOOL.fn_cutDecimals(xValue, objData_Dtt[xIndex].Res.pruDecimal)) === 0)) {
                xValue = ""
                objData_Dtt[xIndex].Stat = "";
                $(Me.currentTarget).attr("class", "input_error")

            } else {
                if ((objData_Dtt[xIndex].Stat == "") && (xStat == null)) {
                    $(Me.currentTarget).removeAttr("class")

                } else if (objData_Dtt[xIndex].Stat == "N") {
                    $(Me.currentTarget).removeAttr("class")
                    
                } else {
                    $(Me.currentTarget).attr("class", "input_error")
                }
            }
            
            console.log(`Val REF:\nB2 = ${objData_Dtt[xIndex].Res.b2}\nB1 = ${objData_Dtt[xIndex].Res.b1}\nA1 = ${objData_Dtt[xIndex].Res.a1}\nA2 = ${objData_Dtt[xIndex].Res.a2}`)
            console.log(`Value = ${$(Me.currentTarget).val()}; ValueParsed = ${TOOL.fn_cutDecimals(xValue, objData_Dtt[xIndex].Res.pruDecimal)}; Stat = ${xStat}\nTipo Dato = ${objData_Dtt[xIndex].TT.ID_TD}\nDecimales = ${objData_Dtt[xIndex].Res.pruDecimal}\nAcepta Ceros = ${objData_Dtt[xIndex].Res.pruCero}\n\n`)

            $(Me.currentTarget).val(xValue)
            $(Me.currentTarget).parents("tr").find(".td_stat").text(objData_Dtt[xIndex].Stat)

            if ((objData_Dtt[xIndex].Stat.toLocaleUpperCase() != "N") && (objData_Dtt[xIndex].Stat.trim() != "")) {
                $(Me.currentTarget).parents("tr").find(".td_stat").css({
                    color: "#d50000"
                })
            } else {
                $(Me.currentTarget).parents("tr").find(".td_stat").css({
                    color: "#212529"
                })
            }

            if (objData_Dtt[xIndex].TT.ID_TD != 1) {
                objWrite.URL = `Ate_Resultados.aspx/IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_NUMERICO`

                objWrite.Param = {
                    ID_RES: objData_Dtt[xIndex].Res.ID_RES,
                    RES: xValue,
                    EVAL: xValue
                }
            } else {
                objWrite.URL = `Ate_Resultados.aspx/IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_TEXTO`

                objWrite.Param = {
                    ID_RES: objData_Dtt[xIndex].Res.ID_RES,
                    RES: xValue
                }
            }
            
            let objAJAX_Write = new TOOL.class_AJAX(
                objWrite.URL,
                (resp: TOOL.int_ajax_success) => {

                },
                (fail: any) => {
                    Hide_Modal()
                    $("#mdlError").modal("show")

                    try {
                        $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType)
                        $("#mdlTxt_Descr").text(fail.responseJSON.Message)
                        $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace)
                    } catch (err) {
                        $("#mdlTxt_Type").text("Error Genérico")
                        $("#mdlTxt_Descr").text("Error en el Front End")
                        $("#mdlTxt_StackT").text("Mire la consola para Detalles.")
                        console.log(fail)
                    }
                }
            )

            objAJAX_Write.requestNow(objWrite.Param)
        }
    }
    
    //Declaración AJAX-----------------------------------------------------------------------------
    let objAJAX_Pac_Data = new TOOL.class_AJAX(
        "Ate_Resultados.aspx/Page_Load" + strUrlQuery,
        (resp: TOOL.int_ajax_success) => {
            objData_Pac = resp.d

            Txt_NumAte.setValue(objData_Pac.nAte)
            Txt_DateAte.setValue(objData_Pac.Fecha)
            Txt_Nombre.setValue(objData_Pac.Nombre)
            Txt_Edad.setValue(objData_Pac.Edad)
            Txt_Sexo.setValue(objData_Pac.Sexo)
            Txt_FUR.setValue(objData_Pac.FUR)
            
            objAJAX_Fill_Table.requestNow({
                R_ID_ATE: objData_Pac.ID_ATE,
                R_ID_SECC: Sel_Secc,
                R_ID_EXAM: Sel_Exam,
                R_ID_PAC: objData_Pac.ID_Pac,
                R_FNAC: objData_Pac.fNac,
                R_SEXO: objData_Pac.Sexo
            })
        },
        (fail: any) => {
            Hide_Modal()
            $("#mdlError").modal("show")

            try {
                $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType)
                $("#mdlTxt_Descr").text(fail.responseJSON.Message)
                $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace)
            } catch (err) {
                $("#mdlTxt_Type").text("Error Genérico")
                $("#mdlTxt_Descr").text("Error en el Front End")
                $("#mdlTxt_StackT").text("Mire la consola para Detalles.")
                console.log(fail)
            }

        }
    )

    let objAJAX_Sel_Prev = new TOOL.class_AJAX(
        "Ate_Resultados.aspx/Sel_Prev" + strUrlQuery,
        (resp: TOOL.int_ajax_success) => {
            let xData: FORM_INT.Data_Sel_Response[]
            xData = resp.d

            for (let i in xData) {
                Sel_Prev.insertElem(xData[i].DESC, xData[i].ID)
            }

            Mdl_Init_Load.endLoad()
        },
        (fail: any) => {
            Hide_Modal()
            $("#mdlError").modal("show")

            try {
                $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType)
                $("#mdlTxt_Descr").text(fail.responseJSON.Message)
                $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace)
            } catch (err) {
                $("#mdlTxt_Type").text("Error Genérico")
                $("#mdlTxt_Descr").text("Error en el Front End")
                $("#mdlTxt_StackT").text("Mire la consola para Detalles.")
                console.log(fail)
            }
        }
    )

    let objAJAX_Sel_Proc = new TOOL.class_AJAX(
        "Ate_Resultados.aspx/Sel_Proc" + strUrlQuery,
        (resp: TOOL.int_ajax_success) => {
            let xData: FORM_INT.Data_Sel_Response[]
            xData = resp.d

            for (let i in xData) {
                Sel_Proc.insertElem(xData[i].DESC, xData[i].ID)
            }

            Mdl_Init_Load.endLoad()
        },
        (fail: any) => {
            Hide_Modal()
            $("#mdlError").modal("show")

            try {
                $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType)
                $("#mdlTxt_Descr").text(fail.responseJSON.Message)
                $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace)
            } catch (err) {
                $("#mdlTxt_Type").text("Error Genérico")
                $("#mdlTxt_Descr").text("Error en el Front End")
                $("#mdlTxt_StackT").text("Mire la consola para Detalles.")
                console.log(fail)
            }
        }
    )

    let objAJAX_Sel_Prog = new TOOL.class_AJAX(
        "Ate_Resultados.aspx/Sel_Prog" + strUrlQuery,
        (resp: TOOL.int_ajax_success) => {
            let xData: FORM_INT.Data_Sel_Response[]
            xData = resp.d

            for (let i in xData) {
                Sel_Prog.insertElem(xData[i].DESC, xData[i].ID)
            }

            Mdl_Init_Load.endLoad()
        },
        (fail: any) => {
            Hide_Modal()
            $("#mdlError").modal("show")

            try {
                $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType)
                $("#mdlTxt_Descr").text(fail.responseJSON.Message)
                $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace)
            } catch (err) {
                $("#mdlTxt_Type").text("Error Genérico")
                $("#mdlTxt_Descr").text("Error en el Front End")
                $("#mdlTxt_StackT").text("Mire la consola para Detalles.")
                console.log(fail)
            }
        }
    )

    let objAJAX_Sel_Secc = new TOOL.class_AJAX(
        "Ate_Resultados.aspx/Sel_Secc" + strUrlQuery,
        (resp: TOOL.int_ajax_success) => {
            let xData: FORM_INT.Data_Sel_Response[]
            xData = resp.d

            for (let i in xData) {
                Sel_Secc.insertElem(xData[i].DESC, xData[i].ID)
            }

            Mdl_Init_Load.endLoad()
        },
        (fail: any) => {
            Hide_Modal()
            $("#mdlError").modal("show")

            try {
                $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType)
                $("#mdlTxt_Descr").text(fail.responseJSON.Message)
                $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace)
            } catch (err) {
                $("#mdlTxt_Type").text("Error Genérico")
                $("#mdlTxt_Descr").text("Error en el Front End")
                $("#mdlTxt_StackT").text("Mire la consola para Detalles.")
                console.log(fail)
            }
        }
    )

    let objAJAX_Sel_Exam = new TOOL.class_AJAX(
        "Ate_Resultados.aspx/Sel_Exam" + strUrlQuery,
        (resp: TOOL.int_ajax_success) => {
            let xData: FORM_INT.Data_Sel_Response[]
            xData = resp.d

            for (let i = 0; i < xData.length; ++i) {
                Sel_Exam.insertElem(xData[i].DESC, xData[i].ID)
            }

            Mdl_Init_Load.endLoad()
        },
        (fail: any) => {
            Hide_Modal()
            $("#mdlError").modal("show")

            try {
                $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType)
                $("#mdlTxt_Descr").text(fail.responseJSON.Message)
                $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace)
            } catch (err) {
                $("#mdlTxt_Type").text("Error Genérico")
                $("#mdlTxt_Descr").text("Error en el Front End")
                $("#mdlTxt_StackT").text("Mire la consola para Detalles.")
                console.log(fail)
            }
        }
    )

    let objAJAX_Fill_Table = new TOOL.class_AJAX(
        "Ate_Resultados.aspx/Json_DataTable",
        (resp: TOOL.int_ajax_success) => {
            objData_Dtt = resp.d

            fn_Make_Table()
            Mdl_Init_Load.endLoad()
        },
        (fail: any) => {
            Hide_Modal()
            $("#mdlError").modal("show")

            try {
                $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType)
                $("#mdlTxt_Descr").text(fail.responseJSON.Message)
                $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace)
            } catch (err) {
                $("#mdlTxt_Type").text("Error Genérico")
                $("#mdlTxt_Descr").text("Error en el Front End")
                $("#mdlTxt_StackT").text("Mire la consola para Detalles.")
                console.log(fail)
            }
        }
    )
    
    //---------------------------------------------------------------------------------------------
    //Evento de carga------------------------------------------------------------------------------
    $(document).ready(() => {
        modal_show()
        
        Sel_Secc.insertElem("<< Todos >>", 0)
        Sel_Exam.insertElem("<< Todos >>", 0)

        objAJAX_Pac_Data.requestNow()
        objAJAX_Sel_Prev.requestNow()
        objAJAX_Sel_Proc.requestNow()
        objAJAX_Sel_Prog.requestNow()
        objAJAX_Sel_Secc.requestNow()
        objAJAX_Sel_Exam.requestNow()
    });

    $(window).on("beforeunload", () => {
        clearTimeout(fucusTimeout)
    })

    Sel_Exam.eventChange((Me: JQueryEventObject) => {
        fn_Make_Table()
    })

    Dtt_Exam.evclick_tr = (Me: JQueryEventObject) => {
        $(Me.currentTarget).find("input").focus()
    }
}