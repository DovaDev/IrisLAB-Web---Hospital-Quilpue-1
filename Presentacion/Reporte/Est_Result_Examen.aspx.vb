Imports Entidades
Imports Negocio
Imports Datos
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Imports System.Collections.Generic
Imports System.Runtime.Remoting

Public Class Est_Result_Examen
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Exam(idPrevision As Integer) As IEnumerable(Of Object)
        Return D_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS_POR_PREVISION(idPrevision)
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Det(ByVal idCodigoFonasa As Integer) As IEnumerable(Of Object)
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_DETERMINACIONES_POR_CODIGO_FONASA_EST
        Return NN_Exam.IRIS_WEBF_BUSCA_DETERMINACIONES_POR_CODIGO_FONASA_EST(idCodigoFonasa)
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_LugarTM() As IEnumerable(Of Object)
        Dim NN_LugarTM As New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        Return NN_LugarTM.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_prevision() As IEnumerable(Of Object)
        Dim NN = New N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        Return NN.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()
    End Function
    <Services.WebMethod()>
    Public Shared Function Fetch_Datatable(desde As String,
                                           hasta As String,
                                           idProcedencia As Integer,
                                           idPrevision As Integer,
                                           idCodigoFonasa As Integer,
                                           idDeterminacion As Integer) As IEnumerable(Of Object)
        Return N_IRIS_WEBF_BUSCA_ESTADISTICA_RESULTADOS_POR_DETERMINACION.IRIS_WEBF_BUSCA_ESTADISTICA_RESULTADOS_POR_DETERMINACION(desde, hasta, idProcedencia, idPrevision, idCodigoFonasa, idDeterminacion)
    End Function
    <Services.WebMethod()>
    Public Shared Function Excel(DOMAIN_URL As String,
                                 desde As String,
                                 hasta As String,
                                 idProcedencia As Integer,
                                 idPrevision As Integer,
                                 idCodigoFonasa As Integer,
                                 idDeterminacion As Integer) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""

        'Declaraciones internas

        Dim lista = N_IRIS_WEBF_BUSCA_ESTADISTICA_RESULTADOS_POR_DETERMINACION.IRIS_WEBF_BUSCA_ESTADISTICA_RESULTADOS_POR_DETERMINACION(desde,
                                                                                                                                        hasta,
                                                                                                                                        idProcedencia,
                                                                                                                                        idPrevision,
                                                                                                                                        idCodigoFonasa,
                                                                                                                                        idDeterminacion)
        'creamos el objeto SLDocument el cual creara el excel
        Dim sl As SLDocument = New SLDocument
        Dim tabla As SLTable
        'Dim estilo As SLStyle
        'Dim estilo2 As SLStyle
        'Dim estilo3 As SLStyle
        Dim Excel_x As Integer
        Dim Excel_y As Integer
        Excel_x = 1
        Excel_y = 9
        Dim ltabla As Integer = 0
        Dim edad As Integer = 0
        Dim idate As String = ""

        Dim Mx_Data(10, 0) As Object

        If (lista.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        '--------------------------------------------------------------------------------------------------------------------------------------------------------------
        'Crear nuevo Dcto
        Dim xls As New SLDocument
        Dim RowH As Integer = 30

        'Definir estilos
        Dim css_Title = xls.CreateStyle
        css_Title.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        css_Title.Font.Bold = True
        css_Title.Font.FontSize = 20

        Dim css_SubTitle = xls.CreateStyle
        css_SubTitle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        css_SubTitle.Font.Bold = True
        css_SubTitle.Font.FontSize = 16

        Dim css_THead = xls.CreateStyle
        css_THead.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
        css_THead.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentValues.Center)
        css_THead.Font.Bold = True
        css_THead.Font.FontSize = 11
        'css_THead.Font.FontColor = System.Drawing.Color.White
        css_THead.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, System.Drawing.Color.Yellow, System.Drawing.Color.Yellow)

        Dim css_TCell_left = xls.CreateStyle
        css_TCell_left.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        css_TCell_left.Font.Bold = False
        css_TCell_left.Font.FontSize = 11

        Dim css_TCell_center = xls.CreateStyle
        css_TCell_center.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
        css_TCell_center.Font.Bold = False
        css_TCell_center.Font.FontSize = 10

        Dim css_TCell_right = xls.CreateStyle
        css_TCell_right.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Right)
        css_TCell_right.Font.Bold = False
        css_TCell_right.Font.FontSize = 10

        Dim css_TCell_right_H = xls.CreateStyle
        css_TCell_right_H.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Right)
        css_TCell_right_H.Font.Bold = False
        css_TCell_right_H.Font.FontSize = 10
        Dim colorH = System.Drawing.Color.FromArgb(237, 237, 237)
        css_TCell_right_H.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, colorH, colorH) '"#56a1ff"

        Dim css_TCell_right_M = xls.CreateStyle
        css_TCell_right_M.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Right)
        css_TCell_right_M.Font.Bold = False
        css_TCell_right_M.Font.FontSize = 10
        Dim colorM = System.Drawing.Color.FromArgb(255, 242, 204)
        css_TCell_right_M.Fill.SetPattern(DocumentFormat.OpenXml.Spreadsheet.PatternValues.Solid, colorM, colorM) '"#ffc26c"

        Dim css_TCell_Date = xls.CreateStyle
        css_TCell_Date.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
        css_TCell_Date.Font.Bold = False
        css_TCell_Date.Font.FontSize = 10
        css_TCell_Date.FormatCode = "dd/mm/yyyy"

        Dim css_TCell_Number = xls.CreateStyle
        css_TCell_Number.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Right)
        css_TCell_Number.Font.Bold = False
        css_TCell_Number.Font.FontSize = 10
        css_TCell_Number.FormatCode = "###,###,##0"

        Dim css_TCell_Money = xls.CreateStyle
        css_TCell_Money.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Right)
        css_TCell_Money.Font.Bold = False
        css_TCell_Money.Font.FontSize = 10
        css_TCell_Money.FormatCode = "$ ###,###,##0"

        Dim css_TCell_Percentage = xls.CreateStyle
        css_TCell_Percentage.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Right)
        css_TCell_Percentage.Font.Bold = False
        css_TCell_Percentage.Font.FontSize = 10
        css_TCell_Percentage.FormatCode = "#,##0.00 %"



        'Colocar Título
        'xls.SetCellValue(1, 1, "Exámenes por paciente")
        'xls.SetCellStyle(1, 1, css_Title)
        'xls.MergeWorksheetCells(1, 1, 1, 3)

        'xls.SetCellValue(2, 1, "N° Lote: " & NUMLOTE)
        'xls.SetCellStyle(2, 1, css_SubTitle)
        'xls.MergeWorksheetCells(2, 1, 2, 3)

        'xls.SetCellValue(3, 1, "Hasta: " & HASTA)
        'xls.SetCellStyle(3, 1, css_SubTitle)
        'xls.MergeWorksheetCells(3, 1, 3, 3)


        'Colocar Cabeceras
        Dim x1 As Integer = 1
        Dim y1 As Integer = 1
        Dim colAct As Integer = x1
        Dim filAct As Integer = y1

        xls.FreezePanes(y1, 0)

        'Variables Lista
        Dim leTable As Integer = 0
        Dim newTable As Boolean = True
        Dim reeTOTAL As Integer = 0
        Dim HIPER_TOTAL As Integer = 0
        Dim indice_if As Integer = 0
        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""
        Dim muestra_comparados As String = ""

        xls.SetCellStyle(filAct, colAct, css_THead)
        xls.SetCellValue(filAct, colAct, "Numero de Atencion") : colAct += 1
        xls.SetCellStyle(filAct, colAct, css_THead)
        xls.SetCellValue(filAct, colAct, "Fecha") : colAct += 1
        xls.SetCellStyle(filAct, colAct, css_THead)
        xls.SetCellValue(filAct, colAct, "Rut Paciente") : colAct += 1
        xls.SetCellStyle(filAct, colAct, css_THead)
        xls.SetCellValue(filAct, colAct, "Nombre paciente") : colAct += 1
        xls.SetCellStyle(filAct, colAct, css_THead)
        xls.SetCellValue(filAct, colAct, "Sexo paciente") : colAct += 1
        xls.SetCellStyle(filAct, colAct, css_THead)
        xls.SetCellValue(filAct, colAct, "Edad Paciente") : colAct += 1
        xls.SetCellStyle(filAct, colAct, css_THead)
        xls.SetCellValue(filAct, colAct, "Procedencia") : colAct += 1
        xls.SetCellStyle(filAct, colAct, css_THead)
        xls.SetCellValue(filAct, colAct, "Examen") : colAct += 1
        xls.SetCellStyle(filAct, colAct, css_THead)
        xls.SetCellValue(filAct, colAct, "Prueba") : colAct += 1
        xls.SetCellStyle(filAct, colAct, css_THead)
        xls.SetCellValue(filAct, colAct, "Resultado") : colAct += 1

        For Each item As E_ESTADISTICA_RESULTADOS_POR_DETERMINACION In lista
            colAct = x1
            filAct += 1

            xls.SetCellStyle(filAct, colAct, css_TCell_left)
            xls.SetCellValue(filAct, colAct, item.ATE_NUM) : colAct += 1

            xls.SetCellStyle(filAct, colAct, css_TCell_left)
            xls.SetCellValue(filAct, colAct, item.ATE_FECHA) : colAct += 1

            xls.SetCellStyle(filAct, colAct, css_TCell_left)
            xls.SetCellValue(filAct, colAct, item.PAC_RUT) : colAct += 1

            xls.SetCellStyle(filAct, colAct, css_TCell_left)
            xls.SetCellValue(filAct, colAct, item.NOMBRE_COMPLETO) : colAct += 1

            xls.SetCellStyle(filAct, colAct, css_TCell_left)
            xls.SetCellValue(filAct, colAct, item.SEXO_DESC) : colAct += 1

            xls.SetCellStyle(filAct, colAct, css_TCell_right)
            xls.SetCellValue(filAct, colAct, item.ATE_AÑO) : colAct += 1

            xls.SetCellStyle(filAct, colAct, css_TCell_left)
            xls.SetCellValue(filAct, colAct, item.PROC_DESC) : colAct += 1

            xls.SetCellStyle(filAct, colAct, css_TCell_left)
            xls.SetCellValue(filAct, colAct, item.CF_DESC) : colAct += 1

            xls.SetCellStyle(filAct, colAct, css_TCell_left)
            xls.SetCellValue(filAct, colAct, item.PRU_DESC) : colAct += 1

            xls.SetCellStyle(filAct, colAct, css_TCell_right)
            xls.SetCellValue(filAct, colAct, item.ATE_RESULTADO) : colAct += 1

        Next

        filAct += 1

        For i = 66 To 102
            Dim letraAct = If(i > 90, Chr(65) & Chr(i - 26), Chr(i))
        Next

        Dim estiloBorde = xls.CreateStyle()
        estiloBorde.Border.LeftBorder.BorderStyle = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin
        estiloBorde.Border.LeftBorder.Color = System.Drawing.Color.Black
        estiloBorde.Border.TopBorder.BorderStyle = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin
        estiloBorde.Border.TopBorder.Color = System.Drawing.Color.Black
        estiloBorde.Border.RightBorder.BorderStyle = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin
        estiloBorde.Border.RightBorder.Color = System.Drawing.Color.Black
        estiloBorde.Border.BottomBorder.BorderStyle = DocumentFormat.OpenXml.Spreadsheet.BorderStyleValues.Thin
        estiloBorde.Border.BottomBorder.Color = System.Drawing.Color.Black
        xls.SetCellStyle(y1, x1, filAct, colAct - 1, estiloBorde)

        xls.AutoFitColumn(x1, lista.Count + x1 - 1)

        'insertar tabla
        tabla = sl.CreateTable("A1", CStr("J" & colAct))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        'incrementa el ancho de cada columna en 1 (1 de excel es 3.35546875)
        'For index As Integer = x1 To lista.Count + x1 - 1
        '    Dim width = xls.GetColumnWidth(index)
        '    xls.SetColumnWidth(index, width + 3.35546875) '+ 3.35546875
        'Next

        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Resultados por Examen " & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Dim URL As String = HttpContext.Current.Request.Url.Authority
        Return URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
End Class