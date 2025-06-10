Public Class E_IRIS_WEBF_BUSCA_RELACION_PREV_PROCE_POR_ID_PREV
    Dim E_ID_ESTADO As Integer
    Dim E_PROC_DESC As String
    Dim E_PREVE_DESC As String
    Dim E_ID_PREVE As Long
    Dim E_ID_PROCEDENCIA As Long
    Public Property ID_ESTADO As Integer
        Get
            Return E_ID_ESTADO
        End Get
        Set(value As Integer)
            E_ID_ESTADO = value
        End Set
    End Property
    Public Property PROC_DESC As String
        Get
            Return E_PROC_DESC
        End Get
        Set(value As String)
            E_PROC_DESC = value
        End Set
    End Property
    Public Property PREVE_DESC As String
        Get
            Return E_PREVE_DESC
        End Get
        Set(value As String)
            E_PREVE_DESC = value
        End Set
    End Property
    Public Property ID_PREVE As Long
        Get
            Return E_ID_PREVE
        End Get
        Set(value As Long)
            E_ID_PREVE = value
        End Set
    End Property
    Public Property ID_PROCEDENCIA As Long
        Get
            Return E_ID_PROCEDENCIA
        End Get
        Set(value As Long)
            E_ID_PROCEDENCIA = value
        End Set
    End Property
End Class