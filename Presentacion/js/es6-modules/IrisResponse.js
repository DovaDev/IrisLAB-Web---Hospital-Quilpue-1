/**
 * Representa el estándar de respuesta en IrisLab...
 * @class
 */
class IrisResponse {
    /**
     * Creates an instance of IrisResponse.
     * @param {Object} [options] - obj config.
     * @param {boolean} [options.success] - Indicates the success status of the request.
     * @param {string} [options.message] - Additional information or error messages.
     * @param {any} [options.data] - The payload or response data.
     * @param {number} [options.code] - html response code of the request.
     */
    constructor({ success, message, data, code } = {}) {
        this.success = success;
        this.message = message;
        this.data = data;
        this.code = code;
    }
}
export default IrisResponse