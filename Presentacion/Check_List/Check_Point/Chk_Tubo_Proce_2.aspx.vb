Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class Chk_Tubo_Proce_2
    Inherits System.Web.UI.Page

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
    Public Shared Function Llenar_Ddl_Seccion() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Seccion As New N_IRIS_WEBF_BUSCA_TIPOS_DE_MUESTRA_CON_COD_BARRA
        Dim Data_Seccion As New List(Of E_IRIS_WEBF_BUSCA_TIPOS_DE_MUESTRA_CON_COD_BARRA)

        Data_Seccion = NN_Seccion.IRIS_WEBF_BUSCA_TIPOS_DE_MUESTRA_CON_COD_BARRA()
        If (Data_Seccion.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Seccion, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal DESDE As String, ByVal HASTA As String,
                                            ByVal ID_PRE As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS
        Dim Data As New List(Of E_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS)

        Data = NN.IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS_3(CDate(DESDE), CDate(HASTA), ID_PRE)

        If (Data.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If

    End Function
    '<Services.WebMethod()>
    'Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String,
    '                                        ByVal ID_PRE As Integer) As String
    '    'Declaraciones del Serializador
    '    'Dim Serializer As New JavaScriptSerializer
    '    Dim str_Builder As New StringBuilder
    '    Dim datas As String = ""
    '    Dim Str_Out As String = ""

    '    'Declaraciones internas
    '    Dim NN As New N_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS
    '    Dim Data_Datos_Pac As New List(Of E_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS)

    '    'creamos el objeto SLDocument el cual creara el excel
    '    Dim sl As SLDocument = New SLDocument
    '    Dim tabla As SLTable
    '    Dim estilo As SLStyle
    '    Dim estilo2 As SLStyle
    '    Dim estilo3 As SLStyle
    '    Dim Excel_x As Integer
    '    Dim Excel_y As Integer
    '    Excel_x = 1
    '    Excel_y = 9
    '    Dim ltabla As Integer = 0

    '    Dim Mx_Data(9, 0) As Object

    '    Dim ID_SECC = 0

    '    Data_Datos_Pac = NN.IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS_3(CDate(DESDE), CDate(HASTA), ID_PRE)

    '    If (Data_Datos_Pac.Count > 0) Then

    '        'Vaciar Matriz
    '        ReDim Mx_Data(9, 0)
    '        For x = 0 To (Mx_Data.GetUpperBound(0))
    '            Mx_Data(x, 0) = Nothing
    '        Next x
    '        'Llenar Matriz
    '        For y = 0 To (Data_Datos_Pac.Count - 1)

    '            If (y > 0) Then
    '                ReDim Preserve Mx_Data(9, y)
    '            End If

    '            Mx_Data(0, y) = y + 1
    '            Mx_Data(1, y) = CInt(Data_Datos_Pac(y).ATE_NUM)
    '            Mx_Data(2, y) = Data_Datos_Pac(y).ATE_NUM_INTERNO
    '            Mx_Data(3, y) = Format(Data_Datos_Pac(y).ATE_FECHA, "dd/MM/yyyy")
    '            Mx_Data(4, y) = Data_Datos_Pac(y).CB_DESC
    '            Mx_Data(5, y) = Data_Datos_Pac(y).T_MUESTRA_DESC
    '            Mx_Data(6, y) = Data_Datos_Pac(y).GMUE_DESC
    '            Mx_Data(7, y) = Data_Datos_Pac(y).PAC_RUT
    '            Mx_Data(8, y) = Data_Datos_Pac(y).PAC_NOMBRE + " " + Data_Datos_Pac(y).PAC_APELLIDO
    '            Mx_Data(9, y) = Data_Datos_Pac(y).PROC_DESC


    '        Next y
    '    Else
    '        Return "null"
    '    End If

    '    'nombrar hoja 
    '    sl.RenameWorksheet("Sheet1", "Listado de Tubos y Procedencia")

    '    'titulo de la tabla
    '    sl.SetCellValue("B2", "Listado de Tubos y Procedencia")
    '    sl.SetCellValue("B4", "Desde: " & DESDE)
    '    sl.SetCellValue("B5", "Hasta: " & HASTA)

    '    For y = 1 To 10
    '        sl.SetColumnWidth(y, 20.0)
    '    Next y

    '    'nombre columnas
    '    sl.SetCellValue("A8", "#")
    '    sl.SetColumnWidth("A", 10)
    '    sl.SetCellValue("B8", "N° Atención")
    '    sl.SetCellValue("C8", "Num Interno")
    '    sl.SetColumnWidth("C", 15)
    '    sl.SetCellValue("D8", "Fecha")
    '    sl.SetCellValue("E8", "N° Barra")
    '    sl.SetColumnWidth("E", 10)
    '    sl.SetCellValue("F8", "Tipo de Muestra")
    '    sl.SetCellValue("G8", "Color Tubo")
    '    sl.SetCellValue("H8", "Rut")
    '    sl.SetCellValue("I8", "Nombre")
    '    sl.SetColumnWidth("I", 40)
    '    sl.SetCellValue("J8", "Lugar TM")
    '    sl.SetColumnWidth("J", 40)


    '    For y = 0 To Mx_Data.GetUpperBound(1)
    '        For x = 0 To Mx_Data.GetUpperBound(0)

    '            sl.SetCellValue(y + Excel_y, x + 1, Mx_Data(x, y))

    '        Next x
    '        ltabla += 1
    '    Next y
    '    ltabla += 8
    '    estilo = sl.CreateStyle()
    '    estilo.Font.FontName = "Arial"
    '    estilo.Font.FontSize = 20
    '    estilo.Font.Bold = True

    '    estilo2 = sl.CreateStyle()
    '    estilo2.Font.FontName = "Arial"
    '    estilo2.Font.FontSize = 14
    '    estilo2.Font.Bold = True

    '    estilo3 = sl.CreateStyle()
    '    estilo3.Font.FontName = "Arial"
    '    estilo3.Font.FontSize = 13
    '    estilo3.Font.Bold = True

    '    sl.SetCellStyle("B2", estilo)
    '    sl.SetCellStyle("B3", estilo2)
    '    sl.SetCellStyle("B4", estilo3)
    '    sl.SetCellStyle("B5", estilo3)

    '    'insertar tabla
    '    tabla = sl.CreateTable("A8", CStr("J" & ltabla + 1))
    '    tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
    '    sl.InsertTable(tabla)

    '    Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
    '    Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_HH-mm-ss") & ".xlsx"

    '    sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo

    '    'Devolver la url del archivo generado
    '    Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    'End Function
    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_PRE As Integer) As String
        ' Obtener datos desde la fuente
        Dim NN As New N_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS
        Dim Data_Datos_Pac As List(Of E_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS) =
        NN.IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS_3(CDate(DESDE), CDate(HASTA), ID_PRE)

        If Data_Datos_Pac.Count = 0 Then
            Return "null"
        End If

        ' Crear el documento Excel y renombrar la hoja
        Dim sl As New SLDocument()
        sl.RenameWorksheet("Sheet1", "Listado de Tubos y Procedencia")

        ' Establecer títulos y subtítulos
        sl.SetCellValue("B2", "Listado de Tubos y Procedencia")
        sl.SetCellValue("B4", "Desde: " & DESDE)
        sl.SetCellValue("B5", "Hasta: " & HASTA)

        ' Ajustar anchos de las columnas 1 a 10
        For col As Integer = 1 To 10
            sl.SetColumnWidth(col, 20.0)
        Next

        ' Crear un DataTable para almacenar los datos (evita los ReDim y bucles por celda)
        Dim dt As New DataTable()
        dt.Columns.Add("#", GetType(Integer))
        dt.Columns.Add("N° Atención", GetType(String))
        dt.Columns.Add("Num Interno", GetType(String))
        dt.Columns.Add("Fecha", GetType(String))
        dt.Columns.Add("N° Barra", GetType(String))
        dt.Columns.Add("Tipo de Muestra", GetType(String))
        dt.Columns.Add("Color Tubo", GetType(String))
        dt.Columns.Add("Rut", GetType(String))
        dt.Columns.Add("Nombre", GetType(String))
        dt.Columns.Add("Lugar TM", GetType(String))

        Dim i As Integer = 0
        For Each item In Data_Datos_Pac
            dt.Rows.Add(i + 1,
                    CInt(item.ATE_NUM),
                    item.ATE_NUM_INTERNO,
                    Format(item.ATE_FECHA, "dd/MM/yyyy"),
                    item.CB_DESC,
                    item.T_MUESTRA_DESC,
                    item.GMUE_DESC,
                    item.PAC_RUT,
                    item.PAC_NOMBRE & " " & item.PAC_APELLIDO,
                    item.PROC_DESC)
            i += 1
        Next

        ' Importar el DataTable a partir de la celda A8, incluyendo los encabezados
        sl.ImportDataTable("A8", dt, True)

        ' Ajustar nuevamente algunos encabezados y anchos si es necesario
        sl.SetCellValue("A8", "#")
        sl.SetColumnWidth("A", 10)
        sl.SetCellValue("B8", "N° Atención")
        sl.SetCellValue("C8", "Num Interno")
        sl.SetColumnWidth("C", 15)
        sl.SetCellValue("D8", "Fecha")
        sl.SetCellValue("E8", "N° Barra")
        sl.SetColumnWidth("E", 10)
        sl.SetCellValue("F8", "Tipo de Muestra")
        sl.SetCellValue("G8", "Color Tubo")
        sl.SetCellValue("H8", "Rut")
        sl.SetCellValue("I8", "Nombre")
        sl.SetColumnWidth("I", 40)
        sl.SetCellValue("J8", "Lugar TM")
        sl.SetColumnWidth("J", 40)

        ' Calcular la última fila de la tabla (encabezados en A8 y luego los datos)
        Dim lastRow As Integer = 8 + dt.Rows.Count

        ' Crear e insertar la tabla en el rango (desde A8 hasta J última fila)
        Dim tabla As SLTable = sl.CreateTable("A8", "J" & lastRow.ToString())
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        ' Definir estilos para títulos y subtítulos
        Dim estilo As SLStyle = sl.CreateStyle()
        estilo.Font.FontName = "Arial"
        estilo.Font.FontSize = 20
        estilo.Font.Bold = True

        Dim estilo2 As SLStyle = sl.CreateStyle()
        estilo2.Font.FontName = "Arial"
        estilo2.Font.FontSize = 14
        estilo2.Font.Bold = True

        Dim estilo3 As SLStyle = sl.CreateStyle()
        estilo3.Font.FontName = "Arial"
        estilo3.Font.FontSize = 13
        estilo3.Font.Bold = True

        sl.SetCellStyle("B2", estilo)
        sl.SetCellStyle("B3", estilo2)
        sl.SetCellStyle("B4", estilo3)
        sl.SetCellStyle("B5", estilo3)

        ' Guardar el archivo y devolver la URL
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_HH-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path)

        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function

    Public Shared Function Calcular_Edad(Fecha_Nacimiento As Date) As Integer
        Dim Años As Object
        ' comprueba si el valor no es nulo  

        Años = DateDiff("yyyy", Fecha_Nacimiento, Now)

        If Date.Now < DateSerial(Year(Now), Month(Fecha_Nacimiento),
                           Day(Fecha_Nacimiento)) Then
            Años = Años - 1
        End If

        Calcular_Edad = CInt(Años)
    End Function

    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If

        Select Case (C_P_ADMIN.Value)
            Case Is <> 1
                Response.Redirect("~/Index.aspx")
        End Select
    End Sub

End Class