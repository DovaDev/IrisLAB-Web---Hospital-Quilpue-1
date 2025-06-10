Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports Entidades
Imports Datos
Public Class N_RESU_ING_USU
    'Declaraciones Generales
    Dim DD_Data As D_RESU_ING_USU
    Sub New()
        DD_Data = New D_RESU_ING_USU
    End Sub
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_USUARIO(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_REL As Integer) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_USUARIO)
        Return DD_Data.IRIS_WEBF_BUSCA_LIS_ADM_RESU_USUARIO(DESDE, HASTA, ID_REL)
    End Function
    Function Gen_Excel(ByVal MAIN_URL As String, ByVal ID_USUARIO As Long, ByVal USU_NOM As String, ByVal DESDE As String, ByVal HASTA As String) As String
        'Declaraciones Generales
        Dim datos As String = ""
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Exam As New N_RESU_ING_USU
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_USUARIO)
        Dim Mx_Data(7, 0) As Object
        'Obtener fechas de la URL para luego transformarlas
        DESDE = DESDE.Replace("-", "a")
        HASTA = HASTA.Replace("-", "a")
        Dim Str_d1() As String = Split(DESDE, "a")
        Dim Str_d2() As String = Split(HASTA, "a")

        Dim Date01 As Date = NN_Date.strToDate(Str_d1(2), Str_d1(1), Str_d1(0))
        Dim Date02 As Date = NN_Date.strToDate(Str_d2(2), Str_d2(1), Str_d2(0))
        Data_Prev = NN_Exam.IRIS_WEBF_BUSCA_LIS_ADM_RESU_USUARIO(Date01, Date02, ID_USUARIO)
        'Vaciar Matriz
        ReDim Mx_Data(3, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_Prev.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(3, y)
            End If
            Mx_Data(0, y) = y + 1
            Mx_Data(1, y) = Data_Prev(y).USU_NOMBRE & "" & Data_Prev(y).USU_APELLIDO
            Mx_Data(2, y) = Data_Prev(y).TOTAL_ATE
            Mx_Data(3, y) = Data_Prev(y).TOT_FONASA
        Next y
        Dim Excel_x As Integer
        Dim Excel_y As Integer
        Excel_x = 1
        Excel_y = 8
        Dim ltabla As Integer = 0
        'creamos el objeto SLDocument el cual creara el excel
        Dim sl As SLDocument = New SLDocument
        Dim tabla As SLTable
        'Dim tabla2 As SLTable
        Dim estilo As SLStyle
        Dim estilo2 As SLStyle
        Dim estilo3 As SLStyle
        Dim formatonum As SLStyle
        'Dim formatoporce As SLStyle
        Dim stTotal As SLStyle
        'Dim grafico As SLChart
        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Resumen de Atenciones por Usuario")
        'titulo de la tabla
        If (ID_USUARIO = 0) Then
            sl.SetCellValue("B2", "Resumen de Atenciones por Usuario: Todos")
        Else
            sl.SetCellValue("B2", "Resumen de Atenciones por Usuario: " & USU_NOM)
        End If
        sl.SetCellValue("B4", "Desde: " & Date01 & " Hasta: " & Date02)
        'nombre columnas
        sl.SetCellValue("A7", "N°")
        sl.SetCellValue("B7", "Tecnólogo Médico")
        sl.SetCellValue("C7", "Cantidad de Atenciones")
        sl.SetCellValue("D7", "Cantidad de Exámenes")
        sl.SetColumnWidth(8, 55.0)
        For y = 1 To 4
            sl.SetColumnWidth(y, 20.0)
        Next y
        For y = 0 To Mx_Data.GetUpperBound(1)
            For x = 0 To Mx_Data.GetUpperBound(0)
                sl.SetCellValue(y + Excel_y, x + 1, Mx_Data(x, y))
            Next x
            ltabla += 1
        Next y
        ltabla += 7

        estilo = sl.CreateStyle()
        estilo.Font.FontName = "Arial"
        estilo.Font.FontSize = 20
        estilo.Font.Bold = True
        estilo2 = sl.CreateStyle()
        estilo2.Font.FontName = "Arial"
        estilo2.Font.FontSize = 14
        estilo2.Font.Bold = True

        estilo3 = sl.CreateStyle()
        estilo3.Font.FontName = "Arial"
        estilo3.Font.FontSize = 13
        estilo3.Font.Bold = True

        stTotal = sl.CreateStyle()
        stTotal.Font.FontSize = 12
        stTotal.Font.Bold = True
        stTotal.FormatCode = "###,###,##0"
        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("B3", estilo2)
        sl.SetCellStyle("B4", estilo3)
        'dar formato numerico
        formatonum = sl.CreateStyle()
        formatonum.FormatCode = "###,###,##0"
        For y = 8 To ltabla + 1
            For i = Asc("C") To Asc("D")
                sl.SetCellStyle(CStr(Chr(i) & y), formatonum)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next y
        'sumar columnas
        For i = Asc("C") To Asc("D")
            sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
            'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        Next i
        'estilo totales
        For i = Asc("C") To Asc("D")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        Next i
        sl.SetCellValue("A" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("D" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String
        Relative_Path = "IRISPDFDERIVADOS\" & USU_NOM & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
End Class
