Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class Perm_Usu
    Inherits System.Web.UI.Page

    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If

        Select Case (C_P_ADMIN.Value)
            Case Is <> 1
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
    Public Shared Function IRIS_WEBF_BUSCA_USUARIO_TODOS() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_LugarTM As New N_IRIS_WEBF_BUSCA_USUARIO_TODOS
        Dim Data_LugarTM As New List(Of E_IRIS_WEBF_BUSCA_USUARIO_TODOS)

        Data_LugarTM = NN_LugarTM.IRIS_WEBF_BUSCA_USUARIO_TODOS()
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
    Public Shared Function IRIS_WEBF_BUSCA_USUARIO_POR_ID(ByVal ID_USUARIO As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_LugarTM As New N_IRIS_WEBF_BUSCA_USUARIO_POR_ID
        Dim Data_LugarTM As New List(Of E_IRIS_WEBF_BUSCA_USUARIO_POR_ID)

        Data_LugarTM = NN_LugarTM.IRIS_WEBF_BUSCA_USUARIO_POR_ID(ID_USUARIO)
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
    Public Shared Function IRIS_WEBF_GRABA_USUARIO(ByVal USU_RUT As String,
                                                    ByVal NOMBRE_USU As String,
                                                    ByVal APE_USU As String,
                                                    ByVal FNAC_USU As String,
                                                    ByVal DIR_USU As String,
                                                    ByVal EMAIL_USU As String,
                                                   ByVal ID_EST_USU As Integer,
                                                    ByVal ID_CIU_COM As Integer,
                                                    ByVal ID_PRO_USU As Integer,
                                                    ByVal ID_CAR_USU As Integer,
                                                    ByVal USUARIO As String,
                                                    ByVal PASS As String,
                                                    ByVal FONO As String,
                                                    ByVal MOVIL As String,
                                                    ByVal USU_ADMIN As Integer,
                                                    ByVal USU_TM As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_LugarTM As New N_IRIS_WEBF_GRABA_USUARIO
        Dim Usu_Creado As Integer

        Usu_Creado = NN_LugarTM.IRIS_WEBF_GRABA_USUARIO(USU_RUT, NOMBRE_USU, APE_USU, CDate(FNAC_USU), DIR_USU, EMAIL_USU, ID_EST_USU, ID_CIU_COM, ID_PRO_USU, ID_CAR_USU, USUARIO, PASS, FONO, MOVIL, USU_ADMIN, USU_TM)
        If (Usu_Creado <> 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Usu_Creado, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_UPDATE_USUARIOS(ByVal ID_USU As Integer,
                                                     ByVal RUT_USU As String,
                                                     ByVal NOMBRE_USU As String,
                                                     ByVal APE_USU As String,
                                                     ByVal FNAC_USU As String,
                                                     ByVal DIR_USU As String,
                                                     ByVal EMAIL_USU As String,
                                                     ByVal ID_EST_USU As Integer,
                                                     ByVal ID_REL_CIU As Integer,
                                                     ByVal ID_PRO_USU As Integer,
                                                     ByVal ID_CAR_USU As Integer,
                                                     ByVal USUARIO As String,
                                                     ByVal PASS As String,
                                                     ByVal ID_PER_USU As Integer,
                                                     ByVal FONO As String,
                                                     ByVal MOVIL As String,
                                                     ByVal USU_ADMIN As Integer,
                                                     ByVal USU_TM As Integer,
                                                     ByVal USU_FIRMA As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_LugarTM As New N_IRIS_WEBF_UPDATE_USUARIOS
        Dim Usu_Creado As Integer

        Usu_Creado = NN_LugarTM.IRIS_WEBF_UPDATE_USUARIOS(ID_USU,
                                                        RUT_USU,
                                                        NOMBRE_USU,
                                                        APE_USU,
                                                        CDate(FNAC_USU),
                                                        DIR_USU,
                                                        EMAIL_USU,
                                                        ID_EST_USU,
                                                        ID_REL_CIU,
                                                        ID_PRO_USU,
                                                        ID_CAR_USU,
                                                        USUARIO,
                                                        PASS,
                                                        ID_PER_USU,
                                                        FONO,
                                                        MOVIL,
                                                        USU_ADMIN,
                                                        USU_TM,
                                                        USU_FIRMA)
        If (Usu_Creado <> 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Usu_Creado, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
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
    Public Shared Function IRIS_WEBF_BUSCA_PROFESION() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""


        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PROFESION)
        Dim NN As N_IRIS_WEBF_BUSCA_PROFESION = New N_IRIS_WEBF_BUSCA_PROFESION
        data_paciente = NN.IRIS_WEBF_BUSCA_PROFESION()
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
    Public Shared Function IRIS_WEBF_BUSCA_CARGO() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""


        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_CARGO)
        Dim NN As N_IRIS_WEBF_BUSCA_CARGO = New N_IRIS_WEBF_BUSCA_CARGO
        data_paciente = NN.IRIS_WEBF_BUSCA_CARGO()
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
    Public Shared Function IRIS_WEBF_BUSCA_PERMISO_USUARIO() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PERMISO_USUARIO)
        Dim NN As N_IRIS_WEBF_BUSCA_PERMISO_USUARIO = New N_IRIS_WEBF_BUSCA_PERMISO_USUARIO

        data_paciente = NN.IRIS_WEBF_BUSCA_PERMISO_USUARIO()
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
