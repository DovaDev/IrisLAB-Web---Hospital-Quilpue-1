Public Class E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO
    Dim EE_ID_T_MUESTRA As Integer
    Dim EE_ATE_NUM As Integer
    Dim EE_T_MUESTRA_DESC As String
    Dim EE_CB_DESC As String
    Dim EE_IDTM As Integer
    Dim EE_ID_ATENCION As Integer
    Dim EE_GMUE_DESC As String
    Dim EE_ATE_FECHA As Date
    Dim EE_ATE_FEC_RECEP As Date
    Dim EE_ATE_USU_RECEP As String
    Dim EE_ATE_EST_RECEP As String
    Dim EE_ATE_EST_RECEP_DESC As String
    Dim EE_EST_DESCRIPCION As String
    Dim EE_CF_DESC As String
    Dim EE_PAC_NOMBRE As String
    Dim EE_ID_PER As Integer
    Dim EE_PAC_APELLIDO As String
    Dim EE_PAC_RUT As String
    Dim EE_PROC_DESC As String
    Dim EE_ID_PACIENTE As Integer
    Dim EE_ATE_AÑO As Integer
    Dim EE_ID_SEXO As Integer
    Dim EE_ATE_EST_RECHAZO As String
    Dim EE_ATE_EST_RECHAZO_DESC As String
    Dim EE_ATE_FEC_RECHAZO As Date
    Dim EE_ATE_USU_RECHAZO As String
    Dim EE_ATE_EST_DERIVA As String
    Dim EE_ATE_EST_DERIVA_DESC As String
    Dim EE_ATE_FEC_DERIVA As Date
    Dim EE_ATE_USU_DERIVA As String
    Dim EE_ID_CODIGO_FONASA As Integer
    Dim EE_ATE_DET_V_ID_ESTADO As Integer
    Dim EE_ATE_DET_REV_ID_ESTADO As Integer
    Dim EE_Expr1 As String
    Dim EE_Expr2 As String
    Dim EE_NAte As Integer
    Dim EE_NExa As Integer
    Dim EE_recSi As Integer
    Dim EE_recNo As Integer
    Dim EE_valiSi As Integer
    Dim EE_valiNo As Integer
    Dim EE_total As Integer
    Dim EE_rechSi As Integer
    Dim EE_rechNo As Integer
    Dim EE_ATE_EST_ENVIO As String
    Dim EE_Expr3 As String
    Dim EE_ATE_FEC_ENVIO As Date
    Dim EE_UENVIO As String
    Dim EE_EST_E As String
    Dim EE_ATE_EST_ENVIO_DESC As String

    Dim EE_ACTIVADOR As String
    Dim EE_MOSTRAR As String
    Dim EE_ENVIO_FECHA_RECEP As Date
    Dim EE_ID_USUARIO_RECEP As Integer
    Dim EE_ID_ESTADO_RECEP As Integer
    Dim EE_USUARIO_ENV_RECEP As String


    'Check tm
    Private EE_CUP As Integer
    Private EE_CVC As Integer
    Private EE_PICCLINE As Integer
    Private EE_TET As Integer
    Private EE_TQT As Integer
    Private EE_AREpi As Integer

    Dim EE_USUARIO_DERI As String

    Dim EE_USUARIO_RECH As String

    Dim EE_HISTO_ATE_FECHA As String
    Dim EE_TP_HIS_ATE_DESC As String
    Dim EE_USUARIO_EX As String
    Dim EE_ESTADO_DET_ATE As Integer
    Dim EE_ID_TP_HIS_ATENCION As Integer
    Dim EE_tmSi As Integer
    Dim EE_tmNo As Integer


    Public Property tmSi As Integer
        Get
            Return EE_tmSi
        End Get
        Set(value As Integer)
            EE_tmSi = value
        End Set
    End Property

    Public Property tmNo As Integer
        Get
            Return EE_tmNo
        End Get
        Set(value As Integer)
            EE_tmNo = value
        End Set
    End Property
    Public Property USUARIO_DERI As String
        Get
            Return EE_USUARIO_DERI
        End Get
        Set(value As String)
            EE_USUARIO_DERI = value
        End Set
    End Property
    Public Property USUARIO_ENV_RECEP As String
        Get
            Return EE_USUARIO_ENV_RECEP
        End Get
        Set(value As String)
            EE_USUARIO_ENV_RECEP = value
        End Set
    End Property
    Public Property ID_ESTADO_RECEP As Integer
        Get
            Return EE_ID_ESTADO_RECEP
        End Get
        Set(value As Integer)
            EE_ID_ESTADO_RECEP = value
        End Set
    End Property
    Public Property ID_USUARIO_RECEP As Integer
        Get
            Return EE_ID_USUARIO_RECEP
        End Get
        Set(value As Integer)
            EE_ID_USUARIO_RECEP = value
        End Set
    End Property
    Public Property ENVIO_FECHA_RECEP As Date
        Get
            Return EE_ENVIO_FECHA_RECEP
        End Get
        Set(value As Date)
            EE_ENVIO_FECHA_RECEP = value
        End Set
    End Property
    Public Property MOSTRAR As String
        Get
            Return EE_MOSTRAR
        End Get
        Set(value As String)
            EE_MOSTRAR = value
        End Set
    End Property
    Public Property ACTIVADOR As String
        Get
            Return EE_ACTIVADOR
        End Get
        Set(value As String)
            EE_ACTIVADOR = value
        End Set
    End Property

    Public Property ATE_EST_ENVIO_DESC As String
        Get
            Return EE_ATE_EST_ENVIO_DESC
        End Get
        Set(value As String)
            EE_ATE_EST_ENVIO_DESC = value
        End Set
    End Property
    Public Property ATE_FEC_ENVIO As Date
        Get
            Return EE_ATE_FEC_ENVIO
        End Get
        Set(value As Date)
            EE_ATE_FEC_ENVIO = value
        End Set
    End Property
    Public Property UENVIO As String
        Get
            Return EE_UENVIO
        End Get
        Set(value As String)
            EE_UENVIO = value
        End Set
    End Property

    Public Property EST_E As String
        Get
            Return EE_EST_E
        End Get
        Set(value As String)
            EE_EST_E = value
        End Set
    End Property
    '--------------------------------------------------------------------
    Dim EE_TP_RECHA_DESC As String
    Dim EE_RECEP_ETI_RECHAZO_OBS As String
    '--------------------------------------------------------------------
    Dim EE_USU_PREINGRESO As String
    Dim EE_FECHA_PREINGRESO As Date
    Dim EE_PREINGRESO_DESC As String
    '--------------------------------------------------------------------
    Dim EE_USU_INGRESO As String
    Dim EE_FECHA_INGRESO As Date
    Dim EE_INGRESO_DESC As String
    '--------------------------------------------------------------------
    Dim EE_ATE_FEC_TM As Date
    Dim EE_ATE_USU_TM As String
    Dim EE_ATE_EST_TM As String
    Dim EE_ATE_EST_TM_DESC As String
    '-------------------------------------------------------------------
    Dim EE_ATE_FEC_VALIDA As Date
    Dim EE_ATE_USU_VALIDA As String
    Dim EE_ATE_EST_VALIDA As String
    Dim EE_ATE_EST_VALIDA_DESC As String
    '-------------------------------------------------------------------
    Dim EE_ATE_EST_IMP_DESC As String
    Public Property ATE_EST_ENVIO As String
        Get
            Return EE_ATE_EST_ENVIO
        End Get
        Set(value As String)
            EE_ATE_EST_ENVIO = value
        End Set
    End Property
    Public Property Expr3 As String
        Get
            Return EE_Expr3
        End Get
        Set(value As String)
            EE_Expr3 = value
        End Set
    End Property
    '--------------------------------------------------------------------
    Public Property ATE_EST_IMP_DESC As String
        Get
            Return EE_ATE_EST_IMP_DESC
        End Get
        Set(value As String)
            EE_ATE_EST_IMP_DESC = value
        End Set
    End Property
    '-------------------------------------------------------------------
    Public Property ATE_FEC_RECEP As Date
        Get
            Return EE_ATE_FEC_RECEP
        End Get
        Set(value As Date)
            EE_ATE_FEC_RECEP = value
        End Set
    End Property

    Public Property ATE_USU_RECEP As String
        Get
            Return EE_ATE_USU_RECEP
        End Get
        Set(value As String)
            EE_ATE_USU_RECEP = value
        End Set
    End Property
    '-------------------------------------------------------------------
    Public Property ATE_FEC_VALIDA As Date
        Get
            Return EE_ATE_FEC_VALIDA
        End Get
        Set(value As Date)
            EE_ATE_FEC_VALIDA = value
        End Set
    End Property

    Public Property ATE_USU_VALIDA As String
        Get
            Return EE_ATE_USU_VALIDA
        End Get
        Set(value As String)
            EE_ATE_USU_VALIDA = value
        End Set
    End Property

    Public Property ATE_EST_VALIDA As String
        Get
            Return EE_ATE_EST_VALIDA
        End Get
        Set(value As String)
            EE_ATE_EST_VALIDA = value
        End Set
    End Property
    Public Property ATE_EST_VALIDA_DESC As String
        Get
            Return EE_ATE_EST_VALIDA_DESC
        End Get
        Set(value As String)
            EE_ATE_EST_VALIDA_DESC = value
        End Set
    End Property
    '-------------------------------------------------------------------
    Public Property ATE_FEC_TM As Date
        Get
            Return EE_ATE_FEC_TM
        End Get
        Set(value As Date)
            EE_ATE_FEC_TM = value
        End Set
    End Property

    Public Property ATE_USU_TM As String
        Get
            Return EE_ATE_USU_TM
        End Get
        Set(value As String)
            EE_ATE_USU_TM = value
        End Set
    End Property

    Public Property ATE_EST_TM As String
        Get
            Return EE_ATE_EST_TM
        End Get
        Set(value As String)
            EE_ATE_EST_TM = value
        End Set
    End Property
    Public Property ATE_EST_TM_DESC As String
        Get
            Return EE_ATE_EST_TM_DESC
        End Get
        Set(value As String)
            EE_ATE_EST_TM_DESC = value
        End Set
    End Property
    '-------------------------------------------------------------------
    Public Property USU_INGRESO As String
        Get
            Return EE_USU_INGRESO
        End Get
        Set(value As String)
            EE_USU_INGRESO = value
        End Set
    End Property
    Public Property FECHA_INGRESO As Date
        Get
            Return EE_FECHA_INGRESO
        End Get
        Set(value As Date)
            EE_FECHA_INGRESO = value
        End Set
    End Property
    Public Property INGRESO_DESC As String
        Get
            Return EE_INGRESO_DESC
        End Get
        Set(value As String)
            EE_INGRESO_DESC = value
        End Set
    End Property
    '--------------------------------------------------------------------
    Public Property USU_PREINGRESO As String
        Get
            Return EE_USU_PREINGRESO
        End Get
        Set(value As String)
            EE_USU_PREINGRESO = value
        End Set
    End Property
    Public Property FECHA_PREINGRESO As Date
        Get
            Return EE_FECHA_PREINGRESO
        End Get
        Set(value As Date)
            EE_FECHA_PREINGRESO = value
        End Set
    End Property
    Public Property PREINGRESO_DESC As String
        Get
            Return EE_PREINGRESO_DESC
        End Get
        Set(value As String)
            EE_PREINGRESO_DESC = value
        End Set
    End Property
    '-------------------------------------------------------------------
    Public Property RECEP_ETI_RECHAZO_OBS As String
        Get
            Return EE_RECEP_ETI_RECHAZO_OBS
        End Get
        Set(value As String)
            EE_RECEP_ETI_RECHAZO_OBS = value
        End Set
    End Property
    Public Property TP_RECHA_DESC As String
        Get
            Return EE_TP_RECHA_DESC
        End Get
        Set(value As String)
            EE_TP_RECHA_DESC = value
        End Set
    End Property
    '--------------------------------------------------------------------
    Public Property rechNo() As Integer
        Get
            Return EE_rechNo
        End Get
        Set(ByVal value As Integer)
            EE_rechNo = value
        End Set
    End Property
    Public Property rechSi() As Integer
        Get
            Return EE_rechSi
        End Get
        Set(ByVal value As Integer)
            EE_rechSi = value
        End Set
    End Property
    Public Property total() As Integer
        Get
            Return EE_total
        End Get
        Set(ByVal value As Integer)
            EE_total = value
        End Set
    End Property
    Public Property valiNo() As Integer
        Get
            Return EE_valiNo
        End Get
        Set(ByVal value As Integer)
            EE_valiNo = value
        End Set
    End Property
    Public Property valiSi() As Integer
        Get
            Return EE_valiSi
        End Get
        Set(ByVal value As Integer)
            EE_valiSi = value
        End Set
    End Property
    Public Property recNo() As Integer
        Get
            Return EE_recNo
        End Get
        Set(ByVal value As Integer)
            EE_recNo = value
        End Set
    End Property
    Public Property recSi() As Integer
        Get
            Return EE_recSi
        End Get
        Set(ByVal value As Integer)
            EE_recSi = value
        End Set
    End Property
    Public Property NExa() As Integer
        Get
            Return EE_NExa
        End Get
        Set(ByVal value As Integer)
            EE_NExa = value
        End Set
    End Property
    Public Property NAte() As Integer
        Get
            Return EE_NAte
        End Get
        Set(ByVal value As Integer)
            EE_NAte = value
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

    Public Property IDTM As Integer
        Get
            Return EE_IDTM
        End Get
        Set(value As Integer)
            EE_IDTM = value
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

    Public Property ATE_EST_RECEP As String
        Get
            Return EE_ATE_EST_RECEP
        End Get
        Set(value As String)
            EE_ATE_EST_RECEP = value
        End Set
    End Property
    Public Property ATE_EST_RECEP_DESC As String
        Get
            Return EE_ATE_EST_RECEP_DESC
        End Get
        Set(value As String)
            EE_ATE_EST_RECEP_DESC = value
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

    Public Property CF_DESC As String
        Get
            Return EE_CF_DESC
        End Get
        Set(value As String)
            EE_CF_DESC = value
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

    Public Property ID_PER As Integer
        Get
            Return EE_ID_PER
        End Get
        Set(value As Integer)
            EE_ID_PER = value
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

    Public Property PAC_RUT As String
        Get
            Return EE_PAC_RUT
        End Get
        Set(value As String)
            EE_PAC_RUT = value
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

    Public Property ID_PACIENTE As Integer
        Get
            Return EE_ID_PACIENTE
        End Get
        Set(value As Integer)
            EE_ID_PACIENTE = value
        End Set
    End Property

    Public Property ATE_AÑO As Integer
        Get
            Return EE_ATE_AÑO
        End Get
        Set(value As Integer)
            EE_ATE_AÑO = value
        End Set
    End Property

    Public Property ID_SEXO As Integer
        Get
            Return EE_ID_SEXO
        End Get
        Set(value As Integer)
            EE_ID_SEXO = value
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
    Public Property ATE_EST_RECHAZO_DESC As String
        Get
            Return EE_ATE_EST_RECHAZO_DESC
        End Get
        Set(value As String)
            EE_ATE_EST_RECHAZO_DESC = value
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

    Public Property ATE_USU_RECHAZO As String
        Get
            Return EE_ATE_USU_RECHAZO
        End Get
        Set(value As String)
            EE_ATE_USU_RECHAZO = value
        End Set
    End Property

    Public Property ATE_EST_DERIVA_DESC As String
        Get
            Return EE_ATE_EST_DERIVA_DESC
        End Get
        Set(value As String)
            EE_ATE_EST_DERIVA_DESC = value
        End Set
    End Property
    Public Property ATE_USU_DERIVA As String
        Get
            Return EE_ATE_USU_DERIVA
        End Get
        Set(value As String)
            EE_ATE_USU_DERIVA = value
        End Set
    End Property

    Public Property ATE_EST_DERIVA As String
        Get
            Return EE_ATE_EST_DERIVA
        End Get
        Set(value As String)
            EE_ATE_EST_DERIVA = value
        End Set
    End Property
    Public Property ATE_FEC_DERIVA As Date
        Get
            Return EE_ATE_FEC_DERIVA
        End Get
        Set(value As Date)
            EE_ATE_FEC_DERIVA = value
        End Set
    End Property

    Public Property ID_CODIGO_FONASA As Integer
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(value As Integer)
            EE_ID_CODIGO_FONASA = value
        End Set
    End Property

    Public Property ATE_DET_V_ID_ESTADO As Integer
        Get
            Return EE_ATE_DET_V_ID_ESTADO
        End Get
        Set(value As Integer)
            EE_ATE_DET_V_ID_ESTADO = value
        End Set
    End Property

    Public Property ATE_DET_REV_ID_ESTADO As Integer
        Get
            Return EE_ATE_DET_REV_ID_ESTADO
        End Get
        Set(value As Integer)
            EE_ATE_DET_REV_ID_ESTADO = value
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

    Public Property Expr2 As String
        Get
            Return EE_Expr2
        End Get
        Set(value As String)
            EE_Expr2 = value
        End Set
    End Property

    Public Property CUP As Integer
        Get
            Return EE_CUP
        End Get
        Set(value As Integer)
            EE_CUP = value
        End Set
    End Property

    Public Property CVC As Integer
        Get
            Return EE_CVC
        End Get
        Set(value As Integer)
            EE_CVC = value
        End Set
    End Property

    Public Property PICCLINE As Integer
        Get
            Return EE_PICCLINE
        End Get
        Set(value As Integer)
            EE_PICCLINE = value
        End Set
    End Property

    Public Property TET As Integer
        Get
            Return EE_TET
        End Get
        Set(value As Integer)
            EE_TET = value
        End Set
    End Property

    Public Property TQT As Integer
        Get
            Return EE_TQT
        End Get
        Set(value As Integer)
            EE_TQT = value
        End Set
    End Property

    Public Property AREpi As Integer
        Get
            Return EE_AREpi
        End Get
        Set(value As Integer)
            EE_AREpi = value
        End Set
    End Property

    Public Property USUARIO_RECH As String
        Get
            Return EE_USUARIO_RECH
        End Get
        Set(value As String)
            EE_USUARIO_RECH = value
        End Set
    End Property

    Public Property HISTO_ATE_FECHA As String
        Get
            Return EE_HISTO_ATE_FECHA
        End Get
        Set(value As String)
            EE_HISTO_ATE_FECHA = value
        End Set
    End Property

    Public Property TP_HIS_ATE_DESC As String
        Get
            Return EE_TP_HIS_ATE_DESC
        End Get
        Set(value As String)
            EE_TP_HIS_ATE_DESC = value
        End Set
    End Property

    Public Property USUARIO_EX As String
        Get
            Return EE_USUARIO_EX
        End Get
        Set(value As String)
            EE_USUARIO_EX = value
        End Set
    End Property

    Public Property ESTADO_DET_ATE As Integer
        Get
            Return EE_ESTADO_DET_ATE
        End Get
        Set(value As Integer)
            EE_ESTADO_DET_ATE = value
        End Set
    End Property

    Public Property ID_TP_HIS_ATENCION As Integer
        Get
            Return EE_ID_TP_HIS_ATENCION
        End Get
        Set(value As Integer)
            EE_ID_TP_HIS_ATENCION = value
        End Set
    End Property
End Class
