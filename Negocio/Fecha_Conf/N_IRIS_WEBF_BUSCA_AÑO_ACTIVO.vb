Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_BUSCA_AÑO_ACTIVO
    Private DD_Data As D_IRIS_WEBF_BUSCA_AÑO_ACTIVO
    Public Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_AÑO_ACTIVO
    End Sub
    Function IRIS_WEBF_BUSCA_AÑO_ACTIVO() As List(Of E_IRIS_WEBF_BUSCA_AÑO_ACTIVO)
        Return DD_Data.D_IRIS_WEBF_BUSCA_AÑO_ACTIVO()
    End Function
End Class
