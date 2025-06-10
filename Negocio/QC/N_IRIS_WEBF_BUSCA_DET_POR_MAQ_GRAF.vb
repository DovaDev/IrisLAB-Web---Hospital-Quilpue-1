Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF
    End Sub
    Function IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF(ByVal DESDE As String, ByVal HASTA As String, ByVal IRIS_LNK_MAQ_ID As Long, ByVal ID_PRUEBA As Long) As List(Of E_IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF)
        Return DD_Data.IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF(DESDE, HASTA, IRIS_LNK_MAQ_ID, ID_PRUEBA)
    End Function
    Function IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF_MM(ByVal DESDE As String, ByVal HASTA As String, ByVal IRIS_LNK_I_ID As Long, ByVal IRIS_LNK_MAQ_ID As Long, ByVal CANAL As String) As List(Of E_IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF)
        Return DD_Data.IRIS_WEBF_BUSCA_DET_POR_MAQ_GRAF_MM(DESDE, HASTA, IRIS_LNK_I_ID, IRIS_LNK_MAQ_ID, CANAL)
    End Function
End Class
