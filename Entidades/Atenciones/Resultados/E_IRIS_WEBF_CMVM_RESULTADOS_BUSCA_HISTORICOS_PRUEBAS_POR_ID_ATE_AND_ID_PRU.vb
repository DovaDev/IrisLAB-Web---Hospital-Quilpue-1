Public Class E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_PRUEBAS_POR_ID_ATE_AND_ID_PRU
    Private E_ID_ATENCION As Long
    Public Property ID_ATENCION() As Long
        Get
            Return E_ID_ATENCION
        End Get
        Set(ByVal value As Long)
            E_ID_ATENCION = value
        End Set
    End Property

    Private E_ATE_NUM As Long
    Public Property ATE_NUM() As Long
        Get
            Return E_ATE_NUM
        End Get
        Set(ByVal value As Long)
            E_ATE_NUM = value
        End Set
    End Property

    Private E_ATE_FECHA As Date
    Public Property ATE_FECHA() As Date
        Get
            Return E_ATE_FECHA
        End Get
        Set(ByVal value As Date)
            E_ATE_FECHA = value
        End Set
    End Property

    Private E_ID_PRUEBA As Long
    Public Property ID_PRUEBA() As Long
        Get
            Return E_ID_PRUEBA
        End Get
        Set(ByVal value As Long)
            E_ID_PRUEBA = value
        End Set
    End Property

    Private E_PRU_COD As String
    Public Property PRU_COD() As String
        Get
            Return E_PRU_COD
        End Get
        Set(ByVal value As String)
            E_PRU_COD = value
        End Set
    End Property

    Private E_PRU_DESC As String
    Public Property PRU_DESC() As String
        Get
            Return E_PRU_DESC
        End Get
        Set(ByVal value As String)
            E_PRU_DESC = value
        End Set
    End Property

    Private E_ATE_RESULTADO As String
    Public Property ATE_RESULTADO() As String
        Get
            Return E_ATE_RESULTADO
        End Get
        Set(ByVal value As String)
            E_ATE_RESULTADO = value
        End Set
    End Property

    Private E_ID_ATE_RES As Long
    Public Property ID_ATE_RES() As Long
        Get
            Return E_ID_ATE_RES
        End Get
        Set(ByVal value As Long)
            E_ID_ATE_RES = value
        End Set
    End Property
End Class
