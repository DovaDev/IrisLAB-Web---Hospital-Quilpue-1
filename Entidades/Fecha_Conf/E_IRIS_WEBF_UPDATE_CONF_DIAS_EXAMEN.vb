
Public Class E_IRIS_WEBF_UPDATE_CONF_DIAS_EXAMEN
    Private EE_ID_CONF As String
    Private EE_CANTIDAD As String
    Private EE_ID_ESTADO As String
    Public Property ID_ESTADO() As String
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As String)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property CANTIDAD() As String
        Get
            Return EE_CANTIDAD
        End Get
        Set(ByVal value As String)
            EE_CANTIDAD = value
        End Set
    End Property
    Public Property ID_CONF() As String
        Get
            Return EE_ID_CONF
        End Get
        Set(ByVal value As String)
            EE_ID_CONF = value
        End Set
    End Property
End Class
