'Importar Capas
Imports System.Collections.Generic
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_GENERO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_GENERO
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_GENERO
    End Sub
    Function IRIS_WEBF_BUSCA_GENERO() As List(Of E_IRIS_WEBF_BUSCA_GENERO)
        Return DD_Data.IRIS_WEBF_BUSCA_GENERO()
    End Function

End Class
