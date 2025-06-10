Imports Entidades
Imports Datos
Public Class N_IRIS_UPDATE_PARAMS_QC_REL_ADL
    Dim DD_Data As D_IRIS_UPDATE_PARAMS_QC_REL_ADL
    Sub New()
        DD_Data = New D_IRIS_UPDATE_PARAMS_QC_REL_ADL
    End Sub
    Function IRIS_UPDATE_PARAMS_QC_REL_ADL(ByVal ID_REL As Long,
                                     ByVal LI As String,
                                     ByVal LS As String,
                                     ByVal MEDIA As String,
                                     ByVal DESVIACION As String,
                                     ByVal CV As String,
                                     ByVal NUM As String) As Integer
        Return DD_Data.IRIS_UPDATE_PARAMS_QC_REL_ADL(ID_REL, LI, LS, MEDIA, DESVIACION, CV, NUM)
    End Function
End Class
