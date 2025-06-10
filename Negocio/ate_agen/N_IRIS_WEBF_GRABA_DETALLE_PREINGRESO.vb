'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_GRABA_DETALLE_PREINGRESO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_DETALLE_PREINGRESO
    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_DETALLE_PREINGRESO
    End Sub
    Function IRIS_WEBF_GRABA_DETALLE_PREINGRESO(ByVal ID_ATE As Integer,
                                                ByVal ID_USUARIO As Integer,
                                                ByVal ID_CF As Integer,
                                                ByVal ID_PER As Integer,
                                                ByVal ID_TP_PAGO As Integer,
                                                ByVal ATE_DET_DOC As Integer,
                                                ByVal ATE_DET_V_PREVI As Integer,
                                                ByVal ATE_DET_V_PAGADO As Integer,
                                                ByVal ATE_DET_V_CCOPAGO As Integer,
                                                Optional ByVal HO_CC As String = "0") As Integer
        Return DD_Data.IRIS_WEBF_GRABA_DETALLE_PREINGRESO(ID_ATE, ID_USUARIO, ID_CF, ID_PER, ID_TP_PAGO, ATE_DET_DOC, ATE_DET_V_PREVI, ATE_DET_V_PAGADO, ATE_DET_V_CCOPAGO, HO_CC)
    End Function
End Class