Public Class E_IRIS_WEBF_BUSCA_PRUEBAS_DIALISIS
    Private EE_ID_ANO As Integer
    Public Property ID_ANO() As Integer
        Get
            Return EE_ID_ANO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ANO = value
        End Set
    End Property
    Private EE_ID_PREVE As Integer
    Public Property ID_PREVE() As Integer
        Get
            Return EE_ID_PREVE
        End Get
        Set(ByVal value As Integer)
            EE_ID_PREVE = value
        End Set
    End Property

    Private EE_ID_PRUEBA As Integer
    Public Property ID_PRUEBA() As Integer
        Get
            Return EE_ID_PRUEBA
        End Get
        Set(ByVal value As Integer)
            EE_ID_PRUEBA = value
        End Set
    End Property

    Private EE_AGRU_PRU_DESC As String
    Public Property AGRU_PRU_DESC() As String
        Get
            Return EE_AGRU_PRU_DESC
        End Get
        Set(ByVal value As String)
            EE_AGRU_PRU_DESC = value
        End Set
    End Property

    Private EE_ANO_DESC As String
    Public Property ANO_DESC() As String
        Get
            Return EE_ANO_DESC
        End Get
        Set(ByVal value As String)
            EE_ANO_DESC = value
        End Set
    End Property
End Class