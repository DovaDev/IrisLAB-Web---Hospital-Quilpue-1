Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
'Importar Capas
Imports Datos
Imports Entidades
Public Class N_REP_LAB_CANT_EXA_SECC
    'Declaraciones Generales
    Dim DD_Data As D_REP_LAB_CANT_EXA_SECC
    Sub New()
        DD_Data = New D_REP_LAB_CANT_EXA_SECC
    End Sub
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_SECCION(ByVal ID_SECCION As Long, ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_SECCION)
        Return DD_Data.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_SECCION(ID_SECCION, DESDE, HASTA)
    End Function
    Function Gen_Excel(ByVal MAIN_URL As String, ByVal ID_SECC As Long, ByVal DATE_str01 As String, ByVal DATE_str02 As String) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date_Operat
        Dim NN_Exam As New N_REP_LAB_CANT_EXA_SECC
        Dim Data_JSON As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_SECCION)
        DATE_str01 = DATE_str01.Replace("-", "/")
        DATE_str02 = DATE_str02.Replace("-", "/")
        Dim Date_01 As Date = NN_Date.strToDate(Split(DATE_str01, "/")(2), Split(DATE_str01, "/")(1), Split(DATE_str01, "/")(0))
        Dim Date_02 As Date = NN_Date.strToDate(Split(DATE_str02, "/")(2), Split(DATE_str02, "/")(1), Split(DATE_str02, "/")(0))
        Data_JSON = NN_Exam.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_SECCION(ID_SECC, Date_01, Date_02)
        If (Data_JSON.Count = 0) Then
            Return "null"
            Exit Function
        End If
        'Declaraciones Activos
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Activo As New List(Of E_IRIS_WEBF_BUSCA_SECCIONES_ACTIVO)
        Dim Seccion_Desc As String = "Todos"
        'Consultar por previsiones activas
        Data_Activo = NN_Activos.IRIS_WEBF_BUSCA_SECCIONES_ACTIVO()
        For y = 0 To (Data_Activo.Count - 1)
            If (ID_SECC = Data_Activo(y).ID_SECCION) Then
                Seccion_Desc = Data_Activo(y).SECC_DESC
                Exit For
            End If
        Next y
        'Vaciar Matriz
        Dim Mx_Data(0, 0) As Object
        ReDim Mx_Data(2, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_JSON.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(Mx_Data.GetUpperBound(0), y)
            End If
            'Agregar Código Fonasa sin el guión y número que le sigue
            Select Case (InStr(Data_JSON(y).CF_COD, "-"))
                Case 0
                    Mx_Data(0, y) = Data_JSON(y).CF_COD & ".-"
                Case Else
                    Dim Cod_Fonasa() As String = Split(Data_JSON(y).CF_COD, "-")
                    Mx_Data(0, y) = Cod_Fonasa(0) & ".-"
            End Select
            Mx_Data(1, y) = Data_JSON(y).CF_DESC
            Mx_Data(2, y) = Data_JSON(y).TOTAL_ATE
        Next y
        'Crear Tabla
        Dim Xls As New SLDocument
        Dim tablePosRow As Integer = 5
        Dim tablePosCol As Integer = 1
        'Colocar Título
        If (ID_SECC <> 0) Then
            Xls.SetCellValue(1, 1, "Total Exámenes por Sección: " & Seccion_Desc)
        Else
            Xls.SetCellValue(1, 1, "Total Exámenes por Sección")
        End If
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
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Código Fonasa") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Descripción de Prestación") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Cant. de Exám.")
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
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now, style)
        Next y
        'Definir Estilos de "Totales"
        tablePosRow_now += 1
        Dim style_total = Xls.CreateStyle()
        style_total.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Right)
        style_total.Font.Bold = True
        style_total.Font.FontSize = 16
        Xls.SetCellStyle(tablePosRow_now, tablePosCol + 1, style_total)
        style_total.Font.Bold = False
        'style_total.FormatCode = "$ ###,###,##0"
        style_total.FormatCode = "###,###,##0"
        Xls.SetCellStyle(tablePosRow_now, tablePosCol_now, style_total)
        'Insertar totales
        Dim nChar As Integer = Asc("A") - 1
        Xls.SetCellValue(tablePosRow_now, tablePosCol + 1, "Total:")
        Xls.SetCellValue(tablePosRow_now, tablePosCol_now - 0, "=SUM(" & (Chr(nChar + tablePosCol_now - 0) & tablePosRow + 1) & ":" & (Chr(nChar + tablePosCol_now - 0) & tablePosRow_now - 1) & ")")
        'Determinar Tabla
        Dim Inner_Table As SLTable = Xls.CreateTable(tablePosRow, tablePosCol, tablePosRow_now, tablePosCol_now)
        Inner_Table.SetTableStyle(SLTableStyleTypeValues.Dark11)
        Xls.InsertTable(Inner_Table)
        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Cant_Exa_Secc_" & Seccion_Desc & "_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        Xls.SaveAs(Ruta_save_local & Relative_Path)
        'Devolver la url del archivo generado
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
End Class