'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_PREVISON_DIALISIS
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_PREVISON_DIALISIS

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_PREVISON_DIALISIS
    End Sub

    Function IRIS_WEBF_BUSCA_PREVISON_DIALISIS() As List(Of E_IRIS_WEBF_BUSCA_PREVISON_DIALISIS)
        Return DD_Data.IRIS_WEBF_BUSCA_PREVISON_DIALISIS()

    End Function
End Class