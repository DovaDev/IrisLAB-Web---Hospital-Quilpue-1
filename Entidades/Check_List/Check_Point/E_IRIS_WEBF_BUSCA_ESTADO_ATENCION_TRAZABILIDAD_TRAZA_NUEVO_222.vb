Public Class E_IRIS_WEBF_BUSCA_ESTADO_ATENCION_TRAZABILIDAD_TRAZA_NUEVO_222
    Dim EE_CB_DESC As String
    Dim EE_ID_ATENCION As Integer
    Dim EE_ID_PER As Integer
    Dim EE_ID_PRUEBA As Integer
    Dim EE_ATE_FEC_TM As Date
    Dim EE_ATE_USU_TM As String
    Dim EE_ATE_EST_TM As String
    Dim EE_EST1 As String
    Dim EE_ATE_FEC_RECEP As Date
    Dim EE_ATE_USU_RECEP As String
    Dim EE_ATE_EST_RECEP As String
    Dim EE_EST2 As String
    Dim EE_ATE_FEC_VALIDA As Date
    Dim EE_ATE_USU_VALIDA As String
    Dim EE_ATE_EST_VALIDA As String
    Dim EE_EST3 As String
    Dim EE_ATE_FEC_DERIVA As Date
    Dim EE_ATE_USU_DERIVA As String
    Dim EE_ATE_EST_DERIVA As String
    Dim EE_ATE_FEC_RECHAZO As Date
    Dim EE_ATE_USU_RECHAZO As String
    Dim EE_ATE_EST_RECHAZO As String
    Dim EE_EST_D As String
    Dim EE_EST_R As String
    Dim EE_UTM As String
    Dim EE_URECEP As String
    Dim EE_UVALIDA As String
    Dim EE_URECHAZO As String
    Dim EE_UDERI As String
    Dim EE_ID_ESTADO As Integer

    Dim EE_ATE_FEC_ENVIO As Date
    Dim EE_UENVIO As String
    Dim EE_EST_E As String
    Dim EE_ATE_EST_ENVIO As String
    Dim EE_ENVIO_FECHA_RECEP As Date
    Dim EE_ID_USUARIO_RECEP As Integer
    Dim EE_ID_ESTADO_RECEP As Integer
    Dim EE_USUARIO_ENV_RECEP As String
    Public Property USUARIO_ENV_RECEP As String
        Get
            Return EE_USUARIO_ENV_RECEP
        End Get
        Set(value As String)
            EE_USUARIO_ENV_RECEP = value
        End Set
    End Property
    Public Property ID_ESTADO_RECEP As Integer
        Get
            Return EE_ID_ESTADO_RECEP
        End Get
        Set(value As Integer)
            EE_ID_ESTADO_RECEP = value
        End Set
    End Property
    Public Property ID_USUARIO_RECEP As Integer
        Get
            Return EE_ID_USUARIO_RECEP
        End Get
        Set(value As Integer)
            EE_ID_USUARIO_RECEP = value
        End Set
    End Property
    Public Property ENVIO_FECHA_RECEP As Date
        Get
            Return EE_ENVIO_FECHA_RECEP
        End Get
        Set(value As Date)
            EE_ENVIO_FECHA_RECEP = value
        End Set
    End Property
    Public Property ATE_EST_ENVIO As String
        Get
            Return EE_ATE_EST_ENVIO
        End Get
        Set(value As String)
            EE_ATE_EST_ENVIO = value
        End Set
    End Property
    Public Property ATE_FEC_ENVIO As Date
        Get
            Return EE_ATE_FEC_ENVIO
        End Get
        Set(value As Date)
            EE_ATE_FEC_ENVIO = value
        End Set
    End Property
    Public Property UENVIO As String
        Get
            Return EE_UENVIO
        End Get
        Set(value As String)
            EE_UENVIO = value
        End Set
    End Property

    Public Property EST_E As String
        Get
            Return EE_EST_E
        End Get
        Set(value As String)
            EE_EST_E = value
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

    Public Property ATE_FEC_TM As Date
        Get
            Return EE_ATE_FEC_TM
        End Get
        Set(value As Date)
            EE_ATE_FEC_TM = value
        End Set
    End Property

    Public Property ATE_USU_TM As String
        Get
            Return EE_ATE_USU_TM
        End Get
        Set(value As String)
            EE_ATE_USU_TM = value
        End Set
    End Property

    Public Property ATE_EST_TM As String
        Get
            Return EE_ATE_EST_TM
        End Get
        Set(value As String)
            EE_ATE_EST_TM = value
        End Set
    End Property

    Public Property EST1 As String
        Get
            Return EE_EST1
        End Get
        Set(value As String)
            EE_EST1 = value
        End Set
    End Property

    Public Property ATE_FEC_RECEP As Date
        Get
            Return EE_ATE_FEC_RECEP
        End Get
        Set(value As Date)
            EE_ATE_FEC_RECEP = value
        End Set
    End Property

    Public Property ATE_USU_RECEP As String
        Get
            Return EE_ATE_USU_RECEP
        End Get
        Set(value As String)
            EE_ATE_USU_RECEP = value
        End Set
    End Property

    Public Property ATE_EST_RECEP As String
        Get
            Return EE_ATE_EST_RECEP
        End Get
        Set(value As String)
            EE_ATE_EST_RECEP = value
        End Set
    End Property

    Public Property EST2 As String
        Get
            Return EE_EST2
        End Get
        Set(value As String)
            EE_EST2 = value
        End Set
    End Property

    Public Property ATE_FEC_VALIDA As Date
        Get
            Return EE_ATE_FEC_VALIDA
        End Get
        Set(value As Date)
            EE_ATE_FEC_VALIDA = value
        End Set
    End Property

    Public Property ATE_USU_VALIDA As String
        Get
            Return EE_ATE_USU_VALIDA
        End Get
        Set(value As String)
            EE_ATE_USU_VALIDA = value
        End Set
    End Property

    Public Property ATE_EST_VALIDA As String
        Get
            Return EE_ATE_EST_VALIDA
        End Get
        Set(value As String)
            EE_ATE_EST_VALIDA = value
        End Set
    End Property

    Public Property EST3 As String
        Get
            Return EE_EST3
        End Get
        Set(value As String)
            EE_EST3 = value
        End Set
    End Property

    Public Property ATE_FEC_DERIVA As Date
        Get
            Return EE_ATE_FEC_DERIVA
        End Get
        Set(value As Date)
            EE_ATE_FEC_DERIVA = value
        End Set
    End Property

    Public Property ATE_USU_DERIVA As String
        Get
            Return EE_ATE_USU_DERIVA
        End Get
        Set(value As String)
            EE_ATE_USU_DERIVA = value
        End Set
    End Property

    Public Property ATE_EST_DERIVA As String
        Get
            Return EE_ATE_EST_DERIVA
        End Get
        Set(value As String)
            EE_ATE_EST_DERIVA = value
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

    Public Property EST_D As String
        Get
            Return EE_EST_D
        End Get
        Set(value As String)
            EE_EST_D = value
        End Set
    End Property

    Public Property EST_R As String
        Get
            Return EE_EST_R
        End Get
        Set(value As String)
            EE_EST_R = value
        End Set
    End Property

    Public Property UTM As String
        Get
            Return EE_UTM
        End Get
        Set(value As String)
            EE_UTM = value
        End Set
    End Property

    Public Property URECEP As String
        Get
            Return EE_URECEP
        End Get
        Set(value As String)
            EE_URECEP = value
        End Set
    End Property

    Public Property UVALIDA As String
        Get
            Return EE_UVALIDA
        End Get
        Set(value As String)
            EE_UVALIDA = value
        End Set
    End Property

    Public Property URECHAZO As String
        Get
            Return EE_URECHAZO
        End Get
        Set(value As String)
            EE_URECHAZO = value
        End Set
    End Property

    Public Property UDERI As String
        Get
            Return EE_UDERI
        End Get
        Set(value As String)
            EE_UDERI = value
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
End Class
