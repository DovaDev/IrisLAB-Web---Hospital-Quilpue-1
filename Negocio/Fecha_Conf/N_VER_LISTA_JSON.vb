
Public Class E_VER_LISTA_JSON
    Private EE_PROC_CANT_EXA As String
    Private EE_CONF_DIAS_FECHA As String
    Private EE_CONF_DIAS_EXA As String
    Private EE_ID_ESTADO As String
    Private EE_ID_PROCEDENCIA As String
    Private EE_ID_CONF_DIAS As String
    Public Property ID_CONF_DIAS() As String
        Get
            Return EE_ID_CONF_DIAS
        End Get
        Set(ByVal value As String)
            EE_ID_CONF_DIAS = value
        End Set
    End Property
    Public Property ID_PROCEDENCIA() As String
        Get
            Return EE_ID_PROCEDENCIA
        End Get
        Set(ByVal value As String)
            EE_ID_PROCEDENCIA = value
        End Set
    End Property
    Public Property ID_ESTADO() As String
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As String)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property CONF_DIAS_EXA() As String
        Get
            Return EE_CONF_DIAS_EXA
        End Get
        Set(ByVal value As String)
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
    Public Property PROC_CANT_EXA() As String
        Get
            Return EE_PROC_CANT_EXA
        End Get
        Set(ByVal value As String)
            EE_PROC_CANT_EXA = value
        End Set
    End Property
End Class
