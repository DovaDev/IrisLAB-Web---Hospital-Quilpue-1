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

Public Class N_C_C
    'Declaraciones Generales
    Dim DD_Data As D_C_C

    Sub New()
        DD_Data = New D_C_C
    End Sub

    Function IRIS_WEBF_BUSCA_PASS(ByVal ID As Integer) As List(Of E_IRIS_WEBF_BUSCA_PASS)
        Return DD_Data.IRIS_WEBF_BUSCA_PASS(ID)
    End Function
    Function IRIS_WEBF_G_PASS(ByVal NCONTRASEÑA As String, ByVal ID As Integer) As Integer
        Return DD_Data.IRIS_WEBF_G_PASS(NCONTRASEÑA, ID)
    End Function
End Class