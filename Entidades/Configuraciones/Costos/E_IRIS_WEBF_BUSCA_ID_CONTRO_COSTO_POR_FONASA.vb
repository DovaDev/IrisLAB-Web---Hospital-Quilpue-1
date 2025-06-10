Public Class E_IRIS_WEBF_BUSCA_ID_CONTRO_COSTO_POR_FONASA
    Private EE_ID_CODIGO_FONASA As Integer
    Public Property ID_CODIGO_FONASA() As Integer
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(ByVal value As Integer)
            EE_ID_CODIGO_FONASA = value
        End Set
    End Property

    Private EE_ID_CONTROL_COSTO As Integer
    Public Property ID_CONTROL_COSTO() As Integer
        Get
            Return EE_ID_CONTROL_COSTO
        End Get
        Set(ByVal value As Integer)
            EE_ID_CONTROL_COSTO = value
        End Set
    End Property
    Private EE_ID_ESTADO As Integer
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Private EE_CONTROL_COSTO_NUM As Integer
    Public Property CONTROL_COSTO_NUM() As Integer
        Get
            Return EE_CONTROL_COSTO_NUM
        End Get
        Set(ByVal value As Integer)
            EE_CONTROL_COSTO_NUM = value
        End Set
    End Property
    Private EE_EXIST As String
    Public Property EXIST() As String
        Get
            Return EE_EXIST
        End Get
        Set(ByVal value As String)
            EE_EXIST = value
        End Set
    End Property
    Private EE_COUNT_DET As Integer
    Public Property COUNT_DET() As Integer
        Get
            Return EE_COUNT_DET
        End Get
        Set(ByVal value As Integer)
            EE_COUNT_DET = value
        End Set
    End Property
End Class