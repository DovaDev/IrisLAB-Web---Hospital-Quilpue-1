Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports Datos
Imports Entidades
Public Class N_GraficoTM_Todo
    Dim DD_Data As D_GraficoTM_Todo
    Sub New()
        DD_Data = New D_GraficoTM_Todo
    End Sub
    Function IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_POR_LUGAR_TM1_TODOS(ByVal Año As Long, ByVal Mes As Long) As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_POR_LUGAR_TM1_TODOS)
        Return DD_Data.IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_POR_LUGAR_TM1_TODOS(Año, Mes)
    End Function
End Class
