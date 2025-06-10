Public Class E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_PREVISION_PANTALLA
    Private EE_TOTAL_ATE As Integer
    Private EE_TOT_FONASA As Integer
    Private EE_ID_ESTADO As Integer
    Private EE_Expr1 As Integer
    Public Property Expr1() As Integer
        Get
            Return EE_Expr1
        End Get
        Set(ByVal value As Integer)
            EE_Expr1 = value
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
    Public Property TOT_FONASA() As Integer
        Get
            Return EE_TOT_FONASA
        End Get
        Set(ByVal value As Integer)
            EE_TOT_FONASA = value
        End Set
    End Property
    Public Property TOTAL_ATE() As Integer
        Get
            Return EE_TOTAL_ATE
        End Get
        Set(ByVal value As Integer)
            EE_TOTAL_ATE = value
        End Set
    End Property
End Class
