Public Class E_IRIS_WEBF_BUSCA_METODO
    Dim EE_ID_METODO As Integer
    Dim EE_METO_COD As String
    Dim EE_METO_DESC As String
    Dim EE_ID_ESTADO As Integer
    Public Property ID_METODO As Integer
        Get
            Return EE_ID_METODO
        End Get
        Set(value As Integer)
            EE_ID_METODO = value
        End Set
    End Property
    Public Property METO_COD As String
        Get
            Return EE_METO_COD
        End Get
        Set(value As String)
            EE_METO_COD = value
        End Set
    End Property
    Public Property METO_DESC As String
        Get
            Return EE_METO_DESC
        End Get
        Set(value As String)
            EE_METO_DESC = value
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
