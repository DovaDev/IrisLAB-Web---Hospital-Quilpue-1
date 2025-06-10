import fetcher from '../../js/es6-modules/Fetcher.js';
/**
 * Busca los ordenes de atención y llena el o los select que se le pasan.
 *
 * @async
 * @param {Object} [options] - Optional settings- si no se le pasa nada, retorna un listado con todos los ordenes de atención.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar.
 * @param {boolean} [options.placeholder=true] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.placeholderText="Todas"] - El texto que se quiere mostrar en el placeholder.
 * @param {number} [options.defecto=0] - El valor que se desea seleccionar automáticamente.
 * @returns {Promise<{ID_ORDEN: number, ORD_COD: string, ORD_DESC: string, ID_ESTADO: number}[]>}
 */
const fillOrdenAtencion = async ({ idSelect = "", placeholder = false, placeholderText = "Seleccione", defecto = 0 } = {}) => {
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
            option.value = item.ID_ORDEN;
            option.text = item.ORD_DESC;
            select.appendChild(option);
        });
        if (placeholder || defecto) {
            select.value = defecto
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
    const response = await fetcher('/Index.aspx/buscarOrdenAtencion', { afterResOk: resOk, method: "post" });
    return Promise.resolve(response);
};
export default fillOrdenAtencion;