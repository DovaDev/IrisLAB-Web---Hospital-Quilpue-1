Imports Entidades
Imports Datos
Public Class N_IRIS_QC_BUSCA_LOTE_NIVEL_SIN_REL
    Dim DD_Data As D_IRIS_QC_BUSCA_LOTE_NIVEL_SIN_REL
    Sub New()
        DD_Data = New D_IRIS_QC_BUSCA_LOTE_NIVEL_SIN_REL
    End Sub
    Function IRIS_QC_BUSCA_LOTE_NIVEL_SIN_REL() As List(Of E_IRIS_QC_BUSCA_LOTE_NIVEL_SIN_REL)
        Return DD_Data.IRIS_QC_BUSCA_LOTE_NIVEL_SIN_REL()
    End Function
End Class
