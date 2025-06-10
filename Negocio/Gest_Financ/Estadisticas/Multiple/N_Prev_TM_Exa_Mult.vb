Imports Entidades
Imports Datos
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web
Public Class N_Prev_TM_Exa_Mult
    'Declaraciones Generales
    Dim DD_Data As D_Prev_TM_Exa_Mult
    Sub New()
        DD_Data = New D_Prev_TM_Exa_Mult
    End Sub
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED(ByVal ID_TP_PAGO As Long, ByVal ID_PRE As Long, ByVal ID_PRE2 As Long, ByVal ID_PRE3 As Long, ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED)
        Return DD_Data.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED(ID_TP_PAGO, ID_PRE, ID_PRE2, ID_PRE3, DESDE, HASTA)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED_2(ByVal ID_TP_PAGO As Long, ByVal ID_PRE As Long, ByVal ID_PRE2 As Long, ByVal ID_PRE3 As Long, ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED)
        Return DD_Data.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED_2(ID_TP_PAGO, ID_PRE, ID_PRE2, ID_PRE3, DESDE, HASTA)
    End Function
    Function Gen_Excel(ByVal MAIN_URL As String, ByVal ID_TP_PAGO As Long, ByVal ID_PRE As Long, ByVal ID_PRE2 As Long,
                                            ByVal ID_PRE3 As Long, ByVal DATE_str01 As String, ByVal DATE_str02 As String, ByVal PROCE_DESC As String) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date_Operat
        Dim NN_Prev As New N_Prev_TM_Exa_Mult
        Dim Data_Prev_TM_Exa_Sum As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED)
        Dim Mx_Data(6, 0) As Object
        'Obtener parámetros para la consulta
        Dim paguito As Long = ID_TP_PAGO
        Dim Previs As Long = ID_PRE
        Dim previs2 As Long = ID_PRE2
        Dim previs3 As Long = ID_PRE3
        'Realizar Consulta
        Data_Prev_TM_Exa_Sum = NN_Prev.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED(ID_TP_PAGO, ID_PRE, ID_PRE2, ID_PRE3, DATE_str01, DATE_str02)
        If (Data_Prev_TM_Exa_Sum.Count = 0) Then
            Return "null"
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(3, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_Prev_TM_Exa_Sum.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(3, y)
            End If
            Mx_Data(0, y) = Data_Prev_TM_Exa_Sum(y).CF_COD
            Mx_Data(1, y) = Data_Prev_TM_Exa_Sum(y).CF_DESC
            Mx_Data(2, y) = Data_Prev_TM_Exa_Sum(y).TOTAL_ATE
            Mx_Data(3, y) = Data_Prev_TM_Exa_Sum(y).TOT_FONASA
            'Mx_Data(4, y) = Data_Prev_TM_Exa_Sum(y).TOTA_SIS
            'Mx_Data(5, y) = Data_Prev_TM_Exa_Sum(y).TOTA_USU
            'Mx_Data(6, y) = Data_Prev_TM_Exa_Sum(y).TOTA_COPA
            'Mx_Data(7, y) = CInt(Data_Prev_TM_Exa_Sum(y).TOTA_USU + Data_Prev_TM_Exa_Sum(y).TOTA_COPA)
            'Mx_Data(8, y) = ""
            'Mx_Data(9, y) = ""
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
        sl.RenameWorksheet("Sheet1", "Resumen de Atenciones por Lugar de TM y Previsión")
        'titulo de la tabla
        sl.SetCellValue("B2", "Resumen de Atenciones por Lugar de TM y Previsión")
        'If (Previs = 0) Then
        ' sl.SetCellValue("B3", "Lugar TM: Todas")
        'Else
        sl.SetCellValue("B3", "Lugar TM: " & PROCE_DESC)
            'End If
            sl.SetCellValue("B4", "Desde: " & DATE_str01 & " Hasta: " & DATE_str02)
        'nombre columnas
        sl.SetCellValue("A7", "Código")
        sl.SetCellValue("B7", "Exámenes")
        sl.SetCellValue("C7", "Cant. Atenciones")
        sl.SetCellValue("D7", "Cant. Exámenes")
        'sl.SetCellValue("E7", "Total Sistema")
        'sl.SetCellValue("F7", "Total Usuario")
        'sl.SetCellValue("G7", "Total Copago")
        'sl.SetCellValue("H7", "Total Pagado")
        'sl.SetCellValue("I7", "Valor Examen")
        'sl.SetCellValue("J7", "Total")
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
        For i = Asc("A") To Asc("D")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        Next i
        sl.SetCellValue("A" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("D" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        If (ID_TP_PAGO = 0) Then
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\Todos" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        Else
            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "IRISPDFDERIVADOS\" & Data_Prev_TM_Exa_Sum(0).CF_DESC & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        End If
    End Function

    Function Gen_Excel_2(ByVal MAIN_URL As String, ByVal ID_TP_PAGO As Long, ByVal ID_PRE As Long, ByVal ID_PRE2 As Long,
                                            ByVal ID_PRE3 As Long, ByVal DATE_str01 As String, ByVal DATE_str02 As String) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date_Operat
        Dim NN_Prev As New N_Prev_TM_Exa_Mult
        Dim Data_Prev_TM_Exa_Sum As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED)
        Dim Mx_Data(6, 0) As Object
        'Obtener parámetros para la consulta
        Dim paguito As Long = ID_TP_PAGO
        Dim Previs As Long = ID_PRE
        Dim previs2 As Long = ID_PRE2
        Dim previs3 As Long = ID_PRE3

        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Proce As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)

        'Consultar por previsiones activas
        Data_Proce = NN_Activos.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()

        '--------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Crear nuevo Dcto
        Dim xls As New SLDocument
        Dim RowH As Integer = 30

        'Definir estilos
        Dim css_Title = xls.CreateStyle
        css_Title.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        css_Title.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_Title.Font.Bold = True
        css_Title.Font.FontSize = 20

        Dim css_SubTitle = xls.CreateStyle
        css_SubTitle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        css_SubTitle.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_SubTitle.Font.Bold = True
        css_SubTitle.Font.FontSize = 16

        Dim css_THead = xls.CreateStyle
        css_THead.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
        css_THead.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_THead.Font.Bold = True
        css_THead.Font.FontSize = 12
        'css_THead.Font.FontColor = System.Drawing.Color.White
        css_THead.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.White, System.Drawing.Color.Orange)

        Dim css_TCell_left = xls.CreateStyle
        css_TCell_left.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        css_TCell_left.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_TCell_left.Font.Bold = False
        css_TCell_left.Font.FontSize = 10

        Dim css_TCell_center = xls.CreateStyle
        css_TCell_center.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
        css_TCell_center.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_TCell_center.Font.Bold = False
        css_TCell_center.Font.FontSize = 10

        Dim css_TCell_right = xls.CreateStyle
        css_TCell_right.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Right)
        css_TCell_right.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_TCell_right.Font.Bold = False
        css_TCell_right.Font.FontSize = 10

        Dim css_TCell_Date = xls.CreateStyle
        css_TCell_Date.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
        css_TCell_Date.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_TCell_Date.Font.Bold = False
        css_TCell_Date.Font.FontSize = 10
        css_TCell_Date.FormatCode = "dd/mm/yyyy"

        Dim css_TCell_Number = xls.CreateStyle
        css_TCell_Number.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Right)
        css_TCell_Number.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_TCell_Number.Font.Bold = False
        css_TCell_Number.Font.FontSize = 10
        css_TCell_Number.FormatCode = "###,###,##0"

        Dim css_TCell_Money = xls.CreateStyle
        css_TCell_Money.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Right)
        css_TCell_Money.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_TCell_Money.Font.Bold = False
        css_TCell_Money.Font.FontSize = 10
        css_TCell_Money.FormatCode = "$ ###,###,##0"

        Dim css_TCell_Percentage = xls.CreateStyle
        css_TCell_Percentage.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Right)
        css_TCell_Percentage.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_TCell_Percentage.Font.Bold = False
        css_TCell_Percentage.Font.FontSize = 10
        css_TCell_Percentage.FormatCode = "#,##0.00 %"



        'Colocar Título
        xls.SetCellValue(1, 1, "Resumen de Atenciones por Lugar de TM y Previsión")
        xls.SetCellStyle(1, 1, css_Title)
        xls.MergeWorksheetCells(1, 1, 1, 3)

        'xls.SetCellValue(2, 1, "Previsión: TODAS")
        'xls.SetCellStyle(2, 1, css_SubTitle)
        'xls.MergeWorksheetCells(2, 1, 2, 3)

        'xls.SetCellValue(3, 1, "Hasta: " & HASTA)
        'xls.SetCellStyle(3, 1, css_SubTitle)
        'xls.MergeWorksheetCells(3, 1, 3, 3)




        'Variables Lista
        Dim xi As Integer = 1
        Dim leTable As Integer = 0
        Dim newTable As Boolean = True
        Dim reeTOTAL As Integer = 0
        Dim HIPER_TOTAL As Integer = 0
        Dim indice_if As Integer = 0
        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""
        Dim muestra_comparados As String = ""

        xls.SetColumnWidth(1, RowH + 10)
        xls.SetColumnWidth(2, RowH + 00)
        xls.SetColumnWidth(3, RowH + 00)
        xls.SetColumnWidth(4, RowH + 00)
        xls.SetColumnWidth(5, RowH + 00)
        xls.SetColumnWidth(6, RowH + 15)
        'xls.SetColumnWidth(7, RowH + 00)
        'xls.SetColumnWidth(8, RowH + 00)
        'xls.SetColumnWidth(9, RowH + 00)
        'xls.SetColumnWidth(10, RowH + 15)
        'xls.SetColumnWidth(11, RowH + 15)
        'xls.SetColumnWidth(12, RowH + 00)

        'Colocar Cabeceras
        Dim x1 As Integer = 1
        Dim y1 As Integer = 5
        Dim x2 As Integer = x1
        Dim y2 As Integer = y1

        Dim T_Ate As Integer = 0
        Dim T_Exa As Integer = 0
        Dim T_Sis As Integer = 0
        Dim T_Usu As Integer = 0
        Dim T_Cop As Integer = 0
        Dim T_Pag As Integer = 0


        Dim titulin As Integer = 0
        For i = 0 To Data_Proce.Count - 1
            titulin = 0
            If Data_Proce(i).ID_PROCEDENCIA <> 0 Then
                Data_Prev_TM_Exa_Sum = NN_Prev.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED(ID_TP_PAGO, Data_Proce(i).ID_PROCEDENCIA, ID_PRE2, ID_PRE3, DATE_str01, DATE_str02)

                If Data_Prev_TM_Exa_Sum.Count > 0 Then
                    For ii = 0 To Data_Prev_TM_Exa_Sum.Count - 1
                        If titulin = 0 Then
                            T_Ate = 0
                            T_Exa = 0
                            T_Sis = 0
                            T_Usu = 0
                            T_Cop = 0
                            T_Pag = 0


                            y2 += 2
                            xls.SetCellStyle(y2, x2, css_THead)
                            xls.SetCellValue(y2, x2, "LUGAR TM") : x2 += 1
                            xls.SetCellStyle(y2, x2, css_THead)
                            xls.SetCellValue(y2, x2, "#") : x2 += 1
                            xls.SetCellStyle(y2, x2, css_THead)
                            xls.SetCellValue(y2, x2, "Código") : x2 += 1
                            xls.SetCellStyle(y2, x2, css_THead)
                            xls.SetCellValue(y2, x2, "Exámenes") : x2 += 1
                            xls.SetCellStyle(y2, x2, css_THead)
                            xls.SetCellValue(y2, x2, "Cant. Atenciones") : x2 += 1
                            xls.SetCellStyle(y2, x2, css_THead)
                            xls.SetCellValue(y2, x2, "Cant. Exámenes") : x2 += 1
                            'xls.SetCellStyle(y2, x2, css_THead)
                            'xls.SetCellValue(y2, x2, "Total Sistema") : x2 += 1
                            'xls.SetCellStyle(y2, x2, css_THead)
                            'xls.SetCellValue(y2, x2, "Total Usuario") : x2 += 1
                            'xls.SetCellStyle(y2, x2, css_THead)
                            'xls.SetCellValue(y2, x2, "Total Copago") : x2 += 1
                            'xls.SetCellStyle(y2, x2, css_THead)
                            'xls.SetCellValue(y2, x2, "Total Pagado") : x2 += 1
                            'xls.SetCellStyle(y2, x2, css_THead)
                            'xls.SetCellValue(y2, x2, "Valor Examen") : x2 += 1
                            'xls.SetCellStyle(y2, x2, css_THead)
                            'xls.SetCellValue(y2, x2, "Total") : x2 += 1


                            x2 = x1
                            y2 += 1
                            titulin = 1

                            xls.SetCellStyle(y2, x2, css_TCell_center)
                            xls.SetCellValue(y2, x2, Data_Proce(i).PROC_DESC) : x2 += 1
                        Else
                            xls.SetCellStyle(y2, x2, css_TCell_center)
                            xls.SetCellValue(y2, x2, "") : x2 += 1
                            titulin = 1
                        End If


                        xls.SetCellStyle(y2, x2, css_TCell_center)
                        xls.SetCellValue(y2, x2, ii + 1) : x2 += 1
                        xls.SetCellStyle(y2, x2, css_TCell_center)
                        xls.SetCellValue(y2, x2, Data_Prev_TM_Exa_Sum(ii).CF_COD) : x2 += 1
                        xls.SetCellStyle(y2, x2, css_TCell_center)
                        xls.SetCellValue(y2, x2, Data_Prev_TM_Exa_Sum(ii).CF_DESC) : x2 += 1
                        xls.SetCellStyle(y2, x2, css_TCell_center)
                        xls.SetCellValue(y2, x2, Data_Prev_TM_Exa_Sum(ii).TOTAL_ATE) : x2 += 1
                        xls.SetCellStyle(y2, x2, css_TCell_center)
                        xls.SetCellValue(y2, x2, Data_Prev_TM_Exa_Sum(ii).TOT_FONASA) : x2 = x1 'x2 += 1
                        'xls.SetCellStyle(y2, x2, css_TCell_center)
                        'xls.SetCellValue(y2, x2, Data_Prev_TM_Exa_Sum(ii).TOTA_SIS) : x2 += 1
                        'xls.SetCellStyle(y2, x2, css_TCell_center)
                        'xls.SetCellValue(y2, x2, Data_Prev_TM_Exa_Sum(ii).TOTA_USU) : x2 += 1
                        'xls.SetCellStyle(y2, x2, css_TCell_center)
                        'xls.SetCellValue(y2, x2, Data_Prev_TM_Exa_Sum(ii).TOTA_COPA) : x2 += 1
                        'xls.SetCellStyle(y2, x2, css_TCell_center)
                        'xls.SetCellValue(y2, x2, CInt(Data_Prev_TM_Exa_Sum(ii).TOTA_USU + Data_Prev_TM_Exa_Sum(ii).TOTA_COPA)) : x2 += 1
                        'xls.SetCellStyle(y2, x2, css_TCell_center)
                        'xls.SetCellValue(y2, x2, "") : x2 += x1
                        'xls.SetCellStyle(y2, x2, css_TCell_center)
                        'xls.SetCellValue(y2, x2, "") : x2 = x1

                        T_Ate += CInt(Data_Prev_TM_Exa_Sum(ii).TOTAL_ATE)
                        T_Exa += CInt(Data_Prev_TM_Exa_Sum(ii).TOT_FONASA)
                        T_Sis += CInt(Data_Prev_TM_Exa_Sum(ii).TOTA_SIS)
                        T_Usu += CInt(Data_Prev_TM_Exa_Sum(ii).TOTA_USU)
                        T_Cop += CInt(Data_Prev_TM_Exa_Sum(ii).TOTA_COPA)
                        T_Pag += CInt(Data_Prev_TM_Exa_Sum(ii).TOTA_USU + Data_Prev_TM_Exa_Sum(ii).TOTA_COPA)

                        y2 += 1

                        If ii = Data_Prev_TM_Exa_Sum.Count - 1 Then
                            xls.SetCellStyle(y2, x2, css_TCell_center)
                            xls.SetCellValue(y2, x2, "") : x2 += 1
                            xls.SetCellStyle(y2, x2, css_TCell_center)
                            xls.SetCellValue(y2, x2, "") : x2 += 1
                            xls.SetCellStyle(y2, x2, css_TCell_center)
                            xls.SetCellValue(y2, x2, "") : x2 += 1
                            xls.SetCellStyle(y2, x2, css_THead)
                            xls.SetCellValue(y2, x2, "TOTALES") : x2 += 1
                            xls.SetCellStyle(y2, x2, css_THead)
                            xls.SetCellValue(y2, x2, T_Ate) : x2 += 1
                            xls.SetCellStyle(y2, x2, css_THead)
                            xls.SetCellValue(y2, x2, T_Exa) : x2 = x1 'x2 += 1
                            'xls.SetCellStyle(y2, x2, css_THead)
                            'xls.SetCellValue(y2, x2, T_Sis) : x2 += 1
                            'xls.SetCellStyle(y2, x2, css_THead)
                            'xls.SetCellValue(y2, x2, T_Usu) : x2 += 1
                            'xls.SetCellStyle(y2, x2, css_THead)
                            'xls.SetCellValue(y2, x2, T_Cop) : x2 += 1
                            'xls.SetCellStyle(y2, x2, css_THead)
                            'xls.SetCellValue(y2, x2, T_Pag) : x2 += 1
                            'xls.SetCellStyle(y2, x2, css_TCell_center)
                            'xls.SetCellValue(y2, x2, "") : x2 += x1
                            'xls.SetCellStyle(y2, x2, css_TCell_center)
                            'xls.SetCellValue(y2, x2, "") : x2 = x1

                            xi += 1
                            y2 += 1

                        End If

                    Next ii
                End If
            End If

        Next i


        'TABLA TODOS*********************
        titulin = 0
            Data_Prev_TM_Exa_Sum = NN_Prev.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_P_TM_EXA_MED(ID_TP_PAGO, 0, ID_PRE2, ID_PRE3, DATE_str01, DATE_str02)

            If Data_Prev_TM_Exa_Sum.Count > 0 Then
                For ii = 0 To Data_Prev_TM_Exa_Sum.Count - 1
                    If titulin = 0 Then
                        T_Ate = 0
                        T_Exa = 0
                        T_Sis = 0
                        T_Usu = 0
                        T_Cop = 0
                        T_Pag = 0


                        y2 += 2
                        xls.SetCellStyle(y2, x2, css_THead)
                        xls.SetCellValue(y2, x2, "LUGAR TM") : x2 += 1
                        xls.SetCellStyle(y2, x2, css_THead)
                        xls.SetCellValue(y2, x2, "#") : x2 += 1
                        xls.SetCellStyle(y2, x2, css_THead)
                        xls.SetCellValue(y2, x2, "Código") : x2 += 1
                        xls.SetCellStyle(y2, x2, css_THead)
                        xls.SetCellValue(y2, x2, "Exámenes") : x2 += 1
                        xls.SetCellStyle(y2, x2, css_THead)
                        xls.SetCellValue(y2, x2, "Cant. Atenciones") : x2 += 1
                        xls.SetCellStyle(y2, x2, css_THead)
                    xls.SetCellValue(y2, x2, "Cant. Exámenes") : x2 += 1
                    'xls.SetCellStyle(y2, x2, css_THead)
                    'xls.SetCellValue(y2, x2, "Total Sistema") : x2 += 1
                    'xls.SetCellStyle(y2, x2, css_THead)
                    'xls.SetCellValue(y2, x2, "Total Usuario") : x2 += 1
                    'xls.SetCellStyle(y2, x2, css_THead)
                    'xls.SetCellValue(y2, x2, "Total Copago") : x2 += 1
                    'xls.SetCellStyle(y2, x2, css_THead)
                    'xls.SetCellValue(y2, x2, "Total Pagado") : x2 += 1
                    'xls.SetCellStyle(y2, x2, css_THead)
                    'xls.SetCellValue(y2, x2, "Valor Examen") : x2 += 1
                    'xls.SetCellStyle(y2, x2, css_THead)
                    'xls.SetCellValue(y2, x2, "Total") : x2 += 1


                    x2 = x1
                        y2 += 1
                        titulin = 1

                        xls.SetCellStyle(y2, x2, css_TCell_center)
                    xls.SetCellValue(y2, x2, "TODOS") : x2 += 1
                    Else
                        xls.SetCellStyle(y2, x2, css_TCell_center)
                        xls.SetCellValue(y2, x2, "") : x2 += 1
                        titulin = 1
                    End If


                    xls.SetCellStyle(y2, x2, css_TCell_center)
                    xls.SetCellValue(y2, x2, ii + 1) : x2 += 1
                    xls.SetCellStyle(y2, x2, css_TCell_center)
                    xls.SetCellValue(y2, x2, Data_Prev_TM_Exa_Sum(ii).CF_COD) : x2 += 1
                    xls.SetCellStyle(y2, x2, css_TCell_center)
                    xls.SetCellValue(y2, x2, Data_Prev_TM_Exa_Sum(ii).CF_DESC) : x2 += 1
                    xls.SetCellStyle(y2, x2, css_TCell_center)
                    xls.SetCellValue(y2, x2, Data_Prev_TM_Exa_Sum(ii).TOTAL_ATE) : x2 += 1
                    xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, Data_Prev_TM_Exa_Sum(ii).TOT_FONASA) : x2 = x1 'x2 += 1
                'xls.SetCellStyle(y2, x2, css_TCell_center)
                'xls.SetCellValue(y2, x2, Data_Prev_TM_Exa_Sum(ii).TOTA_SIS) : x2 += 1
                'xls.SetCellStyle(y2, x2, css_TCell_center)
                'xls.SetCellValue(y2, x2, Data_Prev_TM_Exa_Sum(ii).TOTA_USU) : x2 += 1
                'xls.SetCellStyle(y2, x2, css_TCell_center)
                'xls.SetCellValue(y2, x2, Data_Prev_TM_Exa_Sum(ii).TOTA_COPA) : x2 += 1
                'xls.SetCellStyle(y2, x2, css_TCell_center)
                'xls.SetCellValue(y2, x2, CInt(Data_Prev_TM_Exa_Sum(ii).TOTA_USU + Data_Prev_TM_Exa_Sum(ii).TOTA_COPA)) : x2 += 1
                'xls.SetCellStyle(y2, x2, css_TCell_center)
                'xls.SetCellValue(y2, x2, "") : x2 += x1
                'xls.SetCellStyle(y2, x2, css_TCell_center)
                'xls.SetCellValue(y2, x2, "") : x2 = x1

                T_Ate += CInt(Data_Prev_TM_Exa_Sum(ii).TOTAL_ATE)
                    T_Exa += CInt(Data_Prev_TM_Exa_Sum(ii).TOT_FONASA)
                    T_Sis += CInt(Data_Prev_TM_Exa_Sum(ii).TOTA_SIS)
                    T_Usu += CInt(Data_Prev_TM_Exa_Sum(ii).TOTA_USU)
                    T_Cop += CInt(Data_Prev_TM_Exa_Sum(ii).TOTA_COPA)
                    T_Pag += CInt(Data_Prev_TM_Exa_Sum(ii).TOTA_USU + Data_Prev_TM_Exa_Sum(ii).TOTA_COPA)

                    y2 += 1

                    If ii = Data_Prev_TM_Exa_Sum.Count - 1 Then
                        xls.SetCellStyle(y2, x2, css_TCell_center)
                        xls.SetCellValue(y2, x2, "") : x2 += 1
                        xls.SetCellStyle(y2, x2, css_TCell_center)
                        xls.SetCellValue(y2, x2, "") : x2 += 1
                        xls.SetCellStyle(y2, x2, css_TCell_center)
                        xls.SetCellValue(y2, x2, "") : x2 += 1
                        xls.SetCellStyle(y2, x2, css_THead)
                        xls.SetCellValue(y2, x2, "TOTALES") : x2 += 1
                        xls.SetCellStyle(y2, x2, css_THead)
                        xls.SetCellValue(y2, x2, T_Ate) : x2 += 1
                        xls.SetCellStyle(y2, x2, css_THead)
                    xls.SetCellValue(y2, x2, T_Exa) : x2 = x1 'x2 += 1
                    'xls.SetCellStyle(y2, x2, css_THead)
                    'xls.SetCellValue(y2, x2, T_Sis) : x2 += 1
                    'xls.SetCellStyle(y2, x2, css_THead)
                    'xls.SetCellValue(y2, x2, T_Usu) : x2 += 1
                    'xls.SetCellStyle(y2, x2, css_THead)
                    'xls.SetCellValue(y2, x2, T_Cop) : x2 += 1
                    'xls.SetCellStyle(y2, x2, css_THead)
                    'xls.SetCellValue(y2, x2, T_Pag) : x2 += 1
                    'xls.SetCellStyle(y2, x2, css_TCell_center)
                    'xls.SetCellValue(y2, x2, "") : x2 += x1
                    'xls.SetCellStyle(y2, x2, css_TCell_center)
                    'xls.SetCellValue(y2, x2, "") : x2 = x1

                    xi += 1
                        y2 += 1

                    End If

                Next ii
            End If



            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Todas" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        xls.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")









        ''Crear Ruta de Guardado
        'Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        'Dim Relative_Path As String = "IRISPDFDERIVADOS\Estados_de_Examenes_Por_Lote" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        'xls.SaveAs(Ruta_save_local & Relative_Path)

        ''Devolver la url del archivo generado
        'Dim URL As String = HttpContext.Current.Request.Url.Authority
        'Return URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
End Class