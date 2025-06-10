Imports Negocio
Imports Entidades
Imports System.Web
Imports SpreadsheetLight

Public Class Cobro_RUT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()>
    Public Shared Function Busca_Data_RUT(ByVal DESDE As String, ByVal HASTA As String, ByVal RUT_DNI As String) As List(Of E_Cobro_RUT)
        'Declaraciones internas
        Dim NN As New N_Cobro_RUT
        Dim Data As New List(Of E_Cobro_RUT)

        Data = NN.IRIS_WEBF_BUSCA_ATENCION_FECHA_RUT_COBRO(DESDE, HASTA, RUT_DNI)
        Return Data
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal MAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal RUT_DNI As String) As String
        'Declaraciones Generales
        Dim NN As New N_Cobro_RUT
        Dim Data As New List(Of E_Cobro_RUT)
        Dim Mx_Data(7, 0) As Object
        'Obtener parámetros para la consulta
        'Realizar Consulta
        Data = NN.IRIS_WEBF_BUSCA_ATENCION_FECHA_RUT_COBRO(DESDE, HASTA, RUT_DNI)
        If (Data.Count = 0) Then
            Return "null"
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(7, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        Dim cont As Integer = 0

        Dim tot_Val As Integer = 0

        For y = 0 To (Data.Count - 1)
            For yy = 0 To (Data(y).EXAMENES.Count - 1)

                If (cont > 0) Then
                    ReDim Preserve Mx_Data(7, cont)
                End If

                Mx_Data(0, cont) = cont + 1
                Mx_Data(1, cont) = Data(y).FOLIO
                Mx_Data(2, cont) = Format(Data(y).FECHA, "dd/MM/yyyy")
                Mx_Data(3, cont) = Data(y).PROCEDENCIA
                Mx_Data(4, cont) = Data(y).PREVISION
                Mx_Data(5, cont) = Data(y).EXAMENES(yy).CF_COD
                Mx_Data(6, cont) = Data(y).EXAMENES(yy).CF_DESC
                Mx_Data(7, cont) = Data(y).EXAMENES(yy).VALOR

                tot_Val += Data(y).EXAMENES(yy).VALOR
                cont += 1
            Next yy
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

        estilo3 = sl.CreateStyle()
        estilo3.Font.FontName = "Arial"
        estilo3.Font.FontSize = 12
        estilo3.Font.Bold = True
        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "VRUT")
        'titulo de la tabla
        sl.SetCellStyle("B1", estilo)
        sl.SetCellValue("B1", "Valorización RUT")
        sl.SetCellStyle("E1", estilo3)
        sl.SetCellValue("E1", "RUT/DNI: " & Data(0).RUT)

        sl.SetCellStyle("G1", estilo3)
        sl.SetCellValue("G1", "Nombre: " & Data(0).NOMBRE & " " & Data(0).APELLIDO)

        sl.SetCellStyle("E3", estilo3)
        sl.SetCellValue("E3", "Tot. Ate: " & Data.Count)

        sl.SetCellStyle("F3", estilo3)
        sl.SetCellValue("F3", "Tot. Exa: " & cont)

        sl.SetCellStyle("G3", estilo3)
        sl.SetCellValue("G3", "Tot. Valor: $" & tot_Val.ToString("###,###,##0").Replace(",", "."))

        'nombre columnas
        sl.SetCellValue("A7", "#")
        sl.SetCellValue("B7", "Folio")
        sl.SetCellValue("C7", "Fecha")
        sl.SetCellValue("D7", "Procedencia")
        sl.SetCellValue("E7", "Previsión")
        sl.SetCellValue("F7", "Código")
        sl.SetCellValue("G7", "Descripción")
        sl.SetCellValue("H7", "Valor")
        For y = 1 To 12
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
        sl.SetCellStyle("B3", estilo3)
        sl.SetCellStyle("C3", estilo3)
        sl.SetCellValue("B3", "Desde: ")
        sl.SetCellValue("C3", DESDE)
        sl.SetCellStyle("B5", estilo3)
        sl.SetCellStyle("C5", estilo3)
        sl.SetCellValue("B5", "Hasta: ")
        sl.SetCellValue("C5", HASTA)
        'Anchos de Columnas
        sl.SetColumnWidth("A", 10)
        sl.SetColumnWidth("B", 15)
        sl.SetColumnWidth("C", 15)
        sl.SetColumnWidth("G", 40)
        'dar formato numerico
        formatonum = sl.CreateStyle()
        formatonum.FormatCode = "###,###,##0"
        For y = 8 To ltabla + 1
            For i = Asc("H") To Asc("H")
                sl.SetCellStyle(CStr(Chr(i) & y), formatonum)
                'sl.SetCellStyle(CStr("E" & y), formatonum)
            Next i
        Next y
        ''sumar columnas
        'For i = Asc("I") To Asc("L")
        '    sl.SetCellValue(CStr(Chr(i) & ltabla + 1), CStr("=SUM(" & Chr(i) & "8:" & Chr(i) & ltabla & ")"))
        '    'sl.SetCellValue(CStr("D" & ltabla + 1), CStr("=SUM(D8:D" & ltabla & ")"))
        'Next i
        ''estilo totales
        'For i = Asc("H") To Asc("L")
        '    sl.SetCellStyle(CStr(Chr(i) & ltabla + 1), stTotal)
        'Next i
        'sl.SetCellValue("H" & ltabla + 1, "Total:")
        'insertar tabla
        tabla = sl.CreateTable("A7", CStr("H" & ltabla))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\crut" & Data(0).RUT.Replace(".", "").Replace("-", "") & "_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
End Class