Public Class E_IRIS_WEBF_BUSCA_USUARIO_TODOS
    Dim EE_ID_USUARIO As Integer
    Dim EE_USU_NOMBRE As String
    Dim EE_USU_APELLIDO As String
    Dim EE_ID_ESTADO As Integer
    Dim EE_PER_USU_DESC As String
    Dim EE_USU_NIC As String
    Dim EE_USU_ADMIN As Integer
    Dim EE_proc_desc As String

    Public Property proc_desc As String
        Get
            Return EE_proc_desc
        End Get
        Set(value As String)
            EE_proc_desc = value
        End Set
    End Property

    Public Property USU_ADMIN As Integer
        Get
            Return EE_USU_ADMIN
        End Get
        Set(value As Integer)
            EE_USU_ADMIN = value
        End Set
    End Property

    Public Property ID_USUARIO As Integer
        Get
            Return EE_ID_USUARIO
        End Get
        Set(value As Integer)
            EE_ID_USUARIO = value
        End Set
    End Property

    Public Property USU_NOMBRE As String
        Get
            Return EE_USU_NOMBRE
        End Get
        Set(value As String)
            EE_USU_NOMBRE = value
        End Set
    End Property

    Public Property USU_APELLIDO As String
        Get
            Return EE_USU_APELLIDO
        End Get
        Set(value As String)
            EE_USU_APELLIDO = value
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

    Public Property PER_USU_DESC As String
        Get
            Return EE_PER_USU_DESC
        End Get
        Set(value As String)
            EE_PER_USU_DESC = value
        End Set
    End Property

    Public Property USU_NIC As String
        Get
            Return EE_USU_NIC
        End Get
        Set(value As String)
            EE_USU_NIC = value
        End Set
    End Property
End Class
