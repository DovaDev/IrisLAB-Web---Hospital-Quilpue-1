Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports Datos
Imports Entidades
Public Class N_AteResumen_Sum
    Dim DD_Resumen As D_AteResumen_Sum
    Sub New()
        DD_Resumen = New D_AteResumen_Sum
    End Sub
    Function IRIS_WEBF_BUSCA_EST_EXAMENES_RESULTADOS2(ByVal ID_TM As Long, ByVal ID_PREVE As Long, ByVal ID_PRG As Long, ByVal ID_SUB As Long, ByVal Date_01 As Date, _
                                                                      ByVal Date_02 As Date) As List(Of E_IRIS_WEBF_BUSCA_EST_EXAMENES_RESULTADOS2)
        Return DD_Resumen.IRIS_WEBF_BUSCA_EST_EXAMENES_RESULTADOS2(ID_TM, ID_PREVE, ID_PRG, ID_SUB, Date_01, Date_02)
    End Function
    Function Gen_Excel(ByVal MAIN_URL As String, ByVal ID_TM As Long, ByVal ID_PREVE As Long, ByVal ID_PRG As Long, ByVal ID_SUB As Long, ByVal Date_01 As Date, _
                                                                    ByVal Date_02 As Date) As String
        'Declaraciones Generales
        Dim NN_Date As New N_Date_Operat
        Dim NN_Prev As New D_AteResumen_Sum
        Dim Data_TM_Prevision As New List(Of E_IRIS_WEBF_BUSCA_EST_EXAMENES_RESULTADOS2)
        Dim Mx_Data(14, 0) As Object

        'Realizar Consulta
        Data_TM_Prevision = NN_Prev.IRIS_WEBF_BUSCA_EST_EXAMENES_RESULTADOS2(ID_TM, ID_PREVE, ID_PRG, ID_SUB, Date_01, Date_02)
        If (Data_TM_Prevision.Count = 0) Then
            Return "null"
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(14, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        Dim n As Integer
        'Llenar Matriz
        For y = 0 To (Data_TM_Prevision.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(14, y)
            End If
            n = y + 1
            Mx_Data(0, y) = n
            Mx_Data(1, y) = Data_TM_Prevision(y).ATE_NUM
            Mx_Data(2, y) = Data_TM_Prevision(y).PAC_NOMBRE & " " & Data_TM_Prevision(y).PAC_APELLIDO
            Mx_Data(3, y) = Data_TM_Prevision(y).CF_DESC & "-" & Data_TM_Prevision(y).PRU_DESC
            If (Data_TM_Prevision(y).TP_RESUL_COD = "A") Then
                Mx_Data(4, y) = Data_TM_Prevision(y).ATE_RESULTADO & ".-"
            Else
                Mx_Data(4, y) = Data_TM_Prevision(y).ATE_RESULTADO_NUM & ".-"
            End If
            Mx_Data(5, y) = Data_TM_Prevision(y).UM_DESC
            Mx_Data(6, y) = Data_TM_Prevision(y).PREVE_DESC
            Mx_Data(7, y) = Data_TM_Prevision(y).PROC_DESC
            Mx_Data(8, y) = Data_TM_Prevision(y).PROGRA_DESC
            Mx_Data(9, y) = Data_TM_Prevision(y).PAC_RUT
            Mx_Data(10, y) = Format(CDate(Data_TM_Prevision(y).ATE_FECHA), "dd/MM/yyyy")
            Mx_Data(11, y) = "-/-"
            Mx_Data(12, y) = Data_TM_Prevision(y).ATE_OMI
            Mx_Data(13, y) = Data_TM_Prevision(y).SEXO_DESC
            Mx_Data(14, y) = Data_TM_Prevision(y).ATE_AÑO
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
        'Dim stTotal As SLStyle
        'Dim grafico As SLChart
        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Listado de Resultados por Determinaciones")
        'titulo de la tabla
        sl.SetCellValue("B2", "Listado de Resultados por Determinaciones")
        sl.SetCellValue("B4", "Desde: " & Date_01 & " Hasta: " & Date_02 & Data_TM_Prevision(0).PROC_DESC & " " & Data_TM_Prevision(0).PREVE_DESC & " " & Data_TM_Prevision(0).PROGRA_DESC)
        'nombre columnas
        sl.SetCellValue("A7", "N°")
        sl.SetColumnWidth(1, 10.0)
        sl.SetCellValue("B7", "N° Atenciones")
        sl.SetColumnWidth(2, 10.0)
        sl.SetCellValue("C7", "Nombre Paciente")
        sl.SetColumnWidth(3, 40.0)
        sl.SetCellValue("D7", "Determinacion")
        sl.SetColumnWidth(4, 71.0)
        sl.SetCellValue("E7", "Resultado")
        sl.SetColumnWidth(5, 50.0)
        sl.SetCellValue("F7", "Unidad")
        sl.SetColumnWidth(6, 20.0)
        sl.SetCellValue("G7", "Previsión")
        sl.SetColumnWidth(7, 20.0)
        sl.SetCellValue("H7", "Lugar TM")
        sl.SetColumnWidth(8, 20.0)
        sl.SetCellValue("I7", "Programa")
        sl.SetColumnWidth(9, 20.0)
        sl.SetCellValue("J7", "Rut")
        sl.SetColumnWidth(10, 20.0)
        sl.SetCellValue("K7", "Fecha Atención")
        sl.SetColumnWidth(11, 20.0)
        sl.SetCellValue("L7", "Sub Programa")
        sl.SetColumnWidth(12, 20.0)
        sl.SetCellValue("M7", "OC")
        sl.SetColumnWidth(13, 10.0)
        sl.SetCellValue("N7", "Sexo")
        sl.SetColumnWidth(14, 10.0)
        sl.SetCellValue("O7", "Edad")
        sl.SetColumnWidth(15, 10.0)

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
        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("B3", estilo2)
        sl.SetCellStyle("B4", estilo3)
        'dar formato numerico
        'formatonum = sl.CreateStyle()
        'formatonum.FormatCode = "###,###,##0"
        'For y = 8 To ltabla + 1
        '    For i = Asc("E") To Asc("E")
        '        sl.SetCellStyle(CStr(Chr(i) & y), formatonum)
        '        'sl.SetCellStyle(CStr("E" & y), formatonum)
        '    Next i
        'Next y
        ''sumar columnas
        'For i = Asc("B") To Asc("G")
        '    sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
        '    'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        'Next i
        ''estilo totales
        'For i = Asc("A") To Asc("G")
        '    sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        'Next i
        'sl.SetCellValue("A" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("O" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        'If (Previs = 0) Then
        '    Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        '    Dim Relative_Path As String = "IRISPDFDERIVADOS\Todas" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        '    sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        '    'Devolver la url del archivo generado
        '    Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Reds_Filtr" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
End Class
