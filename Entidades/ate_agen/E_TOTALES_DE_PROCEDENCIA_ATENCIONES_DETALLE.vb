Public Class E_TOTALES_DE_PROCEDENCIA_ATENCIONES_DETALLE
    Private EE_TOTAL_AGEND_CUPO_NORMAL As Integer
    Private EE_TOTAL_AGEND_PRIORITARIO As Integer
    Private EE_TOTAL_AGEND_ESPONTANEO As Integer
    Private EE_PREI_FECHA_PRE As Date
    Private EE_CONF_DIAS_EXA As Integer
    Private EE_TOTAL_CUPO_NORMAL As Integer
    Private EE_TOTAL_PRIORITARIO As Integer
    Private EE_TOTAL_ESPONTANEO As Integer
    Public Property TOTAL_ESPONTANEO() As Integer
        Get
            Return EE_TOTAL_ESPONTANEO
        End Get
        Set(ByVal value As Integer)
            EE_TOTAL_ESPONTANEO = value
        End Set
    End Property
    Public Property TOTAL_PRIORITARIO() As Integer
        Get
            Return EE_TOTAL_PRIORITARIO
        End Get
        Set(ByVal value As Integer)
            EE_TOTAL_PRIORITARIO = value
        End Set
    End Property
    Public Property TOTAL_CUPO_NORMAL() As Integer
        Get
            Return EE_TOTAL_CUPO_NORMAL
        End Get
        Set(ByVal value As Integer)
            EE_TOTAL_CUPO_NORMAL = value
        End Set
    End Property
    Public Property CONF_DIAS_EXA() As Integer
        Get
            Return EE_CONF_DIAS_EXA
        End Get
        Set(ByVal value As Integer)
            EE_CONF_DIAS_EXA = value
        End Set
    End Property
    Public Property PREI_FECHA_PRE() As Date
        Get
            Return EE_PREI_FECHA_PRE
        End Get
        Set(ByVal value As Date)
            EE_PREI_FECHA_PRE = value
        End Set
    End Property
    Public Property TOTAL_AGEND_ESPONTANEO() As Integer
        Get
            Return EE_TOTAL_AGEND_ESPONTANEO
        End Get
        Set(ByVal value As Integer)
            EE_TOTAL_AGEND_ESPONTANEO = value
        End Set
    End Property
    Public Property TOTAL_AGEND_PRIORITARIO() As Integer
        Get
            Return EE_TOTAL_AGEND_PRIORITARIO
        End Get
        Set(ByVal value As Integer)
            EE_TOTAL_AGEND_PRIORITARIO = value
        End Set
    End Property
    Public Property TOTAL_AGEND_CUPO_NORMAL() As Integer
        Get
            Return EE_TOTAL_AGEND_CUPO_NORMAL
        End Get
        Set(ByVal value As Integer)
            EE_TOTAL_AGEND_CUPO_NORMAL = value
        End Set
    End Property
End Class
