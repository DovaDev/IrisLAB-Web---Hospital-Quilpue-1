'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_SECTOR
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_SECTOR
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_SECTOR
    End Sub
    Function IRIS_WEBF_BUSCA_SECTOR() As List(Of E_IRIS_WEBF_BUSCA_SECTOR)
        Return DD_Data.IRIS_WEBF_BUSCA_SECTOR()
    End Function
End Class
