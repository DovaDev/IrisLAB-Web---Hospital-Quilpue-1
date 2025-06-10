'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_GRABA_TRX_BONOS
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_TRX_BONOS
    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_TRX_BONOS
    End Sub
    Function IRIS_WEBF_GRABA_TRX_BONOS(ByVal ID_FP As Integer, ByVal MONTO As Integer, ByVal ID_USU As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_TRX_BONOS(ID_FP, MONTO, ID_USU)
    End Function

    Function IRIS_WEBF_GRABA_TRX_EFECTIVO(ByVal ID_FP As Integer, ByVal MONTO As Integer, ByVal ID_USU As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_TRX_EFECTIVO(ID_FP, MONTO, ID_USU)
    End Function
End Class