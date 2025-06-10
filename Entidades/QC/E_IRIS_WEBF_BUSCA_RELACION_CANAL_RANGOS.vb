Public Class E_IRIS_WEBF_BUSCA_RELACION_CANAL_RANGOS
    Private EE_ID_REL_CANAL_MAQ As Integer
    Private EE_IRIS_LNK_I_ID As Integer
    Private EE_IRIS_LNK_MAQ_ID As Integer
    Private EE_REL_CM_CANAL_DESC As String
    Private EE_REL_CM_DETER_DESC As String
    Private EE_REL_CM_R_DESDE As String
    Private EE_REL_CM_R_HASTA As String
    Private EE_REL_CM_RR_DESDE As String
    Private EE_REL_CM_RR_HASTA As String
    Private EE_ID_ESTADO As Integer
    Private EE_IRIS_LNK_MAQ_DESCRIPCION As String
    Private EE_IRIS_LNK_I_DESCRIPCION As String
    Public Property IRIS_LNK_I_DESCRIPCION() As String
        Get
            Return EE_IRIS_LNK_I_DESCRIPCION
        End Get
        Set(ByVal value As String)
            EE_IRIS_LNK_I_DESCRIPCION = value
        End Set
    End Property
    Public Property IRIS_LNK_MAQ_DESCRIPCION() As String
        Get
            Return EE_IRIS_LNK_MAQ_DESCRIPCION
        End Get
        Set(ByVal value As String)
            EE_IRIS_LNK_MAQ_DESCRIPCION = value
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
    Public Property REL_CM_RR_HASTA() As String
        Get
            Return EE_REL_CM_RR_HASTA
        End Get
        Set(ByVal value As String)
            EE_REL_CM_RR_HASTA = value
        End Set
    End Property
    Public Property REL_CM_RR_DESDE() As String
        Get
            Return EE_REL_CM_RR_DESDE
        End Get
        Set(ByVal value As String)
            EE_REL_CM_RR_DESDE = value
        End Set
    End Property
    Public Property REL_CM_R_HASTA() As String
        Get
            Return EE_REL_CM_R_HASTA
        End Get
        Set(ByVal value As String)
            EE_REL_CM_R_HASTA = value
        End Set
    End Property
    Public Property REL_CM_R_DESDE() As String
        Get
            Return EE_REL_CM_R_DESDE
        End Get
        Set(ByVal value As String)
            EE_REL_CM_R_DESDE = value
        End Set
    End Property
    Public Property REL_CM_DETER_DESC() As String
        Get
            Return EE_REL_CM_DETER_DESC
        End Get
        Set(ByVal value As String)
            EE_REL_CM_DETER_DESC = value
        End Set
    End Property
    Public Property REL_CM_CANAL_DESC() As String
        Get
            Return EE_REL_CM_CANAL_DESC
        End Get
        Set(ByVal value As String)
            EE_REL_CM_CANAL_DESC = value
        End Set
    End Property
    Public Property IRIS_LNK_MAQ_ID() As Integer
        Get
            Return EE_IRIS_LNK_MAQ_ID
        End Get
        Set(ByVal value As Integer)
            EE_IRIS_LNK_MAQ_ID = value
        End Set
    End Property
    Public Property IRIS_LNK_I_ID() As Integer
        Get
            Return EE_IRIS_LNK_I_ID
        End Get
        Set(ByVal value As Integer)
            EE_IRIS_LNK_I_ID = value
        End Set
    End Property
    Public Property ID_REL_CANAL_MAQ() As Integer
        Get
            Return EE_ID_REL_CANAL_MAQ
        End Get
        Set(ByVal value As Integer)
            EE_ID_REL_CANAL_MAQ = value
        End Set
    End Property
End Class
