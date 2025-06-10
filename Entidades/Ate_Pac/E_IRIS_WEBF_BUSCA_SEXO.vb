Public Class E_IRIS_WEBF_BUSCA_SEXO
    Dim EE_ID_SEXO As Integer
    Dim EE_SEXO_COD As String
    Dim EE_SEXO_DESC As String
    Dim EE_ID_ESTADO As String
    Public Property ID_SEXO As Integer
        Get
            Return EE_ID_SEXO
        End Get
        Set(value As Integer)
            EE_ID_SEXO = value
        End Set
    End Property
    Public Property SEXO_COD As String
        Get
            Return EE_SEXO_COD
        End Get
        Set(value As String)
            EE_SEXO_COD = value
        End Set
    End Property
    Public Property SEXO_DESC As String
        Get
            Return EE_SEXO_DESC
        End Get
        Set(value As String)
            EE_SEXO_DESC = value
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
