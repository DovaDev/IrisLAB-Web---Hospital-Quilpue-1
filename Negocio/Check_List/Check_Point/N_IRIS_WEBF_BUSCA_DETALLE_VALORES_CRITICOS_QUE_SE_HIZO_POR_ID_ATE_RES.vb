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

Public Class N_IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES
    End Sub

    Function IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES(ByVal ID_ATE_RES As Integer) As List(Of E_IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES)
        Return DD_Data.IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES(ID_ATE_RES)
    End Function
End Class