Imports Datos

Public Class N_IRIS_WEBF_GRABA_RANGO_REFERENCIA


    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_RANGO_REFERENCIA
    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_RANGO_REFERENCIA
    End Sub

    Function IRIS_WEBF_GRABA_RANGO_REFERENCIA(ByVal ID_PRUEBA As Integer,
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
                                                       ByVal EMBARA As Integer,
                                                       ByVal ID_USUARIO As Integer) As String


        Return DD_Data.IRIS_GRABA_RANGO_REFERENCIA(ID_PRUEBA,
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
                                                        EMBARA,
                                                        ID_USUARIO)
    End Function

End Class