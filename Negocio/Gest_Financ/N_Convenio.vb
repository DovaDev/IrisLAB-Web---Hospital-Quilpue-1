'Importar Capas
Imports Datos
Imports Entidades
'Importar Librerías
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Public Class N_Convenio
    'Declaraciones Generales
    Dim DD_Data As D_Convenio
    Sub New()
        DD_Data = New D_Convenio
    End Sub
    Function IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO(ByVal ID_PREV As Long, ByVal DATE_01 As Date, ByVal DATE_02 As Date) As List(Of E_IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO)
        Dim Data_IN As New List(Of E_IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO)
        'Realizar Consulta
        Data_IN = DD_Data.IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO(ID_PREV, DATE_01, DATE_02)
        If (Data_IN.Count = 0) Then
            Return Data_IN
        End If
        For y = 0 To (Data_IN.Count - 1)
            'Limpiar "BK"
            Dim Name As String = Data_IN(y).CF_DESC
            If (Name.Contains(" BK") = True) Then
                Data_IN(y).CF_DESC = Name.Replace(" BK", "")
            ElseIf (Name.Contains(" bk") = True) Then
                Data_IN(y).CF_DESC = Name.Replace(" bk", "")
            End If
            'Limpiar Cod Fonasa
            Dim Cod() = Data_IN(y).CF_COD.Split("-")
            If (Cod.GetUpperBound(0) > 0) Then
                Data_IN(y).CF_COD = Cod(0)
            End If
        Next y
        ''Agregar ID_CF927 y ID_CF928 a otra lista
        'Dim List_OUT As New List(Of E_IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO)
        'Dim Item_OUT As E_IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO
        'Dim Posit = 0
        'Dim Index = 0
        'While (Index < Data_IN.Count)
        '    Select Case (Data_IN(Index).ID_CF)
        '        Case 927, 928
        '            Item_OUT = New E_IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO
        '            Item_OUT = Data_IN(Index)
        '            List_OUT.Add(Item_OUT)
        '            Data_IN.RemoveAt(Index)
        '            Posit = Index
        '        Case Else
        '            Index += 1
        '    End Select
        'End While
        ''Sumar valores de la nueva lista
        'Item_OUT = New E_IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO
        'For y = 0 To (List_OUT.Count - 1)
        '    Select Case (List_OUT.Count)
        '        Case 0
        '            Exit For
        '        Case 1
        '            Item_OUT.CF_DESC = List_OUT(y).CF_DESC
        '            Item_OUT.CF_PRECIO_AMB = List_OUT(y).CF_PRECIO_AMB
        '            Item_OUT.PJE_CONV = List_OUT(y).PJE_CONV
        '            Item_OUT.PJE_LAB = List_OUT(y).PJE_LAB
        '        Case Else
        '            If (List_OUT(y).ID_CF = 927) Then
        '                Item_OUT.CF_PRECIO_AMB = List_OUT(y).CF_PRECIO_AMB
        '                Item_OUT.PJE_CONV = List_OUT(y).PJE_CONV
        '                Item_OUT.PJE_LAB = List_OUT(y).PJE_LAB
        '            Else
        '                Item_OUT.CF_DESC = List_OUT(y).CF_DESC
        '            End If
        '    End Select
        '    Item_OUT.CF_COD += List_OUT(y).CF_COD
        '    Item_OUT.CANTIDAD += List_OUT(y).CANTIDAD
        '    Item_OUT.COSTO_AMB += List_OUT(y).COSTO_AMB
        '    Item_OUT.COSTO_DERIV += List_OUT(y).COSTO_DERIV
        '    Item_OUT.COSTO_TOTAL += List_OUT(y).COSTO_TOTAL
        'Next y
        'If (List_OUT.Count > 0) Then
        '    Data_IN.Add(Item_OUT)
        'End If
        'Ordenar lista por ID
        'Almacenar las ID en una lista
        Dim List_ID As New List(Of Integer)
        List_ID.Add(867)      '25-Hidroxi Vitamina D
        List_ID.Add(868)      'Ac. ANCA -P (IFI)    (MP0)
        List_ID.Add(869)      'Ac. ANCA-C (IFI) (PR3)
        List_ID.Add(935)      'Ac. Anti-Cardio Lipinas IgG    
        List_ID.Add(937)      'Ac. Anti-Cardio Lipinas IgM    
        List_ID.Add(933)      'Ac. anti-Gliadina IgA
        List_ID.Add(936)      'Ac. anti-Gliadina IgG
        List_ID.Add(881)      'Ac. antireceptor TSH (Trab)
        List_ID.Add(941)      'Acido Vainillilmandelico Cuantit. (Orina)
        List_ID.Add(891)      'Adenocorticotrofina (ACTH)
        List_ID.Add(943)      'Adenosindeaminasa (ADA)
        List_ID.Add(957)      'Bartonella Henselae Serologia  IgM
        List_ID.Add(956)      'Bartonella Henselae Serologia IgG 
        List_ID.Add(960)      'Bordetella Pertussis IgG
        List_ID.Add(961)      'Bordetella Pertussis IgM
        List_ID.Add(978)      'Citrato  (Citraturia orina de 24 Hrs.)
        List_ID.Add(900)      'Clonazepan,  Niveles Plásmaticos,(RAVOTRIL)
        List_ID.Add(980)      'Cobre en orina (CUPRURIA)
        List_ID.Add(495)      'Dehidrotestosterona
        List_ID.Add(497)      'Electroforesis de Lipoproteinas
        List_ID.Add(986)      'FTA-ABS, Anticuerpos Antitreponema
        List_ID.Add(1084)     'Hormona Antimulleriana (AMH)
        List_ID.Add(989)      'IGFBP1 (Insulin Like Growth Factor Binding Protein)
        List_ID.Add(226)      'Inmunofijación de cadenas livianas (K y L) AMBAS
        List_ID.Add(227)      'Inmunofijación de inmunogl. IgA+IgG+IgM (cadenas pesadas)
        List_ID.Add(228)      'Inmunofijación de inmunogl. IgA+IgG+IgM (cadenas pesadas)
        List_ID.Add(229)      'Inmunofijación de inmunogl. IgA+IgG+IgM (cadenas pesadas)
        List_ID.Add(997)      'Lamotrigina
        List_ID.Add(998)      'Nivel Plásmatico de Levetiracetam
        List_ID.Add(1003)     'Oxalato (Oxalaturia orina 24 HRS) Oxaluria
        List_ID.Add(927)      'Peptido Ciclico Citrulinado (aCCP)
        List_ID.Add(1029)     'Peptido C
        List_ID.Add(734)      'Proteinas urinarias, electroforesis (Orina de 24Hrs.
        List_ID.Add(1053)     'T3 Libre
        List_ID.Add(1014)     'Tipificacion  HLA B-27
        List_ID.Add(729)     'Virus Hepatitis A, Anticuerpos Totales (IgG-IgM)
        List_ID.Add(1020)     'Virus Hepatitis B, Ac. anti antigeno de superficie
        List_ID.Add(10)       'Virus Linfotropico Humano (HTLV I y II)
        List_ID.Add(910)      'Vitamina  B12
        List_ID.Add(1021)     'Zinc Orina
        List_ID.Add(1022)     'Zinc Sangre
        'Recorrer la Lista de IDs
        Dim Data_OUT As New List(Of E_IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO)
        For y = 0 To (List_ID.Count - 1)
            Dim Ayy As Long = 0
            While (Ayy < Data_IN.Count)
                Dim Int_ID As Long = List_ID(y)
                If (Int_ID = Data_IN(Ayy).ID_CF) Then
                    Dim Item_Ayy As New E_IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO
                    Item_Ayy = Data_IN(Ayy)
                    Data_OUT.Add(Item_Ayy)
                    Data_IN.RemoveAt(Ayy)
                    Ayy = 0
                Else
                    Ayy += 1
                End If
            End While
        Next y
        Return Data_OUT
    End Function
    'Function IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO(ByVal ID_PREV As Long, ByVal DATE_01 As Date, ByVal DATE_02 As Date) As List(Of E_IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO)
    '    Dim Data_L As New List(Of E_IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO)
    '    Data_L = DD_Data.IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO(ID_PREV, DATE_01, DATE_02)
    '    Dim Data_OUT As New List(Of E_IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO)
    '    Dim n As Integer
    '    Dim item_out As E_IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO
    '    REM limpiar data de los BK,bk
    '    Dim i As Integer = 0
    '    item_out = New E_IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO
    '    For y = 0 To Data_L.Count - 1
    '        Data_L(y).CF_DESC = Data_L(y).CF_DESC.Replace(" BK", "")
    '        Data_L(y).CF_DESC = Data_L(y).CF_DESC.Replace(" bk", "")
    '        Dim srt_cod As String = Data_L(y).CF_COD.Replace("--", "-")
    '        Dim str2_a() As String = srt_cod.Split("-")
    '        If (str2_a.GetUpperBound(0) > 0) Then
    '            Data_L(y).CF_COD = str2_a(0)
    '        End If
    '    Next y

    '    While (Data_L.Count > 0)
    '        item_out = Data_L(0)
    '        Data_OUT.Add(item_out)
    '        Data_L.RemoveAt(0)
    '        If (Data_L.Count = 0) Then
    '            Exit While
    '        End If
    '        Dim str_a = New E_IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO
    '        Dim str_b = New E_IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO
    '        str_a = Data_L(0)
    '        str_b = Data_OUT(Data_OUT.Count - 1)
    '        i = 0
    '        While (i <= Data_L.Count - 1)
    '            If (str_b.CF_DESC = str_a.CF_DESC) Then
    '                str_b.CANTIDAD = str_b.CANTIDAD + str_a.CANTIDAD
    '                If (str_b.CF_PRECIO_AMB = 0) Then
    '                    str_b.CF_PRECIO_AMB = str_a.CF_PRECIO_AMB
    '                Else
    '                End If
    '                str_b.COSTO_AMB = str_b.COSTO_AMB + str_a.COSTO_AMB
    '                str_b.COSTO_DERIV = str_b.COSTO_DERIV + str_a.COSTO_DERIV
    '                str_b.COSTO_TOTAL = str_b.COSTO_TOTAL + str_a.COSTO_TOTAL
    '                Data_OUT(Data_OUT.Count - 1) = str_b
    '                Data_L.RemoveAt(i)
    '                Exit While
    '            Else
    '                i += 1
    '            End If

    '        End While
    '    End While
    '    Return Data_OUT
    'End Function
    Function Gen_Xls(ByVal DOMAIN_URL As String, ByVal ID_PREV As Long, ByVal DATE_str01 As String, ByVal DATE_str02 As String) As String
        'Declaraciones del editor de Fechas
        Dim NN_Date As New N_Date_Operat
        Dim Date_01 As Date = NN_Date.strToDate(Split(DATE_str01, "/")(2), Split(DATE_str01, "/")(1), Split(DATE_str01, "/")(0))
        Dim Date_02 As Date = NN_Date.strToDate(Split(DATE_str02, "/")(2), Split(DATE_str02, "/")(1), Split(DATE_str02, "/")(0))
        'Declaraciones de la Consulta
        Dim NN_List As New N_Convenio
        Dim DD_List As New List(Of E_IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO)
        'Realizar consulta
        DD_List = NN_List.IRIS_WEBF_BUSCA_EXAMENES_SIN_CONVENIO(ID_PREV, Date_01, Date_02)
        If (DD_List.Count = 0) Then
            Return "null"
        End If
        'Declaraciones Xls
        Dim Mx_Data(0, 0) As Object
        ReDim Mx_Data(11, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        For y = 0 To (DD_List.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(Mx_Data.GetUpperBound(0), y)
            End If
            Dim Calc_Cod = Function(Cod As String)
                               Dim Mx_alt() = Cod.Split("-")
                               If (Mx_alt.GetUpperBound(0) > 0) Then
                                   Return Mx_alt(0)
                               Else
                                   Return Cod
                               End If
                           End Function
            Dim Calc_Diff = Function(C_AMB As Long, C_Total As Long) As Long
                                Dim Val As Long = 0
                                Val = C_AMB - C_Total
                                Return Val
                            End Function
            Dim Calc_Pje = Function(C_AMB As Long, C_Total As Long, Pje As Double) As Double
                               Dim Val As Long = 0
                               Val = C_AMB - C_Total
                               Val *= Pje * 0.01
                               Return Val
                           End Function
            Mx_Data(0, y) = Calc_Cod(DD_List(y).CF_COD) & ".-"
            Mx_Data(1, y) = DD_List(y).CF_DESC
            Mx_Data(2, y) = DD_List(y).CANTIDAD
            Mx_Data(3, y) = DD_List(y).CF_PRECIO_AMB
            Mx_Data(4, y) = DD_List(y).COSTO_AMB
            Mx_Data(5, y) = DD_List(y).COSTO_DERIV
            Mx_Data(6, y) = DD_List(y).COSTO_TOTAL
            Mx_Data(7, y) = Calc_Diff(DD_List(y).COSTO_AMB, DD_List(y).COSTO_TOTAL)
            Mx_Data(8, y) = CSng(DD_List(y).PJE_CONV) * 0.01
            Mx_Data(9, y) = Calc_Pje(DD_List(y).COSTO_AMB, DD_List(y).COSTO_TOTAL, DD_List(y).PJE_CONV)
            Mx_Data(10, y) = CSng(DD_List(y).PJE_LAB) * 0.01
            Mx_Data(11, y) = Calc_Pje(DD_List(y).COSTO_AMB, DD_List(y).COSTO_TOTAL, DD_List(y).PJE_LAB)
        Next y
        Dim NN_Activo As New N_Gen_Activos
        Dim DD_Activo As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Dim str_Prev As String = "Todos"
        'Realizar Consulta
        DD_Activo = NN_Activo.IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        For y = 0 To (DD_Activo.Count - 1)
            If (DD_Activo(y).ID_PREVE = ID_PREV) Then
                str_Prev = DD_Activo(y).PREVE_DESC
                Exit For
            End If
        Next y
        'Crear Tabla
        Dim Xls As New SLDocument
        Dim tablePosRow As Integer = 5
        Dim tablePosCol As Integer = 1
        'Colocar Título
        Xls.SetCellValue(1, 1, "Exámenes fuera de Convenio: " & str_Prev)
        Xls.SetCellValue(2, 1, "Fecha desde: " & Format(Date_01, "dd/MM/yyyy"))
        Xls.SetCellValue(3, 1, "Fecha hasta: " & Format(Date_02, "dd/MM/yyyy"))
        'Crear estilo para los títulos
        Dim TitleStyle = Xls.CreateStyle()
        TitleStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        TitleStyle.Font.Bold = True
        TitleStyle.Font.FontSize = 24
        Xls.SetCellStyle(1, 1, TitleStyle)
        TitleStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        TitleStyle.Font.Bold = True
        TitleStyle.Font.FontSize = 16
        Xls.SetCellStyle(2, 1, TitleStyle)
        Xls.SetCellStyle(3, 1, TitleStyle)
        Xls.MergeWorksheetCells(1, 1, 1, 6)
        Xls.MergeWorksheetCells(2, 1, 2, 3)
        Xls.MergeWorksheetCells(3, 1, 3, 3)
        'Llenar Cabeceras
        Xls.RenameWorksheet("Sheet1", "Atenciones por Médico: " & Mx_Data(1, 0))
        Dim tablePosCol_now As Integer = tablePosCol
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Cod Fonasa") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Descripción") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Cantidad") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Valor Unit.") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Valor Pac.") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Costo Deriv.") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Total Costos") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Diferencial") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "%") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "% Aconcagua ($)") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "%") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "% Lab. ($)")
        'Crear estilo para las cabeceras
        Dim colHeaderStyle = Xls.CreateStyle()
        colHeaderStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.CenterContinuous)
        colHeaderStyle.Font.Bold = True
        colHeaderStyle.Font.FontSize = 14
        'Asignar un estilo
        For x = tablePosCol To tablePosCol_now
            Xls.SetCellStyle(tablePosRow, x, colHeaderStyle)
            Xls.AutoFitColumn(x, 250)
        Next x
        'Determinar ancho de Columnas
        tablePosCol_now = tablePosCol
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 45) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 15) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 15) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 25)
        'Agregar el contenido de la matriz
        Dim tablePosRow_now As Integer = tablePosRow
        For y = 0 To Mx_Data.GetUpperBound(1)
            'Sumar +1 a la fila seleccionada
            tablePosRow_now += 1
            For x = 0 To Mx_Data.GetUpperBound(0)
                Xls.SetCellValue(tablePosRow_now, tablePosCol + x, Mx_Data(x, y))
            Next x
            'Formato de celdas
            Dim style = Xls.CreateStyle()
            'style.FormatCode = "dd/mm/yyyy h:mm:ss"
            'Xls.SetCellStyle(tablePosRow_now, tablePosCol + 3, style)
            style.FormatCode = "###,###,##0"
            Xls.SetCellStyle(tablePosRow_now, tablePosCol + 2, style)
            For aa = 3 To tablePosCol_now - 1
                Select Case (aa)
                    Case 8, 10
                        style.FormatCode = "0.00%"
                        Xls.SetCellStyle(tablePosRow_now, tablePosCol + aa, style)
                    Case Else
                        style.FormatCode = "$ ###,###,##0"
                        Xls.SetCellStyle(tablePosRow_now, tablePosCol + aa, style)
                End Select
            Next aa
        Next y
        'Definir Estilos de "Totales"
        tablePosRow_now += 1
        Dim style_total = Xls.CreateStyle()
        style_total.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Right)
        style_total.Font.Bold = True
        style_total.Font.FontSize = 16
        Xls.SetCellStyle(tablePosRow_now, tablePosCol + 1, style_total)
        style_total.Font.Bold = False
        For aa = 2 To tablePosCol_now - 1
            Select Case (aa)
                Case 10, 8
                    style_total.FormatCode = ""
                    Xls.SetCellStyle(tablePosRow_now, tablePosCol + aa, style_total)
                Case 2
                    style_total.FormatCode = "###,###,##0"
                    Xls.SetCellStyle(tablePosRow_now, tablePosCol + aa, style_total)
                Case Else
                    style_total.FormatCode = "$ ###,###,##0"
                    Xls.SetCellStyle(tablePosRow_now, tablePosCol + aa, style_total)
            End Select
        Next aa
        'Insertar totales
        Dim nChar As Integer = Asc("A") - 1
        Xls.SetCellValue(tablePosRow_now, tablePosCol + 1, "Total:")
        For aa = 2 To tablePosCol_now - 1
            Select Case aa
                Case 10, 8
                    Xls.SetCellValue(tablePosRow_now, tablePosCol + aa, " - ")
                Case Else
                    Xls.SetCellValue(tablePosRow_now, tablePosCol + aa, "=SUM(" & (Chr(nChar + tablePosCol + aa) & tablePosRow + 1) & ":" & (Chr(nChar + tablePosCol + aa) & tablePosRow_now - 1) & ")")
            End Select
        Next aa
        'Determinar Tabla
        Dim Inner_Table As SLTable = Xls.CreateTable(tablePosRow, tablePosCol, tablePosRow_now, tablePosCol_now)
        Inner_Table.SetTableStyle(SLTableStyleTypeValues.Dark11)
        Xls.InsertTable(Inner_Table)
        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Val_Convenios_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        Xls.SaveAs(Ruta_save_local & Relative_Path)
        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
End Class