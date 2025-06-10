Imports Entidades
Imports Negocio
Public Class Crea_Edita_Med
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function Llenar_Sexo() As List(Of E_IRIS_WEBF_BUSCA_SEXO)
        Dim NN_CF As New N_IRIS_WEBF_BUSCA_SEXO
        Dim Data_CF As New List(Of E_IRIS_WEBF_BUSCA_SEXO)
        Data_CF = NN_CF.IRIS_WEBF_BUSCA_SEXO()
        If (Data_CF.Count > 0) Then
            Return Data_CF
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Nacionalidad() As List(Of E_IRIS_WEBF_BUSCA_NACIONALIDAD)
        Dim NN_CF As New N_IRIS_WEBF_BUSCA_NACIONALIDAD
        Dim Data_CF As New List(Of E_IRIS_WEBF_BUSCA_NACIONALIDAD)
        Data_CF = NN_CF.IRIS_WEBF_BUSCA_NACIONALIDAD()
        If (Data_CF.Count > 0) Then
            Return Data_CF
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Ciudad() As List(Of E_IRIS_WEBF_BUSCA_CIUDAD)
        Dim NN_CF As New N_IRIS_WEBF_BUSCA_CIUDAD
        Dim Data_CF As New List(Of E_IRIS_WEBF_BUSCA_CIUDAD)
        Data_CF = NN_CF.IRIS_WEBF_BUSCA_CIUDAD()
        If (Data_CF.Count > 0) Then
            Return Data_CF
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_Comuna(ByVal ID_CIU As Integer) As List(Of E_IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA)
        Dim NN_CF As New N_IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA
        Dim Data_CF As New List(Of E_IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA)
        Data_CF = NN_CF.IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA(ID_CIU)
        If (Data_CF.Count > 0) Then
            Return Data_CF
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llena_Espec() As List(Of E_IRIS_WEBF_BUSCA_DOC_ESPECIALIDAD)
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_DOC_ESPECIALIDAD)
        Dim NN As N_IRIS_WEBF_BUSCA_DOC_ESPECIALIDAD = New N_IRIS_WEBF_BUSCA_DOC_ESPECIALIDAD
        data_paciente = NN.IRIS_WEBF_BUSCA_DOC_ESPECIALIDAD()
        If (data_paciente.Count > 0) Then
            Return data_paciente
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Llena_Tabla() As List(Of E_IRIS_WEBF_BUSCA_MEDICO)
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_MEDICO)
        Dim NN As N_IRIS_WEBF_BUSCA_MEDICO = New N_IRIS_WEBF_BUSCA_MEDICO
        data_paciente = NN.IRIS_WEBF_BUSCA_MEDICO()
        If (data_paciente.Count > 0) Then
            Return data_paciente
        Else
            Return Nothing
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Llama_Rel_Ciu_Com() As List(Of E_IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA)
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA)
        Dim NN As N_IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA_ID = New N_IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA_ID
        data_paciente = NN.IRIS_WEBF_BUSCA_RELACION_CIU_COMUNA_ID()
        If (data_paciente.Count > 0) Then
            Return data_paciente
        Else
            Return Nothing
        End If
    End Function
    <Services.WebMethod()>
    Public Shared Function Graba_Medico(ByVal RUT_DOC As String,
                                     ByVal NOMBRE_DOC As String,
                                     ByVal APE_DOC As String,
                                     ByVal ID_SEXO As Integer,
                                     ByVal FNAC_DOC As String,
                                     ByVal ID_NACIONALIDAD As Integer,
                                     ByVal DIR_DOC As String,
                                     ByVal ID_CIU_COM As Integer,
                                     ByVal FONO1 As String,
                                     ByVal FONO2 As String,
                                     ByVal MOVIL1 As String,
                                     ByVal MOVIL2 As String,
                                     ByVal EMAIL_DESC As String,
                                     ByVal ID_ESPECIALIDAD As Integer,
                                     ByVal ID_ESTADO As Integer) As Integer
        Dim datas As Integer
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim Fechita As Date = Convert.ToDateTime(FNAC_DOC)
        Dim NN As N_IRIS_WEBF_GRABA_MEDICOS = New N_IRIS_WEBF_GRABA_MEDICOS
        numerin = NN.IRIS_WEBF_GRABA_MEDICOS(RUT_DOC, NOMBRE_DOC, APE_DOC, ID_SEXO, FNAC_DOC, ID_NACIONALIDAD, DIR_DOC, ID_CIU_COM, FONO1, FONO2, MOVIL1, MOVIL2, EMAIL_DESC, ID_ESPECIALIDAD, ID_ESTADO)

        If (numerin > 0) Then
            'Serializar con JSON

            datas = numerin
        Else
            datas = Nothing
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function Update_Medico(ByVal ID_DOC As Integer,
                                     ByVal RUT_DOC As String,
                                     ByVal NOMBRE_DOC As String,
                                     ByVal APE_DOC As String,
                                     ByVal ID_SEXO As Integer,
                                     ByVal FNAC_DOC As String,
                                     ByVal ID_NACIONALIDAD As Integer,
                                     ByVal DIR_DOC As String,
                                     ByVal ID_CIU_COM As Integer,
                                     ByVal FONO1 As String,
                                     ByVal FONO2 As String,
                                     ByVal MOVIL1 As String,
                                     ByVal MOVIL2 As String,
                                     ByVal EMAIL_DESC As String,
                                     ByVal ID_ESPECIALIDAD As Integer,
                                     ByVal ID_ESTADO As Integer) As Integer
        Dim datas As Integer
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim Fechita As Date = Convert.ToDateTime(FNAC_DOC)
        Dim NN As N_IRIS_WEBF_UPDATE_MEDICOS = New N_IRIS_WEBF_UPDATE_MEDICOS
        numerin = NN.IRIS_WEBF_UPDATE_MEDICOS(ID_DOC, RUT_DOC, NOMBRE_DOC, APE_DOC, ID_SEXO, FNAC_DOC, ID_NACIONALIDAD, DIR_DOC, ID_CIU_COM, FONO1, FONO2, MOVIL1, MOVIL2, EMAIL_DESC, ID_ESPECIALIDAD, ID_ESTADO)

        If (numerin > 0) Then
            'Serializar con JSON

            datas = numerin
        Else
            datas = Nothing
        End If
        Return datas
    End Function
End Class