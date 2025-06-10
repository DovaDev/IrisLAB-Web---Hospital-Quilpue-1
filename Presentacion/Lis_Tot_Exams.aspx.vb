Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class Lis_Tot_Exams
    Inherits System.Web.UI.Page

    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_LugarTM() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_LugarTM As New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        Dim Data_LugarTM As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)

        Data_LugarTM = NN_LugarTM.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()
        If (Data_LugarTM.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_LugarTM, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_LIS_TOT_EXAMS(ByVal DESDE As String, ByVal HASTA As String, ID_PRO As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO)

        'Declaraciones internas

        Dim data_det_ate As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO)
        Dim NN_Det_Ate As N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO = New N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO

        data_det_ate = NN_Det_Ate.IRIS_WEBF_LIS_TOT_EXAMS(DESDE, HASTA, ID_PRO)

        Return data_det_ate
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal DESDE As String, ByVal HASTA As String, ID_PRO As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO)

        'Declaraciones internas

        Dim data_det_ate As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO)
        Dim NN_Det_Ate As N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO = New N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO

        data_det_ate = NN_Det_Ate.IRIS_WEBF_LIS_TOT_EXAMS_2(DESDE, HASTA, ID_PRO)

        Return data_det_ate
    End Function
    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_PRO As Integer) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""

        Dim data_det_ate As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO)
        Dim NN_Det_Ate As N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO = New N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO

        data_det_ate = NN_Det_Ate.IRIS_WEBF_BUSCA_ESTADO_ENVIO_AVIS(DESDE, HASTA, ID_PRO)

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
        Dim RowH As Integer = 10

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

        Dim css_TCell_center_blue = xls.CreateStyle
        css_TCell_center_blue.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
        css_TCell_center_blue.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_TCell_center_blue.Font.Bold = False
        css_TCell_center_blue.Font.FontSize = 10
        css_TCell_center_blue.Font.FontColor = System.Drawing.Color.Blue

        Dim css_TCell_center_red = xls.CreateStyle
        css_TCell_center_red.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
        css_TCell_center_red.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_TCell_center_red.Font.Bold = False
        css_TCell_center_red.Font.FontSize = 10
        css_TCell_center_red.Font.FontColor = System.Drawing.Color.Red

        Dim css_TCell_center_green = xls.CreateStyle
        css_TCell_center_green.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
        css_TCell_center_green.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_TCell_center_green.Font.Bold = False
        css_TCell_center_green.Font.FontSize = 10
        css_TCell_center_green.Font.FontColor = System.Drawing.Color.Green


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
        xls.SetCellValue(1, 1, "Planilla de registro de Residuos")
        xls.SetCellStyle(1, 1, css_Title)
        xls.MergeWorksheetCells(1, 1, 1, 3)



        xls.SetCellStyle(2, 1, css_SubTitle)
        xls.MergeWorksheetCells(2, 1, 2, 3)

        'xls.SetCellValue(3, 1, "Hasta: " & HASTA)
        'xls.SetCellStyle(3, 1, css_SubTitle)
        'xls.MergeWorksheetCells(3, 1, 3, 3)


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

        xls.SetColumnWidth(1, RowH + 00)
        xls.SetColumnWidth(2, RowH + 05)
        xls.SetColumnWidth(3, RowH + 05)
        xls.SetColumnWidth(4, RowH + 01)
        xls.SetColumnWidth(5, RowH + 05)
        xls.SetColumnWidth(6, RowH + 00)
        xls.SetColumnWidth(7, RowH + 00)
        xls.SetColumnWidth(8, RowH + 20)
        xls.SetColumnWidth(9, RowH + 20)
        xls.SetColumnWidth(10, RowH + 05)
        xls.SetColumnWidth(11, RowH + 10)
        xls.SetColumnWidth(12, RowH + 01)
        xls.SetColumnWidth(13, RowH + 05)
        xls.SetColumnWidth(14, RowH + 02)
        xls.SetColumnWidth(15, RowH + 20)
        xls.SetColumnWidth(16, RowH + 05)
        xls.SetColumnWidth(17, RowH + 10)
        xls.SetColumnWidth(18, RowH + 10)
        xls.SetColumnWidth(19, RowH + 10)
        xls.SetColumnWidth(20, RowH + 10)

        y2 += 2
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "#") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "N° Atención (Folio Iris)") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Fecha Creación Folio Iris") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Rut") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Sexo") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Fecha Nacimiento") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Edad") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Nombre") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Examen") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Código Fonasa") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Procedencia") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "OC Avis") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Forma Pago") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Previsión") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Médico") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Programa") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Fecha Creación en Integración") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Fecha Validación Examen") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Hora Validación Examen") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Estado Respecto Avis") : x2 += 1




        For Each List_Data As E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO In data_det_ate
            x2 = x1
            y2 += 1

            If ID_PRO = 0 Then
                xls.SetCellValue(2, 1, "Lugar TM: TODOS")
            Else
                xls.SetCellValue(2, 1, "Lugar TM: " & List_Data.PROC_DESC)
            End If

            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, xi) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.ATE_NUM) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, Format(List_Data.ATE_FECHA, "dd/MM/yyyy")) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.PAC_RUT) : x2 += 1
            If List_Data.ID_SEXO = 1 Then
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, "Masculino") : x2 += 1
            Else
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, "Femenino") : x2 += 1
            End If

            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, Format(List_Data.PAC_FNAC, "dd/MM/yyyy")) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.ATE_AÑO & "A" & " " & List_Data.ATE_MES & "M" & " " & List_Data.ATE_DIA & "D") : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.PAC_NOMBRE & " " & List_Data.PAC_APELLIDO) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.CF_DESC) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.CF_COD) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.PROC_DESC) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.HO_CC) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.TP_PAGO_DESC) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.PREVE_DESC) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.DOC_NOMBRE & " " & List_Data.DOC_APELLIDO) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.PROGRA_DESC) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.HO_FECHAREGISTRO) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, Format(List_Data.ATE_DET_V_FECHA, "dd/MM/yyyy")) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, Format(List_Data.ATE_DET_V_FECHA, "HH:mm")) : x2 += 1

            If List_Data.HO_ESTADOPROCESO = "U" Then
                xls.SetCellStyle(y2, x2, css_TCell_center_blue)
                xls.SetCellValue(y2, x2, "Enviado") : x2 += 1
            ElseIf List_Data.HO_ESTADOPROCESO = "C" Then
                xls.SetCellStyle(y2, x2, css_TCell_center_red)
                xls.SetCellValue(y2, x2, "Cargado") : x2 += 1
            ElseIf List_Data.HO_ESTADOPROCESO = "D" Then
                xls.SetCellStyle(y2, x2, css_TCell_center_green)
                xls.SetCellValue(y2, x2, "Disponible") : x2 += 1
            End If


            xi += 1

            indice_if += 1
        Next
        x2 = x1
        y2 += 2
        Dim contadorin = 1
        Dim super_sumador = 0

        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Estado_Envios_AVIS" & Format(Date.Now, "dd-MM-yyyy_HH-mm-ss") & ".xlsx"
        xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Dim URL As String = HttpContext.Current.Request.Url.Authority
        Return URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
End Class