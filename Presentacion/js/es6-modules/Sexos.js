import fetcher from '../../js/es6-modules/Fetcher.js';
/**
 * Busca los sexos y llena el o los select que se le pasan.
 *
 * @async
 * @param {Object} [options] - Optional settings- si no se le pasa nada, retorna un listado con todos los sexos.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar.
 * @param {boolean} [options.placeholder=false] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.placeholderText="Seleccione"] - El texto que se quiere mostrar en el placeholder.
 * @returns {Promise<{ID_SEXO: number, SEXO_COD: string, SEXO_DESC: string, ID_ESTADO: string}[]>}
 */
const fillSexo = async ({ idSelect = "", placeholder = false, placeholderText = "Seleccione" } = {}) => {
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
            option.value = item.ID_SEXO;
            option.text = item.SEXO_DESC;
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
    const response = await fetcher('/Index.aspx/buscarSexo', { afterResOk: resOk, method: "post" });
    return Promise.resolve(response);
};
export default fillSexo;