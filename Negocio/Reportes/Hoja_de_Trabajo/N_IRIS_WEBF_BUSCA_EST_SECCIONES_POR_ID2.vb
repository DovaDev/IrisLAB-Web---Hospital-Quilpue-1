Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_EST_SECCIONES_POR_ID2

    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_EST_SECCIONES_POR_ID2

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_EST_SECCIONES_POR_ID2
    End Sub

    Function IRIS_WEBF_BUSCA_EST_SECCIONES_POR_ID2(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_REL As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_SECCIONES_POR_RANGO_NUM)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_SECCIONES_POR_ID2(DESDE, HASTA, ID_REL)
    End Function
End Class
