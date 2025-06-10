Public Class E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_ATENCIONES_POR_SECCCION
    Private EE_ATE_NUM As String
    Private EE_ATE_FECHA As DateTime
    Private EE_SECC_COD As String
    Private EE_PROC_DESC As String
    Public Property PROC_DESC() As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(ByVal value As String)
            EE_PROC_DESC = value
        End Set
    End Property
    Public Property SECC_COD() As String
        Get
            Return EE_SECC_COD
        End Get
        Set(ByVal value As String)
            EE_SECC_COD = value
        End Set
    End Property
    Public Property ATE_FECHA() As DateTime
        Get
            Return EE_ATE_FECHA
        End Get
        Set(ByVal value As DateTime)
            EE_ATE_FECHA = value
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
End Class
