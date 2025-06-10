Public Class E_IRIS_WEBF_BUSCA_GENERO
    Dim EE_ID_GENERO As Integer
    Dim EE_GENERO_DESC As String
    Dim EE_ID_ESTADO As Integer

    Public Property ID_GENERO As Integer
        Get
            Return EE_ID_GENERO
        End Get
        Set(value As Integer)
            EE_ID_GENERO = value
        End Set
    End Property

    Public Property GENERO_DESC As String
        Get
            Return EE_GENERO_DESC
        End Get
        Set(value As String)
            EE_GENERO_DESC = value
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
