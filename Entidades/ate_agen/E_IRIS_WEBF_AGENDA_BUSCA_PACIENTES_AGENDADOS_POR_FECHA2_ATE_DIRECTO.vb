Public Class E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2_ATE_DIRECTO
    Dim EE_ID_ATENCION As Integer
    Dim EE_ATE_FECHA As String
    Dim EE_PAC_NOMBRE As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_ID_ESTADO As Integer
    Dim EE_PAC_RUT As String
    Dim EE_EST_DESCRIPCION As String
    Dim EE_ATE_NUM As String
    Dim EE_DNI As String
    Public Property DNI As String
        Get
            Return EE_DNI
        End Get
        Set(ByVal value As String)
            EE_DNI = value
        End Set
    End Property
    Public Property ATE_FECHA As String
        Get
            Return EE_ATE_FECHA
        End Get
        Set(ByVal value As String)
            EE_ATE_FECHA = value
        End Set
    End Property

    Public Property ATE_NUM As String
        Get
            Return EE_ATE_NUM
        End Get
        Set(ByVal value As String)
            EE_ATE_NUM = value
        End Set
    End Property
    Public Property PAC_NOMBRE As String
        Get
            Return EE_PAC_NOMBRE
        End Get
        Set(value As String)
            EE_PAC_NOMBRE = value
        End Set
    End Property
    Public Property PAC_APELLIDO As String
        Get
            Return EE_PAC_APELLIDO
        End Get
        Set(value As String)
            EE_PAC_APELLIDO = value
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
    Public Property PAC_RUT As String
        Get
            Return EE_PAC_RUT
        End Get
        Set(value As String)
            EE_PAC_RUT = value
        End Set
    End Property

    Public Property EST_DESCRIPCION As String
        Get
            Return EE_EST_DESCRIPCION
        End Get
        Set(value As String)
            EE_EST_DESCRIPCION = value
        End Set
    End Property
    Public Property ID_ATENCION As Integer
        Get
            Return EE_ID_ATENCION
        End Get
        Set(value As Integer)
            EE_ID_ATENCION = value
        End Set
    End Property
End Class
