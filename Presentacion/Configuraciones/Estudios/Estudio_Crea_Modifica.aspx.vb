Imports Entidades
Imports Entidades.E_IRIS_WEBF_BUSCA_ANALIZADOR
Imports Negocio
Imports SpreadsheetLight
Imports System.Web
Imports System.Web.Script.Serialization

Public Class Estudio_Crea_Modifica
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR)
        Dim NN As N_IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR = New N_IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR
        data_paciente = NN.IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR()
        If (data_paciente.Count > 0) Then
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
    Public Shared Function LLENAR_DDL_SECCION() As List(Of E_IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO)
        Dim NN_CF As New N_IRIS_WEBF_BUSCA_AREA
        Dim Data_CF As New List(Of E_IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO)
        Data_CF = NN_CF.LLENAR_DDL_SECCION()
        If (Data_CF.Count > 0) Then
            Return Data_CF
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_PERFIL_ESTUDIO_CLINICO() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_ESTUDIO_CLINICO)
        Dim NN As N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION = New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
        data_paciente = NN.IRIS_WEBF_BUSCA_PERFIL_ESTUDIO_CLINICO()
        If (data_paciente.Count > 0) Then
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
    Public Shared Function IRIS_WEBF_GRABA_ESTUDIOS(ByVal PER_COD As String, ByVal PER_DESC As String, ByVal PER_CORTO As String, ByVal PER_HOST1 As String, ByVal PER_HOST2 As String, ByVal PER_BAC_EST As String, ByVal ID_ESTADO As Integer, ByVal ID_RLS_LS As Integer, ByVal PER_NUM_PRU As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION = New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
        numerin = NN.IRIS_WEBF_GRABA_ESTUDIOS(PER_COD, PER_DESC, PER_CORTO, PER_HOST1, PER_HOST2, PER_BAC_EST, ID_ESTADO, ID_RLS_LS, PER_NUM_PRU)

        If (numerin > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(numerin, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_UPDATE_ESTUDIOS_PERFIL(ByVal ID_PER As Integer, ByVal PER_COD As String, ByVal PER_DESC As String, ByVal PER_CORTO As String, ByVal PER_HOST1 As String, ByVal PER_HOST2 As String, ByVal PER_BAC_EST As String, ByVal ID_ESTADO As Integer, ByVal ID_RLS_LS As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION = New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
        numerin = NN.IRIS_WEBF_UPDATE_ESTUDIOS_PERFIL(ID_PER, PER_COD, PER_DESC, PER_CORTO, PER_HOST1, PER_HOST2, PER_BAC_EST, ID_ESTADO, ID_RLS_LS)
        If (numerin > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(numerin, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function Excel(DOMAIN_URL As String) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""

        'Declaraciones internas

        Dim NN_Excel As New N_Excel
        Dim data_det_ate As List(Of E_ESTUDIO_CLINICO)
        Dim NN_Det_Ate As N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION = New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
        data_det_ate = NN_Det_Ate.IRIS_WEBF_BUSCA_PERFIL_ESTUDIO_CLINICO()

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

        'nombre columnas
        sl.SetCellValue("A8", "#")
        sl.SetCellValue("B8", "Código")
        sl.SetCellValue("C8", "Descripción")
        sl.SetCellValue("D8", "Descripción Corta")
        sl.SetCellValue("E8", "N° Det")
        sl.SetCellValue("F8", "Estado")
        sl.SetCellValue("G8", "Host 1")
        sl.SetCellValue("H8", "Host 2")
        sl.SetCellValue("I8", "Seccion")
        sl.SetCellValue("J8", "Contar Bacterio")


        data_det_ate = NN_Det_Ate.IRIS_WEBF_BUSCA_PERFIL_ESTUDIO_CLINICO()

        If (data_det_ate.Count > 0) Then

            For i = 0 To data_det_ate.Count - 1
                Dim colActual = 1
                sl.SetCellValue(i + 9, colActual, i + 1) : colActual += 1
                sl.SetCellValue(i + 9, colActual, data_det_ate(i).PER_COD) : colActual += 1
                sl.SetCellValue(i + 9, colActual, data_det_ate(i).PER_DESC) : colActual += 1
                sl.SetCellValue(i + 9, colActual, data_det_ate(i).PER_CORTO) : colActual += 1
                sl.SetCellValue(i + 9, colActual, data_det_ate(i).PER_NUM_PRU) : colActual += 1

                sl.SetCellValue(i + 9, colActual, If(data_det_ate(i).ID_ESTADO, "ACTIVO", "DESACTIVADO")) : colActual += 1
                sl.SetCellValue(i + 9, colActual, data_det_ate(i).PER_HOST1) : colActual += 1
                sl.SetCellValue(i + 9, colActual, data_det_ate(i).PER_HOST2) : colActual += 1
                sl.SetCellValue(i + 9, colActual, data_det_ate(i).RLS_LS_DESC) : colActual += 1
                sl.SetCellValue(i + 9, colActual, If(data_det_ate(i).PER_BAC_EST, "ACTIVO", "DESACTIVADO")) : colActual += 1
                ltabla += 1

            Next

        Else
            Return "null"
        End If

        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Listado de Envío de Exámenes")

        'titulo de la tabla
        sl.SetCellValue("B2", "Listado de Envío de Exámenes")

        sl.AutoFitColumn(1, 10, 45)
        For y = 1 To 10
            sl.SetColumnWidth(y, sl.GetColumnWidth(y) + 3)
        Next y



        ltabla += 9
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
        tabla = sl.CreateTable("A8", CStr("J" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"

        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo

        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_BUSCA_RANGO_REFERENCIA(ByVal ID_DET As Integer) As List(Of E_IRIS_BUSCA_RANGO_REFERENCIA)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim NN As N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION = New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION

        Dim Data As New List(Of E_IRIS_BUSCA_RANGO_REFERENCIA)
        Data = NN.IRIS_BUSCA_RANGO_REFERENCIA(ID_DET)

        If (Data.Count >= 0) Then
            Return Data
        Else
            Return Nothing
        End If

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_GRABA_RANGO_REFERENCIA(
                                                       ByVal ID_PRUEBA As Integer,
                                                       ByVal ID_SEXO As Integer,
                                                       ByVal ANO_DESDE As Integer,
                                                       ByVal MES_DESDE As Integer,
                                                       ByVal DIAS_DESDE As Integer,
                                                       ByVal ANO_HASTA As Integer,
                                                       ByVal MES_HASTA As Integer,
                                                       ByVal DIAS_HASTA As Integer,
                                                       ByVal MBAJO As Double,
                                                       ByVal BAJO As Double,
                                                       ByVal ALTO As Double,
                                                       ByVal MALTO As Double,
                                                       ByVal TEXTO As String,
                                                       ByVal EMBARA As Integer,
                                                       ByVal ID_USUARIO As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_GRABA_RANGO_REFERENCIA = New N_IRIS_WEBF_GRABA_RANGO_REFERENCIA
        numerin = NN.IRIS_WEBF_GRABA_RANGO_REFERENCIA(ID_PRUEBA,
                                                        ID_SEXO,
                                                        ANO_DESDE,
                                                        MES_DESDE,
                                                        DIAS_DESDE,
                                                        ANO_HASTA,
                                                        MES_HASTA,
                                                        DIAS_HASTA,
                                                        MBAJO,
                                                        BAJO,
                                                        ALTO,
                                                        MALTO,
                                                        TEXTO,
                                                        EMBARA,
                                                        ID_USUARIO)

        If (numerin > 0) Then
            'Srializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(numerin, str_builder)
            datas = str_builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_UPDATE_RANGO_REFERENCIA(
                                                       ByVal ID_RF As Integer,
                                                       ByVal ID_SEXO As Integer,
                                                       ByVal ANO_DESDE As Integer,
                                                       ByVal MES_DESDE As Integer,
                                                       ByVal DIAS_DESDE As Integer,
                                                       ByVal ANO_HASTA As Integer,
                                                       ByVal MES_HASTA As Integer,
                                                       ByVal DIAS_HASTA As Integer,
                                                       ByVal MBAJO As Double,
                                                       ByVal BAJO As Double,
                                                       ByVal ALTO As Double,
                                                       ByVal MALTO As Double,
                                                       ByVal TEXTO As String,
                                                       ByVal EMBARA As Integer) As Integer
        'Declaraciones del Serializazdor
        Dim Serializer As New JavaScriptSerializer
        Dim str_builder As New StringBuilder
        Dim datas As String = ""
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_UPDATE_RANGO_REFERENCIA = New N_IRIS_WEBF_UPDATE_RANGO_REFERENCIA
        numerin = NN.IRIS_WEBF_UPDATE_RANGO_REFERENCIA(ID_RF,
                                                       ID_SEXO,
                                                       ANO_DESDE,
                                                       MES_DESDE,
                                                       DIAS_DESDE,
                                                       ANO_HASTA,
                                                       MES_HASTA,
                                                       DIAS_HASTA,
                                                       MBAJO,
                                                       BAJO,
                                                       ALTO,
                                                       MALTO,
                                                       TEXTO,
                                                       EMBARA)
        If (numerin > 0) Then
            'Serializar con JSON    
            Serializer.MaxJsonLength = 99999999
            Serializer.Serialize(numerin, str_builder)
            datas = str_builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_QUITA_RANGO_REFERENCIA(ByVal ID_RF As Integer) As Integer

        'Declaraciones del Serializazdor
        Dim Serializer As New JavaScriptSerializer
        Dim str_builder As New StringBuilder
        Dim datas As String = ""
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_QUITA_RANGO_REFERENCIA = New N_IRIS_WEBF_QUITA_RANGO_REFERENCIA
        numerin = NN.IRIS_WEBF_QUITA_RANGO_REFERENCIA_(ID_RF)
        If (numerin > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 9999999
            Serializer.Serialize(numerin, str_builder)
            datas = str_builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_BUSCA_PRUEBAS_POR_CODIGO_PER(ByVal ID_PER As Integer) As List(Of E_PRUEBAS)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim NN As N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION = New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION

        Dim Data As New List(Of E_PRUEBAS)
        Data = NN.IRIS_BUSCA_PRUEBAS_POR_CODIGO_PER(ID_PER)

        If (Data.Count >= 0) Then
            Return Data
        Else
            Return Nothing
        End If

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_SEXO() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_SEXO)
        Dim NN As N_IRIS_WEBF_BUSCA_SEXO = New N_IRIS_WEBF_BUSCA_SEXO
        data_paciente = NN.IRIS_WEBF_BUSCA_SEXO()
        If (data_paciente.Count > 0) Then
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
    Public Shared Function IRIS_BUSCA_UNIDAD_MEDIDA() As List(Of E_IRIS_WEBF_BUSCA_UNIDAD_MEDIDA_ACTIVO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim NN As N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION = New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION

        Dim Data As New List(Of E_IRIS_WEBF_BUSCA_UNIDAD_MEDIDA_ACTIVO)
        Data = NN.IRIS_BUSCA_UNIDAD_MEDIDA()
        If (Data.Count > 0) Then
            Return Data
        Else
            Return Nothing
        End If

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_BUSCA_TP_RESULTADO() As List(Of E_IRIS_WEBF_BUSCA_TP_RESULTADO_ACTIVADO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim NN As N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION = New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION

        Dim Data As New List(Of E_IRIS_WEBF_BUSCA_TP_RESULTADO_ACTIVADO)
        Data = NN.IRIS_BUSCA_TP_RESULTADO()
        If (Data.Count > 0) Then
            Return Data
        Else
            Return Nothing
        End If

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_BUSCA_MUESTRA() As List(Of E_IRIS_WEBF_BUSCA_TP_RECIPIENTE)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim NN As N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION = New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION

        Dim Data As New List(Of E_IRIS_WEBF_BUSCA_TP_RECIPIENTE)
        Data = NN.IRIS_BUSCA_MUESTRA()
        If (Data.Count > 0) Then
            Return Data
        Else
            Return Nothing
        End If

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_BUSCA_TP_BACTERIO() As List(Of E_IRIS_WEBF_BUSCA_BACTERIO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim NN As N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION = New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION

        Dim Data As New List(Of E_IRIS_WEBF_BUSCA_BACTERIO)
        Data = NN.IRIS_BUSCA_TP_BACTERIO()
        If (Data.Count > 0) Then
            Return Data
        Else
            Return Nothing
        End If

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_DELETE_PRUEBA(ByVal ID_PRUEBA As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As String = ""
        Dim NN As N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION = New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
        data_paciente = NN.IRIS_DELETE_PRUEBA(ID_PRUEBA)
        'Declaraciones internas

        If (data_paciente.Count > 0) Then
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
    Public Shared Function IRIS_WEBF_UPDATE_PRUEBA(ByVal ID_PRUEBA As Integer, ByVal COD_P As String, ByVal DESC_P As String, ByVal CORTO_P As String,
                                                            ByVal ID_UM_P As Integer, ByVal ID_TP_RESUL_P As Integer, ByVal ID_T_MUESTRA As Integer, ByVal ID_TP_BAC As Integer,
                                                            ByVal ID_PER As Integer, ByVal ORDEN_P As Integer, ByVal SOLICITADOL_P As Integer, ByVal ID_USUARIO_P As Integer, ByVal FECHA_M As String,
                                                            ByVal ID_ESTADO As Integer, ByVal NUM_DEC As Integer, ByVal PRU_P_CERO As Integer, ByVal REQ_RES_VAL As Integer, ByVal PRU_P_PUNTO As Integer) As String

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION = New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
        datas = NN.IRIS_WEBF_UPDATE_PRUEBA(ID_PRUEBA, COD_P, DESC_P, CORTO_P, ID_UM_P, ID_TP_RESUL_P, ID_T_MUESTRA, ID_TP_BAC, ID_PER, ORDEN_P, SOLICITADOL_P, ID_USUARIO_P, FECHA_M, ID_ESTADO, NUM_DEC, PRU_P_CERO, REQ_RES_VAL, PRU_P_PUNTO)
        If (datas.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(datas, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_GRABA_PRUEBA(ByVal COD_P As String, ByVal DESC_P As String, ByVal CORTO_P As String,
                                                        ByVal ID_UM_P As Integer, ByVal ID_TP_RESUL_P As Integer, ByVal ID_T_MUESTRA As Integer, ByVal ID_TP_BAC As Integer,
                                                        ByVal ID_PER As Integer, ByVal ORDEN_P As Integer, ByVal SOLICITADOL_P As Integer, ByVal ID_USUARIO_P As Integer,
                                                        ByVal ID_ESTADO As Integer, ByVal NUM_DEC As Integer, ByVal HOST_P As Integer, ByVal PRU_P_CERO As Integer,
                                                        ByVal REQ_RES_VAL As Integer, ByVal PRU_P_PUNTO As Integer) As List(Of E_PRUEBAS)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As New List(Of E_PRUEBAS)
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION = New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
        datas = NN.IRIS_WEBF_GRABA_PRUEBA(COD_P, DESC_P, CORTO_P, ID_UM_P, ID_TP_RESUL_P, ID_T_MUESTRA, ID_TP_BAC, ID_PER, ORDEN_P, SOLICITADOL_P, ID_USUARIO_P, ID_ESTADO, NUM_DEC, HOST_P, PRU_P_CERO, REQ_RES_VAL, PRU_P_PUNTO)
        If (datas.Count > 0) Then
            'Serializar con JSON
            Return datas
        Else
            Return Nothing
        End If

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_GRABA_FORMATO(ByVal PER_COD As String, ByVal PER_DESC As String, ByVal ID_PER As Integer, ByVal ID_ESTADO As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION = New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
        numerin = NN.IRIS_WEBF_GRABA_FORMATO(PER_COD, PER_DESC, ID_PER, ID_ESTADO)

        If (numerin > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(numerin, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_DELETE_FORMATO(ByVal ID_PER As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION = New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
        numerin = NN.IRIS_WEBF_DELETE_FORMATO(ID_PER)

        If (numerin > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(numerin, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_UPDATE_FORMATO(ByVal PER_COD As String, ByVal PER_DESC As String, ByVal ID_PER As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION = New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
        numerin = NN.IRIS_WEBF_UPDATE_FORMATO(PER_COD, PER_DESC, ID_PER)

        If (numerin > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(numerin, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_UPDATE_DETERMINACIONES_PERFIL(ByVal ID_PER As Integer, ByVal DET As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As String = ""
        Dim NN As N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION = New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
        data_paciente = NN.IRIS_UPDATE_DETERMINACIONES_PERFIL(ID_PER, DET)
        'Declaraciones internas

        If (data_paciente.Count > 0) Then
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
    Public Shared Function IRIS_WEBF_BUSCA_FORMATO(ByVal COD_P As String, ByVal ID_PER As Integer) As List(Of E_IRIS_WEBF_BUSCA_FORMATO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_FORMATO)
        Dim NN As N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION = New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
        data_paciente = NN.IRIS_WEBF_BUSCA_FORMATO(COD_P, ID_PER)

        If (data_paciente.Count > 0) Then
            Return data_paciente
        Else
            Return Nothing
        End If

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_GRABA_FORMATO_RESULTADO(ByVal ID_FORMATO As Integer, ByVal FR_OBJETO As String, ByVal FR_ID_OBJETO As Integer, ByVal FR_FILA As Decimal, ByVal FR_COLUMNA As Decimal, ByVal FR_ALTO As Integer,
                                                             ByVal FR_ANCHO As Integer, ByVal FR_TEXTO As String, ByVal ID_LETRA As Integer, ByVal FR_TAMANO As Integer, ByVal FR_EFECTO As String, ByVal FR_DINAMICA As Integer,
                                                             ByVal FR_DEPENDENCIA As Integer, ByVal ID_PRUEBA As Integer, ByVal ID_ESTADO As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION = New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
        numerin = NN.IRIS_WEBF_GRABA_FORMATO_RESULTADO(ID_FORMATO, FR_OBJETO, FR_ID_OBJETO, FR_FILA, FR_COLUMNA, FR_ALTO, FR_ANCHO, FR_TEXTO, ID_LETRA, FR_TAMANO, FR_EFECTO, FR_DINAMICA, FR_DEPENDENCIA, ID_PRUEBA, ID_ESTADO)

        If (numerin > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(numerin, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_UPDATE_FORMATO_RESULTADO(ByVal FR_OBJETO As String, ByVal FR_TEXTO As String, ByVal FR_TEXTOANT As String, ByVal FR_UNIDAD As String, ByVal ID_PRUEBA As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION = New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
        datas = NN.IRIS_WEBF_UPDATE_FORMATO_RESULTADO(FR_OBJETO, FR_TEXTO, FR_TEXTOANT, FR_UNIDAD, ID_PRUEBA)

        If (datas.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(numerin, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_DELETE_FORMATO_RESULTADO(ByVal ID_PRUEBA As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION = New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
        datas = NN.IRIS_WEBF_DELETE_FORMATO_RESULTADO(ID_PRUEBA)

        If (datas.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(numerin, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_CMVM_BUSCA_METODO_BY_ID_PER_NO_RELACIONADAS(ByVal ID_PER As Integer) As IEnumerable(Of Object)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_progra As List(Of E_IRIS_WEBF_BUSCA_METODO)
        Dim NN_progra As N_IRIS_WEBF_BUSCA_METODO = New N_IRIS_WEBF_BUSCA_METODO

        data_progra = NN_progra.IRIS_WEBF_CMVM_BUSCA_METODO_BY_ID_PER_NO_RELACIONADAS(ID_PER)

        Return data_progra
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_CMVM_BUSCA_DERIVADO_BY_ID_PER_NO_RELACIONADAS(ByVal ID_PER As Integer) As IEnumerable(Of Object)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_progra As List(Of E_IRIS_WEBF_BUSCA_DERIVADOS)
        Dim NN_progra As N_IRIS_WEBF_BUSCA_DERIVADOS = New N_IRIS_WEBF_BUSCA_DERIVADOS

        data_progra = NN_progra.IRIS_WEBF_CMVM_BUSCA_DERIVADO_BY_ID_PER_NO_RELACIONADAS(ID_PER)

        Return data_progra
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_CMVM_BUSCA_TP_MUESTRA_SANGRE_BY_ID_PER_NO_RELACIONADAS(ByVal ID_PER As Integer) As IEnumerable(Of Object)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_progra As List(Of E_IRIS_WEBF_BUSCA_MUESTRA_SANGRE)
        Dim NN_progra As N_IRIS_WEBF_BUSCA_TP_MUESTRA = New N_IRIS_WEBF_BUSCA_TP_MUESTRA

        data_progra = NN_progra.IRIS_WEBF_CMVM_BUSCA_TP_MUESTRA_SANGRE_BY_ID_PER_NO_RELACIONADAS(ID_PER)

        Return data_progra
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_CMVM_BUSCA_ANALIZADOR_BY_ID_PER_NO_RELACIONADAS(ByVal ID_PER As Integer) As IEnumerable(Of Object)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_progra As List(Of E_IRIS_WEBF_BUSCA_ANALIZADOR)
        Dim NN_progra As N_IRIS_WEBF_BUSCA_TP_MUESTRA = New N_IRIS_WEBF_BUSCA_TP_MUESTRA

        data_progra = NN_progra.IRIS_WEBF_CMVM_BUSCA_ANALIZADOR_BY_ID_PER_NO_RELACIONADAS(ID_PER)

        Return data_progra
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_CMVM_BUSCA_RELACION_ESTUDIO_METODO_MANTENEDOR_REL(ByVal ID_PER As Integer) As List(Of E_IRIS_WEBF_BUSCA_RELACION_METODO_ID_PER)
        Dim NN_CF As New N_IRIS_WEBF_BUSCA_METODO
        Dim Data_CF As New List(Of E_IRIS_WEBF_BUSCA_RELACION_METODO_ID_PER)
        Data_CF = NN_CF.IRIS_WEBF_CMVM_BUSCA_RELACION_ESTUDIO_METODO_MANTENEDOR_REL(ID_PER)

        Return Data_CF

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_CMVM_BUSCA_RELACION_ESTUDIO_DERIVADO_MANTENEDOR_REL(ByVal ID_PER As Integer) As List(Of E_IRIS_WEBF_BUSCA_RELACION_DERIVADOS_ID_PER)
        Dim NN_CF As New N_IRIS_WEBF_BUSCA_DERIVADOS
        Dim Data_CF As New List(Of E_IRIS_WEBF_BUSCA_RELACION_DERIVADOS_ID_PER)
        Data_CF = NN_CF.IRIS_WEBF_CMVM_BUSCA_RELACION_ESTUDIO_DERIVADO_MANTENEDOR_REL(ID_PER)

        Return Data_CF

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_CMVM_BUSCA_RELACION_TP_MUESTRA_SANGRE_MANTENEDOR_REL(ByVal ID_PER As Integer) As List(Of E_IRIS_WEBF_BUSCA_MUESTRA_SANGRE_REL)
        Dim NN_CF As New N_IRIS_WEBF_BUSCA_TP_MUESTRA
        Dim Data_CF As New List(Of E_IRIS_WEBF_BUSCA_MUESTRA_SANGRE_REL)
        Data_CF = NN_CF.IRIS_WEBF_CMVM_BUSCA_RELACION_TP_MUESTRA_SANGRE_MANTENEDOR_REL(ID_PER)

        Return Data_CF

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_CMVM_BUSCA_RELACION_ANALIZADOR_MANTENEDOR_REL(ByVal ID_PER As Integer) As List(Of E_IRIS_WEBF_BUSCA_ANALIZADOR_REL)
        Dim NN_CF As New N_IRIS_WEBF_BUSCA_TP_MUESTRA
        Dim Data_CF As New List(Of E_IRIS_WEBF_BUSCA_ANALIZADOR_REL)
        Data_CF = NN_CF.IRIS_WEBF_CMVM_BUSCA_RELACION_ANALIZADOR_MANTENEDOR_REL(ID_PER)

        Return Data_CF

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_GRABA_RELACION_METODO_ESTUDIO(ByVal ID_PER As Integer, ByVal ID_USER As Integer, ByVal ARRAY_ As List(Of Integer)) As Integer
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As Integer = 0
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_BUSCA_METODO = New N_IRIS_WEBF_BUSCA_METODO


        For Each Item As Integer In ARRAY_

            numerin = NN.IRIS_GRABA_RELACION_METODO_ESTUDIO(ID_PER, ID_USER, Item)
        Next

        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_GRABA_RELACION_DERIVADO_ESTUDIO(ByVal ID_PER As Integer, ByVal ID_USER As Integer, ByVal ARRAY_ As List(Of Integer)) As Integer
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As Integer = 0
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_BUSCA_DERIVADOS = New N_IRIS_WEBF_BUSCA_DERIVADOS


        For Each Item As Integer In ARRAY_

            numerin = NN.IRIS_GRABA_RELACION_DERIVADO_ESTUDIO(ID_PER, ID_USER, Item)
        Next

        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_GRABA_RELACION_TP_MUESTRA_SANGRE_ESTUDIO(ByVal ID_PER As Integer, ByVal ID_USER As Integer, ByVal ARRAY_ As List(Of Integer)) As Integer
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As Integer = 0
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_BUSCA_TP_MUESTRA = New N_IRIS_WEBF_BUSCA_TP_MUESTRA


        For Each Item As Integer In ARRAY_

            numerin = NN.IRIS_GRABA_RELACION_TP_MUESTRA_SANGRE_ESTUDIO(ID_PER, ID_USER, Item)
        Next

        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_GRABA_RELACION_ANALIZADOR_ESTUDIO(ByVal ID_PER As Integer, ByVal ID_USER As Integer, ByVal ARRAY_ As List(Of Integer)) As Integer
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As Integer = 0
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_BUSCA_TP_MUESTRA = New N_IRIS_WEBF_BUSCA_TP_MUESTRA


        For Each Item As Integer In ARRAY_

            numerin = NN.IRIS_GRABA_RELACION_ANALIZADOR_ESTUDIO(ID_PER, ID_USER, Item)
        Next

        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_UPDATE_REL_METODO_ESTUDIO_QUITAR_RELACION(ByVal ARRAY_ As List(Of Integer)) As Integer
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As Integer = 0
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_BUSCA_METODO = New N_IRIS_WEBF_BUSCA_METODO


        For Each Item As Integer In ARRAY_

            numerin = NN.IRIS_WEBF_UPDATE_REL_METODO_ESTUDIO_QUITAR_RELACION(Item)
        Next

        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_UPDATE_REL_DERIVADO_ESTUDIO_QUITAR_RELACION(ByVal ARRAY_ As List(Of Integer)) As Integer
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As Integer = 0
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_BUSCA_DERIVADOS = New N_IRIS_WEBF_BUSCA_DERIVADOS


        For Each Item As Integer In ARRAY_

            numerin = NN.IRIS_WEBF_UPDATE_REL_DERIVADO_ESTUDIO_QUITAR_RELACION(Item)
        Next

        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_UPDATE_REL_TP_DE_MUESTRA_SANGRE_ESTUDIO_QUITAR_RELACION(ByVal ARRAY_ As List(Of Integer)) As Integer
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As Integer = 0
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_BUSCA_TP_MUESTRA = New N_IRIS_WEBF_BUSCA_TP_MUESTRA


        For Each Item As Integer In ARRAY_

            numerin = NN.IRIS_WEBF_UPDATE_REL_TP_DE_MUESTRA_SANGRE_ESTUDIO_QUITAR_RELACION(Item)
        Next

        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_UPDATE_REL_ANALIZADOR_QUITAR_RELACION(ByVal ARRAY_ As List(Of Integer)) As Integer
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As Integer = 0
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim NN As N_IRIS_WEBF_BUSCA_TP_MUESTRA = New N_IRIS_WEBF_BUSCA_TP_MUESTRA


        For Each Item As Integer In ARRAY_

            numerin = NN.IRIS_WEBF_UPDATE_REL_ANALIZADOR_QUITAR_RELACION(Item)
        Next

        Return datas
    End Function

End Class