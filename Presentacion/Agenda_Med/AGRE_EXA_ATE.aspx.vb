Imports Entidades
Imports Negocio
Imports System
Imports System.Collections.Generic
Imports System.Runtime.Remoting
Imports System.Text
Imports System.Web
Imports System.Web.Script.Serialization
Public Class AGRE_EXA_ATE
    Inherits System.Web.UI.Page


    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If
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

        Dim reeeeeee As New REEE

        data_pac = NN_pac.IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES_2_NEW(ID)

        If data_pac.Count > 0 Then
            data_examen = NN_Examen.IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL_3_NEW(ID)
            data_atencion = NN_atencion.IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION_2_NEW(ID)

            reeeeeee.proparra1 = data_pac
            reeeeeee.proparra2 = data_examen
            reeeeeee.proparra3 = data_atencion

        End If



        'Declaraciones internas
        Return reeeeeee
    End Function
    <Services.WebMethod()>
    Public Shared Function MODAL_PAC_RUT(ByVal ID As String) As REEE


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

        Dim reeeeeee As New REEE

        data_pac = NN_pac.IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES_2_POR_RUT_NEW(ID)

        If data_pac.Count > 0 Then
            data_examen = NN_Examen.IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL_3_POR_RUT_NEW(data_pac(0).ID_PREINGRESO)
            data_atencion = NN_atencion.IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION_2_POR_RUT_NEW(data_pac(0).ID_PREINGRESO)

            reeeeeee.proparra1 = data_pac
            reeeeeee.proparra2 = data_examen
            reeeeeee.proparra3 = data_atencion

        End If



        'Declaraciones internas
        Return reeeeeee
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_examenes_paciente(ByVal examenes As List(Of examens_avis)) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_HOST_BUSCA_CODIGO_FONSA_POR_COD_AVIS)
        Dim NN As N_IRIS_WEBF_HOST_BUSCA_CODIGO_FONSA_POR_COD_AVIS = New N_IRIS_WEBF_HOST_BUSCA_CODIGO_FONSA_POR_COD_AVIS
        Dim examenes_back As New List(Of E_IRIS_WEBF_HOST_BUSCA_CODIGO_FONSA_POR_COD_AVIS)
        For x = 0 To examenes.Count - 1
            data_paciente = NN.IRIS_WEBF_HOST_BUSCA_CODIGO_FONSA_POR_COD_AVIS_PER(examenes(x).examen)

            If (data_paciente.Count > 0) Then
                Dim Item_Exam As New E_IRIS_WEBF_HOST_BUSCA_CODIGO_FONSA_POR_COD_AVIS
                Item_Exam.ID_CODIGO_FONASA = data_paciente(0).ID_CODIGO_FONASA
                Item_Exam.CF_COD = data_paciente(0).CF_COD
                Item_Exam.CF_DESC = data_paciente(0).CF_DESC
                Item_Exam.ID_ESTADO = data_paciente(0).ID_ESTADO
                Item_Exam.CF_AVIS = data_paciente(0).CF_AVIS
                Item_Exam.HO_CC = examenes(x).HO_CC
                Item_Exam.CODIGO_TEST = examenes(x).examen
                Item_Exam.ID_PER = data_paciente(0).ID_PER
                examenes_back.Add(Item_Exam)
            End If
        Next x
        If (examenes_back.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(examenes_back, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function MODAL_PAC_DNI(ByVal ID As String) As REEE


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

        Dim reeeeeee As New REEE

        data_pac = NN_pac.IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES_2_POR_DNI_NEW(ID)

        If data_pac.Count > 0 Then
            data_examen = NN_Examen.IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL_3_POR_DNI_NEW(data_pac(0).ID_PREINGRESO)
            data_atencion = NN_atencion.IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION_2_POR_DNI_NEW(ID)

            reeeeeee.proparra1 = data_pac
            reeeeeee.proparra2 = data_examen
            reeeeeee.proparra3 = data_atencion
        End If


        'Declaraciones internas
        Return reeeeeee
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal fecha As String, ByVal id As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_procedencia As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX)
        Dim NN_Procedencia As New N_PROCEDENCIAS_Y_CANT_MAX

        data_procedencia = NN_Procedencia.IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX(Date.Now, id)
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
    Public Shared Function Guardar_TodoByVal(ByVal ids As List(Of ids555), ByVal ID_ATENCION As String) As String
        'Checar Galletas
        If (Test_C.emptyCookies = True) Then
            HttpContext.Current.Response.Redirect("~index.aspx", False)
            Return Nothing
        End If

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Dim data_pac As List(Of E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2)
        Dim NN_pac As New N_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2
        'Dim data_examen As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL)
        Dim NN_Examen As New N_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL
        'Dim data_atencion As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION)
        Dim NN_atencion As New N_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION
        Dim correlativo2 As Integer
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim S_Id_User As String = CType(objSession("ID_USER"), String)
        Dim ddx As New N_IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS
        Dim ccx As New N_IRIS_WEBF_BUSCA_CORRELATIVO_ATENCION
        Dim id As Integer
        Dim jj As New N_IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_AVIS
        Dim resu As Integer
        Dim resuresu As New N_IRIS_WEBF_GRABA_RESULTADO_ATENCION
        Dim PERFIL_PRUEBA As List(Of E_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION)
        Dim hh As New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
        '----------------------------------------------------------------------------------------------------------
        Dim ddx3 As New N_IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS
        Dim busca_ho_cc As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL)
        Dim NN_busca_ho_cc As New N_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL
        Dim data_money_old As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
        Dim update_exam_inte As Integer = 0



        Dim VALOR_PREVI As Integer = 0
        Dim VALOR_BENEFI As Integer = 0
        Dim VALOR_SC As Integer = 0
        Dim VALOR_PAGADO As Integer = 0
        Dim VALOR_CF As Integer = 0
        Dim VALOR_CP As Integer = 0

        Dim COPAGO_REL As Integer = 0
        Dim PARTICULAR_REL As Integer = 0

        '----------------------------------------------------------------------------------------------------------
        data_money_old = ddx3.IRIS_WEBF_CMVM_BUSCA_ATENCION_PROGRA2_PRO_SECTOR_AVIS_3_NEW_CAJA_MAS_SC_CHANGE_TP_PAGO(ID_ATENCION)

        Dim Str_Out As String = ""
        If (ids.Count = 0) Then
            Str_Out = Nothing
            Return Str_Out
        End If
        For i = 0 To ids.Count - 1

            '---------------------------------------------------------------------------------------------------------


            ' este guarda log del examen que se agrega
            id = jj.IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_AVIS_3(ID_ATENCION,
                                                                        CInt(S_Id_User),
                                                                        ids(i).id_CF,
                                                                        ids(i).id_PER,
                                                                        1,
                                                                        0,
                                                                        ids(i).Valor,
                                                                        ids(i).Valor,
                                                                        0,
                                                                        ids(i).HO_CC,
                                                                        ids(i).CF_MULTIPLICADOS,
                                                                        ids(i).CODIGO_TEST)

            'Dim ddx6 As New N_IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS
            'ddx6.IRIS_WEBF_GRABA_HISTORIA_ATENCION_AGREGA_QUITA(ID_ATENCION,
            '                     ids(i).id_CF,
            '                     data_money_old(0).ATE_TOTAL,
            '                     data_money_old(0).ATE_V_CF,
            '                     data_money_old(0).ATE_TOTAL_PREVI,
            '                     VALOR_PREVI,
            '                     VALOR_CF,
            '                     VALOR_PAGADO,
            '                     VALOR_PREVI,
            '                     1,
            '                     S_Id_User,
            '                     id)

            PERFIL_PRUEBA = hh.IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION(ids(i).id_PER)



            For x = 0 To PERFIL_PRUEBA.Count - 1
                If (PERFIL_PRUEBA(x).PRU_RESU_INMEDIATO_REAL = Nothing) Then
                    resu = resuresu.IRIS_WEBF_GRABA_RESULTADO_ATENCION(ID_ATENCION, ids(i).id_CF, ids(i).id_PER, PERFIL_PRUEBA(x).ID_PRUEBA, id)
                Else
                    If (PERFIL_PRUEBA(x).ID_TP_RESULTADO = 1) Then
                        resu = resuresu.IRIS_WEBF_GRABA_RESULTADO_ATENCION_DEFECTO(ID_ATENCION, ids(i).id_CF, ids(i).id_PER, PERFIL_PRUEBA(x).ID_PRUEBA, PERFIL_PRUEBA(x).PRU_RESU_INMEDIATO_REAL, id)
                    Else
                        resu = resuresu.IRIS_WEBF_GRABA_RESULTADO_ATENCION(ID_ATENCION, ids(i).id_CF, ids(i).id_PER, PERFIL_PRUEBA(x).ID_PRUEBA, id)
                    End If
                End If
            Next x
        Next i

        Dim NN_ExamenDet As New N_Exa_Esp_V
        Dim DataExamenDet As Integer
        Dim exa_avis As Integer

        For i = 0 To ids.Count - 1
            If (ids(i).CF_ESTADO_EXAMEN = "Espera") Then
                DataExamenDet = NN_ExamenDet.IRIS_WEBF_UPDATE_ESTADO_EXAMEN(ID_ATENCION, ids(i).id_CF)

                'If (IsNothing(ids(i).HO_CC) = False Or ids(i).HO_CC <> 0) Then
                '    exa_avis = NN_ExamenDet.IRIS_WEBF_UPDATE_ESTADO_EXAMEN_INTEGRACION_AVIS(ids(i).HO_CC, ids(i).id_CF)          '<------------  'OJO AQUI !!!!
                'End If
            End If

        Next i

        'Dim numero As Integer
        'Dim N_N As N_IRIS_OBTENER_INFO = New N_IRIS_OBTENER_INFO

        'For i = 0 To ids.Count - 1
        '    If ((ids(i).HO_CC = 0) And (IsNothing(ids(i).CODIGO_TEST) = True)) Then
        '        Continue For
        '    End If

        '    If (ids(i).CF_ESTADO_EXAMEN <> "Espera") Then
        '        numero = N_N.UPDATE_ESTADO_TEST(ids(i).HO_CC, ids(i).CODIGO_TEST)
        '    End If

        'Next i

        'For x = 0 To ids.Count - 1
        '    If ((ids(x).HO_CC = 0) And (IsNothing(ids(x).CODIGO_TEST) = True)) Then
        '        Continue For
        '    End If

        '    If (ids(x).CF_MULTIPLICADOS <> "" And ids(x).CF_ESTADO_EXAMEN <> "Espera") Then
        '        Dim regex As New Regex("[0-9]+", RegexOptions.ECMAScript And RegexOptions.IgnoreCase)
        '        Dim match9000 As MatchCollection
        '        Dim list_Num As New List(Of String)

        '        match9000 = regex.Matches(ids(x).CF_MULTIPLICADOS)
        '        For y = 0 To (match9000.Count - 1)
        '            If (match9000(y).Success = True) Then
        '                numero = N_N.UPDATE_ESTADO_TEST(match9000(y).Value, ids(x).CODIGO_TEST)
        '            End If
        '        Next y
        '    End If
        'Next x







        Str_Out += "{"
        Str_Out += Chr(34) & "ID_Atencion" & Chr(34) & ": " & Chr(34) & ID_ATENCION & Chr(34) & ", "
        Str_Out += Chr(34) & "Correlativo" & Chr(34) & ": " & Chr(34) & correlativo2 & Chr(34)
        Str_Out += "}"
        Return Str_Out


    End Function


    <Services.WebMethod()>
    Public Shared Function Eliminar_Examen(ID_ATENCION As Integer, ID_CODIGO_FONASA As Integer, ID_USUARIO As Integer) As String
        Return N_IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS.IRIS_WEBF_ELIMINA_EXAMEN_ATE_RESULTADO_UPDATE_VALOR_ATE_GRABA_HISTORIAL(ID_ATENCION,
                                                                                                                                                 ID_CODIGO_FONASA,
                                                                                                                                                 ID_USUARIO)
    End Function

End Class
Public Class ids555
    Dim E_id_CF As Integer
    Dim E_id_PER As Integer
    Dim E_Valor As Integer
    Dim E_HO_CC As String
    Dim E_CF_ESTADO_EXAMEN As String
    Dim E_CF_MULTIPLICADOS As String
    Dim E_CODIGO_TEST As String
    Public Property CODIGO_TEST As String
        Get
            Return E_CODIGO_TEST
        End Get
        Set(ByVal value As String)
            E_CODIGO_TEST = value
        End Set
    End Property
    Public Property CF_MULTIPLICADOS As String
        Get
            Return E_CF_MULTIPLICADOS
        End Get
        Set(ByVal value As String)
            E_CF_MULTIPLICADOS = value
        End Set
    End Property
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