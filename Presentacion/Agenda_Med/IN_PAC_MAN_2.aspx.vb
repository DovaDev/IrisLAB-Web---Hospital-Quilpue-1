Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class IN_PAC_MAN_2
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
    Public Shared Function Llenar_DNI(ByVal dni As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT)
        Dim NN As N_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT = New N_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT
        data_paciente = NN.IRIS_WEBF_BUSCA_PACIENTE_POR_dni(dni)
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
                                     ByVal ids As List(Of ids3),
                                     ByVal xHora As String,
                                     ByVal id_Diag As String,
                                     ByVal id_Diag2 As String,
                                     ByVal sub_atencion As String,
                                     ByVal vih As String,
                                     ByVal dni As String,
                                     ByVal Numero_clini As String,
                                     ByVal Sub_progra As String,
                                     ByVal ID_ETNIA As Integer,
                                     ByVal PAC_NOM_SOCIAL As String,
                                     ByVal EMPRESA As Integer,
                                     nombreCodificadoParaSepararVIH As String) As Object

        ' Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim correlativo As Integer

        ' Paciente
        Test_C.Check_C()
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim S_Id_User As String = CType(objSession("ID_USER"), String)
        Dim Rpaciente As Integer
        Dim examun As Integer
        Dim Str_Out As String = ""

        ' Instanciaciones de objetos necesarios
        Dim PREINGRESO2_PRO_SEC As Integer = 0
        Dim nn As New N_IRIS_WEBF_GRABA_PACIENTE_ATENCION
        Dim vv As New N_IRIS_WEBF_UPDATE_PACIENTE_ATENCION
        Dim dd As New N_IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO
        Dim zz As New N_IRIS_WEBF_GRABA_PREINGRESO2
        Dim cc As New N_IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC
        Dim exex As New N_IRIS_WEBF_GRABA_DETALLE_PREINGRESO


        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        Dim clinico_chikito As String = ""

        If (ids(0).Clinico = "" Or ids(0).Clinico = "0") Then
            For b = 0 To ids.Count - 1
                If (IsNumeric(ids(b).Clinico) = True) Then
                    clinico_chikito = ids(b).Clinico
                Else
                    clinico_chikito = ""
                End If
            Next b
        Else
            clinico_chikito = ids(0).Clinico
        End If
        '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        'fecha fur
        If (FUR = "") Then
            FUR = "01/01/1900"
        End If

        If (ids.Count = 0) Then
            Str_Out = Nothing
            Return Str_Out
        Else

            '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            Dim examenesVIHIngresados = New List(Of ids3)
            Dim existeVIH = ids.Any(Function(item) item.CF_VIH)

            If existeVIH Then
                examenesVIHIngresados = ids.Where(Function(item) item.CF_VIH).ToList()
                ids = ids.Where(Function(item) Not item.CF_VIH).ToList()
            End If
            '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

            ' Registrar o actualizar paciente
            If (Paridad = 2) Then
                Rpaciente = nn.IRIS_WEBF_GRABA_PACIENTE_ATENCION(RUT_PAC, NOMBRE_PAC, APE_PAC, CDate(FNAC_PAC), ID_SEXO, ID_NACIONALIDAD, FONO1, MOVIL1, ID_CIU_COM, DIR_PAC, EMAIL_PAC, 1, "", 1, dni, ID_ETNIA, PAC_NOM_SOCIAL)
            Else
                Rpaciente = vv.IRIS_WEBF_UPDATE_PACIENTE_ATENCION(ID_PAC, RUT_PAC, NOMBRE_PAC, APE_PAC, CDate(FNAC_PAC), ID_SEXO, ID_NACIONALIDAD, FONO1, MOVIL1, ID_CIU_COM, DIR_PAC, EMAIL_PAC, 1, OB, 1, ID_ETNIA, PAC_NOM_SOCIAL)
            End If



            Dim idsPreingresos As New List(Of Integer)



            ' Grabar preingreso
            'If (Paridad = 2) Then
            If ids.Count > 0 Then
                ' Buscar correlativo
                correlativo = dd.IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO()

                PREINGRESO2_PRO_SEC = cc.IRIS_WEBF_GRABA_PREINGRESO3_PRO_SEC_AVIS_NEW(correlativo, Rpaciente, CInt(S_Id_User), FUR, Procedencia, PrioridadTM,
                                  TipoAtencion, Doctor, Prevision, 1, 1, ("N° Clínica: " & Numero_clini), 0, EDAD, MES, DIA, TOTAL, 0, 0, FECHA_PRE, Programa, Sector,
                                  Numero_clini, 0, 0, sub_atencion, vih, Sub_progra, EMPRESA, xHora)

                idsPreingresos.Add(PREINGRESO2_PRO_SEC)

                For i = 0 To ids.Count - 1
                    examun = exex.IRIS_WEBF_GRABA_DETALLE_PREINGRESO(PREINGRESO2_PRO_SEC, CInt(S_Id_User), ids(i).id_CF, ids(i).id_PER, 1, 0, ids(i).Valor, ids(i).Valor, 0, ids(i).Clinico)
                Next i

            End If

            Dim idPreingresoVIH = 0
            Dim correlativoVIH = 0
            If examenesVIHIngresados.Count > 0 Then
                Dim idPacienteVIH = (New N_IRIS_WEBF_GRABA_PACIENTE_ATENCION).IRIS_WEBF_GRABA_PACIENTE_VIH_ATE(RUT_PAC, nombreCodificadoParaSepararVIH, "", CDate(FNAC_PAC), ID_SEXO, ID_NACIONALIDAD, FONO1, MOVIL1, ID_CIU_COM, DIR_PAC, EMAIL_PAC, 1, "", 1, "", ID_ETNIA, PAC_NOM_SOCIAL)
                correlativoVIH = (New N_IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO).IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO()
                idPreingresoVIH = (New N_IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC).IRIS_WEBF_GRABA_PREINGRESO3_PRO_SEC_AVIS_NEW(
                                                       correlativoVIH, idPacienteVIH, CInt(S_Id_User), FUR, Procedencia, PrioridadTM,
                                                       TipoAtencion, Doctor, Prevision, 1, 1, ("N° Orden Clínica: " & examenesVIHIngresados(0).Clinico),
                                                       0, EDAD, MES, DIA, TOTAL, 0, 0, FECHA_PRE, Programa, Sector, examenesVIHIngresados(0).Clinico,
                                                       0, 0, sub_atencion, vih, Sub_progra, EMPRESA, 0)
                For Each examen In examenesVIHIngresados
                    Dim idDetalleAtencionVIH = (New N_IRIS_WEBF_GRABA_DETALLE_PREINGRESO).
                    IRIS_WEBF_GRABA_DETALLE_PREINGRESO(idPreingresoVIH, CInt(S_Id_User), examen.id_CF,
                                                       examen.id_PER, 1, 0, examen.Valor, examen.Valor, 0, examen.Clinico)
                Next

                idsPreingresos.Add(idPreingresoVIH)
            End If

            'Dim respuesta = New With {
            '.Correlativo = correlativo,
            '.ID_Atencion = PREINGRESO2_PRO_SEC,
            '.CORELATIVO_VIH = correlativoVIH,
            '.ID_Atencion_VIH = idPreingresoVIH
            '}

            ''Return datas
            'Return respuesta
            Return New With {
                .CORELATIVO = correlativo,
                .ID_PREINGRESO = PREINGRESO2_PRO_SEC,
                .CORELATIVO_VIH = correlativoVIH,
                .ID_PREINGRESO_VIH = idPreingresoVIH
        }
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
    Public Class ids3
        Dim E_id_CF As Integer
        Dim E_id_PER As Integer
        Dim E_Valor As Integer
        Dim E_Clinico As String
        Public Property CF_VIH As Boolean


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
End Class

