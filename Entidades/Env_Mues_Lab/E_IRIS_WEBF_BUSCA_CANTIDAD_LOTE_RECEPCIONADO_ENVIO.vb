Public Class E_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO
    Dim EE_ENVIO_NUM As Integer
    Dim EE_ID_USUARIO As Integer
    Dim EE_ENVIO_FECHA As Date
    Dim EE_USU_NIC As String
    Dim EE_ID_ESTADO_RECEP As String

    Public Property ID_ESTADO_RECEP As String
        Get
            Return EE_ID_ESTADO_RECEP
        End Get
        Set(value As String)
            EE_ID_ESTADO_RECEP = value
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

    Public Property ID_USUARIO As Integer
        Get
            Return EE_ID_USUARIO
        End Get
        Set(value As Integer)
            EE_ID_USUARIO = value
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

    Public Property USU_NIC As String
        Get
            Return EE_USU_NIC
        End Get
        Set(value As String)
            EE_USU_NIC = value
        End Set
    End Property
End Class
