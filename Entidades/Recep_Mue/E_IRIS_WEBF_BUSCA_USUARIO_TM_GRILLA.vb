Public Class E_IRIS_WEBF_BUSCA_USUARIO_TM_GRILLA
    Dim EE_ID_USUARIO As Integer
    Dim EE_USU_NOMBRE As String
    Dim EE_USU_APELLIDO As String
    Dim EE_ID_ESTADO As String
    Dim EE_USU_NIC As String

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

    Public Property ID_ESTADO As String
        Get
            Return EE_ID_ESTADO
        End Get
        Set(value As String)
            EE_ID_ESTADO = value
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
