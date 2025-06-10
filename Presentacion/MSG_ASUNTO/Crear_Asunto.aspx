<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Crear_Asunto.aspx.vb" Inherits="Presentacion.Crear_Asunto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script>
        let msg_Text = "", msg_Doc = "", msg_Img = "", msg_Asunto= "", rdm;
        $(document).ready(function () {

            $('.custom-file-input').on('change', function () {
                var fileName = $(this).val().split('\\').slice(-1)[0];
                $(this).next('.custom-file-control').addClass("selected").html(fileName);
            })

            $("#Inp_Image").change(function () {
                if ($("#Inp_Image").val() != undefined) {
                    let file = document.getElementById('Inp_Image').files[0];
                    getBase64(file);
                }
            });
            $("#Inp_Doc").change(aah=> {
                if ($("#Inp_Doc").val() != undefined) {
                    let file = document.getElementById('Inp_Doc').files[0].name;
                    rdm = makeid();
                    msg_Doc = "/upload_msg/" + rdm + "_" + file;
                }
            });
            $("#Btn_Asunto").click(aah => {
                msg_Text = $("#txt_Msg").val();
                msg_Asunto = $("#txt_Asunto").val();
                //console.log(msg_Doc, msg_Img, msg_Text);
                if (msg_Doc != "" || msg_Img != "" || msg_Text != "") {
                    Ajax_Crear_Asunto();
                }
            });
        });

        function Ajax_Crear_Asunto() {
            //Debug
            //Parámetros
            
            var strParam = JSON.stringify({
                "ASUNTO": msg_Asunto,
                "TEXT": msg_Text,
                "DOC": msg_Doc,
                "IMG": msg_Img
            });
            console.log(strParam);
            $.ajax({
                "type": "POST",
                "url": "Crear_Asunto.aspx/Graba_Asunto",
                "data": strParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    if (data.d != null) {
                        //Show Modal
                        if (data.d == 3) {
                            Guardar_Archivo();
                        }
                    } else {
                        console.log("No paso na");
                    }
                },
                "error": data => {
                    console.log("Sendo error");
                }
            });
        }
        function Guardar_Archivo() {
            var form = new FormData();
            var inputFile = document.getElementById("Inp_Doc");
            form.append("file", inputFile.files[0], rdm + "_" + inputFile.files[0].name);

            $.ajax({
                data: form,
                processData: false,
                contentType: false,
                type: 'POST',
                datatype: 'json',
                url: '/Msg_Uploads.ashx',
                success: function (data) {
                    console.log("Archivo guardado en el server");
                },
                error: function (xhr, textStatus, errorThrown) {
                    onsole.log("Error al guardar en el server");
                },
                cache: false
            });
        }
        function makeid() {
            var text = "";
            var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            for (var i = 0; i < 5; i++)
                text += possible.charAt(Math.floor(Math.random() * possible.length));

            return text;
        }
        function getBase64(file) {
            var reader = new FileReader();
            reader.readAsDataURL(file);
            reader.onload = function () {
                msg_Img = reader.result;
            };
            reader.onerror = function (error) {
                console.log('Error: ', error);
            };
        }
    </script>
    <style>
        .custom-file-control:before {
            content: "Buscar";
            border-color: #868e96;
        }

        .custom-file-control:after {
            content: "Seleccione Archivo...";
            border-color: #868e96;
        }

        .custom-file-control.selected::after {
            content: "" !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="container">
        <div class="card border-bar">
            <div class="card-header bg-bar">
                <h4 class="m-0">Crear nuevo mensaje</h4>
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col">
                        <label for="txt_Asunto">Asunto:</label>
                        <input type="text" id="txt_Asunto" class="form-control" />
                    </div>
                </div>
                <div class="row mt-3">
                    <div class="col">
                        <label for="txt_Msg">
                            Mensaje:
                        </label>
                        <textarea class="form-control" id="txt_Msg"></textarea>
                    </div>
                </div>
                <div class="row mt-3 text-center">
                    <div class="col">
                        <label for="Inp_Image">Imagen:</label>
                        <label class="custom-file">
                            <input type="file" id="Inp_Image" class="custom-file-input">
                            <span class="custom-file-control form-control-sm text-left" style="border-color: #868e96;"></span>
                        </label>
                    </div>
                    <div class="col">
                        <div class="form-group mb-0">
                            <label for="Inp_Doc">Documento:</label>
                            <label class="custom-file">
                                <input type="file" id="Inp_Doc" class="custom-file-input">
                                <span class="custom-file-control form-control-sm text-left" style="border-color: #868e96;"></span>
                            </label>
                        </div>
                    </div>
                </div>
                <div class="row mt-3">
                    <div class="col"></div>
                    <div class="col">
                        <button type="button" id="Btn_Asunto" class="btn btn-block btn-info">Crear</button>
                    </div>
                    <div class="col"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
