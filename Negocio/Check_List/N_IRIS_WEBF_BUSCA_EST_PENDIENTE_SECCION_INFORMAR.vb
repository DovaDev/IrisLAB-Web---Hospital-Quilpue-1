﻿'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_EST_PENDIENTE_SECCION_INFORMAR
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_EST_PENDIENTE_SECCION_INFORMAR
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_EST_PENDIENTE_SECCION_INFORMAR
    End Sub
    Function IRIS_WEBF_BUSCA_EST_PENDIENTE_SECCION_INFORMAR(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_SECC As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_PENDIENTE_SECCION_INFORMAR)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_PENDIENTE_SECCION_INFORMAR(DESDE, HASTA, ID_SECC)
    End Function
End Class