Public Class E_IRIS_WEBF_BUSCA_EMPRESA_ACTIVOS_TODOS
    Dim EE_ID_EMPRESA As Integer
    Dim EE_EMPRESA_COD As String
    Dim EE_EMPRESA_DESC As String
    Dim EE_ID_ESTADO As Integer

    Public Property ID_EMPRESA As Integer
        Get
            Return EE_ID_EMPRESA
        End Get
        Set(value As Integer)
            EE_ID_EMPRESA = value
        End Set
    End Property

    Public Property EMPRESA_COD As String
        Get
            Return EE_EMPRESA_COD
        End Get
        Set(value As String)
            EE_EMPRESA_COD = value
        End Set
    End Property

    Public Property EMPRESA_DESC As String
        Get
            Return EE_EMPRESA_DESC
        End Get
        Set(value As String)
            EE_EMPRESA_DESC = value
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
