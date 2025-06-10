Imports Entidades
Imports Datos
Public Class N_IRIS_UPDATE_QC_ESTADO_REL_LOTE_NIVEL
    Dim DD_Data As D_IRIS_UPDATE_QC_ESTADO_REL_LOTE_NIVEL
    Sub New()
        DD_Data = New D_IRIS_UPDATE_QC_ESTADO_REL_LOTE_NIVEL
    End Sub
    Function IRIS_UPDATE_QC_ESTADO_REL_LOTE_NIVEL(ByVal ID_REL As Long,
                                     ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_UPDATE_QC_ESTADO_REL_LOTE_NIVEL(ID_REL, ID_ESTADO)
    End Function
End Class
