Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA
    End Sub
    Function IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_CF As Integer, ByVal ID_USU As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA(DESDE, HASTA, ID_CF, ID_USU)
    End Function
    Function IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA_3(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_CF As Integer, ByVal ID_USU As Integer, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA_3(DESDE, HASTA, ID_CF, ID_USU, ID_PROC)
    End Function
End Class
