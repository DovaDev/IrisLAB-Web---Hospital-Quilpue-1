Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Editar_atencion
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
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_TPAte() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO
        Dim Data_TPAte As New List(Of E_IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO)
        Data_TPAte = NN.IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO()
        If (Data_TPAte.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_TPAte, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_O_Ate() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_O_Ate As New N_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO
        Dim Data_O_Ate As New List(Of E_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO)
        Data_O_Ate = NN_O_Ate.IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO()
        If (Data_O_Ate.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_O_Ate, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Medico() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Medico As New N_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO
        Dim Data_Medico As New List(Of E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO)
        Data_Medico = NN_Medico.IRIS_WEBF_BUSCA_MEDICOS_ACTIVO()
        If (Data_Medico.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Medico, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Prevision() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Prevision As New N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        Dim Data_Prevision As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Data_Prevision = NN_Prevision.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()
        If (Data_Prevision.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Prevision, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Localizacion() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Localizacion As New N_IRIS_WEBF_BUSCA_LOCALIZACION_ACTIVO
        Dim Data_Localizacion As New List(Of E_IRIS_WEBF_BUSCA_LOCALIZACION_ACTIVO)
        Data_Localizacion = NN_Localizacion.IRIS_WEBF_BUSCA_LOCALIZACION_ACTIVO()
        If (Data_Localizacion.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Localizacion, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Sector() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Sector As New N_IRIS_WEBF_BUSCA_SECTORES_ACTIVOS_TODOS
        Dim Data_Sector As New List(Of E_IRIS_WEBF_BUSCA_SECTORES_ACTIVOS_TODOS)
        Data_Sector = NN_Sector.IRIS_WEBF_BUSCA_SECTORES_ACTIVOS_TODOS()
        If (Data_Sector.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Sector, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Programa() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Programa As New N_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO
        Dim Data_Programa As New List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)
        Data_Programa = NN_Programa.IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO()
        If (Data_Programa.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Programa, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal FECHA1 As String, ByVal FECHA2 As String, ByVal LUGARTM As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_BuscarAtencion As New N_IRIS_WEBF_BUSCA_ATENCION_PACIENTE_FECHA
        Dim NN_Datos_Pac As New N_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES
        Dim Data_Datos_Pac As New List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES)
        Dim Data_Ate As New List(Of E_IRIS_WEBF_BUSCA_ATENCION_PACIENTE_FECHA)

        Data_Ate = NN_BuscarAtencion.IRIS_WEBF_BUSCA_ATENCION_PACIENTE_FECHA(FECHA1, FECHA2, LUGARTM)
        For y = 0 To Data_Ate.Count - 1
            Data_Datos_Pac = NN_Datos_Pac.IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES(Data_Ate(y).ID_ATENCION)
            Data_Ate(y).PAC_FNAC = Data_Datos_Pac(0).PAC_FNAC
        Next y
        If (Data_Ate.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Ate, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2(ByVal ID_ATE As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2
        Dim Data_Ate As New List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2)
        Data_Ate = NN.IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2(ID_ATE)
        If (Data_Ate.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Ate, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_EDITAR_ATE_DATOS_DE_ATENCION2(ByVal ID_ATE As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_EDITAR_ATE_DATOS_DE_ATENCION2
        Dim Data_Ate As New List(Of E_IRIS_WEBF_BUSCA_EDITAR_ATE_DATOS_DE_ATENCION2)
        Data_Ate = NN.IRIS_WEBF_BUSCA_EDITAR_ATE_DATOS_DE_ATENCION2(ID_ATE)
        If (Data_Ate.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Ate, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_UPDATE_DATOS_ATENCIONES3_PRO_SECTOR(ByVal ID_ATE As Integer,
                                                                         ByVal ID_PROCE As Integer,
                                                                         ByVal ID_TP_PACI As Integer,
                                                                         ByVal ID_ORDEN As Integer,
                                                                         ByVal ID_DOCTOR As Integer,
                                                                         ByVal ID_PREVE As Integer,
                                                                         ByVal ID_LOCAL As Integer,
                                                                         ByVal ATE_CAMA As String,
                                                                         ByVal ATE_OBS_FICHA As String,
                                                                         ByVal ID_PROGRA As Integer,
                                                                         ByVal EDAD As Integer,
                                                                         ByVal MES As Integer,
                                                                         ByVal DIA As Integer,
                                                                         ByVal SECTOR As Integer,
                                                                         ByVal ID_PAC As Integer,
                                                                         ByVal FECHA As String,
                                                                         ByVal CHECK() As Object) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_UPDATE_DATOS_ATENCIONES3_PRO_SECTOR
        Dim NN_FECHA As New N_IRIS_WEBF_UPDATE_PACIENTES_FNAC
        Dim numerito As Integer = 0
        Dim numerito2 As Integer = 0
        numerito = NN.IRIS_WEBF_UPDATE_DATOS_ATENCIONES3_PRO_SECTOR(ID_ATE,
                                                                    ID_PROCE,
                                                                    ID_TP_PACI,
                                                                    ID_ORDEN,
                                                                    ID_DOCTOR,
                                                                    ID_PREVE,
                                                                    ID_LOCAL,
                                                                    ATE_CAMA,
                                                                    ATE_OBS_FICHA.ToUpper(),
                                                                    ID_PROGRA,
                                                                    EDAD,
                                                                    MES,
                                                                    DIA,
                                                                    SECTOR)
        If (CHECK.Length > 0) Then
            numerito2 = NN_FECHA.IRIS_WEBF_UPDATE_PACIENTES_FNAC(ID_PAC, FECHA)
        End If

        'Serializar con JSON
        Serializer.MaxJsonLength = 999999999
        Serializer.Serialize(numerito, str_Builder)
        Return str_Builder.ToString
    End Function
    '<Services.WebMethod()>
    'Public Shared Function IRIS_WEBF_UPDATE_PACIENTES_FNAC(ByVal ID_PAC As Integer, ByVal FNAC_PAC As Date) As String
    '    'Declaraciones del Serializador
    '    Dim Serializer As New JavaScriptSerializer
    '    Dim str_Builder As New StringBuilder
    '    'Declaraciones internas
    '    Dim NN As New N_IRIS_WEBF_UPDATE_PACIENTES_FNAC
    '    Dim numerito As Integer
    '    numerito = NN.IRIS_WEBF_UPDATE_PACIENTES_FNAC(ID_PAC, FNAC_PAC)
    '    'Serializar con JSON
    '    Serializer.MaxJsonLength = 999999999
    '    Serializer.Serialize(numerito, str_Builder)
    '    Return str_Builder.ToString
    'End Function
End Class