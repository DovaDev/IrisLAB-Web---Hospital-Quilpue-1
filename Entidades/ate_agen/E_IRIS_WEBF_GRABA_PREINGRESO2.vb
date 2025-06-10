Public Class E_IRIS_WEBF_GRABA_PREINGRESO2
    Dim EE_ATE_NUM As String
    Dim EE_ID_PACIENTE As Integer
    Dim EE_ID_USUARIO As Integer
    Dim EE_ATE_FUR As Date
    Dim EE_ID_PROCE As Integer
    Dim EE_ID_ORDEN As Integer
    Dim EE_ID_TP_PACI As Integer
    Dim EE_ID_DOCTOR As Integer
    Dim EE_ID_PREVE As Integer
    Dim EE_ID_LOCAL As Integer
    Dim EE_ID_ESTADO As Integer
    Dim EE_ATE_OBS As String
    Dim EE_ATE_CAMA As String
    Dim EE_ATE_AÑO As Integer
    Dim EE_ATE_MES As Integer
    Dim EE_ATE_DIA As Integer
    Dim EE_ATE_TOTAL As Integer
    Dim EE_ATE_TOTAL_PREVI As Integer
    Dim EE_ATE_TOTAL_COPA As Integer
    Dim EE_PREI_FECHA_PRE As Integer
    Public Property ATE_NUM As String
        Get
            Return EE_ATE_NUM
        End Get
        Set(value As String)
            EE_ATE_NUM = value
        End Set
    End Property
    Public Property ID_PACIENTE As Integer
        Get
            Return EE_ID_PACIENTE
        End Get
        Set(value As Integer)
            EE_ID_PACIENTE = value
        End Set
    End Property
    Public Property ID_USUARIO As Integer
        Get
            Return EE_ID_USUARIO
        End Get
        Set(value As Integer)
            EE_ID_USUARIO = value
        End Set
    End Property
    Public Property ATE_FUR As Date
        Get
            Return EE_ATE_FUR
        End Get
        Set(value As Date)
            EE_ATE_FUR = value
        End Set
    End Property
    Public Property ID_PROCE As Integer
        Get
            Return EE_ID_PROCE
        End Get
        Set(value As Integer)
            EE_ID_PROCE = value
        End Set
    End Property
    Public Property ID_ORDEN As Integer
        Get
            Return EE_ID_ORDEN
        End Get
        Set(value As Integer)
            EE_ID_ORDEN = value
        End Set
    End Property
    Public Property ID_TP_PACI As Integer
        Get
            Return EE_ID_TP_PACI
        End Get
        Set(value As Integer)
            EE_ID_TP_PACI = value
        End Set
    End Property
    Public Property ID_DOCTOR As Integer
        Get
            Return EE_ID_DOCTOR
        End Get
        Set(value As Integer)
            EE_ID_DOCTOR = value
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
    Public Property ID_LOCAL As Integer
        Get
            Return EE_ID_LOCAL
        End Get
        Set(value As Integer)
            EE_ID_LOCAL = value
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
    Public Property ATE_OBS As String
        Get
            Return EE_ATE_OBS
        End Get
        Set(value As String)
            EE_ATE_OBS = value
        End Set
    End Property
    Public Property ATE_CAMA As String
        Get
            Return EE_ATE_CAMA
        End Get
        Set(value As String)
            EE_ATE_CAMA = value
        End Set
    End Property
    Public Property ATE_AÑO As Integer
        Get
            Return EE_ATE_AÑO
        End Get
        Set(value As Integer)
            EE_ATE_AÑO = value
        End Set
    End Property
    Public Property ATE_MES As Integer
        Get
            Return EE_ATE_MES
        End Get
        Set(value As Integer)
            EE_ATE_MES = value
        End Set
    End Property
    Public Property ATE_DIA As Integer
        Get
            Return EE_ATE_DIA
        End Get
        Set(value As Integer)
            EE_ATE_DIA = value
        End Set
    End Property
    Public Property ATE_TOTAL As Integer
        Get
            Return EE_ATE_TOTAL
        End Get
        Set(value As Integer)
            EE_ATE_TOTAL = value
        End Set
    End Property
    Public Property ATE_TOTAL_PREVI As Integer
        Get
            Return EE_ATE_TOTAL_PREVI
        End Get
        Set(value As Integer)
            EE_ATE_TOTAL_PREVI = value
        End Set
    End Property
    Public Property ATE_TOTAL_COPA As Integer
        Get
            Return EE_ATE_TOTAL_COPA
        End Get
        Set(value As Integer)
            EE_ATE_TOTAL_COPA = value
        End Set
    End Property
    Public Property PREI_FECHA_PRE As Integer
        Get
            Return EE_PREI_FECHA_PRE
        End Get
        Set(value As Integer)
            EE_PREI_FECHA_PRE = value
        End Set
    End Property
End Class
