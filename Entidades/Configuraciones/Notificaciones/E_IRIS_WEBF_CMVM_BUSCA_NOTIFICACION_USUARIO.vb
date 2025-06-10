Public Class E_IRIS_WEBF_CMVM_BUSCA_NOTIFICACION_USUARIO
    Private EE_ID_NOTIF As Long
    Private EE_TIPO_MSG As Integer
    Private EE_MSG As String
    Private EE_FECHA_D As DateTime
    Private EE_FECHA_H As DateTime
    Private EE_NOTIF_ESTADO As Integer
    Private EE_CONFIRMA As Integer
    Private EE_ID_REL_N_U As Long
    Private EE_PERMANENTE As Integer
    Public Property PERMANENTE() As Integer
        Get
            Return EE_PERMANENTE
        End Get
        Set(ByVal value As Integer)
            EE_PERMANENTE = value
        End Set
    End Property
    Public Property ID_REL_N_U() As Long
        Get
            Return EE_ID_REL_N_U
        End Get
        Set(ByVal value As Long)
            EE_ID_REL_N_U = value
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
    Public Property NOTIF_ESTADO() As Integer
        Get
            Return EE_NOTIF_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_NOTIF_ESTADO = value
        End Set
    End Property
    Public Property FECHA_H() As DateTime
        Get
            Return EE_FECHA_H
        End Get
        Set(ByVal value As DateTime)
            EE_FECHA_H = value
        End Set
    End Property
    Public Property FECHA_D() As DateTime
        Get
            Return EE_FECHA_D
        End Get
        Set(ByVal value As DateTime)
            EE_FECHA_D = value
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
    Public Property ID_NOTIF() As Long
        Get
            Return EE_ID_NOTIF
        End Get
        Set(ByVal value As Long)
            EE_ID_NOTIF = value
        End Set
    End Property
End Class
