Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts


'Importar Capas
Imports Datos
Imports Entidades

Public Class N_Ingreso_Ate_Avis
    'Declaraciones Generales
    Dim DD_Data As D_Ingreso_Ate_Avis

    Sub New()
        DD_Data = New D_Ingreso_Ate_Avis
    End Sub

    Function IRIS_WEBF_AGREGAR_MEDICOS_CON_AVIS(ByVal HO_CC As String) As Integer
        Return DD_Data.IRIS_WEBF_AGREGAR_MEDICOS_CON_AVIS(HO_CC)
    End Function
End Class