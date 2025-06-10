Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class Lis_Agen
    Inherits System.Web.UI.Page

    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If

        Select Case (C_P_ADMIN.Value)
            Case 2
                Response.Redirect("~/Index.aspx")
        End Select
    End Sub

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
    Public Shared Function Llenar_DataTable(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_PRE As Integer) As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EST_LUGAR_TM_TODOS_2)

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

        'Declaraciones internas
        Dim data_det_ate As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EST_LUGAR_TM_TODOS_2)
        Dim NN_Det_Ate As N_IRIS_WEBF_AGENDA_BUSCA_EST_LUGAR_TM_TODOS_2 = New N_IRIS_WEBF_AGENDA_BUSCA_EST_LUGAR_TM_TODOS_2
        Dim caca As Integer = 0

        If ID_PRE = 0 Then

            data_det_ate = NN_Det_Ate.IRIS_WEBF_AGENDA_BUSCA_EST_LUGAR_TM_TODOS_2(DESDE, HASTA)
        Else
            data_det_ate = NN_Det_Ate.IRIS_WEBF_AGENDA_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_2(DESDE, HASTA, ID_PRE)
        End If

        caca = 123123

        Return data_det_ate
    End Function

    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_PRE As Integer) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""

        'Declaraciones internas
        Dim data_det_ate As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EST_LUGAR_TM_TODOS_2)
        Dim NN_Det_Ate As N_IRIS_WEBF_AGENDA_BUSCA_EST_LUGAR_TM_TODOS_2 = New N_IRIS_WEBF_AGENDA_BUSCA_EST_LUGAR_TM_TODOS_2

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


        Dim Mx_Data(11, 0) As Object

        If ID_PRE = 0 Then

            data_det_ate = NN_Det_Ate.IRIS_WEBF_AGENDA_BUSCA_EST_LUGAR_TM_TODOS_2(DESDE, HASTA)
        Else
            data_det_ate = NN_Det_Ate.IRIS_WEBF_AGENDA_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_2(DESDE, HASTA, ID_PRE)
        End If

        If (data_det_ate.Count > 0) Then
            edad = 0

            Dim Mx_Datax(11, 0) As Object
            'Llenar Matriz
            For y = 0 To (data_det_ate.Count - 1)

                If (y > 0) Then
                    ReDim Preserve Mx_Data(11, y)
                End If

                Mx_Data(0, y) = y + 1

                Mx_Data(0, y) = CInt(data_det_ate(y).PREI_NUM)
                Mx_Data(1, y) = data_det_ate(y).PAC_NOMBRE + " " + data_det_ate(y).PAC_APELLIDO

                If data_det_ate(y).PAC_RUT Is Nothing Then
                    Mx_Data(2, y) = ""
                Else
                    Mx_Data(2, y) = data_det_ate(y).PAC_RUT
                End If

                Mx_Data(3, y) = Format(data_det_ate(y).PREI_FECHA, "dd/MM/yyyy")
                Mx_Data(4, y) = Format(data_det_ate(y).PREI_FECHA_PRE, "dd/MM/yyyy")
                Mx_Data(5, y) = data_det_ate(y).PROC_DESC
                Mx_Data(6, y) = data_det_ate(y).SEXO_DESC
                Mx_Data(7, y) = data_det_ate(y).EST_DESCRIPCION

                If data_det_ate(y).ATE_NUM Is Nothing Then
                    Mx_Data(8, y) = ""
                Else
                    Mx_Data(8, y) = data_det_ate(y).ATE_NUM
                End If

                If data_det_ate(y).USU_AGE Is Nothing Then
                    Mx_Data(9, y) = ""
                Else
                    Mx_Data(9, y) = data_det_ate(y).USU_AGE
                End If

                If data_det_ate(y).USU_ATE Is Nothing Then
                    Mx_Data(10, y) = ""
                Else
                    Mx_Data(10, y) = data_det_ate(y).USU_ATE
                End If

                If data_det_ate(y).PREI_AÑO Is Nothing Then
                    Mx_Data(11, y) = ""
                Else
                    Mx_Data(11, y) = data_det_ate(y).PREI_AÑO
                End If

            Next y
        Else
            Return "null"
        End If

        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Listado de Agendamiento")

        'titulo de la tabla
        sl.SetCellValue("B2", "Listado de Agendamiento")

        For y = 1 To 12
            sl.SetColumnWidth(y, 20.0)
        Next y

        'nombre columnas
        sl.SetCellValue("A8", "N° Agenda")
        sl.SetCellValue("B8", "Nombre Paciente")
        sl.SetColumnWidth("B", 40)
        sl.SetCellValue("C8", "Rut")
        sl.SetCellValue("D8", "Fecha Ingreso")
        sl.SetCellValue("E8", "Fecha Agenda")
        sl.SetCellValue("F8", "Lugar de TM")
        sl.SetCellValue("G8", "Sexo")
        sl.SetColumnWidth("H", 30)
        sl.SetCellValue("H8", "Estado Agenda")
        sl.SetCellValue("I8", "N° Atención")
        sl.SetCellValue("J8", "Usuario Agenda")
        sl.SetCellValue("K8", "Usuario Ingreso")
        sl.SetCellValue("L8", "Edad")


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
        tabla = sl.CreateTable("A8", CStr("L" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"

        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo

        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function

End Class