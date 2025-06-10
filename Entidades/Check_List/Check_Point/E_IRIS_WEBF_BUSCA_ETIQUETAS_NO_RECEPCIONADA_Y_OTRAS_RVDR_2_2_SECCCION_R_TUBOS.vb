Public Class E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_R_TUBOS
    Private EE_ID_T_MUESTRA As Integer
    Private EE_ATE_NUM As Integer
    Private EE_T_MUESTRA_DESC As String
    Private EE_CB_DESC As String
    Private EE_IDTM As Integer
    Private EE_ID_ATENCION As Integer
    Private EE_GMUE_DESC As String
    Private EE_ATE_FECHA As Date
    Private EE_ATE_NUM_INTERNO As String
    Private EE_ATE_EST_RECEP As String
    Private EE_EST_DECRIPCION As String
    Private EE_CF_DESC As String
    Private EE_PAC_NOMBRE As String
    Private EE_PAC_APELLIDO As String
    Private EE_PAC_RUT As String
    Private EE_PROC_DESC As String
    Private EE_ID_PACIENTE As Integer
    Private EE_ATE_AÑO As String
    Private EE_ID_SEXO As Integer
    Private EE_ATE_EST_RECHAZO As String
    Private EE_ATE_EST_DERIVA As String
    Private EE_ID_CODIGO_FONASA As Integer
    Private EE_ATE_DET_V_ID_ESTADO As String
    Private EE_ATE_DET_REV_ID_ESTADO As String
    Private EE_Expr1 As String
    Private EE_Expr2 As String
    Private EE_ENCRYPTED_ID As String
    Public Property ENCRYPTED_ID() As String
        Get
            Return EE_ENCRYPTED_ID
        End Get
        Set(ByVal value As String)
            EE_ENCRYPTED_ID = value
        End Set
    End Property
    Public Property Expr2() As String
        Get
            Return EE_Expr2
        End Get
        Set(ByVal value As String)
            EE_Expr2 = value
        End Set
    End Property
    Public Property Expr1() As String
        Get
            Return EE_Expr1
        End Get
        Set(ByVal value As String)
            EE_Expr1 = value
        End Set
    End Property
    Public Property ATE_DET_REV_ID_ESTADO() As String
        Get
            Return EE_ATE_DET_REV_ID_ESTADO
        End Get
        Set(ByVal value As String)
            EE_ATE_DET_REV_ID_ESTADO = value
        End Set
    End Property
    Public Property ATE_DET_V_ID_ESTADO() As String
        Get
            Return EE_ATE_DET_V_ID_ESTADO
        End Get
        Set(ByVal value As String)
            EE_ATE_DET_V_ID_ESTADO = value
        End Set
    End Property
    Public Property ID_CODIGO_FONASA() As Integer
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(ByVal value As Integer)
            EE_ID_CODIGO_FONASA = value
        End Set
    End Property
    Public Property ATE_EST_DERIVA() As String
        Get
            Return EE_ATE_EST_DERIVA
        End Get
        Set(ByVal value As String)
            EE_ATE_EST_DERIVA = value
        End Set
    End Property
    Public Property ATE_EST_RECHAZO() As String
        Get
            Return EE_ATE_EST_RECHAZO
        End Get
        Set(ByVal value As String)
            EE_ATE_EST_RECHAZO = value
        End Set
    End Property
    Public Property ID_SEXO() As Integer
        Get
            Return EE_ID_SEXO
        End Get
        Set(ByVal value As Integer)
            EE_ID_SEXO = value
        End Set
    End Property
    Public Property ATE_AÑO() As String
        Get
            Return EE_ATE_AÑO
        End Get
        Set(ByVal value As String)
            EE_ATE_AÑO = value
        End Set
    End Property
    Public Property ID_PACIENTE() As Integer
        Get
            Return EE_ID_PACIENTE
        End Get
        Set(ByVal value As Integer)
            EE_ID_PACIENTE = value
        End Set
    End Property
    Public Property PROC_DESC() As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(ByVal value As String)
            EE_PROC_DESC = value
        End Set
    End Property
    Public Property PAC_RUT() As String
        Get
            Return EE_PAC_RUT
        End Get
        Set(ByVal value As String)
            EE_PAC_RUT = value
        End Set
    End Property
    Public Property PAC_APELLIDO() As String
        Get
            Return EE_PAC_APELLIDO
        End Get
        Set(ByVal value As String)
            EE_PAC_APELLIDO = value
        End Set
    End Property
    Public Property PAC_NOMBRE() As String
        Get
            Return EE_PAC_NOMBRE
        End Get
        Set(ByVal value As String)
            EE_PAC_NOMBRE = value
        End Set
    End Property
    Public Property CF_DESC() As String
        Get
            Return EE_CF_DESC
        End Get
        Set(ByVal value As String)
            EE_CF_DESC = value
        End Set
    End Property
    Public Property EST_DESCRIPCION() As String
        Get
            Return EE_EST_DECRIPCION
        End Get
        Set(ByVal value As String)
            EE_EST_DECRIPCION = value
        End Set
    End Property
    Public Property ATE_EST_RECEP() As String
        Get
            Return EE_ATE_EST_RECEP
        End Get
        Set(ByVal value As String)
            EE_ATE_EST_RECEP = value
        End Set
    End Property
    Public Property ATE_NUM_INTERNO() As String
        Get
            Return EE_ATE_NUM_INTERNO
        End Get
        Set(ByVal value As String)
            EE_ATE_NUM_INTERNO = value
        End Set
    End Property
    Public Property ATE_FECHA() As Date
        Get
            Return EE_ATE_FECHA
        End Get
        Set(ByVal value As Date)
            EE_ATE_FECHA = value
        End Set
    End Property
    Public Property GMUE_DESC() As String
        Get
            Return EE_GMUE_DESC
        End Get
        Set(ByVal value As String)
            EE_GMUE_DESC = value
        End Set
    End Property
    Public Property ID_ATENCION() As Integer
        Get
            Return EE_ID_ATENCION
        End Get
        Set(ByVal value As Integer)
            EE_ID_ATENCION = value
        End Set
    End Property
    Public Property IDTM() As Integer
        Get
            Return EE_IDTM
        End Get
        Set(ByVal value As Integer)
            EE_IDTM = value
        End Set
    End Property
    Public Property CB_DESC() As String
        Get
            Return EE_CB_DESC
        End Get
        Set(ByVal value As String)
            EE_CB_DESC = value
        End Set
    End Property
    Public Property T_MUESTRA_DESC() As String
        Get
            Return EE_T_MUESTRA_DESC
        End Get
        Set(ByVal value As String)
            EE_T_MUESTRA_DESC = value
        End Set
    End Property
    Public Property ATE_NUM() As String
        Get
            Return EE_ATE_NUM
        End Get
        Set(ByVal value As String)
            EE_ATE_NUM = value
        End Set
    End Property
    Public Property ID_T_MUESTRA() As Integer
        Get
            Return EE_ID_T_MUESTRA
        End Get
        Set(ByVal value As Integer)
            EE_ID_T_MUESTRA = value
        End Set
    End Property
End Class
