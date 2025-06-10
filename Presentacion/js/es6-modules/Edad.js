/**
 * Calcula los años, meses y días. 
 *
 * @param {!string} [birthday] - La fecha de nacimiento en formato YYYY-MM-DD (obligatorio)
 * @returns {{ years: number, meses: number, dias: number, formatoYMD: string }} Devuelve formatoYDM ejemplo: 10 Años 5 Meses 29 Días
 */
const calcularEdadExact = birthday => {
    const birthdate = new Date(birthday);
    const now = new Date();
    const diff = now.getTime() - birthdate.getTime();
    const diffYears = diff / (1000 * 60 * 60 * 24 * 365.25);
    const years = Math.floor(diffYears);
    const diffMonths = (diffYears - years) * 12;
    const months = Math.floor(diffMonths);
    const days = Math.floor((diffMonths - months) * (365.25 / 12));
    const formatoYMD = `${years} Años ${months} Meses ${days} Días`;
    return { years, meses: months, dias: days, formatoYMD };
}
/**
 * Enum para representar los posibles formatos de fecha.
 */
const DateFormat = Object.freeze({
    YYYY_MM_DD: 'yyyy-mm-dd',
    DD_MM_YYYY: 'dd-mm-yyyy'
});
/**
 * Formatea los JSON date a string. 
 * "/Date(1678128501927)/" estas horripilancias
 *
 * @param {string} jsonDate - La fecha de que se quiere formatear (obligatorio)
 * @param {Object} [options] - Opciones para el formato de fecha (opcional).
 * @param {string} [options.dateFormat=DateFormat.DD_MM_YYYY] - El formato de fecha a utilizar (opcional, por defecto es 'dd-mm-yyyy'). 
 * Se puede importar el enum DateFormat de este mismo módulo para ver los formatos disponibles
 * @param {boolean} [options.includeTime=false] - Indica si se debe incluir la hora en la salida formateada (opcional, por defecto es 'false').
 * @param {boolean} [options.includeDate=true] - Indica si se debe incluir la fecha en la salida formateada (opcional, por defecto es 'true').
 * @returns {string} La fecha formateada como string con formato por defecto dd-mm-yyyy.
 */
const formatJSONDate = (jsonDate, { dateFormat = DateFormat.DD_MM_YYYY, includeTime = false, includeDate = true } = {}) => {
    if (jsonDate === "") return;
    const date = new Date(parseInt(jsonDate.substr(6)));
    if (date.getFullYear() < 1910) {
        return "";
    }
    let options = includeDate ? { year: 'numeric', month: '2-digit', day: '2-digit' } : {};
    if (dateFormat === DateFormat.YYYY_MM_DD) {
        return date.toISOString().slice(0, 10);
    }
    if (includeTime) {
        options = { ...options, hour: 'numeric', minute: 'numeric', second: 'numeric' };
    }
    const formatter = new Intl.DateTimeFormat('es-CL', options);
    const formattedDate = formatter.format(date);
    return formattedDate;
};

export { calcularEdadExact, formatJSONDate, DateFormat }