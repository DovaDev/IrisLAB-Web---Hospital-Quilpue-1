Public Class E_ESTUDIO_CLINICO

    Private EE_ID_PER As Integer
    Private EE_PER_COD As String
    Private EE_PER_DESC As String
    Private EE_PER_CORTO As String
    Private EE_PER_HOST1 As String
    Private EE_PER_HOST2 As String
    Private EE_PER_BAC_EST As Integer
    Private EE_ID_ESTADO As Integer
    Private EE_PER_NUM_PRU As Integer
    Private EE_ID_RLS_LS As Integer
    Private EE_RLS_LS_DESC As String

    Public Property ID_PER As Integer
        Get
            Return EE_ID_PER
        End Get
        Set(value As Integer)
            EE_ID_PER = value
        End Set
    End Property

    Public Property PER_COD As String
        Get
            Return EE_PER_COD
        End Get
        Set(value As String)
            EE_PER_COD = value
        End Set
    End Property

    Public Property PER_DESC As String
        Get
            Return EE_PER_DESC
        End Get
        Set(value As String)
            EE_PER_DESC = value
        End Set
    End Property

    Public Property PER_CORTO As String
        Get
            Return EE_PER_CORTO
        End Get
        Set(value As String)
            EE_PER_CORTO = value
        End Set
    End Property

    Public Property PER_HOST1 As String
        Get
            Return EE_PER_HOST1
        End Get
        Set(value As String)
            EE_PER_HOST1 = value
        End Set
    End Property

    Public Property PER_HOST2 As String
        Get
            Return EE_PER_HOST2
        End Get
        Set(value As String)
            EE_PER_HOST2 = value
        End Set
    End Property

    Public Property PER_BAC_EST As Integer
        Get
            Return EE_PER_BAC_EST
        End Get
        Set(value As Integer)
            EE_PER_BAC_EST = value
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

    Public Property PER_NUM_PRU As Integer
        Get
            Return EE_PER_NUM_PRU
        End Get
        Set(value As Integer)
            EE_PER_NUM_PRU = value
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

    Public Property RLS_LS_DESC As String
        Get
            Return EE_RLS_LS_DESC
        End Get
        Set(value As String)
            EE_RLS_LS_DESC = value
        End Set
    End Property
End Class
