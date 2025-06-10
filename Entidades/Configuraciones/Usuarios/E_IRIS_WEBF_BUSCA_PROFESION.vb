Public Class E_IRIS_WEBF_BUSCA_PROFESION
    Private EE_ID_PRO As Integer
    Private EE_PRO_COD As String
    Private EE_PRO_DESC As String
    Private EE_ID_ESTADO As Integer
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property PRO_DESC() As String
        Get
            Return EE_PRO_DESC
        End Get
        Set(ByVal value As String)
            EE_PRO_DESC = value
        End Set
    End Property
    Public Property PRO_COD() As String
        Get
            Return EE_PRO_COD
        End Get
        Set(ByVal value As String)
            EE_PRO_COD = value
        End Set
    End Property
    Public Property ID_PRO() As Integer
        Get
            Return EE_ID_PRO
        End Get
        Set(ByVal value As Integer)
            EE_ID_PRO = value
        End Set
    End Property
End Class
