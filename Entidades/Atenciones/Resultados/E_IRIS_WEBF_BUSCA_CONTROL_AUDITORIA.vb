Public Class E_IRIS_WEBF_BUSCA_CONTROL_AUDITORIA
    Private EE_IN_ATENCION As Integer
    Public Property IN_ATENCION() As Integer
        Get
            Return EE_IN_ATENCION
        End Get
        Set(ByVal value As Integer)
            EE_IN_ATENCION = value
        End Set
    End Property
    Private EE_TP_RESUL_DESC As String
    Public Property TP_RESUL_DESC() As String
        Get
            Return EE_TP_RESUL_DESC
        End Get
        Set(ByVal value As String)
            EE_TP_RESUL_DESC = value
        End Set
    End Property
    Private EE_UM_DESC As String
    Public Property UM_DESC() As String
        Get
            Return EE_UM_DESC
        End Get
        Set(ByVal value As String)
            EE_UM_DESC = value
        End Set
    End Property
    Private EE_T_MUESTRA_DESC As String
    Public Property T_MUESTRA_DESC() As String
        Get
            Return EE_T_MUESTRA_DESC
        End Get
        Set(ByVal value As String)
            EE_T_MUESTRA_DESC = value
        End Set
    End Property
    Private EE_PRU_SOLICITADO As String
    Public Property PRU_SOLICITADO() As String
        Get
            Return EE_PRU_SOLICITADO
        End Get
        Set(ByVal value As String)
            EE_PRU_SOLICITADO = value
        End Set
    End Property
    Private EE_ID_T_MUESTRA As Integer
    Public Property ID_T_MUESTRA() As Integer
        Get
            Return EE_ID_T_MUESTRA
        End Get
        Set(ByVal value As Integer)
            EE_ID_T_MUESTRA = value
        End Set
    End Property
    Private EE_ID_TP_RESULTADO As Integer
    Public Property ID_TP_RESULTADO() As Integer
        Get
            Return EE_ID_TP_RESULTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_TP_RESULTADO = value
        End Set
    End Property
    Private EE_ID_U_MEDIDA As Integer
    Public Property ID_U_MEDIDA() As Integer
        Get
            Return EE_ID_U_MEDIDA
        End Get
        Set(ByVal value As Integer)
            EE_ID_U_MEDIDA = value
        End Set
    End Property
    Private EE_PRU_DESC As String
    Public Property PRU_DESC() As String
        Get
            Return EE_PRU_DESC
        End Get
        Set(ByVal value As String)
            EE_PRU_DESC = value
        End Set
    End Property
    Private EE_PRU_COD As String
    Public Property PRU_COD() As String
        Get
            Return EE_PRU_COD
        End Get
        Set(ByVal value As String)
            EE_PRU_COD = value
        End Set
    End Property
    Private EE_ID_PRUEBA As Integer
    Public Property ID_PRUEBA() As Integer
        Get
            Return EE_ID_PRUEBA
        End Get
        Set(ByVal value As Integer)
            EE_ID_PRUEBA = value
        End Set
    End Property
    Private EE_ATE_DET_V_FECHA As Date
    Public Property ATE_DET_V_FECHA() As Date
        Get
            Return EE_ATE_DET_V_FECHA
        End Get
        Set(ByVal value As Date)
            EE_ATE_DET_V_FECHA = value
        End Set
    End Property
    Private EE_ATE_DET_V_ID_USU As Integer
    Public Property ATE_DET_V_ID_USU() As Integer
        Get
            Return EE_ATE_DET_V_ID_USU
        End Get
        Set(ByVal value As Integer)
            EE_ATE_DET_V_ID_USU = value
        End Set
    End Property
    Private EE_ATE_DET_V_ID_ESTADO As Integer
    Public Property ATE_DET_V_ID_ESTADO() As Integer
        Get
            Return EE_ATE_DET_V_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ATE_DET_V_ID_ESTADO = value
        End Set
    End Property
    Private EE_CF_DESC As String
    Public Property CF_DESC() As String
        Get
            Return EE_CF_DESC
        End Get
        Set(ByVal value As String)
            EE_CF_DESC = value
        End Set
    End Property
    Private EE_CF_COD As String
    Public Property CF_COD() As String
        Get
            Return EE_CF_COD
        End Get
        Set(ByVal value As String)
            EE_CF_COD = value
        End Set
    End Property
    Private EE_ID_PER As Integer
    Public Property ID_PER() As Integer
        Get
            Return EE_ID_PER
        End Get
        Set(ByVal value As Integer)
            EE_ID_PER = value
        End Set
    End Property
    Private EE_ID_CODIGO_FONASA As Integer
    Public Property ID_CODIGO_FONASA() As Integer
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(ByVal value As Integer)
            EE_ID_CODIGO_FONASA = value
        End Set
    End Property
    Private EE_OBS_ATE_H2M As String
    Public Property OBS_ATE_H2M() As String
        Get
            Return EE_OBS_ATE_H2M
        End Get
        Set(ByVal value As String)
            EE_OBS_ATE_H2M = value
        End Set
    End Property
    Private EE_ID_ATENCION As Integer
    Public Property ID_ATENCION() As Integer
        Get
            Return EE_ID_ATENCION
        End Get
        Set(ByVal value As Integer)
            EE_ID_ATENCION = value
        End Set
    End Property
    Private EE_AUDI_FECHA As Date
    Public Property AUDI_FECHA() As Date
        Get
            Return EE_AUDI_FECHA
        End Get
        Set(ByVal value As Date)
            EE_AUDI_FECHA = value
        End Set
    End Property

    Private EE_AUDI_ACCION As String
    Public Property AUDI_ACCION() As String
        Get
            Return EE_AUDI_ACCION
        End Get
        Set(ByVal value As String)
            EE_AUDI_ACCION = value
        End Set
    End Property

    Private EE_AUDI_FORMA As String
    Public Property AUDI_FORMA() As String
        Get
            Return EE_AUDI_FORMA
        End Get
        Set(ByVal value As String)
            EE_AUDI_FORMA = value
        End Set
    End Property

    Private EE_ID_ATE_RES As Long
    Public Property ID_ATE_RES() As Long
        Get
            Return EE_ID_ATE_RES
        End Get
        Set(ByVal value As Long)
            EE_ID_ATE_RES = value
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
    Private EE_ATE_EST_VALIDA As Integer
    Public Property ATE_EST_VALIDA() As Integer
        Get
            Return EE_ATE_EST_VALIDA
        End Get
        Set(ByVal value As Integer)
            EE_ATE_EST_VALIDA = value
        End Set
    End Property
    Private EE_ATE_RESULTADO As String
    Public Property ATE_RESULTADO() As String
        Get
            Return EE_ATE_RESULTADO
        End Get
        Set(ByVal value As String)
            EE_ATE_RESULTADO = value
        End Set
    End Property
    Private EE_ATE_RESULTADO_NUM As String
    Public Property ATE_RESULTADO_NUM() As String
        Get
            Return EE_ATE_RESULTADO_NUM
        End Get
        Set(ByVal value As String)
            EE_ATE_RESULTADO_NUM = value
        End Set
    End Property
End Class