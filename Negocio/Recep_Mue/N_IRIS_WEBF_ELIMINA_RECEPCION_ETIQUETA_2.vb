'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_ELIMINA_RECEPCION_ETIQUETA_2
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_ELIMINA_RECEPCION_ETIQUETA_2

    Sub New()
        DD_Data = New D_IRIS_WEBF_ELIMINA_RECEPCION_ETIQUETA_2
    End Sub

    Function IRIS_WEBF_ELIMINA_RECEPCION_ETIQUETA_2(ByVal NUM_ETI As Integer, ByVal NUM_CURVA As String) As Integer
        Return DD_Data.IRIS_WEBF_ELIMINA_RECEPCION_ETIQUETA_2(NUM_ETI, NUM_CURVA)

    End Function
End Class
