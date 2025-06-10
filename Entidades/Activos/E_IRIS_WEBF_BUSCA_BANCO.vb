Public Class E_IRIS_WEBF_BUSCA_BANCO
    Dim EE_ID_BANCO As Integer
    Dim EE_BAN_COD As String
    Dim EE_BAN_DESC As String
    Dim EE_ID_ESTADO As Integer
    Public Property ID_BANCO As Integer
        Get
            Return EE_ID_BANCO
        End Get
        Set(value As Integer)
            EE_ID_BANCO = value
        End Set
    End Property
    Public Property BAN_COD As String
        Get
            Return EE_BAN_COD
        End Get
        Set(value As String)
            EE_BAN_COD = value
        End Set
    End Property
    Public Property BAN_DESC As String
        Get
            Return EE_BAN_DESC
        End Get
        Set(value As String)
            EE_BAN_DESC = value
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
