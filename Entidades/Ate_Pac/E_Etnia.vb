Public Class E_Etnia
    Private EE_ID_ETNIA As Integer
    Private EE_ETNIA_DESC As String
    Private EE_ID_ESTADO As Integer

    Public Property ID_ETNIA As Integer
        Get
            Return EE_ID_ETNIA
        End Get
        Set(value As Integer)
            EE_ID_ETNIA = value
        End Set
    End Property

    Public Property ETNIA_DESC As String
        Get
            Return EE_ETNIA_DESC
        End Get
        Set(value As String)
            EE_ETNIA_DESC = value
        End Set
    End Property

    Public Property ID_ESTADO As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
End Class
