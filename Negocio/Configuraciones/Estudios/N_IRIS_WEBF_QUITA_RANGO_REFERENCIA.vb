Imports Datos

Public Class N_IRIS_WEBF_QUITA_RANGO_REFERENCIA
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_QUITA_RANGO_REFERENCIA

    Sub New()
        DD_Data = New D_IRIS_WEBF_QUITA_RANGO_REFERENCIA
    End Sub


    Function IRIS_WEBF_QUITA_RANGO_REFERENCIA_(ByVal ID_RF As Integer) As Integer

        Return DD_Data.IRIS_QUITA_RANGO_REFERENCIA(ID_RF)
    End Function
End Class