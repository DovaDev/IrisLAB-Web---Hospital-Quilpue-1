import fetcher from '../../js/es6-modules/FetcherV1.js';
/**
 * Enum para representar los tipos de impresion que tiene irisprint.
 * @enum {string}
 */
const Impresiones = Object.freeze({
    /**
     * URL para imprimir todas las etiquetas de la atención. 
     * Parametro acepta [id_atencion].
     * @property {string}
     */
    ETIQUETAS: "http://localhost:9990/Printer/Imp_Etiquetas",
    /**
     * URL para imprimir todas las etiquetas de la atención sin la etiqueta de solicitud. 
     * Parametro acepta [id_atencion].
     * @property {string}
     */
    ETQ_NO_SOL: "http://localhost:9990/Printer/Imp_Etiquetas_No_Sol",
    /**
     * URL para imprimir comprobante de la atención. 
     * Parametro acepta [id_atencion].
     * @property {string}
     */
    COMP_ATEN: "http://localhost:9990/Printer/Imp_Voucher_Compr_Ate",
    /**
     * URL para imprimir comprobante de la toma de muestra.
     * @property {string}
     */
    COMP_TDEM: "http://localhost:9990/Printer/Imp_Voucher_Lugar_TM",
    /**
     * URL para imprimir etiquetas de una atención. 
     * Parametro acepta un objeto de este tipo:
     * {
     *    ID_ATE: id_ate,
     *    ID_TMU: ID_T_MUESTRA[]
     * }
     * @property {string}
     */
    ETIQET_CB: "http://localhost:9990/Printer/Imp_Etiquetas_Cod_Barra",
});
/**
 * Busca los exámenes de la sección y llena el o los select que se le pasan.
 *
 * @async
 * @param {Object} [options] - Optional settings- si no se le pasa nada, retorna un listado con todos los exámenes en la sección.
 * @param {(string|string[])} [options.datos=""] - El array con los id que se le mandan al iris print.
 * @param {boolean} [options.tipoDeImpresion=true] - usar el enum Impresiones para seleccionar entre las impresiones disponibles
 * @param {Function} [options.callback=()=>{}] - se ejecuta después de que responda IrisPrint y cerrar el Swal de éxito de impresión
 * @param {boolean} [options.mostrarMsgExito=true] - para mostrar o no el Swal que dice impresión exitosa
 * @returns {Promise<{ID_CODIGO_FONASA: number, CF_DESC: string}[]>}
 */
const irisPrint = async ({ datos = [], tipoDeImpresion = "", callback = () => { }, mostrarMsgExito = true } = {}) => {
    const afterResNotOk = res => {
        Swal.fire({
            icon: 'error',
            title: 'Error',
            html: `<div>Ex Type: ${res?.responseJSON?.ExceptionType || "0"}</div>
                   <div>Mensaje: ${res?.responseJSON?.Message || "Error en el Front End"}</div>
                   <div>StackTrace: ${res?.responseJSON?.StackTrace || "Mire la consola para Detalles"} </div>`,
        }).then(callback);
    };
    const afterResOk = res => {
        if (mostrarMsgExito) {
            Swal.fire({
                icon: 'success',
                title: 'Éxito',
                html: `<div>${res.Code == 1000002 ? "Esta atención no posee exámenes pendientes." : res.Message}</div>`,
            }).then(callback);
        } else {
            callback();
        }
    };
    const afterCatch = res => {
        Swal.fire({
            icon: 'error',
            title: 'Error',
            html: `Error de conexión con interfaz de impresión.<br/> Asegúrese de que IrisPrint esté abierto y en funcionamiento antes de continuar.`,
        }).then(callback);
    };
    const response = await fetcher(tipoDeImpresion, { afterResOk, afterResNotOk, afterCatch, method: "POST", body: datos });
    return Promise.resolve(response);
};

export { irisPrint, Impresiones };