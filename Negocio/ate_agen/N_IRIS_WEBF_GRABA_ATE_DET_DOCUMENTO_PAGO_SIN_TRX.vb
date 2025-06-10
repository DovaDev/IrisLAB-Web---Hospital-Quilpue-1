'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_GRABA_ATE_DET_DOCUMENTO_PAGO_SIN_TRX
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_ATE_DET_DOCUMENTO_PAGO_SIN_TRX
    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_ATE_DET_DOCUMENTO_PAGO_SIN_TRX
    End Sub
    Function IRIS_WEBF_GRABA_ATE_DET_DOCUMENTO_PAGO_SIN_TRX(ByVal ID_ATE_DOCP As Integer, ByVal ID_FP As Integer, ByVal V_TOTAL As Integer, ByVal ID_USU As Integer, ByVal V_SISTEMA As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_ATE_DET_DOCUMENTO_PAGO_SIN_TRX(ID_ATE_DOCP, ID_FP, V_TOTAL, ID_USU, V_SISTEMA)
    End Function
    Function IRIS_WEBF_GRABA_ATE_DET_DOCUMENTO_PAGO_TRX(ByVal ID_ATE_DOCP As Integer, ByVal ID_FP As Integer, ByVal V_TOTAL As Integer, ByVal ID_TRX As Integer, ByVal ID_USU As Integer, ByVal V_SISTEMA As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_ATE_DET_DOCUMENTO_PAGO_TRX(ID_ATE_DOCP, ID_FP, V_TOTAL, ID_TRX, ID_USU, V_SISTEMA)
    End Function
End Class