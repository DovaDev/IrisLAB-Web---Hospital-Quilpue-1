Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts

'Importar Capas
Imports Datos
Imports Entidades

Public Class N_Impr_Etiq
    'Declaraciones Generales
    Dim DD_Data As D_Impr_Etiq

    Sub New()
        DD_Data = New D_Impr_Etiq
    End Sub

    Function GET_EXCEL(DESDE As String, HASTA As String, ID_PROC As Integer, ID_SECC As Integer, ID_CF As Integer, ID_AREA As Integer) As String
        Dim strURL As String = HttpContext.Current.Request.Url.Authority
        Dim NNN As New N_Impr_Etiq

        Dim List_Out = NNN.IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_FILTRO(DESDE, HASTA, ID_PROC, ID_SECC, ID_CF, ID_AREA)

        'Crear Tabla
        Dim Xls As New XlsDcto
        Xls.x = 1
        Xls.y = 1

        'Escribir Datos
        Xls.Merge(4)
        Xls.Write("Listado de Etiquetas", Xls.CSSref.h1("center"))
        Xls.NxtRow()
        Xls.NxtRow()

        Xls.SetColumnWidth(1, 20)
        Xls.SetColumnWidth(2, 20)
        Xls.SetColumnWidth(3, 20)
        Xls.SetColumnWidth(4, 25)
        Xls.SetColumnWidth(5, 25)
        Xls.SetColumnWidth(6, 60)

        Xls.x = 1
        Xls.y = Xls.y() + 1

        Xls.Write("Cod Barra", Xls.CSSref.th)
        Xls.Write("Tipo de Muestra", Xls.CSSref.th)
        Xls.Write("Color Tubo", Xls.CSSref.th)
        Xls.NxtRow()

        For i = 0 To (List_Out.Count - 1)
            Xls.Write(List_Out(i).CB_COD & ".-", Xls.CSSref.td_string("center"))
            Xls.Write(List_Out(i).T_MUESTRA_DESC, Xls.CSSref.td_string("left"))
            Xls.Write(List_Out(i).GMUE_DESC, Xls.CSSref.td_string("center"))

            Xls.NxtRow()
        Next
        Xls.Set_Table()

        'Ruta de Guardado
        Dim fecha As String = Date.Now.ToString("dd-MM-yyyy_HH-mm-ss")
        Xls.Path = "IRISPDFDERIVADOS\List_Etiquetas_" & fecha & ".xlsx"

        ' Guardar el archivo
        Xls.Guardar_Como(True)

        ' Devolver la URL del archivo generado
        Return strURL & "/" & Replace(Xls.Path, "\", "/")
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_N_ATE(ByVal ATE_NUM As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_ID_ATE)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_N_ATE(ATE_NUM)
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_GENERAL_INFO(ByVal ATE_NUM As Long) As E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_GENERAL_INFO
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_GENERAL_INFO(ATE_NUM)
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_ID_ATE(ByVal ATE_NUM As Long) As List(Of E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_ID_ATE)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_ID_ATE(ATE_NUM)
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_FILTRO(DESDE As String, HASTA As String, ID_PROC As Integer, ID_SECC As Integer, ID_CF As Integer, ID_AREA As Integer) As List(Of E_IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_ID_ATE)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_POR_FILTRO(DESDE, HASTA, ID_PROC, ID_SECC, ID_CF, ID_AREA)
    End Function
End Class