Public Class E_IRIS_WEBF_UPDATE_ESTADO_PRECIOS_FONASA_PREVISION
    Private EE_ID_ANO As Integer
    Private EE_ID_USARIO As Integer
    Private EE_ID_FONASA As Integer
    Private EE_ID_ESTADO As Integer
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property ID_FONASA() As Integer
        Get
            Return EE_ID_FONASA
        End Get
        Set(ByVal value As Integer)
            EE_ID_FONASA = value
        End Set
    End Property
    Public Property ID_ANO() As Integer
        Get
            Return EE_ID_ANO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ANO = value
        End Set
    End Property
    Public Property ID_USUARIO() As Integer
        Get
            Return EE_ID_USARIO
        End Get
        Set(ByVal value As Integer)
            EE_ID_USARIO = value
        End Set
    End Property
End Class
