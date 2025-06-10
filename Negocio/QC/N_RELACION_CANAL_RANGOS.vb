Imports Entidades
Imports Datos
Public Class N_RELACION_CANAL_RANGOS
    Dim DD_Data As D_RELACION_CANAL_RANGOS
    Sub New()
        DD_Data = New D_RELACION_CANAL_RANGOS
    End Sub
    Function IRIS_WEBF_GRABA_RELACION_CANAL_RANGOS(ByVal ID_I As Integer,
                                          ByVal ID_MAQ As Integer,
                                          ByVal CANAL As String,
                                          ByVal DETER As String,
                                          ByVal R_DESDE As String,
                                          ByVal R_HASTA As String,
                                          ByVal RR_DESDE As String,
                                          ByVal RR_HASTA As String) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_RELACION_CANAL_RANGOS(ID_I, ID_MAQ, CANAL, DETER, R_DESDE, R_HASTA, RR_DESDE, RR_HASTA)
    End Function

    Function IRIS_WEBF_UPDATE_RELACION_CANAL_RANGOS(ByVal ID_REL As Integer,
                                                    ByVal ID_I As Integer,
                                                      ByVal ID_MAQ As Integer,
                                                      ByVal CANAL As String,
                                                      ByVal DETER As String,
                                                      ByVal R_DESDE As String,
                                                      ByVal R_HASTA As String,
                                                      ByVal RR_DESDE As String,
                                                      ByVal RR_HASTA As String) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_RELACION_CANAL_RANGOS(ID_REL, ID_I, ID_MAQ, CANAL, DETER, R_DESDE, R_HASTA, RR_DESDE, RR_HASTA)
    End Function

    Function IRIS_WEBF_UPDATE_ESTADO_RELACION_CANAL_RANGOS(ByVal ID_REL As Integer,
                                                    ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_ESTADO_RELACION_CANAL_RANGOS(ID_REL, ID_ESTADO)
    End Function

    Function IRIS_WEBF_BUSCA_RELACION_CANAL_RANGOS() As List(Of E_IRIS_WEBF_BUSCA_RELACION_CANAL_RANGOS)
        Return DD_Data.IRIS_WEBF_BUSCA_RELACION_CANAL_RANGOS()
    End Function
End Class
