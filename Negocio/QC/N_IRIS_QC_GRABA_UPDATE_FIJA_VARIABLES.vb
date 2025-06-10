Imports Entidades
Imports Datos
Public Class N_IRIS_QC_GRABA_UPDATE_FIJA_VARIABLES
    Dim DD_Data As D_IRIS_QC_GRABA_UPDATE_FIJA_VARIABLES
    Sub New()
        DD_Data = New D_IRIS_QC_GRABA_UPDATE_FIJA_VARIABLES
    End Sub
    Function IRIS_QC_GRABA_HIST_FIJA_VARIABLES(ByVal ID_ANA As Long,
                                                ByVal ID_LOTE As Long,
                                                ByVal ID_DET As Long,
                                                ByVal F_LI As String,
                                                ByVal F_LS As String,
                                                ByVal F_ME As String,
                                                ByVal F_DE As String,
                                                ByVal F_CV As String,
                                                ByVal F_N As String) As Integer
        Return DD_Data.IRIS_QC_GRABA_HIST_FIJA_VARIABLES(ID_ANA, ID_LOTE, ID_DET, F_LI, F_LS, F_ME, F_DE, F_CV, F_N)
    End Function
    Function IRIS_QC_UPDATE_FIJA_VARIABLES(ByVal ID_ANA As Long,
                                                ByVal ID_LOTE As Long,
                                                ByVal ID_DET As Long,
                                                ByVal V_LI As String,
                                                ByVal V_LS As String,
                                                ByVal V_ME As String,
                                                ByVal V_DE As String,
                                                ByVal V_CV As String,
                                                ByVal V_N As String) As Integer
        Return DD_Data.IRIS_QC_UPDATE_FIJA_VARIABLES(ID_ANA, ID_LOTE, ID_DET, V_LI, V_LS, V_ME, V_DE, V_CV, V_N)
    End Function
End Class
