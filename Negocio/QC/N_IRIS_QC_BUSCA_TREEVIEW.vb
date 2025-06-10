Imports Entidades
Imports Datos
Public Class N_IRIS_QC_BUSCA_TREEVIEW
    Dim DD_Data As D_IRIS_QC_BUSCA_TREEVIEW
    Sub New()
        DD_Data = New D_IRIS_QC_BUSCA_TREEVIEW
    End Sub
    Function IRIS_QC_BUSCA_TREEVIEW() As List(Of E_IRIS_QC_BUSCA_TREEVIEW)
        Return DD_Data.IRIS_QC_BUSCA_TREEVIEW()
    End Function
End Class
