Public Class E_IRIS_WEBF_BUSCA_REL_PROGRAMA_SUBPROGRAMA
    Dim EE_ID_SUBP As Integer
    Dim EE_SUBP_COD As String
    Dim EE_SUBP_DESC As String
    Dim EE_ID_ESTADO As String

    Public Property ID_SUBP As Integer
        Get
            Return EE_ID_SUBP
        End Get
        Set(value As Integer)
            EE_ID_SUBP = value
        End Set
    End Property

    Public Property SUBP_COD As String
        Get
            Return EE_SUBP_COD
        End Get
        Set(value As String)
            EE_SUBP_COD = value
        End Set
    End Property

    Public Property SUBP_DESC As String
        Get
            Return EE_SUBP_DESC
        End Get
        Set(value As String)
            EE_SUBP_DESC = value
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
