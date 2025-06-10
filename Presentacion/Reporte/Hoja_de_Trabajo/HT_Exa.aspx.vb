Imports Entidades
Imports Negocio
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Public Class HT_Exa

    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Examen() As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        'Declaraciones del Serializador

        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_CF As New N_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        Dim Data_CF As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)

        Data_CF = NN_CF.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS()
        If (Data_CF.Count > 0) Then
            Return Data_CF
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal DESDE As Date,
                                            ByVal HASTA As Date,
                                            ByVal ID_CF As Integer,
                                            ByVal PROCEDENCIA As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID_3)

        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID_3
        Dim Data As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID_3)
        'Dim ID_SECC = 0
        Dim N_ECrypt As New N_Encrypt

        Data = NN.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID_3_2(DESDE, HASTA, ID_CF, PROCEDENCIA)

        If (Data.Count > 0) Then
            For i = 0 To (Data.Count - 1)
                Data(i).ENCRYPTED_ID = N_ECrypt.Encode(Data(i).ID_ATENCION)
            Next i
            Return Data
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal DESDE As Date,
                                            ByVal HASTA As Date,
                                            ByVal ID_CF As Integer,
                                            ByVal PROCEDENCIA As Integer) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""

        'Declaraciones internas
        Dim data_det_ate As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID_3)
        Dim NN_Det_Ate As New N_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID_3

        data_det_ate = NN_Det_Ate.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID_3_2(DESDE, HASTA, ID_CF, PROCEDENCIA)

        'creamos el objeto SLDocument el cual creara el excel
        Dim sl As SLDocument = New SLDocument
        'Dim tabla As SLTable
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

        If (data_det_ate.Count = 0) Then
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
        xls.SetCellValue(1, 1, "Listado de hoja de trabajo por Procedencia Detallado")
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
        Dim xi As Integer = 1
        Dim leTable As Integer = 0
        Dim newTable As Boolean = True
        Dim reeTOTAL As Integer = 0
        Dim HIPER_TOTAL As Integer = 0
        Dim indice_if As Integer = 0

        xls.SetColumnWidth(1, RowH - 20)
        xls.SetColumnWidth(2, RowH + 00)
        xls.SetColumnWidth(3, RowH + 00)
        xls.SetColumnWidth(4, RowH + 10)
        xls.SetColumnWidth(5, RowH + 00)
        xls.SetColumnWidth(6, RowH + 00)
        xls.SetColumnWidth(7, RowH + 00)
        xls.SetColumnWidth(8, RowH + 00)
        xls.SetColumnWidth(9, RowH + 00)
        xls.SetColumnWidth(10, RowH + 00)
        xls.SetColumnWidth(11, RowH + 15)
        xls.SetColumnWidth(12, RowH + 00)
        xls.SetColumnWidth(13, RowH + 00)
        xls.SetColumnWidth(14, RowH + 00)
        xls.SetColumnWidth(15, RowH + 00)
        xls.SetColumnWidth(16, RowH + 00)

        y2 += 2
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "#") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "N° Atención") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Fecha Atención") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Nombre") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "RUT") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "DNI") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Edad") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Lugar TM") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Sexo") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Nacionalidad") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Examen") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Programa") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Sector") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "N° Interno") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Doctor") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Obs. TM") : x2 += 1

        For Each List_Data As E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_POR_ID_3 In data_det_ate
            x2 = x1
            y2 += 1

            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, xi) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.ATE_NUM) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, Format(List_Data.ATE_FECHA, "dd/MM/yyyy")) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.PAC_NOMBRE & " " & List_Data.PAC_APELLIDO) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.PAC_RUT) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.DNI) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.ATE_AÑO & " Años") : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.PROC_DESC) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.SEXO_DESC) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.NACIONALIDAD) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.CF_DESC) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.PROGRAMA) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.SECTOR) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.ATE_NUMERO_INTERNO) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.DOC_NOMBRE & " " & List_Data.DOC_APELLIDO) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.ATE_OBS_TM) : x2 = x1

            xi += 1

            indice_if += 1


        Next
        x2 = x1
        y2 += 2
        Dim contadorin = 1
        Dim super_sumador = 0

        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Lis_Hoja_Trabajo_Por_Examen_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Dim URL As String = HttpContext.Current.Request.Url.Authority
        Return URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
End Class