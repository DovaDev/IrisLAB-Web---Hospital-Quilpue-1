<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Edita_Notificaciones.aspx.vb" Inherits="Presentacion.Edita_Notificaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script>
        $(document).ready(function () {

            Llenar_Notif_Edita();

            var dateNow = moment().format("DD-MM-YYYY hh:mm");
            $("#chekito").prop("checked", false);
            $("#txt_Mensaje").val("");
            $("#Slt_Tipo2").val(1);
            $("#Slt_Tipo").val(0);
            $("#Txt_Date01 input").val(dateNow);
            $('#Txt_Date01').datetimepicker({
                debug: true,
                icons: {
                    previous: 'fa fa-arrow-left',
                    next: 'fa fa-arrow-right'
                },
                format: 'dd-mm-yyyy hh:ii',
                language: 'es',
                weekStart: 1,
                autoclose: true,
                minDate: Date.now(),
                enabledHours: true
            });
            $("#Txt_Date02 input").val(dateNow);
            $('#Txt_Date02').datetimepicker({
                debug: true,
                icons: {
                    previous: 'fa fa-arrow-left',
                    next: 'fa fa-arrow-right'
                },
                format: 'dd-mm-yyyy hh:ii',
                language: 'es',
                weekStart: 1,
                autoclose: true,
                minDate: Date.now(),
                enabledHours: true
            });
            $("#Txt_Date03 input").val("");
            $('#Txt_Date03').datetimepicker({
                debug: true,
                icons: {
                    previous: 'fa fa-arrow-left',
                    next: 'fa fa-arrow-right'
                },
                format: 'dd-mm-yyyy hh:ii',
                language: 'es',
                weekStart: 1,
                autoclose: true,
                minDate: Date.now(),
                enabledHours: true
            });
            $("#Txt_Date04 input").val("");
            $('#Txt_Date04').datetimepicker({
                debug: true,
                icons: {
                    previous: 'fa fa-arrow-left',
                    next: 'fa fa-arrow-right'
                },
                format: 'dd-mm-yyyy hh:ii',
                language: 'es',
                weekStart: 1,
                autoclose: true,
                minDate: Date.now(),
                enabledHours: true
            });
            $("#btn_Buscar").click(aah => {
                Llenar_Notif_Edita();
            });
        });
        let id_Click;
        let Mx_Notif = [{
            "ID_NOTIF": "",
            "TIPO": "",
            "MENSAJE": "",
            "FECHA_D": "",
            "FECHA_H": "",
            "PERMA": "",
            "ESTADO": ""
        }];
        function Llenar_Notif_Edita() {
            console.log("Notif_Edita");

            var Data_Par = JSON.stringify({
                "TIPO": $("#Slt_Tipo").val()
            });

            //Debug
            $.ajax({
                "type": "POST",
                "url": "Edita_Notificaciones.aspx/Busca_Notif_Edita",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    if (data.d != null) {
                        Mx_Notif = data.d;
                        Fill_Dtt();
                    }
                    
                },
                "error": data => {
                    console.log("ERRORR");
                    //Debug
                }
            });

            $("#Btn_Guardar").click(xxh => {
                if (id_Click != "") {
                    Update_Notif_Edita();
                }
            })
        }
        function Fill_Dtt() {

            $("msg_Datatable").dataTable().fnDestroy();
            console.log("Fill Datatable");
            $("#msg_Datatable tbody").empty();
            var i = 1
            Mx_Notif.forEach(aah => {
                let indexx = i - 1;
                $("<tr>").attr("data-index", i - 1).append(
                    $("<td>").css({ "text-align": "left", "font-weight": "bold" }).text(i),
                   $("<td>").css("text-align", "left").text(eeh => {
                       switch (aah.TIPO) { // Tipo de mensaje
                           case 1:
                               return "Cache";
                               break;
                           case 2:
                               return "Sistema";
                               break;
                           case 3:
                               return "Mantención";
                               break;
                           case 4:
                               return "Otros";
                               break;
                       }
                   }),
                   $("<td>").css("text-align", "left").text(aah.MENSAJE),
                   $("<td>").css("text-align", "center").text(ooh=> {
                       return moment(aah.FECHA_D).format("DD-MM-YYYY hh:mm");
                   }),
                   $("<td>").css("text-align", "center").text(ooh=> {
                       return moment(aah.FECHA_H).format("DD-MM-YYYY hh:mm");
                   }),
                   $("<td>").css("text-align", "center").text(uuh=> {
                       if (aah.PERMA == 0) {
                           return "No";
                       }
                       else if (aah.PERMA == 1) {
                           return "Si";
                       }
                   })
                ).appendTo("#msg_Datatable tbody");
                i += 1;

            });
            // CLICK TR
            $("#msg_Datatable tr").click((eeh) => {
                let Index = $((eeh).currentTarget).attr("data-index");
                let F_D = moment(Mx_Notif[Index].FECHA_D).format("DD-MM-YYYY hh:mm");
                let F_H = moment(Mx_Notif[Index].FECHA_H).format("DD-MM-YYYY hh:mm");

                id_Click = Mx_Notif[Index].ID_NOTIF;

                $("#Slt_Tipo2").val(Mx_Notif[Index].TIPO);
                $("#Txt_Date03 input").val(F_D);
                $("#Txt_Date04 input").val(F_H);
                if (Mx_Notif[Index].PERMA == 0) {
                    $("#chekito").prop("checked", false);
                }
                else if (Mx_Notif[Index].PERMA == 1) {
                    $("#chekito").prop("checked", true);
                }
                $("#txt_Mensaje").val(Mx_Notif[Index].MENSAJE);
            });
        }

        function Update_Notif_Edita() {
            let permm;
            let estt;
            let chkd = $("#chekito").prop("checked");
            let chkd2 = $("#chekito2").prop("checked");
            if (chkd == true) {
                perm = 1;
            } else {
                perm = 0;
            }
            if (chkd2 == true) {
                estt = 2;
            } else {
                estt = 1;
            }

            var Data_Par = JSON.stringify({
                "ID_NOTIF": id_Click,
                "TIPO": $("#Slt_Tipo2").val(),
                "FECHA_D": $("#fecha3").val(),
                "FECHA_H": $("#fecha4").val(),
                "PERMA": perm,
                "MENSAJE": $("#txt_Mensaje").val(),
                "ESTADO": estt
            });
            console.log(Data_Par);

            $.ajax({
                "type": "POST",
                "url": "Edita_Notificaciones.aspx/Update_Notif_Edita",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    if (data.d > 0 && data.d != null) {
                        Llenar_Notif_Edita();
                        $("#mdlNotif_usu_Master h5").text("Actualización Correcta");
                        $("#mdlNotif_usu_Master p").text("La notificación se actualizo correctamente.");
                        $("#mdlNotif_usu_Master").modal();

                    } else {
                        $("#mdlNotif_usu_Master h5").text("Problemas en la actualización");
                        $("#mdlNotif_usu_Master p").text("La notificación se pudo actualizar en el sistema.");
                        $("#mdlNotif_usu_Master").modal();
                    }
                },
                "error": data => {
                    $("#mdlNotif_usu_Master h5").text("Problemas en la actualización");
                    $("#mdlNotif_usu_Master p").text("Error al actualizar la notificación.");
                    $("#mdlNotif_usu_Master").modal();
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="container">
        <div class="card border-bar">
            <div class="card-header bg-bar text-center">
                <h4 class="m-0">Editar Notificaciones
                </h4>
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-lg">
                        <h5><i class="fa fa-search fa-fw"></i>Busqueda</h5>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg">
                        <label>Tipo:</label>
                        <select id="Slt_Tipo" class="form-control">
                            <option value="0">Todos</option>
                            <option value="1">Cache</option>
                            <option value="2">Sistema</option>
                            <option value="3">Mantención</option>
                            <option value="4">Otros</option>
                        </select>
                    </div>
                    <%--<div class="col-lg">
                        <label for="txt_Durac">Buscar Desde:</label>
                        <div class='input-group date' id='Txt_Date01'>
                            <input type='text' id="fecha" class="form-control" readonly="true" placeholder="" />
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>
                        </div>
                    </div>
                    <div class="col-lg">
                        <label for="txt_Durac">Buscar Hasta:</label>
                        <div class='input-group date' id='Txt_Date02'>
                            <input type='text' id="fecha2" class="form-control" readonly="true" placeholder="" />
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>
                        </div>
                    </div>--%>
                    <div class="col-lg text-center">
                        <button type="button" class="btn btn-buscar btn-block" id="btn_Buscar" style="margin-top: 2rem"><i class="fa fa-search fa-fw"></i>Buscar</button>
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-lg">
                        <h5><i class="fa fa-edit fa-fw"></i>Editar</h5>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg">
                        <label>Tipo:</label>
                        <select id="Slt_Tipo2" class="form-control">
                            <option value="1">Cache</option>
                            <option value="2">Sistema</option>
                            <option value="3">Mantención</option>
                            <option value="4">Otros</option>
                        </select>
                    </div>
                    <div class="col-lg">
                        <label for="txt_Durac">Fecha Desde:</label>
                        <div class='input-group date' id='Txt_Date03'>
                            <input type='text' id="fecha3" class="form-control" readonly="true" placeholder="" />
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>
                        </div>
                    </div>
                    <div class="col-lg">
                        <label for="txt_Durac">Fecha Hasta:</label>
                        <div class='input-group date' id='Txt_Date04'>
                            <input type='text' id="fecha4" class="form-control" readonly="true" placeholder="" />
                            <span class="input-group-addon">
                                <i class="fa fa-calendar"></i>
                            </span>
                        </div>
                    </div>
                    <div class="col-lg">
                        <label>Permanente:</label><br />
                        <label class="form-check-label" style="cursor: pointer">
                            <input class="form-check-input" type="checkbox" id="chekito" style="cursor: pointer">
                            Permanente
                        </label>
                    </div>
                    <div class="col-lg">
                        <label>Estado:</label><br />
                        <label class="form-check-label" style="cursor: pointer">
                            <input class="form-check-input" type="checkbox" id="chekito2" style="cursor: pointer">
                            Deshabilitar
                        </label>
                    </div>
                </div>
                <div class="row mt-3">
                    <div class="col-lg">
                        <textarea class="form-control" id="txt_Mensaje"></textarea>
                    </div>
                </div>
                <div class="row mt-3">
                    <div class="col-lg text-center">
                        <button type="button" id="Btn_Guardar" class="btn btn-primary"><i class="fa fa-save fa-fw"></i>Guardar</button>
                    </div>
                </div>
                <hr />
                <div class="row">
                    <div class="col-lg">
                        <h5><i class="fa fa-list fa-fw"></i>Lista de Notificaciones</h5>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg">
                        <table class="table table-hover table-striped table-iris" id="msg_Datatable">
                            <thead>
                                <tr>
                                    <th>#</th>
                                    <th>Tipo</th>
                                    <th>Mensaje</th>
                                    <th class="text-center">Fecha D.</th>
                                    <th class="text-center">Fecha H.</th>
                                    <th class="text-center">Permanente</th>
                                </tr>
                            </thead>
                            <tbody></tbody>
                        </table>
                    </div>
                </div>

            </div>
        </div>


    </div>
</asp:Content>
