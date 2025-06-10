Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_MEDICO

    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_MEDICO
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_MEDICO
    End Sub
    Function IRIS_WEBF_BUSCA_MEDICO() As List(Of E_IRIS_WEBF_BUSCA_MEDICO)
        Return DD_Data.IRIS_WEBF_BUSCA_MEDICO()
    End Function
End Class
