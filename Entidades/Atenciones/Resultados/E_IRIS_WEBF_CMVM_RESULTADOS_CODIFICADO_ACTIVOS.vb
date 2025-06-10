Public Class E_IRIS_WEBF_CMVM_RESULTADOS_CODIFICADO_ACTIVOS
    Private EE_ID_REL_PRU_RES As Long
    Public Property ID_REL_PRU_RES() As Long
        Get
            Return EE_ID_REL_PRU_RES
        End Get
        Set(ByVal value As Long)
            EE_ID_REL_PRU_RES = value
        End Set
    End Property

    Private EE_ID_PRUEBA As Long
    Public Property ID_PRUEBA() As Long
        Get
            Return EE_ID_PRUEBA
        End Get
        Set(ByVal value As Long)
            EE_ID_PRUEBA = value
        End Set
    End Property

    Private EE_ID_RES_COD As Long
    Public Property ID_RES_COD() As Long
        Get
            Return EE_ID_RES_COD
        End Get
        Set(ByVal value As Long)
            EE_ID_RES_COD = value
        End Set
    End Property

    Private EE_ID_ESTADO As Integer
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property

    Private EE_RES_COD_DESC As String
    Public Property RES_COD_DESC() As String
        Get
            Return EE_RES_COD_DESC
        End Get
        Set(ByVal value As String)
            EE_RES_COD_DESC = value
        End Set
    End Property

    Private EE_RES_COD_COD As String
    Public Property RES_COD_COD() As String
        Get
            Return EE_RES_COD_COD
        End Get
        Set(ByVal value As String)
            EE_RES_COD_COD = value
        End Set
    End Property

    Private EE_CF_COD As String
    Public Property CF_COD() As String
        Get
            Return EE_CF_COD
        End Get
        Set(ByVal value As String)
            EE_CF_COD = value
        End Set
    End Property

    Private EE_CF_DESC As String
    Public Property CF_DESC() As String
        Get
            Return EE_CF_DESC
        End Get
        Set(ByVal value As String)
            EE_CF_DESC = value
        End Set
    End Property
End Class