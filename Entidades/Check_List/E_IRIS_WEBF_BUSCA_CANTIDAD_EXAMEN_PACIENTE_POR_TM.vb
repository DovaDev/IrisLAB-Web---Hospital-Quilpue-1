Public Class E_IRIS_WEBF_BUSCA_CANTIDAD_EXAMEN_PACIENTE_POR_TM
    Dim EE_ID_ATENCION As Integer
    Dim EE_ATE_NUM As Integer
    Dim EE_ATE_FECHA As Date
    Dim EE_ID_PACIENTE As Integer
    Dim EE_ID_PROCEDENCIA As Integer
    Dim EE_CANT As Integer
    Dim EE_PAC_NOMBRE As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_PROC_DESC As String
    Dim EE_ATE_TOTAL_PREVI As Integer
    Dim EE_ATE_TOTAL_COPA As Integer
    Dim EE_ATE_TOTAL As Integer
    Dim EE_SEXO_DESC As String
    Dim EE_PAC_RUT As String
    Public Property ID_ATENCION As Integer
        Get
            Return EE_ID_ATENCION
        End Get
        Set(value As Integer)
            EE_ID_ATENCION = value
        End Set
    End Property
    Public Property ATE_NUM As Integer
        Get
            Return EE_ATE_NUM
        End Get
        Set(value As Integer)
            EE_ATE_NUM = value
        End Set
    End Property
    Public Property ATE_FECHA As Date
        Get
            Return EE_ATE_FECHA
        End Get
        Set(value As Date)
            EE_ATE_FECHA = value
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
    Public Property ID_PROCEDENCIA As Integer
        Get
            Return EE_ID_PROCEDENCIA
        End Get
        Set(value As Integer)
            EE_ID_PROCEDENCIA = value
        End Set
    End Property
    Public Property CANT As Integer
        Get
            Return EE_CANT
        End Get
        Set(value As Integer)
            EE_CANT = value
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
    Public Property PROC_DESC As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(value As String)
            EE_PROC_DESC = value
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
    Public Property ATE_TOTAL As Integer
        Get
            Return EE_ATE_TOTAL
        End Get
        Set(value As Integer)
            EE_ATE_TOTAL = value
        End Set
    End Property
    Public Property SEXO_DESC As String
        Get
            Return EE_SEXO_DESC
        End Get
        Set(value As String)
            EE_SEXO_DESC = value
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
End Class
