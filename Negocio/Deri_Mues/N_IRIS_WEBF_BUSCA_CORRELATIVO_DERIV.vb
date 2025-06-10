'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_CORRELATIVO_DERIV
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_CORRELATIVO_DERIV

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_CORRELATIVO_DERIV
    End Sub

    Function IRIS_WEBF_BUSCA_CORRELATIVO_DERIV() As List(Of E_IRIS_WEBF_BUSCA_CORRELATIVO_DERIV)
        Return DD_Data.IRIS_WEBF_BUSCA_CORRELATIVO_DERIV()
    End Function
End Class
