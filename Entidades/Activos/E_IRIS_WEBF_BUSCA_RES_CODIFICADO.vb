Public Class E_IRIS_WEBF_BUSCA_RES_CODIFICADO
    Private EE_ID_RES_COD As Integer
    Private EE_RES_COD_COD As String
    Private EE_RES_COD_DESC As String
    Private EE_ID_ESTADO As Integer
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property RES_COD_DESC() As String
        Get
            Return EE_RES_COD_DESC
        End Get
        Set(ByVal value As String)
            EE_RES_COD_DESC = value
        End Set
    End Property
    Public Property RES_COD_COD() As String
        Get
            Return EE_RES_COD_COD
        End Get
        Set(ByVal value As String)
            EE_RES_COD_COD = value
        End Set
    End Property
    Public Property ID_RES_COD() As Integer
        Get
            Return EE_ID_RES_COD
        End Get
        Set(ByVal value As Integer)
            EE_ID_RES_COD = value
        End Set
    End Property
End Class
