Public Class E_IRIS_BUSCA_WEBF_LIS_ADM_RESU_CANT_EXAMENES_AREA_SECCION
    Dim EE_TOTAL_ATE As Long
    Dim EE_TOTAL_PREVE As Long
    Dim EE_TOT_FONASA As Long
    Dim EE_TOTA_SIS As Long
    Dim EE_TOTA_USU As Long
    Dim EE_TOTA_COPA As Long
    Dim EE_CF_DESC As String
    Dim EE_ID_CODIGO_FONASA As Long
    Dim EE_ID_ESTADO As Long
    Dim EE_RLS_LS_DESC As String
    Dim EE_CF_COD As String
    Dim EE_ID_RLS_LS As Long
    Public Property TOTAL_ATE As Long
        Get
            Return EE_TOTAL_ATE
        End Get
        Set(value As Long)
            EE_TOTAL_ATE = value
        End Set
    End Property
    Public Property TOTAL_PREVE As Long
        Get
            Return EE_TOTAL_PREVE
        End Get
        Set(value As Long)
            EE_TOTAL_PREVE = value
        End Set
    End Property
    Public Property TOT_FONASA As Long
        Get
            Return EE_TOT_FONASA
        End Get
        Set(value As Long)
            EE_TOT_FONASA = value
        End Set
    End Property
    Public Property TOTA_SIS As Long
        Get
            Return EE_TOTA_SIS
        End Get
        Set(value As Long)
            EE_TOTA_SIS = value
        End Set
    End Property
    Public Property TOTA_USU As Long
        Get
            Return EE_TOTA_USU
        End Get
        Set(value As Long)
            EE_TOTA_USU = value
        End Set
    End Property
    Public Property TOTA_COPA As Long
        Get
            Return EE_TOTA_COPA
        End Get
        Set(value As Long)
            EE_TOTA_COPA = value
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
    Public Property ID_CODIGO_FONASA As Long
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(value As Long)
            EE_ID_CODIGO_FONASA = value
        End Set
    End Property
    Public Property ID_ESTADO As Long
        Get
            Return EE_ID_ESTADO
        End Get
        Set(value As Long)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property RLS_LS_DESC As String
        Get
            Return EE_RLS_LS_DESC
        End Get
        Set(value As String)
            EE_RLS_LS_DESC = value
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
    Public Property ID_RLS_LS As Long
        Get
            Return EE_ID_RLS_LS
        End Get
        Set(value As Long)
            EE_ID_RLS_LS = value
        End Set
    End Property
End Class
