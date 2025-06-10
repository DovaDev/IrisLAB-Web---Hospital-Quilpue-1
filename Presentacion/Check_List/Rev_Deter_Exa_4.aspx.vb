Imports Entidades
Imports Negocio
Imports Datos
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports System.Web.Script.Serialization
Public Class Rev_Deter_Exa_4
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Exam() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        Dim Data_Exam As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Data_Exam = NN_Exam.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS()
        If (Data_Exam.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Exam, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Det(ByVal ID_CF As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_DETERMINACIONES_POR_CODIGO_FONASA_EST
        Dim Data_Exam As New List(Of E_IRIS_WEBF_BUSCA_DETERMINACIONES_POR_CODIGO_FONASA_EST)
        Data_Exam = NN_Exam.IRIS_WEBF_BUSCA_DETERMINACIONES_POR_CODIGO_FONASA_EST(ID_CF)
        If (Data_Exam.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Exam, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_tp_aviso() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_TP_VALORES_CRITICOS_ACTIVOS
        Dim Data_Exam As New List(Of E_IRIS_WEBF_BUSCA_TP_VALORES_CRITICOS_ACTIVOS)
        Data_Exam = NN_Exam.IRIS_WEBF_BUSCA_TP_VALORES_CRITICOS_ACTIVOS()
        If (Data_Exam.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Exam, str_Builder)
            Return str_Builder.ToString
        Else
            Return Nothing
        End If
    End Function
    '<Services.WebMethod()>
    'Public Shared Function Llenar_DataTable(ByVal DESDE As String, ByVal HASTA As String,
    '                                        ByVal ID_CF As Integer,
    '                                     ByVal MUESTRA() As Object) As String
    '    'Declaraciones del Serializador
    '    Dim Serializer As New JavaScriptSerializer
    '    Dim str_Builder As New StringBuilder
    '    'Declaraciones internas
    '    Dim NN As New N_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
    '    Dim Data As New List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
    '    Dim Data_Final As New List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
    '    Dim NN_Datos_Pac As New N_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES
    '    Dim Data_Datos_Pac As New List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES)
    '    Dim Json_Item_Res As New E_Json_Result_DataTable_Values2
    '    Dim NN_Ate As New N_Ate_Resultados2
    '    Dim Item_print As E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2

    '    For ii = 0 To (MUESTRA.GetUpperBound(0))
    '        Dim CB As String = MUESTRA(ii)

    '        Data = NN.IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_AND_ID_ATE_RES(CDate(DESDE), CDate(HASTA), ID_CF, CB)

    '        For i = 0 To Data.Count - 1
    '            Item_print = New E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2

    '            Item_print.ID_ATENCION = Data(i).ID_ATENCION
    '            Item_print.ATE_NUM = Data(i).ATE_NUM
    '            Item_print.ATE_FECHA = Data(i).ATE_FECHA
    '            Item_print.PAC_NOMBRE = Data(i).PAC_NOMBRE
    '            Item_print.PAC_APELLIDO = Data(i).PAC_APELLIDO
    '            Item_print.CF_DESC = Data(i).CF_DESC
    '            Item_print.CF_COD = Data(i).CF_COD
    '            Item_print.ATE_AÑO = Data(i).ATE_AÑO
    '            Item_print.PRU_DESC = Data(i).PRU_DESC
    '            Item_print.ATE_RESULTADO = Data(i).ATE_RESULTADO
    '            Item_print.ATE_RESULTADO_NUM = Data(i).ATE_RESULTADO_NUM
    '            Item_print.ID_CODIGO_FONASA = Data(i).ID_CODIGO_FONASA
    '            Item_print.ID_PRUEBA = Data(i).ID_PRUEBA
    '            Item_print.ID_ATE_RES = Data(i).ID_ATE_RES
    '            Item_print.PAC_FNAC = Data(i).PAC_FNAC
    '            Item_print.ID_SEXO = Data(i).ID_SEXO
    '            Item_print.UM_DESC = Data(i).UM_DESC
    '            Item_print.ID_TP_RESULTADO = Data(i).ID_TP_RESULTADO
    '            Item_print.TP_RESUL_DESC = Data(i).TP_RESUL_DESC
    '            Item_print.TP_RESUL_COD = Data(i).TP_RESUL_COD
    '            Item_print.ID_U_MEDIDA = Data(i).ID_U_MEDIDA
    '            Item_print.ATE_RR_DESDE = Data(i).ATE_RR_DESDE
    '            Item_print.ATE_R_DESDE = Data(i).ATE_R_DESDE
    '            Item_print.ATE_R_HASTA = Data(i).ATE_R_HASTA
    '            Item_print.ATE_RR_HASTA = Data(i).ATE_RR_HASTA
    '            Item_print.PRU_DECIMAL = Data(i).PRU_DECIMAL
    '            Item_print.PROC_DESC = Data(i).PROC_DESC
    '            Item_print.ATE_DNI = Data(i).ATE_DNI
    '            Item_print.DOC_NOMBRE = Data(i).DOC_NOMBRE
    '            Item_print.DOC_APELLIDO = Data(i).DOC_APELLIDO
    '            Item_print.id_proce = Data(i).id_proce
    '            Item_print.NAC_DESC = Data(i).NAC_DESC
    '            Item_print.PROGRA_DESC = Data(i).PROGRA_DESC
    '            Item_print.SECTOR_DESC = Data(i).SECTOR_DESC

    '            Data_Final.Add(Item_print)
    '        Next i

    '    Next ii

    '    If (Data_Final.Count > 0) Then

    '        For y = 0 To Data_Final.Count - 1

    '            Data_Datos_Pac = NN_Datos_Pac.IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES(Data_Final(y).ID_ATENCION)
    '            Data_Final(y).PAC_RUT = Data_Datos_Pac(0).PAC_RUT

    '            If (Data_Final(y).ATE_EST_VALIDA = 6 Or Data_Final(y).ATE_EST_VALIDA = 14) Then
    '                Data_Final(y).ATE_RR_DESDE = ""
    '                Data_Final(y).ATE_R_DESDE = ""
    '                Data_Final(y).ATE_R_HASTA = ""
    '                Data_Final(y).ATE_RR_HASTA = ""
    '            Else
    '                Json_Item_Res.b2 = Data_Final(y).ATE_RR_DESDE
    '                Json_Item_Res.b1 = Data_Final(y).ATE_R_DESDE
    '                Json_Item_Res.a1 = Data_Final(y).ATE_R_HASTA
    '                Json_Item_Res.a2 = Data_Final(y).ATE_RR_HASTA
    '                Json_Item_Res = NN_Ate.Json_Item_Result_Interval(Data_Final(y).ID_PRUEBA,
    '                                                          Data_Datos_Pac(0).SEXO_DESC,
    '                                                          CDate(Data_Datos_Pac(0).PAC_FNAC),
    '                                                          Json_Item_Res)
    '                Data_Final(y).ATE_RR_DESDE = Json_Item_Res.b2
    '                Data_Final(y).ATE_R_DESDE = Json_Item_Res.b1
    '                Data_Final(y).ATE_R_HASTA = Json_Item_Res.a1
    '                Data_Final(y).ATE_RR_HASTA = Json_Item_Res.a2
    '            End If

    '        Next y

    '        'Serializar con JSON
    '        Serializer.MaxJsonLength = 999999999
    '        Serializer.Serialize(Data_Final, str_Builder)
    '        Return str_Builder.ToString
    '    Else
    '        Return "null"
    '    End If



    'End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal DESDE As String, ByVal HASTA As String,
                                            ByVal ID_CF As Integer,
                                         ByVal MUESTRA() As Object) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN As New N_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
        Dim Data As New List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        Dim Data_Final As New List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        Dim NN_Datos_Pac As New N_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES
        Dim Data_Datos_Pac As New List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES)
        Dim Json_Item_Res As New E_Json_Result_DataTable_Values2
        Dim NN_Ate As New N_Ate_Resultados2

        Data_Final = NN.IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_AND_ID_ATE_RES_CON_ARRAY_y_MARCADOS(CDate(DESDE), CDate(HASTA), ID_CF, MUESTRA)


        If (Data_Final.Count > 0) Then

            For y = 0 To Data_Final.Count - 1

                Data_Datos_Pac = NN_Datos_Pac.IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES(Data_Final(y).ID_ATENCION)
                Data_Final(y).PAC_RUT = Data_Datos_Pac(0).PAC_RUT

                If (Data_Final(y).ATE_EST_VALIDA = 6 Or Data_Final(y).ATE_EST_VALIDA = 14) Then
                    Data_Final(y).ATE_RR_DESDE = ""
                    Data_Final(y).ATE_R_DESDE = ""
                    Data_Final(y).ATE_R_HASTA = ""
                    Data_Final(y).ATE_RR_HASTA = ""
                Else
                    Json_Item_Res.b2 = Data_Final(y).ATE_RR_DESDE
                    Json_Item_Res.b1 = Data_Final(y).ATE_R_DESDE
                    Json_Item_Res.a1 = Data_Final(y).ATE_R_HASTA
                    Json_Item_Res.a2 = Data_Final(y).ATE_RR_HASTA
                    Json_Item_Res = NN_Ate.Json_Item_Result_Interval(Data_Final(y).ID_PRUEBA,
                                                              Data_Datos_Pac(0).SEXO_DESC,
                                                              CDate(Data_Datos_Pac(0).PAC_FNAC),
                                                              Json_Item_Res)
                    Data_Final(y).ATE_RR_DESDE = Json_Item_Res.b2
                    Data_Final(y).ATE_R_DESDE = Json_Item_Res.b1
                    Data_Final(y).ATE_R_HASTA = Json_Item_Res.a1
                    Data_Final(y).ATE_RR_HASTA = Json_Item_Res.a2
                End If

            Next y

            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(Data_Final, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If



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

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_VALOR_CRITICO_POR_ID_ATE_RESULTADO(ByVal ID_ATE_RES As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim Encrypt As New N_Encrypt

        Dim data_det_ate As List(Of E_IRIS_WEBF_BUSCA_VALOR_CRITICO_POR_ID_ATE_RESULTADO)
        Dim NN_Det_Ate As N_IRIS_WEBF_BUSCA_VALOR_CRITICO_POR_ID_ATE_RESULTADO = New N_IRIS_WEBF_BUSCA_VALOR_CRITICO_POR_ID_ATE_RESULTADO

        Dim data_det_ate_hizo As List(Of E_IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES)
        Dim NN_Det_Ate_hizo As N_IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES = New N_IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES

        data_det_ate = NN_Det_Ate.IRIS_WEBF_BUSCA_VALOR_CRITICO_POR_ID_ATE_RESULTADO(ID_ATE_RES)

        If (data_det_ate.Count > 0) Then

            data_det_ate_hizo = NN_Det_Ate_hizo.IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES(ID_ATE_RES)

            If (data_det_ate_hizo.Count > 0) Then

            End If

            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_det_ate, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES(ByVal ID_ATE_RES As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim Encrypt As New N_Encrypt

        Dim data_det_ate_hizo As List(Of E_IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES)
        Dim NN_Det_Ate_hizo As N_IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES = New N_IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES

        data_det_ate_hizo = NN_Det_Ate_hizo.IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES(ID_ATE_RES)

        If (data_det_ate_hizo.Count > 0) Then

            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_det_ate_hizo, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_GRABA_DET_VALORES_CRITICOS_DESCRIPCION(ByVal ID_ATE_RES As Integer,
                                                              ByVal ID_USUARIO As Integer,
                                                              ByVal DET_CRITICO_DESC As String,
                                                              ByVal ID_TP_CRITICO As Integer,
                                                              ByVal FECHA As String,
                                                              ByVal CAUSA As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim Encrypt As New N_Encrypt

        Dim data_det_ate As Integer
        Dim NN_Det_Ate As N_IRIS_WEBF_BUSCA_VALOR_CRITICO_POR_ID_ATE_RESULTADO = New N_IRIS_WEBF_BUSCA_VALOR_CRITICO_POR_ID_ATE_RESULTADO

        data_det_ate = NN_Det_Ate.IRIS_WEBF_GRABA_DET_VALORES_CRITICOS_DESCRIPCION(ID_ATE_RES, ID_USUARIO, DET_CRITICO_DESC, ID_TP_CRITICO, FECHA, CAUSA)

        If (data_det_ate > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_det_ate, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String,
                                 ByVal DESDE As String,
                                 ByVal HASTA As String,
                                ByVal ID_CF As Integer,
                                ByVal MUESTRA() As Object) As String

        'Declaraciones del Serializador
        'Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim Str_Out As String = ""
        'Declaraciones internas
        Dim NN As New N_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
        Dim Data As New List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        Dim NN_Datos_Pac As New N_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES
        Dim Data_Datos_Pac As New List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES)
        Dim Json_Item_Res As New E_Json_Result_DataTable_Values2
        Dim NN_Ate As New N_Ate_Resultados2
        Dim Item_print As E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
        Dim Data_Final As New List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)



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
        Dim Mx_Data(20, 0) As Object






        For ii = 0 To (MUESTRA.GetUpperBound(0))
            Dim CB As String = MUESTRA(ii)

            Data = NN.IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_AND_ID_ATE_RES(CDate(DESDE), CDate(HASTA), ID_CF, CB)

            For i = 0 To Data.Count - 1
                Item_print = New E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2

                Item_print.ID_ATENCION = Data(i).ID_ATENCION
                Item_print.ATE_NUM = Data(i).ATE_NUM
                Item_print.ATE_FECHA = Data(i).ATE_FECHA
                Item_print.PAC_NOMBRE = Data(i).PAC_NOMBRE
                Item_print.PAC_APELLIDO = Data(i).PAC_APELLIDO
                Item_print.CF_DESC = Data(i).CF_DESC
                Item_print.CF_COD = Data(i).CF_COD
                Item_print.ATE_AÑO = Data(i).ATE_AÑO
                Item_print.PRU_DESC = Data(i).PRU_DESC
                Item_print.ATE_RESULTADO = Data(i).ATE_RESULTADO
                Item_print.ATE_RESULTADO_NUM = Data(i).ATE_RESULTADO_NUM
                Item_print.ID_CODIGO_FONASA = Data(i).ID_CODIGO_FONASA
                Item_print.ID_PRUEBA = Data(i).ID_PRUEBA
                Item_print.ID_ATE_RES = Data(i).ID_ATE_RES
                Item_print.PAC_FNAC = Data(i).PAC_FNAC
                Item_print.ID_SEXO = Data(i).ID_SEXO
                Item_print.UM_DESC = Data(i).UM_DESC
                Item_print.ID_TP_RESULTADO = Data(i).ID_TP_RESULTADO
                Item_print.TP_RESUL_DESC = Data(i).TP_RESUL_DESC
                Item_print.TP_RESUL_COD = Data(i).TP_RESUL_COD
                Item_print.ID_U_MEDIDA = Data(i).ID_U_MEDIDA
                Item_print.ATE_RR_DESDE = Data(i).ATE_RR_DESDE
                Item_print.ATE_R_DESDE = Data(i).ATE_R_DESDE
                Item_print.ATE_R_HASTA = Data(i).ATE_R_HASTA
                Item_print.ATE_RR_HASTA = Data(i).ATE_RR_HASTA
                Item_print.PRU_DECIMAL = Data(i).PRU_DECIMAL
                Item_print.PROC_DESC = Data(i).PROC_DESC
                Item_print.ATE_DNI = Data(i).ATE_DNI
                Item_print.DOC_NOMBRE = Data(i).DOC_NOMBRE
                Item_print.DOC_APELLIDO = Data(i).DOC_APELLIDO
                Item_print.id_proce = Data(i).id_proce
                Item_print.NAC_DESC = Data(i).NAC_DESC
                Item_print.PROGRA_DESC = Data(i).PROGRA_DESC
                Item_print.SECTOR_DESC = Data(i).SECTOR_DESC

                Data_Final.Add(Item_print)
            Next i

        Next ii

        If (Data_Final.Count > 0) Then
            For y = 0 To Data_Final.Count - 1
                Data_Datos_Pac = NN_Datos_Pac.IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES(Data_Final(y).ID_ATENCION)
                Data_Final(y).PAC_RUT = Data_Datos_Pac(0).PAC_RUT
                If (Data_Final(y).ATE_EST_VALIDA = 6 Or Data_Final(y).ATE_EST_VALIDA = 14) Then
                    Data_Final(y).ATE_RR_DESDE = ""
                    Data_Final(y).ATE_R_DESDE = ""
                    Data_Final(y).ATE_R_HASTA = ""
                    Data_Final(y).ATE_RR_HASTA = ""
                Else
                    Json_Item_Res.b2 = Data_Final(y).ATE_RR_DESDE
                    Json_Item_Res.b1 = Data_Final(y).ATE_R_DESDE
                    Json_Item_Res.a1 = Data_Final(y).ATE_R_HASTA
                    Json_Item_Res.a2 = Data_Final(y).ATE_RR_HASTA
                    Json_Item_Res = NN_Ate.Json_Item_Result_Interval(Data_Final(y).ID_PRUEBA,
                                                              Data_Datos_Pac(0).SEXO_DESC,
                                                              CDate(Data_Datos_Pac(0).PAC_FNAC),
                                                              Json_Item_Res)
                    Data_Final(y).ATE_RR_DESDE = Json_Item_Res.b2
                    Data_Final(y).ATE_R_DESDE = Json_Item_Res.b1
                    Data_Final(y).ATE_R_HASTA = Json_Item_Res.a1
                    Data_Final(y).ATE_RR_HASTA = Json_Item_Res.a2
                End If
            Next y

            Dim Mx_Datac(20, 0) As Object
            'Vaciar Matriz
            ReDim Mx_Data(20, 0)
            For x = 0 To (Mx_Data.GetUpperBound(0))
                Mx_Data(x, 0) = Nothing
            Next x
            'Llenar Matriz
            For y = 0 To (Data.Count - 1)
                If (y > 0) Then
                    ReDim Preserve Mx_Data(20, y)
                End If
                Mx_Data(0, y) = y + 1
                Mx_Data(1, y) = Data_Final(y).ATE_NUM
                Mx_Data(2, y) = Format(Data_Final(y).ATE_FECHA, "dd/MM/yyyy")
                Mx_Data(3, y) = Data_Final(y).PROC_DESC
                Mx_Data(4, y) = Data_Final(y).ATE_NUM_INTERNO
                Mx_Data(5, y) = Data_Final(y).PAC_NOMBRE + " " + Data(y).PAC_APELLIDO
                Mx_Data(6, y) = Format(Data_Final(y).PAC_FNAC, "dd/MM/yyyy")
                Mx_Data(7, y) = Data_Final(y).ATE_AÑO
                Mx_Data(8, y) = Data_Final(y).PAC_RUT

                If (Data_Final(y).ATE_DNI <> "") Then
                    Mx_Data(9, y) = Data_Final(y).ATE_DNI
                Else
                    Mx_Data(9, y) = ""
                End If

                If (Data_Final(y).NAC_DESC <> "") Then
                    Mx_Data(10, y) = Data_Final(y).NAC_DESC
                Else
                    Mx_Data(10, y) = ""
                End If

                If (Data_Final(y).PROGRA_DESC <> "") Then
                    Mx_Data(11, y) = Data_Final(y).PROGRA_DESC
                Else
                    Mx_Data(11, y) = ""
                End If

                If (Data_Final(y).SECTOR_DESC <> "") Then
                    Mx_Data(12, y) = Data_Final(y).SECTOR_DESC
                Else
                    Mx_Data(12, y) = ""
                End If

                Mx_Data(13, y) = Data_Final(y).PRU_DESC
                Mx_Data(14, y) = Data_Final(y).TP_RESUL_COD

                If (Data_Final(y).ATE_RESULTADO = "") Then
                    Mx_Data(15, y) = Data_Final(y).ATE_RESULTADO = ""
                    If (Data_Final(y).ATE_RESULTADO_NUM = "") Then
                        Mx_Data(15, y) = ""
                    Else
                        Mx_Data(15, y) = Data_Final(y).ATE_RESULTADO_NUM
                    End If
                Else
                    Mx_Data(15, y) = Data_Final(y).ATE_RESULTADO
                End If

                If (Data_Final(y).DOC_NOMBRE = "") Then
                    Mx_Data(16, y) = "SIN MÉDICO"
                Else
                    Mx_Data(16, y) = Data_Final(y).DOC_NOMBRE & " " & Data_Final(y).DOC_APELLIDO
                End If

                If (Data_Final(y).UM_DESC = "") Then
                    Mx_Data(17, y) = "SIN UNIDAD"
                Else
                    Mx_Data(17, y) = Data_Final(y).UM_DESC
                End If

                'If (Data_Final(y).UM_DESC <> "") Then
                '    Mx_Data(14, y) = Data_Final(y).UM_DESC
                'Else
                '    Mx_Data(14, y) = "<Sin Unidad>"
                'End If

                Mx_Data(18, y) = ""

                If (Data_Final(y).ATE_R_DESDE <> "" And Data_Final(y).PRU_DECIMAL <> Nothing) Then
                    If (Data_Final(y).ATE_R_DESDE <> "") Then
                        If (Data_Final(y).ATE_R_DESDE <> ".") Then
                            If (Data_Final(y).ATE_R_DESDE <> "-") Then
                                'Data_Final(y).ATE_R_DESDE = Data_Final(y).ATE_R_DESDE.Replace(".", "")
                                If (IsNumeric(Data_Final(y).ATE_R_DESDE) = True) Then

                                    Mx_Data(19, y) = NN_Ate.Num_Dec(Data_Final(y).ATE_R_DESDE, Data_Final(y).PRU_DECIMAL)
                                Else
                                    Mx_Data(19, y) = Data_Final(y).ATE_R_DESDE
                                End If
                            Else
                                Mx_Data(19, y) = ""
                            End If
                        Else
                            If (Data_Final(y).ATE_RR_DESDE <> "") Then
                                If (Data_Final(y).ATE_RR_DESDE <> "") Then
                                    If (Data_Final(y).ATE_RR_DESDE <> ".") Then
                                        If (Data_Final(y).ATE_RR_DESDE <> "-") Then
                                            'Data_Final(y).ATE_RR_DESDE = Data_Final(y).ATE_R_DESDE.Replace(".", "")
                                            If (IsNumeric(Data_Final(y).ATE_RR_DESDE) = True) Then

                                                Mx_Data(19, y) = NN_Ate.Num_Dec(Data_Final(y).ATE_RR_DESDE, Data_Final(y).PRU_DECIMAL)
                                            Else
                                                Mx_Data(19, y) = Data_Final(y).ATE_RR_DESDE
                                            End If
                                        Else
                                            Mx_Data(19, y) = ""
                                        End If
                                    Else
                                        Mx_Data(19, y) = ""
                                    End If
                                Else
                                    Mx_Data(19, y) = ""
                                End If
                            Else
                                Mx_Data(19, y) = ""
                            End If
                        End If
                    Else
                        If (Data_Final(y).ATE_RR_DESDE <> "" And Data_Final(y).PRU_DECIMAL <> Nothing) Then
                            If (Data_Final(y).ATE_RR_DESDE <> "") Then
                                If (Data_Final(y).ATE_RR_DESDE <> ".") Then
                                    If (Data_Final(y).ATE_R_DESDE <> "-") Then
                                        'Data_Final(y).ATE_RR_DESDE = Data_Final(y).ATE_RR_DESDE.Replace(".", "")
                                        If (IsNumeric(Data_Final(y).ATE_RR_DESDE) = True) Then

                                            Mx_Data(19, y) = NN_Ate.Num_Dec(Data_Final(y).ATE_RR_DESDE, Data_Final(y).PRU_DECIMAL)
                                        Else
                                            Mx_Data(19, y) = Data_Final(y).ATE_RR_DESDE
                                        End If
                                    Else
                                        Mx_Data(19, y) = ""
                                    End If
                                Else
                                    Mx_Data(19, y) = ""
                                End If
                            Else
                                Mx_Data(19, y) = ""
                            End If
                        Else
                            Mx_Data(19, y) = ""
                        End If
                    End If
                Else
                    If (Data_Final(y).ATE_RR_DESDE <> "" And Data_Final(y).PRU_DECIMAL <> Nothing) Then
                        If (Data_Final(y).ATE_RR_DESDE <> "") Then
                            If (Data_Final(y).ATE_RR_DESDE <> ".") Then
                                If (Data_Final(y).ATE_R_DESDE <> "-") Then
                                    'Data_Final(y).ATE_RR_DESDE = Data_Final(y).ATE_RR_DESDE.Replace(".", "")
                                    If (IsNumeric(Data_Final(y).ATE_RR_DESDE) = True) Then

                                        Mx_Data(19, y) = NN_Ate.Num_Dec(Data_Final(y).ATE_RR_DESDE, Data_Final(y).PRU_DECIMAL)
                                    Else
                                        Mx_Data(19, y) = Data_Final(y).ATE_RR_DESDE
                                    End If
                                Else
                                    Mx_Data(19, y) = ""
                                End If
                            Else
                                Mx_Data(19, y) = ""
                            End If
                        Else
                            Mx_Data(19, y) = ""
                        End If
                    Else
                        Mx_Data(19, y) = ""
                    End If
                End If


                If (Data_Final(y).ATE_R_HASTA <> "" And Data_Final(y).PRU_DECIMAL <> Nothing) Then
                    If (Data_Final(y).ATE_R_HASTA <> "") Then
                        If (Data_Final(y).ATE_R_HASTA <> ".") Then
                            If (Data_Final(y).ATE_R_HASTA <> "-") Then
                                'Data_Final(y).ATE_R_HASTA = Data_Final(y).ATE_R_HASTA.Replace(".", "")
                                If (IsNumeric(Data_Final(y).ATE_R_HASTA) = True) Then

                                    Mx_Data(20, y) = NN_Ate.Num_Dec(Data_Final(y).ATE_R_HASTA, Data_Final(y).PRU_DECIMAL)
                                Else
                                    Mx_Data(20, y) = Data_Final(y).ATE_R_HASTA
                                End If
                            Else
                                Mx_Data(20, y) = ""
                            End If
                        Else
                            If (Data_Final(y).ATE_RR_HASTA <> "" And Data_Final(y).PRU_DECIMAL <> Nothing) Then
                                If (Data_Final(y).ATE_RR_HASTA <> "") Then
                                    If (Data_Final(y).ATE_RR_HASTA <> ".") Then
                                        If (Data_Final(y).ATE_RR_HASTA <> "-") Then
                                            'Data_Final(y).ATE_RR_HASTA = Data_Final(y).ATE_RR_HASTA.Replace(".", "")
                                            If (IsNumeric(Data_Final(y).ATE_RR_HASTA) = True) Then

                                                Mx_Data(20, y) = NN_Ate.Num_Dec(Data_Final(y).ATE_RR_HASTA, Data_Final(y).PRU_DECIMAL)
                                            Else
                                                Mx_Data(20, y) = Data_Final(y).ATE_RR_HASTA
                                            End If
                                        Else
                                            Mx_Data(20, y) = ""
                                        End If
                                    Else
                                        Mx_Data(20, y) = ""
                                    End If
                                Else
                                    Mx_Data(20, y) = ""
                                End If
                            Else
                                Mx_Data(20, y) = ""
                            End If
                        End If
                    Else
                        If (Data_Final(y).ATE_RR_HASTA <> "") Then
                            If (Data_Final(y).ATE_RR_HASTA <> "") Then
                                If (Data_Final(y).ATE_RR_HASTA <> ".") Then
                                    If (Data_Final(y).ATE_RR_HASTA <> "-") Then
                                        'Data_Final(y).ATE_RR_HASTA = Data_Final(y).ATE_RR_HASTA.Replace(".", "")
                                        If (IsNumeric(Data_Final(y).ATE_RR_HASTA) = True) Then

                                            Mx_Data(20, y) = NN_Ate.Num_Dec(Data_Final(y).ATE_RR_HASTA, Data_Final(y).PRU_DECIMAL)
                                        Else
                                            Mx_Data(20, y) = Data_Final(y).ATE_RR_HASTA
                                        End If
                                    Else
                                        Mx_Data(20, y) = ""
                                    End If
                                Else
                                    Mx_Data(20, y) = ""
                                End If
                            Else
                                Mx_Data(20, y) = ""
                            End If
                        Else
                            Mx_Data(20, y) = ""
                        End If
                    End If
                Else
                    If (Data_Final(y).ATE_RR_HASTA <> "" And Data_Final(y).PRU_DECIMAL <> Nothing) Then
                        If (Data_Final(y).ATE_RR_HASTA <> "") Then
                            If (Data_Final(y).ATE_RR_HASTA <> ".") Then
                                If (Data_Final(y).ATE_RR_HASTA <> "-") Then
                                    'Data_Final(y).ATE_RR_HASTA = Data_Final(y).ATE_RR_HASTA.Replace(".", "")
                                    If (IsNumeric(Data_Final(y).ATE_RR_HASTA) = True) Then

                                        Mx_Data(20, y) = NN_Ate.Num_Dec(Data_Final(y).ATE_RR_HASTA, Data_Final(y).PRU_DECIMAL)
                                    Else
                                        Mx_Data(20, y) = Data_Final(y).ATE_RR_HASTA
                                    End If
                                Else
                                    Mx_Data(20, y) = ""
                                End If
                            Else
                                Mx_Data(20, y) = ""
                            End If
                        Else
                            Mx_Data(20, y) = ""
                        End If
                    Else
                        Mx_Data(20, y) = ""
                    End If
                End If
            Next y
        Else
            Return "null"
        End If

        For y = 1 To 21
            sl.SetColumnWidth(y, 20.0)
        Next y

        'nombrar hoja 
        sl.RenameWorksheet("Sheet1", "Listado de Resultados por Determinaciones ")
        'titulo de la tabla
        sl.SetCellValue("B2", "Listado de Resultados por Determinaciones ")
        sl.SetCellValue("B4", "Desde: " & DESDE)
        sl.SetCellValue("B5", "Hasta " & HASTA)

        'nombre columnas
        sl.SetCellValue("A8", "#")
        sl.SetColumnWidth("A", 10)
        sl.SetCellValue("B8", "N° Atención")
        sl.SetColumnWidth("B", 10)
        sl.SetCellValue("C8", "fecha Ingreso")
        sl.SetCellValue("D8", "Lugar TM")
        sl.SetCellValue("E8", "Num Interno")
        sl.SetCellValue("F8", "Nombre Paciente")
        sl.SetColumnWidth("F", 40)
        sl.SetCellValue("G8", "Fecha Nac")
        sl.SetCellValue("H8", "Edad")
        sl.SetColumnWidth("H", 10)
        sl.SetCellValue("I8", "Rut Paciente")
        sl.SetCellValue("J8", "DNI")
        sl.SetCellValue("K8", "Nacionalidad")
        sl.SetCellValue("L8", "Programa")
        sl.SetCellValue("M8", "Sector")
        sl.SetCellValue("N8", "Determinación")
        sl.SetCellValue("O8", "T")
        sl.SetCellValue("P8", "Resultado")
        sl.SetColumnWidth("P", 60)
        sl.SetCellValue("Q8", "Médico")
        sl.SetColumnWidth("Q", 40)
        sl.SetCellValue("R8", "Unidad")
        sl.SetCellValue("S8", "E")
        sl.SetCellValue("T8", "Rango Desde")
        sl.SetCellValue("U8", "Rango Hasta")

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
        sl.SetCellStyle("B5", estilo3)
        'insertar tabla
        tabla = sl.CreateTable("A8", CStr("U" & ltabla + 1))
        tabla.SetTableStyle(SLTableStyleTypeValues.Dark11)
        sl.InsertTable(tabla)
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "Excel\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        sl.SaveAs(Ruta_save_local & Relative_Path) 'Abrir el Archivo
        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
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

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If

        Select Case (CInt(C_P_ADMIN.Value))
            Case 1, 3
            Case Else
                Response.Redirect("~/Index.aspx")
        End Select
    End Sub
End Class