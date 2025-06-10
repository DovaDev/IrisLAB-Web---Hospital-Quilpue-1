Public Class E_IRIS_WEBF_BUSCA_DATOS_ATENCION_REIMPR
    Dim EE_PAC_RUT As String
    Dim EE_PAC_NOMBRE As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_ATE_NUM As String
    Dim EE_PAC_FNAC As String
    Dim EE_ATE_AÑO As Integer
    Dim EE_SEXO_DESC As String
    Dim EE_ATE_FUR As String
    Dim EE_NAC_DESC As String
    Dim EE_PAC_FONO1 As String
    Dim EE_PAC_MOVIL1 As String
    Dim EE_CIU_DESC As String
    Dim EE_PAC_DIR As String
    Dim EE_PAC_EMAIL As String
    Dim EE_PAC_OBS_PERMA As String
    Dim EE_ATE_NUM_INTERNO As String
    Dim EE_DNI As String
    Public Property DNI As String
        Get
            Return EE_DNI
        End Get
        Set(value As String)
            EE_DNI = value
        End Set
    End Property

    Public Property ATE_NUM_INTERNO As String
        Get
            Return EE_ATE_NUM_INTERNO
        End Get
        Set(value As String)
            EE_ATE_NUM_INTERNO = value
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
    Public Property PAC_EMAIL As String
        Get
            Return EE_PAC_EMAIL
        End Get
        Set(value As String)
            EE_PAC_EMAIL = value
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
    Public Property CIU_DESC As String
        Get
            Return EE_CIU_DESC
        End Get
        Set(value As String)
            EE_CIU_DESC = value
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
    Public Property PAC_FONO1 As String
        Get
            Return EE_PAC_FONO1
        End Get
        Set(value As String)
            EE_PAC_FONO1 = value
        End Set
    End Property
    Public Property NAC_DESC As String
        Get
            Return EE_NAC_DESC
        End Get
        Set(value As String)
            EE_NAC_DESC = value
        End Set
    End Property

    Public Property ATE_FUR As String
        Get
            Return EE_ATE_FUR
        End Get
        Set(value As String)
            EE_ATE_FUR = value
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
    Public Property ATE_AÑO As Integer
        Get
            Return EE_ATE_AÑO
        End Get
        Set(value As Integer)
            EE_ATE_AÑO = value
        End Set
    End Property


    Public Property PAC_FNAC As String
        Get
            Return EE_PAC_FNAC
        End Get
        Set(value As String)
            EE_PAC_FNAC = value
        End Set
    End Property
    Public Property ATE_NUM As String
        Get
            Return EE_ATE_NUM
        End Get
        Set(value As String)
            EE_ATE_NUM = value
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
    Public Property PAC_NOMBRE As String
        Get
            Return EE_PAC_NOMBRE
        End Get
        Set(value As String)
            EE_PAC_NOMBRE = value
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
End Class
