'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_GRABA_DOC_ESPECIALIDAD
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_DOC_ESPECIALIDAD
    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_DOC_ESPECIALIDAD
    End Sub
    Function IRIS_WEBF_GRABA_DOC_ESPECIALIDAD(ByVal ESP_COD As String, ByVal ESP_DES As String, ByVal ID_ESTADO As String) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_DOC_ESPECIALIDAD(ESP_COD, ESP_DES, ID_ESTADO)
    End Function
End Class
