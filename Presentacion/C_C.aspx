<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="C_C.aspx.vb" Inherits="Presentacion.C_C" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
    <script src="C_C_I.js"></script>
    <script src="C_C.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">

    <div id="mError_AAH2" class="modal fade" role="dialog">
        <div class="modal-dialog ml-xl-auto">

            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                    <h4 id="title8" class="modal-title">Error</h4>
                </div>
                <div class="modal-body">
                    <p>AAAHAHHHHH</p>
                </div>
                <div class="modal-footer">
                    <button type="button" id="button_modal2" class="btn btn-success" data-dismiss="modal">Cerrar</button>

                </div>
            </div>
        </div>
    </div>





    <div class="card-body">
        <div class="card-header">
            <h5>
                <i class="fa fa-user"></i>
                Cambio contraseña
            </h5>
        </div>

        <div class="card-body">
            <div class="row">
                <div class="col-3"></div>
                <div class="col-6">
                    <!-- Text input-->
                    <div class="form-group">
                        <label class="col-md control-label" for="usuario_id">Usuario ID</label>
                        <div class="col-md">
                            <input id="usuario_id" name="usuario_id" type="text" placeholder="Usuario ID" class="form-control input-md" disabled="disabled">
                        </div>
                    </div>
                    <!-- Text input-->
                    <div class="form-group">
                        <label class="col-md control-label" for="nombre_usauio">Nombre de Usuario</label>
                        <div class="col-md">
                            <input id="nombre_usauio" name="nombre_usauio" type="text" placeholder="Nombre de Usuario" class="form-control input-md" disabled="disabled">
                        </div>
                    </div>
                    <!-- Password input-->
                    <div class="form-group">
                        <label class="col-md control-label" for="password1">Contraseña Actual</label>
                        <div class="col-md">
                            <input id="password1" name="password1" type="password" placeholder="Contraseña Actual" class="form-control input-md">
                            <label id="1_1" for="password1" style="color: red;">Campo requerido</label>
                            <label id="1_2" for="password1" style="color: red;">Contraseña incorrecta</label>
                        </div>
                    </div>
                    <!-- Password input-->
                    <div class="form-group">
                        <label class="col-md control-label" for="password2">Nueva Contraseña</label>
                        <div class="col-md">
                            <input id="password2" name="password2" type="password" placeholder="Contraseña" class="form-control input-md">
                            <label id="2_1" for="password2" style="color: red;">Campo requerido</label>
                            <label id="2_2" for="password2" style="color: red;">No Coinciden</label>
                        </div>
                    </div>

                    <!-- Password input-->
                    <div class="form-group">
                        <label class="col-md control-label" for="Password3">Confirme nueva contraseña</label>
                        <div class="col-md">
                            <input id="password3" name="password3" type="password" placeholder="Confirme nueva contraseña" class="form-control input-md">
                            <label id="3_1" for="password3" style="color: red;">Campo requerido</label>
                            <label id="3_2" for="password3" style="color: red;">Contraseñas nuevas no Coinciden</label>
                        </div>
                    </div>

                    <!-- Button (Double) -->
                    <div class="form-group">
                      
                        <div class="col-md">
                            <button id="button1id" name="button1id" class="btn btn-success btn-block">Guardar</button>

                        </div>
                    </div>



                </div>
                <div class="col-3"></div>



            </div>

        </div>


    </div>


</asp:Content>
