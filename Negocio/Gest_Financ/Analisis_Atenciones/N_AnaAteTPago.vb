Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports Datos
Imports Entidades
Public Class N_AnaAteTPago
    Dim DD_Data As D_GraficoAteTP
    Dim DD_Data_Todo As D_GraficoTM_Todo
    Sub New()
        DD_Data = New D_GraficoAteTP
        DD_Data_Todo = New D_GraficoTM_Todo
    End Sub
    Function Gen_Excel(ByVal MAIN_URL As String, ByVal Dll As Long, ByVal Año As String) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date_Operat
        Dim NN_Med As New N_GraficoTM_Todo
        Dim NN_TP As New N_GraficoAteTP
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_POR_LUGAR_TM1_TODOS)
        Dim date_json_rial As New List(Of E_GraficoVisor_Json)
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Proce As New List(Of E_IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE)
        Dim TP_Desc As String = ""
        Dim mm As Integer
        mm = Format(Date.Now, "MM")
        'Consultar por previsiones activas
        Data_Proce = NN_Activos.IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE()
        For i = 0 To Data_Proce.Count - 1
            If Data_Proce(i).ID_TP_PAGO = Dll Then
                TP_Desc = Data_Proce(i).TP_PAGO_DESC
            End If
        Next i

        Dim Mx_Data(2, 0) As Object
        For dd = 1 To 12
            Dim Item As New E_GraficoVisor_Json
            If Dll <> 0 Then
                Data_Med = NN_TP.IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_FORMA_PAGO(Dll, Año, dd)
                If Data_Med.Count <> 0 Then
                    Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                    Item.CANT_ATE = Data_Med(0).CANT_ATE
                    Item.CANT_EXA = Data_Med(0).CANT_EXA
                    date_json_rial.Add(Item)
                ElseIf (Data_Med.Count = 0) Then
                    Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                    Item.CANT_ATE = 0
                    Item.CANT_EXA = 0
                    date_json_rial.Add(Item)
                End If
            Else
                Data_Med = NN_Med.IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_POR_LUGAR_TM1_TODOS(Año, dd)
                If (Data_Med.Count = 0) Then
                    Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                    Item.CANT_ATE = 0
                    Item.CANT_EXA = 0
                    date_json_rial.Add(Item)
                Else
                    Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                    Item.CANT_ATE = Data_Med(0).CANT_ATE
                    Item.CANT_EXA = Data_Med(0).CANT_EXA
                    date_json_rial.Add(Item)
                End If
            End If
        Next dd
        ''Realizar Consulta
        'Data_Lis_Ate = NN_Lis_Ate.IRIS_WEBF_BUSCA_LIS_ADM_LUGAR_TM_TOTALES(ID_PRE, Date01, Date02)
        'If (Data_Lis_Ate.Count = 0) Then
        '    Return "null"
        '    Exit Function
        'End If
        'Vaciar Matriz
        ReDim Mx_Data(2, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (date_json_rial.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(2, y)
            End If
            Mx_Data(0, y) = date_json_rial(y).MES
            Mx_Data(1, y) = date_json_rial(y).CANT_ATE
            Mx_Data(2, y) = date_json_rial(y).CANT_EXA
            'Mx_Data(2, y) = Data_Lis_Ate(y).ATE_AÑO & " años"
            'Mx_Data(3, y) = Format(Data_Lis_Ate(y).ATE_FECHA, "dd/MM/yyy")
            'Mx_Data(4, y) = Format(Data_Lis_Ate(y).ATE_FECHA, "HH:mm:ss")
            'Mx_Data(5, y) = Data_Lis_Ate(y).PROC_DESC
            'Mx_Data(6, y) = Data_Lis_Ate(y).SEXO_DESC
            'Mx_Data(7, y) = CInt(Data_Lis_Ate(y).ATE_TOTAL)
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
        sl.RenameWorksheet("Sheet1", "Atenciones Totales (Análisis)")
        ''titulo de la tabla
        sl.SetCellValue("B2", "Atenciones Totales (Análisis)")
        If (Dll = "0") Then
            sl.SetCellValue("B3", "Tipo de Pago: Todas")
        Else
            sl.SetCellValue("B3", "Tipo de Pago: " & TP_Desc)
        End If
        sl.SetCellValue("B4", "Año: " & Año)
        'nombre columnas
        sl.SetCellValue("A7", "Mes")
        sl.SetCellValue("B7", "N° de Atenciones")
        sl.SetCellValue("C7", "N° de Exámenes")

        For y = 1 To 3
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
            For i = Asc("B") To Asc("C")
                sl.SetCellStyle(CStr(Chr(i) & y), formatonum)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next y
        'sumar columnas
        For i = Asc("B") To Asc("C")
            sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
            'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        Next i
        'estilo totales
        For i = Asc("A") To Asc("C")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        Next i
        sl.SetCellValue("A" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("C" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        If (Dll = 0) Then
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\Todos" & Año & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        Else
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\" & Año & TP_Desc & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        End If
    End Function
End Class
