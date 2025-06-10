Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class Lis_Env_Mues_Lab
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
    Public Shared Function Llenar_Ddl_Exam() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        Dim Data_Exam As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)

        Data_Exam = NN_Exam.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS()
        If (Data_Exam.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Exam, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal TIPO As Integer, ByVal DESDE As String, ByVal HASTA As String,
                                            ByVal ID_PRE As Integer,
                                            ByVal ID_CF As Integer) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""

        'Declaraciones internas
        Dim data_det_ate As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO)
        Dim NN_Det_Ate As N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO = New N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO

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

        data_det_ate = NN_Det_Ate.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO_NORMAL(TIPO, DESDE, HASTA, ID_PRE, ID_CF)

        If (data_det_ate.Count > 0) Then
            edad = 0

            Dim Mx_Datax(8, 0) As Object
            'Llenar Matriz
            For y = 0 To (data_det_ate.Count - 1)

                If (y > 0) Then
                    ReDim Preserve Mx_Data(8, y)
                End If

                Mx_Data(0, y) = y + 1

                'If y > 0 Then

                'Else
                Mx_Data(0, y) = CInt(data_det_ate(y).ATE_NUM)
                Mx_Data(1, y) = data_det_ate(y).ATE_NUM_INTERNO
                Mx_Data(2, y) = data_det_ate(y).PAC_NOMBRE + " " + data_det_ate(y).PAC_APELLIDO
                Mx_Data(3, y) = Calcular_Edad(CDate(data_det_ate(y).PAC_FNAC)) & " " & "Años"
                Mx_Data(4, y) = Format(data_det_ate(y).ATE_FECHA, "dd/MM/yyyy")
                Mx_Data(5, y) = Format(data_det_ate(y).ATE_FECHA, "hh:mm:ss")
                Mx_Data(6, y) = data_det_ate(y).PROC_DESC

                ' End If

                Mx_Data(7, y) = data_det_ate(y).CF_DESC
                Mx_Data(8, y) = data_det_ate(y).EST_DESCRIPCION
            Next y
        Else
            Return "null"
        End If

        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Listado de Envío de Exámenes")

        'titulo de la tabla
        sl.SetCellValue("B2", "Listado de Envío de Exámenes")

        For y = 1 To 9
            sl.SetColumnWidth(y, 20.0)
        Next y

        'nombre columnas
        sl.SetCellValue("A8", "N° Atención")
        sl.SetCellValue("B8", "N° Interno")
        sl.SetCellValue("C8", "Nombre Paciente")
        sl.SetColumnWidth("C", 40)
        sl.SetCellValue("D8", "Edad")
        sl.SetCellValue("E8", "Fecha")
        sl.SetCellValue("F8", "Hora")
        sl.SetCellValue("G8", "Lugar de TM")
        sl.SetCellValue("H8", "Examen")
        sl.SetColumnWidth("H", 40)
        sl.SetCellValue("I8", "Estado")

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

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal TIPO As Integer, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_PRE As Integer, ByVal ID_CF As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO)

        'Declaraciones internas

        Dim data_det_ate As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO)
        Dim NN_Det_Ate As N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO = New N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO

        data_det_ate = NN_Det_Ate.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO_NORMAL(TIPO, DESDE, HASTA, ID_PRE, ID_CF)

        Return data_det_ate
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        'If C_P_ADMIN = 0 Then
        '    Response.Redirect("~/Index.aspx")
        'End If
    End Sub
End Class