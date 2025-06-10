'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_UPDATE_COMUNAS
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_COMUNAS
    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_COMUNAS
    End Sub
    Function IRIS_WEBF_UPDATE_COMUNAS(ByVal ID_COM As Integer, ByVal COM_COD As String, ByVal COM_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_COMUNAS(ID_COM, COM_COD, COM_DES, ID_ESTADO)
    End Function
End Class
