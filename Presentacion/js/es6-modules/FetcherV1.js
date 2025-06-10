/**
 *  Sirve para cualquier tipo de fetch con post o get para no tener que escribir todo el relleno de try catch ni if res.ok.
 *  Se le pueden pasar funciones opcionales para ejecutar después de res.ok === true, después de catch o después de res.ok === false.
 *  @param {string} endpoint - Ruta del endpoint en el controller (ej. /Producto/Crear).
 *  @param {Object} [options] - Optional settings.
 *  @param {string} [options.method="POST"] - GET o POST en string.
 *  @param {Function} [options.afterResOk={}] - Función que se ejecuta si la respuesta del fetch tiene ok: true, ¡IMPORTANTE! recibe res.json como argumento
 *  @param {string|Object.<string, *>} [options.body={}] - Objeto con pares de llave y valor que representan los argumentos que pide el endpoint del controller.
 *  Se puede pasar habiendo sido stringificado con JSON.stringify o como objeto.
 *  @param {Function} [options.afterResNotOk={}] - Función que se ejecuta si la respuesta del fetch tiene ok = false (error de fetch)
 *  @param {Function} [options.afterCatch={}] - Función que se ejecuta si la hay algun error en el código
 *  @returns {Promise<Object>} Promesa con la respuesta del servidor parseada a json.
 */
const fetcher = async (endpoint, { afterResOk = () => { }, body = {}, afterResNotOk = () => { }, afterCatch = () => { }, method = 'POST' } = {}) => {
    body = typeof body === "object" ? JSON.stringify(body) : body;
    const fetchParams = {
        method: method,
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: body
    };
    try {
        let res;
        if (method.toUpperCase() === 'GET') {
            res = await fetch(endpoint);
        } else if (method.toUpperCase() === 'POST') {
            res = await fetch(endpoint, fetchParams);
        }
        if (res.ok) {
            let resJSON = await res.json();
            const valorDevuelto = resJSON?.d !== undefined ? resJSON.d : resJSON;
            await afterResOk(valorDevuelto);
            return Promise.resolve(valorDevuelto);
        } else {
            afterResNotOk(res);
            return Promise.resolve(res);
        }
    } catch (error) {
        console.error(error);
        afterCatch(error);
        return Promise.resolve();
    }
}
export default fetcher;