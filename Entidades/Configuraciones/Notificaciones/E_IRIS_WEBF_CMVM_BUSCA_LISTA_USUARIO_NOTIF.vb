Public Class E_IRIS_WEBF_CMVM_BUSCA_LISTA_USUARIO_NOTIF
    Private EE_TIPO_MSG As Integer
    Private EE_MSG As String
    Private EE_CONFIRMA As Integer
    Private EE_FECHA_CONF As DateTime
    Private EE_USU_NOMBRE As String
    Private EE_USU_APELLIDO As String
    Private EE_ID_USUARIO As Long
    Private EE_ID_ESTADO As Integer
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property ID_USUARIO() As Long
        Get
            Return EE_ID_USUARIO
        End Get
        Set(ByVal value As Long)
            EE_ID_USUARIO = value
        End Set
    End Property
    Public Property USU_APELLIDO() As String
        Get
            Return EE_USU_APELLIDO
        End Get
        Set(ByVal value As String)
            EE_USU_APELLIDO = value
        End Set
    End Property
    Public Property USU_NOMBRE() As String
        Get
            Return EE_USU_NOMBRE
        End Get
        Set(ByVal value As String)
            EE_USU_NOMBRE = value
        End Set
    End Property
    Public Property FECHA_CONF() As DateTime
        Get
            Return EE_FECHA_CONF
        End Get
        Set(ByVal value As DateTime)
            EE_FECHA_CONF = value
        End Set
    End Property
    Public Property CONFIRMA() As Integer
        Get
            Return EE_CONFIRMA
        End Get
        Set(ByVal value As Integer)
            EE_CONFIRMA = value
        End Set
    End Property
    Public Property MSG() As String
        Get
            Return EE_MSG
        End Get
        Set(ByVal value As String)
            EE_MSG = value
        End Set
    End Property
    Public Property TIPO_MSG() As Integer
        Get
            Return EE_TIPO_MSG
        End Get
        Set(ByVal value As Integer)
            EE_TIPO_MSG = value
        End Set
    End Property
End Class
