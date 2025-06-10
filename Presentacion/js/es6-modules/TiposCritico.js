import fetcher from '../../js/es6-modules/Fetcher.js';
import { fillSelect } from './SelectElement.js';
/**
 * Busca los tipos de criíticos y llena el o los select que se le pasan.
 *
 * @async
 * @param {Object} [options] - Optional settings- si no se le pasa nada, retorna un listado con todos los tipos de críticos activos.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar.
 * @param {boolean} [options.placeholder=true] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.placeholderText="Todas"] - El texto que se quiere mostrar en el placeholder.
 * @param {number} [options.idTipoCritico=0] - Si se necesita restringir el tipo de crítico que puede seleccionar, se le pasa el id.
 * @returns {Promise<{ID_TP_CRITICO: number, TP_CRITICO_COD: string, TP_CRITICO_DESC: string, ID_ESTADO: number}[]>}
 */
const fillTiposCritico = async ({ idSelect = "", placeholder = true, placeholderText = "Todos", idTipoCritico = 0, defaultValue = -1 } = {}) => {
    const afterResOk = array => {
        fillSelect({
            array,
            idSelect,
            placeholder,
            placeholderText,
            defaultValue,
            valueProperty: "ID_TP_CRITICO",
            textProperty: "TP_CRITICO_DESC",
            idRestriccion: idTipoCritico
        });
    };
    const response = await fetcher('/Index.aspx/buscarTiposCritico', { afterResOk, method: "post" });
    return Promise.resolve(response);
};
export default fillTiposCritico;