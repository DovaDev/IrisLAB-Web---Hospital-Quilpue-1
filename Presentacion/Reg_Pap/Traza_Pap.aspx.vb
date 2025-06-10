
Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
'Imports System.Globalization
Public Class Traza_Pap
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_DOCUMENTOS_TRAZA_PAP(ByVal ID_CAJA As Integer) As REEE_Folios

        Dim DATA_DOCUMENTO As List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)
        Dim NN_DATA As N_IRIS_WEBF_BUSCA_DOCUMENTOS = New N_IRIS_WEBF_BUSCA_DOCUMENTOS

        Dim DATA_FOLIOS As List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)
        Dim NN_DATA_FOLIOS As N_IRIS_WEBF_BUSCA_DOCUMENTOS = New N_IRIS_WEBF_BUSCA_DOCUMENTOS

        Dim data_paciente As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP)
        Dim NN As N_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2 = New N_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2

        Dim data_list As New List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP)

        DATA_DOCUMENTO = NN_DATA.IRIS_WEBF_BUSCA_DOCUMENTOS_TRAZA_PAP(ID_CAJA)

        DATA_FOLIOS = NN_DATA_FOLIOS.IRIS_WEBF_BUSCA_DOCUMENTOS_TRAZA_PAP_FOLIOS(ID_CAJA)

        Dim folios As Object() = DATA_FOLIOS(0).MATRIZ_NUM_AVIS.Split(",")

        If folios.Count > 0 Then

            For i = 0 To folios.Count - 1
                data_paciente = NN.IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP(folios(i))

                If data_paciente.Count > 0 Then
                    Dim item_ As New E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP

                    item_.HO_CC = data_paciente(0).HO_CC
                    item_.ID_ATENCION = data_paciente(0).ID_ATENCION
                    item_.ATE_NUM = data_paciente(0).ATE_NUM
                    item_.ATE_FECHA = data_paciente(0).ATE_FECHA
                    item_.PROC_DESC = data_paciente(0).PROC_DESC
                    item_.PREVE_DESC = data_paciente(0).PREVE_DESC
                    item_.PAC_RUT = data_paciente(0).PAC_RUT
                    item_.PAC_NOMBRE = data_paciente(0).PAC_NOMBRE
                    item_.PAC_APELLIDO = data_paciente(0).PAC_APELLIDO
                    item_.PAC_FNAC = data_paciente(0).PAC_FNAC
                    item_.ID_SEXO = data_paciente(0).ID_SEXO
                    item_.DOC_NOMBRE = data_paciente(0).DOC_NOMBRE
                    item_.DOC_APELLIDO = data_paciente(0).DOC_APELLIDO
                    item_.ATE_OBS_FICHA = data_paciente(0).ATE_OBS_FICHA
                    item_.ATE_AÑO = data_paciente(0).ATE_AÑO

                    data_list.Add(item_)

                End If
            Next i

        End If

        Dim hola = New REEE_Folios

        hola.proparra1_SUPER = DATA_DOCUMENTO
        hola.proparra2_SUPER = data_list

        Return hola

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_DOCUMENTOS_TRAZA_PAP_CAJA(ByVal DESDE As String, ByVal HASTA As String, ByVal LUGARTM As Integer) As List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)

        Dim DATA_DOCUMENTO As List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)
        Dim NN_DATA As N_IRIS_WEBF_BUSCA_DOCUMENTOS = New N_IRIS_WEBF_BUSCA_DOCUMENTOS

        DATA_DOCUMENTO = NN_DATA.IRIS_WEBF_BUSCA_DOCUMENTOS_TRAZA_PAP_CAJA(DESDE, HASTA, LUGARTM)

        Return DATA_DOCUMENTO
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_GRABA_CAJA_TRAZA_PAP(ByVal COMENTARIO As String,
                                                          ByVal TIPO As String,
                                                          ByVal ID_USUARIO As Integer,
                                                          ByVal MATRIZ_NUM_AVIS() As Object,
                                                          ByVal ID_PROC As String) As Integer

        Dim GRABA_DOCUMENTO As Integer = 0
        Dim NN_DATA As N_IRIS_WEBF_BUSCA_DOCUMENTOS = New N_IRIS_WEBF_BUSCA_DOCUMENTOS
        Dim todosLosAvis As String = ""

        For i = 0 To MATRIZ_NUM_AVIS.Length - 1
            If i = 0 Then
                todosLosAvis += MATRIZ_NUM_AVIS(i)
            Else
                todosLosAvis += "," & MATRIZ_NUM_AVIS(i)
            End If


        Next i

        GRABA_DOCUMENTO = NN_DATA.IRIS_WEBF_GRABA_CAJA_TRAZA_PAP(COMENTARIO, TIPO, ID_USUARIO, todosLosAvis, ID_PROC)



        Return GRABA_DOCUMENTO

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_UPDATE_ESTADO_DOCUMENTOS(ByVal ID_DCTO As Integer) As Integer


        Dim ELIMINA_DOCUMENTO As Integer = 0
        Dim NN_DATA As N_IRIS_WEBF_BUSCA_DOCUMENTOS = New N_IRIS_WEBF_BUSCA_DOCUMENTOS

        ELIMINA_DOCUMENTO = NN_DATA.IRIS_WEBF_UPDATE_ESTADO_DOCUMENTOS(ID_DCTO)

        Return ELIMINA_DOCUMENTO
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_UPDATE_ESTADO_DOCUMENTOS_HABILITAR(ByVal ID_DCTO As Integer) As Integer


        Dim ELIMINA_DOCUMENTO As Integer = 0
        Dim NN_DATA As N_IRIS_WEBF_BUSCA_DOCUMENTOS = New N_IRIS_WEBF_BUSCA_DOCUMENTOS

        ELIMINA_DOCUMENTO = NN_DATA.IRIS_WEBF_UPDATE_ESTADO_DOCUMENTOS_HABILITAR(ID_DCTO)

        Return ELIMINA_DOCUMENTO
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_RECIBIR_CAJA(ByVal ID_USUARIO As Integer, ByVal NUM_TRAZA As Integer) As Integer


        Dim Update_Desc As Integer = 0
        Dim NN_DATA As N_IRIS_WEBF_BUSCA_DOCUMENTOS = New N_IRIS_WEBF_BUSCA_DOCUMENTOS

        Update_Desc = NN_DATA.IRIS_WEBF_RECIBIR_CAJA(ID_USUARIO, NUM_TRAZA)

        Return Update_Desc
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
    Public Shared Function Llenar_AVIS(ByVal NUM_AVIS As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP)
        Dim NN As N_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2 = New N_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2

        Dim NN_ExamenDet As New N_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR
        Dim DataExamenDet As New List(Of E_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR)

        Dim Encrypt As New N_Encrypt

        data_paciente = NN.IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP(NUM_AVIS)

        If (data_paciente.Count > 0) Then
            'data_paciente(0).ENCRYPTED_ID = Encrypt.Encode(data_paciente(0).ID_ATENCION)

            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_paciente, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_ELIMINAR_TRAZA_PAP(ByVal ID_CAJA As Integer) As Integer

        Dim fonaliza_caja As Integer = 0
        Dim NN_DATA As N_IRIS_WEBF_BUSCA_DOCUMENTOS = New N_IRIS_WEBF_BUSCA_DOCUMENTOS

        fonaliza_caja = NN_DATA.IRIS_WEBF_ELIMINAR_TRAZA_PAP(ID_CAJA)

        Return fonaliza_caja

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_FINALIZAR_TRAZA_PAP(ByVal ID_CAJA As Integer, ByVal COMENTARIO As String) As Integer

        Dim fonaliza_caja As Integer = 0
        Dim NN_DATA As N_IRIS_WEBF_BUSCA_DOCUMENTOS = New N_IRIS_WEBF_BUSCA_DOCUMENTOS

        fonaliza_caja = NN_DATA.IRIS_WEBF_FINALIZAR_TRAZA_PAP(ID_CAJA, COMENTARIO)

        Return fonaliza_caja

    End Function


    <Services.WebMethod()>
    Public Shared Function NUMERO(ByVal hola As String) As Double

        Dim numeroooo As String = hola
        Dim numeroooo2 As Double
        Dim numeroooo3 As String = ""
        'Dim numeroooo4


        If ((numeroooo.Trim <> "") And (IsNumeric(numeroooo.Replace(",", ".").Trim) = True)) Then
            numeroooo2 = CDbl(numeroooo)
        ElseIf (numeroooo.Trim <> "") Then
            numeroooo2 = 0
        Else
            numeroooo2 = Nothing
        End If



        Dim strRange As String = ""
        If ((numeroooo.Trim <> "") And (IsNumeric(numeroooo.Replace(",", ".").Trim) = True)) Then
            'numeroooo = CDbl(numeroooo.Replace(",", "."))
            'numeroooo2 = numeroooo.Replace(",", ".")
            numeroooo3 = CDbl(numeroooo)

            'numeroooo3 = Convert.ToDouble(numeroooo2)
            'numeroooo4 = Double.Parse(numeroooo3, NumberStyles.AllowDecimalPoint, CultureInfo.CurrentCulture)

        ElseIf (numeroooo.Trim <> "") Then
            strRange = numeroooo.Trim
        Else
            numeroooo = Nothing
        End If


        'Dim s As String = "2,5"

        'Dim r As Double

        'Dim is_good As Boolean

        'is_good = Double.TryParse(s, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, r)

        Return numeroooo2

    End Function


    <Services.WebMethod()>
    Public Shared Function PDF(ByVal DOMAIN_URL As String, ByVal ID_CAJA As Integer) As String

        'Declaraciones internas
        Dim List_print As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_OC_SED)
        'Dim Item_print As E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_OC_SED
        Dim NN_PDF As New N_PDF
        'Dim elemento()
        'If selected.Length > 0 Then
        '    For i = 0 To selected.Length - 1
        '        Item_print = New E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_OC_SED

        '        elemento = selected(i).split("~")


        '        Item_print.SEXO_DESC = elemento(0)
        '        Item_print.ATE_NUM = elemento(1)
        '        Item_print.PAC_NOMBRE = elemento(2)
        '        Item_print.PAC_APELLIDO = elemento(3)
        '        Item_print.ATE_AÑO = elemento(4)
        '        Item_print.CF_CORTO = elemento(5)
        '        Item_print.PAC_RUT = elemento(6)

        '        List_print.Add(Item_print)
        '    Next i
        Return NN_PDF.PDF_CAJAS_PAP(DOMAIN_URL, ID_CAJA)
        'End If

        Return "null"

    End Function

    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal ID_CAJA As Integer) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""

        'Declaraciones internas
        Dim DATA_DOCUMENTO As List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)
        Dim NN_DATA As N_IRIS_WEBF_BUSCA_DOCUMENTOS = New N_IRIS_WEBF_BUSCA_DOCUMENTOS

        Dim DATA_FOLIOS As List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)
        Dim NN_DATA_FOLIOS As N_IRIS_WEBF_BUSCA_DOCUMENTOS = New N_IRIS_WEBF_BUSCA_DOCUMENTOS

        Dim data_paciente As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP)
        Dim NN As N_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2 = New N_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2

        Dim data_list As New List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP)

        DATA_DOCUMENTO = NN_DATA.IRIS_WEBF_BUSCA_DOCUMENTOS_TRAZA_PAP(ID_CAJA)

        DATA_FOLIOS = NN_DATA_FOLIOS.IRIS_WEBF_BUSCA_DOCUMENTOS_TRAZA_PAP_FOLIOS(ID_CAJA)

        Dim folios As Object() = DATA_FOLIOS(0).MATRIZ_NUM_AVIS.Split(",")

        If folios.Count > 0 Then

            For i = 0 To folios.Count - 1
                data_paciente = NN.IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP(folios(i))

                If data_paciente.Count > 0 Then
                    Dim item_ As New E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP

                    item_.HO_CC = data_paciente(0).HO_CC
                    item_.ID_ATENCION = data_paciente(0).ID_ATENCION
                    item_.ATE_NUM = data_paciente(0).ATE_NUM
                    item_.ATE_FECHA = data_paciente(0).ATE_FECHA
                    item_.PROC_DESC = data_paciente(0).PROC_DESC
                    item_.PREVE_DESC = data_paciente(0).PREVE_DESC
                    item_.PAC_RUT = data_paciente(0).PAC_RUT
                    item_.PAC_NOMBRE = data_paciente(0).PAC_NOMBRE
                    item_.PAC_APELLIDO = data_paciente(0).PAC_APELLIDO
                    item_.PAC_FNAC = data_paciente(0).PAC_FNAC
                    item_.ID_SEXO = data_paciente(0).ID_SEXO
                    item_.DOC_NOMBRE = data_paciente(0).DOC_NOMBRE
                    item_.DOC_APELLIDO = data_paciente(0).DOC_APELLIDO
                    item_.ATE_OBS_FICHA = data_paciente(0).ATE_OBS_FICHA
                    item_.ATE_AÑO = data_paciente(0).ATE_AÑO

                    data_list.Add(item_)

                End If
            Next i

        End If

        Dim hola = New REEE_Folios

        hola.proparra1_SUPER = DATA_DOCUMENTO
        hola.proparra2_SUPER = data_list

        'creamos el objeto SLDocument el cual creara el excel
        Dim sl As SLDocument = New SLDocument

        Dim edad As Integer = 0
        Dim idate As String = ""

        If (DATA_DOCUMENTO.Count = 0) Then
            Return Nothing
            Exit Function
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
        xls.SetCellValue(1, 1, "Visualización y Recepción de Cajas PAP")
        xls.SetCellStyle(1, 1, css_Title)
        xls.MergeWorksheetCells(1, 1, 1, 3)

        xls.SetCellValue(2, 1, "N° de Caja: " & ID_CAJA)
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

        xls.SetColumnWidth(1, RowH - 15)
        xls.SetColumnWidth(2, RowH + 00)
        xls.SetColumnWidth(3, RowH + 00)
        'xls.SetColumnWidth(4, RowH + 00)
        xls.SetColumnWidth(5, RowH - 15)
        xls.SetColumnWidth(6, RowH - 10)
        xls.SetColumnWidth(7, RowH - 10)
        xls.SetColumnWidth(8, RowH + 00)
        xls.SetColumnWidth(9, RowH + 00)
        xls.SetColumnWidth(10, RowH + 00)
        xls.SetColumnWidth(11, RowH + 00)

        y2 += 2
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "#") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Recepcionado por") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Fecha Recep.") : x2 = x1

        For Each List_Data As E_IRIS_WEBF_BUSCA_DOCUMENTOS In DATA_DOCUMENTO
            x2 = x1
            y2 += 1

            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, xi) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.USU_NIC) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, Format(List_Data.FECHA_TRAZA, "dd/MM/yyyy HH:mm")) : x2 += 1

            xi += 1

        Next
        '--------------------------------------------------------------------------------------------------------------------
        x2 = 5
        y2 = 5

        y2 += 2
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "#") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Folio Avis") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Ate Num") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Ate Fecha") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Rut") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Nombre Pac") : x2 += 1
        xls.SetCellStyle(y2, x2, css_THead)
        xls.SetCellValue(y2, x2, "Edad") : x2 = x1

        For Each List_Data As E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP In data_list
            x2 = 5
            y2 += 1
            xi = 1

            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, xi) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.HO_CC) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.ATE_NUM) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, Format(List_Data.ATE_FECHA, "dd/MM/yyyy HH:mm")) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.PAC_RUT) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.PAC_NOMBRE & " " & List_Data.PAC_APELLIDO) : x2 += 1
            xls.SetCellStyle(y2, x2, css_TCell_center)
            xls.SetCellValue(y2, x2, List_Data.ATE_AÑO & " Años") : x2 += 1

            xi += 1

        Next

        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Visualizacion_Recepción_Cajas_PAP_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Dim URL As String = HttpContext.Current.Request.Url.Authority
        Return URL & "/" & Replace(Relative_Path, "\", "/")

    End Function

    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If

        'Select Case (C_P_ADMIN.Value)
        '    Case Is <> 1
        '        Response.Redirect("~/Index.aspx")
        'End Select
    End Sub

End Class


Public Class REEE_Folios
    Dim arr1 As List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)
    Public Property proparra1_SUPER As List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS)
        Get
            Return arr1
        End Get
        Set(ByVal value As List(Of E_IRIS_WEBF_BUSCA_DOCUMENTOS))
            arr1 = value
        End Set
    End Property
    Dim arr2 As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP)
    Public Property proparra2_SUPER As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP)
        Get
            Return arr2
        End Get
        Set(ByVal value As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP))
            arr2 = value
        End Set
    End Property
End Class