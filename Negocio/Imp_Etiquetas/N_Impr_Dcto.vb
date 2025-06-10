Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts

'Importar Capas
Imports Datos
Imports Entidades

Public Class N_Impr_Dcto
    'Declaraciones Generales
    Dim DD_Data As D_Impr_Dcto

    Sub New()
        DD_Data = New D_Impr_Dcto
    End Sub

    Function IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA3(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PROC As Long, ByVal ID_PREV As Long) As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA3)
        Return DD_Data.IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA3(DESDE, HASTA, ID_PROC, ID_PREV)
    End Function
End Class