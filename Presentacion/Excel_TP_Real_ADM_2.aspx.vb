Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class Excel_TP_Real_ADM_2
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Eliminar(ByVal ID As String) As String

        'Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        Dim N_ECrypt As New N_Encrypt
        'Declaraciones internas
        Dim data As Integer
        Dim NN As N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO = New N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO

        data = NN.IRIS_WEBF_ELIMINAR(ID)

        If data > 0 Then

            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function Ajax_DataTable_agregar(ByVal Cod_barra As String,
                                                  ByVal Establecimiento_Contenedor As String,
                                                  ByVal Caja_Transporte As String,
                                                  ByVal Contenedor_Envio As String,
                                                  ByVal Fecha_irislab As String,
                                                  ByVal Muestras_recepcionadas As String,
                                                  ByVal Muestras_enviadas As String,
                                                  ByVal Folio_Hoja_trabajo As String,
                                                  ByVal Fecha_envio_HGF As String,
                                                  ByVal Fecha_recepcion_Resultados As String,
                                                  ByVal Fecha_Validacion_en_Irislab As String) As String

        'Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

        ''Declaraciones del Serializador
        'Dim NN_Date As New N_Date_Operat
        'Dim fecha As String = FECHA_PRE.Replace("/", "-")
        'Dim DIA1 As String = fecha.Split("-")(0)
        'Dim MES2 As String = fecha.Split("-")(1)
        'Dim AÑO3 As String = fecha.Split("-")(2)
        'Dim Date_01 As Date = NN_Date.strToDate(AÑO3, MES2, DIA1)
        'Dim Date_02 As Date = NN_Date.strToDate(AÑO3, MES2, DIA1)




        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        Dim NN_alumno As N_Registrar = New N_Registrar
        Dim retur As Integer

        retur = NN_alumno.IRIS_WEBF_GRABA_EXCEL_CONTENEDOR_ENVIO(
                                00,
                                Cod_barra,
                                Establecimiento_Contenedor,
                                Caja_Transporte,
                                Contenedor_Envio,
                                Fecha_irislab,
                                Muestras_recepcionadas,
                                Muestras_enviadas,
                                Folio_Hoja_trabajo,
                                Fecha_envio_HGF,
                                Fecha_recepcion_Resultados,
                                Fecha_Validacion_en_Irislab)
        'data = NN.IRIS_WEBF_BUSCA_EST_LUGAR_TM_EXCEL_UPDATE(ID, CAMBIO, CASILLA)

        'If data > 0 Then

        '    Serializer.MaxJsonLength = 999999999
        '    Serializer.Serialize(data, str_Builder)
        '    Return str_Builder.ToString
        'Else
        '    Return "null"
        'End If
        Return "null"
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_tabla_exam(ByVal ID As String, ByVal CAMBIO As String, ByVal CASILLA As String) As String

        'Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        Dim N_ECrypt As New N_Encrypt
        'Declaraciones internas
        Dim data As Integer
        Dim NN As N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO = New N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO
        If (((CASILLA = "10") Or (CASILLA = "5") Or (CASILLA = "6") Or (CASILLA = "7") Or (CASILLA = "11111")) And (CAMBIO = "")) Then
            data = 0
        Else
            data = NN.IRIS_WEBF_BUSCA_EST_LUGAR_TM_EXCEL_UPDATE(ID, CAMBIO, CASILLA)
        End If

        If data > 0 Then

            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If

    End Function
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
        Excel_y = 10
        Dim ltabla As Integer = 0
        Dim Mx_Data(11, 0) As Object
        If (data.Count > 0) Then
            Dim Mx_Datac(11, 0) As Object
            'Vaciar Matriz
            ReDim Mx_Data(11, 0)
            For x = 0 To (Mx_Data.GetUpperBound(0))
                Mx_Data(x, 0) = Nothing
            Next x
            'Llenar Matriz
            For y = 0 To (data.Count - 1)
                If (y > 0) Then
                    ReDim Preserve Mx_Data(11, y)
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
                Mx_Data(7, y) = data(y).Muestras_enviadas
                Mx_Data(8, y) = data(y).Folio_Hoja_trabajo
                If (Format(CDate(data(y).Fecha_envio_HGF), "dd/MM/yyyy") <> "01/01/1980") Then
                    Mx_Data(9, y) = Format(CDate(data(y).Fecha_envio_HGF), "dd/MM/yyyy")
                Else
                    Mx_Data(9, y) = ""
                End If
                If (Format(CDate(data(y).Fecha_recepcion_Resultados), "dd/MM/yyyy") <> "01/01/1980" And data(y).Fecha_recepcion_Resultados <> "1/1/1980 12:00:00 AM") Then
                    Mx_Data(10, y) = Format(CDate(data(y).Fecha_recepcion_Resultados), "dd/MM/yyyy")
                Else
                    Mx_Data(10, y) = ""
                End If
                If (Format(CDate(data(y).Fecha_Validacion_en_Irislab), "dd/MM/yyyy") <> "01/01/1980" And data(y).Fecha_Validacion_en_Irislab <> "1/1/1980 12:00:00 AM") Then
                    Mx_Data(11, y) = Format(CDate(data(y).Fecha_Validacion_en_Irislab), "dd/MM/yyyy")
                Else
                    Mx_Data(11, y) = ""
                End If

            Next y
        Else
            Return "null"
        End If
        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Trazabilidad PAP")
        'titulo de la tabla
        sl.SetCellValue("B2", "Trazabilidad PAP ADM")
        For y = 1 To 10
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
        sl.SetCellValue("H8", "Muestras enviadas")
        sl.SetCellValue("I8", "Folio Hoja trabajo")
        sl.SetCellValue("J8", "Fecha envio HGF")
        sl.SetCellValue("K8", "Fecha recepcionada Resultados")
        sl.SetCellValue("L8", "Fecha Validacion en Irislab")

        For y = 1 To 11
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
        tabla = sl.CreateTable("A8", CStr("L" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\TRAZABILIDAD" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function

End Class