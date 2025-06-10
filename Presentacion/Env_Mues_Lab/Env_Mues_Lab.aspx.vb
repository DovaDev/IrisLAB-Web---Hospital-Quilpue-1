Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Env_Mues_Lab
    Inherits System.Web.UI.Page

    'Dim objSession As HttpSessionState = HttpContext.Current.Session
    'Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

    'Dim C_Id_User As String = Convert.ToString(Request.Cookies.[Get]("ID_USER").Value)

    <Services.WebMethod()>
    Public Shared Function Form_Table() As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2)

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2)
        Dim NN As N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2 = New N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2
        Dim data_paciente3 As List(Of E_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA)
        Dim NN3 As N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA = New N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA

        data_paciente = NN.IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2_CON_PENDIENTES_666(ID_USER)
        data_paciente3 = NN3.IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA(ID_USER)

        For i = 0 To data_paciente.Count - 1
            data_paciente(i).USU_NIC = data_paciente3(0).USU_NIC
        Next i

        Return data_paciente

    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal NUM_ATE As String) As String

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP_ENVIO)
        Dim NN As N_IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP_ENVIO = New N_IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP_ENVIO
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

        Dim data_paciente2 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_ENVIO)
        Dim NN2 As N_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_ENVIO = New N_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_ENVIO

        Dim update_paciente3 As Integer = 0
        Dim NN3 As N_IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_ENVIO = New N_IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_ENVIO

        Dim data_paciente4 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_GUARDADA_RECEPCION_ETIQUETAS_ENVIO)
        Dim NN4 As N_IRIS_WEBF_BUSCA_ETIQUETA_GUARDADA_RECEPCION_ETIQUETAS_ENVIO = New N_IRIS_WEBF_BUSCA_ETIQUETA_GUARDADA_RECEPCION_ETIQUETAS_ENVIO

        Dim update_paciente5 As Integer = 0
        Dim NN5 As N_IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA_ENVIO = New N_IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA_ENVIO
        '----------------------------------------------------------------------------------------------------------------------------------
        'Dim data_paciente6 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2)
        Dim NN6 As N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2 = New N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2

        'Dim data_paciente7 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_RECEPCION_EN_PROCESO)
        Dim NN7 As N_IRIS_WEBF_BUSCA_ETIQUETA_RECEPCION_EN_PROCESO = New N_IRIS_WEBF_BUSCA_ETIQUETA_RECEPCION_EN_PROCESO

        'Dim data_paciente8 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____6)
        Dim NN8 As N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____6 = New N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____6

        If (NUM_ATE.Length) < 10 Then
            data_paciente = NN.IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP_ENVIO(NUM_ATE)
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


            'CB = NUM_ATE.Substring(0, 2)
            'ID_ATE = NUM_ATE.Substring(5)

            data_paciente = NN.IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP_ENVIO(NUM_ATE)
            ' Mostrar todos los datos de data_paciente
            For Each paciente In data_paciente
                Debug.WriteLine(paciente.ATE_ID_ESTADO_TM)
            Next
            If data_paciente.Count > 0 Then
                For Each paciente In data_paciente
                    If paciente.ATE_ID_ESTADO_TM <> 8 Then
                        Return "sin-tm"
                    End If
                Next
                data_paciente2 = NN2.IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_ENVIO(NUM_ATE, CB)
                If data_paciente2.Count > 0 Then
                    For i = 0 To data_paciente2.Count - 1
                        update_paciente3 = NN3.IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_ENVIO(data_paciente2(i).ID_ATE_RES, ID_USER) '1 = ID USUARIO
                    Next i

                    data_paciente4 = NN4.IRIS_WEBF_BUSCA_ETIQUETA_GUARDADA_RECEPCION_ETIQUETAS_ENVIO(data_paciente2(0).ID_ATENCION, data_paciente2(0).ATE_NUM, data_paciente2(0).CB_COD, ID_USER) '1 = ID USUARIO

                    If data_paciente4.Count > 0 Then
                        update_paciente5 = 0
                        Return "entregada"
                    Else
                        update_paciente5 = NN5.IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA_ENVIO(data_paciente2(0).ID_ATENCION, data_paciente2(0).ATE_NUM, data_paciente2(0).CB_COD, ID_USER) '1 = ID USUARIO
                        Return "table"
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
    Public Shared Function Guardar_de_una(ByVal NUM_ATE As String) As String

        'Declaraciones internas
        Dim data_paciente2 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_ENVIO)
        Dim NN2 As N_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_ENVIO = New N_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_ENVIO

        Dim update_paciente3 As Integer = 0
        Dim NN3 As N_IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_ENVIO = New N_IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_ENVIO

        Dim data_paciente4 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_GUARDADA_RECEPCION_ETIQUETAS_ENVIO)
        Dim NN4 As N_IRIS_WEBF_BUSCA_ETIQUETA_GUARDADA_RECEPCION_ETIQUETAS_ENVIO = New N_IRIS_WEBF_BUSCA_ETIQUETA_GUARDADA_RECEPCION_ETIQUETAS_ENVIO

        Dim update_paciente5 As Integer = 0
        Dim NN5 As N_IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA_ENVIO = New N_IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA_ENVIO

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

        'Declaraciones internas
        Dim data_paciente_deuna As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ENVIO_NUEVO2)
        Dim NN_deuna As N_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ENVIO_NUEVO2 = New N_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ENVIO_NUEVO2

        Dim hola As String = ""

        data_paciente_deuna = NN_deuna.IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ENVIO_NUEVO2(NUM_ATE)

        If data_paciente_deuna.Count > 0 Then
            For ii = 0 To data_paciente_deuna.Count - 1

                data_paciente2 = NN2.IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_ENVIO(NUM_ATE, data_paciente_deuna(ii).CB_DESC)
                If data_paciente2.Count > 0 Then

                    For i = 0 To data_paciente2.Count - 1
                        update_paciente3 = NN3.IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_ENVIO(data_paciente2(i).ID_ATE_RES, ID_USER)
                    Next i

                    data_paciente4 = NN4.IRIS_WEBF_BUSCA_ETIQUETA_GUARDADA_RECEPCION_ETIQUETAS_ENVIO(data_paciente2(0).ID_ATENCION, data_paciente2(0).ATE_NUM, data_paciente2(0).CB_COD, ID_USER)
                    If data_paciente4.Count > 0 Then
                        update_paciente5 = 0
                    Else
                        update_paciente5 = NN5.IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA_ENVIO(data_paciente2(0).ID_ATENCION, data_paciente2(0).ATE_NUM, data_paciente2(0).CB_COD, ID_USER)
                    End If
                End If
            Next ii
            Return "hola"
        Else
            Return "null"
        End If

    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable_Marcar(ByVal NUM_ATE As String, ByVal MUESTRA() As Object) As String

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP_ENVIO)
        Dim NN As N_IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP_ENVIO = New N_IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP_ENVIO

        Dim data_paciente2 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_ENVIO)
        Dim NN2 As N_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_ENVIO = New N_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_ENVIO

        Dim update_paciente3 As Integer = 0
        Dim NN3 As N_IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_ENVIO = New N_IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_ENVIO

        Dim data_paciente4 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_GUARDADA_RECEPCION_ETIQUETAS_ENVIO)
        Dim NN4 As N_IRIS_WEBF_BUSCA_ETIQUETA_GUARDADA_RECEPCION_ETIQUETAS_ENVIO = New N_IRIS_WEBF_BUSCA_ETIQUETA_GUARDADA_RECEPCION_ETIQUETAS_ENVIO

        Dim update_paciente5 As Integer = 0
        Dim NN5 As N_IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA_ENVIO = New N_IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA_ENVIO

        Dim data_paciente6 As E_List_wDict3
        Dim NN6 As N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2 = New N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2

        Dim data_paciente7 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_RECEPCION_EN_PROCESO_ENVIO)
        Dim NN7 As N_IRIS_WEBF_BUSCA_ETIQUETA_RECEPCION_EN_PROCESO_ENVIO = New N_IRIS_WEBF_BUSCA_ETIQUETA_RECEPCION_EN_PROCESO_ENVIO

        Dim data_paciente8 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____6_ENVIO2)
        Dim NN8 As N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____6_ENVIO2 = New N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____6_ENVIO2

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

        data_paciente = NN.IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP_ENVIO(NUM_ATE)
        Dim contador As Integer = 0
        For ii = 0 To (MUESTRA.GetUpperBound(0))
            Dim CB As String = MUESTRA(ii)

            If data_paciente.Count > 0 Then
                data_paciente2 = NN2.IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_ENVIO(NUM_ATE, CB)
                If data_paciente2.Count > 0 Then
                    For i = 0 To data_paciente2.Count - 1
                        update_paciente3 = NN3.IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_ENVIO(data_paciente2(i).ID_ATE_RES, ID_USER) '1 = ID USUARIO
                    Next i

                    data_paciente4 = NN4.IRIS_WEBF_BUSCA_ETIQUETA_GUARDADA_RECEPCION_ETIQUETAS_ENVIO(data_paciente2(0).ID_ATENCION, data_paciente2(0).ATE_NUM, data_paciente2(0).CB_COD, ID_USER) '1 = ID USUARIO

                    If data_paciente4.Count > 0 Then
                        update_paciente5 = 0
                    Else
                        update_paciente5 = NN5.IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA_ENVIO(data_paciente2(0).ID_ATENCION, data_paciente2(0).ATE_NUM, data_paciente2(0).CB_COD, ID_USER) '1 = ID USUARIO
                        'Return "table"
                    End If

                Else
                    'Return "null"
                End If
            Else
                'Return "null"
            End If

            data_paciente6 = NN6.IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2(ID_USER) ' 1 = ID USUARIO ***********AAAAUAUAUAUAUAUAUAUAUA

            If data_paciente6.List_Data.Count > 0 Then
                For i = 0 To data_paciente6.List_Data.Count - 1
                    If data_paciente6.List_Data(0).ENVIO_ETI_CURVA = "" Or data_paciente6.List_Data(0).ENVIO_ETI_NUM_ATE = "" Then
                        ' Etiqueta recepcionada
                        Return "recepcionada"
                    End If
                Next i

                'For i = 0 To data_paciente6.Count - 1
                '    If data_paciente6(i).RECEP_ETI_CURVA = data_paciente6(i).CB_DESC And data_paciente6(i).Then Then
                'Next i

                data_paciente7 = NN7.IRIS_WEBF_BUSCA_ETIQUETA_RECEPCION_EN_PROCESO_ENVIO(data_paciente6.List_Data(0).ATE_NUM, data_paciente6.List_Data(0).ENVIO_ETI_CURVA)
                data_paciente8 = NN8.IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____6_ENVIO2(data_paciente6.List_Data(0).ID_USUARIO, data_paciente6.List_Data(0).ENVIO_ETI_CURVA, data_paciente6.List_Data(0).ATE_NUM)

                'Return "recepcionada"
            Else
                'Return "null"
            End If
            contador += 1
        Next ii

        'Serializar con JSON
        Serializer.MaxJsonLength = 999999999
        Serializer.Serialize(data_paciente, str_Builder)
        datas = str_Builder.ToString

        If contador > 1 Then
            Return "tables"
        Else
            Return "table"
        End If

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
    Public Shared Function Llenar_DataTable3(ByVal N_ATE As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        'Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS)
        'Dim NN As N_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS = New N_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS
        Dim data_paciente2 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8_ENVIO)
        Dim NN2 As N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8_ENVIO = New N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8_ENVIO
        Dim data_paciente3 As List(Of E_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA)
        Dim NN3 As N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA = New N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA
        '----------------------------------------------------------------------------------------------------------------
        Dim data_folio_recep_envio As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ENVIO_NUEVO2)
        Dim NN_folio_recep_envio As N_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ENVIO_NUEVO2 = New N_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ENVIO_NUEVO2


        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

        data_folio_recep_envio = NN_folio_recep_envio.IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ENVIO_NUEVO2(N_ATE)

        If data_folio_recep_envio.Count > 0 Then
            For i = 0 To data_folio_recep_envio.Count - 1

                data_paciente2 = NN2.IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8_ENVIO(ID_USER, data_folio_recep_envio(i).CB_DESC, data_folio_recep_envio(i).ATE_NUM)
                If data_paciente2 IsNot Nothing AndAlso data_paciente2.Count > 0 Then
                    data_folio_recep_envio(i).EST_DESCRIPCION = data_paciente2(0).EST_DESCRIPCION
                    data_folio_recep_envio(i).ENVIO_ETI_FECHA = data_paciente2(0).ENVIO_ETI_FECHA
                    data_folio_recep_envio(i).PAC_NOMBRE = data_paciente2(0).PAC_NOMBRE
                    data_folio_recep_envio(i).PAC_APELLIDO = data_paciente2(0).PAC_APELLIDO

                    data_paciente3 = NN3.IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA(data_paciente2(0).ID_USUARIO)

                    If data_paciente3 IsNot Nothing AndAlso data_paciente3.Count > 0 Then
                        data_folio_recep_envio(i).USU_NIC = data_paciente3(0).USU_NIC
                    End If
                End If

            Next i


            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_folio_recep_envio, str_Builder)
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
        Dim Correlativo_Lote As List(Of E_IRIS_WEBF_BUSCA_CORRELATIVO_LOTE_ENVIO)
        Dim corre As Integer = 0
        Dim NN_Correlativo_Lote As New N_IRIS_WEBF_BUSCA_CORRELATIVO_LOTE_ENVIO

        Correlativo_Lote = NN_Correlativo_Lote.IRIS_WEBF_BUSCA_CORRELATIVO_LOTE_ENVIO()
        corre = Correlativo_Lote(0).IDENTIFICADOR

        'Serializar con JSON
        Serializer.MaxJsonLength = 999999999
        Serializer.Serialize(corre, str_Builder)
        datas = str_Builder.ToString
        Return datas

    End Function

    <Services.WebMethod()>
    Public Shared Function Guardar_Lote2(ByVal correlativin As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_guardar As List(Of E_IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS_ENVIO)
        Dim NN2 As N_IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS_ENVIO = New N_IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS_ENVIO
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)


        Dim corre_update_Lote As Integer = 0
        Dim NN_Update_Lote As N_IRIS_WEBF_UPDATE_LOTE_RECEPCION_ENVIO = New N_IRIS_WEBF_UPDATE_LOTE_RECEPCION_ENVIO

        data_guardar = NN2.IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS_ENVIO(correlativin, ID_USER)                                          '1 = ID USUARIO

        corre_update_Lote = NN_Update_Lote.IRIS_WEBF_UPDATE_LOTE_RECEPCION_ENVIO(data_guardar(0).IDENTIFICADOR, ID_USER)    '1 = ID USUARIO

        Return "null"

    End Function

    <Services.WebMethod()>
    Public Shared Function Ajax_Ver_Pendiente() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)
        Dim lista_pend As List(Of E_IRIS_WEBF_BUSCA_PENDIENTES_POR_USUARIO)

        Dim NN_ExamenDet As New N_Exa_Esp_V
        lista_pend = NN_ExamenDet.IRIS_WEBF_BUSCA_PENDIENTES_POR_USUARIO(ID_USER)

        If lista_pend.Count > 0 Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(lista_pend, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = Nothing
        End If
        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function Ajax_Pendiente_Marcar(ByVal ATE_NUM As Integer, ByVal CB As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_elimina As Integer = 0
        Dim NN_eliminar As N_IRIS_WEBF_ELIMINA_RECEPCION_ETIQUETA_2_ENVIO = New N_IRIS_WEBF_ELIMINA_RECEPCION_ETIQUETA_2_ENVIO

        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_ENVIO)
        Dim NN_paciente As N_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_ENVIO = New N_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_ENVIO

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)
        Dim data_update_estado As Integer = 0
        Dim NN_update_estado As N_IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_QUITA_ESTADO_ENVIO = New N_IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_QUITA_ESTADO_ENVIO

        data_elimina = NN_eliminar.IRIS_WEBF_ELIMINA_RECEPCION_ETIQUETA_2_ENVIO(ATE_NUM, CB)

        data_paciente = NN_paciente.IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_ENVIO(ATE_NUM, CB)

        If data_paciente.Count > 0 Then
            For i = 0 To data_paciente.Count - 1
                data_update_estado = NN_update_estado.IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_QUITA_ESTADO_ENVIO(data_paciente(i).ID_ATENCION, ID_USER) ' 1 = ID USUARIO
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

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ENVIO_NUEVO2)
        Dim NN As N_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ENVIO_NUEVO2 = New N_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ENVIO_NUEVO2

        Dim data_paciente2 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8_ENVIO)
        Dim NN2 As N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8_ENVIO = New N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8_ENVIO
        'Dim data_paciente2 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____6_ENVIO2)
        'Dim NN2 As N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____6_ENVIO2 = New N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____6_ENVIO2
        Dim data_paciente3 As List(Of E_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA)
        Dim NN3 As N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA = New N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA

        data_paciente = NN.IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ENVIO_NUEVO2(NUM_ATE)

        If data_paciente.Count > 0 Then
            For i = 0 To data_paciente.Count - 1
                'IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8_ENVIO
                data_paciente2 = NN2.IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8_ENVIO(ID_USER, data_paciente(i).CB_DESC, data_paciente(i).ATE_NUM)
                If data_paciente2.Count > 0 Then
                    data_paciente(i).EST_DESCRIPCION = data_paciente2(0).EST_DESCRIPCION
                    data_paciente(i).ENVIO_ETI_FECHA = data_paciente2(0).ENVIO_ETI_FECHA
                    data_paciente(i).PAC_NOMBRE = data_paciente2(0).PAC_NOMBRE
                    data_paciente(i).PAC_APELLIDO = data_paciente2(0).PAC_APELLIDO

                    data_paciente3 = NN3.IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA(data_paciente2(0).ID_USUARIO)

                    data_paciente(i).USU_NIC = data_paciente3(0).USU_NIC

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
    Public Shared Function IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO() As List(Of E_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO)
        Dim NN As N_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO = New N_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO

        data_paciente = NN.IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO()

        Return data_paciente

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2(ByVal NUMLOTE As Integer) As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)
        Dim NN As N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO = New N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO
        Dim data_paciente2 As List(Of E_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA)
        Dim NN2 As N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA = New N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA

        data_paciente = NN.IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO(NUMLOTE)
        If data_paciente.Count > 0 Then
            For i = 0 To data_paciente.Count - 1
                data_paciente2 = NN2.IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA(data_paciente(i).ID_USUARIO)
                data_paciente(i).USU_NIC = data_paciente2(0).USU_NIC
            Next i
        End If
        Return data_paciente

    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        'If C_P_ADMIN = 0 Or C_P_ADMIN = 1 Then
        'Else
        '    Response.Redirect("~/Index.aspx")
        'End If
    End Sub

End Class