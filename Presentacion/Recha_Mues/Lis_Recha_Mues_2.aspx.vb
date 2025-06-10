Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class Lis_Recha_Mues_2
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
    Public Shared Function Llenar_DataTable(ByVal DESDE As String, ByVal HASTA As String, ByVal LUGAR_TM As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim data_fechas As List(Of E_IRIS_WEBF_BUSCA_RECHAZOS_POR_FECHA_LISTADO)
        Dim NN_fechas As N_IRIS_WEBF_BUSCA_RECHAZOS_POR_FECHA_LISTADO = New N_IRIS_WEBF_BUSCA_RECHAZOS_POR_FECHA_LISTADO

        Dim data_lote As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1)
        Dim data_lote2 As New List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1)
        Dim item_lote As E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1
        Dim NN_Lote As N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1 = New N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1

        data_fechas = NN_fechas.IRIS_WEBF_BUSCA_RECHAZOS_POR_FECHA_LISTADO(CDate(DESDE), CDate(HASTA))

        If data_fechas.Count > 0 Then
            For i = 0 To data_fechas.Count - 1
                data_lote = NN_Lote.IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_3(data_fechas(i).LOTE_RECHAZO_NUM, 0, LUGAR_TM)

                If data_lote.Count > 0 Then
                    For ii = 0 To data_lote.Count - 1
                        item_lote = New E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1

                        item_lote.LOTE_RECHAZO_NUM = data_lote(ii).LOTE_RECHAZO_NUM
                        item_lote.ID_ATENCION = data_lote(ii).ID_ATENCION
                        item_lote.RECEP_ETI_CURVA_RECHAZO = data_lote(ii).RECEP_ETI_CURVA_RECHAZO
                        item_lote.RECEP_ETI_NUM_ATE_RECHAZO = data_lote(ii).RECEP_ETI_NUM_ATE_RECHAZO
                        item_lote.ID_USUARIO = data_lote(ii).ID_USUARIO
                        item_lote.RECEP_ETI_FECHA_RECHAZO = data_lote(ii).RECEP_ETI_FECHA_RECHAZO
                        item_lote.ID_LOTE_RECHAZO = data_lote(ii).ID_LOTE_RECHAZO
                        item_lote.ID_ESTADO = data_lote(ii).ID_ESTADO
                        item_lote.CB_DESC = data_lote(ii).CB_DESC
                        item_lote.T_MUESTRA_DESC = data_lote(ii).T_MUESTRA_DESC
                        item_lote.CF_DESC = data_lote(ii).CF_DESC
                        item_lote.PAC_NOMBRE = data_lote(ii).PAC_NOMBRE
                        item_lote.PAC_APELLIDO = data_lote(ii).PAC_APELLIDO
                        item_lote.RLS_LS_DESC = data_lote(ii).RLS_LS_DESC
                        item_lote.ID_RLS_LS = data_lote(ii).ID_RLS_LS
                        item_lote.EST_DESCRIPCION = data_lote(ii).EST_DESCRIPCION
                        item_lote.ID_PER = data_lote(ii).ID_PER
                        item_lote.PROC_DESC = data_lote(ii).PROC_DESC
                        item_lote.ATE_AÑO = data_lote(ii).ATE_AÑO
                        item_lote.ATE_MES = data_lote(ii).ATE_MES
                        item_lote.USU_NIC = data_lote(ii).USU_NIC
                        item_lote.RECEP_ETI_RECHAZO_OBS = data_lote(ii).RECEP_ETI_RECHAZO_OBS
                        item_lote.ATE_DIA = data_lote(ii).ATE_DIA
                        item_lote.SEXO_DESC = data_lote(ii).SEXO_DESC

                        item_lote.PAC_RUT = data_lote(ii).PAC_RUT
                        item_lote.PAC_FNAC = data_lote(ii).PAC_FNAC
                        item_lote.ATE_NUM = data_lote(ii).ATE_NUM
                        item_lote.ATE_NUM_INTERNO = data_lote(ii).ATE_NUM_INTERNO
                        item_lote.ATE_DNI = data_lote(ii).ATE_DNI
                        item_lote.DOC_NOMBRE = data_lote(ii).DOC_NOMBRE
                        item_lote.DOC_APELLIDO = data_lote(ii).DOC_APELLIDO
                        item_lote.ID_PROCEDENCIA = data_lote(ii).ID_PROCEDENCIA
                        item_lote.NAC_DESC = data_lote(ii).NAC_DESC
                        item_lote.PROGRA_DESC = data_lote(ii).PROGRA_DESC
                        item_lote.SECTOR_DESC = data_lote(ii).SECTOR_DESC
                        item_lote.TP_RECHA_DESC = data_lote(ii).TP_RECHA_DESC

                        data_lote2.Add(item_lote)
                    Next ii
                End If
            Next i
        Else
            Return "null"
        End If

        If (data_lote2.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_lote2, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal LUGAR_TM As Integer) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""


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


        Dim Mx_Data(24, 0) As Object

        'Declaraciones internas
        Dim data_fechas As List(Of E_IRIS_WEBF_BUSCA_RECHAZOS_POR_FECHA_LISTADO)
        Dim NN_fechas As N_IRIS_WEBF_BUSCA_RECHAZOS_POR_FECHA_LISTADO = New N_IRIS_WEBF_BUSCA_RECHAZOS_POR_FECHA_LISTADO

        Dim data_lote As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1)
        Dim data_det_ate As New List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1)
        Dim item_lote As E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1
        Dim NN_Lote As N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1 = New N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim LUGARCITO = CType(objSession("USU_TM"), Integer)
        Dim ADMINISTRADORCITO = CType(objSession("P_ADMIN"), Integer)


        data_fechas = NN_fechas.IRIS_WEBF_BUSCA_RECHAZOS_POR_FECHA_LISTADO(CDate(DESDE), CDate(HASTA))

        If data_fechas.Count > 0 Then
            For i = 0 To data_fechas.Count - 1
                data_lote = NN_Lote.IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_3(data_fechas(i).LOTE_RECHAZO_NUM, 0, LUGAR_TM)

                If data_lote.Count > 0 Then
                    If ADMINISTRADORCITO <> 1 Then
                        For ii = 0 To data_lote.Count - 1

                            If LUGARCITO = data_lote(ii).ID_PROCEDENCIA Then

                                item_lote = New E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1

                                item_lote.LOTE_RECHAZO_NUM = data_lote(ii).LOTE_RECHAZO_NUM
                                item_lote.ID_ATENCION = data_lote(ii).ID_ATENCION
                                item_lote.RECEP_ETI_CURVA_RECHAZO = data_lote(ii).RECEP_ETI_CURVA_RECHAZO
                                item_lote.RECEP_ETI_NUM_ATE_RECHAZO = data_lote(ii).RECEP_ETI_NUM_ATE_RECHAZO
                                item_lote.ID_USUARIO = data_lote(ii).ID_USUARIO
                                item_lote.RECEP_ETI_FECHA_RECHAZO = data_lote(ii).RECEP_ETI_FECHA_RECHAZO
                                item_lote.ID_LOTE_RECHAZO = data_lote(ii).ID_LOTE_RECHAZO
                                item_lote.ID_ESTADO = data_lote(ii).ID_ESTADO
                                item_lote.CB_DESC = data_lote(ii).CB_DESC
                                item_lote.T_MUESTRA_DESC = data_lote(ii).T_MUESTRA_DESC
                                item_lote.CF_DESC = data_lote(ii).CF_DESC
                                item_lote.PAC_NOMBRE = data_lote(ii).PAC_NOMBRE
                                item_lote.PAC_APELLIDO = data_lote(ii).PAC_APELLIDO
                                item_lote.RLS_LS_DESC = data_lote(ii).RLS_LS_DESC
                                item_lote.ID_RLS_LS = data_lote(ii).ID_RLS_LS
                                item_lote.EST_DESCRIPCION = data_lote(ii).EST_DESCRIPCION
                                item_lote.ID_PER = data_lote(ii).ID_PER
                                item_lote.PROC_DESC = data_lote(ii).PROC_DESC
                                item_lote.ATE_AÑO = data_lote(ii).ATE_AÑO
                                item_lote.ATE_MES = data_lote(ii).ATE_MES
                                item_lote.USU_NIC = data_lote(ii).USU_NIC
                                item_lote.RECEP_ETI_RECHAZO_OBS = data_lote(ii).RECEP_ETI_RECHAZO_OBS
                                item_lote.ATE_DIA = data_lote(ii).ATE_DIA
                                item_lote.SEXO_DESC = data_lote(ii).SEXO_DESC

                                item_lote.PAC_RUT = data_lote(ii).PAC_RUT
                                item_lote.PAC_FNAC = data_lote(ii).PAC_FNAC
                                item_lote.ATE_NUM = data_lote(ii).ATE_NUM
                                item_lote.ATE_NUM_INTERNO = data_lote(ii).ATE_NUM_INTERNO
                                item_lote.ATE_DNI = data_lote(ii).ATE_DNI
                                item_lote.DOC_NOMBRE = data_lote(ii).DOC_NOMBRE
                                item_lote.DOC_APELLIDO = data_lote(ii).DOC_APELLIDO
                                item_lote.ID_PROCEDENCIA = data_lote(ii).ID_PROCEDENCIA
                                item_lote.NAC_DESC = data_lote(ii).NAC_DESC
                                item_lote.PROGRA_DESC = data_lote(ii).PROGRA_DESC
                                item_lote.SECTOR_DESC = data_lote(ii).SECTOR_DESC
                                item_lote.TP_RECHA_DESC = data_lote(ii).TP_RECHA_DESC

                                data_det_ate.Add(item_lote)
                            End If
                        Next ii

                    Else
                        For ii = 0 To data_lote.Count - 1
                            item_lote = New E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1

                            item_lote.LOTE_RECHAZO_NUM = data_lote(ii).LOTE_RECHAZO_NUM
                            item_lote.ID_ATENCION = data_lote(ii).ID_ATENCION
                            item_lote.RECEP_ETI_CURVA_RECHAZO = data_lote(ii).RECEP_ETI_CURVA_RECHAZO
                            item_lote.RECEP_ETI_NUM_ATE_RECHAZO = data_lote(ii).RECEP_ETI_NUM_ATE_RECHAZO
                            item_lote.ID_USUARIO = data_lote(ii).ID_USUARIO
                            item_lote.RECEP_ETI_FECHA_RECHAZO = data_lote(ii).RECEP_ETI_FECHA_RECHAZO
                            item_lote.ID_LOTE_RECHAZO = data_lote(ii).ID_LOTE_RECHAZO
                            item_lote.ID_ESTADO = data_lote(ii).ID_ESTADO
                            item_lote.CB_DESC = data_lote(ii).CB_DESC
                            item_lote.T_MUESTRA_DESC = data_lote(ii).T_MUESTRA_DESC
                            item_lote.CF_DESC = data_lote(ii).CF_DESC
                            item_lote.PAC_NOMBRE = data_lote(ii).PAC_NOMBRE
                            item_lote.PAC_APELLIDO = data_lote(ii).PAC_APELLIDO
                            item_lote.RLS_LS_DESC = data_lote(ii).RLS_LS_DESC
                            item_lote.ID_RLS_LS = data_lote(ii).ID_RLS_LS
                            item_lote.EST_DESCRIPCION = data_lote(ii).EST_DESCRIPCION
                            item_lote.ID_PER = data_lote(ii).ID_PER
                            item_lote.PROC_DESC = data_lote(ii).PROC_DESC
                            item_lote.ATE_AÑO = data_lote(ii).ATE_AÑO
                            item_lote.ATE_MES = data_lote(ii).ATE_MES
                            item_lote.USU_NIC = data_lote(ii).USU_NIC
                            item_lote.RECEP_ETI_RECHAZO_OBS = data_lote(ii).RECEP_ETI_RECHAZO_OBS
                            item_lote.ATE_DIA = data_lote(ii).ATE_DIA
                            item_lote.SEXO_DESC = data_lote(ii).SEXO_DESC

                            item_lote.PAC_RUT = data_lote(ii).PAC_RUT
                            item_lote.PAC_FNAC = data_lote(ii).PAC_FNAC
                            item_lote.ATE_NUM = data_lote(ii).ATE_NUM
                            item_lote.ATE_NUM_INTERNO = data_lote(ii).ATE_NUM_INTERNO
                            item_lote.ATE_DNI = data_lote(ii).ATE_DNI
                            item_lote.DOC_NOMBRE = data_lote(ii).DOC_NOMBRE
                            item_lote.DOC_APELLIDO = data_lote(ii).DOC_APELLIDO
                            item_lote.ID_PROCEDENCIA = data_lote(ii).ID_PROCEDENCIA
                            item_lote.NAC_DESC = data_lote(ii).NAC_DESC
                            item_lote.PROGRA_DESC = data_lote(ii).PROGRA_DESC
                            item_lote.SECTOR_DESC = data_lote(ii).SECTOR_DESC
                            item_lote.TP_RECHA_DESC = data_lote(ii).TP_RECHA_DESC

                            data_det_ate.Add(item_lote)
                        Next ii
                    End If
                End If
            Next i
        Else
            Return "null"
        End If










        If (data_det_ate.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim xls As New SLDocument
        Dim RowH As Integer = 30

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
        xls.SetCellValue(1, 1, "Rechazos por tubo")
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
        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""
        Dim muestra_comparador As String = ""

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
        xls.SetColumnWidth(13, RowH + 00)
        xls.SetColumnWidth(14, RowH + 15)
        xls.SetColumnWidth(15, RowH + 00)
        xls.SetColumnWidth(16, RowH + 00)
        xls.SetColumnWidth(17, RowH + 00)
        xls.SetColumnWidth(18, RowH + 15)
        xls.SetColumnWidth(19, RowH + 15)
        xls.SetColumnWidth(20, RowH + 00)
        xls.SetColumnWidth(21, RowH + 00)
        xls.SetColumnWidth(22, RowH + 00)
        xls.SetColumnWidth(23, RowH + 00)
        y2 += 2
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "#") : x2 += 1                     '1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "N° Atención") : x2 += 1           '2
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "N° Interno") : x2 += 1            '3
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Rut o DNI") : x2 += 1             '4
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Nombre Paciente") : x2 += 1       '5
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Fecha Nac.") : x2 += 1            '6
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Edad") : x2 += 1                  '7
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Nacionalidad") : x2 += 1          '8
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Etiqueta") : x2 += 1              '9
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Examen Fonasa") : x2 += 1         '10 
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Descripción Sección") : x2 += 1   '11
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Motivo") : x2 += 1                '12
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Observación") : x2 += 1           '13
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Estado") : x2 += 1                '14
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Fecha") : x2 += 1                 '15
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Hora") : x2 += 1                  '16
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Folio") : x2 += 1                 '17
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "N° Lote") : x2 += 1               '18
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Usuario") : x2 += 1               '19
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Lugar de TM") : x2 += 1           '20
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Programa") : x2 += 1              '21 
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Sector") : x2 += 1                '22
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Médico") : x2 += 1                '23

        For i = 0 To data_det_ate.Count - 1
            If (indice_if = 0) Then
                x2 = x1
                y2 += 1

                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, xi) : x2 += 1                                                                              '1
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).ATE_NUM) : x2 += 1                                                         '2
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).ATE_NUM_INTERNO) : x2 += 1                                                 '3
                xls.SetCellStyle(y2, x2, css_TCell_center)
                If data_det_ate(i).PAC_RUT = "" Then
                    xls.SetCellValue(y2, x2, data_det_ate(i).ATE_DNI) : x2 += 1
                Else
                    xls.SetCellValue(y2, x2, data_det_ate(i).PAC_RUT) : x2 += 1                                                     '4
                End If
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).PAC_NOMBRE & " " & data_det_ate(i).PAC_APELLIDO) : x2 += 1                 '5
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, Format(data_det_ate(i).PAC_FNAC, "dd/MM/yyyy")) : x2 += 1                                  '6
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).ATE_AÑO & " Años") : x2 += 1                                               '7
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).NAC_DESC) : x2 += 1                                                         '8
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, "[" & data_det_ate(i).RECEP_ETI_CURVA_RECHAZO & "]" & " " & data_det_ate(i).T_MUESTRA_DESC) : x2 += 1 '9
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).CF_DESC) : x2 += 1                                                         '10
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).RLS_LS_DESC) : x2 += 1                                                     '11
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).TP_RECHA_DESC) : x2 += 1                                                   '12
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).RECEP_ETI_RECHAZO_OBS) : x2 += 1                                           '13
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).EST_DESCRIPCION) : x2 += x1                                                 '14
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, Format(data_det_ate(i).RECEP_ETI_FECHA_RECHAZO, "dd/MM/yyyy")) : x2 += x1                   '15
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, Format(data_det_ate(i).RECEP_ETI_FECHA_RECHAZO, "HH:mm:ss")) : x2 += x1                     '16
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).RECEP_ETI_NUM_ATE_RECHAZO) : x2 += x1                                       '17
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).LOTE_RECHAZO_NUM) : x2 += x1                                                '18
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).USU_NIC) : x2 += x1                                                         '19
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).PROC_DESC) : x2 += x1                                                       '20
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).PROGRA_DESC) : x2 += x1                                                     '21
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).SECTOR_DESC) : x2 += x1                                                     '22
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).DOC_NOMBRE & " " & data_det_ate(i).DOC_APELLIDO) : x2 += x1                 '23

                xi += 1

                indice_if += 1
                cb_desc_comparador = data_det_ate(i).RECEP_ETI_CURVA_RECHAZO
                ate_num_comparador = data_det_ate(i).ATE_NUM
                muestra_comparador = data_det_ate(i).T_MUESTRA_DESC
            ElseIf ((((indice_if > 0) And (data_det_ate(i).RECEP_ETI_CURVA_RECHAZO <> cb_desc_comparador))) Or data_det_ate(i).ATE_NUM <> ate_num_comparador Or data_det_ate(i).T_MUESTRA_DESC <> muestra_comparador) Then
                x2 = x1
                y2 += 1

                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, xi) : x2 += 1                                                                              '1
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).ATE_NUM) : x2 += 1                                                         '2
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).ATE_NUM_INTERNO) : x2 += 1                                                 '3

                xls.SetCellStyle(y2, x2, css_TCell_center)
                If data_det_ate(i).PAC_RUT = "" Then
                    xls.SetCellValue(y2, x2, data_det_ate(i).ATE_DNI) : x2 += 1
                Else
                    xls.SetCellValue(y2, x2, data_det_ate(i).PAC_RUT) : x2 += 1                                                     '4
                End If

                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).PAC_NOMBRE & " " & data_det_ate(i).PAC_APELLIDO) : x2 += 1                 '5
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, Format(data_det_ate(i).PAC_FNAC, "dd/MM/yyyy")) : x2 += 1                                  '6
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).ATE_AÑO & " Años") : x2 += 1                                               '7
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).NAC_DESC) : x2 += 1                                                        '8
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, "[" & data_det_ate(i).RECEP_ETI_CURVA_RECHAZO & "]" & " " & data_det_ate(i).T_MUESTRA_DESC) : x2 += 1 '9
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).CF_DESC) : x2 += 1                                                         '10
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).RLS_LS_DESC) : x2 += 1                                                     '11
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).TP_RECHA_DESC) : x2 += 1                                                   '12
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).RECEP_ETI_RECHAZO_OBS) : x2 += 1                                           '13
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).EST_DESCRIPCION) : x2 += x1                                                 '14
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, Format(data_det_ate(i).RECEP_ETI_FECHA_RECHAZO, "dd/MM/yyyy")) : x2 += x1                   '15
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, Format(data_det_ate(i).RECEP_ETI_FECHA_RECHAZO, "HH:mm:ss")) : x2 += x1                     '16
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).RECEP_ETI_NUM_ATE_RECHAZO) : x2 += x1                                       '17
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).LOTE_RECHAZO_NUM) : x2 += x1                                                '18
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).USU_NIC) : x2 += x1                                                         '19
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).PROC_DESC) : x2 += x1                                                       '20
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).PROGRA_DESC) : x2 += x1                                                     '21
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).SECTOR_DESC) : x2 += x1                                                     '22
                xls.SetCellStyle(y2, x2, css_TCell_center)
                xls.SetCellValue(y2, x2, data_det_ate(i).DOC_NOMBRE & " " & data_det_ate(i).DOC_APELLIDO) : x2 += x1                 '23

                xi += 1

                indice_if += 1
                cb_desc_comparador = data_det_ate(i).RECEP_ETI_CURVA_RECHAZO
                ate_num_comparador = data_det_ate(i).ATE_NUM
                muestra_comparador = data_det_ate(i).T_MUESTRA_DESC
            End If

        Next i

        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Rechazos_Por_Tubo_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Dim URL As String = HttpContext.Current.Request.Url.Authority
        Return URL & "/" & Replace(Relative_Path, "\", "/")

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
    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If

        Select Case (CInt(C_P_ADMIN.Value))
            Case 1, 3, 0
            Case Else
                Response.Redirect("~/Index.aspx")
        End Select
    End Sub
End Class