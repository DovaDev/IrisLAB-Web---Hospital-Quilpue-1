Public Class E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX
    Dim EE_ID_PROCEDENCIA As Integer
    Dim EE_PROC_DESC As String
    Dim EE_PROC_CANT_EXA As Integer
    Dim EE_ID_ESTADO As Integer
    Dim EE_PRO_TIPO_I As Integer
    Dim EE_TOTAL_ATE As Integer
    Dim EE_AGEND_CUPO_NORMAL As Integer
    Dim EE_AGEND_PRIORITARIO As Integer
    Dim EE_AGEND_ESPONTANEO As Integer

    Dim EE_AGEND_PTGO As Integer
    Dim EE_ID_BLOQUE As Integer

    Dim EE_TOTAL_AGEND_CUPO_NORMAL As Integer
    Dim EE_TOTAL_AGEND_PRIORITARIO As Integer
    Dim EE_TOTAL_AGEND_ESPONTANEO As Integer

    Dim EE_TOTAL_AGEND_PTGO As Integer

    Dim EE_TOTAL_AGEND_PAP As Integer
    Dim EE_TOTAL_SOBRE_CUPO As Integer
    Dim EE_TOTAL_COMENTARIO As String
    Public Property TOTAL_COMENTARIO As String
        Get
            Return EE_TOTAL_COMENTARIO
        End Get
        Set(value As String)
            EE_TOTAL_COMENTARIO = value
        End Set
    End Property


    Public Property TOTAL_SOBRE_CUPO As Integer
        Get
            Return EE_TOTAL_SOBRE_CUPO
        End Get
        Set(value As Integer)
            EE_TOTAL_SOBRE_CUPO = value
        End Set
    End Property
    Public Property TOTAL_AGEND_PAP As Integer
        Get
            Return EE_TOTAL_AGEND_PAP
        End Get
        Set(value As Integer)
            EE_TOTAL_AGEND_PAP = value
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

    Public Property ID_PROCEDENCIA As Integer
        Get
            Return EE_ID_PROCEDENCIA
        End Get
        Set(value As Integer)
            EE_ID_PROCEDENCIA = value
        End Set
    End Property
    Public Property PROC_DESC As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(value As String)
            EE_PROC_DESC = value
        End Set
    End Property
    Public Property PROC_CANT_EXA As Integer
        Get
            Return EE_PROC_CANT_EXA
        End Get
        Set(value As Integer)
            EE_PROC_CANT_EXA = value
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
    Public Property PRO_TIPO_I As Integer
        Get
            Return EE_PRO_TIPO_I
        End Get
        Set(value As Integer)
            EE_PRO_TIPO_I = value
        End Set
    End Property
    Public Property TOTAL_ATE As Integer
        Get
            Return EE_TOTAL_ATE
        End Get
        Set(value As Integer)
            EE_TOTAL_ATE = value
        End Set
    End Property
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

    Public Property TOTAL_AGEND_PTGO As Integer
        Get
            Return EE_TOTAL_AGEND_PTGO
        End Get
        Set(value As Integer)
            EE_TOTAL_AGEND_PTGO = value
        End Set
    End Property

    Public Property AGEND_PTGO As Integer
        Get
            Return EE_AGEND_PTGO
        End Get
        Set(value As Integer)
            EE_AGEND_PTGO = value
        End Set
    End Property

    Public Property ID_BLOQUE As Integer
        Get
            Return EE_ID_BLOQUE
        End Get
        Set(value As Integer)
            EE_ID_BLOQUE = value
        End Set
    End Property
    '----------------------------------------
End Class
