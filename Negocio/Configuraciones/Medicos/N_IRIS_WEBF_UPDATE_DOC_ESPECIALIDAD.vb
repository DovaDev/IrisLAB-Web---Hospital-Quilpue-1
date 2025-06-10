'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_UPDATE_DOC_ESPECIALIDAD
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_DOC_ESPECIALIDAD
    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_DOC_ESPECIALIDAD
    End Sub
    Function IRIS_WEBF_UPDATE_DOC_ESPECIALIDAD(ByVal ID_ESP As Integer, ByVal ESP_COD As String, ByVal ESP_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_DOC_ESPECIALIDAD(ID_ESP, ESP_COD, ESP_DES, ID_ESTADO)
    End Function
End Class
