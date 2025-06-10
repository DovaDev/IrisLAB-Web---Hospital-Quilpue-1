Public Class E_IRIS_WEBF_BUSCA_EST_ESTADOS_DETERMINACION
    Private EE_CF_DESC As String
    Private EE_PRU_DESC As String
    Private EE_ATE_NUM As String
    Private EE_ID_ESTADO As Integer
    Private EE_ATE_EST_VALIDA As Integer
    Private EE_EST_DESCRIOCION As String
    Private EE_UM_DESC As String
    Private EE_ATE_RESULTADO As String
    Private EE_ATE_RESULTADO_NUM As String
    Private EE_ATE_FECHA As Date
    Private EE_TP_RESUL_COD As String
    Private EE_ID_TP_RESULTADO As Integer
    Private EE_ID_U_MEDIDA As Integer
    Private EE_ID_ATENCION As Integer
    Public Property ID_ATENCION() As Integer
        Get
            Return EE_ID_ATENCION
        End Get
        Set(ByVal value As Integer)
            EE_ID_ATENCION = value
        End Set
    End Property
    Public Property ID_U_MEDIDA() As Integer
        Get
            Return EE_ID_U_MEDIDA
        End Get
        Set(ByVal value As Integer)
            EE_ID_U_MEDIDA = value
        End Set
    End Property
    Public Property ID_TP_RESULTADO() As Integer
        Get
            Return EE_ID_TP_RESULTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_TP_RESULTADO = value
        End Set
    End Property
    Public Property TP_RESUL_COD() As String
        Get
            Return EE_TP_RESUL_COD
        End Get
        Set(ByVal value As String)
            EE_TP_RESUL_COD = value
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
    Public Property ATE_RESULTADO_NUM() As String
        Get
            Return EE_ATE_RESULTADO_NUM
        End Get
        Set(ByVal value As String)
            EE_ATE_RESULTADO_NUM = value
        End Set
    End Property
    Public Property ATE_RESULTADO() As String
        Get
            Return EE_ATE_RESULTADO
        End Get
        Set(ByVal value As String)
            EE_ATE_RESULTADO = value
        End Set
    End Property
    Public Property UM_DESC() As String
        Get
            Return EE_UM_DESC
        End Get
        Set(ByVal value As String)
            EE_UM_DESC = value
        End Set
    End Property
    Public Property EST_DESCRIPCION() As String
        Get
            Return EE_EST_DESCRIOCION
        End Get
        Set(ByVal value As String)
            EE_EST_DESCRIOCION = value
        End Set
    End Property
    Public Property ATE_EST_VALIDA() As Integer
        Get
            Return EE_ATE_EST_VALIDA
        End Get
        Set(ByVal value As Integer)
            EE_ATE_EST_VALIDA = value
        End Set
    End Property
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
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
    Public Property PRU_DESC() As String
        Get
            Return EE_PRU_DESC
        End Get
        Set(ByVal value As String)
            EE_PRU_DESC = value
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
End Class
