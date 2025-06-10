Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports Datos
Imports Entidades
Public Class N_Med_Det
    Dim DD_Gen_Activos As D_Gen_Activos
    Dim DD_Medico As D_Med_Details
    Sub New()
        DD_Gen_Activos = New D_Gen_Activos
        DD_Medico = New D_Med_Details
    End Sub
    Function IRIS_WEBF_BUSCA_LIS_ADM_MEDICO(ByVal ID_MEDI As Long, ByVal Date_1 As Date, ByVal Date_2 As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_MEDICO)
        Return DD_Medico.IRIS_WEBF_BUSCA_LIS_ADM_MEDICO(ID_MEDI, Date_1, Date_2)
    End Function
    Function Gen_Excel(ByVal MAIN_URL As String, ByVal ID_MED As Long, ByVal DATE1 As String, ByVal DATE2 As String) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date_Operat
        Dim NN_Med As New N_Med_Det
        Dim Data_Med As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_MEDICO)
        Dim Mx_Data(9, 0) As Object
        'Realizar Consulta
        Data_Med = NN_Med.IRIS_WEBF_BUSCA_LIS_ADM_MEDICO(ID_MED, DATE1, DATE2)
        If (Data_Med.Count = 0) Then
            Return "null"
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(10, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_Med.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(Mx_Data.GetUpperBound(0), y)
            End If
            Mx_Data(0, y) = Data_Med(y).ID_ATENCION
            Mx_Data(1, y) = Data_Med(y).PAC_NOMBRE & " " & Data_Med(y).PAC_APELLIDO
            Mx_Data(2, y) = Data_Med(y).DOC_NOMBRE & " " & Data_Med(y).DOC_APELLIDO
            Mx_Data(3, y) = Data_Med(y).ATE_FECHA
            Mx_Data(4, y) = Data_Med(y).PROC_DESC
            Mx_Data(5, y) = Data_Med(y).CF_COD & ".-"
            Mx_Data(6, y) = Data_Med(y).CF_DESC
            Mx_Data(7, y) = CInt(Data_Med(y).ATE_DET_V_PREVI)
            Mx_Data(8, y) = CInt(Data_Med(y).ATE_DET_V_PAGADO)
            Mx_Data(9, y) = CInt(Data_Med(y).ATE_DET_V_COPAGO)
            Mx_Data(10, y) = CInt(Data_Med(y).ATE_DET_V_PAGADO + Data_Med(y).ATE_DET_V_COPAGO)
        Next y
        'Crear Tabla
        Dim Xls As New SLDocument
        Dim tablePosRow As Integer = 5
        Dim tablePosCol As Integer = 1
        'Colocar Título
        If (ID_MED <> 0) Then
            Xls.SetCellValue(1, 1, "Atenciones por Médico: " & Mx_Data(2, 0))
        Else
            Xls.SetCellValue(1, 1, "Atenciones por Médicos")
        End If
        Xls.SetCellValue(2, 1, "Fecha desde: " & DATE1)
        Xls.SetCellValue(3, 1, "Fecha hasta: " & DATE2)
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
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "ID Atención") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Nombre Paciente") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Nombre Médico") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Fecha") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Lugar de TM") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Cod Fonasa") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Descripción") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Valor Sistema") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Valor Usuario") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Valor Copago") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Valor Pagado")
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
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 40) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 40) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 40) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1
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
            style.FormatCode = "dd/mm/yyyy h:mm:ss"
            Xls.SetCellStyle(tablePosRow_now, tablePosCol + 3, style)
            style.FormatCode = "$ ###,###,##0"
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 3, style)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 2, style)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 1, style)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 0, style)
        Next y
        'Definir Estilos de "Totales"
        tablePosRow_now += 1
        Dim style_total = Xls.CreateStyle()
        style_total.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Right)
        style_total.Font.Bold = True
        style_total.Font.FontSize = 16
        Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 4, style_total)
        style_total.Font.Bold = False
        style_total.FormatCode = "$ ###,###,##0"
        Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 3, style_total)
        Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 2, style_total)
        Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 1, style_total)
        Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 0, style_total)
        'Insertar totales
        Dim nChar As Integer = Asc("A") - 1
        Xls.SetCellValue(tablePosRow_now, tablePosCol_now - 4, "Total:")
        Xls.SetCellValue(tablePosRow_now, tablePosCol_now - 3, "=SUM(" & (Chr(nChar + tablePosCol_now - 3) & tablePosRow + 1) & ":" & (Chr(nChar + tablePosCol_now - 3) & tablePosRow_now - 1) & ")")
        Xls.SetCellValue(tablePosRow_now, tablePosCol_now - 2, "=SUM(" & (Chr(nChar + tablePosCol_now - 2) & tablePosRow + 1) & ":" & (Chr(nChar + tablePosCol_now - 2) & tablePosRow_now - 1) & ")")
        Xls.SetCellValue(tablePosRow_now, tablePosCol_now - 1, "=SUM(" & (Chr(nChar + tablePosCol_now - 1) & tablePosRow + 1) & ":" & (Chr(nChar + tablePosCol_now - 1) & tablePosRow_now - 1) & ")")
        Xls.SetCellValue(tablePosRow_now, tablePosCol_now - 0, "=SUM(" & (Chr(nChar + tablePosCol_now - 0) & tablePosRow + 1) & ":" & (Chr(nChar + tablePosCol_now - 0) & tablePosRow_now - 1) & ")")
        'Determinar Tabla
        Dim Inner_Table As SLTable = Xls.CreateTable(tablePosRow, tablePosCol, tablePosRow_now, tablePosCol_now)
        Inner_Table.SetTableStyle(SLTableStyleTypeValues.Dark11)
        Xls.InsertTable(Inner_Table)
        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Det_Ate_per_Med_" & Data_Med(0).DOC_NOMBRE & "_" & Data_Med(0).DOC_APELLIDO & " " & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        Xls.SaveAs(Ruta_save_local & Relative_Path)
        'Devolver la url del archivo generado
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
End Class

