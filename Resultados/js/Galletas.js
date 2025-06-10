var Galletas = {
    "setGalleta": function (clave, value, maxAge) {
        ///<summary>Crear una Galleta</summary>
        ///<param name="clave" type="Str">Nombre de la Clave</param>
        ///<param name="value" type="Str">Valor de la Clave</param>
        ///<param name="maxAge" type="Int">Segundos de vida de la Galleta</param>

        var path = "/";
        var xStr = "";

        var Ayyy = new Date();
        Ayyy = Ayyy.getTime();
        Ayyy = Ayyy + parseFloat(maxAge * 1000);

        Ayyy = new Date(Ayyy);
        Ayyy = Ayyy.toUTCString();

        xStr += String(clave) + "=";
        xStr += encodeURIComponent(String(value)) + "; ";
        xStr += "expires=";
        xStr += Ayyy + "; ";
        xStr += "path=" + path;




        try {
            document.cookie = xStr;


        }
        catch (error) {


        }


    },
    "getGalleta": function (clave) {
        var name = clave + "=";
        var decodedCookie = decodeURIComponent(document.cookie);
        var ca = decodedCookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') {
                c = c.substring(1);
            }
            if (c.indexOf(name) == 0) {
                if (c.substr(c.length - 1) == ' ') {
                    c = c.replace(/\s*$/, "");
                    return c.substring(name.length, c.length);
                }
                else {
                    return c.substring(name.length, c.length);
                }
               

            }
        }
        return null;
    },
    "modGalleta": function (clave, value) {
        ///<summary>Edita el valor de una Galleta</summary>
        ///<param name="clave" type="Str">Nombre de la Clave</param>
        ///<param name="value" type="Str">Valor de la Clave</param>

        var xGalletas = document.cookie;
        var path = "/";
        var xStr = "";




        try {
            if (xGalletas.includes(clave) == true) {
                xStr += clave + "=" + encodeURIComponent(String(value)) + "; ";
                xStr += "path=" + path;

                document.cookie = xStr;

            } else {

            }
        }
        catch (err) {

        }
    },
    "modTime": function (clave, maxAge) {
        ///<summary>Asesinar una Galleta</summary>
        ///<param name="clave" type="Str">Nombre de la Clave</param>
        ///<param name="maxAge" type="Str">Segundos a Expirar</param>

        var arrCookie = String(document.cookie).split(";");
        var path = "/";

        var Ayyy = new Date();
        Ayyy = Ayyy.getTime();
        Ayyy = Ayyy + parseFloat(maxAge * 1000);

        Ayyy = new Date(Ayyy);
        Ayyy = Ayyy.toUTCString();

        var val = this.getGalleta(clave);




        document.cookie = String(clave) + "=" + encodeURIComponent(String(val)) + "; expires=" + Ayyy + "; path=" + path;



    },
    "killGalleta": function (clave) {
        ///<summary>Asesinar una Galleta</summary>
        ///<param name="clave" type="Str">Nombre de la Clave</param>

        var arrCookie = String(document.cookie).split(";");
        var path = "/";
        var ci = new Date(0);
        ci = ci.toUTCString();




        document.cookie = String(clave) + "=; expires=" + ci + "; path=" + path;



    }
}

