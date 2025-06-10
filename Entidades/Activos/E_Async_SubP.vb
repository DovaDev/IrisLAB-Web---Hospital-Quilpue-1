Public Class E_Async_SubP
    Private EE_SubP_ID As Integer
    Public Property SubP_ID() As Integer
        Get
            Return EE_SubP_ID
        End Get
        Set(ByVal value As Integer)
            EE_SubP_ID = value
        End Set
    End Property

    Private EE_SubP_Cod As String
    Public Property SubP_Cod() As String
        Get
            Return EE_SubP_Cod
        End Get
        Set(ByVal value As String)
            EE_SubP_Cod = value
        End Set
    End Property

    Private EE_SubP_Desc As String
    Public Property SubP_Desc() As String
        Get
            Return EE_SubP_Desc
        End Get
        Set(ByVal value As String)
            EE_SubP_Desc = value
        End Set
    End Property
End Class
