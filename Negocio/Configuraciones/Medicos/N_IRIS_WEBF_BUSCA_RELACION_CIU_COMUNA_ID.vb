Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA_ID

    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA_ID
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA_ID
    End Sub
    Function IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA_ID() As List(Of E_IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA)
        Return DD_Data.IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA_ID()
    End Function
End Class
