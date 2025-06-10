Public Class E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_TODOS
    Dim EE_ID_ATENCION As Long
    Dim EE_ATE_NUM As Long
    Dim EE_ATE_FECHA As Date
    Dim EE_ID_PACIENTE As Long
    Dim EE_PAC_NOMBRE As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_ATE_AÑO As Long
    Dim EE_SEXO_DESC As String
    Dim EE_ID_SEXO As Long
    Dim EE_ID_PROCEDENCIA As Long
    Dim EE_ID_ESTADO As Long
    Dim EE_PROC_DESC As String
    Dim EE_ID_NACIONALIDAD As Long
    Dim EE_ID_ORDEN As Long
    Dim EE_ID_TP_PACI As Long
    Dim EE_CF_DESC As String
    Dim EE_ID_CODIGO_FONASA As Long
    Dim EE_PAC_RUT As String


    Dim EE_FECHA_NAC As String
    Dim EE_DNI As String
    Dim EE_NACIONALIDAD As String
    Dim EE_PROGRAMA As String
    Dim EE_SECTOR As String
    Dim EE_NUMERO_INTERNO As String
    Dim EE_MEDICO_SOLICITANTE As String
    Dim EE_MEDICO_SOLICITANTE_2 As String

    Dim EE_ENCRYPTED_ID As String
    Dim EE_CB_DESC As String
    Dim EE_ATE_OBS_TM As String

    Public Property ATE_OBS_TM() As String
        Get
            Return EE_ATE_OBS_TM
        End Get
        Set(ByVal value As String)
            EE_ATE_OBS_TM = value
        End Set
    End Property

    Public Property CB_DESC() As String
        Get
            Return EE_CB_DESC
        End Get
        Set(ByVal value As String)
            EE_CB_DESC = value
        End Set
    End Property
    Public Property ENCRYPTED_ID() As String
        Get
            Return EE_ENCRYPTED_ID
        End Get
        Set(ByVal value As String)
            EE_ENCRYPTED_ID = value
        End Set
    End Property
    Public Property MEDICO_SOLICITANTE_2() As String
        Get
            Return EE_MEDICO_SOLICITANTE_2
        End Get
        Set(ByVal value As String)
            EE_MEDICO_SOLICITANTE_2 = value
        End Set
    End Property
    Public Property MEDICO_SOLICITANTE() As String
        Get
            Return EE_MEDICO_SOLICITANTE
        End Get
        Set(ByVal value As String)
            EE_MEDICO_SOLICITANTE = value
        End Set
    End Property
    Public Property NUMERO_INTERNO() As String
        Get
            Return EE_NUMERO_INTERNO
        End Get
        Set(ByVal value As String)
            EE_NUMERO_INTERNO = value
        End Set
    End Property
    Public Property SECTOR() As String
        Get
            Return EE_SECTOR
        End Get
        Set(ByVal value As String)
            EE_SECTOR = value
        End Set
    End Property
    Public Property PROGRAMA() As String
        Get
            Return EE_PROGRAMA
        End Get
        Set(ByVal value As String)
            EE_PROGRAMA = value
        End Set
    End Property
    Public Property NACIONALIDAD() As String
        Get
            Return EE_NACIONALIDAD
        End Get
        Set(ByVal value As String)
            EE_NACIONALIDAD = value
        End Set
    End Property
    Public Property DNI() As String
        Get
            Return EE_DNI
        End Get
        Set(ByVal value As String)
            EE_DNI = value
        End Set
    End Property
    Public Property FECHA_NAC() As String
        Get
            Return EE_FECHA_NAC
        End Get
        Set(ByVal value As String)
            EE_FECHA_NAC = value
        End Set
    End Property




    Public Property PAC_RUT() As String
        Get
            Return EE_PAC_RUT
        End Get
        Set(ByVal value As String)
            EE_PAC_RUT = value
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
    Public Property ATE_NUM As Long
        Get
            Return EE_ATE_NUM
        End Get
        Set(value As Long)
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
    Public Property ID_PACIENTE As Long
        Get
            Return EE_ID_PACIENTE
        End Get
        Set(value As Long)
            EE_ID_PACIENTE = value
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
    Public Property ATE_AÑO As Long
        Get
            Return EE_ATE_AÑO
        End Get
        Set(value As Long)
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
    Public Property ID_SEXO As Long
        Get
            Return EE_ID_SEXO
        End Get
        Set(value As Long)
            EE_ID_SEXO = value
        End Set
    End Property
    Public Property ID_PROCEDENCIA As Long
        Get
            Return EE_ID_PROCEDENCIA
        End Get
        Set(value As Long)
            EE_ID_PROCEDENCIA = value
        End Set
    End Property
    Public Property ID_ESTADO As Long
        Get
            Return EE_ID_ESTADO
        End Get
        Set(value As Long)
            EE_ID_ESTADO = value
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
    Public Property ID_NACIONALIDAD As Long
        Get
            Return EE_ID_NACIONALIDAD
        End Get
        Set(value As Long)
            EE_ID_NACIONALIDAD = value
        End Set
    End Property
    Public Property ID_ORDEN As Long
        Get
            Return EE_ID_ORDEN
        End Get
        Set(value As Long)
            EE_ID_ORDEN = value
        End Set
    End Property
    Public Property ID_TP_PACI As Long
        Get
            Return EE_ID_TP_PACI
        End Get
        Set(value As Long)
            EE_ID_TP_PACI = value
        End Set
    End Property
    Public Property CF_DESC As String
        Get
            Return EE_CF_DESC
        End Get
        Set(value As String)
            EE_CF_DESC = value
        End Set
    End Property
    Public Property ID_CODIGO_FONASA As Long
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(value As Long)
            EE_ID_CODIGO_FONASA = value
        End Set
    End Property
End Class
