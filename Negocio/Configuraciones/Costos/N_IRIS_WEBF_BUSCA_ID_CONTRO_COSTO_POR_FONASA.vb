Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_ID_CONTRO_COSTO_POR_FONASA
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_ID_CONTRO_COSTO_POR_FONASA

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_ID_CONTRO_COSTO_POR_FONASA
    End Sub

    Function IRIS_WEBF_BUSCA_ID_CONTRO_COSTO_POR_FONASA(ByVal ID_FONASA As Integer, ByVal ID_USUARIO As Integer) As List(Of E_IRIS_WEBF_BUSCA_ID_CONTRO_COSTO_POR_FONASA)
        Return DD_Data.IRIS_WEBF_BUSCA_ID_CONTRO_COSTO_POR_FONASA(ID_FONASA, ID_USUARIO)
    End Function
End Class