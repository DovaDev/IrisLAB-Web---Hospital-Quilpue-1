/// <reference path="../scripts/typings/jquery/jquery.d.ts" />
/// <reference path="../scripts/typings/bootstrap/bootstrap.d.ts" />
/// <reference path="../scripts/typings/bootstrap/datatable.d.ts" />
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
/**
 * Conjunto de Clases usadas para referenciar elementos del DOM. Esta API para funcionar
 * requiere de las siguientes librerías y frameworks:
 *   - jQuery.
 *   - Bootstrap.
 *   - Bootstrap Datepicker.
 *   - Bootstrap Datatables.
 *   - FontAwesome.
 */
var WEBFORM;
(function (WEBFORM) {
    //Clases
    /**
     * Botones
     */
    class class_Button {
        /**
        * Constructor del Objeto Tabla
        * @param id - Id del <div> contenedor
        */
        constructor(id) {
            this.active = true;
            this.id = id;
        }
        /**
        * Establecer el estado del Botón
        * @param status - Booleano indicando si se debe Activar/Desactivar
        */
        setActive(status = true) {
            switch (status) {
                case false:
                    $(`#${this.id}`).attr({ "disabled": true });
                    $(`#${this.id}`).addClass("disabled");
                    break;
                default:
                    $(`#${this.id}`).removeAttr("disabled");
                    $(`#${this.id}`).removeClass("disabled");
                    break;
            }
            this.active = status;
        }
        /**
        * Llamar o Declarar evento Click
        * @param fn - Si se deja en blanco llama al evento Click, si por el
        * contrario se inserta una función, ésta se utilizará para asignarla
        * al evento click del botón.
        */
        click(fn) {
            $(document).ready(() => {
                if (fn) {
                    $(`#${this.id}`).click(fn);
                }
                else {
                    $(`#${this.id}`).click();
                }
            });
        }
        /**
        * Establecer el estado del Botón
        * @param value - [Opcional] - establecer texto del botón. Si no se envía
        * el parámetro la función retornará el texto del botón.
        * @param ai_class - [Optional] - Clase de Font Awesome a usar en el Botón.
        */
        text(value, ai_class) {
            if (value) {
                if (ai_class) {
                    $(`#${this.id}`).html(`<i class="fa fa-fw ${ai_class}"></i>${value}`);
                }
                else {
                    $(`#${this.id}`).text(value);
                }
            }
            else {
                return String($(`#${this.id}`).text());
            }
        }
    }
    WEBFORM.class_Button = class_Button;
    /**
     * Elementos de Entrada de datos
     */
    class class_Input {
        //Construcción de la Clase
        constructor(id) {
            this.numeric = {
                value: false,
                min: null,
                max: null,
                default: null
            };
            this.xActive = true;
            this.id = id;
            this.click_number();
        }
        //Métodos
        get active() {
            let xRararar = $(`#${this.id}`).attr("disabled");
            if (xRararar == null) {
                return false;
            }
            else {
                true;
            }
        }
        set active(status) {
            switch (status) {
                case false:
                    $(document).ready(() => {
                        $(`#${this.id}`).attr({ "disabled": true });
                        $(`#${this.id}`).addClass("disabled");
                    });
                    break;
                default:
                    $(document).ready(() => {
                        $(`#${this.id}`).removeAttr("disabled");
                        $(`#${this.id}`).removeClass("disabled");
                    });
                    break;
            }
        }
        get readOnly() {
            let xRararar = $(`#${this.id}`).attr("disabled");
            if (xRararar == null) {
                return false;
            }
            else {
                true;
            }
        }
        set readOnly(status) {
            switch (status) {
                case true:
                    $(document).ready(() => {
                        $(`#${this.id}`).attr({ "readonly": true });
                    });
                    break;
                default:
                    $(document).ready(() => {
                        $(`#${this.id}`).removeAttr("readonly");
                    });
                    break;
            }
        }
        get value() {
            return $(`#${this.id}`).val();
        }
        set value(val) {
            $(`#${this.id}`).val(val);
        }
        setActive(status) {
            switch (status) {
                case false:
                    $(document).ready(() => {
                        $(`#${this.id}`).attr({ "disabled": true });
                        $(`#${this.id}`).addClass("disabled");
                    });
                    break;
                default:
                    $(document).ready(() => {
                        $(`#${this.id}`).removeAttr("disabled");
                        $(`#${this.id}`).removeClass("disabled");
                    });
                    break;
            }
            this.xActive = status;
        }
        getValue() {
            let xVal = $(`#${this.id}`).val();
            switch (xVal) {
                case null:
                case "":
                    return null;
                default:
                    return xVal;
            }
        }
        setValue(value) {
            $(`#${this.id}`).val(value);
        }
        setReadOnly(value) {
            if (value == true) {
                $(document).ready(() => {
                    $(`#${this.id}`).attr("readonly", String(value));
                    $(`#${this.id}`).css({ background: "#ffffff" });
                });
            }
            else {
                $(document).ready(() => {
                    $(`#${this.id}`).removeAttr("readonly");
                });
            }
        }
        click_number() {
            $(document).ready(() => {
                $(`#${this.id}`).keyup((Me) => {
                    if (this.numeric.value == true) {
                        let value = $(Me.currentTarget).val();
                        value = value.replace(/,/gi, ".");
                        let Ree = value.match(/^-?[0-9]*\.?[0-9]*/gi);
                        if (Ree != null) {
                            $(Me.currentTarget).val(Ree[0]);
                            this.xvalue = parseFloat(Ree[0]);
                        }
                        else {
                            $(Me.currentTarget).val(this.numeric.default);
                            this.xvalue = this.numeric.default;
                        }
                    }
                });
                $(`#${this.id}`).focusout((Me) => {
                    if (this.numeric.value == true) {
                        if (($(`#${this.id}`).val() == "") || ($(`#${this.id}`).val() == "-")) {
                            if ((this.numeric.min < 0) && (this.numeric.max > 0)) {
                                $(`#${this.id}`).val("0");
                            }
                            else if (this.numeric.default != null) {
                                $(`#${this.id}`).val(this.numeric.default);
                            }
                            else {
                                $(`#${this.id}`).val(this.numeric.min);
                            }
                        }
                        else if ((this.numeric.min != null) && (parseFloat($(`#${this.id}`).val()) < this.numeric.min)) {
                            $(`#${this.id}`).val(this.numeric.min);
                        }
                        else if ((this.numeric.max != null) && (parseFloat($(`#${this.id}`).val()) > this.numeric.max)) {
                            $(`#${this.id}`).val(this.numeric.max);
                        }
                    }
                });
            });
        }
        /**
         * Declarar o Llamar al Evento Click
         * @param fn - [Opcional] Permite establecer la función a ejecutar cuando se haga click en algún elem.
         */
        evClick(fn) {
            $(document).ready(() => {
                if (fn) {
                    $(`#${this.id}`).click(fn);
                }
                else {
                    $(`#${this.id}`).click();
                }
            });
        }
        /**
         * Establecer o llamar evento FocusOut
         * @param fn - Función para la declaración del Evento.
         */
        evFocusOut(fn) {
            $(document).ready(() => {
                if (fn) {
                    $(`#${this.id}`).focusout(fn);
                }
                else {
                    $(`#${this.id}`).focusout();
                }
            });
        }
        /**
         * Llama o establece el evento de soltar un botón del teclado.
         * @param fn - [opcional] función a asignar al evento.
         */
        evKeyup(fn) {
            $(document).ready(() => {
                if (fn) {
                    $(`#${this.id}`).keyup(fn);
                }
                else {
                    $(`#${this.id}`).keyup();
                }
            });
        }
        /**
         * Llama o establece el evento de presionar un botón del teclado.
         * @param fn - [opcional] función a asignar al evento.
         */
        evKeypress(fn) {
            $(document).ready(() => {
                if (fn) {
                    $(`#${this.id}`).keypress(fn);
                }
                else {
                    $(`#${this.id}`).keypress();
                }
            });
        }
    }
    WEBFORM.class_Input = class_Input;
    /**
     * Tablas
     */
    class class_Table {
        /**
        * Constructor del Objeto Tabla
        * @param id - Id del <div> contenedor
        * @param message - Mensaje Inicial del <div>
        */
        constructor(id, message) {
            this.td_value = null;
            this.isDataTable = false;
            this.isClickeable = false;
            this.id = id;
            $(document).ready(init => {
                this.cleanTable(message);
            });
        }
        get tr_value() {
            if (this.isClickeable == true) {
                return $(`#${this.id} tbody .tr_selected`).attr("data-index");
            }
            else {
                return null;
            }
        }
        /**
        * Limpiar Tabla
        * @param message - Mensaje del <div>
        */
        cleanTable(message) {
            this.head = [];
            this.body = [];
            $(`#${this.id}`).empty();
            if (message) {
                $(`#${this.id}`).append($("<div>", {
                    "class": "alert alert-info mb-0"
                }));
                $(`#${this.id} .alert`).html(message);
            }
        }
        /**
        * Agregar una Columna en la tabla.
        * @param text - Encabezado de la Columna
        * @param align - Alineación de la Columna ("left", "center", "right")
        */
        addTHead(text, align = "left") {
            let xAlign = String(align.toLowerCase());
            if ((xAlign != "left") && (xAlign != "center") && (xAlign != "right")) {
                xAlign = "left";
            }
            this.head.push({
                "text": text,
                "align": xAlign,
            });
        }
        /**
        * Agregar una Fila en la tabla (cuerpo de la tabla).
        * @param rowValue - Valor asociado a la Fila
        * @param arrData - Array con el contenido de todas las celdas de la Fila
        * @param arrValue - Array con el Valor de todas las celdas de la Fila
        * @param arrClass - Array con el Clase de todas las celdas de la Fila
        * @param arrStyle - Array con el Style de todas las celdas de la Fila
        */
        addRow(rowValue, arrText, arrValue = [], arrClass = [], arrStyle = []) {
            let xRow;
            let xCell;
            xRow = {
                "index": rowValue,
                "cells": []
            };
            arrText.forEach((data, y) => {
                try {
                    xCell = {
                        "html": data,
                        "align": this.head[y].align
                    };
                    if (arrValue != null) {
                        xCell.value = arrValue[y];
                    }
                    if (arrClass != null) {
                        xCell.class = arrClass[y];
                    }
                    if (arrStyle != null) {
                        xCell.style = arrStyle[y];
                    }
                    xRow.cells.push(xCell);
                }
                catch (err) {
                    console.error("[FAIL] - Error al crear Celda:");
                    console.error(`         Index = ${y}`);
                    return;
                }
            });
            this.body.push(xRow);
        }
        /**
        * Actualizar la Tabla con los Datos Guardados
        * @param nullMessage - Mensaje en caso de que la tabla esté vacía
        * @param dtDisplayLength - Cant. de elementos a mostrar por defecto
        * @param dtPaginator - Activar/Desactivar Paginador
        * @param dtFilter - Activar/Desactivar Filtro
        * @param dtSort - Activar/Desactivar el orden alfabético por Columnas
        */
        updateTable(nullMessage, dtDisplayLength = 10, dtPaginator = true, dtFilter = true, dtSort = true) {
            $(`#${this.id} table`).DataTable().destroy();
            let dataLength = this.body.length;
            if (dataLength < 1) {
                this.cleanTable(nullMessage);
                return;
            }
            else {
                $(`#${this.id}`).empty();
                //Armar Tabla
                $(`#${this.id}`).append($("<table>", {
                    "class": "w-100 table-striped",
                    "style": "max-height: 30vh"
                }));
                if (this.head.length > 0) {
                    //Agregar fila de las cabeceras
                    $("<thead>").appendTo(`#${this.id} table`);
                    $(`#${this.id} table thead`).append($("<tr>"));
                    //Recorrer las cabeceras e insertarlas
                    for (let y = 0; y < this.head.length; ++y) {
                        //Crear celda
                        let cell = $("<th>", {
                            "class": "text-center"
                        }).html(this.head[y].text);
                        //Agregar a la Fila de la celda
                        $(`#${this.id} thead tr`).append(cell);
                    }
                }
                //Armar cuerpo de la Tabla
                $("<tbody>").appendTo(`#${this.id} table`);
                for (let yy = 0; yy < this.body.length; ++yy) {
                    let arrCell = [];
                    for (let x = 0; x < this.body[yy].cells.length; ++x) {
                        //Setear Propiedades
                        let prop = {};
                        //prop.align = this.body[y].cells[x].align
                        //Valores opcionales
                        if (this.body[yy].cells[x].value) {
                            prop["data-value"] = this.body[yy].cells[x].value;
                        }
                        if (this.body[yy].cells[x].class) {
                            prop.class = `text-${this.body[yy].cells[x].align} ${this.body[yy].cells[x].class}`;
                        }
                        else {
                            prop.class = `text-${this.body[yy].cells[x].align}`;
                        }
                        if (this.body[yy].cells[x].style) {
                            prop.style = this.body[yy].cells[x].style;
                        }
                        //Crear Celda
                        let cell = $("<td>", prop).html(this.body[yy].cells[x].html);
                        arrCell.push(cell);
                    }
                    var xVar = this.body[yy].index;
                    if (xVar == null) {
                        xVar = yy;
                    }
                    $(`#${this.id} tbody`).append($("<tr>", {
                        "data-index": xVar,
                        "class": () => {
                            if (xVar == this.tr_value) {
                                return "tr_selected";
                            }
                            else {
                                return "";
                            }
                        }
                    }).append(arrCell));
                }
                //Evento click
                if (this.isClickeable == true) {
                    $(`#${this.id} tbody tr`).click((me) => {
                        //Seleccionar Elemento y guardar valor
                        $(`#${this.id} tbody tr`).removeClass("tr_selected");
                        $(me.currentTarget).toggleClass("tr_selected");
                        if (this.evclick_tr != null) {
                            this.evclick_tr(me);
                        }
                    });
                    $(`#${this.id} tbody td`).click((me) => {
                        this.td_value = $(me.currentTarget).attr("data-index");
                        if (this.evclick_td != null) {
                            this.evclick_td(me);
                        }
                    });
                }
                //Determinar DataTable
                if (this.isDataTable == true) {
                    //Establecer DataTable
                    let REEE = $(`#${this.id} table`).DataTable({
                        "iDisplayLength": dtDisplayLength,
                        "info": dtPaginator,
                        "bPaginate": dtPaginator,
                        "bFilter": dtFilter,
                        "bSort": dtSort,
                        "language": {
                            "lengthMenu": "Mostrar: _MENU_",
                            "zeroRecords": "No hay concidencias",
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
                    if (dtPaginator == true) {
                        $(`#${this.id} .dataTables_filter`).addClass("pull-right");
                        $(`#${this.id} .dataTables_paginate`).addClass("pull-right");
                    }
                    else {
                        $(`#${this.id} table`).parent().addClass("mb-3");
                    }
                    $(`#${this.id} .dataTables_filter`).parent().attr({ "class": "col-9" });
                    $(`#${this.id} .dataTables_length`).parent().attr({ "class": "col-3" });
                    $(`#${this.id} table`).parent().addClass("table-responsive");
                    REEE.on("draw", this.evReDraw);
                }
            }
        }
    }
    WEBFORM.class_Table = class_Table;
    /**
     * Listas Desplegables
     */
    class class_Select {
        /**
        * Constructor del Objeto Select
        * @param id - Id del <div> contenedor
        */
        constructor(id) {
            /**
            * Contenedor de los datos a usar en la construcción del Select.
            */
            this.data = [];
            this.id = id;
        }
        get active() {
            let xRararar = $(`#${this.id}`).attr("disabled");
            if (xRararar == null) {
                return false;
            }
            else {
                true;
            }
        }
        set active(status) {
            switch (status) {
                case false:
                    $(document).ready(() => {
                        $(`#${this.id}`).attr({ "disabled": true });
                        $(`#${this.id}`).addClass("disabled");
                    });
                    break;
                default:
                    $(document).ready(() => {
                        $(`#${this.id}`).removeAttr("disabled");
                        $(`#${this.id}`).removeClass("disabled");
                    });
                    break;
            }
        }
        get readOnly() {
            let xRararar = $(`#${this.id}`).attr("disabled");
            if (xRararar == null) {
                return false;
            }
            else {
                true;
            }
        }
        set readOnly(status) {
            switch (status) {
                case true:
                    $(document).ready(() => {
                        $(`#${this.id}`).attr({ "readonly": true });
                    });
                    break;
                default:
                    $(document).ready(() => {
                        $(`#${this.id}`).removeAttr("readonly");
                    });
                    break;
            }
        }
        /**
        * Obtener Texto y valor del elemento seleccionado.
        */
        getValue() {
            let xValue = $(`#${this.id}`).val();
            let xText;
            for (let i = 0; i < this.data.length; ++i) {
                if (this.data[i].value == xValue) {
                    xText = this.data[i].text;
                    break;
                }
            }
            let elem = {
                "value": xValue,
                "text": xText
            };
            return elem;
        }
        /**
         * Selecciona un valor si es que existe.
         * @param value - Valor del elemento a seleccionar.
         */
        setValue(value) {
            $(`#${this.id}`).val(value);
        }
        /**
        * Ingresar un elemento al Select
        * @param text - Texto del elemento a Insertar
        * @param value - Valor del Elemento a Insertar
        */
        insertElem(xText, xValue) {
            let elem;
            elem = {
                "text": xText,
                "value": xValue
            };
            this.data.push(elem);
            $(`#${this.id}`).append($("<option>", {
                "value": elem.value
            }).text(elem.text));
        }
        eventChange(fn) {
            if (fn) {
                $(document).ready(() => {
                    $(`#${this.id}`).change(fn);
                });
            }
            else {
                $(`#${this.id}`).change();
            }
        }
        /**
        * Actualizar el contenido del Select usando la información guardada en "Data".
        */
        updateSelect() {
            $(`#${this.id}`).empty();
            if (this.data.length > 0) {
                for (let y = 0; y < this.data.length; ++y) {
                    $(`#${this.id}`).append($("<option>", {
                        "value": this.data[y].value
                    }).text(this.data[y].text));
                }
            }
            else {
                $(`#${this.id}`).text("Sin Resultados");
            }
        }
        /**
        * Eliminar un elemento tanto de "data" como del Select
        * @param value - Valor del elemento a eliminar
        */
        deleteElem(value) {
            let finished = false;
            $(`#${this.id} option[value=${value}]`).remove();
            while (finished == false) {
                for (let y = 0; y < this.data.length; ++y) {
                    finished = true;
                    if (this.data[y].value == value) {
                        finished = false;
                        this.data.splice(y, 1);
                        break;
                    }
                }
            }
        }
        /**
         * Limpiar todo el Select
         */
        cleanAll() {
            $(`#${this.id}`).empty();
            this.data = [];
        }
    }
    WEBFORM.class_Select = class_Select;
    /**
    * Clase que dibuja modales Genéricos para su posterior uso
    */
    class class_Modal {
        /**
         * Construir el modal
         * @param id - Id interno del Modal
         */
        constructor(id, backHide = true) {
            this.buttons = [];
            this.id_modal = id;
            $(document).ready(() => {
                //Construir Modal
                $(`#${this.id_modal}[class="modal fade"]`).remove();
                $("body").append($("<div>", {
                    "id": id,
                    "class": "modal",
                    "role": "diag",
                    "data-backdrop": () => {
                        if (backHide == false) {
                            return 'static';
                        }
                        else {
                            return backHide;
                        }
                    }
                }).append($("<div>", {
                    "class": "modal-dialog"
                }).append($("<div>", {
                    "class": "modal-content"
                }))));
                $(`#${this.id_modal} .modal-content`).append($("<div>", { "class": "modal-header" }), $("<div>", { "class": "modal-body" }), $("<div>", { "class": "modal-footer" }));
            });
            //$(`#${this.id_modal}`).modal('hide')
        }
        /**
         * Permite Agregar Botones al modal en cuestión
         * @param text - Texto dentro del Botón.
         * @param bt_class - Clase de bootstrap que indica el color del botón.
         * @param callback - Función asociada al clickear el Botón.
         * @param fa_icon - ícono asociado al Botón, debe de ser la clase de Font Awesome.
         */
        addButton(text, bt_class = null, callback = null, fa_icon = null) {
            let objButton = {
                text: text,
                callback: callback,
                type: bt_class,
                icon: fa_icon
            };
            this.buttons.push(objButton);
        }
        cleanButtons() {
            $(`#${this.id_modal} .modal-footer`).empty();
            this.buttons = [];
        }
        /**
         * Mostrar Modal con los elementos insertos
         */
        showModal() {
            $(`#${this.id_modal} .modal-header`).empty();
            $(`#${this.id_modal} .modal-body`).empty();
            $(`#${this.id_modal} .modal-footer`).empty();
            //Agregar elementos al Modal
            $(`#${this.id_modal} .modal-header`).append($("<h5>", { "class": "modal-title" }).text(this.title));
            $(`#${this.id_modal} .modal-body`).html(this.content);
            //Agregar Botones
            if (this.buttons.length > 0) {
                for (let y = 0; y < this.buttons.length; ++y) {
                    //Insertar Botón
                    $(`#${this.id_modal} .modal-footer`).append($("<button>", {
                        "type": "button",
                        "class": `btn ${this.buttons[y].type}`,
                        "data-index": y,
                        "data-dismiss": "modal"
                    }));
                    //Agregar Texto
                    if (this.buttons[y].icon != null) {
                        $(`#${this.id_modal} button[data-index=${y}]`).html(`<i class="fa fa-fw ${this.buttons[y].icon}"></i>${this.buttons[y].text}`);
                    }
                    else {
                        $(`#${this.id_modal} button[data-index=${y}]`).html(this.buttons[y].text);
                    }
                    //Crear Evento Click
                    $(`#${this.id_modal} button[data-index=${y}]`).click(this.buttons[y].callback);
                }
            }
            else {
                //Insertar Botón
                $(`#${this.id_modal} .modal-footer`).append($("<button>", {
                    "type": "button",
                    "class": `btn btn-info`,
                    "data-dismiss": "modal"
                }).text("Aceptar"));
            }
            //$(`#${this.id_modal}`).modal('show')
            $(`#${this.id_modal}`).modal();
        }
    }
    WEBFORM.class_Modal = class_Modal;
    /**
     * Grupo de Checkbox
     */
    class class_Checkbox {
        /**
         * Crea una colección de Checkbox usando un nombre en común. Cada Checkbox debe de tener esta sintaxis:
         * <input type="checkbox" name="[obligatorio]" data-text="[obligatorio]" data-value="[obligatorio]" checked />
         *
         * Consideraciones:
         *   - name: Nombre del grupo de Checkbox.
         *   - data-text: Texto que se usará en el label del Checkbox.
         *   - data-value: Valor del Item. Acepta Booleanos, Números, Cadenas y Objetos enteros ({'prop1': val1, 'prop2': val2}).
         *   - checked: Opcional, si está presente el ítem aparecerá seleccionado por defecto.
         * @param name - Nombre del grupo de Checkbox. Ej: <input type="checkbox" name="[Este_elem]" />
         */
        constructor(name) {
            $(document).ready(() => {
                let xLen = $(`input[name=${name}]`).length;
                this.name = name;
                for (let y = 0; y < xLen; ++y) {
                    let xClass = $(`input[name=${name}]`).eq(y).attr("class");
                    let xStyle = $(`input[name=${name}]`).eq(y).attr("style");
                    let xText = $(`input[name=${name}]`).eq(y).attr("data-text");
                    let xValue = $(`input[name=${name}]`).eq(y).attr("data-value");
                    let xChecked = $(`input[name=${name}]`).eq(y).attr("checked");
                    $(`input[name=${name}]`).eq(y).removeAttr("class");
                    $(`input[name=${name}]`).eq(y).removeAttr("data-text");
                    $(`input[name=${name}]`).eq(y).removeAttr("data-value");
                    $(`input[name=${name}]`).eq(y).removeAttr("checked");
                    if (xStyle == null) {
                        xStyle = "";
                    }
                    let makeVal = (value) => {
                        if (TOOL.fn_IsNumeric(value) == true) {
                            return parseFloat(value);
                        }
                        else {
                            try {
                                let xStr_test = String(value).replace(/'/gi, '"');
                                return JSON.parse(xStr_test);
                            }
                            catch (err) {
                                return value;
                            }
                        }
                    };
                    $(`input[name=${name}]`).eq(y).attr({
                        id: `obj${name}_${y}`,
                        style: "display: none",
                        value: btoa(JSON.stringify({
                            d: makeVal(xValue)
                        }))
                    });
                    $(`input[name=${name}]`).eq(y).after($("<label>", {
                        for: `obj${name}_${y}`,
                        class: xClass,
                        style: `margin-bottom: 7px; ${xStyle}`
                    }).append($("<i>", {
                        "class": "fa fa-square-o",
                        "aria-hidden": true,
                        "style": "width: 15px;"
                    }), $("<span>", {
                        style: "margin-left: 7px; -webkit-user-select: none; -moz-user-select: none; -ms-user-select: none; user-select: none;"
                    }).text(xText)));
                    if (xChecked != null) {
                        $(`input[name=${name}]`).eq(y).attr("checked", "checked");
                        $(`label[for=obj${name}_${y}] i`).attr("class", "fa fa-check-square-o");
                    }
                }
            });
            this.confClick();
        }
        /**
         * Establece la configuración de los Clicks para la visualización del estado del checkbox.
         */
        confClick() {
            $(document).ready(() => {
                $(`input[name=${this.name}]`).click((Me) => {
                    let xID = $(Me.currentTarget).attr("id");
                    let xChecked = $(Me.currentTarget).attr("checked");
                    if (xChecked != null) {
                        $(Me.currentTarget).removeAttr("checked");
                        $(`label[for=${xID}] i`).attr("class", "fa fa-square-o");
                    }
                    else {
                        $(Me.currentTarget).attr("checked", "");
                        $(`label[for=${xID}] i`).attr("class", "fa fa-check-square-o");
                    }
                });
            });
        }
        /**
         * Permite obtener un array con los valores de todos los elementos seleccionados. Ejemplo:
         * [_] Item 01; value = 123
         * [x] Item 02; value = 456
         * [_] Item 03; value = 789
         * [x] Item 04; value = 555
         *
         * Esto devuelve:
         * [456, 555]
         */
        getValues() {
            let arrData = [];
            let xLen = $(`input[name=${this.name}]:checked`).length;
            for (let y = 0; y < xLen; ++y) {
                let xStr_Val;
                let item;
                xStr_Val = $(`input[name=${this.name}]:checked`).eq(y).val();
                xStr_Val = atob(xStr_Val);
                item = JSON.parse(xStr_Val);
                try {
                    arrData.push(JSON.parse(item.d));
                }
                catch (err) {
                    switch (item.d) {
                        case 'true':
                            arrData.push(true);
                            break;
                        case 'false':
                            arrData.push(false);
                            break;
                        default:
                            arrData.push(item.d);
                            break;
                    }
                }
            }
            return arrData;
        }
        /**
         * Declarar o Llamar al Evento Click
         * @param fn - [Opcional] Permite establecer la función a ejecutar cuando se haga click en algún elem.
         */
        evClick(fn) {
            $(document).ready(() => {
                if (fn) {
                    $(`input[name=${this.name}]`).click(fn);
                }
                else {
                    $(`input[name=${this.name}]`).click();
                }
            });
        }
    }
    WEBFORM.class_Checkbox = class_Checkbox;
    class class_Chk_Static {
        //--Configuración Inicial
        /**
         * Crea una serie de Checkbox que luego deben de ser insertados en el HTML de forma "semi-automática"
         * @param name Nombre del Grupo de Checkbox
         */
        constructor(name) {
            this._count = 0;
            this.name = name;
        }
        //--Getters, Setters
        get evClick() {
            return this._evClick;
        }
        set evClick(fn) {
            this._evClick = fn;
            $(`input[name=${this.name}]`).off("click");
            $(`input[name=${this.name}]`).click(fn);
        }
        /**
         * Permite obtener un array con los valores de todos los elementos seleccionados. Ejemplo:
         * [_] Item 01; value = 123
         * [x] Item 02; value = 456
         * [_] Item 03; value = 789
         * [x] Item 04; value = 555
         *
         * Esto devuelve:
         * [456, 555]
         */
        get values() {
            let arrElem = $(`input[name=${this.name}]:checked`);
            let arrData = [];
            arrElem.each((xIndex, xMe) => {
                let xVal = TOOL.fn_Base64().fromBase64($(xMe).val());
                arrData.push(xVal);
            });
            return arrData;
        }
        /**
         * Devuelve una cadena con el HTML del Checkbox, la cual puede ser insertada en cualquier momento al DOM.
         * @param value Elemento cualquiera a asignar, puede ser desde un booleano hasta inclusmo matrices de objetos.
         * @param checked [opcional] Chequeado por defecto
         */
        toString(value, strLabel = null, checked = false, readonly = false) {
            let strValue = TOOL.fn_Base64().toBase64(value);
            let strChecked = "";
            let strReadonly = "";
            let strOut = "";
            if (checked == true) {
                strChecked = " checked ";
            }
            if (readonly == true) {
                strReadonly = " readonly ";
            }
            strOut += `<div class="webform_chk">\n`;
            strOut += `    <input type="checkbox" id="Chk_${this.name}_${this._count}" name="${this.name}" value="${strValue}" ${strChecked} ${strReadonly} />\n`;
            strOut += `    <label for="Chk_${this.name}_${this._count}">\n`;
            strOut += `        <i class="fa fa-square-o" aria-hidden="true" style="width: 15px;"></i>\n`;
            strOut += `        <i class="fa fa-check-square-o" aria-hidden="true" style="width: 15px;"></i>\n`;
            if (strLabel != null) {
                strOut += `        <span>${strLabel}</span>\n`;
            }
            strOut += `    </label>\n`;
            strOut += `</div>`;
            this._count++;
            return strOut;
        }
    }
    WEBFORM.class_Chk_Static = class_Chk_Static;
    /**
     * Clase de Selector de Fechas (Bootstrap 3). La escructura del Html debe de ser así:
     * <div id="[div_Id]"></div>
     * [div_Id] -> Id del elemto a identificar en el constructor.
     */
    class class_DatePicker {
        /**
         * Construir un Datepicker de acuerdo a parámetros asignados.
         * @param id - ID del div a crear.
         */
        constructor(id, small = false) {
            /**
            * Formato de fecha a mostrar
            */
            this.format = "dd/mm/yyyy";
            /**
            * Cerrar automáticamente el popup.
            */
            this.autoclose = true;
            /**
            * Marcado del día actual
            */
            this.todayHighlight = true;
            this.id = id;
            $(document).ready(() => {
                //Construir elemento
                $(`#${this.id}`).addClass("input-group date");
                $(`#${this.id}`).append($("<input>", {
                    type: "text",
                    readonly: "true",
                    style: "background: #ffffff!important;",
                    class: () => {
                        if (small == true) {
                            return "form-control form-control-sm";
                        }
                        else {
                            return "form-control";
                        }
                    }
                }), $("<span>", {
                    class: "input-group-addon"
                }).append($("<i>", {
                    "class": "fa fa-calendar",
                    "aria-hidden": true
                })));
                if (this.value != null) {
                    // @ts-ignore
                    $(`#${this.id} input`).val(moment().format(this.format.toUpperCase()));
                }
            });
            $(document).ready(() => {
                $(`#${this.id}`).datepicker({
                    format: "dd/mm/yyyy",
                    language: "es",
                    autoclose: true,
                    todayHighlight: true
                });
            });
        }
        get value() {
            return $(`#${this.id} input`).val();
        }
        set value(data) {
            $(`#${this.id} input`).val(data);
        }
        get active() {
            let xRararar = $(`#${this.id} input`).attr("disabled");
            if (xRararar == null) {
                return false;
            }
            else {
                true;
            }
        }
        set active(status) {
            switch (status) {
                case false:
                    $(document).ready(() => {
                        $(`#${this.id} input`).attr({ "disabled": true });
                        $(`#${this.id} input`).addClass("disabled");
                        $(`#${this.id} input`).css({ background: "#ccc" });
                    });
                    break;
                default:
                    $(document).ready(() => {
                        $(`#${this.id} input`).removeAttr("disabled");
                        $(`#${this.id} input`).removeClass("disabled");
                        $(`#${this.id} input`).css({ background: "#ffffff" });
                    });
                    break;
            }
        }
        /**
         * Evento Cambio de Valor.
         * @param fn [opcional] función anónima a ejecutar cuando se cumpla el evento.
         * Si no se establece, se llama al evento.
         */
        evChange(fn) {
            if (fn != null) {
                $(document).ready(() => {
                    $(`#${this.id} input`).change(fn);
                });
            }
            else {
                $(`#${this.id} input`).change();
            }
        }
        set placeholder(value) {
            $(`#${this.id} input`).attr("placeholder", value);
        }
    }
    WEBFORM.class_DatePicker = class_DatePicker;
})(WEBFORM || (WEBFORM = {}));
/**
 * Herramientas varias.
 */
var TOOL;
(function (TOOL) {
    //--------------------------------------------------------------------
    /**
     * Comprueba si el Número ingresado es Numérico.
     * @param Value - Valor a comprobar
     */
    function fn_IsNumeric(Value) {
        let xVal;
        let xEval = `${Value}`.match(/^-?[0-9]+((\.|,)[0-9]+)?$/gi);
        if (xEval == null) {
            return false;
        }
        return true;
    }
    TOOL.fn_IsNumeric = fn_IsNumeric;
    /**
     * Convierte un número a una cadena con la cantidad de decimales indicados.
     * @param num - Número a convertir.
     * @param dec - Decimales requeridos.
     * @aprox bool - Truncar/Aproximar
     */
    function fn_cutDecimals(num, dec, aprox = false) {
        //Solo devolver el entero
        let strInput = `${num}`.replace(/,/gi, ".");
        if (fn_IsNumeric(num) == false) {
            return `${num}`;
        }
        let zPositive = (function () {
            if (strInput.match(/^-/gi) == null) {
                strInput = strInput.replace(/^-/gi, "");
                return true;
            }
            else {
                strInput = strInput.replace(/^-/gi, "");
                return false;
            }
        }());
        if (dec == 0) {
            return strInput.replace(/\.[0-9]+$/gi, "");
        }
        if (strInput.match(/\.[0-9]+$/gi) == null) {
            strInput = `${strInput}.0`;
        }
        let strOut = "";
        if (strInput.replace(/^[0-9]+\./gi, "").length > dec) {
            let arrNum = [];
            strInput.split("").forEach(xItem => {
                if (xItem == ".") {
                    arrNum.push(xItem);
                }
                else {
                    arrNum.push(parseInt(xItem));
                }
            });
            while (strOut.replace(/^[0-9]+\./gi, "").length != dec) {
                if (aprox == false) {
                    let arrD = strInput.match(new RegExp(`^[0-9]+\\.[0-9]{${dec}}`, "gi"));
                    if (arrD != null) {
                        strOut = arrD[0];
                    }
                    break;
                }
                let numInit = arrNum.length - 1;
                let boolSum = false;
                for (var i = numInit; i >= 0; i--) {
                    if (arrNum[i] == ".") {
                        continue;
                    }
                    if (arrNum[i] == 9) {
                        if ((boolSum == true) || (i == numInit)) {
                            if (i == 0) {
                                arrNum[i] = parseInt(`${arrNum[i]}`) + 1;
                            }
                            else {
                                arrNum[i] = 0;
                            }
                        }
                        boolSum = true;
                    }
                    else if ((arrNum[i] >= 5) && (arrNum[i] < 9)) {
                        if (boolSum == true) {
                            arrNum[i] = parseInt(`${arrNum[i]}`) + 1;
                        }
                        boolSum = false;
                    }
                    else {
                        if (boolSum == true) {
                            arrNum[i] = parseInt(`${arrNum[i]}`) + 1;
                        }
                        boolSum = false;
                    }
                    if (i == numInit) {
                        if (arrNum[i] >= 5) {
                            boolSum = true;
                        }
                        arrNum.pop();
                    }
                    if ((boolSum == false) && (i != numInit)) {
                        break;
                    }
                }
                strOut = "";
                for (var i = (arrNum.length - 1); i >= 0; i--) {
                    strOut = `${arrNum[i]}${strOut}`;
                }
            }
        }
        else {
            strOut = `${strInput}`;
            while (strOut.replace(/^[0-9]+\./gi, "").length != dec) {
                strOut = `${strOut}0`;
            }
        }
        if (zPositive == false) {
            strOut = `-${strOut}`;
        }
        //console.log(`Aprox   : ${aprox}\nValue In : ${num}\nValue Out: ${strOut}\n`)
        return strOut;
    }
    TOOL.fn_cutDecimals = fn_cutDecimals;
    //--------------------------------------------------------------------
    /**
     * Clase para la implementación sencilla de Peticiones AJAX usando jQuery.
     */
    class class_AJAX {
        /**
         * Construir un Objeto que cuando se ejecuta la llamada devuelve una variable AJAX
         * @param url - Dirección del WebMethod a llamar.
         * @param success - Función anónima con la respuesta en caso de ser correcta.
         * @param fail - Función anónima con la respuesta en caso de ser fallida.
         * @param timeout - [Opcional] Tiempo de espera antes de lanzar error (ms).
         */
        constructor(url, success, fail, timeout) {
            this.param = null;
            this.timeout = null;
            this.objAJAX = null;
            this.URL = url;
            this.success = success;
            this.fail = fail;
            if (timeout) {
                this.timeout = timeout;
            }
        }
        /**
         * Ejecuta una petición AJAX
         */
        requestNow(param, callback) {
            return __awaiter(this, void 0, void 0, function* () {
                this.param = JSON.stringify(param);
                this.build_objAJAX();
                let objAJAX = yield $.ajax(this.objAJAX);
                if (callback != null) {
                    callback();
                }
                return objAJAX;
            });
        }
        /**
         * Función que armar todo el objAJAX
         */
        build_objAJAX() {
            this.objAJAX = {
                type: "POST",
                url: this.URL,
                contentType: "application/json;  charset=utf-8",
                dataType: "json",
                data: this.param,
                timeout: this.timeout,
                success: this.success,
                error: this.fail
            };
            if (this.param == null) {
                delete this.objAJAX.data;
            }
            if (this.timeout == null) {
                delete this.objAJAX.timeout;
            }
            // @ts-ignore
            if (this.queryString != null) {
                // @ts-ignore
                this.objAJAX.url = `${this.objAJAX.url}?${this.queryString}`;
            }
        }
    }
    TOOL.class_AJAX = class_AJAX;
    function fn_Base64() {
        return {
            fromBase64: (str) => {
                let base = window.atob(str);
                return JSON.parse(base).d;
            },
            toBase64: (elem) => {
                let base = JSON.stringify({ d: elem });
                return window.btoa(base);
            }
        };
    }
    TOOL.fn_Base64 = fn_Base64;
})(TOOL || (TOOL = {}));
Array.prototype.DeepSearch = function (property, value) {
    let xIndx = null;
    for (let kok = 0; kok < this.length; kok++) {
        let elem_Val = this[kok][property];
        if (elem_Val == value) {
            xIndx = kok;
            break;
        }
    }
    return xIndx;
};
Object.defineProperty(Array.prototype, "DeepSearch", {
    enumerable: false
});
//# sourceMappingURL=WebForm.js.map