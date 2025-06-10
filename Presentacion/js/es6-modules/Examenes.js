import fetcher from '../../js/es6-modules/Fetcher.js';
import { fillSelect } from './SelectElement.js';
const fillExamenes = async (idSelect, idPrevision = 0, placeholder = true, placeholderText = "Todos") => {
    const fillSelect = (array, id) => {
        $(`#${id}`).empty();
        placeholder && $(`#${id}`).append($("<option>", { "value": 0, "text": placeholderText }));
        array.forEach(item => $(`#${id}`)
            .append($("<option>", { value: item.ID_CODIGO_FONASA, text: item.CF_DESC })));
    };
    const resOk = res => {
        if (typeof idSelect === "object") {
            idSelect.forEach((item) => fillSelect(res, item));
        }
        else {
            fillSelect(res, idSelect);
        }
    };
    const response = await fetcher('/Reporte/Est_Result_Examen.aspx/Llenar_Ddl_Exam', { afterResOk: resOk, method: "post", body: { idPrevision } });
    return Promise.resolve(response);
};

/**
 * Busca los exámenes y llena el o los select que se le pasan.
 *
 * @async
 * @param {Object} [options] - Optional settings- si no se le pasa nada, retorna un listado con todos los doctores.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar.
 * @param {number} [options.idPrevision=0] - El id de previsión por el que se quiere filtrar.
 * @param {boolean} [options.placeholder=true] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.placeholderText="Todas"] - El texto que se quiere mostrar en el placeholder.
 * @param {number} [options.idSeccion=0] - El id de sección por el que se quiere filtrar.
 * @param {number} [options.idArea=0] - El id de área por el que se quiere filtrar.
 * @param {number} [options.idRlsLs=0] - El id de realación área-sección por el que se quiere filtrar.
 * @param {string} [options.defaultValue=-1] - El valor de default que se quiere dejar seleccionado al cargar el select.
 * 
 * @returns {Promise<{ID_CODIGO_FONASA: number, CF_DESC: string}[]>}
 */
const fillExamenesFiltro = async ({ idSelect = "", idPrevision = 0, placeholder = true, placeholderText = "Todos", idSeccion = 0, idArea = 0, idRlsLs = 0, defaultValue = -1 } = {}) => {
    const afterResOk = array => {
        fillSelect({
            array,
            idSelect,
            placeholder,
            placeholderText,
            defaultValue,
            valueProperty: "ID_CODIGO_FONASA",
            textProperty: "CF_DESC",
        });
    };
    const response = await fetcher('/Index.aspx/buscarExamenesFiltro', { afterResOk, method: "post", body: { idPrevision, idSeccion, idArea, idRlsLs } });
    return Promise.resolve(response);
};

/**
 * Busca los exámenes de la sección y llena el o los select que se le pasan.
 *
 * @async
 * @param {Object} [options] - Optional settings- si no se le pasa nada, retorna un listado con todos los exámenes en la sección.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar. Pasar array con los id de los elementos para llenar varios.
 * @param {number} [options.idSeccion=0] - La sección por la que se necesita filtrar los exámenes. Por defecto es 0.
 * @param {boolean} [options.placeholder=true] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.placeholderText="Todas"] - El texto que se quiere mostrar en el placeholder.
 * @returns {Promise<{ID_CODIGO_FONASA: number, CF_DESC: string}[]>}
 */
const fillExamenesSeccion = async ({ idSelect = "", idSeccion = 0, placeholder = true, placeholderText = "Todos" } = {}) => {
    const fillSelect = (array, id) => {
        $(`#${id}`).empty();
        placeholder && $(`#${id}`).append($("<option>", { "value": 0, "text": placeholderText }));
        array.forEach(item => $(`#${id}`)
            .append($("<option>", { value: item.ID_CODIGO_FONASA, text: item.CF_DESC })));
    };
    const resOk = res => {
        if (typeof idSelect === "object") {
            idSelect.forEach((item) => fillSelect(res, item));
        }
        else {
            fillSelect(res, idSelect);
        }
    };
    const response = await fetcher('/Index.aspx/buscarExamenesActivosPorSeccion', { afterResOk: resOk, method: "post", body: { idSeccion } });
    return Promise.resolve(response);
};
/**
 * Busca los exámenes de la sección y llena el o los select que se le pasan.
 *
 * @async
 * @param {Object} [options] - Optional settings- si no se le pasa nada, retorna un listado con todos los exámenes en la sección.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar. Pasar array con los id de los elementos para llenar varios.
 * @param {number} [options.idSeccion=0] - La sección por la que se necesita filtrar los exámenes. Por defecto es 0.
 * @param {number} [options.idArea=0] - El área por la que se necesita filtrar los exámenes. Por defecto es 0.
 * @param {number} [options.idRlsLs=0] - El id de relación entre área y sección por la que se necesita filtrar los exámenes. Por defecto es 0.
 * @param {boolean} [options.placeholder=true] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.defaultValue=-1] - El id del item que se quiere dejar seleccionado, si no existe deja el primero.
 * @param {string} [options.placeholderText="Todas"] - El texto que se quiere mostrar en el placeholder.
 * @param {string} [options.idAtencion=0] - El id de la atención de la que se quieren filtrar los resultados.
 * @param {string} [options.placeholderWhenSingle=true] - Si se quiere poner el placeholder aunque venga sólo 1 resultado.
 * @returns {Promise<{ID_CODIGO_FONASA: number, CF_DESC: string}[]>}
 */
const fillExamenesSeccionArea = async ({ idSelect = "", idSeccion = 0, idArea = 0, idRlsLs = 0, placeholder = true, defaultValue = -1, placeholderText = "Todos", idAtencion = 0, placeholderWhenSingle = true } = {}) => {
    const afterResOk = array => {
        fillSelect({
            array,
            idSelect,
            placeholder,
            placeholderText,
            defaultValue,
            valueProperty: "ID_CODIGO_FONASA",
            textProperty: "CF_DESC",
            placeholderWhenSingle,
        });
    };
    const response = await fetcher('/Index.aspx/buscarExamenesActivosPorSeccionArea', { afterResOk, method: "post", body: { idSeccion, idArea, idAtencion, idRlsLs } });
    return Promise.resolve(response);
};
/**
 * Busca los exámenes de la sección y llena el o los select que se le pasan.
 *
 * @async
 * @param {Object} [options] - Optional settings- si no se le pasa nada, retorna un listado con todos los exámenes en la sección.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar. Pasar array con los id de los elementos para llenar varios.
 * @param {number} [options.idSeccion=0] - La sección por la que se necesita filtrar los exámenes. Por defecto es 0.
 * @param {number} [options.idArea=0] - El área por la que se necesita filtrar los exámenes. Por defecto es 0.
 * @param {number} [options.idRlsLs=0] - El id de relación entre área y sección por la que se necesita filtrar los exámenes. Por defecto es 0.
 * @param {boolean} [options.placeholder=true] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.defaultValue=-1] - El id del item que se quiere dejar seleccionado, si no existe deja el primero.
 * @param {string} [options.placeholderText="Todas"] - El texto que se quiere mostrar en el placeholder.
 * @param {string} [options.idAtencion=0] - El id de la atención de la que se quieren filtrar los resultados.
 * @param {string} [options.placeholderWhenSingle=true] - Si se quiere poner el placeholder aunque venga sólo 1 resultado.
 * @returns {Promise<{ID_CODIGO_FONASA: number, CF_DESC: string}[]>}
 */
const fillExamenesSeccionArea2 = async ({ idSelect = "", idSeccion = 0, idArea = 0, placeholder = true, defaultValue = -1, placeholderText = "Todos", idAtencion = 0, placeholderWhenSingle = true } = {}) => {
    const afterResOk = array => {
        fillSelect({
            array,
            idSelect,
            placeholder,
            placeholderText,
            defaultValue,
            valueProperty: "ID_CODIGO_FONASA",
            textProperty: "CF_DESC",
            placeholderWhenSingle,
        });
    };
    const response = await fetcher('/Index.aspx/buscarExamenesActivosPorSeccionArea2', { afterResOk, method: "post", body: { idSeccion, idArea, idAtencion } });
    return Promise.resolve(response);
};



/**
 * Busca si el examen con un código existe en la lista de agregados y agrega uno o varios exámenes más
 * @param {string} codigoPrerequisite El código que si se encuentra, se agrega uno o varios exámenes automáticamente.
 * @param {string | Array.<string>} codigoAgregar Acepta un string o un array con strings representando los códigos que se quieren agregar automáticamente si se encuentra el examen que se pasa en codigoPrerequisite.
 * @param {Array.<Object>} arrayCargados El array donde se guardan los exámenes que se cargan al seleccionar previsión, en la mayoría de los módulos es Mx_Dtt_examcof pero no en todos 😥.
 * @param {Array.<Object>} arraySource El array donde se guardan los exámenes que se cargan al seleccionar previsión, en la mayoría de los módulos es Mx_Dtt_exam02 pero no en todos 😥.
 */
const buscaUnExamenAgregaOtro = (codigoPrerequisite, codigoAgregar, arrayCargados, arraySource) => {
    codigoAgregar = typeof codigoAgregar == "string" ? [codigoAgregar] : codigoAgregar;

    const existeExamenBuscado = arrayCargados.some(item => item.CF_COD == codigoPrerequisite);
    if (!existeExamenBuscado) return;
    codigoAgregar.forEach(codigo => {
        const examenAgregar = arraySource.filter(item => item.CF_COD == codigo);
        examenAgregar.forEach(exa => {
            if (!arrayCargados.some(item => item.ID_CODIGO_FONASA == exa.ID_CODIGO_FONASA)) {
                exa.CF_ESTADO_EXAMEN = "Activo";
                arrayCargados.push(exa);
            }
        })
    })
}

/**
 * Busca si el examen con un código existe en la lista de agregados y bloquea uno o varios exámenes más
 * @param {string} codigoPrerequisite El código que si se encuentra, se bloquea uno o varios exámenes automáticamente.
 * @param {string | Array.<string>} codigoBloquear Acepta un string o un array con strings representando los códigos que se quieren bloquear automáticamente si se encuentra el examen que se pasa en codigoPrerequisite.
 * @param {Array.<Object>} arrayCargados El array donde se guardan los exámenes que se cargan ir cargandolos a la atención, en la mayoría de los módulos es Mx_Dtt_examcof pero no en todos 😥.
 * @param {Array.<Object>} arraySource El array donde se guardan los exámenes que se cargan al seleccionar previsión, en la mayoría de los módulos es Mx_Dtt_exam02 pero no en todos 😥.
 * @param {Array.<Object>} exaAuto El array donde se guardan los exámenes que se cargan al seleccionar previsión, en la mayoría de los módulos es Mx_Dtt_exam02 pero no en todos 😥.
 * @param {Array.<Object>} exaAtendidos El array con los exámenes que ya tiene la atención. Este parámetro es útil en agregar o quitar examen, o en el visor de resultados donde también se puede agregar o quitar exa 😥.
 */
const buscaUnExamenBloqueaOtros = (codigoPrerequisite, codigoBloquear, arrayCargados, arraySource, exaAuto, exaAtendidos) => {
    codigoBloquear = typeof codigoBloquear == "string" ? [codigoBloquear] : codigoBloquear;
    if (codigoBloquear.length === 0) return arrayCargados;
    let arrayPrueba = arrayCargados;
    if (Array.isArray(exaAtendidos)) {
        arrayPrueba = [...arrayCargados, ...exaAtendidos];
    }
    const existeExamenBuscado = arrayPrueba.some(item => item.CF_COD == codigoPrerequisite);
    if (!existeExamenBuscado) return arrayCargados;
    let existeExamenesBloquear = arrayPrueba.some(item => codigoBloquear.includes(item.CF_COD));
    if (!existeExamenesBloquear) return arrayCargados;
    arrayCargados = arrayCargados.filter(item => !codigoBloquear.includes(item.CF_COD));
    console.log(arrayCargados);
    const { CF_DESC: nombreExamenEncontrado } = arraySource.find(item => item.CF_COD == codigoPrerequisite);
    Swal.fire({
        icon: "info",
        title: `${nombreExamenEncontrado} detectado`,
        html: `Se intentó cargar el o los siguientes exámenes: <br/><br/>
               ${codigoBloquear.map(codigo =>
            "• <b>" + (arraySource.find(item => item.CF_COD == codigo)?.CF_DESC) + "</b> <br/>").join(" ")
            } <br/>
               Las determinaciones de estos exámenes están incluidas dentro del ${nombreExamenEncontrado} y se han quitado para evitar redundancia.`
    });

    for (let prop in exaAuto) {
        const codes = exaAuto[prop];
        exaAuto[prop] = codes.filter(code => !codigoBloquear.includes(code));
    }

    return arrayCargados;
}



const examenesAutomaticos = Object.freeze({
    perBioqui: [
        //"0302047"
    ],
    hemograma: [
        //"0301086"
    ],
    perHepati: [
        //"0301059"
    ],
    hemoOcult: [
        //"0308004"
    ],
    urocultiv: [
        //"0309024"
    ],
});

const examenesBloqueados = Object.freeze({
    perBioquimic: [ // 0302075
        //"0302005",
        //"0302057",
        //"0302023",
        //"0302067",
        //"0302064",
        //"990115",
        //"0302012",
        //"990131",
        //"0302063",
        //"0302045",
        //"0302040",
        //"0302100",
        //"0302060",
        //"0302076",
        //"0302034",
    ],
    tolerGlucosa: [ // 0302048
        //"0302047",
    ],
    perHepatico: [ // 0302076
        //"0302063",
        //"0302012",
        //"990131",
        //"0302040",
        //"0302045",
    ],
    perLipidico: [
        //"0302067",
        //"0302064",
        //"0990115",
    ],
    curInsuB120: [ // 0303031
        //"0303017",
    ],
    hemograma: [ // 0301045
        //"0301036",
        //"0301038",
    ],
});

/**
 * Busca los exámenes por todos los filtros y llena el o los select que se le pasan.
 *
 * @async
 * @param {Object} [options] - Optional settings- si no se le pasa nada, retorna un listado con todos los exámenes en la sección.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar. Pasar array con los id de los elementos para llenar varios.
 * @param {(string|string[])} [options.idRlsLs=0] - El id de la relación entre area y sección para filtrar examen.
 * @param {(string|string[])} [options.idArea=0] - El id del área para filtrar examen.
 * @param {(string|string[])} [options.idSeccion=0] - El id de la sección para filtrar examen .
 * @param {(string|string[])} [options.idPreve=0] - El id de la previsión para filtrar examen.
 * @param {boolean} [options.placeholder=true] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.placeholderText="Todas"] - El texto que se quiere mostrar en el placeholder.
 * @param {string} [options.keepRlsLs=[]] - Un array con las ID_RLS_LS que se quiere mostrar, todo el resto se quita.
 * @returns {Promise<{ID_CODIGO_FONASA: number, CF_DESC: string, ID_RLS_LS: number}[]>}
 */
const fillExamenesRlsAreaSeccPrev = async ({ idSelect = "", idRlsLs = 0, idArea = 0, idSeccion = 0, idPreve = 0, placeholder = true, placeholderText = "Todos", keepRlsLs = [] } = {}) => {
    const fillSelect = (array, id) => {
        $(`#${id}`).empty();
        placeholder && $(`#${id}`).append($("<option>", { "value": 0, "text": placeholderText }));

        array = array.filter(item => keepRlsLs.length === 0 || keepRlsLs.includes(parseInt(item.ID_RLS_LS)));
        array.forEach(item => $(`#${id}`)
            .append($("<option>", { value: item.ID_CODIGO_FONASA, text: item.CF_DESC })));
    };
    const resOk = res => {
        if (typeof idSelect === "object") {
            idSelect.forEach((item) => fillSelect(res, item));
        }
        else {
            fillSelect(res, idSelect);
        }
    };
    const response = await fetcher('/Index.aspx/buscarExamenesActivosPorSeccionAreaPrev', { afterResOk: resOk, method: "post", body: { idRlsLs, idArea, idSeccion, idPreve } });
    return Promise.resolve(response);
};


/**
 * Busca los exámenes por todos los filtros y llena el o los select que se le pasan.
 *
 * @async
 * @param {Object} [options] - Optional settings- si no se le pasa nada, retorna un listado con todos los exámenes en la sección.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar. Pasar array con los id de los elementos para llenar varios.
 * @param {number} [options.idRlsLs=0] - El id de la relación entre area y sección para filtrar examen.
 * @param {number} [options.idArea=0] - El id del área para filtrar examen.
 * @param {number} [options.idSeccion=0] - El id de la sección para filtrar examen .
 * @param {number} [options.idPreve=0] - El id de la previsión para filtrar examen.
 * @param {boolean} [options.placeholder=true] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.placeholderText="Todas"] - El texto que se quiere mostrar en el placeholder.
 * @param {string} [options.keepRlsLs=[]] - Un array con las ID_RLS_LS que se quiere mostrar, todo el resto se quita.
 * @returns {Promise<{ID_CODIGO_FONASA: number, CF_DESC: string, ID_RLS_LS: number}[]>}
 */
const fillExamenesRlsAreaSeccPrevs = async ({ idSelect = "", idRlsLs = 0, idArea = 0, idSeccion = 0, idPreve = 0, placeholder = true, placeholderText = "Todos", keepRlsLs = [], idAtencion = 0 } = {}) => {
    const fillSelect = (array, id) => {
        $(`#${id}`).empty();
        placeholder && $(`#${id}`).append($("<option>", { "value": 0, "text": placeholderText }));

        array = array.filter(item => keepRlsLs.length === 0 || keepRlsLs.includes(parseInt(item.ID_RLS_LS)));
        array.forEach(item => $(`#${id}`)
            .append($("<option>", { value: item.ID_CODIGO_FONASA, text: item.CF_DESC })));
    };
    const resOk = res => {
        if (typeof idSelect === "object") {
            idSelect.forEach((item) => fillSelect(res, item));
        }
        else if (idSelect) {
            fillSelect(res, idSelect);
        }
    };
    const response = await fetcher('/Index.aspx/buscaExamenesActivosPorSeccionAreaPrev', { afterResOk: resOk, method: "post", body: { idRlsLs, idArea, idSeccion, idPreve, idAtencion } });
    return Promise.resolve(response);
};


/**
 * Busca los exámenes de la sección y llena el o los select que se le pasan.
 *
 * @async
 * @param {Object} [options] - Optional settings- si no se le pasa nada, retorna un listado con todos los exámenes en la sección.
 * @param {(string|string[])} [options.idSelect=""] - El ids de el o los select que se quieren llenar. Pasar array con los id de los elementos para llenar varios.
 * @param {boolean} [options.placeholder=true] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.placeholderText="Todas"] - El texto que se quiere mostrar en el placeholder.
 * @returns {Promise<{ID_CODIGO_FONASA: number, CF_DESC: string}[]>}
 */
const fillExamenesSinPrevision = async ({ idSelect = "", placeholder = true, placeholderText = "Todos" } = {}) => {
    const fillSelect = (array, id) => {
        $(`#${id}`).empty();
        placeholder && $(`#${id}`).append($("<option>", { "value": 0, "text": placeholderText }));
        array.forEach(item => $(`#${id}`)
            .append($("<option>", { value: item.ID_CODIGO_FONASA, text: item.CF_DESC })));
    };
    const resOk = res => {
        if (typeof idSelect === "object") {
            idSelect.forEach((item) => fillSelect(res, item));
        }
        else {
            fillSelect(res, idSelect);
        }
    };
    const response = await fetcher('/Index.aspx/buscarExamenesActivos', { afterResOk: resOk, method: "post" });
    return Promise.resolve(response);
};


export { fillExamenes, fillExamenesFiltro,fillExamenesSeccion, buscaUnExamenAgregaOtro, buscaUnExamenBloqueaOtros, fillExamenesSeccionArea, examenesAutomaticos, examenesBloqueados, fillExamenesSinPrevision, fillExamenesRlsAreaSeccPrev, fillExamenesRlsAreaSeccPrevs,fillExamenesSeccionArea2 };
export default fillExamenes;