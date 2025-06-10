Imports Entidades
Imports Negocio
Imports System
Imports System.Collections.Generic
Imports System.Runtime.Remoting
Imports System.Text
Imports System.Web
Imports System.Web.Script.Serialization
Public Class AGRE_EXA_ATE_CJ
    Inherits System.Web.UI.Page


    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub

    <Services.WebMethod()>
    Public Shared Function Llenar_tabla_exam2_ID_CF(ByVal ID_PREVE As Integer, ByVal Fecha As String, ByVal ID_CF As Integer, ByVal ID_CF_REAL As Integer) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION)
        Dim NN As N_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION = New N_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION
        Dim ANO As Date
        ANO = CDate(Fecha)
        data_paciente = NN.IRIS_WEBF_CMVM_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION_BONIFICACION_ID_CODIGO_FONASA(Format(ANO, "yyyy"), ID_PREVE, ID_CF, ID_CF_REAL)
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
    Public Shared Function Request_Prevision() As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Prev_Activo As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Consultar por previsiones activas
        Data_Prev_Activo = NN_Activos.IRIS_WEBF_CMVM_BUSCA_PREVISION_ACTIVO_AND_PART_WEB

        Return Data_Prev_Activo

    End Function
    '<Services.WebMethod()>
    'Public Shared Function Request_Prevision(ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
    '    'Declaraciones internas
    '    Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
    '    Dim NN As N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO = New N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
    '    data_paciente = NN.IRIS_WEBF_CMVM_BUSCA_PREVISION_POR_PROCEDENCIA_ID_PROCE_2_AND_PART_WEB(ID_PROC)

    '    Return data_paciente
    'End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_NO_ESTADO_AGENDA_DESC(ByVal ID_PREVE As Integer, ByVal Fecha As String, ByVal CF As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        Dim NN As N_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA = New N_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA
        Dim ANO As Date
        ANO = CDate(Fecha)
        data_paciente = NN.IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_NO_ESTADO_AGENDA_DESC_BONIFICACION(ID_PREVE, Format(ANO, "yyyy"), CF)
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
    Public Shared Function IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_NO_ESTADO_AGENDA_BONIFICACION(ByVal ID_PREVE As Integer, ByVal Fecha As String, ByVal CF As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        Dim NN As N_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA = New N_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA
        Dim ANO As Date
        ANO = CDate(Fecha)
        data_paciente = NN.IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_NO_ESTADO_AGENDA_BONIFICACION(ID_PREVE, Format(ANO, "yyyy"), CF)
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
    Public Shared Function Llenar_tabla_exam2(ByVal ID_PREVE As Integer, ByVal Fecha As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION)
        Dim NN As N_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION = New N_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION
        Dim ANO As Date
        ANO = CDate(Fecha)
        data_paciente = NN.IRIS_WEBF_CMVM_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION_BONIFICACION(Format(ANO, "yyyy"), ID_PREVE)
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
    Public Shared Function Llenar_tabla_exam2_particular(ByVal ID_PREVE As Integer, ByVal Fecha As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""

        'Declaraciones internas
        Dim data_particular As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION)
        Dim NN_particular As N_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION = New N_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION

        Dim ANO As Date
        ANO = CDate(Fecha)

        data_particular = NN_particular.IRIS_WEBF_CMVM_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION_PARTICULAR_BONIFICACION(Format(ANO, "yyyy"), ID_PREVE)

        If (data_particular.Count > 0) Then

            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_particular, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function tipo_pago() As List(Of E_IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE)

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE)
        Dim NN As N_Gen_Activos = New N_Gen_Activos
        data_paciente = NN.IRIS_WEBF_CMVM_BUSCA_TIPO_DE_PAGO_INGRESO_ATE_SIN_EFECTIVO()

        Return data_paciente

    End Function
    <Services.WebMethod()>
    Public Shared Function MODAL_PAC(ByVal ID As String) As REEE


        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim data_pac As List(Of E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2)
        Dim NN_pac As New N_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2
        Dim data_examen As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL)
        Dim NN_Examen As New N_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL

        Dim data_atencion As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION)
        Dim NN_atencion As New N_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION

        Dim reeeeeee As New REEE

        data_pac = NN_pac.IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES_2_NEW(ID)

        If data_pac.Count > 0 Then
            data_examen = NN_Examen.IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL_3_NEW(ID)
            data_atencion = NN_atencion.IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION_2_NEW(ID)

            reeeeeee.proparra1 = data_pac
            reeeeeee.proparra2 = data_examen
            reeeeeee.proparra3 = data_atencion

        End If



        'Declaraciones internas
        Return reeeeeee
    End Function
    <Services.WebMethod()>
    Public Shared Function MODAL_PAC_RUT(ByVal ID As String) As REEE


        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim data_pac As List(Of E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2)
        Dim NN_pac As New N_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2
        Dim data_examen As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL)
        Dim NN_Examen As New N_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL

        Dim data_atencion As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION)
        Dim NN_atencion As New N_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION

        Dim reeeeeee As New REEE

        data_pac = NN_pac.IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES_2_POR_RUT_NEW(ID)

        If data_pac.Count > 0 Then
            data_examen = NN_Examen.IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL_3_POR_RUT_NEW(data_pac(0).ID_PREINGRESO)
            data_atencion = NN_atencion.IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION_2_POR_RUT_NEW(data_pac(0).ID_PREINGRESO)

            reeeeeee.proparra1 = data_pac
            reeeeeee.proparra2 = data_examen
            reeeeeee.proparra3 = data_atencion

        End If



        'Declaraciones internas
        Return reeeeeee
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_examenes_paciente(ByVal examenes As List(Of examens_avis)) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_HOST_BUSCA_CODIGO_FONSA_POR_COD_AVIS)
        Dim NN As N_IRIS_WEBF_HOST_BUSCA_CODIGO_FONSA_POR_COD_AVIS = New N_IRIS_WEBF_HOST_BUSCA_CODIGO_FONSA_POR_COD_AVIS
        Dim examenes_back As New List(Of E_IRIS_WEBF_HOST_BUSCA_CODIGO_FONSA_POR_COD_AVIS)
        For x = 0 To examenes.Count - 1
            data_paciente = NN.IRIS_WEBF_HOST_BUSCA_CODIGO_FONSA_POR_COD_OMI_PER(examenes(x).examen)

            If (data_paciente.Count > 0) Then
                Dim Item_Exam As New E_IRIS_WEBF_HOST_BUSCA_CODIGO_FONSA_POR_COD_AVIS
                Item_Exam.ID_CODIGO_FONASA = data_paciente(0).ID_CODIGO_FONASA
                Item_Exam.CF_COD = data_paciente(0).CF_COD
                Item_Exam.CF_DESC = data_paciente(0).CF_DESC
                Item_Exam.ID_ESTADO = data_paciente(0).ID_ESTADO
                Item_Exam.CF_AVIS = data_paciente(0).CF_AVIS
                Item_Exam.HO_CC = examenes(x).HO_CC
                Item_Exam.CODIGO_TEST = examenes(x).examen
                Item_Exam.ID_PER = data_paciente(0).ID_PER
                examenes_back.Add(Item_Exam)
            End If
        Next x
        If (examenes_back.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(examenes_back, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function

    <Services.WebMethod()>
    Public Shared Function MODAL_PAC_DNI(ByVal ID As String) As REEE


        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim data_pac As List(Of E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2)
        Dim NN_pac As New N_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2
        Dim data_examen As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL)
        Dim NN_Examen As New N_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL

        Dim data_atencion As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION)
        Dim NN_atencion As New N_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION

        Dim reeeeeee As New REEE

        data_pac = NN_pac.IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES_2_POR_DNI_NEW(ID)

        If data_pac.Count > 0 Then
            data_examen = NN_Examen.IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL_3_POR_DNI_NEW(data_pac(0).ID_PREINGRESO)
            data_atencion = NN_atencion.IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION_2_POR_DNI_NEW(ID)

            reeeeeee.proparra1 = data_pac
            reeeeeee.proparra2 = data_examen
            reeeeeee.proparra3 = data_atencion
        End If


        'Declaraciones internas
        Return reeeeeee
    End Function
    <Services.WebMethod()>
    Public Shared Function Eliminar_Examen2(ByVal ID_ATENCION As Integer,
                                           ByVal ID_CODIGO_FONASA As Integer,
                                           ByVal S_Id_User As Integer) As String

        Return "null"
    End Function

    '<Services.WebMethod()>
    'Public Shared Function Eliminar_Examen(ByVal ID_ATENCION As Integer,
    '                                       ByVal ID_CODIGO_FONASA As Integer,
    '                                       ByVal S_Id_User As Integer) As String
    '    'Declaraciones del Serializador
    '    Dim Serializer As New JavaScriptSerializer
    '    Dim str_Builder As New StringBuilder
    '    Dim datas As String = ""
    '    'Declaraciones internas
    '    'Dim data_eliminar As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
    '    Dim int_eliminar As Integer = 0
    '    Dim NN_eliminar As New N_IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS

    '    Dim update_confirm As Integer
    '    'Dim update_confirm_det As Integer
    '    'Dim update_log As Integer

    '    Dim data_money_old As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
    '    Dim data_rel_copago_old As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
    '    Dim data_det_ate_old As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
    '    Dim reset_copago As Integer = 0
    '    Dim reset_ate_resultado As Integer = 0
    '    Dim dual_copago As Integer
    '    Dim ddx As New N_IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS
    '    Dim ddx2 As New N_IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS
    '    Dim ddx3 As New N_IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS
    '    Dim ddx4 As New N_IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS
    '    Dim ddx5 As New N_IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS
    '    Dim ddx6 As New N_IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS

    '    Dim VALOR_PREVI As Integer = 0
    '    Dim VALOR_BENEFI As Integer = 0
    '    Dim VALOR_SC As Integer = 0
    '    Dim VALOR_PAGADO As Integer = 0
    '    Dim VALOR_CF As Integer = 0
    '    Dim VALOR_CP As Integer = 0

    '    Dim COPAGO_REL As Integer = 0
    '    Dim PARTICULAR_REL As Integer = 0

    '    data_money_old = ddx3.IRIS_WEBF_CMVM_BUSCA_ATENCION_PROGRA2_PRO_SECTOR_AVIS_3_NEW_CAJA_MAS_SC_CHANGE_TP_PAGO(ID_ATENCION)                       'BUSCA DATA ATENCION
    '    data_det_ate_old = ddx4.IRIS_WEBF_CMVM_BUSCA_DET_ATENCION_ELIMINA_EXAMEN(ID_ATENCION, ID_CODIGO_FONASA)                                         'BUSCA DATA DETALLE ATENCION

    '    data_rel_copago_old = ddx4.IRIS_WEBF_BUSCA_REL_COPAGO_AGREGA_EXAMEN(ID_ATENCION)                                                                'BUSCA DATA REL_COPAGO

    '    If data_rel_copago_old.Count > 0 Then
    '        COPAGO_REL += (CInt(data_rel_copago_old(0).REL_MONTO_COPAGO_1) + CInt(data_rel_copago_old(0).REL_MONTO_COPAGO_2))
    '        PARTICULAR_REL += (CInt(data_rel_copago_old(0).REL_MONTO_PARTICULAR) + CInt(data_rel_copago_old(0).REL_MONTO_PARTICULAR_2))

    '    End If

    '    If (data_money_old.Count > 0 And data_det_ate_old.Count > 0) Then

    '        VALOR_PREVI = data_money_old(0).ATE_TOTAL_PREVI
    '        VALOR_BENEFI = data_money_old(0).ATE_V_BENEF
    '        VALOR_SC = data_money_old(0).ATE_V_SC
    '        VALOR_PAGADO = data_money_old(0).ATE_TOTAL
    '        VALOR_CP = data_money_old(0).ATE_V_CP
    '        VALOR_CF = data_money_old(0).ATE_V_CF

    '        VALOR_PREVI -= data_det_ate_old(0).ATE_DET_V_PREVI
    '        VALOR_BENEFI -= data_det_ate_old(0).ATE_DET_VALOR_BENEF
    '        VALOR_SC -= data_det_ate_old(0).ATE_DET_VALOR_CS
    '        VALOR_PAGADO -= CInt(data_det_ate_old(0).ATE_DET_V_PREVI) - CInt(data_det_ate_old(0).ATE_DET_VALOR_BENEF) - CInt(data_det_ate_old(0).ATE_DET_VALOR_CS)

    '        If (data_det_ate_old(0).ID_TP_PAGO = 1 Or data_det_ate_old(0).ID_TP_PAGO = 20 Or data_det_ate_old(0).ID_TP_PAGO = 4) Then
    '            VALOR_CP -= CInt(data_det_ate_old(0).ATE_DET_V_PREVI) - CInt(data_det_ate_old(0).ATE_DET_VALOR_BENEF) - CInt(data_det_ate_old(0).ATE_DET_VALOR_CS)
    '            PARTICULAR_REL -= CInt(data_det_ate_old(0).ATE_DET_V_PREVI) - CInt(data_det_ate_old(0).ATE_DET_VALOR_BENEF) - CInt(data_det_ate_old(0).ATE_DET_VALOR_CS)
    '        Else
    '            VALOR_CF -= CInt(data_det_ate_old(0).ATE_DET_V_PREVI) - CInt(data_det_ate_old(0).ATE_DET_VALOR_BENEF) - CInt(data_det_ate_old(0).ATE_DET_VALOR_CS)
    '            COPAGO_REL -= CInt(data_det_ate_old(0).ATE_DET_V_PREVI) - CInt(data_det_ate_old(0).ATE_DET_VALOR_BENEF) - CInt(data_det_ate_old(0).ATE_DET_VALOR_CS)
    '        End If
    '    End If


    '    'AQUI MODIFICA ATENCION
    '    update_confirm = ddx.IRIS_WEBF_CMVM_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS_3_NEW_CAJA_MAS_SC_CHANGE_TP_PAGO(ID_ATENCION,                        'UPDATE ATENCIÓN
    '                                                                                                                    VALOR_PREVI,
    '                                                                                                                    VALOR_BENEFI,
    '                                                                                                                    VALOR_SC,
    '                                                                                                                    VALOR_PAGADO,
    '                                                                                                                    VALOR_CF,
    '                                                                                                                    VALOR_CP)
    '    'AQUI ELIMINA EXAMEN
    '    int_eliminar = NN_eliminar.IRIS_WEBF_CMVM_UPDATE_ATE_ELIMINAR_EXAMEN_DET_ATE_CAJA(ID_ATENCION, ID_CODIGO_FONASA)               'ELIMINA EXAMEN


    '    'AQUI  RESETEA REL COPAGO
    '    reset_copago = ddx2.IRIS_WEBF_CMVM_RESET_REL_COPAGO_BY_ID_ATENCION(ID_ATENCION)                                                                 'ELIMINA REL_COPAGO
    '    Dim ORIGEN As String = "AGRE_EXA_ATE_CJ - ELIMINA EXAMEN"
    '    If (reset_copago <> 0) Then
    '        '--------------------------- DUAL COPAGO ---------------------------
    '        If (data_rel_copago_old.Count > 0) Then
    '            dual_copago = ddx.IRIS_WEBF_CMVM_GRABA_REL_COPAGO_2(ID_ATENCION,
    '                                              CInt(S_Id_User),
    '                                              Date.Now,
    '                                              data_rel_copago_old(0).ID_TP_PAGO_COPAGO_1,
    '                                              CInt(COPAGO_REL),
    '                                              data_rel_copago_old(0).ID_TP_PAGO_COPAGO_2,
    '                                              0,                                                                'COPAGO_2 = 0, todo queda en copago 1
    '                                              0,
    '                                              0,
    '                                              data_rel_copago_old(0).ID_TP_PAGO_PARTICULAR,
    '                                              CInt(PARTICULAR_REL),
    '                                              data_rel_copago_old(0).ID_TP_PAGO_PARTICULAR_2,
    '                                              0,
    '                                            ORIGEN)                                                                'PARTICULAR_2 = 0 todo queda en particular_1
    '        Else
    '            '?
    '        End If

    '    End If

    '    'AQUI ELIMINA ATE RESULTADO

    '    reset_ate_resultado = ddx5.IRIS_WEBF_CMVM_UPDATE_ELIMINAR_ATE_RESULTADO_CAJA(ID_ATENCION, ID_CODIGO_FONASA)                                     'ELIMINA ATE RESULTADO

    '    If int_eliminar <> 0 Then

    '        Dim write_log As Integer = 0

    '        write_log = ddx6.IRIS_WEBF_GRABA_HISTORIA_ATENCION_AGREGA_QUITA(ID_ATENCION,
    '                             ID_CODIGO_FONASA,
    '                             data_money_old(0).ATE_TOTAL,
    '                             data_money_old(0).ATE_V_CF,
    '                             data_money_old(0).ATE_TOTAL_PREVI,
    '                             VALOR_PREVI,
    '                             VALOR_CF,
    '                             VALOR_PAGADO,
    '                             VALOR_PREVI,
    '                             2,
    '                             S_Id_User, data_det_ate_old(0).ID_DET_ATE)
    '        Return "ok"
    '    Else
    '        Return "null"
    '    End If
    '    Return datas
    'End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal fecha As String, ByVal id As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_procedencia As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX)
        Dim NN_Procedencia As New N_PROCEDENCIAS_Y_CANT_MAX

        data_procedencia = NN_Procedencia.IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX(Date.Now, id)
        If data_procedencia.Count > 0 Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_procedencia, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    '<Services.WebMethod()>
    'Public Shared Function Guardar_TodoByVal(ByVal ids As List(Of ids5555_CC),
    '                                         ByVal ID_ATENCION As String,
    '                                         ByVal ATE_V_SISTEMA As String, 'PARÁMETROS  CAJA    '1  VALOR PREVISIION
    '                                         ByVal ATE_V_BENEF As String,                        '2  VALOR BENEFICIARIO +  SEGURO COMPLEMENATRIO
    '                                         ByVal ATE_V_CF As String,                           '3  TOTAL FONASA
    '                                         ByVal ATE_V_CF_FP As String,                        '4  TIPO DE PAGO FONASA
    '                                         ByVal ATE_V_CP As String,                           '5  VALOR PARTICULAR
    '                                         ByVal ATE_V_CP_FP As String,                        '6  TIPO DE PAGO PARTICULAR
    '                                         ByVal ATE_V_BOLETA As String,                       '7  NUMERO DE BOLETA
    '                                         ByVal ATE_V_PAGADO As String,                       '8  TOTAL SUPREMO
    '                                         ByVal ATE_V_SEG_COMP As String,                     '9  SEGURO COMPLEMENTARIO
    '                                         ByVal ATE_TP_COPAGO_1 As String,                   '10 TIPO COPAGO 1
    '                                         ByVal ATE_VALOR_COPAGO_1 As String,                '11 VALOR COPAGO 1
    '                                         ByVal ATE_TP_COPAGO_2 As String,                   '12 TIPO COPAGO 2
    '                                         ByVal ATE_VALOR_COPAGO_2 As String,                '13 VALOR COPAGO 2
    '                                         ByVal ATE_TP_PARTICULAR_1 As String,               '14 TIPO PARTICULAR 1
    '                                         ByVal ATE_VALOR_PARTICULAR_1 As String,            '15 VALOR PARTICULAR
    '                                         ByVal ATE_TP_PARTICULAR_2 As String,               '16 TIPO PARTICULAR 2 
    '                                         ByVal ATE_VALOR_PARTICULAR_2 As String,             '17 VALOR PARTICULAR 2
    '                                         ByVal ATE_V_SC As String,
    '                                         ByVal S_Id_User As Integer)                         'NUEVO ID_USUARIO) As String
    '    'Checar Galletas
    '    If (Test_C.emptyCookies = True) Then
    '        HttpContext.Current.Response.Redirect("~index.aspx", False)
    '        Return Nothing
    '    End If

    '    Dim ATE_V_SISTEMA_2 As String
    '    Dim ATE_V_BENEF_2 As String
    '    Dim ATE_V_CF_2 As String
    '    Dim ATE_V_CF_FP_2 As String
    '    Dim ATE_V_CP_2 As String
    '    Dim ATE_V_CP_FP_2 As String
    '    Dim ATE_V_BOLETA_2 As String
    '    Dim ATE_V_PAGADO_2 As String
    '    Dim ATE_V_SEG_COMP_2 As String
    '    Dim ATE_V_SC_2 As String

    '    If (ATE_V_SC <> "") Then
    '        ATE_V_SC_2 = ATE_V_SC.ToString().Replace(".", "")
    '    Else
    '        ATE_V_SC_2 = 0
    '    End If


    '    Dim ATE_VALOR_PARTICULAR_1_2 As String
    '    Dim ATE_VALOR_PARTICULAR_2_2 As String

    '    If ATE_VALOR_PARTICULAR_2 <> "" Then
    '        ATE_VALOR_PARTICULAR_2_2 = ATE_VALOR_PARTICULAR_2.ToString().Replace(".", "")
    '    Else
    '        ATE_VALOR_PARTICULAR_2_2 = 0
    '    End If

    '    If ATE_VALOR_PARTICULAR_1 <> "" Then
    '        ATE_VALOR_PARTICULAR_1_2 = ATE_VALOR_PARTICULAR_1.ToString().Replace(".", "")
    '    Else
    '        ATE_VALOR_PARTICULAR_1_2 = 0
    '    End If

    '    If ATE_V_SISTEMA <> "" Then
    '        ATE_V_SISTEMA_2 = ATE_V_SISTEMA.ToString().Replace(".", "")
    '    Else
    '        ATE_V_SISTEMA_2 = 0
    '    End If

    '    If ATE_V_BENEF <> "" Then
    '        ATE_V_BENEF_2 = ATE_V_BENEF.ToString().Replace(".", "")
    '    Else
    '        ATE_V_BENEF_2 = 0
    '    End If

    '    If ATE_V_CF <> "" Then
    '        ATE_V_CF_2 = ATE_V_CF.ToString().Replace(".", "")
    '    Else
    '        ATE_V_CF_2 = 0
    '    End If

    '    If ATE_V_CF_FP <> "" Then
    '        ATE_V_CF_FP_2 = ATE_V_CF_FP.ToString().Replace(".", "")
    '    Else
    '        ATE_V_CF_FP_2 = 0
    '    End If

    '    If ATE_V_CP <> "" Then
    '        ATE_V_CP_2 = ATE_V_CP.ToString().Replace(".", "")
    '    Else
    '        ATE_V_CP_2 = 0
    '    End If

    '    If ATE_V_CP_FP <> "" Then
    '        ATE_V_CP_FP_2 = ATE_V_CP_FP.ToString().Replace(".", "")
    '    Else
    '        ATE_V_CP_FP_2 = 0
    '    End If

    '    If ATE_V_BOLETA <> "" Then
    '        ATE_V_BOLETA_2 = ATE_V_BOLETA.ToString().Replace(".", "")
    '    Else
    '        ATE_V_BOLETA_2 = 0
    '    End If

    '    If ATE_V_PAGADO <> "" Then
    '        ATE_V_PAGADO_2 = ATE_V_PAGADO.ToString().Replace(".", "")
    '    Else
    '        ATE_V_PAGADO_2 = 0
    '    End If

    '    If ATE_V_SEG_COMP <> "" Then
    '        ATE_V_SEG_COMP_2 = ATE_V_SEG_COMP.ToString().Replace(".", "")
    '    Else
    '        ATE_V_SEG_COMP_2 = 0
    '    End If

    '    'Declaraciones del Serializador
    '    Dim Serializer As New JavaScriptSerializer
    '    Dim str_Builder As New StringBuilder
    '    'Dim data_pac As List(Of E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2)
    '    Dim NN_pac As New N_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2
    '    'Dim data_examen As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL)
    '    Dim NN_Examen As New N_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL
    '    'Dim data_atencion As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION)
    '    Dim NN_atencion As New N_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION
    '    Dim correlativo2 As Integer
    '    Dim objSession As HttpSessionState = HttpContext.Current.Session
    '    'Dim S_Id_User As String = CType(objSession("ID_USER"), String)
    '    Dim ddx As New N_IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS
    '    Dim ddx2 As New N_IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS
    '    Dim ddx3 As New N_IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS
    '    Dim ddx4 As New N_IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS
    '    Dim ccx As New N_IRIS_WEBF_BUSCA_CORRELATIVO_ATENCION
    '    Dim id As Integer
    '    Dim jj As New N_IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_AVIS
    '    Dim resu As Integer
    '    Dim resuresu As New N_IRIS_WEBF_GRABA_RESULTADO_ATENCION
    '    Dim PERFIL_PRUEBA As List(Of E_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION)
    '    Dim hh As New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
    '    Dim Str_Out As String = ""

    '    Dim dual_copago As Integer
    '    Dim reset_copago As Integer = 0

    '    Dim update_confirm As Integer
    '    'Dim update_confirm_det As Integer
    '    'Dim update_log As Integer

    '    Dim VALOR_PREVI As Integer = 0
    '    Dim VALOR_BENEFI As Integer = 0
    '    Dim VALOR_SC As Integer = 0
    '    Dim VALOR_PAGADO As Integer = 0
    '    Dim VALOR_CF As Integer = 0
    '    Dim VALOR_CP As Integer = 0

    '    Dim COPAGO_REL As Integer = 0
    '    Dim PARTICULAR_REL As Integer = 0

    '    Dim data_money_old As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
    '    Dim data_rel_copago_old As List(Of E_IRIS_WEBF_BUSCA_RESUMEN_PREVE_PROG_SUBP)
    '    '------------------------------------- PRINCIPIO NUEVAS COSAS -----------------------------------------------------------------

    '    data_money_old = ddx3.IRIS_WEBF_CMVM_BUSCA_ATENCION_PROGRA2_PRO_SECTOR_AVIS_3_NEW_CAJA_MAS_SC_CHANGE_TP_PAGO(ID_ATENCION)

    '    For i = 0 To ids.Count - 1
    '        VALOR_PREVI += ids(i).Valor
    '        VALOR_BENEFI += ids(i).ATE_DET_VALOR_BENEF
    '        VALOR_SC += ids(i).ATE_DET_VALOR_CS
    '        VALOR_PAGADO += ids(i).Valor - ids(i).ATE_DET_VALOR_BENEF - ids(i).ATE_DET_VALOR_CS

    '        If (ids(i).CF_TP_PAGO = 1 Or ids(i).CF_TP_PAGO = 20 Or ids(i).CF_TP_PAGO = 4) Then
    '            VALOR_CP += ids(i).Valor - ids(i).ATE_DET_VALOR_BENEF - ids(i).ATE_DET_VALOR_CS
    '            PARTICULAR_REL += ids(i).Valor - ids(i).ATE_DET_VALOR_BENEF - ids(i).ATE_DET_VALOR_CS
    '        Else
    '            VALOR_CF += ids(i).Valor - ids(i).ATE_DET_VALOR_BENEF - ids(i).ATE_DET_VALOR_CS
    '            COPAGO_REL += ids(i).Valor - ids(i).ATE_DET_VALOR_BENEF - ids(i).ATE_DET_VALOR_CS
    '        End If

    '    Next i

    '    If data_money_old.Count > 0 Then
    '        VALOR_PREVI += data_money_old(0).ATE_TOTAL_PREVI
    '        VALOR_BENEFI += data_money_old(0).ATE_V_BENEF
    '        'VALOR_SC += data_money_old(0).ATE_V_SC
    '        VALOR_PAGADO += data_money_old(0).ATE_TOTAL
    '        VALOR_CP += data_money_old(0).ATE_V_CP
    '        VALOR_CF += data_money_old(0).ATE_V_CF
    '    End If

    '    update_confirm = ddx.IRIS_WEBF_CMVM_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS_3_NEW_CAJA_MAS_SC_CHANGE_TP_PAGO(ID_ATENCION,                    'UPDATE ATENCIÓN
    '                                                                                                                    VALOR_PREVI,
    '                                                                                                                    VALOR_BENEFI,
    '                                                                                                                    ATE_V_SC_2,
    '                                                                                                                    VALOR_PAGADO,
    '                                                                                                                    VALOR_CF,
    '                                                                                                                    VALOR_CP)

    '    data_rel_copago_old = ddx4.IRIS_WEBF_BUSCA_REL_COPAGO_AGREGA_EXAMEN(ID_ATENCION)

    '    reset_copago = ddx2.IRIS_WEBF_CMVM_RESET_REL_COPAGO_BY_ID_ATENCION(ID_ATENCION)

    '    If (reset_copago <> 0) Then
    '        '--------------------------- DUAL COPAGO ---------------------------
    '        If (data_rel_copago_old.Count > 0) Then
    '            dual_copago = ddx.IRIS_WEBF_CMVM_GRABA_REL_COPAGO(ID_ATENCION,
    '                                              CInt(S_Id_User),
    '                                              Date.Now,
    '                                              ATE_TP_COPAGO_1,
    '                                              CInt(data_rel_copago_old(0).REL_MONTO_COPAGO_1) + ATE_VALOR_COPAGO_1,
    '                                              ATE_TP_COPAGO_2,
    '                                              CInt(data_rel_copago_old(0).REL_MONTO_COPAGO_2) + ATE_VALOR_COPAGO_2,
    '                                              ATE_V_CP_FP_2,
    '                                              ATE_V_CP_2,
    '                                              ATE_TP_PARTICULAR_1,
    '                                              CInt(data_rel_copago_old(0).REL_MONTO_PARTICULAR) + ATE_VALOR_PARTICULAR_1_2,
    '                                              ATE_TP_PARTICULAR_2,
    '                                              CInt(data_rel_copago_old(0).REL_MONTO_PARTICULAR_2) + ATE_VALOR_PARTICULAR_2_2)
    '        Else
    '            dual_copago = ddx.IRIS_WEBF_CMVM_GRABA_REL_COPAGO(ID_ATENCION,
    '                                              CInt(S_Id_User),
    '                                              Date.Now,
    '                                              ATE_TP_COPAGO_1,
    '                                              ATE_VALOR_COPAGO_1,
    '                                              ATE_TP_COPAGO_2,
    '                                              ATE_VALOR_COPAGO_2,
    '                                              ATE_V_CP_FP_2,
    '                                              ATE_V_CP_2,
    '                                              ATE_TP_PARTICULAR_1,
    '                                              ATE_VALOR_PARTICULAR_1_2,
    '                                              ATE_TP_PARTICULAR_2,
    '                                              ATE_VALOR_PARTICULAR_2_2)
    '        End If

    '    End If

    '    If (ids.Count = 0) Then
    '        Str_Out = Nothing
    '        Return Str_Out
    '    End If
    '    For i = 0 To ids.Count - 1

    '        Dim valor_copago_det As Integer
    '        If (ids(i).CF_TP_PAGO = 1 Or ids(i).CF_TP_PAGO = 20 Or ids(i).CF_TP_PAGO = 4) Then
    '            valor_copago_det = 0 'ids(i).Valor - ids(i).ATE_DET_VALOR_BENEF - ids(i).ATE_DET_VALOR_CS
    '        Else
    '            valor_copago_det = ids(i).Valor - ids(i).ATE_DET_VALOR_BENEF - ids(i).ATE_DET_VALOR_CS
    '        End If

    '        'update_confirm_det = jj.IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_CAJA_NEW_CHANGE_TP_PAGO_NEW(ID_ATENCION,
    '        '                                                                                                   CInt(S_Id_User),
    '        '                                                                                            ids(i).id_CF,
    '        '                                                                                            ids(i).ATE_DET_TP_1,
    '        '                                                                                            ids(i).Valor,
    '        '                                                                                            (ids(i).Valor - ids(i).ATE_DET_VALOR_BENEF - ids(i).ATE_DET_VALOR_CS),
    '        '                                                                                            valor_copago_det,
    '        '                                                                                            ids(i).ATE_DET_VALOR_BENEF,
    '        '                                                                                            ids(i).ATE_DET_VALOR_CS)

    '        id = jj.IRIS_WEBF_CMVM_GRABA_DETALLE_ATENCION_INTERFAZ_OMI_3_NEW_AGREGA_EXAM(ID_ATENCION,
    '                                                                   CInt(S_Id_User),
    '                                                                 ids(i).id_CF,
    '                                                                  ids(i).id_PER,
    '                                                                   ids(i).ATE_DET_TP_1,
    '                                                                   0,
    '                                                                 ids(i).Valor,
    '                                                                   (ids(i).Valor - ids(i).ATE_DET_VALOR_BENEF - ids(i).ATE_DET_VALOR_CS),
    '                                                                   valor_copago_det,
    '                                                                    ids(i).HO_CC,
    '                                                                "",'ids(i).CF_MULTIPLICADOS,
    '                                                                ids(i).CODIGO_TEST,
    '                                                                ids(i).ATE_DET_VALOR_BENEF,
    '                                                                ids(i).ATE_DET_VALOR_CS)

    '        PERFIL_PRUEBA = hh.IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION(ids(i).id_PER)

    '        For x = 0 To PERFIL_PRUEBA.Count - 1
    '            If (PERFIL_PRUEBA(x).PRU_RESU_INMEDIATO_REAL = Nothing) Then
    '                resu = resuresu.IRIS_WEBF_GRABA_RESULTADO_ATENCION(ID_ATENCION, ids(i).id_CF, ids(i).id_PER, PERFIL_PRUEBA(x).ID_PRUEBA, id)
    '            Else
    '                If (PERFIL_PRUEBA(x).ID_TP_RESULTADO = 1) Then
    '                    resu = resuresu.IRIS_WEBF_GRABA_RESULTADO_ATENCION_DEFECTO(ID_ATENCION, ids(i).id_CF, ids(i).id_PER, PERFIL_PRUEBA(x).ID_PRUEBA, PERFIL_PRUEBA(x).PRU_RESU_INMEDIATO_REAL, id)
    '                Else
    '                    resu = resuresu.IRIS_WEBF_GRABA_RESULTADO_ATENCION(ID_ATENCION, ids(i).id_CF, ids(i).id_PER, PERFIL_PRUEBA(x).ID_PRUEBA, id)
    '                End If
    '            End If
    '        Next x
    '    Next i

    '    Dim NN_ExamenDet As New N_Exa_Esp_V
    '    Dim DataExamenDet As Integer
    '    'Dim exa_avis As Integer

    '    For i = 0 To ids.Count - 1
    '        If (ids(i).CF_ESTADO_EXAMEN = "Espera") Then
    '            DataExamenDet = NN_ExamenDet.IRIS_WEBF_UPDATE_ESTADO_EXAMEN(ID_ATENCION, ids(i).id_CF)

    '            'If (IsNothing(numero_avis) = False Or numero_avis <> 0) Then
    '            '    exa_avis = NN_ExamenDet.IRIS_WEBF_UPDATE_ESTADO_EXAMEN_INTEGRACION_AVIS(numero_avis, Codigo_Fonasa_avis)
    '            'End If
    '        End If

    '    Next i

    '    'Dim numero As Integer
    '    Dim N_N As N_IRIS_OBTENER_INFO = New N_IRIS_OBTENER_INFO

    '    'For i = 0 To ids.Count - 1
    '    '    If ((ids(i).HO_CC = 0) And (IsNothing(ids(i).CODIGO_TEST) = True)) Then
    '    '        Continue For
    '    '    End If

    '    '    If (ids(i).CF_ESTADO_EXAMEN <> "Espera") Then
    '    '        numero = N_N.UPDATE_ESTADO_TEST(ids(i).HO_CC, ids(i).CODIGO_TEST)
    '    '    End If

    '    'Next i

    '    'For x = 0 To ids.Count - 1
    '    '    If ((ids(x).HO_CC = 0) And (IsNothing(ids(x).CODIGO_TEST) = True)) Then
    '    '        Continue For
    '    '    End If

    '    '    If (ids(x).CF_MULTIPLICADOS <> "" And ids(x).CF_ESTADO_EXAMEN <> "Espera") Then
    '    '        Dim regex As New Regex("[0-9]+", RegexOptions.ECMAScript And RegexOptions.IgnoreCase)
    '    '        Dim match9000 As MatchCollection
    '    '        Dim list_Num As New List(Of String)

    '    '        match9000 = regex.Matches(ids(x).CF_MULTIPLICADOS)
    '    '        For y = 0 To (match9000.Count - 1)
    '    '            If (match9000(y).Success = True) Then
    '    '                numero = N_N.UPDATE_ESTADO_TEST(match9000(y).Value, ids(x).CODIGO_TEST)
    '    '            End If
    '    '        Next y
    '    '    End If
    '    'Next x







    '    Str_Out += "{"
    '    Str_Out += Chr(34) & "ID_Atencion" & Chr(34) & ": " & Chr(34) & ID_ATENCION & Chr(34) & ", "
    '    Str_Out += Chr(34) & "Correlativo" & Chr(34) & ": " & Chr(34) & correlativo2 & Chr(34)
    '    Str_Out += "}"
    '    Return Str_Out


    'End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_tabla_exam(ByVal ID_PREVE As Integer, ByVal Fecha As String, ByVal CF As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        Dim NN As N_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA = New N_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA
        Dim ANO As Date
        ANO = CDate(Fecha)
        data_paciente = NN.IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA(ID_PREVE, Format(ANO, "yyyy"), CF)
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

End Class
Public Class ids5555_CC
    Dim E_id_CF As Integer
    Dim E_id_PER As Integer
    Dim E_Valor As Integer
    Dim E_HO_CC As String
    Dim E_CF_ESTADO_EXAMEN As String
    Dim E_CF_MULTIPLICADOS As String
    Dim E_CODIGO_TEST As String
    Dim E_Clinico As String
    Dim E_CF_TP_PAGO As String
    Dim E_ATE_DET_NUM_BONO As String            '6
    Dim E_ATE_DET_NUM_BOL As Integer            '5
    Dim E_ATE_DET_TP_OBS As String              '4
    Dim E_ATE_DET_TP_1 As Integer               '3
    Dim E_ATE_DET_VALOR_CS As Integer           '2
    Dim E_ATE_DET_VALOR_BENEF As Integer        '1
    Dim E_OBS_EXAM As String                    '7

    Public Property OBS_EXAM As String
        Get
            Return E_OBS_EXAM
        End Get
        Set(ByVal value As String)
            E_OBS_EXAM = value
        End Set
    End Property

    Public Property ATE_DET_VALOR_BENEF As Integer
        Get
            Return E_ATE_DET_VALOR_BENEF
        End Get
        Set(ByVal value As Integer)
            E_ATE_DET_VALOR_BENEF = value
        End Set
    End Property

    Public Property ATE_DET_VALOR_CS As Integer
        Get
            Return E_ATE_DET_VALOR_CS
        End Get
        Set(ByVal value As Integer)
            E_ATE_DET_VALOR_CS = value
        End Set
    End Property

    Public Property ATE_DET_TP_1 As Integer
        Get
            Return E_ATE_DET_TP_1
        End Get
        Set(ByVal value As Integer)
            E_ATE_DET_TP_1 = value
        End Set
    End Property

    Public Property ATE_DET_TP_OBS As String
        Get
            Return E_ATE_DET_TP_OBS
        End Get
        Set(ByVal value As String)
            E_ATE_DET_TP_OBS = value
        End Set
    End Property

    Public Property ATE_DET_NUM_BOL As Integer
        Get
            Return E_ATE_DET_NUM_BOL
        End Get
        Set(ByVal value As Integer)
            E_ATE_DET_NUM_BOL = value
        End Set
    End Property

    Public Property ATE_DET_NUM_BONO As String
        Get
            Return E_ATE_DET_NUM_BONO
        End Get
        Set(ByVal value As String)
            E_ATE_DET_NUM_BONO = value
        End Set
    End Property

    Public Property CF_TP_PAGO As String
        Get
            Return E_CF_TP_PAGO
        End Get
        Set(ByVal value As String)
            E_CF_TP_PAGO = value
        End Set
    End Property
    Dim E_CF_TP_PREVE As String
    Public Property CF_TP_PREVE As String
        Get
            Return E_CF_TP_PREVE
        End Get
        Set(ByVal value As String)
            E_CF_TP_PREVE = value
        End Set
    End Property
    Public Property CF_ESTADO_EXAMEN As String
        Get
            Return E_CF_ESTADO_EXAMEN
        End Get
        Set(ByVal value As String)
            E_CF_ESTADO_EXAMEN = value
        End Set
    End Property

    Public Property Clinico As String
        Get
            Return E_Clinico
        End Get
        Set(ByVal value As String)
            E_Clinico = value
        End Set
    End Property
    Public Property CODIGO_TEST As String
        Get
            Return E_CODIGO_TEST
        End Get
        Set(ByVal value As String)
            E_CODIGO_TEST = value
        End Set
    End Property
    Public Property CF_MULTIPLICADOS As String
        Get
            Return E_CF_MULTIPLICADOS
        End Get
        Set(ByVal value As String)
            E_CF_MULTIPLICADOS = value
        End Set
    End Property

    Public Property HO_CC As Integer
        Get
            Return E_HO_CC
        End Get
        Set(ByVal value As Integer)
            E_HO_CC = value
        End Set
    End Property
    Public Property Valor As Integer
        Get
            Return E_Valor
        End Get
        Set(ByVal value As Integer)
            E_Valor = value
        End Set
    End Property
    Public Property id_CF As Integer
        Get
            Return E_id_CF
        End Get
        Set(ByVal value As Integer)
            E_id_CF = value
        End Set
    End Property
    Public Property id_PER As Integer
        Get
            Return E_id_PER
        End Get
        Set(ByVal value As Integer)
            E_id_PER = value
        End Set
    End Property
End Class