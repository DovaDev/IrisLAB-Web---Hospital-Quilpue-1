import fetcher from '../../js/es6-modules/Fetcher.js';
/**
 * Busca los doctores y llena el o los select que se le pasan.
 *
 * @async
 * @param {Object} [options] - Optional settings- si no se le pasa nada, retorna un listado con todos los doctores.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar.
 * @param {boolean} [options.placeholder=true] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.placeholderText="Todas"] - El texto que se quiere mostrar en el placeholder.
 * @param {number} [options.defecto=0] - El valor (ID_DOCTOR) con el que debe quedar seleccionado.
 * @param {Function} [options.callback=()=>{}] - Esta función se ejecuta después de que se llenan los select.
 * @returns {Promise<{ID_DOCTOR: number, DOC_NOMBRE: string, DOC_APELLIDO: string, ID_ESTADO: number, ESP_DESC: string, DOC_FONO1: string, DOC_MOVIL1: string}[]>}
 */
const fillDoctor = async ({ idSelect = "", placeholder = false, placeholderText = "Seleccione", defecto = 0, callback = () => { } } = {}) => {
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
            option.value = item.ID_DOCTOR;
            option.text = item.DOC_NOMBRE + " " + item.DOC_APELLIDO;
            select.appendChild(option);
        });
        if (placeholder || defecto) {
            select.value = defecto;
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
            callback();
        }
            
    };
    const response = await fetcher('/Index.aspx/buscarDoctores', { afterResOk: resOk, method: "post" });
    return Promise.resolve(response);
};
export default fillDoctor;