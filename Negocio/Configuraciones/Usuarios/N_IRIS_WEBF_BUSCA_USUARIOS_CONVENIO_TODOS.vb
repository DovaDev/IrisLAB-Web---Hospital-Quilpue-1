'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_USUARIOS_CONVENIO_TODOS
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_USUARIOS_CONVENIO_TODOS

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_USUARIOS_CONVENIO_TODOS
    End Sub

    Function IRIS_WEBF_BUSCA_USUARIOS_CONVENIO_TODOS() As List(Of E_IRIS_WEBF_BUSCA_USUARIOS_CONVENIO_TODOS)
        Return DD_Data.IRIS_WEBF_BUSCA_USUARIOS_CONVENIO_TODOS()

    End Function
End Class