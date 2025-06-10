Public Class E_IRIS_WEB_GET_NOTIFICATION_COUNTS
    Private EE_numLlamadas As Integer
    Private EE_numCorreos As Integer

    Public Property numLlamadas As Integer
        Get
            Return EE_numLlamadas
        End Get
        Set(value As Integer)
            EE_numLlamadas = value
        End Set
    End Property

    Public Property numCorreos As Integer
        Get
            Return EE_numCorreos
        End Get
        Set(value As Integer)
            EE_numCorreos = value
        End Set
    End Property
End Class
