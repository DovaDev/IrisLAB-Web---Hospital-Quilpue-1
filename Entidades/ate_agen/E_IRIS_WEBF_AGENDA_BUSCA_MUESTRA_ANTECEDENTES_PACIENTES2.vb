Public Class E_IRIS_WEBF_AGENDA_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES2
    Dim EE_ID_PREINGRESO As Integer
    Dim EE_PREI_NUM As Integer
    Dim EE_PREI_FECHA As String
    Dim EE_PREI_FUR As String
    Dim EE_PREI_OBS_FICHA As String
    Dim EE_PREI_AÑO As Integer
    Dim EE_PREI_OBS_TM As String
    Dim EE_PAC_NOMBRE As String
    Dim EE_SEXO_DESC As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_PAC_FNAC As Date
    Dim EE_PAC_DIR As String
    Dim EE_PAC_FONO1 As String
    Dim EE_PAC_MOVIL1 As String
    Dim EE_PAC_EMAIL As String
    Dim EE_PAC_OBS_PERMA As String
    Dim EE_NAC_DESC As String
    Dim EE_CIU_DESC As String
    Dim EE_COM_DESC As String
    Dim EE_ID_PACIENTE As Integer
    Dim EE_PAC_RUT As String
    Dim EE_PREI_MES As Integer
    Dim EE_PREI_DIA As Integer
    Dim EE_DNI As String
    Dim EE_PAC_NOM_SOCIAL As String
    Dim EE_id_Nacionalidad As Integer
    Dim EE_IS_NEO As Integer
    Public Property id_Nacionalidad As Integer
        Get
            Return EE_id_Nacionalidad
        End Get
        Set(value As Integer)
            EE_id_Nacionalidad = value
        End Set
    End Property
    Public Property DNI As String
        Get
            Return EE_DNI
        End Get
        Set(value As String)
            EE_DNI = value
        End Set
    End Property
    Public Property PREI_MES As Integer
        Get
            Return EE_PREI_MES
        End Get
        Set(value As Integer)
            EE_PREI_MES = value
        End Set
    End Property
    Public Property PREI_DIA As Integer
        Get
            Return EE_PREI_DIA
        End Get
        Set(value As Integer)
            EE_PREI_DIA = value
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
    Public Property ID_PREINGRESO As Integer
        Get
            Return EE_ID_PREINGRESO
        End Get
        Set(value As Integer)
            EE_ID_PREINGRESO = value
        End Set
    End Property
    Public Property PREI_NUM As Integer
        Get
            Return EE_PREI_NUM
        End Get
        Set(value As Integer)
            EE_PREI_NUM = value
        End Set
    End Property
    Public Property PREI_FECHA As String
        Get
            Return EE_PREI_FECHA
        End Get
        Set(value As String)
            EE_PREI_FECHA = value
        End Set
    End Property
    Public Property PREI_FUR As String
        Get
            Return EE_PREI_FUR
        End Get
        Set(value As String)
            EE_PREI_FUR = value
        End Set
    End Property
    Public Property PREI_OBS_FICHA As String
        Get
            Return EE_PREI_OBS_FICHA
        End Get
        Set(value As String)
            EE_PREI_OBS_FICHA = value
        End Set
    End Property
    Public Property PREI_AÑO As Integer
        Get
            Return EE_PREI_AÑO
        End Get
        Set(value As Integer)
            EE_PREI_AÑO = value
        End Set
    End Property
    Public Property PREI_OBS_TM As String
        Get
            Return EE_PREI_OBS_TM
        End Get
        Set(value As String)
            EE_PREI_OBS_TM = value
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
    Public Property SEXO_DESC As String
        Get
            Return EE_SEXO_DESC
        End Get
        Set(value As String)
            EE_SEXO_DESC = value
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
    Public Property NAC_DESC As String
        Get
            Return EE_NAC_DESC
        End Get
        Set(value As String)
            EE_NAC_DESC = value
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

    Public Property PAC_NOM_SOCIAL As String
        Get
            Return EE_PAC_NOM_SOCIAL
        End Get
        Set(value As String)
            EE_PAC_NOM_SOCIAL = value
        End Set
    End Property

    Public Property IS_NEO As Integer
        Get
            Return EE_IS_NEO
        End Get
        Set(value As Integer)
            EE_IS_NEO = value
        End Set
    End Property
End Class
