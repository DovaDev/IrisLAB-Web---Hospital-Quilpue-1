Public Class E_IRIS_WEB_BUSCA_USUARIO_ACTIVO_POR_PROCEDENCIA
    Dim EE_ID_USUARIO As Integer
    Dim EE_USU_FULL_NAME As String
    Dim EE_USU_NIC As String

    Public Property ID_USUARIO As Integer
        Get
            Return EE_ID_USUARIO
        End Get
        Set(value As Integer)
            EE_ID_USUARIO = value
        End Set
    End Property

    Public Property USU_FULL_NAME As String
        Get
            Return EE_USU_FULL_NAME
        End Get
        Set(value As String)
            EE_USU_FULL_NAME = value
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
