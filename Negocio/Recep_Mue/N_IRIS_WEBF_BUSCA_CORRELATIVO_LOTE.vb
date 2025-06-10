'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_CORRELATIVO_LOTE
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_CORRELATIVO_LOTE

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_CORRELATIVO_LOTE
    End Sub

    Function IRIS_WEBF_BUSCA_CORRELATIVO_LOTE() As List(Of E_IRIS_WEBF_BUSCA_CORRELATIVO_LOTE)
        Return DD_Data.IRIS_WEBF_BUSCA_CORRELATIVO_LOTE()

    End Function
End Class