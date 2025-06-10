'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR
    End Sub
    Function IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR() As List(Of E_IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR)
        Return DD_Data.IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR()
    End Function
End Class