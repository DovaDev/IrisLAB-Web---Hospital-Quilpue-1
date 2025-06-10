'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_BANCO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_BANCO
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_BANCO
    End Sub
    Function IRIS_WEBF_BUSCA_BANCO() As List(Of E_IRIS_WEBF_BUSCA_BANCO)
        Return DD_Data.IRIS_WEBF_BUSCA_BANCO()
    End Function


    Function IRIS_WEBF_BUSCA_PROGRAMA() As List(Of e_IRIS_WEBF_BUSCA_PROGRAMA)
        Return DD_Data.IRIS_WEBF_BUSCA_PROGRAMA()
    End Function
End Class
