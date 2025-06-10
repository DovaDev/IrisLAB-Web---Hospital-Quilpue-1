'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_RELACION_PROGRA_PREVI
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_RELACION_PROGRA_PREVI

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_RELACION_PROGRA_PREVI
    End Sub

    Function IRIS_WEBF_BUSCA_RELACION_PROGRA_PREVI(ByVal ID_PREVE As Integer) As List(Of E_IRIS_WEBF_BUSCA_RELACION_PROGRA_PREVI)
        Return DD_Data.IRIS_WEBF_BUSCA_RELACION_PROGRA_PREVI(ID_PREVE)

    End Function
End Class