Public Class E_IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES
    Private EE_DET_CRITICO_CAUSA As String
    Public Property DET_CRITICO_CAUSA() As String
        Get
            Return EE_DET_CRITICO_CAUSA
        End Get
        Set(ByVal value As String)
            EE_DET_CRITICO_CAUSA = value
        End Set
    End Property
    Private EE_ID_DET_CRITICO As Integer
    Public Property ID_DET_CRITICO() As Integer
        Get
            Return EE_ID_DET_CRITICO
        End Get
        Set(ByVal value As Integer)
            EE_ID_DET_CRITICO = value
        End Set
    End Property

    Private EE_ID_ATE_RES As Integer
    Public Property ID_ATE_RES() As Integer
        Get
            Return EE_ID_ATE_RES
        End Get
        Set(ByVal value As Integer)
            EE_ID_ATE_RES = value
        End Set
    End Property

    Private EE_ID_USUARIO As Integer
    Public Property ID_USUARIO() As Integer
        Get
            Return EE_ID_USUARIO
        End Get
        Set(ByVal value As Integer)
            EE_ID_USUARIO = value
        End Set
    End Property

    Private EE_DET_CRITICO_FECHA As Date
    Public Property DET_CRITICO_FECHA() As Date
        Get
            Return EE_DET_CRITICO_FECHA
        End Get
        Set(ByVal value As Date)
            EE_DET_CRITICO_FECHA = value
        End Set
    End Property

    Private EE_DET_CRITICO_DESC As String
    Public Property DET_CRITICO_DESC() As String
        Get
            Return EE_DET_CRITICO_DESC
        End Get
        Set(ByVal value As String)
            EE_DET_CRITICO_DESC = value
        End Set
    End Property

    Private EE_ID_ESTADO As Integer
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property

    Private EE_ID_TP_CRITICO As Integer
    Public Property ID_TP_CRITICO() As Integer
        Get
            Return EE_ID_TP_CRITICO
        End Get
        Set(ByVal value As Integer)
            EE_ID_TP_CRITICO = value
        End Set
    End Property

    Private EE_TP_CRITICO_DESC As String
    Public Property TP_CRITICO_DESC() As String
        Get
            Return EE_TP_CRITICO_DESC
        End Get
        Set(ByVal value As String)
            EE_TP_CRITICO_DESC = value
        End Set
    End Property

    Private EE_USU_NIC As String
    Public Property USU_NIC() As String
        Get
            Return EE_USU_NIC
        End Get
        Set(ByVal value As String)
            EE_USU_NIC = value
        End Set
    End Property

    Private EE_EST_DESCRIPCION As String
    Public Property EST_DESCRIPCION() As String
        Get
            Return EE_EST_DESCRIPCION
        End Get
        Set(ByVal value As String)
            EE_EST_DESCRIPCION = value
        End Set
    End Property

    Private EE_DET_CRITICO_FECHA_MANUAL As Date
    Public Property DET_CRITICO_FECHA_MANUAL() As Date
        Get
            Return EE_DET_CRITICO_FECHA_MANUAL
        End Get
        Set(ByVal value As Date)
            EE_DET_CRITICO_FECHA_MANUAL = value
        End Set
    End Property
End Class