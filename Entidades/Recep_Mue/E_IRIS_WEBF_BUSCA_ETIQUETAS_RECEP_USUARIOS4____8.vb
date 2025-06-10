Public Class E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____8
    Dim EE_ID_USUARIO As Integer
    Dim EE_RECEP_ETI_NUM_ATE As String
    Dim EE_RECEP_ETI_CURVA As String
    Dim EE_RECEP_ETI_FECHA As Date
    Dim EE_CB_DESC As String
    Dim EE_ATE_NUM As String
    Dim EE_PAC_NOMBRE As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_ID_ESTADO As String
    Dim EE_EST_DESCRIPCION As String
    Dim EE_T_MUESTRA_DESC As String
    Dim EE_ID_RECEP_ETI As String
    Dim EE_CF_DESC As String
    Dim EE_ID_PER As String
    Dim EE_USU_NIC As String

    Public Property USU_NIC As String
        Get
            Return EE_USU_NIC
        End Get
        Set(value As String)
            EE_USU_NIC = value
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

    Public Property RECEP_ETI_NUM_ATE As String
        Get
            Return EE_RECEP_ETI_NUM_ATE
        End Get
        Set(value As String)
            EE_RECEP_ETI_NUM_ATE = value
        End Set
    End Property

    Public Property RECEP_ETI_CURVA As String
        Get
            Return EE_RECEP_ETI_CURVA
        End Get
        Set(value As String)
            EE_RECEP_ETI_CURVA = value
        End Set
    End Property

    Public Property RECEP_ETI_FECHA As Date
        Get
            Return EE_RECEP_ETI_FECHA
        End Get
        Set(value As Date)
            EE_RECEP_ETI_FECHA = value
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

    Public Property ATE_NUM As String
        Get
            Return EE_ATE_NUM
        End Get
        Set(value As String)
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

    Public Property ID_ESTADO As String
        Get
            Return EE_ID_ESTADO
        End Get
        Set(value As String)
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

    Public Property ID_RECEP_ETI As String
        Get
            Return EE_ID_RECEP_ETI
        End Get
        Set(value As String)
            EE_ID_RECEP_ETI = value
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

    Public Property ID_PER As String
        Get
            Return EE_ID_PER
        End Get
        Set(value As String)
            EE_ID_PER = value
        End Set
    End Property
End Class
