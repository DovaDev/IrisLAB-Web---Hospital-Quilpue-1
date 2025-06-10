Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_AREA_TRABAJO
    Dim DD_Data As D_IRIS_WEBF_BUSCA_AREA_TRABAJO
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_AREA_TRABAJO
    End Sub
    Function IRIS_WEBF_BUSCA_AREA_TRABAJO() As List(Of E_IRIS_WEBF_BUSCA_AREA_TRABAJO)
        Return DD_Data.IRIS_WEBF_BUSCA_AREA_TRABAJO()
    End Function
End Class
