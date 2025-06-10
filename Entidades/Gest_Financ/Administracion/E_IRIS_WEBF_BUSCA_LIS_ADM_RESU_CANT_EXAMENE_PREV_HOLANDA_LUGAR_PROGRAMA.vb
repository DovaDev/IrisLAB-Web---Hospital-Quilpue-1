Public Class E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_LUGAR_PROGRAMA
    Dim E_TOTAL_ATE As Long
    Dim E_TOTAL_PREVE As Long
    Dim E_TOT_FONASA As Long
    Dim E_TOTA_SIS As Long
    Dim E_CF_DESC As String
    Dim E_ID_CODIGO_FONASA As Long
    Dim E_ID_ESTADO As Long
    Dim E_CF_COD As String
    Dim E_ID_PROGRA As Long
    Dim E_PROGRA_DESC As String
    Dim E_ID_PREVE As Long
    Dim E_PREVE_DESC As String
    Dim E_ID_PROCEDENCIA As Long
    Dim E_PROC_DESC As String
    Public Property ID_PREVE As Long
        Get
            Return E_ID_PREVE
        End Get
        Set(value As Long)
            E_ID_PREVE = value
        End Set
    End Property
    Public Property PREVE_DESC As String
        Get
            Return E_PREVE_DESC
        End Get
        Set(value As String)
            E_PREVE_DESC = value
        End Set
    End Property
    Public Property ID_PROCEDENCIA As Long
        Get
            Return E_ID_PROCEDENCIA
        End Get
        Set(value As Long)
            E_ID_PROCEDENCIA = value
        End Set
    End Property
    Public Property PROC_DESC As String
        Get
            Return E_PROC_DESC
        End Get
        Set(value As String)
            E_PROC_DESC = value
        End Set
    End Property
    Public Property TOTAL_ATE As Long
        Get
            Return E_TOTAL_ATE
        End Get
        Set(value As Long)
            E_TOTAL_ATE = value
        End Set
    End Property
    Public Property TOTAL_PREVE As Long
        Get
            Return E_TOTAL_PREVE
        End Get
        Set(value As Long)
            E_TOTAL_PREVE = value
        End Set
    End Property
    Public Property TOT_FONASA As Long
        Get
            Return E_TOT_FONASA
        End Get
        Set(value As Long)
            E_TOT_FONASA = value
        End Set
    End Property
    Public Property TOTA_SIS As Long
        Get
            Return E_TOTA_SIS
        End Get
        Set(value As Long)
            E_TOTA_SIS = value
        End Set
    End Property
    Public Property CF_DESC As String
        Get
            Return E_CF_DESC
        End Get
        Set(value As String)
            E_CF_DESC = value
        End Set
    End Property
    Public Property ID_CODIGO_FONASA As Long
        Get
            Return E_ID_CODIGO_FONASA
        End Get
        Set(value As Long)
            E_ID_CODIGO_FONASA = value
        End Set
    End Property
    Public Property ID_ESTADO As Long
        Get
            Return E_ID_ESTADO
        End Get
        Set(value As Long)
            E_ID_ESTADO = value
        End Set
    End Property
    Public Property CF_COD As String
        Get
            Return E_CF_COD
        End Get
        Set(value As String)
            E_CF_COD = value
        End Set
    End Property
    Public Property ID_PROGRA As Long
        Get
            Return E_ID_PROGRA
        End Get
        Set(value As Long)
            E_ID_PROGRA = value
        End Set
    End Property
    Public Property PROGRA_DESC As String
        Get
            Return E_PROGRA_DESC
        End Get
        Set(value As String)
            E_PROGRA_DESC = value
        End Set
    End Property
End Class