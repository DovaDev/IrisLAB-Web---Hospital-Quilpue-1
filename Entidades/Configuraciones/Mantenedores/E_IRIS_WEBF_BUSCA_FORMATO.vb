Public Class E_IRIS_WEBF_BUSCA_FORMATO
    Dim EE_ID_FORMATO As Integer
    Dim EE_FORMATO_COD As String
    Dim EE_ID_PER As Integer
    Dim EE_ID_ESTADO As Integer


    Public Property ID_FORMATO As Integer
        Get
            Return EE_ID_FORMATO
        End Get
        Set(value As Integer)
            EE_ID_FORMATO = value
        End Set
    End Property

    Public Property FORMATO_COD As String
        Get
            Return EE_FORMATO_COD
        End Get
        Set(value As String)
            EE_FORMATO_COD = value
        End Set
    End Property

    Public Property ID_PER As Integer
        Get
            Return EE_ID_PER
        End Get
        Set(value As Integer)
            EE_ID_PER = value
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
