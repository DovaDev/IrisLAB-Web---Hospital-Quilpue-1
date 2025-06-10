Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports Datos
Imports Entidades
Public Class N_Prevision_Det
    Dim DD_Gen_Activos As D_Gen_Activos
    Dim DD_Prevision As D_Prevision_Details
    Sub New()
        DD_Gen_Activos = New D_Gen_Activos
        DD_Prevision = New D_Prevision_Details
    End Sub
    Function IRIS_WEBF_BUSCA_LIS_ADM_PREVISION(ByVal ID_PRE As Long, ByVal Date_1 As Date, ByVal Date_2 As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_PREVISION)
        Return DD_Prevision.IRIS_WEBF_BUSCA_LIS_ADM_PREVISION(ID_PRE, Date_1, Date_2)
    End Function
    Function Gen_Excel(ByVal MAIN_URL As String, ByVal PREVE As Long, ByVal DATE1 As String, ByVal DATE2 As String) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date_Operat
        Dim NN_Prev As New N_Prevision_Det
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_PREVISION)
        Dim Mx_Data(12, 0) As Object
        'Obtener parámetros para la consulta
        Dim Previs As Long = PREVE
        'Realizar Consulta
        Data_Prev = NN_Prev.IRIS_WEBF_BUSCA_LIS_ADM_PREVISION(Previs, DATE1, DATE2)
        If (Data_Prev.Count = 0) Then
            Return "null"
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(12, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_Prev.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(12, y)
            End If
            Mx_Data(0, y) = y + 1
            Mx_Data(1, y) = Data_Prev(y).ATE_NUM
            Mx_Data(2, y) = Data_Prev(y).PAC_RUT + Data_Prev(y).PAC_DNI
            Mx_Data(3, y) = Data_Prev(y).PAC_NOMBRE + " " + Data_Prev(y).PAC_APELLIDO
            Mx_Data(4, y) = Data_Prev(y).PREVE_DESC
            Mx_Data(5, y) = Format(Data_Prev(y).ATE_FECHA, "dd/MM/yyyy")
            Mx_Data(6, y) = Data_Prev(y).PROC_DESC
            Mx_Data(7, y) = Data_Prev(y).CF_COD
            Mx_Data(8, y) = Data_Prev(y).CF_DESC
            Mx_Data(9, y) = CInt(Data_Prev(y).ATE_DET_V_PREVI)
            Mx_Data(10, y) = CInt(Data_Prev(y).ATE_DET_V_PAGADO)
            Mx_Data(11, y) = CInt(Data_Prev(y).ATE_DET_V_COPAGO)
            Mx_Data(12, y) = CInt(Data_Prev(y).ATE_DET_V_PAGADO + Data_Prev(y).ATE_DET_V_COPAGO)
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
        Dim formatonum As SLStyle
        'Dim formatoporce As SLStyle
        Dim stTotal As SLStyle
        'Dim grafico As SLChart
        'estilo Títulos
        estilo = sl.CreateStyle()
        estilo.Font.FontName = "Arial"
        estilo.Font.FontSize = 20
        estilo.Font.Bold = True
        'Estilo tiutlos, más pequeño
        estilo2 = sl.CreateStyle()
        estilo2.Font.FontName = "Arial"
        estilo2.Font.FontSize = 16
        estilo2.Font.Bold = True
        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Gestion Financiero")
        'titulo de la tabla
        sl.SetCellStyle("B1", estilo)
        sl.SetCellValue("B1", "Detalle de Previsión: ")
        sl.SetCellStyle("D1", estilo)
        sl.SetCellValue("D1", Data_Prev(0).PREVE_DESC)

        'nombre columnas
        sl.SetCellValue("A7", " ")
        sl.SetCellValue("B7", "Nº de Atención")
        sl.SetCellValue("C7", "RUT/DNI")
        sl.SetCellValue("D7", "Nombre")
        sl.SetCellValue("E7", "Previsión")
        sl.SetCellValue("F7", "Fecha")
        sl.SetCellValue("G7", "Lugar de TM")
        sl.SetCellValue("H7", "Código")
        sl.SetCellValue("I7", "Descripción")
        sl.SetCellValue("J7", "Valor sistema")
        sl.SetCellValue("K7", "Valor usuario")
        sl.SetCellValue("L7", "Valor copago")
        sl.SetCellValue("M7", "Valor pagado")
        For y = 1 To 13
            sl.SetColumnWidth(y, 20.0)
        Next y
        For y = 0 To Mx_Data.GetUpperBound(1)
            For x = 0 To Mx_Data.GetUpperBound(0)
                sl.SetCellValue(y + Excel_y, x + 1, Mx_Data(x, y))
            Next x
            ltabla += 1
        Next y
        ltabla += 7
        stTotal = sl.CreateStyle()
        stTotal.Font.FontSize = 12
        stTotal.Font.Bold = True
        stTotal.FormatCode = "###,###,##0"
        'Fechas Desde/Hasta
        sl.SetCellStyle("B3", estilo2)
        sl.SetCellStyle("C3", estilo2)
        sl.SetCellValue("B3", "Desde: ")
        sl.SetCellValue("C3", DATE1)
        sl.SetCellStyle("B5", estilo2)
        sl.SetCellStyle("C5", estilo2)
        sl.SetCellValue("B5", "Hasta: ")
        sl.SetCellValue("C5", DATE2)
        'Anchos de Columnas
        sl.SetColumnWidth("A", 10)
        sl.SetColumnWidth("B", 15)
        sl.SetColumnWidth("D", 40)
        'dar formato numerico
        formatonum = sl.CreateStyle()
        formatonum.FormatCode = "###,###,##0"
        For y = 8 To ltabla + 1
            For i = Asc("J") To Asc("M")
                sl.SetCellStyle(CStr(Chr(i) & y), formatonum)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next y
        'sumar columnas
        For i = Asc("J") To Asc("M")
            sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
            'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        Next i
        'estilo totales
        For i = Asc("J") To Asc("M")
            sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        Next i
        sl.SetCellValue("I" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("M" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\" & Data_Prev(0).PREVE_DESC & " " & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
End Class

