Public Class E_IRIS_WEBF_BUSCA_RESULTADO_DIALISIS
    Dim EE_ID_ATENCION As Integer
    Dim EE_ATE_RESULTADO As String
    Dim EE_ATE_RESULTADO_NUM As String
    Dim EE_ID_PRUEBA As Integer
    Dim EE_ATE_EST_VALIDA As Integer

    Public Property ID_ATENCION As Integer
        Get
            Return EE_ID_ATENCION
        End Get
        Set(value As Integer)
            EE_ID_ATENCION = value
        End Set
    End Property

    Public Property ATE_RESULTADO As String
        Get
            Return EE_ATE_RESULTADO
        End Get
        Set(value As String)
            EE_ATE_RESULTADO = value
        End Set
    End Property

    Public Property ATE_RESULTADO_NUM As String
        Get
            Return EE_ATE_RESULTADO_NUM
        End Get
        Set(value As String)
            EE_ATE_RESULTADO_NUM = value
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

    Public Property ATE_EST_VALIDA As Integer
        Get
            Return EE_ATE_EST_VALIDA
        End Get
        Set(value As Integer)
            EE_ATE_EST_VALIDA = value
        End Set
    End Property
End Class
