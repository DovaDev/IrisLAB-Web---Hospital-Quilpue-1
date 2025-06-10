'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_EST_SECCIONES_POR_RANGO_NUM
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_EST_SECCIONES_POR_RANGO_NUM

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_EST_SECCIONES_POR_RANGO_NUM
    End Sub

    Function IRIS_WEBF_BUSCA_EST_SECCIONES_POR_RANGO_NUM(ByVal DESDE As Integer, ByVal HASTA As Integer, ByVal ID_REL As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_SECCIONES_POR_RANGO_NUM)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_SECCIONES_POR_RANGO_NUM(DESDE, HASTA, ID_REL)
    End Function
End Class
