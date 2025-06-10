'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST
    End Sub
    Function IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST(ByVal HOT As String) As List(Of E_IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST)
        Return DD_Data.IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST(HOT)
    End Function
End Class