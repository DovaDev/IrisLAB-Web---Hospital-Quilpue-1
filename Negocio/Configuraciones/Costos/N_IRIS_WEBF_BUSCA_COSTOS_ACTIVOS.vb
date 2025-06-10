Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts

'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_COSTOS_ACTIVOS
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_COSTOS_ACTIVOS

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_COSTOS_ACTIVOS
    End Sub

    Function IRIS_WEBF_BUSCA_COSTOS_ACTIVOS() As List(Of E_IRIS_WEBF_BUSCA_COSTOS_ACTIVOS)
        Return DD_Data.IRIS_WEBF_BUSCA_COSTOS_ACTIVOS()
    End Function
End Class