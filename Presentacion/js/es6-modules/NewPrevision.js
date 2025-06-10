import fetcher from '../../js/es6-modules/Fetcher.js';
/**
 * Busca las previsione y llena el o los select que se le pasan.
 *
 * @async
 * @param {Object} [options] - Optional settings- si no se le pasa nada, retorna un listado con todas las previsiones.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar.
 * @param {boolean} [options.placeholder=true] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.placeholderText="Todas"] - El texto que se quiere mostrar en el placeholder.
 * @param {number} [options.idPrevision=0] - Si se necesita restringir por usuario la previsión que puede seleccionar, se le pasa el id que se guarda en los datos del usuario.
 * @param {Function} [options.callback=()=>{}] - función que se ejecuta después de llenar los select.
 * @returns {Promise<{ID_PREVE: number, PREVE_COD: string, PREVE_DESC: string, ID_ESTADO: number, ID_LAB: number, PREVE_PARTICULAR: number}[]>}
 */
const fillPrevisiones = async ({ idSelect = "", placeholder = false, placeholderText = "Todas", idPrevision = 0, callback = () => { } } = {}) => {
    idPrevision = parseInt(idPrevision) || 0;
    const fillSelect = (array, id) => {
        const select = document.getElementById(id);
        select.innerHTML = '';
        if (placeholder && placeholderText && idPrevision === 0) {
            const placeholderOption = document.createElement('option');
            placeholderOption.value = 0;
            placeholderOption.text = placeholderText;
            select.appendChild(placeholderOption);
        }
        array.forEach(item => {
            const option = document.createElement('option');
            option.value = item.ID_PREVE;
            option.text = item.PREVE_DESC;
            select.appendChild(option);
        });
    };
    const resOk = async (res) => {
        res = res.filter(item => item.ID_PREVE == idPrevision || idPrevision === 0);
        if (!idSelect) {
            await callback();
            return
        }
        if (typeof idSelect === "object") {
            idSelect.forEach((item) => fillSelect(res, item));
        }
        else {
            fillSelect(res, idSelect);
        }
        await callback();
    };
    const response = await fetcher('/Index.aspx/buscarPrevisionesActivas', { afterResOk: resOk, method: "post" });
    return Promise.resolve(response);
};
export { fillPrevisiones };