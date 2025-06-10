Public Class E_IRIS_WEBF_BUSCA_ANTECENDES_PACIENTE_RECEP_ENVIO
    Dim EE_ID_ATENCION As Integer
    Dim EE_ATE_NUM As Integer
    Dim EE_ATE_OBS_FICHA As String
    Dim EE_ATE_OBS_TM As String
    Dim EE_PAC_NOMBRE As String
    Dim EE_PAC_RUT As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_PAC_FONO1 As String
    Dim EE_PAC_MOVIL1 As String
    Dim EE_PAC_EMAIL As String
    Dim EE_ATE_AÑO As String
    Dim EE_SEXO_DESC As String
    Dim EE_ATE_ID_ESTADO_TM As Integer

    Public Property ID_ATENCION As Integer
        Get
            Return EE_ID_ATENCION
        End Get
        Set(value As Integer)
            EE_ID_ATENCION = value
        End Set
    End Property

    Public Property ATE_NUM As Integer
        Get
            Return EE_ATE_NUM
        End Get
        Set(value As Integer)
            EE_ATE_NUM = value
        End Set
    End Property

    Public Property ATE_OBS_FICHA As String
        Get
            Return EE_ATE_OBS_FICHA
        End Get
        Set(value As String)
            EE_ATE_OBS_FICHA = value
        End Set
    End Property

    Public Property ATE_OBS_TM As String
        Get
            Return EE_ATE_OBS_TM
        End Get
        Set(value As String)
            EE_ATE_OBS_TM = value
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

    Public Property PAC_APELLIDO As String
        Get
            Return EE_PAC_APELLIDO
        End Get
        Set(value As String)
            EE_PAC_APELLIDO = value
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

    Public Property ATE_AÑO As String
        Get
            Return EE_ATE_AÑO
        End Get
        Set(value As String)
            EE_ATE_AÑO = value
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

    Public Property ATE_ID_ESTADO_TM As Integer
        Get
            Return EE_ATE_ID_ESTADO_TM
        End Get
        Set(value As Integer)
            EE_ATE_ID_ESTADO_TM = value
        End Set
    End Property
End Class
