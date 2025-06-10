Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Crear_Edit_Usu_Convenio
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
    Public Shared Function IRIS_WEBF_BUSCA_USUARIOS_CONVENIO_TODOS() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_usu As List(Of E_IRIS_WEBF_BUSCA_USUARIOS_CONVENIO_TODOS)
        Dim NN_usu As N_IRIS_WEBF_BUSCA_USUARIOS_CONVENIO_TODOS = New N_IRIS_WEBF_BUSCA_USUARIOS_CONVENIO_TODOS

        data_usu = NN_usu.IRIS_WEBF_BUSCA_USUARIOS_CONVENIO_TODOS()

        If (data_usu.Count > 0) Then
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_usu, str_Builder)
            datas = str_Builder.ToString

            Return datas
        Else
            datas = "null"
            End If

        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_USUARIOS_CONVENIO_POR_ID(ByVal ID_USU As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_usu As List(Of E_IRIS_WEBF_BUSCA_USUARIOS_CONVENIO_POR_ID)
        Dim NN_usu As N_IRIS_WEBF_BUSCA_USUARIOS_CONVENIO_POR_ID = New N_IRIS_WEBF_BUSCA_USUARIOS_CONVENIO_POR_ID

        data_usu = NN_usu.IRIS_WEBF_BUSCA_USUARIOS_CONVENIO_POR_ID(ID_USU)
        If (data_usu.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_usu, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If

        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_UPDATE_USUARIOS_CONVENIO(ByVal ID_USU As Integer,
                                                ByVal USU_CONV_NIC As String,
                                                ByVal USU_CONV_PASS As String,
                                                ByVal USU_CONV_NOMBRE As String,
                                                ByVal USU_CONV_APELLIDO As String,
                                                ByVal USU_RUT As String,
                                                ByVal USU_DIR As String,
                                                ByVal USU_FONO As String,
                                                ByVal USU_MOVIL As String,
                                                ByVal USU_EMAIL As String,
                                                ByVal ID_ESTADO As Integer,
                                                ByVal ID_LAB As Integer,
                                                ByVal ID_PREVE As Integer,
                                                ByVal ID_PREVE2 As Integer,
                                                ByVal ID_PROCEDENCIA As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim update_USU As Integer = 0
        Dim NN_usu As N_IRIS_WEBF_UPDATE_USUARIOS_CONVENIO = New N_IRIS_WEBF_UPDATE_USUARIOS_CONVENIO

        update_USU = NN_usu.IRIS_WEBF_UPDATE_USUARIOS_CONVENIO(ID_USU,
                                                          USU_CONV_NIC,
                                                          USU_CONV_PASS,
                                                          USU_CONV_NOMBRE,
                                                          USU_CONV_APELLIDO,
                                                          USU_RUT,
                                                          USU_DIR,
                                                          USU_FONO,
                                                          USU_MOVIL,
                                                          USU_EMAIL,
                                                          ID_ESTADO,
                                                          ID_LAB,
                                                          ID_PREVE,
                                                          ID_PREVE2,
                                                          ID_PROCEDENCIA)
        If (update_USU > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(update_USU, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If

        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_GRABA_USUARIOS_CONVENIO(ByVal ID_USU As Integer,
                                            ByVal USU_CONV_NIC As String,
                                            ByVal USU_CONV_PASS As String,
                                            ByVal USU_CONV_NOMBRE As String,
                                            ByVal USU_CONV_APELLIDO As String,
                                            ByVal USU_RUT As String,
                                            ByVal USU_DIR As String,
                                            ByVal USU_FONO As String,
                                            ByVal USU_MOVIL As String,
                                            ByVal USU_EMAIL As String,
                                            ByVal ID_ESTADO As Integer,
                                            ByVal ID_LAB As Integer,
                                            ByVal ID_PREVE As Integer,
                                            ByVal ID_PREVE2 As Integer,
                                            ByVal ID_PROCEDENCIA As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim update_USU As Integer = 0
        Dim NN_usu As N_IRIS_WEBF_GRABA_USUARIOS_CONVENIO = New N_IRIS_WEBF_GRABA_USUARIOS_CONVENIO

        update_USU = NN_usu.IRIS_WEBF_GRABA_USUARIOS_CONVENIO(ID_USU,
                                                          USU_CONV_NIC,
                                                          USU_CONV_PASS,
                                                          USU_CONV_NOMBRE,
                                                          USU_CONV_APELLIDO,
                                                          USU_RUT,
                                                          USU_DIR,
                                                          USU_FONO,
                                                          USU_MOVIL,
                                                          USU_EMAIL,
                                                          ID_ESTADO,
                                                          ID_LAB,
                                                          ID_PREVE,
                                                          ID_PREVE2,
                                                          ID_PROCEDENCIA)
        If (update_USU > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(update_USU, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If

        Return datas
    End Function
End Class