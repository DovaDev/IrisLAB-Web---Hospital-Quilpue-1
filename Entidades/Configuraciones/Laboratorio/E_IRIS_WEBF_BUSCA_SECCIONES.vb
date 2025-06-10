Public Class E_IRIS_WEBF_BUSCA_SECCIONES
    Private EE_ID_SECCION As Integer
    Private EE_SECC_COD As String
    Private EE_SEC_DESC As String
    Private EE_ID_ESTADO As Integer
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property SECC_DESC() As String
        Get
            Return EE_SEC_DESC
        End Get
        Set(ByVal value As String)
            EE_SEC_DESC = value
        End Set
    End Property
    Public Property SECC_COD() As String
        Get
            Return EE_SECC_COD
        End Get
        Set(ByVal value As String)
            EE_SECC_COD = value
        End Set
    End Property
    Public Property ID_SECCION() As Integer
        Get
            Return EE_ID_SECCION
        End Get
        Set(ByVal value As Integer)
            EE_ID_SECCION = value
        End Set
    End Property
End Class
