function Valid_RUT(str_In) {

    //Funciones
    function Cleaner(aaa) {
        //Declaraciones

        var arr_In = aaa.split(""); //console.log('[OK] - Array de entrada Creado: [' + arr_In + '];');
        var arr_Out = []; //console.log('[OK] - Array de Salida Creado: [' + arr_Out + '];');
        var str_Out = ""; //console.log('[OK] - String de Salida Creado: "' + str_Out + '";');

        //Pasar al 2do array solo valores numéricos

        for (i = 0; i < arr_In.length; ++i) {
            var aaa = arr_In[i];

            if (isNaN(aaa) == false) {


                arr_Out.push(aaa);
            } else if (aaa.toUpperCase() == "K") {
                arr_Out.push(aaa.toUpperCase());
            } else {

            }
        };

        //Escribir en una cadena el contenido del nuevo array
        for (i = 0; i < arr_Out.length; ++i) {
            str_Out += "" + arr_Out[i];
        }

        return str_Out;
    }
    function Formatt(bbb) {
        var arr_01 = bbb.split("");
        var arr_02 = [];
        var str_aaa = "";   //cadena de salida

        //Ordenar cifras en el orden inverso
        for (i = arr_01.length - 1; i >= 0; --i) {
            arr_02.push(arr_01[i]);
        }

        //Agregar símbolos
        for (i = 0; i < arr_02.length; ++i) {
            switch (i) {
                case 0:
                    str_aaa = "-" + arr_02[i];
                    break;
                case 4:
                case 7:
                case 10:
                case 13:
                    str_aaa = arr_02[i] + "." + str_aaa;
                    break;
                default:
                    str_aaa = arr_02[i] + str_aaa;
                    break;
            }
        }

        return str_aaa;
    }

    //Declaraciones internas
    var Clean_Out = "" + Cleaner(str_In.replace(/\s/g, ""));

    //Comprobar si el RUT ya limpiado contiene caracteres
    if ((Clean_Out == "") || (Clean_Out == null)) {
        return {
            "Clean": Clean_Out,
            "Valid": false
        };
    }

    //dividir el RUT
    var RUT_Number = Clean_Out.slice(0, (Clean_Out.length - 1));
    var RUT_N_VERF = Clean_Out.slice(-1);


    //Comprobar que la 1ra parte sea numérica
    if (isNaN(RUT_Number) == true) {
        return {
            "Clean": Clean_Out,
            "Valid": false,
            "Format": Clean_Out
        };
    }

    //Multiplicar los dígitos por el contador
    var Count = 2;
    var Total = 0;
    RUT_Number = RUT_Number.split("");
    for (y = (RUT_Number.length - 1); y >= 0; --y) {
        Total += RUT_Number[y] * Count;


        if (Count >= 7) { Count = 2; } else { Count += 1; }
    }

    //Calcular Dígito Verificador
    Total = Total % 11;
    Total = 11 - Total;


    //Alterar Cifra Verificadora
    switch (RUT_N_VERF) {
        case "0":
            RUT_N_VERF = 11;
            break;
        case "K":
            RUT_N_VERF = 10;
            break;
    }

    //Comprobar Validez
    if (Total == RUT_N_VERF) {
        return {
            "Clean": Clean_Out,
            "Valid": true,
            "Format": Formatt(Clean_Out)
        };
    } else {
        return {
            "Clean": Clean_Out,
            "Valid": false,
            "Format": Clean_Out
        };
    }
}
