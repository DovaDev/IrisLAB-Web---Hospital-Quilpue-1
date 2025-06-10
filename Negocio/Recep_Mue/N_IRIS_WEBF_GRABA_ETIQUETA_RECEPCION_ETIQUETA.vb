'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA

    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA
    End Sub

    Function IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA(ByVal ID_ATE As Integer, ByVal NUM_ATE As Integer, ByVal CB As String, ByVal ID_USUARIO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA(ID_ATE, NUM_ATE, CB, ID_USUARIO)

    End Function
End Class
