Public Class E_DATOS_FECHA_PROCEDENCIA
    Dim EE_FECHA As String
    Dim EE_CONF_DIAS_EXA_BUSCA_DIAS As Integer
    Dim EE_TOTAL_ATE As Integer
    Dim EE_DIA_DEL_DIA As String
    Dim EE_AGEND_CUPO_NORMAL As Integer
    Dim EE_AGEND_PRIORITARIO As Integer
    Dim EE_AGEND_ESPONTANEO As Integer
    Dim EE_TOTAL_AGEND_CUPO_NORMAL As Integer
    Dim EE_TOTAL_AGEND_PRIORITARIO As Integer
    Dim EE_TOTAL_AGEND_ESPONTANEO As Integer

    Dim EE_TOTAL_COMENTARIO As String
    Public Property TOTAL_COMENTARIO As String
        Get
            Return EE_TOTAL_COMENTARIO
        End Get
        Set(value As String)
            EE_TOTAL_COMENTARIO = value
        End Set
    End Property
    Public Property TOTAL_AGEND_CUPO_NORMAL As Integer
        Get
            Return EE_TOTAL_AGEND_CUPO_NORMAL
        End Get
        Set(value As Integer)
            EE_TOTAL_AGEND_CUPO_NORMAL = value
        End Set
    End Property
    Public Property TOTAL_AGEND_PRIORITARIO As Integer
        Get
            Return EE_TOTAL_AGEND_PRIORITARIO
        End Get
        Set(value As Integer)
            EE_TOTAL_AGEND_PRIORITARIO = value
        End Set
    End Property
    Public Property TOTAL_AGEND_ESPONTANEO As Integer
        Get
            Return EE_TOTAL_AGEND_ESPONTANEO
        End Get
        Set(value As Integer)
            EE_TOTAL_AGEND_ESPONTANEO = value
        End Set
    End Property

    Public Property AGEND_CUPO_NORMAL As Integer
        Get
            Return EE_AGEND_CUPO_NORMAL
        End Get
        Set(value As Integer)
            EE_AGEND_CUPO_NORMAL = value
        End Set
    End Property
    Public Property AGEND_PRIORITARIO As Integer
        Get
            Return EE_AGEND_PRIORITARIO
        End Get
        Set(value As Integer)
            EE_AGEND_PRIORITARIO = value
        End Set
    End Property
    Public Property AGEND_ESPONTANEO As Integer
        Get
            Return EE_AGEND_ESPONTANEO
        End Get
        Set(value As Integer)
            EE_AGEND_ESPONTANEO = value
        End Set
    End Property

    Public Property DIA_DEL_DIA As String
        Get
            Return EE_DIA_DEL_DIA
        End Get
        Set(ByVal value As String)
            EE_DIA_DEL_DIA = value
        End Set
    End Property
    Public Property FECHA As String
        Get
            Return EE_FECHA
        End Get
        Set(ByVal value As String)
            EE_FECHA = value
        End Set
    End Property
    Public Property CONF_DIAS_EXA_BUSCA_DIAS As Integer
        Get
            Return EE_CONF_DIAS_EXA_BUSCA_DIAS
        End Get
        Set(ByVal value As Integer)
            EE_CONF_DIAS_EXA_BUSCA_DIAS = value
        End Set
    End Property
    Public Property TOTAL_ATE As Integer
        Get
            Return EE_TOTAL_ATE
        End Get
        Set(ByVal value As Integer)
            EE_TOTAL_ATE = value
        End Set
    End Property
End Class
