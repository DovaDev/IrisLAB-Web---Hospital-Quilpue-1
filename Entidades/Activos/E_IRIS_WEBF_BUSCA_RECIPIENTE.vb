Public Class E_IRIS_WEBF_BUSCA_RECIPIENTE
    Private EE_ID_GMUE As Integer
    Private EE_GMUE_COD As String
    Private EE_GMUE_DES As String
    Private EE_ID_ESTADO As Integer
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property GMUE_DES() As String
        Get
            Return EE_GMUE_DES
        End Get
        Set(ByVal value As String)
            EE_GMUE_DES = value
        End Set
    End Property
    Public Property GMUE_COD() As String
        Get
            Return EE_GMUE_COD
        End Get
        Set(ByVal value As String)
            EE_GMUE_COD = value
        End Set
    End Property


    Public Property ID_GMUE() As Integer
        Get
            Return EE_ID_GMUE
        End Get
        Set(ByVal value As Integer)
            EE_ID_GMUE = value
        End Set
    End Property
End Class
