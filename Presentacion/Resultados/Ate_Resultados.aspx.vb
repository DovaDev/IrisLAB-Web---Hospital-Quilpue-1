Imports Negocio
Imports Entidades
Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Web.HttpContext

Public Class Ate_Resultados
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

        Dim LOG As New N_Log
        Dim xNick As String = Current.Request.Cookies("NICKNAME").Value
        LOG.Path = "\LOG\Resultados\" & Format(Date.Now, "MM-dd-yyyy - !") & xNick & ".txt"
        LOG.Write_Line("ID_ATE = " & ID_ATE)

        'List_In = NN_Activo.IRIS_WEBF_BUSCA_VISOR_SECCION_POR_ID_ATENCION(ID_ATE)
        Return List_In
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
    Public Shared Function Page_Load() As E_IRIS_WEBF_RESULTADOS_PACIENTE_DATA
        'Declaraciones internas
        Dim NN_Ate_Det As New N_Ate_Resultados_Info
        Dim NN_Age As New N_Calc_Age
        Dim Data_Gen As New E_IRIS_WEBF_RESULTADOS_PACIENTE_DATA

        Dim LOG As New N_Log
        Dim xNick As String = Current.Request.Cookies("NICKNAME").Value

        LOG.Path = "\LOG\Resultados\" & Format(Date.Now, "MM-dd-yyyy - !") & xNick & ".txt"
        LOG.Write_Line("El usuario " & xNick & " ha ingresado al formulario.")
        LOG.Write_Line("Cargando datos del paciente...")

        Dim ID_ATE As Long = (New Ate_Resultados).ID_ATE

        'Realizar consulta
        Data_Gen = NN_Ate_Det.IRIS_WEBF_RESULTADOS_PACIENTE_DATA(ID_ATE)
        Data_Gen.EDAD = NN_Age.IrisLAB_Cal_Edad_Exacta(Data_Gen.PAC_FNAC, Date.Now)

        LOG.Write_Line("Paciente identificado:")
        LOG.Write_Line("<space />- RUT: " & Data_Gen.PAC_RUT, False)
        LOG.Write_Line("<space />- Nombre: " & Data_Gen.PAC_NOMBRE, False)
        LOG.Write_Line("Carga Completada.")
        LOG.Write_Line()
        LOG.Write_Separator()
        Return Data_Gen
    End Function

    <Services.WebMethod()>
    Public Shared Function Json_DataTable('ByVal R_ID_ATE As Long,
                                          ByVal R_ID_SECC As Integer,
                                          ByVal R_ID_EXAM As Integer,
                                          ByVal R_ID_PAC As Long,
                                          ByVal R_FNAC As Date,
                                          ByVal R_SEXO As String) As List(Of E_Json_Result_DataTable)
        'Declaraciones internas
        Dim Data_Res01 As List(Of E_IRIS_WEBF_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN2)
        Dim NN_Result As New N_Ate_Resultados
        Dim Mx_F_Nac(2) As String
        Dim NN_Date As New N_Date

        Dim LOG As New N_Log
        Dim xNick As String = Current.Request.Cookies("NICKNAME").Value
        LOG.Path = "\LOG\Resultados\" & Format(Date.Now, "MM-dd-yyyy - !") & xNick & ".txt"
        LOG.Write_Line("Cargando resultados del paciente...")

        'Realizar consultas
        NN_Result.ID_ATE = (New Ate_Resultados).ID_ATE
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

        'Data_Res01 = NN_Result.IRIS_WEBF_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN2(R_ID_ATE, R_ID_SECC, R_ID_EXAM)
        Data_Res01 = NN_Result.IRIS_WEBF_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN2(NN_Result.ID_ATE, R_ID_SECC, R_ID_EXAM)
        LOG.Write_Line("Cant. Resultados: " & Data_Res01.Count)
        LOG.Write_Line("<space />Carga Completada.", False)
        LOG.Write_Line()
        LOG.Write_Separator()
        Return NN_Result.Build_Json_Datatable(Data_Res01)
    End Function

    <Services.WebMethod()>
    Public Shared Sub IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_TEXTO(ByVal ID_RES As Integer, ByVal RES As String)
        Dim NN_Result As New N_Ate_Resultados
        Dim LOG As New N_Log
        Dim xNick As String = Current.Request.Cookies("NICKNAME").Value

        If (Current.Request.Cookies("NICKNAME").Value = Nothing) Then
            Current.Response.Redirect("~index.aspx")
        End If

        LOG.Path = "\LOG\Resultados\" & Format(Date.Now, "MM-dd-yyyy - !") & xNick & ".txt"
        LOG.Write_Line("Actualizar Valor Texto")
        LOG.Write_Line("<space />Usuario: " & xNick, False)
        LOG.Write_Line("<space />ID Result: " & ID_RES, False)
        LOG.Write_Line("<space />Resultado: " & RES, False)

        Try
            NN_Result.IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_TEXTO(ID_RES, RES)

            Dim xID_USER As Long = CLng(Current.Request.Cookies("ID_USER").Value)
            NN_Result.IRIS_WEBF_GRABA_CONTROL_AUDITORIA(xID_USER, "DIGITA RESULTADO: " & RES, "DIGITADO", ID_RES)

            LOG.Write_Line("Campo actualizado correctamente")
            LOG.Write_Line()
            LOG.Write_Separator()
        Catch ex As Exception
            LOG.Write_ERROR(ex)
        End Try

    End Sub

    <Services.WebMethod()>
    Public Shared Sub IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_NUMERICO(ByVal ID_RES As Integer, ByVal RES As String, ByVal EVAL As String)
        Dim NN_Result As New N_Ate_Resultados
        Dim LOG As New N_Log
        Dim xNick As String = Current.Request.Cookies("NICKNAME").Value
        LOG.Path = "\LOG\Resultados\" & Format(Date.Now, "MM-dd-yyyy - !") & xNick & ".txt"
        LOG.Write_Line("Actualizar Valor Numérico")
        LOG.Write_Line("<space />Usuario: " & xNick, False)
        LOG.Write_Line("<space />ID Result: " & ID_RES, False)
        LOG.Write_Line("<space />Resultado: " & RES, False)
        LOG.Write_Line("<space />Evaluación: " & EVAL, False)

        If (Current.Request.Cookies("NICKNAME").Value = Nothing) Then
            Current.Response.Redirect("~index.aspx")
        End If

        Try
            NN_Result.IRIS_WEBF_UPDATE_RESULDADO_DE_EXAMEN_NUMERICO(ID_RES, RES, EVAL)

            Dim xID_USER As Long = CLng(Current.Request.Cookies("ID_USER").Value)
            NN_Result.IRIS_WEBF_GRABA_CONTROL_AUDITORIA(xID_USER, "DIGITA RESULTADO: " & RES, "DIGITADO", ID_RES)

            LOG.Write_Line("Campo actualizado correctamente")
            LOG.Write_Line()
            LOG.Write_Separator()
        Catch ex As Exception
            LOG.Write_ERROR(ex)
        End Try
    End Sub

    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")
        Dim C_ID_USER As HttpCookie = Request.Cookies.Get("ID_USER")
        Dim CNICKNAME As HttpCookie = Request.Cookies.Get("NICKNAME")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If

        'If (C_P_ADMIN.Value <> 1) Then
        '    Response.Redirect("~/Index.aspx")
        'End If

        'Select Case (CStr(CNICKNAME.Value).ToUpper)
        'Case "DPEREIRA", "MGS3"
        'Case Else
        'Response.Redirect("~/Index.aspx")
        'End Select
    End Sub

    <Services.WebMethod()>
    Public Shared Function Fill_Audit(ByVal ID_RES As Integer) As List(Of E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA)
        Dim NN_Result As New N_Ate_Resultados

        Return NN_Result.IRIS_WEBF_BUSCA_CONTROL_AUDITORIA(ID_RES)
    End Function

    <Services.WebMethod()>
    Public Shared Sub Set_Validate(ByVal Obj_Valid As List(Of E_Valid_Params))
        Dim NN_Data As New N_Ate_Resultados
        Dim Cookie_ID As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")

        If (IsNothing(Cookie_ID) = True) Then
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End If

        For Each ItemParam In Obj_Valid
            NN_Data.IRIS_WEBF_UPDATE_VALIDA_RESULTADO(ItemParam.ID_ATE_RES, CInt(Cookie_ID.Value), ItemParam.DESDE, ItemParam.HASTA, ItemParam.AB, ItemParam.MUY_DESDE, ItemParam.MUY_HASTA, ItemParam.MUY_AB, ItemParam.UNIDADES)

            NN_Data = New N_Ate_Resultados
            NN_Data.IRIS_WEBF_GRABA_CONTROL_AUDITORIA(Cookie_ID.Value, "VALIDA RESULTADO : " & ItemParam.VALUE, "DIGITADO", ItemParam.ID_ATE_RES)
        Next
        Dim xID_USER As Long = CLng(Current.Request.Cookies("ID_USER").Value)
    End Sub

    <Services.WebMethod()>
    Public Shared Sub Set_Unvalidate(ByVal Obj_Unvalid As List(Of E_Unvalid_Params))
        Dim NN_Data As New N_Ate_Resultados
        Dim Cookie_ID As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")

        If (IsNothing(Cookie_ID) = True) Then
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End If

        For Each ItemParam In Obj_Unvalid
            NN_Data.IRIS_WEBF_UPDATE_DESVALIDA_RESULTADO(ItemParam.ID_ATE_RES, CInt(Cookie_ID.Value))

            NN_Data = New N_Ate_Resultados
            NN_Data.IRIS_WEBF_GRABA_CONTROL_AUDITORIA(Cookie_ID.Value, "DESVALIDA RESULTADO : " & ItemParam.VALUE, "DIGITADO", ItemParam.ID_ATE_RES)
        Next
    End Sub

    <Services.WebMethod()>
    Public Shared Function Get_Result_Cod(ByVal ID_PRUEBA As Integer) As List(Of E_IRIS_WEBF_CMVM_RESULTADOS_CODIFICADO_ACTIVOS)
        Dim NNN As New N_Ate_Resultados

        Return NNN.IRIS_WEBF_CMVM_RESULTADOS_CODIFICADO_ACTIVOS(ID_PRUEBA)
    End Function

    <Services.WebMethod()>
    Public Shared Function Change_Ate_L_or_R(ByVal ID_ATE As Long, ByVal DIRECTION As Boolean, ByVal ID_PROC As Integer,
                                             ByVal ID_PREV As Integer, ByVal ID_PROG As Integer, ByVal ID_SECC As Integer,
                                             ByVal ID_EXAM As Integer, ByVal ID_SECT As Integer, ByVal ID_PACI As Long) As String
        Dim NNN As New N_Ate_Resultados
        Dim EEE As New N_Encrypt
        Dim ID_OTHER As Long
        Dim StrEncr As String = ""

        ID_OTHER = NNN.IRIS_WEBF_CMVM_BUSCA_ATE_L_R(ID_ATE, DIRECTION, ID_PROC, ID_PREV, ID_PROG, ID_SECC, ID_EXAM, ID_SECT, ID_PACI)
        StrEncr = EEE.Encode(CStr(ID_OTHER))

        Return StrEncr
    End Function

    <Services.WebMethod()>
    Public Shared Function Get_Hist_General_Info() As E_IRIS_WEBF_CMVM_RESULTADOS_HISTORICOS_GENERAL_INFO
        Dim AAA As New Ate_Resultados
        Dim NNN As New N_Ate_Resultados

        Return NNN.IRIS_WEBF_CMVM_RESULTADOS_HISTORICOS_GENERAL_INFO(AAA.ID_ATE)
    End Function

    <Services.WebMethod()>
    Public Shared Function Get_ID_ATE_by_NUM_ATE(ByVal NUM_ATE As Long) As String
        Dim NNN As New N_Ate_Resultados
        Dim RRR As Long = 0
        Dim DEC As String

        'RRR = NNN.IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ID_ATE_BY_ATE_NUM(NUM_ATE)
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

    Public Class E_Valid_Params
        Private EE_HASTA As String
        Public Property HASTA() As String
            Get
                Return EE_HASTA
            End Get
            Set(ByVal value As String)
                EE_HASTA = value
            End Set
        End Property
        Private EE_DESDE As String
        Public Property DESDE() As String
            Get
                Return EE_DESDE
            End Get
            Set(ByVal value As String)
                EE_DESDE = value
            End Set
        End Property
        Private EE_ID_ATE_RES As Integer
        Public Property ID_ATE_RES() As Integer
            Get
                Return EE_ID_ATE_RES
            End Get
            Set(ByVal value As Integer)
                EE_ID_ATE_RES = value
            End Set
        End Property
        Private EE_AB As String
        Public Property AB() As String
            Get
                Return EE_AB
            End Get
            Set(ByVal value As String)
                EE_AB = value
            End Set
        End Property
        Private EE_MUY_DESDE As String
        Public Property MUY_DESDE() As String
            Get
                Return EE_MUY_DESDE
            End Get
            Set(ByVal value As String)
                EE_MUY_DESDE = value
            End Set
        End Property
        Private EE_MUY_HASTA As String
        Public Property MUY_HASTA() As String
            Get
                Return EE_MUY_HASTA
            End Get
            Set(ByVal value As String)
                EE_MUY_HASTA = value
            End Set
        End Property
        Private EE_MUY_AB As String
        Public Property MUY_AB() As String
            Get
                Return EE_MUY_AB
            End Get
            Set(ByVal value As String)
                EE_MUY_AB = value
            End Set
        End Property
        Private EE_UNIDADES As String
        Public Property UNIDADES() As String
            Get
                Return EE_UNIDADES
            End Get
            Set(ByVal value As String)
                EE_UNIDADES = value
            End Set
        End Property
        Private EE_VALUE As String
        Public Property VALUE() As String
            Get
                Return EE_VALUE
            End Get
            Set(ByVal value As String)
                EE_VALUE = value
            End Set
        End Property
    End Class

    Public Class E_Unvalid_Params
        Private EE_ID_ATE_RES As Integer
        Public Property ID_ATE_RES() As Integer
            Get
                Return EE_ID_ATE_RES
            End Get
            Set(ByVal value As Integer)
                EE_ID_ATE_RES = value
            End Set
        End Property
        Private EE_VALUE As String
        Public Property VALUE() As String
            Get
                Return EE_VALUE
            End Get
            Set(ByVal value As String)
                EE_VALUE = value
            End Set
        End Property
    End Class
End Class