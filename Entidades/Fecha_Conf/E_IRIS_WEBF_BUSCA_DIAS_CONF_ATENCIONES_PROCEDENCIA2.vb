Public Class E_IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA2
    Private EE_PROC_CANT_EXA As Integer
    Private EE_CONF_DIAS_FECHA As String
    Private EE_CONF_DIAS_EXA As Integer
    Private EE_ID_ESTADO As Integer
    Private EE_ID_PROCEDENCIA As Integer
    Private EE_ID_CONF_DIAS As Integer
    Private EE_AGEND_CUPO_NORMAL As Integer
    Private EE_AGEND_PRIORITARIO As Integer
    Private EE_AGEND_ESPONTANEO As Integer
    Private EE_AGEND_COMENTARIO As String


    Public Property AGEND_COMENTARIO As String
        Get
            Return EE_AGEND_COMENTARIO
        End Get
        Set(value As String)
            EE_AGEND_COMENTARIO = value
        End Set
    End Property

    Public Property AGEND_CUPO_NORMAL As Integer
        Get
            Return EE_AGEND_CUPO_NORMAL
        End Get
        Set(value As Integer)
            EE_AGEND_CUPO_NORMAL = value
        End Set
    End Property
    Public Property AGEND_PRIORITARIO As Integer
        Get
            Return EE_AGEND_PRIORITARIO
        End Get
        Set(value As Integer)
            EE_AGEND_PRIORITARIO = value
        End Set
    End Property
    Public Property AGEND_ESPONTANEO As Integer
        Get
            Return EE_AGEND_ESPONTANEO
        End Get
        Set(value As Integer)
            EE_AGEND_ESPONTANEO = value
        End Set
    End Property
    Public Property ID_CONF_DIAS() As Integer
        Get
            Return EE_ID_CONF_DIAS
        End Get
        Set(ByVal value As Integer)
            EE_ID_CONF_DIAS = value
        End Set
    End Property
    Public Property ID_PROCEDENCIA() As Integer
        Get
            Return EE_ID_PROCEDENCIA
        End Get
        Set(ByVal value As Integer)
            EE_ID_PROCEDENCIA = value
        End Set
    End Property
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property CONF_DIAS_EXA() As Integer
        Get
            Return EE_CONF_DIAS_EXA
        End Get
        Set(ByVal value As Integer)
            EE_CONF_DIAS_EXA = value
        End Set
    End Property
    Public Property CONF_DIAS_FECHA() As String
        Get
            Return EE_CONF_DIAS_FECHA
        End Get
        Set(ByVal value As String)
            EE_CONF_DIAS_FECHA = value
        End Set
    End Property
    Public Property PROC_CANT_EXA() As Integer
        Get
            Return EE_PROC_CANT_EXA
        End Get
        Set(ByVal value As Integer)
            EE_PROC_CANT_EXA = value
        End Set
    End Property

End Class
