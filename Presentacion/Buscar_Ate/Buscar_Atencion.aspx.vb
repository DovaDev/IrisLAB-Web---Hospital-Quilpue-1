Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts

Public Class Buscar_Atencion
    Inherits System.Web.UI.Page

    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub

    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_LugarTM() As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        'Declaraciones internas
        Dim objN As New N_Gen_Activos
        Dim objL As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)

        objL = objN.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO_BY_ID_PREV
        Return objL
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal FECHA1 As String, ByVal FECHA2 As String, ByVal LUGARTM As String) As List(Of E_IRIS_WEBF_BUSCA_ATENCION_PACIENTE_FECHA)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_BuscarAtencion As New N_IRIS_WEBF_BUSCA_ATENCION_PACIENTE_FECHA
        Dim Data_BuscarAtencion As New List(Of E_IRIS_WEBF_BUSCA_ATENCION_PACIENTE_FECHA)

        Data_BuscarAtencion = NN_BuscarAtencion.IRIS_WEBF_BUSCA_ATENCION_PACIENTE_FECHA(FECHA1, FECHA2, LUGARTM)
        Return Data_BuscarAtencion
    End Function

    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal FECHA1 As String, ByVal FECHA2 As String, ByVal LUGARTM As String) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""

        'Declaraciones internas
        Dim NN_Det_Ate As New N_IRIS_WEBF_BUSCA_ATENCION_PACIENTE_FECHA
        Dim data_det_ate As New List(Of E_IRIS_WEBF_BUSCA_ATENCION_PACIENTE_FECHA)

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
        Dim edad As Integer = 0
        Dim idate As String = ""


        Dim Mx_Data(8, 0) As Object

        data_det_ate = NN_Det_Ate.IRIS_WEBF_BUSCA_ATENCION_PACIENTE_FECHA(FECHA1, FECHA2, LUGARTM)

        If (data_det_ate.Count > 0) Then
            edad = 0

            Dim Mx_Datax(8, 0) As Object
            'Llenar Matriz
            For y = 0 To (data_det_ate.Count - 1)

                If (y > 0) Then
                    ReDim Preserve Mx_Data(8, y)
                End If

                Mx_Data(0, y) = y + 1
                Mx_Data(1, y) = CInt(data_det_ate(y).ATE_NUM)
                Mx_Data(2, y) = Format(data_det_ate(y).ATE_FECHA, "dd/MM/yyyy hh:mm:ss")
                Mx_Data(3, y) = data_det_ate(y).PAC_RUT
                Mx_Data(4, y) = data_det_ate(y).PAC_NOMBRE & " " & data_det_ate(y).PAC_APELLIDO
                Mx_Data(5, y) = data_det_ate(y).ATE_AÑO & " " & "Años"
                Mx_Data(6, y) = data_det_ate(y).SEXO_DESC
                Mx_Data(7, y) = data_det_ate(y).PROC_DESC
                Mx_Data(8, y) = data_det_ate(y).DOC_NOMBRE & " " & data_det_ate(y).DOC_APELLIDO
            Next y
        Else
            Return "null"
        End If

        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Listado de Atenciones")

        'titulo de la tabla
        sl.SetCellValue("B2", "Listado de Atenciones")

        If LUGARTM = "0" Then
            sl.SetCellValue("B4", "PROCEDENCIA : TODAS")
        Else
            sl.SetCellValue("B4", "PROCEDENCIA :" & data_det_ate(0).PROC_DESC)
        End If


        sl.SetCellValue("B6", "DESDE: " & FECHA1)
        sl.SetCellValue("D6", "HASTA: " & FECHA2)

        For y = 1 To 9
            sl.SetColumnWidth(y, 20.0)
        Next y

        'nombre columnas
        sl.SetCellValue("A8", "#")
        sl.SetColumnWidth("A", 10)
        sl.SetCellValue("B8", "N° Atención")
        sl.SetCellValue("C8", "Fecha Atención")
        sl.SetCellValue("D8", "RUT/DNI")
        sl.SetCellValue("E8", "Nombre Paciente")
        sl.SetColumnWidth("E", 40)
        sl.SetCellValue("F8", "Edad")
        sl.SetCellValue("G8", "Sexo")
        sl.SetCellValue("H8", "Procedencia")
        sl.SetColumnWidth("H", 30)
        sl.SetCellValue("I8", "Nombre Doctor")
        sl.SetColumnWidth("I", 40)

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
        tabla = sl.CreateTable("A8", CStr("I" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"

        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo

        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
End Class