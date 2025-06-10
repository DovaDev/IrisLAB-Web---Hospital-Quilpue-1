/// <reference path="C:\Users\None\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Viña\Presentacion\js/jQuery.js" />
/// <reference path="C:\Users\None\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Viña\Presentacion\js/bootstrap.js" />
/// <reference path="C:\Users\None\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Viña\Presentacion\js/datepicker/js/bootstrap-datepicker.js" />
/// <reference path="C:\Users\None\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Viña\Presentacion\vendor/datatables/jquery.dataTables.js" />
/// <reference path="C:\Users\None\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Viña\Presentacion\vendor/datatables/dataTables.bootstrap4.js" />
/// <reference path="C:\Users\None\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Viña\Presentacion\js/moment.js" />

let Class_AJAX = function () {
    this.instance = null;
    this.url = "";
    this.success = () => { };
    this.error = (fail) => {
        Hide_Modal();
        $("#mdlError").modal("show");

        try {
            $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType);
            $("#mdlTxt_Descr").text(fail.responseJSON.Message);
            $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace);
        } catch (err) {
            $("#mdlTxt_Type").text("Error Genérico");
            $("#mdlTxt_Descr").text("Error en el Front End");
            $("#mdlTxt_StackT").text("Mire la consola para Detalles.");
            console.log(fail);
        }
    };
};
Class_AJAX.prototype.callback = function (data) {
    let objParam = {
        "type": "POST",
        "url": this.url,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "success": this.success,
        "error": this.error
    };

    if (data != null) {
        objParam["data"] = JSON.stringify(data);
    }

    this.instance = $.ajax(objParam);
};

//----------------------------------------------------------------

$(document).ready(() => {
    let arrInput = [
        `#Txt_Date01`,
        `#Txt_Date02`
    ];

    arrInput.forEach((xItem) => {
        $(xItem).val(moment().format(`DD/MM/YYYY`));

        $(xItem).parent().datepicker({
            format: "dd/mm/yyyy",
            language: "es",
            autoclose: true
        });
    });

    modal_show();
    objAJAX_PROC.callback();
});

$(document).ready(() => {
    $("#Btn_Search").click(() => {
        modal_show();
        objAJAX_DATA.callback({
            DATE_01: $("#Txt_Date01").val(),
            DATE_02: $("#Txt_Date02").val(),
            ID_PROC: $("#Sel_Proc").val()
        });
    });
});

//----------------------------------------------------------------
let arrSel_PROC = [
    {
        ID_PROCEDENCIA: 0,
        PROC_DESC: ""
    }
];

let objAJAX_PROC = new Class_AJAX();
objAJAX_PROC.url = "Impr_Dcto.aspx/Get_Sel_Proc";
objAJAX_PROC.success = (resp) => {
    arrSel_PROC = resp.d;

    $("#Sel_Proc").empty();
    //$("#Sel_Proc").append(
    //    $(`<option>`, {
    //        value: 0
    //    }).text("TODOS")
    //);
    arrSel_PROC.forEach((xItem) => {
        $("#Sel_Proc").append(
            $(`<option>`, {
                value: xItem.ID_PROCEDENCIA
            }).text(xItem.PROC_DESC)
        );
    });
    Hide_Modal();
};

let arrData = [
  {
      ID_PREINGRESO: 0,
      PREI_NUM: "",
      PREI_FECHA: new Date,
      ID_ATENCION: 0,
      ATE_NUM: "",
      ATE_FECHA: new Date,
      PAC_COD: "",
      PAC_NOMBRE: "",
      ID_PROCEDENCIA: 0,
      PROC_DESC: "",
      ID_PREVE: 0,
      PREVE_DESC: "",
      EST_DESCRIPCION: "",
      COUNT_PEND: 0
  }
];

let objAJAX_DATA = new Class_AJAX();
objAJAX_DATA.url = "Impr_Dcto.aspx/Get_Data";
objAJAX_DATA.success = (resp) => {
    arrData = resp.d;

    let objBody = $(`#divTable .card-body`);
    objBody.empty();

    if (arrData.length == 0) {
        Hide_Modal();
        objBody.removeClass("table-responsive");
        objBody.append(
            $(`<div>`, { class: "alert alert-danger m-3" }).html(`No se han encontrado resultados con los parámetros de búsqueda indicados.`)
        );
        return;
    }

    objBody.addClass("table-responsive");
    let objTable = $(`<table>`, { class: "table table-stripped" });
    objTable.append(
        $("<thead>").append(
            $(`<tr>`).append(
                $(`<th>`, { class: `text-center` }).text("Nro Preingreso"),
                $(`<th>`, { class: `text-center` }).text("Fecha Agendam"),
                $(`<th>`, { class: `text-center` }).text("Nro Atención"),
                $(`<th>`, { class: `text-center` }).text("Fecha Atención"),
                $(`<th>`, { class: `text-center` }).text("RUT/DNI"),
                $(`<th>`, { class: `text-center` }).text("Nombre Paciente"),
                $(`<th>`, { class: `text-center` }).text("Procedencia"),
                $(`<th>`, { class: `text-center` }).text("Impr Voucher Agendam"),
                $(`<th>`, { class: `text-center` }).text("Impr Voucher Atención"),
                $(`<th>`, { class: `text-center` }).text("Impr Voucher Pendientes"),
                $(`<th>`, { class: `text-center` }).text("Impr Etiquetas")
            )
        ),
        $("<tbody>")
    );

    arrData.forEach((xItem) => {
        objTable.children("tbody").append(
            $(`<tr>`).append(
                $(`<td>`, { class: `text-center` }).text(function () {
                    if (xItem.PREI_NUM != null) {
                        return xItem.PREI_NUM;
                    } else {
                        return ' - ';
                    }
                }()),
                $(`<td>`, { class: `text-center` }).text(function () {
                    if (xItem.PREI_NUM != null) {
                        return moment(xItem.PREI_FECHA).format("DD/MM/YYYY");
                    } else {
                        return ' - ';
                    }
                }()),
                $(`<td>`, { class: `text-center` }).text(function () {
                    if (xItem.ATE_NUM != null) {
                        return xItem.ATE_NUM;
                    } else {
                        return ' - ';
                    }
                }()),
                $(`<td>`, { class: `text-center` }).text(function () {
                    if (xItem.ATE_NUM != null) {
                        return moment(xItem.ATE_FECHA).format("DD/MM/YYYY");
                    } else {
                        return ' - ';
                    }
                }()),
                $(`<td>`, { class: `text-center` }).text(xItem.PAC_COD),
                $(`<td>`, { class: `text-left` }).text(xItem.PAC_NOMBRE),
                $(`<td>`, { class: `text-left` }).text(function () {
                    if (xItem.PROC_DESC != null) {
                        return xItem.PROC_DESC;
                    } else {
                        return ' - ';
                    }
                }()),
                $(`<td>`, { class: `text-center` }).append(
                    $(`<button>`, {
                        class: "btn btn-success btn_print01",
                        disabled: (function () {
                            if (xItem.PREI_NUM != null) {
                                return false;
                            } else {
                                return true;
                            }
                        }()),
                        "data-id": xItem.ID_PREINGRESO
                    }).html(`<i class="fa fa-print" aria-hidden="true"></i>`)
                ),
                $(`<td>`, { class: `text-center` }).append(
                    $(`<button>`, {
                        class: "btn btn-success btn_print02",
                        disabled: (function () {
                            if (xItem.ATE_NUM != null) {
                                return false;
                            } else {
                                return true;
                            }
                        }()),
                        "data-id": xItem.ID_ATENCION
                    }).html(`<i class="fa fa-print" aria-hidden="true"></i>`)
                ),
                $(`<td>`, { class: `text-center` }).append(
                    $(`<button>`, {
                        class: "btn btn-success btn_print03",
                        disabled: (function () {
                            if ((xItem.ATE_NUM != null) && (xItem.COUNT_PEND > 0)) {
                                return false;
                            } else {
                                return true;
                            }
                        }()),
                        "data-id": xItem.ID_ATENCION
                    }).html(`<i class="fa fa-print" aria-hidden="true"></i>`)
                ),
                $(`<td>`, { class: `text-center` }).append(
                    $(`<button>`, {
                        class: "btn btn-success btn_print04",
                        disabled: (function () {
                            if (xItem.ATE_NUM != null) {
                                return false;
                            } else {
                                return true;
                            }
                        }()),
                        "data-id": xItem.ID_ATENCION
                    }).html(`<i class="fa fa-print" aria-hidden="true"></i>`)
                )
            )
        );

    });

    objBody.append(objTable);
    $(`.btn_print01`).click(function (Me) {
        Me.stopImmediatePropagation();
        let numId = parseInt($(this).attr("data-id"));

        objAJAX_PRINT.url = "http://localhost:9990/Printer/Imp_Voucher_Agendam",

        objAJAX_PRINT.callback([
            numId
        ]);
    });

    $(`.btn_print02`).click(function (Me) {
        Me.stopImmediatePropagation();
        let numId = parseInt($(this).attr("data-id"));

        objAJAX_PRINT.url = "http://localhost:9990/Printer/Imp_Voucher_Compr_Ate";

        objAJAX_PRINT.callback([
            numId
        ]);
    });

    $(`.btn_print03`).click(function (Me) {
        Me.stopImmediatePropagation();
        let numId = parseInt($(this).attr("data-id"));

        objAJAX_PRINT.url = "http://localhost:9990/Printer/Imp_Voucher_Lugar_TM";

        objAJAX_PRINT.callback([
            numId
        ]);
    });

    $(`.btn_print04`).click(function (Me) {
        Me.stopImmediatePropagation();
        let numId = parseInt($(this).attr("data-id"));

        objAJAX_PRINT.url = "http://localhost:9990/Printer/Imp_Etiquetas";

        objAJAX_PRINT.callback([
            numId
        ]);
    });

    objBody.children("table").DataTable({
        "bSort": true,
        "iDisplayLength": 100,
        "language": {
            "lengthMenu": "Mostrar: _MENU_",
            "zeroRecords": "No hay concidencias",
            "info": "Mostrando Página _PAGE_ de _PAGES_",
            "infoEmpty": "No hay concidencias",
            "infoFiltered": "(Se buscó en _MAX_ registros )",
            "search": "<strong><i class='fa fa-search'></i>Filtro: </strong>",
            "paginate": {
                "previous": "Anterior",
                "next": "Siguiente"
            }
        }
    });

    Hide_Modal();
};

//---------------------------------------------------------------

let objAJAX_PRINT = new Class_AJAX();
objAJAX_PRINT.success = (resp) => {

    Swal.fire({
        icon: "success",
        title: resp.Status,
        text: resp.Message,
    });

};