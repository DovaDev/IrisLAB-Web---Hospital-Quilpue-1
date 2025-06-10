Public Class E_IRIS_WEBF_BUSCA_PACK_CF
    Dim EE_ID_PACK As Integer
    Dim EE_PACK_COD As String
    Dim EE_PACK_DESC As String
    Dim EE_ID_ESTADO As Integer
    Dim EE_ID_REL_PACK_CF As Integer

    Public Property ID_PACK As Integer
        Get
            Return EE_ID_PACK
        End Get
        Set(value As Integer)
            EE_ID_PACK = value
        End Set
    End Property

    Public Property PACK_COD As String
        Get
            Return EE_PACK_COD
        End Get
        Set(value As String)
            EE_PACK_COD = value
        End Set
    End Property

    Public Property PACK_DESC As String
        Get
            Return EE_PACK_DESC
        End Get
        Set(value As String)
            EE_PACK_DESC = value
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

    Public Property ID_REL_PACK_CF As Integer
        Get
            Return EE_ID_REL_PACK_CF
        End Get
        Set(value As Integer)
            EE_ID_REL_PACK_CF = value
        End Set
    End Property
End Class
