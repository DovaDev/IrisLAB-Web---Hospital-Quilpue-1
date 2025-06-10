Imports Datos
Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Recha_Mues
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
    Public Shared Function Form_Table(ByVal ID_USU As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4_RECHAZO)

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = ID_USU

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4_RECHAZO)
        Dim NN As N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4_RECHAZO = New N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4_RECHAZO

        Dim data_paciente2 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_EXAMENES_DESC_RECEPCION_RECHAZO)
        Dim NN2 As N_IRIS_WEBF_BUSCA_ETIQUETAS_EXAMENES_DESC_RECEPCION_RECHAZO = New N_IRIS_WEBF_BUSCA_ETIQUETAS_EXAMENES_DESC_RECEPCION_RECHAZO

        Dim data_paciente3 As List(Of E_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA)
        Dim NN3 As N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA = New N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA


        data_paciente = NN.IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4_RECHAZO(ID_USER)

        For i = 0 To data_paciente.Count - 1
            data_paciente2 = NN2.IRIS_WEBF_BUSCA_ETIQUETAS_EXAMENES_DESC_RECEPCION_RECHAZO(data_paciente(i).ATE_NUM, data_paciente(i).CB_DESC)
            If data_paciente2.Count > 0 Then
                For ii = 0 To data_paciente2.Count - 1
                    If ii = 0 Then
                        data_paciente(i).CF_DESC &= data_paciente2(ii).CF_DESC
                    Else
                        If data_paciente2(ii).CF_DESC <> (data_paciente2(ii - 1).CF_DESC) Then
                            data_paciente(i).CF_DESC &= " - " & data_paciente2(ii).CF_DESC
                        End If
                    End If

                Next ii
            End If
        Next i
        data_paciente3 = NN3.IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA(ID_USER)

        For i = 0 To data_paciente.Count - 1
            data_paciente(i).USU_NIC = data_paciente3(0).USU_NIC
        Next i

        Return data_paciente

    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal NUM_ATE As String, ByVal ID_USU As Integer) As String

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP)
        Dim NN As N_IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP = New N_IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = ID_USU

        Dim data_paciente2 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_RECHAZO)
        Dim NN2 As N_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_RECHAZO = New N_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_RECHAZO

        Dim data_paciente3 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_GUARDADA_RECEPCION_ETIQUETAS_RECHAZO)
        Dim NN3 As N_IRIS_WEBF_BUSCA_ETIQUETA_GUARDADA_RECEPCION_ETIQUETAS_RECHAZO = New N_IRIS_WEBF_BUSCA_ETIQUETA_GUARDADA_RECEPCION_ETIQUETAS_RECHAZO

        If (NUM_ATE.Length) < 10 Then
            data_paciente = NN.IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP(NUM_ATE)

            If data_paciente.Count > 0 Then
                'Serializar con JSON
                Serializer.MaxJsonLength = 999999999
                Serializer.Serialize(data_paciente, str_Builder)
                datas = str_Builder.ToString
                Return datas
            Else
                Return "null"
            End If
        Else
            Dim CB As String = ""
            Dim ID_ATE As String = ""

            CB = NUM_ATE.Substring(0, 2)
            NUM_ATE = NUM_ATE.Substring(2, 8)
            NUM_ATE = NUM_ATE.TrimStart("0")

            data_paciente = NN.IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP(NUM_ATE)

            If data_paciente.Count > 0 Then
                data_paciente2 = NN2.IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_RECHAZO(NUM_ATE, CB)

                If data_paciente2.Count > 0 Then
                    'For i = 0 To data_paciente2.Count - 1
                    data_paciente3 = NN3.IRIS_WEBF_BUSCA_ETIQUETA_GUARDADA_RECEPCION_ETIQUETAS_RECHAZO(data_paciente2(0).ID_ATENCION, data_paciente2(0).ATE_NUM, data_paciente2(0).CB_COD, ID_USER)
                    'Next i

                    If data_paciente3.Count > 0 Then
                        Return "entregada"
                    Else
                        Return "Modal_Confirmar_rechazo_DIRECTO"
                    End If
                Else
                    Return "null"
                End If

            Else
                Return "null"
            End If

        End If

        'Serializar con JSON
        Serializer.MaxJsonLength = 999999999
        Serializer.Serialize(data_paciente, str_Builder)
        datas = str_Builder.ToString
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable_Marcar(NUM_ATE As String, ID_ATE As Integer, MUESTRA() As Object, ID_TIPO As Integer, OBSER As String, TEXT_MOTIVO As String, ID_USU As Integer, idCodigoFonasaMarcado As Integer, MENSAJE_GENERADO As String) As String

        Dim VALOR_TIPO_OBSERVACION As String = $"{TEXT_MOTIVO} - {OBSER}"

        Dim test = ""

        For Each cb In MUESTRA
            test = D_IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA_RECHAZO.IRIS_WEB_GRABA_RECHAZO_ETIQUETA_UPDATE_ATE_RES(ID_ATE, NUM_ATE, cb, ID_USU, ID_TIPO, OBSER, VALOR_TIPO_OBSERVACION, idCodigoFonasaMarcado, MENSAJE_GENERADO)
        Next

        Return test
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable2(ByVal N_ATE As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ENVIO_NUEVO2)
        Dim NN As N_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ENVIO_NUEVO2 = New N_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ENVIO_NUEVO2
        Dim data_paciente2 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____6_ENVIO2)
        Dim NN2 As N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____6_ENVIO2 = New N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____6_ENVIO2
        Dim data_paciente3 As List(Of E_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA)
        Dim NN3 As N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA = New N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA

        data_paciente = NN.IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ENVIO_NUEVO2(N_ATE)

        If data_paciente.Count > 0 Then
            For i = 0 To data_paciente.Count - 1

                data_paciente2 = NN2.IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____6_ENVIO2(0, data_paciente(i).CB_DESC, data_paciente(i).ATE_NUM)

                If data_paciente2.Count > 0 Then
                    data_paciente(i).EST_DESCRIPCION = data_paciente2(0).EST_DESCRIPCION
                    data_paciente(i).ENVIO_ETI_FECHA = data_paciente2(0).ENVIO_ETI_FECHA
                    data_paciente(i).PAC_NOMBRE = data_paciente2(0).PAC_NOMBRE
                    data_paciente(i).PAC_APELLIDO = data_paciente2(0).PAC_APELLIDO

                    data_paciente3 = NN3.IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA(data_paciente2(0).ID_USUARIO)

                    data_paciente(i).USU_NIC = data_paciente3(0).USU_NIC
                Else
                    Return "null"
                End If
            Next i


            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_paciente, str_Builder)
            datas = str_Builder.ToString
            Return datas
        Else
            Return "null"
        End If


        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable3(ByVal N_ATE As String, ByVal ID_USU As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas

        Dim data_bus_eti_x_folio As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS_RECHAZO)
        Dim NN_bus_eti_x_folio As N_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS_RECHAZO = New N_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS_RECHAZO

        Dim data_bus_est_det As List(Of E_IRIS_WEBF_BUSCA_ESTADO_DETERMINACION_RECEPCION_MUESTRA_RECHAZO)
        Dim NN_bus_est_det As N_IRIS_WEBF_BUSCA_ESTADO_DETERMINACION_RECEPCION_MUESTRA_RECHAZO = New N_IRIS_WEBF_BUSCA_ESTADO_DETERMINACION_RECEPCION_MUESTRA_RECHAZO

        Dim data_paciente3 As List(Of E_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA)
        Dim NN3 As N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA = New N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = ID_USU

        data_bus_eti_x_folio = NN_bus_eti_x_folio.IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS_RECHAZO(N_ATE)

        If data_bus_eti_x_folio.Count > 0 Then
            For i = 0 To data_bus_eti_x_folio.Count - 1

                data_bus_est_det = NN_bus_est_det.IRIS_WEBF_BUSCA_ESTADO_DETERMINACION_RECEPCION_MUESTRA_RECHAZO(data_bus_eti_x_folio(i).ID_ATENCION, data_bus_eti_x_folio(i).ID_PER, data_bus_eti_x_folio(i).CB_DESC)
                If data_bus_est_det.Count > 0 Then
                    data_bus_eti_x_folio(i).EST_DESCRIPCION = data_bus_est_det(0).EST_DESCRIPCION
                    data_bus_eti_x_folio(i).ATE_FEC_RECHAZO = data_bus_est_det(0).ATE_FEC_RECHAZO
                    data_bus_eti_x_folio(i).PAC_NOMBRE = data_bus_est_det(0).PAC_NOMBRE
                    data_bus_eti_x_folio(i).PAC_APELLIDO = data_bus_est_det(0).PAC_APELLIDO
                    data_bus_eti_x_folio(i).ID_PRUEBA = data_bus_est_det(0).ID_PRUEBA
                    data_bus_eti_x_folio(i).ATE_USU_RECHAZO = data_bus_est_det(0).ATE_USU_RECHAZO
                    data_bus_eti_x_folio(i).ATE_NUM_OMI = data_bus_est_det(0).ATE_NUM_OMI
                    data_bus_eti_x_folio(i).ATE_CODIGO_TEST = data_bus_est_det(0).ATE_CODIGO_TEST
                    data_bus_eti_x_folio(i).ID_CODIGO_FONASA = data_bus_est_det(0).ID_CODIGO_FONASA
                    data_bus_eti_x_folio(i).TP_RECHA_DESC = data_bus_est_det(0).TP_RECHA_DESC

                    If data_bus_eti_x_folio(i).ATE_USU_RECHAZO <> "-/-" Then
                        data_paciente3 = NN3.IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA(data_bus_eti_x_folio(i).ATE_USU_RECHAZO)
                        data_bus_eti_x_folio(i).USU_NIC = data_paciente3(0).USU_NIC
                    Else
                        data_bus_eti_x_folio(i).USU_NIC = "-/-"
                    End If



                End If

            Next i


            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_bus_eti_x_folio, str_Builder)
            datas = str_Builder.ToString
            Return datas
        Else
            Return "null"
        End If


        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function Guardar_Lote() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim Correlativo_Lote As List(Of E_IRIS_WEBF_BUSCA_CORRELATIVO_LOTE_RECHAZO)
        Dim corre As Integer = 0
        Dim NN_Correlativo_Lote As N_IRIS_WEBF_BUSCA_CORRELATIVO_LOTE_RECHAZO = New N_IRIS_WEBF_BUSCA_CORRELATIVO_LOTE_RECHAZO

        Correlativo_Lote = NN_Correlativo_Lote.IRIS_WEBF_BUSCA_CORRELATIVO_LOTE_RECHAZO()
        corre = Correlativo_Lote(0).IDENTIFICADOR

        'Serializar con JSON
        Serializer.MaxJsonLength = 999999999
        Serializer.Serialize(corre, str_Builder)
        datas = str_Builder.ToString
        Return datas

    End Function

    <Services.WebMethod()>
    Public Shared Function Guardar_Lote2(ByVal correlativin As Integer, ByVal ID_USU As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_guardar As List(Of E_IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS_RECHAZO)
        Dim NN2 As N_IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS_RECHAZO = New N_IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS_RECHAZO
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = ID_USU


        Dim corre_update_Lote As Integer = 0
        Dim NN_Update_Lote As N_IRIS_WEBF_UPDATE_LOTE_RECEPCION_RECHAZO = New N_IRIS_WEBF_UPDATE_LOTE_RECEPCION_RECHAZO

        data_guardar = NN2.IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS_RECHAZO(correlativin, ID_USER)

        corre_update_Lote = NN_Update_Lote.IRIS_WEBF_UPDATE_LOTE_RECEPCION_RECHAZO(data_guardar(0).IDENTIFICADOR, ID_USER)

        Return "null"

    End Function

    <Services.WebMethod()>
    Public Shared Function Ajax_Pendiente_Marcar(ByVal ATE_NUM As Integer, ByVal CB As String, ByVal ID_RECEP_ETI_RECHAZO_SUPREMO As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_elimina As Integer = 0
        Dim NN_eliminar As N_IRIS_WEBF_ELIMINA_RECEPCION_ETIQUETA_RECHAZO = New N_IRIS_WEBF_ELIMINA_RECEPCION_ETIQUETA_RECHAZO

        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_RECHAZO)
        Dim NN_paciente As N_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_RECHAZO = New N_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_RECHAZO

        Dim data_update_estado As Integer = 0
        Dim NN_update_estado As N_IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_QUITA_ESTADO_RECHAZO = New N_IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_QUITA_ESTADO_RECHAZO

        Dim data_update_estado2 As Integer = 0
        Dim NN_update_estado2 As N_IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_RECHAZO_INSERTA_RECHAZO = New N_IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_RECHAZO_INSERTA_RECHAZO
        Dim NADA As String = ""
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

        data_elimina = NN_eliminar.IRIS_WEBF_ELIMINA_RECEPCION_ETIQUETA_RECHAZO(ID_RECEP_ETI_RECHAZO_SUPREMO)

        data_paciente = NN_paciente.IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_RECHAZO(ATE_NUM, CB)

        If data_paciente.Count > 0 Then
            For i = 0 To data_paciente.Count - 1
                data_update_estado = NN_update_estado.IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_QUITA_ESTADO_RECHAZO(data_paciente(i).ID_ATE_RES, ID_USER)
                data_update_estado2 = NN_update_estado2.IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_RECHAZO_INSERTA_RECHAZO(data_paciente(i).ID_ATE_RES, NADA)
            Next i
        Else
            Return "null"
        End If

        Return "null"
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_Modal_Cargar_Doble_click(ByVal NUM_ATE As String) As String

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas

        Dim data_bus_eti_x_folio As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS_RECHAZO)
        Dim NN_bus_eti_x_folio As N_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS_RECHAZO = New N_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS_RECHAZO

        Dim data_bus_est_det As List(Of E_IRIS_WEBF_BUSCA_ESTADO_DETERMINACION_RECEPCION_MUESTRA_RECHAZO)
        Dim NN_bus_est_det As N_IRIS_WEBF_BUSCA_ESTADO_DETERMINACION_RECEPCION_MUESTRA_RECHAZO = New N_IRIS_WEBF_BUSCA_ESTADO_DETERMINACION_RECEPCION_MUESTRA_RECHAZO

        Dim data_paciente3 As List(Of E_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA)
        Dim NN3 As N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA = New N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

        data_bus_eti_x_folio = NN_bus_eti_x_folio.IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS_RECHAZO(NUM_ATE)

        If data_bus_eti_x_folio.Count > 0 Then
            For i = 0 To data_bus_eti_x_folio.Count - 1

                data_bus_est_det = NN_bus_est_det.IRIS_WEBF_BUSCA_ESTADO_DETERMINACION_RECEPCION_MUESTRA_RECHAZO(data_bus_eti_x_folio(i).ID_ATENCION, data_bus_eti_x_folio(i).ID_PER, data_bus_eti_x_folio(i).CB_DESC)
                If data_bus_est_det.Count > 0 Then
                    data_bus_eti_x_folio(i).EST_DESCRIPCION = data_bus_est_det(0).EST_DESCRIPCION
                    data_bus_eti_x_folio(i).ATE_FEC_RECHAZO = data_bus_est_det(0).ATE_FEC_RECHAZO
                    data_bus_eti_x_folio(i).PAC_NOMBRE = data_bus_est_det(0).PAC_NOMBRE
                    data_bus_eti_x_folio(i).PAC_APELLIDO = data_bus_est_det(0).PAC_APELLIDO
                    data_bus_eti_x_folio(i).ID_PRUEBA = data_bus_est_det(0).ID_PRUEBA
                    data_bus_eti_x_folio(i).ATE_USU_RECHAZO = data_bus_est_det(0).ATE_USU_RECHAZO
                    data_bus_eti_x_folio(i).TP_RECHA_DESC = data_bus_est_det(0).TP_RECHA_DESC

                    If data_bus_eti_x_folio(i).ATE_USU_RECHAZO <> "-/-" Then
                        data_paciente3 = NN3.IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA(data_bus_eti_x_folio(i).ATE_USU_RECHAZO)
                        data_bus_eti_x_folio(i).USU_NIC = data_paciente3(0).USU_NIC
                    Else
                        data_bus_eti_x_folio(i).USU_NIC = "-/-"
                    End If



                End If

            Next i


            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_bus_eti_x_folio, str_Builder)
            datas = str_Builder.ToString
            Return datas
        Else
            Return "null"
        End If


        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function Info(ByVal ID_USU As Integer) As List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES_VER)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES_VER)
        Dim NN As N_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES_VER = New N_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES_VER

        data_paciente = NN.IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES_VER(ID_USU)

        Return data_paciente

    End Function

    <Services.WebMethod()>
    Public Shared Function Exa_Info(ByVal ID_Pac As Integer) As List(Of E_IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER)
        Dim NN As N_IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER = New N_IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

        data_paciente = NN.IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER(ID_Pac)




        Return data_paciente

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO() As List(Of E_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_RECHAZO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_RECHAZO)
        Dim NN As N_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_RECHAZO = New N_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_RECHAZO

        data_paciente = NN.IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_RECHAZO()

        Return data_paciente

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2(ByVal NUMLOTE As Integer) As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_2)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_2)
        Dim NN As N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_2 = New N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_2
        Dim data_paciente2 As List(Of E_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA)
        Dim NN2 As N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA = New N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA

        data_paciente = NN.IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_2(NUMLOTE, 0)
        If data_paciente.Count > 0 Then
            For i = 0 To data_paciente.Count - 1
                data_paciente2 = NN2.IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA(data_paciente(i).ID_USUARIO)
                data_paciente(i).USU_NIC = data_paciente2(0).USU_NIC
            Next i
        End If
        Return data_paciente

    End Function

    <Services.WebMethod()>
    Public Shared Function GUARDAR_AL_PISTOLEAR_EL_TUBO(ByVal NUM_ATE As String, ByVal ID_TIPO As Integer, ByVal OBSER As String, ByVal TEXT_MOTIVO As String) As String

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP)
        Dim NN As N_IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP = New N_IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP

        Dim data_paciente2 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_RECHAZO)
        Dim NN2 As N_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_RECHAZO = New N_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_RECHAZO

        Dim update_paciente3 As Integer = 0
        Dim NN3 As N_IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA_RECHAZO = New N_IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA_RECHAZO

        Dim update_paciente4 As Integer = 0
        Dim NN4 As N_IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_RECHAZO = New N_IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_RECHAZO

        Dim update_paciente5 As Integer = 0
        Dim NN5 As N_IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_RECHAZO_INSERTA_RECHAZO = New N_IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_RECHAZO_INSERTA_RECHAZO
        Dim VALOR_TIPO_OBSERVACION As String
        VALOR_TIPO_OBSERVACION = TEXT_MOTIVO & " " & OBSER

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)


        Dim contador As Integer = 0
        Dim CB As String = ""
        Dim ID_ATE As String = ""

        CB = NUM_ATE.Substring(0, 2)
        NUM_ATE = NUM_ATE.Substring(2, 8)
        NUM_ATE = NUM_ATE.TrimStart("0")

        data_paciente = NN.IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP(NUM_ATE)

        update_paciente3 = NN3.IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA_RECHAZO(data_paciente(0).ID_ATENCION, NUM_ATE, CB, ID_USER, ID_TIPO, OBSER)

        data_paciente2 = NN2.IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_RECHAZO(NUM_ATE, CB)

        If data_paciente2.Count > 0 Then
            For i = 0 To data_paciente2.Count - 1
                update_paciente4 = NN4.IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_RECHAZO(data_paciente2(i).ID_ATE_RES, ID_USER)
                update_paciente5 = NN5.IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_RECHAZO_INSERTA_RECHAZO(data_paciente2(i).ID_ATE_RES, VALOR_TIPO_OBSERVACION)
            Next i
            Return "tables"
        Else
            Return "null"
        End If

        Return "null"

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        If C_P_ADMIN = 0 Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
End Class