Public Class E_IRIS_WEBF_GRABA_CONF_EXAMENES
    Private EE_ID_PRO As String
    Private EE_FECHA As String
    Private EE_CANT As String
    Public Property CANT() As String
        Get
            Return EE_CANT
        End Get
        Set(ByVal value As String)
            EE_CANT = value
        End Set
    End Property
    Public Property FECHA() As String
        Get
            Return EE_FECHA
        End Get
        Set(ByVal value As String)
            EE_FECHA = value
        End Set
    End Property
    Public Property ID_PRO() As String
        Get
            Return EE_ID_PRO
        End Get
        Set(ByVal value As String)
            EE_ID_PRO = value
        End Set
    End Property
End Class
