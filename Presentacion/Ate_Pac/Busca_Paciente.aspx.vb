Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Busca_Paciente
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal RUT_P As String, ByVal NOM_P As String, ByVal APE_P As String, ByVal DNI_P As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PACIENTE_LIKE2)
        Dim NN As N_IRIS_WEBF_BUSCA_PACIENTE_LIKE2 = New N_IRIS_WEBF_BUSCA_PACIENTE_LIKE2
        Dim nombre As String = NOM_P.Trim()
        Dim apellido As String = APE_P.Trim()
        Dim sinpuntos As String = RUT_P.Replace(".", "")
        sinpuntos = "%" & sinpuntos & "%"
        RUT_P = "%" & RUT_P & "%"
        nombre = "%" & nombre & "%"
        apellido = "%" & apellido & "%"
        DNI_P = "%" & DNI_P & "%"
        data_paciente = NN.IRIS_WEBF_BUSCA_PACIENTE_LIKE2_4_DNI(RUT_P, nombre, apellido, sinpuntos, DNI_P)
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
    Public Shared Function Llenar_DataTable_Ate(ByVal NUM_ATE As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_ate As List(Of E_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION)
        Dim data_ate_2 As List(Of E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES______2)
        Dim NN_Ate As N_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION = New N_IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION
        Dim NN_Ate_2 As N_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES = New N_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES
        data_ate = NN_Ate.IRIS_WEBF_BUSCA_ID_ATENCION_POR_NUMERO_DE_ATENCION(NUM_ATE)
        If (data_ate.Count > 0) Then
            data_ate_2 = NN_Ate_2.IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES______2(data_ate(0).ID_ATENCION)
            If (data_ate_2.Count > 0) Then
                'Serializar con JSON
                Serializer.MaxJsonLength = 999999999
                Serializer.Serialize(data_ate_2, str_Builder)
                datas = str_Builder.ToString
            Else
                datas = "null"
            End If
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable_Ate_ONCLICK(ByVal ID_PAC As String) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_ate As List(Of E_IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER)
        Dim NN_Ate As N_IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER = New N_IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER
        data_ate = NN_Ate.IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER(ID_PAC)
        If (data_ate.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_ate, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
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
End Class
