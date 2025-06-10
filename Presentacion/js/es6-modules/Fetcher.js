const optionsDefault = {
    afterResOk: () => { },
    body: '',
    afterResNotOk: () => { },
    afterCatch: () => { },
    method: 'POST'
}
/**
 *  Sirve para cualquier tipo de fetch con post o get para no tener que escribir todo el relleno de try catch ni if res.ok.
 *  Se le pueden pasar funciones opcionales para ejecutar después de res.ok === true, después de catch o después de res.ok === false.
 *  @param {string} method - GET o POST en string.
 *  @param {string} endpoint - Ruta del endpoint en el controller (ej. /Producto/Crear).
 *  @param {Function} afterResOk - Función que se ejecuta si la respuesta del fetch tiene ok: true, ¡IMPORTANTE! recibe res.json como argumento
 *  @param {object} body - Objeto con pares de llave y valor que representan los argumentos que pide el endpoint del controller, se puede pasar habiendo sido stringificado con JSON.stringify o no.
 *  @param {Function} afterResNotOk - Función que se ejecuta si la respuesta del fetch tiene ok = false (error de fetch)
 *  @param {Function} afterCatch - Función que se ejecuta si la hay algun error en el código
 *  @returns {Promise} Promesa con la respuesta del servidor parseada a json.
 */
const fetcher = async (endpoint, options = optionsDefault) => {
    options = { ...optionsDefault, ...options };
    options.body = typeof options.body === "object" ? JSON.stringify(options.body) : options.body;
    const fetchParams = {
        method: options.method,
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: options.body
    };
    try {
        let res;
        if (options.method.toUpperCase() === 'GET') {
            res = await fetch(endpoint);
        } else if (options.method.toUpperCase() === 'POST') {
            res = await fetch(endpoint, fetchParams);
        }
        if (res.ok) {
            let resJSON = await res.json();
            options.afterResOk(resJSON.d);
            return Promise.resolve(resJSON.d);
        } else {
            options.afterResNotOk();
            return Promise.resolve(res);
        }
    } catch (error) {
        console.error(error);
        options.afterCatch();
        return Promise.resolve();
    }
}
const fetcherOld = 1;
export { fetcherOld };
export default fetcher;