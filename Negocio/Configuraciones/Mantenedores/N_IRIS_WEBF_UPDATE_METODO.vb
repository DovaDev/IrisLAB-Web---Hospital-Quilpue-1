﻿'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_UPDATE_METODO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_METODO
    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_METODO
    End Sub
    Function IRIS_WEBF_UPDATE_METODO(ByVal ID_ATE As String, ByVal ATE_COD As String, ByVal ATE_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_METODO(ID_ATE, ATE_COD, ATE_DES, ID_ESTADO)
    End Function
End Class
