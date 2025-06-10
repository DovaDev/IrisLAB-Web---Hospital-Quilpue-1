Imports Negocio
Imports Entidades
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Imports Datos
Public Class HT_Sec_Proce
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_LugarTM() As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        'Declaraciones internas
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        Dim Data_Exam As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Data_Exam = NN_Exam.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()
        If (Data_Exam.Count > 0) Then
            Return Data_Exam
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Seccion() As List(Of E_IRIS_WEBF_BUSCA_SECCIONES_ACTIVO)
        'Declaraciones internas
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_SECCIONES_ACTIVO
        Dim Data_Exam As New List(Of E_IRIS_WEBF_BUSCA_SECCIONES_ACTIVO)
        Data_Exam = NN_Exam.IRIS_WEBF_BUSCA_SECCIONES_ACTIVO()
        If (Data_Exam.Count > 0) Then
            Return Data_Exam
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Call_DataTable(ByVal DATE_str01 As String, ByVal DATE_str02 As String, ByVal ID_SECC As Long, ByVal ID_PRE As Long) As List(Of E_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_5)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        Dim NN_Table As New N_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_5
        Dim List_Obj As New List(Of E_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_5)
        Dim N_ECrypt As New N_Encrypt
        List_Obj = NN_Table.IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_5(DATE_str01, DATE_str02, ID_SECC, ID_PRE)

        If (List_Obj.Count > 0) Then
            For i = 0 To (List_Obj.Count - 1)
                List_Obj(i).ENCRYPTED_ID = N_ECrypt.Encode(List_Obj(i).ID_ATENCION)
            Next i
            Return List_Obj
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal DATE_str01 As String, ByVal DATE_str02 As String, ByVal ID_SECC As Long, ByVal ID_PRE As Long) As String
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim List_Activo_01 As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Dim List_Activo_02 As New List(Of E_IRIS_WEBF_BUSCA_SECCIONES_ACTIVO)

        List_Activo_01 = NN_Activos.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        List_Activo_02 = NN_Activos.IRIS_WEBF_BUSCA_SECCIONES_ACTIVO

        Dim Select_Proce As String = "Todos"
        For y = 0 To (List_Activo_01.Count - 1)
            If (List_Activo_01(y).ID_PROCEDENCIA = ID_PRE) Then
                Select_Proce = List_Activo_01(y).PROC_DESC
                Exit For
            End If
        Next y

        Dim Select_Secc As String = "Todos"
        For y = 0 To (List_Activo_02.Count - 1)
            If (List_Activo_02(y).ID_SECCION = ID_SECC) Then
                Select_Secc = List_Activo_02(y).SECC_DESC
                Exit For
            End If
        Next y


        Dim DD_Data = New D_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_5

        'Consulta Principal
        Dim Data_OUT As New List(Of E_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_5)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_TM")
        Dim ID_PROC As Integer

        Try
            ID_PROC = CInt(galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try
        Data_OUT = DD_Data.IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_5(DATE_str01, DATE_str02, ID_SECC, ID_PRE, ID_PROC)

        'Armar Excel
        'Declaraciones Generales
        If (Data_OUT.Count = 0) Then
            Return "null"
            Exit Function
        End If

        Dim Mx_Data(0, 0) As Object
        ReDim Mx_Data(12, 0)

        'Vaciar Matriz
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x

        'Llenar Matriz
        For y = 0 To (Data_OUT.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(Mx_Data.GetUpperBound(0), y)
            End If
            Dim Calc_Age As New N_Calc_Age

            Mx_Data(0, y) = Data_OUT(y).ATE_NUM
            Mx_Data(1, y) = Data_OUT(y).PAC_RUT
            Mx_Data(2, y) = Data_OUT(y).PAC_DNI
            Mx_Data(3, y) = Data_OUT(y).NAC_DESC
            Mx_Data(4, y) = Data_OUT(y).PAC_NOMBRE & " " & Data_OUT(y).PAC_APELLIDO
            Mx_Data(5, y) = Format(Data_OUT(y).PAC_FNAC, "dd/MM/yyyy")
            Mx_Data(6, y) = Calc_Age.IrisLAB_Cal_Edad_Exacta(Data_OUT(y).PAC_FNAC, Date.Now, True)
            Mx_Data(7, y) = Format(Data_OUT(y).ATE_FECHA, "dd/MM/yyyy")
            Mx_Data(8, y) = Data_OUT(y).PROC_DESC
            Mx_Data(9, y) = Data_OUT(y).ATE_NUM_INTERNO
            Mx_Data(10, y) = Data_OUT(y).PROGRA_DESC
            Mx_Data(11, y) = Data_OUT(y).SECTOR_DESC
            Mx_Data(12, y) = Data_OUT(y).DOC_NOMBRE & " " & Data_OUT(y).DOC_APELLIDO

        Next y

        'Crear Tabla
        Dim Xls As New SLDocument
        Dim tablePosRow As Integer = 8
        Dim tablePosCol As Integer = 1

        'Colocar Título
        Xls.SetCellValue(1, 1, "Listado de Trabajo Sección y Procedencia: ")
        Xls.SetCellValue(2, 1, "Fecha desde: " & DATE_str01)
        Xls.SetCellValue(3, 1, "Fecha hasta: " & DATE_str02)
        Xls.SetCellValue(4, 1, "Sección: " & Select_Secc)
        Xls.SetCellValue(5, 1, "Procedencia: " & Select_Proce)


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
        Xls.SetCellStyle(4, 1, TitleStyle)
        Xls.SetCellStyle(5, 1, TitleStyle)

        Xls.MergeWorksheetCells(1, 1, 1, 6)
        Xls.MergeWorksheetCells(2, 1, 2, 3)
        Xls.MergeWorksheetCells(3, 1, 3, 3)
        Xls.MergeWorksheetCells(4, 1, 4, 3)
        Xls.MergeWorksheetCells(5, 1, 5, 3)

        'Llenar Cabeceras
        Xls.RenameWorksheet("Sheet1", "Revisión de Valores Críticos: " & Mx_Data(1, 0))
        Dim tablePosCol_now As Integer = tablePosCol

        Xls.SetCellValue(tablePosRow, tablePosCol_now, "N° Atención") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "RUT Paciente") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "DNI") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Nacionalidad") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Nombre Paciente") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Fecha Nac") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Edad") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Fecha") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Lugar de TM") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Num Interno") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Programa") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Sector") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Médico") : tablePosCol_now += 1

        tablePosCol_now -= 1

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
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'DNI
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 40) : tablePosCol_now += 1 'nombre
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 ' f nac
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1 'edad
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'fecha
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1 'lugar tm
        Xls.SetColumnWidth(tablePosCol_now, 15) : tablePosCol_now += 1 'num interno
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'programa
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'sector
        Xls.SetColumnWidth(tablePosCol_now, 40) : tablePosCol_now += 1 'medico

        tablePosCol_now -= 1

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
            style.FormatCode = "dd/mm/yyyy"
            Xls.SetCellStyle(tablePosRow_now, tablePosCol + 4, style)

            style.FormatCode = "###,###,##0.0###"
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 5, style)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 3, style)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 2, style)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 1, style)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 0, style)

            style.FormatCode = ""
            style.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol + 4, style)
        Next y

        'Determinar Tabla
        Dim Inner_Table As SLTable = Xls.CreateTable(tablePosRow, tablePosCol, tablePosRow_now, tablePosCol_now)
        Inner_Table.SetTableStyle(SLTableStyleTypeValues.Dark11)
        Xls.InsertTable(Inner_Table)

        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\HT_Sec_Proc" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        Xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
End Class