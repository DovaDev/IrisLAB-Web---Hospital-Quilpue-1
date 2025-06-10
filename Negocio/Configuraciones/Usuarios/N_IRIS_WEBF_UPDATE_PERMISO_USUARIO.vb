'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_UPDATE_PERMISO_USUARIO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_PERMISO_USUARIO
    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_PERMISO_USUARIO
    End Sub
    Function IRIS_WEBF_UPDATE_PERMISO_USUARIO(ByVal ID_PU As Integer, ByVal PU_COD As String, ByVal PU_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_PERMISO_USUARIO(ID_PU, PU_COD, PU_DES, ID_ESTADO)
    End Function
End Class
