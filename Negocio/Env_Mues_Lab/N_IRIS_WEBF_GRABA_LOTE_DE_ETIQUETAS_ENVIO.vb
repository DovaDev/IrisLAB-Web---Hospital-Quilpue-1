﻿'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS_ENVIO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS_ENVIO

    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS_ENVIO
    End Sub

    Function IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS_ENVIO(ByVal NUM_LOTE As Integer, ByVal ID_USUARIO As Integer) As List(Of E_IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS_ENVIO)
        Return DD_Data.IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS_ENVIO(NUM_LOTE, ID_USUARIO)

    End Function
End Class
