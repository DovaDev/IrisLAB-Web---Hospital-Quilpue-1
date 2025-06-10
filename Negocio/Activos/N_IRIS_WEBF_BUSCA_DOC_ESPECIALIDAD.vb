'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_DOC_ESPECIALIDAD
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_DOC_ESPECIALIDAD
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_DOC_ESPECIALIDAD
    End Sub
    Function IRIS_WEBF_BUSCA_DOC_ESPECIALIDAD() As List(Of E_IRIS_WEBF_BUSCA_DOC_ESPECIALIDAD)
        Return DD_Data.IRIS_WEBF_BUSCA_DOC_ESPECIALIDAD()
    End Function
End Class
