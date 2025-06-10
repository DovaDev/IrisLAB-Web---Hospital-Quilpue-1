'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_USUARIO_TODOS
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_USUARIO_TODOS

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_USUARIO_TODOS
    End Sub

    Function IRIS_WEBF_BUSCA_USUARIO_TODOS() As List(Of E_IRIS_WEBF_BUSCA_USUARIO_TODOS)
        Return DD_Data.IRIS_WEBF_BUSCA_USUARIO_TODOS()

    End Function
End Class