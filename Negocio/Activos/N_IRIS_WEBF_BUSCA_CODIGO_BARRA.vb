Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_CODIGO_BARRA
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_CODIGO_BARRA
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_CODIGO_BARRA
    End Sub
    Function IRIS_WEBF_BUSCA_CODIGO_BARRA() As List(Of E_IRIS_WEBF_BUSCA_CODIGO_BARRA)
        Return DD_Data.IRIS_WEBF_BUSCA_CODIGO_BARRA()
    End Function
End Class
