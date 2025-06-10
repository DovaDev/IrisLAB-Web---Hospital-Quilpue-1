
/**
 * Todo el código que necesita para que funcione el modal de editar agenda en listar paciente.
 * @param {Object} [Options={}] - El id del elemento select donde se eligen los doctores, por defecto es un string vacío.
 * @param {string} [Options.idElementoBrother=""] - El id del elemento select donde se eligen los doctores, por defecto es un string vacío.
 * @param {Array} [Options.Mx_Detalle_ate=[]] - El array con los datos del paciente que se seleccionó del listado.
 * @param {Function} [Options.Ajax_modal_exa=()=>{}] - La función que llena el modal, se pasa el pointer para llamarla al cargar un examen.
 * @param {number} [Options.idAtencion= 0] - trae el id de la atencion 
*/
const habilitarBotonEditarAgenda = async ({ ver_vih= "", idElementoBrother = "", Mx_Detalle_ate = [], idAtencion = 0 , Ajax_modal_exa = () => { } } = {}) => {


    
    if (!idElementoBrother) return;
    // poner los estilos y el botón lupa
    
    document.getElementById("btnAddExamen")?.parentElement?.remove();
    console.log("!¿", idAtencion)
    if (idAtencion != 0) {
        return 
    }
    console.log("!", idAtencion)
    const gridAntecedentes = document.createElement('div');
    gridAntecedentes.style.display = 'grid';
    gridAntecedentes.style.gridTemplateColumns = 'repeat(auto-fill, minmax(75px, 1fr))';
    gridAntecedentes.style.gridTemplateRows = 'minmax(70px, auto)';
    gridAntecedentes.style.columnGap = '1rem';
    gridAntecedentes.style.gridAutoFlow = 'dense';
    gridAntecedentes.style.marginBottom = '1rem';

    // Create the elements
    const div = document.createElement('div');
    div.className = 'col-sm';
    div.style.maxWidth = 'fit-content';
    div.style.paddingLeft = '0px';

    let button = document.createElement('button');
    button.id = 'btnAddExamen';
    button.type = 'button';
    button.className = 'btn btn-primary btn-block';
    button.style.marginTop = '0px';
    button.addEventListener("click", () => {
        ajaxExamenesPrevision();
        $('#modal-add-examenes').modal('show');
        Mx_Carga = [];
    });

    let icon = document.createElement('i');
    icon.className = 'fa fa-fw fa-plus';
    icon.setAttribute('aria-hidden', 'true');

    // Assemble the elements
    button.textContent = "Exámenes"
    button.prepend(icon);
    div.appendChild(button);

    const divDoctores = document.getElementById(idElementoBrother).parentElement;
    divDoctores.insertAdjacentElement('afterbegin', div);
    document.getElementById("modal-add-examenes")?.remove()
    // Create the main container div
    const modalContainer = document.createElement('div');
    modalContainer.classList.add('modal', 'fade');
    modalContainer.id = 'modal-add-examenes';
    modalContainer.tabIndex = '-1';
    modalContainer.setAttribute('role', 'dialog');
    modalContainer.setAttribute('aria-labelledby', 'eModalLabel');
    modalContainer.setAttribute('aria-hidden', 'true');

    // Create the modal dialog
    const modalDialog = document.createElement('div');
    modalDialog.classList.add('modal-dialog', 'modal-lg');
    modalDialog.setAttribute('role', 'document');

    // Create the modal content
    const modalContent = document.createElement('div');
    modalContent.classList.add('modal-content');

    // Create the modal header
    const modalHeader = document.createElement('div');
    modalHeader.classList.add('modal-header');

    const modalTitle = document.createElement('h4');
    modalTitle.classList.add('modal-title');
    modalTitle.id = 'sss';
    modalTitle.textContent = 'Agregar Exámenes';

    // Append the title to the header
    modalHeader.appendChild(modalTitle);

    // Create the modal body
    const modalBody = document.createElement('div');
    modalBody.classList.add('modal-body');

    // Create the form
    const form = document.createElement('form');

    // Create the col-md-12 div
    const colDiv = document.createElement('div');
    colDiv.classList.add('col-md-12');

    // Create the highlights2 div
    const highlightsDiv = document.createElement('div');
    highlightsDiv.id = 'Div_Tabla2';
    highlightsDiv.style.width = '100%';
    highlightsDiv.classList.add('highlights2');

    // Append the highlights2 div to the col-md-12 div
    colDiv.appendChild(highlightsDiv);

    // Append the col-md-12 div to the form
    form.appendChild(colDiv);

    // Append the form to the modal body
    modalBody.appendChild(form);

    // Create the modal footer
    const modalFooter = document.createElement('div');
    modalFooter.classList.add('modal-footer');

    // Create the "Cancelar" button
    const cancelButton = document.createElement('button');
    cancelButton.type = 'button';
    cancelButton.classList.add('btn', 'btn-secondary');
    cancelButton.setAttribute('data-dismiss', 'modal');
    cancelButton.textContent = 'Cancelar';

    // Create the "Cargar" button
    const cargarButton = document.createElement('button');
    cargarButton.type = 'button';
    cargarButton.id = 'btn-guardar-examenes';
    cargarButton.classList.add('btn', 'btn-success');
    cargarButton.setAttribute('data-dismiss', 'modal');
    cargarButton.textContent = 'Cargar';

    // Append the buttons to the modal footer
    modalFooter.appendChild(cancelButton);
    modalFooter.appendChild(cargarButton);

    // Append the header, body, and footer to the content
    modalContent.appendChild(modalHeader);
    modalContent.appendChild(modalBody);
    modalContent.appendChild(modalFooter);

    // Append the content to the dialog
    modalDialog.appendChild(modalContent);

    // Append the dialog to the container
    modalContainer.appendChild(modalDialog);

    // Append the container to the document body
    document.body.appendChild(modalContainer);
    

    /**
     * Represents an array of objects containing exam-related information.
     *
     * @typedef {Object} ExamObject
     * @property {number} AÑO_DESC - The description for the year.
     * @property {number} ID_PREVE - The ID for preve.
     * @property {number} ID_CODIGO_FONASA - The ID for the FONASA code.
     * @property {number} CF_PRECIO_AMB - The price for ambulatory services.
     * @property {number} CF_PRECIO_HOS - The price for hospital services.
     * @property {number} ID_ESTADO - The ID for the exam state.
     * @property {number} CF_COD - The code for the exam.
     * @property {number} CF_DESC - The description for the exam.
     * @property {number} ID_PER - The ID for the person.
     * @property {number} ID_CF_PRECIO - The ID for the price.
     * @property {number} CF_DIAS - The number of days for the exam.
     */

    /** @type {Array<ExamObject>} */
    let Mx_Dtt_exam02 = [{
        "AÑO_DESC": 0,
        "ID_PREVE": 0,
        "ID_CODIGO_FONASA": 0,
        "CF_PRECIO_AMB": 0,
        "CF_PRECIO_HOS": 0,
        "ID_ESTADO": 0,
        "CF_COD": 0,
        "CF_DESC": 0,
        "ID_PER": 0,
        "ID_CF_PRECIO": 0,
        "CF_DIAS": 0,
    }];

    function ajaxExamenesPrevision() {
        var f = moment().format("DD-MM-YYYY");
        $("#Div_Tabla2").empty();
        var Data_Par = JSON.stringify({
            "ID_PREVE": Mx_Detalle_ate.proparra3[0].ID_PREVE,
            "Fecha": f
        });
        $.ajax({
            "type": "POST",
            "url": "/Agenda_Med/Ingreso_Ate.aspx/Llenar_tabla_exam2",
            "data": Data_Par,
            "contentType": "application/json;  charset=utf-8",
            "dataType": "json",
            "success": function (response) {
                var json_receiver = response.d;
                if (json_receiver != null) {
                    Mx_Dtt_exam02 = json_receiver.filter(item => !Mx_Detalle_ate.proparra2.some(exaActual => exaActual.ID_CODIGO_FONASA ==item.ID_CODIGO_FONASA));
                    fillExamenesPrevision();
                } 
            },
        });
    }
    let Mx_Carga = [];
    function fillExamenesPrevision() {
        $("#Div_Tabla2").empty().append($("<table>", { id: "DataTableAddExa", class: "display table table-hover table-striped table-iris", width: "100%", cellspacing: "0" }));
        $("#DataTableAddExa").append($("<thead>", { class: "cabzera"}), $("<tbody>"));
        $("#DataTableAddExa thead").append($("<tr>").append(
            $("<th>", { "class": "textoReducido" }).text("Nº"),
            $("<th>", { "class": "textoReducido" }).text("Codigo"),
            $("<th>", { "class": "textoReducido" }).text("Descripcion"),
            $("<th>", { "class": "textoReducido" }).text("Carga")
        ));
        for (let i = 0; i < Mx_Dtt_exam02.length; i++) {
            $("#DataTableAddExa tbody").append($("<tr>", { class: "textoReducido manito", padding: "1px !important", }).append(
                $("<td>", { align: "left", class: "textoReducido" }).text(i + 1),
                $("<td>", { align: "left", class: "textoReducido" }).text(Mx_Dtt_exam02[i].CF_COD),
                $("<td>", { align: "left", class: "textoReducido" }).text(Mx_Dtt_exam02[i].CF_DESC),
                $("<td>", { align: "center", class: "textoReducido" }).html("<div class='checkbox checkbox-success pp' style='margin-top:-5px;'><input type='checkbox' class='manitos2' name='chk_Btn_Exa' id='H" + i + "' value='" + Mx_Dtt_exam02[i].ID_CODIGO_FONASA + "' /><label class='manitos2' for='H" + i + "'></label></div>")
            ));
        }
        $("#DataTableAddExa").DataTable({
            "searching": true,
            "iDisplayLength": 100,
            "info": false,
            "bPaginate": false,
            "bFilter": true,
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
        $("input[name=chk_Btn_Exa]").on("click", (e) => {
            let val = $(e.currentTarget).val();
            let status = $(e.currentTarget).prop("checked");
            if (status == true) {
                let i = 0;
                Mx_Carga.forEach(aah => {
                    if (aah == val) {
                        i = 1;
                    }
                });

                if (i == 0) {
                    Mx_Carga.push(val);
                }
            } else {
                let index = Mx_Carga.indexOf(val);
                Mx_Carga.splice(index, 1);
            }
        });
    }

    $("#btn-guardar-examenes").on("click", async () => {
        const idUsuario = parseInt(Galletas.getGalleta("ID_USER"));

        if (!idUsuario) {

            Swal.fire({ icon: "info", title: "Información", html: "Su sesión ha caducado, por favor inicie sesión nuevamente." });
            setTimeout(() => window.location.href = '/', 3000)
            return;
        };

        const checkedExamenes = document.querySelectorAll('input[name=chk_Btn_Exa]:checked');
        const examenesAgregar = Array.from(checkedExamenes).map(item => Mx_Dtt_exam02.find(exa => exa.ID_CODIGO_FONASA === parseInt(item.value)));
        const examenesBodyRequest = examenesAgregar.map(item => ({ id_CF: item.ID_CODIGO_FONASA, id_PER: item.ID_PER, Valor: item.CF_PRECIO_AMB, Clinico: "0" }));

        if (examenesBodyRequest.length === 0) {
            Swal.fire({ icon: "info", title: "Información", html: "Debe seleccionar examenes de la tabla para cargarlos." });
            return;
        }
        const body = JSON.stringify({
            ID_PREINGRESO: Mx_Detalle_ate.proparra3[0].ID_PREINGRESO,
            ID_USUARIO: idUsuario,
            examenesArray: examenesBodyRequest,
        });

        const idPreingreso = Mx_Detalle_ate.proparra3[0].ID_PREINGRESO;
        const idAtencion = Mx_Detalle_ate.proparra3[0].ID_ATENCION;
        const ateNum = Mx_Detalle_ate.proparra3[0].ATE_NUM;


        $.ajax({
            "type": "POST",
            "url": "/Agenda_Med/Lis_Pac_TDM.aspx/AddExamenToPreingreso",
            "data": body,
            "contentType": "application/json; charset=utf-8",
            "dataType": "json",
            "success": (res) => {

                Swal.fire({ icon: "success", title: "Éxito", html: "Exámenes agregados con éxito." });

                Ajax_modal_exa(idPreingreso, idAtencion, ateNum, true);

            }
        });

    });

}

export { habilitarBotonEditarAgenda };