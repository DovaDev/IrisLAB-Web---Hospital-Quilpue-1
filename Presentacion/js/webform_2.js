var H;
(function (H) {
    H.HTMLAlign = {
        left: {
            align: "left",
            class: "text-left ",
            style: "text-align: left; "
        },
        center: {
            align: "center",
            class: "text-center ",
            style: "text-align: center; "
        },
        right: {
            align: "right",
            class: "text-right ",
            style: "text-align: right; "
        }
    };
    /**
     * Clase que permite crear tablas en HTML de forma simple y eficiente.
     */
    class Ts_Table {
        /**
         * Crea una nueva instancia de Ts_Table
         * @param ID_DOM ID del elemento HTML que contendrá la Tabla que será dibujada.
         */
        constructor(id_dom) {
            this.dtt_is = false;
            this.dtt_display_length = 10;
            this.dtt_paginator = true;
            this.dtt_filter = true;
            this.dtt_sort = true;
            this.id_object = `#${id_dom}`;
            this.arr_headers = [];
            this.arr_data = [];
            this.arr_cell_box = [];
            $(document).ready(() => {
                if (this.arr_data.length > 0) {
                    this.makeTable();
                    return;
                }
                $(this.id_object).append($("<div>", {
                    class: "alert alert-primary mb-0 pb-0"
                }).append($("<p>").append(this.msg_init)));
            });
        }
        /**
         * Devuelve un entero con el índice de la Fila seleccionada, si no hay alguna fila seleccionada retornará null.
         */
        get rowIndex() {
            let str_nnn = $(`${this.id_object} table tbody tr.selected`).attr("data-index");
            let num_nnn = null;
            if (str_nnn != null) {
                num_nnn = parseInt(`${str_nnn}`);
            }
            return num_nnn;
        }
        /**
         * Establece la instancia actual como tipo Data Table.
         * @param set               Determina si la instancia actual será del tipo Data Table.
         * @param display_length    Establece el número de elementos por página por defecto.
         * @param paginator         Determina si el Paginador será visible.
         * @param filter            Determina si el Filtro será visible.
         * @param sort              Determina si las columnas pueden ordenarse automáticamente.
         */
        setDataTable(set = true, display_length = 10, paginator = true, filter = true, sort = true) {
            this.dtt_is = set;
            this.dtt_display_length = display_length;
            this.dtt_paginator = paginator;
            this.dtt_filter = filter;
            this.dtt_sort = sort;
        }
        //public setSelectable()
        /**
         * Crea una nueva columna en su estructura interna
         * @param text      Texto que irá en la tabla.
         * @param alignment Alineación, use "H.HTMLAlign" para determinar dicha alineación.
         */
        addHeader(text, alignment) {
            this.arr_headers.push({
                content: text,
                align: alignment
            });
        }
        /**
         * Agrega la celda en un "Contenedor Temporal". Cuando el contenedor esté lleno, se puede generar una fila usando el método Ts_Table.makeRow().
         * @param content   Contenido que se agregará a la celda
         * @param alignment Alineación, use "H.HTMLAlign" para determinar dicha alineación.
         */
        addCellRow(content, alignment) {
            this.arr_cell_box.push({
                content: content,
                align: alignment
            });
        }
        /**
         * Arma una fila entera a partir de las celdas almacenadas en el "Contenedor Temporal". Además vacía el contenedor en cuestión.
         */
        makeRow() {
            let arr_insert = [];
            this.arr_cell_box.forEach(xitem => {
                arr_insert.push({
                    content: xitem.content,
                    align: xitem.align
                });
            });
            this.arr_data.push(arr_insert);
            this.arr_cell_box = [];
        }
        /**
         * Dibuja la tabla con todos los datos internos almacenados.
         */
        makeTable() {
            $(this.id_object).empty();
            console.log(this);
            //En caso de no haber resultados
            if (this.arr_data.length == 0) {
                $(this.id_object).append($("<div>", {
                    class: "alert alert-warning mb-0 pb-0"
                }).append(this.msg_empty));
                return;
            }
            //Llenar Cabeceras
            let obj_table = $("<table>", { class: "w-100 table-striped" }).appendTo(this.id_object);
            obj_table.append($("<thead>").append($("<tr>")), $("<tbody>"));
            this.arr_headers.forEach(xitem => {
                obj_table.find("tr").append($("<th>", {
                    class: xitem.align.class
                }).append(xitem.content));
            });
            //Colocar Celdas
            this.arr_data.forEach((xitem, xi) => {
                let xrow = $("<tr>", { "data-index": xi });
                xitem.forEach(xcell => {
                    xrow.append($("<td>", {
                        class: xcell.align.class
                    }).append(xcell.content));
                });
                obj_table.append(xrow);
            });
            //Asignar eventos
            $(this.id_object).append(obj_table);
            $(`${this.id_object} table tbody tr`).click((Me) => {
                $(`${this.id_object} table tbody tr`).removeClass("selected");
                $(Me.currentTarget).addClass("selected");
            });
            if (this.clickRow != null) {
                $(`${this.id_object} table tbody tr`).click(this.clickRow);
            }
            //Determinar DataTable
            if (this.dtt_is == true) {
                //Establecer DataTable
                let obj_dtt = $(`${this.id_object} table`).DataTable({
                    "iDisplayLength": this.dtt_display_length,
                    "info": this.dtt_paginator,
                    "bPaginate": this.dtt_paginator,
                    "bFilter": this.dtt_filter,
                    "bSort": this.dtt_sort,
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
                if (this.dtt_paginator == true) {
                    $(`${this.id_object} .dataTables_filter`).addClass("pull-right");
                    $(`${this.id_object} .dataTables_paginate`).addClass("pull-right");
                }
                else {
                    $(`${this.id_object} table`).parent().addClass("mb-3");
                }
                $(`${this.id_object} .dataTables_filter`).parent().attr({ "class": "col-9" });
                $(`${this.id_object} .dataTables_length`).parent().attr({ "class": "col-3" });
                $(`${this.id_object} table`).parent().addClass("table-responsive");
            }
        }
    }
    H.Ts_Table = Ts_Table;
    class Ts_Textbox {
        constructor() {
        }
        get raw() {
            return this.obj_raw;
        }
    }
    H.Ts_Textbox = Ts_Textbox;
})(H || (H = {}));
//# sourceMappingURL=webform_2.js.map