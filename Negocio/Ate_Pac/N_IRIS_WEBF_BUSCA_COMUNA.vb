'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_COMUNA
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_COMUNA
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_COMUNA
    End Sub
    Function IRIS_WEBF_BUSCA_COMUNA() As List(Of E_IRIS_WEBF_BUSCA_COMUNA)
        Return DD_Data.IRIS_WEBF_BUSCA_COMUNA()
    End Function
End Class