Public Class E_IRIS_WEBF_BUSCA_PACIENTE_LIKE2
    Dim EE_ID_PACIENTE As String
    Dim EE_PAC_RUT As String
    Dim EE_PAC_NOMBRE As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_SEXO_DESC As String
    Dim EE_PAC_DIR As String
    Dim EE_PAC_FONO1 As String
    Dim EE_PAC_MOVIL1 As String
    Dim EE_PAC_EMAIL As String
    Dim EE_PAC_OBS_PERMA As String
    Dim EE_DIA_DESC As String
    Dim EE_ID_SEXO As String
    Dim EE_ID_ESTADO As String
    Dim EE_ID_LUGAR_TM As String
    Dim EE_DESC_LUGAR_TM As String
    Dim EE_PAC_DNI As String
    Dim EE_ID_REL_CIU_COM As Integer
    Public Property PAC_DNI As String
        Get
            Return EE_PAC_DNI
        End Get
        Set(value As String)
            EE_PAC_DNI = value
        End Set
    End Property
    Public Property DESC_LUGAR_TM As String
        Get
            Return EE_DESC_LUGAR_TM
        End Get
        Set(value As String)
            EE_DESC_LUGAR_TM = value
        End Set
    End Property
    Public Property ID_LUGAR_TM As String
        Get
            Return EE_ID_LUGAR_TM
        End Get
        Set(value As String)
            EE_ID_LUGAR_TM = value
        End Set
    End Property
    Public Property ID_PACIENTE As String
        Get
            Return EE_ID_PACIENTE
        End Get
        Set(value As String)
            EE_ID_PACIENTE = value
        End Set
    End Property
    Public Property PAC_RUT As String
        Get
            Return EE_PAC_RUT
        End Get
        Set(value As String)
            EE_PAC_RUT = value
        End Set
    End Property
    Public Property PAC_NOMBRE As String
        Get
            Return EE_PAC_NOMBRE
        End Get
        Set(value As String)
            EE_PAC_NOMBRE = value
        End Set
    End Property
    Public Property PAC_APELLIDO As String
        Get
            Return EE_PAC_APELLIDO
        End Get
        Set(value As String)
            EE_PAC_APELLIDO = value
        End Set
    End Property
    Public Property SEXO_DESC As String
        Get
            Return EE_SEXO_DESC
        End Get
        Set(value As String)
            EE_SEXO_DESC = value
        End Set
    End Property
    Public Property PAC_DIR As String
        Get
            Return EE_PAC_DIR
        End Get
        Set(value As String)
            EE_PAC_DIR = value
        End Set
    End Property
    Public Property PAC_FONO1 As String
        Get
            Return EE_PAC_FONO1
        End Get
        Set(value As String)
            EE_PAC_FONO1 = value
        End Set
    End Property
    Public Property PAC_MOVIL1 As String
        Get
            Return EE_PAC_MOVIL1
        End Get
        Set(value As String)
            EE_PAC_MOVIL1 = value
        End Set
    End Property
    Public Property PAC_EMAIL As String
        Get
            Return EE_PAC_EMAIL
        End Get
        Set(value As String)
            EE_PAC_EMAIL = value
        End Set
    End Property
    Public Property PAC_OBS_PERMA As String
        Get
            Return EE_PAC_OBS_PERMA
        End Get
        Set(value As String)
            EE_PAC_OBS_PERMA = value
        End Set
    End Property
    Public Property DIA_DESC As String
        Get
            Return EE_DIA_DESC
        End Get
        Set(value As String)
            EE_DIA_DESC = value
        End Set
    End Property
    Public Property ID_SEXO As String
        Get
            Return EE_ID_SEXO
        End Get
        Set(value As String)
            EE_ID_SEXO = value
        End Set
    End Property
    Public Property ID_ESTADO As String
        Get
            Return EE_ID_ESTADO
        End Get
        Set(value As String)
            EE_ID_ESTADO = value
        End Set
    End Property

    Public Property ID_REL_CIU_COM As Integer
        Get
            Return EE_ID_REL_CIU_COM
        End Get
        Set(value As Integer)
            EE_ID_REL_CIU_COM = value
        End Set
    End Property
End Class
