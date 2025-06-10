Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class Env_Mues_Lab_Mid_Recep
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
    Public Shared Function Llenar_Ddl_Exam() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        Dim Data_Exam As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)

        Data_Exam = NN_Exam.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS()
        If (Data_Exam.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Exam, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO() As List(Of E_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO)
        Dim NN As N_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO = New N_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO

        data_paciente = NN.IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO_RECEP()

        Return data_paciente

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO_POR_FECHA(ByVal DESDE As String, ByVal HASTA As String, ByVal NLOTE As String) As List(Of E_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO)
        Dim NN As N_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO = New N_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO

        data_paciente = NN.IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO_POR_FECHA_RECEP(DESDE, HASTA, NLOTE)

        Return data_paciente

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO(ByVal NUMLOTE As Integer) As E_List_wDict2
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_paciente As E_List_wDict2
        Dim NN As N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO = New N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO

        data_paciente = NN.IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO(NUMLOTE)
        Return data_paciente

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_UPDATE_LOTE_RECEPCION_ENVIO_RECEP(ByVal NUMLOTE As Integer) As Integer
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

        'Declaraciones internas
        Dim data_paciente As E_List_wDict2
        Dim NN As N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO = New N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO

        Dim data_update As Integer = 0

        Dim data_lote As List(Of E_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO)
        Dim NN_lote As N_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO = New N_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO


        data_paciente = NN.IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO(NUMLOTE)
        If data_paciente.List_Data.Count > 0 Then
            data_lote = NN_lote.IRIS_WEBF_BUSCA_IF_UPDATE_LOTE_RECEPCIONADO_ENVIO_POR_RECEP(NUMLOTE)
            If data_lote.Count > 0 Then
                If data_lote(0).ID_ESTADO_RECEP = "9" Then
                    data_update = 0
                Else
                    data_update = NN.IRIS_WEBF_UPDATE_LOTE_RECEPCION_ENVIO_RECEP(NUMLOTE, ID_USER)
                End If
            Else
                data_update = 0
            End If
        Else
            data_update = 0
        End If


        Return data_update

    End Function

    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal NUMLOTE As Integer) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""

        'Declaraciones internas
        Dim data_det_ate As E_List_wDict2
        Dim NN_Det_Ate As N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO = New N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO

        data_det_ate = NN_Det_Ate.IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO(NUMLOTE)

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


        Dim Mx_Data(8, 0) As Object

        If (data_det_ate.List_Data.Count = 0) Then
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
        xls.SetCellValue(1, 1, "Estados de Exámenes por Lote")
        xls.SetCellStyle(1, 1, css_Title)
        xls.MergeWorksheetCells(1, 1, 1, 3)

        xls.SetCellValue(2, 1, "N° Lote: " & NUMLOTE)
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
        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""
        Dim muestra_comparados As String = ""

        xls.SetColumnWidth(1, RowH + 00)
        xls.SetColumnWidth(2, RowH + 00)
        xls.SetColumnWidth(3, RowH + 00)
        xls.SetColumnWidth(4, RowH + 15)
        xls.SetColumnWidth(5, RowH + 00)
        xls.SetColumnWidth(6, RowH + 00)
        xls.SetColumnWidth(7, RowH + 00)
        xls.SetColumnWidth(8, RowH + 15)
        xls.SetColumnWidth(9, RowH + 15)
        xls.SetColumnWidth(10, RowH + 00)
        xls.SetColumnWidth(11, RowH + 00)
        xls.SetColumnWidth(12, RowH + 00)

        y2 += 2
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "#") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "N° Atención") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "N° Interno") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Nombre Paciente") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Edad") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Fecha Atención") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Fecha Envío") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Lugar de TM") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Etiqueta") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Estado") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "N° Lote") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Usuario") : x2 += 1

        For Each List_Data As E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO In data_det_ate.List_Data
            If (indice_if = 0) Then
                x2 = x1
                y2 += 1

                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, xi) : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, List_Data.ATE_NUM) : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, List_Data.ATE_NUM_INTERNO) : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, List_Data.PAC_NOMBRE & " " & List_Data.PAC_APELLIDO) : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, List_Data.ATE_AÑO & " Años") : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, Format(List_Data.ATE_FECHA, "dd/MM/yyyy HH:mm:ss")) : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, Format(List_Data.ENVIO_ETI_FECHA, "dd/MM/yyyy HH:mm:ss")) : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, List_Data.PROC_DESC) : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, "[" & List_Data.CB_DESC & "]" & " - " & List_Data.T_MUESTRA_DESC) : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, List_Data.EST_DESCRIPCION) : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, List_Data.ENVIO_NUM) : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, List_Data.USU_NIC) : x2 = x1

                xi += 1

                indice_if += 1
                cb_desc_comparador = List_Data.CB_DESC
                ate_num_comparador = List_Data.ATE_NUM
                muestra_comparados = List_Data.T_MUESTRA_DESC
            ElseIf ((((indice_if > 0) And (List_Data.CB_DESC <> cb_desc_comparador))) Or List_Data.ATE_NUM <> ate_num_comparador Or List_Data.T_MUESTRA_DESC <> muestra_comparados) Then
                x2 = x1
                y2 += 1

                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, xi) : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, List_Data.ATE_NUM) : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, List_Data.ATE_NUM_INTERNO) : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, List_Data.PAC_NOMBRE & " " & List_Data.PAC_APELLIDO) : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, List_Data.ATE_AÑO & " Años") : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, Format(List_Data.ATE_FECHA, "dd/MM/yyyy HH:mm:ss")) : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, Format(List_Data.ENVIO_ETI_FECHA, "dd/MM/yyyy HH:mm:ss")) : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, List_Data.PROC_DESC) : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, "[" & List_Data.CB_DESC & "]" & " - " & List_Data.T_MUESTRA_DESC) : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, List_Data.EST_DESCRIPCION) : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, List_Data.ENVIO_NUM) : x2 += 1
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, List_Data.USU_NIC) : x2 = x1

                xi += 1

                indice_if += 1
                cb_desc_comparador = List_Data.CB_DESC
                ate_num_comparador = List_Data.ATE_NUM
                muestra_comparados = List_Data.T_MUESTRA_DESC
            End If

        Next
        x2 = x1
        y2 += 2
        Dim contadorin = 1
        Dim super_sumador = 0

        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "#") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Etiqueta") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Total") : x2 = x1


        For Each key In data_det_ate.Dictionary.Keys
            x2 = x1
            y2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, contadorin) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_left)
            xls.SetCellValue(y2, x2, key) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_right)
            xls.SetCellValue(y2, x2, data_det_ate.Dictionary.Item(key)) : x2 = x1

            contadorin += 1
            super_sumador += data_det_ate.Dictionary.Item(key)
        Next

        x2 = x1
        y2 += 1

        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "TOTAL") : x2 += 1
        xls.MergeWorksheetCells(y2, x1, y2, x2) : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, super_sumador) : x2 = x1


        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Estados_de_Examenes_Por_Lote" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Dim URL As String = HttpContext.Current.Request.Url.Authority
        Return URL & "/" & Replace(Relative_Path, "\", "/")

    End Function

    <Services.WebMethod()>
    Public Shared Function PDFF(ByVal DOMAIN_URL As String, ByVal NUMLOTE As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim NN_pdf As N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO = New N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO
        Dim link As String
        Dim Str_Out As String = ""

        link = NN_pdf.PDFF_TUBO(DOMAIN_URL, NUMLOTE)
        Return link
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal TIPO As Integer, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_PRE As Integer, ByVal ID_CF As Integer) As E_List_wDict

        'Declaraciones internas
        Dim data_det_ate As E_List_wDict
        Dim NN_Det_Ate As N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO = New N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO

        data_det_ate = NN_Det_Ate.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO(TIPO, DESDE, HASTA, ID_PRE, ID_CF)

        Return data_det_ate
    End Function

    Public Shared Function Calcular_Edad(Fecha_Nacimiento As Date) As Integer
        Dim Años As Object
        ' comprueba si el valor no es nulo  

        Años = DateDiff("yyyy", Fecha_Nacimiento, Now)

        If Date.Now < DateSerial(Year(Now), Month(Fecha_Nacimiento),
                           Day(Fecha_Nacimiento)) Then
            Años = Años - 1
        End If

        Calcular_Edad = CInt(Años)
    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Or C_P_ADMIN = 1 Then
        Else

            Response.Redirect("~/Index.aspx")
        End If

    End Sub
End Class