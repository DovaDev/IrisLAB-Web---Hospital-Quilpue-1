/// <reference path="C:\Users\None\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Holanda\Presentacion\vendor/jquery/jquery.js" />
/// <reference path="C:\Users\None\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Holanda\Presentacion\vendor/popper/popper.js" />
/// <reference path="C:\Users\None\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Holanda\Presentacion\vendor/bootstrap/js/bootstrap.js" />
/// <reference path="C:\Users\None\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Holanda\Presentacion\js/moment.js" />
/// <reference path="C:\Users\None\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Holanda\Presentacion\js/datepicker/js/bootstrap-datepicker.js" />
/// <reference path="C:\Users\None\Documents\Source\Repos\IrisLab Web\IrisLAB Web - Holanda\Presentacion\js/RUT.js" />

//Datepicker
$(document).ready(() => {
    $(`#Txt_Date`).css({ cursor: `pointer` });
    $(`#Txt_Date`).val(moment().format(`DD/MM/YYYY`));
    $(`#Txt_Date`).parent().datepicker({
        format: "dd/mm/yyyy",
        language: "es"
    });

    $(`#Txt_RUT`).focus();
});

//Eventos
$(document).ready(() => {
    $(`#Txt_RUT`).keyup((Me) => {
        let xValue = $(Me.currentTarget).val();
        let xValAlt = "";
        let xOut = "";

        xValue = xValue.replace(/(\.|-)/gi, "");
        if (xValue.match(/^[0-9]*(k?)$/gi) == null) {
            $(Me.currentTarget).val("");
            $(`#errRUT_1`).fadeIn(250);
            return;
        } else if (xValue.length > 9) {
            $(Me.currentTarget).val("");
            $(`#errRUT_1`).fadeIn(250);
            return;
        }

        //$(`#errRUT_1`).fadeOut(250);
        $(`#errRUT_2`).fadeOut(250);
        for (var i = xValue.length - 1; i >= 0; i--) {
            xValAlt = `${xValAlt}${xValue[i]}`
        }

        xValAlt = xValAlt.split("");
        for (i = 0; i < xValAlt.length; i++) {
            xOut = `${xValAlt[i]}${xOut}`;

            if (i == 0) {
                xOut = `-${xOut}`;
            } else if (i == 3) {
                xOut = `.${xOut}`;
            } else if (i == 6) {
                xOut = `.${xOut}`;
            }
        }

        $(Me.currentTarget).val(xOut);
    });

    $(`#Txt_RUT`).focusout((Me) => {
        let xValue = $(Me.currentTarget).val();
        let objValid = Valid_RUT(xValue);

        if ((objValid.Clean == true) || (xValue == "")) {
            $(`#errRUT_1`).fadeOut(250, () => {
                $(`#errRUT_2`).fadeIn(250);
            });
            
            return;
        }
        if (objValid.Valid == false) {
            $(Me.currentTarget).val("");
            $(`#errRUT_1`).fadeIn(250);
        } else {
            $(`#errRUT_1`).fadeOut(250);
        }
    });

    $(`#Txt_AteNum`).keyup((Me) => {
        let xValue = $(Me.currentTarget).val();

        xValue = xValue.replace(/[0-9]/gi, "");
        if (xValue.length > 0) {
            $(Me.currentTarget).val("");
        }

        $(`#errFolio`).fadeOut(250);
    });

    $(`#Txt_AteNum`).focusout((Me) => {
        let xValue = $(Me.currentTarget).val();

        if (xValue.length == 0) {
            $(`#errFolio`).fadeIn(250);
        }
    });

    $(`#Btn_Login`).click(() => {
        let valRUT = $(`#Txt_RUT`).val();
        let valATE = $(`#Txt_AteNum`).val();
        let valDATE = $(`#Txt_Date`).val();

        valRUT = Valid_RUT(valRUT);
        if (valRUT.Clean == true) {
            $(`#errRUT_2`).fadeIn(250);
            return;
        }

        if (valATE.length == 0) {
            $(`#errFolio`).fadeIn(250);
            return;
        }

        fn_AJAX();
    });
});

let fn_AJAX = () => {
    let objParam = {
        RUT: $(`#Txt_RUT`).val(),
        N_ATE: $(`#Txt_AteNum`).val(),
        Date_ATE: (function () {
            let arrDate = $(`#Txt_Date`).val().split("/");
            let arrOutput = [];
            
            arrDate.forEach((xItem) => {
                arrOutput.push(parseInt(xItem));
            });

            return arrOutput;
        }())
    };

    $.ajax({
        "type": "POST",
        "url": "/Acceso_Pacientes/Login_Pacientes.aspx/Login",
        "data": JSON.stringify(objParam),
        "contentType": "application/json;  charset=utf-8",
        "dataType": "json",
        "timeout": 5000,
        "success": resp => {
            if (resp.d == null) {
                $(`#errNotFound`).fadeIn(250);
            } else {
                window.location = resp.d;
            }
        },
        "error": fail => {
            $(`#errNotFound`).fadeIn(250);
        }
    })
};
