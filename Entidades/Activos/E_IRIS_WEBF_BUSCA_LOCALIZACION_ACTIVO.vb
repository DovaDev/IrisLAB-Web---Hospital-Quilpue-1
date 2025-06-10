Public Class E_IRIS_WEBF_BUSCA_LOCALIZACION_ACTIVO
    Dim EE_ID_LOCAL As Integer
    Dim EE_LOCAL_COD As String
    Dim EE_LOCAL_DESC As String
    Dim EE_ID_ESTADO As String
    Public Property ID_LOCAL As Integer
        Get
            Return EE_ID_LOCAL
        End Get
        Set(value As Integer)
            EE_ID_LOCAL = value
        End Set
    End Property
    Public Property LOCAL_COD As String
        Get
            Return EE_LOCAL_COD
        End Get
        Set(value As String)
            EE_LOCAL_COD = value
        End Set
    End Property
    Public Property LOCAL_DESC As String
        Get
            Return EE_LOCAL_DESC
        End Get
        Set(value As String)
            EE_LOCAL_DESC = value
        End Set
    End Property
    Public Property ID_ESTADO As String
        Get
            Return EE_ID_ESTADO
        End Get
        Set(value As String)
            EE_ID_ESTADO = value
        End Set
    End Property
End Class
