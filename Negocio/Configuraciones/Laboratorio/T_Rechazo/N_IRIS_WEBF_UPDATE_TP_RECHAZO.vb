﻿Imports Entidades
Imports Datos
Public Class N_IRIS_WEBF_UPDATE_TP_RECHAZO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_TP_RECHAZO
    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_TP_RECHAZO
    End Sub
    Function IRIS_WEBF_UPDATE_TP_RECHAZO(ByVal ID_TP_RECHAZO As Integer, ByVal TP_RECHA_COD As String, ByVal TP_RECHA_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_TP_RECHAZO(ID_TP_RECHAZO, TP_RECHA_COD, TP_RECHA_DES, ID_ESTADO)
    End Function
End Class
