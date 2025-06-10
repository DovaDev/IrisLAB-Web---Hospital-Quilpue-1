Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts

'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_CONTROL_COSTO_RELACIONADOS
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_CONTROL_COSTO_RELACIONADOS

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_CONTROL_COSTO_RELACIONADOS
    End Sub

    Function IRIS_BUSCA_CONTROL_COSTO_RELACIONADOS(ByVal ID_CONTROL As Integer) As List(Of E_IRIS_WEBF_BUSCA_CONTROL_COSTO_RELACIONADOS)
        Return DD_Data.IRIS_BUSCA_CONTROL_COSTO_RELACIONADOS(ID_CONTROL)
    End Function
End Class