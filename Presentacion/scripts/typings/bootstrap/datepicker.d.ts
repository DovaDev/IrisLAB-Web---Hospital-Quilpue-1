interface JQuery {
    /**
    * Implementa un Modal con selección de Fecha.
    * @param options Objeto que contiene toda la configuración inicial del Datepicker.
    */
    datepicker(options?: DatePicker_objParam): JQuery;
}

interface DatePicker_objParam {
    /**
    * Formato de la fecha a mostrar en el Textbox.
    */
    format?: string;

    /**
    * Idioma del Datepicker
    */
    language?: string;

    /**
    * Determina si el modal se cerrará automáticamente al clickear en un elemento.
    */
    autoclose?: boolean;

    /**
    * Determina si se debe de marcar el día actual en el Datepicker.
    */
    todayHighlight?: boolean;
}
