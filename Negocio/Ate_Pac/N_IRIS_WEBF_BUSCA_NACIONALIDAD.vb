'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_NACIONALIDAD
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_NACIONALIDAD
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_NACIONALIDAD
    End Sub
    Function IRIS_WEBF_BUSCA_NACIONALIDAD() As List(Of E_IRIS_WEBF_BUSCA_NACIONALIDAD)
        Return DD_Data.IRIS_WEBF_BUSCA_NACIONALIDAD()
    End Function
End Class