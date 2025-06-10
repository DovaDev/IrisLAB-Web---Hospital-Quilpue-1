Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_AGRUPA
    Dim DD_Data As D_IRIS_WEBF_BUSCA_AGRUPA
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_AGRUPA
    End Sub
    Function IRIS_WEBF_BUSCA_AGRUPA() As List(Of E_IRIS_WEBF_BUSCA_AGRUPA)
        Return DD_Data.IRIS_WEBF_BUSCA_AGRUPA()
    End Function
End Class
