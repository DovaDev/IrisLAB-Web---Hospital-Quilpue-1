// eslint-disable-next-line @typescript-eslint/ban-ts-comment
// @ts-nocheck
namespace CONF_USER {
    declare var modal_show: () => void
    declare var Hide_Modal: () => void
    declare var Valid_RUT: (str_In: string) => INT.iRUT
    class Load {
        counter: number = 0
        limiter: number = 7

        constructor() {
            $(document).ready(() => {
                modal_show()
            })
        }

        callback() {
            if (this.counter >= this.limiter) {
                this.counter = 0
                Hide_Modal()
            } else {
                this.counter += 1
            }
        }
    }

    namespace INT {
        export interface int_Sel_Role {
            USU_ADMIN: number;
            ADMIN_DESC: string;
        }

        export interface iRUT {
            Clean: string;
            Valid: boolean;
            Format: string;
        }

        export interface int_Data {
            ID_USUARIO: number;
            USU_NOMBRE: string;
            USU_APELLIDO: string;
            ID_ESTADO: number;
            USU_NIC: string;
            ADMIN_DESC: string;
            PROC_DESC: string;
            PREVE_DESC: string;
        }

        export interface int_UserData {
            ID_USUARIO: number;
            USU_NIC: string;
            USU_PASS: string;
            ID_PER_USU: number;
            USU_NOMBRE: string;
            USU_APELLIDO: string;
            ID_ESTADO: number;
            ID_PROFESION: number;
            USU_RUT: string;
            USU_DIR: string;
            ID_CIUDAD: number;
            ID_COMUNA: number;
            USU_FONO: string;
            USU_MOVIL: string;
            USU_EMAIL: string;
            ID_CARGO: number;
            USU_FNAC: Date;
            USU_TM: number;
            USU_ADMIN: number;
            USU_ENTER_LINK: string;
            USU_MOBILE: number;
            USU_ID_PROC: number;
            USU_ID_PREV: number;
            //USU_FIRMA: number;
            //USU_FIRMA2: number;
        }
    }

    namespace OBJ {
        //Declaraciones Variables de Entorno
        let bol_AddUser: boolean = false
        let bol_EditUser: boolean = false
        export let arrTable: Array<INT.int_Data> = []
        export let objUser: INT.int_UserData
        export let objLoad = new Load()

        //Declaraciones Elementos
        export let Txt_Nick = new WEBFORM.class_Input("Txt_Nick")
        export let Sel_Role = new WEBFORM.class_Select("Sel_Role")
        export let Txt_Pass01 = new WEBFORM.class_Input("Txt_Pass01")
        export let Txt_FNac = new WEBFORM.class_DatePicker("Txt_FNac", true)
        export let Txt_Rut = new WEBFORM.class_Input("Txt_Rut")
        export let Sel_Proc = new WEBFORM.class_Select("Sel_Proc")
        export let Sel_Prev = new WEBFORM.class_Select("Sel_Prev")
        export let Txt_Nombre = new WEBFORM.class_Input("Txt_Nombre")
        export let Txt_Surn = new WEBFORM.class_Input("Txt_Surn")
        export let Txt_Direct = new WEBFORM.class_Input("Txt_Direct")
        export let Txt_Email = new WEBFORM.class_Input("Txt_Email")
        export let Txt_Fono = new WEBFORM.class_Input("Txt_Fono")
        export let Txt_Cel = new WEBFORM.class_Input("Txt_Cel")
        export let Sel_Ciudad = new WEBFORM.class_Select("Sel_Ciudad")
        export let Sel_Comuna = new WEBFORM.class_Select("Sel_Comuna")
        export let Sel_Profesion = new WEBFORM.class_Select("Sel_Profesion")
        export let Sel_Cargo = new WEBFORM.class_Select("Sel_Cargo")
        export let Sel_Estado = new WEBFORM.class_Select("Sel_Estado")

        export let objTable = new WEBFORM.class_Table("divTable", `Cargando...`)
        export let Chk_Activo = new WEBFORM.class_Chk_Static("Chk_Activo")

        export let Btn_Add = new WEBFORM.class_Button("Btn_Add")
        export let Btn_Edit = new WEBFORM.class_Button("Btn_Edit")
        export let Btn_Save = new WEBFORM.class_Button("Btn_Save")

        //Declaraciones AJAX
        export let objAJAX_Sel_Role = new TOOL.class_AJAX(
            "Conf_User.aspx/Data_Sel_Role",
            (resp: TOOL.int_ajax_success) => {
                let arrSel_Data: Array<WEBFORM.int_select>
                arrSel_Data = resp.d

                Sel_Role.cleanAll()
                arrSel_Data.forEach((xItem) => {
                    Sel_Role.insertElem(xItem.text, xItem.value)
                })

                objLoad.callback()
            },
            (fail: any) => {
                Hide_Modal()
                $("#mdlError").modal("show")

                try {
                    $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType)
                    $("#mdlTxt_Descr").text(fail.responseJSON.Message)
                    $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace)
                } catch (err) {
                    $("#mdlTxt_Type").text("Error Genérico")
                    $("#mdlTxt_Descr").text("Error en el Front End")
                    $("#mdlTxt_StackT").text("Mire la consola para Detalles.")
                    console.log(fail)
                }
            }
        )

        export let objAJAX_Sel_Proc = new TOOL.class_AJAX(
            "Conf_User.aspx/Data_Sel_Proc",
            (resp: TOOL.int_ajax_success) => {
                let arrSel_Data: Array<WEBFORM.int_select>
                arrSel_Data = resp.d

                Sel_Proc.cleanAll()
                Sel_Proc.insertElem("TODOS", 0)
                arrSel_Data.forEach((xItem) => {
                    Sel_Proc.insertElem(xItem.text, xItem.value)
                })

                objLoad.callback()
            },
            (fail: any) => {
                Hide_Modal()
                $("#mdlError").modal("show")

                try {
                    $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType)
                    $("#mdlTxt_Descr").text(fail.responseJSON.Message)
                    $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace)
                } catch (err) {
                    $("#mdlTxt_Type").text("Error Genérico")
                    $("#mdlTxt_Descr").text("Error en el Front End")
                    $("#mdlTxt_StackT").text("Mire la consola para Detalles.")
                    console.log(fail)
                }
            }
        )

        export let objAJAX_Sel_Prev = new TOOL.class_AJAX(
            "Conf_User.aspx/Data_Sel_Prev",
            (resp: TOOL.int_ajax_success) => {
                let arrSel_Data: Array<WEBFORM.int_select>
                arrSel_Data = resp.d

                Sel_Prev.cleanAll()
                Sel_Prev.insertElem("TODOS", 0)
                arrSel_Data.forEach((xItem) => {
                    Sel_Prev.insertElem(xItem.text, xItem.value)
                })

                objLoad.callback()
            },
            (fail: any) => {
                Hide_Modal()
                $("#mdlError").modal("show")

                try {
                    $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType)
                    $("#mdlTxt_Descr").text(fail.responseJSON.Message)
                    $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace)
                } catch (err) {
                    $("#mdlTxt_Type").text("Error Genérico")
                    $("#mdlTxt_Descr").text("Error en el Front End")
                    $("#mdlTxt_StackT").text("Mire la consola para Detalles.")
                    console.log(fail)
                }
            }
        )

        export let objAJAX_Sel_Ciudad = new TOOL.class_AJAX(
            "Conf_User.aspx/Data_Sel_Ciudad",
            (resp: TOOL.int_ajax_success) => {
                let arrSel_Data: Array<WEBFORM.int_select>
                arrSel_Data = resp.d

                Sel_Ciudad.cleanAll()
                //Sel_Ciudad.insertElem("TODOS", 0)
                arrSel_Data.forEach((xItem) => {
                    Sel_Ciudad.insertElem(xItem.text, xItem.value)
                })

                objAJAX_Sel_Comuna.requestNow({
                    ID_CIUD: Sel_Ciudad.getValue().value
                })

                objLoad.callback()
            },
            (fail: any) => {
                Hide_Modal()
                $("#mdlError").modal("show")

                try {
                    $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType)
                    $("#mdlTxt_Descr").text(fail.responseJSON.Message)
                    $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace)
                } catch (err) {
                    $("#mdlTxt_Type").text("Error Genérico")
                    $("#mdlTxt_Descr").text("Error en el Front End")
                    $("#mdlTxt_StackT").text("Mire la consola para Detalles.")
                    console.log(fail)
                }
            }
        )

        export let objAJAX_Sel_Comuna = new TOOL.class_AJAX(
            "Conf_User.aspx/Data_Sel_Comuna",
            (resp: TOOL.int_ajax_success) => {
                let arrSel_Data: Array<WEBFORM.int_select>
                arrSel_Data = resp.d

                Sel_Comuna.cleanAll()
                //Sel_Comuna.insertElem("TODOS", 0)
                arrSel_Data.forEach((xItem) => {
                    Sel_Comuna.insertElem(xItem.text, xItem.value)
                })

                objLoad.callback()
            },
            (fail: any) => {
                Hide_Modal()
                $("#mdlError").modal("show")

                try {
                    $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType)
                    $("#mdlTxt_Descr").text(fail.responseJSON.Message)
                    $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace)
                } catch (err) {
                    $("#mdlTxt_Type").text("Error Genérico")
                    $("#mdlTxt_Descr").text("Error en el Front End")
                    $("#mdlTxt_StackT").text("Mire la consola para Detalles.")
                    console.log(fail)
                }
            }
        )

        export let objAJAX_Sel_Profesion = new TOOL.class_AJAX(
            "Conf_User.aspx/Data_Sel_Prefesion",
            (resp: TOOL.int_ajax_success) => {
                let arrSel_Data: Array<WEBFORM.int_select>
                arrSel_Data = resp.d

                Sel_Profesion.cleanAll()
                arrSel_Data.forEach((xItem) => {
                    Sel_Profesion.insertElem(xItem.text, xItem.value)
                })

                objLoad.callback()
            },
            (fail: any) => {
                Hide_Modal()
                $("#mdlError").modal("show")

                try {
                    $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType)
                    $("#mdlTxt_Descr").text(fail.responseJSON.Message)
                    $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace)
                } catch (err) {
                    $("#mdlTxt_Type").text("Error Genérico")
                    $("#mdlTxt_Descr").text("Error en el Front End")
                    $("#mdlTxt_StackT").text("Mire la consola para Detalles.")
                    console.log(fail)
                }
            }
        )

        export let objAJAX_Sel_Cargo = new TOOL.class_AJAX(
            "Conf_User.aspx/Data_Sel_Cargo",
            (resp: TOOL.int_ajax_success) => {
                let arrSel_Data: Array<WEBFORM.int_select>
                arrSel_Data = resp.d

                Sel_Cargo.cleanAll()
                arrSel_Data.forEach((xItem) => {
                    Sel_Cargo.insertElem(xItem.text, xItem.value)
                })

                objLoad.callback()
            },
            (fail: any) => {
                Hide_Modal()
                $("#mdlError").modal("show")

                try {
                    $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType)
                    $("#mdlTxt_Descr").text(fail.responseJSON.Message)
                    $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace)
                } catch (err) {
                    $("#mdlTxt_Type").text("Error Genérico")
                    $("#mdlTxt_Descr").text("Error en el Front End")
                    $("#mdlTxt_StackT").text("Mire la consola para Detalles.")
                    console.log(fail)
                }
            }
        )

        export let objAJAX_Sel_Estados = new TOOL.class_AJAX(
            "Conf_User.aspx/Data_Sel_Estados",
            (resp: TOOL.int_ajax_success) => {
                let arrSel_Data: Array<WEBFORM.int_select>
                arrSel_Data = resp.d

                Sel_Estado.cleanAll()
                arrSel_Data.forEach((xItem) => {
                    Sel_Estado.insertElem(xItem.text, xItem.value)
                })

                objLoad.callback()
            },
            (fail: any) => {
                Hide_Modal()
                $("#mdlError").modal("show")

                try {
                    $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType)
                    $("#mdlTxt_Descr").text(fail.responseJSON.Message)
                    $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace)
                } catch (err) {
                    $("#mdlTxt_Type").text("Error Genérico")
                    $("#mdlTxt_Descr").text("Error en el Front End")
                    $("#mdlTxt_StackT").text("Mire la consola para Detalles.")
                    console.log(fail)
                }
            }
        )

        export let objAJAX_Table = new TOOL.class_AJAX(
            "Conf_User.aspx/Call_Table_Data",
            (resp: TOOL.int_ajax_success) => {
                arrTable = resp.d

                objTable.cleanTable("No se han encontrado Usuarios Registrados")
                if (arrTable.length == 0) {
                    return
                }

                //Agregar Cabeceras
                objTable.addTHead("N°", "right")
                objTable.addTHead("Nickname", "left")
                objTable.addTHead("Nombre", "left")
                objTable.addTHead("Activo", "center")
                objTable.addTHead("Tipo Usuario", "center")
                objTable.addTHead("Procedencia", "left")
                objTable.addTHead("Previsión", "left")

                //Llenar Tabla
                arrTable.forEach((xItem, xI) => {
                    objTable.addRow(
                        xItem.ID_USUARIO,
                        [
                            (function (): string {
                                let reeee = `${xI + 1}`

                                while (reeee.length < `${arrTable.length}`.length) {
                                    reeee = `0${reeee}`
                                }

                                return reeee
                            } ()),
                            xItem.USU_NIC,
                            `${xItem.USU_NOMBRE} ${xItem.USU_APELLIDO}`,
                            (function (): string {
                                let bolTest: boolean = false


                                if (xItem.ID_ESTADO == 1) {
                                    bolTest = true
                                }

                                return Chk_Activo.toString(xI, null, bolTest)
                            } ()),
                            xItem.ADMIN_DESC,
                            xItem.PROC_DESC,
                            xItem.PREVE_DESC
                        ]
                    )
                })

                objTable.updateTable("No se han encontrado Usuarios registrados", 25)
            },
            (fail: any) => {
                Hide_Modal()
                $("#mdlError").modal("show")

                try {
                    $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType)
                    $("#mdlTxt_Descr").text(fail.responseJSON.Message)
                    $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace)
                } catch (err) {
                    $("#mdlTxt_Type").text("Error Genérico")
                    $("#mdlTxt_Descr").text("Error en el Front End")
                    $("#mdlTxt_StackT").text("Mire la consola para Detalles.")
                    console.log(fail)
                }
            }
        )

        export let objAJAX_Get_User_Data = new TOOL.class_AJAX(
            "Conf_User.aspx/Call_User_Data",
            (resp: TOOL.int_ajax_success) => {
                objUser = resp.d

                //console.log(objUser)
                Sel_Ciudad.setValue(objUser.ID_CIUDAD)
                Txt_Nick.value = objUser.USU_NIC
                Sel_Role.setValue(objUser.USU_ADMIN)
                Txt_Pass01.value = objUser.USU_PASS
                Txt_FNac.value = moment(objUser.USU_FNAC).format("DD/MM/YYYY")
                Txt_Rut.value = objUser.USU_RUT
                Txt_Nombre.value = objUser.USU_NOMBRE
                Txt_Surn.value = objUser.USU_APELLIDO
                Txt_Direct.value = objUser.USU_DIR
                Txt_Email.value = objUser.USU_EMAIL
                Txt_Fono.value = objUser.USU_FONO
                Txt_Cel.value = objUser.USU_MOVIL

                OBJ.objAJAX_Sel_Comuna.requestNow({
                    ID_CIUD: OBJ.Sel_Ciudad.getValue().value
                }, () => {
                    Sel_Comuna.setValue(objUser.ID_COMUNA)
                })

                Sel_Profesion.setValue(objUser.ID_PROFESION)
                Sel_Cargo.setValue(objUser.ID_CARGO)
                Sel_Estado.setValue(objUser.ID_ESTADO)


                OBJ.objAJAX_Sel_Proc.requestNow({
                    ID_PREV: 0
                }, () => {
                    Sel_Proc.setValue(objUser.USU_ID_PROC)

                    OBJ.objAJAX_Sel_Prev.requestNow({
                        ID_PROC: objUser.USU_ID_PROC
                    }, () => {
                        Sel_Prev.setValue(objUser.USU_ID_PREV)
                    })
                })
            },
            (fail: any) => {
                Hide_Modal()
                $("#mdlError").modal("show")

                try {
                    $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType)
                    $("#mdlTxt_Descr").text(fail.responseJSON.Message)
                    $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace)
                } catch (err) {
                    $("#mdlTxt_Type").text("Error Genérico")
                    $("#mdlTxt_Descr").text("Error en el Front End")
                    $("#mdlTxt_StackT").text("Mire la consola para Detalles.")
                    console.log(fail)
                }
            }
        )

        export let objAJAX_Get_User_Write = new TOOL.class_AJAX(
            "Conf_User.aspx/IRIS_WEBF_CMVM_USER_UPDATE",
            (resp: TOOL.int_ajax_success) => {
                objAJAX_Table.requestNow()
            },
            (fail: any) => {
                Hide_Modal()
                $("#mdlError").modal("show")

                try {
                    $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType)
                    $("#mdlTxt_Descr").text(fail.responseJSON.Message)
                    $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace)
                } catch (err) {
                    $("#mdlTxt_Type").text("Error Genérico")
                    $("#mdlTxt_Descr").text("Error en el Front End")
                    $("#mdlTxt_StackT").text("Mire la consola para Detalles.")
                    console.log(fail)
                }
            }
        )

        export let objAJAX_Get_User_Change_Stat = new TOOL.class_AJAX(
            "Conf_User.aspx/Change_Status",
            (resp: TOOL.int_ajax_success) => {
            },
            (fail: any) => {
                Hide_Modal()
                $("#mdlError").modal("show")

                try {
                    $("#mdlTxt_Type").text(fail.responseJSON.ExceptionType)
                    $("#mdlTxt_Descr").text(fail.responseJSON.Message)
                    $("#mdlTxt_StackT").text(fail.responseJSON.StackTrace)
                } catch (err) {
                    $("#mdlTxt_Type").text("Error Genérico")
                    $("#mdlTxt_Descr").text("Error en el Front End")
                    $("#mdlTxt_StackT").text("Mire la consola para Detalles.")
                    console.log(fail)
                }
            }
        )
    }

    namespace EV {
        //Selects
        OBJ.Sel_Proc.eventChange((Me: JQueryEventObject) => {
            OBJ.objAJAX_Sel_Prev.requestNow({
                ID_PROC: OBJ.Sel_Proc.getValue().value
            })
        })
        //OBJ.Sel_Prev.eventChange((Me: JQueryEventObject) => {
        //    OBJ.objAJAX_Sel_Proc.requestNow({
        //        ID_PREV: OBJ.Sel_Prev.getValue().value
        //    })
        //})
        OBJ.Sel_Ciudad.eventChange((Me: JQueryEventObject) => {
            OBJ.objAJAX_Sel_Comuna.requestNow({
                ID_CIUD: OBJ.Sel_Ciudad.getValue().value
            })
        })
        
        //Textbox
        OBJ.Txt_Rut.evKeyup((Me: JQueryEventObject) => {
            let xValue = $(Me.currentTarget).val();
            let xValAlt = "";
            let xOut = "";

            xValue = xValue.replace(/(\.|-)/gi, "");
            if (xValue.match(/^[0-9]*(k?)$/gi) == null) {
                $(Me.currentTarget).val("");
                $(`#errRUT_2`).hide();
                $(`#errRUT_1`).slideDown(() => {
                    setTimeout(() => {
                        $(`#errRUT_1`).slideUp();
                    }, 5000);
                });
                return;
            } else if (xValue.length > 9) {
                $(Me.currentTarget).val("");
                $(`#errRUT_2`).hide();
                $(`#errRUT_1`).slideDown(() => {
                    setTimeout(() => {
                        $(`#errRUT_1`).slideUp();
                    }, 5000);
                });
                return;
            }

            //$(`#errRUT_1`).fadeOut(250);
            //$(`#errRUT_2`).show()

            for (var i = xValue.length - 1; i >= 0; i--) {
                xValAlt = `${xValAlt}${xValue[i]}`
            }

            let arrValAlt = xValAlt.split("");
            for (i = 0; i < arrValAlt.length; i++) {
                xOut = `${arrValAlt[i]}${xOut}`;

                if (i == 0) {
                    xOut = `-${xOut}`;
                } else if (i == 3) {
                    xOut = `.${xOut}`;
                } else if (i == 6) {
                    xOut = `.${xOut}`;
                }
            }

            $(Me.currentTarget).val(xOut);
        })
        OBJ.Txt_Rut.evFocusOut((Me: JQueryEventObject) => {
            let xRut: INT.iRUT = Valid_RUT(OBJ.Txt_Rut.value)

            if (xRut.Valid == false) {
                OBJ.Txt_Rut.value = ""
            }
        })

        //Eventos Tabla
        $(document).ready(() => {
            OBJ.objTable.isClickeable = true
            OBJ.objTable.isDataTable = true

            OBJ.objAJAX_Sel_Role.requestNow()
            OBJ.objAJAX_Sel_Proc.requestNow({
                ID_PREV: 0
            }, () => {
                OBJ.objAJAX_Sel_Prev.requestNow({
                    ID_PROC: OBJ.Sel_Proc.getValue().value
                })
            })
            OBJ.objAJAX_Sel_Ciudad.requestNow()
            OBJ.objAJAX_Sel_Profesion.requestNow()
            OBJ.objAJAX_Sel_Cargo.requestNow()
            OBJ.objAJAX_Sel_Estados.requestNow()
            OBJ.objAJAX_Table.requestNow()
        })
        OBJ.objTable.evclick_tr = (Me: JQueryEventObject): void => {
            Me.stopImmediatePropagation()
            //OBJ.Chk_Activo.evClick = (Me: JQueryEventObject) => {
            //    let ID_USER: number = JSON.parse(atob($(Me.currentTarget).val())).d
            //    let bolStat: boolean = $(Me.currentTarget).prop("checked")

            //    //console.log(`ID_USER = ${ID_USER}\nSTATUS = ${bolStat}`)
            //    OBJ.objAJAX_Get_User_Change_Stat.requestNow({
            //        ID_USER: ID_USER,
            //        ID_ESTADO: bolStat
            //    })
            //}
            if ($(Me.target).parents("td").children("div").children("input").length > 0) {
                let ID_USER: number = OBJ.arrTable[JSON.parse(atob($(Me.target).val())).d].ID_USUARIO
                let bolStat: boolean = $(Me.target).prop("checked")

                //console.log(`ID_USER = ${ID_USER}\nSTATUS = ${bolStat}`)
                OBJ.objAJAX_Get_User_Change_Stat.requestNow({
                    ID_USER: ID_USER,
                    ID_ESTADO: bolStat
                })
            } else {

                fn_Deactivate()
                fn_Readonly(true)
                OBJ.Btn_Edit.setActive(true)

                fn_Clear()
                OBJ.objAJAX_Get_User_Data.requestNow({
                    ID_USER: parseInt(`${OBJ.objTable.tr_value}`)
                })
            }
        }

        //Agregar/Editar usuario
        $(document).ready(() => {
            OBJ.Btn_Add.setActive(true)
            OBJ.Btn_Edit.setActive(false)
            OBJ.Btn_Save.setActive(false)

            OBJ.Txt_Nick.active = false
            OBJ.Sel_Role.active = false
            OBJ.Txt_Pass01.active = false
            OBJ.Txt_FNac.active = false
            OBJ.Txt_Rut.active = false
            OBJ.Sel_Proc.active = false
            OBJ.Sel_Prev.active = false
            OBJ.Txt_Nombre.active = false
            OBJ.Txt_Surn.active = false
            OBJ.Txt_Direct.active = false
            OBJ.Txt_Email.active = false
            OBJ.Txt_Fono.active = false
            OBJ.Txt_Cel.active = false
            OBJ.Sel_Ciudad.active = false
            OBJ.Sel_Comuna.active = false
            OBJ.Sel_Profesion.active = false
            OBJ.Sel_Cargo.active = false
            OBJ.Sel_Estado.active = false

            OBJ.Txt_FNac.placeholder = "Ingrese Fecha..."
        })
        $(window).resize(() => {
            let vw: number = window.innerWidth;

            if (vw <= 767.98) {
                $("#divData .card-body > .row").appendTo("#mdlData .modal-body")
                $("#Btn_Save").appendTo("#mdlData .modal-footer")
                $("#Btn_Save").removeClass("btn-block")

                let xlng: number = $("#divData .card-body > .row > div").length
                $("#divData .card-body > .row > div").eq(xlng - 1).remove()

            } else {
                $("#mdlData .modal-body > .row").appendTo("#divData .card-body")
                $("#mdlData .modal-body > .row").append(
                    $("<div>", { class: "col-md-12" })
                )

                let xlng: number = $("#divData .card-body > .row > div").length
                $("#Btn_Save").appendTo($("#divData .card-body > .row > div").eq(xlng - 1))
                $("#Btn_Save").addClass("btn-block")
                $("#mdlData").modal("hide")
            }
        })

        let fn_Deactivate = () => {

            OBJ.Btn_Add.setActive(true)
            OBJ.Btn_Edit.setActive(false)
            OBJ.Btn_Save.setActive(false)

            OBJ.Txt_Nick.active = false
            OBJ.Sel_Role.active = false
            OBJ.Txt_Pass01.active = false
            OBJ.Txt_FNac.active = false
            OBJ.Txt_Rut.active = false
            OBJ.Sel_Proc.active = false
            OBJ.Sel_Prev.active = false
            OBJ.Txt_Nombre.active = false
            OBJ.Txt_Surn.active = false
            OBJ.Txt_Direct.active = false
            OBJ.Txt_Email.active = false
            OBJ.Txt_Fono.active = false
            OBJ.Txt_Cel.active = false
            OBJ.Sel_Ciudad.active = false
            OBJ.Sel_Comuna.active = false
            OBJ.Sel_Profesion.active = false
            OBJ.Sel_Cargo.active = false
            OBJ.Sel_Estado.active = false

            OBJ.Txt_FNac.placeholder = "Ingrese Fecha..."
        }
        let fn_Activate = () => {
            OBJ.Txt_Nick.active = true
            OBJ.Sel_Role.active = true
            OBJ.Txt_FNac.active = true
            OBJ.Txt_Rut.active = true
            OBJ.Sel_Proc.active = true
            OBJ.Sel_Prev.active = true
            OBJ.Txt_Nombre.active = true
            OBJ.Txt_Surn.active = true
            OBJ.Txt_Direct.active = true
            OBJ.Txt_Email.active = true
            OBJ.Txt_Fono.active = true
            OBJ.Txt_Cel.active = true
            OBJ.Sel_Ciudad.active = true
            OBJ.Sel_Comuna.active = true
            OBJ.Sel_Profesion.active = true
            OBJ.Sel_Cargo.active = true
            OBJ.Sel_Estado.active = true
        }
        let fn_Readonly = (changeTo: boolean) => {
            OBJ.Txt_Nick.readOnly = changeTo
            OBJ.Sel_Role.readOnly = changeTo
            OBJ.Txt_Pass01.readOnly = changeTo
            OBJ.Txt_Rut.readOnly = changeTo
            OBJ.Sel_Proc.readOnly = changeTo
            OBJ.Sel_Prev.readOnly = changeTo
            OBJ.Txt_Nombre.readOnly = changeTo
            OBJ.Txt_Surn.readOnly = changeTo
            OBJ.Txt_Direct.readOnly = changeTo
            OBJ.Txt_Email.readOnly = changeTo
            OBJ.Txt_Fono.readOnly = changeTo
            OBJ.Txt_Cel.readOnly = changeTo
            OBJ.Sel_Ciudad.readOnly = changeTo
            OBJ.Sel_Comuna.readOnly = changeTo
            OBJ.Sel_Profesion.readOnly = changeTo
            OBJ.Sel_Cargo.readOnly = changeTo
            OBJ.Sel_Estado.readOnly = changeTo
        }
        let fn_Clear = () => {
            OBJ.Txt_Nick.value = ""
            OBJ.Sel_Role.setValue(OBJ.Sel_Role.data[0].value)
            OBJ.Txt_Pass01.value = ""
            OBJ.Txt_Rut.value = ""
            OBJ.Sel_Proc.setValue(OBJ.Sel_Proc.data[0].value)
            OBJ.Sel_Prev.setValue(OBJ.Sel_Prev.data[0].value)
            OBJ.Txt_Nombre.value = ""
            OBJ.Txt_Surn.value = ""
            OBJ.Txt_Direct.value = ""
            OBJ.Txt_Email.value = ""
            OBJ.Txt_Fono.value = ""
            OBJ.Txt_Cel.value = ""
            OBJ.Sel_Ciudad.setValue(OBJ.Sel_Ciudad.data[0].value)
            OBJ.Sel_Comuna.setValue(OBJ.Sel_Comuna.data[0].value)
            OBJ.Sel_Profesion.setValue(OBJ.Sel_Profesion.data[0].value)
            OBJ.Sel_Cargo.setValue(OBJ.Sel_Cargo.data[0].value)
            OBJ.Sel_Estado.setValue(OBJ.Sel_Estado.data[0].value)
        }

        OBJ.Btn_Add.click((Me: JQueryEventObject) => {
            bolEdit = false
            $(window).resize()
            fn_Activate()
            fn_Readonly(false)
            fn_Clear()

            OBJ.Txt_Pass01.active = true
            OBJ.Btn_Edit.setActive(false)
            $("#divTable table tr").removeClass("tr_selected")

            let vw: number = window.innerWidth;
            if (vw <= 767.98) {
                $("#mdlData .modal-header h5").text("Crear Usuario")
                $("#mdlData").modal()
            }
        })
        OBJ.Btn_Edit.click((Me: JQueryEventObject) => {
            bolEdit = true
            $(window).resize()
            fn_Activate()
            fn_Readonly(false)

            OBJ.Txt_Pass01.active = true

            let vw: number = window.innerWidth;
            if (vw <= 767.98) {
                $("#mdlData .modal-header h5").text("Modificar Usuario")
                $("#mdlData").modal()
            }
        })

        //Validación
        $(document).ready(() => {
            $(`#divData select`).change((Me: JQueryEventObject) => {
                fn_Check_Txt(bolEdit)
            })
            $(`#divData input`).keyup((Me: JQueryEventObject) => {
                fn_Check_Txt(bolEdit)
            })
        })
        let bolEdit: boolean = false
        let fn_Check_Txt = (bolEdit: boolean) => {
            if (OBJ.Txt_Nick.value.trim() == "") {
                OBJ.Btn_Save.setActive(false)
                return
            }

            if (OBJ.Txt_Pass01.value.trim() == "") {
                OBJ.Btn_Save.setActive(false)
                return
            }

            if (OBJ.Txt_FNac.value == moment().format("DD/MM/YYYY")) {
                OBJ.Btn_Save.setActive(false)
                return
            }

            if (OBJ.Txt_Rut.value.trim() == "") {
                OBJ.Btn_Save.setActive(false)
                return
            }

            if (OBJ.Txt_Nombre.value.trim() == "") {
                OBJ.Btn_Save.setActive(false)
                return
            }

            if (OBJ.Txt_Surn.value.trim() == "") {
                OBJ.Btn_Save.setActive(false)
                return
            }

            OBJ.Btn_Save.setActive(true)
        }
        OBJ.Btn_Save.click((Me: JQueryEventObject) => {
            let ID_USUARIO: number = (function (): number {
                if (OBJ.objTable.tr_value == null) {
                    return 0
                } else {
                    return parseInt(`${OBJ.objTable.tr_value}`)
                }
            } ())
            let strPass: string = OBJ.Txt_Pass01.value

            if (bolEdit == true) {
                $(`#lbl_Message p`).html(`Usuario Editado Correctamente`)
                OBJ.objAJAX_Get_User_Write.URL = "Conf_User.aspx/IRIS_WEBF_CMVM_USER_UPDATE"
            } else {
                $(`#lbl_Message p`).html(`Usuario Creado Correctamente`)
                OBJ.objAJAX_Get_User_Write.URL = "Conf_User.aspx/IRIS_WEBF_CMVM_USER_INSERT"
            }

            OBJ.objAJAX_Get_User_Write.requestNow({
                ID_USER: ID_USUARIO,
                USU_NICK: OBJ.Txt_Nick.value,
                ID_ROLE: OBJ.Sel_Role.getValue().value,
                USU_PASS: strPass,
                USU_FNAC: OBJ.Txt_FNac.value,
                USU_RUT: OBJ.Txt_Rut.value,
                ID_PROC: OBJ.Sel_Proc.getValue().value,
                ID_PREV: OBJ.Sel_Prev.getValue().value,
                USU_NOMBRE: OBJ.Txt_Nombre.value,
                USU_APELLIDO: OBJ.Txt_Surn.value,
                USU_DIR: OBJ.Txt_Direct.value,
                USU_EMAIL: OBJ.Txt_Email.value,
                USU_FONO: OBJ.Txt_Fono.value,
                USU_MOVIL: OBJ.Txt_Cel.value,
                ID_CIUDAD: OBJ.Sel_Ciudad.getValue().value,
                ID_COMUNA: OBJ.Sel_Comuna.getValue().value,
                ID_PROFESION: OBJ.Sel_Profesion.getValue().value,
                ID_CARGO: OBJ.Sel_Cargo.getValue().value,
                ID_ESTADO: OBJ.Sel_Estado.getValue().value
            })

            OBJ.Btn_Save.setActive(false)
            $("#divTable table tr").removeClass("tr_selected")
            fn_Clear()
            fn_Deactivate()
            $("#mdlData").modal("hide")

            $(`#lbl_Message`).fadeIn(250, () => {
                setTimeout(() => {
                    $(`#lbl_Message`).fadeOut(250)
                }, 1500)
            })
        })
    }
}