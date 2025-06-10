import fetcher from '../../js/es6-modules/Fetcher.js';
/**
 * Busca los programas y llena el o los select que se le pasan.
 *
 * @async
 * @param {number} idProcedencia - Obligatorio, se debe mandar el id de la previsión donde se quieren buscar programas.
 * @param {Object} [options] - Optional settings - si no se le pasa nada, retorna un listado con todas las programas.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar.
 * @param {boolean} [options.placeholder=true] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.placeholderText="Todas"] - El texto que se quiere mostrar en el placeholder.
 * @param {Function} [options.callback=()=>{}] - función que se ejecuta después de llenar los select.
 * @returns {Promise<{ID_PROGRA: number, ID_PREVE: number, PROGRA_DESC: string, ID_ESTADO: number, ESTADO: number}[]>}
 */
const fillProgramasPorPrevision = async (idPrevision, { idSelect = "", placeholder = false, placeholderText = "Todos", callback = () => { } } = {}) => {
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
            option.value = item.ID_PROGRA;
            option.text = item.PROGRA_DESC;
            select.appendChild(option);
        });
    };
    const resOk = async (res) => {
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
    const response = await fetcher('/Index.aspx/buscaProgramaPorPrevision', { afterResOk: resOk, method: "post", body: { idPrevision } });
    return Promise.resolve(response);
};

/**
 * Busca los programas y llena el o los select que se le pasan.
 *
 * @async
 * @param {number} idProcedencia - Obligatorio, se debe mandar el id de la previsión donde se quieren buscar programas.
 * @param {Object} [options] - Optional settings - si no se le pasa nada, retorna un listado con todas las programas.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar.
 * @param {boolean} [options.placeholder=true] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.placeholderText="Todas"] - El texto que se quiere mostrar en el placeholder.
 * @param {Function} [options.callback=()=>{}] - función que se ejecuta después de llenar los select.
 * @returns {Promise<{ID_PROGRA: number,PROGRA_COD: string, PROGRA_DESC: string, ID_ESTADO: number}[]>}
 */
const fillProgramas = async ({ idSelect = "", placeholder = false, placeholderText = "Todos", callback = () => { } } = {}) => {
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
            option.value = item.ID_PROGRA;
            option.text = item.PROGRA_DESC;
            select.appendChild(option);
        });
    };
    const resOk = async (res) => {
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
    const response = await fetcher('/Index.aspx/buscaPrograma', { afterResOk: resOk, method: "post" });
    return Promise.resolve(response);
};

export default fillProgramas;
export { fillProgramasPorPrevision }