<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Cobro_RUT.aspx.vb" Inherits="Presentacion.Cobro_RUT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script src="/js/Custom_Objects.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <script>
        $(document).ready(() => {
            var dateNow = moment().format("DD-MM-YYYY");
            $("#Txt_Date01 input, #Txt_Date02 input").val(dateNow);
            $('#Txt_Date01, #Txt_Date02').datetimepicker(
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
                    minView: 2
                }
            );

            $("#txt_RUT").focusout(() => {
                let v_RUT = $("#txt_RUT").val();
                if (v_RUT != "") {
                    rut_dni_format(v_RUT);
                }
            });

            $("#txt_RUT").keypress(e => {
                if (e.keyCode == 13) {
                    let v_RUT = $("#txt_RUT").val();
                    if (v_RUT != "") {
                        rut_dni_format(v_RUT);
                    }
                }
            });

            $("#Btn_Buscar").click(() => {
                let v_RUT = $("#txt_RUT").val();
                let v_Desde = $("#fecha").val();
                let v_Hasta = $("#fecha2").val();

                if (v_RUT != "") {
                    Ajax_Buscar(v_Desde, v_Hasta, v_RUT);
                }
            });

            $("#Btn_Excel").click(() => {
                let v_RUT = $("#txt_RUT").val();
                let v_Desde = $("#fecha").val();
                let v_Hasta = $("#fecha2").val();

                if (v_RUT != "") {
                    Ajax_Excel(v_Desde, v_Hasta, v_RUT);
                }
            });
        });

        function rut_dni_format(v_RUT) {

            let valid_RUT = Valid_RUT(v_RUT);

            if (valid_RUT.Valid == true) {
                v_RUT = valid_RUT.Format;
            }

            $("#txt_RUT").val(v_RUT);
        }

        let Mx_Ate_Exa = [{
            FOLIO: "",
            FECHA: "",
            RUT: "",
            DNI: "",
            NOMBRE: "",
            APELLIDO: "",
            PROCEDENCIA: "",
            PREVISION: "",
            EXAMENES: [{
                CF_COD: "",
                CF_DESC: "",
                VALOR: ""
            }],
        }];

        function Ajax_Buscar(DESDE, HASTA, RUT_DNI) {
            modal_show();
            let Data_Par = JSON.stringify({
                "DESDE": DESDE,
                "HASTA": HASTA,
                "RUT_DNI": RUT_DNI
            });

            $.ajax({
                "type": "POST",
                "url": "Cobro_RUT.aspx/Busca_Data_RUT",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    let json_receiver = response.d;
                    if (json_receiver != null) {
                        Mx_Ate_Exa = json_receiver;
                        console.log(Mx_Ate_Exa);

                        fn_Fill_Table(Mx_Ate_Exa);

                        Hide_Modal();
                    } else {
                        console.log(response);
                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    console.log(response);
                    Hide_Modal();
                }
            });
        }

        function fn_Fill_Table(AE) {
            $("#div_Dtt").empty();

            $("<table>").attr({ id: "DataTable", cellspacing: "0", class: "table table-hover table-striped table-iris dataTable no-footer" }).appendTo($("#div_Dtt"));

            $("#DataTable").append(
                $("<thead>").append(
                    $("<tr>").append(
                        $("<th>").text("#"),
                        $("<th>").text("Folio"),
                        $("<th>").text("Fecha"),
                        //$("<th>").text("RUT/DNI"),
                        //$("<th>").text("Nombre Paciente"),
                        $("<th>").text("Procedencia"),
                        $("<th>").text("Previsión"),
                        $("<th>").text("Código"),
                        $("<th>").text("Descripción"),
                        $("<th>").text("Valor").attr("class", "text-right")
                    )
                )
            );

            $("#DataTable").append(
                $("<tbody>")
            );

            let i = 1
            let tot = 0;

            AE.forEach(aah => {
                aah.EXAMENES.forEach(eeh => {

                    tot += eeh.VALOR;

                    $("<tr>").append(
                        $("<td>").text(i),
                        $("<td>").text(aah.FOLIO),
                        $("<td>").text(moment(aah.FECHA).format("DD-MM-YYYY")),
                        //$("<td>").text(aah.RUT + aah.DNI),
                        //$("<td>").text(aah.NOMBRE + " " + aah.APELLIDO),
                        $("<td>").text(aah.PROCEDENCIA),
                        $("<td>").text(aah.PREVISION),
                        $("<td>").text(eeh.CF_COD),
                        $("<td>").text(eeh.CF_DESC),
                        $("<td>").attr("class", "text-right").text("$" + cFormat.numToString(eeh.VALOR, 0, ".", ","))
                    ).appendTo($("#DataTable tbody"));
                    i++;
                });
            });

            $("#DataTable").DataTable({
                "bSort": true,
                "iDisplayLength": 100,
                "info": false,
                "bPaginate": false,
                //"bFilter": false,
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

            $("#pac_RUT").text(AE[0].RUT + AE[0].DNI);
            $("#pac_Nom").text(AE[0].NOMBRE +" "+ AE[0].APELLIDO);
            $("#pac_Ate").text(AE.length);
            $("#pac_Exa").text(i);
            $("#pac_Tot").text("$" + cFormat.numToString(tot, 0, ".", ","));

        }

        function Ajax_Excel(DESDE, HASTA, RUT_DNI) {
            modal_show();

            var Data_Par = JSON.stringify({
                "MAIN_URL": location.origin,
                "DESDE": DESDE,
                "HASTA": HASTA,
                "RUT_DNI": RUT_DNI
            });
            $.ajax({
                "type": "POST",
                "url": "Cobro_RUT.aspx/Gen_Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        window.open(json_receiver, 'Download');
                        Hide_Modal();
                    } else {
                        console.log(response);
                        Hide_Modal();
                    }
                },
                "error": function (response) {
                    console.log(response);
                    Hide_Modal();
                }
            });
        }

    </script>
    <div class="container">
        <div class="card border-bar">
            <div class="card-header bg-bar p-2">
                <h4 class="text-center m-0">Valorización por RUT</h4>
            </div>
            <div class="card-body pt-2 pb-2">
                <div class="row">
                    <div class="col-lg-2">
                        <label for="fecha">Desde:</label>
                        <div class='input-group date' id='Txt_Date01'>
                            <input type='text' id="fecha" class="form-control" readonly="true" placeholder="Desde..." />
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>
                        </div>
                    </div>
                    <div class="col-lg-2">
                        <label for="fecha2">Hasta:</label>
                        <div class='input-group date' id='Txt_Date02'>
                            <input type='text' id="fecha2" class="form-control" readonly="true" placeholder="Hasta..." />
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>
                        </div>
                    </div>
                    <div class="col-lg">
                        <label for="txt_RUT">RUT/DNI:</label>
                        <input type="text" id="txt_RUT" class="form-control" />
                    </div>
                    <div class="col-lg-2">
                        <br />
                        <button type="button" id="Btn_Buscar" class="btn btn-buscar btn-block mt-2"><i class="fa fa-fw fa-search mr-2"></i>Buscar</button>
                    </div>
                    <div class="col-lg-2">
                        <br />
                        <button type="button" id="Btn_Excel" class="btn btn-success btn-block mt-2"><i class="fa fa-fw fa-file-excel-o mr-2"></i>Excel</button>
                    </div>
                </div>

                <div class="row mt-3">
                    <div class="col-lg-3">
                        RUT/DNI:
                        <span id="pac_RUT" class="text-danger font-weight-bold"></span>
                    </div>
                    <div class="col-lg-4">
                        Nombre:
                        <span id="pac_Nom" class="text-danger font-weight-bold"></span>
                    </div>
                    <div class="col-lg">
                        Tot. Ate:
                        <span id="pac_Ate" class="text-danger font-weight-bold"></span>
                    </div>
                    <div class="col-lg">
                        Tot. Exa:
                        <span id="pac_Exa" class="text-danger font-weight-bold"></span>
                    </div>
                    <div class="col-lg-2">
                        Tot. Valor:
                        <span id="pac_Tot" class="text-danger font-weight-bold"></span>
                    </div>
                </div>
            </div>
        </div>
        <div id="div_Dtt" class="mt-3">
        </div>
    </div>
</asp:Content>
