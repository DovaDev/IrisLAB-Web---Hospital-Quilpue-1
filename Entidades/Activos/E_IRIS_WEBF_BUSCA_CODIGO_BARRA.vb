Public Class E_IRIS_WEBF_BUSCA_CODIGO_BARRA
    Private EE_ID_CB As Integer
    Private EE_CB_COD As String
    Private EE_CB_DES As String
    Private EE_ID_ESTADO As String
    Public Property ID_ESTADO() As String
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As String)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property CB_DES() As String
        Get
            Return EE_CB_DES
        End Get
        Set(ByVal value As String)
            EE_CB_DES = value
        End Set
    End Property
    Public Property CB_COD() As String
        Get
            Return EE_CB_COD
        End Get
        Set(ByVal value As String)
            EE_CB_COD = value
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
End Class
