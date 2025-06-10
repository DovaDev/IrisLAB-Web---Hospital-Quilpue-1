Imports Entidades
Imports Datos
Public Class N_IRIS_QC_BUSCA_SECCIONES
    Dim DD_Data As D_IRIS_QC_BUSCA_SECCIONES
    Sub New()
        DD_Data = New D_IRIS_QC_BUSCA_SECCIONES
    End Sub
    Function IRIS_QC_BUSCA_SECCIONES() As List(Of E_IRIS_QC_BUSCA_SECCIONES)
        Return DD_Data.IRIS_QC_BUSCA_SECCIONES()
    End Function
End Class
