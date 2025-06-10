Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class Excel_TP_Real_2
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
    Public Shared Function Llenar_DataTable(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_TM As String) As String

        'Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        Dim N_ECrypt As New N_Encrypt
        'Declaraciones internas
        Dim data As List(Of E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL)
        Dim NN As N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO = New N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO

        data = NN.IRIS_WEBF_BUSCA_EST_LUGAR_TM_EXCEL_CONTENEDOR_ENVIO(DESDE, HASTA, ID_TM)

        If data.Count > 0 Then

            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_TM As String) As String

        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""
        'Declaraciones internas
        Dim data As List(Of E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL)
        Dim NN As N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO = New N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO

        data = NN.IRIS_WEBF_BUSCA_EST_LUGAR_TM_EXCEL_CONTENEDOR_ENVIO(DESDE, HASTA, ID_TM)
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
        Dim Mx_Data(12, 0) As Object
        If (data.Count > 0) Then
            Dim Mx_Datac(12, 0) As Object
            'Vaciar Matriz
            ReDim Mx_Data(12, 0)
            For x = 0 To (Mx_Data.GetUpperBound(0))
                Mx_Data(x, 0) = Nothing
            Next x
            'Llenar Matriz
            For y = 0 To (data.Count - 1)
                If (y > 0) Then
                    ReDim Preserve Mx_Data(12, y)
                End If
                Mx_Data(0, y) = y + 1
                Mx_Data(1, y) = data(y).Cod_Barra
                Mx_Data(2, y) = data(y).Establecimiento_Contenedor
                Mx_Data(3, y) = data(y).Caja_Transporte
                Mx_Data(4, y) = data(y).Contenedor_Envio
                If (Format(CDate(data(y).Fecha_irislab), "dd/MM/yyyy") <> "01/01/1980") Then
                    Mx_Data(5, y) = Format(CDate(data(y).Fecha_irislab), "dd/MM/yyyy HH:mm")
                Else
                    Mx_Data(5, y) = ""
                End If

                Mx_Data(6, y) = data(y).Muestras_recepcionadas

                Dim diferr As Integer = 0
                diferr = (CInt(data(y).Muestras_recepcionadas) - CInt(data(y).Muestras_enviadas))
                Mx_Data(7, y) = diferr

                Mx_Data(8, y) = data(y).Muestras_enviadas
                Mx_Data(9, y) = data(y).Folio_Hoja_trabajo
                If (Format(CDate(data(y).Fecha_envio_HGF), "dd/MM/yyyy") <> "01/01/1980") Then
                    Mx_Data(10, y) = Format(CDate(data(y).Fecha_envio_HGF), "dd/MM/yyyy")
                Else
                    Mx_Data(10, y) = ""
                End If
                If (Format(CDate(data(y).Fecha_recepcion_Resultados), "dd/MM/yyyy") <> "01/01/1980") Then
                    Mx_Data(11, y) = Format(CDate(data(y).Fecha_recepcion_Resultados), "dd/MM/yyyy")
                Else
                    Mx_Data(11, y) = ""
                End If
                If (Format(CDate(data(y).Fecha_Validacion_en_Irislab), "dd/MM/yyyy") <> "01/01/1980") Then
                    Mx_Data(12, y) = Format(CDate(data(y).Fecha_Validacion_en_Irislab), "dd/MM/yyyy")
                Else
                    Mx_Data(12, y) = ""
                End If

            Next y
        Else
            Return "null"
        End If
        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Trazabilidad PAP")
        'titulo de la tabla
        sl.SetCellValue("B2", "Trazabilidad PAP")
        For y = 1 To 13
            sl.SetColumnWidth(y, 20.0)
        Next y
        'nombre columnas
        sl.SetCellValue("A8", "#")
        sl.SetCellValue("B8", "Cod. Barra")
        sl.SetCellValue("C8", "Establecimiento/Contenedor")
        'sl.SetColumnWidth("D", 40)
        sl.SetCellValue("D8", "Caja Transporte N°")
        sl.SetCellValue("E8", "Contenedor de Envió AP")
        sl.SetCellValue("F8", "Fecha y hora ingreso Irislab")
        sl.SetCellValue("G8", "Muestras recepcionadas")
        sl.SetCellValue("H8", "Diferencia")
        sl.SetCellValue("I8", "Muestras enviadas")
        sl.SetCellValue("J8", "Folio Hoja trabajo")
        sl.SetCellValue("K8", "Fecha envio HGF")
        sl.SetCellValue("L8", "Fecha recepcionada Resultados")
        sl.SetCellValue("M8", "Fecha Validacion en Irislab")

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
        tabla = sl.CreateTable("A8", CStr("M" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\TRAZABILIDAD" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
End Class