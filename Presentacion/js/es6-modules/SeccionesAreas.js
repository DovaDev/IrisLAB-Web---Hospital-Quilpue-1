import fetcher from '../../js/es6-modules/FetcherV1.js';
import { fillSelect } from './SelectElement.js';
/**
 * Busca las secciones-areas o areas-secciones y llena el o los select que se le pasan.
 *
 * @async
 * @param {Object} [options] - Optional settings- si no se le pasa nada, retorna un listado con todas las secciones-areas o areas-secciones no se.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar. Pasar array con los id de los elementos para llenar varios.
 * @param {boolean} [options.placeholder=true] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.placeholderText="Todas"] - El texto que se quiere mostrar en el placeholder.
 * @param {string} [options.defaultValue=-1] - El id del item que se quiere dejar seleccionado, si no existe deja el primero.
 * @param {string} [options.idAtencion=0] - El id de la atención de la que se quieren filtrar los resultados.
 * @param {string} [options.placeholderWhenSingle=true] - Si se quiere poner el placeholder aunque venga sólo 1 resultado.
 * @returns {Promise<{ID_RLS_LS: number, ID_LABO: number, ID_SECCION: number, RLS_LS_DESC: string, ID_ESTADO: number}[]>}
 */
const fillSeccionesAreas = async ({ idSelect = "", placeholder = true, placeholderText = "Todas", defaultValue = -1, idAtencion = 0, placeholderWhenSingle = true } = {}) => {
    const afterResOk = array => {
        fillSelect({
            array,
            idSelect,
            placeholder,
            placeholderText,
            defaultValue,
            valueProperty: "ID_RLS_LS",
            textProperty: "RLS_LS_DESC",
            placeholderWhenSingle
        });
    };
    const response = await fetcher('/Index.aspx/buscarSeccionArea2', { afterResOk, method: "post", body: { idAtencion } });
    return Promise.resolve(response);
};
/**
 * Busca las secciones y llena el o los select que se le pasan.
 *
 * @async
 * @param {number} idArea - id del área de la que se quieren buscar las secciones, si es 0 trae todas.
 * @param {Object} [options] - Optional settings- si no se le pasa nada, retorna un listado con todas las secciones.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar. Pasar array con los id de los elementos para llenar varios.
 * @param {boolean} [options.placeholder=true] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.placeholderText="Todas"] - El texto que se quiere mostrar en el placeholder.
 * @param {string} [options.defaultValue=-1] - El id del item que se quiere dejar seleccionado, si no existe deja el primero.
 * @param {string} [options.idAtencion=0] - El id de la atención de la que se quieren filtrar los resultados.
 * @param {string} [options.placeholderWhenSingle=true] - Si se quiere poner el placeholder aunque venga sólo 1 resultado.
 * @returns {Promise<{ID_SECCION: number, SECC_COD: string, SECC_DESC: string, ID_ESTADO: number}[]>}
 */
const fillSecciones = async (idArea, { idSelect = "", placeholder = true, placeholderText = "Todas", defaultValue = -1, idAtencion = 0, placeholderWhenSingle = true } = {}) => {
    const afterResOk = array => {
        fillSelect({
            array,
            idSelect,
            placeholder,
            placeholderText,
            defaultValue,
            valueProperty: "ID_SECCION",
            textProperty: "SECC_DESC",
            placeholderWhenSingle
        });
    };

    const response = await fetcher('/Index.aspx/buscarSeccionesActivas', { afterResOk, method: "post", body: { idArea, idAtencion } });
    return Promise.resolve(response);
};
/**
 * Busca las áreas y llena el o los select que se le pasan.
 *
 * @async
 * @param {Object} [options] - Optional settings- si no se le pasa nada, retorna un listado con todas las secciones.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar. Pasar array con los id de los elementos para llenar varios.
 * @param {boolean} [options.placeholder=true] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.placeholderText="Todas"] - El texto que se quiere mostrar en el placeholder.
 * @param {string} [options.defaultValue=-1] - El id del item que se quiere dejar seleccionado, si no existe deja el primero.
 * @param {string} [options.idAtencion=0] - El id de la atención de la que se quieren filtrar los resultados.
 * @param {string} [options.placeholderWhenSingle=true] - Si se quiere poner el placeholder aunque venga sólo 1 resultado.
 * @returns {Promise<{ID_AREA: number, AREA_COD: string, AREA_DESC: string, ID_ESTADO: number}[]>}
 */
const fillAreas = async ({ idSelect = "", placeholder = false, placeholderText = "Todas", defaultValue = -1, idAtencion = 0, placeholderWhenSingle = true } = {}) => {
    const afterResOk = array => {
        fillSelect({
            array,
            idSelect,
            placeholder,
            placeholderText,
            defaultValue,
            valueProperty: "ID_AREA",
            textProperty: "AREA_DESC",
            placeholderWhenSingle
        });
    };
    const response = await fetcher('/Index.aspx/buscarAreasTrabajoActivas', { afterResOk, method: "post", body: { idAtencion } });
    return Promise.resolve(response);
};
export { fillSecciones, fillAreas };
export default fillSeccionesAreas;