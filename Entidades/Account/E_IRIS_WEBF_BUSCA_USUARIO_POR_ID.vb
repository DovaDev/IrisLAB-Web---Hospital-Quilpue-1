Public Class E_IRIS_WEBF_BUSCA_USUARIO_POR_ID
    Dim EE_USU_NIC As String
    Dim EE_USU_PASS As String
    Dim EE_ID_PER_USU As Integer
    Dim EE_USU_NOMBRE As String
    Dim EE_USU_APELLIDO As String
    Dim EE_ID_ESTADO As Integer
    Dim EE_ID_PROFESION As Integer
    Dim EE_USU_RUT As String
    Dim EE_USU_DIR As String
    Dim EE_ID_REL_CIU_COM As Integer
    Dim EE_USU_FONO As String
    Dim EE_USU_MOVIL As String
    Dim EE_USU_EMAIL As String
    Dim EE_ID_CARGO As Integer
    Dim EE_USU_FNAC As Date
    Dim EE_ID_CIUDAD As Integer
    Dim EE_ID_USUARIO As Integer

    Public Property USU_NIC As String
        Get
            Return EE_USU_NIC
        End Get
        Set(value As String)
            EE_USU_NIC = value
        End Set
    End Property

    Public Property USU_PASS As String
        Get
            Return EE_USU_PASS
        End Get
        Set(value As String)
            EE_USU_PASS = value
        End Set
    End Property

    Public Property ID_PER_USU As Integer
        Get
            Return EE_ID_PER_USU
        End Get
        Set(value As Integer)
            EE_ID_PER_USU = value
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

    Public Property ID_PROFESION As Integer
        Get
            Return EE_ID_PROFESION
        End Get
        Set(value As Integer)
            EE_ID_PROFESION = value
        End Set
    End Property

    Public Property USU_RUT As String
        Get
            Return EE_USU_RUT
        End Get
        Set(value As String)
            EE_USU_RUT = value
        End Set
    End Property

    Public Property USU_DIR As String
        Get
            Return EE_USU_DIR
        End Get
        Set(value As String)
            EE_USU_DIR = value
        End Set
    End Property

    Public Property ID_REL_CIU_COM As Integer
        Get
            Return EE_ID_REL_CIU_COM
        End Get
        Set(value As Integer)
            EE_ID_REL_CIU_COM = value
        End Set
    End Property

    Public Property USU_FONO As String
        Get
            Return EE_USU_FONO
        End Get
        Set(value As String)
            EE_USU_FONO = value
        End Set
    End Property

    Public Property USU_MOVIL As String
        Get
            Return EE_USU_MOVIL
        End Get
        Set(value As String)
            EE_USU_MOVIL = value
        End Set
    End Property

    Public Property USU_EMAIL As String
        Get
            Return EE_USU_EMAIL
        End Get
        Set(value As String)
            EE_USU_EMAIL = value
        End Set
    End Property

    Public Property ID_CARGO As Integer
        Get
            Return EE_ID_CARGO
        End Get
        Set(value As Integer)
            EE_ID_CARGO = value
        End Set
    End Property

    Public Property USU_FNAC As Date
        Get
            Return EE_USU_FNAC
        End Get
        Set(value As Date)
            EE_USU_FNAC = value
        End Set
    End Property

    Public Property ID_CIUDAD As Integer
        Get
            Return EE_ID_CIUDAD
        End Get
        Set(value As Integer)
            EE_ID_CIUDAD = value
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
End Class
