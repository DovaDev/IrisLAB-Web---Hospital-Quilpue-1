Public Class E_Asoc_Costo_Exa
    Private EE_ID_CONTROL As Integer
    Public Property ID_CONTROL() As Integer
        Get
            Return EE_ID_CONTROL
        End Get
        Set(ByVal value As Integer)
            EE_ID_CONTROL = value
        End Set
    End Property
    Private EE_ID_COSTO As Integer
    Public Property ID_COSTO() As Integer
        Get
            Return EE_ID_COSTO
        End Get
        Set(ByVal value As Integer)
            EE_ID_COSTO = value
        End Set
    End Property
    Private EE_PRECIO As Integer
    Public Property PRECIO() As Integer
        Get
            Return EE_PRECIO
        End Get
        Set(ByVal value As Integer)
            EE_PRECIO = value
        End Set
    End Property
    Private EE_ID_USUARIO As Integer
    Public Property ID_USUARIO() As Integer
        Get
            Return EE_ID_USUARIO
        End Get
        Set(ByVal value As Integer)
            EE_ID_USUARIO = value
        End Set
    End Property
End Class
