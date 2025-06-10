//Declaraciones Internas
namespace MODAL {
    declare var modal_show: () => void
    declare var Hide_Modal: () => void
    export let show = () => {
        modal_show()
    }
    export let hide = () => {
        Hide_Modal()
    }
}
interface iData {
    ID_PREINGRESO: number;
    PREI_NUM: string;
    PREI_FECHA_PRE: Date;
    ID_ATENCION: number;
    ATE_NUM: string;
    ATE_FECHA: Date;
    PAC_COD: string;
    PAC_NOMBRE: string;
    ID_PROCEDENCIA: number;
    PROC_DESC: string;
    ID_PREVE: number;
    PREV_DESC: string;
    ID_PROGRAMA: number;
    PROGRA_DESC: string;
    ID_SUBP: number;
    SUBP_DESC: string;
    EST_DESCRIPCION: string;
    COUNT_PEND: number;
}
let arrData: Array<iData> = []

//Declaraciones Objetos
let txtDate01 = new H.Ts_Textbox("txtDate01")
let txtDate02 = new H.Ts_Textbox("txtDate02")
let selProc = new H.Ts_Select("selProc")
let selPrev = new H.Ts_Select("selPrev")
let selProg = new H.Ts_Select("selProg")
let selSubP = new H.Ts_Select("selSubP")
let txtN_Pre = new H.Ts_Textbox("txtN_Pre")
let txtN_Ate = new H.Ts_Textbox("txtN_Ate")
let txtP_Rut = new H.Ts_Textbox("txtP_Rut")
let txtP_Dni = new H.Ts_Textbox("txtP_Dni")
let txtP_Name = new H.Ts_Textbox("txtP_Name")
let txtP_Last = new H.Ts_Textbox("txtP_Last")
let btnSearch1 = new H.Ts_Button("btnSearch1")
let btnSearch2 = new H.Ts_Button("btnSearch2")
let divTable = new H.Ts_Table("divTable")

//Declaraciones AJAX
let fn_error = (fail: any) => {
    MODAL.hide()
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
let ajaxProc = new U.Ajax()
ajaxProc.functName = "GET_Sel_Proc"
ajaxProc.error = fn_error
ajaxProc.success = (resp) => {
    let arr: Array<{
        ID_PROCEDENCIA: number;
        PROC_COD: string;
        PROC_DESC: string;
        ID_ESTADO: number;
    }> = resp.d

    selProc.clean()
    selProc.addItem("TODOS", 0)
    arr.forEach(item => {
        selProc.addItem(item.PROC_DESC, item.ID_PROCEDENCIA)
    })

    ajaxPrev.requestNow({
        ID_PROC: 0
    })

    selProc.eventChange = null
    selProc.eventChange = (Me) => {
        ajaxPrev.requestNow({
            ID_PROC: selProc.value
        })
    }
}

let ajaxPrev = new U.Ajax()
ajaxPrev.functName = "GET_Sel_Prev"
ajaxPrev.error = fn_error
ajaxPrev.success = (resp) => {
    let arr: Array<{
        ID_PREVE: number;
        PREVE_COD: string;
        PREVE_DESC: string;
        ID_ESTADO: number;
    }> = resp.d

    selPrev.clean()
    selPrev.addItem("TODOS", 0)
    arr.forEach(item => {
        selPrev.addItem(item.PREVE_DESC, item.ID_PREVE)
    })

    ajaxProg.requestNow()
}

let ajaxProg = new U.Ajax()
ajaxProg.functName = "GET_Sel_Prog"
ajaxProg.error = fn_error
ajaxProg.success = (resp) => {
    let arr: Array<{
        ID_PROGRA: number;
        PROGRA_COD: string;
        PROGRA_DESC: string;
        ID_ESTADO: number;
    }> = resp.d

    selProg.clean()
    selProg.addItem("TODOS", 0)
    arr.forEach(item => {
        selProg.addItem(item.PROGRA_DESC, item.ID_PROGRA)
    })

    ajaxSubP.requestNow({
        ID_PREV: selPrev.value,
        ID_PROG: selProg.value
    })

    selProg.eventChange = null
    selProg.eventChange = (Me) => {
        ajaxSubP.requestNow({
            ID_PREV: selPrev.value,
            ID_PROG: selProg.value
        })
    }
}

let ajaxSubP = new U.Ajax()
ajaxSubP.functName = "GET_Sel_SubP"
ajaxSubP.error = fn_error
ajaxSubP.success = (resp) => {
    let arr: Array<{
        ID_PROGRA: number;
        ID_SUBP: number;
        SUBP_DESC: string;
        ID_ESTADO: number;
        ID_PREVE: number;
    }> = resp.d

    selSubP.clean()
    selSubP.addItem("TODOS", 0)
    arr.forEach(item => {
        selSubP.addItem(item.SUBP_DESC, item.ID_SUBP)
    })
}

let ajaxData = new U.Ajax()
ajaxData.error = fn_error
ajaxData.success = (resp) => {
    arrData = resp.d
    
    divTable.addHeader("N° Preingreso", H.cHTMLAlign.center)
    divTable.addHeader("Fecha Prei", H.cHTMLAlign.center)
    divTable.addHeader("N° Atención", H.cHTMLAlign.center)
    divTable.addHeader("Fecha Ate", H.cHTMLAlign.center)
    divTable.addHeader("RUT/DNI", H.cHTMLAlign.center)
    divTable.addHeader("Nombre Paciente", H.cHTMLAlign.center)
    divTable.addHeader("Procedencia", H.cHTMLAlign.center)
    divTable.addHeader("Previsión", H.cHTMLAlign.center)
    divTable.addHeader("Programa", H.cHTMLAlign.center)
    divTable.addHeader("Sub Programa", H.cHTMLAlign.center)

    arrData.forEach((item, i) => {
        if (item.PREI_FECHA_PRE != null) {
            divTable.addCellRow(item.PREI_NUM, H.cHTMLAlign.right)
            divTable.addCellRow(moment(item.PREI_FECHA_PRE).format("DD/MM/YYYY"), H.cHTMLAlign.center)
        } else {
            divTable.addCellRow("-", H.cHTMLAlign.center)
            divTable.addCellRow("-", H.cHTMLAlign.center)
        }
        if (item.ATE_FECHA != null) {
            divTable.addCellRow(item.ATE_NUM, H.cHTMLAlign.right)
            divTable.addCellRow(moment(item.ATE_FECHA).format("DD/MM/YYYY"), H.cHTMLAlign.center)
        } else {
            divTable.addCellRow("-", H.cHTMLAlign.center)
            divTable.addCellRow("-", H.cHTMLAlign.center)
        }
        divTable.addCellRow(item.PAC_COD, H.cHTMLAlign.center)
        divTable.addCellRow(item.PAC_NOMBRE, H.cHTMLAlign.left)
        divTable.addCellRow(item.PROC_DESC, H.cHTMLAlign.left)
        divTable.addCellRow(item.PREV_DESC, H.cHTMLAlign.left)
        divTable.addCellRow(item.PROGRA_DESC.replace(/(<|>)/gi, ""), H.cHTMLAlign.left)
        divTable.addCellRow(item.SUBP_DESC.replace(/(<|>)/gi, ""), H.cHTMLAlign.left)

        divTable.makeRow()
    })
    divTable.makeTable()
}

//Configuracion
txtDate01.datePicker = true
txtDate01.locked = true
txtDate02.datePicker = true
txtDate02.locked = true
divTable.setDataTable(true, 100)

//Inicio Ejecución
H.form.load = () => {
    ajaxProc.requestNow({
        ID_PREV: 0
    })
    
}

//Eventos
btnSearch1.eventClick = () => {
    divTable.showLoading()
    ajaxData.functName = "GET_DataTable_Filther_1"
    ajaxData.requestNow({
        DESDE: moment(txtDate01.value, `DD/MM/YYYY`).toDate(),
        HASTA: moment(txtDate02.value, `DD/MM/YYYY`).toDate(),
        ID_PROC: selProc.value,
        ID_PREV: selPrev.value,
        ID_PROG: selProg.value,
        ID_SUBP: selSubP.value
    })
}

btnSearch2.eventClick = () => {
    let bol_search: boolean = false

    if (txtN_Pre.value.trim() != "") {
        bol_search = true
    }
    if (txtN_Ate.value.trim() != "") {
        bol_search = true
    }
    if (txtP_Rut.value.trim() != "") {
        bol_search = true
    }
    if (txtP_Dni.value.trim() != "") {
        bol_search = true
    }
    if (txtP_Name.value.trim() != "") {
        bol_search = true
    }
    if (txtP_Last.value.trim() != "") {
        bol_search = true
    }

    if (bol_search == false) {
        $(`#mdlEmpty`).modal()
        return
    }

    divTable.showLoading()
    ajaxData.functName = "GET_DataTable_Filther_2"
    ajaxData.requestNow({
        PRE_NUM: txtN_Pre.value,
        ATE_NUM: txtN_Ate.value,
        PAC_RUT: txtP_Rut.value,
        PAC_DNI: txtP_Dni.value,
        PAC_NAME: txtP_Name.value,
        PAC_LAST: txtP_Last.value
    })
}