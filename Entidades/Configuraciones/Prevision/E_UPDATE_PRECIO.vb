Public Class E_UPDATE_PRECIO
    Private EE_ID_PRECIO As Integer
    Private EE_AMB As Integer
    Private EE_HOSP As Integer
    Private EE_BON As Integer
    Private EE_PAR As Integer
    Public Property PAR() As Integer
        Get
            Return EE_PAR
        End Get
        Set(ByVal value As Integer)
            EE_PAR = value
        End Set
    End Property
    Public Property BON() As Integer
        Get
            Return EE_BON
        End Get
        Set(ByVal value As Integer)
            EE_BON = value
        End Set
    End Property
    Public Property HOSP() As Integer
        Get
            Return EE_HOSP
        End Get
        Set(ByVal value As Integer)
            EE_HOSP = value
        End Set
    End Property
    Public Property AMB() As Integer
        Get
            Return EE_AMB
        End Get
        Set(ByVal value As Integer)
            EE_AMB = value
        End Set
    End Property
    Public Property ID_PRECIO() As Integer
        Get
            Return EE_ID_PRECIO
        End Get
        Set(ByVal value As Integer)
            EE_ID_PRECIO = value
        End Set
    End Property
End Class
