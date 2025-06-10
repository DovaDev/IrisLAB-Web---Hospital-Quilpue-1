'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_CIUDAD
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_CIUDAD
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_CIUDAD
    End Sub
    Function IRIS_WEBF_BUSCA_CIUDAD() As List(Of E_IRIS_WEBF_BUSCA_CIUDAD)
        Return DD_Data.IRIS_WEBF_BUSCA_CIUDAD()
    End Function
End Class