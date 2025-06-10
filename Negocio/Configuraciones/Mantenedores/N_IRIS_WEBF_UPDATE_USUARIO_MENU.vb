Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_UPDATE_USUARIO_MENU
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_USUARIO_MENU
    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_USUARIO_MENU
    End Sub
    Function IRIS_WEBF_UPDATE_USUARIO_MENU(ByVal ID As Integer, ByVal ID_USU As Integer, ByVal ID_MEN As Integer, ByVal ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_USUARIO_MENU(ID, ID_USU, ID_MEN, ESTADO)
    End Function
End Class
