Public Class E_IRIS_WEBF_BUSCA_EDITAR_PACIENTE_DATOS_ACTUALES
    Dim EE_ID_PACIENTE As Integer
    Dim EE_PAC_RUT As String
    Dim EE_PAC_NOMBRE As String
    Dim EE_ID_SEXO As Integer
    Dim EE_PAC_APELLIDO As String
    Dim EE_PAC_FNAC As Date
    Dim EE_ID_NACIONALIDAD As Integer
    Dim EE_PAC_DIR As String
    Dim EE_ID_REL_CIU_COM As Integer
    Dim EE_PAC_FONO1 As String
    Dim EE_PAC_FONO2 As String
    Dim EE_PAC_MOVIL1 As String
    Dim EE_PAC_MOVIL2 As String
    Dim EE_PAC_EMAIL As String
    Dim EE_PAC_OBS_PER As String
    Dim EE_ID_DIAGNOSTICO As Integer
    Dim EE_PAC_OBS_PERMA As String
    Dim EE_ID_ESTADO As Integer
    Dim EE_EST_DESCRIPCION As String
    Dim EE_DIA_DESC As String
    Dim EE_SEXO_DESC As String
    Dim EE_NAC_DESC As String
    Dim EE_COM_DESC As String
    Dim EE_CIU_DESC As String
    Dim EE_PAC_DNI As String

    Dim EE_ID_COMUNA As Integer
    Dim EE_ID_CIUDAD As Integer
    Public Property PAC_DNI As String
        Get
            Return EE_PAC_DNI
        End Get
        Set(value As String)
            EE_PAC_DNI = value
        End Set
    End Property
    Public Property ID_PACIENTE As Integer
        Get
            Return EE_ID_PACIENTE
        End Get
        Set(value As Integer)
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
    Public Property ID_SEXO As Integer
        Get
            Return EE_ID_SEXO
        End Get
        Set(value As Integer)
            EE_ID_SEXO = value
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
    Public Property PAC_FNAC As Date
        Get
            Return EE_PAC_FNAC
        End Get
        Set(value As Date)
            EE_PAC_FNAC = value
        End Set
    End Property
    Public Property ID_NACIONALIDAD As Integer
        Get
            Return EE_ID_NACIONALIDAD
        End Get
        Set(value As Integer)
            EE_ID_NACIONALIDAD = value
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
    Public Property ID_REL_CIU_COM As Integer
        Get
            Return EE_ID_REL_CIU_COM
        End Get
        Set(value As Integer)
            EE_ID_REL_CIU_COM = value
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
    Public Property PAC_FONO2 As String
        Get
            Return EE_PAC_FONO2
        End Get
        Set(value As String)
            EE_PAC_FONO2 = value
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
    Public Property PAC_MOVIL2 As String
        Get
            Return EE_PAC_MOVIL2
        End Get
        Set(value As String)
            EE_PAC_MOVIL2 = value
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
    Public Property PAC_OBS_PER As String
        Get
            Return EE_PAC_OBS_PER
        End Get
        Set(value As String)
            EE_PAC_OBS_PER = value
        End Set
    End Property
    Public Property ID_DIAGNOSTICO As Integer
        Get
            Return EE_ID_DIAGNOSTICO
        End Get
        Set(value As Integer)
            EE_ID_DIAGNOSTICO = value
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
    Public Property ID_ESTADO As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property EST_DESCRIPCION As String
        Get
            Return EE_EST_DESCRIPCION
        End Get
        Set(value As String)
            EE_EST_DESCRIPCION = value
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
    Public Property SEXO_DESC As String
        Get
            Return EE_SEXO_DESC
        End Get
        Set(value As String)
            EE_SEXO_DESC = value
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
    Public Property COM_DESC As String
        Get
            Return EE_COM_DESC
        End Get
        Set(value As String)
            EE_COM_DESC = value
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

    Public Property ID_COMUNA As Integer
        Get
            Return EE_ID_COMUNA
        End Get
        Set(value As Integer)
            EE_ID_COMUNA = value
        End Set
    End Property

    Public Property ID_CIUDAD As Integer
        Get
            Return EE_ID_CIUDAD
        End Get
        Set(value As Integer)
            EE_ID_CIUDAD = value
        End Set
    End Property
End Class
