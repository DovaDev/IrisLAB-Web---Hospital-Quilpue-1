Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_BUSCA_REL_LAB_SECCION
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_REL_LAB_SECCION
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_REL_LAB_SECCION
    End Sub
    Function IRIS_WEBF_BUSCA_REL_LAB_SECCION() As List(Of E_IRIS_WEBF_BUSCA_REL_LAB_SECCION)
        Return DD_Data.IRIS_WEBF_BUSCA_REL_LAB_SECCION()
    End Function
End Class
