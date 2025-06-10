'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_webf_BUSCA_LISTADO_DERIVADOS_POR_NUM_PROCESO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_webf_BUSCA_LISTADO_DERIVADOS_POR_NUM_PROCESO

    Sub New()
        DD_Data = New D_IRIS_webf_BUSCA_LISTADO_DERIVADOS_POR_NUM_PROCESO
    End Sub

    Function IRIS_webf_BUSCA_LISTADO_DERIVADOS_POR_NUM_PROCESO(ByVal NUM As Integer, ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_webf_BUSCA_LISTADO_DERIVADOS_POR_NUM_PROCESO)
        Return DD_Data.IRIS_webf_BUSCA_LISTADO_DERIVADOS_POR_NUM_PROCESO(NUM, DESDE, HASTA)

    End Function
End Class