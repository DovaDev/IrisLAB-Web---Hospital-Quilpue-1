Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports iTextSharp.text
Imports iTextSharp.text.pdf

'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_TP_VALORES_CRITICOS_ACTIVOS
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_TP_VALORES_CRITICOS_ACTIVOS

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_TP_VALORES_CRITICOS_ACTIVOS
    End Sub

    Function IRIS_WEBF_BUSCA_TP_VALORES_CRITICOS_ACTIVOS() As List(Of E_IRIS_WEBF_BUSCA_TP_VALORES_CRITICOS_ACTIVOS)
        Return DD_Data.IRIS_WEBF_BUSCA_TP_VALORES_CRITICOS_ACTIVOS()
    End Function
End Class