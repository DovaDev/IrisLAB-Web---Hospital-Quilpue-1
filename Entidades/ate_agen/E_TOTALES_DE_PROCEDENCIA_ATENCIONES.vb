Public Class E_TOTALES_DE_PROCEDENCIA_ATENCIONES
    Dim EE_TOTAL_AGEND_CUPO_NORMAL As Integer
    Dim EE_TOTAL_AGEND_PRIORITARIO As Integer
    Dim EE_TOTAL_AGEND_ESPONTANEO As Integer
    Dim EE_TOTAL_AGEND_PAP As Integer
    Dim EE_TOTAL_SOBRE_CUPO As Integer
    Dim EE_id_desc As String
    Private EE_PREI_FECHA_PRE As Date


    Private EE_TOTAL_COMENTARIO As String
    Public Property TOTAL_COMENTARIO() As String
        Get
            Return EE_TOTAL_COMENTARIO
        End Get
        Set(ByVal value As String)
            EE_TOTAL_COMENTARIO = value
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
    Public Property TOTAL_SOBRE_CUPO As Integer
        Get
            Return EE_TOTAL_SOBRE_CUPO
        End Get
        Set(value As Integer)
            EE_TOTAL_SOBRE_CUPO = value
        End Set
    End Property
    Public Property id_desc As String
        Get
            Return EE_id_desc
        End Get
        Set(value As String)
            EE_id_desc = value
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
End Class
