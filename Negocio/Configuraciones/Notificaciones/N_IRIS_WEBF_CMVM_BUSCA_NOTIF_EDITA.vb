Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_CMVM_BUSCA_NOTIF_EDITA
    Dim DD_Data As D_IRIS_WEBF_CMVM_BUSCA_NOTIF_EDITA
    Sub New()
        DD_Data = New D_IRIS_WEBF_CMVM_BUSCA_NOTIF_EDITA
    End Sub
    Function IRIS_WEBF_CMVM_BUSCA_NOTIF_EDITA(ByVal TIPO As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_NOTIF_EDITA)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_NOTIF_EDITA(TIPO)
    End Function
End Class
