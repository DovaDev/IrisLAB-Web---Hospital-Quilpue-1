Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_BUSCA_RECIPIENTE
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_RECIPIENTE
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_RECIPIENTE
    End Sub
    Function IRIS_WEBF_BUSCA_RECIPIENTE() As List(Of E_IRIS_WEBF_BUSCA_RECIPIENTE)
        Return DD_Data.IRIS_WEBF_BUSCA_RECIPIENTE()
    End Function
End Class
