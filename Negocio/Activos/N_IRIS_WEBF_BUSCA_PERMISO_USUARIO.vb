'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_PERMISO_USUARIO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_PERMISO_USUARIO
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_PERMISO_USUARIO
    End Sub
    Function IRIS_WEBF_BUSCA_PERMISO_USUARIO() As List(Of E_IRIS_WEBF_BUSCA_PERMISO_USUARIO)
        Return DD_Data.IRIS_WEBF_BUSCA_PERMISO_USUARIO()
    End Function
End Class
