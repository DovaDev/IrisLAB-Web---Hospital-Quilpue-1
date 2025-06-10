Public Class E_Login2
    Dim EE_LOGGED As Boolean = False
    Dim EE_ID_USER As Long
    Dim EE_NICKNAME As String
    Dim EE_P_ADMIN As Integer
    Dim EE_RUT As String
    Dim EE_NAME As String
    Dim EE_SURNAME As String
    Dim EE_USU_TM As String
    Private EE_ID_PROF As Integer
    Private EE_USU_RUT_IMED As String
    Private EE_USU_PASS_IMED As String
    Public Property USU_PASS_IMED() As String
        Get
            Return EE_USU_PASS_IMED
        End Get
        Set(ByVal value As String)
            EE_USU_PASS_IMED = value
        End Set
    End Property
    Public Property USU_RUT_IMED() As String
        Get
            Return EE_USU_RUT_IMED
        End Get
        Set(ByVal value As String)
            EE_USU_RUT_IMED = value
        End Set
    End Property
    Public Property ID_PROF() As Integer
        Get
            Return EE_ID_PROF
        End Get
        Set(ByVal value As Integer)
            EE_ID_PROF = value
        End Set
    End Property

    Dim EE_USU_PREV As String
    Private EE_USU_ID_PROC As Integer
    Public Property USU_ID_PROC() As Integer
        Get
            Return EE_USU_ID_PROC
        End Get
        Set(ByVal value As Integer)
            EE_USU_ID_PROC = value
        End Set
    End Property
    Public Property USU_PREV As String
        Get
            Return EE_USU_PREV
        End Get
        Set(value As String)
            EE_USU_PREV = value
        End Set
    End Property

    Public Property LOGGED As Boolean
        Get
            Return EE_LOGGED
        End Get
        Set(value As Boolean)
            EE_LOGGED = value
        End Set
    End Property
    Public Property ID_USER As Long
        Get
            Return EE_ID_USER
        End Get
        Set(value As Long)
            EE_ID_USER = value
        End Set
    End Property
    Public Property NICKNAME As String
        Get
            Return EE_NICKNAME
        End Get
        Set(value As String)
            EE_NICKNAME = value
        End Set
    End Property
    Public Property P_ADMIN As Integer
        Get
            Return EE_P_ADMIN
        End Get
        Set(value As Integer)
            EE_P_ADMIN = value
        End Set
    End Property
    Public Property RUT As String
        Get
            Return EE_RUT
        End Get
        Set(value As String)
            EE_RUT = value
        End Set
    End Property
    Public Property NAME As String
        Get
            Return EE_NAME
        End Get
        Set(value As String)
            EE_NAME = value
        End Set
    End Property
    Public Property SURNAME As String
        Get
            Return EE_SURNAME
        End Get
        Set(value As String)
            EE_SURNAME = value
        End Set
    End Property
End Class
