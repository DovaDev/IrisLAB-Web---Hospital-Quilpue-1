Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_BUSCA_DET_POR_MAKINA
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_DET_POR_MAKINA
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_DET_POR_MAKINA
    End Sub
    Function IRIS_WEBF_BUSCA_DET_POR_MAKINA(ByVal IRIS_LNK_MAQ_ID As Long) As List(Of E_IRIS_WEBF_BUSCA_DET_POR_MAKINA)
        Return DD_Data.IRIS_WEBF_BUSCA_DET_POR_MAKINA(IRIS_LNK_MAQ_ID)
    End Function
    Function IRIS_WEBF_BUSCA_DET_POR_MAKINA_MM(ByVal IRIS_LNK_MAQ_ID As Long, ByVal IRIS_LNK_I_ID As Long) As List(Of E_IRIS_WEBF_BUSCA_CANAL_MAQ)
        Return DD_Data.IRIS_WEBF_BUSCA_DET_POR_MAKINA_MM(IRIS_LNK_MAQ_ID, IRIS_LNK_I_ID)
    End Function
End Class
