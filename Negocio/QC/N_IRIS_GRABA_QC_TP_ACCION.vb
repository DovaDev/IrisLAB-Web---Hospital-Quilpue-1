Imports Entidades
Imports Datos
Public Class N_IRIS_GRABA_QC_TP_ACCION

    Dim DD_Data As D_IRIS_GRABA_QC_TP_ACCION
    Sub New()
        DD_Data = New D_IRIS_GRABA_QC_TP_ACCION
    End Sub
    Function IRIS_GRABA_QC_TP_ACCION(ByVal AREA_COD As String,
                                     ByVal AREA_DES As String,
                                     ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_GRABA_QC_TP_ACCION(AREA_COD, AREA_DES, ID_ESTADO)
    End Function
End Class