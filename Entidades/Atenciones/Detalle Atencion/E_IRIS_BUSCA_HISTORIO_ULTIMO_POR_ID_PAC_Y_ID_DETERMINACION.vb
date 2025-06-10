Public Class E_IRIS_WEBF_BUSCA_HISTORICO_ULTIMO_POR_ID_PAC_Y_ID_DETERMINACION
    Dim EE_ID_PACIENTE As Long
    Dim EE_ATE_FECHA As Date
    Dim EE_ID_PRUEBA As Long
    Dim EE_ATE_RESULTADO As String
    Dim EE_ATE_EST_VALIDA As Integer
    Dim EE_ATE_RESULTADO_NUM As String
    Dim EE_ATE_NUM As String
    Dim EE_ID_ATENCION As Long
    Public Property ID_PACIENTE As Long
        Get
            Return EE_ID_PACIENTE
        End Get
        Set(value As Long)
            EE_ID_PACIENTE = value
        End Set
    End Property
    Public Property ATE_FECHA As Date
        Get
            Return EE_ATE_FECHA
        End Get
        Set(value As Date)
            EE_ATE_FECHA = value
        End Set
    End Property
    Public Property ID_PRUEBA As Long
        Get
            Return EE_ID_PRUEBA
        End Get
        Set(value As Long)
            EE_ID_PRUEBA = value
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
    Public Property ATE_EST_VALIDA As Integer
        Get
            Return EE_ATE_EST_VALIDA
        End Get
        Set(value As Integer)
            EE_ATE_EST_VALIDA = value
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
    Public Property ATE_NUM As String
        Get
            Return EE_ATE_NUM
        End Get
        Set(value As String)
            EE_ATE_NUM = value
        End Set
    End Property
    Public Property ID_ATENCION As Long
        Get
            Return EE_ID_ATENCION
        End Get
        Set(value As Long)
            EE_ID_ATENCION = value
        End Set
    End Property
End Class
