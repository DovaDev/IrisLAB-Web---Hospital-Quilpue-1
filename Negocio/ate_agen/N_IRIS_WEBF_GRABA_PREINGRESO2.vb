'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_GRABA_PREINGRESO2
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_PREINGRESO2
    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_PREINGRESO2
    End Sub
    Function IRIS_WEBF_GRABA_PREINGRESO2(ByVal ATE_NUM As String,
                                         ByVal ID_PACIENTE As Integer,
                                         ByVal ID_USUARIO As Integer,
                                         ByVal ATE_FUR As Date,
                                         ByVal ID_PROCE As Integer,
                                         ByVal ID_ORDEN As Integer,
                                         ByVal ID_TP_PACI As Integer,
                                         ByVal ID_DOCTOR As Integer,
                                         ByVal ID_PREVE As Integer,
                                         ByVal ID_LOCAL As Integer,
                                         ByVal ID_ESTADO As Integer,
                                         ByVal ATE_OBS As String,
                                         ByVal ATE_CAMA As String,
                                         ByVal ATE_AÑO As Integer,
                                         ByVal ATE_MES As Integer,
                                         ByVal ATE_DIA As Integer,
                                         ByVal ATE_TOTAL As Integer,
                                         ByVal ATE_TOTAL_PREVI As Integer,
                                         ByVal ATE_TOTAL_COPA As Integer,
                                         ByVal PREI_FECHA_PRE As Date) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_PREINGRESO2(ATE_NUM, ID_PACIENTE, ID_USUARIO, ATE_FUR, ID_PROCE, ID_ORDEN, ID_TP_PACI, ID_DOCTOR, ID_PREVE, ID_LOCAL, ID_ESTADO, ATE_OBS, ATE_CAMA, ATE_AÑO, ATE_MES, ATE_DIA, ATE_TOTAL, ATE_TOTAL_PREVI, ATE_TOTAL_COPA, PREI_FECHA_PRE)
    End Function
End Class