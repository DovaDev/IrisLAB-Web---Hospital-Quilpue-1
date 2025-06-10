Imports Entidades
Imports Datos
Public Class N_IRIS_QC_BUSCA_U_MEDIDA
    Dim DD_Data As D_IRIS_QC_BUSCA_U_MEDIDA
    Sub New()
        DD_Data = New D_IRIS_QC_BUSCA_U_MEDIDA
    End Sub
    Function IRIS_QC_BUSCA_U_MEDIDA() As List(Of E_IRIS_QC_BUSCA_U_MEDIDA)
        Return DD_Data.IRIS_QC_BUSCA_U_MEDIDA()
    End Function
End Class
