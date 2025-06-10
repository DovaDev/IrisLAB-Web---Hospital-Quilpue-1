document.addEventListener('DOMContentLoaded', function () {

    Llenar_Ddl_Seccion();

    // #region VARIABLES
    let Mx_Ddl_Seccion = [];
    let Mx_Dtt_Format = [];

    let Mx_Dtt_Exam = [];
    let Mx_Dtt_Exam_Rel = [];
    let Mx_Dtt_Exam_Asoc = [];

    let Mx_Check_C = [];
    let Mx_Check_NC = [];

    let id_cf_select;
    let id_cf_rem;
    //#endregion


    //#region EVENTOS
    $('#ddl_secc').change(function () {
        Llenar_Codigos_REM();
    });


    $("#btn_Agregar").click(() => {
        Agrega_Panel();
    });

    $("#btn_Quitar").click(() => {
        Quita_Panel();
    });

    $("#btn_Guardar_Panel").click(() => {
        //   console.log("btn guarda panel");
        Guardar_Panel();
    });

    function Quita_Panel() {
        modal_show();
        let c_index = $("tr[name='p_Anti'][class='manito active']").attr("data-index");

        Mx_Check_C.forEach(aah => {
            $("tr[name='p_C'][data-index='" + aah.index + "'][data-type='" + aah.type + "']").remove();

            $("#dtt_exam tbody").append(
                $("<tr>", { "class": "manito", "name": "p_No_C", "data-index": aah.index, "data-type": aah.type }).append(
                    $("<td>").css("height", "0").text(() => {
                        if (aah.type == "No_Cargado") {
                            return Mx_Dtt_Exam.find((item) => item.ID_CODIGO_FONASA == aah.index)?.CF_COD
                        } else {
                            return Mx_Dtt_Exam_Rel.find((item) => item.ID_CODIGO_FONASA == aah.index)?.CF_COD
                        }

                    }),
                    $("<td>").css({
                        "height": "0",
                        "text-aling": "center",
                        "vertical-align": "middle"
                    }).text(() => {
                        if (aah.type == "No_Cargado") {
                            return Mx_Dtt_Exam.find((item) => item.ID_CODIGO_FONASA == aah.index)?.CF_DESC
                        } else {
                            return Mx_Dtt_Exam_Rel.find((item) => item.ID_CODIGO_FONASA == aah.index)?.CF_DESC
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
            //console.log(index+" "+checked);
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
                    //console.log(Mx_Check_NC);
                } else {
                    Mx_Check_NC.push({ "index": index, "type": type });
                    //console.log(Mx_Check_NC);
                }
            } else {
                let Mx_Index = Mx_Check_NC.findIndex(x => x.index === index && x.type === type);
                Mx_Check_NC.splice(Mx_Index, 1);
                //console.log(Mx_Check_NC);
            }
        }).one();

        Mx_Check_C = [];
        Hide_Modal();

    }

    function Agrega_Panel() {
        modal_show();
        Mx_Check_NC.forEach(aah => {
            $("tr[name='p_No_C'][data-index='" + aah.index + "'][data-type='" + aah.type + "']").remove();

            $("#dtt_exam_rel tbody").append(
                $("<tr>", { "class": "manito", "name": "p_C", "data-index": aah.index, "data-type": aah.type }).append(
                    $("<td>").css("height", "0").text(() => {
                        if (aah.type == "No_Cargado") {

                            return Mx_Dtt_Exam.find((item) => item.ID_CODIGO_FONASA == aah.index)?.CF_COD
                        } else {
                            return Mx_Dtt_Exam_Rel.find((item) => item.ID_CODIGO_FONASA == aah.index)?.CF_COD
                        }

                    }),
                    $("<td>").css("height", "0").text(Mx_Dtt_Exam.find((item) => item.ID_CODIGO_FONASA == aah.index)?.CF_DESC),
                    $("<td>").css("height", "0").html(() => {
                        return "<input type='checkbox' name='chk_Cargado'/>";
                    }),
                )
            );


        });
        $("input[name='chk_Cargado']").unbind();
        $("input[name='chk_Cargado']").click((e) => {
            //e.stopImmediatePropagation();
            let index = $(e.currentTarget).parent().parent().attr("data-index");
            let checked = $(e.currentTarget).prop("checked");
            let type = $(e.currentTarget).parent().parent().attr("data-type");
            //console.log(index+" "+checked);
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
                    //console.log(Mx_Check_C);
                } else {
                    Mx_Check_C.push({ "index": index, "type": type });
                    //console.log(Mx_Check_C);
                }
            } else {
                let Mx_Index = Mx_Check_C.findIndex(x => x === index && x.type === type);
                Mx_Check_C.splice(Mx_Index, 1);
                //console.log(Mx_Check_C);
            }
        }).one();

        Mx_Check_NC = [];
        Hide_Modal();
    }

    function Ver_Rel_Codigo() {
        $("#mdlPanel").modal("show");
    }


    function Ver_Ajuste_Codigo() {
        $("#mdlPanelAjustar").modal("show");
    }
    //#endregion

    // #region AJAX

    function Actualizar_Ajuste(id_fonasa_rem, id_cf_ex, select_opt) {

        var strParam = JSON.stringify({
            "ID_FONASAS_REM": id_fonasa_rem,
            "ID_CF_EX": id_cf_ex,
             "OPT": select_opt
        });

        $.ajax({
            "type": "POST",
            "url": "Rem.aspx/Actualizar_Ajuste",
            "data": strParam,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": data => {
                console.log(` RESPONSE: ${data.d}`);
                $("tr[name='p_Anti'][class='manito active']").trigger("click");

                //objAJAX_Get_ID_ATE.requestNow({
                //    NUM_ATE: $("#Txt_NumAte").val(),
                //    USU_ID_PROC: Galletas.getGalleta("USU_ID_PROC")
                //});

                Hide_Modal();
            },
            "error": data => {
                Hide_Modal();
            }
        });
    }

    function Guardar_Panel() {

        let NCar = [];
        let Car = [];
        let Mx_Guarda_Panel = [];

        Car = $("tr[name='p_C']");
        NCar = $("tr[name='p_No_C']");

        let c_index = $("tr[name='p_Anti'][class='manito active']").attr("data-index");
       
        // Buscar data-type Cargado
        for (let i = 0; i < Car.length; i++) {
            let _type = Car[i].getAttribute("data-type");
            let _index = Car[i].getAttribute("data-index");
            let _prev = $("#Sel_Prev").val();
            console.log(`ITEM: ${_type}`)
            console.log(`ITEM: ${_index}`)
            if (_type == "No_Cargado") {
                //console.log(_index+" "+_type);
                Mx_Guarda_Panel.push({ "ID_CF": _index, "ID_FONASA_REM_HOSP": id_cf_rem, "TYPE": "Crea" });
            }
        }

        // Buscar data-type No_Cargado
        for (let i = 0; i < NCar.length; i++) {
            let _type = NCar[i].getAttribute("data-type");
            let _index = NCar[i].getAttribute("data-index");
            let _prev = $("#Sel_Prev").val();

            if (_type == "Cargado") {
                //console.log(_index+" "+_type);
                Mx_Guarda_Panel.push({ "ID_CF": _index, "ID_FONASA_REM_HOSP": id_cf_rem, "TYPE": "Quita" });
            }
        }

        if (Mx_Guarda_Panel.length > 0) {
            console.log(Mx_Guarda_Panel);
            modal_show();
            var strParam = JSON.stringify({
                "Mx_Panel": Mx_Guarda_Panel
            });

            $.ajax({
                "type": "POST",
                "url": "Rem.aspx/Guarda_Panel_Codigo",
                "data": strParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    console.log(` RESPONSE: ${data.d}`);
                    $("tr[name='p_Anti'][class='manito active']").trigger("click");

                    //objAJAX_Get_ID_ATE.requestNow({
                    //    NUM_ATE: $("#Txt_NumAte").val(),
                    //    USU_ID_PROC: Galletas.getGalleta("USU_ID_PROC")
                    //});

                    Hide_Modal();
                },
                "error": data => {
                    Hide_Modal();
                }
            });
        }
    }

    function Llenar_Examenes_Rel(id_fonasa_rem_hosp, type) {
        modal_show();

        if (id_fonasa_rem_hosp != 0 || id_fonasa_rem_hosp != undefined) {

            var strParam = JSON.stringify({
                ID_FONASA_REM_HOSP: id_fonasa_rem_hosp
            });

            if (type == undefined) {
                return;
            }

            $.ajax({
                "type": "POST",
                "url": "Rem.aspx/Llenar_Examenes_Rel",
                "data": strParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    if (type == "ajustar") {
                        Mx_Dtt_Exam_Asoc = data.d;
                        Fill_Dtt_Exam_Asoc();

                    } else if (type == "relacionar") {
                        Mx_Dtt_Exam_Rel = data.d;

                        if (Mx_Dtt_Exam_Rel != null) {
                            Fill_Dtt_Exam_Rel();
                        }
                    }
                },
                "error": data => {
                    //Debug
                    Hide_Modal();
                }
            });
        }
    }
    function Llenar_Examenes() {
        modal_show();

        if (Mx_Ddl_Seccion.length > 0) {
            var id_ddl_secc = $("#ddl_secc").val();

            var strParam = JSON.stringify({
                ID_DDL_SECC: id_ddl_secc == undefined ? 0 : id_ddl_secc
            });

            $.ajax({
                "type": "POST",
                "url": "Rem.aspx/Llenar_Examenes",
                "data": strParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    Mx_Dtt_Exam = data.d;
                    Fill_Dtt_Exam();
                },
                "error": data => {
                    //Debug
                    Hide_Modal();
                }
            });
        }
    }

    function Llenar_Codigos_REM() {
        modal_show();

        if (Mx_Ddl_Seccion.length > 0) {
            var id_ddl_secc = $("#ddl_secc").val();

            var strParam = JSON.stringify({
                ID_DDL_SECC: id_ddl_secc == undefined ? 0 : id_ddl_secc
            });

            $.ajax({
                "type": "POST",
                "url": "Rem.aspx/Llenar_Codigos_REM",
                "data": strParam,
                "contentType": "application/json;  charset=utf-8",
                "dataType": "json",
                "success": data => {
                    //Debug
                    Mx_Dtt_Format = data.d;
                    Fill_Dtt_Format();
                },
                "error": data => {
                    //Debug
                    Hide_Modal();
                }
            });
        }
    }
    function Llenar_Ddl_Seccion() {
        $.ajax({
            "type": "POST",
            "url": "Rem.aspx/Llenar_Seccion_Rem",
            //"data": Data_Par,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": data => {
                //Debug
                Mx_Ddl_Seccion = data.d;

                Fill_Ddl_Seccion();

                Llenar_Codigos_REM();
            },
            "error": data => {
                //Debug
            }
        });
    }
    // #endregion


    // #region Llenado

    function Fill_Dtt_Exam_Select(cf_cod, cf_desc) {
        $("#row_codigo_rem tbody").empty();
        //Recorrer JSON
        const row = $("<tr>", {
            "class": "manito",
            //"id": item.ID_FONASA_REM_HOSP
        }).append(
            $("<td>").css("text-align", "left").text(cf_cod),
            $("<td>").css("text-align", "left").text(cf_desc),
        ).appendTo("#row_codigo_rem tbody");

        Hide_Modal();
    }
    function Fill_Dtt_Exam_Rel() {
        $("#dtt_exam_rel tbody").empty();
        //Recorrer JSON
        var i = 0
        Mx_Dtt_Exam_Rel.forEach(item => {
            const row = $("<tr>", {
                "class": "manito",
                "name": "p_C",
                "data-index": item.ID_CODIGO_FONASA,
                "data-type": "Cargado"
                //"id": item.ID_FONASA_REM_HOSP
            }).append(

                $("<td>").css("text-align", "center").text(item.CF_COD),
                $("<td>").css("text-align", "left").text(item.CF_DESC),
                $("<td>").css("height", "0").html(() => {
                    return "<input type='checkbox' name='chk_Cargado'/>";
                })
            ).appendTo("#dtt_exam_rel tbody");

            i += 1;
            Hide_Modal();
        });
        $("input[name='chk_Cargado']").click((e) => {
            //e.stopImmediatePropagation();
            let index = $(e.currentTarget).parent().parent().attr("data-index");
            let checked = $(e.currentTarget).prop("checked");
            let type = $(e.currentTarget).parent().parent().attr("data-type");
            console.log(index + " " + checked);
            if (checked == true) {
                if (Mx_Check_C.length > 0) {
                    let cnt = 0;
                    Mx_Check_C.forEach(item => {
                        if (item == index) {
                            cnt = 1;
                        }
                    });
                    if (cnt == 0) {
                        Mx_Check_C.push({ "index": index, "type": type });
                    }
                    console.log(Mx_Check_C);
                } else {
                    Mx_Check_C.push({ "index": index, "type": type });
                    console.log(Mx_Check_C);
                }
            } else {
                let Mx_Index = Mx_Check_C.findIndex(x => x.index === index && x.type === type);
                Mx_Check_C.splice(Mx_Index, 1);
                console.log(Mx_Check_C);
            }
        }).one();
        $("#dtt_exam_rel").DataTable({
            "bSort": false,
            "iDisplayLength": 100,
            "info": false,
            "bPaginate": false,
            "language": {
                "lengthMenu": "Mostrar: _MENU_",
                "zeroRecords": "No hay coincidencias",
                "info": "Mostrando Página _PAGE_ de _PAGES_",
                "infoEmpty": "No hay coincidencias",
                "infoFiltered": "(Se buscó en _MAX_ registros)",
                "search": "<strong><i class='fa fa-search'></i> Filtro: </strong>",
                "paginate": {
                    "previous": "Anterior",
                    "next": "Siguiente"
                }
            },
            "dom": '<"top"f>rt<"bottom"ilp><"clear">'
        });
    }
    function Fill_Dtt_Exam_Asoc() {
        $("#dtt_examenes_asoc tbody").empty();
        //Recorrer JSON
        var i = 0
        Mx_Dtt_Exam_Asoc.forEach(item => {
            const row = $("<tr>", {
                "class": "manito",
                "name": "p_C",
                "data-index": item.ID_CODIGO_FONASA,
                "data-type": "Cargado"
                //"id": item.ID_FONASA_REM_HOSP
            }).append(

                $("<td>").css("text-align", "center").text(item.CF_COD),
                $("<td>").css("text-align", "left").text(item.CF_DESC),
                $("<td>").css("height", "0").html(() => {
                    return `
                <select class="form-select" name='select_Cargado' id="select_${item.ID_CF_EX}">
                    <option value="0" data-index="0">No definido</option>
                    <option value="1" data-index="${item.ID_FONASA_REM_HOSP}">Excluir</option>
                    <option value="2" data-index="${item.ID_FONASA_REM_HOSP}">Priorizar</option>
                </select>`;
                })
            ).appendTo("#dtt_examenes_asoc tbody");

            if (item.PRIORI == 0 && item.EXCLUIR == 0) {
                $(`#select_${item.ID_CF_EX}`).val("0");
            } else {
                if (item.EXCLUIR == 1 && item.PRIORI == 0) {
                    $(`#select_${item.ID_CF_EX}`).val("1");
                }
                if (item.EXCLUIR == 0 && item.PRIORI == 1) {
                    $(`#select_${item.ID_CF_EX}`).val("2");
                }
            }

            i += 1;
            Hide_Modal();
        });

        //$("select[name='select_Cargado']").change((e) => {
        //    let index = $(e.currentTarget).parent().parent().attr("data-index");
        //    let selectedOption = $(e.currentTarget).val();
        //    let type = $(e.currentTarget).parent().parent().attr("data-type");
        //    console.log(index + " " + selectedOption);
        //});

        // Manejar el evento de cambio en los select
        $("select[name='select_Cargado']").change((e) => {
            let selectedOption = $(e.currentTarget).val();
            // Obtener el data-index del option seleccionado
            let dataIndex = $(e.currentTarget).find('option:selected').data('index');

            let selectId = $(e.currentTarget).attr('id');

            let idCFEX = selectId.split('_')[1];

            Actualizar_Ajuste(dataIndex, idCFEX, selectedOption);

            // Si selecciona 'Excluir' (1) o 'Priorizar' (2), deshabilitar los otros select
            if (selectedOption === "1" || selectedOption === "2") {
                $("select[name='select_Cargado']").not(e.currentTarget).prop("disabled", true);
            } else {
                // Si selecciona 'No definido' (0), habilitar todos los select
                $("select[name='select_Cargado']").prop("disabled", false);
            }
        });

        $("#dtt_examenes_asoc").DataTable({
            "bSort": false,
            "iDisplayLength": 100,
            "info": false,
            "bPaginate": false,
            "language": {
                "lengthMenu": "Mostrar: _MENU_",
                "zeroRecords": "No hay coincidencias",
                "info": "Mostrando Página _PAGE_ de _PAGES_",
                "infoEmpty": "No hay coincidencias",
                "infoFiltered": "(Se buscó en _MAX_ registros)",
                "search": "<strong><i class='fa fa-search'></i> Filtro: </strong>",
                "paginate": {
                    "previous": "Anterior",
                    "next": "Siguiente"
                }
            },
            "dom": '<"top"f>rt<"bottom"ilp><"clear">'
        });
    }
    function Fill_Dtt_Exam() {
        $("#dtt_exam tbody").empty();
        //Recorrer JSON
        var i = 0
        Mx_Dtt_Exam.forEach(item => {
            const row = $("<tr>", {
                "class": "manito",
                "name": "p_No_C",
                "data-index": item.ID_CODIGO_FONASA,
                "data-type": "No_Cargado"
            }).append(

                $("<td>").css("text-align", "center").text(item.CF_COD),
                $("<td>").css("text-align", "left").text(item.CF_DESC),
                $("<td>").css("height", "0").html(() => {
                    return "<input type='checkbox' name='chk_No_Cargado'/>";
                })
            ).appendTo("#dtt_exam tbody");
            i += 1;
            Hide_Modal();
        });
        $("input[name='chk_No_Cargado']").click((e) => {
            //e.stopImmediatePropagation();
            let index = $(e.currentTarget).parent().parent().attr("data-index");
            let checked = $(e.currentTarget).prop("checked");
            let type = $(e.currentTarget).parent().parent().attr("data-type");
            console.log(index + " " + checked);
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
                    console.log(Mx_Check_NC);
                } else {
                    Mx_Check_NC.push({ "index": index, "type": type });
                    console.log(Mx_Check_NC);
                }
            } else {
                let Mx_Index = Mx_Check_NC.findIndex(x => x.index === index && x.type === type);
                Mx_Check_NC.splice(Mx_Index, 1);
                console.log(Mx_Check_NC);
            }
        }).one();
        $("#dtt_exam").DataTable({
            "bSort": false,
            "iDisplayLength": 100,
            "info": false,
            "bPaginate": false,
            "language": {
                "lengthMenu": "Mostrar: _MENU_",
                "zeroRecords": "No hay coincidencias",
                "info": "Mostrando Página _PAGE_ de _PAGES_",
                "infoEmpty": "No hay coincidencias",
                "infoFiltered": "(Se buscó en _MAX_ registros)",
                "search": "<strong><i class='fa fa-search'></i> Filtro: </strong>",
                "paginate": {
                    "previous": "Anterior",
                    "next": "Siguiente"
                }
            },
            "dom": '<"top"f>rt<"bottom"ilp><"clear">'
        });

    }
    function Fill_Dtt_Format() {
        $("#Dtt_Codigos_Format tbody").empty();
        //Recorrer JSON
        var i = 1
        Mx_Dtt_Format.forEach(item => {
            const row = $("<tr>", {
                "class": "manito",
                "id": item.ID_FONASA_REM_HOSP
            }).append(
                $("<td>").css({ "text-align": "center", "font-weight": "bold" }).text(i),
                $("<td>").css("text-align", "center").text(item.CF_COD_IRIS),
                $("<td>").css("text-align", "left").text(item.CF_DESC_HOSP),
                $("<td>").css("text-align", "center").text(item.ID_ESTADO == 1 ? "Activo" : "Inactivo"),
                $("<td>").css("text-align", "center").text(item.SECC_REM_DESC),
                $("<td>").css("text-align", "center").html(function () {
                    return `<button class="btn btn-danger" id="btn_relacionar_${i}">
                                    <i class="fa fa-link"></i>
                                 </button>`;
                }),
                $("<td>").css("text-align", "center").html(function () {
                    return `<button class="btn btn-warning" id="btn_ajustar_${i}">
                                    <i class="fa fa-cogs"></i>
                                 </button>`;
                })
            ).appendTo("#Dtt_Codigos_Format tbody");

            // Evento para doble clic

            $(`#btn_relacionar_${i}`).click(function () {
                    Llenar_Examenes()
                    //id_cf_select = item.ID_CODIGO_FONASA;
                    id_cf_rem = item.ID_FONASA_REM_HOSP
                    Ver_Rel_Codigo(item.ID_FONASA_REM_HOSP); // Acción para doble clic
                    Llenar_Examenes_Rel(item.ID_FONASA_REM_HOSP, "relacionar")
                    console.log(`ITEM: ${JSON.stringify({ item })}`)
                    Fill_Dtt_Exam_Select(item.CF_COD_IRIS, item.CF_DESC_HOSP)
            });

            $(`#btn_ajustar_${i}`).click(function () {
                Ver_Ajuste_Codigo()
                //dtt_examenes_asoc
                Llenar_Examenes_Rel(item.ID_FONASA_REM_HOSP, "ajustar")
                //Llenar_Examenes_Asoc(item.ID_FONASA_REM_HOSP);
            });

            //row.dblclick(function () {
            //    Llenar_Examenes()
            //    //id_cf_select = item.ID_CODIGO_FONASA;
            //    id_cf_rem = item.ID_FONASA_REM_HOSP
            //    Ver_Rel_Codigo(item.ID_FONASA_REM_HOSP); // Acción para doble clic
            //    Llenar_Examenes_Rel(item.ID_FONASA_REM_HOSP)
            //    console.log(`ITEM: ${JSON.stringify({ item })}`)
            //    Fill_Dtt_Exam_Select(item.CF_COD_IRIS, item.CF_DESC_HOSP)
            //});

            //// Evento clic cuando uno solo
            //row.click(function () {
            //    console.log("Fila con ID " + item.ID_FONASA_REM_HOSP + " clickeada");
            //});

            i += 1;
            Hide_Modal();
        });

        $("#Dtt_Codigos_Format").DataTable({
            "bSort": false,
            "iDisplayLength": 100,
            "info": false,
            "bPaginate": false,
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
    }
    function Fill_Ddl_Seccion() {
        $("<option>", {
            "value": 0
        }).text("TODOS").appendTo("#ddl_secc");
        Mx_Ddl_Seccion.forEach(item => {
            $("<option>",
                {
                    "value": item.ID_SECC_REM
                }
            ).text(item.SECC_REM_DESC).appendTo("#ddl_secc");
        });
    }
    // #endregion
});