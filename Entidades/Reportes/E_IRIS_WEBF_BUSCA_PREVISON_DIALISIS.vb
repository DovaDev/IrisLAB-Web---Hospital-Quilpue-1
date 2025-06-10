Public Class E_IRIS_WEBF_BUSCA_PREVISON_DIALISIS
    Dim EE_ID_PREVE As Integer
    Dim EE_PREVE_DESC As String
    Dim EE_PREVE_DIA As Integer
    Dim EE_PREVE_DIA_ORD As Integer

    Public Property ID_PREVE As Integer
        Get
            Return EE_ID_PREVE
        End Get
        Set(value As Integer)
            EE_ID_PREVE = value
        End Set
    End Property

    Public Property PREVE_DESC As String
        Get
            Return EE_PREVE_DESC
        End Get
        Set(value As String)
            EE_PREVE_DESC = value
        End Set
    End Property

    Public Property PREVE_DIA As Integer
        Get
            Return EE_PREVE_DIA
        End Get
        Set(value As Integer)
            EE_PREVE_DIA = value
        End Set
    End Property

    Public Property PREVE_DIA_ORD As Integer
        Get
            Return EE_PREVE_DIA_ORD
        End Get
        Set(value As Integer)
            EE_PREVE_DIA_ORD = value
        End Set
    End Property
End Class
