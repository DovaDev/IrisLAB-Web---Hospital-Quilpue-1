import fetcher from '../../js/es6-modules/Fetcher.js';
/**
 * Busca las secciones-areas o areas-secciones y llena el o los select que se le pasan.
 *
 * @async
 * @param {Object} [options] - Optional settings- si no se le pasa nada, retorna un listado con todas las secciones-areas o areas-secciones no se.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar. Pasar array con los id de los elementos para llenar varios.
 * @param {boolean} [options.placeholder=true] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.placeholderText="Todas"] - El texto que se quiere mostrar en el placeholder.
 * @returns {Promise<{ID_RLS_LS: number, ID_LABO: number, ID_SECCION: number, RLS_LS_DESC: string, ID_ESTADO: number}[]>}
 */
const fillSeccionesAreas = async ({ idSelect = "", placeholder = true, placeholderText = "Todas", keep = [] } = {}) => {

    const fillSelect = (array, id) => {
        const select = document.getElementById(id);
        select.innerHTML = '';
        if (placeholder && placeholderText) {
            const placeholderOption = document.createElement('option');
            placeholderOption.value = 0;
            placeholderOption.text = placeholderText;
            select.appendChild(placeholderOption);
        }

        array = array.filter(item => keep.length == 0 || keep.includes(parseInt(item.ID_RLS_LS)));
        array.forEach(item => {
            const option = document.createElement('option');
            option.value = item.ID_RLS_LS;
            option.text = item.RLS_LS_DESC;
            select.appendChild(option);
        });
    };
    const resOk = res => {
        if (!idSelect) {
            return
        }
        if (typeof idSelect === "object") {
            idSelect.forEach((item) => fillSelect(res, item));
        }
        else {
            fillSelect(res, idSelect);
        }
    };
    const response = await fetcher('/Index.aspx/buscarSeccionArea', { afterResOk: resOk, method: "post" });
    return Promise.resolve(response);
};
/**
 * Busca las secciones y llena el o los select que se le pasan.
 *
 * @async
 * @param {Object} [options] - Optional settings- si no se le pasa nada, retorna un listado con todas las secciones.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar. Pasar array con los id de los elementos para llenar varios.
 * @param {boolean} [options.placeholder=true] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.placeholderText="Todas"] - El texto que se quiere mostrar en el placeholder.
 * @returns {Promise<{ID_SECCION: number, SECC_COD: string, SECC_DESC: string, ID_ESTADO: number}[]>}
 */
const fillSecciones = async ({ idSelect = "", placeholder = true, placeholderText = "Todas" } = {}) => {

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
            option.value = item.ID_SECCION;
            option.text = item.SECC_DESC;
            select.appendChild(option);
        });
    };
    const resOk = res => {
        if (!idSelect) {
            return
        }
        if (typeof idSelect === "object") {
            idSelect.forEach((item) => fillSelect(res, item));
        }
        else {
            fillSelect(res, idSelect);
        }
    };
    const response = await fetcher('/Index.aspx/buscarSeccionesActivas', { afterResOk: resOk, method: "post" });
    return Promise.resolve(response);
};
export { fillSecciones };
export default fillSeccionesAreas;