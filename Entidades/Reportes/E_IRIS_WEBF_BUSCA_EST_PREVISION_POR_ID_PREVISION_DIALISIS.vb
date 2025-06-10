Public Class E_IRIS_WEBF_BUSCA_EST_PREVISION_POR_ID_PREVISION_DIALISIS
    Private EE_ID_ATENCION As Integer
    Public Property ID_ATENCION() As Integer
        Get
            Return EE_ID_ATENCION
        End Get
        Set(ByVal value As Integer)
            EE_ID_ATENCION = value
        End Set
    End Property

    Private EE_ATE_NUM As Integer
    Public Property ATE_NUM() As Integer
        Get
            Return EE_ATE_NUM
        End Get
        Set(ByVal value As Integer)
            EE_ATE_NUM = value
        End Set
    End Property

    Private EE_ATE_FECHA As Date
    Public Property ATE_FECHA() As Date
        Get
            Return EE_ATE_FECHA
        End Get
        Set(ByVal value As Date)
            EE_ATE_FECHA = value
        End Set
    End Property

    Private EE_ID_PACIENTE As Integer
    Public Property ID_PACIENTE() As Integer
        Get
            Return EE_ID_PACIENTE
        End Get
        Set(ByVal value As Integer)
            EE_ID_PACIENTE = value
        End Set
    End Property

    Private EE_PREVE_DESC As String
    Public Property PREVE_DESC() As String
        Get
            Return EE_PREVE_DESC
        End Get
        Set(ByVal value As String)
            EE_PREVE_DESC = value
        End Set
    End Property

    Private EE_PAC_NOMBRE As String
    Public Property PAC_NOMBRE() As String
        Get
            Return EE_PAC_NOMBRE
        End Get
        Set(ByVal value As String)
            EE_PAC_NOMBRE = value
        End Set
    End Property

    Private EE_PAC_APELLIDO As String
    Public Property PAC_APELLIDO() As String
        Get
            Return EE_PAC_APELLIDO
        End Get
        Set(ByVal value As String)
            EE_PAC_APELLIDO = value
        End Set
    End Property

    Private EE_PAC_RUT As String
    Public Property PAC_RUT() As String
        Get
            Return EE_PAC_RUT
        End Get
        Set(ByVal value As String)
            EE_PAC_RUT = value
        End Set
    End Property
    Private EE_ATE_ANO As String
    Public Property ATE_ANO() As String
        Get
            Return EE_ATE_ANO
        End Get
        Set(ByVal value As String)
            EE_ATE_ANO = value
        End Set
    End Property

    Private EE_ATE_MES As String
    Public Property ATE_MES() As String
        Get
            Return EE_ATE_MES
        End Get
        Set(ByVal value As String)
            EE_ATE_MES = value
        End Set
    End Property

    Private EE_ATE_DIA As String
    Public Property ATE_DIA() As String
        Get
            Return EE_ATE_DIA
        End Get
        Set(ByVal value As String)
            EE_ATE_DIA = value
        End Set
    End Property

    Private EE_ID_SEXO As Integer
    Public Property ID_SEXO() As Integer
        Get
            Return EE_ID_SEXO
        End Get
        Set(ByVal value As Integer)
            EE_ID_SEXO = value
        End Set
    End Property

    Private EE_SEXO_DESC As String
    Public Property SEXO_DESC() As String
        Get
            Return EE_SEXO_DESC
        End Get
        Set(ByVal value As String)
            EE_SEXO_DESC = value
        End Set
    End Property

    Private EE_PROC_DESC As String
    Public Property PROC_DESC() As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(ByVal value As String)
            EE_PROC_DESC = value
        End Set
    End Property

    Private EE_PAC_FNAC As Date
    Public Property PAC_FNAC() As Date
        Get
            Return EE_PAC_FNAC
        End Get
        Set(ByVal value As Date)
            EE_PAC_FNAC = value
        End Set
    End Property

    Dim EE_ATE_RESULTADO As String
    Dim EE_ATE_RESULTADO_NUM As String
    Dim EE_ID_PRUEBA As Integer
    Dim EE_ATE_EST_VALIDA As Integer
    Dim EE_Data_PRUEBAS As E_IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS
    Dim EE_Data_RESULTADO As E_IRIS_WEBF_BUSCA_RESULTADO_DIALISIS
    Public Property Data_RESULTADO As E_IRIS_WEBF_BUSCA_RESULTADO_DIALISIS
        Get
            Return EE_Data_RESULTADO
        End Get
        Set(value As E_IRIS_WEBF_BUSCA_RESULTADO_DIALISIS)
            EE_Data_RESULTADO = value
        End Set
    End Property
    Public Property Data_PRUEBAS As E_IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS
        Get
            Return EE_Data_PRUEBAS
        End Get
        Set(value As E_IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS)
            EE_Data_PRUEBAS = value
        End Set
    End Property

    Public Property ATE_RESULTADO As String
        Get
            Return EE_ATE_RESULTADO
        End Get
        Set(value As String)
            EE_ATE_RESULTADO = value
        End Set
    End Property

    Public Property ATE_RESULTADO_NUM As String
        Get
            Return EE_ATE_RESULTADO_NUM
        End Get
        Set(value As String)
            EE_ATE_RESULTADO_NUM = value
        End Set
    End Property

    Public Property ID_PRUEBA As Integer
        Get
            Return EE_ID_PRUEBA
        End Get
        Set(value As Integer)
            EE_ID_PRUEBA = value
        End Set
    End Property

    Public Property ATE_EST_VALIDA As Integer
        Get
            Return EE_ATE_EST_VALIDA
        End Get
        Set(value As Integer)
            EE_ATE_EST_VALIDA = value
        End Set
    End Property
End Class