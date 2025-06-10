Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class Lis_Env_Mues_Lab_4
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

        data_paciente = NN.IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO()

        Return data_paciente

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO_POR_FECHA(ByVal DESDE As String, ByVal HASTA As String, ByVal LUGARTM As Integer) As E_List_wDict3
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO)
        Dim NN As N_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO = New N_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO

        Dim data_paciente_2 As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)
        Dim NN_2 As N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO = New N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO

        Dim data_final As New List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)

        Dim e_element = New E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO

        Dim List_In As New List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)
        Dim List_Out As New E_List_wDict3


        data_paciente = NN.IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO_POR_FECHA_TOTAL_DE_LOTES(DESDE, HASTA, LUGARTM)

        If data_paciente.Count > 0 Then
            For i = 0 To data_paciente.Count - 1
                data_paciente_2 = NN_2.IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO_3_INFO_2(data_paciente(i).ENVIO_NUM)

                If data_paciente_2.Count > 0 Then

                    For Each item In data_paciente_2
                        e_element = New E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO

                        e_element.ENVIO_NUM = data_paciente(i).ENVIO_NUM
                        e_element.ENVIO_FECHA = item.ENVIO_FECHA
                        e_element.CB_DESC = item.CB_DESC
                        e_element.T_MUESTRA_DESC = item.T_MUESTRA_DESC
                        e_element.CANTIDAD_TUBO = item.CANTIDAD_TUBO

                        data_final.Add(e_element)

                    Next

                End If

                data_final.Add(e_element)
            Next i

        Else
            'Return E_List_wDict3
        End If

        List_In = data_final
        Dim Pairs As New Dictionary(Of String, Long)

        For Each etiq In List_In
            Dim strKey As String = "[" & etiq.CB_DESC & "]" & " - " & etiq.T_MUESTRA_DESC

            If (Pairs.Keys.Contains(strKey) = False) Then
                Pairs.Item(strKey) = 0
            End If
        Next

        Dim cb_desc_comparador As String = ""
        'Dim ate_num_comparador As String = ""
        Dim ate_muestra_comparador As String = ""

        For i = 0 To List_In.Count - 1
            Dim strKey As String = "[" & List_In(i).CB_DESC & "]" & " - " & List_In(i).T_MUESTRA_DESC
            If i = 0 Then

                Pairs.Item(strKey) += 1

                cb_desc_comparador = List_In(i).CB_DESC
                'ate_num_comparador = List_In(i).ATE_NUM
                ate_muestra_comparador = List_In(i).T_MUESTRA_DESC
            ElseIf ((((i > 0) And (List_In(i).CB_DESC <> cb_desc_comparador))) Or List_In(i).T_MUESTRA_DESC <> ate_muestra_comparador) Then
                Pairs.Item(strKey) += 1

                cb_desc_comparador = List_In(i).CB_DESC
                'ate_num_comparador = List_In(i).ATE_NUM
                ate_muestra_comparador = List_In(i).T_MUESTRA_DESC
            End If
        Next i

        List_Out.List_Data = List_In
        List_Out.Dictionary = Pairs

        Return List_Out

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

        data_paciente = NN.IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO_3(NUMLOTE)
        Return data_paciente

    End Function

    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal LUGARTM As Integer) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""

        'Declaraciones internas
        'Dim data_det_ate As E_List_wDict2
        Dim NN_Det_Ate As N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO = New N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO

        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO)
        Dim NN As N_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO = New N_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO

        Dim data_paciente_2 As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)
        Dim NN_2 As N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO = New N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO

        Dim data_final As New List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)

        Dim e_element = New E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO

        Dim List_In As New List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)
        Dim List_Out As New E_List_wDict3


        data_paciente = NN.IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO_POR_FECHA_TOTAL_DE_LOTES(DESDE, HASTA, LUGARTM)

        If data_paciente.Count > 0 Then
            For i = 0 To data_paciente.Count - 1
                data_paciente_2 = NN_2.IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO_3_INFO_2(data_paciente(i).ENVIO_NUM)

                If data_paciente_2.Count > 0 Then

                    For Each item In data_paciente_2
                        e_element = New E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO

                        e_element.ENVIO_NUM = data_paciente(i).ENVIO_NUM
                        e_element.ENVIO_FECHA = item.ENVIO_FECHA
                        e_element.CB_DESC = item.CB_DESC
                        e_element.T_MUESTRA_DESC = item.T_MUESTRA_DESC
                        e_element.CANTIDAD_TUBO = item.CANTIDAD_TUBO

                        data_final.Add(e_element)

                    Next

                End If

                data_final.Add(e_element)
            Next i

        Else
            'Return E_List_wDict3
        End If

        List_In = data_final
        Dim Pairs As New Dictionary(Of String, Long)

        For Each etiq In List_In
            Dim strKey As String = "[" & etiq.CB_DESC & "]" & " - " & etiq.T_MUESTRA_DESC

            If (Pairs.Keys.Contains(strKey) = False) Then
                Pairs.Item(strKey) = 0
            End If
        Next

        Dim cb_desc_comparador As String = ""
        'Dim ate_num_comparador As String = ""
        Dim ate_muestra_comparador As String = ""

        For i = 0 To List_In.Count - 1
            Dim strKey As String = "[" & List_In(i).CB_DESC & "]" & " - " & List_In(i).T_MUESTRA_DESC
            If i = 0 Then

                Pairs.Item(strKey) += 1

                cb_desc_comparador = List_In(i).CB_DESC
                'ate_num_comparador = List_In(i).ATE_NUM
                ate_muestra_comparador = List_In(i).T_MUESTRA_DESC
            ElseIf ((((i > 0) And (List_In(i).CB_DESC <> cb_desc_comparador))) Or List_In(i).T_MUESTRA_DESC <> ate_muestra_comparador) Then
                Pairs.Item(strKey) += 1

                cb_desc_comparador = List_In(i).CB_DESC
                'ate_num_comparador = List_In(i).ATE_NUM
                ate_muestra_comparador = List_In(i).T_MUESTRA_DESC
            End If
        Next i

        List_Out.List_Data = List_In
        List_Out.Dictionary = Pairs

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

        If (List_Out.List_Data.Count = 0) Then
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
        xls.SetCellValue(1, 1, "Listado Total de Tubos")
        xls.SetCellStyle(1, 1, css_Title)
        xls.MergeWorksheetCells(1, 1, 1, 3)

        xls.SetCellValue(2, 1, "DESDE: " & DESDE)
        xls.SetCellStyle(2, 1, css_SubTitle)
        xls.MergeWorksheetCells(2, 1, 2, 3)

        xls.SetCellValue(3, 1, "HASTA: " & HASTA)
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

        Dim ate_num_comparador As String = ""
        Dim muestra_comparados As String = ""

        xls.SetColumnWidth(1, RowH - 10)
        xls.SetColumnWidth(2, RowH + 00)
        xls.SetColumnWidth(3, RowH + 00)
        xls.SetColumnWidth(4, RowH + 00)
        xls.SetColumnWidth(5, RowH + 15)
        xls.SetColumnWidth(6, RowH + 00)

        'xls.SetCellValue(y2, x2, "Observación") : x2 += 1

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

        For Each key In List_Out.Dictionary.Keys
            x2 = x1
            y2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, contadorin) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_left)
            xls.SetCellValue(y2, x2, key) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_right)
            xls.SetCellValue(y2, x2, List_Out.Dictionary.Item(key)) : x2 = x1

            contadorin += 1
            super_sumador += List_Out.Dictionary.Item(key)
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
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Litado_Total_Tubos" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
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

        'If C_P_ADMIN = 0 Or C_P_ADMIN = 1 Then
        'Else

        '    Response.Redirect("~/Index.aspx")
        'End If

    End Sub


    Public Class E_List_wDict3
        Private EE_List_Data As IEnumerable(Of Object)
        Public Property List_Data() As IEnumerable(Of Object)
            Get
                Return EE_List_Data
            End Get
            Set(ByVal value As IEnumerable(Of Object))
                EE_List_Data = value
            End Set
        End Property

        Private EE_Dictionary As Dictionary(Of String, Long)
        Public Property Dictionary() As Dictionary(Of String, Long)
            Get
                Return EE_Dictionary
            End Get
            Set(ByVal value As Dictionary(Of String, Long))
                EE_Dictionary = value
            End Set
        End Property
    End Class
End Class