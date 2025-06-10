Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_BUSCA_TP_RECHAZO
    Dim DD_Data As D_IRIS_WEBF_BUSCA_TP_RECHAZO
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_TP_RECHAZO
    End Sub
    Function IRIS_WEBF_BUSCA_TP_RECHAZO() As List(Of E_IRIS_WEBF_BUSCA_TP_RECHAZO)
        Return DD_Data.IRIS_WEBF_BUSCA_TP_RECHAZO()
    End Function
End Class
