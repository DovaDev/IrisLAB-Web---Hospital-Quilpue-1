Public Class E_IRIS_WEBF_BUSCA_NACIONALIDAD
    Dim EE_ID_NACIONALIDAD As Integer
    Dim EE_NAC_COD As String
    Dim EE_NAC_DESC As String
    Dim EE_ID_ESTADO As String
    Public Property ID_NACIONALIDAD As Integer
        Get
            Return EE_ID_NACIONALIDAD
        End Get
        Set(value As Integer)
            EE_ID_NACIONALIDAD = value
        End Set
    End Property
    Public Property NAC_COD As String
        Get
            Return EE_NAC_COD
        End Get
        Set(value As String)
            EE_NAC_COD = value
        End Set
    End Property
    Public Property NAC_DESC As String
        Get
            Return EE_NAC_DESC
        End Get
        Set(value As String)
            EE_NAC_DESC = value
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
