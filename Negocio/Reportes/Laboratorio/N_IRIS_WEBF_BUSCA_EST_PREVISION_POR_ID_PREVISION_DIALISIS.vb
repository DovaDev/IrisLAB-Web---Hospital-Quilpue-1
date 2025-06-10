Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts

'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_EST_PREVISION_POR_ID_PREVISION_DIALISIS
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_EST_PREVISION_POR_ID_PREVISION_DIALISIS

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_EST_PREVISION_POR_ID_PREVISION_DIALISIS
    End Sub

    Function IRIS_WEBF_BUSCA_EST_PREVISION_POR_ID_PREVISION_DIALISIS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PRE As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_PREVISION_POR_ID_PREVISION_DIALISIS)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_PREVISION_POR_ID_PREVISION_DIALISIS(DESDE, HASTA, ID_PRE)
    End Function
End Class