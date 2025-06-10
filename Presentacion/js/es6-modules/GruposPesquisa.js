import fetcher from '../../js/es6-modules/FetcherV1.js';
/**
 * Busca los grupos de pesquisa y llena el o los select que se le pasan.
 *
 * @async
 * @param {Object} [options] - Optional settings- si no se le pasa nada, retorna un listado con todas los grupos de pesquisa.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar. Pasar array con los id de los elementos para llenar varios.
 * @param {boolean} [options.placeholder=true] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.placeholderText="Todas"] - El texto que se quiere mostrar en el placeholder (Opcional default "<Sin Selección>").
 * @param {number} [options.idTipoPesquisa=0] - Filtra el tipo de pesquisa 1 para VIH y 2 para RPR/Chagas (Opcional default 0).
 * @param {string} [options.mostrarCodigo=true] - Mostrar el codigo del grupo de pesquisa (Opcional default true).
 * @param {string} [options.mostrarDesc=false] - Mostrar la descripción del grupo de pesquisa (Opcional default false).
 * @param {number} [options.defaultValue=-1] - El valor que se quiere dejar seleccionado al cargar el select.
 * @returns {Promise<{ID_GRUPO_PESQUISA: number, GRUPO_PESQUISA_COD: string, GRUPO_PESQUISA_DESC: string, ID_TIPO_PESQUISA: number, ID_ESTADO: number}[]>}
 */
const fillGrupoPesquisa = async ({ idSelect = "", placeholder = true, placeholderText = "Seleccione", idTipoPesquisa = 0, mostrarCodigo = false, mostrarDesc = true, defaultValue = -1 } = {}) => {

    const fillSelect = (array, id) => {
        const select = document.getElementById(id);
        select.innerHTML = '';
        if (placeholder && placeholderText) {
            const placeholderOption = document.createElement('option');
            placeholderOption.value = 0;
            placeholderOption.text = placeholderText;
            select.appendChild(placeholderOption);
        }
        array = array.filter(item => item.ID_TIPO_PESQUISA == idTipoPesquisa);
        array.forEach(item => {
            const option = document.createElement('option');
            option.value = item.ID_GRUPO_PESQUISA;
            option.text = `${(mostrarCodigo ? item.GRUPO_PESQUISA_COD + " " : "")}${(mostrarDesc ? item.GRUPO_PESQUISA_DESC : "")}`;
            select.appendChild(option);
        });
        if (defaultValue > -1) {
            select.value = defaultValue;
        }
    };
    const resOk = res => {
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
    const response = await fetcher('/Index.aspx/buscarGrupoPesquisa', { afterResOk: resOk, method: "post" });
    return Promise.resolve(response);
};
export default fillGrupoPesquisa;