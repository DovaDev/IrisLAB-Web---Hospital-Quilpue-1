Public Class E_IRIS_WEBF_BUSCA_USUARIOS_CONVENIO_TODOS
    Dim EE_ID_USUARIO_CONV As Integer
    Dim EE_USU_CONV_NIC As String
    Dim EE_USU_CONV_PASS As String
    Dim EE_USU_CONV_NOMBRE As String
    Dim EE_USU_CONV_APELLIDO As String
    Dim EE_ID_ESTADO As Integer
    Dim EE_USU_RUT As String
    Dim EE_USU_DIR As String
    Dim EE_USU_FONO As String
    Dim EE_USU_MOVIL As String
    Dim EE_USU_EMAIL As String
    Dim EE_ID_PREVE As Integer
    Dim EE_ID_PROCEDENCIA As Integer
    Dim EE_ID_PREVE2 As Integer
    Dim EE_ID_LAB As Integer
    Dim EE_PROC_DESC As String
    Dim EE_PREVE_DESC As String
    Dim EE_PREVE_DESC_2 As String
    Public Property PREVE_DESC_2 As String
        Get
            Return EE_PREVE_DESC_2
        End Get
        Set(value As String)
            EE_PREVE_DESC_2 = value
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
    Public Property PROC_DESC As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(value As String)
            EE_PROC_DESC = value
        End Set
    End Property

    Public Property ID_USUARIO_CONV As Integer
        Get
            Return EE_ID_USUARIO_CONV
        End Get
        Set(value As Integer)
            EE_ID_USUARIO_CONV = value
        End Set
    End Property

    Public Property USU_CONV_NIC As String
        Get
            Return EE_USU_CONV_NIC
        End Get
        Set(value As String)
            EE_USU_CONV_NIC = value
        End Set
    End Property

    Public Property USU_CONV_PASS As String
        Get
            Return EE_USU_CONV_PASS
        End Get
        Set(value As String)
            EE_USU_CONV_PASS = value
        End Set
    End Property

    Public Property USU_CONV_NOMBRE As String
        Get
            Return EE_USU_CONV_NOMBRE
        End Get
        Set(value As String)
            EE_USU_CONV_NOMBRE = value
        End Set
    End Property

    Public Property USU_CONV_APELLIDO As String
        Get
            Return EE_USU_CONV_APELLIDO
        End Get
        Set(value As String)
            EE_USU_CONV_APELLIDO = value
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

    Public Property ID_PREVE As Integer
        Get
            Return EE_ID_PREVE
        End Get
        Set(value As Integer)
            EE_ID_PREVE = value
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

    Public Property ID_PREVE2 As Integer
        Get
            Return EE_ID_PREVE2
        End Get
        Set(value As Integer)
            EE_ID_PREVE2 = value
        End Set
    End Property

    Public Property ID_LAB As Integer
        Get
            Return EE_ID_LAB
        End Get
        Set(value As Integer)
            EE_ID_LAB = value
        End Set
    End Property
End Class
