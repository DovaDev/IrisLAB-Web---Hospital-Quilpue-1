Public Class E_IRIS_WEBF_BUSCA_ETIQUETA_POR_FOLIO_RECEPCION_DE_ETIQUETAS_RECHAZO
    Dim EE_ID_T_MUESTRA As Integer
    Dim EE_ATE_NUM As Integer
    Dim EE_ID_ATENCION As Integer
    Dim EE_ID_PER As Integer
    Dim EE_T_MUESTRA_DESC As String
    Dim EE_CB_DESC As String
    Dim EE_Expr1 As Integer
    Dim EE_CF_DESC As String
    Dim EE_ATE_EST_RECHAZO As String
    '-----------------------------
    Dim EE_ID_PRUEBA As Integer
    Dim EE_ATE_FEC_RECHAZO As Date
    Dim EE_ATE_USU_RECHAZO As String
    Dim EE_EST_DESCRIPCION As String
    Dim EE_PAC_NOMBRE As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_USU_NIC As String
    '-----------------------------
    Dim EE_DOC_NOMBRE As String
    Dim EE_DOC_APELLIDO As String
    Dim EE_PREVE_DESC As String
    Dim EE_PROC_DESC As String

    Dim EE_ATE_NUM_OMI As String
    Dim EE_ATE_CODIGO_TEST As String

    Public Property ID_CODIGO_FONASA As Integer
    Public Property TP_RECHA_DESC As String
    Public Property ATE_CODIGO_TEST As String
        Get
            Return EE_ATE_CODIGO_TEST
        End Get
        Set(value As String)
            EE_ATE_CODIGO_TEST = value
        End Set
    End Property

    Public Property ATE_NUM_OMI As String
        Get
            Return EE_ATE_NUM_OMI
        End Get
        Set(value As String)
            EE_ATE_NUM_OMI = value
        End Set
    End Property
    Public Property PROC_DESC As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(value As String)
            EE_PROC_DESC = value
        End Set
    End Property
    Public Property PREVE_DESC As String
        Get
            Return EE_PREVE_DESC
        End Get
        Set(value As String)
            EE_PREVE_DESC = value
        End Set
    End Property
    Public Property DOC_APELLIDO As String
        Get
            Return EE_DOC_APELLIDO
        End Get
        Set(value As String)
            EE_DOC_APELLIDO = value
        End Set
    End Property
    Public Property DOC_NOMBRE As String
        Get
            Return EE_DOC_NOMBRE
        End Get
        Set(value As String)
            EE_DOC_NOMBRE = value
        End Set
    End Property

    Public Property USU_NIC As String
        Get
            Return EE_USU_NIC
        End Get
        Set(value As String)
            EE_USU_NIC = value
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
    Public Property PAC_NOMBRE As String
        Get
            Return EE_PAC_NOMBRE
        End Get
        Set(value As String)
            EE_PAC_NOMBRE = value
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

    Public Property ATE_USU_RECHAZO As String
        Get
            Return EE_ATE_USU_RECHAZO
        End Get
        Set(value As String)
            EE_ATE_USU_RECHAZO = value
        End Set
    End Property
    Public Property ATE_FEC_RECHAZO As Date
        Get
            Return EE_ATE_FEC_RECHAZO
        End Get
        Set(value As Date)
            EE_ATE_FEC_RECHAZO = value
        End Set
    End Property
    Public Property ID_PRUEBA As Integer
        Get
            Return EE_ID_PRUEBA
        End Get
        Set(value As Integer)
            EE_ID_PRUEBA = value
        End Set
    End Property
    Public Property ID_T_MUESTRA As Integer
        Get
            Return EE_ID_T_MUESTRA
        End Get
        Set(value As Integer)
            EE_ID_T_MUESTRA = value
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

    Public Property ID_ATENCION As Integer
        Get
            Return EE_ID_ATENCION
        End Get
        Set(value As Integer)
            EE_ID_ATENCION = value
        End Set
    End Property

    Public Property ID_PER As Integer
        Get
            Return EE_ID_PER
        End Get
        Set(value As Integer)
            EE_ID_PER = value
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

    Public Property CB_DESC As String
        Get
            Return EE_CB_DESC
        End Get
        Set(value As String)
            EE_CB_DESC = value
        End Set
    End Property

    Public Property Expr1 As Integer
        Get
            Return EE_Expr1
        End Get
        Set(value As Integer)
            EE_Expr1 = value
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

    Public Property ATE_EST_RECHAZO As String
        Get
            Return EE_ATE_EST_RECHAZO
        End Get
        Set(value As String)
            EE_ATE_EST_RECHAZO = value
        End Set
    End Property
End Class
