Public Class E_IRIS_WEBF_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN2
    Private E_ID_ATE_RES As Long
    Private E_TP_RESUL_COD As String
    Private E_UM_DESC As String
    Private E_ID_U_MEDIDA_1 As Long
    Private E_PRU_DESC As String
    Private E_ID_PRUEBA As Long
    Private E_ID_PER As Long
    Private E_PRU_P_CERO As Integer
    Private E_ATE_RESULTADO As String
    Private E_ATE_R_DESDE As String
    Private E_ATE_R_HASTA As String
    Private E_ID_ESTADO As Integer
    Private E_PRU_ORDEN As Long
    Private E_PRU_COD As String
    Private E_PRU_DECIMAL As Integer
    Private E_CF_CORTO As String
    Private E_ID_ATENCION As Long
    Private E_ID_U_MEDIDA_2 As Long
    Private E_ID_TP_RESULTADO As Long
    Private E_PRU_RESU_INMEDIATO As String
    Private E_ATE_EST_VALIDA As Integer
    Private E_EST_COD As String
    Private E_ATE_RESULTADO_NUM As String
    Private E_ID_RLS_LS As Long
    Private E_ID_CODIGO_FONASA As Integer
    Private E_ATE_RR_DESDE As String
    Private E_ATE_RR_HASTA As String
    Private E_ATE_RR_ALTOBAJO As Long
    Private E_ATE_EST_RECHAZO As Integer
    Private E_ATE_EST_DERIVA As Integer
    Private E_ATE_RESULTADO_ALT As String
    Private E_RES_HIST As String
    Private E_RES_HIST_NUM As String
    Private EE_RES_HIST_FECHA As Date
    Private EE_RF_V_B_DESDE As String
    Private EE_RF_V_DESDE As String
    Private EE_RF_V_HASTA As String
    Private EE_RF_V_A_HASTA As String
    Private EE_RF_R_TEXTO As String
    Public CANTIDAD_DE_HISTORICOS As Integer
    Public RECHAZADO As Boolean
    Public RECEPCIONADO As Boolean

    Private E_ATE_REV_ID_ESTADO As Integer
    Private E_ATE_DET_REV_ID_ESTADO As Integer

    Private E_ID_DET_ATE As Integer
    Public Property RF_V_A_HASTA() As String
        Get
            Return EE_RF_V_A_HASTA
        End Get
        Set(ByVal value As String)
            EE_RF_V_A_HASTA = value
        End Set
    End Property
    Public Property RF_V_HASTA() As String
        Get
            Return EE_RF_V_HASTA
        End Get
        Set(ByVal value As String)
            EE_RF_V_HASTA = value
        End Set
    End Property
    Public Property RF_V_DESDE() As String
        Get
            Return EE_RF_V_DESDE
        End Get
        Set(ByVal value As String)
            EE_RF_V_DESDE = value
        End Set
    End Property
    Public Property RF_V_B_DESDE() As String
        Get
            Return EE_RF_V_B_DESDE
        End Get
        Set(ByVal value As String)
            EE_RF_V_B_DESDE = value
        End Set
    End Property
    Public Property RES_HIST_FECHA() As Date
        Get
            Return EE_RES_HIST_FECHA
        End Get
        Set(ByVal value As Date)
            EE_RES_HIST_FECHA = value
        End Set
    End Property
    Public Property RES_HIST_NUM() As String
        Get
            Return E_RES_HIST_NUM
        End Get
        Set(ByVal value As String)
            E_RES_HIST_NUM = value
        End Set
    End Property
    Public Property RES_HIST() As String
        Get
            Return E_RES_HIST
        End Get
        Set(ByVal value As String)
            E_RES_HIST = value
        End Set
    End Property

    Public Property ID_ATE_RES As Long
        Get
            Return E_ID_ATE_RES
        End Get
        Set(value As Long)
            E_ID_ATE_RES = value
        End Set
    End Property
    Public Property TP_RESUL_COD As String
        Get
            Return E_TP_RESUL_COD
        End Get
        Set(value As String)
            E_TP_RESUL_COD = value
        End Set
    End Property
    Public Property UM_DESC As String
        Get
            Return E_UM_DESC
        End Get
        Set(value As String)
            E_UM_DESC = value
        End Set
    End Property
    Public Property ID_U_MEDIDA_1 As Long
        Get
            Return E_ID_U_MEDIDA_1
        End Get
        Set(value As Long)
            E_ID_U_MEDIDA_1 = value
        End Set
    End Property
    Public Property PRU_DESC As String
        Get
            Return E_PRU_DESC
        End Get
        Set(value As String)
            E_PRU_DESC = value
        End Set
    End Property
    Public Property ID_PRUEBA As Long
        Get
            Return E_ID_PRUEBA
        End Get
        Set(value As Long)
            E_ID_PRUEBA = value
        End Set
    End Property
    Public Property ID_PER As Long
        Get
            Return E_ID_PER
        End Get
        Set(value As Long)
            E_ID_PER = value
        End Set
    End Property
    Public Property PRU_P_CERO As Integer
        Get
            Return E_PRU_P_CERO
        End Get
        Set(value As Integer)
            E_PRU_P_CERO = value
        End Set
    End Property
    Public Property ATE_RESULTADO As String
        Get
            Return E_ATE_RESULTADO
        End Get
        Set(value As String)
            E_ATE_RESULTADO = value
        End Set
    End Property
    Public Property ATE_R_DESDE As String
        Get
            Return E_ATE_R_DESDE
        End Get
        Set(value As String)
            E_ATE_R_DESDE = value
        End Set
    End Property
    Public Property ATE_R_HASTA As String
        Get
            Return E_ATE_R_HASTA
        End Get
        Set(value As String)
            E_ATE_R_HASTA = value
        End Set
    End Property
    Public Property ID_ESTADO As Integer
        Get
            Return E_ID_ESTADO
        End Get
        Set(value As Integer)
            E_ID_ESTADO = value
        End Set
    End Property
    Public Property PRU_ORDEN As Long
        Get
            Return E_PRU_ORDEN
        End Get
        Set(value As Long)
            E_PRU_ORDEN = value
        End Set
    End Property
    Public Property PRU_COD As String
        Get
            Return E_PRU_COD
        End Get
        Set(value As String)
            E_PRU_COD = value
        End Set
    End Property
    Public Property PRU_DECIMAL As Integer
        Get
            Return E_PRU_DECIMAL
        End Get
        Set(value As Integer)
            E_PRU_DECIMAL = value
        End Set
    End Property
    Public Property CF_CORTO As String
        Get
            Return E_CF_CORTO
        End Get
        Set(value As String)
            E_CF_CORTO = value
        End Set
    End Property
    Public Property ID_ATENCION As Long
        Get
            Return E_ID_ATENCION
        End Get
        Set(value As Long)
            E_ID_ATENCION = value
        End Set
    End Property
    Public Property ID_U_MEDIDA_2 As Long
        Get
            Return E_ID_U_MEDIDA_2
        End Get
        Set(value As Long)
            E_ID_U_MEDIDA_2 = value
        End Set
    End Property
    Public Property ID_TP_RESULTADO As Long
        Get
            Return E_ID_TP_RESULTADO
        End Get
        Set(value As Long)
            E_ID_TP_RESULTADO = value
        End Set
    End Property
    Public Property PRU_RESU_INMEDIATO As String
        Get
            Return E_PRU_RESU_INMEDIATO
        End Get
        Set(value As String)
            E_PRU_RESU_INMEDIATO = value
        End Set
    End Property
    Public Property ATE_EST_VALIDA As Integer
        Get
            Return E_ATE_EST_VALIDA
        End Get
        Set(value As Integer)
            E_ATE_EST_VALIDA = value
        End Set
    End Property
    Public Property EST_COD As String
        Get
            Return E_EST_COD
        End Get
        Set(value As String)
            E_EST_COD = value
        End Set
    End Property
    Public Property ATE_RESULTADO_NUM As String
        Get
            Return E_ATE_RESULTADO_NUM
        End Get
        Set(value As String)
            E_ATE_RESULTADO_NUM = value
        End Set
    End Property
    Public Property ID_RLS_LS As Long
        Get
            Return E_ID_RLS_LS
        End Get
        Set(value As Long)
            E_ID_RLS_LS = value
        End Set
    End Property
    Public Property ID_CODIGO_FONASA As Integer
        Get
            Return E_ID_CODIGO_FONASA
        End Get
        Set(value As Integer)
            E_ID_CODIGO_FONASA = value
        End Set
    End Property
    Public Property ATE_RR_DESDE As String
        Get
            Return E_ATE_RR_DESDE
        End Get
        Set(value As String)
            E_ATE_RR_DESDE = value
        End Set
    End Property
    Public Property ATE_RR_HASTA As String
        Get
            Return E_ATE_RR_HASTA
        End Get
        Set(value As String)
            E_ATE_RR_HASTA = value
        End Set
    End Property
    Public Property ATE_RR_ALTOBAJO As Long
        Get
            Return E_ATE_RR_ALTOBAJO
        End Get
        Set(value As Long)
            E_ATE_RR_ALTOBAJO = value
        End Set
    End Property
    Public Property ATE_EST_RECHAZO As Integer
        Get
            Return E_ATE_EST_RECHAZO
        End Get
        Set(value As Integer)
            E_ATE_EST_RECHAZO = value
        End Set
    End Property
    Public Property ATE_EST_DERIVA As Integer
        Get
            Return E_ATE_EST_DERIVA
        End Get
        Set(value As Integer)
            E_ATE_EST_DERIVA = value
        End Set
    End Property
    Public Property ATE_RESULTADO_ALT As String
        Get
            Return E_ATE_RESULTADO_ALT
        End Get
        Set(value As String)
            E_ATE_RESULTADO_ALT = value
        End Set
    End Property

    Private EE_PRU_VECTOR_CALCULO As String
    Public Property PRU_VECTOR_CALCULO() As String
        Get
            Return EE_PRU_VECTOR_CALCULO
        End Get
        Set(ByVal value As String)
            EE_PRU_VECTOR_CALCULO = value
        End Set
    End Property

    Private EE_REQ_RES_VAL As String
    Public Property REQ_RES_VAL() As String
        Get
            Return EE_REQ_RES_VAL
        End Get
        Set(ByVal value As String)
            EE_REQ_RES_VAL = value
        End Set
    End Property

    Public Property RF_R_TEXTO As String
        Get
            Return EE_RF_R_TEXTO
        End Get
        Set(value As String)
            EE_RF_R_TEXTO = value
        End Set
    End Property

    Public Property ATE_REV_ID_ESTADO As Integer
        Get
            Return E_ATE_REV_ID_ESTADO
        End Get
        Set(value As Integer)
            E_ATE_REV_ID_ESTADO = value
        End Set
    End Property

    Public Property ATE_DET_REV_ID_ESTADO As Integer
        Get
            Return E_ATE_DET_REV_ID_ESTADO
        End Get
        Set(value As Integer)
            E_ATE_DET_REV_ID_ESTADO = value
        End Set
    End Property

    Public Property ID_DET_ATE As Integer
        Get
            Return E_ID_DET_ATE
        End Get
        Set(value As Integer)
            E_ID_DET_ATE = value
        End Set
    End Property
End Class