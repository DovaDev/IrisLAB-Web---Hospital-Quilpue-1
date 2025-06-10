import fetcher from '../../js/es6-modules/Fetcher.js';
/**
 * Busca los tipos de atención y llena el o los select que se le pasan.
 *
 * @async
 * @param {Object} [options] - Optional settings- si no se le pasa nada, retorna un listado con todos los tipos de atencion activos.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar.
 * @param {boolean} [options.placeholder=true] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.placeholderText="Todas"] - El texto que se quiere mostrar en el placeholder.
 * @param {number} [options.idTipoAtencion=0] - Si se necesita restringir el tipo de atención que puede seleccionar, se le pasa el id.
 * @param {number} [options.remove=[]] - Si se quieren sacar algunos, se le pasa un array con los values del select que no se quieren incluir.
 * @returns {Promise<{ID_TP_ATENCION: number, TP_ATE_COD: string, TP_ATE_DESC: string, ID_ESTADO: number}[]>}
 */
const fillTiposAtencion = async ({ idSelect = "", placeholder = true, placeholderText = "Todos", idTipoAtencion = 0, remove = [] } = {}) => {
    idTipoAtencion = parseInt(idTipoAtencion) || 0;
    const fillSelect = (array, id) => {
        const select = document.getElementById(id);
        select.innerHTML = '';
        if (placeholder && placeholderText && idTipoAtencion === 0) {
            const placeholderOption = document.createElement('option');
            placeholderOption.value = 0;
            placeholderOption.text = placeholderText;
            select.appendChild(placeholderOption);
        }
        array = array.filter(item => !remove.includes(parseInt(item.ID_TP_ATENCION)) || idTipoAtencion != 0);
        array.forEach(item => {
            const option = document.createElement('option');
            option.value = item.ID_TP_ATENCION;
            option.text = item.TP_ATE_DESC;
            select.appendChild(option);
        });
    };
    const resOk = res => {
        res = res.filter(item => item.ID_TP_ATENCION == idTipoAtencion || idTipoAtencion === 0);
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
    const response = await fetcher('/Index.aspx/buscarTiposAtencionActivo', { afterResOk: resOk, method: "post" });
    return Promise.resolve(response);
};
export default fillTiposAtencion;