Public Class E_Detalle_Atencion_Toma_De_Muestra
    Private E_ID_PER As Integer
    Private E_CB_DESC As String
    Private E_T_MUESTRA_DESC As String
    Private E_CF_DESC As String
    Private E_EST_DESCRIPCION As String
    Private E_ATE_FEC_TM As String
    Private E_USU_FULL_NAME As String
    Private E_ATE_EST_TM As Integer
    Private E_GMUE_DESC As String
    Private E_ID_CODIGO_FONASA As String
    Private E_SITIO_ANATO As String
    Private E_IS_ANATO As Boolean
    Private E_ATE_RESULTADO As String
    Private E_ID_ATE_RES As String

    Public Property ID_PER As Integer
        Get
            Return E_ID_PER
        End Get
        Set(value As Integer)
            E_ID_PER = value
        End Set
    End Property
    Public Property CB_DESC As String
        Get
            Return E_CB_DESC
        End Get
        Set(value As String)
            E_CB_DESC = value
        End Set
    End Property
    Public Property T_MUESTRA_DESC As String
        Get
            Return E_T_MUESTRA_DESC
        End Get
        Set(value As String)
            E_T_MUESTRA_DESC = value
        End Set
    End Property
    Public Property CF_DESC As String
        Get
            Return E_CF_DESC
        End Get
        Set(value As String)
            E_CF_DESC = value
        End Set
    End Property

    Public Property EST_DESCRIPCION As String
        Get
            Return E_EST_DESCRIPCION
        End Get
        Set(value As String)
            E_EST_DESCRIPCION = value
        End Set
    End Property

    Public Property ATE_FEC_TM As String
        Get
            Return E_ATE_FEC_TM
        End Get
        Set(value As String)
            E_ATE_FEC_TM = value
        End Set
    End Property

    Public Property USU_FULL_NAME As String
        Get
            Return E_USU_FULL_NAME
        End Get
        Set(value As String)
            E_USU_FULL_NAME = value
        End Set
    End Property

    Public Property ATE_EST_TM As Integer
        Get
            Return E_ATE_EST_TM
        End Get
        Set(value As Integer)
            E_ATE_EST_TM = value
        End Set
    End Property

    Public Property GMUE_DESC As String
        Get
            Return E_GMUE_DESC
        End Get
        Set(value As String)
            E_GMUE_DESC = value
        End Set
    End Property

    Public Property ID_CODIGO_FONASA As String
        Get
            Return E_ID_CODIGO_FONASA
        End Get
        Set(value As String)
            E_ID_CODIGO_FONASA = value
        End Set
    End Property

    Public Property SITIO_ANATO As String
        Get
            Return E_SITIO_ANATO
        End Get
        Set(value As String)
            E_SITIO_ANATO = value
        End Set
    End Property

    Public Property IS_ANATO As Boolean
        Get
            Return E_IS_ANATO
        End Get
        Set(value As Boolean)
            E_IS_ANATO = value
        End Set
    End Property

    Public Property ATE_RESULTADO As String
        Get
            Return E_ATE_RESULTADO
        End Get
        Set(value As String)
            E_ATE_RESULTADO = value
        End Set
    End Property

    Public Property ID_ATE_RES As String
        Get
            Return E_ID_ATE_RES
        End Get
        Set(value As String)
            E_ID_ATE_RES = value
        End Set
    End Property
End Class