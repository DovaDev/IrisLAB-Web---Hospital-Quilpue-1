Public Class E_IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO
    Dim EE_IDPRO As Long
    Dim EE_ID_PREVE As Long
    Dim EE_ID_ESTADO As Integer
    Dim EE_PROGRA_DESC As String
    Dim EE_ESTADO As Integer
    Public Property ID_PROGRA As Long
        Get
            Return EE_IDPRO
        End Get
        Set(value As Long)
            EE_IDPRO = value
        End Set
    End Property
    Public Property ID_PREVE As Long
        Get
            Return EE_ID_PREVE
        End Get
        Set(value As Long)
            EE_ID_PREVE = value
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
    Public Property PROGRA_DESC As String
        Get
            Return EE_PROGRA_DESC
        End Get
        Set(value As String)
            EE_PROGRA_DESC = value
        End Set
    End Property
    Public Property ESTADO As Integer
        Get
            Return EE_ESTADO
        End Get
        Set(value As Integer)
            EE_ESTADO = value
        End Set
    End Property
End Class
