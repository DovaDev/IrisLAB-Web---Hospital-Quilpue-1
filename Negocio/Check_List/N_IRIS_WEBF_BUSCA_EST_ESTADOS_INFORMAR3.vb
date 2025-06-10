'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR3
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR3
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR3
    End Sub
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR3(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_PRE2 As Integer, ByVal ID_EST As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR3)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR3(DESDE, HASTA, ID_CF, ID_PRE2, ID_EST)
    End Function
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR_NEW(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PROC As Integer, ByVal ID_PRE2 As Integer, ByVal ID_CF As Integer, ByVal ID_EST As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR_NEW)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR_NEW(DESDE, HASTA, ID_PROC, ID_PRE2, ID_CF, ID_EST)
    End Function
End Class