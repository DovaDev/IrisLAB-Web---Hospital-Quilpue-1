Imports Entidades
Imports Datos
Public Class N_IRIS_GRABA_QC_REL_NIVEL_LOTE
    Dim DD_Data As D_IRIS_GRABA_QC_REL_NIVEL_LOTE
    Sub New()
        DD_Data = New D_IRIS_GRABA_QC_REL_NIVEL_LOTE
    End Sub
    Function IRIS_GRABA_QC_REL_NIVEL_LOTE(ByVal N1 As Long,
                                     ByVal N2 As Long) As Integer
        Return DD_Data.IRIS_GRABA_QC_REL_NIVEL_LOTE(N1, N2)
    End Function
End Class
