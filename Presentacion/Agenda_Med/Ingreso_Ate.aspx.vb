Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Ingreso_Ate
    Inherits System.Web.UI.Page

    <Services.WebMethod()>
    Public Shared Function Llenar_DL_GENERO() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_GENERO)
        Dim NN As N_IRIS_WEBF_BUSCA_GENERO = New N_IRIS_WEBF_BUSCA_GENERO
        data_paciente = NN.IRIS_WEBF_BUSCA_GENERO()
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
    Public Shared Function BUSCA_PREI_EXAMED(ByVal PREI_NUM As String) As List(Of E_EXAMED_BUSCAR_PREI_IRISLAB_BLUELAB)
        'Declaraciones internas
        Dim data_paciente As List(Of E_EXAMED_BUSCAR_PREI_IRISLAB_BLUELAB)
        Dim NN As N_EXAMED_BUSCAR_PREI_IRISLAB_BLUELAB = New N_EXAMED_BUSCAR_PREI_IRISLAB_BLUELAB
        data_paciente = NN.EXAMED_BUSCAR_PREI_IRISLAB_BLUELAB(PREI_NUM)

        Return data_paciente
    End Function

    <Services.WebMethod()>
    Public Shared Function Request_Prevision(ByVal ID_PROC As Integer) As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Dim NN As N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO = New N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        data_paciente = NN.IRIS_WEBF_BUSCA_PREVISION_PROCEDENCIA_ACTIVO(ID_PROC)

        Return data_paciente
    End Function

    <Services.WebMethod()>
    Public Shared Function Request_Programa(ByVal ID_PREV As Integer) As List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO)
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO)
        Dim NN As New N_Gen_Activos
        data_paciente = NN.IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO(ID_PREV)

        Return data_paciente
    End Function

    <Services.WebMethod()>
    Public Shared Function Request_SubPrograma(ByVal ID_PREV As Integer, ByVal ID_PROG As Integer) As List(Of E_Async_SubP)
        Dim NN_Activo As New N_Gen_Activos

        Return NN_Activo.Request_SubPrograma(ID_PREV, ID_PROG)
    End Function

    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If
    End Sub
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST(ByVal HOST As String) As List(Of E_IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST)
        Dim NN As N_IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST = New N_IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST
        data_paciente = NN.IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST(HOST)

        Return data_paciente
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST2(ByVal HOST As String) As List(Of E_IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST)
        Dim NN As N_IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST = New N_IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST
        data_paciente = NN.IRIS_WEBF_BUSCA_DIAGNOSTICO_POR_HOST(HOST)
        Return data_paciente
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_tabla_exam2_global() As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION)
        Dim NN As N_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION = New N_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION

        data_paciente = NN.IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION_22()

        'Return datas
        Return data_paciente
    End Function




    <Services.WebMethod()>
    Public Shared Function Llenar_tabla_exam2(ByVal ID_PREVE As Integer, ByVal Fecha As String) As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION)
        Dim NN As N_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION = New N_IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION
        Dim ANO As Date
        ANO = CDate(Fecha)

        If ID_PREVE = 254 Then
            data_paciente = NN.IRIS_WEBF_CMVM_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION_SAN_JOAQUIN(Format(ANO, "yyyy"), ID_PREVE)
        Else
            data_paciente = NN.IRIS_WEBF_BUSCA_CODIGO_FONASA_PARA_CARGA_ATENCION(Format(ANO, "yyyy"), ID_PREVE)
        End If


        Return data_paciente
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_tabla_exam(ByVal ID_PREVE As Integer, ByVal Fecha As String, ByVal CF As String) As List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
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

        Return data_paciente
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_Tabla_Pack(ByVal ID_PREVE As Integer, ByVal Fecha As String, ByVal CF As String) As List(Of E_IRIS_WEBF_BUSCA_PACK_CF)
        Dim NN_CF As New N_IRIS_WEBF_BUSCA_PACK
        Dim Data_CF As New List(Of E_IRIS_WEBF_BUSCA_PACK_CF)
        Data_CF = NN_CF.IRIS_WEBF_BUSCA_PACK()
        If (Data_CF.Count > 0) Then
            Return Data_CF
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_tabla_exam_pack(ByVal ID_PREVE As Integer, ByVal Fecha As String, ByVal CF As String) As List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        Dim NN_CF As New N_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA
        Dim Data_CF As New List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        Data_CF = NN_CF.IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA_PACK(ID_PREVE, Fecha, CF)
        If (Data_CF.Count > 0) Then
            Return Data_CF
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl_LugarTM() As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones internas
        Dim NN_LugarTM As New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        Dim Data_LugarTM As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Data_LugarTM = NN_LugarTM.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()

        Return Data_LugarTM
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_rut(ByVal rut As String) As List(Of E_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT)
        Dim NN As N_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT = New N_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT
        data_paciente = NN.IRIS_WEBF_BUSCA_PACIENTE_POR_RUT(rut)

        Return data_paciente
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
        data_pac = NN_pac.IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES_2_POR_RUT_NEW(ID)
        If data_pac.Count > 0 Then
            data_examen = NN_Examen.IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL_3_POR_RUT_NEW(data_pac(0).ID_PREINGRESO)
            data_atencion = NN_atencion.IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION_2_POR_RUT_NEW(data_pac(0).ID_PREINGRESO)
        End If

        Dim reeeeeee As New REEE
        reeeeeee.proparra1 = data_pac
        reeeeeee.proparra2 = data_examen
        reeeeeee.proparra3 = data_atencion

        'Declaraciones internas
        Return reeeeeee
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DNI(ByVal dni As String) As List(Of E_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT)
        Dim NN As N_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT = New N_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT
        data_paciente = NN.IRIS_WEBF_BUSCA_PACIENTE_POR_dni(dni)

        Return data_paciente
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
        data_pac = NN_pac.IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES_2_POR_DNI_NEW_2(ID)
        If data_pac.Count > 0 Then
            data_examen = NN_Examen.IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL_3_POR_RUT_NEW(data_pac(0).ID_PREINGRESO)
            data_atencion = NN_atencion.IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION_2_POR_RUT_NEW(data_pac(0).ID_PREINGRESO)
        End If
        Dim reeeeeee As New REEE
        reeeeeee.proparra1 = data_pac
        reeeeeee.proparra2 = data_examen
        reeeeeee.proparra3 = data_atencion

        'Declaraciones internas
        Return reeeeeee
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DL_SEXO() As List(Of E_IRIS_WEBF_BUSCA_SEXO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_SEXO)
        Dim NN As N_IRIS_WEBF_BUSCA_SEXO = New N_IRIS_WEBF_BUSCA_SEXO
        data_paciente = NN.IRIS_WEBF_BUSCA_SEXO()

        Return data_paciente
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DL_NAC() As List(Of E_IRIS_WEBF_BUSCA_NACIONALIDAD)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_NACIONALIDAD)
        Dim NN As N_IRIS_WEBF_BUSCA_NACIONALIDAD = New N_IRIS_WEBF_BUSCA_NACIONALIDAD
        data_paciente = NN.IRIS_WEBF_BUSCA_NACIONALIDAD()

        Return data_paciente
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DL_Ciudad() As List(Of E_IRIS_WEBF_BUSCA_CIUDAD)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_CIUDAD)
        Dim NN As N_IRIS_WEBF_BUSCA_CIUDAD = New N_IRIS_WEBF_BUSCA_CIUDAD
        data_paciente = NN.IRIS_WEBF_BUSCA_CIUDAD()

        Return data_paciente
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_CIUDAD() As List(Of E_IRIS_WEBF_BUSCA_CIUDAD)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_CIUDAD)
        Dim NN As N_IRIS_WEBF_BUSCA_CIUDAD = New N_IRIS_WEBF_BUSCA_CIUDAD
        data_paciente = NN.IRIS_WEBF_BUSCA_CIUDAD()

        Return data_paciente
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA(ByVal ID_CIU As Integer) As List(Of E_IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA)
        Dim NN As N_IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA = New N_IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA
        data_paciente = NN.IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA(ID_CIU)

        Return data_paciente
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_DL_prevision() As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Dim NN As N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO = New N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        data_paciente = NN.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()

        Return data_paciente
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DL_aTENCIONES() As List(Of E_IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO)
        Dim NN As N_IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO = New N_IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO
        data_paciente = NN.IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO()

        Return data_paciente
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DL_Sectores() As List(Of E_IRIS_WEBF_BUSCA_SECTORES_ACTIVOS_TODOS)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_SECTORES_ACTIVOS_TODOS)
        Dim NN As N_IRIS_WEBF_BUSCA_SECTORES_ACTIVOS_TODOS = New N_IRIS_WEBF_BUSCA_SECTORES_ACTIVOS_TODOS
        data_paciente = NN.IRIS_WEBF_BUSCA_SECTORES_ACTIVOS_TODOS()

        Return data_paciente
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DL_Empresa() As List(Of E_IRIS_WEBF_BUSCA_EMPRESA_ACTIVOS_TODOS)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_EMPRESA_ACTIVOS_TODOS)
        Dim NN As N_IRIS_WEBF_BUSCA_SECTORES_ACTIVOS_TODOS = New N_IRIS_WEBF_BUSCA_SECTORES_ACTIVOS_TODOS
        data_paciente = NN.IRIS_WEBF_BUSCA_EMPRESA_ACTIVOS_TODOS()

        Return data_paciente
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DL_Programa() As List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)
        Dim NN As N_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO = New N_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO
        data_paciente = NN.IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO()

        Return data_paciente
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DL_DOC() As List(Of E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO)
        Dim NN As N_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO = New N_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO
        data_paciente = NN.IRIS_WEBF_BUSCA_MEDICOS_ACTIVO()

        Return data_paciente
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DL_ordenATE() As List(Of E_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO)
        Dim NN As N_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO = New N_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO
        data_paciente = NN.IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO()

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
        data_pac = NN_pac.IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES_2_NEW(ID)
        data_examen = NN_Examen.IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL_2_NEW(ID)
        data_atencion = NN_atencion.IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION_2_NEW(ID)
        Dim reeeeeee As New REEE
        reeeeeee.proparra1 = data_pac
        reeeeeee.proparra2 = data_examen
        reeeeeee.proparra3 = data_atencion
        'Declaraciones internas
        Return reeeeeee
    End Function
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
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_DIAGNOSTICO() As List(Of E_IRIS_WEBF_BUSCA_DIAGNOSTICO)
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_DIAGNOSTICO)
        Dim NN As N_IRIS_WEBF_BUSCA_DIAGNOSTICO = New N_IRIS_WEBF_BUSCA_DIAGNOSTICO
        data_paciente = NN.IRIS_WEBF_BUSCA_DIAGNOSTICO()

        Return data_paciente
    End Function
    <Services.WebMethod()>
    Public Shared Function Guardar_TodoByVal(ByVal RUT_PAC As String,
                                             ByVal NOMBRE_PAC As String,
                                             ByVal APE_PAC As String,
                                             ByVal FNAC_PAC As String,
                                             ByVal ID_SEXO As Integer,
                                             ByVal ID_GENERO As Integer,
                                             ByVal ID_NACIONALIDAD As Integer,
                                             ByVal FONO1 As String,
                                             ByVal MOVIL1 As String,
                                             ByVal ID_CIU_COM As Integer,
                                             ByVal DIR_PAC As String,
                                             ByVal EMAIL_PAC As String,
                                             ByVal FUR As String,
                                             ByVal Paridad As String,
                                             ByVal ID_PAC As String,
                                             ByVal OB As String,
                                             ByVal Procedencia As Integer,
                                             ByVal Programa As Integer,
                                             ByVal Sector As Integer,
                                             ByVal TipoAtencion As Integer,
                                             ByVal PrioridadTM As Integer,
                                             ByVal Doctor As Integer,
                                             ByVal Prevision As Integer,
                                             ByVal EDAD As Integer,
                                             ByVal MES As Integer,
                                             ByVal DIA As Integer,
                                             ByVal TOTAL As Integer,
                                             ByVal FECHA_PRE As String,
                                             ByVal ids As List(Of ids2),
                                             ByVal ate_obs As String,
                                             ByVal Interno As String,
                                             ByVal id_Diag As String,
                                             ByVal id_Diag2 As String,
                                             ByVal sub_atencion As String,
                                             ByVal vih As String,
                                             ByVal dni As String,
                                             ByVal SUB_PROGRAMA As String,
                                             ByVal S_Id_User As Integer,
                                             ByVal EPIVIGILA As String,
                                             ByVal BUSQUEDA_ACTIVA As Integer,
                                             ByVal EXAMED As String,
                                             ID_ETNIA As Integer,
                                             PAC_NOM_SOCIAL As String,
                                             nombreCodificadoParaSepararVIH As String,
                                             ByVal EMPRESA As Integer,
                                             ByVal GLUCOSA() As Object, ByVal ID_GRUPO_PESQUISA As Integer, ByVal IS_NEO As Integer) As Object
        'Checar Galletas
        If (Test_C.emptyCookies = True) Then
            HttpContext.Current.Response.Redirect("~index.aspx", False)
            Return Nothing
        End If

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        Dim correlativo As Integer

        'paciente
        Dim Rpaciente As Integer
        Dim examun As Integer
        Dim Str_Out As String = ""
        Dim DATASSSSSS As Integer
        ' Dim PREINGRESO2 As Integer
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Dim S_Id_User As String = CType(objSession("ID_USER"), String)
        Dim PREINGRESO2_PRO_SEC As Integer = 0
        Dim nn As N_IRIS_WEBF_GRABA_PACIENTE_ATENCION = New N_IRIS_WEBF_GRABA_PACIENTE_ATENCION
        Dim vv As N_IRIS_WEBF_UPDATE_PACIENTE_ATENCION = New N_IRIS_WEBF_UPDATE_PACIENTE_ATENCION
        Dim dd As N_IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO = New N_IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO
        Dim zz As N_IRIS_WEBF_GRABA_PREINGRESO2 = New N_IRIS_WEBF_GRABA_PREINGRESO2
        Dim cc As N_IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC = New N_IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC
        Dim exex As N_IRIS_WEBF_GRABA_DETALLE_PREINGRESO = New N_IRIS_WEBF_GRABA_DETALLE_PREINGRESO
        Dim clinico_chikito As String = ""

        If (ids(0).Clinico = "" Or ids(0).Clinico = "0") Then
            For b = 0 To ids.Count - 1
                If (IsNumeric(ids(b).Clinico) = True) Then
                    clinico_chikito = ids(b).Clinico
                Else
                    clinico_chikito = ""
                End If
            Next b
        Else
            clinico_chikito = ids(0).Clinico
        End If


        'fecha fur
        If (FUR = "") Then
            FUR = "01/01/1900"
        End If
        If (ids.Count = 0) Then
            Str_Out = Nothing
            Return Str_Out
        Else

            'HACIENDO LO DEL VIH BASADO EN LOBARNECHEA

            Dim examenesVIHIngresados = New List(Of ids2)
            Dim existeVIH = ids.Any(Function(item) item.CF_VIH)

            If existeVIH Then
                examenesVIHIngresados = ids.Where(Function(item) item.CF_VIH).ToList()
                ids = ids.Where(Function(item) Not item.CF_VIH).ToList()
            End If

            ' Buscar correlativo
            correlativo = dd.IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO()

            'If (RUT_PAC = "") Then
            '    Rpaciente = (New N_IRIS_WEBF_GRABA_PACIENTE_ATENCION).IRIS_WEBF_GRABA_PACIENTE_ATENCION(
            '        RUT_PAC, NOMBRE_PAC, APE_PAC, CDate(FNAC_PAC), ID_SEXO, ID_NACIONALIDAD, FONO1, MOVIL1, ID_CIU_COM, DIR_PAC, EMAIL_PAC, 1, OB, 1, dni, ID_ETNIA, PAC_NOM_SOCIAL)
            'Else
            '    Dim data_paciente = (New N_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT).IRIS_WEBF_BUSCA_PACIENTE_POR_RUT(RUT_PAC)
            '    If (data_paciente.Count = 0) Then
            '        Rpaciente = (New N_IRIS_WEBF_GRABA_PACIENTE_ATENCION).IRIS_WEBF_GRABA_PACIENTE_ATENCION(
            '            RUT_PAC, NOMBRE_PAC, APE_PAC, CDate(FNAC_PAC), ID_SEXO, ID_NACIONALIDAD, FONO1, MOVIL1, ID_CIU_COM, DIR_PAC, EMAIL_PAC, 1, OB, 1, dni, ID_ETNIA, PAC_NOM_SOCIAL)
            '    Else
            '        Rpaciente = (New N_IRIS_WEBF_UPDATE_PACIENTE_ATENCION).IRIS_WEBF_UPDATE_PACIENTE_ATENCION(
            '            ID_PAC, RUT_PAC, NOMBRE_PAC, APE_PAC, CDate(FNAC_PAC), ID_SEXO, ID_NACIONALIDAD, FONO1, MOVIL1, ID_CIU_COM, DIR_PAC, EMAIL_PAC, 1, OB, 1, ID_ETNIA, PAC_NOM_SOCIAL)
            '    End If
            'End If

            'HASTA AQUI
            'regitrar paciente o actualizar
            If (Paridad = 2) Then
                Rpaciente = nn.IRIS_WEBF_GRABA_PACIENTE_ATENCION_GENERO(RUT_PAC, NOMBRE_PAC, APE_PAC, CDate(FNAC_PAC), ID_SEXO, ID_GENERO, ID_NACIONALIDAD, FONO1, MOVIL1, ID_CIU_COM, DIR_PAC, EMAIL_PAC, 1, OB, 1, dni, ID_ETNIA, PAC_NOM_SOCIAL, IS_NEO)
            Else
                Rpaciente = vv.IRIS_WEBF_UPDATE_PACIENTE_ATENCION_GENERO(ID_PAC, RUT_PAC, NOMBRE_PAC, APE_PAC, CDate(FNAC_PAC), ID_SEXO, ID_GENERO, ID_NACIONALIDAD, FONO1, MOVIL1, ID_CIU_COM, DIR_PAC, EMAIL_PAC, 1, OB, 1, ID_ETNIA, PAC_NOM_SOCIAL, IS_NEO)
            End If

            Dim idsPreingresos As New List(Of Integer)

            If ids.Count > 0 Then

                'ir a buscar correlativo
                'correlativo = dd.IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO()

                'PREINGRESO2_PRO_SEC = cc.IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC_NEW(correlativo, Rpaciente, CInt(S_Id_User), FUR, Procedencia, PrioridadTM, TipoAtencion, Doctor, Prevision, 1, 1, ate_obs.ToUpper, 0, EDAD, MES, DIA, TOTAL, 0, 0, FECHA_PRE, Programa, Sector, id_Diag, id_Diag2, sub_atencion, vih, dni)
                PREINGRESO2_PRO_SEC = cc.IRIS_WEBF_GRABA_PREINGRESO3_PRO_SEC_AVIS_NEW(correlativo,
                                                                  Rpaciente,
                                                                  CInt(S_Id_User),
                                                                  FUR,
                                                                  Procedencia,
                                                                  PrioridadTM,
                                                                  TipoAtencion,
                                                                  Doctor,
                                                                  Prevision,
                                                                  1,
                                                                  1,
                                                                  (""),
                                                                  0,
                                                                  EDAD,
                                                                  MES,
                                                                  DIA,
                                                                  TOTAL,
                                                                  0,
                                                                  0,
                                                                  FECHA_PRE,
                                                                  Programa,
                                                                  Sector, ids(0).Clinico, 0, 0, sub_atencion, vih, SUB_PROGRAMA, EMPRESA, ID_GRUPO_PESQUISA
                                                                 )
                idsPreingresos.Add(PREINGRESO2_PRO_SEC)

                For i = 0 To ids.Count - 1
                    examun = exex.IRIS_WEBF_GRABA_DETALLE_PREINGRESO(PREINGRESO2_PRO_SEC, CInt(S_Id_User), ids(i).id_CF, ids(i).id_PER, 1, 0, ids(i).Valor, ids(i).Valor, 0, ids(i).Clinico)
                Next i

            End If

            Dim data_examen2 As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL)
            Dim NN_Examen2 As New N_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL

            Dim NN_Date As New N_Date
            Dim fecha As String = FECHA_PRE.Replace("/", "-")
            Dim DIA1 As String = fecha.Split("-")(0)
            Dim MES2 As String = fecha.Split("-")(1)
            Dim AÑO3 As String = fecha.Split("-")(2)
            Dim Date_01 As Date = NN_Date.strToDate(AÑO3, MES2, DIA1)
            Dim Date_02 As Date = NN_Date.strToDate(AÑO3, MES2, DIA1)


            data_examen2 = NN_Examen2.IRIS_WEBF_BUSCA_EXAMEN(Date_02, Date_01, RUT_PAC)

            Dim idPreingresoVIH = 0
            Dim correlativoVIH = 0
            If examenesVIHIngresados.Count > 0 Then
                Dim idPacienteVIH = (New N_IRIS_WEBF_GRABA_PACIENTE_ATENCION).IRIS_WEBF_GRABA_PACIENTE_VIH_ATE(RUT_PAC, nombreCodificadoParaSepararVIH, "", CDate(FNAC_PAC), ID_SEXO, ID_NACIONALIDAD, FONO1, MOVIL1, ID_CIU_COM, DIR_PAC, EMAIL_PAC, 1, "", 1, "", ID_ETNIA, PAC_NOM_SOCIAL)
                correlativoVIH = (New N_IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO).IRIS_WEBF_BUSCA_CORRELATIVO_PREINGRESO()
                idPreingresoVIH = (New N_IRIS_WEBF_GRABA_PREINGRESO2_PRO_SEC).IRIS_WEBF_GRABA_PREINGRESO3_PRO_SEC_AVIS_NEW(
                                                       correlativoVIH, idPacienteVIH, CInt(S_Id_User), FUR, Procedencia, PrioridadTM,
                                                       TipoAtencion, Doctor, Prevision, 1, 1, (""),
                                                       0, EDAD, MES, DIA, TOTAL, 0, 0, FECHA_PRE, Programa, Sector, examenesVIHIngresados(0).Clinico,
                                                       0, 0, sub_atencion, vih, SUB_PROGRAMA, EMPRESA, ID_GRUPO_PESQUISA)
                For Each examen In examenesVIHIngresados
                    Dim idDetalleAtencionVIH = (New N_IRIS_WEBF_GRABA_DETALLE_PREINGRESO).
                    IRIS_WEBF_GRABA_DETALLE_PREINGRESO(idPreingresoVIH, CInt(S_Id_User), examen.id_CF,
                                                       examen.id_PER, 1, 0, examen.Valor, examen.Valor, 0, examen.Clinico)
                Next

                idsPreingresos.Add(idPreingresoVIH)
            End If


            Dim correlativos As New List(Of Correlativo)

            'otra parte del vih codificado
            For Each idPreingreso In idsPreingresos

                Dim data_pac As List(Of E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2)
                Dim NN_pac As New N_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2
                Dim data_examen As List(Of E_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL)
                Dim NN_Examen As New N_IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL
                Dim data_atencion As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION)
                Dim NN_atencion As New N_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION
                Dim correlativo2 As Integer
                Dim id_atencion As Integer
                Dim ddx As New N_IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS
                Dim ccx As New N_IRIS_WEBF_BUSCA_CORRELATIVO_ATENCION
                Dim id As Integer
                Dim jj As New N_IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_AVIS
                Dim resu As Integer
                Dim resuresu As New N_IRIS_WEBF_GRABA_RESULTADO_ATENCION
                Dim PERFIL_PRUEBA As List(Of E_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION)
                Dim hh As New N_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
                data_pac = NN_pac.IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2(idPreingreso)
                data_examen = NN_Examen.IRIS_WEBF_AGENDA_BUSCA_AGREGA_QUITA_EXAMEN_ACTUAL(idPreingreso)
                data_atencion = NN_atencion.IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION(idPreingreso)
                correlativo2 = ccx.IRIS_WEBF_BUSCA_CORRELATIVO_ATENCION()
                id_atencion = ddx.IRIS_WEBF_GRABA_ATENCION_PROGRA2_PRO_SECTOR_AVIS(correlativo2,
                                                                          data_pac(0).ID_PACIENTE,
                                                                          CInt(S_Id_User),
                                                                          data_pac(0).PREI_FUR,
                                                                          data_atencion(0).ID_PROCEDENCIA,
                                                                          data_atencion(0).ID_ORDEN,
                                                                          data_atencion(0).ID_TP_PACI,
                                                                          data_atencion(0).ID_DOCTOR,
                                                                          data_atencion(0).ID_PREVE,
                                                                          data_atencion(0).ID_LOCAL,
                                                                          1,
                                                                          data_atencion(0).PREI_OBS_FICHA,
                                                                          data_atencion(0).PREI_CAMA,
                                                                          data_pac(0).PREI_AÑO,
                                                                          data_pac(0).PREI_MES,
                                                                          data_pac(0).PREI_DIA,
                                                                          data_examen(0).PREI_DET_V_PAGADO,
                                                                          data_examen(0).PREI_DET_V_PREVI,
                                                                          data_examen(0).PREI_DET_V_COPAGO,
                                                                          data_atencion(0).ID_PROGRAMA,
                                                                          "",
                                                                          data_atencion(0).ID_SECTOR,
                                                                          clinico_chikito,'ids(0).Clinico,
                                                                          Interno,
                                                                          data_atencion(0).ID_DIAGNOSTICO,
                                                                          data_atencion(0).ID_DIAGNOSTICO2,
                                                                          data_atencion(0).VIH,
                                                                          data_pac(0).DNI,
                                                                          ate_obs, SUB_PROGRAMA,
                                                                          EPIVIGILA,
                                                                          BUSQUEDA_ACTIVA,
                                                                          EXAMED,
                                                                          EMPRESA,
                                                                          ID_GRUPO_PESQUISA)

                For i = 0 To data_examen.Count - 1
                    id = jj.IRIS_WEBF_GRABA_DETALLE_ATENCION_INTERFAZ_AVIS(id_atencion,
                                                                   CInt(S_Id_User),
                                                                   data_examen(i).ID_CODIGO_FONASA,
                                                                   data_examen(i).ID_PER,
                                                                   data_examen(i).ID_TP_PAGO,
                                                                   data_examen(i).PREI_DET_DOC,
                                                                   data_examen(i).PREI_DET_V_PREVI,
                                                                   data_examen(i).PREI_DET_V_PAGADO,
                                                                   data_examen(i).PREI_DET_V_COPAGO,
                                                                   data_examen(i).ATE_NUM_AVIS,
                                                                   data_examen(i).SITIO_ANATO)





                    PERFIL_PRUEBA = hh.IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION(data_examen(i).ID_PER)
                    'And data_examen(i).ID_PER <> 217 
                    If data_examen(i).ID_PER <> 1319 Then
                        For x = 0 To PERFIL_PRUEBA.Count - 1
                            Dim result = ids.FirstOrDefault(Function(item) data_examen(i).ID_CODIGO_FONASA = item.id_CF)
                            If (PERFIL_PRUEBA(x).PRU_RESU_INMEDIATO_REAL = Nothing) Then
                                resu = resuresu.IRIS_WEBF_GRABA_RESULTADO_ATENCION_ANATO(id_atencion, If(PERFIL_PRUEBA(x).IS_ANATO, result.SITIO_ANATO, Nothing), data_examen(i).ID_CODIGO_FONASA, data_examen(i).ID_PER, PERFIL_PRUEBA(x).ID_PRUEBA, id)
                            Else
                                If (PERFIL_PRUEBA(x).ID_TP_RESULTADO = 1) Then
                                    resu = resuresu.IRIS_WEBF_GRABA_RESULTADO_ATENCION_DEFECTO(id_atencion, data_examen(i).ID_CODIGO_FONASA, data_examen(i).ID_PER, PERFIL_PRUEBA(x).ID_PRUEBA, PERFIL_PRUEBA(x).PRU_RESU_INMEDIATO_REAL, id)
                                Else
                                    resu = resuresu.IRIS_WEBF_GRABA_RESULTADO_ATENCION(id_atencion, data_examen(i).ID_CODIGO_FONASA, data_examen(i).ID_PER, PERFIL_PRUEBA(x).ID_PRUEBA, id)
                                End If
                            End If
                        Next x
                    End If

                    '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
                    If data_examen(i).ID_PER = 1319 Then
                        Dim list_glucosa As List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
                        Dim NN_glu As N_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA = New N_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA

                        list_glucosa = NN_glu.IRIS_WEBF_CMVM_BUSCA_DETERMINACIONES_GLUCOSA(data_examen(i).ID_PER)

                        If GLUCOSA.Length > 0 And list_glucosa.Count > 0 Then
                            For pr = 0 To GLUCOSA.Length - 1
                                For pr2 = 0 To list_glucosa.Count - 1
                                    If GLUCOSA(pr) = list_glucosa(pr2).ID_PRUEBA Then
                                        If (list_glucosa(pr2).PRU_RESU_INMEDIATO_REAL = Nothing) Then
                                            resu = resuresu.IRIS_WEBF_GRABA_RESULTADO_ATENCION(id_atencion, data_examen(i).ID_CODIGO_FONASA, data_examen(i).ID_PER, list_glucosa(pr2).ID_PRUEBA, id)
                                        Else
                                            If (list_glucosa(pr2).ID_TP_RESULTADO = 1) Then
                                                resu = resuresu.IRIS_WEBF_GRABA_RESULTADO_ATENCION_DEFECTO(id_atencion, data_examen(i).ID_CODIGO_FONASA, data_examen(i).ID_PER, list_glucosa(pr2).ID_PRUEBA, list_glucosa(pr2).PRU_RESU_INMEDIATO_REAL, id)
                                            Else
                                                resu = resuresu.IRIS_WEBF_GRABA_RESULTADO_ATENCION(id_atencion, data_examen(i).ID_CODIGO_FONASA, data_examen(i).ID_PER, list_glucosa(pr2).ID_PRUEBA, id)
                                            End If
                                        End If
                                    End If
                                Next pr2
                            Next pr
                        End If
                    End If
                    '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


                Next i
                '----------------- Auto PAGO Datos ---------------------------
                Dim qq As New N_IRIS_WEBF_UPDATE_ATE_AGREGA_ID_ATE_DOCP
                Dim update1 As Integer
                '----------------------------------------------------------
                Dim ww As New N_IRIS_WEBF_UPDATE_ATE_DETALLE_AGREGA_ID_ATE_DOCP
                Dim update2 As Integer
                '-----------------------------------------------------------
                Dim ee As New N_IRIS_WEBF_BUSCA_ATE_FORMA_PAGO_SUMA_TOTALES
                Dim buscarFormaPAgo As List(Of E_IRIS_WEBF_BUSCA_ATE_FORMA_PAGO_SUMA_TOTALES)
                '-----------------------------------------------------------------
                Dim rr As New N_IRIS_WEBF_BUSCA_ATE_DOCUMENTOS_DE_PAGO_POR_ID_ATENCION
                'Dim buscarAteDOC As List(Of E_IRIS_WEBF_BUSCA_ATE_DOCUMENTOS_DE_PAGO_POR_ID_ATENCION)
                '---------------------------------------------------------------------------------
                Dim correlativo_tp_pago As Integer
                Dim bb As New N_IRIS_WEBF_BUSCA_CORRELATIVO_DOCUMENTO_FORMA_PAGO
                Dim qwerty As Integer
                Dim xcv As New N_IRIS_WEBF_GRABA_TRX_BONOS
                Dim qwe As Integer
                Dim uuuu As New N_IRIS_WEBF_GRABA_ATE_DET_DOCUMENTO_PAGO_SIN_TRX
                correlativo_tp_pago = bb.IRIS_WEBF_BUSCA_CORRELATIVO_DOCUMENTO_FORMA_PAGO()
                update1 = qq.IRIS_WEBF_UPDATE_ATE_AGREGA_ID_ATE_DOCP(id_atencion, correlativo_tp_pago, 1)
                update2 = ww.IRIS_WEBF_UPDATE_ATE_DETALLE_AGREGA_ID_ATE_DOCP(id_atencion, correlativo_tp_pago)

                Dim graba_ate As Integer
                Dim tt As New N_IRIS_GRABA_ATE_DOCUMENTO_PAGO
                graba_ate = tt.IRIS_GRABA_ATE_DOCUMENTO_PAGO(id_atencion, correlativo_tp_pago, CInt(S_Id_User))
                buscarFormaPAgo = ee.IRIS_WEBF_BUSCA_ATE_FORMA_PAGO_SUMA_TOTALES(id_atencion)
                If (buscarFormaPAgo.Count > 0) Then
                    If (buscarFormaPAgo(0).ID_TP_PAGO = 4 Or buscarFormaPAgo(0).ID_TP_PAGO = 5) Then
                        qwerty = xcv.IRIS_WEBF_GRABA_TRX_BONOS(buscarFormaPAgo(0).ID_TP_PAGO, buscarFormaPAgo(0).T_PAGADO, CInt(S_Id_User))
                    ElseIf (buscarFormaPAgo(0).ID_TP_PAGO = 1 Or buscarFormaPAgo(0).ID_TP_PAGO = 3 Or buscarFormaPAgo(0).ID_TP_PAGO = 7 Or buscarFormaPAgo(0).ID_TP_PAGO = 11) Then
                        qwerty = xcv.IRIS_WEBF_GRABA_TRX_EFECTIVO(buscarFormaPAgo(0).ID_TP_PAGO, buscarFormaPAgo(0).T_PAGADO, CInt(S_Id_User))
                    End If
                End If
                If (qwerty = 0) Then
                    qwe = uuuu.IRIS_WEBF_GRABA_ATE_DET_DOCUMENTO_PAGO_SIN_TRX(correlativo_tp_pago, buscarFormaPAgo(0).ID_TP_PAGO, buscarFormaPAgo(0).T_PAGADO, CInt(S_Id_User), 0)
                Else
                    qwe = uuuu.IRIS_WEBF_GRABA_ATE_DET_DOCUMENTO_PAGO_TRX(correlativo_tp_pago, buscarFormaPAgo(0).ID_TP_PAGO, buscarFormaPAgo(0).T_PAGADO, qwerty, CInt(S_Id_User), 0)
                End If
                Dim ahg As Integer
                Dim uu As New N_IRIS_WEBF_AGENDA_UPDATE_ESTADO_PREINGRESO

                'update despues de pago
                ahg = uu.IRIS_WEBF_AGENDA_UPDATE_ESTADO_PREINGRESO(PREINGRESO2_PRO_SEC, id_atencion)
                DATASSSSSS = NN_pac.IRIS_WEBF_UPDATE_OBS_INTERNO_PRE_INGRESO(PREINGRESO2_PRO_SEC, Interno, OB, data_atencion(0).PREI_OBS_FICHA)

                Dim NN_ExamenDet As New N_Exa_Esp_V
                Dim DataExamenDet As Integer
                'Dim exa_avis As Integer

                For i = 0 To ids.Count - 1
                    If (ids(i).CF_ESTADO_EXAMEN = "Espera") Then
                        DataExamenDet = NN_ExamenDet.IRIS_WEBF_UPDATE_ESTADO_EXAMEN(id_atencion, ids(i).id_CF)

                        'If (IsNothing(numero_avis) = False Or numero_avis <> 0) Then
                        '    exa_avis = NN_ExamenDet.IRIS_WEBF_UPDATE_ESTADO_EXAMEN_INTEGRACION_AVIS(numero_avis, Codigo_Fonasa_avis)
                        'End If
                    End If
                Next i

                correlativos.Add(New Correlativo With {.CORRELAT = correlativo2, .ID_ATE = id_atencion})
                Str_Out += "{"
                Str_Out += Chr(34) & "ID_Atencion" & Chr(34) & ": " & Chr(34) & id_atencion & Chr(34) & ", "
                Str_Out += Chr(34) & "Correlativo" & Chr(34) & ": " & Chr(34) & correlativo2 & Chr(34)
                Str_Out += "}"
                'Return Str_Out
            Next



            Dim respuesta = New With {
            .Correlativo = correlativos(0).CORRELAT,
            .ID_Atencion = correlativos(0).ID_ATE,
            .CORELATIVO_VIH = 0,
            .ID_Atencion_VIH = 0
            }
            If correlativos.Count > 1 Then
                respuesta.CORELATIVO_VIH = correlativos(1).CORRELAT
                respuesta.ID_Atencion_VIH = correlativos(1).ID_ATE
            End If

            'Return datas
            Return respuesta
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Data_Sel_Ciudad() As List(Of E_Select)
        Dim NNN As New N_Gen_Activos
        Dim List_Data As New List(Of E_IRIS_WEBF_CMVM_BUSCA_CIUDAD_BY_ID_USER)
        Dim list_Out As New List(Of E_Select)

        List_Data = NNN.Request_Ciudad_By_ID_USER
        For Each xItem In List_Data
            Dim lol As New E_Select

            lol.value = xItem.ID_CIUDAD
            lol.text = xItem.CIU_DESC

            list_Out.Add(lol)
        Next

        Return list_Out
    End Function

    <Services.WebMethod()>
    Public Shared Function Data_Sel_Comuna(ByVal ID_CIUD As Integer) As List(Of E_Select)
        Dim NNN As New N_Gen_Activos
        Dim List_Data As New List(Of E_IRIS_WEBF_CMVM_BUSCA_COMUNA_BY_ID_USER)
        Dim list_Out As New List(Of E_Select)

        List_Data = NNN.Request_Comuna_By_ID_USER
        For Each xItem In List_Data
            Dim lol As New E_Select

            lol.value = xItem.ID_COMUNA
            lol.text = xItem.COM_DESC

            list_Out.Add(lol)
        Next

        Return list_Out
    End Function

    <Services.WebMethod()>
    Public Shared Function Data_Sel_Comuna_id_ciu(ByVal ID_CIUD As Integer) As List(Of E_Select)
        Dim NNN As New N_Gen_Activos
        Dim List_Data As New List(Of E_IRIS_WEBF_CMVM_BUSCA_COMUNA_BY_ID_USER)
        Dim list_Out As New List(Of E_Select)

        List_Data = NNN.Request_Comuna(ID_CIUD)
        For Each xItem In List_Data
            Dim lol As New E_Select

            lol.value = xItem.ID_REL_CIU_COM
            'lol.value = xItem.ID_COMUNA
            lol.text = xItem.COM_DESC

            list_Out.Add(lol)
        Next

        Return list_Out
    End Function


    <Services.WebMethod()>
    Public Shared Function Get_Ciu_Com_User(ByVal ID_USER As Integer) As E_IRIS_WEBF_CMVM_BUSCA_ID_CIU_ID_COM_BY_ID_USER
        Dim NNN As New N_Login2

        Return NNN.IRIS_WEBF_CMVM_BUSCA_ID_CIU_ID_COM_BY_ID_USER(ID_USER)
    End Function


    '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_NO_ESTADO_AGENDA_BONIFICACION_GLUCOSA(ByVal ID_PREVE As Integer, ByVal Fecha As String, ByVal CF As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        Dim NN As N_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA = New N_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA
        Dim ANO As Date
        ANO = CDate(Fecha)
        data_paciente = NN.IRIS_WEBF_CMVM_BUSCA_ATENCION_CODIGO_FONASA_NO_ESTADO_AGENDA_BONIFICACION_GLUCOSA_2(ID_PREVE, Format(ANO, "yyyy"), CF)
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
    Public Shared Function IRIS_WEBF_CMVM_BUSCA_DETERMINACIONES_GLUCOSA(ByVal ID_PERFIL As Integer) As String

        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA)
        Dim NN As N_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA = New N_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA
        'Dim ANO As Date

        data_paciente = NN.IRIS_WEBF_CMVM_BUSCA_DETERMINACIONES_GLUCOSA(ID_PERFIL)
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




    '@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ GUARDAR EDITAR MEDICO@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_GRABA_EDITA_DOC(ByVal RUT As String, ByVal NOMBRE As String, ByVal ID As Long, ByVal TIPO As Integer) As Long

        'Declaraciones internas
        Dim data As Long
        Dim NN As New N_IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE

        data = NN.IRIS_WEBF_GRABA_EDITA_DOC(RUT, NOMBRE, ID, TIPO)

        Return data

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_DOC_POR_RUT(ByVal RUT As String) As E_IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE

        'Declaraciones internas
        Dim data_paciente As E_IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE
        Dim NN As New N_IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE

        data_paciente = NN.IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE(RUT)
        If (data_paciente.DOC_NOMBRE = Nothing) Then
            Return Nothing
        Else
            Return data_paciente
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_DOC_POR_NOM(ByVal NOM As String) As List(Of E_IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE)

        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE)
        Dim NN As New N_IRIS_WEBF_BUSCA_DOC_POR_RUT_NOMBRE

        data_paciente = NN.IRIS_WEBF_BUSCA_DOC_POR_NOM_APE(NOM)
        If (data_paciente.Count > 0) Then
            Return data_paciente
        Else
            Return Nothing
        End If
    End Function
    Public Class ids2
        Dim E_id_CF As Integer
        Dim E_id_PER As Integer
        Dim E_Valor As Integer
        Dim E_Clinico As String
        Dim E_CF_ESTADO_EXAMEN As String
        Dim E_SITIO_ANATO As String
        Public Property CF_VIH As Boolean
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

        Public Property SITIO_ANATO As String
            Get
                Return E_SITIO_ANATO
            End Get
            Set(value As String)
                E_SITIO_ANATO = value
            End Set
        End Property
    End Class
End Class
Public Class Correlativo
    Public Property ID_ATE
    Public Property CORRELAT
End Class
