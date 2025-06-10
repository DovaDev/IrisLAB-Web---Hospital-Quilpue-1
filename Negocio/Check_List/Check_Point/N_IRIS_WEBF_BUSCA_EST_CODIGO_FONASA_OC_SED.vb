'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_OC_SED
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_OC_SED

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_OC_SED
    End Sub

    Function IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_OC_SED(ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_OC_SED)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_OC_SED(DESDE, HASTA)

    End Function
End Class