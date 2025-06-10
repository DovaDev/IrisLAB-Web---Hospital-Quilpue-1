
Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class Excel_TP_Real_ADM_AVIS_VER
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Eliminar(ByVal ID As String) As String

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
                                                  ByVal Fecha_irislab As String,
                                                  ByVal Muestras_recepcionadas As String,
                                                  ByVal Muestras_enviadas As String,
                                                  ByVal Folio_Hoja_trabajo As String,
                                                  ByVal Fecha_envio_HGF As String,
                                                  ByVal Fecha_recepcion_Resultados As String,
                                                  ByVal Fecha_Validacion_en_Irislab As String,
                                                  ByVal nummm_avisssss As String) As String

        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        Dim NN_alumno As N_Registrar = New N_Registrar
        Dim retur As Integer

        retur = NN_alumno.IRIS_WEBF_GRABA_EXCEL_2(
                                00,
                                Cod_barra,
                                Establecimiento_Contenedor,
                                Caja_Transporte,
                                Fecha_irislab,
                                Muestras_recepcionadas,
                                Muestras_enviadas,
                                Folio_Hoja_trabajo,
                                Fecha_envio_HGF,
                                Fecha_recepcion_Resultados,
                                Fecha_Validacion_en_Irislab,
                                nummm_avisssss)

        Return "null"
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_tabla_exam(ByVal ID As String, ByVal CAMBIO As String, ByVal CASILLA As String) As String

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        Dim N_ECrypt As New N_Encrypt
        'Declaraciones internas
        Dim data As Integer
        Dim NN As N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO = New N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO
        If (((CASILLA = "10") Or (CASILLA = "5") Or (CASILLA = "6") Or (CASILLA = "7")) And (CAMBIO = "")) Then
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

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        Dim N_ECrypt As New N_Encrypt
        'Declaraciones internas
        Dim data As List(Of E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL)
        Dim NN As N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO = New N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO

        Dim data_paciente As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP)
        Dim NN2 As N_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2 = New N_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2

        Dim Encrypt As New N_Encrypt

        data = NN.IRIS_WEBF_BUSCA_EST_LUGAR_TM_EXCEL_2(DESDE, HASTA, ID_TM)

        If data.Count > 0 Then

            For i = 0 To data.Count - 1
                If data(i).ATE_AVIS_UNION <> "" Then
                    data_paciente = NN2.IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP(data(i).ATE_AVIS_UNION)

                    If data_paciente.Count > 0 Then

                        data(i).ATE_NUM = data_paciente(0).ATE_NUM
                        data(i).PAC_NOMBRE = data_paciente(0).PAC_NOMBRE
                        data(i).PAC_APELLIDO = data_paciente(0).PAC_APELLIDO
                        data(i).PAC_RUT = data_paciente(0).PAC_RUT
                        data(i).ATE_AÑO = data_paciente(0).ATE_AÑO
                    End If


                End If
            Next i

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
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""
        'Declaraciones internas
        Dim data As List(Of E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL)
        Dim NN As N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO = New N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO

        Dim data_paciente As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP)
        Dim NN2 As N_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2 = New N_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2

        data = NN.IRIS_WEBF_BUSCA_EST_LUGAR_TM_EXCEL_2(DESDE, HASTA, ID_TM)

        For i = 0 To data.Count - 1
            If data(i).ATE_AVIS_UNION <> "" Then
                data_paciente = NN2.IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP(data(i).ATE_AVIS_UNION)

                If data_paciente.Count > 0 Then

                    data(i).ATE_NUM = data_paciente(0).ATE_NUM
                    data(i).PAC_NOMBRE = data_paciente(0).PAC_NOMBRE
                    data(i).PAC_APELLIDO = data_paciente(0).PAC_APELLIDO
                    data(i).PAC_RUT = data_paciente(0).PAC_RUT
                    data(i).ATE_AÑO = data_paciente(0).ATE_AÑO
                End If

            Else
                data(i).ATE_NUM = ""
                data(i).PAC_NOMBRE = ""
                data(i).PAC_APELLIDO = ""
                data(i).PAC_RUT = ""
                data(i).ATE_AÑO = ""
            End If
        Next i

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
        Dim Mx_Data(16, 0) As Object
        If (data.Count > 0) Then
            Dim Mx_Datac(16, 0) As Object
            'Vaciar Matriz
            ReDim Mx_Data(16, 0)
            For x = 0 To (Mx_Data.GetUpperBound(0))
                Mx_Data(x, 0) = Nothing
            Next x
            'Llenar Matriz
            For y = 0 To (data.Count - 1)
                If (y > 0) Then
                    ReDim Preserve Mx_Data(16, y)
                End If
                Mx_Data(0, y) = y + 1
                Mx_Data(1, y) = data(y).ATE_AVIS_UNION
                Mx_Data(2, y) = data(y).ATE_NUM
                Mx_Data(3, y) = data(y).PAC_NOMBRE & " " & data(y).PAC_APELLIDO
                Mx_Data(4, y) = data(y).PAC_RUT
                Mx_Data(5, y) = data(y).ATE_AÑO & " Años"
                Mx_Data(6, y) = data(y).Cod_Barra
                Mx_Data(7, y) = data(y).Establecimiento_Contenedor

                If (Format(CDate(data(y).Fecha_irislab), "dd/MM/yyyy") <> "01/01/1980") Then
                    Mx_Data(8, y) = Format(CDate(data(y).Fecha_irislab), "dd/MM/yyyy HH:mm")
                Else
                    Mx_Data(8, y) = ""
                End If

                Mx_Data(9, y) = data(y).Muestras_recepcionadas

                If (IsNumeric(data(y).Muestras_recepcionadas) And IsNumeric(data(y).Muestras_enviadas)) Then

                End If
                Dim difer As String = ""
                'Dim difer As Integer = 0
                'difer = (CInt(data(y).Muestras_recepcionadas) - CInt(data(y).Muestras_enviadas))

                Mx_Data(10, y) = ""

                Mx_Data(11, y) = data(y).Muestras_enviadas
                Mx_Data(12, y) = data(y).Folio_Hoja_trabajo
                Mx_Data(13, y) = data(y).Caja_Transporte
                If (Format(CDate(data(y).Fecha_envio_HGF), "dd/MM/yyyy") <> "01/01/1980") Then
                    Mx_Data(14, y) = Format(CDate(data(y).Fecha_envio_HGF), "dd/MM/yyyy")
                Else
                    Mx_Data(14, y) = ""
                End If
                If (Format(CDate(data(y).Fecha_recepcion_Resultados), "dd/MM/yyyy") <> "01/01/1980" And data(y).Fecha_recepcion_Resultados <> "1/1/1980 12:00:00 AM") Then
                    Mx_Data(15, y) = Format(CDate(data(y).Fecha_recepcion_Resultados), "dd/MM/yyyy")
                Else
                    Mx_Data(15, y) = ""
                End If
                If (Format(CDate(data(y).Fecha_Validacion_en_Irislab), "dd/MM/yyyy") <> "01/01/1980" And data(y).Fecha_Validacion_en_Irislab <> "1/1/1980 12:00:00 AM") Then
                    Mx_Data(16, y) = Format(CDate(data(y).Fecha_Validacion_en_Irislab), "dd/MM/yyyy")
                Else
                    Mx_Data(16, y) = ""
                End If

            Next y
        Else
            Return "null"
        End If
        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Trazabilidad PAP")
        'titulo de la tabla
        sl.SetCellValue("B2", "Trazabilidad PAP ADM")
        For y = 1 To 17
            sl.SetColumnWidth(y, 20.0)
        Next y
        'nombre columnas
        sl.SetCellValue("A8", "#")
        sl.SetCellValue("B8", "Folio Avis")
        sl.SetCellValue("C8", "Ate Num")
        sl.SetCellValue("D8", "Nombre Pac")
        sl.SetCellValue("E8", "Rut")
        sl.SetCellValue("F8", "Edad")
        sl.SetCellValue("G8", "Cod. Barra")
        sl.SetCellValue("H8", "Establecimiento/Contenedor")
        sl.SetCellValue("I8", "Fecha y hora ingreso Irislab")
        sl.SetCellValue("J8", "Muestras recepcionadas")
        sl.SetCellValue("K8", "Diferencia")
        sl.SetCellValue("L8", "Muestras enviadas")
        sl.SetCellValue("M8", "Folio Hoja trabajo")
        sl.SetCellValue("N8", "Caja Transporte N°")
        sl.SetCellValue("O8", "Fecha envio HGF")
        sl.SetCellValue("P8", "Fecha recepcionada Resultados")
        sl.SetCellValue("Q8", "Fecha Validacion en Irislab")

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
        tabla = sl.CreateTable("A8", CStr("Q" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\TRAZABILIDAD" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
    '----------------------------------------------------------------------------------------------------------------------------------------
    <Services.WebMethod()>
    Public Shared Function Llenar_AVIS(ByVal NUM_AVIS As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP)
        Dim NN As N_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2 = New N_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2

        Dim NN_ExamenDet As New N_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR
        Dim DataExamenDet As New List(Of E_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR)

        Dim Encrypt As New N_Encrypt

        data_paciente = NN.IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP(NUM_AVIS)

        'If data_paciente.Count > 0 Then
        '    DataExamenDet = NN_ExamenDet.IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR(data_paciente(0).ID_ATENCION)
        'Else
        '    datas = "null"
        'End If

        If (data_paciente.Count > 0) Then
            data_paciente(0).ENCRYPTED_ID = Encrypt.Encode(data_paciente(0).ID_ATENCION)

            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_paciente, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function Busca_Examenes(ByVal ID_ATE As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim NN_ExamenDet As New N_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR
        Dim DataExamenDet As New List(Of E_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR)

        DataExamenDet = NN_ExamenDet.IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR_PAP(ID_ATE)

        If (DataExamenDet.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(DataExamenDet, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_GRABA_UNION_DATOS_PAP_AVIS(ByVal ID_REG As Integer, ByVal NUM_AVIS As Integer) As String

        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        Dim NN_alumno As N_Registrar = New N_Registrar
        Dim retur As Integer

        retur = NN_alumno.IRIS_WEBF_GRABA_UNION_DATOS_PAP_AVIS(ID_REG, NUM_AVIS)

        If retur > 0 Then

            Return "ok"
        Else
            Return "null"
        End If

    End Function

End Class