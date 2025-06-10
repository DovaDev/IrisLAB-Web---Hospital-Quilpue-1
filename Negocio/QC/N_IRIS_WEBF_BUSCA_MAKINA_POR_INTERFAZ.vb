Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_BUSCA_MAKINA_POR_INTERFAZ
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_MAKINA_POR_INTERFAZ
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_MAKINA_POR_INTERFAZ
    End Sub
    Function IRIS_WEBF_BUSCA_MAKINA_POR_INTERFAZ(ByVal IRIS_LNK_I_ID As Long) As List(Of E_IRIS_WEBF_BUSCA_MAKINA_POR_INTERFAZ)
        Return DD_Data.IRIS_WEBF_BUSCA_MAKINA_POR_INTERFAZ(IRIS_LNK_I_ID)
    End Function
End Class
