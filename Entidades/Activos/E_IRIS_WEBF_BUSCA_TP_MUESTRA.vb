Public Class E_IRIS_WEBF_BUSCA_TP_MUESTRA
    Private EE_ID_RE As Integer
    Private EE_RE_COD As String
    Private EE_RE_DES As String
    Private EE_ID_CB As Integer
    Private EE_ID_RECEP As Integer
    Private EE_ID_ESTADO As Integer
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property ID_RECEP() As Integer
        Get
            Return EE_ID_RECEP
        End Get
        Set(ByVal value As Integer)
            EE_ID_RECEP = value
        End Set
    End Property
    Public Property ID_CB() As Integer
        Get
            Return EE_ID_CB
        End Get
        Set(ByVal value As Integer)
            EE_ID_CB = value
        End Set
    End Property
    Public Property RE_DES() As String
        Get
            Return EE_RE_DES
        End Get
        Set(ByVal value As String)
            EE_RE_DES = value
        End Set
    End Property
    Public Property RE_COD() As String
        Get
            Return EE_RE_COD
        End Get
        Set(ByVal value As String)
            EE_RE_COD = value
        End Set
    End Property
    Public Property ID_RE() As Integer
        Get
            Return EE_ID_RE
        End Get
        Set(ByVal value As Integer)
            EE_ID_RE = value
        End Set
    End Property
End Class
