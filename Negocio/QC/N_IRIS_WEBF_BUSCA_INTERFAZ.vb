Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_BUSCA_INTERFAZ
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_INTERFAZ
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_INTERFAZ
    End Sub
    Function IRIS_WEBF_BUSCA_INTERFAZ() As List(Of E_IRIS_WEBF_BUSCA_INTERFAZ)
        Return DD_Data.IRIS_WEBF_BUSCA_INTERFAZ()
    End Function
End Class
