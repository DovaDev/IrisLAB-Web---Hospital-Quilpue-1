Public Class E_IRIS_WEBF_BUSCA_MUESTRA_ANTECEDENTES_PACIENTES4
    Private EE_ID_ATENCION As Long
    Private EE_ATE_NUM As String
    Private EE_ATE_FECHA As Date
    Private EE_ATE_FUR As String
    Private EE_ATE_OBS_FICHA As String
    Private EE_ATE_AÑO As Integer
    Private EE_ATE_OBS_TM As String
    Private EE_PAC_NOMBRE As String
    Private EE_SEXO_DESC As String
    Private EE_PAC_APELLIDO As String
    Private EE_PAC_FNAC As Date
    Private EE_PAC_DIR As String
    Private EE_PAC_FONO1 As String
    Private EE_PAC_MOVIL1 As String
    Private EE_PAC_EMAIL As String
    Private EE_PAC_OBS_PERMA As String
    Private EE_NAC_DESC As String
    Private EE_COM_DESC As String
    Private EE_CIU_DESC As String
    Private EE_ID_PACIENTE As Long
    Private EE_PAC_RUT As String
    Private EE_PROGRA_DESC As String
    Private EE_ATE_TOTAL As Long
    Private EE_ATE_TOTAL_PREVI As Long
    Private EE_ATE_TOTAL_COPA As Long
    Private EE_ATE_AUTORIZO_RETIRO As String
    Private EE_PREVE_DESC As String
    Private EE_PROC_DESC As String
    Private EE_DOC_NOMBRE As String
    Private EE_DOC_APELLIDO As String
    Private EE_ATE_AVIS As String
    Private EE_PAC_DNI As String
    Public Property PAC_DNI As String
        Get
            Return EE_PAC_DNI
        End Get
        Set(value As String)
            EE_PAC_DNI = value
        End Set
    End Property
    Public Property ATE_AVIS As String
        Get
            Return EE_ATE_AVIS
        End Get
        Set(value As String)
            EE_ATE_AVIS = value
        End Set
    End Property
    Public Property ID_ATENCION As Long
        Get
            Return EE_ID_ATENCION
        End Get
        Set(value As Long)
            EE_ID_ATENCION = value
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
    Public Property ATE_FECHA As Date
        Get
            Return EE_ATE_FECHA
        End Get
        Set(value As Date)
            EE_ATE_FECHA = value
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
    Public Property ATE_OBS_FICHA As String
        Get
            Return EE_ATE_OBS_FICHA
        End Get
        Set(value As String)
            EE_ATE_OBS_FICHA = value
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
    Public Property ID_PACIENTE As Long
        Get
            Return EE_ID_PACIENTE
        End Get
        Set(value As Long)
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
    Public Property PROGRA_DESC As String
        Get
            Return EE_PROGRA_DESC
        End Get
        Set(value As String)
            EE_PROGRA_DESC = value
        End Set
    End Property
    Public Property ATE_TOTAL As Long
        Get
            Return EE_ATE_TOTAL
        End Get
        Set(value As Long)
            EE_ATE_TOTAL = value
        End Set
    End Property
    Public Property ATE_TOTAL_PREVI As Long
        Get
            Return EE_ATE_TOTAL_PREVI
        End Get
        Set(value As Long)
            EE_ATE_TOTAL_PREVI = value
        End Set
    End Property
    Public Property ATE_TOTAL_COPA As Long
        Get
            Return EE_ATE_TOTAL_COPA
        End Get
        Set(value As Long)
            EE_ATE_TOTAL_COPA = value
        End Set
    End Property
    Public Property ATE_AUTORIZO_RETIRO As String
        Get
            Return EE_ATE_AUTORIZO_RETIRO
        End Get
        Set(value As String)
            EE_ATE_AUTORIZO_RETIRO = value
        End Set
    End Property
    Public Property PREVE_DESC As String
        Get
            Return EE_PREVE_DESC
        End Get
        Set(value As String)
            EE_PREVE_DESC = value
        End Set
    End Property
    Public Property PROC_DESC As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(value As String)
            EE_PROC_DESC = value
        End Set
    End Property
    Public Property DOC_NOMBRE As String
        Get
            Return EE_DOC_NOMBRE
        End Get
        Set(value As String)
            EE_DOC_NOMBRE = value
        End Set
    End Property
    Public Property DOC_APELLIDO As String
        Get
            Return EE_DOC_APELLIDO
        End Get
        Set(value As String)
            EE_DOC_APELLIDO = value
        End Set
    End Property
End Class
