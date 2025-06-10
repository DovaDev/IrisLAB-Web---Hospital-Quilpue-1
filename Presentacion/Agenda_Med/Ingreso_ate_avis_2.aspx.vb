Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Ingreso_ate_avis_2
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
    Public Shared Function MODAL_PAC(ByVal ID As String) As REEE


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
        Return reeeeeee
    End Function
    <Services.WebMethod()>
    Public Shared Function crearDoc(ByVal AVIS As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_LugarTM As New N_Ingreso_Ate_Avis
        Dim Data_LugarTM As New Integer
        Data_LugarTM = NN_LugarTM.IRIS_WEBF_AGREGAR_MEDICOS_CON_AVIS(AVIS)
        If (Data_LugarTM > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_LugarTM, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Guardar_TodoByVal(ByVal RUT_PAC As String,
                                                ByVal HO_CC As String,
                                                ByVal FUR As String,
                                                ByVal Paridad As String,
                                                ByVal ID_PAC As String,
                                                ByVal OB As String,
                                                ByVal Procedencia As Integer,
                                                ByVal Programa As Integer,
                                                ByVal Sector As Integer,
                                                ByVal TipoAtencion As Integer,
                                                ByVal PrioridadTM As Integer,
                                                ByVal Doctor As Integer,
                                                ByVal Prevision As Integer,
                                                ByVal EDAD As Integer,
                                                ByVal MES As Integer,
                                                ByVal DIA As Integer,
                                                ByVal TOTAL As Integer,
                                                ByVal FECHA_PRE As String,
                                                ByVal ids As List(Of ids_7),
                                                ByVal ATE_SAYDEX As String,
                                                ByVal DIAG1 As Integer,
                                                ByVal DIAG2 As Integer,
                                                ByVal interno As String,
                                                ByVal sub_atencion As String,
                                                ByVal vih As String,
                                                ByVal NOMBRE_PAC As String,
                                                ByVal APE_PAC As String,
                                                ByVal FNAC_PAC As String,
                                                ByVal ID_SEXO As Integer,
                                                ByVal ID_NACIONALIDAD As Integer,
                                                ByVal FONO1 As String,
                                                ByVal MOVIL1 As String,
                                                ByVal ID_CIU_COM As Integer,
                                                ByVal DIR_PAC As String,
                                                ByVal EMAIL_PAC As String,
                                                ByVal id_ate As String,
                                                ByVal NEW_VIH As String,
                                                ByVal S_Id_User As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Dim correlativo As Integer
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Dim S_Id_User As String = CType(objSession("ID_USER"), String)
        'paciente
        Test_C.Check_C()
        'Dim Rpaciente As Integer
        'Dim examun As Integer
        Dim Str_Out As String = ""
        ' Dim PREINGRESO2 As Integer
        Dim PREINGRESO2_PRO_SEC As Integer = 0
        Dim DATASSSSSS As Integer
        Dim nn As N_IRIS_WEBF_GRABA_PACIENTE_ATENCION = New N_IRIS_WEBF_GRABA_PACIENTE_ATENCION
        Dim vv As N_IRIS_WEBF_UPDATE_PACIENTE_ATENCION = New N_IRIS_WEBF_UPDATE_PACIENTE_ATENCION
        Dim dd As N_IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO = New N_IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO
        Dim zz As N_IRIS_WEBF_HOST_UPDATE_CARGA_AVIS_FOLIO = New N_IRIS_WEBF_HOST_UPDATE_CARGA_AVIS_FOLIO
        Dim cc As N_IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC = New N_IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC
        Dim exex As N_IRIS_WEBF_GRABA_DETALLE_PREINGRESO = New N_IRIS_WEBF_GRABA_DETALLE_PREINGRESO
        Dim RUT_USUARIO_VB_2 As String
        'Dim data_paciente2222 As List(Of E_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT)
        Dim NNv As N_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT = New N_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT
        RUT_USUARIO_VB_2 = Replace(RUT_PAC, ".", "")
        'fecha fur
        If (FUR = "") Then
            FUR = "01/01/1900"
        End If
        If (ids.Count = 0) Then
            Str_Out = Nothing
            Return Str_Out
        Else
            If (Paridad = 1) Then
                For x = 0 To ids.Count - 1
                    zz.IRIS_WEBF_HOST_UPDATE_CARGA_AVIS_FOLIO(ids(x).HO_CC, id_ate)
                Next x

                'Else
                'zz.IRIS_WEBF_HOST_UPDATE_CARGA_AVIS(RUT_USUARIO_VB_2, id_ate)
            End If

            'Dim data_examen2 As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL)
            'Dim NN_Examen2 As New N_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL

            'Dim NN_Date As New N_Date_Operat
            'Dim fecha As String = FECHA_PRE.Replace("/", "-")
            'Dim DIA1 As String = fecha.Split("-")(0)
            'Dim MES2 As String = fecha.Split("-")(1)
            'Dim AÑO3 As String = fecha.Split("-")(2)
            'Dim Date_01 As Date = NN_Date.strToDate(AÑO3, MES2, DIA1)
            'Dim Date_02 As Date = NN_Date.strToDate(AÑO3, MES2, DIA1)

            ''Date_01 = Date_01.Replace("/", "-")
            ''Date_02 = Date_02.Replace("/", "-")

            ''ver si tiene otros exames......
            'data_examen2 = NN_Examen2.IRIS_WEBF_BUSCA_EXAMEN(Date_02, Date_01, RUT_PAC)

            ''If (data_examen2.Count > 0) Then


            ''    For i = 0 To ids.Count - 1
            ''        Dim reee As Boolean = True
            ''        For x = 0 To data_examen2.Count - 1
            ''            If (data_examen2(x).ID_CODIGO_FONASA = ids(i).id_CF) Then
            ''                reee = False
            ''                Exit For
            ''            End If
            ''        Next x
            ''        If (reee = True) Then
            ''            examun = exex.IRIS_WEBF_GRABA_DETALLE_PREINGRESO(PREINGRESO2_PRO_SEC, CInt(S_Id_User), ids(i).id_CF, ids(i).id_PER, 1, 0, ids(i).Valor, ids(i).Valor, 0)
            ''        End If
            ''    Next i

            ''Else
            'For i = 0 To ids.Count - 1
            '    examun = exex.IRIS_WEBF_GRABA_DETALLE_PREINGRESO(PREINGRESO2_PRO_SEC, CInt(S_Id_User), ids(i).id_CF, ids(i).id_PER, 1, 0, ids(i).Valor, ids(i).Valor, 0, ids(i).HO_CC)
            'Next i
            'End If


            '.................................
            Dim hocc As String = ""

            If (HO_CC = "" Or HO_CC = "0") Then
                For b = 0 To ids.Count - 1
                    If (IsNumeric(ids(b).HO_CC) = True) Then
                        hocc = ids(b).HO_CC
                    Else
                        hocc = ""
                    End If
                Next b
            Else
                hocc = HO_CC
            End If

            Dim data_pac As List(Of E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2)
            Dim NN_pac As New N_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2
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
            data_pac = NN_pac.IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2(id_ate)
            data_examen = NN_Examen.IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL(id_ate)
            data_atencion = NN_atencion.IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION(id_ate)
            correlativo2 = ccx.IRIS_WEBF_BUSCA_CORRELATIVO_ATENCION()
            id_atencion = ddx.IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS_3_NEW_VIH_NEW(correlativo2,
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
                                                                                            ids(0).Valor,
                                                                                            ids(0).Valor,
                                                                                            0,
                                                                                            data_atencion(0).ID_PROGRAMA,
                                                                                            "",
                                                                                            data_atencion(0).ID_SECTOR,
                                                                                            hocc,
                                                                                            interno,
                                                                                            data_atencion(0).ID_DIAGNOSTICO,
                                                                                            data_atencion(0).ID_DIAGNOSTICO2,
                                                                                            vih,'data_atencion(0).VIH,
                                                                                            data_pac(0).DNI,
                                                                                            OB,
                                                                                            NEW_VIH)

            For i = 0 To ids.Count - 1
                id = jj.IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_AVIS(id_atencion,
                                                                   CInt(S_Id_User),
                                                                   ids(i).id_CF,
                                                                   ids(i).id_PER,
                                                                   1,
                                                                   0,
                                                                   ids(i).Valor,
                                                                   ids(i).Valor,
                                                                   0,
                                                                    ids(i).HO_CC, "")

                PERFIL_PRUEBA = hh.IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION(ids(i).id_PER)

                For x = 0 To PERFIL_PRUEBA.Count - 1
                    If (PERFIL_PRUEBA(x).PRU_RESU_INMEDIATO_REAL = Nothing) Then
                        resu = resuresu.IRIS_WEBF_GRABA_RESULTADO_ATENCION(id_atencion, ids(i).id_CF, ids(i).id_PER, PERFIL_PRUEBA(x).ID_PRUEBA, id)
                    Else
                        If (PERFIL_PRUEBA(x).ID_TP_RESULTADO = 1) Then
                            resu = resuresu.IRIS_WEBF_GRABA_RESULTADO_ATENCION_DEFECTO(id_atencion, ids(i).id_CF, ids(i).id_PER, PERFIL_PRUEBA(x).ID_PRUEBA, PERFIL_PRUEBA(x).PRU_RESU_INMEDIATO_REAL, id)
                        Else
                            resu = resuresu.IRIS_WEBF_GRABA_RESULTADO_ATENCION(id_atencion, ids(i).id_CF, ids(i).id_PER, PERFIL_PRUEBA(x).ID_PRUEBA, id)
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
            ahg = uu.IRIS_WEBF_AGENDA_UPDATE_ESTADO_PREINGRESO(id_ate, id_atencion)
            DATASSSSSS = NN_pac.IRIS_WEBF_UPDATE_OBS_INTERNO_PRE_INGRESO(id_ate, interno, OB, "N° Orden Clínica: " + hocc)


            DATASSSSSS = NN_pac.IRIS_WEBF_UPDATE_OBS_INTERNO_ATENCION(id_atencion, interno, OB, "N° Orden Clínica: " + hocc)
            'DATASSSSSS = NN_pac.IRIS_WEBF_UPDATE_OBS_INTERNO_PRE_INGRESO(id_ate, interno, OB, "" + ids(0).HO_CC)



            Dim NN_ExamenDet As New N_Exa_Esp_V
            Dim DataExamenDet As Integer
            Dim exa_avis As Integer

            Dim NN_ExamenDet_2 As New N_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR
            Dim DataExamenDet_2 As New List(Of E_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR)




            DataExamenDet_2 = NN_ExamenDet_2.IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR_2(correlativo2)





            For i = 0 To ids.Count - 1
                If (ids(i).CF_ESTADO_EXAMEN = "Espera") Then
                    DataExamenDet = NN_ExamenDet.IRIS_WEBF_UPDATE_ESTADO_EXAMEN(id_atencion, ids(i).id_CF)

                    If (IsNothing(ids(i).HO_CC) = False Or ids(i).HO_CC <> 0) Then
                        For ss = 0 To DataExamenDet_2.Count - 1
                            If (DataExamenDet_2(ss).ID_CODIGO_FONASA = ids(i).id_CF) Then
                                exa_avis = NN_ExamenDet.IRIS_WEBF_UPDATE_ESTADO_EXAMEN_INTEGRACION_AVIS(ids(i).HO_CC, DataExamenDet_2(ss).CF_AVIS)
                            End If
                        Next ss
                    End If
                End If
            Next i









            Str_Out += "{"
            Str_Out += Chr(34) & "ID_Atencion" & Chr(34) & ": " & Chr(34) & id_atencion & Chr(34) & ", "
            Str_Out += Chr(34) & "Correlativo" & Chr(34) & ": " & Chr(34) & correlativo2 & Chr(34)
            Str_Out += "}"
            Return Str_Out
            Return datas
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_tabla_exam2_global() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION)
        Dim NN As N_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION = New N_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION

        data_paciente = NN.IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION_22()
        If (data_paciente.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_paciente, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_tabla_exam2(ByVal ID_PREVE As Integer, ByVal Fecha As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION)
        Dim NN As N_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION = New N_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION
        Dim ANO As Date
        ANO = CDate(Fecha)
        data_paciente = NN.IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION(Format(ANO, "yyyy"), ID_PREVE)
        If (data_paciente.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_paciente, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
End Class
Public Class ids_7
    Dim E_id_CF As Integer
    Dim E_id_PER As Integer
    Dim E_Valor As Integer
    Dim E_HO_CC As String
    Dim E_CF_ESTADO_EXAMEN As String

    Public Property CF_ESTADO_EXAMEN As String
        Get
            Return E_CF_ESTADO_EXAMEN
        End Get
        Set(ByVal value As String)
            E_CF_ESTADO_EXAMEN = value
        End Set
    End Property
    Public Property HO_CC As Integer
        Get
            Return E_HO_CC
        End Get
        Set(ByVal value As Integer)
            E_HO_CC = value
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
