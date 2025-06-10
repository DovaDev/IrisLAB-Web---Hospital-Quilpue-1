Imports Entidades
Imports Datos
Public Class N_IRIS_QC_BUSCA_ANALITO
    Dim DD_Data As D_IRIS_QC_BUSCA_ANALITO
    Sub New()
        DD_Data = New D_IRIS_QC_BUSCA_ANALITO
    End Sub
    Function IRIS_QC_BUSCA_ANALITO() As List(Of E_IRIS_QC_BUSCA_ANALITO)
        Return DD_Data.IRIS_QC_BUSCA_ANALITO()
    End Function
End Class
