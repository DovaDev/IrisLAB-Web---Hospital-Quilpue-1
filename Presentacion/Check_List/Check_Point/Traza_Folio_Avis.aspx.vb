Imports Entidades
Imports Negocio
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class Traza_Folio_Avis
    Inherits System.Web.UI.Page

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
    Public Shared Function Llenar_DataTable(ByVal TIPO As Integer,
                                            ByVal ID_PRE As Integer,
                                            ByVal ID_CF As Integer,
                                            ByVal ID_VAL As Integer,
                                            ByVal ID_NMUE As Integer,
                                            ByVal ID_SECCION As Integer,
                                            ByVal ATENUM As Integer,
                                            ByVal ID_TP As Integer,
                                            ByVal ID_ENVIO As Integer,
                                            ByVal ID_DERIVADO As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'asdsd
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

        Data_Validado = NN.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO_AVIS(TIPO, Date.Now, Date.Now, ID_PRE, ID_CF, ID_VAL, ID_NMUE, ID_SECCION, ATENUM, ID_ENVIO, ID_DERIVADO)
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

                If Data_Validado(y).ATE_DET_V_ID_ESTADO = 6 Or Data_Validado(y).ATE_DET_V_ID_ESTADO = 14 Then
                    valiSi += 1
                Else
                    valiNo += 1
                End If

                If Data_Validado(y).ATE_EST_RECHAZO = 16 Then
                    rechSi += 1
                    If ID_TP = 0 Then
                        data_tipo_rechazo = NN_tipo_rechazo.IRIS_WEBF_BUSCA_RECEPCION_RECHAZO_TIPO_RECHAZO(Data_Validado(y).ID_ATENCION, Data_Validado(y).CB_DESC)
                        Data_Validado(y).TP_RECHA_DESC = data_tipo_rechazo(0).TP_RECHA_DESC
                        Data_Validado(y).RECEP_ETI_RECHAZO_OBS = data_tipo_rechazo(0).RECEP_ETI_RECHAZO_OBS
                        Data_Validado(y).ACTIVADOR = "1"
                        Data_Validado(y).MOSTRAR = "MOSTRAR"
                    Else
                        data_tipo_rechazo_por_tipo = NN_tipo_rechazo_por_tipo.IRIS_WEBF_BUSCA_RECEPCION_RECHAZO_TIPO_RECHAZO_POR_TIPO(Data_Validado(y).ID_ATENCION, Data_Validado(y).CB_DESC, ID_TP)
                        If data_tipo_rechazo_por_tipo.Count > 0 Then
                            Data_Validado(y).TP_RECHA_DESC = data_tipo_rechazo_por_tipo(0).TP_RECHA_DESC
                            Data_Validado(y).RECEP_ETI_RECHAZO_OBS = data_tipo_rechazo_por_tipo(0).RECEP_ETI_RECHAZO_OBS
                            Data_Validado(y).MOSTRAR = "MOSTRAR"
                            Data_Validado(y).ACTIVADOR = "0"
                        Else
                            Data_Validado(y).ACTIVADOR = "0"
                            Data_Validado(y).MOSTRAR = "NOMOSTRAR"
                        End If
                    End If
                Else
                    rechNo += 1
                    Data_Validado(y).MOSTRAR = "NOMOSTRAR"
                End If

                data_busca_agen_por_id_ate_det_logo = NN_busca_agen_por_id_ate_det_logo.IRIS_WEBF_BUSCA_AGENDA_POR_ID_ATENCION_DETALLE_LOGO(Data_Validado(y).ID_ATENCION, Data_Validado(y).ID_CODIGO_FONASA)
                If data_busca_agen_por_id_ate_det_logo.Count > 0 Then
                    Data_Validado(y).PREINGRESO_DESC = "SI"
                    Data_Validado(y).USU_PREINGRESO = data_busca_agen_por_id_ate_det_logo(0).USU_NIC
                    Data_Validado(y).FECHA_PREINGRESO = data_busca_agen_por_id_ate_det_logo(0).PREI_DET_V_FECHA
                End If

                data_busca_ate_para_log_por_id_ate = NN_busca_ate_para_log_por_id_ate.IRIS_WEBF_BUSCA_ATENCIONES_PARA_LOG_POR_ID_ATE(Data_Validado(y).ID_ATENCION, Data_Validado(y).ID_CODIGO_FONASA)
                If data_busca_ate_para_log_por_id_ate.Count > 0 Then
                    Data_Validado(y).INGRESO_DESC = "SI"
                    Data_Validado(y).USU_INGRESO = data_busca_ate_para_log_por_id_ate(0).USU_NIC
                    Data_Validado(y).FECHA_INGRESO = data_busca_ate_para_log_por_id_ate(0).ATE_DET_FECHA
                End If

                data_busca_estado_ate_trazabi_traza = NN_busca_estado_ate_trazabi_traza.IRIS_WEBF_BUSCA_ESTADO_ATENCION_TRAZABILIDAD_TRAZA_NUEVO_222_2(Data_Validado(y).ID_ATENCION, Data_Validado(y).ID_PER, Data_Validado(y).CB_DESC)
                If data_busca_estado_ate_trazabi_traza.Count > 0 Then
                    If data_busca_estado_ate_trazabi_traza(0).ATE_EST_TM = 8 Then
                        Data_Validado(y).ATE_EST_TM_DESC = "SI"
                        Data_Validado(y).ATE_USU_TM = data_busca_estado_ate_trazabi_traza(0).UTM
                        Data_Validado(y).ATE_FEC_TM = data_busca_estado_ate_trazabi_traza(0).ATE_FEC_TM
                    End If
                    If data_busca_estado_ate_trazabi_traza(0).ATE_EST_RECEP = 9 Then
                        Data_Validado(y).ATE_EST_RECEP_DESC = "SI"
                        Data_Validado(y).ATE_USU_RECEP = data_busca_estado_ate_trazabi_traza(0).URECEP
                        Data_Validado(y).ATE_FEC_RECEP = data_busca_estado_ate_trazabi_traza(0).ATE_FEC_RECEP
                    End If
                    If data_busca_estado_ate_trazabi_traza(0).ATE_EST_RECHAZO = 16 Then
                        Data_Validado(y).ATE_EST_RECHAZO_DESC = "SI"
                        Data_Validado(y).ATE_USU_RECHAZO = data_busca_estado_ate_trazabi_traza(0).URECHAZO
                        Data_Validado(y).ATE_FEC_RECHAZO = data_busca_estado_ate_trazabi_traza(0).ATE_FEC_RECHAZO
                    End If
                    If data_busca_estado_ate_trazabi_traza(0).ATE_EST_DERIVA = 15 Then
                        Data_Validado(y).ATE_EST_DERIVA_DESC = "SI"
                        Data_Validado(y).ATE_USU_DERIVA = data_busca_estado_ate_trazabi_traza(0).UDERI
                        Data_Validado(y).ATE_FEC_DERIVA = data_busca_estado_ate_trazabi_traza(0).ATE_FEC_DERIVA
                    End If
                    If data_busca_estado_ate_trazabi_traza(0).ATE_EST_VALIDA = 6 Or data_busca_estado_ate_trazabi_traza(0).ATE_EST_VALIDA = 14 Then
                        Data_Validado(y).ATE_EST_VALIDA_DESC = "SI"
                        Data_Validado(y).ATE_USU_VALIDA = data_busca_estado_ate_trazabi_traza(0).UVALIDA
                        Data_Validado(y).ATE_FEC_VALIDA = data_busca_estado_ate_trazabi_traza(0).ATE_FEC_VALIDA
                        If data_busca_estado_ate_trazabi_traza(0).ATE_EST_VALIDA = 14 Then
                            Data_Validado(y).ATE_EST_IMP_DESC = "SI"
                        End If
                    End If
                    If data_busca_estado_ate_trazabi_traza(0).ATE_EST_ENVIO = 5 Then
                        Data_Validado(y).ATE_EST_ENVIO_DESC = "SI"
                        Data_Validado(y).UENVIO = data_busca_estado_ate_trazabi_traza(0).UENVIO
                        Data_Validado(y).ATE_FEC_ENVIO = data_busca_estado_ate_trazabi_traza(0).ATE_FEC_ENVIO

                        Data_Validado(y).ENVIO_FECHA_RECEP = data_busca_estado_ate_trazabi_traza(0).ENVIO_FECHA_RECEP
                        Data_Validado(y).ID_USUARIO_RECEP = data_busca_estado_ate_trazabi_traza(0).ID_USUARIO_RECEP
                        Data_Validado(y).ID_ESTADO_RECEP = data_busca_estado_ate_trazabi_traza(0).ID_ESTADO_RECEP
                        Data_Validado(y).USUARIO_ENV_RECEP = data_busca_estado_ate_trazabi_traza(0).USUARIO_ENV_RECEP
                    End If
                End If

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

            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Validado, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String, ByVal TIPO As Integer,
                                            ByVal ID_PRE As Integer,
                                            ByVal ID_CF As Integer,
                                            ByVal ID_VAL As Integer,
                                            ByVal ID_NMUE As Integer,
                                            ByVal ID_SECCION As Integer,
                                            ByVal ATENUM As Integer,
                                            ByVal ID_TP As Integer,
                                            ByVal ID_ENVIO As Integer,
                                            ByVal ID_DERIVADO As Integer) As String
        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""

        'Declaraciones internas
        Dim NN As New N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO
        Dim Data_Validado As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO)

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
        Dim Mx_Data(48, 0) As Object
        Dim ltabla As Integer = 0
        Dim edad As Integer = 0




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

        Data_Validado = NN.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO_AVIS(TIPO, Date.Now, Date.Now, ID_PRE, ID_CF, ID_VAL, ID_NMUE, ID_SECCION, ATENUM, ID_ENVIO, ID_DERIVADO)
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

                If Data_Validado(y).ATE_DET_V_ID_ESTADO = 6 Or Data_Validado(y).ATE_DET_V_ID_ESTADO = 14 Then
                    valiSi += 1
                Else
                    valiNo += 1
                End If

                If Data_Validado(y).ATE_EST_RECHAZO = 16 Then
                    rechSi += 1
                    If ID_TP = 0 Then
                        data_tipo_rechazo = NN_tipo_rechazo.IRIS_WEBF_BUSCA_RECEPCION_RECHAZO_TIPO_RECHAZO(Data_Validado(y).ID_ATENCION, Data_Validado(y).CB_DESC)
                        Data_Validado(y).TP_RECHA_DESC = data_tipo_rechazo(0).TP_RECHA_DESC
                        Data_Validado(y).RECEP_ETI_RECHAZO_OBS = data_tipo_rechazo(0).RECEP_ETI_RECHAZO_OBS
                        Data_Validado(y).ACTIVADOR = "1"
                        Data_Validado(y).MOSTRAR = "MOSTRAR"
                    Else
                        data_tipo_rechazo_por_tipo = NN_tipo_rechazo_por_tipo.IRIS_WEBF_BUSCA_RECEPCION_RECHAZO_TIPO_RECHAZO_POR_TIPO(Data_Validado(y).ID_ATENCION, Data_Validado(y).CB_DESC, ID_TP)
                        If data_tipo_rechazo_por_tipo.Count > 0 Then
                            Data_Validado(y).TP_RECHA_DESC = data_tipo_rechazo_por_tipo(0).TP_RECHA_DESC
                            Data_Validado(y).RECEP_ETI_RECHAZO_OBS = data_tipo_rechazo_por_tipo(0).RECEP_ETI_RECHAZO_OBS
                            Data_Validado(y).MOSTRAR = "MOSTRAR"
                            Data_Validado(y).ACTIVADOR = "0"
                        Else
                            Data_Validado(y).ACTIVADOR = "0"
                            Data_Validado(y).MOSTRAR = "NOMOSTRAR"
                        End If
                    End If
                Else
                    rechNo += 1
                    Data_Validado(y).MOSTRAR = "NOMOSTRAR"
                End If

                data_busca_agen_por_id_ate_det_logo = NN_busca_agen_por_id_ate_det_logo.IRIS_WEBF_BUSCA_AGENDA_POR_ID_ATENCION_DETALLE_LOGO(Data_Validado(y).ID_ATENCION, Data_Validado(y).ID_CODIGO_FONASA)
                If data_busca_agen_por_id_ate_det_logo.Count > 0 Then
                    Data_Validado(y).PREINGRESO_DESC = "SI"
                    Data_Validado(y).USU_PREINGRESO = data_busca_agen_por_id_ate_det_logo(0).USU_NIC
                    Data_Validado(y).FECHA_PREINGRESO = data_busca_agen_por_id_ate_det_logo(0).PREI_DET_V_FECHA
                End If

                data_busca_ate_para_log_por_id_ate = NN_busca_ate_para_log_por_id_ate.IRIS_WEBF_BUSCA_ATENCIONES_PARA_LOG_POR_ID_ATE(Data_Validado(y).ID_ATENCION, Data_Validado(y).ID_CODIGO_FONASA)
                If data_busca_ate_para_log_por_id_ate.Count > 0 Then
                    Data_Validado(y).INGRESO_DESC = "SI"
                    Data_Validado(y).USU_INGRESO = data_busca_ate_para_log_por_id_ate(0).USU_NIC
                    Data_Validado(y).FECHA_INGRESO = data_busca_ate_para_log_por_id_ate(0).ATE_DET_FECHA
                End If

                data_busca_estado_ate_trazabi_traza = NN_busca_estado_ate_trazabi_traza.IRIS_WEBF_BUSCA_ESTADO_ATENCION_TRAZABILIDAD_TRAZA_NUEVO_222_2(Data_Validado(y).ID_ATENCION, Data_Validado(y).ID_PER, Data_Validado(y).CB_DESC)
                If data_busca_estado_ate_trazabi_traza.Count > 0 Then
                    If data_busca_estado_ate_trazabi_traza(0).ATE_EST_TM = 8 Then
                        Data_Validado(y).ATE_EST_TM_DESC = "SI"
                        Data_Validado(y).ATE_USU_TM = data_busca_estado_ate_trazabi_traza(0).UTM
                        Data_Validado(y).ATE_FEC_TM = data_busca_estado_ate_trazabi_traza(0).ATE_FEC_TM
                    End If
                    If data_busca_estado_ate_trazabi_traza(0).ATE_EST_RECEP = 9 Then
                        Data_Validado(y).ATE_EST_RECEP_DESC = "SI"
                        Data_Validado(y).ATE_USU_RECEP = data_busca_estado_ate_trazabi_traza(0).URECEP
                        Data_Validado(y).ATE_FEC_RECEP = data_busca_estado_ate_trazabi_traza(0).ATE_FEC_RECEP
                    End If
                    If data_busca_estado_ate_trazabi_traza(0).ATE_EST_RECHAZO = 16 Then
                        Data_Validado(y).ATE_EST_RECHAZO_DESC = "SI"
                        Data_Validado(y).ATE_USU_RECHAZO = data_busca_estado_ate_trazabi_traza(0).URECHAZO
                        Data_Validado(y).ATE_FEC_RECHAZO = data_busca_estado_ate_trazabi_traza(0).ATE_FEC_RECHAZO
                    End If
                    If data_busca_estado_ate_trazabi_traza(0).ATE_EST_DERIVA = 15 Then
                        Data_Validado(y).ATE_EST_DERIVA_DESC = "SI"
                        Data_Validado(y).ATE_USU_DERIVA = data_busca_estado_ate_trazabi_traza(0).UDERI
                        Data_Validado(y).ATE_FEC_DERIVA = data_busca_estado_ate_trazabi_traza(0).ATE_FEC_DERIVA
                    End If
                    If data_busca_estado_ate_trazabi_traza(0).ATE_EST_VALIDA = 6 Or data_busca_estado_ate_trazabi_traza(0).ATE_EST_VALIDA = 14 Then
                        Data_Validado(y).ATE_EST_VALIDA_DESC = "SI"
                        Data_Validado(y).ATE_USU_VALIDA = data_busca_estado_ate_trazabi_traza(0).UVALIDA
                        Data_Validado(y).ATE_FEC_VALIDA = data_busca_estado_ate_trazabi_traza(0).ATE_FEC_VALIDA
                        If data_busca_estado_ate_trazabi_traza(0).ATE_EST_VALIDA = 14 Then
                            Data_Validado(y).ATE_EST_IMP_DESC = "SI"
                        End If
                    End If
                    If data_busca_estado_ate_trazabi_traza(0).ATE_EST_ENVIO = 5 Then
                        Data_Validado(y).ATE_EST_ENVIO_DESC = "SI"
                        Data_Validado(y).UENVIO = data_busca_estado_ate_trazabi_traza(0).UENVIO
                        Data_Validado(y).ATE_FEC_ENVIO = data_busca_estado_ate_trazabi_traza(0).ATE_FEC_ENVIO

                        Data_Validado(y).ENVIO_FECHA_RECEP = data_busca_estado_ate_trazabi_traza(0).ENVIO_FECHA_RECEP
                        Data_Validado(y).ID_USUARIO_RECEP = data_busca_estado_ate_trazabi_traza(0).ID_USUARIO_RECEP
                        Data_Validado(y).ID_ESTADO_RECEP = data_busca_estado_ate_trazabi_traza(0).ID_ESTADO_RECEP
                        Data_Validado(y).USUARIO_ENV_RECEP = data_busca_estado_ate_trazabi_traza(0).USUARIO_ENV_RECEP
                    End If
                End If

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

            'Vaciar Matriz
            ReDim Mx_Data(48, 0)
            For x = 0 To (Mx_Data.GetUpperBound(0))
                Mx_Data(x, 0) = Nothing
            Next x

            'Llenar Matriz
            If Data_Validado(0).ACTIVADOR <> "0" Then



                'For ahh = 0 To Data_Validado.Count - 1
                '    If Data_Validado(ahh).MOSTRAR <> "MOSTRAR" Then
                '        'pufff pa fuera
                '    End If
                'Next ahh

                'Dim xi As Integer = 0
                'While (xi <= (Data_Validado.Count - 1))
                '    If Data_Validado(xi).MOSTRAR = "MOSTRAR" Then
                '        xi += 1
                '        Continue While
                '    End If

                '    Data_Validado.RemoveAt(xi)
                '    xi = 0
                'End While

                For y = 0 To (Data_Validado.Count - 1)
                    If (y > 0) Then
                        ReDim Preserve Mx_Data(48, y)
                    End If
                    Mx_Data(0, y) = y + 1

                    If Data_Validado(y).ATE_NUM = Nothing Then
                        Mx_Data(1, y) = ""
                    Else
                        Mx_Data(1, y) = CInt(Data_Validado(y).ATE_NUM)
                    End If

                    If Data_Validado(y).PAC_RUT = Nothing Then
                        Mx_Data(2, y) = ""
                    Else
                        Mx_Data(2, y) = Data_Validado(y).PAC_RUT
                    End If

                    If Data_Validado(y).PAC_NOMBRE = Nothing Or Data_Validado(y).PAC_APELLIDO = Nothing Then
                        Mx_Data(3, y) = ""
                    Else
                        Mx_Data(3, y) = Data_Validado(y).PAC_NOMBRE + " " + Data_Validado(y).PAC_APELLIDO
                    End If

                    If Data_Validado(y).ATE_AÑO = Nothing Then
                        Mx_Data(4, y) = ""
                    Else
                        Mx_Data(4, y) = Data_Validado(y).ATE_AÑO & " " & "Años"
                    End If

                    If Data_Validado(y).ATE_FECHA = Nothing Then
                        Mx_Data(5, y) = ""
                    Else
                        Mx_Data(5, y) = Format(Data_Validado(y).ATE_FECHA, "dd/MM/yyyy")
                    End If

                    If Data_Validado(y).ATE_FECHA = Nothing Then
                        Mx_Data(6, y) = ""
                    Else
                        Mx_Data(6, y) = Format(Data_Validado(y).ATE_FECHA, "hh:mm:ss")
                    End If

                    If Data_Validado(y).PROC_DESC = Nothing Then
                        Mx_Data(7, y) = ""
                    Else
                        Mx_Data(7, y) = Data_Validado(y).PROC_DESC
                    End If

                    If Data_Validado(y).ID_SEXO = Nothing Then
                        Mx_Data(8, y) = ""
                    Else
                        If Data_Validado(y).ID_SEXO = "2" Then
                            Mx_Data(8, y) = "Femenino"
                        Else
                            Mx_Data(8, y) = "Masculino"
                        End If
                    End If

                    If Data_Validado(y).CF_DESC = Nothing Then
                        Mx_Data(9, y) = ""
                    Else
                        Mx_Data(9, y) = Data_Validado(y).CF_DESC
                    End If

                    If Data_Validado(y).T_MUESTRA_DESC = Nothing Then
                        Mx_Data(10, y) = ""
                    Else
                        Mx_Data(10, y) = Data_Validado(y).T_MUESTRA_DESC
                    End If

                    If Data_Validado(y).CB_DESC = Nothing Then
                        Mx_Data(11, y) = ""
                    Else
                        Mx_Data(11, y) = CStr("-" & Data_Validado(y).CB_DESC & "-")
                    End If

                    If Data_Validado(y).ATE_EST_ENVIO = Nothing Then
                        Mx_Data(12, y) = ""
                    Else
                        If Data_Validado(y).ATE_EST_ENVIO = "5" Then
                            Mx_Data(12, y) = "SI"
                        Else
                            Mx_Data(12, y) = ""
                        End If
                    End If
                    '---------------------------
                    If Data_Validado(y).ID_ESTADO_RECEP = 0 Then
                        Mx_Data(13, y) = ""
                    Else
                        If Data_Validado(y).ID_ESTADO_RECEP = 9 Then
                            Mx_Data(13, y) = "SI"
                        Else
                            Mx_Data(13, y) = ""
                        End If
                    End If
                    '---------------------------

                    If Data_Validado(y).ATE_EST_RECEP = Nothing Then
                        Mx_Data(14, y) = ""
                    Else
                        If Data_Validado(y).ATE_EST_RECEP = "9" Then
                            Mx_Data(14, y) = "SI"
                        Else
                            Mx_Data(14, y) = ""
                        End If
                    End If

                    If Data_Validado(y).ATE_DET_V_ID_ESTADO = Nothing Then
                        Mx_Data(15, y) = ""
                    Else
                        If Data_Validado(y).ATE_DET_V_ID_ESTADO = "14" Or Data_Validado(y).ATE_DET_V_ID_ESTADO = "6" Then
                            Mx_Data(15, y) = "SI"
                        Else
                            Mx_Data(15, y) = ""
                        End If
                    End If

                    If Data_Validado(y).ATE_EST_RECHAZO = Nothing Then
                        Mx_Data(16, y) = ""
                    Else
                        If Data_Validado(y).ATE_EST_RECHAZO = "7" Then
                            Mx_Data(16, y) = ""
                        Else
                            Mx_Data(16, y) = "SI"
                        End If
                    End If


                    If Data_Validado(y).TP_RECHA_DESC = Nothing Then
                        Mx_Data(17, y) = ""
                    Else
                        Mx_Data(17, y) = Data_Validado(y).TP_RECHA_DESC
                    End If

                    If Data_Validado(y).RECEP_ETI_RECHAZO_OBS = Nothing Then
                        Mx_Data(18, y) = ""
                    Else
                        Mx_Data(18, y) = Data_Validado(y).RECEP_ETI_RECHAZO_OBS
                    End If

                    If Data_Validado(y).PREINGRESO_DESC = Nothing Then
                        Mx_Data(19, y) = ""
                    Else
                        Mx_Data(19, y) = Data_Validado(y).PREINGRESO_DESC
                    End If

                    If Data_Validado(y).USU_PREINGRESO = Nothing Then
                        Mx_Data(20, y) = ""
                    Else
                        Mx_Data(20, y) = Data_Validado(y).USU_PREINGRESO
                    End If

                    If Data_Validado(y).FECHA_PREINGRESO = Nothing Then
                        Mx_Data(21, y) = ""
                    Else
                        Mx_Data(21, y) = Format(Data_Validado(y).FECHA_PREINGRESO, "dd/MM/yyyy")
                    End If

                    If Data_Validado(y).INGRESO_DESC = Nothing Then
                        Mx_Data(22, y) = ""
                    Else
                        Mx_Data(22, y) = Data_Validado(y).INGRESO_DESC
                    End If

                    If Data_Validado(y).USU_INGRESO = Nothing Then
                        Mx_Data(23, y) = ""
                    Else
                        Mx_Data(23, y) = Data_Validado(y).USU_INGRESO
                    End If

                    If Data_Validado(y).FECHA_INGRESO = Nothing Then
                        Mx_Data(24, y) = ""
                    Else
                        Mx_Data(24, y) = Format(Data_Validado(y).FECHA_INGRESO, "dd/MM/yyyy")
                    End If

                    If Data_Validado(y).ATE_EST_TM_DESC = Nothing Then
                        Mx_Data(25, y) = ""
                    Else
                        Mx_Data(25, y) = Data_Validado(y).ATE_EST_TM_DESC
                    End If

                    If Data_Validado(y).ATE_USU_TM = Nothing Then
                        Mx_Data(26, y) = ""
                    Else
                        Mx_Data(26, y) = Data_Validado(y).ATE_USU_TM
                    End If

                    If Data_Validado(y).ATE_FEC_TM = Nothing Then
                        Mx_Data(27, y) = ""
                    Else
                        Mx_Data(27, y) = Format(Data_Validado(y).ATE_FEC_TM, "dd/MM/yyyy")
                    End If

                    If Data_Validado(y).ATE_EST_ENVIO_DESC = Nothing Then
                        Mx_Data(28, y) = ""
                    Else
                        Mx_Data(28, y) = Data_Validado(y).ATE_EST_ENVIO_DESC
                    End If

                    If Data_Validado(y).UENVIO = Nothing Then
                        Mx_Data(29, y) = ""
                    Else
                        Mx_Data(29, y) = Data_Validado(y).UENVIO
                    End If

                    If Data_Validado(y).ATE_FEC_ENVIO = Nothing Then
                        Mx_Data(30, y) = ""
                    Else
                        Mx_Data(30, y) = Format(Data_Validado(y).ATE_FEC_ENVIO, "dd/MM/yyyy")
                    End If
                    '-------------------------------------
                    If Data_Validado(y).ID_ESTADO_RECEP = Nothing Then
                        Mx_Data(31, y) = ""
                    Else
                        If Data_Validado(y).ID_ESTADO_RECEP = 0 Then
                            Mx_Data(31, y) = ""
                        Else
                            Mx_Data(31, y) = "SI"
                        End If
                    End If

                    If Data_Validado(y).ID_ESTADO_RECEP = Nothing Then
                        Mx_Data(32, y) = ""
                    Else
                        If Data_Validado(y).ID_ESTADO_RECEP = 0 Then
                            Mx_Data(32, y) = ""
                        Else
                            Mx_Data(32, y) = Data_Validado(y).USUARIO_ENV_RECEP
                        End If
                    End If

                    If Data_Validado(y).ID_ESTADO_RECEP = Nothing Then
                        Mx_Data(33, y) = ""
                    Else
                        If Data_Validado(y).ID_ESTADO_RECEP = 0 Then
                            Mx_Data(33, y) = ""
                        Else
                            Mx_Data(33, y) = Format(Data_Validado(y).ENVIO_FECHA_RECEP, "dd/MM/yyyy")
                        End If
                    End If
                    '-------------------------------------
                    If Data_Validado(y).ATE_EST_RECEP_DESC = Nothing Then
                        Mx_Data(34, y) = ""
                    Else
                        Mx_Data(34, y) = Data_Validado(y).ATE_EST_RECEP_DESC
                    End If

                    If Data_Validado(y).ATE_USU_RECEP = Nothing Then
                        Mx_Data(35, y) = ""
                    Else
                        Mx_Data(35, y) = Data_Validado(y).ATE_USU_RECEP
                    End If

                    If Data_Validado(y).ATE_FEC_RECEP = Nothing Then
                        Mx_Data(36, y) = ""
                    Else
                        Mx_Data(36, y) = Format(Data_Validado(y).ATE_FEC_RECEP, "dd/MM/yyyy")
                    End If

                    If Data_Validado(y).ATE_EST_VALIDA_DESC = Nothing Then
                        Mx_Data(37, y) = ""
                    Else
                        Mx_Data(37, y) = Data_Validado(y).ATE_EST_VALIDA_DESC
                    End If

                    If Data_Validado(y).ATE_USU_VALIDA = Nothing Then
                        Mx_Data(38, y) = ""
                    Else
                        Mx_Data(38, y) = Data_Validado(y).ATE_USU_VALIDA
                    End If

                    If Data_Validado(y).ATE_FEC_VALIDA = Nothing Then
                        Mx_Data(39, y) = ""
                    Else
                        Mx_Data(39, y) = Format(Data_Validado(y).ATE_FEC_VALIDA, "dd/MM/yyyy")
                    End If

                    If Data_Validado(y).ATE_EST_RECHAZO_DESC = Nothing Then
                        Mx_Data(40, y) = ""
                    Else
                        Mx_Data(40, y) = Data_Validado(y).ATE_EST_RECHAZO_DESC
                    End If

                    If Data_Validado(y).ATE_USU_RECHAZO = Nothing Then
                        Mx_Data(41, y) = ""
                    Else
                        Mx_Data(41, y) = Data_Validado(y).ATE_USU_RECHAZO
                    End If

                    If Data_Validado(y).ATE_FEC_RECHAZO = Nothing Then
                        Mx_Data(42, y) = ""
                    Else
                        Mx_Data(42, y) = Format(Data_Validado(y).ATE_FEC_RECHAZO, "dd/MM/yyyy")
                    End If

                    If Data_Validado(y).ATE_EST_DERIVA_DESC = Nothing Then
                        Mx_Data(43, y) = ""
                    Else
                        Mx_Data(43, y) = Data_Validado(y).ATE_EST_DERIVA_DESC
                    End If

                    If Data_Validado(y).ATE_USU_DERIVA = Nothing Then
                        Mx_Data(44, y) = ""
                    Else
                        Mx_Data(44, y) = Data_Validado(y).ATE_USU_DERIVA
                    End If

                    If Data_Validado(y).ATE_FEC_DERIVA = Nothing Then
                        Mx_Data(45, y) = ""
                    Else
                        Mx_Data(45, y) = Format(Data_Validado(y).ATE_FEC_DERIVA, "dd/MM/yyyy")
                    End If

                    If Data_Validado(y).ATE_EST_IMP_DESC = Nothing Then
                        Mx_Data(46, y) = ""
                    Else
                        Mx_Data(46, y) = Data_Validado(y).ATE_EST_IMP_DESC
                    End If

                    Mx_Data(47, y) = ""
                    Mx_Data(48, y) = ""

                Next y
            Else
                Dim xi As Integer = 0
                While (xi <= (Data_Validado.Count - 1))
                    If Data_Validado(xi).MOSTRAR = "MOSTRAR" Then
                        xi += 1
                        Continue While

                    Else
                        Data_Validado.RemoveAt(xi)
                        If xi <> 0 Then
                            xi -= 1
                        End If


                    End If
                End While
                If Data_Validado.Count > 0 Then
                    For y = 0 To Data_Validado.Count - 1
                        If (y > 0) Then
                            ReDim Preserve Mx_Data(48, y)
                        End If
                        Mx_Data(0, y) = y + 1

                        If Data_Validado(y).ATE_NUM = Nothing Then
                            Mx_Data(1, y) = ""
                        Else
                            Mx_Data(1, y) = CInt(Data_Validado(y).ATE_NUM)
                        End If

                        If Data_Validado(y).PAC_RUT = Nothing Then
                            Mx_Data(2, y) = ""
                        Else
                            Mx_Data(2, y) = Data_Validado(y).PAC_RUT
                        End If

                        If Data_Validado(y).PAC_NOMBRE = Nothing Or Data_Validado(y).PAC_APELLIDO = Nothing Then
                            Mx_Data(3, y) = ""
                        Else
                            Mx_Data(3, y) = Data_Validado(y).PAC_NOMBRE + " " + Data_Validado(y).PAC_APELLIDO
                        End If

                        If Data_Validado(y).ATE_AÑO = Nothing Then
                            Mx_Data(4, y) = ""
                        Else
                            Mx_Data(4, y) = Data_Validado(y).ATE_AÑO & " " & "Años"
                        End If

                        If Data_Validado(y).ATE_FECHA = Nothing Then
                            Mx_Data(5, y) = ""
                        Else
                            Mx_Data(5, y) = Format(Data_Validado(y).ATE_FECHA, "dd/MM/yyyy")
                        End If

                        If Data_Validado(y).ATE_FECHA = Nothing Then
                            Mx_Data(6, y) = ""
                        Else
                            Mx_Data(6, y) = Format(Data_Validado(y).ATE_FECHA, "hh:mm:ss")
                        End If

                        If Data_Validado(y).PROC_DESC = Nothing Then
                            Mx_Data(7, y) = ""
                        Else
                            Mx_Data(7, y) = Data_Validado(y).PROC_DESC
                        End If

                        If Data_Validado(y).ID_SEXO = Nothing Then
                            Mx_Data(8, y) = ""
                        Else
                            If Data_Validado(y).ID_SEXO = "2" Then
                                Mx_Data(8, y) = "Femenino"
                            Else
                                Mx_Data(8, y) = "Masculino"
                            End If
                        End If

                        If Data_Validado(y).CF_DESC = Nothing Then
                            Mx_Data(9, y) = ""
                        Else
                            Mx_Data(9, y) = Data_Validado(y).CF_DESC
                        End If

                        If Data_Validado(y).T_MUESTRA_DESC = Nothing Then
                            Mx_Data(10, y) = ""
                        Else
                            Mx_Data(10, y) = Data_Validado(y).T_MUESTRA_DESC
                        End If

                        If Data_Validado(y).CB_DESC = Nothing Then
                            Mx_Data(11, y) = ""
                        Else
                            Mx_Data(11, y) = CStr("-" & Data_Validado(y).CB_DESC & "-")
                        End If

                        If Data_Validado(y).ATE_EST_ENVIO = Nothing Then
                            Mx_Data(12, y) = ""
                        Else
                            If Data_Validado(y).ATE_EST_ENVIO = "5" Then
                                Mx_Data(12, y) = "SI"
                            Else
                                Mx_Data(12, y) = ""
                            End If
                        End If
                        '---------------------------
                        If Data_Validado(y).ID_ESTADO_RECEP = 0 Then
                            Mx_Data(13, y) = ""
                        Else
                            If Data_Validado(y).ID_ESTADO_RECEP = 9 Then
                                Mx_Data(13, y) = "SI"
                            Else
                                Mx_Data(13, y) = ""
                            End If
                        End If
                        '---------------------------
                        If Data_Validado(y).ATE_EST_RECEP = Nothing Then
                            Mx_Data(14, y) = ""
                        Else
                            If Data_Validado(y).ATE_EST_RECEP = "9" Then
                                Mx_Data(14, y) = "SI"
                            Else
                                Mx_Data(14, y) = ""
                            End If
                        End If

                        If Data_Validado(y).ATE_DET_V_ID_ESTADO = Nothing Then
                            Mx_Data(15, y) = ""
                        Else
                            If Data_Validado(y).ATE_DET_V_ID_ESTADO = "14" Or Data_Validado(y).ATE_DET_V_ID_ESTADO = "6" Then
                                Mx_Data(15, y) = "SI"
                            Else
                                Mx_Data(15, y) = ""
                            End If
                        End If

                        If Data_Validado(y).ATE_EST_RECHAZO = Nothing Then
                            Mx_Data(16, y) = ""
                        Else
                            If Data_Validado(y).ATE_EST_RECHAZO = "7" Then
                                Mx_Data(16, y) = ""
                            Else
                                Mx_Data(16, y) = "SI"
                            End If
                        End If


                        If Data_Validado(y).TP_RECHA_DESC = Nothing Then
                            Mx_Data(17, y) = ""
                        Else
                            Mx_Data(17, y) = Data_Validado(y).TP_RECHA_DESC
                        End If

                        If Data_Validado(y).RECEP_ETI_RECHAZO_OBS = Nothing Then
                            Mx_Data(18, y) = ""
                        Else
                            Mx_Data(18, y) = Data_Validado(y).RECEP_ETI_RECHAZO_OBS
                        End If

                        If Data_Validado(y).PREINGRESO_DESC = Nothing Then
                            Mx_Data(19, y) = ""
                        Else
                            Mx_Data(19, y) = Data_Validado(y).PREINGRESO_DESC
                        End If

                        If Data_Validado(y).USU_PREINGRESO = Nothing Then
                            Mx_Data(20, y) = ""
                        Else
                            Mx_Data(20, y) = Data_Validado(y).USU_PREINGRESO
                        End If

                        If Data_Validado(y).FECHA_PREINGRESO = Nothing Then
                            Mx_Data(21, y) = ""
                        Else
                            Mx_Data(21, y) = Format(Data_Validado(y).FECHA_PREINGRESO, "dd/MM/yyyy")
                        End If

                        If Data_Validado(y).INGRESO_DESC = Nothing Then
                            Mx_Data(22, y) = ""
                        Else
                            Mx_Data(22, y) = Data_Validado(y).INGRESO_DESC
                        End If

                        If Data_Validado(y).USU_INGRESO = Nothing Then
                            Mx_Data(23, y) = ""
                        Else
                            Mx_Data(23, y) = Data_Validado(y).USU_INGRESO
                        End If

                        If Data_Validado(y).FECHA_INGRESO = Nothing Then
                            Mx_Data(24, y) = ""
                        Else
                            Mx_Data(24, y) = Format(Data_Validado(y).FECHA_INGRESO, "dd/MM/yyyy")
                        End If

                        If Data_Validado(y).ATE_EST_TM_DESC = Nothing Then
                            Mx_Data(25, y) = ""
                        Else
                            Mx_Data(25, y) = Data_Validado(y).ATE_EST_TM_DESC
                        End If

                        If Data_Validado(y).ATE_USU_TM = Nothing Then
                            Mx_Data(26, y) = ""
                        Else
                            Mx_Data(26, y) = Data_Validado(y).ATE_USU_TM
                        End If

                        If Data_Validado(y).ATE_FEC_TM = Nothing Then
                            Mx_Data(27, y) = ""
                        Else
                            Mx_Data(27, y) = Format(Data_Validado(y).ATE_FEC_TM, "dd/MM/yyyy")
                        End If

                        If Data_Validado(y).ATE_EST_ENVIO_DESC = Nothing Then
                            Mx_Data(28, y) = ""
                        Else
                            Mx_Data(28, y) = Data_Validado(y).ATE_EST_ENVIO_DESC
                        End If

                        If Data_Validado(y).UENVIO = Nothing Then
                            Mx_Data(29, y) = ""
                        Else
                            Mx_Data(29, y) = Data_Validado(y).UENVIO
                        End If

                        If Data_Validado(y).ATE_FEC_ENVIO = Nothing Then
                            Mx_Data(30, y) = ""
                        Else
                            Mx_Data(30, y) = Format(Data_Validado(y).ATE_FEC_ENVIO, "dd/MM/yyyy")
                        End If
                        '-------------------------------------
                        If Data_Validado(y).ID_ESTADO_RECEP = Nothing Then
                            Mx_Data(31, y) = ""
                        Else
                            If Data_Validado(y).ID_ESTADO_RECEP = 0 Then
                                Mx_Data(31, y) = ""
                            Else
                                Mx_Data(31, y) = Data_Validado(y).ATE_EST_ENVIO_DESC
                            End If
                        End If

                        If Data_Validado(y).ID_ESTADO_RECEP = Nothing Then
                            Mx_Data(32, y) = ""
                        Else
                            If Data_Validado(y).ID_ESTADO_RECEP = 0 Then
                                Mx_Data(32, y) = ""
                            Else
                                Mx_Data(32, y) = Data_Validado(y).USUARIO_ENV_RECEP
                            End If
                        End If

                        If Data_Validado(y).ID_ESTADO_RECEP = Nothing Then
                            Mx_Data(33, y) = ""
                        Else
                            If Data_Validado(y).ID_ESTADO_RECEP = 0 Then
                                Mx_Data(33, y) = ""
                            Else
                                Mx_Data(33, y) = Format(Data_Validado(y).ENVIO_FECHA_RECEP, "dd/MM/yyyy")
                            End If
                        End If
                        '-------------------------------------
                        If Data_Validado(y).ATE_EST_RECEP_DESC = Nothing Then
                            Mx_Data(34, y) = ""
                        Else
                            Mx_Data(34, y) = Data_Validado(y).ATE_EST_RECEP_DESC
                        End If

                        If Data_Validado(y).ATE_USU_RECEP = Nothing Then
                            Mx_Data(35, y) = ""
                        Else
                            Mx_Data(35, y) = Data_Validado(y).ATE_USU_RECEP
                        End If

                        If Data_Validado(y).ATE_FEC_RECEP = Nothing Then
                            Mx_Data(36, y) = ""
                        Else
                            Mx_Data(36, y) = Format(Data_Validado(y).ATE_FEC_RECEP, "dd/MM/yyyy")
                        End If

                        If Data_Validado(y).ATE_EST_VALIDA_DESC = Nothing Then
                            Mx_Data(37, y) = ""
                        Else
                            Mx_Data(37, y) = Data_Validado(y).ATE_EST_VALIDA_DESC
                        End If

                        If Data_Validado(y).ATE_USU_VALIDA = Nothing Then
                            Mx_Data(38, y) = ""
                        Else
                            Mx_Data(38, y) = Data_Validado(y).ATE_USU_VALIDA
                        End If

                        If Data_Validado(y).ATE_FEC_VALIDA = Nothing Then
                            Mx_Data(39, y) = ""
                        Else
                            Mx_Data(39, y) = Format(Data_Validado(y).ATE_FEC_VALIDA, "dd/MM/yyyy")
                        End If

                        If Data_Validado(y).ATE_EST_RECHAZO_DESC = Nothing Then
                            Mx_Data(40, y) = ""
                        Else
                            Mx_Data(40, y) = Data_Validado(y).ATE_EST_RECHAZO_DESC
                        End If

                        If Data_Validado(y).ATE_USU_RECHAZO = Nothing Then
                            Mx_Data(41, y) = ""
                        Else
                            Mx_Data(41, y) = Data_Validado(y).ATE_USU_RECHAZO
                        End If

                        If Data_Validado(y).ATE_FEC_RECHAZO = Nothing Then
                            Mx_Data(42, y) = ""
                        Else
                            Mx_Data(42, y) = Format(Data_Validado(y).ATE_FEC_RECHAZO, "dd/MM/yyyy")
                        End If

                        If Data_Validado(y).ATE_EST_DERIVA_DESC = Nothing Then
                            Mx_Data(43, y) = ""
                        Else
                            Mx_Data(43, y) = Data_Validado(y).ATE_EST_DERIVA_DESC
                        End If

                        If Data_Validado(y).ATE_USU_DERIVA = Nothing Then
                            Mx_Data(44, y) = ""
                        Else
                            Mx_Data(44, y) = Data_Validado(y).ATE_USU_DERIVA
                        End If

                        If Data_Validado(y).ATE_FEC_DERIVA = Nothing Then
                            Mx_Data(45, y) = ""
                        Else
                            Mx_Data(45, y) = Format(Data_Validado(y).ATE_FEC_DERIVA, "dd/MM/yyyy")
                        End If

                        If Data_Validado(y).ATE_EST_IMP_DESC = Nothing Then
                            Mx_Data(46, y) = ""
                        Else
                            Mx_Data(46, y) = Data_Validado(y).ATE_EST_IMP_DESC
                        End If

                        Mx_Data(47, y) = ""
                        Mx_Data(48, y) = ""
                    Next y
                Else
                    Return "null"
                End If

            End If



        Else
            Return "null"
        End If

        sl.SetCellValue("A4", "N° Atenciones:" & " " & NAte)
        sl.SetCellValue("A6", "N° Exámenes:" & " " & NExa)
        sl.SetCellValue("C4", "Recepcionado SI:" & " " & recSi & " / " & "NO:" & " " & recNo)
        sl.SetCellValue("C6", "Valida SI:" & " " & valiSi & " / " & "NO:" & " " & valiNo)
        sl.SetCellValue("E4", "Rechazado SI:" & " " & rechSi & " / " & "NO:" & " " & rechNo)
        sl.SetCellValue("E6", "TOTAL:" & " " & total)

        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Trazabilidad por Número de Folio")

        'titulo de la tabla
        sl.SetCellValue("B2", "Trazabilidad por Número de Folio")

        For y = 1 To 49
            sl.SetColumnWidth(y, 20.0)
        Next y

        'nombre columnas
        sl.SetCellValue("A8", "#")
        sl.SetCellValue("B8", "N° Atención")
        sl.SetCellValue("C8", "Rut Paciente")
        sl.SetCellValue("D8", "Nombre Paciente")
        sl.SetCellValue("E8", "Edad")
        sl.SetCellValue("F8", "Fecha")
        sl.SetCellValue("G8", "Hora")
        sl.SetCellValue("H8", "Lugar de TM")
        sl.SetCellValue("I8", "Sexo")
        sl.SetCellValue("J8", "Examen")
        sl.SetCellValue("K8", "Tipo de Etiqueta")
        sl.SetCellValue("L8", "CB")
        sl.SetCellValue("M8", "Enviado")
        '-------------------------------------
        sl.SetCellValue("N8", "Recep. Lab.")
        '----------------------------------
        sl.SetCellValue("O8", "Recep.")
        sl.SetCellValue("P8", "Validado")
        sl.SetCellValue("Q8", "Rechazado")
        sl.SetCellValue("R8", "Tipo de Rechazo")
        sl.SetCellValue("S8", "Obs. Rechazo")
        sl.SetCellValue("T8", "Agenda")
        sl.SetCellValue("U8", "Usuario Agen.")
        sl.SetCellValue("V8", "Fecha Agen.")
        sl.SetCellValue("W8", "Ingreso")
        sl.SetCellValue("X8", "Usuario Ing.")
        sl.SetCellValue("Y8", "fecha Ing.")
        sl.SetCellValue("Z8", "TM")
        sl.SetCellValue("AA8", "Usuario TM")
        sl.SetCellValue("AB8", "Fecha TM")
        sl.SetCellValue("AC8", "Envio")
        sl.SetCellValue("AD8", "Usuario Env.")
        sl.SetCellValue("AE8", "Fecha Env.")
        '-------------------------------
        sl.SetCellValue("AF8", "Recep. Lab.")
        sl.SetCellValue("AG8", "Usuario")
        sl.SetCellValue("AH8", "Fecha")
        '-------------------------------
        sl.SetCellValue("AI8", "Recepción")
        sl.SetCellValue("AJ8", "Usuario Recep.")
        sl.SetCellValue("AK8", "Fecha Recep.")
        sl.SetCellValue("AL8", "Valida")
        sl.SetCellValue("AM8", "Usuario Val.")
        sl.SetCellValue("AN8", "Fecha Val.")
        sl.SetCellValue("AO8", "Rechazo")
        sl.SetCellValue("AP8", "Usuario Recha.")
        sl.SetCellValue("AQ8", "Fecha Recha.")
        sl.SetCellValue("AR8", "Derivación")
        sl.SetCellValue("AS8", "Usuario Deri.")
        sl.SetCellValue("AT8", "Fecha Deri.")
        sl.SetCellValue("AU8", "Impresión")
        sl.SetCellValue("AV8", "Usuario Imp.")
        sl.SetCellValue("AW8", "Fecha Imp.")

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
        tabla = sl.CreateTable("A8", CStr("AW" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"

        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo

        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")

    End Function

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
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        'If (IsNothing(C_P_ADMIN) = True) Then
        '    Response.Redirect("~/Index.aspx")
        'End If

        'Select Case (C_P_ADMIN.Value)
        '    Case Is <> 1
        '        Response.Redirect("~/Index.aspx")
        'End Select
    End Sub

End Class