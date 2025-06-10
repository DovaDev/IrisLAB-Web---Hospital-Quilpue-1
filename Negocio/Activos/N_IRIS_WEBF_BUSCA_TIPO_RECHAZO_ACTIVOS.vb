'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_TIPO_RECHAZO_ACTIVOS
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_TIPO_RECHAZO_ACTIVOS

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_TIPO_RECHAZO_ACTIVOS
    End Sub

    Function IRIS_WEBF_BUSCA_TIPO_RECHAZO_ACTIVOS() As List(Of E_IRIS_WEBF_BUSCA_TIPO_RECHAZO_ACTIVOS)
        Return DD_Data.IRIS_WEBF_BUSCA_TIPO_RECHAZO_ACTIVOS()

    End Function
End Class