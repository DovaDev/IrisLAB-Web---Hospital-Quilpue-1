Imports Datos

Public Class N_IRIS_WEBF_UPDATE_RANGO_REFERENCIA
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_RANGO_REFERENCIA
    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_RANGO_REFERENCIA
    End Sub

    Function IRIS_WEBF_UPDATE_RANGO_REFERENCIA(ByVal ID_RF As Integer,
                                                       ByVal ID_SEXO As Integer,
                                                       ByVal ANO_DESDE As Integer,
                                                       ByVal MES_DESDE As Integer,
                                                       ByVal DIAS_DESDE As Integer,
                                                       ByVal ANO_HASTA As Integer,
                                                       ByVal MES_HASTA As Integer,
                                                       ByVal DIAS_HASTA As Integer,
                                                       ByVal MBAJO As Double,
                                                       ByVal BAJO As Double,
                                                       ByVal ALTO As Double,
                                                       ByVal MALTO As Double,
                                                       ByVal TEXTO As String,
                                                       ByVal EMBARA As Integer) As Integer

        Return DD_Data.IRIS_UPDATE_RANGO_REFERENCIA(ID_RF,
                                                       ID_SEXO,
                                                       ANO_DESDE,
                                                       MES_DESDE,
                                                       DIAS_DESDE,
                                                       ANO_HASTA,
                                                       MES_HASTA,
                                                       DIAS_HASTA,
                                                       MBAJO,
                                                       BAJO,
                                                       ALTO,
                                                       MALTO,
                                                       TEXTO,
                                                       EMBARA)

    End Function

End Class