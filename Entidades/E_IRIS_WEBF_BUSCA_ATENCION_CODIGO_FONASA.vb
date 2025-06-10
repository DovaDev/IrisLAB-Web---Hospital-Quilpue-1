Public Class E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA
    Dim EE_CF_COD As String
    Dim EE_CF_DESC As String
    Dim EE_CF_PRECIO_AMB As String
    Dim EE_CF_PRECIO_HOS As String
    Dim EE_AÑO_COD As String
    Dim EE_CF_DIAS As String
    Dim EE_ID_PER As Integer
    Dim EE_ID_PREVE As Integer
    Dim EE_ID_ESTADO As Integer
    Dim EE_ID_CF_PRECIO As Integer
    Dim EE_ID_CODIGO_FONASA As Integer
    Dim EE_CF_ESTADO_EXAMEN As String
    Dim EE_CF_BONIFICACION As Integer
    Dim EE_CF_HOST_IMED As String

    Private EE_ID_PRUEBA As Integer
    Private EE_PRU_COD As String
    Private EE_PRU_DESC As String
    Private EE_PRU_P_CERO As String
    Private EE_ID_TP_RESULTADO As Integer
    Private EE_PRU_RESU_INMEDIATO_REAL As String
    Private EE_CF_IMED_CANTIDAD As Integer

    Private EE_IS_ANATO As Boolean

    Public Property CF_HOST_IMED As String
        Get
            Return EE_CF_HOST_IMED
        End Get
        Set(value As String)
            EE_CF_HOST_IMED = value
        End Set
    End Property
    Public Property CF_BONIFICACION As Integer
        Get
            Return EE_CF_BONIFICACION
        End Get
        Set(value As Integer)
            EE_CF_BONIFICACION = value
        End Set
    End Property
    Public Property CF_ESTADO_EXAMEN As String
        Get
            Return EE_CF_ESTADO_EXAMEN
        End Get
        Set(value As String)
            EE_CF_ESTADO_EXAMEN = value
        End Set
    End Property
    Public Property CF_COD As String
        Get
            Return EE_CF_COD
        End Get
        Set(value As String)
            EE_CF_COD = value
        End Set
    End Property
    Public Property CF_DESC As String
        Get
            Return EE_CF_DESC
        End Get
        Set(value As String)
            EE_CF_DESC = value
        End Set
    End Property
    Public Property CF_PRECIO_AMB As String
        Get
            Return EE_CF_PRECIO_AMB
        End Get
        Set(value As String)
            EE_CF_PRECIO_AMB = value
        End Set
    End Property
    Public Property CF_PRECIO_HOS As String
        Get
            Return EE_CF_PRECIO_HOS
        End Get
        Set(value As String)
            EE_CF_PRECIO_HOS = value
        End Set
    End Property
    Public Property AÑO_COD As String
        Get
            Return EE_AÑO_COD
        End Get
        Set(value As String)
            EE_AÑO_COD = value
        End Set
    End Property
    Public Property CF_DIAS As String
        Get
            Return EE_CF_DIAS
        End Get
        Set(value As String)
            EE_CF_DIAS = value
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
    Public Property ID_PREVE As Integer
        Get
            Return EE_ID_PREVE
        End Get
        Set(value As Integer)
            EE_ID_PREVE = value
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
    Public Property ID_CF_PRECIO As Integer
        Get
            Return EE_ID_CF_PRECIO
        End Get
        Set(value As Integer)
            EE_ID_CF_PRECIO = value
        End Set
    End Property
    Public Property ID_CODIGO_FONASA As Integer
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(value As Integer)
            EE_ID_CODIGO_FONASA = value
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

    Public Property CF_IMED_CANTIDAD As Integer
        Get
            Return EE_CF_IMED_CANTIDAD
        End Get
        Set(value As Integer)
            EE_CF_IMED_CANTIDAD = value
        End Set
    End Property

    Public Property IS_ANATO As Boolean
        Get
            Return EE_IS_ANATO
        End Get
        Set(value As Boolean)
            EE_IS_ANATO = value
        End Set
    End Property
End Class
