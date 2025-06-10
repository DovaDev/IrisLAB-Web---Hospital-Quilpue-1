Public Class E_IRIS_WEBF_BUSCA_USUARIO_MENU
    Private EE_ID As Integer
    Private EE_ID_USUARIO As Integer
    Private EE_ID_MENU As Integer
    Private EE_ESTADO As Integer
    Public Property ESTADO() As Integer
        Get
            Return EE_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ESTADO = value
        End Set
    End Property
    Public Property ID_MENU() As Integer
        Get
            Return EE_ID_MENU
        End Get
        Set(ByVal value As Integer)
            EE_ID_MENU = value
        End Set
    End Property
    Public Property ID_USUARIO() As Integer
        Get
            Return EE_ID_USUARIO
        End Get
        Set(ByVal value As Integer)
            EE_ID_USUARIO = value
        End Set
    End Property
    Public Property ID() As Integer
        Get
            Return EE_ID
        End Get
        Set(ByVal value As Integer)
            EE_ID = value
        End Set
    End Property
End Class
