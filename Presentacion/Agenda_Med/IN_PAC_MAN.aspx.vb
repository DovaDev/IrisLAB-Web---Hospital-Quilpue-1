Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class IN_PAC_MAN
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
    Public Shared Function Llenar_Ddl_LugarTM() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_LugarTM As New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        Dim Data_LugarTM As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Data_LugarTM = NN_LugarTM.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()
        If (Data_LugarTM.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_LugarTM, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DL_SEXO() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_SEXO)
        Dim NN As N_IRIS_WEBF_BUSCA_SEXO = New N_IRIS_WEBF_BUSCA_SEXO
        data_paciente = NN.IRIS_WEBF_BUSCA_SEXO()
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
    Public Shared Function Llenar_DL_NAC() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_NACIONALIDAD)
        Dim NN As N_IRIS_WEBF_BUSCA_NACIONALIDAD = New N_IRIS_WEBF_BUSCA_NACIONALIDAD
        data_paciente = NN.IRIS_WEBF_BUSCA_NACIONALIDAD()
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
    Public Shared Function Llenar_DL_Ciudad() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_CIUDAD)
        Dim NN As N_IRIS_WEBF_BUSCA_CIUDAD = New N_IRIS_WEBF_BUSCA_CIUDAD
        data_paciente = NN.IRIS_WEBF_BUSCA_CIUDAD()
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
    Public Shared Function Llenar_DL_Comuna() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_COMUNA)
        Dim NN As N_IRIS_WEBF_BUSCA_COMUNA = New N_IRIS_WEBF_BUSCA_COMUNA
        data_paciente = NN.IRIS_WEBF_BUSCA_COMUNA()
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
    Public Shared Function Llenar_rut(ByVal rut As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT)
        Dim NN As N_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT = New N_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT
        data_paciente = NN.IRIS_WEBF_BUSCA_PACIENTE_POR_RUT(rut)
        If (data_paciente.Count > 0) Then
            'Serializar con JSON
            'data_paciente(0).PAC_FNAC = data_paciente(0).PAC_FNAC.Replace("/", "-")
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_paciente, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DL_prevision() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Dim NN As N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO = New N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        data_paciente = NN.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()
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
    Public Shared Function Llenar_DL_aTENCIONES() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO)
        Dim NN As N_IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO = New N_IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO
        data_paciente = NN.IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO()
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
    Public Shared Function Llenar_DL_Sectores() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_SECTORES_ACTIVOS_TODOS)
        Dim NN As N_IRIS_WEBF_BUSCA_SECTORES_ACTIVOS_TODOS = New N_IRIS_WEBF_BUSCA_SECTORES_ACTIVOS_TODOS
        data_paciente = NN.IRIS_WEBF_BUSCA_SECTORES_ACTIVOS_TODOS()
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
    Public Shared Function Llenar_DL_Programa() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)
        Dim NN As N_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO = New N_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO
        data_paciente = NN.IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO()
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
    Public Shared Function Llenar_DL_DOC() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO)
        Dim NN As N_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO = New N_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO
        data_paciente = NN.IRIS_WEBF_BUSCA_MEDICOS_ACTIVO()
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
    Public Shared Function Llenar_DL_ordenATE() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO)
        Dim NN As N_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO = New N_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO
        data_paciente = NN.IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO()
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
    Public Shared Function Llenar_tabla_exam(ByVal ID_PREVE As Integer, ByVal Fecha As String, ByVal CF As String) As List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        Dim NN As N_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA = New N_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA
        Dim ANO As Date
        ANO = CDate(Fecha)
        data_paciente = NN.IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA(ID_PREVE, Format(ANO, "yyyy"), CF)
        Return data_paciente
        'If (data_paciente.Count > 0) Then
        '    'Serializar con JSON
        '    Serializer.MaxJsonLength = 999999999
        '    Serializer.Serialize(data_paciente, str_Builder)
        '    datas = str_Builder.ToString
        'Else
        '    datas = "null"
        'End If
        'Return datas
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
        'data_paciente = NN.IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION(Format(ANO, "yyyy"), ID_PREVE)
        data_paciente = NN.IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION(2017, ID_PREVE)
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
    Public Shared Function Guardar_TodoByVal(ByVal RUT_PAC As String,
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
                                               ByVal ids As List(Of ids),
                                               ByVal xHora As String,
                                             ByVal id_Diag As String,
                                             ByVal id_Diag2 As String,
                                             ByVal dni As String,
                                             id_etnia As Integer,
                                            PAC_NOM_SOCIAL As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim correlativo As Integer
        'paciente
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim S_Id_User As String = CType(objSession("ID_USER"), String)
        Dim Rpaciente As Integer
        Dim examun As Integer
        Dim Str_Out As String = ""
        ' Dim PREINGRESO2 As Integer
        Dim PREINGRESO2_PRO_SEC As Integer = 0
        Dim nn As N_IRIS_WEBF_GRABA_PACIENTE_ATENCION = New N_IRIS_WEBF_GRABA_PACIENTE_ATENCION
        Dim vv As N_IRIS_WEBF_UPDATE_PACIENTE_ATENCION = New N_IRIS_WEBF_UPDATE_PACIENTE_ATENCION
        Dim dd As N_IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO = New N_IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO
        Dim zz As N_IRIS_WEBF_GRABA_PREINGRESO2 = New N_IRIS_WEBF_GRABA_PREINGRESO2
        Dim cc As N_IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC = New N_IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC
        Dim exex As N_IRIS_WEBF_GRABA_DETALLE_PREINGRESO = New N_IRIS_WEBF_GRABA_DETALLE_PREINGRESO



        'fecha fur
        If (FUR = "") Then
            FUR = "01/01/1900"
        End If
        If (ids.Count = 0) Then
            Str_Out = Nothing
            Return Str_Out
        Else
            'regitrar paciente o actualizar
            If (Paridad = 2) Then
                Rpaciente = nn.IRIS_WEBF_GRABA_PACIENTE_ATENCION(RUT_PAC, NOMBRE_PAC, APE_PAC, CDate(FNAC_PAC), ID_SEXO, ID_NACIONALIDAD, FONO1, MOVIL1, ID_CIU_COM, DIR_PAC, EMAIL_PAC, 1, "", 1, dni, id_etnia, PAC_NOM_SOCIAL)
            Else
                Rpaciente = vv.IRIS_WEBF_UPDATE_PACIENTE_ATENCION(ID_PAC, RUT_PAC, NOMBRE_PAC, APE_PAC, CDate(FNAC_PAC), ID_SEXO, ID_NACIONALIDAD, FONO1, MOVIL1, ID_CIU_COM, DIR_PAC, EMAIL_PAC, 1, OB, 1, id_etnia, PAC_NOM_SOCIAL)
            End If
            'ir a buscar correlativo
            correlativo = dd.IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO()
            '[IRIS_GRABA_PREINGRESO2]    
            'If (Paridad = 2) Then
            '    PREINGRESO2 = zz.IRIS_WEBF_GRABA_PREINGRESO2(correlativo, Rpaciente, 22, FUR, Procedencia, PrioridadTM, TipoAtencion, Doctor, Prevision, 1, 1, "", 0, EDAD, MES, DIA, TOTAL, TOTAL, TOTAL, FECHA_PRE)
            'Else
            '    PREINGRESO2 = zz.IRIS_WEBF_GRABA_PREINGRESO2(correlativo, ID_PAC, 22, FUR, Procedencia, PrioridadTM, TipoAtencion, Doctor, Prevision, 1, 1, OB, 0, EDAD, MES, DIA, TOTAL, TOTAL, TOTAL, FECHA_PRE)
            'End If
            'IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC
            'AGREGAR LA HORA A ESTE PA DE ACÁ!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            If (Paridad = 2) Then
                PREINGRESO2_PRO_SEC = cc.IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC(correlativo, Rpaciente, CInt(S_Id_User), FUR, Procedencia, PrioridadTM, TipoAtencion, Doctor, Prevision, 1, 1, "", 0, EDAD, MES, DIA, TOTAL, 0, 0, FECHA_PRE, Programa, Sector, id_Diag, id_Diag2, xHora)
            Else
                PREINGRESO2_PRO_SEC = cc.IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC(correlativo, ID_PAC, CInt(S_Id_User), FUR, Procedencia, PrioridadTM, TipoAtencion, Doctor, Prevision, 1, 1, OB, 0, EDAD, MES, DIA, TOTAL, 0, 0, FECHA_PRE, Programa, Sector, id_Diag, id_Diag2, xHora)
            End If

            Dim data_examen As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL)
            Dim NN_Examen As New N_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL
            Dim NN_Date As New N_Date
            Dim fecha As String = FECHA_PRE.Replace("/", "-")
            Dim DIA1 As String = fecha.Split("-")(0)
            Dim MES2 As String = fecha.Split("-")(1)
            Dim AÑO3 As String = fecha.Split("-")(2)
            Dim Date_01 As Date = NN_Date.strToDate(AÑO3, MES2, DIA1)
            Dim Date_02 As Date = NN_Date.strToDate(AÑO3, MES2, DIA1)

            'Date_01 = Date_01.Replace("/", "-")
            'Date_02 = Date_02.Replace("/", "-")

            'ver si tiene otros exames......
            data_examen = NN_Examen.IRIS_WEBF_BUSCA_EXAMEN(Date_02, Date_01, RUT_PAC)

            'If (data_examen.Count > 0) Then


            '    For i = 0 To ids.Count - 1
            '        Dim reee As Boolean = True
            '        For x = 0 To data_examen.Count - 1
            '            If (data_examen(x).ID_CODIGO_FONASA = ids(i).id_CF) Then
            '                reee = False
            '                Exit For
            '            End If
            '        Next x
            '        If (reee = True) Then
            '            examun = exex.IRIS_WEBF_GRABA_DETALLE_PREINGRESO(PREINGRESO2_PRO_SEC, CInt(S_Id_User), ids(i).id_CF, ids(i).id_PER, 1, 0, ids(i).Valor, ids(i).Valor, 0)
            '        End If
            '    Next i

            'Else
            For i = 0 To ids.Count - 1
                examun = exex.IRIS_WEBF_GRABA_DETALLE_PREINGRESO(PREINGRESO2_PRO_SEC, CInt(S_Id_User), ids(i).id_CF, ids(i).id_PER, 1, 0, ids(i).Valor, ids(i).Valor, 0, "")
            Next i
            'End If


            '.................................






            Str_Out += "{"
            Str_Out += Chr(34) & "CORELATIVO" & Chr(34) & ": " & Chr(34) & correlativo & Chr(34) & ", "
            Str_Out += Chr(34) & "ID_PREINGRESO" & Chr(34) & ": " & Chr(34) & PREINGRESO2_PRO_SEC & Chr(34)
            Str_Out += "}"
            Return Str_Out
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_CIUDAD() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_CIUDAD)
        Dim NN As N_IRIS_WEBF_BUSCA_CIUDAD = New N_IRIS_WEBF_BUSCA_CIUDAD
        data_paciente = NN.IRIS_WEBF_BUSCA_CIUDAD()
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
    Public Shared Function IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA(ByVal ID_CIU As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA)
        Dim NN As N_IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA = New N_IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA
        data_paciente = NN.IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA(ID_CIU)
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
Public Class ids
    Dim E_id_CF As Integer
    Dim E_id_PER As Integer
    Dim E_Valor As Integer
    Dim E_HO_CC As String


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
