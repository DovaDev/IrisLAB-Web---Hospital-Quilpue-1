Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts

'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_RELACION_COSTO_FONASA
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_RELACION_COSTO_FONASA

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_RELACION_COSTO_FONASA
    End Sub

    Function IRIS_WEBF_BUSCA_RELACION_COSTO_FONASA(ByVal ID_CONTROL As Integer) As List(Of E_IRIS_WEBF_BUSCA_RELACION_COSTO_FONASA)
        Return DD_Data.IRIS_WEBF_BUSCA_RELACION_COSTO_FONASA(ID_CONTROL)
    End Function
End Class