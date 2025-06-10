'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR
    End Sub
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR(DESDE, HASTA, ID_CF)
    End Function
End Class
