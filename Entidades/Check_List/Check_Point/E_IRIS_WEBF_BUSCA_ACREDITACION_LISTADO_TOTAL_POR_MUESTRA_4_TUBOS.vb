Public Class E_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_4_TUBOS
    Dim EE_ID_T_MUESTRA As Integer
    Dim EE_ATE_NUM As Integer
    Dim EE_T_MUESTRA_DESC As String
    Dim EE_CB_DESC As String
    Dim EE_Expr1 As String
    Dim EE_ID_ATENCION As Integer
    Dim EE_GMUE_DESC As String
    Dim EE_ATE_FECHA As Date
    Dim EE_ID_RECEP_ETI As Integer
    Dim EE_ID_RECEP_ETI_RECHAZO As Integer
    Dim EE_ID_RECEP_ETI_DERIVA As Integer
    Dim EE_PAC_RUT As String
    Dim EE_PAC_NOMBRE As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_ATE_NUM_INTERNO As String
    Dim EE_PROC_DESC As String

    Public Property PROC_DESC As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(value As String)
            EE_PROC_DESC = value
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

    Public Property Expr1 As String
        Get
            Return EE_Expr1
        End Get
        Set(value As String)
            EE_Expr1 = value
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

    Public Property GMUE_DESC As String
        Get
            Return EE_GMUE_DESC
        End Get
        Set(value As String)
            EE_GMUE_DESC = value
        End Set
    End Property

    Public Property ATE_FECHA As Date
        Get
            Return EE_ATE_FECHA
        End Get
        Set(value As Date)
            EE_ATE_FECHA = value
        End Set
    End Property

    Public Property ID_RECEP_ETI As Integer
        Get
            Return EE_ID_RECEP_ETI
        End Get
        Set(value As Integer)
            EE_ID_RECEP_ETI = value
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

    Public Property ID_RECEP_ETI_DERIVA As Integer
        Get
            Return EE_ID_RECEP_ETI_DERIVA
        End Get
        Set(value As Integer)
            EE_ID_RECEP_ETI_DERIVA = value
        End Set
    End Property

    Public Property PAC_RUT As String
        Get
            Return EE_PAC_RUT
        End Get
        Set(value As String)
            EE_PAC_RUT = value
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

    Public Property ATE_NUM_INTERNO As String
        Get
            Return EE_ATE_NUM_INTERNO
        End Get
        Set(value As String)
            EE_ATE_NUM_INTERNO = value
        End Set
    End Property
End Class
