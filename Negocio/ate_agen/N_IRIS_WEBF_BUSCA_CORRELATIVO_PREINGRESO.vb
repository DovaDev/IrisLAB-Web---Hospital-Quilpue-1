'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO
    End Sub
    Function IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO() As Integer
        Return DD_Data.IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO()
    End Function
End Class
