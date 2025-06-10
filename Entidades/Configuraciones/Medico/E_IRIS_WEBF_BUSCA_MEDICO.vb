Public Class E_IRIS_WEBF_BUSCA_MEDICO
    Private EE_DOC_RUT As String
    Private EE_DOC_NOMBRE As String
    Private EE_DOC_APELLIDO As String
    Private EE_ID_SEXO As Integer
    Private EE_DOC_FNAC As Date
    Private EE_ID_NACIONALIDAD As Integer
    Private EE_DOC_DIR As String
    Private EE_ID_REL_CIU_COM As Integer
    Private EE_DOC_FONO1 As String
    Private EE_DOC_FONO2 As String
    Private EE_DOC_MOVIL1 As String
    Private EE_DOC_MOVIL2 As String
    Private EE_DOC_EMAIL As String
    Private EE_ID_ESPECIALIDAD As Integer
    Private EE_ID_ESTADO As Integer
    Private EE_ID_DOCTOR As Integer
    Private EE_ESP_DESC As String
    Public Property ESP_DESC() As String
        Get
            Return EE_ESP_DESC
        End Get
        Set(ByVal value As String)
            EE_ESP_DESC = value
        End Set
    End Property
    Public Property ID_DOCTOR() As Integer
        Get
            Return EE_ID_DOCTOR
        End Get
        Set(ByVal value As Integer)
            EE_ID_DOCTOR = value
        End Set
    End Property
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property ID_ESPECIALIDAD() As Integer
        Get
            Return EE_ID_ESPECIALIDAD
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESPECIALIDAD = value
        End Set
    End Property
    Public Property DOC_EMAIL() As String
        Get
            Return EE_DOC_EMAIL
        End Get
        Set(ByVal value As String)
            EE_DOC_EMAIL = value
        End Set
    End Property
    Public Property DOC_MOVIL2() As String
        Get
            Return EE_DOC_MOVIL2
        End Get
        Set(ByVal value As String)
            EE_DOC_MOVIL2 = value
        End Set
    End Property
    Public Property DOC_MOVIL1() As String
        Get
            Return EE_DOC_MOVIL1
        End Get
        Set(ByVal value As String)
            EE_DOC_MOVIL1 = value
        End Set
    End Property
    Public Property DOC_FONO2() As String
        Get
            Return EE_DOC_FONO2
        End Get
        Set(ByVal value As String)
            EE_DOC_FONO2 = value
        End Set
    End Property
    Public Property DOC_FONO1() As String
        Get
            Return EE_DOC_FONO1
        End Get
        Set(ByVal value As String)
            EE_DOC_FONO1 = value
        End Set
    End Property
    Public Property ID_REL_CIU_COM() As Integer
        Get
            Return EE_ID_REL_CIU_COM
        End Get
        Set(ByVal value As Integer)
            EE_ID_REL_CIU_COM = value
        End Set
    End Property
    Public Property DOC_DIR() As String
        Get
            Return EE_DOC_DIR
        End Get
        Set(ByVal value As String)
            EE_DOC_DIR = value
        End Set
    End Property
    Public Property ID_NACIONALIDAD() As Integer
        Get
            Return EE_ID_NACIONALIDAD
        End Get
        Set(ByVal value As Integer)
            EE_ID_NACIONALIDAD = value
        End Set
    End Property
    Public Property DOC_FNAC() As Date
        Get
            Return EE_DOC_FNAC
        End Get
        Set(ByVal value As Date)
            EE_DOC_FNAC = value
        End Set
    End Property
    Public Property ID_SEXO() As Integer
        Get
            Return EE_ID_SEXO
        End Get
        Set(ByVal value As Integer)
            EE_ID_SEXO = value
        End Set
    End Property
    Public Property DOC_APELLIDO() As String
        Get
            Return EE_DOC_APELLIDO
        End Get
        Set(ByVal value As String)
            EE_DOC_APELLIDO = value
        End Set
    End Property
    Public Property DOC_NOMBRE() As String
        Get
            Return EE_DOC_NOMBRE
        End Get
        Set(ByVal value As String)
            EE_DOC_NOMBRE = value
        End Set
    End Property
    Public Property DOC_RUT() As String
        Get
            Return EE_DOC_RUT
        End Get
        Set(ByVal value As String)
            EE_DOC_RUT = value
        End Set
    End Property
End Class