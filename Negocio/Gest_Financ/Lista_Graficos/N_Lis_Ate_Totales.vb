
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports Datos
Imports Entidades
Public Class N_Lis_Ate_Totales
    'Declaraciones Generales
    Dim DD_Data As D_Lis_Ate_Totales
    Sub New()
        DD_Data = New D_Lis_Ate_Totales
    End Sub
    Function IRIS_WEBF_BUSCA_LIS_ADM_LUGAR_TM_TOTALES(ByVal ID_PRE As Long, ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_LUGAR_TM_TOTALES)
        Return DD_Data.IRIS_WEBF_BUSCA_LIS_ADM_LUGAR_TM_TOTALES(ID_PRE, DESDE, HASTA)
    End Function
    Function Gen_Excel(ByVal MAIN_URL As String, ByVal ID_PRE As Long, ByVal PROC_DESC As String, ByVal DATE1 As String, ByVal DATE2 As String) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date_Operat
        Dim NN_Lis_Ate As New N_Lis_Ate_Totales
        Dim Data_Lis_Ate As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_LUGAR_TM_TOTALES)
        Dim Mx_Data(6, 0) As Object
        'Obtener parámetros para la consulta
        Dim Previs As Long = ID_PRE
        Dim LugTM As String = PROC_DESC
        'Realizar Consulta
        Data_Lis_Ate = NN_Lis_Ate.IRIS_WEBF_BUSCA_LIS_ADM_LUGAR_TM_TOTALES(ID_PRE, DATE1, DATE2)
        If (Data_Lis_Ate.Count = 0) Then
            Return "null"
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(7, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_Lis_Ate.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(7, y)
            End If
            Mx_Data(0, y) = Data_Lis_Ate(y).ATE_NUM
            Mx_Data(1, y) = Data_Lis_Ate(y).PAC_NOMBRE + " " + Data_Lis_Ate(y).PAC_APELLIDO
            Mx_Data(2, y) = Data_Lis_Ate(y).ATE_AÑO & " años"
            Mx_Data(3, y) = Format(Data_Lis_Ate(y).ATE_FECHA, "dd/MM/yyy")
            Mx_Data(4, y) = Format(Data_Lis_Ate(y).ATE_FECHA, "HH:mm:ss")
            Mx_Data(5, y) = Data_Lis_Ate(y).PROC_DESC
            Mx_Data(6, y) = Data_Lis_Ate(y).SEXO_DESC
            Mx_Data(7, y) = CInt(Data_Lis_Ate(y).ATE_TOTAL)
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
        sl.RenameWorksheet("Sheet1", "Atenciones Totales (Listado)")
        'titulo de la tabla
        sl.SetCellValue("B2", "Atenciones Totales (Listado)")
        If (PROC_DESC = "Todos") Then
            sl.SetCellValue("B3", "Lugar De TM: Todas")
        Else
            sl.SetCellValue("B3", "Lugar De TM: " & PROC_DESC)
        End If
        sl.SetCellValue("B4", "Desde: " & DATE1 & " Hasta: " & DATE2)
        'nombre columnas
        sl.SetCellValue("A7", "N° Atención")
        sl.SetCellValue("B7", "Nombre Paciente")
        sl.SetCellValue("C7", "Edad")
        sl.SetCellValue("D7", "Fecha")
        sl.SetCellValue("E7", "Hora")
        sl.SetCellValue("F7", "Lugar de TM")
        sl.SetCellValue("G7", "Sexo")
        sl.SetCellValue("H7", "Total")
        For y = 1 To 8
            sl.SetColumnWidth(y, 20.0)
        Next y
        sl.SetColumnWidth(2, 35.0) 'Ancho para la columna de Nombre
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
            For i = Asc("H") To Asc("H")
                sl.SetCellStyle(CStr(Chr(i) & y), formatonum)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next y
        'sumar columnas
        For i = Asc("H") To Asc("H")
            sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
            'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        Next i
        'estilo totales
        For i = Asc("A") To Asc("H")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        Next i
        sl.SetCellValue("A" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("H" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        If (Previs = 0) Then
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\Todos" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        Else
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\" & PROC_DESC & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        End If
    End Function
End Class