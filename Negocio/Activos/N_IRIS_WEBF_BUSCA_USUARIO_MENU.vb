Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_BUSCA_USUARIO_MENU
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_USUARIO_MENU
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_USUARIO_MENU
    End Sub
    Function IRIS_WEBF_BUSCA_USUARIO_MENU() As List(Of E_IRIS_WEBF_BUSCA_USUARIO_MENU)
        Return DD_Data.IRIS_WEBF_BUSCA_USUARIO_MENU()
    End Function
End Class
