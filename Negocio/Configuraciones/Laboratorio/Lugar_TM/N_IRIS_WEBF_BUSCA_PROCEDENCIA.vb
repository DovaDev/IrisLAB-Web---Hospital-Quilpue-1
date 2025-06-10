Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_PROCEDENCIA
    Dim DD_Data As D_IRIS_WEBF_BUSCA_PROCEDENCIA
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_PROCEDENCIA
    End Sub
    Function IRIS_WEBF_BUSCA_PROCEDENCIA() As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA)
        Return DD_Data.IRIS_WEBF_BUSCA_PROCEDENCIA()
    End Function

    Function IRIS_WEBF_BUSCA_PROCEDENCIA_2() As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA)
        Return DD_Data.IRIS_WEBF_BUSCA_PROCEDENCIA_2()
    End Function

End Class
