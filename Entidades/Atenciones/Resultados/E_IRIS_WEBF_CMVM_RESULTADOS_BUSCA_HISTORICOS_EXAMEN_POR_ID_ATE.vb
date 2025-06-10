Public Class E_IRIS_WEBF_CMVM_RESULTADOS_BUSCA_HISTORICOS_EXAMEN_POR_ID_ATE
    Private E_ID_CODIGO_FONASA As Long
    Public Property ID_CODIGO_FONASA() As Long
        Get
            Return E_ID_CODIGO_FONASA
        End Get
        Set(ByVal value As Long)
            E_ID_CODIGO_FONASA = value
        End Set
    End Property

    Private E_CF_COD As String
    Public Property CF_COD() As String
        Get
            Return E_CF_COD
        End Get
        Set(ByVal value As String)
            E_CF_COD = value
        End Set
    End Property

    Private E_CF_DESC As String
    Public Property CF_DESC() As String
        Get
            Return E_CF_DESC
        End Get
        Set(ByVal value As String)
            E_CF_DESC = value
        End Set
    End Property

    Private E_EXA_COUNT As Integer
    Public Property EXA_COUNT() As Integer
        Get
            Return E_EXA_COUNT
        End Get
        Set(ByVal value As Integer)
            E_EXA_COUNT = value
        End Set
    End Property
End Class
