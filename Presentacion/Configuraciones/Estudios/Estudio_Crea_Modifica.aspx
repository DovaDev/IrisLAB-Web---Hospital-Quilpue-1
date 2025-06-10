<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Master.Master" CodeBehind="Estudio_Crea_Modifica.aspx.vb" Inherits="Presentacion.Estudio_Crea_Modifica" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Cph_Head" runat="server">
        <script>
        let IDD = 0
        let IDDPrueba = -1
        let IDDFormato = -1
        let IDD_RF = 0
        let INDICE_REF = 0
        let cant_det = 0
        let codigo_per = ""
        let accion = 0

        let dataSession = localStorage.getItem("perfil");

        function toAjaxModalInterRefer(idPrueba) {
            console.log('id prueba antes de cambiar', idPrueba)
            IDDPrueba = idPrueba;
            Ajax_Tabla_Refer();
            $("#rangesModal").show();
        }


        //function toAjaxModalInterRefer(idPrueba) {
        //    Ajax_Tabla_Refer(idPrueba);
        //}
        $(document).ready(function () {


            $("#modalRefer").hide(); /*<---- OCULTA EL MODAL DE REFER ASOCIADAS A UN ESTUDIO*/
            $("#modalDete").hide(); /*<---- OCULTA EL MODAL DE DETERMINACIONES ASOCIADAS A UN ESTUDIO*/
            $(".block_wait").fadeOut(0);
            Ajax_Ddl_Mantenedor();
            Ajax_Ddl_Mantenedor_Unidad()
            Ajax_Ddl_Mantenedor_Seccion();
            Ajax_Tabla();
            Ajax_Ddl_Mantenedor_sexo()


            ///////////////////////////////////////////////// MODAL METODOS ////////////////////////////////////////////////////

            //BTM MODAL MÉTODOS 
            $("#btn_modal_metodos").click(function () {
                $('#eModal_metodos').modal('hide');
                $('#eModal_metodos').modal('show');
                Ajax_Tabla_metodo()
                Ajax_metodo_Relacionadas()

            });

            //BTN SALIR MODAL METODO
            $("#btnSalirModal_metodos").click(function () {
                $('#eModal_metodos').modal('hide')
            });

            //BTN AGREGAR MODAL METODO
            $("#btn_Agregar").click(function () {

                let lista_metodo = Mx_Dtt_tabla_modal_metodo.filter(item => item.CHECK == 1).map(item => item.ID_METODO)
                console.log(lista_metodo)

                Ajax_Agregar();

            });
            //BTN QUITAR MODAL METODO
            $("#btn_Quitar").click(function () {
                let lista_metodo2 = Mx_Dtt_metodo_rel.filter(item => item.CHECK == 1).map(item => item.ID_REL_PER_DER)
                console.log(lista_metodo2)

                Ajax_Quitar();
            });
            //BTN VER MANTENEDOR metodo
            $("#btnVerMetodoAnalitico").click(function () {

                window.open('/Configuraciones/Mantenedores/Metod_Anali.aspx', '_blank');
                //window.location.href = "/Configuraciones/Estudios/Estudio_Crea_Modifica.aspx";

            });

            ///////////////////////////////////////////////// MODAL DERIVADOR ////////////////////////////////////////////////////

            //BTM MODAL DERIVADOR
            $("#btn_modal_derivador").click(function () {
                $('#eModal_derivado').modal('hide');
                $('#eModal_derivado').modal('show');
                console.log("si funco");
                Ajax_Tabla_derivado()
                Ajax_metodo_Relacionadas_derivado()

            });

            //BTN SALIR MODAL DERIVADOR
            $("#btnSalirModal_deri").click(function () {
                $('#eModal_derivado').modal('hide')
            });

            //BTN AGREGAR MODAL DERIVADOR
            $("#btn_Agregar_derivado").click(function () {

                let lista_derivado = Mx_Dtt_tabla_modal_derivado.filter(item => item.CHECK == 1).map(item => item.ID_DERIVADO)
                console.log(lista_derivado)

                Ajax_Agregar_deri();

            });
            //BTN QUITAR MODAL DERIVADOR
            $("#btn_Quitar_derivado").click(function () {

                let lista_derivado2 = Mx_Dtt_derivado_rel.filter(item => item.CHECK == 1).map(item => item.ID_REL_PER_DER)
                console.log(lista_derivado2)

                Ajax_Quitar_deri();
            });
            //BTN VER MANTENEDOR DERIVADOR
            $("#btnVerDerivador").click(function () {

                window.open('/Configuraciones/Mantenedores/Derivado.aspx', '_blank');
                //window.location.href = "/Configuraciones/Estudios/Estudio_Crea_Modifica.aspx";

            });


            ///////////////////////////////////////////////// MODAL MUESTRA TIPO SANGRE////////////////////////////////////////////////////

            //BTM MODAL MUESTRA
            $("#btn_modal_muestra").click(function () {
                $('#eModal_muestra').modal('hide');
                $('#eModal_muestra').modal('show');
                console.log("si funco");
                Ajax_Tabla_muestra()
                Ajax_metodo_Relacionadas_muestra()

            });

            //BTN SALIR MODAL MUESTRA
            $("#btnSalirModal_muestra").click(function () {
                $('#eModal_muestra').modal('hide')
            });

            //BTN AGREGAR MODAL MUESTRA
            $("#btn_Agregar_muestra").click(function () {

                let lista_muestra = Mx_Dtt_tabla_modal_muestra.filter(item => item.CHECK == 1).map(item => item.ID_MUESTRA_SANGRE)
                console.log(lista_muestra)

                Ajax_Agregar_muestra();

            });
            //BTN QUITAR MODAL MUESTRA
            $("#btn_Quitar_muestra").click(function () {

                let lista_muestra2 = Mx_Dtt_muestra_rel.filter(item => item.CHECK == 1).map(item => item.ID_REL_PER_MSANGRE)
                console.log(lista_muestra2)

                Ajax_Quitar_muestra();
            });

            //BTN VER MANTENEDOR DERIVADOR
            $("#btnVerTPSANGRE").click(function () {

                window.open('/Configuraciones/Mantenedores/TipoMuestraSangre.aspx', '_blank');


            });

            ///////////////////////////////////////////////// MODAL ANALIZADOR ////////////////////////////////////////////////////

            //BTM MODAL ANALIZADOR
            $("#btn_modal_analizador").click(function () {
                $('#eModal_analizador').modal('hide');
                $('#eModal_analizador').modal('show');
                console.log("si funco");
                Ajax_Tabla_analizador()
                Ajax_metodo_Relacionadas_analizador()

            });

            //BTN SALIR MODAL ANALIZADOR
            $("#btnSalirModal_analizador").click(function () {
                $('#eModal_analizador').modal('hide')
            });

            //BTN AGREGAR MODAL ANALIZADOR
            $("#btn_Agregar_analizador").click(function () {

                let lista_analizador = Mx_Dtt_tabla_modal_analizador.filter(item => item.CHECK == 1).map(item => item.ID_ANAL)
                console.log(lista_analizador)

                Ajax_Agregar_analizador();

            });
            //BTN QUITAR MODAL ANALIZADOR
            $("#btn_Quitar_analizador").click(function () {

                let lista_analizador2 = Mx_Dtt_analizador_rel.filter(item => item.CHECK == 1).map(item => item.ID_REL_PER_ANAL)
                console.log(lista_analizador2)

                Ajax_Quitar_analizador();
            });
            //BTN VER MANTENEDOR ANALIZADOR
            $("#btnVerAnal").click(function () {

                window.open('/Configuraciones/Mantenedores/Analizador.aspx', '_blank');


            });

            ///////////////////////////////////////////////// MODAL DETERTERMINACIONES ////////////////////////////////////////////

            $("#Btn_Eliminar_modal").click(function () {

                if (IDDPrueba == 0) {

                    $("#mError_AAH h4").text("Seleccionar el dato en la tabla");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Seleccionar en la tabla el dato que desea Eliminar .");
                    $("#mError_AAH").modal();

                }
                else {
                    Alertas_Accion(2, 'esta Prueba', 'prueba');
                }

            });

            $("#Btn_Modificar_modal").click(function () {
                Alertas_Accion(1, 'esta Prueba', 'prueba');
            });

            //CERRAR EL MODAL
            $("#Btn_Cerrar_modal_determinaciones").click(function () {

                Ajax_Limpiar();
                $("#Div_Tabla_Pruebas").empty();
                despintarCasillasEstudio();
                $("#Btn_Guardar").attr("disabled", false);
                $("#Btn_Modificar").attr("disabled", true);
                $("#Btn_Eliminar").attr("disabled", true);
                bloquear_botones();
            });
            bloquear_botones();



            ///////////////////////////////////////////////// MODAL REFER ////////////////////////////////////////////////////



            //BTM MODAL REFER
            $("#Btn_inter_ref_modal").click(function () {
                $('#eModal_ref').modal('hide');
                $('#eModal_ref').modal('show');
                $('#btnGuardarRanRef').attr("disabled", true);
                Ajax_Tabla_Refer();
            });

            //BTN SALIR MODAL METODO
            $("#btnSalir").click(function () {
                $('#btnGuardarRanRef').attr("disabled", true)
                $('#eModal_ref').modal('hide')
                //Ajax_Limpiar();
            });


            //BTN GUARDAR REFER
            $('#btnGuardarRanRef').click(() => {

                let validador;
                validador = Validar_Input_Refer();

                if (validador === 0) {
                    return Swal.fire({
                        toast: false,
                        icon: 'warning',
                        text: 'Uno o mas campos vacios',
                        showCancelButton: false,
                        confirmButtonColor: '#3085d6',
                        cancelButtonColor: '#d33',
                        confirmButtonText: 'Ok',
                    });
                } else {
                    Ajax_Graba_Refer();
                    $('#btnGuardarRanRef').attr('disabled', true);
                }
            });

            //BTN MODIFICAR REFER
            $('#btnModificarRanRef').click(() => {
                Alertas_Accion(1, 'este Rango y Referencia', 'referencia');
                $('#btnEliminarRanRef').attr("disabled", true);
                $('#btnModificarRanRef').attr("disabled", true);
            });

            //BTN ELIMINAR REFER
            $('#btnEliminarRanRef').click(() => {
                Alertas_Accion(2, 'este Rango y Referencia', 'referencia');
                $('#btnEliminarRanRef').attr("disabled", true);
                $('#btnModificarRanRef').attr("disabled", true);
            });



            ///////////////////////////////////////////////// INTERFAZ PRINCIPAL ////////////////////////////////////////////////////

            //BTN LIMPIAR
            $("#Btn_limpiar").click(function () {
                $("#Btn_Eliminar_modal").attr("disabled", true);
                $("#Btn_Modificar_modal").attr("disabled", true);

                Ajax_Limpiar();
                $("#Div_Tabla_Pruebas").empty();
                accion = 1
                alerta_Proc_Correctos();
                despintarCasillasEstudio();
                $("#Btn_Guardar").attr("disabled", false);
                $("#Btn_Modificar").attr("disabled", true);
                $("#Btn_Eliminar").attr("disabled", true);
            });

            //BTN MODIFICAR
            $("#Btn_Modificar").click(function () {
                console.log('ESTE ES EL ID AL HACER CLICK EN MODIFICAR', IDD);
                console.log('esto es el txt_dete que debe ser mayor a MX_pruebas: ', $("#txt_Dete").val())
                if (IDD === 0) {
                    Swal.fire("Seleccionar un valor en la tabla");
                    $("#mError_AAH h4").text("Seleccionar el dato en la tabla");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Seleccionar en la tabla el dato que desea modificar .");
                    $("#mError_AAH").modal();

                }
                else {
                    if ($("#txt_Dete").val() >= Mx_Pruebas.length) {
                        console.log('entramos a actualizar')
                        if (validar() === 6) {
                            Alertas_Accion(1, 'este Estudio Clinico', 'estudio')
                        }
                    } else {

                        console.log('mx_pruebas: ', Mx_Pruebas.length)
                    }

                }
            });

            //BTN ELIMINAR PRUEBA
            $("#Btn_Eliminar").click(function () {
                if (IDD == 0) {

                    $("#mError_AAH h4").text("Seleccionar el dato en la tabla");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Seleccionar en la tabla el dato que desea Eliminar .");
                    $("#mError_AAH").modal();

                }
                else {
                    Alertas_Accion(2, 'este Estudio', 'estudio') //ALERTA ELIMINAR ESTUDIO CLINICO
                    $("#Btn_Modificar").attr("disabled", true);
                    $("#Btn_Eliminar").attr("disabled", true);

                }
            });

            //BTN GUARDAR
            $("#Btn_Guardar").click(function () {

                if (validar() === 6) {

                    Ajax_Guardar();
                    accion = 2
                    alerta_Proc_Correctos();
                    despintarCasillasEstudio();
                    $("#Btn_Guardar").attr("disabled", true);
                    $("#Btn_Modificar").attr("disabled", true);
                    $("#Btn_Eliminar").attr("disabled", true);

                } else {
                    $("#mError_AAH h4").text("Error");
                    $("#mError_AAH button").attr("class", "btn btn-danger");
                    $("#mError_AAH p").text("Por favor, complete los campos solicitados.");
                    $("#mError_AAH").modal();
                }
            });

            //BTN EXCEL
            $("#Btn_Excel").click(function () {
                Ajax_Excel()
                accion = 5
                alerta_Proc_Correctos();
                despintarCasillasEstudio();
                Ajax_Limpiar();
            });

            //DEJA LOS CHECK EN 1 O EN 0
            $(document).on("change", "#div_chk input[type='checkbox']", function () {
                if ($(this).is(':checked')) {
                    $(this).val("1");
                } else {
                    $(this).val("0");
                }
            });

            //BLOQUEA LOS BOTONES
            $("#Btn_Guardar").attr("disabled", false);
            $("#Btn_Modificar").attr("disabled", true);
            $("#Btn_Eliminar").attr("disabled", true);
            $("#Btn_Determinacion").attr("disabled", true);
            $("#btn_modal_metodos").attr("disabled", true);
            $("#btn_modal_derivador").attr("disabled", true);
            $("#btn_modal_muestra").attr("disabled", true);
            $("#btn_modal_analizador").attr("disabled", true);


            $("#btnGuardarRanRef").attr("disabled", true);
            $("#btnModificarRanRef").attr("disabled", true);
            $("#btnEliminarRanRef").attr("disabled", true);
        });

        //Bloquea botones de la tabla de determinaciones
        function bloquear_botones() {
            //BLOQUEA LOS BOTONES
            $("#Btn_Eliminar_modal").attr("disabled", true);
            $("#Btn_inter_ref_modal").attr("disabled", true);
            $("#Btn_Modificar_modal").attr("disabled", true);
        }
    </script>


    <%-- //////////// DE AQUI PARA ABAJO EMPIEZA TODA LA PRIMERA INTERFAZ DE ESTUDIO //////////////////////// --%>

    <%-------------------- FUNCION PARA MOSTRAR UN ALERTA DE LOS PROCESOS HECHOS CORRECTAMENTE ---------%>
    <script>
        function alerta_Proc_Correctos() {
            var text = ""
            switch (accion) {
                case 1:
                    text = 'Limpiado correctamente'
                    break;
                case 2:
                    text = 'Guardado correctamente'
                    break;
                case 3:
                    text = 'Modificado correctamente'
                    break;
                case 4:
                    text = 'Eliminado correctamente'
                    break;
                case 5:
                    text = 'El Excel se genero correctamente'
                    break;
            }

            const Toast = Swal.mixin({
                toast: true,
                position: 'top-end',
                showConfirmButton: false,
                timer: 1500,
                timerProgressBar: true,
                didOpen: (toast) => {
                    toast.addEventListener('mouseenter', Swal.stopTimer)
                    toast.addEventListener('mouseleave', Swal.resumeTimer)
                }
            })
            Toast.fire({
                icon: 'success',
                title: text
            })
        }

    </script>
    <%--------------------------------------------- FUNCION PARA VALIDAR LOS CAMPOS VACIOS -------------------%>
    <script>
        function validar() {
            var sum = 0;
            if ($("#txt_cod").val() == "") {
                $("#txt_cod").css({
                    "border-color": "red"
                });
            } else {
                sum += 1;
                $("#txt_cod").css({ "border-color": "#868e96" });
            }

            if ($("#txt_des").val() == "") {
                $("#txt_des").css({
                    "border-color": "red"
                });
            } else {
                sum += 1;
                $("#txt_des").css({ "border-color": "#868e96" });
            }

            if ($("#txtdes_cor").val() == "") {
                $("#txtdes_cor").css({
                    "border-color": "red"
                });
            } else {
                sum += 1;
                $("#txtdes_cor").css({ "border-color": "#868e96" });
            }

            if ($("#txt_Dete").val() == "") {
                $("#txt_Dete").css({
                    "border-color": "red"
                });
            } else {
                sum += 1;
                $("#txt_Dete").css({ "border-color": "#868e96" });
            }

            if ($("#Ddl_Mantenedor").val() == 0) {
                $("#Ddl_Mantenedor").css({
                    "border-color": "red"
                });
            } else {
                sum += 1;
                $("#Ddl_Mantenedor").css({ "border-color": "#868e96" });
            }
            if ($("#ddl_Seccion").val() == 0) {
                $("#ddl_Seccion").css({
                    "border-color": "red"
                });
            } else {
                sum += 1;
                $("#ddl_Seccion").css({ "border-color": "#868e96" });
            }
            if ($("#txt_Host1").val()) {
                $("#txt_Host1").css({
                    "border-color": "#868e96"
                });
            } else {

                $("#txt_Host2").css({ "border-color": "#868e96" });
            }
            if ($("#txt_Host2").val()) {
                $("#txt_Host2").css({
                    "border-color": "#868e96"
                });
            } else {

                $("#txt_Host1").css({ "border-color": "#868e96" });
            }
            return sum;
        }
    </script>



    <%--------------------------------------------- FUNCION PARA PINTAR LOS INPUTS ---------------------------%>
    <script>

        function pintarCasillas() {

            if (($("#txt_cod").val()) || ($("#txt_des").val()) || ($("#txtdes_cor").val()) || ($("#txt_Dete").val()) || ($("#Ddl_Mantenedor").val()) || ($("#txt_Host1").val()) || ($("#txt_Host2").val()) || ($("#ddl_Seccion").val())) {
                $("#txt_cod").css({
                    "border-color": "black",
                    "border-width": "medium"
                });
                $("#txt_des").css({
                    "border-color": "black",
                    "border-width": "medium"
                });
                $("#txtdes_cor").css({
                    "border-color": "black",
                    "border-width": "medium"
                });
                $("#txt_Dete").css({
                    "border-color": "black",
                    "border-width": "medium"
                });
                $("#Ddl_Mantenedor").css({
                    "border-color": "black",
                    "border-width": "medium"
                });
                $("#txt_Host1").css({
                    "border-color": "black",
                    "border-width": "medium"
                });
                $("#txt_Host2").css({
                    "border-color": "black",
                    "border-width": "medium"
                });
                $("#ddl_Seccion").css({
                    "border-color": "black",
                    "border-width": "medium"
                });
            }
        }
    </script>
    <%--------------------------------------------- FUNCION PARA DESPINTAR LOS INPUTS ------------------------%>
    <script>
        function despintarCasillasEstudio() {
            if (($("#txt_cod").val()) || ($("#txt_des").val()) || ($("#txtdes_cor").val()) || ($("#txt_Dete").val()) || ($("#Ddl_Mantenedor").val()) || ($("#txt_Host1").val()) || ($("#txt_Host2").val()) || ($("#ddl_Seccion").val())) {
                $("#txt_cod").css({
                    "border-color": "#868e96",
                    "border-width": "thin"
                });
                $("#txt_des").css({
                    "border-color": "#868e96",
                    "border-width": "thin"
                });
                $("#txtdes_cor").css({
                    "border-color": "#868e96",
                    "border-width": "thin"
                });
                $("#txt_Dete").css({
                    "border-color": "#868e96",
                    "border-width": "thin"
                });
                $("#Ddl_Mantenedor").css({
                    "border-color": "#868e96",
                    "border-width": "thin"
                });
                $("#txt_Host1").css({
                    "border-color": "#868e96",
                    "border-width": "thin"
                });
                $("#txt_Host2").css({
                    "border-color": "#868e96",
                    "border-width": "thin"
                });
                $("#ddl_Seccion").css({
                    "border-color": "#868e96",
                    "border-width": "thin"
                });
            }

        }
    </script>
    <%--------------------------------------------- AJAX_CODIGUIN --------------------------------------------%>
    <script>
        function Ajax_Codiguin(codigo, desc, desc_corta, host1, host2, bac_est, id_estado, per_num_pru, id_rls_ls, rls_ls_desc, id_per) {



            $("#Btn_Guardar").attr("disabled", true);
            $("#Btn_Modificar").attr("disabled", false);
            $("#Btn_Eliminar").attr("disabled", false);
            $("#Btn_Determinacion").attr("disabled", false);

            //APARTADO DEL MODAL DERIVADOR
            $("#txtCodigoDerivadoEstudio").val(codigo);
            $("#txtDescripcionDerivadoEstudio").val(desc);

            $("#btn_modal_derivador").attr("disabled", false);

            //APARTADO DEL MODAL METODOS
            $("#txtCodigoMetodoEstudio").val(codigo);
            $("#txtDescripcionMetodoEstudio").val(desc);
            $("#btn_modal_metodos").attr("disabled", false);


            //APARTADO DEL MODAL MUESTRA
            $("#txtCodigoMuestraEstudio").val(codigo);
            $("#txtDescripcionMuestraEstudio").val(desc);
            $("#btn_modal_muestra").attr("disabled", false);

            //APARTADO DEL MODAL DE ANALIZADOR
            $("#txtCodigoAnalizadorEstudio").val(codigo);
            $("#txtDescripcionAnalizadorEstudio").val(desc);
            $("#btn_modal_analizador").attr("disabled", false);

            //APARTADO DEL MODAL DE REFERENCIA
            $("#txtAantecedenteCodEstudio").val(codigo);
            $("#txtAntecedenteDescEstudio").val(desc);

            $("#Div_Tabla_refer").empty();
            //APARTADO MODAL DETERMINACIONES

            $("#txtDeterminaCodEstudio").val("");
            $("#txtDeterminaDescEstudio").val("");
            $("#modalDete").show();

            //APARTADO MODAL REFER 
            //$("#modalRefer").show();

            $("#txt_cod").val(codigo);
            $("#txt_des").val(desc);
            $("#txtdes_cor").val(desc_corta);
            $("#txt_Dete").val(per_num_pru);
            $("#txt_Host1").val(host1);
            $("#txt_Host2").val(host2);
            //console.log("Id Estado: ", id_estado);
            $("#Ddl_Mantenedor").val(id_estado);
            $("#ddl_Seccion").val(id_rls_ls);
            $("#chk_imp_sel_prueba").val(bac_est);
            IDD = id_per


            codigo_per = codigo
            cant_det = parseInt(per_num_pru)

            console.log(IDD)
            console.log(codigo_per)

            if ($("#chk_imp_sel_prueba") == 1) {
                $("#bacterio").prop("checked", true);
                $("#bacterio").val("1");
            }
            else {
                $("#bacterio").prop("checked", false);
                $("#bacterio").val("0");
            }
            pintarCasillas();
            Ajax_Tabla_Determinacion()



        };
    </script>
    <%--------------------------------------------- DDL ESTADO MANTENEDOR-------------------------------------%>
    <script>
        var Mx_Dtt_Mantenedor = [
            {
                "ID_ESTADO": 0,
                "EST_DESCRIPCION": 0,
                "EST_MANTENEDOR": 0
            }
        ];
        function Ajax_Ddl_Mantenedor() {
            modal_show();


            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Mx_Dtt_Mantenedor = JSON.parse(json_receiver);
                        console.log("Estado: ", Mx_Dtt_Mantenedor)
                        Fill_Ddl_Mantenedor();
                        Hide_Modal();
                    } else {
                        Hide_Modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                }
            });
        }

        function Fill_Ddl_Mantenedor() {
            $("#Ddl_Mantenedor").empty();
            $("<option>", { "value": 0 }).text("Seleccionar").appendTo("#Ddl_Mantenedor");
            for (y = 0; y < Mx_Dtt_Mantenedor.length; ++y) {
                $("<option>", {
                    "value": Mx_Dtt_Mantenedor[y].ID_ESTADO
                }).text(Mx_Dtt_Mantenedor[y].EST_DESCRIPCION).appendTo("#Ddl_Mantenedor");
            }
        };
    </script>
    <%--------------------------------------------- DDL ESTADO SECCION ---------------------------------------%>
    <script>
        var Mx_Dtt_Seccion = [
            {
                "ID_RLS_LS": 0,
                "ID_LABO": 0,
                "ID_SECCION": 0,
                "RLS_LS_DESC": 0,
                "ID_ESTADO": 0
            }
        ];
        function Ajax_Ddl_Mantenedor_Seccion() {
            modal_show();


            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/LLENAR_DDL_SECCION",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        Mx_Dtt_Seccion = /*JSON.parse*/(json_receiver);
                        Fill_Ddl_Mantenedor_Seccion();


                        Hide_Modal();
                    } else {
                        Hide_Modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                }
            });
        }

        //Llenar DropDownList DE SECCION
        function Fill_Ddl_Mantenedor_Seccion() {
            $("#ddl_Seccion").empty();
            $("<option>", { "value": 0 }).text("Seleccionar").appendTo("#ddl_Seccion");
            for (y = 0; y < Mx_Dtt_Seccion.length; ++y) {
                $("<option>", {
                    "value": Mx_Dtt_Seccion[y].ID_RLS_LS

                }).text(Mx_Dtt_Seccion[y].RLS_LS_DESC).appendTo("#ddl_Seccion");

            }
        };
    </script>
    <%--------------------------------------------- BUSCAR DATOS DE LA TABLA ---------------------------------%>
    <script>
        var Mx_Dtt = [
            {
                "ID_PER": 0,
                "PER_COD": 0,
                "PER_DESC": 0,
                "PER_CORTO": 0,
                "PER_HOST1": 0,
                "PER_HOST2": 0,
                "PER_BAC_EST": 0,
                "ID_ESTADO": 0,
                "PER_NUM_PRU": 0,
                "ID_RLS_LS": 0,
                "RLS_LS_DESC": 0
            }
        ];
        function Ajax_Tabla() {
            modal_show();


            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_WEBF_BUSCA_PERFIL_ESTUDIO_CLINICO",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        /*console.log(json_receiver)*/
                        Mx_Dtt = JSON.parse(json_receiver);
                        direccionado();
                        $("#Div_Tabla_Estudios").empty();

                        Fill_DataTable();
                        Hide_Modal();


                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
        //--------------------------------------------------- CREA LA TABLA -------------------------------------------|
        function Fill_DataTable() {
            $("<table>", {
                "id": "Div_Tabla_Estudios",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla");

            $("#Div_Tabla_Estudios").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#Div_Tabla_Estudios").attr("class", "table table-hover table-striped table-iris");
            $("#Div_Tabla_Estudios thead").attr("class", "cabezera");
            $("#Div_Tabla_Estudios thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Código"),
                    $("<th>", { "class": "textoReducido" }).text("Descripción"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Estado"),
                    $("<th>", { "class": "textoReducido" }).text("N° Det"),
                    $("<th>", { "class": "textoReducido" }).text("Seccion"),
                    $("<th>", { "class": "textoReducido" }).text("Bacterio")

                )
            );
            for (i = 0; i < Mx_Dtt.length; i++) {

                if (IDD == Mx_Dtt[i].ID_PER) {

                    cant_det = parseInt(Mx_Dtt[i].PER_NUM_PRU)
                    codigo_per = Mx_Dtt[i].PER_COD
                    Ajax_Codiguin(Mx_Dtt[i].PER_COD, Mx_Dtt[i].PER_DESC, Mx_Dtt[i].PER_CORTO, Mx_Dtt[i].PER_HOST1, Mx_Dtt[i].PER_HOST2, Mx_Dtt[i].PER_BAC_EST, Mx_Dtt[i].ID_ESTADO, Mx_Dtt[i].PER_NUM_PRU, Mx_Dtt[i].ID_RLS_LS, Mx_Dtt[i].RLS_LS_DESC, Mx_Dtt[i].ID_PER)
                }
                $("#Div_Tabla_Estudios tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_Codiguin("` + Mx_Dtt[i].PER_COD + `","` + Mx_Dtt[i].PER_DESC + `","` + Mx_Dtt[i].PER_CORTO + `","` + Mx_Dtt[i].PER_HOST1 + `","` + Mx_Dtt[i].PER_HOST2 + `","` + Mx_Dtt[i].PER_BAC_EST + `","` + Mx_Dtt[i].ID_ESTADO + `","` + Mx_Dtt[i].PER_NUM_PRU + `","` + Mx_Dtt[i].ID_RLS_LS + `","` + Mx_Dtt[i].RLS_LS_DESC + `","` + Mx_Dtt[i].ID_PER + `")`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PER_COD),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PER_DESC),
                        $("<td>").css("text-align", "center",).html("<input type='checkbox' style='pointer-events:none'   id='chekito" + i + "' />"),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].PER_NUM_PRU),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt[i].RLS_LS_DESC),
                        $("<td>").css("text-align", "center",).html("<input type='checkbox' style='pointer-events:none'   id='bacterio" + i + "' />"),
                    )
                );
                if (Mx_Dtt[i].ID_ESTADO == 1) {
                    $("#chekito" + i).prop("checked", true);
                }
                if (Mx_Dtt[i].PER_BAC_EST == 1) {
                    $("#bacterio" + i).prop("checked", true);
                }
            }
            $("#Div_Tabla_Estudios tbody tr").click(function () {     /* <----- Pinta de color azul la tabla*/
                $("#Div_Tabla_Estudios tbody tr").removeClass("active");
                $(this).addClass("active");

                document.getElementById("chk_imp_sel_prueba").checked = $($(this).children()[6]).children()[0].checked;

            });
            $("#Div_Tabla_Estudios tbody tr").click(function () {     /* <----- Pinta de color azul la tabla*/
                $("#Div_Tabla_Estudios tbody tr").removeClass("active");
                $(this).addClass("active");
            });
            $('#Div_Tabla_Estudios').dataTable({                 /* <----- Agregue esta linea de codigo que agrega un buscador para la tabla*/
                "retrieve": true,
                "iDisplayLength": false,
                "info": false,
                "bPaginate": false,
                "bFilter": true,
                "bSort": false,
                "language": {
                    "search": "<strong></i>Filtro: </strong>"
                }
            });
        }


        function direccionado() {
            if (dataSession != null) {
                console.log(dataSession)
                IDD = parseInt(dataSession)
                let per = Mx_Dtt.find(element => element.ID_PER === IDD);
                Ajax_Codiguin(per.PER_COD, per.PER_DESC, per.PER_CORTO, per.PER_HOST1, per.PER_HOST2, per.PER_BAC_EST, per.ID_ESTADO, per.PER_NUM_PRU, per.ID_RLS_LS, per.RLS_LS_DESC, per.ID_PER)
                Ajax_Tabla_Determinacion()
                localStorage.removeItem("perfil");
            } else {
                //IDD = Mx_Dtt[0].ID_PER
                //Ajax_Tabla_Determinacion()
            }
        }
    </script>
    <%--------------------------------------------- GRABA ----------------------------------------------------%>
    <script>
        var numerin = 0
        function Ajax_Guardar() {
            modal_show();
            var Data_Par = JSON.stringify({
                "PER_COD": $("#txt_cod").val(),
                "PER_DESC": $("#txt_des").val(),
                "PER_CORTO": $("#txtdes_cor").val(),
                "PER_HOST1": $("#txt_Host1").val(),
                "PER_HOST2": $("#txt_Host2").val(),
                "PER_BAC_EST": $("#chk_imp_sel_prueba").val(),
                "ID_ESTADO": $("#Ddl_Mantenedor").val(),
                "PER_NUM_PRU": $("#txt_Dete").val(),
                "ID_RLS_LS": $("#ddl_Seccion").val()
            });



            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_WEBF_GRABA_ESTUDIOS",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;

                    if (json_receiver != "null") {
                        Hide_Modal();
                        IDD = parseInt(json_receiver)

                        codigo_per = $("#txt_cod").val();

                        Ajax_Formato(parseInt(json_receiver))
                        Ajax_Tabla();
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }
                    $("#Id_Conte").show();
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }

        function Ajax_Formato(perfil) {
            modal_show();
            var Data_Par = JSON.stringify({
                "ID_PER": perfil,
                "PER_COD": $("#txt_cod").val(),
                "PER_DESC": $("#txt_des").val(),
                "ID_ESTADO": $("#Ddl_Mantenedor").val(),
            });

            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_WEBF_GRABA_FORMATO",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;

                    if (json_receiver != "null") {

                        Add_Prueba(parseInt($("#txt_Dete").val()), 0, 0)
                        Ajax_Limpiar();
                        //console.log('formato creado')

                    } else {
                        //console.log('formato Error')

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }
                    $("#Id_Conte").show();
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
    </script>
    <%--------------------------------------------- UPDATE ---------------------------------------------------%>
    <script>

        var numerin = 0
        function Ajax_Update1() {

            modal_show();

            var Data_Par = JSON.stringify({

                "ID_PER": IDD,
                "PER_COD": $("#txt_cod").val(),
                "PER_DESC": $("#txt_des").val(),
                "PER_CORTO": $("#txtdes_cor").val(),
                "PER_HOST1": $("#txt_Host1").val(),
                "PER_HOST2": $("#txt_Host2").val(),
                "PER_BAC_EST": $("#chk_imp_sel_prueba").val(),
                "ID_ESTADO": $("#Ddl_Mantenedor").val(),
                //"PER_NUM_PRU": $("#txt_Dete").val(),
                "ID_RLS_LS": $("#ddl_Seccion").val()
                /*"RLS_LS_DESC": 0*/
            });


            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_WEBF_UPDATE_ESTUDIOS_PERFIL",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        numerin = JSON.parse(json_receiver);
                        accion = 3
                        alerta_Proc_Correctos();
                        despintarCasillasEstudio();
                        //Hide_Modal();
                        Add_Prueba(parseInt($("#txt_Dete").val()), Mx_Pruebas.length, Mx_Pruebas[Mx_Pruebas.length - 1].PRU_ORDEN)
                        Ajax_Formato_Update(IDD)
                        Ajax_Limpiar();
                        Ajax_Tabla();
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No ha ocurrido actualización.");
                        $("#mError_AAH").modal();
                    }
                    $("#Id_Conte").show();
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }

        function Ajax_Formato_Update(perfil) {
            modal_show();
            var Data_Par = JSON.stringify({
                "ID_PER": perfil,
                "PER_COD": $("#txt_cod").val(),
                "PER_DESC": $("#txt_des").val(),
            });

            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_WEBF_UPDATE_FORMATO",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;

                    if (json_receiver != "null") {



                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("Este Perfil NO tiene un formato asociado");
                        $("#mError_AAH").modal();
                    }
                    $("#Id_Conte").show();
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
    </script>
    <%--------------------------------------------- DELETE ---------------------------------------------------%>
    <script>
        var numerin = 0
        function Ajax_Delete_Prueba() {
            modal_show();
            var Data_Par = JSON.stringify({
                "ID_PER": IDD,
                "PER_COD": $("#txt_cod").val(),
                "PER_DESC": $("#txt_des").val(),
                "PER_CORTO": $("#txtdes_cor").val(),
                "PER_HOST1": $("#txt_Host1").val(),
                "PER_HOST2": $("#txt_Host2").val(),
                "PER_BAC_EST": $("#chk_imp_sel_prueba").val(),
                "ID_ESTADO": 2,
                "PER_NUM_PRU": $("#txt_Dete").val(),
                "ID_RLS_LS": $("#ddl_Seccion").val()
                /*"RLS_LS_DESC": 0*/
            });

            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_WEBF_UPDATE_ESTUDIOS_PERFIL",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        numerin = JSON.parse(json_receiver);
                        Hide_Modal();
                        Ajax_Formato_Delete(IDD);
                        accion = 4
                        alerta_Proc_Correctos();
                        despintarCasillasEstudio();
                        Ajax_Limpiar();
                        Ajax_Tabla();
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }
                    $("#Id_Conte").show();
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }

        function Ajax_Formato_Delete(perfil) {
            modal_show();
            var Data_Par = JSON.stringify({
                "ID_PER": perfil,
            });

            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_WEBF_DELETE_FORMATO",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;

                    if (json_receiver != "null") {


                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }
                    $("#Id_Conte").show();
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
    </script>
    <%--------------------------------------------- LIMPIAR --------------------------------------------------%>
    <script>
        function Ajax_Limpiar() {
            despintarCasillasEstudio();
            //IDD = 0;
            $("#modalRefer").hide();
            $("#modalDete").hide();
            $("#txt_cod").val("");
            $("#txt_des").val("");
            $("#txtdes_cor").val("");
            $("#txt_Dete").val("");
            $("#txt_Host1").val("");
            $("#txt_Host2").val("");
            $("#Ddl_Mantenedor").val(0);
            $("#ddl_Seccion").val(0);
            $("#chk_imp_sel_prueba").val();
            $("table tbody tr").removeClass("active");
            $("#chk_imp_sel_prueba").prop("checked", false);
            $("#Btn_Guardar").attr("disabled", false);
            $("#Btn_Modificar").attr("disabled", true);
            $("#Btn_Eliminar").attr("disabled", true);
            $("#Btn_Determinacion").attr("disabled", true);
            $("#btn_modal_metodos").attr("disabled", true);
            $("#btn_modal_derivador").attr("disabled", true);
            $("#btn_modal_muestra").attr("disabled", true);
            $("#btn_modal_analizador").attr("disabled", true);

        }
    </script>
    <%--------------------------------------------- EXCEL ----------------------------------------------------%>
    <script>
        var Mx_Dtt_Excel = [
            {
                "urls": ""
            }
        ];
        function Ajax_Excel() {

            var Data_Par = JSON.stringify({
                "DOMAIN_URL": location.origin
            });

            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/Excel",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        window.open(json_receiver, 'Download');


                    } else {

                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
    </script>

    <%-- //////////// DE AQUI PARA ABAJO EMPIEZA LA PARTE DE METODOS ASOCIADAS A UN ESTUDIO ///////////////////// --%>

    <%--------------------------- BUSCAR METODOS NO RELACIONADA (TABLA MODAL METODOS NO RELACIONADO) -----%>
    <script>
        var Mx_Dtt_tabla_modal_metodo = [
            {
                "ID_METODO": 0,
                "METO_COD": 0,
                "METO_DESC": 0,
                "ID_ESTADO": 0,
                "CHECK": 0

            }
        ];
        function Ajax_Tabla_metodo() {
            var Data_Par = JSON.stringify({
                "ID_PER": IDD

            });

            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_WEBF_CMVM_BUSCA_METODO_BY_ID_PER_NO_RELACIONADAS",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        Mx_Dtt_tabla_modal_metodo = (json_receiver);

                        $("#Div_Tabla_indicaciones").empty();
                        Fill_DataTable4();
                        Hide_Modal();
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();

                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
        //----------------------------------- CREA LA TABLA -------------------------------------------|
        function Fill_DataTable4() {
            $("<table>", {
                "id": "Div_Tabla_indicaciones",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_indi");
            $("#Div_Tabla_indicaciones").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#Div_Tabla_indicaciones").attr("class", "table table-hover table-striped table-iris");
            $("#Div_Tabla_indicaciones thead").attr("class", "cabezera");
            $("#Div_Tabla_indicaciones thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Descripción"),
                    $("<th>", { "class": "textoReducido" }).text("Agregar")

                )
            );
            for (i = 0; i < Mx_Dtt_tabla_modal_metodo.length; i++) {
                $("#Div_Tabla_indicaciones tbody").append(
                    $("<tr>", {
                        /*"onclick": `Ajax_Codiguin_No_Relacionadas("` + Mx_Dtt_tabla_modal_metodo[i].ID_METODO + `")`,*/
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_tabla_modal_metodo[i].METO_DESC),
                        $("<td>").css("text-align", "left",).html("<input type='checkbox'  id='No_relacionado" + Mx_Dtt_tabla_modal_metodo[i].ID_METODO + "' />"),
                    )
                );
            }
            $("#Div_Tabla_indicaciones tbody tr").click(function () {
                $("#Div_Tabla_indicaciones tbody tr").removeClass("active");
                $(this).addClass("active");
            });
            $("#Div_Tabla_indicaciones tbody tr td input").click(function (e) {
                let id_check = $(e.currentTarget).attr('id');
                console.log(id_check)


                let aux = Mx_Dtt_tabla_modal_metodo.find(item => item.ID_METODO == id_check.split('No_relacionado')[1]);
                console.log(aux)
                aux.CHECK = $('#' + id_check).is(':checked') ? 1 : 0;
            });
            $('#Div_Tabla_indicaciones').DataTable({                 /* <----- Agregue esta linea de codigo que agrega un buscador para la tabla*/
                "retrieve": true,
                "iDisplayLength": false,
                "info": false,
                "bPaginate": false,
                "bFilter": true,
                "bSort": false,
                "language": {
                    "search": "<strong></i>Filtro: </strong>"
                }
            });
        }
    </script>
    <%--------------------------- BUSCA METODO RELACIONADO (TABLA MODAL METODOS RELACIONADO)  ------------%>
    <script>
        var Mx_Dtt_metodo_rel = [
            {
                "ID_METODO": 0,
                "METODO_COD": 0,
                "METO_DESC": 0,
                "ID_ESTADO": 0,
                "ID_REL": 0,
                "ID_PER": 0,
                "ID_USUARIO": 0,
                "ID_REL_PER_METO": 0,
                "CHECK": 0,
                "REL_PER_METOD": 0


            }
        ];
        function Ajax_metodo_Relacionadas() {
            var Data_Par = JSON.stringify({
                "ID_PER": IDD

            });
            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_WEBF_CMVM_BUSCA_RELACION_ESTUDIO_METODO_MANTENEDOR_REL",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        Mx_Dtt_metodo_rel = (json_receiver);
                        Mx_Dtt_metodo_rel = Mx_Dtt_metodo_rel.map(item => {
                            item.CHECK = 0;
                            return item;
                        });



                        Fill_DataTable_metodo_Relacionada();
                        Hide_Modal();
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();

                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                }
            });
        }
        /*----------------------------------- CREACION DE LA TABLA CON LAS INDICACIONES REALACIONADAS -----------------------------*/
        function Fill_DataTable_metodo_Relacionada() {
            $("#Div_Tabla_Metodo_Rel").empty();
            $("<table>", {
                "id": "DataTable_met_id",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Metodo_Rel");
            $("#DataTable_met_id").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_met_id").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_met_id thead").attr("class", "cabezera");
            $("#DataTable_met_id thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Descripción"),
                    $("<th>", { "class": "textoReducido" }).text("Quitar")

                )
            );
            for (i = 0; i < Mx_Dtt_metodo_rel.length; i++) {
                $("#DataTable_met_id tbody").append(
                    $("<tr>", {
                        /*"onclick": `Ajax_Codiguin_Tabla_Relacionada("` + Mx_Dtt_metodo_rel[i].ID_REL_PER_METO + `")`,*/
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_metodo_rel[i].METO_DESC),
                        $("<td>").css("text-align", "left",).html("<input type='checkbox'  id='relacionado" + Mx_Dtt_metodo_rel[i].ID_REL_PER_METO + "' />"),
                    )
                );
            }
            $("#DataTable_met_id tbody tr").click(function () {
                $("#DataTable_met_id tbody tr").removeClass("active");
                $(this).addClass("active");
            });
            $("#DataTable_met_id tbody tr td input").click(function (e) {
                let id_check = $(e.currentTarget).attr('id');
                console.log(id_check)


                let aux = Mx_Dtt_metodo_rel.find(item => "" + item.ID_REL_PER_METO == id_check.split('relacionado')[1]);
                console.log(aux)
                aux.CHECK = $('#' + id_check).is(':checked') ? 1 : 0;
            });
            $('#DataTable_met_id').DataTable({                 /* <----- Agregue esta linea de codigo que agrega un buscador para la tabla*/
                "retrieve": true,
                "iDisplayLength": false,
                "info": false,
                "bPaginate": false,
                "bFilter": true,
                "bSort": false,
                "language": {
                    "search": "<strong></i>Filtro: </strong>"
                }
            });
        }
    </script>
    <%--------------------------- BOTON AGREGAR ----------------------------------------------------------%>
    <script>

        function Ajax_Agregar() {

            let user_metodo = Galletas.getGalleta("ID_USER");
            modal_show();
            var Data_Par = JSON.stringify({
                "ID_PER": IDD,
                "ARRAY_": Mx_Dtt_tabla_modal_metodo.filter(item => item.CHECK == 1).map(item => item.ID_METODO),
                "ID_USER": user_metodo

            });

            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_GRABA_RELACION_METODO_ESTUDIO",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        numerin = JSON.parse(json_receiver);
                        Hide_Modal();

                        Ajax_Tabla_metodo()

                        Ajax_metodo_Relacionadas()
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }

                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
    </script>
    <%--------------------------- BOTON QUITAR -----------------------------------------------------------%>
    <script>
        function Ajax_Quitar() {
            modal_show();
            var Data_Par = JSON.stringify({
                "ARRAY_": Mx_Dtt_metodo_rel.filter(item => item.CHECK == 1).map(item => item.ID_REL_PER_METO)

            });
            console.log(Data_Par)
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_WEBF_UPDATE_REL_METODO_ESTUDIO_QUITAR_RELACION",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        numerin = JSON.parse(json_receiver);
                        Hide_Modal();


                        Ajax_Tabla_metodo()

                        Ajax_metodo_Relacionadas()
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }

                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
    </script>

    <%-- //////////////// DE AQUI PARA ABAJO EMPIEZA LA PARTE DEl MODAL DE DERIVADOS /////////////////////////// --%>

    <%--------------------------- BUSCAR DERIVADO NO RELACIONADA (TABLA MODAL DERIVADO NO RELACIONADO) ------------%>
    <script>
        var Mx_Dtt_tabla_modal_derivado = [
            {
                "ID_DERIVADO": 0,
                "DERI_COD": 0,
                "DERI_DESC": 0,
                "ID_ESTADO": 0,
                "CHECK": 0

            }
        ];
        function Ajax_Tabla_derivado() {
            var Data_Par = JSON.stringify({
                "ID_PER": IDD

            });

            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_WEBF_CMVM_BUSCA_DERIVADO_BY_ID_PER_NO_RELACIONADAS",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        Mx_Dtt_tabla_modal_derivado = (json_receiver);

                        $("#Div_Tabla_derivado").empty();
                        Fill_DataTable5();
                        Hide_Modal();
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();

                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
        //----------------------------------- CREA LA TABLA -------------------------------------------|
        function Fill_DataTable5() {
            $("<table>", {
                "id": "Div_Tabla_derivado",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_deri");
            $("#Div_Tabla_derivado").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#Div_Tabla_derivado").attr("class", "table table-hover table-striped table-iris");
            $("#Div_Tabla_derivado thead").attr("class", "cabezera");
            $("#Div_Tabla_derivado thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Descripción"),
                    $("<th>", { "class": "textoReducido" }).text("Agregar")

                )
            );
            for (i = 0; i < Mx_Dtt_tabla_modal_derivado.length; i++) {
                $("#Div_Tabla_derivado tbody").append(
                    $("<tr>", {
                        /*"onclick": `Ajax_Codiguin_No_Relacionadas("` + Mx_Dtt_tabla_modal_derivado[i].ID_DERIVADO + `")`,*/
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_tabla_modal_derivado[i].DERI_DESC),
                        $("<td>").css("text-align", "left",).html("<input type='checkbox'  id='No_relacionado" + Mx_Dtt_tabla_modal_derivado[i].ID_DERIVADO + "' />"),
                    )
                );
            }
            $("#Div_Tabla_derivado tbody tr").click(function () {
                $("#Div_Tabla_derivado tbody tr").removeClass("active");
                $(this).addClass("active");
            });
            $("#Div_Tabla_derivado tbody tr td input").click(function (e) {
                let id_check = $(e.currentTarget).attr('id');
                console.log(id_check)


                let aux = Mx_Dtt_tabla_modal_derivado.find(item => item.ID_DERIVADO == id_check.split('No_relacionado')[1]);
                console.log(aux)
                aux.CHECK = $('#' + id_check).is(':checked') ? 1 : 0;
            });
            $('#Div_Tabla_derivado').DataTable({                 /* <----- Agregue esta linea de codigo que agrega un buscador para la tabla*/
                "retrieve": true,
                "iDisplayLength": false,
                "info": false,
                "bPaginate": false,
                "bFilter": true,
                "bSort": false,
                "language": {
                    "search": "<strong></i>Filtro: </strong>"
                }
            });
        }
    </script>
    <%--------------------------- BUSCA METODO RELACIONADO (TABLA MODAL DERIVACION RELACIONADO)  ------------------%>
    <script>
        var Mx_Dtt_derivado_rel = [
            {
                "ID_DERIVADO": 0,
                "DERI_COD": 0,
                "ID_ESTADO": 0,
                "ID_REL": 0,
                "ID_PER": 0,
                "ID_USUARIO": 0,
                "ID_REL_PER_DER": 0,
                "CHECK": 0,
                "REL_PER_DERIV": 0


            }
        ];
        function Ajax_metodo_Relacionadas_derivado() {
            var Data_Par = JSON.stringify({
                "ID_PER": IDD

            });
            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_WEBF_CMVM_BUSCA_RELACION_ESTUDIO_DERIVADO_MANTENEDOR_REL",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        Mx_Dtt_derivado_rel = (json_receiver);
                        Mx_Dtt_derivado_rel = Mx_Dtt_derivado_rel.map(item => {
                            item.CHECK = 0;
                            return item;
                        });
                        $("#Div_Tabla_derivado_Rel").empty();


                        Fill_DataTable_deri_Relacionada();
                        Hide_Modal();
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();

                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                }
            });
        }
        /*----------------------------------- CREACION DE LA TABLA CON LAS derivaciones REALACIONADAS -----------------------------*/
        function Fill_DataTable_deri_Relacionada() {
            $("<table>", {
                "id": "DataTable_indic_id",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_derivado_Rel");
            $("#DataTable_indic_id").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_indic_id").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_indic_id thead").attr("class", "cabezera");
            $("#DataTable_indic_id thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Descripción"),
                    $("<th>", { "class": "textoReducido" }).text("Quitar")

                )
            );
            for (i = 0; i < Mx_Dtt_derivado_rel.length; i++) {
                $("#DataTable_indic_id tbody").append(
                    $("<tr>", {
                        /*"onclick": `Ajax_Codiguin_Tabla_Relacionada("` + Mx_Dtt_derivado_rel[i].ID_REL_PER_DER + `")`,*/
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_derivado_rel[i].DERI_DESC),
                        $("<td>").css("text-align", "left",).html("<input type='checkbox'  id='relacionado" + Mx_Dtt_derivado_rel[i].ID_REL_PER_DER + "' />"),
                    )
                );
            }
            $("#DataTable_indic_id tbody tr").click(function () {
                $("#DataTable_indic_id tbody tr").removeClass("active");
                $(this).addClass("active");
            });
            $("#DataTable_indic_id tbody tr td input").click(function (e) {
                let id_check = $(e.currentTarget).attr('id');
                console.log(id_check)


                let aux = Mx_Dtt_derivado_rel.find(item => "" + item.ID_REL_PER_DER == id_check.split('relacionado')[1]);
                console.log(aux)
                aux.CHECK = $('#' + id_check).is(':checked') ? 1 : 0;
            });
            $('#DataTable_indic_id').DataTable({                 /* <----- Agregue esta linea de codigo que agrega un buscador para la tabla*/
                "retrieve": true,
                "iDisplayLength": false,
                "info": false,
                "bPaginate": false,
                "bFilter": true,
                "bSort": false,
                "language": {
                    "search": "<strong></i>Filtro: </strong>"
                }
            });
        }
    </script>
    <%--------------------------- BOTON AGREGAR DERIVACION --------------------------------------------------------%>
    <script>

        function Ajax_Agregar_deri() {

            let user_metodo = Galletas.getGalleta("ID_USER");
            modal_show();


            var Data_Par = JSON.stringify({
                "ID_PER": IDD,
                "ARRAY_": Mx_Dtt_tabla_modal_derivado.filter(item => item.CHECK == 1).map(item => item.ID_DERIVADO),
                "ID_USER": user_metodo

            });
            console.log(Data_Par);
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_GRABA_RELACION_DERIVADO_ESTUDIO",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        numerin = JSON.parse(json_receiver);
                        Hide_Modal();

                        Ajax_Tabla_derivado()

                        Ajax_metodo_Relacionadas_derivado()
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }

                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
    </script>
    <%--------------------------- BOTON QUITAR --------------------------------------------------------------------%>
    <script>
        function Ajax_Quitar_deri() {
            modal_show();
            var Data_Par = JSON.stringify({
                "ARRAY_": Mx_Dtt_derivado_rel.filter(item => item.CHECK == 1).map(item => item.ID_REL_PER_DER)

            });
            console.log(Data_Par)
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_WEBF_UPDATE_REL_DERIVADO_ESTUDIO_QUITAR_RELACION",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        numerin = JSON.parse(json_receiver);
                        Hide_Modal();


                        Ajax_Tabla_derivado()

                        Ajax_metodo_Relacionadas_derivado()
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }

                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
    </script>

    <%-- //////////////// DE AQUI PARA ABAJO EMPIEZA LA PARTE DEl MODAL DE TIPO MUESTRA SANGRE ///////////////////// --%>

    <%--------------------------- BUSCAR TIPO MUESTRA SANGRE NO RELACIONADA (TABLA MODAL TIPO MUESTRA SANGRE NO RELACIONADO) -----%>
    <script>
        var Mx_Dtt_tabla_modal_muestra = [
            {
                "ID_MUESTRA_SANGRE": 0,
                "MUESTRA_SANGRE_COD": 0,
                "MUESTRA_SANGRE_DESC": 0,
                "ID_ESTADO": 0,
                "CHECK": 0

            }
        ];
        function Ajax_Tabla_muestra() {
            var Data_Par = JSON.stringify({
                "ID_PER": IDD

            });

            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_WEBF_CMVM_BUSCA_TP_MUESTRA_SANGRE_BY_ID_PER_NO_RELACIONADAS",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        Mx_Dtt_tabla_modal_muestra = (json_receiver);

                        $("#Div_Tabla_muestra").empty();
                        Fill_DataTable6();
                        Hide_Modal();
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();

                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
        //----------------------------------- CREA LA TABLA -------------------------------------------|
        function Fill_DataTable6() {
            $("<table>", {
                "id": "Div_Tabla_muestra",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_mues");
            $("#Div_Tabla_muestra").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#Div_Tabla_muestra").attr("class", "table table-hover table-striped table-iris");
            $("#Div_Tabla_muestra thead").attr("class", "cabezera");
            $("#Div_Tabla_muestra thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Descripción"),
                    $("<th>", { "class": "textoReducido" }).text("Agregar")

                )
            );
            for (i = 0; i < Mx_Dtt_tabla_modal_muestra.length; i++) {
                $("#Div_Tabla_muestra tbody").append(
                    $("<tr>", {
                        /*"onclick": `Ajax_Codiguin_No_Relacionadas("` + Mx_Dtt_tabla_modal_muestra[i].ID_DERIVADO + `")`,*/
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_tabla_modal_muestra[i].MUESTRA_SANGRE_DESC),
                        $("<td>").css("text-align", "left",).html("<input type='checkbox'  id='No_relacionado" + Mx_Dtt_tabla_modal_muestra[i].ID_MUESTRA_SANGRE + "' />"),
                    )
                );
            }
            $("#Div_Tabla_muestra tbody tr").click(function () {
                $("#Div_Tabla_muestra tbody tr").removeClass("active");
                $(this).addClass("active");
            });
            $("#Div_Tabla_muestra tbody tr td input").click(function (e) {
                let id_check = $(e.currentTarget).attr('id');
                console.log(id_check)


                let aux = Mx_Dtt_tabla_modal_muestra.find(item => item.ID_MUESTRA_SANGRE == id_check.split('No_relacionado')[1]);
                console.log(aux)
                aux.CHECK = $('#' + id_check).is(':checked') ? 1 : 0;
            });
            $('#Div_Tabla_muestra').DataTable({                 /* <----- Agregue esta linea de codigo que agrega un buscador para la tabla*/
                "retrieve": true,
                "iDisplayLength": false,
                "info": false,
                "bPaginate": false,
                "bFilter": true,
                "bSort": false,
                "language": {
                    "search": "<strong></i>Filtro: </strong>"
                }
            });
        }
    </script>
    <%--------------------------- BUSCA METODO RELACIONADO (TABLA MODAL TIPO MUESTRA SANGRE RELACIONADO)  ------------%>
    <script>
        var Mx_Dtt_muestra_rel = [
            {
                "ID_MUESTRA_SANGRE": 0,
                "MUESTRA_SANGRE_COD": 0,
                "ID_ESTADO": 0,
                "ID_PER": 0,
                "ID_USUARIO": 0,
                "ID_REL_PER_MSANGRE": 0,
                "CHECK": 0,
                "REL_PER_MSANGRE": 0


            }
        ];
        function Ajax_metodo_Relacionadas_muestra() {
            var Data_Par = JSON.stringify({
                "ID_PER": IDD

            });
            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_WEBF_CMVM_BUSCA_RELACION_TP_MUESTRA_SANGRE_MANTENEDOR_REL",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        Mx_Dtt_muestra_rel = (json_receiver);
                        Mx_Dtt_muestra_rel = Mx_Dtt_muestra_rel.map(item => {
                            item.CHECK = 0;
                            return item;
                        });
                        $("#Div_Tabla_muestra_Rel").empty();


                        Fill_DataTable_muestra_Relacionada();
                        Hide_Modal();
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();

                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                }
            });
        }
        /*----------------------------------- CREACION DE LA TABLA CON LAS Muestra REALACIONADAS -----------------------------*/
        function Fill_DataTable_muestra_Relacionada() {
            $("<table>", {
                "id": "DataTable_mues_id",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_muestra_Rel");
            $("#DataTable_mues_id").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_mues_id").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_mues_id thead").attr("class", "cabezera");
            $("#DataTable_mues_id thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Descripción"),
                    $("<th>", { "class": "textoReducido" }).text("Quitar")

                )
            );
            for (i = 0; i < Mx_Dtt_muestra_rel.length; i++) {
                $("#DataTable_mues_id tbody").append(
                    $("<tr>", {
                        /*"onclick": `Ajax_Codiguin_Tabla_Relacionada("` + Mx_Dtt_muestra_rel[i].ID_REL_PER_MSANGRE + `")`,*/
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_muestra_rel[i].MUESTRA_SANGRE_DESC),
                        $("<td>").css("text-align", "left",).html("<input type='checkbox'  id='relacionado" + Mx_Dtt_muestra_rel[i].ID_REL_PER_MSANGRE + "' />"),
                    )
                );
            }
            $("#DataTable_mues_id tbody tr").click(function () {
                $("#DataTable_mues_id tbody tr").removeClass("active");
                $(this).addClass("active");
            });
            $("#DataTable_mues_id tbody tr td input").click(function (e) {
                let id_check = $(e.currentTarget).attr('id');
                console.log(id_check)


                let aux = Mx_Dtt_muestra_rel.find(item => "" + item.ID_REL_PER_MSANGRE == id_check.split('relacionado')[1]);
                console.log(aux)
                aux.CHECK = $('#' + id_check).is(':checked') ? 1 : 0;
            });
            $('#DataTable_mues_id').DataTable({                 /* <----- Agregue esta linea de codigo que agrega un buscador para la tabla*/
                "retrieve": true,
                "iDisplayLength": false,
                "info": false,
                "bPaginate": false,
                "bFilter": true,
                "bSort": false,
                "language": {
                    "search": "<strong></i>Filtro: </strong>"
                }
            });
        }
    </script>
    <%--------------------------- BOTON AGREGAR TIPO MUESTRA SANGRE ----------------------------------------------------------%>
    <script>

        function Ajax_Agregar_muestra() {

            let user_metodo = Galletas.getGalleta("ID_USER");
            modal_show();
            var Data_Par = JSON.stringify({
                "ID_PER": IDD,
                "ARRAY_": Mx_Dtt_tabla_modal_muestra.filter(item => item.CHECK == 1).map(item => item.ID_MUESTRA_SANGRE),
                "ID_USER": user_metodo

            });

            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_GRABA_RELACION_TP_MUESTRA_SANGRE_ESTUDIO",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        numerin = JSON.parse(json_receiver);
                        Hide_Modal();

                        Ajax_Tabla_muestra()

                        Ajax_metodo_Relacionadas_muestra()
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }

                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
    </script>
    <%--------------------------- BOTON QUITAR -----------------------------------------------------------%>
    <script>
        function Ajax_Quitar_muestra() {
            modal_show();
            var Data_Par = JSON.stringify({
                "ARRAY_": Mx_Dtt_muestra_rel.filter(item => item.CHECK == 1).map(item => item.ID_REL_PER_MSANGRE)

            });
            console.log(Data_Par)
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_WEBF_UPDATE_REL_TP_DE_MUESTRA_SANGRE_ESTUDIO_QUITAR_RELACION",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        numerin = JSON.parse(json_receiver);
                        Hide_Modal();


                        Ajax_Tabla_muestra()

                        Ajax_metodo_Relacionadas_muestra()
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }

                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
    </script>

    <%-- //////////////// DE AQUI PARA ABAJO EMPIEZA LA PARTE DEl MODAL ANALIZADOR  ///////////////////// --%>

    <%--------------------------- BUSCAR TIPO ANALIZADOR SANGRE NO RELACIONADA (TABLA MODAL TIPO ANALIZADOR  NO RELACIONADO) -----%>
    <script>
        var Mx_Dtt_tabla_modal_analizador = [
            {
                "ID_ANAL": 0,
                "ANAL_COD": 0,
                "ANAL_DESC": 0,
                "ID_ESTADO": 0,
                "CHECK": 0

            }
        ];
        function Ajax_Tabla_analizador() {
            var Data_Par = JSON.stringify({
                "ID_PER": IDD

            });

            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_WEBF_CMVM_BUSCA_ANALIZADOR_BY_ID_PER_NO_RELACIONADAS",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        Mx_Dtt_tabla_modal_analizador = (json_receiver);

                        $("#Div_Tabla_analizador").empty();
                        Fill_DataTable7();
                        Hide_Modal();
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();

                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
        //----------------------------------- CREA LA TABLA -------------------------------------------|
        function Fill_DataTable7() {
            $("<table>", {
                "id": "Div_Tabla_analizador",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_anal");
            $("#Div_Tabla_analizador").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#Div_Tabla_analizador").attr("class", "table table-hover table-striped table-iris");
            $("#Div_Tabla_analizador thead").attr("class", "cabezera");
            $("#Div_Tabla_analizador thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Descripción"),
                    $("<th>", { "class": "textoReducido" }).text("Agregar")

                )
            );
            for (i = 0; i < Mx_Dtt_tabla_modal_analizador.length; i++) {
                $("#Div_Tabla_analizador tbody").append(
                    $("<tr>", {
                        /*"onclick": `Ajax_Codiguin_No_Relacionadas("` + Mx_Dtt_tabla_modal_analizador[i].ID_ANAL + `")`,*/
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_tabla_modal_analizador[i].ANAL_DESC),
                        $("<td>").css("text-align", "left",).html("<input type='checkbox'  id='No_relacionado" + Mx_Dtt_tabla_modal_analizador[i].ID_ANAL + "' />"),
                    )
                );
            }
            $("#Div_Tabla_analizador tbody tr").click(function () {
                $("#Div_Tabla_analizador tbody tr").removeClass("active");
                $(this).addClass("active");
            });
            $("#Div_Tabla_analizador tbody tr td input").click(function (e) {
                let id_check = $(e.currentTarget).attr('id');
                console.log(id_check)


                let aux = Mx_Dtt_tabla_modal_analizador.find(item => item.ID_ANAL == id_check.split('No_relacionado')[1]);
                console.log(aux)
                aux.CHECK = $('#' + id_check).is(':checked') ? 1 : 0;
            });
            $('#Div_Tabla_analizador').DataTable({                 /* <----- Agregue esta linea de codigo que agrega un buscador para la tabla*/
                "retrieve": true,
                "iDisplayLength": false,
                "info": false,
                "bPaginate": false,
                "bFilter": true,
                "bSort": false,
                "language": {
                    "search": "<strong></i>Filtro: </strong>"
                }
            });
        }
    </script>
    <%--------------------------- BUSCA METODO RELACIONADO (TABLA MODAL TIPO ANALIZADOR  RELACIONADO)  ------------%>
    <script>
        var Mx_Dtt_analizador_rel = [
            {
                "ID_ANAL": 0,
                "ANAL_COD": 0,
                "ANAL_DESC": 0,
                "ID_ESTADO": 0,
                "ID_PER": 0,
                "ID_USUARIO": 0,
                "ID_REL_PER_ANAL": 0,
                "CHECK": 0,

            }
        ];
        function Ajax_metodo_Relacionadas_analizador() {
            var Data_Par = JSON.stringify({
                "ID_PER": IDD

            });
            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_WEBF_CMVM_BUSCA_RELACION_ANALIZADOR_MANTENEDOR_REL",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        Mx_Dtt_analizador_rel = (json_receiver);
                        Mx_Dtt_analizador_rel = Mx_Dtt_analizador_rel.map(item => {
                            item.CHECK = 0;
                            return item;
                        });
                        $("#Div_Tabla_anal_Rel").empty();


                        Fill_DataTable_analizador_Relacionada();
                        Hide_Modal();
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();

                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                }
            });
        }
        /*----------------------------------- CREACION DE LA TABLA CON LAS ANALIZADOR REALACIONADAS -----------------------------*/
        function Fill_DataTable_analizador_Relacionada() {
            $("<table>", {
                "id": "DataTable_ana_id",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_anal_Rel");
            $("#DataTable_ana_id").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#DataTable_ana_id").attr("class", "table table-hover table-striped table-iris");
            $("#DataTable_ana_id thead").attr("class", "cabezera");
            $("#DataTable_ana_id thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido" }).text("#"),
                    $("<th>", { "class": "textoReducido" }).text("Descripción"),
                    $("<th>", { "class": "textoReducido" }).text("Quitar")

                )
            );
            for (i = 0; i < Mx_Dtt_analizador_rel.length; i++) {
                $("#DataTable_ana_id tbody").append(
                    $("<tr>", {
                        /*"onclick": `Ajax_Codiguin_Tabla_Relacionada("` + Mx_Dtt_analizador_rel[i].ID_REL_PER_ANAL + `")`,*/
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(Mx_Dtt_analizador_rel[i].ANAL_DESC),
                        $("<td>").css("text-align", "left",).html("<input type='checkbox'  id='relacionado" + Mx_Dtt_analizador_rel[i].ID_REL_PER_ANAL + "' />"),
                    )
                );
            }
            $("#DataTable_ana_id tbody tr").click(function () {
                $("#DataTable_ana_id tbody tr").removeClass("active");
                $(this).addClass("active");
            });
            $("#DataTable_ana_id tbody tr td input").click(function (e) {
                let id_check = $(e.currentTarget).attr('id');
                console.log(id_check)


                let aux = Mx_Dtt_analizador_rel.find(item => "" + item.ID_REL_PER_ANAL == id_check.split('relacionado')[1]);
                console.log(aux)
                aux.CHECK = $('#' + id_check).is(':checked') ? 1 : 0;
            });
            $('#DataTable_ana_id').DataTable({                 /* <----- Agregue esta linea de codigo que agrega un buscador para la tabla*/
                "retrieve": true,
                "iDisplayLength": false,
                "info": false,
                "bPaginate": false,
                "bFilter": true,
                "bSort": false,
                "language": {
                    "search": "<strong></i>Filtro: </strong>"
                }
            });
        }
    </script>
    <%--------------------------- BOTON AGREGAR ANALIZADOR  ----------------------------------------------------------%>
    <script>

        function Ajax_Agregar_analizador() {

            let user_metodo = Galletas.getGalleta("ID_USER");
            modal_show();
            var Data_Par = JSON.stringify({
                "ID_PER": IDD,
                "ARRAY_": Mx_Dtt_tabla_modal_analizador.filter(item => item.CHECK == 1).map(item => item.ID_ANAL),
                "ID_USER": user_metodo

            });

            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_GRABA_RELACION_ANALIZADOR_ESTUDIO",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        numerin = JSON.parse(json_receiver);
                        Hide_Modal();

                        Ajax_Tabla_analizador()

                        Ajax_metodo_Relacionadas_analizador()
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }

                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
    </script>
    <%--------------------------- BOTON QUITAR -----------------------------------------------------------%>
    <script>
        function Ajax_Quitar_analizador() {
            modal_show();
            var Data_Par = JSON.stringify({
                "ARRAY_": Mx_Dtt_analizador_rel.filter(item => item.CHECK == 1).map(item => item.ID_REL_PER_ANAL)

            });
            console.log(Data_Par)
            $(".block_wait").fadeIn(500);
            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_WEBF_UPDATE_REL_ANALIZADOR_QUITAR_RELACION",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        numerin = JSON.parse(json_receiver);
                        Hide_Modal();


                        Ajax_Tabla_analizador()

                        Ajax_metodo_Relacionadas_analizador()
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }

                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
    </script>

    <%-- ////////// DE AQUI PARA ABAJO EMPIEZA LA PARTE DE DETERMINACIONES ASOCIADAS A UN ESTUDIO ////////////// --%>

    <%----------------------------------- BUSCAR DATOS DETERMINACIONES DE LA TABLA --------------%>
    <script>
        var Mx_Pruebas = [
            {
                "ID_PRUEBA": 0,
                "PRU_COD": 0,
                "PRU_DESC": 0,
                "PRU_ORDEN": 0,
                "ID_U_MEDIDA": 0,
                "ID_TP_RESULTADO": 0,
                "ID_T_MUESTRA": 0,
                "ID_TP_BAC": 0,
                "PRU_SOLICITADO": 0,
                "ID_ESTADO": 0,
                "PRU_DECIMAL": 0,
                "PRU_CORTO": 0,
                "PRU_P_CERO": 0,
                "REQ_RES_VAL": 0,
                "PRU_P_PUNTO": 0,
            }
        ];


        function Ajax_Tabla_Determinacion() {

            var Data_Par = JSON.stringify({
                "ID_PER": IDD
            });
            modal_show();

            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_BUSCA_PRUEBAS_POR_CODIGO_PER",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    json_receiver = response.d;

                    if (json_receiver != null) {

                        Mx_Pruebas = json_receiver;
                        $("#Div_Tabla_Pruebas").empty();
                        $("#Div_Tabla_Lista").empty();
                        $("#Div_Tabla_Estudio_Cod_Fonasa").empty();

                        Fill_DataTableModal();

                        Hide_Modal();


                    } else {

                        Hide_Modal();
                        $("#Div_Tabla_Pruebas").empty();
                        $('#eModal2').modal('hide');
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();


                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
        //--------------------------------------------------- CREA LA TABLA -------------------------------------------|
        function Fill_DataTableModal() {
            $("<table>", {
                "id": "Div_Tabla_Lista",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#Div_Tabla_Pruebas");

            $("#Div_Tabla_Lista").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#Div_Tabla_Lista").attr("class", "table table-hover table-striped table-iris");
            $("#Div_Tabla_Lista thead").attr("class", "cabezera");
            $("#Div_Tabla_Lista thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido text-center" }).text("#"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Código"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Descripción"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Orden"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Unidad"),
                    $("<th>", { "class": "textoReducido text-center" }).text("T Resultado"),
                    $("<th>", { "class": "textoReducido text-center" }).text("T Muestra"),
                    $("<th>", { "class": "textoReducido text-center" }).text("T Bac"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Solicitado"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Activo"),
                    $("<th>", { "class": "textoReducido text-center" }).text("N Dec."),
                    $("<th>", { "class": "textoReducido text-center" }).text("= 0"),
                    $("<th>", { "class": "textoReducido text-center" }).text("RPV"),
                    $("<th>", { "class": "textoReducido text-center" }).text("PUNT")

                )
            );
            for (i = 0; i < Mx_Pruebas.length; i++) {
                $("#Div_Tabla_Lista tbody").append(
                    $("<tr>", {
                        "onclick": `toAjaxModalInterRefer("` + Mx_Pruebas[i].ID_PRUEBA + `")`,
                        "onclick": `Seleccion("` + Mx_Pruebas[i].ID_PRUEBA + '","' + Mx_Pruebas[i].PRU_COD + '","' + Mx_Pruebas[i].PRU_DESC + `")`,
                        /*"onclick": `Seleccion2("` + Mx_Pruebas[i].PRU_COD + "," + Mx_Pruebas[i].PRU_DESC + `")`,*/
                        "class": "manito",
                        "id": Mx_Pruebas[i].ID_PRUEBA
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(i + 1),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).html("<input type=text class='textoReducidoV2' id='txt_cod_prueba" + i + "'/>"),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).html("<input type=text class='textoReducidoV2' id='txt_desc_prueba" + i + "'/>"),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).html("<input type=text class='textoReducidoV2' id='txt_orden_prueba" + i + "'/>"),
                        $("<td>", { "align": "center" }).css("text-align", "center",).html("<select id='ddl_unidad" + i + "'></select>"),
                        $("<td>", { "align": "center" }).css("text-align", "center",).html("<select id='ddl_resultado" + i + "'></select>"),
                        $("<td>", { "align": "center" }).css("text-align", "center",).html("<select id='ddl_muestra" + i + "'></select>"),
                        $("<td>", { "align": "center" }).css("text-align", "center",).html("<select id='ddl_bac" + i + "'></select>"),
                        $("<td>").css("text-align", "center",).html("<input type='checkbox' id='solic" + i + "' />"),
                        $("<td>").css("text-align", "center",).html("<input type='checkbox' id='activo" + i + "' />"),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).html("<input type=text class='textoReducidoV2' id='txt_decimal_prueba" + i + "'/>"),
                        $("<td>").css("text-align", "center",).html("<input type='checkbox' id='cero" + i + "' />"),
                        $("<td>").css("text-align", "center",).html("<input type='checkbox' id='rpv" + i + "' />"),
                        $("<td>").css("text-align", "center",).html("<input type='checkbox' id='punto" + i + "' />"),
                    )
                );
                if (Mx_Pruebas[i].PRU_SOLICITADO == 1) {
                    $("#solic" + i).prop("checked", true);
                }

                if (Mx_Pruebas[i].ID_ESTADO == 1) {
                    $("#activo" + i).prop("checked", true);
                }
                if (Mx_Pruebas[i].PRU_P_CERO == 1) {
                    $("#cero" + i).prop("checked", true);
                }
                if (Mx_Pruebas[i].REQ_RES_VAL == 1) {
                    $("#rpv" + i).prop("checked", true);
                }
                if (Mx_Pruebas[i].PRU_P_PUNTO == 1) {
                    $("#punto" + i).prop("checked", true);
                }
                Fill_Ddl_Mantenedor_Unidad_single(i)
                Fill_Ddl_Mantenedor_Resultado_single(i)
                Fill_Ddl_Mantenedor_Muestra_single(i)
                Fill_Ddl_Mantenedor_Bacterio_single(i)
                $("#txt_cod_prueba" + i).val(Mx_Pruebas[i].PRU_COD);
                $("#txt_desc_prueba" + i).val(Mx_Pruebas[i].PRU_DESC);
                $("#txt_orden_prueba" + i).val(Mx_Pruebas[i].PRU_ORDEN);
                $("#txt_decimal_prueba" + i).val(Mx_Pruebas[i].PRU_DECIMAL);
                $("#ddl_unidad" + i).val(Mx_Pruebas[i].ID_U_MEDIDA);
                $("#ddl_resultado" + i).val(Mx_Pruebas[i].ID_TP_RESULTADO);
                $("#ddl_muestra" + i).val(Mx_Pruebas[i].ID_T_MUESTRA);
                $("#ddl_bac" + i).val(Mx_Pruebas[i].ID_TP_BAC);

                //$("#txtDeterminaCodEstudio").val(PRU_COD);
                //$("#txtDeterminaDescEstudio").val(PRU_DESC);
            }
            $("#Div_Tabla_Lista tbody tr").click(function () {     /* <----- Pinta de color azul la tabla*/
                $("#Div_Tabla_Lista tbody tr").removeClass("active");
                $(this).addClass("active");
            });
            $('#Div_Tabla_Lista').dataTable({                 /* <----- Agregue esta linea de codigo que agrega un buscador para la tabla*/
                "retrieve": true,
                "iDisplayLength": false,
                "info": false,
                "bPaginate": false,
                "bFilter": true,
                "bSort": false,
                "language": {
                    "search": "<strong></i>Filtro: </strong>"
                }
            });
        }
    </script>
    <%----------------------------------- BUCAR DATOS SELECT MODAL ------------------------------%>
    <script>
        var Mx_unidad = [
            {
                "ID_U_MEDIDA": 0,
                "UM_COD": 0,
                "UM_DESC": 0,
                "ID_ESTADO": 0,
            }
        ];

        var Mx_resultado = [
            {
                "ID_TP_RESULTADO": 0,
                "TP_RESUL_COD": 0,
                "TP_RESUL_DESC": 0,
                "ID_ESTADO": 0,
            }
        ];

        var Mx_Muestra = [
            {
                "ID_G_MUESTRA": 0,
                "GMUE_COD": 0,
                "GMUE_DESC": 0,
                "ID_ESTADO": 0,
            }
        ];

        var Mx_bacterio = [
            {
                "ID_TP_BAC": 0,
                "TP_BAC_COD": 0,
                "TP_BAC_DESC": 0,
                "ID_ESTADO": 0,
            }
        ];

        //Llenar DropDownList DE UNIDAD
        function Ajax_Ddl_Mantenedor_Unidad() {
            modal_show();

            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_BUSCA_UNIDAD_MEDIDA",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        Mx_unidad = /*JSON.parse*/(json_receiver);
                        Ajax_Ddl_Mantenedor_Resultado()
                        Hide_Modal();
                    } else {
                        Hide_Modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                }
            });
        }

        function Fill_Ddl_Mantenedor_Unidad_single(i) {
            let str = "#ddl_unidad" + i
            $(str).empty();
            $("<option>", { "value": 0 }).text("Seleccionar").appendTo(str);
            for (y = 0; y < Mx_unidad.length; ++y) {
                $("<option>", {
                    "value": Mx_unidad[y].ID_U_MEDIDA

                }).text(Mx_unidad[y].UM_DESC).appendTo(str);

            }
        };

        //Llenar DropDownList DE RESULTADO
        function Ajax_Ddl_Mantenedor_Resultado() {
            modal_show();


            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_BUSCA_TP_RESULTADO",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        /*console.log(json_receiver);*/
                        Mx_resultado = /*JSON.parse*/(json_receiver);

                        Ajax_Ddl_Mantenedor_Muestra()
                        Hide_Modal();
                    } else {
                        Hide_Modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                }
            });
        }

        function Fill_Ddl_Mantenedor_Resultado_single(i) {
            let str = "#ddl_resultado" + i
            $(str).empty();
            $("<option>", { "value": 0 }).text("Seleccionar").appendTo(str);
            for (y = 0; y < Mx_resultado.length; ++y) {
                $("<option>", {
                    "value": Mx_resultado[y].ID_TP_RESULTADO

                }).text(Mx_resultado[y].TP_RESUL_DESC).appendTo(str);

            }
        };

        //Llenar DropDownList DE MUESTRA
        function Ajax_Ddl_Mantenedor_Muestra() {
            modal_show();


            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_BUSCA_MUESTRA",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        /*console.log(json_receiver);*/
                        Mx_Muestra = /*JSON.parse*/(json_receiver);
                        Ajax_Ddl_Mantenedor_Bacterio()
                        Hide_Modal();
                    } else {
                        Hide_Modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                }
            });
        }

        function Fill_Ddl_Mantenedor_Muestra_single(i) {
            let str = "#ddl_muestra" + i
            $(str).empty();
            $("<option>", { "value": 0 }).text("Seleccionar").appendTo(str);
            for (y = 0; y < Mx_Muestra.length; ++y) {
                $("<option>", {
                    "value": Mx_Muestra[y].ID_G_MUESTRA

                }).text(Mx_Muestra[y].GMUE_DESC).appendTo(str);

            }
        };
        //Llenar DropDownList DE BACTERIO
        function Ajax_Ddl_Mantenedor_Bacterio() {
            modal_show();


            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_BUSCA_TP_BACTERIO",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        /*console.log(json_receiver);*/
                        Mx_bacterio = /*JSON.parse*/(json_receiver);
                        Hide_Modal();
                    } else {
                        Hide_Modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                }
            });
        }

        function Fill_Ddl_Mantenedor_Bacterio_single(i) {
            let str = "#ddl_bac" + i
            $(str).empty();
            $("<option>", { "value": 0 }).text("Seleccionar").appendTo(str);
            for (y = 0; y < Mx_bacterio.length; ++y) {
                $("<option>", {
                    "value": Mx_bacterio[y].ID_TP_BAC

                }).text(Mx_bacterio[y].TP_BAC_DESC).appendTo(str);

            }
        };
    </script>
    <%----------------------------------- FUNCION PARA VALIDAR LOS CAMPOS VACIOS ----------------%>
    <script>
        function validarModal() {
            var sum = 0;
            if ($("#ddl_unidad").val() == 0) {
                $("#ddl_unidad").css({
                    "border-color": "red"
                });
            } else {
                sum += 1;
                $("#ddl_unidad").css({ "border-color": "#868e96" });
            }

            if ($("#ddl_resultado").val() == 0) {
                $("#ddl_resultado").css({
                    "border-color": "red"
                });
            } else {
                sum += 1;
                $("#ddl_resultado").css({ "border-color": "#868e96" });
            }
            if ($("#ddl_muestra").val() == 0) {
                $("#ddl_muestra").css({
                    "border-color": "red"
                });
            } else {
                sum += 1;
                $("#ddl_muestra").css({ "border-color": "#868e96" });
            }
            if ($("#ddl_bac").val() == 0) {
                $("#ddl_bac").css({
                    "border-color": "red"
                });
            } else {
                sum += 1;
                $("#ddl_bac").css({ "border-color": "#868e96" });
            }

            return sum;
        }
    </script>
    <%----------------------------------- DELETE PRUEBA -----------------------------------------%>
    <script>

        function Seleccion(id_prueba, PRU_COD, PRU_DESC) {
            IDDPrueba = id_prueba
            $("#Btn_Modificar_modal").attr("disabled", false);
            $("#Btn_inter_ref_modal").attr("disabled", false);
            $("#Btn_Eliminar_modal").attr("disabled", false);
            Ajax_Tabla_Refer();
            $("#modalRefer").show();

            $("#txtDeterminaCodEstudio").val(PRU_COD);
            $("#txtDeterminaDescEstudio").val(PRU_DESC);
        }

        var numerin = 0
        function Ajax_Eliminar_Prueba() {
            modal_show();
            var Data_Par = JSON.stringify({
                "ID_PRUEBA": IDDPrueba,

            });


            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_DELETE_PRUEBA",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        let cant_det = $("#txt_Dete").val()
                        numerin = JSON.parse(json_receiver);
                        Hide_Modal();
                        Ajax_Actualizar_Cant_Det(cant_det - 1)
                        Ajax_Delete_Formato(IDDPrueba);
                        Ajax_Tabla_Determinacion();
                    } else {
                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();
                    }
                    $("#Id_Conte").show();
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }

        function Ajax_Delete_Formato(ID_PRUEBA) {

            var Data_Par = JSON.stringify({
                "ID_PRUEBA": ID_PRUEBA
            });

            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_WEBF_DELETE_FORMATO_RESULTADO",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
    </script>
    <%----------------------------------- UPDATE ------------------------------------------------%>
    <script>
        var numerin = 0

        async function Ajax_Update_Prueba() {
            let estado = 0
            let solicitado = 1
            let cero = 0
            let rpv = 0
            let punto = 0

            modal_show();

            let fecha = moment().format('YYYY-MM-DD HH:mm:ss.SSS')
            typeof (fecha)

            let user = parseInt(getCookie('ID_USER'));
            for (let i = 0; i < Mx_Pruebas.length; i++) {
                if ($("#activo" + i).is(':checked')) {
                    estado = 1
                } else {
                    estado = 3
                }

                if ($("#solic" + i).is(':checked')) {
                    solicitado = 1
                } else {
                    solicitado = 0
                }

                if ($("#cero" + i).is(':checked')) {
                    cero = 1
                } else {
                    cero = 0
                }

                if ($("#rpv" + i).is(':checked')) {
                    rpv = 1
                } else {
                    rpv = 0
                }

                if ($("#punto" + i).is(':checked')) {
                    punto = 1
                } else {
                    punto = 0
                }

                if (Mx_Pruebas[i].PRU_COD != $("#txt_cod_prueba" + i).val() ||
                    Mx_Pruebas[i].PRU_DESC != $("#txt_desc_prueba" + i).val() ||
                    Mx_Pruebas[i].PRU_ORDEN != $("#txt_orden_prueba" + i).val() ||
                    Mx_Pruebas[i].PRU_DECIMAL != $("#txt_decimal_prueba" + i).val() ||
                    Mx_Pruebas[i].ID_U_MEDIDA != $("#ddl_unidad" + i).val() ||
                    Mx_Pruebas[i].ID_TP_RESULTADO != $("#ddl_resultado" + i).val() ||
                    Mx_Pruebas[i].ID_T_MUESTRA != $("#ddl_muestra" + i).val() ||
                    Mx_Pruebas[i].ID_TP_BAC != $("#ddl_bac" + i).val() ||
                    Mx_Pruebas[i].PRU_SOLICITADO != solicitado ||
                    Mx_Pruebas[i].ID_ESTADO != estado ||
                    Mx_Pruebas[i].PRU_P_CERO != cero ||
                    Mx_Pruebas[i].REQ_RES_VAL != rpv ||
                    Mx_Pruebas[i].PRU_P_PUNTO != punto
                ) {

                    let desc_corta = ($("#txt_desc_prueba" + i).val()).toUpperCase()
                    let corta = ""
                    if (desc_corta.length > 5) {
                        corta = desc_corta.substring(0, 6)
                    } else {
                        corta = desc_corta
                    }
                    let Data_Par = JSON.stringify({

                        "ID_PRUEBA": Mx_Pruebas[i].ID_PRUEBA,
                        "COD_P": $("#txt_cod_prueba" + i).val(),
                        "DESC_P": ($("#txt_desc_prueba" + i).val()).toUpperCase(),
                        "CORTO_P": corta,
                        "ID_UM_P": $("#ddl_unidad" + i).val(),
                        "ID_TP_RESUL_P": $("#ddl_resultado" + i).val(),
                        "ID_T_MUESTRA": $("#ddl_muestra" + i).val(),
                        "ID_TP_BAC": $("#ddl_bac" + i).val(),
                        "ID_PER": IDD,
                        "ORDEN_P": $("#txt_orden_prueba" + i).val(),
                        "SOLICITADOL_P": solicitado,
                        "ID_USUARIO_P": user,
                        "FECHA_M": fecha,
                        "ID_ESTADO": estado,
                        "NUM_DEC": $("#txt_decimal_prueba" + i).val(),
                        "PRU_P_CERO": cero,
                        "REQ_RES_VAL": rpv,
                        "PRU_P_PUNTO": punto,
                    });

                    Ajax_Upate_Prueba_continuacion(Data_Par, parseInt($("#ddl_unidad" + i).val()), $("#txt_desc_prueba" + i).val(), Mx_Pruebas[i].PRU_DESC, Mx_Pruebas[i].ID_PRUEBA)
                }
                await sleep(500)
            }
            Hide_Modal();


        }

        function Ajax_Upate_Prueba_continuacion(Data_Par, unidad, texto, textoAnterior, prueba) {

            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_WEBF_UPDATE_PRUEBA",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        Ajax_Update_Formato(unidad, texto, textoAnterior, prueba);
                        numerin = JSON.parse(json_receiver);
                        Hide_Modal();
                        Ajax_Tabla_Determinacion();
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No ha ocurrido actualización.");
                        $("#mError_AAH").modal();
                    }
                    $("#Id_Conte").show();
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }

        function Ajax_Update_Formato(unidad, texto, textoAnterior, prueba) {


            let selected = Mx_unidad.find(element => element.ID_U_MEDIDA === unidad)

            var Data_Par = JSON.stringify({

                "FR_OBJETO": "Iris_Nombre",
                "FR_TEXTO": texto.toUpperCase(),
                "FR_TEXTOANT": textoAnterior,
                "FR_UNIDAD": (selected.UM_DESC),
                "ID_PRUEBA": prueba

            });



            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_WEBF_UPDATE_FORMATO_RESULTADO",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }

        function Ajax_Actualizar_Cant_Det(determinaciones) {
            modal_show();
            var Data_Par = JSON.stringify({
                "ID_PER": IDD,
                "DET": determinaciones,
            });

            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_UPDATE_DETERMINACIONES_PERFIL",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        Hide_Modal();
                        Ajax_Tabla()
                    } else {
                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No ha ocurrido actualización.");
                        $("#mError_AAH").modal();
                    }
                    $("#Id_Conte").show();
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                }
            });
        }

    </script>
    <%----------------------------------- ADD ---------------------------------------------------%>
    <script>
        var numerin = 0

        async function Add_Prueba(actual, indice, inicio) {

            let cant_add = actual - indice
            let user = parseInt(getCookie('ID_USER'));
            let orden = inicio

            if (cant_add > 1) {

                for (let i = 0; i < cant_add - 1; i++) {
                    indice++
                    orden = orden + 5

                    let Data_Par = JSON.stringify({
                        "COD_P": codigo_per + "-" + indice,
                        "DESC_P": "CAMPO-" + indice,
                        "CORTO_P": "CAMPO-",
                        "ID_UM_P": 1,
                        "ID_TP_RESUL_P": 1,
                        "ID_T_MUESTRA": 1,
                        "ID_TP_BAC": 1,
                        "ID_PER": IDD,
                        "ORDEN_P": orden,
                        "SOLICITADOL_P": 1,
                        "ID_USUARIO_P": user,
                        "ID_ESTADO": 1,
                        "NUM_DEC": 0,
                        "HOST_P": 0,
                        "PRU_P_CERO": 0,
                        "REQ_RES_VAL": 0,
                        "PRU_P_PUNTO": 0,
                    });
                    Ajax_Add_Prueba(Data_Par, ("CAMPO-" + indice), 1)
                    sleep(500)
                }
                indice++
                orden = orden + 5
                let Data_Par = JSON.stringify({
                    "COD_P": codigo_per + "-" + indice,
                    "DESC_P": "OBSERVACION",
                    "CORTO_P": "OBSERV",
                    "ID_UM_P": 1,
                    "ID_TP_RESUL_P": 1,
                    "ID_T_MUESTRA": 1,
                    "ID_TP_BAC": 1,
                    "ID_PER": IDD,
                    "ORDEN_P": orden,
                    "SOLICITADOL_P": 0,
                    "ID_USUARIO_P": user,
                    "ID_ESTADO": 1,
                    "NUM_DEC": 0,
                    "HOST_P": 0,
                    "PRU_P_CERO": 0,
                    "REQ_RES_VAL": 0,
                    "PRU_P_PUNTO": 0,
                });
                Ajax_Add_Prueba(Data_Par, "OBSERVACION", 1)
                sleep(500)
            } else {
                indice++
                orden = orden + 5
                let Data_Par = JSON.stringify({
                    "COD_P": codigo_per + "-" + indice,
                    "DESC_P": "OBSERVACION",
                    "CORTO_P": "OBSERVACION",
                    "ID_UM_P": 1,
                    "ID_TP_RESUL_P": 1,
                    "ID_T_MUESTRA": 1,
                    "ID_TP_BAC": 1,
                    "ID_PER": IDD,
                    "ORDEN_P": orden,
                    "SOLICITADOL_P": 0,
                    "ID_USUARIO_P": user,
                    "ID_ESTADO": 1,
                    "NUM_DEC": 0,
                    "HOST_P": 0,
                    "PRU_P_CERO": 0,
                    "REQ_RES_VAL": 0,
                    "PRU_P_PUNTO": 0,
                });
                Ajax_Add_Prueba(Data_Par, "OBSERVACION", 1)
                sleep(500)
            }
            Ajax_Tabla_Determinacion();
        }

        function getCookie(c_name) {
            if (document.cookie.length > 0) {
                c_start = document.cookie.indexOf(c_name + "=");
                if (c_start !== -1) {
                    c_start = c_start + c_name.length + 1;
                    c_end = document.cookie.indexOf(";", c_start);
                    if (c_end === -1)
                        c_end = document.cookie.length;

                    // Reemplaza unescape con decodeURIComponent
                    return decodeURIComponent(document.cookie.substring(c_start, c_end));
                }
            }
            return "";
        }

        function Ajax_Add_Prueba(Data_Par, texto, unidad) {

            modal_show();

            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_WEBF_GRABA_PRUEBA",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        let prueba = json_receiver[0].ID_PRUEBA

                        Hide_Modal();

                        Ajax_find_formato(texto, unidad, prueba);
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No ha ocurrido actualización.");
                        $("#mError_AAH").modal();
                    }
                    $("#Id_Conte").show();
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }

        function Ajax_find_formato(texto, unidad, prueba) {

            var Data_Par = JSON.stringify({

                "COD_P": codigo_per,
                "ID_PER": IDD,

            });

            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_WEBF_BUSCA_FORMATO",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != null) {

                        IDDFormato = json_receiver[0].ID_FORMATO

                        Graba_Formato(IDDFormato, texto, unidad, prueba)

                        Hide_Modal();
                    } else {

                        Hide_Modal();

                    }
                    $("#Id_Conte").show();
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }

    </script>
    <%----------------------------------- ADD FORMATO RESULTADO ---------------------------------%>
    <script>

        async function Graba_Formato(id_formato, texto, unidad, prueba) {

            //ETIQUETA
            let ID_FORMATO = id_formato
            let FR_ID_OBJETO = getSecondsToday().toString()
            let id_prueba = prueba
            let FR_ALTO = 140
            let i = 0
            let ID_LETRA = 1
            let FR_EFECTO = ""
            let FR_DINAMICA = 0
            let FR_DEPENDENCIA = 1
            let ID_ESTADO = 1

            modal_show();
            let selected = Mx_unidad.find(element => element.ID_U_MEDIDA === unidad)
            i++
            Ajax_Graba_Formato(ID_FORMATO, "Iris_Nombre", FR_ID_OBJETO, Fr_Fila(i, FR_ALTO), 300, FR_ALTO, 1850, texto, ID_LETRA, 9, FR_EFECTO, FR_DINAMICA, FR_DEPENDENCIA, id_prueba, ID_ESTADO)
            await sleep(200)
            i++
            Ajax_Graba_Formato(ID_FORMATO, "Iris_Nombre", FR_ID_OBJETO, Fr_Fila(i, FR_ALTO), 3300, FR_ALTO, 160, ":", ID_LETRA, 9, FR_EFECTO, FR_DINAMICA, FR_DEPENDENCIA, id_prueba, ID_ESTADO)
            await sleep(200)
            i++
            Ajax_Graba_Formato(ID_FORMATO, "Iris_Det", FR_ID_OBJETO, Fr_Fila(i, FR_ALTO), 3450, FR_ALTO, 2410, texto, ID_LETRA, 9, FR_EFECTO, FR_DINAMICA, FR_DEPENDENCIA, id_prueba, ID_ESTADO)
            await sleep(200)
            i++
            Ajax_Graba_Formato(ID_FORMATO, "Iris_Unidad", FR_ID_OBJETO, Fr_Fila(i, FR_ALTO), 2700, FR_ALTO, 700, selected.UM_DESC, ID_LETRA, 9, FR_EFECTO, FR_DINAMICA, FR_DEPENDENCIA, id_prueba, ID_ESTADO)
            await sleep(200)
            i++
            Ajax_Graba_Formato(ID_FORMATO, "Iris_Rango", FR_ID_OBJETO, Fr_Fila(i, FR_ALTO), 6200, FR_ALTO, 700, texto, ID_LETRA, 9, FR_EFECTO, FR_DINAMICA, FR_DEPENDENCIA, id_prueba, ID_ESTADO)
            await sleep(200)
            i++
            Ajax_Graba_Formato(ID_FORMATO, "Iris_RHisto", FR_ID_OBJETO, Fr_Fila(i, FR_ALTO), 7000, FR_ALTO, 700, texto, ID_LETRA, 9, FR_EFECTO, FR_DINAMICA, FR_DEPENDENCIA, id_prueba, ID_ESTADO)
            await sleep(200)
            i++
            Ajax_Graba_Formato(ID_FORMATO, "Iris_FHisto", FR_ID_OBJETO, Fr_Fila(i, FR_ALTO), 7800, FR_ALTO, 700, texto, ID_LETRA, 9, FR_EFECTO, FR_DINAMICA, FR_DEPENDENCIA, id_prueba, ID_ESTADO)
            await sleep(200)
            Hide_Modal();
        }

        function Fr_Fila(num_ant, alto) {
            let FR_FILA = 2040
            if (num_ant === 1) {
                return FR_FILA
            } else {
                FR_FILA = (2040 + (alto * (num_ant) - 1)) - (num_ant * 2.5)
                return FR_FILA
            }
        }

        function getSecondsToday() {
            let now = new Date();

            // creamos un objeto que contenga el día/mes/año actual
            let today = new Date(now.getFullYear(), now.getMonth(), now.getDate());

            let diff = now - today; // diferencia entre fechas, representado en ms
            return Math.round(diff / 1000); // pasaje a segundos
        }

        function sleep(ms) {
            return new Promise(resolve => setTimeout(resolve, ms));
        }

        function Ajax_Graba_Formato(ID_FORMATO, FR_OBJETO, FR_ID_OBJETO, FR_FILA, FR_COLUMNA, FR_ALTO, FR_ANCHO, FR_TEXTO, ID_LETRA, FR_TAMANO, FR_EFECTO, FR_DINAMICA, FR_DEPENDENCIA, ID_PRUEBA, ID_ESTADO) {

            var Data_Par = JSON.stringify({

                "ID_FORMATO": ID_FORMATO,
                "FR_OBJETO": FR_OBJETO,
                "FR_ID_OBJETO": FR_ID_OBJETO,
                "FR_FILA": FR_FILA,
                "FR_COLUMNA": FR_COLUMNA,
                "FR_ALTO": FR_ALTO,
                "FR_ANCHO": FR_ANCHO,
                "FR_TEXTO": FR_TEXTO,
                "ID_LETRA": ID_LETRA,
                "FR_TAMANO": FR_TAMANO,
                "FR_EFECTO": FR_EFECTO,
                "FR_DINAMICA": FR_DINAMICA,
                "FR_DEPENDENCIA": FR_DEPENDENCIA,
                "ID_PRUEBA": ID_PRUEBA,
                "ID_ESTADO": ID_ESTADO,
            });


            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_WEBF_GRABA_FORMATO_RESULTADO",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                    }
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }

    </script>


    <%-- ////////////////////////////// DE AQUI PARA ABAJO EMPIEZA EL MODAL REFER ////////////////////////////// --%>

    <%--  AJAX MANTENEDOR DE SEXO --%>
    <script>
        var Mx_sexo = [
            {
                "ID_SEXO": 0,
                "SEXO_COD": 0,
                "SEXO_DESC": 0,
                "ID_ESTADO": 0,
            }
        ];

        //Llenar DropDownList DE SEXO
        function Ajax_Ddl_Mantenedor_sexo() {
            modal_show();

            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_WEBF_BUSCA_SEXO",
                //"data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {

                        Mx_sexo = JSON.parse(json_receiver);
                        // Ajax_Ddl_Mantenedor_Resultado()
                        Hide_Modal();
                    } else {
                        Hide_Modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);
                }
            });
        }

        function Fill_Ddl_Mantenedor_sexo(i) {
            let str = "#lstSexo" + i
            $(str).empty();
            $("<option>", { "value": 0 }).text("Seleccionar").appendTo(str);
            for (y = 0; y < Mx_sexo.length; ++y) {
                $("<option>", {
                    "value": Mx_sexo[y].ID_SEXO

                }).text(Mx_sexo[y].SEXO_DESC).appendTo(str);

            }
        };
    </script>
    <%--  AJAX BUSCA RANGO DE  REFER --%>
    <script>
        var Mx_refer = [
            {
                "ID_RF": 0,
                "ID_PRUEBA": 0,
                "ID_SEXO": 0,
                "RF_ANO_DESDE": 0,
                "RF_MESES_DESDE": 0,
                "RF_DIAS_DESDE": 0,
                "RF_ANO_HASTA": 0,
                "RF_MESES_HASTA": 0,
                "RF_DIAS_HASTA": 0,
                "RF_V_B_DESDE": 0,
                "RF_V_DESDE": 0,
                "RF_V_HASTA": 0,
                "RF_V_A_HASTA": 0,
                "RF_R_TEXTO": 0,
                "ID_ESTADO": 0,
                "RF_EMBARAZADA": 0,
                "RF_TEXTO_EXTRA": 0,
            }
        ];
        function Ajax_Tabla_Refer() {
            var Data_Par = JSON.stringify({
                "ID_DET": IDDPrueba

            });
            modal_show();

            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_BUSCA_RANGO_REFERENCIA",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    json_receiver = response.d;
                    if (json_receiver != null) {

                        Mx_refer = json_receiver;
                        /*$("#Div_Tabla_Pruebas").empty();*/
                        $("#Div_Tabla_refer").empty();
                        /* $("#Div_Tabla_Estudio_Cod_Fonasa").empty();*/
                        Fill_DataTableModal_refer()
                        Ajax_Ddl_Mantenedor_sexo()
                        Hide_Modal();

                    } else {

                        Hide_Modal();
                        /*$("#Div_Tabla_Pruebas").empty();*/
                        /*$('#eModal2').modal('hide');*/
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No se han encontrado resultados");
                        $("#mError_AAH").modal();

                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
        function Fill_DataTableModal_refer() {
            $("#Div_Tabla_refer").empty();
            $("<table>", {
                "id": "Div_Tabla_refer",
                "class": "display",
                "width": "100%",
                "cellspacing": "0"
            }).appendTo("#tabla_ref");

            $("#Div_Tabla_refer").append(
                $("<thead>"),
                $("<tbody>")
            );
            $("#Div_Tabla_refer").attr("class", "table table-hover table-striped table-iris");
            $("#Div_Tabla_refer thead").attr("class", "cabezera");
            $("#Div_Tabla_refer thead").append(
                $("<tr>").append(
                    $("<th>", { "class": "textoReducido text-center" }).text("#"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Sexo"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Año Desde"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Mes Desde"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Dia Desde"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Año Hasta"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Mes Hasta"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Dias Hasta"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Muy Bajo"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Desde"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Hasta"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Muy Alto"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Valor Texto"),
                    $("<th>", { "class": "textoReducido text-center" }).text("Embarazada")
                )
            );
            if (Mx_refer.length === 0) {
                cargar_filas_refer(0);
                Fill_Ddl_Mantenedor_sexo(0);
                $("#lstSexo" + 0).val(0);
            } else {
                for (i = 0; i < Mx_refer.length; i++) {

                    cargar_filas_refer(i);


                    if (Mx_refer[i].RF_EMBARAZADA == 1) {
                        $("#embarazada" + i).prop("checked", true);
                    }

                    Fill_Ddl_Mantenedor_sexo(i);
                    $("#txtAnoDesde" + i).val(Mx_refer[i].RF_ANO_DESDE);
                    $("#txtMesDesde" + i).val(Mx_refer[i].RF_MESES_DESDE);
                    $("#txtDiaDesde" + i).val(Mx_refer[i].RF_DIAS_DESDE);
                    $("#txtAnoHasta" + i).val(Mx_refer[i].RF_ANO_HASTA);
                    $("#txtMesHasta" + i).val(Mx_refer[i].RF_MESES_HASTA);
                    $("#txtDiaHasta" + i).val(Mx_refer[i].RF_DIAS_HASTA);
                    $("#txtMuyBajo" + i).val(Mx_refer[i].RF_V_B_DESDE);
                    $("#txtDesde" + i).val(Mx_refer[i].RF_V_DESDE);
                    $("#txtHasta" + i).val(Mx_refer[i].RF_V_HASTA);
                    $("#txtMuyAlto" + i).val(Mx_refer[i].RF_V_A_HASTA);
                    $("#txtValorTexto" + i).val(Mx_refer[i].RF_R_TEXTO);
                    $("#lstSexo" + i).val(Mx_refer[i].ID_SEXO);

                    if (i === (Mx_refer.length - 1)) {
                        cargar_filas_refer(Mx_refer.length);
                    }
                    Fill_Ddl_Mantenedor_sexo(Mx_refer.length);
                    $("#lstSexo" + Mx_refer.length).val(0);

                }
            }

            $("#Div_Tabla_refer tbody tr").click(function () {     /* <----- Pinta de color azul la tabla*/
                $("#Div_Tabla_refer tbody tr").removeClass("active");
                $(this).addClass("active");
            });
            $('#Div_Tabla_refer').dataTable({                 /* <----- Agregue esta linea de codigo que agrega un buscador para la tabla*/
                "retrieve": true,
                "iDisplayLength": false,
                "info": false,
                "bPaginate": false,
                "bFilter": true,
                "bSort": false,
                "language": {
                    "search": "<strong></i>Filtro: </strong>"
                }
            });
            //METODO PARA CARGAR FILAS DE LA TABLA REFE
            function cargar_filas_refer(ind) {
                $("#Div_Tabla_refer tbody").append(
                    $("<tr>", {
                        "onclick": `Ajax_codeguin_refer("` + Mx_refer[ind]?.ID_PRUEBA + `","` + Mx_refer[ind]?.PRU_COD + `","` + Mx_refer[ind]?.PRU_DESC + `","` + Mx_refer[ind]?.ID_RF + `","` + ind + `")`,
                        "class": "manito"
                    }).append(
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).text(ind + 1),
                        $("<td>", { "align": "center" }).css("text-align", "center",).html("<select id='lstSexo" + ind + "'></select>").on('change', 'select', function () {
                            activar_check_segun_sexo(ind, $(this).find(':selected').val());

                        }),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).html("<input type=text class='textoReducidoV2' id='txtAnoDesde" + ind + "'/>"),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).html("<input type=text class='textoReducidoV2' id='txtMesDesde" + ind + "'/>"),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).html("<input type=text class='textoReducidoV2' id='txtDiaDesde" + ind + "'/>"),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).html("<input type=text class='textoReducidoV2' id='txtAnoHasta" + ind + "'/>"),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).html("<input type=text class='textoReducidoV2' id='txtMesHasta" + ind + "'/>"),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).html("<input type=text class='textoReducidoV2' id='txtDiaHasta" + ind + "'/>"),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).html("<input type=text class='textoReducidoV2' id='txtMuyBajo" + ind + "'/>"),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).html("<input type=text class='textoReducidoV2' id='txtDesde" + ind + "'/>"),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).html("<input type=text class='textoReducidoV2' id='txtHasta" + ind + "'/>"),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).html("<input type=text class='textoReducidoV2' id='txtMuyAlto" + ind + "'/>"),
                        $("<td>", { "align": "left" }, { "class": "textoReducido" }).html("<input type=text class='textoReducidoV2' id='txtValorTexto" + ind + "'/>"),
                        $("<td>").css("text-align", "center").html("<input type='checkbox' id='embarazada" + ind + "' disabled='" + (Mx_refer[i]?.ID_SEXO === 2 ? false : true) + "' />")
                    )
                );
            }
        }
        // FUNCION PARA VALIDAR SELECT SEXO
        function activar_check_segun_sexo(ind, selectedValue) {

            let checkbox = $("#embarazada" + ind);

            if (selectedValue === '2') {
                $('#embarazada' + ind).removeAttr('disabled', false)

            } else {
                $('#embarazada' + ind).attr('disabled', true)
                $('#embarazada' + ind).attr('checked', false)
            }
        }
        //FUNCIÓN PARA VALIDAR INPUT RAN REFE
        function Validar_Input_Refer() {

            let ind;
            if (Mx_refer.length === 0) {
                ind = 0;
            } else {
                ind = Mx_refer.length;
            }

            if ($("#txtAnoDesde" + ind).val() === "" ||
                $("#txtMesDesde" + ind).val() === "" ||
                $("#txtDiaDesde" + ind).val() === "" ||
                $("#txtAnoHasta" + ind).val() === "" ||
                $("#txtMesHasta" + ind).val() === "" ||
                $("#txtDiaHasta" + ind).val() === "" ||
                $("#txtMuyBajo" + ind).val() === "" ||
                $("#txtDesde" + ind).val() === "" ||
                $("#txtHasta" + ind).val() === "" ||
                $("#txtMuyAlto" + ind).val() === "" ||
                $("#txtValorTexto" + ind).val() === "" ||
                $("#lstSexo" + Mx_refer.length).val() === 0) {
                return 0
            } else {
                return 1
            }
        }
    </script>
    <%--  AJAX CODEGUIN REFER --%>
    <script>
        function Ajax_codeguin_refer(ID_PRUEBA, PRU_COD, PRU_DESC, ID_RF, INDICE) {


            if (ID_PRUEBA === 'undefined') { //Si llega undefined significa que se selecciono la fila para guardar una nuevo rango de referencia

                $("#btnGuardarRanRef").attr("disabled", false);
                $("#btnModificarRanRef").attr("disabled", true);
                $("#btnEliminarRanRef").attr("disabled", true);
                INDICE_REF = INDICE
            } else {
                IDDPrueba = ID_PRUEBA
                IDD_RF = ID_RF;
                INDICE_REF = INDICE;
                $("#btnGuardarRanRef").attr("disabled", true);
                $("#btnModificarRanRef").attr("disabled", false);
                $("#btnEliminarRanRef").attr("disabled", false);
            }

        }
    </script>


    <%------------------------------------- AJAX REFER ---------------------------------------------%>
    <script>


        function Ajax_Update_Refer() {
            //AJAX NEW

            let embaraCheck = "";
            if ($('#embarazada' + INDICE_REF).is(':checked')) {
                embaraCheck = 1
            } else {
                embaraCheck = 0
            }

            var Data_Par = JSON.stringify({
                "ID_RF": IDD_RF,
                "ID_SEXO": $('#lstSexo' + INDICE_REF).val(),
                "ANO_DESDE": $('#txtAnoDesde' + INDICE_REF).val(),
                "MES_DESDE": $('#txtMesDesde' + INDICE_REF).val(),
                "DIAS_DESDE": $('#txtDiaDesde' + INDICE_REF).val(),
                "ANO_HASTA": $('#txtAnoHasta' + INDICE_REF).val(),
                "MES_HASTA": $('#txtMesHasta' + INDICE_REF).val(),
                "DIAS_HASTA": $('#txtDiaHasta' + INDICE_REF).val(),
                "MBAJO": $('#txtMuyBajo' + INDICE_REF).val(),
                "BAJO": $('#txtDesde' + INDICE_REF).val(),
                "ALTO": $('#txtHasta' + INDICE_REF).val(),
                "MALTO": $('#txtMuyAlto' + INDICE_REF).val(),
                "TEXTO": $('#txtValorTexto' + INDICE_REF).val(),
                "EMBARA": embaraCheck
            });

            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_UPDATE_RANGO_REFERENCIA",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        numerin = JSON.parse(json_receiver);
                        accion = 3;
                        alerta_Proc_Correctos();
                        Ajax_Limpiar();
                        Ajax_Tabla_Refer();
                    } else {
                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No ha ocurrido actualización.");
                        $("#mError_AAH").modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });

        }

        function Ajax_Graba_Refer() {

            let ind = Mx_refer.length;

            let embaraCheck = "";
            if ($('#embarazada' + ind).is(':checked')) {
                embaraCheck = 1
            } else {
                embaraCheck = 0
            }
            let user_metodo = Galletas.getGalleta("ID_USER");

            var Data_Par = JSON.stringify({
                "ID_PRUEBA": IDDPrueba,
                "ID_SEXO": $('#lstSexo' + ind).val(),
                "ANO_DESDE": $('#txtAnoDesde' + ind).val(),
                "MES_DESDE": $('#txtMesDesde' + ind).val(),
                "DIAS_DESDE": $('#txtDiaDesde' + ind).val(),
                "ANO_HASTA": $('#txtAnoHasta' + ind).val(),
                "MES_HASTA": $('#txtMesHasta' + ind).val(),
                "DIAS_HASTA": $('#txtDiaHasta' + ind).val(),
                "MBAJO": $('#txtMuyBajo' + ind).val(),
                "BAJO": $('#txtDesde' + ind).val(),
                "ALTO": $('#txtHasta' + ind).val(),
                "MALTO": $('#txtMuyAlto' + ind).val(),
                "TEXTO": $('#txtValorTexto' + ind).val(),
                "EMBARA": embaraCheck,
                "ID_USUARIO": user_metodo
            });
            ///FALTA ADD
            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_GRABA_RANGO_REFERENCIA",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        numerin = JSON.parse(json_receiver);
                        accion = 2;
                        alerta_Proc_Correctos();
                        Ajax_Limpiar();
                        Ajax_Tabla_Refer();
                        //Hide_Modal()
                        /* Ajax_Tabla_Determinacion();*/
                    } else {

                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No ha ocurrido actualización.");
                        $("#mError_AAH").modal();
                    }
                    $("#Id_Conte").show();
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }

        function Ajax_Quita_Refer() {
            var Data_Par = JSON.stringify({
                "ID_RF": IDD_RF,
            });
            console.log(Data_Par)
            $.ajax({
                "type": "POST",
                "url": "Estudio_Crea_Modifica.aspx/IRIS_QUITA_RANGO_REFERENCIA",
                "data": Data_Par,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": function (response) {
                    var json_receiver = response.d;
                    if (json_receiver != "null") {
                        numerin = JSON.parse(json_receiver);
                        accion = 4;
                        alerta_Proc_Correctos();
                        Ajax_Limpiar();
                        Ajax_Tabla_Refer();
                    } else {
                        Hide_Modal();
                        $("#mError_AAH h4").text("Sin resultados");
                        $("#mError_AAH button").attr("class", "btn btn-danger");
                        $("#mError_AAH p").text("No ha ocurrido actualización.");
                        $("#mError_AAH").modal();
                    }
                    $(".block_wait").fadeOut(500);
                },
                "error": function (response) {
                    var str_Error = response.responseJSON.ExceptionType + "\n \n";
                    str_Error = response.responseJSON.Message;
                    alert(str_Error);

                }
            });
        }
    </script>

    <%------------------------------------ALERTAS--------------------------------------------------%>
    <script>
        function Alertas_Accion(action, modulo, nombreModulo) {
            let texto = '';
            switch (action) {
                case 1:
                    texto = '¿Estas seguro de actualizar ' + modulo + '?';
                    break;
                case 2:
                    texto = '¿Estas seguro de eliminar ' + modulo + '?';
                    break;

            };
            return Swal.fire({
                toast: false,
                icon: 'warning',
                text: texto,
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Si',
                cancelButtonText: 'Cancelar'
            }
            ).then((result) => {
                if (result['isConfirmed']) {

                    switch (action) {
                        case 1:
                            if (nombreModulo === 'referencia') {
                                //ACTUALIZACION REFERENCIA
                                Ajax_Update_Refer();
                            } else if (nombreModulo === 'prueba') {
                                //ACTUALIZACION PRUEBA
                                Ajax_Update_Prueba()
                            } else if (nombreModulo === 'estudio') {
                                Ajax_Update1();
                            }

                            break;
                        case 2:
                            if (nombreModulo === 'referencia') {
                                //ELIMINAR REFERENCIA
                                Ajax_Quita_Refer();
                            } else if (nombreModulo === 'prueba') {
                                //ELIMINAR PRUEBA
                                Ajax_Eliminar_Prueba();
                            } else if (nombreModulo === 'estudio') {
                                Ajax_Delete_Prueba();
                            }
                            break;

                    }

                }
            })

        }
    </script>
    <%----------------------------------- ESTILOS DE LA PAGINA ----------------------------------%>
    <style>
        .manito {
            cursor: pointer;
        }

        .progress-bar.animate {
            width: 100%;
        }

        #DataTable tbody td {
            text-transform: uppercase;
        }

        #DataTable_Ate tbody td {
            text-transform: uppercase;
        }

        #DataTable_Lis_Exa_Ate tbody td {
            text-transform: uppercase;
        }

        .mrgn {
            margin-left: 20px;
            margin-right: 20px;
        }

        #btnFichaAcceso {
            margin-bottom: 1vh;
        }

        #i {
            display: flex;
            flex-flow: row nowrap;
        }

        .cabezera {
            background: #46963f;
            color: white;
        }

        .textoReducido {
            font-size: 12px;
        }

        .textoReducidoV2 {
            font-size: 10px;
        }

        .highlights {
            width: 710px;
            height: 300px; /* Ancho y alto fijo */
            overflow: auto; /* Se oculta el contenido desbordado */
            /* background-color: #efefef;*/
            /*border: 2px solid #46963f;*/
        }

        /*.highlights2 {
            width: 710px;
            height: 404px;*/ /* Ancho y alto fijo */
        /*overflow: auto;*/ /* Se oculta el contenido desbordado */
        /*}*/

        /*.row {*/ /* Le agregue esto para que se vea mas ordenado */
        /*margin: 1px;
        }*/
        .rowPrimeraFila {
            margin: 4px;
        }

        .rowBotones {
            margin: 4px;
        }

        #ddl_Seccion {
            width: 100%;
            font-size: 12px;
        }

        .check {
            width: 30px;
            height: 30px;
        }

        .papa-input {
            display: flex;
            align-content: center;
            text-align: center;
            flex-direction: row;
            justify-content: flex-start;
            align-items: center;
        }

        .form-check-input {
            width: 10%;
            height: 15px;
            padding: 0;
            margin: 0;
        }

        .border-bar {
            border-top: none;
            margin: -2px;
        }

        #modal-mod {
            margin: -1px
        }

        .btn-sq-lg {
            width: 100px !important;
            height: 100px !important;
        }

        .card-header {
            margin: -1px;
        }

        @media screen and (max-width: 600px) {
            .flexon {
                display: flex;
                flex-flow: column;
                width: 90vw;
            }

            .flx {
                flex: 1;
                max-width: 100%;
            }

            .highlights {
                height: 100%;
            }

            .buttons {
                display: flex;
                flex-flow: column;
            }

            #Btn_Buscar_x_ate {
                width: 90vw;
                margin-left: -12px;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cph_Body" runat="server">
        <!--------------------------------------------- MODAL DE LAS ALERTAS -------------------------------------->
    <div id="mError_AAH" class="modal fade" role="dialog">
        <div class="modal-dialog modal-sm">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Error</h4>
                </div>
                <div class="modal-body">
                    <p>AAAHAHHHHH</p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid">
        <%--------------------------------------------- TITULO GRANDE --------------------------------------------%>
        <div class="card mb-3 border-bar">
            <div class="card-header bg-bar">
                <h5 class="text-center"><i class="fa fa-fw fa-info"></i>Información de Estudios Clínicos</h5>
            </div>
            <%--------------------------------------------- PRIMERA FILA ---------------------------------------------%>
            <div class="rowPrimeraFila">
                <div class="row mb-3">
                    <div class="col-sm-2">
                        <label for="txt_cod">Código</label>
                        <input type="text" id="txt_cod" class="form-control" required="" />
                    </div>
                    <div class="col-sm-4">
                        <label for="txt_des">Descripción</label>
                        <input type="text" id="txt_des" class="form-control" required="" />
                    </div>
                    <div class="col-sm-2">
                        <label for="txtdes_cor">Desc. Corta</label>
                        <input type="text" id="txtdes_cor" class="form-control" required="" />
                    </div>
                    <div class="col-sm-2">
                        <label for="txt_ndias">N° Dete.</label>
                        <input type="number" id="txt_Dete" class="form-control" required="" />
                    </div>
                    <div class="col-sm-2">
                        <label for="Ddl_Mantenedor">Estado:</label>
                        <select id="Ddl_Mantenedor" class="form-control textoReducido mayus">
                        </select>
                    </div>
                </div>
                <%--------------------------------------------- SEGUNDA FILA ---------------------------------------------%>
                <div class="row mb-3">
                    <div class="col-sm">
                        <label for="txt_ndias">HOST (1)</label>
                        <input type="number" id="txt_Host1" class="form-control" required="" />
                    </div>
                    <div class="col-sm">
                        <label for="txt_ndias">HOST (2)</label>
                        <input type="number" id="txt_Host2" class="form-control" required="" />
                    </div>

                    <div class="col-sm">
                        <label for="ddl_agr">Seccion</label>
                        <select id="ddl_Seccion" class="form-control"></select>
                    </div>
                    <div class="col-sm">
                        <label for="chk_imp_sel_bacterio">Contar Bacterio</label>
                        <div class="form-check papa-input" id="div_chk">
                            <input class="form-check-input" type="checkbox" value="0" id="chk_imp_sel_prueba" />
                            ACTIVO
                        </div>
                    </div>
                </div>
            </div>
            <%--------------------------------------------- DIV DE LA TABLA ------------------------------------------%>
            <div class="row">
                <div class="col-sm">
                    <div id="Div_Tabla" style="width: 100%; height: 300px" class="highlights"></div>
                </div>
            </div>
            <%--------------------------------------------- PARTE DE LOS BOTONES -------------------------------------%>
            <div class="rowBotones">
                <hr />
                <div class="row">
                    <div class="col-sm">
                        <button id="Btn_limpiar" class="btn btn-buscar btn-block" style="padding: 3px;" type="submit">Limpiar <i class="fa fa-fw fa-eraser mr-2" aria-hidden="true"></i></button>
                    </div>
                    <div class="col-sm">
                        <button id="Btn_Guardar" class="btn btn-primary btn-block" style="padding: 3px;" type="submit">Guardar <i class="fa fa-save" aria-hidden="true"></i></button>
                    </div>
                    <div class="col-sm">
                        <button id="Btn_Modificar" class="btn btn-warning btn-block" style="padding: 3px;" type="submit">Modificar <i class="fa fa-edit" aria-hidden="true"></i></button>
                    </div>
                    <div class="col-sm">
                        <button id="Btn_Eliminar" class="btn btn-danger btn-block" style="padding: 3px;" type="submit">Eliminar <i class="fa fa-fw fa-remove mr-2" aria-hidden="true"></i></button>
                    </div>
                    <div class="col-sm">
                        <button id="Btn_Excel" class="btn btn-success btn-block" style="padding: 3px;" type="submit">Excel <i class="fa fa-eject" aria-hidden="true"></i></button>
                    </div>
                    <div class="col-sm">
                        <button type="button" class="btn btn-warning btn-block" style="padding: 3px" id="btn_modal_metodos"><i class="fa fa-fw fa-file-text-o mr-2"></i>Método Analítico</button>
                    </div>
                    <div class="col-sm">
                        <button type="button" class="btn btn-warning btn-block" style="padding: 3px" id="btn_modal_derivador"><i class="fa fa-fw fa-file-text-o mr-2"></i>Derivador</button>
                    </div>
                    <div class="col-sm">
                        <button type="button" class="btn btn-warning btn-block" style="padding: 3px" id="btn_modal_muestra"><i class="fa fa-fw fa-file-text-o mr-2"></i>T. Muestra De Sangre</button>
                    </div>
                    <div class="col-sm">
                        <button type="button" class="btn btn-warning btn-block" style="padding: 3px" id="btn_modal_analizador"><i class="fa fa-fw fa-file-text-o mr-2"></i>Analizador</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-------------------------------------------- PARTE DE DETERMINACIONES ASOCIADAS A UN ESTUDIO --%>
    <div class="ocultarModal" id="modalDete">
        <div class="container-fluid">
            <div class="card mb-3 border-bar">
                <div class="card-header bg-bar">
                    <%-------------------------------------------- TITULO GRANDE ------------------------------------%>
                    <h5 class="text-center"><i class="fa fa-fw fa-info"></i>Detalle de Determinaciones Asociadas a un Estudio</h5>
                </div>
                <br />
                <%-------------------------------------------- TABLA ------------------------------------%>
                <div id="Div_Tabla_Pruebas" style="width: 100%; height: 100%" class="highlights"></div>
                <%-------------------------------------------- BOTONES ---------------------------------------------%>
                <div class="rowPrimeraFila">
                    <button id="Btn_Modificar_modal" class="btn btn-warning " type="submit">Modificar <i class="fa fa-edit" aria-hidden="true"></i></button>
                    <button id="Btn_Eliminar_modal" class="btn btn-danger" type="submit">Eliminar <i class="fa fa-fw fa-remove mr-2" aria-hidden="true"></i></button>
                    <button id="Btn_inter_ref_modal" class="btn btn-success" type="submit">Inter. Refer<i class="fa fa-fw fa-remove mr-2" aria-hidden="true"></i></button>
                    <button id="Btn_Cerrar_modal_determinaciones" class="btn btn-secondary" type="submit">Salir <i class="fa fa-fw fa-remove mr-2" aria-hidden="true"></i></button>
                </div>
            </div>
        </div>
    </div>

    <%-------------------------------------------- MODAL DE MÉTODO --%>
    <div class="modal fade" id="eModal_metodos" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" style="max-width: 1400px" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <h6 style="text-align: center">Asociar Métodos a Estudios </h6>
                    <div class="row">
                        <div class="col-sm">
                            <p for="floatingInput">CODIGO ESTUDIO</p>
                            <input type="text" class="form-control" id="txtCodigoMetodoEstudio" disabled="" />
                        </div>
                        <div class="col-sm" style="grid-column: span 2">
                            <p for="floatingInput">DESCRIPCIÓN ESTUDIO</p>
                            <input type="text" class="form-control" id="txtDescripcionMetodoEstudio" disabled="" />
                        </div>
                    </div>

                    <hr />
                    <div class="row">
                        <div class="col-lg-5 mb-3" style="overflow: auto; height: 55vh; width: 100%" id="Div_Tabla_indi">
                        </div>
                        <div class="col-lg-2 mb-3">
                            <div class="row  text-center mb-3">
                                <div class="col">
                                    <a class="btn btn-sq-lg btn-primary" style="color: white" id="btn_Agregar"><b><i class="fa fa-arrow-right fa-3x"></i>
                                        <br />
                                        Agregar</b></a>
                                </div>
                            </div>
                            <div class="row  text-center">
                                <div class="col">
                                    <a class="btn btn-sq-lg btn-danger" style="color: white" id="btn_Quitar"><b><i class="fa fa-arrow-left fa-3x"></i>
                                        <br />
                                        Quitar</b></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-5 mb-3" style="overflow: auto; height: 55vh;" id="Div_Tabla_Metodo_Rel">
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" id="btnVerMetodoAnalitico">
                        <i class="fa-solid fa-down-left-and-up-right-to-center"></i>Metodo 
                    </button>
                    <button type="button" class="btn btn-secondary" id="btnSalirModal_metodos" data-bs-dismiss="modal">
                        Salir
                    </button>
                </div>
            </div>
        </div>
    </div>
    <%-------------------------------------------- MODAL DE RANGOS POR PRUEBAS--%>
    <div class="modal fade" id="rangesModal" tabindex="-1" role="dialog" aria-labelledby="rangesModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" style="max-width: 1400px" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <h6 style="text-align: center">Mantenedor de Rangos de Resultado</h6>

                    <hr />
                    <div class="row">
                        <div class="col-lg-5 mb-3" style="overflow: auto; height: 55vh; width: 100%" id="rangeDataTable">
                        </div>
                        <div class="col-lg-2 mb-3">
                            <div class="row  text-center mb-3">
                                <div class="col">
                                    <a class="btn btn-sq-lg btn-primary" style="color: white" id=""><b><i class="fa fa-arrow-right fa-3x"></i>
                                        <br />
                                        Agregar</b></a>
                                </div>
                            </div>
                            <div class="row  text-center">
                                <div class="col">
                                    <a class="btn btn-sq-lg btn-danger" style="color: white" id=""><b><i class="fa fa-arrow-left fa-3x"></i>
                                        <br />
                                        Quitar</b></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-5 mb-3" style="overflow: auto; height: 55vh;" id="Div_Tabla_derivado_Rels">
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" id="btnVerDerivado">
                        <i class="fa-solid fa-down-left-and-up-right-to-center"></i>Derivador
                    </button>
                    <button type="button" class="btn btn-secondary" id="btnSalirModal_Prue" data-bs-dismiss="modal">
                        Salir
                    </button>

                </div>
            </div>
        </div>
    </div>
    <%-------------------------------------------- MODAL DE DERIVADOS --%>
    <div class="modal fade" id="eModal_derivado" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" style="max-width: 1400px" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <h6 style="text-align: center">Asociar Laboratorio Derivador </h6>
                    <div class="row">
                        <div class="col-sm">
                            <p for="floatingInput">CODIGO ESTUDIO</p>
                            <input type="text" class="form-control" id="txtCodigoDerivadoEstudio" disabled="" />
                        </div>
                        <div class="col-sm" style="grid-column: span 2">
                            <p for="floatingInput">DESCRIPCIÓN ESTUDIO</p>
                            <input type="text" class="form-control" id="txtDescripcionDerivadoEstudio" disabled="" />
                        </div>
                    </div>

                    <hr />
                    <div class="row">
                        <div class="col-lg-5 mb-3" style="overflow: auto; height: 55vh; width: 100%" id="Div_Tabla_deri">
                        </div>
                        <div class="col-lg-2 mb-3">
                            <div class="row  text-center mb-3">
                                <div class="col">
                                    <a class="btn btn-sq-lg btn-primary" style="color: white" id="btn_Agregar_derivado"><b><i class="fa fa-arrow-right fa-3x"></i>
                                        <br />
                                        Agregar</b></a>
                                </div>
                            </div>
                            <div class="row  text-center">
                                <div class="col">
                                    <a class="btn btn-sq-lg btn-danger" style="color: white" id="btn_Quitar_derivado"><b><i class="fa fa-arrow-left fa-3x"></i>
                                        <br />
                                        Quitar</b></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-5 mb-3" style="overflow: auto; height: 55vh;" id="Div_Tabla_derivado_Rel">
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" id="btnVerDerivador">
                        <i class="fa-solid fa-down-left-and-up-right-to-center"></i>Derivador
                    </button>
                    <button type="button" class="btn btn-secondary" id="btnSalirModal_deri" data-bs-dismiss="modal">
                        Salir
                    </button>

                </div>
            </div>
        </div>
    </div>

    <%-------------------------------------------- MODAL DE MUESTRA DE SANGRE --%>
    <div class="modal fade" id="eModal_muestra" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" style="max-width: 1400px" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <h6 style="text-align: center">Asociar Tipo de Muestra de Sangre a Estudio </h6>
                    <div class="row">
                        <div class="col-sm">
                            <p for="floatingInput">CODIGO ESTUDIO</p>
                            <input type="text" class="form-control" id="txtCodigoMuestraEstudio" disabled="" />
                        </div>
                        <div class="col-sm" style="grid-column: span 2">
                            <p for="floatingInput">DESCRIPCIÓN ESTUDIO</p>
                            <input type="text" class="form-control" id="txtDescripcionMuestraEstudio" disabled="" />
                        </div>
                    </div>

                    <hr />
                    <div class="row">
                        <div class="col-lg-5 mb-3" style="overflow: auto; height: 55vh; width: 100%" id="Div_Tabla_mues">
                        </div>
                        <div class="col-lg-2 mb-3">
                            <div class="row  text-center mb-3">
                                <div class="col">
                                    <a class="btn btn-sq-lg btn-primary" style="color: white" id="btn_Agregar_muestra"><b><i class="fa fa-arrow-right fa-3x"></i>
                                        <br />
                                        Agregar</b></a>
                                </div>
                            </div>
                            <div class="row  text-center">
                                <div class="col">
                                    <a class="btn btn-sq-lg btn-danger" style="color: white" id="btn_Quitar_muestra"><b><i class="fa fa-arrow-left fa-3x"></i>
                                        <br />
                                        Quitar</b></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-5 mb-3" style="overflow: auto; height: 55vh;" id="Div_Tabla_muestra_Rel">
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" id="btnVerTPSANGRE">
                        <i class="fa-solid fa-down-left-and-up-right-to-center"></i>Tipo Musetra Sangre
                    </button>
                    <button type="button" class="btn btn-secondary" id="btnSalirModal_muestra" data-bs-dismiss="modal">
                        Salir
                    </button>
                </div>
            </div>
        </div>
    </div>
    <%-------------------------------------------- MODAL DE TIPO ANALIZADOR SANGRE --%>
    <div class="modal fade" id="eModal_analizador" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" style="max-width: 1400px" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <h6 style="text-align: center">Asociar Analizador a Estudio </h6>
                    <div class="row">
                        <div class="col-sm">
                            <p for="floatingInput">CODIGO ESTUDIO</p>
                            <input type="text" class="form-control" id="txtCodigoAnalizadorEstudio" disabled="" />
                        </div>
                        <div class="col-sm" style="grid-column: span 2">
                            <p for="floatingInput">DESCRIPCIÓN ESTUDIO</p>
                            <input type="text" class="form-control" id="txtDescripcionAnalizadorEstudio" disabled="" />
                        </div>
                    </div>

                    <hr />
                    <div class="row">
                        <div class="col-lg-5 mb-3" style="overflow: auto; height: 55vh; width: 100%" id="Div_Tabla_anal">
                        </div>
                        <div class="col-lg-2 mb-3">
                            <div class="row  text-center mb-3">
                                <div class="col">
                                    <a class="btn btn-sq-lg btn-primary" style="color: white" id="btn_Agregar_analizador"><b><i class="fa fa-arrow-right fa-3x"></i>
                                        <br />
                                        Agregar</b></a>
                                </div>
                            </div>
                            <div class="row  text-center">
                                <div class="col">
                                    <a class="btn btn-sq-lg btn-danger" style="color: white" id="btn_Quitar_analizador"><b><i class="fa fa-arrow-left fa-3x"></i>
                                        <br />
                                        Quitar</b></a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-5 mb-3" style="overflow: auto; height: 55vh;" id="Div_Tabla_anal_Rel">
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" id="btnVerAnal">
                        <i class="fa-solid fa-down-left-and-up-right-to-center"></i>Analizador
                    </button>
                    <button type="button" class="btn btn-secondary" id="btnSalirModal_analizador" data-bs-dismiss="modal">
                        Salir
                    </button>

                </div>
            </div>
        </div>
    </div>

    <%-------------------------------------------- MODAL DE INTER. REF --------------------------------------%>
    <div class="modal fade" id="eModal_ref" tabindex="-1" role="dialog" aria-labelledby="eModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" style="max-width: 1400px" role="document">
            <div class="modal-content">
                <div class="modal-body">
                    <h5 class="text-center"><i class="fa fa-fw fa-info"></i>Detalle de Determinaciones Asociadas a un Estudio</h5>
                    <h6 style="text-align: center">ANTECEDENTE DE ESTUDIO</h6>
                    <div class="row">
                        <div class="col-sm">
                            <p for="floatingInput">CODIGO ESTUDIO</p>
                            <input type="text" class="form-control" id="txtAntecedenteDescEstudio" disabled="" />
                        </div>
                        <div class="col-sm" style="grid-column: span 2">
                            <p for="floatingInput">DESCRIPCIÓN ESTUDIO</p>
                            <input type="text" class="form-control" id="txtAantecedenteCodEstudio" disabled="" />
                        </div>
                    </div>
                    <hr />
                    <h6 style="text-align: center">ANTECEDENTE DE DETERMINACION</h6>
                    <div class="row">
                        <div class="col-sm">
                            <label for="floatingInput">CODIGO DETERMINACION</label>
                            <input type="text" class="form-control" id="txtDeterminaCodEstudio" disabled="" />
                        </div>
                        <div class="col-sm" style="grid-column: span 2">
                            <label for="floatingInput">DESCRIPCIÓN DETERMINACION</label>
                            <input type="text" class="form-control" id="txtDeterminaDescEstudio" disabled="" />
                        </div>
                    </div>
                </div>
                <br />
                <%-------------------------------------------- TABLA ------------------------------------%>
                <form>
                    <div class="col-md-12">
                        <div id="tabla_ref" style="width: 100%; height: 100%; overflow: auto;" class="highlights2"></div>
                    </div>
                </form>
                <%-------------------------------------------- BOTONES ---------------------------------------------%>
                <div class="rowPrimeraFila">
                    <button type="button" class="btn btn-primary" id="btnGuardarRanRef">
                        <i class="fa-solid fa-down-left-and-up-right-to-center"></i>Guardar
                    </button>
                    <button type="button" class="btn btn-primary" id="btnModificarRanRef">
                        <i class="fa-solid fa-down-left-and-up-right-to-center"></i>Modificar
                    </button>
                    <button type="button" class="btn btn-danger" id="btnEliminarRanRef">
                        <i class="fa-solid fa-up-right-and-down-left-from-center"></i>Eliminar
                    </button>
                    <button type="button" class="btn btn-secondary" id="btnSalir" data-bs-dismiss="modal">
                        Salir
                    </button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
