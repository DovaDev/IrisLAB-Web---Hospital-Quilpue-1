$(document).ready(function () {
    //Crear Modal Genérico
    $("body").append(
        $("<div>", {
            "id": "cModal",
            "class": "custom_modal"
        }).append(
            $("<div>").append(
                $("<div>", { "class": "cModal_Text" }).append(
                    $("<h1>"),
                    $("<br />"),
                    $("<p>")
                ),
                $("<div>", { "class": "cModal_Btn" }).append(
                )
            )
        )
    );
    $("#cModal").hide();
});
//Modal de Error
function cModal_Error(title, content) {
    //Cambiar Texto
    $("#cModal").attr("class", "custom_modal m_error");
    $("#cModal .cModal_Text h1").text(title);
    $("#cModal .cModal_Text p").html(content);
    //Agregar el botón Aceptar dentro del Modal
    $("#cModal .cModal_Btn").append(
        $("<span>", {
            "id": "cModal_Btn_Aceptar",
            "class": "cBtn cAceptar"
        }).text("Aceptar")
    );
    //Mostrar Modal
    $("#cModal").fadeIn(500);
    //Registrar Eventos
    $("#cModal_Btn_Aceptar").click(function () {
        $("#cModal").fadeOut(500, function () {
            $("#cModal .cModal_Text h1").empty();
            $("#cModal .cModal_Text p").empty();
            $("#cModal .cModal_Btn").empty();
        });
    });
}
//Modal de notificación
function cModal_Notif(title, content) {
    //Cambiar Texto
    $("#cModal").attr("class", "custom_modal m_ok");
    $("#cModal .cModal_Text h1").text(title);
    $("#cModal .cModal_Text p").html(content);
    //Agregar el botón Aceptar dentro del Modal
    $("#cModal .cModal_Btn").append(
        $("<span>", {
            "id": "cModal_Btn_Aceptar",
            "class": "cBtn cAceptar"
        }).text("Aceptar")
    );
    //Mostrar Modal
    $("#cModal").fadeIn(500);
    //Registrar Eventos
    $("#cModal_Btn_Aceptar").click(function () {
        $("#cModal").fadeOut(500, function () {
            $("#cModal .cModal_Text h1").empty();
            $("#cModal .cModal_Text p").empty();
            $("#cModal .cModal_Btn").empty();
        });
    });
}
//Modal de Notificación con Botón personalizado
function cModal_Notif_Custom(title, content, button_text, button_funct) {
    //Cambiar Texto
    $("#cModal").attr("class", "custom_modal m_ok");
    $("#cModal .cModal_Text h1").text(title);
    $("#cModal .cModal_Text p").html(content);
    //Agregar el botón Aceptar dentro del Modal
    $("#cModal .cModal_Btn").append(
        $("<span>", {
            "id": "cModal_Btn_Aceptar",
            "class": "cBtn cAceptar"
        }).text(button_text)
    );
    //Mostrar Modal
    $("#cModal").fadeIn(500);
}