'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2
    End Sub

    Function IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2(ByVal NUMLOTE As Integer) As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2)
        Return DD_Data.IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2(NUMLOTE)

    End Function
End Class