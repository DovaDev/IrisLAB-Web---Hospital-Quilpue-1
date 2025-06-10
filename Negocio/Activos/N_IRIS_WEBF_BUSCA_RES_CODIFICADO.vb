Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_BUSCA_RES_CODIFICADO
    Dim DD_Data As D_IRIS_WEBF_BUSCA_RES_CODIFICADO
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_RES_CODIFICADO
    End Sub
    Function IRIS_WEBF_BUSCA_RES_CODIFICADO() As List(Of E_IRIS_WEBF_BUSCA_RES_CODIFICADO)
        Return DD_Data.IRIS_WEBF_BUSCA_RES_CODIFICADO()
    End Function
End Class
