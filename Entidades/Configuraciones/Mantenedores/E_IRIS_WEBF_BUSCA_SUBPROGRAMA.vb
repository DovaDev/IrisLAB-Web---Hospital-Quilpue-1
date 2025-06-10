Public Class E_IRIS_WEBF_BUSCA_SUBPROGRAMA
    Dim E_ID_SUBP As Long
    Dim E_SUBP_COD As String
    Dim E_SUBP_DESC As String
    Dim E_ID_ESTADO As Long
    Dim E_CHECK As Integer
    Public Property CHECK As Long
        Get
            Return E_CHECK
        End Get
        Set(value As Long)
            E_CHECK = value
        End Set
    End Property

    Public Property ID_ESTADO As Long
        Get
            Return E_ID_ESTADO
        End Get
        Set(value As Long)
            E_ID_ESTADO = value
        End Set
    End Property
    Public Property SUBP_DESC As String
        Get
            Return E_SUBP_DESC
        End Get
        Set(value As String)
            E_SUBP_DESC = value
        End Set
    End Property
    Public Property SUBP_COD As String
        Get
            Return E_SUBP_COD
        End Get
        Set(value As String)
            E_SUBP_COD = value
        End Set
    End Property
    Public Property ID_SUBP As Long
        Get
            Return E_ID_SUBP
        End Get
        Set(value As Long)
            E_ID_SUBP = value
        End Set
    End Property


End Class
