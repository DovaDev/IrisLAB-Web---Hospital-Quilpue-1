Public Class E_IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA
    'IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA
    Dim EE_PROC_CANT_EXA_BUSCA_DIAS As Integer
    Dim EE_CONF_DIAS_FECHA_BUSCA_DIAS As Date
    Dim EE_CONF_DIAS_EXA_BUSCA_DIAS As Integer
    Dim EE_ID_ESTADO_BUSCA_DIAS As Integer
    Dim EE_ID_PROCEDENCIA_BUSCA_DIAS As Integer
    Dim EE_ID_CONF_DIAS_BUSCA_DIAS As Integer
    Public Property PROC_CANT_EXA_BUSCA_DIAS As Integer
        Get
            Return EE_PROC_CANT_EXA_BUSCA_DIAS
        End Get
        Set(value As Integer)
            EE_PROC_CANT_EXA_BUSCA_DIAS = value
        End Set
    End Property
    Public Property CONF_DIAS_FECHA_BUSCA_DIAS As Date
        Get
            Return EE_CONF_DIAS_FECHA_BUSCA_DIAS
        End Get
        Set(value As Date)
            EE_CONF_DIAS_FECHA_BUSCA_DIAS = value
        End Set
    End Property
    Public Property CONF_DIAS_EXA_BUSCA_DIAS As Integer
        Get
            Return EE_CONF_DIAS_EXA_BUSCA_DIAS
        End Get
        Set(value As Integer)
            EE_CONF_DIAS_EXA_BUSCA_DIAS = value
        End Set
    End Property
    Public Property ID_ESTADO_BUSCA_DIAS As Integer
        Get
            Return EE_ID_ESTADO_BUSCA_DIAS
        End Get
        Set(value As Integer)
            EE_ID_ESTADO_BUSCA_DIAS = value
        End Set
    End Property
    Public Property ID_PROCEDENCIA_BUSCA_DIAS As Integer
        Get
            Return EE_ID_PROCEDENCIA_BUSCA_DIAS
        End Get
        Set(value As Integer)
            EE_ID_PROCEDENCIA_BUSCA_DIAS = value
        End Set
    End Property
    Public Property ID_CONF_DIAS_BUSCA_DIAS As Integer
        Get
            Return EE_ID_CONF_DIAS_BUSCA_DIAS
        End Get
        Set(value As Integer)
            EE_ID_CONF_DIAS_BUSCA_DIAS = value
        End Set
    End Property
    '----------------------------------------
End Class
