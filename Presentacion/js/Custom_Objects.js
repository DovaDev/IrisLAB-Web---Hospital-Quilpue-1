var cFormat = {
    //Formatear un Número a Cadena
    "numToString": function (number, c_dec, s_int, s_dec) {
        var arr_int = (String(number).split("."))[0];
        var arr_dec = (String(number).split("."))[1];
        var str_int = "";
        var str_dec = "";
        //Retornar "NaN" si el valor no es un número
        if (isNaN(number) == true) {
            return "NaN";
        }
        //Concatenar "arr_int"
        var pos_int = 0;
        for (yi = (arr_int.length - 1) ; yi >= 0; --yi) {
            if (pos_int % 3 == 0) {
                if ((pos_int > 0) && (pos_int < (arr_int.length))) {
                    str_int = s_int + str_int;
                }
            }
            str_int = arr_int[yi] + str_int;
            pos_int += 1;
        }
        //Devolver resultados si no hay decimales
        if ((arr_dec == undefined) && (c_dec == 0)) {
            return str_int;
        }
        //Concatenar "arr_dec"
        if (arr_dec.length < c_dec) {
            str_dec = (String(number).split("."))[1];
            while (str_dec.length < c_dec) {
                str_dec += "0";
            }
        } else {
            for (yi = 0; yi < c_dec; ++yi) {
                str_dec += arr_dec[yi];
            }
        }
        return str_int + s_dec + str_dec;
    }
};