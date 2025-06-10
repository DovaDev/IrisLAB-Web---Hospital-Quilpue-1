Public Class E_IRIS_WEBF_BUSCA_RELACION_PREVI_PROCE
    Dim EE_PROC_DESC As String
    Dim EE_ID_PROCEDENCIA As Integer
    Dim EE_ID_ESTADO As Integer
    Dim EE_ID_PREVE As Integer
    Dim EE_ID_REL_PREV_PROC As Integer

    Public Property PROC_DESC As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(value As String)
            EE_PROC_DESC = value
        End Set
    End Property

    Public Property ID_PROCEDENCIA As Integer
        Get
            Return EE_ID_PROCEDENCIA
        End Get
        Set(value As Integer)
            EE_ID_PROCEDENCIA = value
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

    Public Property ID_PREVE As Integer
        Get
            Return EE_ID_PREVE
        End Get
        Set(value As Integer)
            EE_ID_PREVE = value
        End Set
    End Property

    Public Property ID_REL_PREV_PROC As Integer
        Get
            Return EE_ID_REL_PREV_PROC
        End Get
        Set(value As Integer)
            EE_ID_REL_PREV_PROC = value
        End Set
    End Property
End Class
