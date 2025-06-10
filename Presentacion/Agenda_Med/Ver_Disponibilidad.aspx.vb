Imports Negocio
Imports Entidades
Imports System.Web
Imports System.Web.Script.Serialization
'Imports SpreadsheetLight
'Imports SpreadsheetLight.Charts
Public Class Ver_Disponibilidad
    Inherits System.Web.UI.Page

    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If

        Select Case (C_P_ADMIN.Value)
            Case 2
                Response.Redirect("~/Index.aspx")
        End Select

    End Sub
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal fecha As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_procedencia As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX)
        Dim NN_Procedencia As New N_PROCEDENCIAS_Y_CANT_MAX
        data_procedencia = NN_Procedencia.IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX(fecha)
        If data_procedencia.Count > 0 Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_procedencia, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_PAC(ByVal ID As String, ByVal fecha As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_pac As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        Dim NN_pac As New N_PROCEDENCIAS_Y_CANT_MAX
        data_pac = NN_pac.IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2(ID, fecha)
        If data_pac.Count > 0 Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_pac, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function examenes(ByVal ID As String, ByVal fecha As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_pac As List(Of E_IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA)
        Dim NN_pac As New N_PROCEDENCIAS_Y_CANT_MAX
        data_pac = NN_pac.IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA(ID, fecha)
        If data_pac.Count > 0 Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_pac, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function MODAL_PAC(ByVal ID As String) As String
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
        data_examen = NN_Examen.IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL(ID)
        data_atencion = NN_atencion.IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION(ID)
        Dim reeeeeee As New REEE
        reeeeeee.proparra1 = data_pac
        reeeeeee.proparra2 = data_examen
        reeeeeee.proparra3 = data_atencion
        'Declaraciones internas
        If data_pac.Count > 0 Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(reeeeeee, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function grabar_atencion(ByVal PREINGRESO As String, ByVal NUM As String, ByVal ID_PACIENTE As String) As String
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
        Dim correlativo As Integer
        Dim id_atencion As Integer
        Dim dd As New N_IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS
        Dim cc As New N_IRIS_WEBF_BUSCA_CORRELATIVO_ATENCION
        Dim id As Integer
        Dim jj As New N_IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_AVIS
        Dim resu As Integer
        Dim resuresu As New N_IRIS_WEBF_GRABA_RESULTADO_ATENCION
        Dim PERFIL_PRUEBA As List(Of E_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION)
        Dim hh As New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
        Dim Str_Out As String = ""
        data_pac = NN_pac.IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2(PREINGRESO)
        data_examen = NN_Examen.IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL(PREINGRESO)
        data_atencion = NN_atencion.IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION(PREINGRESO)
        correlativo = cc.IRIS_WEBF_BUSCA_CORRELATIVO_ATENCION()
        id_atencion = dd.IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS(correlativo,
                                                                          ID_PACIENTE,
                                                                          1,
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
                                                                          data_examen(0).PREI_DET_V_PAGADO,
                                                                          data_examen(0).PREI_DET_V_PREVI,
                                                                          data_examen(0).PREI_DET_V_COPAGO,
                                                                          data_atencion(0).ID_PROGRAMA,
                                                                          "",
                                                                          data_atencion(0).ID_SECTOR,
                                                                         correlativo, 789,
                                                                           data_atencion(0).ID_DIAGNOSTICO, data_atencion(0).ID_DIAGNOSTICO2, data_atencion(0).VIH, data_pac(0).DNI, "", 1, "", "", "", data_atencion(0).EMPRESA, data_atencion(0).ID_GRUPO_PESQUISA)

        For i = 0 To data_examen.Count - 1
            id = jj.IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_AVIS(id_atencion,
                                                                   1,
                                                                   data_examen(i).ID_CODIGO_FONASA,
                                                                   data_examen(i).ID_PER,
                                                                   data_examen(i).ID_TP_PAGO,
                                                                   data_examen(i).PREI_DET_DOC,
                                                                   data_examen(i).PREI_DET_V_PREVI,
                                                                   data_examen(i).PREI_DET_V_PAGADO,
                                                                   data_examen(i).PREI_DET_V_COPAGO,
                                                                   correlativo, "")
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
        graba_ate = tt.IRIS_GRABA_ATE_DOCUMENTO_PAGO(id_atencion, correlativo_tp_pago, 1)
        buscarFormaPAgo = ee.IRIS_WEBF_BUSCA_ATE_FORMA_PAGO_SUMA_TOTALES(id_atencion)
        If (buscarFormaPAgo.Count > 0) Then
            If (buscarFormaPAgo(0).ID_TP_PAGO = 4 Or buscarFormaPAgo(0).ID_TP_PAGO = 5) Then
                qwerty = xcv.IRIS_WEBF_GRABA_TRX_BONOS(buscarFormaPAgo(0).ID_TP_PAGO, buscarFormaPAgo(0).T_PAGADO, 1)
            ElseIf (buscarFormaPAgo(0).ID_TP_PAGO = 1 Or buscarFormaPAgo(0).ID_TP_PAGO = 3 Or buscarFormaPAgo(0).ID_TP_PAGO = 7 Or buscarFormaPAgo(0).ID_TP_PAGO = 11) Then
                qwerty = xcv.IRIS_WEBF_GRABA_TRX_EFECTIVO(buscarFormaPAgo(0).ID_TP_PAGO, buscarFormaPAgo(0).T_PAGADO, 1)
            End If
        End If
        If (qwerty = 0) Then
            qwe = uuuu.IRIS_WEBF_GRABA_ATE_DET_DOCUMENTO_PAGO_SIN_TRX(correlativo_tp_pago, buscarFormaPAgo(0).ID_TP_PAGO, buscarFormaPAgo(0).T_PAGADO, 1, 0)
        Else
            qwe = uuuu.IRIS_WEBF_GRABA_ATE_DET_DOCUMENTO_PAGO_TRX(correlativo_tp_pago, buscarFormaPAgo(0).ID_TP_PAGO, buscarFormaPAgo(0).T_PAGADO, qwerty, 1, 0)
        End If
        Dim ahg As Integer
        Dim uu As New N_IRIS_WEBF_AGENDA_UPDATE_ESTADO_PREINGRESO
        'update despues de pago
        ahg = uu.IRIS_WEBF_AGENDA_UPDATE_ESTADO_PREINGRESO(PREINGRESO, id_atencion)


        Str_Out += "{"
        Str_Out += Chr(34) & "ID_Atencion" & Chr(34) & ": " & Chr(34) & id_atencion & Chr(34) & ", "
        Str_Out += Chr(34) & "Correlativo" & Chr(34) & ": " & Chr(34) & correlativo & Chr(34)
        Str_Out += "}"
        Return Str_Out
        Return datas
    End Function
    Private Class REEE
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
End Class