<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Update_File_Test.aspx.vb" Inherits="Presentacion.Update_File_Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script>
        $(document).ready(function () {
            $("#Btn_Guardar").click(function () {

                var form = new FormData();
                var inputFile = document.getElementById("Inp_Upload");
                form.append("file", inputFile.files[0]);

                $.ajax({
                    data: form,
                    processData: false,
                    contentType: false,
                    type: 'POST',
                    datatype: 'json',
                    url: '/Uploads.ashx',
                    success: function (data) {
                        alert("Success");
                    },
                    error: function (xhr, textStatus, errorThrown) {
                        alert("Problema.  " + xhr.status + ': ' + errorThrown);
                    },
                    cache: false
                });

            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg">
                <input type="file" id="Inp_Upload" />
            </div>
            <div class="col-lg">
                <button type="button" class="btn btn-buscar" id="Btn_Guardar">
                    Guardar
                </button>
            </div>
        </div>
    </div>
</asp:Content>
