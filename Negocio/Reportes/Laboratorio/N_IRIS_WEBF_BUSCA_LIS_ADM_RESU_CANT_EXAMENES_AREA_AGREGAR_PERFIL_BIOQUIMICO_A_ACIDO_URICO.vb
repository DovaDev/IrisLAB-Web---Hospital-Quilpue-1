Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports iTextSharp.text
Imports iTextSharp.text.pdf

'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
    End Sub
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_EXAMES_REM(ByVal CF_COD As String, ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Return DD_Data.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_EXAMES_REM(CF_COD, DESDE, HASTA)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_CADA_PROCE_2(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PROCEDENCIA As Integer, ByVal CF_COD As String) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Return DD_Data.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_CADA_PROCE_2(DESDE, HASTA, ID_PROCEDENCIA, CF_COD)
    End Function
    Function IRIS_WEBF_BUSCA_EXAMS_REM() As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Return DD_Data.IRIS_WEBF_BUSCA_EXAMS_REM()
    End Function

    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO(ByVal ID_TP_PAGO As Integer, ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Return DD_Data.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO(ID_TP_PAGO, DESDE, HASTA)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_VALIDADOS(ByVal ID_TP_PAGO As Integer, ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Return DD_Data.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_VALIDADOS(ID_TP_PAGO, DESDE, HASTA)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_CADA_PROCE(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PROCEDENCIA As Integer, ByVal ID_CODIGO_FONASA As Integer) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Return DD_Data.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_CADA_PROCE(DESDE, HASTA, ID_PROCEDENCIA, ID_CODIGO_FONASA)
    End Function
    Function Gen_Excel_Desagrupado(ByVal MAIN_URL As String, ByVal ID_CODIGO_FONASA As Long, ByVal DATE1 As String, ByVal DATE2 As String) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date_Operat
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Dim Data_Exam As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Lista_REEEEEEE As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
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
        Data_Exam = NN_Exam.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO(ID_CODIGO_FONASAA, Date01, Date02)
        If (Data_Exam.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim perfiles_bioquimicos As Integer = 0
        Dim perfiles_hepaticos As Integer = 0
        Dim perfiles_lipidicos As Integer = 0

        If (Data_Exam.Count > 0) Then
            For a = 0 To Data_Exam.Count - 1
                If Data_Exam(a).ID_CODIGO_FONASA = 145 Then
                    perfiles_bioquimicos = Data_Exam(a).TOTAL_ATE
                End If
            Next a

            For b = 0 To Data_Exam.Count - 1
                If Data_Exam(b).ID_CODIGO_FONASA = 668 Then
                    perfiles_hepaticos = Data_Exam(b).TOTAL_ATE
                End If
            Next b

            For c = 0 To Data_Exam.Count - 1
                If Data_Exam(c).ID_CODIGO_FONASA = 76 Then
                    perfiles_lipidicos = Data_Exam(c).TOTAL_ATE
                End If
            Next c

            Dim found136 As Boolean = False
            Dim bili_total As Boolean = False
            Dim bili_direc As Boolean = False
            Dim fosfa As Boolean = False
            For i = 0 To Data_Exam.Count - 1
                'Data_Exam(i).ID_CODIGO_FONASA = 617 Or Acido urico
                'Data_Exam(i).ID_CODIGO_FONASA = 676 Or



                If Data_Exam(i).ID_CODIGO_FONASA = 103 Or Data_Exam(i).ID_CODIGO_FONASA = 66 Or Data_Exam(i).ID_CODIGO_FONASA = 558 Then
                    Data_Exam(i).TOTAL_ATE += perfiles_bioquimicos
                End If

                If Data_Exam(i).ID_CODIGO_FONASA = 463 Or Data_Exam(i).ID_CODIGO_FONASA = 57 Or Data_Exam(i).ID_CODIGO_FONASA = 94 Or Data_Exam(i).ID_CODIGO_FONASA = 136 Or Data_Exam(i).ID_CODIGO_FONASA = 137 Then
                    Data_Exam(i).TOTAL_ATE += perfiles_hepaticos
                End If

                If Data_Exam(i).ID_CODIGO_FONASA = 140 Or Data_Exam(i).ID_CODIGO_FONASA = 141 Or Data_Exam(i).ID_CODIGO_FONASA = 138 Then
                    Data_Exam(i).TOTAL_ATE += perfiles_lipidicos '140 colesterol total, el bioquimico y lipidico, 141 colesterol HDL
                End If

                'Identificar CF 136
                If (Data_Exam(i).ID_CODIGO_FONASA = 136) Then
                    found136 = True
                End If
                If Data_Exam(i).ID_CODIGO_FONASA = 57 Then
                    bili_total = True
                End If
                If Data_Exam(i).ID_CODIGO_FONASA = 463 Then
                    bili_direc = True
                End If
                If Data_Exam(i).ID_CODIGO_FONASA = 94 Then
                    fosfa = True
                End If
            Next i

            'Agregar 136 si no existe
            If (found136 = False) Then
                Dim xItem As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

                xItem.ID_CODIGO_FONASA = 136
                xItem.CF_DESC = "Transaminasas , Piruvica (GPT)"
                xItem.TOTAL_ATE = perfiles_hepaticos
                xItem.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem.SECC_ORDEN = 51
                xItem.CF_COD = "1026"

                Data_Exam.Add(xItem)
            End If

            If (fosfa = False) Then
                Dim xItem As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

                xItem.ID_CODIGO_FONASA = 94
                xItem.CF_DESC = "Fosfatasas Alcalinas"
                xItem.TOTAL_ATE = perfiles_hepaticos
                xItem.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem.SECC_ORDEN = 51
                xItem.CF_COD = "1010"

                Data_Exam.Add(xItem)
            End If

            If bili_total = False Then
                Dim xItem2 As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
                xItem2.ID_CODIGO_FONASA = 57
                xItem2.CF_DESC = "Bilirrubina total"
                xItem2.TOTAL_ATE = perfiles_hepaticos
                xItem2.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem2.SECC_ORDEN = 51
                xItem2.CF_COD = "1004"

                Data_Exam.Add(xItem2)

            End If

            If bili_direc = False Then
                Dim xItem3 As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
                xItem3.ID_CODIGO_FONASA = 463
                xItem3.CF_DESC = "Bilirrubina Directa"
                xItem3.TOTAL_ATE = perfiles_hepaticos
                xItem3.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem3.SECC_ORDEN = 51
                xItem3.CF_COD = "1003"

                Data_Exam.Add(xItem3)
            End If

            'ORDENARRRRRRRRR

            Lista_REEEEEEE = NN_Exam.Ordenar_REEEEE(Data_Exam)
        End If
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
        xls.SetCellValue(1, 1, "Censo REM 18")
        xls.SetCellStyle(1, 1, css_Title)
        xls.MergeWorksheetCells(1, 1, 1, 3)

        xls.SetCellValue(2, 1, "Desde: " & Format(Date01, "dd/MM/yyyy"))
        xls.SetCellStyle(2, 1, css_SubTitle)
        xls.MergeWorksheetCells(2, 1, 2, 3)

        xls.SetCellValue(3, 1, "Hasta: " & Format(Date02, "dd/MM/yyyy"))
        xls.SetCellStyle(3, 1, css_SubTitle)
        xls.MergeWorksheetCells(3, 1, 3, 3)


        'Colocar Cabeceras
        Dim x1 As Integer = 1
        Dim y1 As Integer = 5
        Dim x2 As Integer = x1
        Dim y2 As Integer = y1

        'Variables Lista
        Dim xi As Integer = 0
        Dim leTable As Integer = 0
        Dim newTable As Boolean = True
        Dim reeTOTAL As Integer = 0
        Dim HIPER_TOTAL As Integer = 0

        xls.SetColumnWidth(1, RowH + 00)
        xls.SetColumnWidth(2, RowH + 15)
        xls.SetColumnWidth(3, RowH + 00)

        While (xi < Lista_REEEEEEE.Count)
            If (xi > 0) Then
                If (Lista_REEEEEEE(xi).SECC_ALT_DESC <> Lista_REEEEEEE(xi - 1).SECC_ALT_DESC) Then
                    y2 += 1
                    xls.SetCellStyle(y2, x2, css_THead)
                    xls.SetCellValue(y2, x2, "Total:") : x2 += 1
                    xls.MergeWorksheetCells(y2, x1, y2, x2) : x2 += 1
                    xls.SetCellStyle(y2, x2, css_TCell_Number)
                    xls.SetCellValue(y2, x2, reeTOTAL) : x2 = x1

                    newTable = True
                    reeTOTAL = 0
                Else
                    newTable = False
                End If
            End If

            If (newTable = True) Then
                y2 += 2
                xls.SetCellStyle(y2, x2, css_THead)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).SECC_ALT_DESC)
                xls.MergeWorksheetCells(y2, x1, y2, x1 + 2)
            End If

            If (Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 145 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 668 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 76) Then
                x2 = x1
                y2 += 1

                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).CF_COD & ".-") : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_left)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).CF_DESC) : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_Number)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).TOTAL_ATE) : x2 = x1

                reeTOTAL += Lista_REEEEEEE(xi).TOTAL_ATE
                HIPER_TOTAL += Lista_REEEEEEE(xi).TOTAL_ATE
            End If

            xi += 1
        End While

        y2 += 3
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "TOTAL FINAL: ") : x2 += 1
        xls.MergeWorksheetCells(y2, x1, y2, x2) : x2 += 1
        xls.SetCellStyle(y2, x2, css_TCell_Number)
        xls.SetCellValue(y2, x2, HIPER_TOTAL) : x2 = x1


        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\REM_18" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Dim URL As String = HttpContext.Current.Request.Url.Authority
        Return URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
    Function Gen_Excel_Desagrupado_REM(ByVal MAIN_URL As String, ByVal DATE1 As String, ByVal DATE2 As String) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date_Operat
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Dim Data_Exam As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Lista_REEEEEEE As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Data_Prev_2 As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Data_exam_proc As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim NN_LugarTM As New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        Dim Data_LugarTM As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Dim NN_Exam_2 As New N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Dim Mx_Data(2, 0) As Object
        'Obtener fechas de la URL para luego transformarlas
        DATE1 = DATE1.Replace("-", "a")
        DATE2 = DATE2.Replace("-", "a")
        Dim Str_d1() As String = Split(DATE1, "a")
        Dim Str_d2() As String = Split(DATE2, "a")
        'Obtener parámetros para la consulta

        Dim Date01 As Date = NN_Date.strToDate(Str_d1(2), Str_d1(1), Str_d1(0))
        Dim Date02 As Date = NN_Date.strToDate(Str_d2(2), Str_d2(1), Str_d2(0))

        Data_LugarTM = NN_LugarTM.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()

        Data_Prev = NN_Exam.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO(0, Date01, Date02)

        If (Data_Prev.Count = 0) Then
            Return Nothing
            Exit Function
        End If


        'For i = 0 To Data_Prev.Count - 1
        '    Select Case Data_Prev(i).ID_CODIGO_FONASA
        '        Case 2
        '            Dim xItem As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

        '            xItem.ID_CODIGO_FONASA = 0
        '            xItem.CF_DESC = "Transaminasas , Piruvica (GPT)"
        '            xItem.TOTAL_ATE = 0
        '            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
        '            xItem.SECC_ORDEN = 1
        '            xItem.CF_COD = "0301003"

        '            Data_Prev.Add(xItem)

        '    End Select
        'Next i

        If (Data_Prev.Count > 0) Then

            Lista_REEEEEEE = NN_Exam.Ordenar_REEEEE(Data_Prev)

            For i = 0 To Lista_REEEEEEE.Count - 1
                For ii = 0 To Data_LugarTM.Count - 1
                    Data_Prev_2 = NN_Exam_2.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_CADA_PROCE(Date01, Date02, Data_LugarTM(ii).ID_PROCEDENCIA, Lista_REEEEEEE(i).ID_CODIGO_FONASA)
                    Dim Item As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

                    If Data_Prev_2.Count > 0 Then
                        Item.TOTAL_ATE = Data_Prev_2(0).TOTAL_ATE
                        Item.PROC_DESC = Data_LugarTM(ii).PROC_DESC
                        Item.ID_PROCEDENCIA = Data_LugarTM(ii).ID_PROCEDENCIA
                        Item.ID_CODIGO_FONASA = Data_Prev_2(0).ID_CODIGO_FONASA
                    Else
                        Item.TOTAL_ATE = 0
                        Item.PROC_DESC = Data_LugarTM(ii).PROC_DESC
                        Item.ID_PROCEDENCIA = Data_LugarTM(ii).ID_PROCEDENCIA
                        Item.ID_CODIGO_FONASA = Lista_REEEEEEE(i).ID_CODIGO_FONASA

                    End If
                    Data_exam_proc.Add(Item)
                Next ii
            Next i
        End If
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

        Dim css_TCell_Number_Bold = xls.CreateStyle
        css_TCell_Number.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Right)
        css_TCell_Number.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_TCell_Number.Font.Bold = True
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
        xls.SetCellValue(1, 1, "Censo REM")
        xls.SetCellStyle(1, 1, css_Title)
        xls.MergeWorksheetCells(1, 1, 1, 3)

        xls.SetCellValue(2, 1, "Desde: " & Format(Date01, "dd/MM/yyyy"))
        xls.SetCellStyle(2, 1, css_SubTitle)
        xls.MergeWorksheetCells(2, 1, 2, 3)

        xls.SetCellValue(3, 1, "Hasta: " & Format(Date02, "dd/MM/yyyy"))
        xls.SetCellStyle(3, 1, css_SubTitle)
        xls.MergeWorksheetCells(3, 1, 3, 3)


        'Colocar Cabeceras
        Dim x1 As Integer = 1
        Dim y1 As Integer = 5
        Dim x2 As Integer = x1
        Dim y2 As Integer = y1

        'Variables Lista
        Dim xi As Integer = 0
        Dim leTable As Integer = 0
        Dim newTable As Boolean = True
        Dim reeTOTAL As Integer = 0
        Dim HIPER_TOTAL As Integer = 0

        xls.SetColumnWidth(1, RowH - 10)
        xls.SetColumnWidth(2, RowH + 15)
        xls.SetColumnWidth(3, RowH - 17)
        xls.SetColumnWidth(4, RowH - 10)
        xls.SetColumnWidth(5, RowH - 10)
        xls.SetColumnWidth(6, RowH - 10)
        xls.SetColumnWidth(7, RowH - 10)
        xls.SetColumnWidth(8, RowH - 10)
        xls.SetColumnWidth(9, RowH - 10)
        xls.SetColumnWidth(10, RowH - 10)
        xls.SetColumnWidth(11, RowH - 10)
        xls.SetColumnWidth(12, RowH - 10)
        xls.SetColumnWidth(13, RowH - 10)
        xls.SetColumnWidth(14, RowH - 10)
        xls.SetColumnWidth(15, RowH - 10)
        xls.SetColumnWidth(16, RowH - 10)
        xls.SetColumnWidth(17, RowH - 10)
        xls.SetColumnWidth(18, RowH - 10)
        xls.SetColumnWidth(19, RowH - 10)
        xls.SetColumnWidth(20, RowH - 10)
        xls.SetColumnWidth(21, RowH - 10)
        xls.SetColumnWidth(22, RowH - 10)
        xls.SetColumnWidth(23, RowH - 10)
        xls.SetColumnWidth(24, RowH - 10)
        xls.SetColumnWidth(25, RowH - 10)
        xls.SetColumnWidth(26, RowH - 10)
        xls.SetColumnWidth(27, RowH - 10)
        xls.SetColumnWidth(28, RowH - 10)
        xls.SetColumnWidth(29, RowH - 10)
        xls.SetColumnWidth(30, RowH - 10)
        xls.SetColumnWidth(31, RowH - 10)
        xls.SetColumnWidth(32, RowH - 10)
        xls.SetColumnWidth(33, RowH - 10)
        xls.SetColumnWidth(34, RowH - 10)
        xls.SetColumnWidth(35, RowH - 10)
        xls.SetColumnWidth(36, RowH - 10)
        xls.SetColumnWidth(37, RowH - 10)
        xls.SetColumnWidth(38, RowH - 10)
        xls.SetColumnWidth(39, RowH - 10)

        y2 += 1
        For a = 0 To Data_LugarTM.Count - 1
            If a = 0 Then

                xls.SetCellStyle(y2, x2, css_THead)
                xls.SetCellValue(y2, x2, "Código") : x2 += 1
                xls.SetCellStyle(y2, x2, css_THead)
                xls.SetCellValue(y2, x2, "Glosa") : x2 += 1
                xls.SetCellStyle(y2, x2, css_THead)
                xls.SetCellValue(y2, x2, "Total") : x2 += 1
                xls.SetCellStyle(y2, x2, css_THead)
                xls.SetCellValue(y2, x2, Data_LugarTM(a).PROC_DESC) : x2 += 1

            Else
                xls.SetCellStyle(y2, x2, css_THead)
                xls.SetCellValue(y2, x2, Data_LugarTM(a).PROC_DESC) : x2 += 1
            End If
        Next a

        While (xi < Lista_REEEEEEE.Count)
            If (xi > 0) Then
                If (Lista_REEEEEEE(xi).SECC_ALT_DESC <> Lista_REEEEEEE(xi - 1).SECC_ALT_DESC) Then
                    y2 += 1
                    xls.SetCellStyle(y2, x2, css_THead)
                    xls.SetCellValue(y2, x2, "Total:") : x2 += 1
                    xls.MergeWorksheetCells(y2, x1, y2, x2) : x2 += 1
                    xls.SetCellStyle(y2, x2, css_TCell_Number)
                    xls.SetCellValue(y2, x2, reeTOTAL) : x2 = x1

                    newTable = True
                    reeTOTAL = 0
                Else
                    newTable = False
                End If
            End If

            If (newTable = True) Then
                y2 += 2
                x2 = x1
                xls.SetCellStyle(y2, x2, css_THead)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).SECC_ALT_DESC)
                xls.MergeWorksheetCells(y2, x1, y2, x1 + 2)
            End If

            x2 = x1
            y2 += 1

            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).CF_COD & ".-") : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_left)
            xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).CF_DESC) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_Number)
            xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).TOTAL_ATE) : x2 += 1

            'For b = 0 To Data_LugarTM.Count - 1
            For bb = 0 To Data_exam_proc.Count - 1
                'If Data_LugarTM(b).ID_PROCEDENCIA = Data_exam_proc(bb).ID_PROCEDENCIA And Lista_REEEEEEE(xi).ID_CODIGO_FONASA = Data_exam_proc(bb).ID_CODIGO_FONASA Then
                'xls.GetCellValueAsString(10, x2)
                'y1 = 10
                Dim VALUE_CELL As String = xls.GetCellValueAsString(6, x2)

                If Data_exam_proc(bb).PROC_DESC = VALUE_CELL And Lista_REEEEEEE(xi).ID_CODIGO_FONASA = Data_exam_proc(bb).ID_CODIGO_FONASA Then

                    xls.SetCellStyle(y2, x2, css_TCell_Number_Bold)
                    xls.SetCellValue(y2, x2, Data_exam_proc(bb).TOTAL_ATE) : x2 += 1
                Else
                    'xls.SetCellStyle(y2, x2, css_TCell_Number)
                    '    xls.SetCellValue(y2, x2, 0)
                End If
            Next bb
            'Next b

            x2 = x1

            reeTOTAL += Lista_REEEEEEE(xi).TOTAL_ATE
            HIPER_TOTAL += Lista_REEEEEEE(xi).TOTAL_ATE



            xi += 1
        End While

        y2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Total:") : x2 += 1
        xls.MergeWorksheetCells(y2, x1, y2, x2) : x2 += 1
        xls.SetCellStyle(y2, x2, css_TCell_Number)
        xls.SetCellValue(y2, x2, reeTOTAL) : x2 = x1

        y2 += 3
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "TOTAL FINAL: ") : x2 += 1
        xls.MergeWorksheetCells(y2, x1, y2, x2) : x2 += 1
        xls.SetCellStyle(y2, x2, css_TCell_Number_Bold)
        xls.SetCellValue(y2, x2, HIPER_TOTAL) : x2 = x1


        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\REM_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Dim URL As String = HttpContext.Current.Request.Url.Authority
        Return URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
    Function Gen_Excel_Desagrupado_VALIDADOS(ByVal MAIN_URL As String, ByVal ID_CODIGO_FONASA As Long, ByVal DATE1 As String, ByVal DATE2 As String) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date_Operat
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Dim Data_Exam As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Lista_REEEEEEE As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
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
        Data_Exam = NN_Exam.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_VALIDADOS(ID_CODIGO_FONASAA, Date01, Date02)
        If (Data_Exam.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim perfiles_bioquimicos As Integer = 0
        Dim perfiles_hepaticos As Integer = 0
        Dim perfiles_lipidicos As Integer = 0

        If (Data_Exam.Count > 0) Then
            For a = 0 To Data_Exam.Count - 1
                If Data_Exam(a).ID_CODIGO_FONASA = 145 Then
                    perfiles_bioquimicos = Data_Exam(a).TOTAL_ATE
                End If
            Next a

            For b = 0 To Data_Exam.Count - 1
                If Data_Exam(b).ID_CODIGO_FONASA = 668 Then
                    perfiles_hepaticos = Data_Exam(b).TOTAL_ATE
                End If
            Next b

            For c = 0 To Data_Exam.Count - 1
                If Data_Exam(c).ID_CODIGO_FONASA = 76 Then
                    perfiles_lipidicos = Data_Exam(c).TOTAL_ATE
                End If
            Next c

            Dim found136 As Boolean = False
            Dim bili_total As Boolean = False
            Dim bili_direc As Boolean = False
            Dim fosfa As Boolean = False
            For i = 0 To Data_Exam.Count - 1
                'Data_Exam(i).ID_CODIGO_FONASA = 617 Or Acido urico
                'Data_Exam(i).ID_CODIGO_FONASA = 676 Or



                If Data_Exam(i).ID_CODIGO_FONASA = 103 Or Data_Exam(i).ID_CODIGO_FONASA = 66 Or Data_Exam(i).ID_CODIGO_FONASA = 558 Then
                    Data_Exam(i).TOTAL_ATE += perfiles_bioquimicos
                End If

                If Data_Exam(i).ID_CODIGO_FONASA = 463 Or Data_Exam(i).ID_CODIGO_FONASA = 57 Or Data_Exam(i).ID_CODIGO_FONASA = 94 Or Data_Exam(i).ID_CODIGO_FONASA = 136 Or Data_Exam(i).ID_CODIGO_FONASA = 137 Then
                    Data_Exam(i).TOTAL_ATE += perfiles_hepaticos
                End If

                If Data_Exam(i).ID_CODIGO_FONASA = 140 Or Data_Exam(i).ID_CODIGO_FONASA = 141 Or Data_Exam(i).ID_CODIGO_FONASA = 138 Then
                    Data_Exam(i).TOTAL_ATE += perfiles_lipidicos '140 colesterol total, el bioquimico y lipidico, 141 colesterol HDL
                End If

                'Identificar CF 136
                If (Data_Exam(i).ID_CODIGO_FONASA = 136) Then
                    found136 = True
                End If
                If Data_Exam(i).ID_CODIGO_FONASA = 57 Then
                    bili_total = True
                End If
                If Data_Exam(i).ID_CODIGO_FONASA = 463 Then
                    bili_direc = True
                End If
                If Data_Exam(i).ID_CODIGO_FONASA = 94 Then
                    fosfa = True
                End If
            Next i

            'Agregar 136 si no existe
            If (found136 = False) Then
                Dim xItem As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

                xItem.ID_CODIGO_FONASA = 136
                xItem.CF_DESC = "Transaminasas , Piruvica (GPT)"
                xItem.TOTAL_ATE = perfiles_hepaticos
                xItem.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem.SECC_ORDEN = 51
                xItem.CF_COD = "1026"

                Data_Exam.Add(xItem)
            End If

            If (fosfa = False) Then
                Dim xItem As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

                xItem.ID_CODIGO_FONASA = 94
                xItem.CF_DESC = "Fosfatasas Alcalinas"
                xItem.TOTAL_ATE = perfiles_hepaticos
                xItem.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem.SECC_ORDEN = 51
                xItem.CF_COD = "1010"

                Data_Exam.Add(xItem)
            End If

            If bili_total = False Then
                Dim xItem2 As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
                xItem2.ID_CODIGO_FONASA = 57
                xItem2.CF_DESC = "Bilirrubina total"
                xItem2.TOTAL_ATE = perfiles_hepaticos
                xItem2.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem2.SECC_ORDEN = 51
                xItem2.CF_COD = "1004"

                Data_Exam.Add(xItem2)

            End If

            If bili_direc = False Then
                Dim xItem3 As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
                xItem3.ID_CODIGO_FONASA = 463
                xItem3.CF_DESC = "Bilirrubina Directa"
                xItem3.TOTAL_ATE = perfiles_hepaticos
                xItem3.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem3.SECC_ORDEN = 51
                xItem3.CF_COD = "1003"

                Data_Exam.Add(xItem3)
            End If

            'ORDENARRRRRRRRR
            Lista_REEEEEEE = NN_Exam.Ordenar_REEEEE(Data_Exam)
        End If
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
        xls.SetCellValue(1, 1, "Censo REM18 Validados")
        xls.SetCellStyle(1, 1, css_Title)
        xls.MergeWorksheetCells(1, 1, 1, 3)

        xls.SetCellValue(2, 1, "Desde: " & Format(Date01, "dd/MM/yyyy"))
        xls.SetCellStyle(2, 1, css_SubTitle)
        xls.MergeWorksheetCells(2, 1, 2, 3)

        xls.SetCellValue(3, 1, "Hasta: " & Format(Date02, "dd/MM/yyyy"))
        xls.SetCellStyle(3, 1, css_SubTitle)
        xls.MergeWorksheetCells(3, 1, 3, 3)


        'Colocar Cabeceras
        Dim x1 As Integer = 1
        Dim y1 As Integer = 5
        Dim x2 As Integer = x1
        Dim y2 As Integer = y1

        'Variables Lista
        Dim xi As Integer = 0
        Dim leTable As Integer = 0
        Dim newTable As Boolean = True
        Dim reeTOTAL As Integer = 0
        Dim HIPER_TOTAL As Integer = 0

        xls.SetColumnWidth(1, RowH + 00)
        xls.SetColumnWidth(2, RowH + 15)
        xls.SetColumnWidth(3, RowH + 00)

        While (xi < Lista_REEEEEEE.Count)
            If (xi > 0) Then
                If (Lista_REEEEEEE(xi).SECC_ALT_DESC <> Lista_REEEEEEE(xi - 1).SECC_ALT_DESC) Then
                    y2 += 1
                    xls.SetCellStyle(y2, x2, css_THead)
                    xls.SetCellValue(y2, x2, "Total:") : x2 += 1
                    xls.MergeWorksheetCells(y2, x1, y2, x2) : x2 += 1
                    xls.SetCellStyle(y2, x2, css_TCell_Number)
                    xls.SetCellValue(y2, x2, reeTOTAL) : x2 = x1

                    newTable = True
                    reeTOTAL = 0
                Else
                    newTable = False
                End If
            End If

            If (newTable = True) Then
                y2 += 2
                xls.SetCellStyle(y2, x2, css_THead)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).SECC_ALT_DESC)
                xls.MergeWorksheetCells(y2, x1, y2, x1 + 2)
            End If

            If (Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 145 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 668 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 76) Then
                x2 = x1
                y2 += 1

                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).CF_COD & ".-") : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_left)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).CF_DESC) : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_Number)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).TOTAL_ATE) : x2 = x1

                reeTOTAL += Lista_REEEEEEE(xi).TOTAL_ATE
                HIPER_TOTAL += Lista_REEEEEEE(xi).TOTAL_ATE
            End If

            xi += 1
        End While

        y2 += 3
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "TOTAL FINAL: ") : x2 += 1
        xls.MergeWorksheetCells(y2, x1, y2, x2) : x2 += 1
        xls.SetCellStyle(y2, x2, css_TCell_Number)
        xls.SetCellValue(y2, x2, HIPER_TOTAL) : x2 = x1


        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\REM_18" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Dim URL As String = HttpContext.Current.Request.Url.Authority
        Return URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
    Function Gen_Excel_Agrupado(ByVal MAIN_URL As String, ByVal ID_CODIGO_FONASA As Long, ByVal DATE1 As String, ByVal DATE2 As String) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date_Operat
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Dim Data_Exam As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Lista_REEEEEEE As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
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
        Data_Exam = NN_Exam.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO(ID_CODIGO_FONASAA, Date01, Date02)
        If (Data_Exam.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim perfiles_bioquimicos As Integer = 0
        Dim perfiles_hepaticos As Integer = 0
        Dim perfiles_lipidicos As Integer = 0

        If (Data_Exam.Count > 0) Then
            For a = 0 To Data_Exam.Count - 1
                If Data_Exam(a).ID_CODIGO_FONASA = 145 Then
                    perfiles_bioquimicos = Data_Exam(a).TOTAL_ATE
                End If
            Next a

            For b = 0 To Data_Exam.Count - 1
                If Data_Exam(b).ID_CODIGO_FONASA = 668 Then
                    perfiles_hepaticos = Data_Exam(b).TOTAL_ATE
                End If
            Next b

            For c = 0 To Data_Exam.Count - 1
                If Data_Exam(c).ID_CODIGO_FONASA = 76 Then
                    perfiles_lipidicos = Data_Exam(c).TOTAL_ATE
                End If
            Next c

            Dim found136 As Boolean = False
            Dim bili_total As Boolean = False
            Dim bili_direc As Boolean = False
            For i = 0 To Data_Exam.Count - 1
                'Data_Exam(i).ID_CODIGO_FONASA = 617 Or Acido urico
                'Data_Exam(i).ID_CODIGO_FONASA = 676 Or



                If Data_Exam(i).ID_CODIGO_FONASA = 103 Or Data_Exam(i).ID_CODIGO_FONASA = 66 Or Data_Exam(i).ID_CODIGO_FONASA = 558 Then
                    Data_Exam(i).TOTAL_ATE += perfiles_bioquimicos
                End If

                If Data_Exam(i).ID_CODIGO_FONASA = 463 Or Data_Exam(i).ID_CODIGO_FONASA = 57 Or Data_Exam(i).ID_CODIGO_FONASA = 94 Or Data_Exam(i).ID_CODIGO_FONASA = 136 Or Data_Exam(i).ID_CODIGO_FONASA = 137 Then
                    Data_Exam(i).TOTAL_ATE += perfiles_hepaticos
                End If

                If Data_Exam(i).ID_CODIGO_FONASA = 140 Or Data_Exam(i).ID_CODIGO_FONASA = 141 Or Data_Exam(i).ID_CODIGO_FONASA = 138 Then
                    Data_Exam(i).TOTAL_ATE += perfiles_lipidicos '140 colesterol total, el bioquimico y lipidico, 141 colesterol HDL
                End If

                'Identificar CF 136
                If (Data_Exam(i).ID_CODIGO_FONASA = 136) Then
                    found136 = True
                End If
                If Data_Exam(i).ID_CODIGO_FONASA = 57 Then
                    bili_total = True
                End If
                If Data_Exam(i).ID_CODIGO_FONASA = 463 Then
                    bili_direc = True
                End If
            Next i

            'Agregar 136 si no existe
            If (found136 = False) Then
                Dim xItem As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

                xItem.ID_CODIGO_FONASA = 136
                xItem.CF_DESC = "Transaminasas , Piruvica (GPT)"
                xItem.TOTAL_ATE = perfiles_hepaticos
                xItem.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem.SECC_ORDEN = 51
                xItem.CF_COD = "1026"

                Data_Exam.Add(xItem)
            End If

            If bili_total = False Then
                Dim xItem2 As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
                xItem2.ID_CODIGO_FONASA = 57
                xItem2.CF_DESC = "Bilirrubina total"
                xItem2.TOTAL_ATE = perfiles_hepaticos
                xItem2.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem2.SECC_ORDEN = 51
                xItem2.CF_COD = "1004"

                Data_Exam.Add(xItem2)

            End If

            If bili_direc = False Then
                Dim xItem3 As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
                xItem3.ID_CODIGO_FONASA = 463
                xItem3.CF_DESC = "Bilirrubina Directa"
                xItem3.TOTAL_ATE = perfiles_hepaticos
                xItem3.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem3.SECC_ORDEN = 51
                xItem3.CF_COD = "1003"

                Data_Exam.Add(xItem3)
            End If

            'ORDENARRRRRRRRR
            Lista_REEEEEEE = NN_Exam.Ordenar_REEEEE(Data_Exam)
        End If
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
        xls.SetCellValue(1, 1, "Censo REM 18")
        xls.SetCellStyle(1, 1, css_Title)
        xls.MergeWorksheetCells(1, 1, 1, 3)

        xls.SetCellValue(2, 1, "Desde: " & Format(Date01, "dd/MM/yyyy"))
        xls.SetCellStyle(2, 1, css_SubTitle)
        xls.MergeWorksheetCells(2, 1, 2, 3)

        xls.SetCellValue(3, 1, "Hasta: " & Format(Date02, "dd/MM/yyyy"))
        xls.SetCellStyle(3, 1, css_SubTitle)
        xls.MergeWorksheetCells(3, 1, 3, 3)


        'Colocar Cabeceras
        Dim x1 As Integer = 1
        Dim y1 As Integer = 5
        Dim x2 As Integer = x1
        Dim y2 As Integer = y1

        'Variables Lista
        Dim xi As Integer = 0
        Dim leTable As Integer = 0
        Dim newTable As Boolean = True
        Dim reeTOTAL As Integer = 0
        Dim HIPER_TOTAL As Integer = 0

        xls.SetColumnWidth(1, RowH + 00)
        xls.SetColumnWidth(2, RowH + 15)
        xls.SetColumnWidth(3, RowH + 00)

        While (xi < Lista_REEEEEEE.Count)
            If (xi > 0) Then
                If (Lista_REEEEEEE(xi).SECC_ALT_DESC <> Lista_REEEEEEE(xi - 1).SECC_ALT_DESC) Then
                    y2 += 1
                    xls.SetCellStyle(y2, x2, css_THead)
                    xls.SetCellValue(y2, x2, "Total:") : x2 += 1
                    xls.MergeWorksheetCells(y2, x1, y2, x2) : x2 += 1
                    xls.SetCellStyle(y2, x2, css_TCell_Number)
                    xls.SetCellValue(y2, x2, reeTOTAL) : x2 = x1

                    newTable = True
                    reeTOTAL = 0
                Else
                    newTable = False
                End If
            End If

            If (newTable = True) Then
                y2 += 2
                xls.SetCellStyle(y2, x2, css_THead)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).SECC_ALT_DESC)
                xls.MergeWorksheetCells(y2, x1, y2, x1 + 2)
            End If
            'Data_Exam(xi).ID_CODIGO_FONASA <> 676 And 'Test de tolerancia a la glucosa
            If (Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 103 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 140 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 141 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 66 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 558 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 138 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 463 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 57 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 94 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 136 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 137 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 140) Then
                x2 = x1
                y2 += 1

                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).CF_COD & ".-") : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_left)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).CF_DESC) : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_Number)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).TOTAL_ATE) : x2 = x1

                reeTOTAL += Lista_REEEEEEE(xi).TOTAL_ATE
                HIPER_TOTAL += Lista_REEEEEEE(xi).TOTAL_ATE
            End If

            xi += 1
        End While

        y2 += 3
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "TOTAL FINAL: ") : x2 += 1
        xls.MergeWorksheetCells(y2, x1, y2, x2) : x2 += 1
        xls.SetCellStyle(y2, x2, css_TCell_Number)
        xls.SetCellValue(y2, x2, HIPER_TOTAL) : x2 = x1

        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\REM_18" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Dim URL As String = HttpContext.Current.Request.Url.Authority
        Return URL & "/" & Replace(Relative_Path, "\", "/")

    End Function

    Function Gen_Excel_Agrupado_VALIDADOS(ByVal MAIN_URL As String, ByVal ID_CODIGO_FONASA As Long, ByVal DATE1 As String, ByVal DATE2 As String) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date_Operat
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Dim Data_Exam As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Lista_REEEEEEE As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
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
        Data_Exam = NN_Exam.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_VALIDADOS(ID_CODIGO_FONASAA, Date01, Date02)
        If (Data_Exam.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim perfiles_bioquimicos As Integer = 0
        Dim perfiles_hepaticos As Integer = 0
        Dim perfiles_lipidicos As Integer = 0

        If (Data_Exam.Count > 0) Then
            For a = 0 To Data_Exam.Count - 1
                If Data_Exam(a).ID_CODIGO_FONASA = 145 Then
                    perfiles_bioquimicos = Data_Exam(a).TOTAL_ATE
                End If
            Next a

            For b = 0 To Data_Exam.Count - 1
                If Data_Exam(b).ID_CODIGO_FONASA = 668 Then
                    perfiles_hepaticos = Data_Exam(b).TOTAL_ATE
                End If
            Next b

            For c = 0 To Data_Exam.Count - 1
                If Data_Exam(c).ID_CODIGO_FONASA = 76 Then
                    perfiles_lipidicos = Data_Exam(c).TOTAL_ATE
                End If
            Next c

            Dim found136 As Boolean = False
            Dim bili_total As Boolean = False
            Dim bili_direc As Boolean = False
            For i = 0 To Data_Exam.Count - 1
                'Data_Exam(i).ID_CODIGO_FONASA = 617 Or Acido uricoS
                'Data_Exam(i).ID_CODIGO_FONASA = 676 Or



                If Data_Exam(i).ID_CODIGO_FONASA = 103 Or Data_Exam(i).ID_CODIGO_FONASA = 66 Or Data_Exam(i).ID_CODIGO_FONASA = 558 Then
                    Data_Exam(i).TOTAL_ATE += perfiles_bioquimicos
                End If

                If Data_Exam(i).ID_CODIGO_FONASA = 463 Or Data_Exam(i).ID_CODIGO_FONASA = 57 Or Data_Exam(i).ID_CODIGO_FONASA = 94 Or Data_Exam(i).ID_CODIGO_FONASA = 136 Or Data_Exam(i).ID_CODIGO_FONASA = 137 Then
                    Data_Exam(i).TOTAL_ATE += perfiles_hepaticos
                End If

                If Data_Exam(i).ID_CODIGO_FONASA = 140 Or Data_Exam(i).ID_CODIGO_FONASA = 141 Or Data_Exam(i).ID_CODIGO_FONASA = 138 Then
                    Data_Exam(i).TOTAL_ATE += perfiles_lipidicos '140 colesterol total, el bioquimico y lipidico, 141 colesterol HDL
                End If

                'Identificar CF 136
                If (Data_Exam(i).ID_CODIGO_FONASA = 136) Then
                    found136 = True
                End If
                If Data_Exam(i).ID_CODIGO_FONASA = 57 Then
                    bili_total = True
                End If
                If Data_Exam(i).ID_CODIGO_FONASA = 463 Then
                    bili_direc = True
                End If
            Next i

            'Agregar 136 si no existe
            If (found136 = False) Then
                Dim xItem As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

                xItem.ID_CODIGO_FONASA = 136
                xItem.CF_DESC = "Transaminasas , Piruvica (GPT)"
                xItem.TOTAL_ATE = perfiles_hepaticos
                xItem.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem.SECC_ORDEN = 51
                xItem.CF_COD = "1026"

                Data_Exam.Add(xItem)
            End If

            If bili_total = False Then
                Dim xItem2 As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
                xItem2.ID_CODIGO_FONASA = 57
                xItem2.CF_DESC = "Bilirrubina total"
                xItem2.TOTAL_ATE = perfiles_hepaticos
                xItem2.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem2.SECC_ORDEN = 51
                xItem2.CF_COD = "1004"

                Data_Exam.Add(xItem2)

            End If

            If bili_direc = False Then
                Dim xItem3 As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
                xItem3.ID_CODIGO_FONASA = 463
                xItem3.CF_DESC = "Bilirrubina Directa"
                xItem3.TOTAL_ATE = perfiles_hepaticos
                xItem3.SECC_ALT_DESC = "SANGRE - BIOQUÍMICO"
                xItem3.SECC_ORDEN = 51
                xItem3.CF_COD = "1003"

                Data_Exam.Add(xItem3)
            End If
            'ORDENARRRRRRRRR

            Lista_REEEEEEE = NN_Exam.Ordenar_REEEEE(Data_Exam)
        End If
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
        xls.SetCellValue(1, 1, "Censo REM18 VALIDADOS")
        xls.SetCellStyle(1, 1, css_Title)
        xls.MergeWorksheetCells(1, 1, 1, 3)

        xls.SetCellValue(2, 1, "Desde: " & Format(Date01, "dd/MM/yyyy"))
        xls.SetCellStyle(2, 1, css_SubTitle)
        xls.MergeWorksheetCells(2, 1, 2, 3)

        xls.SetCellValue(3, 1, "Hasta: " & Format(Date02, "dd/MM/yyyy"))
        xls.SetCellStyle(3, 1, css_SubTitle)
        xls.MergeWorksheetCells(3, 1, 3, 3)


        'Colocar Cabeceras
        Dim x1 As Integer = 1
        Dim y1 As Integer = 5
        Dim x2 As Integer = x1
        Dim y2 As Integer = y1

        'Variables Lista
        Dim xi As Integer = 0
        Dim leTable As Integer = 0
        Dim newTable As Boolean = True
        Dim reeTOTAL As Integer = 0
        Dim HIPER_TOTAL As Integer = 0

        xls.SetColumnWidth(1, RowH + 00)
        xls.SetColumnWidth(2, RowH + 15)
        xls.SetColumnWidth(3, RowH + 00)

        While (xi < Lista_REEEEEEE.Count)
            If (xi > 0) Then
                If (Lista_REEEEEEE(xi).SECC_ALT_DESC <> Lista_REEEEEEE(xi - 1).SECC_ALT_DESC) Then
                    y2 += 1
                    xls.SetCellStyle(y2, x2, css_THead)
                    xls.SetCellValue(y2, x2, "Total:") : x2 += 1
                    xls.MergeWorksheetCells(y2, x1, y2, x2) : x2 += 1
                    xls.SetCellStyle(y2, x2, css_TCell_Number)
                    xls.SetCellValue(y2, x2, reeTOTAL) : x2 = x1

                    newTable = True
                    reeTOTAL = 0
                Else
                    newTable = False
                End If
            End If

            If (newTable = True) Then
                y2 += 2
                xls.SetCellStyle(y2, x2, css_THead)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).SECC_ALT_DESC)
                xls.MergeWorksheetCells(y2, x1, y2, x1 + 2)
            End If
            'Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 676 And 'Test de tolerancia a la glucosa
            If (Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 103 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 140 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 141 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 66 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 558 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 138 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 463 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 57 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 94 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 136 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 137 And Lista_REEEEEEE(xi).ID_CODIGO_FONASA <> 140) Then
                x2 = x1
                y2 += 1

                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).CF_COD & ".-") : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_left)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).CF_DESC) : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_Number)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).TOTAL_ATE) : x2 = x1

                reeTOTAL += Lista_REEEEEEE(xi).TOTAL_ATE
                HIPER_TOTAL += Lista_REEEEEEE(xi).TOTAL_ATE
            End If

            xi += 1
        End While

        y2 += 3
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "TOTAL FINAL: ") : x2 += 1
        xls.MergeWorksheetCells(y2, x1, y2, x2) : x2 += 1
        xls.SetCellStyle(y2, x2, css_TCell_Number)
        xls.SetCellValue(y2, x2, HIPER_TOTAL) : x2 = x1

        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\REM_18" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Dim URL As String = HttpContext.Current.Request.Url.Authority
        Return URL & "/" & Replace(Relative_Path, "\", "/")

    End Function

    Function Ordenar_REEEEE(ByVal List_In As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim List_Out As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)

        'Depurar!!!
        Debug.WriteLine("Lista entrada")
        For y = 0 To (List_In.Count - 1)
            Debug.WriteLine(List_In(y).SECC_ORDEN & " -- " & List_In(y).ID_CODIGO_FONASA & " -> " & List_In(y).CF_DESC)
        Next

        'Hacer una lista con los elementos estos en orden
        Dim memory_yeah As Integer = 0
        While (List_In.Count > 0)
            'Buscar el numero más alto
            Dim memory_Max As Integer = -1
            For y = 0 To (List_In.Count - 1)
                If (List_In(y).SECC_ORDEN > memory_Max) Then
                    memory_Max = List_In(y).SECC_ORDEN
                End If
            Next y
            memory_yeah = memory_Max + 1

            'Buscar más bajo
            Dim i As Integer = 0
            For y = 0 To (List_In.Count - 1)
                If (List_In(y).SECC_ORDEN < memory_yeah) Then
                    memory_yeah = List_In(y).SECC_ORDEN
                    i = y
                End If
            Next y

            'Mover elemento al otro lado
            List_Out.Add(List_In(i))
            List_In.RemoveAt(i)
        End While

        Return List_Out
    End Function
    Function Gen_Excel_Desagrupado_REM_2(ByVal MAIN_URL As String, ByVal DATE1 As String, ByVal DATE2 As String) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date_Operat
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Dim Data_Exam As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Lista_REEEEEEE As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Data_Prev_2 As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Data_exam_proc As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim NN_LugarTM As New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        Dim Data_LugarTM As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Dim NN_Exam_2 As New N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Dim Data_exams_rem As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim NN_Exam_exams_rem As New N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Dim Data_Prev_one_exam As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim NN_Exam_one_exam As New N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Dim Data_agregados As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Mx_Data(2, 0) As Object
        'Obtener fechas de la URL para luego transformarlas
        DATE1 = DATE1.Replace("-", "a")
        DATE2 = DATE2.Replace("-", "a")
        Dim Str_d1() As String = Split(DATE1, "a")
        Dim Str_d2() As String = Split(DATE2, "a")
        'Obtener parámetros para la consulta

        Dim Date01 As Date = NN_Date.strToDate(Str_d1(2), Str_d1(1), Str_d1(0))
        Dim Date02 As Date = NN_Date.strToDate(Str_d2(2), Str_d2(1), Str_d2(0))

        Data_LugarTM = NN_LugarTM.IRIS_WEBF_CMVM_BUSCA_PROCEDENCIA_ACTIVO_SIN_ID_USER()
        Data_exams_rem = NN_Exam_exams_rem.IRIS_WEBF_BUSCA_EXAMS_REM()

        If Data_exams_rem.Count > 0 Then
            For i = 0 To Data_exams_rem.Count - 1
                Data_Prev_one_exam = NN_Exam_one_exam.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_EXAMES_REM(Data_exams_rem(i).CF_COD, Date01, Date02)
                Dim item As E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
                If Data_Prev_one_exam.Count > 0 Then

                    item.TOTAL_ATE = Data_Prev_one_exam(0).TOTAL_ATE
                    item.CF_COD = Data_exams_rem(i).CF_COD
                    item.CF_DESC = Data_exams_rem(i).CF_DESC
                    item.ORDEN = Data_exams_rem(i).ORDEN
                    item.SECC_ALT_DESC = Data_exams_rem(i).SECC_ALT_DESC
                    item.ID_SECC_ALT = Data_exams_rem(i).ID_SECC_ALT
                    item.SECC_ORDEN = Data_exams_rem(i).SECC_ORDEN

                    Data_agregados.Add(item)
                Else
                    item.TOTAL_ATE = 0
                    item.CF_COD = Data_exams_rem(i).CF_COD
                    item.CF_DESC = Data_exams_rem(i).CF_DESC
                    item.ORDEN = Data_exams_rem(i).ORDEN
                    item.SECC_ALT_DESC = Data_exams_rem(i).SECC_ALT_DESC
                    item.ID_SECC_ALT = Data_exams_rem(i).ID_SECC_ALT
                    item.SECC_ORDEN = Data_exams_rem(i).SECC_ORDEN

                    Data_agregados.Add(item)
                End If

            Next i
        Else
        End If


        If (Data_agregados.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        If (Data_agregados.Count > 0) Then

            Lista_REEEEEEE = NN_Exam.Ordenar_REEEEE(Data_agregados)

            For i = 0 To Lista_REEEEEEE.Count - 1
                'If Lista_REEEEEEE(i).TOTAL_ATE > 0 Then
                For ii = 0 To Data_LugarTM.Count - 1
                    Data_Prev_2 = NN_Exam_2.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_CADA_PROCE_2(Date01, Date02, Data_LugarTM(ii).ID_PROCEDENCIA, Lista_REEEEEEE(i).CF_COD)
                    Dim Item As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

                    If Data_Prev_2.Count > 0 Then
                        Item.TOTAL_ATE = Data_Prev_2(0).TOTAL_ATE
                        Item.PROC_DESC = Data_LugarTM(ii).PROC_DESC
                        Item.ID_PROCEDENCIA = Data_LugarTM(ii).ID_PROCEDENCIA
                        Item.ID_CODIGO_FONASA = Data_Prev_2(0).ID_CODIGO_FONASA
                        Item.CF_COD = Data_Prev_2(0).CF_COD
                    Else
                        Item.TOTAL_ATE = 0
                        Item.PROC_DESC = Data_LugarTM(ii).PROC_DESC
                        Item.ID_PROCEDENCIA = Data_LugarTM(ii).ID_PROCEDENCIA
                        Item.ID_CODIGO_FONASA = Lista_REEEEEEE(i).ID_CODIGO_FONASA
                        Item.CF_COD = Lista_REEEEEEE(i).CF_COD

                    End If
                    Data_exam_proc.Add(Item)
                Next ii

            Next i

            'For i = 0 To Lista_REEEEEEE.Count - 1
            '    'If Lista_REEEEEEE(i).TOTAL_ATE > 0 Then

            '    Data_Prev_2 = NN_Exam_2.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_CADA_PROCE_2(Date01, Date02, Lista_REEEEEEE(i).CF_COD)
            '    Dim Item As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

            '        If Data_Prev_2.Count > 0 Then
            '            Item.TOTAL_ATE = Data_Prev_2(0).TOTAL_ATE
            '            Item.PROC_DESC = Data_LugarTM(ii).PROC_DESC
            '            Item.ID_PROCEDENCIA = Data_LugarTM(ii).ID_PROCEDENCIA
            '            Item.ID_CODIGO_FONASA = Data_Prev_2(0).ID_CODIGO_FONASA
            '            Item.CF_COD = Data_Prev_2(0).CF_COD
            '        Else
            '            Item.TOTAL_ATE = 0
            '            Item.PROC_DESC = Data_LugarTM(ii).PROC_DESC
            '            Item.ID_PROCEDENCIA = Data_LugarTM(ii).ID_PROCEDENCIA
            '            Item.ID_CODIGO_FONASA = Lista_REEEEEEE(i).ID_CODIGO_FONASA
            '            Item.CF_COD = Lista_REEEEEEE(i).CF_COD

            '        End If
            '        Data_exam_proc.Add(Item)


            '    Next i
        End If
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

        Dim css_TCell_Number_Bold = xls.CreateStyle
        css_TCell_Number.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Right)
        css_TCell_Number.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_TCell_Number.Font.Bold = True
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
        xls.SetCellValue(1, 1, "Censo REM")
        xls.SetCellStyle(1, 1, css_Title)
        xls.MergeWorksheetCells(1, 1, 1, 3)

        xls.SetCellValue(2, 1, "Desde: " & Format(Date01, "dd/MM/yyyy"))
        xls.SetCellStyle(2, 1, css_SubTitle)
        xls.MergeWorksheetCells(2, 1, 2, 3)

        xls.SetCellValue(3, 1, "Hasta: " & Format(Date02, "dd/MM/yyyy"))
        xls.SetCellStyle(3, 1, css_SubTitle)
        xls.MergeWorksheetCells(3, 1, 3, 3)


        'Colocar Cabeceras
        Dim x1 As Integer = 1
        Dim y1 As Integer = 5
        Dim x2 As Integer = x1
        Dim y2 As Integer = y1

        'Variables Lista
        Dim xi As Integer = 0
        Dim leTable As Integer = 0
        Dim newTable As Boolean = True
        Dim reeTOTAL As Integer = 0
        Dim HIPER_TOTAL As Integer = 0

        xls.SetColumnWidth(1, RowH - 10)
        xls.SetColumnWidth(2, RowH + 15)
        xls.SetColumnWidth(3, RowH - 17)
        xls.SetColumnWidth(4, RowH - 10)
        xls.SetColumnWidth(5, RowH - 10)
        xls.SetColumnWidth(6, RowH - 10)
        xls.SetColumnWidth(7, RowH - 10)
        xls.SetColumnWidth(8, RowH - 10)
        xls.SetColumnWidth(9, RowH - 10)
        xls.SetColumnWidth(10, RowH - 10)
        xls.SetColumnWidth(11, RowH - 10)
        xls.SetColumnWidth(12, RowH - 10)
        xls.SetColumnWidth(13, RowH - 10)
        xls.SetColumnWidth(14, RowH - 10)
        xls.SetColumnWidth(15, RowH - 10)
        xls.SetColumnWidth(16, RowH - 10)
        xls.SetColumnWidth(17, RowH - 10)
        xls.SetColumnWidth(18, RowH - 10)
        xls.SetColumnWidth(19, RowH - 10)
        xls.SetColumnWidth(20, RowH - 10)
        xls.SetColumnWidth(21, RowH - 10)
        xls.SetColumnWidth(22, RowH - 10)
        xls.SetColumnWidth(23, RowH - 10)
        xls.SetColumnWidth(24, RowH - 10)
        xls.SetColumnWidth(25, RowH - 10)
        xls.SetColumnWidth(26, RowH - 10)
        xls.SetColumnWidth(27, RowH - 10)
        xls.SetColumnWidth(28, RowH - 10)
        xls.SetColumnWidth(29, RowH - 10)
        xls.SetColumnWidth(30, RowH - 10)
        xls.SetColumnWidth(31, RowH - 10)
        xls.SetColumnWidth(32, RowH - 10)
        xls.SetColumnWidth(33, RowH - 10)
        xls.SetColumnWidth(34, RowH - 10)
        xls.SetColumnWidth(35, RowH - 10)
        xls.SetColumnWidth(36, RowH - 10)
        xls.SetColumnWidth(37, RowH - 10)
        xls.SetColumnWidth(38, RowH - 10)
        xls.SetColumnWidth(39, RowH - 10)

        y2 += 1
        For a = 0 To Data_LugarTM.Count - 1
            If a = 0 Then

                xls.SetCellStyle(y2, x2, css_THead)
                xls.SetCellValue(y2, x2, "Código") : x2 += 1
                xls.SetCellStyle(y2, x2, css_THead)
                xls.SetCellValue(y2, x2, "Glosa") : x2 += 1
                xls.SetCellStyle(y2, x2, css_THead)
                xls.SetCellValue(y2, x2, "Total") : x2 += 1
                xls.SetCellStyle(y2, x2, css_THead)
                xls.SetCellValue(y2, x2, Data_LugarTM(a).PROC_DESC) : x2 += 1

            Else
                xls.SetCellStyle(y2, x2, css_THead)
                xls.SetCellValue(y2, x2, Data_LugarTM(a).PROC_DESC) : x2 += 1
            End If
        Next a

        While (xi < Lista_REEEEEEE.Count)
            If (xi > 0) Then
                If (Lista_REEEEEEE(xi).SECC_ALT_DESC <> Lista_REEEEEEE(xi - 1).SECC_ALT_DESC) Then
                    y2 += 1
                    xls.SetCellStyle(y2, x2, css_THead)
                    xls.SetCellValue(y2, x2, "Total:") : x2 += 1
                    xls.MergeWorksheetCells(y2, x1, y2, x2) : x2 += 1
                    xls.SetCellStyle(y2, x2, css_TCell_Number)
                    xls.SetCellValue(y2, x2, reeTOTAL) : x2 = x1

                    newTable = True
                    reeTOTAL = 0
                Else
                    newTable = False
                End If
            End If

            If (newTable = True) Then
                y2 += 2
                x2 = x1
                xls.SetCellStyle(y2, x2, css_THead)
                xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).SECC_ALT_DESC)
                xls.MergeWorksheetCells(y2, x1, y2, x1 + 2)
            End If

            x2 = x1
            y2 += 1

            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).CF_COD & ".-") : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_left)
            xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).CF_DESC) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_Number)
            xls.SetCellValue(y2, x2, Lista_REEEEEEE(xi).TOTAL_ATE) : x2 += 1

            'For b = 0 To Data_LugarTM.Count - 1
            For bb = 0 To Data_exam_proc.Count - 1
                'If Data_LugarTM(b).ID_PROCEDENCIA = Data_exam_proc(bb).ID_PROCEDENCIA And Lista_REEEEEEE(xi).ID_CODIGO_FONASA = Data_exam_proc(bb).ID_CODIGO_FONASA Then
                'xls.GetCellValueAsString(10, x2)
                'y1 = 10
                Dim VALUE_CELL As String = xls.GetCellValueAsString(6, x2)

                If Data_exam_proc(bb).PROC_DESC = VALUE_CELL And Lista_REEEEEEE(xi).CF_COD = Data_exam_proc(bb).CF_COD Then

                    xls.SetCellStyle(y2, x2, css_TCell_Number_Bold)
                    xls.SetCellValue(y2, x2, Data_exam_proc(bb).TOTAL_ATE) : x2 += 1
                Else
                    'xls.SetCellStyle(y2, x2, css_TCell_Number)
                    '    xls.SetCellValue(y2, x2, 0)
                End If
            Next bb
            'Next b

            x2 = x1

            reeTOTAL += Lista_REEEEEEE(xi).TOTAL_ATE
            HIPER_TOTAL += Lista_REEEEEEE(xi).TOTAL_ATE



            xi += 1
        End While

        y2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Total:") : x2 += 1
        xls.MergeWorksheetCells(y2, x1, y2, x2) : x2 += 1
        xls.SetCellStyle(y2, x2, css_TCell_Number)
        xls.SetCellValue(y2, x2, reeTOTAL) : x2 = x1

        y2 += 3
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "TOTAL FINAL: ") : x2 += 1
        xls.MergeWorksheetCells(y2, x1, y2, x2) : x2 += 1
        xls.SetCellStyle(y2, x2, css_TCell_Number_Bold)
        xls.SetCellValue(y2, x2, HIPER_TOTAL) : x2 = x1


        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\REM_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Dim URL As String = HttpContext.Current.Request.Url.Authority
        Return URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
End Class