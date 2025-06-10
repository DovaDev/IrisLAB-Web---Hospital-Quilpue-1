Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts

'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_CORRELATIVO_CONTROL_COSTO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_CORRELATIVO_CONTROL_COSTO

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_CORRELATIVO_CONTROL_COSTO
    End Sub

    Function IRIS_WEBF_BUSCA_CORRELATIVO_CONTROL_COSTO() As Integer
        Return DD_Data.IRIS_WEBF_BUSCA_CORRELATIVO_CONTROL_COSTO()
    End Function
End Class
