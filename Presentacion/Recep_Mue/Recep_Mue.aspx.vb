Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Recep_Mue
    Inherits System.Web.UI.Page

    'Dim objSession As HttpSessionState = HttpContext.Current.Session
    'Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

    'Dim C_Id_User As String = Convert.ToString(Request.Cookies.[Get]("ID_USER").Value)

    <Services.WebMethod()>
    Public Shared Function Form_Table() As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4)

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4)
        Dim NN As N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4 = New N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4
        Dim data_paciente3 As List(Of E_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA)
        Dim NN3 As N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA = New N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA

        data_paciente = NN.IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4(ID_USER)           '1 = ID USUARIO
        data_paciente3 = NN3.IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA(ID_USER)                      '1 = ID USUARIO

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
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP)
        Dim NN As N_IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP = New N_IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

        Dim data_paciente2 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP)
        Dim NN2 As N_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP = New N_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP

        Dim update_paciente3 As Integer = 0
        Dim NN3 As N_IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION = New N_IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION

        Dim data_paciente4 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_GUARDADA_RECEPCION_ETIQUETAS)
        Dim NN4 As N_IRIS_WEBF_BUSCA_ETIQUETA_GUARDADA_RECEPCION_ETIQUETAS = New N_IRIS_WEBF_BUSCA_ETIQUETA_GUARDADA_RECEPCION_ETIQUETAS

        Dim update_paciente5 As Integer = 0
        Dim NN5 As N_IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA = New N_IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA

        Dim data_paciente6 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4)
        Dim NN6 As N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4 = New N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4

        Dim data_paciente7 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_RECEPCION_EN_PROCESO)
        Dim NN7 As N_IRIS_WEBF_BUSCA_ETIQUETA_RECEPCION_EN_PROCESO = New N_IRIS_WEBF_BUSCA_ETIQUETA_RECEPCION_EN_PROCESO

        Dim data_paciente8 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____6)
        Dim NN8 As N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____6 = New N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____6

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


            'CB = NUM_ATE.Substring(0, 2)
            'ID_ATE = NUM_ATE.Substring(5)

            data_paciente = NN.IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP(NUM_ATE)

            If data_paciente.Count > 0 Then
                data_paciente2 = NN2.IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP(NUM_ATE, CB)
                If data_paciente2.Count > 0 Then
                    For i = 0 To data_paciente2.Count - 1
                        update_paciente3 = NN3.IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION(data_paciente2(i).ID_ATE_RES, ID_USER) '1 = ID USUARIO
                    Next i

                    data_paciente4 = NN4.IRIS_WEBF_BUSCA_ETIQUETA_GUARDADA_RECEPCION_ETIQUETAS(data_paciente2(0).ID_ATENCION, data_paciente2(0).ATE_NUM, data_paciente2(0).CB_COD, ID_USER) '1 = ID USUARIO

                    If data_paciente4.Count > 0 Then
                        update_paciente5 = 0
                        Return "entregada"
                    Else
                        update_paciente5 = NN5.IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA(data_paciente2(0).ID_ATENCION, data_paciente2(0).ATE_NUM, data_paciente2(0).CB_COD, ID_USER) '1 = ID USUARIO
                        Return "table"
                    End If

                Else
                    Return "null"
                End If
            Else
                Return "null"
            End If

            data_paciente6 = NN6.IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4(ID_USER) ' 1 = ID USUARIO

            If data_paciente6.Count > 0 Then
                For i = 0 To data_paciente6.Count - 1
                    If data_paciente6(0).RECEP_ETI_CURVA = "" Or data_paciente6(0).RECEP_ETI_NUM_ATE = "" Then
                        ' Etiqueta recepcionada
                        Return "recepcionada"
                    End If
                Next i

                'For i = 0 To data_paciente6.Count - 1
                '    If data_paciente6(i).RECEP_ETI_CURVA = data_paciente6(i).CB_DESC And data_paciente6(i).Then Then
                'Next i

                data_paciente7 = NN7.IRIS_WEBF_BUSCA_ETIQUETA_RECEPCION_EN_PROCESO(data_paciente6(0).ATE_NUM, data_paciente6(0).RECEP_ETI_CURVA)
                data_paciente8 = NN8.IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____6(data_paciente6(0).ID_USUARIO, data_paciente6(0).RECEP_ETI_CURVA, data_paciente6(0).ATE_NUM)

                Return "recepcionada"
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
    Public Shared Function Llenar_DataTable_Marcar(ByVal NUM_ATE As String, ByVal MUESTRA() As Object) As String

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP)
        Dim NN As N_IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP = New N_IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP

        Dim data_paciente2 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP)
        Dim NN2 As N_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP = New N_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP

        Dim update_paciente3 As Integer = 0
        Dim NN3 As N_IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION = New N_IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION

        Dim data_paciente4 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_GUARDADA_RECEPCION_ETIQUETAS)
        Dim NN4 As N_IRIS_WEBF_BUSCA_ETIQUETA_GUARDADA_RECEPCION_ETIQUETAS = New N_IRIS_WEBF_BUSCA_ETIQUETA_GUARDADA_RECEPCION_ETIQUETAS

        Dim update_paciente5 As Integer = 0
        Dim NN5 As N_IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA = New N_IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA

        Dim data_paciente6 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4)
        Dim NN6 As N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4 = New N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4

        Dim data_paciente7 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_RECEPCION_EN_PROCESO)
        Dim NN7 As N_IRIS_WEBF_BUSCA_ETIQUETA_RECEPCION_EN_PROCESO = New N_IRIS_WEBF_BUSCA_ETIQUETA_RECEPCION_EN_PROCESO

        Dim data_paciente8 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____6)
        Dim NN8 As N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____6 = New N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____6

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)
        'Dim CB As String = ""
        'Dim ID_ATE As String = ""

        'CB = NUM_ATE.Substring(0, 2)

        'CB = NUM_ATE.Substring(0, 2)
        'ID_ATE = NUM_ATE.Substring(5)

        data_paciente = NN.IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP(NUM_ATE)
        Dim contador As Integer = 0
        For ii = 0 To (MUESTRA.GetUpperBound(0))
            Dim CB As String = MUESTRA(ii)

            If data_paciente.Count > 0 Then
                data_paciente2 = NN2.IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP(NUM_ATE, CB)
                If data_paciente2.Count > 0 Then
                    For i = 0 To data_paciente2.Count - 1
                        update_paciente3 = NN3.IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION(data_paciente2(i).ID_ATE_RES, ID_USER) '1 = ID USUARIO
                    Next i

                    data_paciente4 = NN4.IRIS_WEBF_BUSCA_ETIQUETA_GUARDADA_RECEPCION_ETIQUETAS(data_paciente2(0).ID_ATENCION, data_paciente2(0).ATE_NUM, data_paciente2(0).CB_COD, ID_USER) '1 = ID USUARIO

                    If data_paciente4.Count > 0 Then
                        update_paciente5 = 0
                    Else
                        update_paciente5 = NN5.IRIS_WEBF_GRABA_ETIQUETA_RECEPCION_ETIQUETA(data_paciente2(0).ID_ATENCION, data_paciente2(0).ATE_NUM, data_paciente2(0).CB_COD, ID_USER) '1 = ID USUARIO
                        Return "table"
                    End If

                Else
                    Return "null"
                End If
            Else
                Return "null"
            End If

            data_paciente6 = NN6.IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4(1) ' 1 = ID USUARIO

            If data_paciente6.Count > 0 Then
                For i = 0 To data_paciente6.Count - 1
                    If data_paciente6(0).RECEP_ETI_CURVA = "" Or data_paciente6(0).RECEP_ETI_NUM_ATE = "" Then
                        ' Etiqueta recepcionada
                        Return "recepcionada"
                    End If
                Next i

                'For i = 0 To data_paciente6.Count - 1
                '    If data_paciente6(i).RECEP_ETI_CURVA = data_paciente6(i).CB_DESC And data_paciente6(i).Then Then
                'Next i

                data_paciente7 = NN7.IRIS_WEBF_BUSCA_ETIQUETA_RECEPCION_EN_PROCESO(data_paciente6(0).ATE_NUM, data_paciente6(0).RECEP_ETI_CURVA)
                data_paciente8 = NN8.IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____6(data_paciente6(0).ID_USUARIO, data_paciente6(0).RECEP_ETI_CURVA, data_paciente6(0).ATE_NUM)

                'Return "recepcionada"
            Else
                Return "null"
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
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS)
        Dim NN As N_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS = New N_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS
        Dim data_paciente2 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8)
        Dim NN2 As N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8 = New N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8
        Dim data_paciente3 As List(Of E_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA)
        Dim NN3 As N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA = New N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA

        data_paciente = NN.IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS(N_ATE)

        If data_paciente.Count > 0 Then
            For i = 0 To data_paciente.Count - 1

                data_paciente2 = NN2.IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8(0, data_paciente(i).CB_DESC, data_paciente(i).ATE_NUM)

                If data_paciente2.Count > 0 Then
                    data_paciente(i).EST_DESCRIPCION = data_paciente2(0).EST_DESCRIPCION
                    data_paciente(i).RECEP_ETI_FECHA = data_paciente2(0).RECEP_ETI_FECHA
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
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS)
        Dim NN As N_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS = New N_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS
        Dim data_paciente2 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8)
        Dim NN2 As N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8 = New N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8
        Dim data_paciente3 As List(Of E_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA)
        Dim NN3 As N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA = New N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)

        data_paciente = NN.IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS(N_ATE)

        If data_paciente.Count > 0 Then
            For i = 0 To data_paciente.Count - 1

                data_paciente2 = NN2.IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8(ID_USER, data_paciente(i).CB_DESC, data_paciente(i).ATE_NUM)
                If data_paciente2.Count > 0 Then
                    data_paciente(i).EST_DESCRIPCION = data_paciente2(0).EST_DESCRIPCION
                    data_paciente(i).RECEP_ETI_FECHA = data_paciente2(0).RECEP_ETI_FECHA
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
    Public Shared Function Guardar_Lote() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim Correlativo_Lote As List(Of E_IRIS_WEBF_BUSCA_CORRELATIVO_LOTE)
        Dim corre As Integer = 0
        Dim NN_Correlativo_Lote As N_IRIS_WEBF_BUSCA_CORRELATIVO_LOTE = New N_IRIS_WEBF_BUSCA_CORRELATIVO_LOTE

        Dim data_guardar As List(Of E_IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS)
        Dim NN2 As N_IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS = New N_IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS

        Dim corre_update_Lote As Integer = 0
        Dim NN_Update_Lote As N_IRIS_WEBF_UPDATE_LOTE_RECEPCION = New N_IRIS_WEBF_UPDATE_LOTE_RECEPCION

        Correlativo_Lote = NN_Correlativo_Lote.IRIS_WEBF_BUSCA_CORRELATIVO_LOTE()
        corre = Correlativo_Lote(0).IDENTIFICADOR

        'data_guardar = NN2.IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS(corre, 1)                                          '1 = ID USUARIO

        'corre_update_Lote = NN_Update_Lote.IRIS_WEBF_UPDATE_LOTE_RECEPCION(data_guardar(0).IDENTIFICADOR, 1)    '1 = ID USUARIO

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
        Dim data_guardar As List(Of E_IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS)
        Dim NN2 As N_IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS = New N_IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)


        Dim corre_update_Lote As Integer = 0
        Dim NN_Update_Lote As N_IRIS_WEBF_UPDATE_LOTE_RECEPCION = New N_IRIS_WEBF_UPDATE_LOTE_RECEPCION

        data_guardar = NN2.IRIS_WEBF_GRABA_LOTE_DE_ETIQUETAS(correlativin, ID_USER)                                          '1 = ID USUARIO

        corre_update_Lote = NN_Update_Lote.IRIS_WEBF_UPDATE_LOTE_RECEPCION(data_guardar(0).IDENTIFICADOR, ID_USER)    '1 = ID USUARIO

        Return "null"

    End Function

    <Services.WebMethod()>
    Public Shared Function Ajax_Pendiente_Marcar(ByVal ATE_NUM As Integer, ByVal CB As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_elimina As Integer = 0
        Dim NN_eliminar As N_IRIS_WEBF_ELIMINA_RECEPCION_ETIQUETA_2 = New N_IRIS_WEBF_ELIMINA_RECEPCION_ETIQUETA_2

        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP)
        Dim NN_paciente As N_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP = New N_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim ID_USER As Integer = CType(objSession("ID_USER"), Integer)
        Dim data_update_estado As Integer = 0
        Dim NN_update_estado As N_IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_QUITA_ESTADO = New N_IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_QUITA_ESTADO

        data_elimina = NN_eliminar.IRIS_WEBF_ELIMINA_RECEPCION_ETIQUETA_2(ATE_NUM, CB)

        data_paciente = NN_paciente.IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP(ATE_NUM, CB)

        If data_paciente.Count > 0 Then
            For i = 0 To data_paciente.Count - 1
                data_update_estado = NN_update_estado.IRIS_WEBF_UPDATE_ESTADO_RECEPCIONADO_RECEPCION_QUITA_ESTADO(data_paciente(i).ID_ATENCION, ID_USER) ' 1 = ID USUARIO
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
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS)
        Dim NN As N_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS = New N_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS
        Dim data_paciente2 As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8)
        Dim NN2 As N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8 = New N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8
        Dim data_paciente3 As List(Of E_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA)
        Dim NN3 As N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA = New N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA

        data_paciente = NN.IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS(NUM_ATE)

        If data_paciente.Count > 0 Then
            For i = 0 To data_paciente.Count - 1

                data_paciente2 = NN2.IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8(0, data_paciente(i).CB_DESC, data_paciente(i).ATE_NUM)
                If data_paciente2.Count > 0 Then
                    data_paciente(i).EST_DESCRIPCION = data_paciente2(0).EST_DESCRIPCION
                    data_paciente(i).RECEP_ETI_FECHA = data_paciente2(0).RECEP_ETI_FECHA
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
    Public Shared Function IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO() As List(Of E_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO)
        Dim NN As N_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO = New N_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO

        data_paciente = NN.IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO()

        Return data_paciente

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2(ByVal NUMLOTE As Integer) As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2)
        Dim NN As N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2 = New N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2
        Dim data_paciente2 As List(Of E_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA)
        Dim NN2 As N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA = New N_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA

        data_paciente = NN.IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2(NUMLOTE)
        If data_paciente.Count > 0 Then
            For i = 0 To data_paciente.Count - 1
                data_paciente2 = NN2.IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA(data_paciente(i).ID_USUARIO)
                data_paciente(i).USU_NIC = data_paciente2(0).USU_NIC
            Next i
        End If
        Return data_paciente

    End Function
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        'If C_P_ADMIN = 0 Then
        '    Response.Redirect("~/Index.aspx")
        'End If
    End Sub
End Class