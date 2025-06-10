Imports System
Imports System.Collections.Generic
Imports System.Runtime.Remoting
Imports System.Text
Imports Entidades
Imports Negocio
Imports System.Web
Imports System.IO
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Imports System.Security.Cryptography
Imports System.Diagnostics

Public Class Traza_Env_RecepLab_V2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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
    Public Shared Function Llenar_Ddl_Seccion() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Seccion As New N_IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO
        Dim Data_Seccion As New List(Of E_IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO)

        Data_Seccion = NN_Seccion.IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO()
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
    Public Shared Function DDL_TIPO_RECHAZO_ACTIVOS() As List(Of E_IRIS_WEBF_BUSCA_TIPO_RECHAZO_ACTIVOS)

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        Dim data_rechazo_activo As List(Of E_IRIS_WEBF_BUSCA_TIPO_RECHAZO_ACTIVOS)
        Dim NN_rechazo_activos As N_IRIS_WEBF_BUSCA_TIPO_RECHAZO_ACTIVOS = New N_IRIS_WEBF_BUSCA_TIPO_RECHAZO_ACTIVOS

        data_rechazo_activo = NN_rechazo_activos.IRIS_WEBF_BUSCA_TIPO_RECHAZO_ACTIVOS()

        If data_rechazo_activo.Count > 0 Then
            Return data_rechazo_activo
        Else
            Return Nothing
        End If



    End Function


    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(TIPO As Integer,
                                            DESDE As String,
                                            HASTA As String,
                                            ID_PROCEDENCIA As Integer,
                                            ID_ENVIO As Integer) As Object
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim Data_Validado As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO)
        Dim NN As New N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO

        Dim data_busca_estado_ate_trazabi_traza As New List(Of E_IRIS_WEBF_BUSCA_ESTADO_ATENCION_TRAZABILIDAD_TRAZA_NUEVO_222)
        Dim NN_busca_estado_ate_trazabi_traza As New N_IRIS_WEBF_BUSCA_ESTADO_ATENCION_TRAZABILIDAD_TRAZA_NUEVO_222

        Dim file_name As String = "/logggggggg.txt"
        Dim obj_log As N_Log

        obj_log = New N_Log
        obj_log.Path = file_name

        Dim idate As String = ""

        Dim NAte As Integer = 0
        Dim NExa As Integer = 0
        Dim recSi As Integer = 0
        Dim recNo As Integer = 0
        Dim valiSi As Integer = 0
        Dim valiNo As Integer = 0
        Dim total As Integer = 0
        Dim rechSi As Integer = 0
        Dim rechNo As Integer = 0

        Try
            Data_Validado = NN.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO_666_FECHAS_ENVIO_Y_RECEP_LAB2(TIPO, CDate(DESDE), CDate(HASTA), ID_ENVIO, ID_PROCEDENCIA)
            If (Data_Validado.Count > 0) Then
                idate = Data_Validado(0).ID_ATENCION
                NAte = 1
                For y = 0 To Data_Validado.Count - 1
                    If Data_Validado(y).ATE_EST_RECEP = 9 Then
                        recSi += 1
                    Else
                        recNo += 1
                    End If

                    NExa += 1
                    total += 1

                    If idate = Data_Validado(y).ID_ATENCION Then
                        idate = idate
                    Else
                        NAte += 1
                        idate = Data_Validado(y).ID_ATENCION
                    End If

                    'If Data_Validado(y).ATE_DET_V_ID_ESTADO = 6 Or Data_Validado(y).ATE_DET_V_ID_ESTADO = 14 Then
                    '    valiSi += 1
                    'Else
                    '    valiNo += 1
                    'End If

                    'data_busca_estado_ate_trazabi_traza = NN_busca_estado_ate_trazabi_traza.IRIS_WEBF_BUSCA_ESTADO_ATENCION_TRAZABILIDAD_TRAZA_NUEVO_222_2(Data_Validado(y).ID_ATENCION, Data_Validado(y).ID_PER, Data_Validado(y).CB_DESC)
                    'If data_busca_estado_ate_trazabi_traza.Count > 0 Then
                    '    If data_busca_estado_ate_trazabi_traza(0).ATE_EST_RECEP = 9 Then
                    '        Data_Validado(y).ATE_EST_RECEP_DESC = "SI"
                    '        Data_Validado(y).ATE_USU_RECEP = data_busca_estado_ate_trazabi_traza(0).URECEP
                    '        Data_Validado(y).ATE_FEC_RECEP = data_busca_estado_ate_trazabi_traza(0).ATE_FEC_RECEP
                    '    End If
                    '    If data_busca_estado_ate_trazabi_traza(0).ATE_EST_ENVIO = 5 Then
                    '        Data_Validado(y).ATE_EST_ENVIO_DESC = "SI"
                    '        Data_Validado(y).UENVIO = data_busca_estado_ate_trazabi_traza(0).UENVIO
                    '        Data_Validado(y).ATE_FEC_ENVIO = data_busca_estado_ate_trazabi_traza(0).ATE_FEC_ENVIO

                    '        Data_Validado(y).ENVIO_FECHA_RECEP = data_busca_estado_ate_trazabi_traza(0).ENVIO_FECHA_RECEP
                    '        Data_Validado(y).ID_USUARIO_RECEP = data_busca_estado_ate_trazabi_traza(0).ID_USUARIO_RECEP
                    '        Data_Validado(y).ID_ESTADO_RECEP = data_busca_estado_ate_trazabi_traza(0).ID_ESTADO_RECEP
                    '        Data_Validado(y).USUARIO_ENV_RECEP = data_busca_estado_ate_trazabi_traza(0).USUARIO_ENV_RECEP

                    '        rechSi += 1
                    '    Else
                    '        rechNo += 1
                    '    End If

                    'End If

                    Data_Validado(0).NAte = NAte
                    Data_Validado(0).NExa = NExa
                    Data_Validado(0).recSi = recSi
                    Data_Validado(0).recNo = recNo
                    Data_Validado(0).valiSi = valiSi
                    Data_Validado(0).valiNo = valiNo
                    Data_Validado(0).rechSi = rechSi
                    Data_Validado(0).rechNo = rechNo
                    Data_Validado(0).total = total

                Next y
                Data_Validado(0).rechSi = Data_Validado.Where(Function(x) x.ATE_EST_ENVIO_DESC = 5).Count()
                Data_Validado(0).rechNo = Data_Validado.Where(Function(x) x.ATE_EST_ENVIO_DESC <> 5).Count()

                Return Data_Validado
                'Serializar con JSON
                Serializer.MaxJsonLength = 999999999
                Serializer.Serialize(Data_Validado, str_Builder)
                Return str_Builder.ToString
            Else
                Return "null"
            End If
        Catch ex As Exception
            obj_log.Write_ERROR(ex)
        End Try


        Return "null"




    End Function


    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable_id_ate(TIPO As Integer,
                                            DESDE As String,
                                            HASTA As String,
                                            ID_PROCEDENCIA As Integer,
                                            ID_ENVIO As Integer, ID_ATENCION As String) As Object
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim Data_Validado As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO)
        Dim NN As New N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO

        Dim data_tipo_rechazo As New List(Of E_IRIS_WEBF_BUSCA_RECEPCION_RECHAZO_TIPO_RECHAZO)
        Dim NN_tipo_rechazo As New N_IRIS_WEBF_BUSCA_RECEPCION_RECHAZO_TIPO_RECHAZO

        Dim data_tipo_rechazo_por_tipo As New List(Of E_IRIS_WEBF_BUSCA_RECEPCION_RECHAZO_TIPO_RECHAZO_POR_TIPO)
        Dim NN_tipo_rechazo_por_tipo As New N_IRIS_WEBF_BUSCA_RECEPCION_RECHAZO_TIPO_RECHAZO_POR_TIPO

        Dim data_busca_agen_por_id_ate_det_logo As New List(Of E_IRIS_WEBF_BUSCA_AGENDA_POR_ID_ATENCION_DETALLE_LOGO)
        Dim NN_busca_agen_por_id_ate_det_logo As New N_IRIS_WEBF_BUSCA_AGENDA_POR_ID_ATENCION_DETALLE_LOGO

        Dim data_busca_ate_para_log_por_id_ate As New List(Of E_IRIS_WEBF_BUSCA_ATENCIONES_PARA_LOG_POR_ID_ATE)
        Dim NN_busca_ate_para_log_por_id_ate = New N_IRIS_WEBF_BUSCA_ATENCIONES_PARA_LOG_POR_ID_ATE

        Dim data_busca_estado_ate_trazabi_traza As New List(Of E_IRIS_WEBF_BUSCA_ESTADO_ATENCION_TRAZABILIDAD_TRAZA_NUEVO_222)
        Dim NN_busca_estado_ate_trazabi_traza As New N_IRIS_WEBF_BUSCA_ESTADO_ATENCION_TRAZABILIDAD_TRAZA_NUEVO_222

        Dim file_name As String = "/logggggggg.txt"
        Dim obj_log As N_Log

        obj_log = New N_Log
        obj_log.Path = file_name

        Dim idate As String = ""

        Dim NAte As Integer = 0
        Dim NExa As Integer = 0
        Dim recSi As Integer = 0
        Dim recNo As Integer = 0
        Dim tmSi As Integer = 0
        Dim tmNo As Integer = 0
        Dim valiSi As Integer = 0
        Dim valiNo As Integer = 0
        Dim total As Integer = 0
        Dim rechSi As Integer = 0
        Dim rechNo As Integer = 0
        Dim id_Ate_decoded = (New N_Encrypt).Decode(CStr(ID_ATENCION))
        Debug.WriteLine($"Id Ate: {id_Ate_decoded}")
        Try
            Data_Validado = NN.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO_666_FECHAS_ENVIO_Y_RECEP_LAB_id_ate2(CDate(DESDE), CDate(HASTA), id_Ate_decoded, ID_PROCEDENCIA)
            If (Data_Validado.Count = 0) Then
                Return Data_Validado
            End If


            Data_Validado(0).total = Data_Validado.Count

            Data_Validado(0).NAte = Data_Validado.GroupBy(Function(x) New With {x.ID_ATENCION}).Count()
            Data_Validado(0).NExa = Data_Validado.GroupBy(Function(x) New With {x.ID_ATENCION, x.ID_CODIGO_FONASA}).Count()

            Data_Validado(0).recSi = Data_Validado.Where(Function(x) x.ATE_EST_RECEP = 9).Count()
            Data_Validado(0).recNo = Data_Validado.Where(Function(x) x.ATE_EST_RECEP <> 9).Count()

            Data_Validado(0).tmSi = Data_Validado.Where(Function(x) x.ATE_EST_TM = 8).Count()
            Data_Validado(0).tmNo = Data_Validado.Where(Function(x) x.ATE_EST_TM <> 8).Count()

            Data_Validado(0).valiSi = Data_Validado.Where(Function(x) x.ATE_EST_VALIDA = 6 Or x.ATE_EST_VALIDA = 14).Count()
            Data_Validado(0).valiNo = Data_Validado.Where(Function(x) x.ATE_EST_VALIDA <> 6 And x.ATE_EST_VALIDA <> 14).Count()

            Data_Validado(0).rechSi = Data_Validado.Where(Function(x) x.ATE_EST_ENVIO_DESC = 5).Count() ' este es el envio y se guarda en rech por la zorraaaaaaaaa
            Data_Validado(0).rechNo = Data_Validado.Where(Function(x) x.ATE_EST_ENVIO_DESC <> 5).Count()


            Return Data_Validado


        Catch ex As Exception
            obj_log.Write_ERROR(ex)

        End Try



        Return Data_Validado



    End Function

    '<Services.WebMethod()>
    'Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String,
    '                         ID_PROCEDENCIA As Integer) As String
    '    'Declaraciones del Serializador
    '    Dim str_Builder As New StringBuilder
    '    Dim datas As String = ""
    '    Dim Str_Out As String = ""

    '    'Declaraciones internas

    '    Dim NN_Excel As New N_Excel
    '    Dim titulo_bol As String = ""
    '    Dim tipo_fecha As String = ""
    '    Dim NN As New N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO
    '    Dim Data_LugarTM As New List(Of E_IRIS_WEBF_BUSCA_USUARIO_POR_ID)
    '    Dim NN_BOL_LOG As New N_IRIS_WEBF_BUSCA_DATOS_BOLETA_ELECTRONICA
    '    Dim Data_Validado As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO)
    '    'Data_LugarTM = NN_USER.IRIS_WEBF_BUSCA_USUARIO_POR_ID(ID_USUARIO)
    '    Dim ltabla As Integer = 0
    '    'creamos el objeto SLDocument el cual creara el excel
    '    Dim sl As SLDocument = New SLDocument
    '    Dim tabla As SLTable
    '    Dim estilo As SLStyle
    '    Dim estilo2 As SLStyle
    '    Dim estilo_celda_num As SLStyle
    '    Dim estilo_celda_bol As SLStyle

    '    Dim Excel_x As Integer
    '    Dim Excel_y As Integer

    '    Dim End_Column As Integer
    '    Dim End_Column_Table As String

    '    Dim estilo_celda_moneda As SLStyle
    '    estilo_celda_moneda = sl.CreateStyle()
    '    estilo_celda_moneda.FormatCode = "#,##0_);_(#,##0)" ' Establece el formato de moneda para pesos chilenos
    '    estilo_celda_moneda.SetHorizontalAlignment(HorizontalAlign.Left)

    '    Excel_x = 1
    '    Excel_y = 9

    '    End_Column = 10
    '    End_Column_Table = "AG"
    '    sl.SetCellValue("B2", "Listado de Resultados por Determinaciones")
    '    sl.SetCellValue("B4", "Desde: " & DESDE)
    '    sl.SetCellValue("B5", "Hasta " & HASTA)

    '    sl.SetCellValue("A8", "#")
    '    sl.SetCellValue("B8", "N° Atención")
    '    sl.SetCellValue("C8", "Rut Paciente")
    '    sl.SetCellValue("D8", "Nombre Paciente")
    '    sl.SetCellValue("E8", "Edad")
    '    sl.SetCellValue("F8", "Fecha Ate.")
    '    sl.SetCellValue("G8", "Hora Ate.")
    '    sl.SetCellValue("H8", "Lugar de TM")
    '    sl.SetCellValue("I8", "Sexo")
    '    sl.SetCellValue("J8", "Examen")
    '    sl.SetCellValue("K8", "Tipo Etiqueta")
    '    sl.SetCellValue("L8", "CB")
    '    sl.SetCellValue("M8", "TdeM")
    '    sl.SetCellValue("N8", "Usu TdeM")
    '    sl.SetCellValue("O8", "Fecha TdeM")
    '    sl.SetCellValue("P8", "Envío")
    '    sl.SetCellValue("Q8", "Usuario")
    '    sl.SetCellValue("R8", "Fecha Envio")
    '    sl.SetCellValue("S8", "Recepción")
    '    sl.SetCellValue("T8", "Usuario")
    '    sl.SetCellValue("U8", "Fecha Recep.")
    '    sl.SetCellValue("V8", "Validado")
    '    sl.SetCellValue("W8", "Usu. Valida")
    '    sl.SetCellValue("X8", "Fecha Valida")
    '    sl.SetCellValue("Y8", "Derivado")
    '    sl.SetCellValue("Z8", "Usu Deriva")
    '    sl.SetCellValue("AA8", "Fecha Deriva")
    '    sl.SetCellValue("AB8", "Rechazo")
    '    sl.SetCellValue("AC8", "Usu Rechazo")
    '    sl.SetCellValue("AD8", "Fecha Rechazo")
    '    sl.SetCellValue("AE8", "Estado Exam")
    '    sl.SetCellValue("AF8", "Fecha Exam")
    '    sl.SetCellValue("AG8", "Usuario Exam")


    '    estilo_celda_num = sl.CreateStyle()
    '    estilo_celda_num.Font.Bold = True
    '    estilo_celda_num.SetHorizontalAlignment(HorizontalAlign.Center)

    '    estilo_celda_bol = sl.CreateStyle()
    '    estilo_celda_bol.Font.Bold = True
    '    estilo_celda_bol.SetHorizontalAlignment(HorizontalAlign.Center)
    '    estilo_celda_bol.Font.FontColor = System.Drawing.Color.Red

    '    Data_Validado = NN.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO_666_FECHAS_ENVIO_Y_RECEP_LAB_id_ate2(CDate(DESDE), CDate(HASTA), 0, ID_PROCEDENCIA)

    '    If (Data_Validado.Count > 0) Then
    '        For i = 0 To Data_Validado.Count - 1
    '            Dim col_actual As Integer = 1 ' Inicializa la columna en la que comenzarás a escribir

    '            ' CELDA NUM
    '            sl.SetCellValue(i + 9, col_actual, i + 1)
    '            sl.SetCellStyle(i + 9, col_actual, estilo_celda_num) : col_actual += 1

    '            ' CELDA ATENCION NUMERO
    '            Dim atencionNumero As Integer = If(Data_Validado(i).ATE_NUM = 0, 0, Data_Validado(i).ATE_NUM)
    '            sl.SetCellValue(i + 9, col_actual, atencionNumero) : col_actual += 1

    '            ' CELDA RUT
    '            sl.SetCellValue(i + 9, col_actual, If(String.IsNullOrEmpty(Data_Validado(i).PAC_RUT), "-", Data_Validado(i).PAC_RUT)) : col_actual += 1

    '            ' CELDA NOMBRE COMPLETO PACIENTE
    '            sl.SetCellValue(i + 9, col_actual, $"{Data_Validado(i).PAC_NOMBRE} {Data_Validado(i).PAC_APELLIDO}") : col_actual += 1

    '            ' CELDA EDAD PACIENTE
    '            sl.SetCellValue(i + 9, col_actual, If(Data_Validado(i).ATE_AÑO = 0, "-", $"{Data_Validado(i).ATE_AÑO} Año(s)")) : col_actual += 1

    '            ' CELDA FECHA ATENCION
    '            sl.SetCellValue(i + 9, col_actual, If(Data_Validado(i).ATE_FECHA = DateTime.MinValue, "-", Data_Validado(i).ATE_FECHA.ToString("yyyy-MM-dd"))) : col_actual += 1

    '            ' CELDA HORA ATENCION
    '            sl.SetCellValue(i + 9, col_actual, If(Data_Validado(i).ATE_FECHA = DateTime.MinValue, "-", Data_Validado(i).ATE_FECHA.ToString("HH:mm:ss"))) : col_actual += 1

    '            ' CELDA LUGAR TM
    '            sl.SetCellValue(i + 9, col_actual, If(Data_Validado(i).PROC_DESC Is Nothing, "-", Data_Validado(i).PROC_DESC)) : col_actual += 1

    '            ' CELDA SEXO
    '            Dim sexo As String
    '            If Data_Validado(i).ID_SEXO = 2 Then
    '                sexo = "Femenino"
    '            ElseIf Data_Validado(i).ID_SEXO = 1 Then
    '                sexo = "Masculino"
    '            Else
    '                sexo = "-"
    '            End If
    '            sl.SetCellValue(i + 9, col_actual, sexo) : col_actual += 1

    '            ' CELDA EXAMEN
    '            sl.SetCellValue(i + 9, col_actual, If(Data_Validado(i).CF_DESC Is Nothing, "-", Data_Validado(i).CF_DESC)) : col_actual += 1

    '            ' CELDA TIPO ETIQUETA
    '            sl.SetCellValue(i + 9, col_actual, If(Data_Validado(i).T_MUESTRA_DESC Is Nothing, "-", Data_Validado(i).T_MUESTRA_DESC)) : col_actual += 1

    '            ' CELDA CÓDIGO BARRA
    '            Dim cb_desc As Integer = If(Data_Validado(i).CB_DESC = 0, 0, Data_Validado(i).CB_DESC)
    '            sl.SetCellValue(i + 9, col_actual, cb_desc) : col_actual += 1

    '            ' CELDA TOMA DE MUESTRA
    '            sl.SetCellValue(i + 9, col_actual, If(Data_Validado(i).ATE_EST_TM_DESC Is Nothing, "-", Data_Validado(i).ATE_EST_TM_DESC)) : col_actual += 1

    '            ' CELDA USU TM
    '            sl.SetCellValue(i + 9, col_actual, If(Data_Validado(i).ATE_USU_TM Is Nothing, "-", Data_Validado(i).ATE_USU_TM)) : col_actual += 1

    '            ' CELDA FECHA TM
    '            sl.SetCellValue(i + 9, col_actual, If(Data_Validado(i).ATE_FEC_TM.ToString("HH:mm:ss") = "00:00:00", "-", Data_Validado(i).ATE_FEC_TM.ToString("yyyy-MM-dd HH:mm:ss"))) : col_actual += 1

    '            ' CELDA ENVÍO
    '            sl.SetCellValue(i + 9, col_actual, If(Data_Validado(i).ATE_EST_ENVIO_DESC Is Nothing, "-", Data_Validado(i).ATE_EST_ENVIO_DESC)) : col_actual += 1

    '            ' CELDA USUARIO ENVÍO
    '            sl.SetCellValue(i + 9, col_actual, If(Data_Validado(i).UENVIO Is Nothing, "-", Data_Validado(i).UENVIO)) : col_actual += 1

    '            ' CELDA FECHA ENVÍO
    '            sl.SetCellValue(i + 9, col_actual, If(Data_Validado(i).ATE_FEC_ENVIO.ToString("HH:mm:ss") = "00:00:00", "-", Data_Validado(i).ATE_FEC_ENVIO.ToString("yyyy-MM-dd HH:mm:ss"))) : col_actual += 1

    '            ' CELDA RECEPCIÓN
    '            sl.SetCellValue(i + 9, col_actual, If(Data_Validado(i).ATE_EST_RECEP_DESC Is Nothing, "-", Data_Validado(i).ATE_EST_RECEP_DESC)) : col_actual += 1

    '            ' CELDA USUARIO RECEPCIÓN
    '            sl.SetCellValue(i + 9, col_actual, If(Data_Validado(i).ATE_USU_RECEP Is Nothing, "-", Data_Validado(i).ATE_USU_RECEP)) : col_actual += 1

    '            ' CELDA FECHA RECEPCIÓN
    '            sl.SetCellValue(i + 9, col_actual, If(Data_Validado(i).ATE_FEC_RECEP.ToString("HH:mm:ss") = "00:00:00", "-", Data_Validado(i).ATE_FEC_RECEP.ToString("yyyy-MM-dd HH:mm:ss"))) : col_actual += 1

    '            ' CELDA ESTADO VALIDADO
    '            sl.SetCellValue(i + 9, col_actual, If(Data_Validado(i).ATE_EST_VALIDA_DESC Is Nothing, "-", Data_Validado(i).ATE_EST_VALIDA_DESC)) : col_actual += 1

    '            ' CELDA USUARIO VALIDA
    '            sl.SetCellValue(i + 9, col_actual, If(Data_Validado(i).ATE_USU_VALIDA Is Nothing, "-", Data_Validado(i).ATE_USU_VALIDA)) : col_actual += 1

    '            ' CELDA FECHA VALIDADO
    '            sl.SetCellValue(i + 9, col_actual, If(Data_Validado(i).ATE_FEC_VALIDA.ToString("HH:mm:ss") = "00:00:00", "-", Data_Validado(i).ATE_FEC_VALIDA.ToString("yyyy-MM-dd HH:mm:ss"))) : col_actual += 1

    '            ' CELDA ESTADO DERIVADO
    '            sl.SetCellValue(i + 9, col_actual, If(Data_Validado(i).ATE_EST_DERIVA_DESC Is Nothing, "-", Data_Validado(i).ATE_EST_DERIVA_DESC)) : col_actual += 1

    '            ' CELDA USUARIO DERIVADO
    '            sl.SetCellValue(i + 9, col_actual, If(Data_Validado(i).USUARIO_DERI Is Nothing, "-", Data_Validado(i).USUARIO_DERI)) : col_actual += 1

    '            ' CELDA FECHA DERIVADO
    '            sl.SetCellValue(i + 9, col_actual, If(Data_Validado(i).ATE_FEC_DERIVA.ToString("HH:mm:ss") = "00:00:00", "-", Data_Validado(i).ATE_FEC_DERIVA.ToString("yyyy-MM-dd HH:mm:ss"))) : col_actual += 1

    '            ' CELDA ESTADO RECHAZO
    '            sl.SetCellValue(i + 9, col_actual, If(Data_Validado(i).ATE_EST_RECHAZO_DESC Is Nothing, "-", Data_Validado(i).ATE_EST_RECHAZO_DESC)) : col_actual += 1

    '            ' CELDA USUARIO RECHAZO
    '            sl.SetCellValue(i + 9, col_actual, If(Data_Validado(i).USUARIO_RECH Is Nothing, "-", Data_Validado(i).USUARIO_RECH)) : col_actual += 1

    '            ' CELDA FECHA RECHAZO
    '            sl.SetCellValue(i + 9, col_actual, If(Data_Validado(i).ATE_FEC_RECHAZO.ToString("HH:mm:ss") = "00:00:00", "-", Data_Validado(i).ATE_FEC_RECHAZO.ToString("yyyy-MM-dd HH:mm:ss"))) : col_actual += 1

    '            ' CELDA TIPO HISTORIA ATENCION
    '            sl.SetCellValue(i + 9, col_actual, If(Data_Validado(i).TP_HIS_ATE_DESC Is Nothing, "-", Data_Validado(i).TP_HIS_ATE_DESC)) : col_actual += 1

    '            ' CELDA HISTORIA ATENCION FECHA
    '            sl.SetCellValue(i + 9, col_actual, If(Data_Validado(i).HISTO_ATE_FECHA Is Nothing, "-", Data_Validado(i).HISTO_ATE_FECHA)) : col_actual += 1

    '            ' CELDA USUARIO EXAMINADOR
    '            sl.SetCellValue(i + 9, col_actual, If(Data_Validado(i).USUARIO_EX Is Nothing, "-", Data_Validado(i).USUARIO_EX))
    '            ltabla += 1
    '        Next
    '    End If

    '    'Nombrar hoja
    '    sl.RenameWorksheet("Sheet1", "Listado de Resultados por Determinaciones")

    '    sl.AutoFitColumn(2, End_Column, 20)
    '    For y = 2 To End_Column
    '        sl.SetColumnWidth(y, sl.GetColumnWidth(y) + 3)
    '    Next y

    '    ltabla += 8
    '    'Estilos
    '    estilo = sl.CreateStyle()
    '    estilo.Font.FontName = "Arial"
    '    estilo.Font.FontSize = 20
    '    estilo.Font.Bold = True
    '    estilo.Alignment.Horizontal = HorizontalAlign.Center
    '    estilo.Alignment.Vertical = VerticalAlign.Middle

    '    estilo2 = sl.CreateStyle()
    '    estilo2.Font.Bold = True
    '    estilo2.Alignment.Horizontal = HorizontalAlign.Center
    '    estilo2.Alignment.Vertical = VerticalAlign.Middle

    '    sl.SetCellStyle("C2", estilo)
    '    sl.SetCellStyle("C7", estilo2)



    '    sl.SetCellStyle("I7", estilo2)
    '    sl.SetCellStyle("K7", estilo2)
    '    sl.SetCellStyle("H7", estilo2)


    '    'insertar tabla
    '    tabla = sl.CreateTable("A8", CStr(End_Column_Table & ltabla))
    '    tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
    '    sl.InsertTable(tabla)

    '    Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
    '    Dim Relative_Path As String = "Trazabilidad_por_Envio_Recepcion_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".xlsx"
    '    sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
    '    'Devolver la url del archivo generado
    '    Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    'End Function

    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal DESDE As String, ByVal HASTA As String,
                             ID_PROCEDENCIA As Integer) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""
        ' Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO
        Dim Data_Validado As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO)
        'creamos el objeto SLDocument el cual creara el excel
        Dim sl As SLDocument = New SLDocument
        Dim tabla As SLTable
        Dim estilo As SLStyle
        Dim estilo2 As SLStyle
        Dim estilo3 As SLStyle
        Dim estilo4 As SLStyle
        Dim Excel_x As Integer
        Dim Excel_y As Integer
        Excel_x = 1
        Excel_y = 9
        Dim ltabla As Integer = 0

        estilo4 = sl.CreateStyle()
        estilo4.SetWrapText(True)

        Data_Validado = NN.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO_666_FECHAS_ENVIO_Y_RECEP_LAB_id_ate2(CDate(DESDE), CDate(HASTA), 0, ID_PROCEDENCIA)

        If (Data_Validado.Count > 0) Then
            Dim Mx_Data(32, Data_Validado.Count - 1) As Object

            'Llenar Matriz
            For y = 0 To Data_Validado.Count - 1
                Mx_Data(0, y) = y + 1 '#
                Mx_Data(1, y) = If(Data_Validado(y).ATE_NUM = 0, "-", Data_Validado(y).ATE_NUM.ToString()) ' n° atención
                Mx_Data(2, y) = If(Data_Validado(y).PAC_RUT = "", "-", Data_Validado(y).PAC_RUT) ' rut
                Mx_Data(3, y) = $"{Data_Validado(y).PAC_NOMBRE} {Data_Validado(y).PAC_APELLIDO}" 'nombre comp paciente
                Mx_Data(4, y) = If(Data_Validado(y).ATE_AÑO = 0, "-", $"{Data_Validado(y).ATE_AÑO} Año(s)") ' edad paciente
                Mx_Data(5, y) = If(Data_Validado(y).ATE_FECHA = DateTime.MinValue, "-", Data_Validado(y).ATE_FECHA.ToString("yyyy-MM-dd")) ' fecha ate
                Mx_Data(6, y) = If(Data_Validado(y).ATE_FECHA = DateTime.MinValue, "-", Data_Validado(y).ATE_FECHA.ToString("HH:mm:ss")) ' hora ate



                Mx_Data(7, y) = If(Data_Validado(y).PROC_DESC Is Nothing, "-", Data_Validado(y).PROC_DESC) ' lugar tm
                Dim sexo As String

                If Data_Validado(y).ID_SEXO = 2 Then
                    sexo = "Femenino"
                ElseIf Data_Validado(y).ID_SEXO = 1 Then
                    sexo = "Masculino"
                Else
                    sexo = "-"
                End If

                Mx_Data(8, y) = sexo
                Mx_Data(9, y) = If(Data_Validado(y).CF_DESC Is Nothing, "-", Data_Validado(y).CF_DESC) ' examen
                Mx_Data(10, y) = If(Data_Validado(y).T_MUESTRA_DESC Is Nothing, "-", Data_Validado(y).T_MUESTRA_DESC) ' tipo etiqueta
                Mx_Data(11, y) = If(Data_Validado(y).CB_DESC Is Nothing, "-", Data_Validado(y).CB_DESC) ' cb codigo barra
                Mx_Data(12, y) = If(Data_Validado(y).ATE_EST_TM_DESC Is Nothing, "-", Data_Validado(y).ATE_EST_TM_DESC) ' toma de muestra
                Mx_Data(13, y) = If(Data_Validado(y).ATE_USU_TM Is Nothing, "-", Data_Validado(y).ATE_USU_TM) ' usu tm
                Mx_Data(14, y) = If(Data_Validado(y).ATE_FEC_TM.ToString("HH:mm:ss") = "00:00:00", "-", Data_Validado(y).ATE_FEC_TM.ToString("yyyy-MM-dd HH:mm:ss")) ' Fecha tm
                Mx_Data(15, y) = If(Data_Validado(y).ATE_EST_ENVIO_DESC Is Nothing, "-", Data_Validado(y).ATE_EST_ENVIO_DESC) ' envio
                Mx_Data(16, y) = If(Data_Validado(y).UENVIO Is Nothing, "-", Data_Validado(y).UENVIO) ' usuario envio
                Mx_Data(17, y) = If(Data_Validado(y).ATE_FEC_ENVIO.ToString("HH:mm:ss") = "00:00:00", "-", Data_Validado(y).ATE_FEC_ENVIO.ToString("yyyy-MM-dd HH:mm:ss")) ' fecha envio
                Mx_Data(18, y) = If(Data_Validado(y).ATE_EST_RECEP_DESC Is Nothing, "-", Data_Validado(y).ATE_EST_RECEP_DESC) ' recepción
                Mx_Data(19, y) = If(Data_Validado(y).ATE_USU_RECEP Is Nothing, "-", Data_Validado(y).ATE_USU_RECEP) ' usuario env
                Mx_Data(20, y) = If(Data_Validado(y).ATE_FEC_RECEP.ToString("HH:mm:ss") = "00:00:00", "-", Data_Validado(y).ATE_FEC_RECEP.ToString("yyyy-MM-dd HH:mm:ss")) ' ate fecha recep
                Mx_Data(21, y) = If(Data_Validado(y).ATE_EST_VALIDA_DESC Is Nothing, "-", Data_Validado(y).ATE_EST_VALIDA_DESC)
                Mx_Data(22, y) = If(Data_Validado(y).ATE_USU_VALIDA Is Nothing, "-", Data_Validado(y).ATE_USU_VALIDA)
                Mx_Data(23, y) = If(Data_Validado(y).ATE_FEC_VALIDA.ToString("HH:mm:ss") = "00:00:00", "-", Data_Validado(y).ATE_FEC_VALIDA.ToString("yyyy-MM-dd HH:mm:ss"))
                Mx_Data(24, y) = If(Data_Validado(y).ATE_EST_DERIVA_DESC Is Nothing, "-", Data_Validado(y).ATE_EST_DERIVA_DESC)
                Mx_Data(25, y) = If(Data_Validado(y).USUARIO_DERI Is Nothing, "-", Data_Validado(y).USUARIO_DERI)
                Mx_Data(26, y) = If(Data_Validado(y).ATE_FEC_DERIVA.ToString("HH:mm:ss") = "00:00:00", "-", Data_Validado(y).ATE_FEC_DERIVA.ToString("yyyy-MM-dd HH:mm:ss"))
                Mx_Data(27, y) = If(Data_Validado(y).ATE_EST_RECHAZO_DESC Is Nothing, "-", Data_Validado(y).ATE_EST_RECHAZO_DESC)
                Mx_Data(28, y) = If(Data_Validado(y).USUARIO_RECH Is Nothing, "-", Data_Validado(y).USUARIO_RECH)
                Mx_Data(29, y) = If(Data_Validado(y).ATE_FEC_RECHAZO.ToString("HH:mm:ss") = "00:00:00", "-", Data_Validado(y).ATE_FEC_RECHAZO.ToString("yyyy-MM-dd HH:mm:ss"))
                Mx_Data(30, y) = If(Data_Validado(y).ID_TP_HIS_ATENCION = 0, 
                                    "-", 
                                    If(Data_Validado(y).ID_TP_HIS_ATENCION = 3, 
                                       "EXA AGREGADO", 
                                       "EXA ELIMINADO"))

                Mx_Data(31, y) = If(Data_Validado(y).HISTO_ATE_FECHA Is Nothing, "-", Data_Validado(y).HISTO_ATE_FECHA)
                Mx_Data(32, y) = If(Data_Validado(y).USUARIO_EX Is Nothing, "-", Data_Validado(y).USUARIO_EX)
            Next

            sl.SetCellStyle(9, 1, Data_Validado.Count + 8, 32, estilo4)

            sl.SetColumnWidth(5, 32, 15)
            sl.SetColumnWidth(33, 33, 15)
            sl.SetColumnWidth(4, 4, 28)
            ''nombrar hoja 
            'sl.SelectWorksheet("Sheet1")
            'sl.RenameWorksheet("Sheet1", "Listado de Resultados por Determinaciones")
            'titulo de la tabla
            sl.SetCellValue("B2", "Listado de Resultados por Determinaciones")
            sl.SetCellValue("B4", "Desde: " & DESDE)
            sl.SetCellValue("B5", "Hasta " & HASTA)

            'nombre columnas
            Dim columnHeaders As String() = {"#", "N° Atención", "Rut Paciente", "Nombre Paciente", "Edad", "Fecha Ate.", "Hora Ate.",
                                         "Lugar de TM", "Sexo", "Examen", "Tipo Etiqueta", "CB", "TdeM", "Usu TdeM", "Fecha TdeM",
                                         "Envío", "Usuario", "Fecha Envio", "Recepción", "Usu Recep", "Fecha Recep.", "Validado",
                                         "Usu Valida", "Fecha Valida", "Derivado", "Usu Deriva", "Fecha Deriva", "Rechazo", "Usu Rechazo", "Fecha Rechazo",
                                         "Estado Exam", "Fecha Exam", "Usuario Exam"}

            For i As Integer = 0 To columnHeaders.Length - 1
                sl.SetCellValue(8, i + 1, columnHeaders(i))
            Next

            ' Poner datos en el Excel
            For y = 0 To Mx_Data.GetUpperBound(1)
                For x = 0 To Mx_Data.GetUpperBound(0)
                    sl.SetCellValue(y + Excel_y, x + 1, CStr(Mx_Data(x, y)))
                Next x
                ltabla += 1
            Next y
            ltabla += 8

            'Aplicar estilos
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
            sl.SetCellStyle("B4", estilo3)
            sl.SetCellStyle("B5", estilo3)

            'insertar tabla
            tabla = sl.CreateTable("A8", "AG" & ltabla)
            tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
            sl.InsertTable(tabla)

            Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
            Dim Relative_Path As String = "Trazabilidad_por_Envio_Recepcion_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".xlsx"
            sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
            'Devolver la url del archivo generado
            Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        Else
            Return "NO-DATA"
        End If
    End Function

    '<Services.WebMethod()>
    'Public Shared Function Excel(DOMAIN_URL As String,
    '                         TIPO As Integer,
    '                         DESDE As String,
    '                         HASTA As String,
    '                         ID_PROCEDENCIA As Integer,
    '                         ID_ENVIO As Integer) As String
    '    ' Declaraciones del Serializador
    '    Dim str_Builder As New StringBuilder
    '    Dim datas As String = ""
    '    Dim Str_Out As String = ""

    '    ' Declaraciones internas
    '    Dim NN As New N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO
    '    Dim Data_Validado As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO)

    '    ' Creación del objeto SLDocument que creará el Excel
    '    Dim sl As SLDocument = New SLDocument
    '    Dim tabla As SLTable
    '    Dim estilo As SLStyle
    '    Dim estilo2 As SLStyle
    '    Dim estilo3 As SLStyle
    '    Dim ltabla As Integer = 0
    '    Dim NAte As Integer = 0
    '    Dim NExa As Integer = 0
    '    Dim recSi As Integer = 0
    '    Dim recNo As Integer = 0
    '    Dim valiSi As Integer = 0
    '    Dim valiNo As Integer = 0
    '    Dim total As Integer = 0
    '    Dim rechSi As Integer = 0
    '    Dim rechNo As Integer = 0

    '    Data_Validado = NN.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO_666_FECHAS_ENVIO_Y_RECEP_LAB_id_ate2(CDate(DESDE), CDate(HASTA), 0, ID_PROCEDENCIA)

    '    If (Data_Validado.Count > 0) Then
    '        Dim idate = Data_Validado(0).ID_ATENCION
    '        NAte = 1

    '        'Data_Validado(0).total = Data_Validado.Count
    '        'Data_Validado(0).NAte = Data_Validado.GroupBy(Function(x) New With {x.ID_ATENCION}).Count()
    '        'Data_Validado(0).NExa = Data_Validado.GroupBy(Function(x) New With {x.ID_ATENCION, x.ID_CODIGO_FONASA}).Count()
    '        'Data_Validado(0).recSi = Data_Validado.Where(Function(x) x.ATE_EST_RECEP = 9).Count()
    '        'Data_Validado(0).recNo = Data_Validado.Where(Function(x) x.ATE_EST_RECEP <> 9).Count()
    '        'Data_Validado(0).tmSi = Data_Validado.Where(Function(x) x.ATE_EST_TM = 8).Count()
    '        'Data_Validado(0).tmNo = Data_Validado.Where(Function(x) x.ATE_EST_TM <> 8).Count()
    '        'Data_Validado(0).valiSi = Data_Validado.Where(Function(x) x.ATE_EST_VALIDA = 6 Or x.ATE_EST_VALIDA = 14).Count()
    '        'Data_Validado(0).valiNo = Data_Validado.Where(Function(x) x.ATE_EST_VALIDA <> 6 And x.ATE_EST_VALIDA <> 14).Count()
    '        ''Data_Validado(0).rechSi = Data_Validado.Where(Function(x) x.ATE_EST_ENVIO_DESC = 5).Count()
    '        'Data_Validado(0).rechNo = Data_Validado.Where(Function(x) x.ATE_EST_ENVIO_DESC <> 5).Count()
    '    Else
    '        Return "null"
    '    End If

    '    'sl.SetCellValue("A4", "N° Atenciones: " & NAte)
    '    'sl.SetCellValue("A6", "N° Exámenes: " & NExa)
    '    'sl.SetCellValue("C4", "Recepcionado SI: " & recSi & " / NO: " & recNo)
    '    'sl.SetCellValue("E4", "Enviado SI: " & rechSi & " / NO: " & rechNo)
    '    'sl.SetCellValue("E6", "TOTAL: " & total)

    '    ' Nombrar hoja
    '    sl.RenameWorksheet("Sheet1", "Trazabilidad por Envío - Recepción")

    '    ' Título de la tabla
    '    sl.SetCellValue("B2", "Trazabilidad por Envío - Recepción")

    '    For y = 1 To 21
    '        sl.SetColumnWidth(y, 20.0)
    '    Next y

    '    Dim primeraFila = 9
    '    Dim primeraColumna = 1
    '    Dim colAct = primeraColumna
    '    Dim filAct = primeraFila

    '    ' Nombre columnas
    '    sl.SetCellValue(filAct, colAct, "#") : colAct += 1
    '    sl.SetCellValue(filAct, colAct, "N° Atención") : colAct += 1
    '    sl.SetCellValue(filAct, colAct, "Rut Paciente") : colAct += 1
    '    sl.SetCellValue(filAct, colAct, "Nombre Paciente") : colAct += 1
    '    sl.SetCellValue(filAct, colAct, "Edad") : colAct += 1
    '    sl.SetCellValue(filAct, colAct, "Fecha") : colAct += 1
    '    sl.SetCellValue(filAct, colAct, "Hora") : colAct += 1
    '    sl.SetCellValue(filAct, colAct, "Lugar de TM") : colAct += 1
    '    sl.SetCellValue(filAct, colAct, "Sexo") : colAct += 1
    '    sl.SetCellValue(filAct, colAct, "Examen") : colAct += 1
    '    sl.SetCellValue(filAct, colAct, "Tipo de Etiqueta") : colAct += 1
    '    sl.SetCellValue(filAct, colAct, "CB") : colAct += 1
    '    sl.SetCellValue(filAct, colAct, "Enviado") : colAct += 1
    '    sl.SetCellValue(filAct, colAct, "Usuario Env.") : colAct += 1
    '    sl.SetCellValue(filAct, colAct, "Fecha Env.") : colAct += 1
    '    sl.SetCellValue(filAct, colAct, "Recepcionado") : colAct += 1
    '    sl.SetCellValue(filAct, colAct, "Usuario Recep.") : colAct += 1
    '    sl.SetCellValue(filAct, colAct, "Fecha Recep.") : colAct += 1
    '    sl.SetCellValue(filAct, colAct, "Validado") : colAct += 1
    '    sl.SetCellValue(filAct, colAct, "Usuario Valid.") : colAct += 1
    '    sl.SetCellValue(filAct, colAct, "Fecha Valid.") : colAct += 1
    '    sl.SetCellValue(filAct, colAct, "Usuario Deriva.") : colAct += 1
    '    sl.SetCellValue(filAct, colAct, "Fecha Deriva") : colAct += 1
    '    sl.SetCellValue(filAct, colAct, "Usuario Rechazo") : colAct += 1
    '    sl.SetCellValue(filAct, colAct, "Fecha Rechazo") : colAct += 1
    '    sl.SetCellValue(filAct, colAct, "Est. Examen") : colAct += 1
    '    sl.SetCellValue(filAct, colAct, "Fecha Examen") : colAct += 1
    '    sl.SetCellValue(filAct, colAct, "Usuario Examen") : colAct += 1

    '    Dim indice = 1
    '    For Each dato In Data_Validado
    '        filAct += 1
    '        colAct = 1
    '        sl.SetCellValue(filAct, colAct, indice) : indice += 1 : colAct += 1
    '        sl.SetCellValue(filAct, colAct, dato.ATE_NUM) : colAct += 1
    '        sl.SetCellValue(filAct, colAct, dato.PAC_RUT) : colAct += 1
    '        sl.SetCellValue(filAct, colAct, dato.PAC_NOMBRE & " " & dato.PAC_APELLIDO) : colAct += 1
    '        sl.SetCellValue(filAct, colAct, dato.ATE_AÑO) : colAct += 1
    '        sl.SetCellValue(filAct, colAct, Format(dato.ATE_FECHA, "dd/MM/yyyy")) : colAct += 1
    '        sl.SetCellValue(filAct, colAct, Format(dato.ATE_FECHA, "HH:mm:ss")) : colAct += 1
    '        sl.SetCellValue(filAct, colAct, dato.PROC_DESC) : colAct += 1
    '        sl.SetCellValue(filAct, colAct, If(dato.ID_SEXO = 2, "Femenino", "Masculino")) : colAct += 1
    '        sl.SetCellValue(filAct, colAct, dato.CF_DESC) : colAct += 1
    '        sl.SetCellValue(filAct, colAct, dato.T_MUESTRA_DESC) : colAct += 1
    '        sl.SetCellValue(filAct, colAct, dato.CB_DESC) : colAct += 1
    '        sl.SetCellValue(filAct, colAct, dato.ATE_EST_TM_DESC) : colAct += 1
    '        sl.SetCellValue(filAct, colAct, dato.ATE_USU_TM) : colAct += 1
    '        sl.SetCellValue(filAct, colAct, Format(dato.ATE_FEC_TM, "dd/MM/yyyy HH:mm:ss")) : colAct += 1
    '        sl.SetCellValue(filAct, colAct, dato.ATE_EST_ENVIO_DESC) : colAct += 1
    '        sl.SetCellValue(filAct, colAct, dato.UENVIO) : colAct += 1
    '        sl.SetCellValue(filAct, colAct, Format(dato.ATE_FEC_ENVIO, "dd/MM/yyyy HH:mm:ss")) : colAct += 1
    '        sl.SetCellValue(filAct, colAct, dato.ATE_EST_RECEP_DESC) : colAct += 1
    '        sl.SetCellValue(filAct, colAct, dato.USUARIO_ENV_RECEP) : colAct += 1
    '        sl.SetCellValue(filAct, colAct, Format(dato.ATE_FEC_RECEP, "dd/MM/yyyy HH:mm:ss")) : colAct += 1

    '    Next

    '    'insertar tabla
    '    tabla = sl.CreateTable("A8", CStr("U" & ltabla))
    '    tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
    '    sl.InsertTable(tabla)
    '    Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
    '    Dim Relative_Path As String = "Trazabilidad_por_Envio_Recepcion_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".xlsx"
    '    sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
    '    'Devolver la url del archivo generado
    '    Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    'End Function


    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable_Det_Ate(ByVal ID_ATE As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim Encrypt As New N_Encrypt

        Dim data_det_ate As List(Of E_IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_PACIENTE)
        Dim data_num As List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES)
        Dim NN_Det_Ate As N_IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_PACIENTE = New N_IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_PACIENTE
        Dim NN_Num As N_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES = New N_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES

        data_det_ate = NN_Det_Ate.IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_PACIENTE(ID_ATE)
        If (data_det_ate.Count > 0) Then
            data_num = NN_Num.IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES(data_det_ate(0).ID_ATENCION)
            data_det_ate(0).NUM_ATE = data_num(0).ATE_NUM

            For i = 0 To (data_det_ate.Count - 1)
                data_det_ate(i).ENCRYPTED_ID = Encrypt.Encode(ID_ATE)
            Next i

            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_det_ate, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If

        Return datas
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
        'Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")



        'If (IsNothing(C_P_ADMIN) = True) Then
        '    Response.Redirect("~/Index.aspx")
        'End If

        'Select Case (C_P_ADMIN.Value)
        '    Case Is <> 1, 0
        '        Response.Redirect("~/Index.aspx")
        'End Select
    End Sub

End Class