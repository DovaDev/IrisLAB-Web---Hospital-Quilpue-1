Imports Entidades
Imports Negocio
Public Class Edita_Notificaciones
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()>
    Public Shared Function Busca_Notif_Edita(ByVal TIPO As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_NOTIF_EDITA)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_BUSCA_NOTIF_EDITA
        Dim Data_Estado_Mant As New List(Of E_IRIS_WEBF_CMVM_BUSCA_NOTIF_EDITA)

        Data_Estado_Mant = NN_Estado_Mant.IRIS_WEBF_CMVM_BUSCA_NOTIF_EDITA(TIPO)
        If (Data_Estado_Mant.Count > 0) Then

            Return Data_Estado_Mant
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Update_Notif_Edita(ByVal ID_NOTIF As Long,
                                              ByVal TIPO As Integer,
                                              ByVal FECHA_D As String,
                                              ByVal FECHA_H As String,
                                              ByVal PERMA As Integer,
                                              ByVal MENSAJE As String,
                                              ByVal ESTADO As Integer) As Integer
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Estado_Mant As New N_IRIS_WEBF_CMVM_UPDATE_NOTIF_EDITA
        Dim Data_Estado_Mant As Integer

        Data_Estado_Mant = NN_Estado_Mant.IRIS_WEBF_CMVM_UPDATE_NOTIF_EDITA(ID_NOTIF, TIPO, FECHA_D, FECHA_H, PERMA, MENSAJE, ESTADO)
        If (Data_Estado_Mant <> Nothing) Then
            Return Data_Estado_Mant
        Else
            Return Nothing
        End If
    End Function
End Class