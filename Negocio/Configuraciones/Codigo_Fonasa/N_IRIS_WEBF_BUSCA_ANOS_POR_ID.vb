Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_BUSCA_ANOS_POR_ID
    Private DD_Data As D_IRIS_WEBF_BUSCA_ANOS_POR_ID
    Public Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_ANOS_POR_ID
    End Sub
    Function IRIS_WEBF_BUSCA_ANOS_POR_ID(ByVal ANO As String) As List(Of E_IRIS_WEBF_BUSCA_ANOS_POR_ID)
        Return DD_Data.D_IRIS_WEBF_BUSCA_ANOS_POR_ID(ANO)
    End Function
End Class
