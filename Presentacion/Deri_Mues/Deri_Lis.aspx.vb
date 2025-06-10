Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Imports ASPPDFLib
Public Class Deri_Lis
    Inherits System.Web.UI.Page

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_DERIVADOS() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_derivados As List(Of E_IRIS_WEBF_BUSCA_DERIVADOS)
        Dim NN As N_IRIS_WEBF_BUSCA_DERIVADOS = New N_IRIS_WEBF_BUSCA_DERIVADOS

        data_derivados = NN.IRIS_WEBF_BUSCA_DERIVADOS()

        If (data_derivados.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_derivados, str_Builder)
            datas = str_Builder.ToString

            Return datas
        Else
            Return "null"
        End If

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_webf_BUSCA_LISTADO_DERIVADOS_POR_NUM_PROCESO(ByVal NUM As Integer, ByVal DESDE As String, ByVal HASTA As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_derivados As List(Of E_IRIS_webf_BUSCA_LISTADO_DERIVADOS_POR_NUM_PROCESO)
        Dim NN As N_IRIS_webf_BUSCA_LISTADO_DERIVADOS_POR_NUM_PROCESO = New N_IRIS_webf_BUSCA_LISTADO_DERIVADOS_POR_NUM_PROCESO

        data_derivados = NN.IRIS_webf_BUSCA_LISTADO_DERIVADOS_POR_NUM_PROCESO(NUM, CDate(DESDE), CDate(HASTA))

        If (data_derivados.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_derivados, str_Builder)
            datas = str_Builder.ToString
            Return datas
        Else
            Return "null"
        End If

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_DATOS_DERIVADOR_DETALLE_NUEVO_NUM(ByVal NUM As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_derivados As List(Of E_IRIS_WEBF_BUSCA_DATOS_DERIVADOR_DETALLE_NUEVO_NUM)
        Dim NN As N_IRIS_WEBF_BUSCA_DATOS_DERIVADOR_DETALLE_NUEVO_NUM = New N_IRIS_WEBF_BUSCA_DATOS_DERIVADOR_DETALLE_NUEVO_NUM

        data_derivados = NN.IRIS_WEBF_BUSCA_DATOS_DERIVADOR_DETALLE_NUEVO_NUM(NUM)

        If (data_derivados.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_derivados, str_Builder)
            datas = str_Builder.ToString

            Return datas

        Else
            Return "null"
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal NUM As Integer, ByVal DESDE As String, ByVal HASTA As String) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""


        'Declaraciones internas
        Dim data_det_ate As List(Of E_IRIS_webf_BUSCA_LISTADO_DERIVADOS_POR_NUM_PROCESO)
        Dim NN As N_IRIS_webf_BUSCA_LISTADO_DERIVADOS_POR_NUM_PROCESO = New N_IRIS_webf_BUSCA_LISTADO_DERIVADOS_POR_NUM_PROCESO


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


        Dim Mx_Data(5, 0) As Object

        data_det_ate = NN.IRIS_webf_BUSCA_LISTADO_DERIVADOS_POR_NUM_PROCESO(NUM, CDate(DESDE), CDate(HASTA))

        If (data_det_ate.Count > 0) Then
            edad = 0

            Dim Mx_Datax(5, 0) As Object
            'Llenar Matriz
            For y = 0 To (data_det_ate.Count - 1)

                If (y > 0) Then
                    ReDim Preserve Mx_Data(5, y)
                End If

                Mx_Data(0, y) = y + 1
                Mx_Data(1, y) = data_det_ate(y).DERIV_NUM
                Mx_Data(2, y) = data_det_ate(y).DERI_DESC
                Mx_Data(3, y) = data_det_ate(y).USU_NOMBRE & " " & data_det_ate(y).USU_APELLIDO
                Mx_Data(4, y) = Format(data_det_ate(y).DERIV_PRO_FECHA, "dd/MM/yyyy")
                Mx_Data(5, y) = Format(data_det_ate(y).DERIV_PRO_FECHA, "hh:mm:ss")

            Next y
        Else
            Return "null"
        End If


        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Búsqueda de Listados de Derivación")

        'titulo de la tabla
        sl.SetCellValue("B2", "Búsqueda de Listados de Derivación")

        For y = 1 To 6
            sl.SetColumnWidth(y, 20.0)
        Next y

        'nombre columnas
        sl.SetCellValue("A8", "#")
        sl.SetColumnWidth("A", 10)
        sl.SetCellValue("B8", "N°")
        sl.SetCellValue("C8", "Nombre del Derivador")
        sl.SetColumnWidth("C", 40)
        sl.SetCellValue("D8", "Nombre Usuario")
        sl.SetColumnWidth("D", 40)
        sl.SetCellValue("E8", "Fecha")
        sl.SetCellValue("F8", "Hora")


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
        tabla = sl.CreateTable("A8", CStr("F" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"

        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo

        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function
    <Services.WebMethod()>
    Public Shared Function Excel_Click(ByVal DOMAIN_URL As String, ByVal NUM As Integer) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""


        'Declaraciones internas
        Dim data_det_ate As List(Of E_IRIS_WEBF_BUSCA_DATOS_DERIVADOR_DETALLE_NUEVO_NUM)
        Dim NN As N_IRIS_WEBF_BUSCA_DATOS_DERIVADOR_DETALLE_NUEVO_NUM = New N_IRIS_WEBF_BUSCA_DATOS_DERIVADOR_DETALLE_NUEVO_NUM



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

        data_det_ate = NN.IRIS_WEBF_BUSCA_DATOS_DERIVADOR_DETALLE_NUEVO_NUM(NUM)


        If (data_det_ate.Count > 0) Then
            edad = 0

            Dim Mx_Datax(8, 0) As Object
            'Llenar Matriz
            For y = 0 To (data_det_ate.Count - 1)

                If (y > 0) Then
                    ReDim Preserve Mx_Data(8, y)
                End If

                Mx_Data(0, y) = y + 1
                Mx_Data(1, y) = data_det_ate(y).ATE_NUM
                Mx_Data(2, y) = data_det_ate(y).ATE_FECHA
                Mx_Data(3, y) = data_det_ate(y).PAC_NOMBRE & " " & data_det_ate(y).PAC_APELLIDO
                Mx_Data(4, y) = data_det_ate(y).CF_DESC
                Mx_Data(5, y) = data_det_ate(y).ORD_DESC
                Mx_Data(6, y) = data_det_ate(y).DOC_NOMBRE & " " & data_det_ate(y).DOC_APELLIDO
                Mx_Data(7, y) = data_det_ate(y).SEXO_COD
                Mx_Data(8, y) = Format(CDate(data_det_ate(y).PAC_FNAC), "dd/MM/yyyy")


            Next y
        Else
            Return "null"
        End If



        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Listado Exámenes de la Atención")

        'titulo de la tabla
        sl.SetCellValue("B2", "Listado Exámenes de la Atención")

        For y = 1 To 9
            sl.SetColumnWidth(y, 20.0)
        Next y

        'nombre columnas
        sl.SetCellValue("A8", "Datos")
        sl.SetColumnWidth("A", 10)
        sl.SetCellValue("B8", "N° Atención")
        sl.SetCellValue("C8", "Fecha")
        sl.SetCellValue("D8", "Paciente")
        sl.SetColumnWidth("D", 40)
        sl.SetCellValue("E8", "Exámenes")
        sl.SetCellValue("F8", "Orden")
        sl.SetCellValue("G8", "Médico")
        sl.SetColumnWidth("G", 40)
        sl.SetCellValue("H8", "Sexo")
        sl.SetCellValue("I8", "F. Nac")


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