Public Class E_IRIS_WEBF_BUSCA_MENU
    Private EE_ID As Integer
    Private EE_NOM_MENU As String
    Private EE_DESC_MENU As String
    Public Property DESC_MENU() As String
        Get
            Return EE_DESC_MENU
        End Get
        Set(ByVal value As String)
            EE_DESC_MENU = value
        End Set
    End Property
    Public Property NOM_MENU() As String
        Get
            Return EE_NOM_MENU
        End Get
        Set(ByVal value As String)
            EE_NOM_MENU = value
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
