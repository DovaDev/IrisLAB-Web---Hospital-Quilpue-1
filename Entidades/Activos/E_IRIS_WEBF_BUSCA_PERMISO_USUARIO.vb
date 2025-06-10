Public Class E_IRIS_WEBF_BUSCA_PERMISO_USUARIO
    Dim EE_ID_PER_USU As Integer
    Dim EE_PER_USU_COD As String
    Dim EE_PER_USU_DESC As String
    Dim EE_ID_ESTADO As Integer
    Public Property ID_PER_USU As Integer
        Get
            Return EE_ID_PER_USU
        End Get
        Set(value As Integer)
            EE_ID_PER_USU = value
        End Set
    End Property
    Public Property PER_USU_COD As String
        Get
            Return EE_PER_USU_COD
        End Get
        Set(value As String)
            EE_PER_USU_COD = value
        End Set
    End Property
    Public Property PER_USU_DESC As String
        Get
            Return EE_PER_USU_DESC
        End Get
        Set(value As String)
            EE_PER_USU_DESC = value
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
