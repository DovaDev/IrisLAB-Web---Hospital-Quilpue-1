Public Class E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
    Dim EE_ID_PREVE As Integer
    Dim EE_PREVE_COD As String
    Dim EE_PREVE_DESC As String
    Dim EE_ID_ESTADO As Integer
    Dim EE_PREVE_PART_WEB As Integer
    Dim EE_PREVE_PARTICULAR As Integer

    Public Property PREVE_PARTICULAR As Integer
        Get
            Return EE_PREVE_PARTICULAR
        End Get
        Set(value As Integer)
            EE_PREVE_PARTICULAR = value
        End Set
    End Property
    Public Property PREVE_PART_WEB As Integer
        Get
            Return EE_PREVE_PART_WEB
        End Get
        Set(value As Integer)
            EE_PREVE_PART_WEB = value
        End Set
    End Property
    Public Property ID_PREVE As Integer
        Get
            Return EE_ID_PREVE
        End Get
        Set(value As Integer)
            EE_ID_PREVE = value
        End Set
    End Property
    Public Property PREVE_COD As String
        Get
            Return EE_PREVE_COD
        End Get
        Set(value As String)
            EE_PREVE_COD = value
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
    Public Property ID_ESTADO As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
End Class

