var $re = {
    "getQueryVal": function (Input) {
        ///<summary>Conseguir valor de una QueryString</summary>
        ///<param name="Input" type="Str">Variable a obtener</param>
        var query = window.location.search.substring(1);
        var vars = query.split("&");
        for (var i = 0; i < vars.length; i++) {
            var pair = vars[i].split("=");
            if (pair[0] == Input) {
                return pair[1];
            }
        }
        return false;
    },
    "isNumeric": function (Value) {
        ///<summary>Devuelve un booleano indicando si es booleano o no.</summary>
        ///<param name="Input" type="Str">Variable a obtener</param>
        if (isNaN(Value) == true) {
            return false;
        } else if (Value == null) {
            return false;
        } else if (Value === "") {
            return false;
        } else {
            var numX = parseFloat(Value);
            if (((numX * 8) / numX) == 8) {
                return true;
            } else if (numX == 0) {
                return true;
            } else {
                return false;
            }
        }
    },
    "cutDecimals": function (num, dec) {
        var arrNum = String(num).split(".");
        //Comprobar si es formateable
        if (this.isNumeric(num) == false) {
            return num;
        } else if (this.isNumeric(dec) == false) {
            return num;
        } else if (dec == 0) {
            return arrNum[0];
        }
        var xFloat = [];
        if (arrNum.length > 1) {
            xFloat = arrNum[1].split("");
        }
        var strOut = arrNum[0] + ".";
        for (ayy = 0; ayy < dec; ++ayy) {
            if (ayy < xFloat.length) {
                strOut += xFloat[ayy];
            } else {
                strOut += "0";
            }
        }
        
        return strOut;
    }
};

