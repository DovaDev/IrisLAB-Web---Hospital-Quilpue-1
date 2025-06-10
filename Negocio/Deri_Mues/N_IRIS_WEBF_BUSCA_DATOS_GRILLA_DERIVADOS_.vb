'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_DATOS_GRILLA_DERIVADOS_
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_DATOS_GRILLA_DERIVADOS_

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_DATOS_GRILLA_DERIVADOS_
    End Sub

    Function IRIS_WEBF_BUSCA_DATOS_GRILLA_DERIVADOS_(ByVal ID_ATE As Integer, ByVal ID_CF As Integer) As List(Of E_IRIS_WEBF_BUSCA_DATOS_GRILLA_DERIVADOS_)
        Return DD_Data.IRIS_WEBF_BUSCA_DATOS_GRILLA_DERIVADOS_(ID_ATE, ID_CF)

    End Function
End Class