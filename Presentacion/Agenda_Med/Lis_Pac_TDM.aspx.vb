Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Imports Datos

Public Class Lis_Pac_TDM
    Inherits System.Web.UI.Page

    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If

        Select Case (C_P_ADMIN.Value)
            Case 2
                'Response.Redirect("~/Index.aspx")
        End Select
    End Sub
    <Services.WebMethod()>
    Public Shared Function Enlazar_avis(ByVal ID_ate As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_pac As List(Of E_IRIS_WEBF_BUSCA_DATOS_PARA_ENLAZAR)
        Dim data_HO_CC As List(Of E_IRIS_WEBF_BUSCA_DATOS_PARA_ENLAZAR)
        Dim NN_pac As New N_Lis_Pac_TDM
        Dim reiii As String
        Dim numerito As Integer
        Dim APELLIDO_P As String
        Dim APELLIDO_M As String
        Dim FECHA_NAC As String
        Dim SEXO As String
        Dim FECHA As String
        data_pac = NN_pac.IRIS_WEBF_BUSCA_DATOS_PARA_ENLAZAR(ID_ate)
        If (data_pac(0).ATE_AVIS = "" Or data_pac(0).ATE_AVIS = "0") Then
            reiii = "null"
        Else

            data_HO_CC = NN_pac.IRIS_WEBF_BUSCA_SI_EXISTE_HO_CC(data_pac(0).ATE_AVIS)

            If (data_HO_CC.Count = 0) Then
                If (data_pac(0).PAC_APELLIDO.Split(" ").Count > 1) Then
                    APELLIDO_P = data_pac(0).PAC_APELLIDO.Split(" ")(0)
                    APELLIDO_M = data_pac(0).PAC_APELLIDO.Split(" ")(1)
                Else
                    APELLIDO_P = data_pac(0).PAC_APELLIDO.Split(" ")(0) & "."
                    APELLIDO_M = ""
                End If


                FECHA_NAC = Format(CDate(data_pac(0).PAC_FNAC), "yyyy/MM/dd").Replace("/", "")
                FECHA = Format(data_pac(0).ATE_FECHA, "yyyy/MM/dd HH:mm:ss").Replace("/", "").Replace(" ", "").Replace(":", "")
                If (data_pac(0).ID_SEXO = 2) Then
                    SEXO = "F"
                Else
                    SEXO = "M"
                End If

                For I = 0 To data_pac.Count - 1

                    numerito = NN_pac.IRIS_WEBF_BUSCA_DATOS_PARA_ENLAZAR_CON_UPDATE(data_pac(I).ATE_AVIS,
                                                                                    data_pac(I).PAC_RUT.Replace(".", ""),
                                                                                    data_pac(I).PAC_NOMBRE,
                                                                                    APELLIDO_P,
                                                                                    APELLIDO_M,
                                                                                    SEXO,
                                                                                    FECHA_NAC,
                                                                                    data_pac(I).PAC_FONO1,
                                                                                    data_pac(I).PAC_EMAIL,
                                                                                    data_pac(I).DOC_RUT,
                                                                                    data_pac(I).DOC_NOMBRE,
                                                                                    data_pac(I).DOC_APELLIDO,
                                                                                    data_pac(I).CF_AVIS,
                                                                                    data_pac(I).CF_DESC,
                                                                                    data_pac(I).COD_AVIS_PROC, ID_ate, FECHA)
                Next I
                If (numerito = 1) Then
                    reiii = "125"
                Else
                    reiii = "null"
                End If
            Else
                reiii = "2222"
            End If
        End If
        Return reiii
    End Function
    '<Services.WebMethod()>
    'Public Shared Function Llenar_Ddl_LugarTM() As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
    '    'Declaraciones internas
    '    Dim objN As New N_Gen_Activos
    '    Dim objL As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)

    '    objL = objN.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO_BY_ID_PREV
    '    Return objL
    'End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_LugarTM() As Object


        Return (New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO).IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()

    End Function


    '<Services.WebMethod()>
    'Public Shared Function Llenar_PAC(ByVal ID As String, ByVal fecha As String) As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
    '    'Declaraciones del Serializador
    '    Dim Serializer As New JavaScriptSerializer
    '    Dim str_Builder As New StringBuilder
    '    Dim datas As String = ""
    '    'Declaraciones internas
    '    Dim data_pac As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
    '    Dim NN_pac As New N_PROCEDENCIAS_Y_CANT_MAX
    '    data_pac = NN_pac.IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2_BLOQUE_ID_ORDEN(ID, fecha)
    '    Return data_pac
    'End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_PAC(ID_PROCEDENCIA As Integer, ID_PREVISION As Integer, desde As String, hasta As String) As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_pac As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        Dim NN_pac As New N_PROCEDENCIAS_Y_CANT_MAX
        data_pac = NN_pac.IRIS_WEBF_BUSCA_LIS_PAC_TDM(ID_PROCEDENCIA, ID_PREVISION, desde, hasta)
        Return data_pac
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_LIS_PAC_TDM_TRAER_POR_ESTADO(ID_PROCEDENCIA As Integer, ID_PREVISION As Integer, desde As String, hasta As String, ESTADO As Integer) As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_pac As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        Dim NN_pac As New N_PROCEDENCIAS_Y_CANT_MAX
        data_pac = NN_pac.IRIS_WEBF_BUSCA_LIS_PAC_TDM_TRAER_POR_ESTADO(ID_PROCEDENCIA, ID_PREVISION, desde, hasta, ESTADO)
        Return data_pac
    End Function
    <Services.WebMethod()>
    Public Shared Function MODAL_PAC(ByVal ID As String, ByVal ID_ATE As String) As REEE
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim data_pac As List(Of E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2)
        Dim NN_pac As New N_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2
        Dim data_examen As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL)
        Dim NN_Examen As New N_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL

        Dim data_atencion As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION)
        Dim NN_atencion As New N_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION
        data_pac = NN_pac.IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2(ID)


        'IFIFIF'
        If (ID_ATE = 0) Then
            data_examen = NN_Examen.IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL(ID)
        Else
            data_examen = NN_Examen.IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL_ATE_ESTADO_4(ID_ATE)
        End If

        data_atencion = NN_atencion.IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION(ID)
        Dim reeeeeee As New REEE
        reeeeeee.proparra1 = data_pac
        reeeeeee.proparra2 = data_examen
        reeeeeee.proparra3 = data_atencion
        'Declaraciones internas
        Return reeeeeee
    End Function




    <Services.WebMethod()>
    Public Shared Function Update_No_Asistio(ID_PREINGRESO As Integer) As Integer
        Return N_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2.IRIS_WEBF_UPDATE_PREINGRESO_NO_ASISITIO(ID_PREINGRESO)
    End Function

    <Services.WebMethod()>
    Public Shared Function MODAL_Actualizar(ByVal ID_ate As String,
                                        ByVal id_pre As String,
                                        ByVal obs_TDM As String,
                                        ByVal obs As String,
                                        ByVal interno As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim DATASSSSSS As Integer
        Dim NN_pac As New N_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2
        Dim Str_Out As String = ""
        Dim NN_Examen As New N_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL
        Dim NN_atencion As New N_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION
        'update despues de pago
        If (ID_ate = 0) Then
            DATASSSSSS = NN_pac.IRIS_WEBF_UPDATE_OBS_INTERNO_PRE_INGRESO(id_pre, interno, obs, obs_TDM)
        Else
            DATASSSSSS = NN_pac.IRIS_WEBF_UPDATE_OBS_INTERNO_ATENCION(ID_ate, interno, obs_TDM, obs)
            DATASSSSSS = NN_pac.IRIS_WEBF_UPDATE_OBS_INTERNO_PRE_INGRESO(id_pre, interno, obs_TDM, obs)
        End If

        If DATASSSSSS > 0 Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(DATASSSSSS, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function MODAL_elimanar(ByVal ID_ate As String,
                                        ByVal id_pre As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim DATASSSSSS As Integer
        Dim NN_pac As New N_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2
        Dim Str_Out As String = ""
        'Dim data_pac As List(Of E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2)
        Dim data_examen As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL)
        Dim NN_Examen As New N_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL
        'Dim data_atencion As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION)
        Dim NN_atencion As New N_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION
        'Dim correlativo2 As Integer
        'Dim id_atencion As Integer
        'update despues de pago
        Dim NN_ExamenDet As New N_Exa_Esp_V
        'Dim DataExamenDet As Integer
        Dim exa_avis As Integer

        DATASSSSSS = NN_pac.IRIS_WEBF_UPDATE_ELIMINAR_PREINGRESO(id_pre)


        data_examen = NN_Examen.IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL_RT(id_pre)



        If (data_examen.Count > 0) Then
            For i = 0 To data_examen.Count - 1
                If (data_examen(i).ATE_NUM_AVIS <> 0) Then
                    exa_avis = NN_ExamenDet.IRIS_WEBF_UPDATE_ESTADO_EXAMEN_INTEGRACION_AVIS(data_examen(i).ATE_NUM_AVIS, data_examen(i).HO_ExamenCodigo)
                End If
            Next i
        End If



        If (ID_ate = 0) Then
        Else
            DATASSSSSS = NN_pac.IRIS_WEBF_UPDATE_ELIMINAR_ATENCION(ID_ate)

            Dim objSession As HttpSessionState = HttpContext.Current.Session
            Dim datos_his As New List(Of E_IRIS_WEBF_BUSCA_DATOS_PARA_HISTORIAL_AGREGA_QUITA_2)
            Dim n_histr As New N_historial
            datos_his = n_histr.IRIS_WEBF_BUSCA_DATOS_PARA_HISTORIAL_AGREGA_QUITA_2(ID_ate)
            Dim id_usuario As String = CType(objSession("ID_USER"), String)
            Dim grabar_01 As Integer
            If (datos_his.Count > 0) Then
                For i = 0 To datos_his.Count - 1
                    grabar_01 = n_histr.IRIS_WEBF_GRABA_HISTORIA_ATENCION_AGREGA_QUITA(ID_ate,
                                                                                   datos_his(i).ID_PER,
                                                                                   datos_his(i).ATE_DET_V_PAGADO,
                                                                                   datos_his(i).ATE_DET_V_COPAGO,
                                                                                  datos_his(i).ATE_DET_V_PREVI, 0, 0, 0, 0, 2, id_usuario)
                Next i
            End If

            Dim LOG As New N_Log
            Dim xNick As String = CType(objSession("NICKNAME"), String)
            LOG.Path = "\LOG\Cambio_Estado\" & Format(Date.Now, "dd-MM-yyyy - ") & "CAMBIO DE ELIMINAR EXAMEN" & ".txt"
            LOG.Write_Line("ELIMINAR ATENCION")
            LOG.Write_Line("NICKNAME = " & xNick, False)
            LOG.Write_Line("ID_PREINGRESO = " & id_pre, False)
            LOG.Write_Line("ID_ATE = " & ID_ate, False)
            LOG.Write_Separator()

        End If

        If DATASSSSSS > 0 Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(DATASSSSSS, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function MODAL_update(ByVal ID_ate As String,
                                        ByVal id_pre As String,
                                        ByVal obs_TDM As String,
                                        ByVal obs As String,
                                        ByVal interno As String) As List(Of E_IRIS_WEBF_correlativos)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim DATASSSSSS As Integer
        Dim NN_pac As New N_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2
        Dim Str_Out As String = ""
        Dim data_pac As List(Of E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2)
        Dim data_examen As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL)
        Dim NN_Examen As New N_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL
        Dim data_atencion As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION)
        Dim NN_atencion As New N_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION
        Dim correlativo2 As Integer
        Dim id_atencion As Integer
        Dim ddx As New N_IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS
        Dim ccx As New N_IRIS_WEBF_BUSCA_CORRELATIVO_ATENCION
        Dim id As Integer
        Dim jj As New N_IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_AVIS
        Dim resu As Integer
        Dim resuresu As New N_IRIS_WEBF_GRABA_RESULTADO_ATENCION
        Dim PERFIL_PRUEBA As List(Of E_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION)
        Dim hh As New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim S_Id_User As String = CType(objSession("ID_USER"), String)
        data_pac = NN_pac.IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2(id_pre)
        data_examen = NN_Examen.IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL(id_pre)
        data_atencion = NN_atencion.IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION(id_pre)
        correlativo2 = ccx.IRIS_WEBF_BUSCA_CORRELATIVO_ATENCION()

        Dim tot_paga As Integer = 0
        Dim tot_previ As Integer = 0
        Dim tot_copa As Integer = 0

        id_atencion = ddx.IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS(correlativo2,
                                                                          data_pac(0).ID_PACIENTE,
                                                                          CInt(S_Id_User),
                                                                          data_pac(0).PREI_FUR,
                                                                          data_atencion(0).ID_PROCEDENCIA,
                                                                          data_atencion(0).ID_ORDEN,
                                                                          data_atencion(0).ID_TP_PACI,
                                                                          data_atencion(0).ID_DOCTOR,
                                                                          data_atencion(0).ID_PREVE,
                                                                          data_atencion(0).ID_LOCAL,
                                                                          1,
                                                                          data_atencion(0).PREI_OBS_FICHA,
                                                                          data_atencion(0).PREI_CAMA,
                                                                          data_pac(0).PREI_AÑO,
                                                                          data_pac(0).PREI_MES,
                                                                          data_pac(0).PREI_DIA,
                                                                          tot_paga,'data_examen(0).PREI_DET_V_PAGADO,
                                                                          tot_previ,'data_examen(0).PREI_DET_V_PREVI,
                                                                          tot_copa,'data_examen(0).PREI_DET_V_COPAGO,
                                                                          data_atencion(0).ID_PROGRAMA,
                                                                          "",
                                                                          data_atencion(0).ID_SECTOR,
                                                                          correlativo2,
                                                                          interno,
                                                                          data_atencion(0).ID_DIAGNOSTICO, data_atencion(0).ID_DIAGNOSTICO2, data_atencion(0).VIH, data_pac(0).DNI, obs_TDM, data_atencion(0).Sub_PROGRAMA, "", 0, "", data_atencion(0).EMPRESA, data_atencion(0).ID_GRUPO_PESQUISA)


        For i = 0 To data_examen.Count - 1
            id = jj.IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_AVIS(id_atencion,
                                                                   CInt(S_Id_User),
                                                                   data_examen(i).ID_CODIGO_FONASA,
                                                                   data_examen(i).ID_PER,
                                                                   data_examen(i).ID_TP_PAGO,
                                                                   data_examen(i).PREI_DET_DOC,
                                                                   data_examen(i).PREI_DET_V_PREVI,
                                                                   data_examen(i).PREI_DET_V_PAGADO,
                                                                   data_examen(i).PREI_DET_V_COPAGO,
                                                                   data_examen(i).ATE_NUM_AVIS, "")

            PERFIL_PRUEBA = hh.IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION(data_examen(i).ID_PER)
            For x = 0 To PERFIL_PRUEBA.Count - 1
                If (PERFIL_PRUEBA(x).PRU_RESU_INMEDIATO_REAL = Nothing) Then
                    resu = resuresu.IRIS_WEBF_GRABA_RESULTADO_ATENCION(id_atencion, data_examen(i).ID_CODIGO_FONASA, data_examen(i).ID_PER, PERFIL_PRUEBA(x).ID_PRUEBA, id)
                Else
                    If (PERFIL_PRUEBA(x).ID_TP_RESULTADO = 1) Then
                        resu = resuresu.IRIS_WEBF_GRABA_RESULTADO_ATENCION_DEFECTO(id_atencion, data_examen(i).ID_CODIGO_FONASA, data_examen(i).ID_PER, PERFIL_PRUEBA(x).ID_PRUEBA, PERFIL_PRUEBA(x).PRU_RESU_INMEDIATO_REAL, id)
                    Else
                        resu = resuresu.IRIS_WEBF_GRABA_RESULTADO_ATENCION(id_atencion, data_examen(i).ID_CODIGO_FONASA, data_examen(i).ID_PER, PERFIL_PRUEBA(x).ID_PRUEBA, id)
                    End If
                End If
            Next x
        Next i
        '----------------- Auto PAGO Datos ---------------------------
        Dim qq As New N_IRIS_WEBF_UPDATE_ATE_AGREGA_ID_ATE_DOCP
        Dim update1 As Integer
        '----------------------------------------------------------
        Dim ww As New N_IRIS_WEBF_UPDATE_ATE_DETALLE_AGREGA_ID_ATE_DOCP
        Dim update2 As Integer
        '-----------------------------------------------------------
        Dim ee As New N_IRIS_WEBF_BUSCA_ATE_FORMA_PAGO_SUMA_TOTALES
        Dim buscarFormaPAgo As List(Of E_IRIS_WEBF_BUSCA_ATE_FORMA_PAGO_SUMA_TOTALES)
        '-----------------------------------------------------------------
        Dim rr As New N_IRIS_WEBF_BUSCA_ATE_DOCUMENTOS_DE_PAGO_POR_ID_ATENCION
        'Dim buscarAteDOC As List(Of E_IRIS_WEBF_BUSCA_ATE_DOCUMENTOS_DE_PAGO_POR_ID_ATENCION)
        '---------------------------------------------------------------------------------
        Dim correlativo_tp_pago As Integer
        Dim bb As New N_IRIS_WEBF_BUSCA_CORRELATIVO_DOCUMENTO_FORMA_PAGO
        Dim qwerty As Integer
        Dim xcv As New N_IRIS_WEBF_GRABA_TRX_BONOS
        Dim qwe As Integer
        Dim uuuu As New N_IRIS_WEBF_GRABA_ATE_DET_DOCUMENTO_PAGO_SIN_TRX
        correlativo_tp_pago = bb.IRIS_WEBF_BUSCA_CORRELATIVO_DOCUMENTO_FORMA_PAGO()
        update1 = qq.IRIS_WEBF_UPDATE_ATE_AGREGA_ID_ATE_DOCP(id_atencion, correlativo_tp_pago, 1)
        update2 = ww.IRIS_WEBF_UPDATE_ATE_DETALLE_AGREGA_ID_ATE_DOCP(id_atencion, correlativo_tp_pago)

        Dim graba_ate As Integer
        Dim tt As New N_IRIS_GRABA_ATE_DOCUMENTO_PAGO
        graba_ate = tt.IRIS_GRABA_ATE_DOCUMENTO_PAGO(id_atencion, correlativo_tp_pago, CInt(S_Id_User))
        buscarFormaPAgo = ee.IRIS_WEBF_BUSCA_ATE_FORMA_PAGO_SUMA_TOTALES(id_atencion)
        If (buscarFormaPAgo.Count > 0) Then
            If (buscarFormaPAgo(0).ID_TP_PAGO = 4 Or buscarFormaPAgo(0).ID_TP_PAGO = 5) Then
                qwerty = xcv.IRIS_WEBF_GRABA_TRX_BONOS(buscarFormaPAgo(0).ID_TP_PAGO, buscarFormaPAgo(0).T_PAGADO, CInt(S_Id_User))
            ElseIf (buscarFormaPAgo(0).ID_TP_PAGO = 1 Or buscarFormaPAgo(0).ID_TP_PAGO = 3 Or buscarFormaPAgo(0).ID_TP_PAGO = 7 Or buscarFormaPAgo(0).ID_TP_PAGO = 11) Then
                qwerty = xcv.IRIS_WEBF_GRABA_TRX_EFECTIVO(buscarFormaPAgo(0).ID_TP_PAGO, buscarFormaPAgo(0).T_PAGADO, CInt(S_Id_User))
            End If
        End If
        If (qwerty = 0) Then
            qwe = uuuu.IRIS_WEBF_GRABA_ATE_DET_DOCUMENTO_PAGO_SIN_TRX(correlativo_tp_pago, buscarFormaPAgo(0).ID_TP_PAGO, buscarFormaPAgo(0).T_PAGADO, CInt(S_Id_User), 0)
        Else
            qwe = uuuu.IRIS_WEBF_GRABA_ATE_DET_DOCUMENTO_PAGO_TRX(correlativo_tp_pago, buscarFormaPAgo(0).ID_TP_PAGO, buscarFormaPAgo(0).T_PAGADO, qwerty, CInt(S_Id_User), 0)
        End If
        Dim ahg As Integer
        Dim uu As New N_IRIS_WEBF_AGENDA_UPDATE_ESTADO_PREINGRESO
        'update despues de pago
        DATASSSSSS = NN_pac.IRIS_WEBF_UPDATE_OBS_INTERNO_ATENCION(id_atencion, interno, obs_TDM, obs)
        DATASSSSSS = NN_pac.IRIS_WEBF_UPDATE_OBS_INTERNO_PRE_INGRESO(id_pre, interno, obs_TDM, obs)
        ahg = uu.IRIS_WEBF_AGENDA_UPDATE_ESTADO_PREINGRESO(id_pre, id_atencion)
        Dim item As New E_IRIS_WEBF_correlativos
        Dim enviar As New List(Of E_IRIS_WEBF_correlativos)
        item.ID_ATENCION = id_atencion
        item.Correlativo = correlativo2
        enviar.Add(item)
        Return enviar
    End Function
    '<Services.WebMethod()>
    'Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal DESDE As String,
    '                                      ByVal ID_CF As Integer) As String
    '    'Declaraciones del Serializador
    '    'Dim Serializer As New JavaScriptSerializer
    '    Dim str_Builder As New StringBuilder
    '    Dim datas As String = ""
    '    Dim Str_Out As String = ""
    '    'Declaraciones internas
    '    Dim Data As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
    '    Dim NN As New N_PROCEDENCIAS_Y_CANT_MAX

    '    'creamos el objeto SLDocument el cual creara el excel
    '    Dim sl As SLDocument = New SLDocument
    '    Dim tabla As SLTable
    '    Dim estilo As SLStyle
    '    Dim estilo2 As SLStyle
    '    Dim estilo3 As SLStyle
    '    Dim Excel_x As Integer
    '    Dim Excel_y As Integer
    '    Excel_x = 1
    '    Excel_y = 9
    '    Dim ltabla As Integer = 0
    '    Dim Mx_Data(5, 0) As Object
    '    Data = NN.IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2(ID_CF, DESDE)
    '    If (Data.Count > 0) Then
    '        Dim Mx_Datac(6, 0) As Object
    '        'Vaciar Matriz
    '        ReDim Mx_Data(6, 0)
    '        For x = 0 To (Mx_Data.GetUpperBound(0))
    '            Mx_Data(x, 0) = Nothing
    '        Next x
    '        'Llenar Matriz
    '        For y = 0 To (Data.Count - 1)
    '            If (y > 0) Then
    '                ReDim Preserve Mx_Data(6, y)
    '            End If
    '            Mx_Data(0, y) = y + 1
    '            Mx_Data(1, y) = Data(y).PAC_NOMBRE + " " + Data(y).PAC_APELLIDO
    '            Mx_Data(2, y) = Data(y).PAC_RUT
    '            Mx_Data(3, y) = Data(y).PREI_NUM
    '            Mx_Data(4, y) = Data(y).PROC_DESC
    '            Mx_Data(5, y) = CInt(Data(y).CANT_EXAM)
    '            Mx_Data(6, y) = Data(y).EST_DESCRIPCION
    '        Next y
    '    Else
    '        Return "null"
    '    End If
    '    'nombrar hoja 
    '    sl.RenameWorksheet("Sheet1", "Listado de pacientes")
    '    'titulo de la tabla
    '    sl.SetCellValue("B2", "Listado de pacientes")
    '    For y = 1 To 9
    '        sl.SetColumnWidth(y, 20.0)
    '    Next y
    '    'nombre columnas
    '    sl.SetCellValue("A8", "#")
    '    sl.SetColumnWidth("A", 10)
    '    sl.SetCellValue("B8", "Nombre Paciente")
    '    sl.SetCellValue("C8", "Rut")
    '    sl.SetCellValue("D8", "N° Atención")
    '    sl.SetColumnWidth("D", 40)
    '    sl.SetCellValue("E8", "Procedencia")
    '    sl.SetCellValue("F8", "Cant. Exámenes")
    '    sl.SetCellValue("G8", "Estado")

    '    For y = 0 To Mx_Data.GetUpperBound(1)
    '        For x = 0 To Mx_Data.GetUpperBound(0)
    '            sl.SetCellValue(y + Excel_y, x + 1, Mx_Data(x, y))
    '        Next x
    '        ltabla += 1
    '    Next y
    '    ltabla += 8
    '    estilo = sl.CreateStyle()
    '    estilo.Font.FontName = "Arial"
    '    estilo.Font.FontSize = 20
    '    estilo.Font.Bold = True
    '    estilo2 = sl.CreateStyle()
    '    estilo2.Font.FontName = "Arial"
    '    estilo2.Font.FontSize = 14
    '    estilo2.Font.Bold = True
    '    estilo3 = sl.CreateStyle()
    '    estilo3.Font.FontName = "Arial"
    '    estilo3.Font.FontSize = 13
    '    estilo3.Font.Bold = True
    '    sl.SetCellStyle("B2", estilo)
    '    sl.SetCellStyle("B3", estilo2)
    '    sl.SetCellStyle("B4", estilo3)
    '    'insertar tabla
    '    tabla = sl.CreateTable("A8", CStr("G" & ltabla + 1))
    '    tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
    '    sl.InsertTable(tabla)
    '    Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
    '    Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
    '    sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
    '    'Devolver la url del archivo generado
    '    Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    'End Function
    <Services.WebMethod()>
    Public Shared Function Excel(DOMAIN_URL As String, ID_PROCEDENCIA As Integer, ID_PREVISION As Integer, desde As String, hasta As String, ESTADO As Integer) As String
        Dim data_pac = (New N_PROCEDENCIAS_Y_CANT_MAX).IRIS_WEBF_BUSCA_LIS_PAC_TDM_TRAER_POR_ESTADO(ID_PROCEDENCIA, ID_PREVISION, desde, hasta, ESTADO)

        Dim sl As SLDocument = New SLDocument

        Dim estilo As SLStyle
        Dim estilo2 As SLStyle

        Dim Excel_x = 1
        Dim Excel_y = 8

        If (data_pac.Count = 0) Then
            Return Nothing
        End If

        estilo = sl.CreateStyle()
        estilo.Font.FontName = "Arial"
        estilo.Font.FontSize = 20
        estilo.Font.Bold = True
        estilo2 = sl.CreateStyle()
        estilo2.Font.FontName = "Arial"
        estilo2.Font.FontSize = 14
        estilo2.Font.Bold = True

        sl.RenameWorksheet("Sheet1", "Listado de Pacientes")

        sl.SetCellValue("B2", "Listado de Pacientes")
        sl.SetCellStyle("B2", estilo)
        sl.SetCellValue("B3", desde + " hasta " + hasta)
        sl.SetCellStyle("B3", estilo2)


        Dim row = Excel_y
        Dim col = Excel_x

        sl.SetCellValue(row, col, "#") : col += 1
        sl.SetCellValue(row, col, "Nombre Paciente") : col += 1
        sl.SetCellValue(row, col, "Rut/DNI") : col += 1
        sl.SetCellValue(row, col, "N° Pre Ingreso") : col += 1
        sl.SetCellValue(row, col, "N° Atención") : col += 1
        sl.SetCellValue(row, col, "Fecha Agendamiento") : col += 1
        sl.SetCellValue(row, col, "Fecha Atencíón") : col += 1
        sl.SetCellValue(row, col, "Procedencia") : col += 1
        sl.SetCellValue(row, col, "Cant.Exa.") : col += 1
        sl.SetCellValue(row, col, "Estado") : col += 1


        For i = 0 To data_pac.Count - 1
            Dim ate = data_pac(i)
            row += 1
            col = Excel_x

            sl.SetCellValue(row, col, i + 1) : col += 1
            sl.SetCellValue(row, col, $"{ate.PAC_NOMBRE} {ate.PAC_APELLIDO}") : col += 1
            sl.SetCellValue(row, col, If(ate.PAC_RUT = "", ate.DNI, ate.PAC_RUT)) : col += 1
            sl.SetCellValue(row, col, ate.PREI_NUM) : col += 1
            sl.SetCellValue(row, col, If(ate.ATE_NUM_INT = 0, "", ate.ATE_NUM_INT)) : col += 1
            sl.SetCellValue(row, col, ate.PREI_FECHA_PRE_String) : col += 1
            sl.SetCellValue(row, col, ate.ATE_FECHA) : col += 1
            sl.SetCellValue(row, col, ate.PROC_DESC) : col += 1
            sl.SetCellValue(row, col, ate.CANT_EXAM) : col += 1
            sl.SetCellValue(row, col, ate.EST_DESCRIPCION)
        Next

        Dim tabla = sl.CreateTable(Excel_y, Excel_x, row, col)
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        sl.AutoFitColumn(Excel_x, col)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path)

        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function




    <Services.WebMethod()>
    Public Shared Function Excel_Absentismo(ID_PROCEDENCIA As Integer, ID_PREVISION As Integer, fecha As String, proc_desc As String, preve_desc As String) As String
        Dim data_pac = Datos.D_PROCEDENCIAS_Y_CANT_MAX.IRIS_WEB_AUSENTISMO(ID_PROCEDENCIA, ID_PREVISION, fecha)

        Dim sl As SLDocument = New SLDocument

        Dim estilo As SLStyle
        Dim estilo2 As SLStyle

        Dim Excel_x = 1
        Dim Excel_y = 5

        If (data_pac.Count = 0) Then
            Return Nothing
        End If

        estilo = sl.CreateStyle()
        estilo.Font.FontName = "Arial"
        estilo.Font.FontSize = 20
        estilo.Font.Bold = True
        estilo2 = sl.CreateStyle()
        estilo2.Font.FontName = "Arial"
        estilo2.Font.FontSize = 14
        estilo2.Font.Bold = True

        Dim fechaAsDateTime As DateTime = DateTime.ParseExact(fecha, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)

        sl.RenameWorksheet("Sheet1", "Listado de Ausentismo")

        sl.SetCellValue("A1", $"Procedencia: {proc_desc}")
        sl.SetCellStyle("A1", estilo)
        sl.SetCellValue("A2", $"Previsión: {preve_desc}")
        sl.SetCellStyle("A2", estilo)
        sl.SetCellValue("A3", $"Mes: {fechaAsDateTime.ToString("MMMM")}")
        sl.SetCellStyle("A3", estilo2)
        sl.MergeWorksheetCells(1, 1, 1, 12)
        sl.MergeWorksheetCells(2, 1, 2, 12)
        sl.MergeWorksheetCells(3, 1, 3, 12)

        Dim row = Excel_y
        Dim col = Excel_x

        For i = 0 To data_pac.Count - 1
            Dim item = data_pac(i)

            sl.SetCellValue(row, col, item.Descripcion) : row += 1

            For d = 1 To DateTime.DaysInMonth(fechaAsDateTime.Year, fechaAsDateTime.Month)
                sl.SetCellValue(row, col, item.GetType().GetProperty("d" & d).GetValue(item)) : row += 1
            Next

            col += 1
            row = Excel_y
        Next

        row = Excel_y
        col = Excel_x + 3
        sl.SetCellValue(row, col, "Ausentismo") : col += 1
        sl.SetCellValue(row, col, "Cantidad")

        row += 1

        Dim stPercent = sl.CreateStyle()
        stPercent.FormatCode = "0.00%"
        stPercent.Font.Bold = True
        For d = 1 To DateTime.DaysInMonth(fechaAsDateTime.Year, fechaAsDateTime.Month)
            col = Excel_x + 3

            Dim celdaAgendados = SLConvert.ToCellReference(row, 2)
            Dim celdaAtendidos = SLConvert.ToCellReference(row, 3)

            Dim agendado = sl.GetCellValueAsInt32(celdaAgendados)

            If agendado > 0 Then
                sl.SetCellStyle(row, col, stPercent)
                sl.SetCellValue(row, col, $"=1-{celdaAtendidos}/{celdaAgendados}") : col += 1
                sl.SetCellValue(row, col, $"={celdaAgendados}-{celdaAtendidos}")
            End If

            row += 1
        Next

        Dim tabla = sl.CreateTable(Excel_y, Excel_x, row - 1, col)
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        sl.AutoFitColumn(Excel_x, col)
        For i = Excel_x To col
            sl.SetColumnWidth(i, sl.GetColumnWidth(i) + 2)
        Next


        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path)

        Return HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority) + VirtualPathUtility.ToAbsolute("~/") & "/" & Replace(Relative_Path, "\", "/")
    End Function


    <Services.WebMethod()>
    Public Shared Function Excel_Con_Examenes(DOMAIN_URL As String, ID_PROCEDENCIA As Integer, ID_PREVISION As Integer, desde As String, hasta As String) As String
        Dim data_pac = (New N_PROCEDENCIAS_Y_CANT_MAX).IRIS_WEBF_BUSCA_LIS_PAC_TDM_CON_EXAMENES(ID_PROCEDENCIA, ID_PREVISION, desde, hasta)

        Dim sl As SLDocument = New SLDocument

        Dim estilo As SLStyle
        Dim estilo2 As SLStyle

        Dim Excel_x = 1
        Dim Excel_y = 8

        If (data_pac.Count = 0) Then
            Return Nothing
        End If

        estilo = sl.CreateStyle()
        estilo.Font.FontName = "Arial"
        estilo.Font.FontSize = 20
        estilo.Font.Bold = True
        estilo2 = sl.CreateStyle()
        estilo2.Font.FontName = "Arial"
        estilo2.Font.FontSize = 14
        estilo2.Font.Bold = True

        sl.RenameWorksheet("Sheet1", "Listado de Pacientes")

        sl.SetCellValue("B2", "Listado de Pacientes")
        sl.SetCellStyle("B2", estilo)
        sl.SetCellValue("B3", desde + " hasta " + hasta)
        sl.SetCellStyle("B3", estilo2)


        Dim row = Excel_y
        Dim col = Excel_x

        sl.SetCellValue(row, col, "#") : col += 1
        sl.SetCellValue(row, col, "Nombre Paciente") : col += 1
        sl.SetCellValue(row, col, "Rut/DNI") : col += 1
        sl.SetCellValue(row, col, "N° Pre Ingreso") : col += 1
        sl.SetCellValue(row, col, "N° Atención") : col += 1
        sl.SetCellValue(row, col, "Fecha Agendamiento") : col += 1
        sl.SetCellValue(row, col, "Fecha Atencíón") : col += 1
        sl.SetCellValue(row, col, "Procedencia") : col += 1
        sl.SetCellValue(row, col, "Cant.Exa.") : col += 1
        sl.SetCellValue(row, col, "Estado") : col += 1


        For i = 0 To data_pac.Count - 1
            Dim ate = data_pac(i)
            row += 1
            col = Excel_x

            sl.SetCellValue(row, col, i + 1) : col += 1
            sl.SetCellValue(row, col, $"{ate.PAC_NOMBRE} {ate.PAC_APELLIDO}") : col += 1
            sl.SetCellValue(row, col, If(ate.PAC_RUT = "", ate.DNI, ate.PAC_RUT)) : col += 1
            sl.SetCellValue(row, col, ate.PREI_NUM) : col += 1
            sl.SetCellValue(row, col, If(ate.ATE_NUM_INT = 0, "", ate.ATE_NUM_INT)) : col += 1
            sl.SetCellValue(row, col, ate.PREI_FECHA_PRE_String) : col += 1
            sl.SetCellValue(row, col, ate.ATE_FECHA) : col += 1
            sl.SetCellValue(row, col, ate.PROC_DESC) : col += 1
            sl.SetCellValue(row, col, ate.CF_DESC) : col += 1
            sl.SetCellValue(row, col, ate.EST_DESCRIPCION)
        Next

        Dim tabla = sl.CreateTable(Excel_y, Excel_x, row, col)
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        sl.AutoFitColumn(Excel_x, col)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path)

        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function

    '<Services.WebMethod()>
    'Public Shared Function AddExamenToPreingreso(ID_PREINGRESO As Integer, ID_USUARIO As Integer, examenesArray As List(Of ids3)) As Object
    '    For Each exa In examenesArray
    '        Dim test = (New N_IRIS_WEBF_GRABA_DETALLE_PREINGRESO).
    '            IRIS_WEBF_GRABA_DETALLE_PREINGRESO(ID_PREINGRESO, ID_USUARIO, exa.id_CF, exa.id_PER, 1, 0, exa.Valor, exa.Valor, 0, exa.Clinico)
    '    Next
    '    Return 1
    'End Function

    '<Services.WebMethod()>
    'Public Shared Function DeleteExamenfromPreingreso(ID_PREINGRESO As Integer, ID_USUARIO As Integer, ID_CODIGO_FONASA As Integer) As Object
    '    ' Crear una instancia de N_IRIS_WEBF_GRABA_DETALLE_PREINGRESO
    '    Dim detallePreingreso As New N_IRIS_WEBF_GRABA_DETALLE_PREINGRESO()

    '    ' Llamar al método compartido usando la instancia
    '    detallePreingreso.IRIS_WEB_ELIMINA_DETALLE_PREINGRESO(ID_PREINGRESO, ID_USUARIO, ID_CODIGO_FONASA)

    '    ' Devolver una respuesta
    '    Return 1
    'End Function


    <Services.WebMethod()>
    Public Shared Function AddExamenToPreingreso(ID_PREINGRESO As Integer, ID_USUARIO As Integer, examenesArray As List(Of ids3)) As Object
        For Each exa In examenesArray
            Dim test = (New N_IRIS_WEBF_GRABA_DETALLE_PREINGRESO).
                IRIS_WEBF_GRABA_DETALLE_PREINGRESO(ID_PREINGRESO, ID_USUARIO, exa.id_CF, exa.id_PER, 1, 0, exa.Valor, exa.Valor, 0, exa.Clinico)
        Next
        Return 1
    End Function

    <Services.WebMethod()>
    Public Shared Function DeleteExamenfromPreingreso(ID_PREINGRESO As Integer, ID_USUARIO As Integer, ID_CODIGO_FONASA As Integer) As Object

        Dim test = D_IRIS_WEB_ELIMINA_DETALLE_PREINGRESO.IRIS_WEB_ELIMINA_DETALLE_PREINGRESO(ID_PREINGRESO, ID_USUARIO, ID_CODIGO_FONASA)

        Return 1
    End Function


    Public Class ids3
        Dim E_id_CF As Integer
        Dim E_id_PER As Integer
        Dim E_Valor As Integer
        Dim E_Clinico As String


        Public Property Clinico As String
            Get
                Return E_Clinico
            End Get
            Set(ByVal value As String)
                E_Clinico = value
            End Set
        End Property
        Public Property Valor As Integer
            Get
                Return E_Valor
            End Get
            Set(ByVal value As Integer)
                E_Valor = value
            End Set
        End Property
        Public Property id_CF As Integer
            Get
                Return E_id_CF
            End Get
            Set(ByVal value As Integer)
                E_id_CF = value
            End Set
        End Property
        Public Property id_PER As Integer
            Get
                Return E_id_PER
            End Get
            Set(ByVal value As Integer)
                E_id_PER = value
            End Set
        End Property
    End Class

    '<Services.WebMethod()>
    'Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal ID As String, ByVal fecha As String) As String

    '    'Declaraciones del Serializador
    '    'Dim Serializer As New JavaScriptSerializer
    '    Dim str_Builder As New StringBuilder
    '    Dim datas As String = ""
    '    Dim Str_Out As String = ""
    '    'Declaraciones internas
    '    Dim data_pac As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
    '    Dim NN_pac As New N_PROCEDENCIAS_Y_CANT_MAX
    '    data_pac = NN_pac.IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2_BLOQUE_ID_ORDEN(ID, fecha)
    '    'creamos el objeto SLDocument el cual creara el excel
    '    Dim sl As SLDocument = New SLDocument
    '    Dim tabla As SLTable
    '    Dim estilo As SLStyle
    '    Dim estilo2 As SLStyle
    '    Dim estilo3 As SLStyle
    '    Dim Excel_x As Integer
    '    Dim Excel_y As Integer
    '    Excel_x = 1
    '    Excel_y = 9
    '    Dim ltabla As Integer = 0
    '    Dim Mx_Data(12, 0) As Object
    '    If (data_pac.Count > 0) Then
    '        'Vaciar Matriz
    '        ReDim Mx_Data(12, 0)
    '        For x = 0 To (Mx_Data.GetUpperBound(0))
    '            Mx_Data(x, 0) = Nothing
    '        Next x
    '        'Llenar Matriz
    '        For y = 0 To (data_pac.Count - 1)
    '            If (y > 0) Then
    '                ReDim Preserve Mx_Data(12, y)
    '            End If
    '            Dim colAct = 0
    '            Mx_Data(colAct, y) = y + 1 : colAct += 1
    '            Mx_Data(colAct, y) = data_pac(y).PREI_HORA : colAct += 1

    '            Mx_Data(colAct, y) = data_pac(y).ATE_FECHA : colAct += 1
    '            Mx_Data(colAct, y) = data_pac(y).ATE_FECHA_TM : colAct += 1

    '            If data_pac(y).ID_ORDEN = 1 Then
    '                Mx_Data(colAct, y) = "Normal"
    '            ElseIf data_pac(y).ID_ORDEN = 2 Then
    '                Mx_Data(colAct, y) = "Embarazada"
    '            ElseIf data_pac(y).ID_ORDEN = 3 Then
    '                Mx_Data(colAct, y) = "Adulto mayor"
    '            ElseIf data_pac(y).ID_ORDEN = 4 Then
    '                Mx_Data(colAct, y) = "Lactante"
    '            ElseIf data_pac(y).ID_ORDEN = 5 Then
    '                Mx_Data(colAct, y) = "Menor de edad"
    '            ElseIf data_pac(y).ID_ORDEN = 6 Then
    '                Mx_Data(colAct, y) = "Urgencia"
    '            ElseIf data_pac(y).ID_ORDEN = 7 Then
    '                Mx_Data(colAct, y) = "Carga de glucosa"
    '            ElseIf data_pac(y).ID_ORDEN = 8 Then
    '                Mx_Data(colAct, y) = "Postrado"
    '            ElseIf data_pac(y).ID_ORDEN = 9 Then
    '                Mx_Data(colAct, y) = "Insulino dependiente"
    '            ElseIf data_pac(y).ID_ORDEN = 10 Then
    '                Mx_Data(colAct, y) = "Mobilidad reducida"
    '            Else
    '                Mx_Data(colAct, y) = "Otro"
    '            End If
    '            colAct += 1
    '            Mx_Data(colAct, y) = data_pac(y).PAC_NOMBRE + " " + data_pac(y).PAC_APELLIDO : colAct += 1

    '            If (data_pac(y).PAC_RUT = "") Then
    '                Mx_Data(colAct, y) = data_pac(y).DNI
    '            Else
    '                Mx_Data(colAct, y) = data_pac(y).PAC_RUT
    '            End If
    '            colAct += 1

    '            Mx_Data(colAct, y) = data_pac(y).PREI_ANO & " Años" : colAct += 1
    '            Mx_Data(colAct, y) = data_pac(y).PREI_NUM : colAct += 1
    '            Mx_Data(colAct, y) = data_pac(y).ATE_NUM : colAct += 1
    '            Mx_Data(colAct, y) = data_pac(y).PROC_DESC : colAct += 1
    '            Mx_Data(colAct, y) = data_pac(y).CANT_EXAM : colAct += 1
    '            Mx_Data(colAct, y) = data_pac(y).EST_DESCRIPCION : colAct += 1
    '        Next y
    '    Else
    '        Return Nothing
    '    End If
    '    'nombrar hoja 
    '    sl.RenameWorksheet("Sheet1", "Listado de Pacientes")
    '    'titulo de la tabla
    '    sl.SetCellValue("B2", "Listado de Pacientes")
    '    sl.SetCellValue("B3", fecha)
    '    'nombre columnas
    '    Dim col = 1
    '    sl.SetCellValue(8, col, "#")
    '    sl.SetColumnWidth(col, 10) : col += 1
    '    sl.SetCellValue(8, col, "Bloque")
    '    sl.SetColumnWidth(col, 15) : col += 1
    '    sl.SetCellValue(8, col, "Hora Ingreso")
    '    sl.SetColumnWidth(col, 15) : col += 1
    '    sl.SetCellValue(8, col, "Hora TdeM")
    '    sl.SetColumnWidth(col, 15) : col += 1
    '    sl.SetCellValue(8, col, "Prioridad TM")
    '    sl.SetColumnWidth(col, 20) : col += 1
    '    sl.SetCellValue(8, col, "Nombre Paciente")
    '    sl.SetColumnWidth(col, 40) : col += 1
    '    sl.SetCellValue(8, col, "Rut o DNI")
    '    sl.SetColumnWidth(col, 20) : col += 1
    '    sl.SetCellValue(8, col, "Edad")
    '    sl.SetColumnWidth(col, 15) : col += 1
    '    sl.SetCellValue(8, col, "N° Pre Ingreso")
    '    sl.SetColumnWidth(col, 15) : col += 1
    '    sl.SetCellValue(8, col, "N° Atención")
    '    sl.SetColumnWidth(col, 15) : col += 1
    '    sl.SetCellValue(8, col, "Procedencia")
    '    sl.SetColumnWidth(col, 20) : col += 1
    '    sl.SetCellValue(8, col, "Cant. Exámenes")
    '    sl.SetColumnWidth(col, 10) : col += 1
    '    sl.SetCellValue(8, col, "Estado")
    '    sl.SetColumnWidth(col, 20) ' col se usa para ver hasta donde llega la tabla al final

    '    For y = 0 To Mx_Data.GetUpperBound(1)
    '        For x = 0 To Mx_Data.GetUpperBound(0)
    '            sl.SetCellValue(y + Excel_y, x + 1, Mx_Data(x, y))
    '        Next x
    '        ltabla += 1
    '    Next y
    '    ltabla += 8
    '    estilo = sl.CreateStyle()
    '    estilo.Font.FontName = "Arial"
    '    estilo.Font.FontSize = 20
    '    estilo.Font.Bold = True
    '    estilo2 = sl.CreateStyle()
    '    estilo2.Font.FontName = "Arial"
    '    estilo2.Font.FontSize = 14
    '    estilo2.Font.Bold = True
    '    estilo3 = sl.CreateStyle()
    '    estilo3.Font.FontName = "Arial"
    '    estilo3.Font.FontSize = 13
    '    estilo3.Font.Bold = True
    '    sl.SetCellStyle("B2", estilo)
    '    sl.SetCellStyle("B3", estilo2)
    '    sl.SetCellStyle("B4", estilo3)
    '    'insertar tabla
    '    tabla = sl.CreateTable("A8", CStr(Chr(64 + col) & ltabla + 1))
    '    tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
    '    sl.InsertTable(tabla)
    '    Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
    '    Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
    '    sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
    '    'Devolver la url del archivo generado
    '    Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    'End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable_Det_Ate(ID_ATE As String) As Object
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim Encrypt As New N_Encrypt
        Dim data_det_ate As List(Of E_IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_PACIENTE)
        Dim data_num As List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES)
        data_det_ate = (New N_IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_PACIENTE).IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_PACIENTE2_AGENDA(ID_ATE)
        If (data_det_ate.Count > 0) Then
            data_num = (New N_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES).IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES_AGENDA(data_det_ate(0).ID_ATENCION)
            data_det_ate(0).NUM_ATE = data_num(0).ATE_NUM
            For i = 0 To (data_det_ate.Count - 1)
                data_det_ate(i).ENCRYPTED_ID = Encrypt.Encode(ID_ATE)
            Next i
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_det_ate, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return data_det_ate
    End Function
    <Services.WebMethod()>
    Public Shared Function Busca_Cupos_Disponibles(fecha As String, id As String, id_bloque As Integer) As Object
        Return N_PROCEDENCIAS_Y_CANT_MAX.IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA_NEW_COMNE_PTGO_disponible(fecha, id_bloque, id)
    End Function

    <Services.WebMethod()>
    Public Shared Function Cambia_Hora_Agenda(idAgendamiento As Integer, fecha As String, idProcedencia As String, id_bloque As Integer, SUB_GRUPO_ATE As Integer) As Object
        Return N_PROCEDENCIAS_Y_CANT_MAX.IRIS_WEBF_UPDATE_HORA_AGENDAMIENTO(idAgendamiento, fecha, id_bloque, idProcedencia, SUB_GRUPO_ATE)
    End Function




End Class





Public Class REEE
    Dim arr1 As List(Of E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2)
    Dim arr2 As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL)
    Dim arr3 As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION)
    Public Property proparra3 As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION)
        Get
            Return arr3
        End Get
        Set(ByVal value As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION))
            arr3 = value
        End Set
    End Property
    Public Property proparra1 As List(Of E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2)
        Get
            Return arr1
        End Get
        Set(ByVal value As List(Of E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2))
            arr1 = value
        End Set
    End Property
    Public Property proparra2 As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL)
        Get
            Return arr2
        End Get
        Set(ByVal value As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL))
            arr2 = value
        End Set
    End Property
End Class
Public Class E_IRIS_WEBF_correlativos
    Dim EE_ID_ATENCION As Integer
    Dim EE_Correlativo As Integer
    Public Property ID_ATENCION As Integer
        Get
            Return EE_ID_ATENCION
        End Get
        Set(value As Integer)
            EE_ID_ATENCION = value
        End Set
    End Property
    Public Property Correlativo As Integer
        Get
            Return EE_Correlativo
        End Get
        Set(value As Integer)
            EE_Correlativo = value
        End Set
    End Property
End Class