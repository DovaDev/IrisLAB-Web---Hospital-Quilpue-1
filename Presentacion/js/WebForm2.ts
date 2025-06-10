// eslint-disable-next-line @typescript-eslint/ban-ts-comment
// @ts-nocheck

namespace H {
    //--------------------------------------------------------------------------
    //--CONSTANTES--------------------------------------------------------------
    export const cHTMLAlign: { left: IHTMLAlignElement, center: IHTMLAlignElement, right: IHTMLAlignElement } = {
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
    }
    
    //--------------------------------------------------------------------------
    //--INTERFACES--------------------------------------------------------------
    export interface ITableCell {
        content: string | JQuery | Element;
        align: IHTMLAlignElement;
    }

    interface IHTMLAlignElement {
        align: string;
        class: string;
        style: string;
    }
    
    //--------------------------------------------------------------------------
    //--CLASES------------------------------------------------------------------

    //Contadores Internos
    let count_Table: number = 0
    let count_Textbox: number = 0
    let count_Button: number = 0
    let count_Select: number = 0
    let count_Checkbox: number = 0

    /**
     * Clase Privada Padre que contiene todos los métodos y propiedades génericas.
     */
    class Ts_Input {
        //Propiedades de Booteo
        protected obj_raw: JQuery
        protected str_class: string
        protected str_style: string
        
        //Control de Carga
        protected bol_loading: boolean
        protected bol_loaded: boolean

        //Propiedades internas
        protected bol_locked: boolean
        protected bol_enable: boolean

        //Eventos
        protected fn_click: (Me?: JQueryEventObject) => void
        protected fn_focus: (Me?: JQueryEventObject) => void
        protected fn_change: (Me?: JQueryEventObject) => void
        protected fn_focus_in: (Me?: JQueryEventObject) => void
        protected fn_focus_out: (Me?: JQueryEventObject) => void
        protected fn_key_press: (Me?: JQueryEventObject) => void
        protected fn_key_down: (Me?: JQueryEventObject) => void
        protected fn_key_up: (Me?: JQueryEventObject) => void
        
        //----------------------------------------------------------------------
        constructor(id_dom: string, obj_new: JQuery, callback: () => void) {
            //Asignación o Creación del elemento
            this.bol_loading = false
            this.bol_loaded = false

            this.bol_enable = true
            this.bol_locked = false

            if (id_dom != null) {
                H.form.load = () => {
                    this.obj_raw = $(`#${id_dom}`)

                    if (this.obj_raw.length > 0) {
                        this.str_class = this.obj_raw.attr(`class`)
                        if (this.str_class == null) {
                            this.str_class = ""
                        }
                        this.str_style = this.obj_raw.attr(`style`)
                        if (this.str_style == null) {
                            this.str_style = ""
                        }

                        this.bol_loading = true
                        this.bol_loaded = true

                        //---------------------------------------------------------
                        this._load()
                        callback()
                    } else {
                        this._new(obj_new, callback)
                    }
                }
            } else {
                this._new(obj_new, callback)
            }

        }
        private _new(_new: JQuery, _callback: () => void) {
            this.obj_raw = _new
            this.str_class = this.obj_raw.attr(`class`)
            if (this.str_class == null) {
                this.str_class = ""
            }
            this.str_style = this.obj_raw.attr(`style`)
            if (this.str_style == null) {
                this.str_style = ""
            }

            this.obj_raw.on("DOMNodeInserted", () => {
                //Controlar Ejecución de la Función
                if (this.bol_loading == false) {
                    this.bol_loading = true
                    return
                }
                if (this.bol_loaded == true) {
                    return
                }

                this.bol_loaded = true
                    
                //---------------------------------------------------------
                this._load()
                _callback()
            })

        }
        private _load() {
            //Activar o desactivar elemento
            if (this.bol_locked == true) {
                this.obj_raw.attr({ style: `${this.str_style} cursor: pointer; background: #ffffff;` })
                this.obj_raw.attr({ readonly: "readonly" })
            } else {
                this.obj_raw.attr({ style: `${this.str_style}` })
                this.obj_raw.removeAttr("readonly")
            }

            //Bloquear o desbloquear elemento
            if (this.bol_enable == false) {
                this.obj_raw.attr("disabled", "disabled")
            } else {
                this.obj_raw.removeAttr("disabled")
            }

            //Asignar eventos
            if (this.fn_click != null) {
                this.obj_raw.click(this.fn_click)
            }
            if (this.fn_focus != null) {
                this.obj_raw.focus(this.fn_focus)
            }
            if (this.fn_change != null) {
                this.obj_raw.change((Me: JQueryEventObject) => {
                    setTimeout(() => { this.fn_change(Me) }, 1)
                })
            }
            if (this.fn_focus_in != null) {
                this.obj_raw.focusin(this.fn_focus_in)
            }
            if (this.fn_focus_out != null) {
                this.obj_raw.focusout(this.fn_focus_out)
            }
            if (this.fn_key_press != null) {
                this.obj_raw.keypress(this.fn_key_press)
            }
            if (this.fn_key_down != null) {
                this.obj_raw.keydown(this.fn_key_down)
            }
            if (this.fn_key_up != null) {
                this.obj_raw.keyup(this.fn_key_up)
            }
        }

        //-----------------------------------------------------------------
        //--PROPIEDADES----------------------------------------------------
        /**
         * Obtiene o altera el objeto como si fuera un objeto JQuery.
         */
        get raw(): JQuery {
            return this.obj_raw
        }
        set raw(value: JQuery) {
            this.obj_raw = value
        }

        /**
         * Obtiene o establece el estado de bloqueo del Textbox
         */
        get locked(): boolean {
            return this.bol_locked
        }
        set locked(value: boolean) {
            if (value == true) {
                if (this.bol_loaded == true) {
                    this.obj_raw.attr({ style: `${this.str_style} cursor: pointer; background: #ffffff;` })
                    this.obj_raw.attr({ readonly: "readonly" })
                }
            } else {
                if (this.bol_loaded == true) {
                    this.obj_raw.attr({ style: `${this.str_style}` })
                    this.obj_raw.removeAttr("readonly")
                }
            }

            this.bol_locked = value
        }

        /**
         * Obtiene o establece el estado "habilitado/deshabilitado" del Botón
         */
        get enable(): boolean {
            return this.bol_enable
        }
        set enable(value: boolean) {
            if (value == true) {
                if (this.bol_loaded == true) {
                    this.obj_raw.attr("disabled", "disabled")
                }
            } else {
                if (this.bol_loaded == true) {
                    this.obj_raw.removeAttr("disabled")
                }
            }

            this.bol_enable = value
        }

        /**
         * Obtiene o establece la o las clases del objeto.
         */
        get class(): string {
            return this.str_class
        }
        set class(value: string) {
            this.str_class = value

            if (this.bol_loaded == false) {
                H.form.load = () => {
                    this.obj_raw.attr({ class: value })
                }
            } else {
                this.obj_raw.attr({ class: value })
            }
        }

        //-----------------------------------------------------------------
        //--EVENTOS--------------------------------------------------------
        /**
         * Obtiene o establece el evento click.
         */
        get eventClick(): (Me?: JQueryEventObject) => void {
            return this.fn_click
        }
        set eventClick(value: (Me?: JQueryEventObject) => void) {
            this.fn_click = value

            if (this.bol_loaded == true) {
                if (value != null) {
                    this.obj_raw.click(value)
                } else {
                    this.obj_raw.off("click")
                }
            }
        }
        /**
         * Obtiene o establece el evento Focus.
         */
        get eventFocus(): (Me?: JQueryEventObject) => void {
            return this.fn_focus
        }
        set eventFocus(value: (Me?: JQueryEventObject) => void) {
            this.fn_focus = value

            if (this.bol_loaded == true) {
                if (value != null) {
                    this.obj_raw.focus(value)
                } else {
                    this.obj_raw.off("focus")
                }
            }
        }
        /**
         * Obtiene o establece el evento Change.
         */
        get eventChange(): (Me?: JQueryEventObject) => void {
            return this.fn_change
        }
        set eventChange(value: (Me?: JQueryEventObject) => void) {
            this.fn_change = value

            if (this.bol_loaded == true) {
                if (value != null) {
                    this.obj_raw.change((Me: JQueryEventObject) => {
                        setTimeout(() => { this.fn_change(Me) }, 1)
                    })
                } else {
                    this.obj_raw.off("change")
                }
            }
        }
        /**
         * Obtiene o establece el evento Focus In.
         */
        get eventFocusIn(): (Me?: JQueryEventObject) => void {
            return this.fn_focus_in
        }
        set eventFocusIn(value: (Me?: JQueryEventObject) => void) {
            this.fn_focus_in = value

            if (this.bol_loaded == true) {
                if (value != null) {
                    this.obj_raw.focusin(value)
                } else {
                    this.obj_raw.off("focusin")
                }
            }
        }
        /**
         * Obtiene o establece el evento Focus Out.
         */
        get eventFocusOut(): (Me?: JQueryEventObject) => void {
            return this.fn_focus_out
        }
        set eventFocusOut(value: (Me?: JQueryEventObject) => void) {
            this.fn_focus_out = value

            if (this.bol_loaded == true) {
                if (value != null) {
                    this.obj_raw.focusout(value)
                } else {
                    this.obj_raw.off("focusout")
                }
            }
        }
        /**
         * Obtiene o establece el evento Key Press.
         */
        get eventKeyPress(): (Me?: JQueryEventObject) => void {
            return this.fn_key_press
        }
        set eventKeyPress(value: (Me?: JQueryEventObject) => void) {
            this.fn_key_press = value

            if (this.bol_loaded == true) {
                if (value != null) {
                    this.obj_raw.keypress(value)
                } else {
                    this.obj_raw.off("keypress")
                }
            }
        }
        /**
         * Obtiene o establece el evento Key Down.
         */
        get eventKeyDown(): (Me?: JQueryEventObject) => void {
            return this.fn_key_down
        }
        set eventKeyDown(value: (Me?: JQueryEventObject) => void) {
            this.fn_key_down = value

            if (this.bol_loaded == true) {
                if (value != null) {
                    this.obj_raw.keydown(value)
                } else {
                    this.obj_raw.off("keydown")
                }
            }
        }
        /**
         * Obtiene o establece el evento Key Up.
         */
        get eventKeyUp(): (Me?: JQueryEventObject) => void {
            return this.fn_key_up
        }
        set eventKeyUp(value: (Me?: JQueryEventObject) => void) {
            this.fn_key_up = value

            if (this.bol_loaded == true) {
                if (value != null) {
                    this.obj_raw.keyup(value)
                } else {
                    this.obj_raw.off("keyup")
                }
            }
        }
    }

    /**
     * Clase que permite crear tablas en HTML de forma simple y eficiente.
     */
    export class Ts_Table {
        private obj_raw: JQuery
        private bol_loading: boolean
        private bol_loaded: boolean

        private bol_screen_initial: boolean
        private bol_screen_loading: boolean
        private bol_screen_finish: boolean

        private str_msg_init: string
        private str_msg_none: string

        private arr_headers: Array<ITableCell>
        private arr_data: Array<Array<ITableCell>>
        private arr_cell_box: Array<ITableCell>

        private dtt_is: boolean = false
        private dtt_display_length: number = 10
        private dtt_paginator: boolean = true
        private dtt_filter: boolean = true
        private dtt_sort: boolean = true

        private clickRow: (Me?: JQueryEventObject) => void
        private bol_selectable: boolean
        private num_value: number

        constructor(id_dom: string = null) {
            this.str_msg_init = `Por favor realice una búsqueda.`
            this.str_msg_none = `No se han encontrado Resultados.`

            this.bol_screen_initial = false
            this.bol_screen_loading = false
            this.bol_screen_finish = false

            this.arr_headers = []
            this.arr_data = []
            this.arr_cell_box = []

            if (id_dom != null) {
                H.form.load = () => {
                    this.obj_raw = $(`#${id_dom}`)
                    this._load()
                }
            } else {
                this.bol_loading = false
                this.bol_loaded = false

                this.obj_raw = $("<div>", { id: `table_${count_Table}` })
                count_Table += 1
                this._load()
                //this.obj_raw.on("DOMNodeInserted", () => {
                //    //Controlar Ejecución de la Función
                //    if (this.bol_loading == false) {
                //        this.bol_loading = true
                //        return
                //    }
                //    if (this.bol_loaded == true) {
                //        return
                //    } else {
                //        this.bol_loaded = true
                //    }

                //    //Acciones Internas
                //    this._load()
                //})
            }
        }
        private _load() {
            this.obj_raw.append(
                $("<div>", {
                    class: `alert alert-primary mb-0`
                }).html(this.str_msg_init)
            )

            this.bol_loading = true
            this.bol_loaded = true

            this.bol_screen_initial = true
            this.bol_screen_loading = false
            this.bol_screen_finish = false
        }
        
        /**
         * Obtiene o altera el objeto como si fuera un objeto JQuery.
         */
        get raw(): JQuery {
            return this.obj_raw
        }
        set raw(value: JQuery) {
            this.obj_raw = value
        }

        /**
         * Obtiene o establece el mensaje inicial que muestra el objeto tabla
         */
        get msgInit(): string {
            return this.str_msg_init
        }
        set msgInit(value: string) {
            this.str_msg_init = value

            let fn_do = () => {
                if (this.bol_screen_initial == true) {
                    this.obj_raw.children(".alert").html(this.str_msg_init)
                }
            }

            if (this.bol_loaded == false) {
                H.form.load = () => {
                    fn_do()
                }
            } else {
                fn_do()
            }
        }

        /**
         * Obtiene o establece el mensaje que muestra el objeto tabla cuando no hay resultados que mostrar
         */
        get msgEmpty(): string {
            return this.str_msg_none
        }
        set msgEmpty(value: string) {
            this.str_msg_none = value

            let fn_do = () => {
                if (this.bol_screen_initial == true) {
                    this.obj_raw.children(".alert").html(this.str_msg_none)
                }
            }

            if (this.bol_loaded == false) {
                H.form.load = () => {
                    fn_do()
                }
            } else {
                fn_do()
            }
        }

        /**
         * Muestra el mensaje inicial.
         */
        public showInitial(): void {
            //Current Action
            let fn_do = () => {
                this.obj_raw.children().fadeOut(250, () => {
                    this.obj_raw.empty()
                    let div_loading = $("<div>", {
                        class: `alert alert-primary mb-0`
                    }).html(this.str_msg_init)

                    div_loading.hide()
                    this.obj_raw.append(div_loading)
                    div_loading.fadeIn(250)
                })
            }

            //Handler
            if (this.bol_loaded == false) {
                H.form.load = () => {
                    fn_do()
                }
            } else {
                fn_do()
            }
        }

        /**
         * Muestra el ícono de carga
         */
        public showLoading(): void {
            //Current Action
            let fn_do = () => {
                this.obj_raw.children().fadeOut(250, () => {
                    this.obj_raw.empty()
                    let div_loading = $("<div>", { class: "ts-table-loading", style: "display: none;" }).append(
                        $("<i>", { class: "fa fa-spinner fa-pulse fa-5x fa-fw" }),
                        $("<h3>", { class: "text-center mt-3" }).text("Cargando...")
                    )

                    this.obj_raw.append(div_loading)
                    div_loading.fadeIn(250)
                })
            }

            //Handler
            if (this.bol_loaded == false) {
                H.form.load = () => {
                    fn_do()
                }
            } else {
                fn_do()
            }
        }
        
        /**
         * Crea una nueva columna en su estructura interna
         * @param text      Texto que irá en la tabla.
         * @param alignment Alineación, use "H.cHTMLAlign" para determinar dicha alineación.
         */
        public addHeader(text: string, alignment: IHTMLAlignElement): void {
            this.arr_headers.push({
                content: text,
                align: alignment
            })
        }

        /**
         * Agrega la celda en un "Contenedor Temporal". Cuando el contenedor esté lleno, se puede generar una fila usando el método Ts_Table.makeRow().
         * @param content   Contenido que se agregará a la celda
         * @param alignment Alineación, use "H.HTMLAlign" para determinar dicha alineación.
         */
        public addCellRow(content: string | JQuery | Element, alignment: IHTMLAlignElement): void {
            this.arr_cell_box.push({
                content: content,
                align: alignment
            })
        }

        /**
         * Arma una fila entera a partir de las celdas almacenadas en el "Contenedor Temporal". Además vacía el contenedor en cuestión.
         */
        public makeRow(): void {
            let arr_insert: Array<ITableCell> = []

            this.arr_cell_box.forEach(xitem => {
                arr_insert.push({
                    content: xitem.content,
                    align: xitem.align
                })
            })

            this.arr_data.push(arr_insert)
            this.arr_cell_box = []
        }

        /**
         * Arma la tabla con todos los datos ingresados.
         */
        public makeTable(): void {
            //Current Action
            let fn_do = () => {
                if (this.arr_data.length == 0) {
                    this.bol_screen_initial = true
                    this.bol_screen_loading = false
                    this.bol_screen_finish = false


                    this.obj_raw.children().fadeOut(250, () => {
                        this.obj_raw.empty()
                        this.obj_raw.append(
                            $("<div>", {
                                class: `alert alert-danger mb-0`
                            }).html(this.str_msg_none)
                        )
                    })
                    this.arr_cell_box = []
                    this.arr_data = []
                    this.arr_headers = []
                    return
                }
                

                //Llenar Cabeceras
                let obj_ts_table = $("<table>", { class: "w-100 table table-striped" })
                obj_ts_table.append(
                    $("<thead>").append($("<tr>")),
                    $("<tbody>")
                )

                this.arr_headers.forEach(xitem => {
                    obj_ts_table.find("tr").append(
                        $("<th>", {
                            class: xitem.align.class
                        }).append(xitem.content)
                    )
                })

                //Colocar Celdas
                this.arr_data.forEach((xitem, xi) => {
                    let xrow = $("<tr>", { "data-index": xi })

                    xitem.forEach(xcell => {
                        xrow.append($("<td>", {
                            class: xcell.align.class
                        }).append(xcell.content))
                    })

                    obj_ts_table.append(xrow)
                })

                //Asignar eventos
                obj_ts_table.find(`tbody tr`).click((Me: JQueryEventObject) => {
                    obj_ts_table.find(`tbody tr`).removeClass("selected")
                    $(Me.currentTarget).addClass("selected")

                    this.num_value = parseInt($(Me.currentTarget).attr("data-index"))
                })
                if (this.clickRow != null) {
                    obj_ts_table.find(`tbody tr`).click(this.clickRow)
                }

                this.num_value = null
                this.arr_cell_box = []
                this.arr_data = []
                this.arr_headers = []

                let fn_make_dtt = () => {
                    //Determinar DataTable
                    if (this.dtt_is == true) {
                        //Establecer DataTable
                        let obj_dtt = this.obj_raw.children("table").DataTable({
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
                        })

                        obj_dtt.on("preDraw", () => {
                            obj_ts_table.find(`tbody tr`).removeClass("selected")
                        })
                        obj_dtt.on("draw", () => {
                            obj_ts_table.find(`tbody tr[data-index="${this.num_value}"]`).addClass("selected")
                        })

                        if (this.dtt_paginator == true) {
                            //this.obj_raw.find(`.dataTables_filter`).addClass("pull-right")
                            //this.obj_raw.find(`.dataTables_paginate`).addClass("pull-right")
                        } else {
                            this.obj_raw.find(`table`).parent().addClass("mb-3")
                        }

                        this.obj_raw.find(`.dataTables_filter`).parent().attr({ "class": "col-12 col-sm-9" })
                        this.obj_raw.find(`.dataTables_length`).parent().attr({ "class": "col-12 col-sm-3" })

                        this.obj_raw.find(`table`).parent().addClass("table-responsive")
                        this.bol_screen_initial = false
                        this.bol_screen_loading = false
                        this.bol_screen_finish = true
                    }
                }

                setTimeout(() => {
                    this.obj_raw.children().fadeOut(250, () => {
                        this.obj_raw.empty()
                        this.obj_raw.append(obj_ts_table)

                        fn_make_dtt()
                        obj_ts_table.fadeIn(250)
                    })
                }, 300)
            }

            //Handler
            if (this.bol_loaded == false) {
                H.form.load = () => {
                    fn_do()
                }
            } else {
                fn_do()
            }
        }
        
        /**
         * Establece la instancia actual como tipo Data Table.
         * @param set               Determina si la instancia actual será del tipo Data Table.
         * @param display_length    Establece el número de elementos por página por defecto.
         * @param paginator         Determina si el Paginador será visible.
         * @param filter            Determina si el Filtro será visible.
         * @param sort              Determina si las columnas pueden ordenarse automáticamente.
         */
        public setDataTable(set: boolean = true, display_length: number = 10, paginator: boolean = true, filter: boolean = true, sort: boolean = true) {
            this.dtt_is = set
            this.dtt_display_length = display_length
            this.dtt_paginator = paginator
            this.dtt_filter = filter
            this.dtt_sort = sort
        }

        /**
         * Evento click que se desencadena cuando se hace click en alguna fila.
         */
        get eventClick(): (Me?: JQueryEventObject) => void {
            return this.clickRow
        }
        set eventClick(value: (Me?: JQueryEventObject) => void) {
            this.clickRow = value

            //Current Action
            let fn_do = () => {
                this.obj_raw.off("click")
                if (value != null) {
                    this.obj_raw.find("tbody tr").click(this.clickRow())
                }
            }

            //Handler
            if (this.bol_loaded == false) {
                this.obj_raw.on("DOMNodeInserted", () => {
                    fn_do()
                })
            } else {
                fn_do()
            }
        }

        /**
         * Valor de la celda seleccionada.
         */
        get value(): number {
            return this.num_value
        }
    }   

    /**
     * Clase que permite acceder a los métodos para Textbox.
     */
    export class Ts_Textbox extends Ts_Input {
        private bol_datepicker: boolean
        private bol_timepicker: boolean
        private bol_password: boolean
        private str_value: string

        /**
         * Crea una nueva instancia de la clase "Ts_Textbox".
         * @param id_row ID del elemento dentro del DOM.
         */
        constructor(id_dom: string = null) {
            let obj_new: JQuery = $(`<input>`, {
                type: `text`,
                id: `Txt_${count_Textbox}`,
                class: `form-control`
            })

            count_Textbox += 1
            let load = () => {

                //Tipo contraseña
                if (this.bol_password == true) {
                    this.obj_raw.attr({ type: "password" })
                }

                //Activar datePicker o timePicker
                if (this.bol_datepicker == true) {
                    //datePicker
                    this.loadDatePicker()
                } else if (this.bol_timepicker == true) {
                    //timePicker
                    this.loadTimePicker()
                }

                //Event Obtener valor
                this.str_value = `${this.obj_raw.val()}`
                this.obj_raw.change(() => {
                    this.str_value = `${this.obj_raw.val()}`
                })
            }

            super(id_dom, obj_new, load)
            this.bol_datepicker = false
            this.bol_timepicker = false
            this.bol_password = false
        }

        private loadDatePicker() {
            if (this.bol_loaded == false) {
                return
            }

            //Crear datePicker
            let xpar = this.obj_raw.parent()
            let xcon = $("<div>", { class: "input-group date" })

            let xbuttn = $("<i>", { class: "fa fa-calendar" })
            let xaddon = $("<span>", { class: "input-group-addon" })

            xaddon.append(xbuttn)
            xpar.append(xcon)

            xcon.append(this.obj_raw)
            xcon.append(xaddon)

            this.obj_raw.val(moment().format("DD/MM/YYYY"))
            xcon.datepicker({
                format: "dd/mm/yyyy",
                language: "es",
                autoclose: true
            })
        }
        private unloadDatePicker() {
            if (this.bol_loaded == false) {
                return
            }

            //Alterar datePicker
            let xpar = this.obj_raw.parent()
            let xcon = xpar.parent()

            xpar.datepicker("remove")
            this.obj_raw.detach()

            xpar.remove()
            xcon.append(this.obj_raw)

            this.obj_raw.val("")
        }

        private loadTimePicker() {
            if (this.bol_loaded == false) {
                return
            }

            //Crear timePicker
            let xpar = this.obj_raw.parent()
            let xcon = $("<div>", { class: "input-group clockPicker" })

            let xbuttn = $("<i>", { class: "fa fa-clock-o" })
            let xaddon = $("<span>", { class: "input-group-addon" })

            xaddon.append(xbuttn)
            xpar.append(xcon)

            xcon.append(this.obj_raw)
            xcon.append(xaddon)

            this.obj_raw.val(moment().format("hh:mm"))
            xcon.clockpicker({
                donetext: 'Hecho'
            })
        }
        private unloadTimePicker() {
            if (this.bol_loaded == false) {
                return
            }

            //Alterar timePicker
            let xpar = this.obj_raw.parent()
            let xcon = xpar.parent()

            xpar.clockpicker("remove")
            this.obj_raw.detach()

            xpar.remove()
            xcon.append(this.obj_raw)

            this.obj_raw.val("")
        }

        /**
         * Obtiene o establece el Textbox como Datepicker.
         */
        get datePicker(): boolean {
            return this.bol_datepicker
        }
        set datePicker(value: boolean) {
            //Salir si el elemento todavía no existe en el DOM
            if (this.bol_datepicker == value) {
                return
            }

            this.bol_datepicker = value
            if (this.bol_datepicker == false) {
                return
            }
            
            //Alterar el DOM
            if (value == true) {
                this.bol_timepicker = false

                this.unloadTimePicker()
                this.loadDatePicker()
            } else {
                this.unloadDatePicker()
            }
        }

        /**
         * Obtiene o establece el Textbox como TimePicker.
         */
        get timePicker(): boolean {
            return this.bol_timepicker
        }
        set timePicker(value: boolean) {
            //Salir si el elemento todavía no existe en el DOM
            if (this.bol_timepicker == value) {
                return
            }
            this.bol_timepicker = value
            if (this.bol_loaded == false) {
                return
            }
            
            //Alterar el DOM
            if (value == true) {
                this.bol_datepicker = false

                this.unloadDatePicker()
                this.loadTimePicker()
            } else {
                this.unloadTimePicker()
            }
        }

        /**
         * Obtiene o establece el Textbox del tipo Contraseña.
         */
        get password(): boolean {
            return this.bol_password
        }
        set password(value: boolean) {
            this.bol_password = value

            if (this.bol_loaded == false) {
                return
            }

            if (value == true) {
                this.obj_raw.attr({ type: "password" })
            } else {
                this.obj_raw.attr({ type: "text" })
            }
        }
        
        /**
         * Obtiene o establece el valor del Textbox
         */
        get value(): string {
            return this.str_value
        }
        set value(val: string) {
            this.str_value = val
            if (this.bol_loaded == true) {
                this.obj_raw.val(val)
            }
        }
    }

    /**
     * Clase que permite acceder a los métodos para Botones.
     */
    export class Ts_Button extends Ts_Input {
        private str_icon: string
        private str_text: string
        
        /**
         * Crea una nueva instancia de la clase "Ts_Button".
         * @param id_row ID del elemento dentro del DOM.
         */
        constructor(id_dom: string = null) {
            let obj_new = $(`<button>`, {
                type: `button`,
                id: `Btn_${count_Button}`,
                class: `btn btn-primary`
            })
            obj_new.append(
                $("<i>")
            )

            count_Button += 1
            let load = () => {

                //Activar o desactivar elemento
                if (this.bol_enable == true) {
                    this.obj_raw.attr({ readonly: "readonly" })
                } else {
                    this.obj_raw.removeAttr("readonly")
                }

                //Bloquear o desbloquear elemento
                if (this.bol_locked == true) {
                    this.obj_raw.attr("disabled", "disabled")
                } else {
                    this.obj_raw.removeAttr("disabled")
                }

                //Asignar ícono y texto
                if (this.str_text != null) {
                    this.obj_raw.append($("<span>", { style: "margin-left: 0.5rem;" }))
                    this.obj_raw.find("span").text(this.str_text)
                }
                if (this.str_icon != null) {
                    this.obj_raw.find("i").attr({
                        class: this.str_icon
                    })
                }
            }

            super(id_dom, obj_new, load)
            this.str_icon = null
            this.str_text = null
        }

        /**
         * Obtiene o establece el ícono dentro del botón
         */
        get icon(): string {
            return this.str_icon
        }
        set icon(value: string) {
            this.str_icon = value

            if (this.bol_loaded == false) {
                H.form.load = () => {
                    if (this.obj_raw.find("i").length > 0) {
                        this.obj_raw.find("i").attr({ class: value })
                    } else {
                        this.obj_raw.prepend($("<i>", { class: value }))
                    }
                }
            } else {
                if (this.obj_raw.find("i").length > 0) {
                    this.obj_raw.find("i").attr({ class: value })
                } else {
                    this.obj_raw.prepend("<i>", { class: value })
                }
            }
        }

        /**
         * Obtiene o establece el texto dentro del botón
         */
        get text(): string {
            return this.str_text
        }
        set text(value: string) {
            if (this.str_text == null) {
                if (this.bol_loaded == true) {
                    this.obj_raw.find("span").remove()
                    this.obj_raw.append($("<span>", { style: "margin-left: 0.5rem;" }))
                }
            }
            this.str_text = value

            if (this.bol_loaded == true) {
                this.obj_raw.find("span").remove()
                this.obj_raw.find("span").text(value)
            }
        }
    }

    /**
     * Clase que permite acceder a los métodos para Selects.
     */
    export class Ts_Select extends Ts_Input {
        private arr_data: Array<{ value: any, Text: string }>

        constructor(id_dom: string = null) {
            let obj_new = $("<select>", {
                id: `Sel_${count_Select}`,
                class: `form-control`
            })

            count_Select += 1
            let load = () => {

                this.arr_data.forEach(xItem => {
                    let xVal: string = JSON.stringify({ d: xItem.value })
                    xVal = encodeURI(xVal)
                    xVal = btoa(xVal)

                    let xOption = $(`<option>`, {
                        value: xVal
                    }).text(xItem.Text)

                    this.obj_raw.append(xOption)
                })
                this.arr_data = []
            }

            super(id_dom, obj_new, load)
            this.arr_data = []
        }

        /**
         * Agregar un ítem al Select.
         * @param text      Texto del elemento ingresado.
         * @param value     Objeto a insertar como valor.
         */
        public addItem(text: string, value: any) {
            if (this.bol_loaded == false) {
                this.arr_data.push({
                    value: value,
                    Text: text
                })
            } else {
                let xVal: string = JSON.stringify({ d: value })
                xVal = encodeURI(xVal)
                xVal = btoa(xVal)

                let xOption = $(`<option>`, {
                    value: xVal
                }).text(text)

                this.obj_raw.append(xOption)
            }
        }

        /**
         * Obtiene el Objeto almacenado como valor en el Select.
         */
        get value(): any {
            let xStr: string = this.obj_raw.val()
            let xVal: any

            xStr = atob(xStr)
            xStr = decodeURI(xStr)
            xVal = JSON.parse(xStr)

            return xVal.d
        }

        /**
         * Limpia el contenido del Select
         */
        public clean(): void {
            this.obj_raw.empty()
            this.arr_data = []
        }
    }

    /**
     * Clase que permite acceder a los métodos para Checkbox.
     */
    export class Ts_Checkbox extends Ts_Input {
        private str_text: string
        private bol_checked: boolean

        constructor(id_dom: string = null) {
            let obj_new = $("<input>", {
                type: "checkbox",
                id: `Chk_${count_Checkbox}`,
                "data-text": ""
            })

            count_Checkbox += 1
            let load = () => {
                let xparent = this.obj_raw.parent()
                let xcontainer = $("<div>", {
                    class: `checkbox-group ${this.str_class}`,
                    style: this.str_style
                })
                let xlabel = $("<label>", {
                    for: this.obj_raw.attr("id")
                })
                let xdata_0 = $("<i>", {
                    class: "fa fa-square",
                    "data-value": 0
                })
                let xdata_1 = $("<i>", {
                    class: "fa fa-check-square",
                    "data-value": 1
                })
                let xspan = $("<span>")

                //Determinar texto por Código o por atributo html
                if ((this.str_text == null) || (this.str_text == "")) {
                    xspan.text(this.obj_raw.attr("data-text"))
                    this.str_text = this.obj_raw.attr("data-text")
                } else {
                    xspan.text(this.str_text)
                }

                //Determinar Estado
                if (this.bol_checked == true) {
                    this.obj_raw.prop({ checked: true })
                } else {
                    this.obj_raw.removeAttr("checked")
                }

                xlabel.append(
                    xdata_0,
                    xdata_1,
                    xspan
                )

                xcontainer.append(
                    this.obj_raw,
                    xlabel
                )

                xparent.append(xcontainer)
            }

            super(id_dom, obj_new, load)
            this.bol_checked = false
        }

        /**
         * Obtiene o establece el Texto del Checkbox.
         */
        get text(): string {
            return this.str_text
        }
        set text(value: string) {
            this.str_text = value

            if (this.bol_loaded == true) {
                this.obj_raw.parent().find("span").text(value)
            }
        }

        /**
         * Obtiene o establece el estado de Check del elemento.
         */
        get checked(): boolean {
            this.bol_checked = this.obj_raw.prop("checked")
            return this.bol_checked
        }
        set checked(value: boolean) {
            this.bol_checked = value

            if (this.bol_loaded == true) {
                this.raw.prop("checked", value)
            }
        }
    }
}

namespace H {
    class Class_Form {
        /**
         * Configurar evento de carga
         */
        set load(value: () => void) {
            window.addEventListener("load", value, false)
        }
    }
    /**
     * Instancia general del Formulario
     */
    export let form = new Class_Form()
}

namespace U {
    /**
     * Clase que reúne todos los métodos más recurrentes en el uso de AJAX
     */
    export class Ajax {
        private str_type: string
        private str_contentType: string
        private str_dataType: string

        private str_url_root: string
        private str_url_user: string
        private str_data: any
        private fn_success: (resp: { d: any }) => void
        private fn_error: (resp: any) => void
        private obj_promise: JQueryXHR
        
        /**
         * Crea una instancia de la clase AJAX, definida con sus ajustes por defecto
         */
        constructor() {
            this.str_type = "POST"
            this.str_contentType = "application/json;  charset=utf-8"
            this.str_dataType = "json"

            this.str_url_root = location.href + "/"
            this.str_url_user = null
        }

        /**
         * Obtiene o establece la url del archivo que contiene la función a llamar dek backend.
         */
        get url(): string {
            return this.str_url_root
        }
        set url(value: string) {
            this.str_url_root = value

            if (value.match(/\/$/gi) == null) {
                this.str_url_root += "/"
            }
        }

        /**
         * Obtiene o establece el nombre de la función a llamar en el backend
         */
        get functName() {
            return this.str_url_user
        }
        set functName(value: string) {
            this.str_url_user = value

            if (value.match(/^\//gi) == null) {
                this.str_url_user = value.replace(/^\//gi, "")
            }
        }

        /**
         * Obtiene o establece la función asíncrona que será ejecutada cuando la petición se realiza correctamente
         */
        get success() {
            return this.fn_success
        }
        set success(fn: (resp: { d: any }) => void) {
            this.fn_success = fn
        }

        /**
         * Obtiene o establece la función asíncrona que será ejecutada cuando la petición lanza una excepción
         */
        get error() {
            return this.fn_success
        }
        set error(fn: (fail: any) => void) {
            this.fn_error = fn
        }

        /**
         * Ejecuta la petición asíncrona utilizando un objeto que contenga los parámetros que requiere la función de destino.
         * @param parameters 
         */
        public requestNow(parameters: any = null) {
            let obj_options: JQueryAjaxSettings = {}
            obj_options.type = this.str_type
            obj_options.url = `${this.str_url_root}${this.str_url_user}`
            obj_options.contentType = this.str_contentType
            obj_options.dataType = this.str_dataType
            obj_options.success = this.fn_success
            obj_options.error = this.fn_error

            if (parameters != null) {
                obj_options.data = JSON.stringify(parameters)
            }

            this.obj_promise = $.ajax(obj_options)
        }

        /**
         * Obtiene la promesa asíncrona cuando ésta es ejecutada. Cuando el objeto AJAX todavía no ejecuta la llamada devuelve null.
         */
        get promise(): JQueryXHR {
            return this.promise
        }
    }
}