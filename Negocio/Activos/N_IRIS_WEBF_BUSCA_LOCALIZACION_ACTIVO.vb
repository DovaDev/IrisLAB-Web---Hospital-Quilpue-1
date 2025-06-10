'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_LOCALIZACION_ACTIVO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_LOCALIZACION_ACTIVO
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_LOCALIZACION_ACTIVO
    End Sub
    Function IRIS_WEBF_BUSCA_LOCALIZACION_ACTIVO() As List(Of E_IRIS_WEBF_BUSCA_LOCALIZACION_ACTIVO)
        Return DD_Data.IRIS_WEBF_BUSCA_LOCALIZACION_ACTIVO()
    End Function
End Class