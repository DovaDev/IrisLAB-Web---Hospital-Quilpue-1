Public Class E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA3
    Private EE_ID_PREINGRESO As Long
    Public Property ID_PREINGRESO() As Long
        Get
            Return EE_ID_PREINGRESO
        End Get
        Set(ByVal value As Long)
            EE_ID_PREINGRESO = value
        End Set
    End Property

    Private EE_PREI_NUM As String
    Public Property PREI_NUM() As String
        Get
            Return EE_PREI_NUM
        End Get
        Set(ByVal value As String)
            EE_PREI_NUM = value
        End Set
    End Property

    Private EE_PREI_FECHA As Date
    Public Property PREI_FECHA() As Date
        Get
            Return EE_PREI_FECHA
        End Get
        Set(ByVal value As Date)
            EE_PREI_FECHA = value
        End Set
    End Property

    Private EE_ID_ATENCION As Long
    Public Property ID_ATENCION() As Long
        Get
            Return EE_ID_ATENCION
        End Get
        Set(ByVal value As Long)
            EE_ID_ATENCION = value
        End Set
    End Property

    Private EE_ATE_NUM As String
    Public Property ATE_NUM() As String
        Get
            Return EE_ATE_NUM
        End Get
        Set(ByVal value As String)
            EE_ATE_NUM = value
        End Set
    End Property

    Private EE_ATE_FECHA As Date
    Public Property ATE_FECHA() As Date
        Get
            Return EE_ATE_FECHA
        End Get
        Set(ByVal value As Date)
            EE_ATE_FECHA = value
        End Set
    End Property

    Private EE_PAC_COD As String
    Public Property PAC_COD() As String
        Get
            Return EE_PAC_COD
        End Get
        Set(ByVal value As String)
            EE_PAC_COD = value
        End Set
    End Property

    Private EE_PAC_NOMBRE As String
    Public Property PAC_NOMBRE() As String
        Get
            Return EE_PAC_NOMBRE
        End Get
        Set(ByVal value As String)
            EE_PAC_NOMBRE = value
        End Set
    End Property

    Private EE_ID_PROCEDENCIA As Integer
    Public Property ID_PROCEDENCIA() As Integer
        Get
            Return EE_ID_PROCEDENCIA
        End Get
        Set(ByVal value As Integer)
            EE_ID_PROCEDENCIA = value
        End Set
    End Property

    Private EE_PROC_DESC As String
    Public Property PROC_DESC() As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(ByVal value As String)
            EE_PROC_DESC = value
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

    Private EE_PREVE_DESC As String
    Public Property PREVE_DESC() As String
        Get
            Return EE_PREVE_DESC
        End Get
        Set(ByVal value As String)
            EE_PREVE_DESC = value
        End Set
    End Property

    Private EE_EST_DESCRIPCION As String
    Public Property EST_DESCRIPCION() As String
        Get
            Return EE_EST_DESCRIPCION
        End Get
        Set(ByVal value As String)
            EE_EST_DESCRIPCION = value
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