Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Ingreso_Ate_Saydex
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST(ByVal HOST As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST)
        Dim NN As N_IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST = New N_IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST
        data_paciente = NN.IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST(HOST)
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
    Public Shared Function IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST2(ByVal HOST As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST)
        Dim NN As N_IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST = New N_IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST
        data_paciente = NN.IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST(HOST)
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
    Public Shared Function Llenar_AVIS_RUT(ByVal RUT As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        RUT = Replace(RUT, ".", "")
        RUT = Replace(RUT, "-", "")
        Dim data_paciente As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX)
        Dim NN As N_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX = New N_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX
        data_paciente = NN.IRIS_WEBF_HOST_BUsCA_DATOS_PACIENTE_POR_RUT_SAYDEX(RUT)
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
    Public Shared Function Llenar_tabla_exam(ByVal ID_PREVE As Integer, ByVal Fecha As String, ByVal CF As String) As String
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

    <Services.WebMethod()>
    Public Shared Function AJAX_SIN_RUT() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX)
        Dim NN As N_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX = New N_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX
        data_paciente = NN.IRIS_HOST_BUSCA_PACIENTE_SIN_RUT_SAYDEX()
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
    Public Shared Function IRIS_WEBF_BUSCA_DIAGNOSTICO() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_DIAGNOSTICO)
        Dim NN As N_IRIS_WEBF_BUSCA_DIAGNOSTICO = New N_IRIS_WEBF_BUSCA_DIAGNOSTICO
        data_paciente = NN.IRIS_WEBF_BUSCA_DIAGNOSTICO()
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
    Public Shared Function Llenar_AVIS(ByVal AVIS As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX)
        Dim NN As N_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX = New N_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX
        data_paciente = NN.IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_SAYDEX(AVIS)
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
            data_paciente = NN.IRIS_WEBF_HOST_BUSCA_CODIGO_FONSA_POR_COD_SAYDEX(examenes(x).examen)

            If (data_paciente.Count > 0) Then
                Dim Item_Exam As New E_IRIS_WEBF_HOST_BUSCA_CODIGO_FONSA_POR_COD_AVIS
                Item_Exam.ID_CODIGO_FONASA = data_paciente(0).ID_CODIGO_FONASA
                Item_Exam.CF_COD = data_paciente(0).CF_COD
                Item_Exam.CF_DESC = data_paciente(0).CF_DESC
                Item_Exam.ID_ESTADO = data_paciente(0).ID_ESTADO
                Item_Exam.CF_AVIS = data_paciente(0).CF_AVIS
                Item_Exam.HO_CC = examenes(x).HO_CC
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
                                             ByVal ids As List(Of ids55_2),
                                               ByVal ATE_SAYDEX As String,
                                               ByVal DIAG1 As Integer,
                                               ByVal DIAG2 As Integer,
                                           ByVal interno As String, ByVal sub_atencion As String,
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
                                               ID_ETNIA As Integer,
                                                PAC_NOM_SOCIAL As String,
                                                ByVal EMPRESA As Integer) As String
        'Checar Galletas
        If (Test_C.emptyCookies = True) Then
            HttpContext.Current.Response.Redirect("~index.aspx", False)
            Return Nothing
        End If

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim correlativo As Integer
        Test_C.Check_C()
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim S_Id_User As String = CType(objSession("ID_USER"), String)
        'paciente
        Dim Rpaciente As Integer
        Dim examun As Integer
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
        Dim data_paciente2222 As List(Of E_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT)
        Dim NNv As N_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT = New N_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT
        Dim RUT_USUARIO_VB_2 As String
        RUT_USUARIO_VB_2 = Replace(RUT_PAC, ".", "")
        RUT_USUARIO_VB_2 = Replace(RUT_USUARIO_VB_2, "-", "")

        Dim hocc As String = ""

        If (HO_CC = "0") Then
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
        'fecha fur
        If (FUR = "") Then
            FUR = "01/01/1900"
        End If
        If (ids.Count = 0) Then
            Str_Out = Nothing
            Return Str_Out
        Else
            data_paciente2222 = NNv.IRIS_WEBF_BUSCA_PACIENTE_POR_RUT(RUT_PAC)


            If (data_paciente2222.Count = 0 Or RUT_PAC = "") Then
                Rpaciente = nn.IRIS_WEBF_GRABA_PACIENTE_ATENCION(RUT_PAC, NOMBRE_PAC, APE_PAC, CDate(FNAC_PAC), ID_SEXO, ID_NACIONALIDAD, FONO1, MOVIL1, ID_CIU_COM, DIR_PAC, EMAIL_PAC, 1, "", 1, "", ID_ETNIA, PAC_NOM_SOCIAL)
                correlativo = dd.IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO()
                PREINGRESO2_PRO_SEC = cc.IRIS_WEBF_GRABA_PREINGRESO3_PRO_SEC_AVIS_NEW(correlativo,
                                                                             Rpaciente,
                                                                             CInt(S_Id_User),
                                                                             FUR,
                                                                             Procedencia,
                                                                             PrioridadTM,
                                                                             TipoAtencion,
                                                                             Doctor,
                                                                             Prevision,
                                                                             1,
                                                                             1,
                                                                             OB,
                                                                             0,
                                                                             EDAD,
                                                                             MES,
                                                                             DIA,
                                                                             TOTAL,
                                                                             0,
                                                                             0,
                                                                             FECHA_PRE,
                                                                             Programa,
                                                                             Sector, ATE_SAYDEX, DIAG1, DIAG2, sub_atencion, vih, 1, EMPRESA, 0)
            Else

                correlativo = dd.IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO()
                PREINGRESO2_PRO_SEC = cc.IRIS_WEBF_GRABA_PREINGRESO3_PRO_SEC_AVIS_NEW(correlativo,
                                                                             data_paciente2222(0).ID_PACIENTE,
                                                                             CInt(S_Id_User),
                                                                             FUR,
                                                                             Procedencia,
                                                                             PrioridadTM,
                                                                             TipoAtencion,
                                                                             Doctor,
                                                                             Prevision,
                                                                             1,
                                                                             1,
                                                                             OB,
                                                                             0,
                                                                             EDAD,
                                                                             MES,
                                                                             DIA,
                                                                             TOTAL,
                                                                             0,
                                                                             0,
                                                                             FECHA_PRE,
                                                                             Programa,
                                                                             Sector, ATE_SAYDEX, DIAG1, DIAG2, sub_atencion, vih, 1, EMPRESA, 0)
            End If



            If (Paridad = 1) Then
                zz.IRIS_WEBF_HOST_UPDATE_CARGA_SAYDEX_FOLIO(HO_CC, PREINGRESO2_PRO_SEC)
            Else
                zz.IRIS_WEBF_HOST_UPDATE_CARGA_SAYDEX_FOLIO(HO_CC, PREINGRESO2_PRO_SEC)
                'zz.IRIS_WEBF_HOST_UPDATE_CARGA_SAYDEX(RUT_USUARIO_VB_2, PREINGRESO2_PRO_SEC)
            End If

            Dim data_examen2 As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL)
            Dim NN_Examen2 As New N_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL

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
            data_examen2 = NN_Examen2.IRIS_WEBF_BUSCA_EXAMEN(Date_02, Date_01, RUT_PAC)

            'If (data_examen2.Count > 0) Then


            '    For i = 0 To ids.Count - 1
            '        Dim reee As Boolean = True
            '        For x = 0 To data_examen2.Count - 1
            '            If (data_examen2(x).ID_CODIGO_FONASA = ids(i).id_CF) Then
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
                examun = exex.IRIS_WEBF_GRABA_DETALLE_PREINGRESO(PREINGRESO2_PRO_SEC, CInt(S_Id_User), ids(i).id_CF, ids(i).id_PER, 1, 0, ids(i).Valor, ids(i).Valor, 0, ids(i).HO_CC)
            Next i
            'End If



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
            data_pac = NN_pac.IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2(PREINGRESO2_PRO_SEC)
            data_examen = NN_Examen.IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL(PREINGRESO2_PRO_SEC)
            data_atencion = NN_atencion.IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION(PREINGRESO2_PRO_SEC)
            correlativo2 = ccx.IRIS_WEBF_BUSCA_CORRELATIVO_ATENCION()
            id_atencion = ddx.IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_SAYDEX_POSTA(correlativo2,
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
                                                                          data_examen(0).PREI_DET_V_PAGADO,
                                                                          data_examen(0).PREI_DET_V_PREVI,
                                                                          data_examen(0).PREI_DET_V_COPAGO,
                                                                          data_atencion(0).ID_PROGRAMA,
                                                                          "",
                                                                          data_atencion(0).ID_SECTOR,
                                                                        hocc,
                                                                               interno,
                                                                               data_atencion(0).ID_DIAGNOSTICO, data_atencion(0).ID_DIAGNOSTICO2, data_atencion(0).VIH, data_pac(0).DNI)

            For i = 0 To data_examen.Count - 1
                id = jj.IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_SAYDEX_01(id_atencion,
                                                                   CInt(S_Id_User),
                                                                    ids(i).id_CF, ids(i).id_PER, 1, 0, ids(i).Valor, 0, 0, ids(i).HO_CC, ids(i).CF_MULTIPLICADOS)

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
            ahg = uu.IRIS_WEBF_AGENDA_UPDATE_ESTADO_PREINGRESO(PREINGRESO2_PRO_SEC, id_atencion)
            DATASSSSSS = NN_pac.IRIS_WEBF_UPDATE_OBS_INTERNO_PRE_INGRESO(PREINGRESO2_PRO_SEC, interno, "", "")
            Dim NN_ExamenDet As New N_Exa_Esp_V
            Dim DataExamenDet As Integer
            'Dim exa_avis As Integer

            For i = 0 To ids.Count - 1
                If (ids(i).CF_ESTADO_EXAMEN = "Espera") Then
                    DataExamenDet = NN_ExamenDet.IRIS_WEBF_UPDATE_ESTADO_EXAMEN(id_atencion, ids(i).id_CF)

                    'If (IsNothing(numero_avis) = False Or numero_avis <> 0) Then
                    '    exa_avis = NN_ExamenDet.IRIS_WEBF_UPDATE_ESTADO_EXAMEN_INTEGRACION_AVIS(numero_avis, Codigo_Fonasa_avis)
                    'End If
                End If

            Next i

            'Dim numero As Integer
            Dim N_N As N_IRIS_OBTENER_INFO = New N_IRIS_OBTENER_INFO

            For i = 0 To ids.Count - 1
                If (ids(i).CF_ESTADO_EXAMEN <> "Espera") Then
                    'numero = N_N.UPDATE_ESTADO_TEST(ids(i).HO_CC, ids(i).CODIGO_TEST)
                    DataExamenDet = NN_ExamenDet.IRIS_WEBF_UPDATE_ESTADO_EXAMEN_SAYDEX(ids(i).HO_CC, ids(i).CODIGO_TEST)
                Else
                    DataExamenDet = NN_ExamenDet.IRIS_WEBF_UPDATE_ESTADO_EXAMEN_INTEGRACION_SAYDEX(ids(i).HO_CC, ids(i).CODIGO_TEST)
                End If

            Next i

            For x = 0 To ids.Count - 1
                If (ids(x).CF_MULTIPLICADOS <> "" And ids(x).CF_ESTADO_EXAMEN <> "Espera") Then
                    Dim regex As New Regex("[0-9]+", RegexOptions.ECMAScript And RegexOptions.IgnoreCase)
                    Dim match9000 As MatchCollection
                    Dim list_Num As New List(Of String)

                    match9000 = regex.Matches(ids(x).CF_MULTIPLICADOS)
                    For y = 0 To (match9000.Count - 1)
                        If (match9000(y).Success = True) Then
                            DataExamenDet = NN_ExamenDet.IRIS_WEBF_UPDATE_ESTADO_EXAMEN_INTEGRACION_SAYDEX(match9000(y).Value, ids(x).CODIGO_TEST)
                        End If
                    Next y
                End If
            Next x

            Str_Out += "{"
            Str_Out += Chr(34) & "ID_Atencion" & Chr(34) & ": " & Chr(34) & id_atencion & Chr(34) & ", "
            Str_Out += Chr(34) & "Correlativo" & Chr(34) & ": " & Chr(34) & correlativo2 & Chr(34)
            Str_Out += "}"
            Return Str_Out
            Return datas
        End If
    End Function

End Class
Public Class examens_avis
    Dim E_examen As Integer
    Dim E_HO_CC As String
    Public Property examen As Integer
        Get
            Return E_examen
        End Get
        Set(ByVal value As Integer)
            E_examen = value
        End Set
    End Property
    Public Property HO_CC As String
        Get
            Return E_HO_CC
        End Get
        Set(ByVal value As String)
            E_HO_CC = value
        End Set
    End Property
End Class
Public Class ids55_2
    Dim E_id_CF As Integer
    Dim E_id_PER As Integer
    Dim E_Valor As Integer
    Dim E_HO_CC As String
    Dim E_CF_ESTADO_EXAMEN As String
    Dim E_CF_MULTIPLICADOS As String
    Dim E_CODIGO_TEST As String
    Dim E_CF_TP_PAGO As String
    Dim E_CF_VALOR As String
    Dim E_CF_TP_PROGRA As String
    Public Property CF_TP_PROGRA As String
        Get
            Return E_CF_TP_PROGRA
        End Get
        Set(ByVal value As String)
            E_CF_TP_PROGRA = value
        End Set
    End Property
    Public Property CF_VALOR As String
        Get
            Return E_CF_VALOR
        End Get
        Set(ByVal value As String)
            E_CF_VALOR = value
        End Set
    End Property
    Public Property CF_TP_PAGO As String
        Get
            Return E_CF_TP_PAGO
        End Get
        Set(ByVal value As String)
            E_CF_TP_PAGO = value
        End Set
    End Property
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
