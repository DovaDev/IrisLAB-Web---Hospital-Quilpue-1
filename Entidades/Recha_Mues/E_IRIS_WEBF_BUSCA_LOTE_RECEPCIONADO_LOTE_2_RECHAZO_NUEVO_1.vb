Public Class E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1
    Dim EE_LOTE_RECHAZO_NUM As String
    Dim EE_ID_ATENCION As Integer
    Dim EE_RECEP_ETI_CURVA_RECHAZO As String
    Dim EE_RECEP_ETI_NUM_ATE_RECHAZO As String
    Dim EE_ID_USUARIO As Integer
    Dim EE_RECEP_ETI_FECHA_RECHAZO As Date
    Dim EE_ID_LOTE_RECHAZO As Integer
    Dim EE_ID_ESTADO As Integer
    Dim EE_CB_DESC As String
    Dim EE_T_MUESTRA_DESC As String
    Dim EE_CF_DESC As String
    Dim EE_PAC_NOMBRE As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_RLS_LS_DESC As String
    Dim EE_ID_RLS_LS As Integer
    Dim EE_EST_DESCRIPCION As String
    Dim EE_ID_PER As Integer
    Dim EE_PROC_DESC As String
    Dim EE_ATE_AÑO As String
    Dim EE_ATE_MES As String
    Dim EE_USU_NIC As String
    Dim EE_RECEP_ETI_RECHAZO_OBS As String
    Dim EE_ATE_DIA As String
    Dim EE_SEXO_DESC As String

    Dim EE_PAC_RUT As String
    Dim EE_PAC_FNAC As Date
    Dim EE_ATE_NUM_INTERNO As String
    Dim EE_ATE_DNI As String
    Dim EE_DOC_NOMBRE As String
    Dim EE_DOC_APELLIDO As String
    Dim EE_ID_PROCEDENCIA As String
    Dim EE_NAC_DESC As String
    Dim EE_PROGRA_DESC As String
    Dim EE_SECTOR_DESC As String
    Dim EE_ATE_NUM As String
    Dim EE_TP_RECHA_DESC As String
    Public Property TP_RECHA_DESC As String
        Get
            Return EE_TP_RECHA_DESC
        End Get
        Set(value As String)
            EE_TP_RECHA_DESC = value
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
    Public Property PAC_RUT As String
        Get
            Return EE_PAC_RUT
        End Get
        Set(value As String)
            EE_PAC_RUT = value
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
    Public Property ATE_NUM_INTERNO As String
        Get
            Return EE_ATE_NUM_INTERNO
        End Get
        Set(value As String)
            EE_ATE_NUM_INTERNO = value
        End Set
    End Property
    Public Property ATE_DNI As String
        Get
            Return EE_ATE_DNI
        End Get
        Set(value As String)
            EE_ATE_DNI = value
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
    Public Property ID_PROCEDENCIA As Integer
        Get
            Return EE_ID_PROCEDENCIA
        End Get
        Set(value As Integer)
            EE_ID_PROCEDENCIA = value
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
    Public Property PROGRA_DESC As String
        Get
            Return EE_PROGRA_DESC
        End Get
        Set(value As String)
            EE_PROGRA_DESC = value
        End Set
    End Property
    Public Property SECTOR_DESC As String
        Get
            Return EE_SECTOR_DESC
        End Get
        Set(value As String)
            EE_SECTOR_DESC = value
        End Set
    End Property
    Public Property LOTE_RECHAZO_NUM As String
        Get
            Return EE_LOTE_RECHAZO_NUM
        End Get
        Set(value As String)
            EE_LOTE_RECHAZO_NUM = value
        End Set
    End Property

    Public Property ID_ATENCION As Integer
        Get
            Return EE_ID_ATENCION
        End Get
        Set(value As Integer)
            EE_ID_ATENCION = value
        End Set
    End Property

    Public Property RECEP_ETI_CURVA_RECHAZO As String
        Get
            Return EE_RECEP_ETI_CURVA_RECHAZO
        End Get
        Set(value As String)
            EE_RECEP_ETI_CURVA_RECHAZO = value
        End Set
    End Property

    Public Property RECEP_ETI_NUM_ATE_RECHAZO As String
        Get
            Return EE_RECEP_ETI_NUM_ATE_RECHAZO
        End Get
        Set(value As String)
            EE_RECEP_ETI_NUM_ATE_RECHAZO = value
        End Set
    End Property

    Public Property ID_USUARIO As Integer
        Get
            Return EE_ID_USUARIO
        End Get
        Set(value As Integer)
            EE_ID_USUARIO = value
        End Set
    End Property

    Public Property RECEP_ETI_FECHA_RECHAZO As Date
        Get
            Return EE_RECEP_ETI_FECHA_RECHAZO
        End Get
        Set(value As Date)
            EE_RECEP_ETI_FECHA_RECHAZO = value
        End Set
    End Property

    Public Property ID_LOTE_RECHAZO As Integer
        Get
            Return EE_ID_LOTE_RECHAZO
        End Get
        Set(value As Integer)
            EE_ID_LOTE_RECHAZO = value
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

    Public Property CB_DESC As String
        Get
            Return EE_CB_DESC
        End Get
        Set(value As String)
            EE_CB_DESC = value
        End Set
    End Property

    Public Property T_MUESTRA_DESC As String
        Get
            Return EE_T_MUESTRA_DESC
        End Get
        Set(value As String)
            EE_T_MUESTRA_DESC = value
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

    Public Property RLS_LS_DESC As String
        Get
            Return EE_RLS_LS_DESC
        End Get
        Set(value As String)
            EE_RLS_LS_DESC = value
        End Set
    End Property

    Public Property ID_RLS_LS As Integer
        Get
            Return EE_ID_RLS_LS
        End Get
        Set(value As Integer)
            EE_ID_RLS_LS = value
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

    Public Property ID_PER As Integer
        Get
            Return EE_ID_PER
        End Get
        Set(value As Integer)
            EE_ID_PER = value
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

    Public Property ATE_AÑO As String
        Get
            Return EE_ATE_AÑO
        End Get
        Set(value As String)
            EE_ATE_AÑO = value
        End Set
    End Property

    Public Property ATE_MES As String
        Get
            Return EE_ATE_MES
        End Get
        Set(value As String)
            EE_ATE_MES = value
        End Set
    End Property

    Public Property USU_NIC As String
        Get
            Return EE_USU_NIC
        End Get
        Set(value As String)
            EE_USU_NIC = value
        End Set
    End Property

    Public Property RECEP_ETI_RECHAZO_OBS As String
        Get
            Return EE_RECEP_ETI_RECHAZO_OBS
        End Get
        Set(value As String)
            EE_RECEP_ETI_RECHAZO_OBS = value
        End Set
    End Property

    Public Property ATE_DIA As String
        Get
            Return EE_ATE_DIA
        End Get
        Set(value As String)
            EE_ATE_DIA = value
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
End Class
