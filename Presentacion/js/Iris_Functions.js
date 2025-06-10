//**************************************************************************
//************************* IMPRIMIR DOCUMENTOS ****************************
//**************************************************************************

//Declaración de Prototipo
function Iris_Print(data, success, error) {
    //Modo Estricto
    "use strict";
    //Ajax
    this.AJAX = {
        "type": "POST",
        "contentType": "text/plain;  charset=utf-8",
        "dataType": "json"
    };
    //Declarar Variables Opcionales
    this.AJAX.data = JSON.stringify(data) || "";
    this.AJAX.success = success || "";
    this.AJAX.error = error || "";

}

//Metodos del Prototipo
Iris_Print.prototype = {
    //Imprimir Etiquetas
    "Imp_Etiquetas": function () {
        this.AJAX.url = "http://localhost:9990/Printer/Imp_Etiquetas";

        return $.ajax(this.AJAX);
    },
    //Imprimir Voucher de Agenda Meédica
    "Imp_Voucher_Agendam": function () {
        this.AJAX.url = "http://localhost:9990/Printer/Imp_Voucher_Agendam";

        return $.ajax(this.AJAX);
    },
    //Imprimir Voucher de Procedencia
    "Imp_Voucher_Lugar_TM": function () {
        this.AJAX.url = "http://localhost:9990/Printer/Imp_Voucher_Lugar_TM";

        return $.ajax(this.AJAX);
    },
    //Imprimir Voucher de Comprobante Atencion
    "Imp_Voucher_Compr_Ate": function () {
        this.AJAX.url = "http://localhost:9990/Printer/Imp_Voucher_Compr_Ate";

        return $.ajax(this.AJAX);
    },
};


//**************************************************************************
//******************** EJECUTAR METODO DE PROTOTIPO ************************
//**************************************************************************


////**Definir Data para el AJAX
//var Ajax_Data = [15356];

////**Definir funcion para success
//function fn_Success() {
//    //**Escribir Codigo aqui
//    alert("Si");
//}
////**Definir funcion para error
//function fn_Error() {
//    //**Escribir Codigo aqui
//    alert("No");
//}
////**Crear Instancia de un nuevo Prototipo
//var Imp_Eti = new Iris_Print(Ajax_Data, fn_Success);
////**Ejecutar el Método de Imprimir Etiquetas
//Imp_Eti.imp_Etiquetas();

//Imp_Vou = new Iris_Print(Ajax_Data, fn_Success, fn_Error);
//Imp_Vou.Imp_Voucher_Agendam();


//**************************************************************************
//************************** QUERY SELECT UPDATE ***************************
//**************************************************************************


//Declaracion de Prototipo
function Iris_Query(url, data, success, error) {
    data = data || "";
    //Modo Estricto
    "use strict";
    //Ajax
    this.AJAX = {
        "type": "POST",
        "url": url,
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json"
    };
    //Declarar Variables Opcionales
    if (data != "") {
        this.AJAX.data = JSON.stringify(data);
    }
    this.AJAX.success = success || "";
    this.AJAX.error = error || "";

}
//Metodos del Prototipo
Iris_Query.prototype = {
    //Just RUN !
    "Run": function () {

        $.ajax(this.AJAX);
    }
};
