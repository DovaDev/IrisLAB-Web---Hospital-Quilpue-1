Public Class E_PRUEBAS

    Private EE_ID_PRUEBA As Integer
    Private EE_PRU_COD As String
    Private EE_PRU_DESC As String
    Private EE_PRU_ORDEN As Integer
    Private EE_ID_U_MEDIDA As Integer
    Private EE_ID_TP_RESULTADO As Integer
    Private EE_ID_T_MUESTRA As Integer
    Private EE_ID_TP_BAC As Integer
    Private EE_PRU_SOLICITADO As Integer
    Private EE_ID_ESTADO As Integer
    Private EE_PRU_DECIMAL As Integer
    Private EE_PRU_CORTO As String
    Private EE_UM_DESC As String
    Private EE_TP_RESUL_DESC As String
    Private EE_T_MUESTRA_DESC As String
    Private EE_TP_BAC_DESC As String
    Private EE_PRU_P_CERO As Integer
    Private EE_REQ_RES_VAL As Integer
    Private EE_PRU_P_PUNTO As Integer

    Public Property ID_PRUEBA As Integer
        Get
            Return EE_ID_PRUEBA
        End Get
        Set(value As Integer)
            EE_ID_PRUEBA = value
        End Set
    End Property

    Public Property PRU_COD As String
        Get
            Return EE_PRU_COD
        End Get
        Set(value As String)
            EE_PRU_COD = value
        End Set
    End Property

    Public Property PRU_DESC As String
        Get
            Return EE_PRU_DESC
        End Get
        Set(value As String)
            EE_PRU_DESC = value
        End Set
    End Property

    Public Property PRU_CORTO As String
        Get
            Return EE_PRU_CORTO
        End Get
        Set(value As String)
            EE_PRU_CORTO = value
        End Set
    End Property

    Public Property UM_DESC As String
        Get
            Return EE_UM_DESC
        End Get
        Set(value As String)
            EE_UM_DESC = value
        End Set
    End Property
    Public Property TP_RESUL_DESC As String
        Get
            Return EE_TP_RESUL_DESC
        End Get
        Set(value As String)
            EE_TP_RESUL_DESC = value
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
    Public Property TP_BAC_DESC As String
        Get
            Return EE_TP_BAC_DESC
        End Get
        Set(value As String)
            EE_TP_BAC_DESC = value
        End Set
    End Property
    Public Property PRU_ORDEN As Integer
        Get
            Return EE_PRU_ORDEN
        End Get
        Set(value As Integer)
            EE_PRU_ORDEN = value
        End Set
    End Property

    Public Property PRU_P_CERO As Integer
        Get
            Return EE_PRU_P_CERO
        End Get
        Set(value As Integer)
            EE_PRU_P_CERO = value
        End Set
    End Property

    Public Property REQ_RES_VAL As Integer
        Get
            Return EE_REQ_RES_VAL
        End Get
        Set(value As Integer)
            EE_REQ_RES_VAL = value
        End Set
    End Property

    Public Property PRU_P_PUNTO As Integer
        Get
            Return EE_PRU_P_PUNTO
        End Get
        Set(value As Integer)
            EE_PRU_P_PUNTO = value
        End Set
    End Property

    Public Property ID_U_MEDIDA As Integer
        Get
            Return EE_ID_U_MEDIDA
        End Get
        Set(value As Integer)
            EE_ID_U_MEDIDA = value
        End Set
    End Property

    Public Property ID_TP_RESULTADO As Integer
        Get
            Return EE_ID_TP_RESULTADO
        End Get
        Set(value As Integer)
            EE_ID_TP_RESULTADO = value
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

    Public Property ID_TP_BAC As Integer
        Get
            Return EE_ID_TP_BAC
        End Get
        Set(value As Integer)
            EE_ID_TP_BAC = value
        End Set
    End Property

    Public Property PRU_SOLICITADO As Integer
        Get
            Return EE_PRU_SOLICITADO
        End Get
        Set(value As Integer)
            EE_PRU_SOLICITADO = value
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

    Public Property PRU_DECIMAL As Integer
        Get
            Return EE_PRU_DECIMAL
        End Get
        Set(value As Integer)
            EE_PRU_DECIMAL = value
        End Set
    End Property

End Class
