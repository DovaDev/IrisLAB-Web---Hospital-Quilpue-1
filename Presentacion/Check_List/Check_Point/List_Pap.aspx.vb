Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class List_Pap
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_TM As Integer, ByVal ID_CF As Integer) As String

        'Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        Dim N_ECrypt As New N_Encrypt
        'Declaraciones internas
        Dim data As List(Of E_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO)
        Dim NN As N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO = New N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO

        data = NN.IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO(DESDE, HASTA, ID_TM, ID_CF)

        If data.Count > 0 Then
            For i = 0 To (data.Count - 1)
                data(i).ID_FCL = N_ECrypt.Encode(data(i).ID_ATENCION)
            Next i

            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_TM As Integer, ByVal ID_CF As Integer) As String

        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""
        'Declaraciones internas
        Dim data As List(Of E_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO)
        Dim NN As N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO = New N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO

        data = NN.IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO(DESDE, HASTA, ID_TM, ID_CF)
        'creamos el objeto SLDocument el cual creara el excel
        Dim sl As SLDocument = New SLDocument
        Dim tabla As SLTable
        Dim estilo As SLStyle
        Dim estilo2 As SLStyle
        Dim estilo3 As SLStyle
        Dim Excel_x As Integer
        Dim Excel_y As Integer
        Excel_x = 1
        Excel_y = 9
        Dim ltabla As Integer = 0
        Dim Mx_Data(13, 0) As Object
        If (data.Count > 0) Then
            Dim Mx_Datac(13, 0) As Object
            'Vaciar Matriz
            ReDim Mx_Data(13, 0)
            For x = 0 To (Mx_Data.GetUpperBound(0))
                Mx_Data(x, 0) = Nothing
            Next x
            'Llenar Matriz
            For y = 0 To (data.Count - 1)
                If (y > 0) Then
                    ReDim Preserve Mx_Data(13, y)
                End If
                Mx_Data(0, y) = y + 1
                Mx_Data(1, y) = CInt(data(y).ID_ATENCION)
                Mx_Data(2, y) = data(y).ATE_FECHA
                Mx_Data(3, y) = data(y).PROC_DESC
                Mx_Data(4, y) = data(y).ATE_NUM_INTERNO
                Mx_Data(5, y) = data(y).PAC_NOMBRE + " " + data(y).PAC_APELLIDO
                Mx_Data(6, y) = Format(CDate(data(y).PAC_FNAC), "dd/MM/yyyy")
                Mx_Data(7, y) = data(y).ATE_AÑO
                If (data(y).PAC_RUT = "") Then
                    Mx_Data(8, y) = data(y).PAC_DNI
                Else
                    Mx_Data(8, y) = data(y).PAC_RUT
                End If
                Mx_Data(9, y) = data(y).CF_DESC
                Mx_Data(10, y) = data(y).NAC_DESC
                Mx_Data(11, y) = data(y).PROGRA_DESC
                Mx_Data(12, y) = data(y).SECTOR_DESC
                Mx_Data(13, y) = data(y).DOC_NOMBRE + " " + data(y).DOC_APELLIDO
            Next y
        Else
            Return "null"
        End If
        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Cantidad de Exámenes por Paciente")
        'titulo de la tabla
        sl.SetCellValue("B2", "Cantidad de Exámenes por Paciente")
        For y = 1 To 9
            sl.SetColumnWidth(y, 20.0)
        Next y
        'nombre columnas
        sl.SetCellValue("A8", "#")
        sl.SetCellValue("B8", "N° Atención")
        sl.SetCellValue("C8", "Fecha Ingreso")
        'sl.SetColumnWidth("D", 40)
        sl.SetCellValue("D8", "Lugar TM")
        sl.SetCellValue("E8", "Num Interno")
        sl.SetCellValue("F8", "Nombre Paciente")
        sl.SetCellValue("G8", "Fecha Nac")
        sl.SetCellValue("H8", "Edad")
        sl.SetCellValue("I8", "Rut o D.N.I")
        sl.SetCellValue("J8", "Examen")
        sl.SetCellValue("K8", "Nacionalidad")
        sl.SetCellValue("L8", "Programa")
        sl.SetCellValue("M8", "Sector")
        sl.SetCellValue("N8", "Doctor")

        For y = 1 To 9
            sl.SetColumnWidth(y, 20.0)
        Next y
        For y = 0 To Mx_Data.GetUpperBound(1)
            For x = 0 To Mx_Data.GetUpperBound(0)
                sl.SetCellValue(y + Excel_y, x + 1, Mx_Data(x, y))
            Next x
            ltabla += 1
        Next y
        ltabla += 8
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
        'insertar tabla
        tabla = sl.CreateTable("A8", CStr("N" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
End Class