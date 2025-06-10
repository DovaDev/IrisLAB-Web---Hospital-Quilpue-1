Imports Entidades
Imports Datos
Public Class N_IRIS_UPDATE_QC_REL_ADL
    Dim DD_Data As D_IRIS_UPDATE_QC_REL_ADL
    Sub New()
        DD_Data = New D_IRIS_UPDATE_QC_REL_ADL
    End Sub
    Function IRIS_UPDATE_QC_REL_ADL(ByVal ID_REL_ADL As Long) As Integer
        Return DD_Data.IRIS_UPDATE_QC_REL_ADL(ID_REL_ADL)
    End Function
End Class
