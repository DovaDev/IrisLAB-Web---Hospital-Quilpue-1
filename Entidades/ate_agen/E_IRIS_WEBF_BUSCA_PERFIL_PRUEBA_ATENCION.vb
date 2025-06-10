Public Class E_IRIS_WEBF_BUSCA_PERFIL_PRUEBA_ATENCION
    Dim EE_ID_PRUEBA As Integer
    Dim EE_PRU_COD As String
    Dim EE_PRU_DESC As String
    Dim EE_ID_PER As Integer
    Dim EE_PRU_P_CERO As String
    Dim EE_ID_TP_RESULTADO As Integer
    Dim EE_PRU_RESU_INMEDIATO_REAL As String

    Dim EE_IS_ANATO As Integer
    Public Property ID_PRUEBA As Integer
        Get
            Return EE_ID_PRUEBA
        End Get
        Set(value As Integer)
            EE_ID_PRUEBA = value
        End Set
    End Property
    Public Property PRU_COD As String
        Get
            Return EE_PRU_COD
        End Get
        Set(value As String)
            EE_PRU_COD = value
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
    Public Property ID_PER As Integer
        Get
            Return EE_ID_PER
        End Get
        Set(value As Integer)
            EE_ID_PER = value
        End Set
    End Property
    Public Property PRU_P_CERO As String
        Get
            Return EE_PRU_P_CERO
        End Get
        Set(value As String)
            EE_PRU_P_CERO = value
        End Set
    End Property
    Public Property ID_TP_RESULTADO As Integer
        Get
            Return EE_ID_TP_RESULTADO
        End Get
        Set(value As Integer)
            EE_ID_TP_RESULTADO = value
        End Set
    End Property
    Public Property PRU_RESU_INMEDIATO_REAL As String
        Get
            Return EE_PRU_RESU_INMEDIATO_REAL
        End Get
        Set(value As String)
            EE_PRU_RESU_INMEDIATO_REAL = value
        End Set
    End Property

    Public Property IS_ANATO As Integer
        Get
            Return EE_IS_ANATO
        End Get
        Set(value As Integer)
            EE_IS_ANATO = value
        End Set
    End Property
End Class
