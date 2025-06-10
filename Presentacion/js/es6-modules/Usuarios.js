import fetcher from '../../js/es6-modules/FetcherV1.js';
import { fillSelect } from './SelectElement.js';
/**
 * Busca los usuarios y llena el o los select que se le pasan.
 *
 * @async
 * @param {Object} [options] - Optional settings- si no se le pasa nada, retorna un listado con todos los usuarios.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar.
 * @param {boolean} [options.placeholder=true] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.placeholderText="Todas"] - El texto que se quiere mostrar en el placeholder.
 * @param {number} [options.defaultValue=-1] - El valor que se desea seleccionar automáticamente.
 * @returns {Promise<{ID_USUARIO: number, USU_FULL_NAME: string, USU_NIC: string}[]>}
 */
const fillUsuariosPorProcedencia = async (idProcedencia, { idSelect = "", placeholder = false, placeholderText = "Seleccione Usuario", defaultValue = -1 } = {}) => {
    const fillSelect = (array, id) => {
        const select = document.getElementById(id);
        select.innerHTML = '';
        if (placeholder && placeholderText) {
            const placeholderOption = document.createElement('option');
            placeholderOption.value = 0;
            placeholderOption.text = placeholderText;
            select.appendChild(placeholderOption);
        }
        array.forEach(item => {
            const option = document.createElement('option');
            option.value = item.ID_USUARIO;
            option.text = `${item.USU_FULL_NAME} (${item.USU_NIC})`;
            select.appendChild(option);
        });
        if (defaultValue > -1) {
            select.value = defaultValue
        }
    };
    const resOk = res => {
        if (!idSelect) {
            return
        }
        if (idSelect !== "") { 
            if (typeof idSelect === "object") {
                idSelect.forEach((item) => fillSelect(res, item));
            }
            else {
                fillSelect(res, idSelect);
            }
        }
    };
    const response = await fetcher('/Index.aspx/buscarUsuariosPorProcedencia', { afterResOk: resOk, method: "post", body: { idProcedencia } });
    return Promise.resolve(response);
};

/**
 * Busca los usuarios y llena el o los select que se le pasan.
 *
 * @async
 * @param {number} [idProcedencia] - id de la procedencia por la que se quieren filtrar los usuarios
 * @param {Object} [options] - Optional settings- si no se le pasa nada, retorna un listado con todos los usuarios.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar.
 * @param {boolean} [options.placeholder=true] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.placeholderText="Todas"] - El texto que se quiere mostrar en el placeholder.
 * @param {number} [options.defaultValue=-1] - El valor que se desea seleccionar automáticamente.
 * @param {number} [options.flebotomista=false] - Pasar en true si solo se quieren mostrar los flebotomistas.
 * @returns {Promise<{ID_USUARIO: number, USU_FULL_NAME: string, USU_NIC: string}[]>}
 */
const fillUsuariosPorProcedenciaFlebotomista = async (idProcedencia, { idSelect = "", placeholder = false, placeholderText = "Seleccione Usuario", defaultValue = -1, flebotomista = false } = {}) => {
    const afterResOk = array => {
        fillSelect({
            array,
            idSelect,
            placeholder,
            placeholderText,
            defaultValue,
            valueProperty: "ID_USUARIO",
            textProperty: "USU_FULL_NAME",
        });
    };
    const response = await fetcher('/Index.aspx/buscarUsuariosPorProcedenciaFlebotomista', { afterResOk, body: { idProcedencia, flebotomista } });
    return Promise.resolve(response);
};

/**
 * Busca los usuarios y llena el o los select que se le pasan.
 *
 * @async
 * @param {Object} [options] - Optional settings- si no se le pasa nada, retorna un listado con todos los usuarios.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar.
 * @param {boolean} [options.placeholder=true] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.placeholderText="Todas"] - El texto que se quiere mostrar en el placeholder.
 * @param {number} [options.defaultValue=-1] - El valor que se desea seleccionar automáticamente.
 * @returns {Promise<{ID_USUARIO: number, USU_FULL_NAME: string, USU_NIC: string}[]>}
 */
const fillUsuariosPorProcedenciaFlebo = async (idProcedencia, { idSelect = "", placeholder = false, placeholderText = "Seleccione Usuario", defaultValue = -1 } = {}) => {
    const fillSelect = (array, id) => {
        const select = document.getElementById(id);
        select.innerHTML = '';
        if (placeholder && placeholderText) {
            const placeholderOption = document.createElement('option');
            placeholderOption.value = 0;
            placeholderOption.text = placeholderText;
            select.appendChild(placeholderOption);
        }
        array.forEach(item => {
            const option = document.createElement('option');
            option.value = item.ID_USUARIO;
            option.text = `${item.USU_FULL_NAME} (${item.USU_NIC})`;
            select.appendChild(option);
        });
        if (defaultValue > -1) {
            select.value = defaultValue;
        }
    };
    const resOk = res => {
        if (!idSelect) {
            return;
        }
        if (idSelect !== "") {
            if (typeof idSelect === "object") {
                idSelect.forEach((item) => fillSelect(res, item));
            }
            else {
                fillSelect(res, idSelect);
            }
        }
    };
    const response = await fetcher('/Index.aspx/buscarUsuariosPorProcedenciaFlebo', { afterResOk: resOk, method: "post", body: { idProcedencia } });
    return Promise.resolve(response);
};

export { fillUsuariosPorProcedenciaFlebotomista, fillUsuariosPorProcedenciaFlebo };
export default fillUsuariosPorProcedencia;