Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports Entidades
Imports Datos
Imports System.Drawing
Public Class N_LugarTM_Det_Async_Privados

End Class
Public Class N_LugarTM_Det_Async







End Class

Public Class N_LugarTM_Det_Async_REM
    'Declaraciones Generales
    Dim DD_Data As D_LugarTM_Det

    Dim STRLOCAL As String
    Dim URL_BASE As String
    Dim DESDE As String
    Dim HASTA As String
    Dim ID_CF As Integer
    Dim ID_FP As Integer
    Dim ID_PREV As Integer
    Dim E_DESDE As String
    Dim E_HASTA As String
    Dim EMAIL As String


    Sub New(ByVal xSTRLOCAL As String, ByVal xURL_BASE As String, ByVal xDESDE As String, ByVal xHASTA As String, ByVal xID_CF As Integer, ByVal xEMAIL As String)
        DD_Data = New D_LugarTM_Det

        STRLOCAL = xSTRLOCAL
        URL_BASE = xURL_BASE
        DESDE = xDESDE
        HASTA = xHASTA
        ID_CF = xID_CF
        EMAIL = xEMAIL


    End Sub





    Public Sub Gen_Excel_Async_REM()
        'Declaraciones Generales
        Dim NN_Date As New N_Date
        Dim Data_TM_Provision As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR45_6)
        Dim strFilename As String = ""
        Dim Mx_Data(14, 0) As Object

        '-----------------------------------------------------------------------------------------------------
        Dim NN_REX As New N_LugarTM_Det_Async_REM(STRLOCAL, URL_BASE, DESDE, HASTA, ID_CF, EMAIL)

        'PREPARAR CORREO
        Dim NN_CORREO As New N_EMAIL_QUILPUE
        NN_CORREO.Set_Destinat = EMAIL
        NN_CORREO.Set_Asunto = "REM - " & DESDE & " - " & HASTA
        If ((URL_BASE.Contains("http:\\") = False) And (URL_BASE.Contains("https:\\") = False)) Then
            URL_BASE = "http:\\" & URL_BASE
        End If

        'Declaraciones Generales
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

        Data_LugarTM = NN_LugarTM.IRIS_WEBF_CMVM_BUSCA_PROCEDENCIA_ACTIVO_SIN_ID_USER()
        Data_exams_rem = NN_Exam_exams_rem.IRIS_WEBF_BUSCA_EXAMS_REM()

        '---------- DECLARACIONES POR CADA EXAMEN --------------------------
        Dim leyden_0301110 As Integer = 0
        Dim mutacion_0301111 As Integer = 0
        Dim per_lipidico_0302034 As Integer = 0
        Dim per_hepatico_0302076 As Integer = 0
        Dim per_bioquimico_0302075 As Integer = 0
        Dim bilirrubina_0302013 As Integer = 0
        Dim electrolitos_x3_0302032 As Integer = 0
        Dim colesterol_total_0302067 As Integer = 0
        Dim colesterol_hdl_0302068 As Integer = 0
        Dim fosfatasas_alcalinas_0302040 As Integer = 0
        Dim gama_glutamil_0302045 As Integer = 0
        Dim transaminasas_las_2_0302063 As Integer = 0
        Dim trigliceridos_0302064 As Integer = 0
        Dim panel_de_glicemia_0302093 As Integer = 0


        '---------- FIN DECLARCIONES POR EXAMEN ----------------------------

        If Data_exams_rem.Count > 0 Then
            For i = 0 To Data_exams_rem.Count - 1          '<-------------------------------------------------
                Data_Prev_one_exam = NN_Exam_one_exam.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_EXAMES_REM(Data_exams_rem(i).CF_COD, DESDE, HASTA)
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

                If Data_exams_rem(i).CF_COD = "0301110" Then
                    leyden_0301110 += Data_Prev_one_exam(0).TOTAL_ATE
                End If

                Select Case Data_exams_rem(i).CF_COD
                    Case "0302013"      '84
                        bilirrubina_0302013 += Data_Prev_one_exam(0).TOTAL_ATE
                    Case "0302067"      '90
                        colesterol_total_0302067 += Data_Prev_one_exam(0).TOTAL_ATE
                    Case "0302068"      '91
                        colesterol_hdl_0302068 += Data_Prev_one_exam(0).TOTAL_ATE
                    Case "0302032"      '100
                        electrolitos_x3_0302032 += (Data_Prev_one_exam(0).TOTAL_ATE * 3)
                    Case "0302040"      '106
                        fosfatasas_alcalinas_0302040 += Data_Prev_one_exam(0).TOTAL_ATE
                    Case "0302045"      '109
                        gama_glutamil_0302045 += Data_Prev_one_exam(0).TOTAL_ATE
                    Case "0302063"      '125
                        transaminasas_las_2_0302063 += Data_Prev_one_exam(0).TOTAL_ATE
                    Case "0302064"      '126
                        trigliceridos_0302064 += Data_Prev_one_exam(0).TOTAL_ATE


                        '0302047 




                    Case "0302034"      '102
                        per_lipidico_0302034 += Data_Prev_one_exam(0).TOTAL_ATE
                    Case "0302076"
                        per_hepatico_0302076 += Data_Prev_one_exam(0).TOTAL_ATE
                    Case Else
                        'Return "error"
                End Select

            Next i
        Else
        End If


        If (Data_agregados.Count > 0) Then

            Lista_REEEEEEE = NN_Exam.Ordenar_REEEEE(Data_agregados)

            For i = 0 To Lista_REEEEEEE.Count - 1              '<----------------------------------------------------
                'If Lista_REEEEEEE(i).TOTAL_ATE > 0 Then
                For ii = 0 To Data_LugarTM.Count - 1            '<----------------------------------------------------
                    Data_Prev_2 = NN_Exam_2.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_CADA_PROCE_2(DESDE, HASTA, Data_LugarTM(ii).ID_PROCEDENCIA, Lista_REEEEEEE(i).CF_COD)
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
                'Else

                'End If

            Next i
        End If

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

        xls.SetCellValue(2, 1, "Desde: " & DESDE)
        xls.SetCellStyle(2, 1, css_SubTitle)
        xls.MergeWorksheetCells(2, 1, 2, 3)

        xls.SetCellValue(3, 1, "Hasta: " & HASTA)
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
        'Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\REM_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        xls.SaveAs(STRLOCAL & Relative_Path)

        'Devolver la url del archivo generado
        'Dim URL As String = HttpContext.Current.Request.Url.Authority

        URL_BASE = URL_BASE.Replace("\", "/")
        Dim HTML As String = Write_Email_rem(DESDE, HASTA, URL_BASE & "/" & Relative_Path.Replace("\", "/"), URL_BASE)
        NN_CORREO.Send_Email(HTML)




        'strFilename = "IRISPDFDERIVADOS\Pacientes_Examenes_Precios_Prev_LugarTM" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"

        'sl.SaveAs(STRLOCAL & strFilename)

        'URL_BASE = URL_BASE.Replace("\", "/")
        'Dim HTML As String = Write_Email(DESDE, HASTA, URL_BASE & "/" & strFilename.Replace("\", "/"), URL_BASE)
        'NN_CORREO.Send_Email(HTML)

    End Sub

#Region "HELPER"
    Private Function Crear_Estilo(ByVal sl As SLDocument, ByVal fontSize As Integer, ByVal isBold? As Boolean, ByVal fontName As String, ByVal horizontalAlignment? As HorizontalAlign, ByVal verticalAlignment As VerticalAlign?, ByVal fillColor? As System.Drawing.Color, ByVal isWrapText As Boolean) As SLStyle
        Dim estilo As SLStyle = sl.CreateStyle()

        If Not isBold Is Nothing Then
            With estilo.Font
                .Bold = isBold
            End With
        End If
        With estilo.Font
            .FontSize = fontSize
            .FontName = fontName
        End With
        With estilo.Alignment
            If horizontalAlignment IsNot Nothing Then
                .Horizontal = horizontalAlignment
            End If
            .Vertical = verticalAlignment
        End With
        If fillColor IsNot Nothing Then
            estilo.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, fillColor, System.Drawing.Color.Transparent)
        End If
        If verticalAlignment IsNot Nothing Then
            estilo.Alignment.Vertical = DocumentFormat.OpenXml.Drawing.Diagrams.VerticalAlignmentValues.Middle
        End If
        estilo.SetWrapText(isWrapText)
        Return estilo

    End Function

#End Region

    Public Sub Gen_Excel_Desagrupado_Async(List_Data As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES))
        'Declaraciones Generales                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
        Dim N_Date As New N_Date
        ' Lista  Objetos de Examenes REM
        Dim D_Data As New D_IRIS_WEBF_BUSCA_CANT_EXAMENES

        DESDE = DESDE.Replace("-", "/")
        HASTA = HASTA.Replace("-", "/")
        Dim Date_01 As Date = N_Date.strToDate(Split(DESDE, "/")(2), Split(DESDE, "/")(1), Split(DESDE, "/")(0))
        Dim Date_02 As Date = N_Date.strToDate(Split(HASTA, "/")(2), Split(HASTA, "/")(1), Split(HASTA, "/")(0))

        ' Obtenemos el nombre del mes
        Dim mes_nombre As String = Date_01.ToString("MMMM")
        ' Obtenemos el numero del mes
        Dim mes_numero As String = Date_01.Month.ToString("00")


        Dim NN_REX As New N_LugarTM_Det_Async_REM(STRLOCAL, URL_BASE, DESDE, HASTA, ID_CF, EMAIL)
        'Preparamos el correo
        Dim NN_CORREO As New N_EMAIL_QUILPUE
        NN_CORREO.Set_Destinat = EMAIL
        NN_CORREO.Set_Asunto = "REM - " & DESDE & " - " & HASTA
        If ((URL_BASE.Contains("http:\\") = False) And (URL_BASE.Contains("https:\\") = False)) Then
            URL_BASE = "http:\\" & URL_BASE
        End If


        'Declaraciones para Excel
        Dim sl As New SLDocument
        Dim tabla As SLTable
        Dim ltabla As Integer = 0

        Dim End_Column As Integer = 2
        Dim End_Column_Table As String = "BJ"



        '---------------------Estilos----------------------

        'Crear un nuevo estilo y restablecer el color de fondo
        Dim estilo_1 As SLStyle
        Dim estilo_2 As SLStyle
        Dim estilo_3 As SLStyle
        Dim estilo_4 As SLStyle

        Dim estilo_celda_1 As SLStyle
        Dim estilo_celda_2 As SLStyle
        Dim estilo_celda_3 As SLStyle
        Dim estilo_celda_4 As SLStyle


        Dim soft_orange As Color = ColorTranslator.FromHtml("#fcd5b4") ' color_1
        Dim light_gray_o As Color = ColorTranslator.FromHtml("#fde9d9") 'color_2
        Dim soft_yellow As Color = ColorTranslator.FromHtml("#fce74e") ' color_3
        Dim pale_yellow As Color = ColorTranslator.FromHtml("#ffffcc") 'color_4
        Dim light_gray As Color = ColorTranslator.FromHtml("#c0c0c0") 'color_5
        Dim light_blue As Color = ColorTranslator.FromHtml("#ccffff") 'color_6
        Dim gray_green As Color = ColorTranslator.FromHtml("#e2efda") 'color_7

        ' Estilos para celdas de titulo
        ' Crear estilos para celdas de título
        estilo_1 = Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, Nothing, False)
        estilo_2 = Crear_Estilo(sl, 8, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, Nothing, False)
        estilo_3 = Crear_Estilo(sl, 11, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, Nothing, False)
        estilo_4 = Crear_Estilo(sl, 9, False, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, Nothing, False)

        ' Crear estilos para celdas de información
        estilo_celda_1 = Crear_Estilo(sl, 8, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, soft_yellow, False)
        estilo_celda_2 = Crear_Estilo(sl, 8, False, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, pale_yellow, False)
        estilo_celda_3 = Crear_Estilo(sl, 9, False, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, gray_green, False)
        estilo_celda_4 = Crear_Estilo(sl, 9, False, "Verdana", Nothing, VerticalAlign.Middle, gray_green, False)

        ' Colores para columnas tipos de atención y otros
        Dim color_tp1 As Color = ColorTranslator.FromHtml("#f8cbad") ' Atención abierta
        Dim color_tp2 As Color = ColorTranslator.FromHtml("#ffe699") ' Atención cerrada
        Dim color_tp3 As Color = ColorTranslator.FromHtml("#a9d08e") ' UE
        Dim color_tp4 As Color = ColorTranslator.FromHtml("#9bc2e6") ' UEGO
        Dim color_tp5 As Color = ColorTranslator.FromHtml("#bfbfbf") ' Unidad de apoyo
        Dim color_tp6 As Color = ColorTranslator.FromHtml("#ff7c80") ' Atención extrahospitalaria

        ' Colores para procedencias 
        Dim color_proc1 As Color = ColorTranslator.FromHtml("#ffff00") ' proc 1 extra hosp
        Dim color_proc2 As Color = ColorTranslator.FromHtml("#00b0f0") ' proc 2 extra hosp
        Dim color_proc3 As Color = ColorTranslator.FromHtml("#a6a6a6") ' proc 3 extra hosp
        Dim color_proc4 As Color = ColorTranslator.FromHtml("#bf8f00") ' proc 4 extra hosp
        Dim color_proc5 As Color = ColorTranslator.FromHtml("#9bc2e6") ' proc 5 extra hosp

        ' Crear un estilo para las celdas con bordes internos
        Dim estilo_borde As New SLStyle()
        Dim estilo_borde_punto As New SLStyle()
        Dim estilo_borde_punto_2 As New SLStyle()
        Dim estilo_borde_final As New SLStyle()
        Dim estilo_borde_final_2 As New SLStyle()

        Dim estilo_sin_borde As New SLStyle()


        ' Establecer el borde con un color específico
        estilo_borde_punto.Border.SetBottomBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Dotted, Color.DarkGray)
        estilo_borde_punto.Border.SetTopBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Dotted, Color.DarkGray)
        estilo_borde_punto.Border.SetLeftBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)
        estilo_borde_punto.Border.SetRightBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)

        'Estilos qlos 2
        ' Establecer el borde con un color específico
        estilo_borde_punto_2.Border.SetBottomBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Dotted, Color.DarkGray)
        estilo_borde_punto_2.Border.SetTopBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Dotted, Color.DarkGray)
        estilo_borde_punto_2.Border.SetLeftBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)
        estilo_borde_punto_2.Border.SetRightBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)

        estilo_borde.Border.SetTopBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)
        estilo_borde.Border.SetBottomBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)
        estilo_borde.Border.SetLeftBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)
        estilo_borde.Border.SetRightBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)

        estilo_borde_final.Border.SetTopBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Dotted, Color.DarkGray)
        estilo_borde_final.Border.SetBottomBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)

        estilo_borde_final_2.Border.SetTopBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin, Color.Black)


        estilo_sin_borde.Border.SetTopBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.None, Color.Transparent)
        estilo_sin_borde.Border.SetBottomBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.None, Color.Transparent)
        estilo_sin_borde.Border.SetLeftBorder(DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.None, Color.Transparent)

        'Creacion de hojas
        sl.AddWorksheet("Sheet1")
#Region "Sheet1"

        'Seleccionamos Sheet1
        sl.SelectWorksheet("Sheet1")

        ' Princpio
        sl.SetCellValue("A1", "SEREMI: Región de Valparaíso")
        sl.SetCellValue("A2", "Establecimiento: Hospital Quilpué")
        sl.SetCellValue("A3", "Comuna: Quilpué")
        sl.SetCellValue("A4", $"Desde: {DESDE}, Hasta: {HASTA}")
        sl.SetCellValue("A5", "Año: " & Now.ToString("yyyy"))

        sl.SetCellValue("B7", "CENSO REM")
        ' Aplicar el estilo a las celdas A10:C10 y A11:C11

        sl.SetCellValue("A9", "CÓDIGOS")
        sl.MergeWorksheetCells("A9", "A10")
        sl.SetCellValue("B9", "GLOSA")
        sl.MergeWorksheetCells("B9", "B10")


        sl.SetCellValue("D9", "CANTIDAD DE ATENCIONES POR PROCEDENCIA")
        sl.MergeWorksheetCells("D9", "BK9")

        '----------------COLUMNAS TIPO ATENCIÓN----------------------
        sl.SetCellValue("D10", "ATENCIÓN ABIERTA")
        sl.MergeWorksheetCells("D10", "F10")

        sl.SetCellValue("G10", "ATENCIÓN CERRADA")
        sl.MergeWorksheetCells("G10", "S10")

        sl.SetCellValue("T10", "UE")
        sl.MergeWorksheetCells("T10", "V10")

        sl.SetCellValue("W10", "UEGO")

        sl.SetCellValue("X10", "UNIDAD DE APOYO")
        sl.MergeWorksheetCells("X10", "Y10")

        sl.SetCellValue("Z10", "ATENCIÓN EXTRAHOSPITALARIO")
        sl.MergeWorksheetCells("Z10", "BE10")



        '----------------COLUMNAS TOTAL GENERAL----------------------
        sl.SetCellValue("C9", "TOTAL GENERAL")
        sl.MergeWorksheetCells("C9", "C10")

        '----------------COLUMNAS PROCEDENCIAS----------------------
        'sl.SetCellValue("B11", "EXÁMENES DE LABORATORIO")

        ' ---------------COLUMN ATENCIÓN ABIERTA------------------------------
        sl.SetCellValue("D11", "CAE")
        sl.SetCellValue("E11", "USM-HDIURNO")
        sl.SetCellValue("F11", "PERSONAL")
        'sl.SetCellValue("G11", "TOTAL")
        ' ---------------COLUMN ATENCIÓN CERRADA------------------------------
        sl.SetCellValue("G11", "MQ1")
        sl.SetCellValue("H11", "MQ2")
        sl.SetCellValue("I11", "MQ3")
        sl.SetCellValue("J11", "UAPQ (Pabellon)")
        sl.SetCellValue("K11", "PEDIATRIA")
        sl.SetCellValue("L11", "NEONATOLOGIA")
        sl.SetCellValue("M11", "UPC")
        sl.SetCellValue("N11", "UCI-A")
        sl.SetCellValue("O11", "UTI")
        sl.SetCellValue("P11", "MATERNIDAD")
        sl.SetCellValue("Q11", "CMA")
        sl.SetCellValue("R11", "HOSP. DOMICI")
        sl.SetCellValue("S11", "UEA-HOSP")
        'sl.SetCellValue("U11", "TOTAL")
        '-----------------COLUMNAS UE--------------------------------------------
        sl.SetCellValue("T11", "UEA")
        sl.SetCellValue("U11", "UEI")
        sl.SetCellValue("V11", "SAUD")
        'sl.SetCellValue("Y11", "TOTAL")
        '-----------------COLUMNAS UEGO---------------------------------
        sl.SetCellValue("W11", "UEGO")
        '-----------------COLUMNAS UNIDAD DE APOYO---------------------------------
        sl.SetCellValue("X11", "ANATOMIA PATOLOGICA")
        sl.SetCellValue("Y11", "IMAGENOLOGIA")
        'sl.SetCellValue("AC11", "TOTAL")
        '-----------------COLUMNAS EXTRAHOSPITALARIO---------------------------------
        sl.SetCellValue("Z11", "CESFAM Alcalde Iván Manríquez")
        sl.SetCellValue("AA11", "CESFAM Aviador Acevedo")
        sl.SetCellValue("AB11", "CESFAM QUILPUE")
        sl.SetCellValue("AC11", "CESFAM y SAR Belloto SUR")
        sl.SetCellValue("AD11", "Cons.Pompeya")
        sl.SetCellValue("AE11", "CECOSF El Retiro")
        sl.SetCellValue("AF11", "Cons.El Belloto")
        sl.SetCellValue("AG11", "CESFAM Villa Alemana")
        sl.SetCellValue("AH11", "CESFAM Las Américas")
        sl.SetCellValue("AI11", "Cons.Eduardo Frei")
        sl.SetCellValue("AJ11", "CESFAM Juan Bautista Bravo Vega")
        sl.SetCellValue("AK11", "Cons.Cien Aguilas")
        sl.SetCellValue("AL11", "SAPU EDUARDO FREI")
        sl.SetCellValue("AM11", "CESFAM Limache")
        sl.SetCellValue("AN11", "CESFAM Olmue")
        sl.SetCellValue("AO11", "APS CABILDO")
        sl.SetCellValue("AP11", "APS Hijuelas")
        sl.SetCellValue("AQ11", "APS La Calera")
        sl.SetCellValue("AR11", "APS LA LIGUA")
        sl.SetCellValue("AS11", "APS Nogales ")
        sl.SetCellValue("AT11", "APS PETORCA ")
        sl.SetCellValue("AU11", "HOSPITAL DE LIMACHE")
        sl.SetCellValue("AV11", "Hosp.Geriatrico Paz de la tarde (limache)")
        sl.SetCellValue("AW11", "Hosp.Modular de Emergencia (limache)")
        sl.SetCellValue("AX11", "Hosp.Peñablanca")
        sl.SetCellValue("AY11", "Hosp.Gustavo Fricke")
        sl.SetCellValue("AZ11", "HOSPITAL CALERA")
        sl.SetCellValue("BA11", "Hospital de Petorca")
        sl.SetCellValue("BB11", "HOSPITAL DE QUILLOTA")
        sl.SetCellValue("BC11", "Hospital de Cabildo")
        sl.SetCellValue("BD11", "Hospital de La Ligua")
        sl.SetCellValue("BE11", "HOSPITAL QUINTERO")
        'sl.SetCellValue("BJ11", "OTROS")
        'sl.SetCellValue("BK11", "TOTAL")


        sl.SetCellStyle("A9", estilo_1)
        sl.SetCellStyle("A9", estilo_borde)
        sl.SetCellStyle("A10", estilo_borde)

        sl.SetCellStyle("B9", estilo_1)
        sl.SetCellStyle("B9", estilo_borde)
        sl.SetCellStyle("B10", estilo_borde)

        sl.SetCellStyle(9, 4, 9, 57, estilo_3)
        sl.SetCellStyle(10, 4, 10, 57, estilo_4)
        sl.SetCellStyle(9, 3, 11, 57, estilo_borde)

        sl.SetCellStyle("A11", estilo_2)
        sl.SetCellStyle("A11", estilo_borde)
        sl.SetCellStyle("C11", estilo_borde)
        sl.SetCellStyle("A7", estilo_3)
        sl.SetCellStyle("A8", estilo_3)


        ' Colores para columnas tp atención
        sl.SetCellStyle(10, 4, 10, 6, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_tp1, True))
        sl.SetCellStyle(10, 7, 10, 20, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_tp2, True))
        sl.SetCellStyle(10, 21, 10, 24, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_tp3, True))
        sl.SetCellStyle(10, 25, 10, 25, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_tp4, True))
        sl.SetCellStyle(10, 26, 10, 28, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_tp5, True))
        sl.SetCellStyle(10, 29, 10, 57, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_tp6, True))

        ' Colores para columnas procedencias
        sl.SetCellStyle(11, 29, 11, 32, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_proc1, True))
        sl.SetCellStyle(11, 33, 11, 39, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_proc2, True))
        sl.SetCellStyle(11, 40, 11, 49, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_proc3, True))
        sl.SetCellStyle(11, 50, 11, 54, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_proc4, True))
        sl.SetCellStyle(11, 55, 11, 55, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, color_proc5, True))

        'sl.FreezePanes(11, 2)
        sl.FreezePanes(0, 2)

        '-----------TABLA------------
        If (List_Data.Count > 0) Then
            ' Declarar una variable para realizar un seguimiento de la fila actual
            Dim fila_actual As Integer = 12

            ' Iterar sobre las secciones en el JSON
            Dim id_seccion_actual As Long
            Dim datos_seccion_actual As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES)
            Dim indice As Integer
            Dim totalDatos As Integer

            ' Ordenar la lista por ID_SECC_REM
            Dim sortedList = List_Data.OrderBy(Function(item) item.ID_SECC_REM).ToList()
            Dim contador As Integer = 0
            For Each seccion In sortedList.GroupBy(Function(item) item.ID_SECC_REM)

                ' Contador
                contador += 1

                ' Obtener la sección actual
                id_seccion_actual = seccion.Key
                datos_seccion_actual = seccion.ToList()

                'Debug.WriteLine("CONTADOR: " & contador)
                ' Establecer el nombre de la sección
                If (contador = 1) Then
                    sl.SetCellValue(fila_actual - 1, 2, datos_seccion_actual(0).AREA_DESC.ToUpper)
                    'fila_actual += 1
                End If
                If (contador = 6 And datos_seccion_actual(0).ID_AREA_REM = 2) Then
                    'Debug.WriteLine("CONTADOR 2: " & contador)
                    sl.SetCellValue(fila_actual, 2, datos_seccion_actual(0).AREA_DESC.ToUpper)
                    fila_actual += 1
                End If
                sl.SetCellStyle(fila_actual - 1, 2, fila_actual, 57, estilo_borde)
                sl.SetCellValue(fila_actual, 1, datos_seccion_actual(0).SECC_REM_DESC.ToUpper)

                sl.SetCellStyle(fila_actual, 1, fila_actual, 57, estilo_celda_1)
                sl.SetCellStyle(fila_actual, 1, fila_actual, 57, estilo_borde)

                sl.MergeWorksheetCells($"A{fila_actual}", $"B{fila_actual}")
                ' Sumar los TOTAL_ATE para esta sección
                'total_ate_seccion = datos_seccion_actual.Sum(Function(x) x.CANTIDAD)

                'total_ate_cerrada = datos_seccion_actual.Sum(Function(x) x.ATENCION_CERRADA)
                'total_ate_abierta = datos_seccion_actual.Sum(Function(x) x.ATENCION_ABIERTA)
                'total_ate_emergencia = datos_seccion_actual.Sum(Function(x) x.EMERGENCIA)

                'sl.SetCellValue(fila_actual, 3, total_ate_seccion)
                'sl.SetCellValue(fila_actual, 4, total_ate_cerrada)
                'sl.SetCellValue(fila_actual, 5, total_ate_abierta)
                'sl.SetCellValue(fila_actual, 6, total_ate_emergencia)

                ' Incrementar la fila actual para los datos
                fila_actual += 1
                totalDatos = datos_seccion_actual.Count
                indice = 1 ' Suponiendo que el índice del primer elemento es 1
                ' Iterar sobre los datos de la sección actual
                For Each dato In datos_seccion_actual

                    sl.SetCellValue(fila_actual, 1, dato.CF_COD_IRIS)
                    sl.SetCellValue(fila_actual, 2, dato.CF_DESC_HOSP)

                    ' TOTAL GENERAL
                    'sl.SetCellValue(fila_actual, 3, EnsureNonNegative(dato.CANTIDAD))
                    sl.SetCellValue(fila_actual, 3, EnsureNonNegative(calcularCantidadTotal(dato)))
                    ' ATENCIÓN ABIERTA
                    sl.SetCellValue(fila_actual, 4, EnsureNonNegative(dato.CAE))
                    sl.SetCellValue(fila_actual, 5, EnsureNonNegative(dato.USM_HDIURNO))
                    sl.SetCellValue(fila_actual, 6, EnsureNonNegative(dato.PERSONAL))
                    'sl.SetCellValue(fila_actual, 7, dato.TOTAL_ABIERTA)

                    ' ATENCIÓN CERRADA
                    sl.SetCellValue(fila_actual, 7, EnsureNonNegative(dato.MQ1))
                    sl.SetCellValue(fila_actual, 8, EnsureNonNegative(dato.MQ2))
                    sl.SetCellValue(fila_actual, 9, EnsureNonNegative(dato.MQ3))
                    sl.SetCellValue(fila_actual, 10, EnsureNonNegative(dato.UAPQ_PABELLON))
                    sl.SetCellValue(fila_actual, 11, EnsureNonNegative(dato.PEDIATRIA))
                    sl.SetCellValue(fila_actual, 12, EnsureNonNegative(dato.NEONATOLOGIA))
                    sl.SetCellValue(fila_actual, 13, EnsureNonNegative(dato.UPC))
                    sl.SetCellValue(fila_actual, 14, EnsureNonNegative(dato.UCI_A))
                    sl.SetCellValue(fila_actual, 15, EnsureNonNegative(dato.UTI))
                    sl.SetCellValue(fila_actual, 16, EnsureNonNegative(dato.MATERNIDAD))
                    sl.SetCellValue(fila_actual, 17, EnsureNonNegative(dato.CMA))
                    sl.SetCellValue(fila_actual, 18, EnsureNonNegative(dato.HOSP_DOCIMI))
                    sl.SetCellValue(fila_actual, 19, EnsureNonNegative(dato.UEA_HOSP))
                    'sl.SetCellValue(fila_actual, 21, dato.TOTAL_CERRADA)

                    ' UE
                    sl.SetCellValue(fila_actual, 20, EnsureNonNegative(dato.UEA))
                    sl.SetCellValue(fila_actual, 21, EnsureNonNegative(dato.UEI))
                    sl.SetCellValue(fila_actual, 22, EnsureNonNegative(dato.SAUD))
                    'sl.SetCellValue(fila_actual, 25, dato.TOTAL_UE)

                    ' UEGO
                    sl.SetCellValue(fila_actual, 23, EnsureNonNegative(dato.UEGO))

                    ' UNIDAD DE APOYO
                    sl.SetCellValue(fila_actual, 24, EnsureNonNegative(dato.ANATOMIA_PATO))
                    sl.SetCellValue(fila_actual, 25, EnsureNonNegative(dato.IMAGENOLOGIA))
                    'sl.SetCellValue(fila_actual, 29, dato.TOTAL_UNIDAD_APOYO)

                    ' ATENCIÓN EXTRAHOSPITALARIO
                    sl.SetCellValue(fila_actual, 26, EnsureNonNegative(dato.CESFAM_IVAN_MAN))
                    sl.SetCellValue(fila_actual, 27, EnsureNonNegative(dato.CESFAM_AV_AC))
                    sl.SetCellValue(fila_actual, 28, EnsureNonNegative(dato.CESFAM_QUILPUE)) ' FALTA
                    sl.SetCellValue(fila_actual, 29, EnsureNonNegative(dato.CESFAM_BELLOTO)) ' FALTA
                    sl.SetCellValue(fila_actual, 30, EnsureNonNegative(dato.CONS_POMPEYA))
                    sl.SetCellValue(fila_actual, 31, EnsureNonNegative(dato.CECOSF_RETIRO))
                    sl.SetCellValue(fila_actual, 32, EnsureNonNegative(dato.CONS_BELLOTO))
                    sl.SetCellValue(fila_actual, 33, EnsureNonNegative(dato.CESFAM_VILLA_AL))
                    sl.SetCellValue(fila_actual, 34, EnsureNonNegative(dato.CESFAM_AMERICAS))
                    sl.SetCellValue(fila_actual, 35, EnsureNonNegative(dato.CONS_EDUARDO_FREI))
                    sl.SetCellValue(fila_actual, 36, EnsureNonNegative(dato.CESFAM_JUAN_BT))
                    sl.SetCellValue(fila_actual, 37, EnsureNonNegative(dato.CONS_AGUILAS))
                    sl.SetCellValue(fila_actual, 38, EnsureNonNegative(dato.SAPU_FREI))
                    sl.SetCellValue(fila_actual, 39, EnsureNonNegative(dato.CESFAM_LIMACHE))
                    sl.SetCellValue(fila_actual, 40, EnsureNonNegative(dato.CESFAM_OLMUE))
                    sl.SetCellValue(fila_actual, 41, EnsureNonNegative(dato.APS_CABILDO))
                    sl.SetCellValue(fila_actual, 42, EnsureNonNegative(dato.APS_HIJUELAS))
                    sl.SetCellValue(fila_actual, 43, EnsureNonNegative(dato.APS_CALERA))
                    sl.SetCellValue(fila_actual, 44, EnsureNonNegative(dato.APS_LIGUA))
                    sl.SetCellValue(fila_actual, 45, EnsureNonNegative(dato.APS_NOGALES))
                    sl.SetCellValue(fila_actual, 46, EnsureNonNegative(dato.APS_PETORCA))
                    sl.SetCellValue(fila_actual, 47, EnsureNonNegative(dato.HOSP_LIMACHE))
                    sl.SetCellValue(fila_actual, 48, EnsureNonNegative(dato.HOSP_PETORCA)) ' HOSP. GERIATRICO PAZ DE LA TARDE (LIMACHE)
                    sl.SetCellValue(fila_actual, 49, EnsureNonNegative(dato.HOSP_MODULAR_LMCHE)) ' HOSP. MODULAR DE EMERGENCIA (LIMACHE)
                    sl.SetCellValue(fila_actual, 50, EnsureNonNegative(dato.HOSP_PENBLANCA))
                    sl.SetCellValue(fila_actual, 51, EnsureNonNegative(dato.HOSP_GUSTAVO_FRICKE))
                    sl.SetCellValue(fila_actual, 52, EnsureNonNegative(dato.HOSP_CALERA))
                    sl.SetCellValue(fila_actual, 53, EnsureNonNegative(dato.HOSP_PETORCA))
                    sl.SetCellValue(fila_actual, 54, EnsureNonNegative(dato.HOSP_QUILLOTA))
                    sl.SetCellValue(fila_actual, 55, EnsureNonNegative(dato.HOSP_CABILDO))
                    sl.SetCellValue(fila_actual, 56, EnsureNonNegative(dato.HOSP_LIGUA))
                    sl.SetCellValue(fila_actual, 57, EnsureNonNegative(dato.HOSP_QUINTERO))
                    'sl.SetCellValue(fila_actual, 62, 0) ' FALTA OTROS
                    'sl.SetCellValue(fila_actual, 63, dato.TOTAL_EXTRA) ' FALTA PROC OTROS

                    sl.SetCellStyle(fila_actual, 1, fila_actual, 57, estilo_borde_punto)
                    If indice = totalDatos Then
                        sl.SetCellValue((fila_actual + 1), 2, "TOTAL")
                        sl.SetCellStyle((fila_actual + 1), 2, (fila_actual + 1), 2, Crear_Estilo(sl, 9, True, "Verdana", Nothing, VerticalAlign.Middle, Nothing, False))
                        sl.SetCellStyle(fila_actual + 1, 1, fila_actual + 1, 57, estilo_borde_punto)
                        sl.SetCellStyle((fila_actual + 1), 1, (fila_actual + 1), 57, estilo_borde)
                        'total_ate_seccion = datos_seccion_actual.Sum(Function(x) x.CANTIDAD)
                        ' ATENCIÓN ABIERTA
                        'Debug.WriteLine($"Fila Actual: {fila_actual + 1}")
                        'Debug.WriteLine($"Cantidad de data: {datos_seccion_actual.Count()}")
                        sl.SetCellValue(fila_actual + 1, 3, $"=SUM(C{(fila_actual + 1) - datos_seccion_actual.Count()}:C{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 4, $"=SUM(D{(fila_actual + 1) - datos_seccion_actual.Count()}:D{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 5, $"=SUM(E{(fila_actual + 1) - datos_seccion_actual.Count()}:E{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 6, $"=SUM(F{(fila_actual + 1) - datos_seccion_actual.Count()}:F{fila_actual})")
                        'sl.SetCellValue((fila_actual + 1), 7, datos_seccion_actual.Sum(Function(x) x.TOTAL_ABIERTA))

                        ' ATENCIÓN CERRADA
                        sl.SetCellValue((fila_actual + 1), 7, $"=SUM(G{(fila_actual + 1) - datos_seccion_actual.Count()}:G{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 8, $"=SUM(H{(fila_actual + 1) - datos_seccion_actual.Count()}:H{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 9, $"=SUM(I{(fila_actual + 1) - datos_seccion_actual.Count()}:I{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 10, $"=SUM(J{(fila_actual + 1) - datos_seccion_actual.Count()}:J{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 11, $"=SUM(K{(fila_actual + 1) - datos_seccion_actual.Count()}:K{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 12, $"=SUM(L{(fila_actual + 1) - datos_seccion_actual.Count()}:L{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 13, $"=SUM(M{(fila_actual + 1) - datos_seccion_actual.Count()}:M{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 14, $"=SUM(N{(fila_actual + 1) - datos_seccion_actual.Count()}:N{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 15, $"=SUM(O{(fila_actual + 1) - datos_seccion_actual.Count()}:O{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 16, $"=SUM(P{(fila_actual + 1) - datos_seccion_actual.Count()}:P{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 17, $"=SUM(Q{(fila_actual + 1) - datos_seccion_actual.Count()}:Q{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 18, $"=SUM(R{(fila_actual + 1) - datos_seccion_actual.Count()}:R{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 19, $"=SUM(S{(fila_actual + 1) - datos_seccion_actual.Count()}:S{fila_actual})")
                        'sl.SetCellValue((fila_actual + 1), 21, datos_seccion_actual.Sum(Function(x) x.TOTAL_CERRADA))

                        ' UE
                        sl.SetCellValue((fila_actual + 1), 20, $"=SUM(T{(fila_actual + 1) - datos_seccion_actual.Count()}:T{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 21, $"=SUM(U{(fila_actual + 1) - datos_seccion_actual.Count()}:U{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 22, $"=SUM(V{(fila_actual + 1) - datos_seccion_actual.Count()}:V{fila_actual})")
                        'sl.SetCellValue((fila_actual + 1), 25, datos_seccion_actual.Sum(Function(x) x.TOTAL_UE))

                        ' UEGO
                        sl.SetCellValue(fila_actual + 1, 23, $"=SUM(W{(fila_actual + 1) - datos_seccion_actual.Count()}:W{fila_actual})")

                        ' UNIDAD DE APOYO
                        sl.SetCellValue((fila_actual + 1), 24, $"=SUM(X{(fila_actual + 1) - datos_seccion_actual.Count()}:X{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 25, $"=SUM(Y{(fila_actual + 1) - datos_seccion_actual.Count()}:Y{fila_actual})")
                        'sl.SetCellValue((fila_actual + 1), 29, datos_seccion_actual.Sum(Function(x) x.TOTAL_UNIDAD_APOYO))

                        ' ATENCIÓN EXTRAHOSPITALARIO
                        sl.SetCellValue((fila_actual + 1), 26, $"=SUM(Z{(fila_actual + 1) - datos_seccion_actual.Count()}:Z{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 27, $"=SUM(AA{(fila_actual + 1) - datos_seccion_actual.Count()}:AA{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 28, $"=SUM(AB{(fila_actual + 1) - datos_seccion_actual.Count()}:AB{fila_actual})") ' FALTA
                        sl.SetCellValue((fila_actual + 1), 29, $"=SUM(AC{(fila_actual + 1) - datos_seccion_actual.Count()}:AC{fila_actual})") ' FALTA
                        sl.SetCellValue((fila_actual + 1), 30, $"=SUM(AD{(fila_actual + 1) - datos_seccion_actual.Count()}:AD{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 31, $"=SUM(AE{(fila_actual + 1) - datos_seccion_actual.Count()}:AE{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 32, $"=SUM(AF{(fila_actual + 1) - datos_seccion_actual.Count()}:AF{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 33, $"=SUM(AG{(fila_actual + 1) - datos_seccion_actual.Count()}:AG{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 34, $"=SUM(AH{(fila_actual + 1) - datos_seccion_actual.Count()}:AH{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 35, $"=SUM(AI{(fila_actual + 1) - datos_seccion_actual.Count()}:AI{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 36, $"=SUM(AJ{(fila_actual + 1) - datos_seccion_actual.Count()}:AJ{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 37, $"=SUM(AK{(fila_actual + 1) - datos_seccion_actual.Count()}:AK{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 38, $"=SUM(AL{(fila_actual + 1) - datos_seccion_actual.Count()}:AL{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 39, $"=SUM(AM{(fila_actual + 1) - datos_seccion_actual.Count()}:AM{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 40, $"=SUM(AN{(fila_actual + 1) - datos_seccion_actual.Count()}:AN{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 41, $"=SUM(AO{(fila_actual + 1) - datos_seccion_actual.Count()}:AO{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 42, $"=SUM(AP{(fila_actual + 1) - datos_seccion_actual.Count()}:AP{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 43, $"=SUM(AQ{(fila_actual + 1) - datos_seccion_actual.Count()}:AQ{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 44, $"=SUM(AR{(fila_actual + 1) - datos_seccion_actual.Count()}:AR{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 45, $"=SUM(AS{(fila_actual + 1) - datos_seccion_actual.Count()}:AS{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 46, $"=SUM(AT{(fila_actual + 1) - datos_seccion_actual.Count()}:AT{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 47, $"=SUM(AU{(fila_actual + 1) - datos_seccion_actual.Count()}:AU{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 48, $"=SUM(AV{(fila_actual + 1) - datos_seccion_actual.Count()}:AV{fila_actual})") ' HOSP. GERIATRICO PAZ DE LA TARDE (LIMACHE)
                        sl.SetCellValue((fila_actual + 1), 49, $"=SUM(AW{(fila_actual + 1) - datos_seccion_actual.Count()}:AW{fila_actual})") ' HOSP. MODULAR DE EMERGENCIA (LIMACHE)
                        sl.SetCellValue((fila_actual + 1), 50, $"=SUM(AX{(fila_actual + 1) - datos_seccion_actual.Count()}:AX{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 51, $"=SUM(AY{(fila_actual + 1) - datos_seccion_actual.Count()}:AY{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 52, $"=SUM(AZ{(fila_actual + 1) - datos_seccion_actual.Count()}:AZ{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 53, $"=SUM(BA{(fila_actual + 1) - datos_seccion_actual.Count()}:BA{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 54, $"=SUM(BB{(fila_actual + 1) - datos_seccion_actual.Count()}:BB{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 55, $"=SUM(BC{(fila_actual + 1) - datos_seccion_actual.Count()}:BC{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 56, $"=SUM(BD{(fila_actual + 1) - datos_seccion_actual.Count()}:BD{fila_actual})")
                        sl.SetCellValue((fila_actual + 1), 57, $"=SUM(BE{(fila_actual + 1) - datos_seccion_actual.Count()}:BE{fila_actual})")
                        'sl.SetCellValue((fila_actual + 1), 62, 0) ' FALTA OTROS
                        'sl.SetCellValue((fila_actual + 1), 63, datos_seccion_actual.Sum(Function(x) x.TOTAL_EXTRA)) ' FALTA PROC OTROS

                        fila_actual += 1
                    End If

                    fila_actual += 1
                    indice += 1
                Next

                ' ESTILO FINAL DE TABLA
                'sl.SetCellStyle(fila_actual, 1, totalDatos, 2, estilo_borde)

                ' COLUMNA 1
                'sl.SetCellStyle(fila_actual, 1, totalDatos, 1, estilo_celda_3)
                ' COLUMNA 2
                'sl.SetCellStyle(fila_actual, 2, totalDatos, 2, estilo_celda_4)

                ' COLUMNAS 3 A 61
                'sl.SetCellStyle(fila_actual, 3, totalDatos, 61, estilo_celda_2)
                'sl.SetCellStyle(fila_actual, 3, totalDatos, 61, estilo_borde_punto)
            Next

            ' COLUMNAS PROCEDENCIA
        End If
        ' Calcula y agrega el total general al final de la tabla
        Dim totalGeneral As Double = 0

        ' Creamos estas variables para la fila Total
        Dim filaTotal As Integer = List_Data.Count + 9
        Dim columnaTextoTotal As Integer = 3 ' Columna C
        Dim columnaTotal As Integer = 5 ' Columna E



        'Ancho de Columnas Primera tabla
        sl.SetColumnWidth(1, 18)
        sl.SetColumnWidth(2, 90)

        'Ancho de Columnas Segunda tabla

        sl.SetColumnWidth(3, 61, 15)

        Dim totalGrupo2 As Integer = List_Data.GroupBy(Function(item) item.ID_SECCION).Count()
        Dim totalGrupos As Integer = List_Data.Count()
        sl.SetCellStyle(11, 1, 11, 57, Crear_Estilo(sl, 9, False, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, Nothing, True))
        sl.SetCellStyle(13, 3, ((totalGrupos * 2) + 12), 57, Crear_Estilo(sl, 9, True, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, Nothing, True))
        sl.SetCellStyle(13, 1, ((totalGrupos * 2) + 12), 1, Crear_Estilo(sl, 9, Nothing, "Verdana", HorizontalAlign.Center, VerticalAlign.Middle, Nothing, True))
        sl.SetCellStyle(13, 2, ((totalGrupos * 2) + 12), 2, Crear_Estilo(sl, 9, Nothing, "Verdana", Nothing, VerticalAlign.Middle, Nothing, True))
        'sl.SetCellStyle(13, 1, (totalGrupos + totalGrupo2 + 22), 62, estilo_borde_punto)
        'Debug.WriteLine("TOTAL GRUPOS {0}", totalGrupos)
        'Debug.WriteLine("TOTAL GRUPOS 2 {0}", totalGrupo2)
        ltabla += 10

#End Region

        'Nombrar hojas
        sl.RenameWorksheet("Sheet1", "REM")

        'insertar tabla
        tabla = sl.CreateTable("A10", CStr(End_Column_Table & ltabla - 4))
        tabla.SetTableStyle(SLTableStyleTypeValues.Medium9)
        sl.InsertTable(tabla)
        'Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")

        Dim hora_actual As DateTime = DateTime.Now
        Dim Relative_Path As String = "Excel\" & "REM_" & mes_nombre.ToUpper & "_" & Format(Date.Parse(HASTA), "yyyy") & "_" & hora_actual.ToString("HH-mm") & ".xlsx"
        sl.SaveAs(STRLOCAL & Relative_Path) 'Abrir el Archivo
        sl.Dispose()
        'Devolver la url del archivo generado
        URL_BASE = URL_BASE.Replace("\", "/")
        Dim HTML As String = Write_Email_rem(DESDE, HASTA, URL_BASE & "/" & Relative_Path.Replace("\", "/"), URL_BASE)
        NN_CORREO.Send_Email(HTML)
    End Sub
    ' Función para asegurarse de que el valor sea positivo
    Private Function EnsureNonNegative(value As Integer) As Integer
        If value < 0 Then
            Return 0
        End If
        Return value
    End Function
#Region "AYUDAS"
    Public Shared Function calcularCantidadTotal(ByVal item As E_IRIS_WEBF_BUSCA_CANT_EXAMENES) As Integer
        Dim total As Integer = 0

        total += item.CAE
        total += item.USM_HDIURNO
        total += item.PERSONAL
        total += item.MQ1
        total += item.MQ2
        total += item.MQ3
        total += item.UAPQ_PABELLON
        total += item.PEDIATRIA
        total += item.NEONATOLOGIA
        total += item.UPC
        total += item.UCI_A
        total += item.UTI
        total += item.MATERNIDAD
        total += item.CMA
        total += item.HOSP_DOCIMI
        total += item.UEA_HOSP
        total += item.UEA
        total += item.UEI
        total += item.SAUD
        total += item.UEGO
        total += item.ANATOMIA_PATO
        total += item.IMAGENOLOGIA
        total += item.CESFAM_IVAN_MAN
        total += item.CESFAM_AV_AC
        total += item.CESFAM_QUILPUE
        total += item.CESFAM_BELLOTO
        total += item.CONS_POMPEYA
        total += item.CECOSF_RETIRO
        total += item.CONS_BELLOTO
        total += item.CESFAM_VILLA_AL
        total += item.CESFAM_AMERICAS
        total += item.CONS_EDUARDO_FREI
        total += item.CESFAM_JUAN_BT
        total += item.CONS_AGUILAS
        total += item.SAPU_FREI
        total += item.CESFAM_LIMACHE
        total += item.CESFAM_OLMUE
        total += item.APS_CABILDO
        total += item.APS_HIJUELAS
        total += item.APS_CALERA
        total += item.APS_LIGUA
        total += item.APS_NOGALES
        total += item.APS_PETORCA
        total += item.HOSP_LIMACHE
        total += item.HOSP_GERIATRICO_LMCHE
        total += item.HOSP_MODULAR_LMCHE
        total += item.HOSP_PENBLANCA
        total += item.HOSP_GUSTAVO_FRICKE
        total += item.HOSP_CALERA
        total += item.HOSP_PETORCA
        total += item.HOSP_QUILLOTA
        total += item.HOSP_CABILDO
        total += item.HOSP_LIGUA
        total += item.HOSP_QUINTERO

        item.CANTIDAD = total
        Return item.CANTIDAD
    End Function

#End Region
    Private Function Write_Email_rem(ByVal Date_01 As String, ByVal Date_02 As String, ByVal link As String, ByVal url_base As String) As String
        Dim HTML_str As String = ""
        Debug.WriteLine("<img style='width: 40%; height: auto; margin: 0; padding: 0; float: left;' src='" & url_base & "/Imagenes/IrisLab_Logo_LARGO.png' />" & vbLf)
        HTML_str &= "<!DOCTYPE html>" & vbLf
        HTML_str &= "<html>" & vbLf
        HTML_str &= "<head>" & vbLf
        HTML_str &= "<meta http-equiv='Content-Type' content='text/html; charset=utf-8'/>" & vbLf
        HTML_str &= "<title>REM - Hospital Quilpué</title>" & vbLf
        HTML_str &= "</head>" & vbLf
        HTML_str &= "<body>" & vbLf
        HTML_str &= "    <link href='https://fonts.googleapis.com/css?family=Saira' rel='stylesheet'>" & vbLf
        HTML_str &= "    <table style='width: 90%; margin: 0 auto; font-family: 'Saira', sans-serif;'>" & vbLf
        HTML_str &= "        <tr>" & vbLf
        HTML_str &= "            <th align='center' style='padding: 0;'>" & vbLf
        HTML_str &= "                <img style='width: 40%; height: auto; margin: 0; padding: 0; float: left;' src='" & url_base & "/Imagenes/IrisLab_Logo_LARGO.png' />" & vbLf
        'HTML_str &= "                <img style='width: 40%; height: auto; margin: 0; padding: 0; float: right;' src='" & url_base & "/Imagenes/00_logo_holanda_full.png />" & vbLf
        HTML_str &= "            </th>" & vbLf
        HTML_str &= "        </tr>" & vbLf
        HTML_str &= "        <tr>" & vbLf
        HTML_str &= "            <td style='padding: 5px; padding-top: 15px;'>" & vbLf
        HTML_str &= "                <table style='width: 100%; border-collapse: collapse; border: 2px solid #2d43d5;'>" & vbLf
        HTML_str &= "                    <tr>" & vbLf
        HTML_str &= "                        <th colspan='2' style='color: #ffffff; background: #2d43d5; font-size: 22px; padding: 5px;'>Solicitud de Documento</th>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        HTML_str &= "                        <td>Documento Solicitado:</td>" & vbLf
        HTML_str &= "                        <td>REM - Hospital Quilpué</td>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        HTML_str &= "                        <td>Desde:</td>" & vbLf
        HTML_str &= "                        <td>" & Date_01 & "</td>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        HTML_str &= "                        <td>Hasta:</td>" & vbLf
        HTML_str &= "                        <td>" & Date_02 & "</td>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        'HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        'HTML_str &= "                        <td>Procedencia:</td>" & vbLf
        'HTML_str &= "                        <td>" & Me.ARRTEXT(0) & "</td>" & vbLf
        'HTML_str &= "                    </tr>" & vbLf
        'HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        'HTML_str &= "                        <td>Prevision:</td>" & vbLf
        'HTML_str &= "                        <td>" & Me.ARRTEXT(1) & "</td>" & vbLf
        'HTML_str &= "                    </tr>" & vbLf
        'HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        'HTML_str &= "                        <td>Programa:</td>" & vbLf
        'HTML_str &= "                        <td>" & Me.ARRTEXT(2) & "</td>" & vbLf
        'HTML_str &= "                    </tr>" & vbLf
        'HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        'HTML_str &= "                        <td>SubPrograma:</td>" & vbLf
        'HTML_str &= "                        <td>" & Me.ARRTEXT(3) & "</td>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        HTML_str &= "                    <tr align='center'>" & vbLf
        HTML_str &= "                        <td colspan='2'>" & vbLf

        If (String.IsNullOrEmpty(link) = False) Then
            HTML_str &= "                            <a href='" & link & "' style='text-decoration: none; font-size: 20px;'>Descargar Archivo</a>" & vbLf
        Else
            HTML_str &= "                            <strong style='text-decoration: none; font-size: 20px;'>La búsqueda solicitada no devolvió resultados.</strong>" & vbLf
        End If

        HTML_str &= "                        </td>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        HTML_str &= "                </table>" & vbLf
        HTML_str &= "            </td>" & vbLf
        HTML_str &= "        </tr>" & vbLf
        HTML_str &= "    </table>" & vbLf
        HTML_str &= "</body>" & vbLf
        HTML_str &= "</html>" & vbLf

        Return HTML_str
    End Function
End Class
