Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_LIS_ADM_ESTADOS
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_LIS_ADM_ESTADOS
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_LIS_ADM_ESTADOS
    End Sub
    Function IRIS_WEBF_BUSCA_LIS_ADM_ESTADOS() As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_ESTADOS)
        Return DD_Data.D_IRIS_WEBF_BUSCA_LIS_ADM_ESTADOS()
    End Function
End Class
