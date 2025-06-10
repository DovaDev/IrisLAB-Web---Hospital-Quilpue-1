'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_ELIMINA_RECEPCION_ETIQUETA_2_ENVIO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_ELIMINA_RECEPCION_ETIQUETA_2_ENVIO

    Sub New()
        DD_Data = New D_IRIS_WEBF_ELIMINA_RECEPCION_ETIQUETA_2_ENVIO
    End Sub

    Function IRIS_WEBF_ELIMINA_RECEPCION_ETIQUETA_2_ENVIO(ByVal NUM_ETI As Integer, ByVal NUM_CURVA As String) As Integer
        Return DD_Data.IRIS_WEBF_ELIMINA_RECEPCION_ETIQUETA_2_ENVIO(NUM_ETI, NUM_CURVA)

    End Function
End Class
