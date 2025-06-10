Imports Entidades
Imports Negocio
Public Class Notificaciones
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Preve() As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Estado_Mant As New N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        Dim Data_Estado_Mant As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)

        Data_Estado_Mant = NN_Estado_Mant.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()
        If (Data_Estado_Mant.Count > 0) Then

            Return Data_Estado_Mant
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_LugarTM() As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        'Declaraciones internas
        Dim NN_LugarTM As New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        Dim Data_LugarTM As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)

        Data_LugarTM = NN_LugarTM.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()
        Return Data_LugarTM
    End Function
    <Services.WebMethod()>
    Public Shared Function Call_Users() As List(Of E_IRIS_WEBF_BUSCA_USUARIO3)
        Dim NNN As New N_Usuario_Sum
        Dim List_Data As New List(Of E_IRIS_WEBF_BUSCA_USUARIO3)

        List_Data = NNN.IRIS_WEBF_BUSCA_USUARIO3()

        Return List_Data
    End Function
    <Services.WebMethod()>
    Public Shared Function Graba_Notificaciones(ByVal TIPO_MENSAJE As Integer,
                                                ByVal MENSAJE As String,
                                                ByVal FECHA_D As String,
                                                ByVal FECHA_H As String,
                                                ByVal PERMANENTE As Integer,
                                                ByVal ARR_USER() As Integer) As Integer
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Declaraciones Consulta
        Dim NN_Search As New N_IRIS_WEBF_CMVM_GRABA_NOTIFICACION_USUARIO
        Dim NN_Search2 As New N_IRIS_WEBF_CMVM_GRABA_REL_NOTIFICACION_USUARIO
        Dim Data_OUT As Integer
        Dim Data_OUT2 As Integer

        Data_OUT = NN_Search.IRIS_WEBF_CMVM_GRABA_NOTIFICACION_USUARIO(TIPO_MENSAJE, MENSAJE, FECHA_D, FECHA_H, PERMANENTE)
        If (Data_OUT > 0) Then

            For Each usr As Integer In ARR_USER
                Data_OUT2 = NN_Search2.IRIS_WEBF_CMVM_GRABA_REL_NOTIFICACION_USUARIO(Data_OUT, usr)
            Next
            Return Data_OUT2
        Else
            Return Nothing
        End If
    End Function
End Class