Public Class E_IRIS_WEBF_GRABA_USUARIO
    Dim EE_NOMBRE_USU As String
    Dim EE_APE_USU As String
    Dim EE_USUARIO As String
    Dim EE_PASS As String
    Dim EE_USU_ADMIN As Integer
    Dim EE_USU_TM As Integer

    Public Property NOMBRE_USU As String
        Get
            Return EE_NOMBRE_USU
        End Get
        Set(value As String)
            EE_NOMBRE_USU = value
        End Set
    End Property

    Public Property APE_USU As String
        Get
            Return EE_APE_USU
        End Get
        Set(value As String)
            EE_APE_USU = value
        End Set
    End Property

    Public Property USUARIO As String
        Get
            Return EE_USUARIO
        End Get
        Set(value As String)
            EE_USUARIO = value
        End Set
    End Property

    Public Property PASS As String
        Get
            Return EE_PASS
        End Get
        Set(value As String)
            EE_PASS = value
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

    Public Property USU_TM As Integer
        Get
            Return EE_USU_TM
        End Get
        Set(value As Integer)
            EE_USU_TM = value
        End Set
    End Property
End Class
