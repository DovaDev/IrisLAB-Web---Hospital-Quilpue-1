'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_DIAGNOSTICO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_DIAGNOSTICO
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_DIAGNOSTICO
    End Sub
    Function IRIS_WEBF_BUSCA_DIAGNOSTICO() As List(Of E_IRIS_WEBF_BUSCA_DIAGNOSTICO)
        Return DD_Data.IRIS_WEBF_BUSCA_DIAGNOSTICO()
    End Function

    Function IRIS_WEBF_BUSCA_SUBPROGRAMA() As List(Of E_IRIS_WEBF_BUSCA_SUBPROGRAMA)
        Return DD_Data.IRIS_WEBF_BUSCA_SUBPROGRAMA()
    End Function


End Class