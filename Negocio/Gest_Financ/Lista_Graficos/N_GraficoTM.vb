Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports Datos
Imports Entidades
Public Class N_GraficoTM
    Dim DD_Data As D_GraficoTM
    Sub New()
        DD_Data = New D_GraficoTM
    End Sub
    Function IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_POR_LUGAR_TM1(ByVal PAC As Long, ByVal Año As Long, ByVal Mes As Long) As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_POR_LUGAR_TM1_TODOS)
        Return DD_Data.IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_POR_LUGAR_TM1(PAC, Año, Mes)
    End Function
    Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal Dll As Long, ByVal Año As Long) As String
        'Declaraciones Generales
        Dim Mx_Data(2, 0) As Object
        Dim NN_Date As New N_Date_Operat
        Dim NN_Med As New N_GraficoTM_Todo
        Dim NN_MM As New N_GraficoTM
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_POR_LUGAR_TM1_TODOS)
        Dim date_json_rial As New List(Of E_GraficoVisor_Json)
        'Declaraciones Internas
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Proce As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Dim TM As String
        'Consultar por previsiones activas
        Data_Proce = NN_Activos.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()
        For Y = 0 To Data_Proce.Count - 1
            If (Data_Proce(Y).ID_PROCEDENCIA = Dll) Then
                TM = Data_Proce(Y).PROC_DESC
            End If
        Next Y
        Dim MM As Integer
        MM = Format(Date.Now, "MM")
        If (Dll = 0) Then
            For dd = 1 To 12
                Dim Item As New E_GraficoVisor_Json
                If (MM >= dd) Then
                    Data_Med = NN_Med.IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_POR_LUGAR_TM1_TODOS(Año, dd)
                    Item.MES = Format(CDate("01/" & dd & "/2017"), "MMMM")
                    Item.CANT_ATE = Data_Med(0).CANT_ATE
                    Item.CANT_EXA = Data_Med(0).CANT_EXA
                    date_json_rial.Add(Item)
                End If
            Next dd
        Else
            For dd = 1 To 12
                Dim Item As New E_GraficoVisor_Json
                Data_Med = NN_MM.IRIS_WEBF_BUSCA_CANT_EXAMENES_ATE_POR_LUGAR_TM1(Dll, Año, dd)
                If (Data_Med.Count <> 0) Then
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
            Next dd
        End If
        'Vaciar Matriz
        ReDim Mx_Data(2, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For Y = 0 To (date_json_rial.Count - 1)
            If (Y > 0) Then
                ReDim Preserve Mx_Data(2, Y)
            End If

            Mx_Data(0, Y) = date_json_rial(Y).MES
            Mx_Data(1, Y) = date_json_rial(Y).CANT_ATE
            Mx_Data(2, Y) = date_json_rial(Y).CANT_EXA

        Next Y
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
        sl.RenameWorksheet("Sheet1", "Cantidad Anuales por Lugar de Toma de Muestra")
        'titulo de la tabla
        sl.SetCellValue("B2", "Cantidad Anuales por Lugar de Toma de Muestra")
        If (Dll = 0) Then
            sl.SetCellValue("B3", "Año: " & Año & " Lugar TM: Todas")
        Else
            sl.SetCellValue("B3", "Año: " & Año & " Lugar TM:" & TM)
        End If
        'If (ID_previviviviv = 0) Then
        '    sl.SetCellValue("B3", "Previsión: Todas")
        'Else
        '    sl.SetCellValue("B3", "Previsión: " & Data_Pac(0).PREVE_DESC)
        'End If

        'nombre columnas

        sl.SetCellValue("A7", "Meses")
        sl.SetCellValue("B7", "Cantidad de Atenciones")
        sl.SetCellValue("C7", "Cantidad de Exámenes")

        For Y = 1 To 4
            sl.SetColumnWidth(Y, 20.0)
        Next Y
        For Y = 0 To Mx_Data.GetUpperBound(1)
            For x = 0 To Mx_Data.GetUpperBound(0)
                sl.SetCellValue(Y + Excel_y, x + 1, Mx_Data(x, Y))
            Next x
            ltabla += 1
        Next Y
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
        For Y = 8 To ltabla + 1
            For i = Asc("B") To Asc("C")
                sl.SetCellStyle(CStr(Chr(i) & Y), formatonum)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next Y
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
            Dim Relative_Path As String = "IRISPDFDERIVADOS\Todas" & Año & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        Else
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\" & Año & TM & " " & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        End If
    End Function
End Class
