import fetcher from '../../js/es6-modules/Fetcher.js';
/**
 * Busca las procedencias y llena el o los select que se le pasan.
 *
 * @async
 * @param {Object} [options] - Optional settings- si no se le pasa nada, retorna un listado con todas las procedencias.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar. (default: "").
 * @param {boolean} [options.placeholder=false] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.). (default: false).
 * @param {string} [options.placeholderText="Todas"] - El texto que se quiere mostrar en el placeholder. (default: "Todas").
 * @param {number} [options.idProcedencia=0] - Si se necesita restringir por usuario la procedencia que puede seleccionar, se le pasa el id que se guarda en los datos del usuario. (default: 0).
 * @returns {Promise<{ID_PROCEDENCIA: string, PROC_COD: string, PROC_DESC: string, ID_ESTADO: string}[]>}
 */
const fillProcedencias = async ({ idSelect = "", placeholder = false, placeholderText = "Todas", idProcedencia = 0 } = {}) => {
    idProcedencia = parseInt(idProcedencia) || 0;
    const fillSelect = (array, id) => {
        const select = document.getElementById(id);
        select.innerHTML = '';
        if (placeholder && placeholderText && idProcedencia === 0) {
            const placeholderOption = document.createElement('option');
            placeholderOption.value = 0;
            placeholderOption.text = placeholderText;
            select.appendChild(placeholderOption);
        }
        array.forEach(item => {
            const option = document.createElement('option');
            option.value = item.ID_PROCEDENCIA;
            option.text = item.PROC_DESC;
            select.appendChild(option);
        });
    };
    const resOk = res => {
        res = res.filter(item => item.ID_PROCEDENCIA == idProcedencia || idProcedencia === 0);
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
    const response = await fetcher('/Index.aspx/buscarProcedenciasActivas', { afterResOk: resOk, method: "post" });
    return Promise.resolve(response);
};
export default fillProcedencias;