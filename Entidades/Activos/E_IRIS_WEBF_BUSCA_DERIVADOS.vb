Public Class E_IRIS_WEBF_BUSCA_DERIVADOS
    Dim EE_ID_DERIVADO As Integer
    Dim EE_DERI_DESC As String
    Dim EE_ID_ESTADO As Integer
    Dim EE_DERI_COD As String

    Public Property ID_DERIVADO As Integer
        Get
            Return EE_ID_DERIVADO
        End Get
        Set(value As Integer)
            EE_ID_DERIVADO = value
        End Set
    End Property

    Public Property DERI_DESC As String
        Get
            Return EE_DERI_DESC
        End Get
        Set(value As String)
            EE_DERI_DESC = value
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

    Public Property DERI_COD As String
        Get
            Return EE_DERI_COD
        End Get
        Set(value As String)
            EE_DERI_COD = value
        End Set
    End Property
End Class
