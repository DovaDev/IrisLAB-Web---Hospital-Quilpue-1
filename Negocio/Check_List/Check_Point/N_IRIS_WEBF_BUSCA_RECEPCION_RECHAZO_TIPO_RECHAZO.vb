﻿'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_RECEPCION_RECHAZO_TIPO_RECHAZO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_RECEPCION_RECHAZO_TIPO_RECHAZO

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_RECEPCION_RECHAZO_TIPO_RECHAZO
    End Sub

    Function IRIS_WEBF_BUSCA_RECEPCION_RECHAZO_TIPO_RECHAZO(ByVal ID_ATE As Integer, ByVal CURVA As String) As List(Of E_IRIS_WEBF_BUSCA_RECEPCION_RECHAZO_TIPO_RECHAZO)
        Return DD_Data.IRIS_WEBF_BUSCA_RECEPCION_RECHAZO_TIPO_RECHAZO(ID_ATE, CURVA)
    End Function
End Class