'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_TP_RESULTADO_ACTIVADO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_TP_RESULTADO_ACTIVADO
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_TP_RESULTADO_ACTIVADO
    End Sub
    Function IRIS_WEBF_BUSCA_TP_RESULTADO_ACTIVADO() As List(Of E_IRIS_WEBF_BUSCA_TP_RESULTADO_ACTIVADO)
        Return DD_Data.IRIS_WEBF_BUSCA_TP_RESULTADO_ACTIVADO()
    End Function
End Class