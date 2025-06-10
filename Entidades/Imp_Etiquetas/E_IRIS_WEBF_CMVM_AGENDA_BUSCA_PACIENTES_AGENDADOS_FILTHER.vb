Public Class E_IRIS_WEBF_CMVM_AGENDA_BUSCA_PACIENTES_AGENDADOS_FILTHER
    Private E_ID_PREINGRESO As Long
    Public Property ID_PREINGRESO() As Long
        Get
            Return E_ID_PREINGRESO
        End Get
        Set(ByVal value As Long)
            E_ID_PREINGRESO = value
        End Set
    End Property

    Private E_PREI_NUM As String
    Public Property PREI_NUM() As String
        Get
            Return E_PREI_NUM
        End Get
        Set(ByVal value As String)
            E_PREI_NUM = value
        End Set
    End Property

    Private E_PREI_FECHA_PRE As Date?
    Public Property PREI_FECHA_PRE() As Date?
        Get
            Return E_PREI_FECHA_PRE
        End Get
        Set(ByVal value As Date?)
            E_PREI_FECHA_PRE = value
        End Set
    End Property

    Private E_ID_ATENCION As Long
    Public Property ID_ATENCION() As Long
        Get
            Return E_ID_ATENCION
        End Get
        Set(ByVal value As Long)
            E_ID_ATENCION = value
        End Set
    End Property

    Private E_ATE_NUM As String
    Public Property ATE_NUM() As String
        Get
            Return E_ATE_NUM
        End Get
        Set(ByVal value As String)
            E_ATE_NUM = value
        End Set
    End Property

    Private E_ATE_FECHA As Date?
    Public Property ATE_FECHA() As Date?
        Get
            Return E_ATE_FECHA
        End Get
        Set(ByVal value As Date?)
            E_ATE_FECHA = value
        End Set
    End Property

    Private E_PAC_COD As String
    Public Property PAC_COD() As String
        Get
            Return E_PAC_COD
        End Get
        Set(ByVal value As String)
            E_PAC_COD = value
        End Set
    End Property

    Private E_PAC_NOMBRE As String
    Public Property PAC_NOMBRE() As String
        Get
            Return E_PAC_NOMBRE
        End Get
        Set(ByVal value As String)
            E_PAC_NOMBRE = value
        End Set
    End Property

    Private E_ID_PROCEDENCIA As Long
    Public Property ID_PROCEDENCIA() As Long
        Get
            Return E_ID_PROCEDENCIA
        End Get
        Set(ByVal value As Long)
            E_ID_PROCEDENCIA = value
        End Set
    End Property

    Private E_PROC_DESC As String
    Public Property PROC_DESC() As String
        Get
            Return E_PROC_DESC
        End Get
        Set(ByVal value As String)
            E_PROC_DESC = value
        End Set
    End Property

    Private E_ID_PREVE As Long
    Public Property ID_PREVE() As Long
        Get
            Return E_ID_PREVE
        End Get
        Set(ByVal value As Long)
            E_ID_PREVE = value
        End Set
    End Property

    Private E_PREV_DESC As String
    Public Property PREV_DESC() As String
        Get
            Return E_PREV_DESC
        End Get
        Set(ByVal value As String)
            E_PREV_DESC = value
        End Set
    End Property

    Private E_ID_PROGRAMA As Long
    Public Property ID_PROGRAMA() As Long
        Get
            Return E_ID_PROGRAMA
        End Get
        Set(ByVal value As Long)
            E_ID_PROGRAMA = value
        End Set
    End Property

    Private E_PROGRA_DESC As String
    Public Property PROGRA_DESC() As String
        Get
            Return E_PROGRA_DESC
        End Get
        Set(ByVal value As String)
            E_PROGRA_DESC = value
        End Set
    End Property

    Private E_ID_SUBP As Long
    Public Property ID_SUBP() As Long
        Get
            Return E_ID_SUBP
        End Get
        Set(ByVal value As Long)
            E_ID_SUBP = value
        End Set
    End Property

    Private E_SUBP_DESC As String
    Public Property SUBP_DESC() As String
        Get
            Return E_SUBP_DESC
        End Get
        Set(ByVal value As String)
            E_SUBP_DESC = value
        End Set
    End Property

    Private E_EST_DESCRIPCION As String
    Public Property EST_DESCRIPCION() As String
        Get
            Return E_EST_DESCRIPCION
        End Get
        Set(ByVal value As String)
            E_EST_DESCRIPCION = value
        End Set
    End Property

    Private E_COUNT_PEND As Integer
    Public Property COUNT_PEND() As Integer
        Get
            Return E_COUNT_PEND
        End Get
        Set(ByVal value As Integer)
            E_COUNT_PEND = value
        End Set
    End Property
End Class