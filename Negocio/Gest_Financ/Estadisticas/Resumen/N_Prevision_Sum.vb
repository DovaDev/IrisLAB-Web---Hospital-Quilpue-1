Imports Entidades
Imports Datos
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web
Public Class N_Prevision_Sum
    Dim DD_Gen_Activos As D_Gen_Activos
    Dim DD_Prev As D_Prevision_Sum
    Sub New()
        DD_Gen_Activos = New D_Gen_Activos
        DD_Prev = New D_Prevision_Sum
    End Sub
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION(ByVal ID_PRE As Long, ByVal Date_01 As Date, ByVal Date_02 As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION)
        Return DD_Prev.IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION(ID_PRE, Date_01, Date_02)
    End Function
    Function Gen_Excel(ByVal MAIN_URL As String, ByVal PREVE As Long, ByVal DATE1 As String, ByVal DATE2 As String) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date_Operat
        Dim NN_Prev As New N_Prevision_Sum
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION)
        Dim Mx_Data(6, 0) As Object
        'Obtener parámetros para la consulta
        Dim Previs As Long = PREVE
        'Realizar Consulta
        Data_Prev = NN_Prev.IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION(Previs, DATE1, DATE2)
        If (Data_Prev.Count = 0) Then
            Return "null"
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(6, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_Prev.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(6, y)
            End If
            Mx_Data(0, y) = Data_Prev(y).PREVE_DESC
            Mx_Data(1, y) = Data_Prev(y).TOTAL_ATE
            Mx_Data(2, y) = Data_Prev(y).TOT_FONASA
            Mx_Data(3, y) = Data_Prev(y).TOTA_SIS
            Mx_Data(4, y) = Data_Prev(y).TOTA_USU
            Mx_Data(5, y) = Data_Prev(y).TOTA_COPA
            Mx_Data(6, y) = CInt(Data_Prev(y).TOTA_USU + Data_Prev(y).TOTA_COPA)
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
        If (PREVE = 0) Then
            sl.SetCellValue("B3", "Previsión: Todas")
        Else
            sl.SetCellValue("B3", "Previsión: " & Data_Prev(0).PREVE_DESC)
        End If
        sl.SetCellValue("B4", "Desde: " & DATE1 & " Hasta: " & DATE2)
        'nombre columnas
        sl.SetCellValue("A7", "Previsión")
        sl.SetCellValue("B7", "Cant. Atenciones")
        sl.SetCellValue("C7", "Cant. Exámenes")
        sl.SetCellValue("D7", "Total Sistema")
        sl.SetCellValue("E7", "Total Usuarios")
        sl.SetCellValue("F7", "Total Copago")
        sl.SetCellValue("G7", "Total Pagado")
        For y = 1 To 7
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
        For i = Asc("B") To Asc("G")
            sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
            'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        Next i
        'estilo totales
        For i = Asc("A") To Asc("G")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        Next i
        sl.SetCellValue("A" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("G" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        If (PREVE = 0) Then
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\Todas" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        Else
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\" & Data_Prev(0).PREVE_DESC & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        End If
    End Function



    Function Gen_Excel2(ByVal MAIN_URL As String, ByVal PREVE As Long, ByVal DATE1 As String, ByVal DATE2 As String) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date_Operat
        Dim Data_Prev As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX)
        Dim NN_Procedencia As New N_PROCEDENCIAS_Y_CANT_MAX

        Data_Prev = NN_Procedencia.IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX_EStadi(DATE1, DATE2, PREVE)
        Dim Mx_Data(5, 0) As Object
        'Obtener parámetros para la consulta
        Dim Previs As Long = PREVE
        'Realizar Consulta
        If (Data_Prev.Count = 0) Then
            Return "null"
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(5, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_Prev.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(5, y)
            End If
            Mx_Data(0, y) = Data_Prev(y).PROC_DESC
            Mx_Data(1, y) = Data_Prev(y).TOTAL_AGEND_CUPO_NORMAL
            Mx_Data(2, y) = Data_Prev(y).TOTAL_AGEND_PRIORITARIO
            Mx_Data(3, y) = Data_Prev(y).TOTAL_AGEND_ESPONTANEO
            Mx_Data(4, y) = Data_Prev(y).TOTAL_AGEND_PAP
            Mx_Data(5, y) = Data_Prev(y).TOTAL_AGEND_PAP + Data_Prev(y).TOTAL_AGEND_ESPONTANEO + Data_Prev(y).TOTAL_AGEND_PRIORITARIO + Data_Prev(y).TOTAL_AGEND_CUPO_NORMAL
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
        sl.RenameWorksheet("Sheet1", "Total de Agendados por Cupo")
        'titulo de la tabla
        sl.SetCellValue("B2", "Total de Agendados por Cupo")
        If (PREVE = 0) Then
            sl.SetCellValue("B3", "Previsión: Todas")
        Else
            sl.SetCellValue("B3", "Previsión: " & Data_Prev(0).PROC_DESC)
        End If
        sl.SetCellValue("B4", "Desde: " & DATE1 & " Hasta: " & DATE2)
        'nombre columnas
        sl.SetCellValue("A7", "Procedencia")
        sl.SetCellValue("B7", "Cant. Cupo Normal")
        sl.SetCellValue("C7", "Cant. Cupo Prioritario")
        sl.SetCellValue("D7", "Cant. Cupo Espontáneo")
        sl.SetCellValue("E7", "Cant. Cupo PAP")
        sl.SetCellValue("F7", "Total")
        For y = 1 To 7
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
            For i = Asc("B") To Asc("F")
                sl.SetCellStyle(CStr(Chr(i) & y), formatonum)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next y
        'sumar columnas
        For i = Asc("B") To Asc("F")
            sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
            'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        Next i
        'estilo totales
        For i = Asc("A") To Asc("F")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        Next i
        sl.SetCellValue("A" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("F" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        If (PREVE = 0) Then
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\Todas" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        Else
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\" & Data_Prev(0).PROC_DESC & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        End If
    End Function
    Function Gen_Excel_DET(ByVal MAIN_URL As String, ByVal id As String, ByVal fecha As String, ByVal fecha2 As String) As String
        'Declaraciones internas
        Dim data_procedencia As List(Of E_TOTALES_DE_PROCEDENCIA_ATENCIONES_DETALLE)
        Dim NN_Procedencia As New N_PROCEDENCIAS_Y_CANT_MAX

        Dim data_dia As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX)
        Dim NN_dia As New N_PROCEDENCIAS_Y_CANT_MAX
        data_procedencia = NN_Procedencia.IRIS_WEBF_BUSCA_CANT_PREINGRESO_FECHA_ACTUAL_DETALLADO(id, fecha, fecha2)

        'fecha a string para buscar los totales por cada atención

        For Each dat In data_procedencia
            Dim fechita As String
            fechita = dat.PREI_FECHA_PRE.ToString("dd/MM/yyyy")
            fechita = fechita.Replace("-", "/")

            data_dia = NN_dia.examens2(id, fechita)

            If (data_dia.Count > 0) Then
                dat.TOTAL_CUPO_NORMAL = data_dia(0).AGEND_CUPO_NORMAL
                dat.TOTAL_ESPONTANEO = data_dia(0).AGEND_ESPONTANEO
                dat.TOTAL_PRIORITARIO = data_dia(0).AGEND_PRIORITARIO
            End If

        Next


        Dim Mx_Data(10, 0) As Object
        'Obtener parámetros para la consulta
        'Dim Previs As Long = PREVE
        'Realizar Consulta
        If (data_procedencia.Count = 0) Then
            Return "null"
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(10, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (data_procedencia.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(10, y)
            End If
            Dim dif_Norm, dif_Prio, dif_Espo As Integer

            Mx_Data(0, y) = Format(CDate(data_procedencia(y).PREI_FECHA_PRE), "dd/MM/yyyy")
            Mx_Data(1, y) = data_procedencia(y).TOTAL_CUPO_NORMAL
            Mx_Data(2, y) = data_procedencia(y).TOTAL_AGEND_CUPO_NORMAL

            dif_Norm = data_procedencia(y).TOTAL_CUPO_NORMAL - data_procedencia(y).TOTAL_AGEND_CUPO_NORMAL
            If dif_Norm < 0 Then
                dif_Norm = 0
            End If
            Mx_Data(3, y) = dif_Norm


            Mx_Data(4, y) = data_procedencia(y).TOTAL_PRIORITARIO
            Mx_Data(5, y) = data_procedencia(y).TOTAL_AGEND_PRIORITARIO

            dif_Prio = data_procedencia(y).TOTAL_PRIORITARIO - data_procedencia(y).TOTAL_AGEND_PRIORITARIO
            If dif_Prio < 0 Then
                dif_Prio = 0
            End If
            Mx_Data(6, y) = dif_Prio
            Mx_Data(7, y) = data_procedencia(y).TOTAL_ESPONTANEO
            Mx_Data(8, y) = data_procedencia(y).TOTAL_AGEND_ESPONTANEO

            dif_Espo = data_procedencia(y).TOTAL_ESPONTANEO - data_procedencia(y).TOTAL_AGEND_ESPONTANEO
            If dif_Espo < 0 Then
                dif_Espo = 0
            End If
            Mx_Data(9, y) = dif_Espo

            Mx_Data(10, y) = data_procedencia(y).TOTAL_CUPO_NORMAL + data_procedencia(y).TOTAL_PRIORITARIO + data_procedencia(y).TOTAL_ESPONTANEO
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
        sl.RenameWorksheet("Sheet1", "Total de Agendados por Cupo")
        'titulo de la tabla
        sl.SetCellValue("B2", "Total de Agendados por Cupo")
        'If (PREVE = 0) Then
        '    sl.SetCellValue("B3", "Previsión: Todas")
        'Else
        '    sl.SetCellValue("B3", "Previsión: " & Data_Prev(0).PROC_DESC)
        'End If
        sl.SetCellValue("B4", "Desde: " & fecha & " Hasta: " & fecha2)
        'nombre columnas
        sl.SetCellValue("A7", "Fecha")
        sl.SetCellValue("B7", "Cupo Normal")
        sl.SetCellValue("C7", "Agen. Normal")
        sl.SetCellValue("D7", "Disp.Normal")
        sl.SetCellValue("E7", "Cupo Prioritario")
        sl.SetCellValue("F7", "Agen. Prioritario")
        sl.SetCellValue("G7", "Disp. Prioritario")
        sl.SetCellValue("H7", "Cupo Espontáneo")
        sl.SetCellValue("I7", "Agen. Espontáneo")
        sl.SetCellValue("J7", "Disp. Espontáneo")
        sl.SetCellValue("K7", "Total")
        For y = 1 To 11
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
        'sl.SetCellStyle("B3", estilo2)
        sl.SetCellStyle("B4", estilo3)
        'dar formato numerico
        formatonum = sl.CreateStyle()
        formatonum.FormatCode = "###,###,##0"
        For y = 8 To ltabla + 1
            For i = Asc("B") To Asc("F")
                sl.SetCellStyle(CStr(Chr(i) & y), formatonum)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next y
        'sumar columnas
        'For i = Asc("B") To Asc("F")
        '    sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
        '    'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        'Next i
        'estilo totales
        For i = Asc("A") To Asc("F")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        Next i
        'sl.SetCellValue("A" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("K" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Cupo_Tot_Ate" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
End Class
