Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Crear_Edit_Pac
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
    Public Shared Function Llenar_rut(ByVal rut As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_rut As List(Of E_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT)
        Dim NN_rut As N_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT = New N_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT

        data_rut = NN_rut.IRIS_WEBF_BUSCA_PACIENTE_POR_RUT(rut)


        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_EDITAR_PACIENTE_DATOS_ACTUALES)
        Dim NN As N_IRIS_WEBF_BUSCA_EDITAR_PACIENTE_DATOS_ACTUALES = New N_IRIS_WEBF_BUSCA_EDITAR_PACIENTE_DATOS_ACTUALES

        If data_rut.Count > 0 Then
            data_paciente = NN.IRIS_WEBF_BUSCA_EDITAR_PACIENTE_DATOS_ACTUALES(data_rut(0).ID_PACIENTE)
            If (data_paciente.Count > 0) Then

                'data_paciente(0).PAC_FNAC = data_paciente(0).PAC_FNAC.Replace("/", "-")
                'Serializar con JSON
                Serializer.MaxJsonLength = 999999999
                Serializer.Serialize(data_paciente, str_Builder)
                datas = str_Builder.ToString

                Return datas
            Else
                datas = "null"
            End If
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal RUT_P As String, ByVal NOM_P As String, ByVal APE_P As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PACIENTE_LIKE2)
        Dim NN As N_IRIS_WEBF_BUSCA_PACIENTE_LIKE2 = New N_IRIS_WEBF_BUSCA_PACIENTE_LIKE2
        Dim nombre As String = NOM_P.Trim()
        Dim apellido As String = APE_P.Trim()
        Dim sinpuntos As String = RUT_P.Replace(".", "")
        sinpuntos = "%" & sinpuntos & "%"
        RUT_P = "%" & RUT_P & "%"
        nombre = "%" & nombre & "%"
        apellido = "%" & apellido & "%"
        data_paciente = NN.IRIS_WEBF_BUSCA_PACIENTE_LIKE2(RUT_P, nombre, apellido, sinpuntos)
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
    Public Shared Function Llenar_DataTable_Antiguos_OLD(ByVal ID_PAC As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PACIENTE_POR_ID)
        Dim NN As N_IRIS_WEBF_BUSCA_PACIENTE_POR_ID = New N_IRIS_WEBF_BUSCA_PACIENTE_POR_ID

        data_paciente = NN.IRIS_WEBF_BUSCA_PACIENTE_POR_ID(ID_PAC)
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
    Public Shared Function Llenar_DataTable_Antiguos(ByVal ID_PAC As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_EDITAR_PACIENTE_DATOS_ACTUALES)
        Dim NN As N_IRIS_WEBF_BUSCA_EDITAR_PACIENTE_DATOS_ACTUALES = New N_IRIS_WEBF_BUSCA_EDITAR_PACIENTE_DATOS_ACTUALES

        data_paciente = NN.IRIS_WEBF_BUSCA_EDITAR_PACIENTE_DATOS_ACTUALES(ID_PAC)
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
    Public Shared Function IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR)
        Dim NN As N_IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR = New N_IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR

        data_paciente = NN.IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR()
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
    Public Shared Function IRIS_WEBF_BUSCA_SEXO() As String
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
    Public Shared Function IRIS_WEBF_BUSCA_NACIONALIDAD() As String
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

    '<Services.WebMethod()>
    'Public Shared Function IRIS_WEBF_BUSCA_COMUNA() As String
    '    'Declaraciones del Serializador
    '    Dim Serializer As New JavaScriptSerializer
    '    Dim str_Builder As New StringBuilder
    '    Dim datas As String = ""
    '    'Declaraciones internas
    '    Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_COMUNA)
    '    Dim NN As N_IRIS_WEBF_BUSCA_COMUNA = New N_IRIS_WEBF_BUSCA_COMUNA

    '    data_paciente = NN.IRIS_WEBF_BUSCA_COMUNA()
    '    If (data_paciente.Count > 0) Then
    '        'Serializar con JSON
    '        Serializer.MaxJsonLength = 999999999
    '        Serializer.Serialize(data_paciente, str_Builder)
    '        datas = str_Builder.ToString
    '    Else
    '        datas = "null"
    '    End If

    '    Return datas
    'End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_UPDATE_PACIENTES(ByVal ID_PAC As Integer,
                                                      ByVal RUT_PAC As String,
                                                      ByVal NOMBRE_PAC As String,
                                                      ByVal APE_PAC As String,
                                                      ByVal ID_SEXO As Integer,
                                                      ByVal FNAC_PAC As String,
                                                      ByVal ID_NACIONALIDAD As Integer,
                                                      ByVal DIR_PAC As String,
                                                      ByVal ID_CIU_COM As Integer,
                                                      ByVal FONO1 As String,
                                                      ByVal FONO2 As String,
                                                      ByVal MOVIL1 As String,
                                                      ByVal MOVIL2 As String,
                                                      ByVal EMAIL_PAC As String,
                                                      ByVal ID_DIAGNOSTICO As Integer,
                                                      ByVal ID_ESTADO As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim NN As N_IRIS_WEBF_UPDATE_PACIENTES = New N_IRIS_WEBF_UPDATE_PACIENTES

        Dim numerito As Integer

        numerito = NN.IRIS_WEBF_UPDATE_PACIENTES(ID_PAC, RUT_PAC, NOMBRE_PAC, APE_PAC, ID_SEXO, CDate(FNAC_PAC), ID_NACIONALIDAD, DIR_PAC, ID_CIU_COM, FONO1, FONO2, MOVIL1, MOVIL2, EMAIL_PAC, ID_DIAGNOSTICO, ID_ESTADO)

        'Serializar con JSON
        Serializer.MaxJsonLength = 999999999
        Serializer.Serialize(numerito, str_Builder)
        datas = str_Builder.ToString

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
    Public Shared Function IRIS_WEBF_GRABA_PACIENTE(ByVal RUT_PAC As String,
                                      ByVal NOMBRE_PAC As String,
                                      ByVal APE_PAC As String,
                                      ByVal ID_SEXO As Integer,
                                      ByVal FNAC_PAC As String,
                                      ByVal ID_NACIONALIDAD As Integer,
                                      ByVal DIR_PAC As String,
                                      ByVal ID_CIU_COM As Integer,
                                      ByVal FONO1 As String,
                                      ByVal FONO2 As String,
                                      ByVal MOVIL1 As String,
                                      ByVal MOVIL2 As String,
                                      ByVal EMAIL_PAC As String,
                                      ByVal ID_DIAGNOSTICO As Integer,
                                      ByVal ID_ESTADO As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_graba As Integer
        Dim NN_graba As N_IRIS_WEBF_GRABA_PACIENTE = New N_IRIS_WEBF_GRABA_PACIENTE

        data_graba = NN_graba.IRIS_WEBF_GRABA_PACIENTE(RUT_PAC,
                                                NOMBRE_PAC,
                                                APE_PAC,
                                                ID_SEXO,
                                                CDate(FNAC_PAC),
                                                ID_NACIONALIDAD,
                                                DIR_PAC,
                                                ID_CIU_COM,
                                                FONO1, FONO2,
                                                MOVIL1,
                                                MOVIL2,
                                                EMAIL_PAC,
                                                ID_DIAGNOSTICO,
                                                ID_ESTADO)
        If (data_graba > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_graba, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If

        Return datas
    End Function
End Class