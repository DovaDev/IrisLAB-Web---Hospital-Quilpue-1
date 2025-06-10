Public Class E_IRIS_WEBF_BUSCA_ESTADO_DETERMINACION_RECEPCION_MUESTRA_RECHAZO
    Dim EE_CB_DESC As String
    Dim EE_ID_ATENCION As Integer
    Dim EE_ID_PER As Integer
    Dim EE_ID_PRUEBA As Integer
    Dim EE_ATE_FEC_RECHAZO As Date
    Dim EE_ATE_USU_RECHAZO As String
    Dim EE_ATE_EST_RECHAZO As String
    Dim EE_EST_DESCRIPCION As String
    Dim EE_PAC_NOMBRE As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_ATE_NUM As Integer
    Dim EE_ATE_NUM_OMI As String
    Dim EE_ID_CODIGO_FONASA As Integer
    Dim EE_ATE_CODIGO_TEST As String

    Public Property TP_RECHA_DESC As String
    Public Property ATE_CODIGO_TEST As String
        Get
            Return EE_ATE_CODIGO_TEST
        End Get
        Set(value As String)
            EE_ATE_CODIGO_TEST = value
        End Set
    End Property

    Public Property ID_CODIGO_FONASA As Integer
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(value As Integer)
            EE_ID_CODIGO_FONASA = value
        End Set
    End Property

    Public Property ATE_NUM_OMI As String
        Get
            Return EE_ATE_NUM_OMI
        End Get
        Set(value As String)
            EE_ATE_NUM_OMI = value
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

    Public Property ID_ATENCION As Integer
        Get
            Return EE_ID_ATENCION
        End Get
        Set(value As Integer)
            EE_ID_ATENCION = value
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

    Public Property ID_PRUEBA As Integer
        Get
            Return EE_ID_PRUEBA
        End Get
        Set(value As Integer)
            EE_ID_PRUEBA = value
        End Set
    End Property

    Public Property ATE_FEC_RECHAZO As Date
        Get
            Return EE_ATE_FEC_RECHAZO
        End Get
        Set(value As Date)
            EE_ATE_FEC_RECHAZO = value
        End Set
    End Property

    Public Property ATE_USU_RECHAZO As String
        Get
            Return EE_ATE_USU_RECHAZO
        End Get
        Set(value As String)
            EE_ATE_USU_RECHAZO = value
        End Set
    End Property

    Public Property ATE_EST_RECHAZO As String
        Get
            Return EE_ATE_EST_RECHAZO
        End Get
        Set(value As String)
            EE_ATE_EST_RECHAZO = value
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

    Public Property ATE_NUM As Integer
        Get
            Return EE_ATE_NUM
        End Get
        Set(value As Integer)
            EE_ATE_NUM = value
        End Set
    End Property
End Class
