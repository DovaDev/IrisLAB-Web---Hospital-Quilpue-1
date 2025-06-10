Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_BUSCA_CARGO
    Dim DD_Data As D_IRIS_WEBF_BUSCA_CARGO
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_CARGO
    End Sub
    Function IRIS_WEBF_BUSCA_CARGO() As List(Of E_IRIS_WEBF_BUSCA_CARGO)
        Return DD_Data.IRIS_WEBF_BUSCA_CARGO()
    End Function
End Class
