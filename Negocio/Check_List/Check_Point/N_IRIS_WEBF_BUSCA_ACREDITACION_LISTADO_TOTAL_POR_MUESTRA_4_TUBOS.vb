'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS
    End Sub

    Function IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_SECC As Integer, ByVal ID_PRE As Integer, ByVal ID_TUBO As Integer) As List(Of E_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS)
        Return DD_Data.IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS(DESDE, HASTA, ID_SECC, ID_PRE, ID_TUBO)

    End Function

    Function IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS_2(ByVal DESDE As Date,
                                                                              ByVal HASTA As Date,
                                                                              ByVal ID_PRE As Integer) As List(Of E_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS)

        Return DD_Data.IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS_2(DESDE, HASTA, ID_PRE)

    End Function

    Function IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS_3(ByVal DESDE As Date,
                                                                          ByVal HASTA As Date,
                                                                          ByVal ID_PRE As Integer) As List(Of E_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS)

        Return DD_Data.IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS_3(DESDE, HASTA, ID_PRE)

    End Function
End Class