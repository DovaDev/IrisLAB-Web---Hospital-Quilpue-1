Public Class E_IRIS_WEBF_BUSCA_RETICULOCITOS_POR_FECHA

    Private E_ID_ATE_RES As Integer
    Private E_ATE_RESULTADO_NUM As String
    Private E_ID_PROCEDENCIA As Integer

    Public Property ID_ATE_RES As Integer
        Get
            Return E_ID_ATE_RES
        End Get
        Set(value As Integer)
            E_ID_ATE_RES = value
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

    Public Property ID_PROCEDENCIA As Integer
        Get
            Return E_ID_PROCEDENCIA
        End Get
        Set(value As Integer)
            E_ID_PROCEDENCIA = value
        End Set
    End Property
End Class

