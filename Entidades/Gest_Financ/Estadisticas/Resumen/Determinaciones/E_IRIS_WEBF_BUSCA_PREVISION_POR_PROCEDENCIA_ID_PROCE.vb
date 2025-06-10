Public Class E_IRIS_WEBF_BUSCA_PREVISION_POR_PROCEDENCIA_ID_PROCE
    Dim EE_ID_REL_PREV_PROC As Long
    Dim EE_ID_PREVE As Long
    Dim EE_ID_PROCEDENCIA As Long
    Dim EE_PROC_DESC As String
    Dim EE_PREVE_DESC As String
    Dim EE_ID_ESTADO As Integer
    Public Property ID_REL_PREV_PROC As Long
        Get
            Return EE_ID_REL_PREV_PROC
        End Get
        Set(value As Long)
            EE_ID_REL_PREV_PROC = value
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
    Public Property ID_PROCEDENCIA As Long
        Get
            Return EE_ID_PROCEDENCIA
        End Get
        Set(value As Long)
            EE_ID_PROCEDENCIA = value
        End Set
    End Property
    Public Property PROC_DESC As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(value As String)
            EE_PROC_DESC = value
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
