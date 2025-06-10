Public Class E_IRIS_WEBF_BUSCA_ETIQUETA_BARRA_PACIENTE_RECEP_ENVIO
    Dim EE_ATE_NUM As Integer
    Dim EE_ID_CODIGO_FONASA As Integer
    Dim EE_ID_PER As Integer
    Dim EE_ID_PRUEBA As Integer
    Dim EE_ID_ATE_RES As Integer
    Dim EE_PRU_DESC As String
    Dim EE_CB_COD As String
    Dim EE_T_MUESTRA_DESC As String
    Dim EE_ATE_FEC_ENVIO As Date
    Dim EE_ATE_USU_ENVIO As String
    Dim EE_ATE_EST_ENVIO As String
    Dim EE_ID_ATENCION As Integer

    Public Property ATE_NUM As Integer
        Get
            Return EE_ATE_NUM
        End Get
        Set(value As Integer)
            EE_ATE_NUM = value
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

    Public Property ID_PER As Integer
        Get
            Return EE_ID_PER
        End Get
        Set(value As Integer)
            EE_ID_PER = value
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

    Public Property ID_ATE_RES As Integer
        Get
            Return EE_ID_ATE_RES
        End Get
        Set(value As Integer)
            EE_ID_ATE_RES = value
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

    Public Property CB_COD As String
        Get
            Return EE_CB_COD
        End Get
        Set(value As String)
            EE_CB_COD = value
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

    Public Property ATE_FEC_ENVIO As Date
        Get
            Return EE_ATE_FEC_ENVIO
        End Get
        Set(value As Date)
            EE_ATE_FEC_ENVIO = value
        End Set
    End Property

    Public Property ATE_USU_ENVIO As String
        Get
            Return EE_ATE_USU_ENVIO
        End Get
        Set(value As String)
            EE_ATE_USU_ENVIO = value
        End Set
    End Property

    Public Property ATE_EST_ENVIO As String
        Get
            Return EE_ATE_EST_ENVIO
        End Get
        Set(value As String)
            EE_ATE_EST_ENVIO = value
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
End Class
