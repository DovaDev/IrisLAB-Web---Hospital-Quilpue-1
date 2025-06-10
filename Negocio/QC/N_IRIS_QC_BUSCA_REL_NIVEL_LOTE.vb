Imports Entidades
Imports Datos
Public Class N_IRIS_QC_BUSCA_REL_NIVEL_LOTE
    Dim DD_Data As D_IRIS_QC_BUSCA_REL_NIVEL_LOTE
    Sub New()
        DD_Data = New D_IRIS_QC_BUSCA_REL_NIVEL_LOTE
    End Sub
    Function IRIS_QC_BUSCA_REL_NIVEL_LOTE() As List(Of E_IRIS_QC_BUSCA_REL_NIVEL_LOTE)
        Return DD_Data.IRIS_QC_BUSCA_REL_NIVEL_LOTE()
    End Function
End Class
