Public Class E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO
    Dim EE_ENVIO_NUM As Integer
    Dim EE_ID_ATENCION As Integer
    Dim EE_ENVIO_ETI_CURVA As String
    Dim EE_ENVIO_ETI_NUM_ATE As Integer
    Dim EE_ID_USUARIO As Integer
    Dim EE_ENVIO_ETI_FECHA As Date
    Dim EE_ID_ENVIO As Integer
    Dim EE_ID_ESTADO As Integer
    Dim EE_CB_DESC As String
    Dim EE_T_MUESTRA_DESC As String
    Dim EE_CF_DESC As String
    Dim EE_PAC_NOMBRE As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_RLS_LS_DESC As String
    Dim EE_ID_RLS_LS As String
    Dim EE_EST_DESCRIPCION As String
    Dim EE_ID_PER As Integer
    Dim EE_PROC_DESC As String
    Dim EE_ATE_AÑO As String
    Dim EE_ATE_MES As String
    Dim EE_ATE_DIA As String
    Dim EE_SEXO_DESC As String
    Dim EE_USU_NIC As String
    Dim EE_ATE_NUM_INTERNO As String
    Dim EE_ATE_NUM As String
    Dim EE_ATE_FECHA As Date
    Dim EE_ATE_OBS_TM As String
    Dim EE_PAC_RUT As String
    Dim EE_PAC_DNI As String
    Dim EE_ENVIO_FECHA As Date
    Dim EE_CANTIDAD_TUBO As Integer
    Dim EE_INDICE As Integer

    Public Property INDICE As Integer
        Get
            Return EE_INDICE
        End Get
        Set(value As Integer)
            EE_INDICE = value
        End Set
    End Property

    Public Property CANTIDAD_TUBO As Integer
        Get
            Return EE_CANTIDAD_TUBO
        End Get
        Set(value As Integer)
            EE_CANTIDAD_TUBO = value
        End Set
    End Property

    Public Property ENVIO_FECHA As Date
        Get
            Return EE_ENVIO_FECHA
        End Get
        Set(value As Date)
            EE_ENVIO_FECHA = value
        End Set
    End Property

    Public Property PAC_DNI As String
        Get
            Return EE_PAC_DNI
        End Get
        Set(value As String)
            EE_PAC_DNI = value
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

    Public Property ATE_OBS_TM As String
        Get
            Return EE_ATE_OBS_TM
        End Get
        Set(value As String)
            EE_ATE_OBS_TM = value
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

    Public Property ATE_NUM As String
        Get
            Return EE_ATE_NUM
        End Get
        Set(value As String)
            EE_ATE_NUM = value
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

    Public Property ENVIO_NUM As Integer
        Get
            Return EE_ENVIO_NUM
        End Get
        Set(value As Integer)
            EE_ENVIO_NUM = value
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

    Public Property ENVIO_ETI_CURVA As String
        Get
            Return EE_ENVIO_ETI_CURVA
        End Get
        Set(value As String)
            EE_ENVIO_ETI_CURVA = value
        End Set
    End Property

    Public Property ENVIO_ETI_NUM_ATE As Integer
        Get
            Return EE_ENVIO_ETI_NUM_ATE
        End Get
        Set(value As Integer)
            EE_ENVIO_ETI_NUM_ATE = value
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

    Public Property ENVIO_ETI_FECHA As Date
        Get
            Return EE_ENVIO_ETI_FECHA
        End Get
        Set(value As Date)
            EE_ENVIO_ETI_FECHA = value
        End Set
    End Property

    Public Property ID_ENVIO As Integer
        Get
            Return EE_ID_ENVIO
        End Get
        Set(value As Integer)
            EE_ID_ENVIO = value
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

    Public Property ID_RLS_LS As String
        Get
            Return EE_ID_RLS_LS
        End Get
        Set(value As String)
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

    Public Property USU_NIC As String
        Get
            Return EE_USU_NIC
        End Get
        Set(value As String)
            EE_USU_NIC = value
        End Set
    End Property
End Class
