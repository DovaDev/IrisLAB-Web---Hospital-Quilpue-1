Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts

'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS
    End Sub

    Function IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS(ByVal ANO As String, ByVal ID_P As Integer) As List(Of E_IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS)
        Return DD_Data.IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS(ANO, ID_P)
    End Function
End Class