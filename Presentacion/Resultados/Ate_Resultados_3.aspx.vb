Imports Negocio
Imports Entidades
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.HttpContext
Imports Datos

Public Class Ate_Resultados_3
    Inherits System.Web.UI.Page

    Public ReadOnly Property ID_ATE() As Long
        Get
            Dim Encrypt As New N_Encrypt
            Dim strVal As String

            strVal = HttpContext.Current.Request.QueryString("ID")
            If (IsNothing(strVal) = False) Then
                strVal = Encrypt.Decode(strVal)
            Else
                strVal = "0"
            End If

            Return CLng(strVal)
        End Get
    End Property
    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_Seccion() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder

        'Declaraciones internas
        Dim NN_Seccion As New N_IRIS_WEBF_BUSCA_REL_LAB_SECCION
        Dim Data_Seccion As New List(Of E_IRIS_WEBF_BUSCA_REL_LAB_SECCION)

        Data_Seccion = NN_Seccion.IRIS_WEBF_BUSCA_REL_LAB_SECCION()
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
    Public Shared Function Critico_Manual(ByVal ID_ATE_RES As Long) As Integer
        Dim NN_Activo As New N_Ate_Resultados

        Return NN_Activo.IRIS_WEBF_UPDATE_CRIT_MANUAL(ID_ATE_RES)
    End Function

    <Services.WebMethod()>
    Public Shared Function Sel_Proc() As List(Of Ddl_List_Resultados)
        Dim NN_Activo As New N_Gen_Activos
        Dim List_In As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Dim list_Out As New List(Of Ddl_List_Resultados)

        List_In = NN_Activo.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO_BY_ID_PREV()

        For y = 0 To (List_In.Count - 1)
            Dim item_Out As New Ddl_List_Resultados

            item_Out.ID = List_In(y).ID_PROCEDENCIA
            item_Out.DESC = List_In(y).PROC_DESC

            list_Out.Add(item_Out)
        Next y

        Return list_Out
    End Function

    <Services.WebMethod()>
    Public Shared Function Sel_Prev(ByVal ID_PROC As Long) As List(Of Ddl_List_Resultados)
        Dim NN_Activo As New N_Gen_Activos
        Dim List_In As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Dim list_Out As New List(Of Ddl_List_Resultados)

        List_In = NN_Activo.IRIS_WEBF_BUSCA_PREVISION_ACTIVO_BY_ID_PROC(ID_PROC)

        For y = 0 To (List_In.Count - 1)
            Dim item_Out As New Ddl_List_Resultados

            item_Out.ID = List_In(y).ID_PREVE
            item_Out.DESC = List_In(y).PREVE_DESC

            list_Out.Add(item_Out)
        Next y

        Return list_Out
    End Function

    <Services.WebMethod()>
    Public Shared Function Sel_Prev_Activo(ByVal ID_PROC As Long) As List(Of Ddl_List_Resultados)
        Dim NN_Activo As New N_Gen_Activos
        Dim List_In As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Dim list_Out As New List(Of Ddl_List_Resultados)

        List_In = NN_Activo.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()

        For y = 0 To (List_In.Count - 1)
            Dim item_Out As New Ddl_List_Resultados

            item_Out.ID = List_In(y).ID_PREVE
            item_Out.DESC = List_In(y).PREVE_DESC

            list_Out.Add(item_Out)
        Next y

        Return list_Out
    End Function
    <Services.WebMethod()>
    Public Shared Function Sel_Prog(ByVal ID_PREV As Long) As List(Of Ddl_List_Resultados)
        Dim NN_Activo As New N_Gen_Activos
        Dim List_In As New List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)
        Dim list_Out As New List(Of Ddl_List_Resultados)

        List_In = NN_Activo.IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO_BY_ID_PREV(ID_PREV)

        For y = 0 To (List_In.Count - 1)
            Dim item_Out As New Ddl_List_Resultados

            item_Out.ID = List_In(y).ID_PROGRA
            item_Out.DESC = List_In(y).PROGRA_DESC

            list_Out.Add(item_Out)
        Next y

        Return list_Out
    End Function

    <Services.WebMethod()>
    Public Shared Function Sel_Secc() As List(Of Sel_Secc_Parser)
        Dim NN_Activo As New N_Ate_Resultados
        Dim List_In As New List(Of Sel_Secc_Parser)
        Dim list_Out As New List(Of Ddl_List_Resultados)

        Dim ID_ATE As Long
        ID_ATE = (New Ate_Resultados).ID_ATE

        List_In = NN_Activo.IRIS_WEBF_BUSCA_VISOR_SECCION_POR_ID_ATENCION(ID_ATE)
        Return List_In
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA(ByVal ID_CIU As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA)
        Dim NN As N_IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA = New N_IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA
        data_paciente = NN.IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA(ID_CIU)
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
    Public Shared Function Sel_Exam() As List(Of Ddl_List_Resultados)
        Dim NN_Activo As New N_Gen_Activos
        Dim List_In As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Dim list_Out As New List(Of Ddl_List_Resultados)

        List_In = NN_Activo.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS()

        For y = 0 To (List_In.Count - 1)
            Dim item_Out As New Ddl_List_Resultados

            item_Out.ID = List_In(y).ID_CODIGO_FONASA
            item_Out.DESC = List_In(y).CF_DESC

            list_Out.Add(item_Out)
        Next y

        Return list_Out
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_CMVM_BUSCA_ID_PER_BY_ID_CF(ByVal ID_CF As Integer, ByVal ATE_NUM As String) As List(Of Ddl_List_Resultados)
        Dim NN_Activo As New N_Gen_Activos
        Dim NN_Activo_id_ate As New N_Gen_Activos
        Dim List_In As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Dim List_In_id_ate As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Dim list_Out As New List(Of Ddl_List_Resultados)

        Dim EEE As N_Encrypt = New N_Encrypt

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim id_user As String = CType(objSession("ID_USER"), String)

        List_In = NN_Activo.IRIS_WEBF_CMVM_BUSCA_ID_PER_BY_ID_CF(ID_CF)
        List_In_id_ate = NN_Activo_id_ate.IRIS_WEBF_CMVM_BUSCA_ID_ATE_BY_ATE_NUM(ATE_NUM)

        For y = 0 To (List_In.Count - 1)
            Dim item_Out As New Ddl_List_Resultados

            item_Out.ID_PER = List_In(y).ID_PER
            item_Out.ID_ATENCION = List_In_id_ate(0).ID_ATENCION
            item_Out.ENCRYPTED_ID_USER = id_user

            list_Out.Add(item_Out)
        Next y

        Return list_Out
    End Function

    <Services.WebMethod()>
    Public Shared Function Sel_IntExt() As List(Of Ddl_List_Resultados)
        Dim NN_Activo As New N_Ate_Resultados
        Dim List_In As New List(Of E_IRIS_WEBF_CMVM_BUSCA_TIPO_CLIENTE_ACTIVO)
        Dim list_Out As New List(Of Ddl_List_Resultados)

        List_In = NN_Activo.IRIS_WEBF_CMVM_BUSCA_TIPO_CLIENTE_ACTIVO()

        For y = 0 To (List_In.Count - 1)
            Dim item_Out As New Ddl_List_Resultados

            item_Out.ID = List_In(y).ID_INTEXT
            item_Out.DESC = List_In(y).INTEXT_DESC

            list_Out.Add(item_Out)
        Next y

        Return list_Out
    End Function

    <Services.WebMethod()>
    Public Shared Function Page_Load(ByVal NUM_ATE As Long, ByVal USU_ID_PROC As Integer) As E_IRIS_WEBF_RESULTADOS_PACIENTE_DATA


        Dim strVal = HttpContext.Current.Request.QueryString("ID")
        If (IsNothing(strVal) = False) Then
            strVal = (New N_Encrypt).Decode(strVal)
        Else
            strVal = "0"
        End If

        Dim ID_ATE_ENCODED
        If NUM_ATE <> 0 Then
            Dim RRR = (New N_Ate_Resultados).IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ID_ATE_BY_ATE_NUM(NUM_ATE, USU_ID_PROC)
            strVal = RRR
            If (RRR <> 0) Then
                ID_ATE_ENCODED = (New N_Encrypt).Encode(CStr(RRR))
            Else
                ID_ATE_ENCODED = CStr(RRR)
            End If
        Else
            ID_ATE_ENCODED = (New N_Encrypt).Encode(CStr(strVal))
        End If

        'Realizar consulta
        Dim Data_Gen = (New N_Ate_Resultados_Info).IRIS_WEBF_CMVM_RESULTADOS_PACIENTE_DATA_3_H2M_CAMA(strVal)
        Data_Gen.EDAD = (New N_Calc_Age).IrisLAB_Cal_Edad_Exacta(Data_Gen.PAC_FNAC, Date.Now)
        Data_Gen.ID_ATE_ENCODED = ID_ATE_ENCODED

        Return Data_Gen
    End Function

    <Services.WebMethod()>
    Public Shared Function Json_DataTable('ByVal R_ID_ATE As Long,
                                          ByVal R_ID_SECC As Integer,
                                          ByVal R_ID_EXAM As Integer,
                                          ByVal R_ID_PAC As Long,
                                          ByVal R_FNAC As Date,
                                          ByVal R_SEXO As String,
                                          ByVal R_DIA As Integer,
                                          ByVal R_MES As Integer,
                                          ByVal R_AÑO As Integer,
                                          ByVal ACTIVA_PENDIENTES As Integer,
                                          ByVal ACTIVA_PENDIENTES_R As Integer) As List(Of E_Json_Result_DataTable)
        'Declaraciones internas
        Dim Data_Res01 As List(Of E_IRIS_WEBF_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN2)
        Dim NN_Result As New N_Ate_Resultados
        Dim Mx_F_Nac(2) As String
        Dim NN_Date As New N_Date


        'Realizar consultas
        NN_Result.ID_ATE = (New Ate_Resultados_3).ID_ATE
        'NN_Result.ID_SECC = R_ID_SECC
        'NN_Result.ID_EXAM = R_ID_EXAM
        'NN_Result.ID_PAC = R_ID_PAC
        'NN_Result.F_NAC = R_FNAC
        'NN_Result.SEXO = R_SEXO

        NN_Result.ID_SECC = 0
        NN_Result.ID_EXAM = 0
        NN_Result.ID_PAC = R_ID_PAC
        NN_Result.F_NAC = R_FNAC
        NN_Result.SEXO = R_SEXO



        Data_Res01 = NN_Result.IRIS_WEB_RESULTADOS_BUSCA_VISOR_DETALLE(NN_Result.ID_ATE, R_ID_SECC, R_ID_EXAM, R_DIA, R_MES, R_AÑO, ACTIVA_PENDIENTES_R)

        Dim retRes = NN_Result.Build_Json_Datatable(Data_Res01)

        Return retRes
    End Function

    <Services.WebMethod()>
    Public Shared Function Guarda_Critico_Manual(ID_ATE_RES As Integer) As Integer
        Dim ID_USER As Long = CLng(Current.Request.Cookies("ID_USER").Value)
        Return (New D_Ate_Resultados).IRIS_WEB_UPDATE_CRITICO_MANUAL(ID_ATE_RES, ID_USER)
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_RESULTADO_ESTADO_ANTES_DE_VALIDAR(ByVal ID_ATE_RES As Integer) As Integer
        Dim NN_Result2 As New N_Ate_Resultados
        Dim list_busca As Integer = 0

        list_busca = NN_Result2.IRIS_WEBF_BUSCA_RESULTADO_ESTADO_ANTES_DE_VALIDAR(ID_ATE_RES)

        Return list_busca
    End Function

    <Services.WebMethod()>
    Public Shared Sub IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_TEXTO(ByVal ID_RES As Integer, ByVal RES As String)
        If (Current.Request.Cookies("NICKNAME").Value = Nothing) Then
            Current.Response.Redirect("~index.aspx")
        End If
        Try
            Dim xID_USER As Long = CLng(Current.Request.Cookies("ID_USER").Value)
            Dim updated = D_Ate_Resultados.IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_TEXTO_CON_LOG(ID_RES, RES, xID_USER)
        Catch ex As Exception
            Dim LOG As New N_Log
            Dim xNick As String = Current.Request.Cookies("NICKNAME").Value
            LOG.Write_ERROR(ex)
        End Try
    End Sub

    <Services.WebMethod()>
    Public Shared Sub IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_NUMERICO(ByVal ID_RES As Integer, ByVal RES As String)
        If (Current.Request.Cookies("NICKNAME").Value = Nothing) Then
            Current.Response.Redirect("~index.aspx")
        End If
        Try
            Dim xID_USER As Long = CLng(Current.Request.Cookies("ID_USER").Value)
            Dim resultadoViejo = D_Ate_Resultados.IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_NUMERICO_CON_LOG(ID_RES, RES, xID_USER)
        Catch ex As Exception
            Dim LOG As New N_Log
            Dim xNick As String = Current.Request.Cookies("NICKNAME").Value
            LOG.Path = "\LOG\Resultados\" & Format(Date.Now, "MM-dd-yyyy - !") & xNick & ".txt"
            LOG.Write_ERROR(ex)
        End Try
    End Sub


    <Services.WebMethod()>
    Public Shared Function Fill_Audit(ByVal ID_RES As Integer) As List(Of E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA)
        Dim NN_Result As New N_Ate_Resultados

        Return NN_Result.IRIS_WEBF_BUSCA_CONTROL_AUDITORIA(ID_RES)
    End Function

    <Services.WebMethod()>
    Public Shared Sub Set_Revision(ByVal Obj_Rev As List(Of Obj_Rev))

        Dim Cookie_ID As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")

        If (IsNothing(Cookie_ID) = True) Then
            HttpContext.Current.Response.Redirect("~/index.aspx")
            Return
        End If

        For Each ItemParam In Obj_Rev
            D_Ate_Resultados.IRIS_WEBF_UPDATE_REVISION_RESULTADO_ATENCIONES(ItemParam)
        Next
    End Sub
    <Services.WebMethod()>
    Public Shared Sub Set_Remove_Revision(ByVal Obj_Remove_Revision As List(Of Obj_Rev))

        Dim Cookie_ID As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")

        If (IsNothing(Cookie_ID) = True) Then
            HttpContext.Current.Response.Redirect("~/index.aspx")
            Return
        End If

        For Each ItemParam In Obj_Remove_Revision
            D_Ate_Resultados.IRIS_WEBF_UPDATE_REVISION_DET_RESULTADO_EN_ATENCION_QUITA_ESTADO(ItemParam)
        Next
    End Sub



    <Services.WebMethod()>
    Public Shared Sub Set_Validate(ByVal Obj_Valid As List(Of Obj_Valida))

        Dim Cookie_ID As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")

        If (IsNothing(Cookie_ID) = True) Then
            HttpContext.Current.Response.Redirect("~/index.aspx")
            Return
        End If

        For Each ItemParam In Obj_Valid
            D_Ate_Resultados.IRIS_WEB_RESULTADOS_UPDATE_VALIDACION_RESULTADO_CON_LOG(ItemParam)
        Next
    End Sub

    <Services.WebMethod()>
    Public Shared Sub Set_Unvalidate(ByVal Obj_Unvalid As List(Of E_Unvalid_Params))
        Dim NN_Data As New N_Ate_Resultados
        Dim Cookie_ID As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")

        If (IsNothing(Cookie_ID) = True) Then
            HttpContext.Current.Response.Redirect("~/index.aspx")
            Return
        End If

        For Each ItemParam In Obj_Unvalid
            D_Ate_Resultados.IRIS_WEB_RESULTADOS_UPDATE_DESVALIDACION_RESULTADO_CON_LOG(ItemParam.ID_ATE_RES, CInt(Cookie_ID.Value), ItemParam.VALUE)
        Next
    End Sub

    <Services.WebMethod()>
    Public Shared Function Get_Result_Cod(ByVal ID_PRUEBA As Integer) As List(Of E_IRIS_WEBF_CMVM_RESULTADOS_CODIFICADO_ACTIVOS)
        Dim NNN As New N_Ate_Resultados

        Return NNN.IRIS_WEBF_CMVM_RESULTADOS_CODIFICADO_ACTIVOS(ID_PRUEBA)
    End Function

    <Services.WebMethod()>
    Public Shared Function Change_Ate_L_or_R(ByVal ATE_NUM As Long, ByVal DIRECTION As Boolean, ByVal ID_PROC As Integer,
                                             ByVal ID_PREV As Integer, ByVal ID_PROG As Integer, ByVal ID_SECC As Integer,
                                             ByVal ID_EXAM As Integer, ByVal ID_SECT As Integer, ByVal ID_PACI As Long,
                                             ByVal USU_ID_PROC As Integer, ByVal ACTIVA_PENDIENTES As Integer, ByVal ACTIVA_PENDIENTES_R As Integer) As Object



        Dim ID_USER As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")
        If (IsNothing(ID_USER) = True) Then
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End If

        Dim strVal = HttpContext.Current.Request.QueryString("ID")
        If (IsNothing(strVal) = False) Then
            strVal = (New N_Encrypt).Decode(strVal)
        Else
            strVal = "0"
        End If

        Dim siguienteAteNum = D_Ate_Resultados.IRIS_WEB_BUSCA_POR_FLECHA(ATE_NUM, DIRECTION, ID_PROC, ID_PREV, ID_PROG, ID_SECC, ID_EXAM, ID_SECT, ID_PACI, ID_USER.Value, USU_ID_PROC, ACTIVA_PENDIENTES_R)

        If siguienteAteNum = ATE_NUM Or siguienteAteNum = 0 Then
            Return 0
        End If

        Dim ID_ATE_ENCODED
        If siguienteAteNum <> 0 Then
            Dim RRR = (New N_Ate_Resultados).IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ID_ATE_BY_ATE_NUM(siguienteAteNum, USU_ID_PROC)
            strVal = RRR
            If (RRR <> 0) Then
                ID_ATE_ENCODED = (New N_Encrypt).Encode(CStr(RRR))
            Else
                ID_ATE_ENCODED = CStr(RRR)
            End If
        Else
            ID_ATE_ENCODED = (New N_Encrypt).Encode(CStr(strVal))
        End If

        'Realizar consulta
        Dim Data_Gen = (New N_Ate_Resultados_Info).IRIS_WEBF_CMVM_RESULTADOS_PACIENTE_DATA_3_H2M_CAMA(strVal)
        Data_Gen.EDAD = (New N_Calc_Age).IrisLAB_Cal_Edad_Exacta(Data_Gen.PAC_FNAC, Date.Now)
        Data_Gen.ID_ATE_ENCODED = ID_ATE_ENCODED

        Return Data_Gen

    End Function

    <Services.WebMethod()>
    Public Shared Function Get_Hist_General_Info() As E_IRIS_WEBF_CMVM_RESULTADOS_HISTORICOS_GENERAL_INFO
        Dim AAA As New Ate_Resultados
        Dim NNN As New N_Ate_Resultados

        Return NNN.IRIS_WEBF_CMVM_RESULTADOS_HISTORICOS_GENERAL_INFO(AAA.ID_ATE)
    End Function

    <Services.WebMethod()>
    Public Shared Function Get_ID_ATE_by_NUM_ATE(ByVal NUM_ATE As Long, ByVal USU_ID_PROC As Integer) As String
        Dim NNN As New N_Ate_Resultados
        Dim RRR As Long = 0
        Dim DEC As String

        RRR = (New N_Ate_Resultados).IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ID_ATE_BY_ATE_NUM(NUM_ATE, USU_ID_PROC)
        If (RRR <> 0) Then
            DEC = (New N_Encrypt).Encode(CStr(RRR))
        Else
            DEC = CStr(RRR)
        End If
        Return DEC
    End Function

    <Services.WebMethod()>
    Public Shared Function Draw_Graph_Hist(ByVal ID_ATE As Long, ByVal ID_PRU As Long, ByVal BL_ALL As Boolean) As List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VALORES_GRAFICOS)
        Return (New N_Ate_Resultados).IRIS_WEBF_CMVM_RESULTADOS_BUSCA_VALORES_GRAFICOS(ID_ATE, ID_PRU, BL_ALL)
    End Function

    <Services.WebMethod()>
    Public Shared Function Get_Table_Historico_Examenes(ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_EXAMEN_POR_ID_ATE)
        Return (New N_Ate_Resultados).IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_EXAMEN_POR_ID_ATE(ID_ATE)
    End Function

    <Services.WebMethod()>
    Public Shared Function Get_Table_Historico_Pruebas_Por_Examen(ByVal ID_ATE As Long, ByVal ID_CF As Long) As List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_PRUEBAS_POR_ID_ATE_AND_ID_PRU)
        Return (New N_Ate_Resultados).IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_PRUEBAS_POR_ID_ATE_AND_ID_CF(ID_ATE, ID_CF)
    End Function

    <Services.WebMethod()>
    Public Shared Function Check_Valida(ByVal ID_ATE As Long, ByVal ID_CF As Long) As Integer
        Return (New N_Ate_Resultados).IRIS_WEBF_CMVM_RESULTADOS_CHECK_VALIDA(ID_ATE, ID_CF)
    End Function

    'CULTIVOS

    <Services.WebMethod()>
    Public Shared Function Busca_Exa_Cultivo(ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_CULTIVOS)
        Return (New N_Ate_Resultados).IRIS_WEBF_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA_CULTIVOS(ID_ATE)
    End Function

    <Services.WebMethod()>
    Public Shared Function Busca_Ate_Por_Sec(ByVal DESDE As String, ByVal HASTA As String, ID_SEC As Integer, ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION)
        Return (New N_Ate_Resultados).IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION_PROCEDENCIA(DESDE, HASTA, ID_SEC, ID_PROC)
    End Function
    <Services.WebMethod()>
    Public Shared Function Busca_Ate_Por_Sec_Pendientes(ByVal DESDE As String, ByVal HASTA As String, ID_SEC As Integer, ByVal ID_PROC As Integer, ByVal ACTIVA_PENDIENTES As Integer, ByVal ACTIVA_PENDIENTES_R As Integer) As List(Of E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION)

        If ACTIVA_PENDIENTES = 1 And ACTIVA_PENDIENTES_R = 0 Then
            'ID_OTHER = NNN.IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATE_L_R_3_PENDIENTES(ATE_NUM, DIRECTION, ID_PROC, ID_PREV, ID_PROG, ID_SECC, ID_EXAM, ID_SECT, ID_PACI, USU_ID_PROC)
            Return (New N_Ate_Resultados).IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION_PROCEDENCIA_PENDIENTES_ACTIVA_1(DESDE, HASTA, ID_SEC, ID_PROC)
        ElseIf ACTIVA_PENDIENTES = 0 And ACTIVA_PENDIENTES_R = 1 Then
            'ID_OTHER = NNN.IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATE_L_R_3_PENDIENTES_VAL(ATE_NUM, DIRECTION, ID_PROC, ID_PREV, ID_PROG, ID_SECC, ID_EXAM, ID_SECT, ID_PACI, USU_ID_PROC)
            Return (New N_Ate_Resultados).IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION_PROCEDENCIA_PENDIENTES_ACTIVA_2(DESDE, HASTA, ID_SEC, ID_PROC)
        Else
            'ID_OTHER = NNN.IRIS_WEBF_CMVM_BUSCA_ATE_L_R_2(ATE_NUM, DIRECTION, ID_PROC, ID_PREV, ID_PROG, ID_SECC, ID_EXAM, ID_SECT, ID_PACI, USU_ID_PROC)
            Return (New N_Ate_Resultados).IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION_PROCEDENCIA_PENDIENTES(DESDE, HASTA, ID_SEC, ID_PROC)
        End If


    End Function
    <Services.WebMethod()>
    Public Shared Function busca_examenes_pendientes(DESDE As String, HASTA As String, ID_SEC As Integer, ID_PROC As Integer, ID_CODIGO_FONASA As Integer) As Object
        Return (New N_Ate_Resultados).IRIS_WEBF_CMVM_RESULTADOS_BUSCA_EXAMENES_PENDIENTES(DESDE, HASTA, ID_SEC, ID_PROC, ID_CODIGO_FONASA)
    End Function

    <Services.WebMethod()>
    Public Shared Function Busca_Exa_Ant_No_Cargado(ByVal ID_CF As Integer, ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_NO_CARGADAS)
        Return (New N_Ate_Resultados).IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_NO_CARGADAS(ID_CF, ID_ATE)
    End Function
    <Services.WebMethod()>
    Public Shared Function Busca_Exa_Ant_Cargado(ByVal ID_CF As Integer, ByVal ID_ATE As Long) As List(Of E_IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_CARGADAS)
        Return (New N_Ate_Resultados).IRIS_WEBF_BUSCA_ANTIBIOGRAMAS_CARGADAS(ID_CF, ID_ATE)
    End Function
    <Services.WebMethod()>
    Public Shared Function Guarda_Panel_Cultivo(ByVal Mx_Panel As List(Of E_IRIS_WEBF_GUARDA_QUITA_PANEL)) As Integer
        Return (New N_Ate_Resultados).IRIS_WEBF_GUARDA_QUITA_PANEL(Mx_Panel)
    End Function


    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_EXAMENES_OBSERVACION_H2M(ByVal ATE_NUM As String) As List(Of E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA)
        Dim NN_Result2 As New N_Ate_Resultados
        Dim list_busca As New List(Of E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA)

        list_busca = NN_Result2.IRIS_WEBF_BUSCA_EXAMENES_OBSERVACION_H2M(ATE_NUM)

        Return list_busca
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_PRUEBA_NO_SOLICITADA_Y_SOLICITADA_TODOS(ByVal ID_ATENCION As Integer, ByVal ID_PER As Integer, ByVal SOLICITADA As Integer, ByVal ID_ESTADO As Integer) As List(Of E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA)
        Dim NN_Result2 As New N_Ate_Resultados
        Dim list_busca As New List(Of E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA)

        Dim NN_Result As New N_Ate_Resultados
        Dim list_busca_2 As New List(Of E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA)

        list_busca_2 = NN_Result.IRIS_WEBF_BUSCA_PRUEBAS_ACTIVAS_ATENCION(ID_ATENCION, ID_PER)
        list_busca = NN_Result2.IRIS_WEBF_BUSCA_PRUEBA_NO_SOLICITADA_Y_SOLICITADA_TODOS(ID_ATENCION, ID_PER, SOLICITADA, ID_ESTADO)

        For i = 0 To list_busca_2.Count - 1
            For ii = 0 To list_busca.Count - 1
                If list_busca(ii).ID_PRUEBA = list_busca_2(i).ID_PRUEBA Then
                    list_busca(ii).IN_ATENCION = 1
                End If
            Next ii
        Next i

        Return list_busca
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_GRABA_RESULTADO_ATENCION_DEFECTO_H2M(ByVal ID_ATENCION As Integer, ByVal ID_PER As Integer, ByVal ID_CF As Integer, ByVal IDS_PRUEBAS() As Object) As Integer
        Dim NN_Result2 As New N_Ate_Resultados
        Dim list_busca As Integer = 0

        For i = 0 To IDS_PRUEBAS.Length - 1
            list_busca = NN_Result2.IRIS_WEBF_GRABA_RESULTADO_ATENCION_DEFECTO_H2M(ID_ATENCION, ID_PER, ID_CF, IDS_PRUEBAS(i))
        Next i

        Return list_busca
    End Function

    <Services.WebMethod()>
    Public Shared Function busca_numero_atencion_l_r(numeroAtencion As Integer, direccion As Boolean, idCodigoFonasa As Integer) As Integer
        Return (New N_Ate_Resultados).busca_numero_atencion_l_r(numeroAtencion, direccion, idCodigoFonasa)
    End Function




    <Services.WebMethod()>
    Public Shared Function Quitar_Estado_Examen(ID_ATENCION As Integer, ID_CODIGO_FONASA() As Integer, ID_USUARIO As Integer) As Object

        Dim respuesta = New IrisResponse With {
            .code = 200,
            .success = True,
            .message = "Estados quitados con éxito"
        }

        Dim listModificado As New List(Of resQuitaEstado)
        Try
            For Each cf In ID_CODIGO_FONASA
                listModificado.Add(New resQuitaEstado With {
                                   .idCf = cf,
                                   .modificados = D_Ate_Resultados.IRIS_WEB_QUITA_ESTADO_PERFIL_VISOR(ID_ATENCION, cf, ID_USUARIO)})
            Next
            respuesta.data = listModificado
            Return respuesta
        Catch ex As Exception
            Return New IrisResponse(code:=500)
        End Try

    End Function


    <Services.WebMethod()>
    Public Shared Function BuscarHistorialPorPrueba(idAtencion As Integer, idPaciente As Integer, idPrueba As Integer) As Object

        Dim respuesta = New IrisResponse With {
            .code = 200,
            .success = True,
            .message = ""
        }

        Try
            respuesta.data = D_Ate_Resultados.IRIS_WEB_BUSCAR_HISTORIAL_POR_PRUEBA(idAtencion, idPaciente, idPrueba)
            Return respuesta
        Catch ex As Exception
            Return New IrisResponse(code:=500)
        End Try

    End Function

    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        'Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")
        'Dim C_ID_USER As HttpCookie = Request.Cookies.Get("ID_USER")
        'Dim CNICKNAME As HttpCookie = Request.Cookies.Get("NICKNAME")

        'If (IsNothing(C_P_ADMIN) = True) Then
        '    Response.Redirect("~/Index.aspx")
        'End If

        'If (C_P_ADMIN.Value <> 1) Then
        '    Response.Redirect("~/Index.aspx")
        'End If

        'Select Case (CStr(CNICKNAME.Value).ToUpper)
        'Case "DPEREIRA", "MGS3"
        'Case Else
        'Response.Redirect("~/Index.aspx")
        'End Select
    End Sub
    Private Class resQuitaEstado
        Public idCf As Integer
        Public modificados As Integer
    End Class




End Class