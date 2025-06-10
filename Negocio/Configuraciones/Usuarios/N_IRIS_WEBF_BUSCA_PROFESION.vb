Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_BUSCA_PROFESION
    Dim DD_Data As D_IRIS_WEBF_BUSCA_PROFESION
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_PROFESION
    End Sub
    Function IRIS_WEBF_BUSCA_PROFESION() As List(Of E_IRIS_WEBF_BUSCA_PROFESION)
        Return DD_Data.IRIS_WEBF_BUSCA_PROFESION()
    End Function
End Class
