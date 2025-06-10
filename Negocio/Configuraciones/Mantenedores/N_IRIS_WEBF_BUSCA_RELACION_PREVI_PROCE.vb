'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_RELACION_PREVI_PROCE
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_RELACION_PREVI_PROCE

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_RELACION_PREVI_PROCE
    End Sub

    Function IRIS_WEBF_BUSCA_RELACION_PREVI_PROCE(ByVal ID_PREVE As Integer) As List(Of E_IRIS_WEBF_BUSCA_RELACION_PREVI_PROCE)
        Return DD_Data.IRIS_WEBF_BUSCA_RELACION_PREVI_PROCE(ID_PREVE)

    End Function
End Class