Imports Entidades
Imports Datos
Public Class N_IRIS_QC_BUSCA_NIVEL_POR_LOTE_DESC
    Dim DD_Data As D_IRIS_QC_BUSCA_NIVEL_POR_LOTE_DESC
    Sub New()
        DD_Data = New D_IRIS_QC_BUSCA_NIVEL_POR_LOTE_DESC
    End Sub
    Function IRIS_QC_BUSCA_NIVEL_POR_LOTE_DESC(ByVal LOTE_DESC As String) As Integer
        Return DD_Data.IRIS_QC_BUSCA_NIVEL_POR_LOTE_DESC(LOTE_DESC)
    End Function
End Class
