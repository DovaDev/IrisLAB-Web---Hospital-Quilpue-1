import fetcher from '../../js/es6-modules/FetcherV1.js';
import { fillSelect } from './SelectElement.js';
/**
 * Busca las etnias y llena el o los select que se le pasan.
 *
 * @async
 * @param {Object} [options] - Optional settings- si no se le pasa nada, retorna un listado con todas las etnias.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar.
 * @param {boolean} [options.placeholder=true] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.placeholderText="Todas"] - El texto que se quiere mostrar en el placeholder.
 * @param {number} [options.defaultValue=-1] - El valor de default que se quiere dejar seleccionado al cargar el select.
 * @returns {Promise<{ID_ETNIA: number, ETNIA_DESC: string, ID_ESTADO: number}[]>}
 */
const fillEtnias = async ({ idSelect = "", placeholder = false, placeholderText = "Seleccione", defaultValue = -1 } = {}) => {
    const afterResOk = array => {
        fillSelect({
            array,
            idSelect,
            placeholder,
            placeholderText,
            defaultValue,
            valueProperty: "ID_ETNIA",
            textProperty: "ETNIA_DESC",
        });
    };
    const response = await fetcher('/Index.aspx/buscarEtnias', { afterResOk, method: "post" });
    return Promise.resolve(response);
};
export default fillEtnias;