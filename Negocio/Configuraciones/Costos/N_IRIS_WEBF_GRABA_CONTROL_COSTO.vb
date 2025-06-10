Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts


'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_GRABA_CONTROL_COSTO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_GRABA_CONTROL_COSTO

    Sub New()
        DD_Data = New D_IRIS_WEBF_GRABA_CONTROL_COSTO
    End Sub

    Function IRIS_WEBF_GRABA_CONTROL_COSTO(ByVal ID_CF As Integer, ByVal NUM As Integer, ByVal ID_USUARIO As Integer, ByVal PRECIO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_CONTROL_COSTO(ID_CF, NUM, ID_USUARIO, PRECIO)
    End Function
End Class