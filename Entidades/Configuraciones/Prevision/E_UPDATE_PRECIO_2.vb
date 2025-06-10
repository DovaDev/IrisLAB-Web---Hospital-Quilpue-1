Public Class E_UPDATE_PRECIO_2
    Private EE_ID_PRECIO As Integer
    Private EE_AMB As Integer
    Private EE_HOSP As Integer
    Private EE_ID_PREVE As Integer
    Private EE_ID_CF As Integer
    Private EE_ANO As Integer
    Public Property ID_AÑO() As Integer
        Get
            Return EE_ANO
        End Get
        Set(ByVal value As Integer)
            EE_ANO = value
        End Set
    End Property
    Public Property ID_CF() As Integer
        Get
            Return EE_ID_CF
        End Get
        Set(ByVal value As Integer)
            EE_ID_CF = value
        End Set
    End Property
    Public Property ID_PREVI() As Integer
        Get
            Return EE_ID_PREVE
        End Get
        Set(ByVal value As Integer)
            EE_ID_PREVE = value
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
