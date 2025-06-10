Imports Entidades
Imports Datos
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web
Public Class N_Paciente_Sum
    Dim DD_Gen_Activos As D_Gen_Activos
    Dim DD_Pac As D_Paciente_Sum
    Sub New()
        DD_Gen_Activos = New D_Gen_Activos
        DD_Pac = New D_Paciente_Sum
    End Sub
    Function IRIS_WEBF_BUSCA_LIS_ADM_PACIENTES(ByVal ID_PREVE As Long, ByVal Date_01 As Date, ByVal Date_02 As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_PACIENTES)
        Return DD_Pac.IRIS_WEBF_BUSCA_LIS_ADM_PACIENTES(ID_PREVE, Date_01, Date_02)
    End Function
    Function Gen_Excel(ByVal MAIN_URL As String, ByVal ID_PRE As Long, ByVal PREVE_DESC As String, ByVal DATE1 As String, ByVal DATE2 As String) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date_Operat
        Dim NN_Prev As New N_Paciente_Sum
        Dim Data_Pac As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_PACIENTES)
        Dim Mx_Data(8, 0) As Object
        'Obtener parámetros para la consulta
        Dim ID_previviviviv As Long = ID_PRE
        'Realizar Consulta
        Data_Pac = NN_Prev.IRIS_WEBF_BUSCA_LIS_ADM_PACIENTES(ID_previviviviv, DATE1, DATE2)
        If (Data_Pac.Count = 0) Then
            Return "null"
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(8, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_Pac.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(8, y)
            End If
            Mx_Data(0, y) = y + 1
            Mx_Data(1, y) = Data_Pac(y).ATE_NUM
            Mx_Data(2, y) = Data_Pac(y).PAC_RUT
            Mx_Data(3, y) = Data_Pac(y).PAC_APELLIDO + " " + Data_Pac(y).PAC_NOMBRE
            Mx_Data(4, y) = Data_Pac(y).TP_PAGO_DESC
            Mx_Data(5, y) = ""
            Mx_Data(6, y) = Data_Pac(y).ATE_TOTAL_PREVI
            Mx_Data(7, y) = Data_Pac(y).ATE_TOTAL_COPA
            Mx_Data(8, y) = ""
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
        sl.RenameWorksheet("Sheet1", "Detalle Previsión")
        'titulo de la tabla
        sl.SetCellValue("B2", "Resumen de Previsión")
        sl.SetCellValue("B3", "Previsión: " & PREVE_DESC)
        'If (ID_previviviviv = 0) Then
        '    sl.SetCellValue("B3", "Previsión: Todas")
        'Else
        '    sl.SetCellValue("B3", "Previsión: " & Data_Pac(0).PREVE_DESC)
        'End If
        sl.SetCellValue("B4", "Desde: " & DATE1 & " Hasta: " & DATE2)
        'nombre columnas
        sl.SetCellValue("A7", "N° Correlativo")
        sl.SetColumnWidth(1, 10.0)
        sl.SetCellValue("B7", "Folio")
        sl.SetColumnWidth(2, 15.0)
        sl.SetCellValue("C7", "R.U.T")
        sl.SetColumnWidth(3, 15.0)
        sl.SetCellValue("D7", "Nombre")
        sl.SetColumnWidth(4, 40.0)
        sl.SetCellValue("E7", "Forma de Pago")
        sl.SetColumnWidth(5, 15.0)
        sl.SetCellValue("F7", "N° Bonos")
        sl.SetColumnWidth(6, 15.0)
        sl.SetCellValue("G7", "Total Bonos")
        sl.SetColumnWidth(7, 15.0)
        sl.SetCellValue("H7", "Total Copago")
        sl.SetColumnWidth(8, 15.0)
        sl.SetCellValue("I7", "Total Particular")
        sl.SetColumnWidth(9, 15.0)
        'For y = 1 To 7
        '    sl.SetColumnWidth(y, 20.0)
        'Next y
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
            For i = Asc("B") To Asc("I")
                sl.SetCellStyle(CStr(Chr(i) & y), formatonum)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next y
        'sumar columnas
        For i = Asc("G") To Asc("I")
            sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
            'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        Next i
        'estilo totales
        For i = Asc("A") To Asc("I")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        Next i
        sl.SetCellValue("A" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("I" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        If (ID_previviviviv = 0) Then
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\Todas" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        Else
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\" & PREVE_DESC & " " & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        End If
    End Function
End Class
