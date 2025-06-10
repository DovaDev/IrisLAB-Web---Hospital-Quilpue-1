Public Class E_IRIS_WEBF_BUSCA_DATOS_PACIENTE_eXA_eSP
    Private EE_PAC_RUT As String
    Public Property PAC_RUT() As String
        Get
            Return EE_PAC_RUT
        End Get
        Set(ByVal value As String)
            EE_PAC_RUT = value
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

    Private EE_ID_SEXO As Integer
    Public Property ID_SEXO() As Integer
        Get
            Return EE_ID_SEXO
        End Get
        Set(ByVal value As Integer)
            EE_ID_SEXO = value
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

    Private EE_ID_NACIONALIDAD As Integer
    Public Property ID_NACIONALIDAD() As Integer
        Get
            Return EE_ID_NACIONALIDAD
        End Get
        Set(ByVal value As Integer)
            EE_ID_NACIONALIDAD = value
        End Set
    End Property

    Private EE_ATE_AVIS As String
    Public Property ATE_AVIS() As String
        Get
            Return EE_ATE_AVIS
        End Get
        Set(ByVal value As String)
            EE_ATE_AVIS = value
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
End Class
