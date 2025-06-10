'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS

    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS
    End Sub

    Function IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS(ByVal NUM_LOTE As Integer, ByVal ID_USUARIO As Integer) As List(Of E_IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS)
        Return DD_Data.IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS(NUM_LOTE, ID_USUARIO)

    End Function
End Class
