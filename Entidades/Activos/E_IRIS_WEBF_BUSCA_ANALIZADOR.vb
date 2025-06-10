Public Class E_IRIS_WEBF_BUSCA_ANALIZADOR
    Private EE_ID_ANAL As Integer
    Private EE_ANAL_COD As String
    Private EE_ANAL_DESC As String
    Private EE_ID_ESTADO As Integer

    Public Property ID_ANAL As Integer
        Get
            Return EE_ID_ANAL
        End Get
        Set(value As Integer)
            EE_ID_ANAL = value
        End Set
    End Property

    Public Property ANAL_COD As String
        Get
            Return EE_ANAL_COD
        End Get
        Set(value As String)
            EE_ANAL_COD = value
        End Set
    End Property

    Public Property ANAL_DESC As String
        Get
            Return EE_ANAL_DESC
        End Get
        Set(value As String)
            EE_ANAL_DESC = value
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