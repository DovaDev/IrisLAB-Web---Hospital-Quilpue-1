Imports Entidades
Imports Datos
Public Class N_IRIS_QC_BUSCA_TP_ACCION_ACTIVAS
    Dim DD_Data As D_IRIS_QC_BUSCA_TP_ACCION_ACTIVAS
    Sub New()
        DD_Data = New D_IRIS_QC_BUSCA_TP_ACCION_ACTIVAS
    End Sub
    Function IRIS_QC_BUSCA_TP_ACCION_ACTIVAS() As List(Of E_IRIS_QC_BUSCA_TP_ACCION)
        Return DD_Data.IRIS_QC_BUSCA_TP_ACCION_ACTIVAS()
    End Function
End Class
