Public Class E_UPDATE_CF_PRECIO
    Private EE_ID_CONTROL_COSTO As Integer
    Public Property ID_CONTROL_COSTO() As Integer
        Get
            Return EE_ID_CONTROL_COSTO
        End Get
        Set(ByVal value As Integer)
            EE_ID_CONTROL_COSTO = value
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
    Private EE_TOTAL_PRECIO As String
    Public Property TOTAL_PRECIO() As String
        Get
            Return EE_TOTAL_PRECIO
        End Get
        Set(ByVal value As String)
            EE_TOTAL_PRECIO = value
        End Set
    End Property
End Class
