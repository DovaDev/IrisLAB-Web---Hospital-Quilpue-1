Public Class E_IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER
    Dim EE_ID_ATENCION As String
    Dim EE_PAC_NOMBRE As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_ATE_NUM As String
    Dim EE_ATE_FECHA As String
    Dim EE_DOC_NOMBRE As String
    Dim EE_DOC_APELLIDO As String
    Dim EE_PREVE_DESC As String
    Dim EE_PROC_DESC As String
    Dim EE_TP_ATE_DESC As String
    Dim EE_ID_PACIENTE As String
    Dim EE_PREI_FECHA_PRE As Date
    Public Property PREI_FECHA_PRE As Date
        Get
            Return EE_PREI_FECHA_PRE
        End Get
        Set(value As Date)
            EE_PREI_FECHA_PRE = value
        End Set
    End Property
    Public Property ID_ATENCION As String
        Get
            Return EE_ID_ATENCION
        End Get
        Set(value As String)
            EE_ID_ATENCION = value
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
    Public Property ATE_NUM As String
        Get
            Return EE_ATE_NUM
        End Get
        Set(value As String)
            EE_ATE_NUM = value
        End Set
    End Property
    Public Property ATE_FECHA As String
        Get
            Return EE_ATE_FECHA
        End Get
        Set(value As String)
            EE_ATE_FECHA = value
        End Set
    End Property
    Public Property DOC_NOMBRE As String
        Get
            Return EE_DOC_NOMBRE
        End Get
        Set(value As String)
            EE_DOC_NOMBRE = value
        End Set
    End Property
    Public Property DOC_APELLIDO As String
        Get
            Return EE_DOC_APELLIDO
        End Get
        Set(value As String)
            EE_DOC_APELLIDO = value
        End Set
    End Property
    Public Property PREVE_DESC As String
        Get
            Return EE_PREVE_DESC
        End Get
        Set(value As String)
            EE_PREVE_DESC = value
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
    Public Property TP_ATE_DESC As String
        Get
            Return EE_TP_ATE_DESC
        End Get
        Set(value As String)
            EE_TP_ATE_DESC = value
        End Set
    End Property
    Public Property ID_PACIENTE As String
        Get
            Return EE_ID_PACIENTE
        End Get
        Set(value As String)
            EE_ID_PACIENTE = value
        End Set
    End Property
End Class
