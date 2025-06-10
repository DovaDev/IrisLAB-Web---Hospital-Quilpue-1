Public Class E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2
    Dim EE_ID_PREINGRESO As Integer
    Dim EE_PREI_NUM As Integer
    Dim EE_PREI_FECHA As Date
    Dim EE_PAC_NOMBRE As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_ID_ESTADO As Integer
    Dim EE_PAC_RUT As String
    Dim EE_PREI_FEC_FLE As Integer
    Dim EE_PREI_FECHA_PRE As Date
    Dim EE_ID_PACIENTE As Integer
    Dim EE_PREI_IID_ESTADO As Integer
    Dim EE_EST_DESCRIPCION As String
    Dim EE_ID_ATENCION As Integer
    Dim EE_PROC_DESC As String
    Dim EE_CANT_EXAM As Integer
    Dim EE_ATE_NUM As String
    Dim EE_DNI As String
    Dim EE_HA_DESC As String
    Dim EE_ID_HA As Integer
    Private EE_BLOQUE_DESC As String
    Private EE_ID_BLOQUE As Integer
    Private EE_SUB_GRUPO_ATE As Integer
    Private EE_PREI_HORA As String
    Private EE_ID_ORDEN As Integer
    Private EE_PREI_ANO As String
    Private EE_PREI_MES As String
    Private EE_PREI_DIA As String
    Dim EE_ATE_FECHA As String
    Dim EE_ATE_FECHA_TM As String
    Dim EE_ATE_NUM_INT As Integer
    Dim EE_PREI_FECHA_PRE_String As String
    Dim EE_CF_DESC As String
    Dim EE_ESTADO As Integer

    Public Property PREI_DIA() As String
        Get
            Return EE_PREI_DIA
        End Get
        Set(ByVal value As String)
            EE_PREI_DIA = value
        End Set
    End Property
    Public Property PREI_MES() As String
        Get
            Return EE_PREI_MES
        End Get
        Set(ByVal value As String)
            EE_PREI_MES = value
        End Set
    End Property
    Public Property PREI_ANO() As String
        Get
            Return EE_PREI_ANO
        End Get
        Set(ByVal value As String)
            EE_PREI_ANO = value
        End Set
    End Property
    Public Property ID_ORDEN() As Integer
        Get
            Return EE_ID_ORDEN
        End Get
        Set(ByVal value As Integer)
            EE_ID_ORDEN = value
        End Set
    End Property
    Public Property PREI_HORA() As String
        Get
            Return EE_PREI_HORA
        End Get
        Set(ByVal value As String)
            EE_PREI_HORA = value
        End Set
    End Property
    Public Property SUB_GRUPO_ATE() As Integer
        Get
            Return EE_SUB_GRUPO_ATE
        End Get
        Set(ByVal value As Integer)
            EE_SUB_GRUPO_ATE = value
        End Set
    End Property
    Public Property ID_BLOQUE() As Integer
        Get
            Return EE_ID_BLOQUE
        End Get
        Set(ByVal value As Integer)
            EE_ID_BLOQUE = value
        End Set
    End Property
    Public Property BLOQUE_DESC() As String
        Get
            Return EE_BLOQUE_DESC
        End Get
        Set(ByVal value As String)
            EE_BLOQUE_DESC = value
        End Set
    End Property

    Public Property ID_HA As Integer
        Get
            Return EE_ID_HA
        End Get
        Set(ByVal value As Integer)
            EE_ID_HA = value
        End Set
    End Property

    Public Property HA_DESC As String
        Get
            Return EE_HA_DESC
        End Get
        Set(ByVal value As String)
            EE_HA_DESC = value
        End Set
    End Property

    Public Property DNI As String
        Get
            Return EE_DNI
        End Get
        Set(ByVal value As String)
            EE_DNI = value
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
    Public Property CANT_EXAM As Integer
        Get
            Return EE_CANT_EXAM
        End Get
        Set(ByVal value As Integer)
            EE_CANT_EXAM = value
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
    Public Property PREI_NUM As Integer
        Get
            Return EE_PREI_NUM
        End Get
        Set(value As Integer)
            EE_PREI_NUM = value
        End Set
    End Property
    Public Property PREI_FECHA As Date
        Get
            Return EE_PREI_FECHA
        End Get
        Set(value As Date)
            EE_PREI_FECHA = value
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
    Public Property PREI_FEC_FLE As Integer
        Get
            Return EE_PREI_FEC_FLE
        End Get
        Set(value As Integer)
            EE_PREI_FEC_FLE = value
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
    Public Property ID_PACIENTE As Integer
        Get
            Return EE_ID_PACIENTE
        End Get
        Set(value As Integer)
            EE_ID_PACIENTE = value
        End Set
    End Property
    Public Property PREI_IID_ESTADO As Integer
        Get
            Return EE_PREI_IID_ESTADO
        End Get
        Set(value As Integer)
            EE_PREI_IID_ESTADO = value
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
    Public Property PROC_DESC As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(value As String)
            EE_PROC_DESC = value
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

    Public Property ATE_FECHA_TM As String
        Get
            Return EE_ATE_FECHA_TM
        End Get
        Set(value As String)
            EE_ATE_FECHA_TM = value
        End Set
    End Property

    Public Property ATE_NUM_INT As Integer
        Get
            Return EE_ATE_NUM_INT
        End Get
        Set(value As Integer)
            EE_ATE_NUM_INT = value
        End Set
    End Property

    Public Property PREI_FECHA_PRE_String As String
        Get
            Return EE_PREI_FECHA_PRE_String
        End Get
        Set(value As String)
            EE_PREI_FECHA_PRE_String = value
        End Set
    End Property

    Public Property CF_DESC As String
        Get
            Return EE_CF_DESC
        End Get
        Set(value As String)
            EE_CF_DESC = value
        End Set
    End Property

    Public Property ESTADO As Integer
        Get
            Return EE_ESTADO
        End Get
        Set(value As Integer)
            EE_ESTADO = value
        End Set
    End Property
End Class
