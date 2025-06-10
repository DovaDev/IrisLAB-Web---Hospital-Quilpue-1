Public Class E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4_RECHAZO
    Dim EE_ID_USUARIO As Integer
    Dim EE_RECEP_ETI_NUM_ATE_RECHAZO As Integer
    Dim EE_RECEP_ETI_CURVA_RECHAZO As String
    Dim EE_RECEP_ETI_FECHA_RECHAZO As Date
    Dim EE_CB_DESC As String
    Dim EE_ATE_NUM As Integer
    Dim EE_PAC_NOMBRE As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_ID_ESTADO As Integer
    Dim EE_EST_DESCRIPCION As String
    Dim EE_T_MUESTRA_DESC As String
    Dim EE_ID_RECEP_ETI_RECHAZO As Integer
    Dim EE_ID_CF_RECHAZADO As Integer
    Dim EE_CF_DESC As String
    Dim EE_USU_NIC As String

    Public Property USU_NIC As String
        Get
            Return EE_USU_NIC
        End Get
        Set(value As String)
            EE_USU_NIC = value
        End Set
    End Property
    Public Property CF_DESC As String
        Get
            Return EE_CF_DESC
        End Get
        Set(value As String)
            EE_CF_DESC = value
        End Set
    End Property
    Public Property ID_USUARIO As Integer
        Get
            Return EE_ID_USUARIO
        End Get
        Set(value As Integer)
            EE_ID_USUARIO = value
        End Set
    End Property

    Public Property RECEP_ETI_NUM_ATE_RECHAZO As Integer
        Get
            Return EE_RECEP_ETI_NUM_ATE_RECHAZO
        End Get
        Set(value As Integer)
            EE_RECEP_ETI_NUM_ATE_RECHAZO = value
        End Set
    End Property

    Public Property RECEP_ETI_CURVA_RECHAZO As String
        Get
            Return EE_RECEP_ETI_CURVA_RECHAZO
        End Get
        Set(value As String)
            EE_RECEP_ETI_CURVA_RECHAZO = value
        End Set
    End Property

    Public Property RECEP_ETI_FECHA_RECHAZO As Date
        Get
            Return EE_RECEP_ETI_FECHA_RECHAZO
        End Get
        Set(value As Date)
            EE_RECEP_ETI_FECHA_RECHAZO = value
        End Set
    End Property

    Public Property CB_DESC As String
        Get
            Return EE_CB_DESC
        End Get
        Set(value As String)
            EE_CB_DESC = value
        End Set
    End Property
    Public Property ATE_NUM As Integer
        Get
            Return EE_ATE_NUM
        End Get
        Set(value As Integer)
            EE_ATE_NUM = value
        End Set
    End Property

    Public Property PAC_NOMBRE As String
        Get
            Return EE_PAC_NOMBRE
        End Get
        Set(value As String)
            EE_PAC_NOMBRE = value
        End Set
    End Property

    Public Property PAC_APELLIDO As String
        Get
            Return EE_PAC_APELLIDO
        End Get
        Set(value As String)
            EE_PAC_APELLIDO = value
        End Set
    End Property

    Public Property ID_ESTADO As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property

    Public Property EST_DESCRIPCION As String
        Get
            Return EE_EST_DESCRIPCION
        End Get
        Set(value As String)
            EE_EST_DESCRIPCION = value
        End Set
    End Property

    Public Property T_MUESTRA_DESC As String
        Get
            Return EE_T_MUESTRA_DESC
        End Get
        Set(value As String)
            EE_T_MUESTRA_DESC = value
        End Set
    End Property

    Public Property ID_RECEP_ETI_RECHAZO As Integer
        Get
            Return EE_ID_RECEP_ETI_RECHAZO
        End Get
        Set(value As Integer)
            EE_ID_RECEP_ETI_RECHAZO = value
        End Set
    End Property

    Public Property ID_CF_RECHAZADO As Integer
        Get
            Return EE_ID_CF_RECHAZADO
        End Get
        Set(value As Integer)
            EE_ID_CF_RECHAZADO = value
        End Set
    End Property
End Class
