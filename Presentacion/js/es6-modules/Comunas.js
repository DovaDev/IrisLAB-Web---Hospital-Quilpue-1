import fetcher from '../../js/es6-modules/Fetcher.js';
/**
 * Busca las comunas y llena el o los select que se le pasan.
 *
 * @async
 * @param {number} idCiudad - Obligatorio, se debe mandar el id de la ciudad donde se quieren buscar comunas.
 * @param {Object} [options] - Optional settings- si no se le pasa nada, retorna un listado con todas las comunas de la ciudad.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar.
 * @param {boolean} [options.placeholder=true] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.placeholderText="Todas"] - El texto que se quiere mostrar en el placeholder.
 * @param {number} [options.idComuna=0] - Si se necesita restringir por usuario la comuna que puede seleccionar, se le pasa el id que se guarda en los datos del usuario.
 * @returns {Promise<{ID_COMUNA: number, COM_DESC: string, ID_ESTADO: number, ID_CIUDAD: number, ID_REL_CIU_COM: number}[]>}
 */

const fillComunas = async (idCiudad, { idSelect = "", placeholder = false, placeholderText = "Todas", idComuna = 0 } = {}) => {
    idComuna = parseInt(idComuna) || 0;
    const fillSelect = (array, id) => {
        const select = document.getElementById(id);
        select.innerHTML = '';
        if (placeholder && placeholderText && idComuna === 0) {
            const placeholderOption = document.createElement('option');
            placeholderOption.value = 0;
            placeholderOption.text = placeholderText;
            select.appendChild(placeholderOption);
        }
        array.forEach(item => {
            const option = document.createElement('option');
            option.value = item.ID_REL_CIU_COM;
            option.text = item.COM_DESC;
            select.appendChild(option);
        });
    };
    const resOk = res => {
        res = res.filter(item => item.ID_COMUNA == idComuna || idComuna === 0);
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
    const response = await fetcher('/Index.aspx/Buscar_Comunas', { afterResOk: resOk, method: "post", body: { idCiudad } });
    return Promise.resolve(response);
};
export default fillComunas;