Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports Entidades
Imports Datos
Public Class N_REP_LAB_SEC
    'Declaraciones Generales
    Dim DD_Data As D_REP_LAB_SEC
    Sub New()
        DD_Data = New D_REP_LAB_SEC
    End Sub
    Function IRIS_WEBF_CMVM_BUSCA_EST_SECCIONES_POR_ID_DERIVA(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_REL As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_SECCIONES_TODOS)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_EST_SECCIONES_POR_ID_DERIVA(DESDE, HASTA, ID_REL)
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_EST_SECCIONES_TODOS_DERIVA(ByVal DESDE As String, ByVal HASTA As String) As List(Of E_IRIS_WEBF_BUSCA_EST_SECCIONES_TODOS)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_EST_SECCIONES_TODOS_DERIVA(DESDE, HASTA)
    End Function
    Function IRIS_WEBF_BUSCA_EST_SECCIONES_TODOS(ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_EST_SECCIONES_TODOS)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_SECCIONES_TODOS(DESDE, HASTA)
    End Function
    Function IRIS_WEBF_BUSCA_EST_SECCIONES_POR_ID(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_REL As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_SECCIONES_TODOS)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_SECCIONES_POR_ID(DESDE, HASTA, ID_REL)
    End Function
    Function Gen_Excel(ByVal MAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_CF As Integer) As String
        'Declaraciones Generales
        Dim datos As String = ""
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Exam As New N_REP_LAB_SEC
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_EST_SECCIONES_TODOS)
        Dim Mx_Data(7, 0) As Object
        'Obtener fechas de la URL para luego transformarlas
        DESDE = DESDE.Replace("-", "a")
        HASTA = HASTA.Replace("-", "a")
        Dim Str_d1() As String = Split(DESDE, "a")
        Dim Str_d2() As String = Split(HASTA, "a")

        Dim Date01 As Date = NN_Date.strToDate(Str_d1(2), Str_d1(1), Str_d1(0))
        Dim Date02 As Date = NN_Date.strToDate(Str_d2(2), Str_d2(1), Str_d2(0))
        If (ID_CF = 0) Then
            Data_Prev = NN_Exam.IRIS_WEBF_BUSCA_EST_SECCIONES_TODOS(Date01, Date02)
        Else
            Data_Prev = NN_Exam.IRIS_WEBF_BUSCA_EST_SECCIONES_POR_ID(Date01, Date02, ID_CF)
        End If
        'Vaciar Matriz
        ReDim Mx_Data(7, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_Prev.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(7, y)
            End If
            Mx_Data(0, y) = Data_Prev(y).ATE_NUM
            Mx_Data(1, y) = Data_Prev(y).PAC_NOMBRE & "" & Data_Prev(y).PAC_APELLIDO
            Mx_Data(2, y) = Data_Prev(y).ATE_AÑO
            Mx_Data(3, y) = Format(CDate(Data_Prev(y).ATE_FECHA), "dd/MM/yyyy")
            Mx_Data(4, y) = Format(CDate(Data_Prev(y).ATE_FECHA), "HH:mm:ss")
            Mx_Data(5, y) = Data_Prev(y).RLS_LS_DESC
            Mx_Data(6, y) = Data_Prev(y).SEXO_DESC
            Mx_Data(7, y) = Data_Prev(y).CF_DESC
        Next y
        Dim Excel_x As Integer
        Dim Excel_y As Integer
        Excel_x = 1
        Excel_y = 8
        Dim ltabla As Integer = 0
        'creamos el objeto SLDocument el cual creara el excel
        Dim sl As SLDocument = New SLDocument
        Dim tabla As SLTable
        'Dim tabla2 As SLTable
        Dim estilo As SLStyle
        Dim estilo2 As SLStyle
        Dim estilo3 As SLStyle
        'Dim formatonum As SLStyle
        'Dim formatoporce As SLStyle
        Dim stTotal As SLStyle
        'Dim grafico As SLChart
        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Busqueda de Atenciones por Secciones")
        'titulo de la tabla
        sl.SetCellValue("B2", "Busqueda de Atenciones por Secciones")
        sl.SetCellValue("B4", "Desde: " & Date01 & " Hasta: " & Date02)
        'nombre columnas
        sl.SetCellValue("A7", "N° Atención")
        sl.SetCellValue("B7", "Nombre Paciente")
        sl.SetCellValue("C7", "Edad")
        sl.SetCellValue("D7", "Fecha")
        sl.SetCellValue("E7", "Hora")
        sl.SetCellValue("F7", "Seccion")
        sl.SetCellValue("G7", "Sexo")
        sl.SetCellValue("H7", "Exámen")
        sl.SetColumnWidth(8, 55.0)
        For y = 1 To 7
            sl.SetColumnWidth(y, 20.0)
        Next y
        For y = 0 To Mx_Data.GetUpperBound(1)
            For x = 0 To Mx_Data.GetUpperBound(0)
                sl.SetCellValue(y + Excel_y, x + 1, Mx_Data(x, y))
            Next x
            ltabla += 1
        Next y
        ltabla += 7

        estilo = sl.CreateStyle()
        estilo.Font.FontName = "Arial"
        estilo.Font.FontSize = 20
        estilo.Font.Bold = True
        estilo2 = sl.CreateStyle()
        estilo2.Font.FontName = "Arial"
        estilo2.Font.FontSize = 14
        estilo2.Font.Bold = True

        estilo3 = sl.CreateStyle()
        estilo3.Font.FontName = "Arial"
        estilo3.Font.FontSize = 13
        estilo3.Font.Bold = True

        stTotal = sl.CreateStyle()
        stTotal.Font.FontSize = 12
        stTotal.Font.Bold = True
        stTotal.FormatCode = "###,###,##0"
        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("B3", estilo2)
        sl.SetCellStyle("B4", estilo3)


        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("H" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String
        Relative_Path = "IRISPDFDERIVADOS\" & Data_Prev(0).RLS_LS_DESC & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
End Class