﻿'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_UPDATE_INDICACIONES
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_INDICACIONES
    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_INDICACIONES
    End Sub
    Function IRIS_WEBF_UPDATE_INDICACIONES(ByVal ID_IND As Integer, ByVal IND_COD As String, ByVal IND_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_INDICACIONES(ID_IND, IND_COD, IND_DES, ID_ESTADO)
    End Function
End Class

