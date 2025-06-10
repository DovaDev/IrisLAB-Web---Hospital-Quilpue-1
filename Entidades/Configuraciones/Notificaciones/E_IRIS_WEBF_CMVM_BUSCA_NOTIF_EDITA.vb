Public Class E_IRIS_WEBF_CMVM_BUSCA_NOTIF_EDITA
    Private EE_ID_NOTIF As Integer
    Private EE_TIPO As Integer
    Private EE_MENSAJE As String
    Private EE_FECHA_D As DateTime
    Private EE_FECHA_H As DateTime
    Private EE_PERMA As Integer
    Private EE_ESTADO As Integer
    Public Property ESTADO() As Integer
        Get
            Return EE_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ESTADO = value
        End Set
    End Property
    Public Property PERMA() As Integer
        Get
            Return EE_PERMA
        End Get
        Set(ByVal value As Integer)
            EE_PERMA = value
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
    Public Property MENSAJE() As String
        Get
            Return EE_MENSAJE
        End Get
        Set(ByVal value As String)
            EE_MENSAJE = value
        End Set
    End Property
    Public Property TIPO() As Integer
        Get
            Return EE_TIPO
        End Get
        Set(ByVal value As Integer)
            EE_TIPO = value
        End Set
    End Property
    Public Property ID_NOTIF() As Integer
        Get
            Return EE_ID_NOTIF
        End Get
        Set(ByVal value As Integer)
            EE_ID_NOTIF = value
        End Set
    End Property
End Class
