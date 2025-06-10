Imports Entidades
Imports Datos
Public Class N_IRIS_QC_BUSCA_TP_ACCION
    Dim DD_Data As D_IRIS_QC_BUSCA_TP_ACCION
    Sub New()
        DD_Data = New D_IRIS_QC_BUSCA_TP_ACCION
    End Sub
    Function IRIS_QC_BUSCA_TP_ACCION() As List(Of E_IRIS_QC_BUSCA_TP_ACCION)
        Return DD_Data.IRIS_QC_BUSCA_TP_ACCION()
    End Function
End Class
