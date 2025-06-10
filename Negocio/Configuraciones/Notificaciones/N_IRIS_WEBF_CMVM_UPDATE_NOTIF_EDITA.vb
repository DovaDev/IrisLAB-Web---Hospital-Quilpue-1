Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_CMVM_UPDATE_NOTIF_EDITA
    Dim DD_Data As D_IRIS_WEBF_CMVM_UPDATE_NOTIF_EDITA
    Sub New()
        DD_Data = New D_IRIS_WEBF_CMVM_UPDATE_NOTIF_EDITA
    End Sub
    Function IRIS_WEBF_CMVM_UPDATE_NOTIF_EDITA(ByVal ID_NOTIF As Long,
                                              ByVal TIPO As Integer,
                                              ByVal FECHA_D As String,
                                              ByVal FECHA_H As String,
                                              ByVal PERMA As Integer,
                                              ByVal MENSAJE As String,
                                              ByVal ESTADO As Integer
                                               ) As Integer
        Return DD_Data.IRIS_WEBF_CMVM_UPDATE_NOTIF_EDITA(ID_NOTIF, TIPO, FECHA_D, FECHA_H, PERMA, MENSAJE, ESTADO)
    End Function
End Class
