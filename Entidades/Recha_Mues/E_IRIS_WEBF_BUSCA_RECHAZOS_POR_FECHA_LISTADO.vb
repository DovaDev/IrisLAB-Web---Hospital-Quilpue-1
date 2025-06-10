Public Class E_IRIS_WEBF_BUSCA_RECHAZOS_POR_FECHA_LISTADO
    Dim EE_ID_LOTE_RECHAZO As Integer
    Dim EE_LOTE_RECHAZO_NUM As String
    Dim EE_ID_USUARIO As Integer
    Dim EE_LOTE_RECHAZO_FECHA As Date
    Dim EE_ID_ESTADO As Integer

    Public Property ID_LOTE_RECHAZO As Integer
        Get
            Return EE_ID_LOTE_RECHAZO
        End Get
        Set(value As Integer)
            EE_ID_LOTE_RECHAZO = value
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

    Public Property ID_USUARIO As Integer
        Get
            Return EE_ID_USUARIO
        End Get
        Set(value As Integer)
            EE_ID_USUARIO = value
        End Set
    End Property

    Public Property LOTE_RECHAZO_FECHA As Date
        Get
            Return EE_LOTE_RECHAZO_FECHA
        End Get
        Set(value As Date)
            EE_LOTE_RECHAZO_FECHA = value
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
