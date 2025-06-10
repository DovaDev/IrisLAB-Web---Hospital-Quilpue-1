Public Class E_IRIS_WEBF_CMVM_BUSCA_USUARIO_TODOS_2
    Private EE_ID_USUARIO As Long
    Public Property ID_USUARIO() As Long
        Get
            Return EE_ID_USUARIO
        End Get
        Set(ByVal value As Long)
            EE_ID_USUARIO = value
        End Set
    End Property

    Private EE_USU_NOMBRE As String
    Public Property USU_NOMBRE() As String
        Get
            Return EE_USU_NOMBRE
        End Get
        Set(ByVal value As String)
            EE_USU_NOMBRE = value
        End Set
    End Property

    Private EE_USU_APELLIDO As String
    Public Property USU_APELLIDO() As String
        Get
            Return EE_USU_APELLIDO
        End Get
        Set(ByVal value As String)
            EE_USU_APELLIDO = value
        End Set
    End Property

    Private EE_ID_ESTADO As Integer
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property

    Private EE_USU_NIC As String
    Public Property USU_NIC() As String
        Get
            Return EE_USU_NIC
        End Get
        Set(ByVal value As String)
            EE_USU_NIC = value
        End Set
    End Property

    Private EE_ADMIN_DESC As String
    Public Property ADMIN_DESC() As String
        Get
            Return EE_ADMIN_DESC
        End Get
        Set(ByVal value As String)
            EE_ADMIN_DESC = value
        End Set
    End Property

    Private EE_PROC_DESC As String
    Public Property PROC_DESC() As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(ByVal value As String)
            EE_PROC_DESC = value
        End Set
    End Property

    Private EE_PREVE_DESC As String
    Public Property PREVE_DESC() As String
        Get
            Return EE_PREVE_DESC
        End Get
        Set(ByVal value As String)
            EE_PREVE_DESC = value
        End Set
    End Property
End Class