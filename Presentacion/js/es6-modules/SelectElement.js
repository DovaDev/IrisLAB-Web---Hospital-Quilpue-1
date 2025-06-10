/**
 * llena el select.
 *
 * @async
 * @param {Object} [options] - Optional settings.
 * @param {(string)} [options.idSelect=""] - El id de el select que se quiere llenar.
 * @param {boolean} [options.placeholder=true] - Si se quiere incluir un placeholder o no (Todas, Seleccione, etc.).
 * @param {string} [options.placeholderText="Todo"] - El placeholder que se muestra como priemra opcion con value 0.
 * @param {string} [options.valueProperty=""] - El nombre de la propiedad que se usa en el valor de cada opción.
 * @param {string|string[]} [options.textProperty=""] - El nombre de la propiedad que se usa en el texto de cada opción 
 * acepta un string o string[] de propiedades y las concatena con un espacio.
 * @param {string} [options.textoConcatenador=" "] - El texto que se quiere usar para separar la concatenación en caso de necesitar algo diferente al default " " (un espacio).
 * @param {string} [options.defaultValue=-1] - El valor de default que se quiere dejar seleccionado al cargar el select.
 * @param {string} [options.idRestriccion=0] - Por si se quiere mostrar solo 1 de los valores que tiene el select, generalmente usado para restringir previsiones o procedencias en usuarios.
 */
const fillSelect = ({ array = [], idSelect = "", valueProperty = "", textProperty = "", defaultValue = -1, placeholder = false, placeholderText = "Todo", idRestriccion = 0, textoConcatenador = " ", placeholderWhenSingle = true }) => {
    if (idSelect === "" || !idSelect) return
    idRestriccion = parseInt(idRestriccion) || 0;
    array = array.filter(item => item[valueProperty] == idRestriccion || idRestriccion == 0);
    let selectElements = Array.isArray(idSelect)
        ? idSelect.map(item => document.getElementById(item))
        : [document.getElementById(idSelect)];
    selectElements.forEach(select => {
        select.innerHTML = '';
        if (placeholder && placeholderText && idRestriccion === 0 && (placeholderWhenSingle || array.length > 1)) {
            const placeholderOption = document.createElement('option');
            placeholderOption.value = 0;
            placeholderOption.text = placeholderText;
            select.appendChild(placeholderOption);
        }
        array.forEach(item => {
            const option = document.createElement('option');
            option.value = item[valueProperty];
            if (typeof textProperty === "object") {
                option.text = textProperty.map(prop => item[prop]).join(textoConcatenador);
            } else {
                option.text = item[textProperty];
            }
            select.appendChild(option);
        });
        const existeDefaultProperty = array.some(item => item[valueProperty] == defaultValue);
        if (defaultValue > -1 && existeDefaultProperty) {
            select.value = defaultValue
        }
    })
};

export { fillSelect };