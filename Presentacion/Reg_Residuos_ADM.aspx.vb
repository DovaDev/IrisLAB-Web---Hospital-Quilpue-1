
Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class Reg_Residuos_ADM
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Eliminar(ByVal ID As String) As String

        'Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        Dim N_ECrypt As New N_Encrypt
        'Declaraciones internas
        Dim data As Integer
        Dim NN As N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO = New N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO

        data = NN.IRIS_WEBF_ELIMINAR_RESIDUO(ID)

        If data > 0 Then

            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function Ajax_DataTable_agregar(ByVal FFOLIO As String,
                                   ByVal FFECHA As String,
                                   ByVal IID_SECCION As String,
                                   ByVal IID_TP_RESIDUO As String,
                                   ByVal BBOLSA_CONTENEDOR As String,
                                   ByVal KKILOS_RESIDUO As String,
                                   ByVal RRESPONSABLE As String,
                                   ByVal IID_PROCEDENCIA As String,
                                                  ByVal SSUPERVISOR As String) As String

        'Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

        ''Declaraciones del Serializador
        'Dim NN_Date As New N_Date_Operat
        'Dim fecha As String = FECHA_PRE.Replace("/", "-")
        'Dim DIA1 As String = fecha.Split("-")(0)
        'Dim MES2 As String = fecha.Split("-")(1)
        'Dim AÑO3 As String = fecha.Split("-")(2)
        'Dim Date_01 As Date = NN_Date.strToDate(AÑO3, MES2, DIA1)
        'Dim Date_02 As Date = NN_Date.strToDate(AÑO3, MES2, DIA1)


        Dim kilazos As String = KKILOS_RESIDUO.Replace(".", ",")

        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        Dim NN_alumno As N_Registrar = New N_Registrar
        Dim retur As Integer

        retur = NN_alumno.IRIS_WEBF_GRABA_TRAZA_RESIDUOS_2(
                                 FFOLIO,
                                    CDate(FFECHA),
                                    IID_SECCION,
                                    IID_TP_RESIDUO,
                                    BBOLSA_CONTENEDOR,
                                    kilazos,
                                    RRESPONSABLE,
                                    IID_PROCEDENCIA,
                                 SSUPERVISOR)
        'data = NN.IRIS_WEBF_BUSCA_EST_LUGAR_TM_EXCEL_UPDATE(ID, CAMBIO, CASILLA)

        'If data > 0 Then

        '    Serializer.MaxJsonLength = 999999999
        '    Serializer.Serialize(data, str_Builder)
        '    Return str_Builder.ToString
        'Else
        '    Return "null"
        'End If
        Return "null"
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_UPDATE_RESIDUOS(ByVal ID As String, ByVal CAMBIO As String, ByVal CASILLA As String) As String

        'Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        Dim N_ECrypt As New N_Encrypt
        'Declaraciones internas
        Dim data As Integer
        Dim NN As N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO = New N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO
        If (((CASILLA = "1") Or (CASILLA = "2") Or (CASILLA = "3") Or (CASILLA = "4") Or (CASILLA = "5") Or (CASILLA = "6") Or (CASILLA = "7") Or (CASILLA = "8") Or (CASILLA = "10")) And (CAMBIO = "")) Then
            data = 0
        Else
            data = NN.IRIS_WEBF_UPDATE_RESIDUOS_2(CInt(ID), CAMBIO, CASILLA)
        End If

        If data > 0 Then

            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If

    End Function
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
    Public Shared Function Llenar_Ddl_TP_RESIDUO() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_LugarTM As New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        Dim Data_TORESIDUO As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)

        Data_TORESIDUO = NN_LugarTM.IRIS_WEBF_BUSCA_TP_RESIDUO_ACTIVO()
        If (Data_TORESIDUO.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_TORESIDUO, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_SECCCION_RESIDUO() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_LugarTM As New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        Dim Data_TORESIDUO As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)

        Data_TORESIDUO = NN_LugarTM.IRIS_WEBF_BUSCA_SECCION_RESIDUO_ACTIVO()
        If (Data_TORESIDUO.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_TORESIDUO, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing '
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_TM As Integer) As E_List_wDict_2

        'Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

        Dim N_ECrypt As New N_Encrypt
        'Declaraciones internas
        Dim data As E_List_wDict_2
        Dim NN As N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO = New N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO

        data = NN.IRIS_WEBF_BUSCA_DATOS_RESIDUOS_2(DESDE, HASTA, ID_TM)

        Return data

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_SECC_TRAZA_RESIDUO() As String

        'Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        Dim N_ECrypt As New N_Encrypt
        'Declaraciones internas
        Dim data As List(Of E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL)
        Dim NN As N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO = New N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO

        data = NN.IRIS_WEBF_BUSCA_SECC_TRAZA_RESIDUO()

        If data.Count > 0 Then

            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_TM As Integer) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""

        'Declaraciones internas
        Dim data_det_ate As E_List_wDict_2
        Dim NN_Det_Ate As N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO = New N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO

        data_det_ate = NN_Det_Ate.IRIS_WEBF_BUSCA_DATOS_RESIDUOS_2(DESDE, HASTA, ID_TM)

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

        If (data_det_ate.List_Data.Count = 0) Then
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

        Dim css_TCell_center_yellow = xls.CreateStyle
        css_TCell_center_yellow.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
        css_TCell_center_yellow.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_TCell_center_yellow.Font.Bold = False
        css_TCell_center_yellow.Font.FontSize = 10
        css_TCell_center_yellow.Font.FontColor = System.Drawing.Color.Gold

        Dim css_TCell_center_red = xls.CreateStyle
        css_TCell_center_red.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
        css_TCell_center_red.SetVerticalAlignment(DocumentFormat.OpenXml.Spreadsheet.VerticalAlignmentRunValues.Baseline)
        css_TCell_center_red.Font.Bold = False
        css_TCell_center_red.Font.FontSize = 10
        css_TCell_center_red.Font.FontColor = System.Drawing.Color.Red


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
        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""
        Dim muestra_comparados As String = ""

        xls.SetColumnWidth(1, RowH + 00)
        xls.SetColumnWidth(2, RowH + 05)
        xls.SetColumnWidth(3, RowH + 10)
        xls.SetColumnWidth(4, RowH + 05)
        xls.SetColumnWidth(5, RowH + 20)
        xls.SetColumnWidth(6, RowH + 20)
        xls.SetColumnWidth(7, RowH + 10)
        xls.SetColumnWidth(8, RowH + 05)
        xls.SetColumnWidth(9, RowH + 20)
        xls.SetColumnWidth(10, RowH + 20)
        xls.SetColumnWidth(11, RowH + 20)

        y2 += 2
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "#") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Folio") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Fecha") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Codigo") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Sección") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Tipo Residuo") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Bolsa/Contenedor") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Kilos") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Responsable Acopio") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Supervisor REAS") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Lugar TM") : x2 += 1

        For Each List_Data As E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL In data_det_ate.List_Data
            x2 = x1
            y2 += 1

            If ID_TM = 0 Then
                xls.SetCellValue(2, 1, "Lugar TM: TODOS")
            Else
                xls.SetCellValue(2, 1, "Lugar TM: " & List_Data.PROC_DESC)
            End If

            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, xi) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.FOLIO_RESIDUO) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, Format(List_Data.FECHA_RESIDUO, "dd/MM/yyyy")) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.COD_SECC_RESIDUO) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.SECC_RESIDUO_DESC) : x2 += 1

            If List_Data.TP_RESIDUO_DESC = "ESPECIAL (bolsa amarilla)" Or List_Data.TP_RESIDUO_DESC = "ESPECIAL CORTANTE (amarillo rigido)" Or List_Data.TP_RESIDUO_DESC = "ESPECIAL (bolsa amarilla)" & vbCrLf Or List_Data.TP_RESIDUO_DESC = "ESPECIAL CORTANTE (amarillo rigido)" & vbCrLf Then
                xls.SetCellStyle(y2, x2, css_TCell_center_yellow)
                xls.SetCellValue(y2, x2, List_Data.TP_RESIDUO_DESC) : x2 += 1
            ElseIf List_Data.TP_RESIDUO_DESC = "PELIGROSO (bolsa roja)" Or List_Data.TP_RESIDUO_DESC = "PELIGROSO CORTANTE (rojo rigido)" Or List_Data.TP_RESIDUO_DESC = "PELIGROSO CORTANTE (rojo rigido)" & vbCrLf Or List_Data.TP_RESIDUO_DESC = "PELIGROSO (bolsa roja)" & vbCrLf Then
                xls.SetCellStyle(y2, x2, css_TCell_center_red)
                xls.SetCellValue(y2, x2, List_Data.TP_RESIDUO_DESC) : x2 += 1
            Else
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, List_Data.TP_RESIDUO_DESC) : x2 += 1
            End If



            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.BOLSA_CONT_RESIDUO) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, CDbl(List_Data.KILOS_RESIDUO)) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.RESPONSABLE_RESIDUO) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.SUPERVISOR) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.PROC_DESC) : x2 = x1

            xi += 1

            indice_if += 1
        Next
        x2 = x1
        y2 += 2
        Dim contadorin = 1
        Dim super_sumador = 0

        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "#") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Lugar TM") : x2 += 1
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
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Planilla_de_registro_Residuos" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Dim URL As String = HttpContext.Current.Request.Url.Authority
        Return URL & "/" & Replace(Relative_Path, "\", "/")

    End Function

End Class