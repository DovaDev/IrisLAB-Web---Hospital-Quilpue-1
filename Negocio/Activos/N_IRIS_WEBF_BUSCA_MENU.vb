Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_BUSCA_MENU
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_MENU
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_MENU
    End Sub
    Function IRIS_WEBF_BUSCA_MENU() As List(Of E_IRIS_WEBF_BUSCA_MENU)
        Return DD_Data.IRIS_WEBF_BUSCA_MENU()
    End Function
End Class
