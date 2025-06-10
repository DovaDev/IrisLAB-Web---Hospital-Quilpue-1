var H;
(function (H) {
    H.HTMLAlign = {
        left: {
            align: "left",
            class: ".text-left ",
            style: "text-align: left; "
        },
        center: {
            align: "center",
            class: ".text-center ",
            style: "text-align: center; "
        },
        right: {
            align: "right",
            class: ".text-right ",
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
            this.id_object = `#${id_dom}`;
            this.arr_headers = [];
            this.arr_data = [];
            this.arr_cell_box = [];
            document.addEventListener("load", () => {
                $(this.id_object).append($("<alert>", {
                    class: "alert alert-primary pb-0"
                }).append(this.msg_init));
            }, false);
        }
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
            //En caso de no haber resultados
            if (this.arr_data.length == 0) {
                $(this.id_object).append($("<alert>", {
                    class: "alert alert-warning pb-0"
                }).append(this.msg_empty));
                return;
            }
            //Armar tabla
        }
    }
    H.Ts_Table = Ts_Table;
})(H || (H = {}));
//# sourceMappingURL=webform 2.js.map