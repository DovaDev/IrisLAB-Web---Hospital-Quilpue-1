import fetcher from '../../js/es6-modules/Fetcher.js';
/**
 * Busca los bloques y llena el o los select que se le pasan.
 *
 * @async
 * @param {Object} [options] - Optional settings- si no se le pasa nada igual retorna un listado con todos los bloques.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar.
 * @param {boolean} [options.placeholder=true] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.placeholderText="Todas"] - El texto que se quiere mostrar en el placeholder.
 * @returns {Promise<{ID_BLOQUE: number, BLOQUE_COD: string, BLOQUE_DESC: string, ID_ESTADO: number, BLOQUE_ORDEN: number}[]>}
 */
const fillBloques = async ({ idSelect = "", placeholder = false, placeholderText = "Todos" } = {}) => {
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
            option.value = item.ID_BLOQUE;
            option.text = item.BLOQUE_DESC;
            select.appendChild(option);
        });
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
    const response = await fetcher('/Index.aspx/Buscar_Bloques', { afterResOk: resOk, method: "post" });
    return Promise.resolve(response);
};
export default fillBloques;