import fetcher from '../../js/es6-modules/Fetcher.js';
const fillDeterminaciones = async (idSelect, idCodigoFonasa = 0, placeholder = true, placeholderText = "Todas") => {
    if (idCodigoFonasa == 0) {
        if (typeof idSelect === "object") {
            idSelect.forEach((item) => $(`#${item}`).empty().append($("<option>", { "value": 0, "text": "Seleccione Examen" })));
        }
        else {
            $(`#${idSelect}`).empty().append().append($("<option>", { "value": 0, "text": "Seleccione Examen" }));
        }
        return;
    }
    const fillSelect = (array, id) => {
        $(`#${id}`).empty();
        placeholder && $(`#${id}`).append($("<option>", { "value": 0, "text": placeholderText }));
        array.forEach(item => $(`#${id}`)
            .append($("<option>", { value: item.ID_PRUEBA, text: item.PRU_DESC })));
    };
    const resOk = res => {
        if (typeof idSelect === "object") {
            idSelect.forEach((item) => fillSelect(res, item));
        }
        else {
            fillSelect(res, idSelect);
        }
    };
    const response = await fetcher('/Reporte/Est_Result_Examen.aspx/Llenar_Ddl_Det', { afterResOk: resOk, method: "post", body: { idCodigoFonasa } });
    return Promise.resolve(response);
};
export default fillDeterminaciones;