import fetcher from '../../js/es6-modules/Fetcher.js';
/**
 * Busca las previsione y llena el o los select que se le pasan.
 *
 * @async
 * @param {Object} [options] - Optional settings- si no se le pasa nada, retorna un listado con todas las previsiones.
 * @param {number} [options.numeroAtencion=0] - El numero de atención actual.
 * @param {number} [options.direccion=true] - La dirección en la que se quiere buscar si es mayor al actual dejar true, si es menor false.
 * @returns {Promise<ATE_NUM: number>}
 */
const buscaNumeroAtencionFlecha = async ({ numeroAtencion = 0, direccion = true, idCodigoFonasa } = {}) => {
    const body = {
        numeroAtencion,
        direccion,
        idCodigoFonasa,
    }
    const response = await fetcher('/Resultados/Ate_Resultados_2.aspx/busca_numero_atencion_l_r', { method: "post", body });
    return Promise.resolve(response);
};
export default buscaNumeroAtencionFlecha;