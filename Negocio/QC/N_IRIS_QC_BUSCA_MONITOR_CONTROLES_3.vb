Imports Entidades
Imports Datos
Public Class N_IRIS_QC_BUSCA_MONITOR_CONTROLES_3
    Dim DD_Data As D_IRIS_QC_BUSCA_MONITOR_CONTROLES_3
    Sub New()
        DD_Data = New D_IRIS_QC_BUSCA_MONITOR_CONTROLES_3
    End Sub
    Function IRIS_QC_BUSCA_MONITOR_CONTROLES_3(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_ANA As Long) As List(Of E_IRIS_QC_BUSCA_MONITOR_CONTROLES_3)
        Return DD_Data.IRIS_QC_BUSCA_MONITOR_CONTROLES_3(DESDE, HASTA, ID_ANA)
    End Function
End Class

