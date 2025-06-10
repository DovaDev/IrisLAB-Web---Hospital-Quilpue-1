Public Class E_IRIS_BUSCA_RANGO_REFERENCIA

    Dim EE_ID_RF As Integer
    Dim EE_ID_PRUEBA As Integer
    Dim EE_ID_SEXO As Integer
    Dim EE_RF_ANO_DESDE As Integer
    Dim EE_RF_MESES_DESDE As Integer
    Dim EE_RF_DIAS_DESDE As Integer
    Dim EE_RF_ANO_HASTA As Integer
    Dim EE_RF_MESES_HASTA As Integer
    Dim EE_RF_DIAS_HASTA As Integer
    Dim EE_RF_V_B_DESDE As Decimal
    Dim EE_RF_V_DESDE As Decimal
    Dim EE_RF_V_HASTA As Decimal
    Dim EE_RF_V_A_HASTA As Decimal
    Dim EE_RF_R_TEXTO As String
    Dim EE_ID_ESTADO As Integer
    Dim EE_RF_EMBARAZADA As Integer
    Dim EE_RF_TEXTO_EXTRA As String

    Public Property ID_RF As Integer
        Get
            Return EE_ID_RF
        End Get
        Set(value As Integer)
            EE_ID_RF = value
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

    Public Property ID_SEXO As Integer
        Get
            Return EE_ID_SEXO
        End Get
        Set(value As Integer)
            EE_ID_SEXO = value
        End Set
    End Property

    Public Property RF_ANO_DESDE As Integer
        Get
            Return EE_RF_ANO_DESDE
        End Get
        Set(value As Integer)
            EE_RF_ANO_DESDE = value
        End Set
    End Property

    Public Property RF_MESES_DESDE As Integer
        Get
            Return EE_RF_MESES_DESDE
        End Get
        Set(value As Integer)
            EE_RF_MESES_DESDE = value
        End Set
    End Property

    Public Property RF_DIAS_DESDE As Integer
        Get
            Return EE_RF_DIAS_DESDE
        End Get
        Set(value As Integer)
            EE_RF_DIAS_DESDE = value
        End Set
    End Property

    Public Property RF_ANO_HASTA As Integer
        Get
            Return EE_RF_ANO_HASTA
        End Get
        Set(value As Integer)
            EE_RF_ANO_HASTA = value
        End Set
    End Property

    Public Property RF_MESES_HASTA As Integer
        Get
            Return EE_RF_MESES_HASTA
        End Get
        Set(value As Integer)
            EE_RF_MESES_HASTA = value
        End Set
    End Property

    Public Property RF_DIAS_HASTA As Integer
        Get
            Return EE_RF_DIAS_HASTA
        End Get
        Set(value As Integer)
            EE_RF_DIAS_HASTA = value
        End Set
    End Property

    Public Property RF_V_B_DESDE As Decimal
        Get
            Return EE_RF_V_B_DESDE
        End Get
        Set(value As Decimal)
            EE_RF_V_B_DESDE = value
        End Set
    End Property

    Public Property RF_V_DESDE As Decimal
        Get
            Return EE_RF_V_DESDE
        End Get
        Set(value As Decimal)
            EE_RF_V_DESDE = value
        End Set
    End Property

    Public Property RF_V_HASTA As Decimal
        Get
            Return EE_RF_V_HASTA
        End Get
        Set(value As Decimal)
            EE_RF_V_HASTA = value
        End Set
    End Property

    Public Property RF_V_A_HASTA As Decimal
        Get
            Return EE_RF_V_A_HASTA
        End Get
        Set(value As Decimal)
            EE_RF_V_A_HASTA = value
        End Set
    End Property

    Public Property RF_R_TEXTO As String
        Get
            Return EE_RF_R_TEXTO
        End Get
        Set(value As String)
            EE_RF_R_TEXTO = value
        End Set
    End Property

    Public Property ID_ESTADO As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property

    Public Property RF_EMBARAZADA As Integer
        Get
            Return EE_RF_EMBARAZADA
        End Get
        Set(value As Integer)
            EE_RF_EMBARAZADA = value
        End Set
    End Property

    Public Property RF_TEXTO_EXTRA As String
        Get
            Return EE_RF_TEXTO_EXTRA
        End Get
        Set(value As String)
            EE_RF_TEXTO_EXTRA = value
        End Set
    End Property
End Class