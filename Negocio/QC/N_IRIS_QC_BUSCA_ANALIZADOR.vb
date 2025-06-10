Imports Entidades
Imports Datos
Public Class N_IRIS_QC_BUSCA_ANALIZADOR
    Dim DD_Data As D_IRIS_QC_BUSCA_ANALIZADOR
    Sub New()
        DD_Data = New D_IRIS_QC_BUSCA_ANALIZADOR
    End Sub
    Function IRIS_QC_BUSCA_ANALIZADOR() As List(Of E_IRIS_QC_BUSCA_ANALIZADOR)
        Return DD_Data.IRIS_QC_BUSCA_ANALIZADOR()
    End Function
End Class
