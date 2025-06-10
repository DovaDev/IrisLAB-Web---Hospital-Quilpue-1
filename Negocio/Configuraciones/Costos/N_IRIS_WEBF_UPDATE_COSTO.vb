'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_UPDATE_COSTO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_COSTO
    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_COSTO
    End Sub
    Function IRIS_WEBF_UPDATE_COSTO(ByVal ID_COM As Integer, ByVal COM_COD As String, ByVal COM_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_COSTO(ID_COM, COM_COD, COM_DES, ID_ESTADO)
    End Function
End Class
