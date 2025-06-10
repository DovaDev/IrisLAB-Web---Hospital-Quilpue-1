Public Class E_Usuario_Para_Tomar_Muestra
    Private E_ID_USUARIO As Integer
    Private E_USU_FULL_NAME As String
    Private E_USU_NIC As String

    Public Property ID_USUARIO As Integer
        Get
            Return E_ID_USUARIO
        End Get
        Set(value As Integer)
            E_ID_USUARIO = value
        End Set
    End Property

    Public Property USU_FULL_NAME As String
        Get
            Return E_USU_FULL_NAME
        End Get
        Set(value As String)
            E_USU_FULL_NAME = value
        End Set
    End Property

    Public Property USU_NIC As String
        Get
            Return E_USU_NIC
        End Get
        Set(value As String)
            E_USU_NIC = value
        End Set
    End Property
End Class
