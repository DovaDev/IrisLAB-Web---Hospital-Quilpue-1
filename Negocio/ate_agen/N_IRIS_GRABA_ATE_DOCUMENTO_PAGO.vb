'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_GRABA_ATE_DOCUMENTO_PAGO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_GRABA_ATE_DOCUMENTO_PAGO
    Sub New()
        DD_Data = New D_IRIS_GRABA_ATE_DOCUMENTO_PAGO
    End Sub
    Function IRIS_GRABA_ATE_DOCUMENTO_PAGO(ByVal ID_ATE As Integer, ByVal NUM As Integer, ByVal ID_USU As Integer) As Integer
        Return DD_Data.IRIS_GRABA_ATE_DOCUMENTO_PAGO(ID_ATE, NUM, ID_USU)
    End Function
End Class