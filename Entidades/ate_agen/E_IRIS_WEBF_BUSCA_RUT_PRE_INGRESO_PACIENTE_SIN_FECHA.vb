Public Class E_IRIS_WEBF_BUSCA_RUT_PRE_INGRESO_PACIENTE_SIN_FECHA
    Dim EE_PAC_RUT As String
    Dim EE_PAC_NOMBRE As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_PREI_NUM As Integer
    Dim EE_PREI_FECHA_PRE As Date
    Dim EE_PREI_FECHA_A As Date
    Dim EE_ID_ATENCION As Integer
    Dim EE_PROC_DESC As String
    Dim EE_ID_PREINGRESO As Integer
    Dim EE_ID_PROCEDENCIA As Integer
    Public Property PAC_RUT As String
        Get
            Return EE_PAC_RUT
        End Get
        Set(value As String)
            EE_PAC_RUT = value
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
    Public Property PREI_NUM As Integer
        Get
            Return EE_PREI_NUM
        End Get
        Set(value As Integer)
            EE_PREI_NUM = value
        End Set
    End Property
    Public Property PREI_FECHA_PRE As Date
        Get
            Return EE_PREI_FECHA_PRE
        End Get
        Set(value As Date)
            EE_PREI_FECHA_PRE = value
        End Set
    End Property
    Public Property PREI_FECHA_A As Date
        Get
            Return EE_PREI_FECHA_A
        End Get
        Set(value As Date)
            EE_PREI_FECHA_A = value
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
    Public Property PROC_DESC As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(value As String)
            EE_PROC_DESC = value
        End Set
    End Property
    Public Property ID_PREINGRESO As Integer
        Get
            Return EE_ID_PREINGRESO
        End Get
        Set(value As Integer)
            EE_ID_PREINGRESO = value
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
End Class
