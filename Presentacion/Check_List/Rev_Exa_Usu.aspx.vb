Imports Negocio
Imports Entidades
Imports SpreadsheetLight

Public Class Rev_Exa_Usu
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Exa() As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Prev_Activo As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        'Consultar por previsiones activas
        Data_Prev_Activo = NN_Activos.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS

        Return Data_Prev_Activo
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Usu() As List(Of E_IRIS_WEBF_BUSCA_USUARIO2)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Usuarios As New N_Usuario_Sum
        Dim Data_Usuarios_Resumen As New List(Of E_IRIS_WEBF_BUSCA_USUARIO2)
        'Consultar por previsiones activas
        Data_Usuarios_Resumen = NN_Usuarios.IRIS_WEBF_BUSCA_USUARIO2()

        Return Data_Usuarios_Resumen
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DTT(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_CF As Integer, ByVal ID_USU As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA)
        'Declaraciones del Serializador
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN As New N_IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA
        Dim Data As New List(Of E_IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA)
        'Consultar por previsiones activas
        Data = NN.IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA(DESDE, HASTA, ID_CF, ID_USU)

        Return Data
    End Function
    <Services.WebMethod()>
    Public Shared Function Gen_Excel(ByVal MAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_CF As Integer, ByVal ID_USU As Integer) As String
        'Declaraciones Generales
        Dim NN As New N_IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA
        Dim Data As New List(Of E_IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA)
        Dim Mx_Data(10, 0) As Object
        'Obtener parámetros para la consulta
        'Realizar Consulta
        Data = NN.IRIS_WEBF_BUSCA_EST_EXA_USU_VALIDA(DESDE, HASTA, ID_CF, ID_USU)
        If (Data.Count = 0) Then
            Return "null"
            Exit Function
        End If
        'Vaciar Matriz
        ReDim Mx_Data(10, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        Dim cont As Integer = 0


        For y = 0 To (Data.Count - 1)


            If (cont > 0) Then
                ReDim Preserve Mx_Data(10, cont)
            End If

            Mx_Data(0, cont) = cont + 1
            Mx_Data(1, cont) = Data(y).Folio
            Mx_Data(2, cont) = Data(y).Fecha_Ingreso
            Mx_Data(3, cont) = Data(y).Hora_Ingreso
            Mx_Data(4, cont) = Data(y).Rut
            Mx_Data(5, cont) = Data(y).Nombre_Pac
            Mx_Data(6, cont) = Data(y).Procedencia
            Mx_Data(7, cont) = Data(y).Examen
            Mx_Data(8, cont) = Data(y).Fecha_Valida
            Mx_Data(9, cont) = Data(y).Hora_Valida
            Mx_Data(10, cont) = Data(y).Usuario_Valida

            cont += 1

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
        sl.RenameWorksheet("Sheet1", "REFV")
        'titulo de la tabla
        sl.SetCellStyle("B1", estilo)
        sl.SetCellValue("B1", "Revisión Exámenes por Fecha Validación")

        'nombre columnas
        sl.SetCellValue("A7", "#")
        sl.SetCellValue("B7", "Folio")
        sl.SetCellValue("C7", "Fecha Ingreso")
        sl.SetCellValue("D7", "Hora Ingreso")
        sl.SetCellValue("E7", "RUT")
        sl.SetCellValue("F7", "Nombre Pac")
        sl.SetCellValue("G7", "Procedencia")
        sl.SetCellValue("H7", "Examen")
        sl.SetCellValue("I7", "Fecha Validación")
        sl.SetCellValue("J7", "Hora Validación")
        sl.SetCellValue("K7", "Profesional")
        For y = 1 To 10
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
        sl.SetColumnWidth("D", 15)
        sl.SetColumnWidth("H", 15)
        sl.SetColumnWidth("I", 15)
        sl.SetColumnWidth("F", 40)
        sl.SetColumnWidth("G", 30)
        sl.SetColumnWidth("H", 40)
        sl.SetColumnWidth("K", 40)
        'dar formato numerico
        'formatonum = sl.CreateStyle()
        'formatonum.FormatCode = "###,###,##0"
        'For y = 8 To ltabla + 1
        '    For i = Asc("H") To Asc("H")
        '        sl.SetCellStyle(CStr(Chr(i) & y), formatonum)
        '        'sl.SetCellStyle(CStr("E" & y), formatonum)
        '    Next i
        'Next y
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
        tabla = sl.CreateTable("A7", CStr("K" & ltabla))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\REFV_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function

End Class