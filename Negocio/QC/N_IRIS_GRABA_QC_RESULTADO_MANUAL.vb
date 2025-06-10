Imports Entidades
Imports Datos
Public Class N_IRIS_GRABA_QC_RESULTADO_MANUAL
    Dim DD_Data As D_IRIS_GRABA_QC_RESULTADO_MANUAL
    Sub New()
        DD_Data = New D_IRIS_GRABA_QC_RESULTADO_MANUAL
    End Sub
    Function IRIS_GRABA_QC_RESULTADO_MANUAL(ByVal ID_ANA As Long,
                                                          ByVal ID_LOTE As Long,
                                                          ByVal ID_DET As Long,
                                                          ByVal FECHA As String,
                                                          ByVal ID_TP_ACCION As Long,
                                                          ByVal RESUL As String,
                                                          ByVal COMENTARIO As String) As Integer
        Return DD_Data.IRIS_GRABA_QC_RESULTADO_MANUAL(ID_ANA, ID_LOTE, ID_DET, FECHA, ID_TP_ACCION, RESUL, COMENTARIO)
    End Function
End Class
