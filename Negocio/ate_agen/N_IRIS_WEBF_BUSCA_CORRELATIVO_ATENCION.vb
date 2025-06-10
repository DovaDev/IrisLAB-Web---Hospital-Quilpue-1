'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_CORRELATIVO_ATENCION
    Dim DD_Data As D_IRIS_WEBF_BUSCA_CORRELATIVO_ATENCION
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_CORRELATIVO_ATENCION
    End Sub
    Function IRIS_WEBF_BUSCA_CORRELATIVO_ATENCION() As Integer
        Return DD_Data.IRIS_WEBF_BUSCA_CORRELATIVO_ATENCION()
    End Function
End Class
