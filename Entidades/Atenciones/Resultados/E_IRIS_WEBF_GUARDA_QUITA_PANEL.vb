
Public Class E_IRIS_WEBF_GUARDA_QUITA_PANEL
    Private EE_ID_PANEL As Integer
    Private EE_ID_ATE As Long
    Private EE_ID_CF_CULT As Integer
    Private EE_ID_PREVE As Integer
    Public Property ID_PREVE() As Integer
        Get
            Return EE_ID_PREVE
        End Get
        Set(ByVal value As Integer)
            EE_ID_PREVE = value
        End Set
    End Property
    Public Property ID_CF_CULT() As Integer
        Get
            Return EE_ID_CF_CULT
        End Get
        Set(ByVal value As Integer)
            EE_ID_CF_CULT = value
        End Set
    End Property
    Private EE_TYPE As String
    Public Property TYPE() As String
        Get
            Return EE_TYPE
        End Get
        Set(ByVal value As String)
            EE_TYPE = value
        End Set
    End Property
    Public Property ID_ATE() As Long
        Get
            Return EE_ID_ATE
        End Get
        Set(ByVal value As Long)
            EE_ID_ATE = value
        End Set
    End Property
    Public Property ID_PANEL() As Integer
        Get
            Return EE_ID_PANEL
        End Get
        Set(ByVal value As Integer)
            EE_ID_PANEL = value
        End Set
    End Property
End Class