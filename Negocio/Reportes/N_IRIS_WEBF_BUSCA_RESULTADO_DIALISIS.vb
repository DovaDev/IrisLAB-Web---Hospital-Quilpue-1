'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_RESULTADO_DIALISIS
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_RESULTADO_DIALISIS

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_RESULTADO_DIALISIS
    End Sub

    Function IRIS_WEBF_BUSCA_RESULTADO_DIALISIS(ByVal ID_ATE As Integer, ByVal ID_PRU As Integer) As List(Of E_IRIS_WEBF_BUSCA_RESULTADO_DIALISIS)
        Return DD_Data.IRIS_WEBF_BUSCA_RESULTADO_DIALISIS(ID_ATE, ID_PRU)

    End Function
End Class