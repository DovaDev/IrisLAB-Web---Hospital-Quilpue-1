import fetcher from '../../js/es6-modules/Fetcher.js';
/**
 * Busca las ciudades y llena el o los select que se le pasan.
 *
 * @async
 * @param {Object} [options] - Optional settings- si no se le pasa nada, retorna un listado con todas las ciudades.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar.
 * @param {boolean} [options.placeholder=true] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.placeholderText="Todas"] - El texto que se quiere mostrar en el placeholder.
 * @param {number} [options.idCiudad=0] - Si se necesita restringir por usuario la ciudad que puede seleccionar, se le pasa el id que se guarda en los datos del usuario.
 * @returns {Promise<{ID_CIUDAD: string, CIU_COD: string, CIU_DESC: string, ID_ESTADO: string}[]>}
 */
const fillCiudades = async ({ idSelect = "", placeholder = false, placeholderText = "Todas", idCiudad = 0 } = {}) => {
    idCiudad = parseInt(idCiudad) || 0;
    const fillSelect = (array, id) => {
        const select = document.getElementById(id);
        select.innerHTML = '';
        if (placeholder && placeholderText && idCiudad === 0) {
            const placeholderOption = document.createElement('option');
            placeholderOption.value = 0;
            placeholderOption.text = placeholderText;
            select.appendChild(placeholderOption);
        }
        array.forEach(item => {
            const option = document.createElement('option');
            option.value = item.ID_CIUDAD;
            option.text = item.CIU_DESC;
            select.appendChild(option);
        });
    };
    const resOk = res => {
        res = res.filter(item => item.ID_CIUDAD == idCiudad || idCiudad === 0);
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
    const response = await fetcher('/Index.aspx/Buscar_Ciudades', { afterResOk: resOk, method: "post" });
    return Promise.resolve(response);
};
export default fillCiudades;