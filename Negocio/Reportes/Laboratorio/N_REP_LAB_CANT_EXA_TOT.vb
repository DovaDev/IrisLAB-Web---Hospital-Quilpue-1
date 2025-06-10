Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports Entidades
Imports Datos
Public Class N_REP_LAB_CANT_EXA_TOT
    Dim DD_Examenes As D_Examenes_Sum
    Sub New()
        DD_Examenes = New D_Examenes_Sum
    End Sub
    Function Gen_Excel(ByVal MAIN_URL As String, ByVal ID_CODIGO_FONASA As Long, ByVal DATE1 As String, ByVal DATE2 As String, ByVal PROCEDENCIA As Integer) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date_Operat
        Dim NN_Exam As New N_Examenes_Sum
        Dim Data_Exam As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES)
        Dim Mx_Data(2, 0) As Object
        'Obtener fechas de la URL para luego transformarlas
        DATE1 = DATE1.Replace("-", "a")
        DATE2 = DATE2.Replace("-", "a")
        Dim Str_d1() As String = Split(DATE1, "a")
        Dim Str_d2() As String = Split(DATE2, "a")
        'Obtener parámetros para la consulta
        Dim ID_CODIGO_FONASAA As Long = ID_CODIGO_FONASA
        Dim Date01 As Date = NN_Date.strToDate(Str_d1(2), Str_d1(1), Str_d1(0))
        Dim Date02 As Date = NN_Date.strToDate(Str_d2(2), Str_d2(1), Str_d2(0))
        'Realizar Consulta
        Data_Exam = NN_Exam.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES(ID_CODIGO_FONASAA, Date01, Date02, PROCEDENCIA)
        If (Data_Exam.Count = 0) Then
            Return "null"
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(2, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_Exam.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(2, y)
            End If
            Mx_Data(0, y) = Data_Exam(y).CF_COD
            Mx_Data(1, y) = Data_Exam(y).CF_DESC
            Mx_Data(2, y) = Data_Exam(y).TOTAL_ATE
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
        sl.RenameWorksheet("Sheet1", "Cantidad de Exámenes Totales")
        'titulo de la tabla
        sl.SetCellValue("B2", "Cantidad de Exámenes Totales")
        If (ID_CODIGO_FONASAA = 0) Then
            sl.SetCellValue("B3", "Exámenes: Todas")
        Else
            sl.SetCellValue("B3", "Examen: " & Data_Exam(0).CF_DESC)
        End If
        sl.SetCellValue("B4", "Desde: " & Date01 & " Hasta: " & Date02)
        'nombre columnas
        sl.SetCellValue("A7", "Código Fonasa")
        sl.SetCellValue("B7", "Descripción de Prestación")
        sl.SetCellValue("C7", "Cant. Exámenes")
        For y = 1 To 3
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
            For i = Asc("B") To Asc("G")
                sl.SetCellStyle(CStr(Chr(i) & y), formatonum)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next y
        'sumar columnas
        sl.SetCellValue(CStr("C" & ltabla + 1), CStr("=SUM(" & "C" & "8:" & "C" & ltabla & ")"))
        'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))

        'estilo totales
        For i = Asc("A") To Asc("C")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        Next i
        sl.SetCellValue("A" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("C" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        If (ID_CODIGO_FONASAA = 0) Then
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\Todas" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        Else
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\" & Data_Exam(0).CF_DESC & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        End If
    End Function
End Class
