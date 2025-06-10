'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_CORRELATIVO_LOTE_ENVIO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_CORRELATIVO_LOTE_ENVIO

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_CORRELATIVO_LOTE_ENVIO
    End Sub

    Function IRIS_WEBF_BUSCA_CORRELATIVO_LOTE_ENVIO() As List(Of E_IRIS_WEBF_BUSCA_CORRELATIVO_LOTE_ENVIO)
        Return DD_Data.IRIS_WEBF_BUSCA_CORRELATIVO_LOTE_ENVIO()

    End Function
End Class
