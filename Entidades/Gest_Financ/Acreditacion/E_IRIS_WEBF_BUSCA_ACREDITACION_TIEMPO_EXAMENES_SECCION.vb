Public Class E_IRIS_WEBF_BUSCA_ACREDITACION_TIEMPO_EXAMENES_SECCION
    Private EE_ATE_NUM As String
    Private EE_ATE_FECHA As Date
    Private EE_ATE_DET_V_ID_ESTADO As Integer
    Private EE_EST_DESCRIPCION As String
    Private EE_CF_COD As String
    Private EE_CF_DESC As String
    Private EE_ID_CODIGO_FONASA As Integer
    Private EE_ID_ATENCION As Integer
    Private EE_PAC_NOMBRE As String
    Private EE_PAC_APELLIDO As String
    Private EE_PROC_DESC As String
    Private EE_ID_PROCEDENCIA As Integer
    Private EE_ATE_AÑO As String
    Private EE_SEXO_DESC As String
    Private EE_ID_PACIENTE As Integer
    Private EE_ID_SEXO As Integer
    Private EE_ID_ESTADO As Integer
    Private EE_PAC_RUT As String
    Private EE_PAC_FNAC As Date
    Private EE_ATE_DET_V_PREVI As Integer
    Private EE_ATE_MES As String
    Private EE_ATE_DIA As String
    Private EE_TP_PAGO__DESC As String
    Private EE_PREVE_DESC As String
    Private EE_DOC_NOMBRE As String
    Private EE_DOC_APELLIDO As String
    Private EE_PROGRA_DESC As String
    Private EE_CF_TIEMPO_NORMAL As String
    Private EE_CF_TIEMPO_URGENCIA As String
    Private EE_CF_DIAS As String
    Private EE_ATE_DET_V_FECHA As Date
    Private EE_PROC_URG As String
    Private EE_ORD_DESC As String
    Private EE_ORD_URG As String
    Private EE_ENCRYPTED_ID As String
    Public Property ENCRYPTED_ID() As String
        Get
            Return EE_ENCRYPTED_ID
        End Get
        Set(ByVal value As String)
            EE_ENCRYPTED_ID = value
        End Set
    End Property
    Public Property ORD_URG() As String
        Get
            Return EE_ORD_URG
        End Get
        Set(ByVal value As String)
            EE_ORD_URG = value
        End Set
    End Property
    Public Property ORD_DESC() As String
        Get
            Return EE_ORD_DESC
        End Get
        Set(ByVal value As String)
            EE_ORD_DESC = value
        End Set
    End Property
    Public Property PROC_URG() As String
        Get
            Return EE_PROC_URG
        End Get
        Set(ByVal value As String)
            EE_PROC_URG = value
        End Set
    End Property
    Public Property ATE_DET_V_FECHA() As Date
        Get
            Return EE_ATE_DET_V_FECHA
        End Get
        Set(ByVal value As Date)
            EE_ATE_DET_V_FECHA = value
        End Set
    End Property
    Public Property CF_DIAS() As String
        Get
            Return EE_CF_DIAS
        End Get
        Set(ByVal value As String)
            EE_CF_DIAS = value
        End Set
    End Property
    Public Property CF_TIEMPO_URGENCIA() As String
        Get
            Return EE_CF_TIEMPO_URGENCIA
        End Get
        Set(ByVal value As String)
            EE_CF_TIEMPO_URGENCIA = value
        End Set
    End Property
    Public Property CF_TIEMPO_NORMAL() As String
        Get
            Return EE_CF_TIEMPO_NORMAL
        End Get
        Set(ByVal value As String)
            EE_CF_TIEMPO_NORMAL = value
        End Set
    End Property
    Public Property PROGRA_DESC() As String
        Get
            Return EE_PROGRA_DESC
        End Get
        Set(ByVal value As String)
            EE_PROGRA_DESC = value
        End Set
    End Property
    Public Property DOC_APELLIDO() As String
        Get
            Return EE_DOC_APELLIDO
        End Get
        Set(ByVal value As String)
            EE_DOC_APELLIDO = value
        End Set
    End Property
    Public Property DOC_NOMBRE() As String
        Get
            Return EE_DOC_NOMBRE
        End Get
        Set(ByVal value As String)
            EE_DOC_NOMBRE = value
        End Set
    End Property
    Public Property PREVE_DESC() As String
        Get
            Return EE_PREVE_DESC
        End Get
        Set(ByVal value As String)
            EE_PREVE_DESC = value
        End Set
    End Property
    Public Property TP_PAGO_DESC() As String
        Get
            Return EE_TP_PAGO__DESC
        End Get
        Set(ByVal value As String)
            EE_TP_PAGO__DESC = value
        End Set
    End Property
    Public Property ATE_DIA() As String
        Get
            Return EE_ATE_DIA
        End Get
        Set(ByVal value As String)
            EE_ATE_DIA = value
        End Set
    End Property
    Public Property ATE_MES() As String
        Get
            Return EE_ATE_MES
        End Get
        Set(ByVal value As String)
            EE_ATE_MES = value
        End Set
    End Property
    Public Property ATE_DET_V_PREVI() As Integer
        Get
            Return EE_ATE_DET_V_PREVI
        End Get
        Set(ByVal value As Integer)
            EE_ATE_DET_V_PREVI = value
        End Set
    End Property
    Public Property PAC_FNAC() As Date
        Get
            Return EE_PAC_FNAC
        End Get
        Set(ByVal value As Date)
            EE_PAC_FNAC = value
        End Set
    End Property
    Public Property PAC_RUT() As String
        Get
            Return EE_PAC_RUT
        End Get
        Set(ByVal value As String)
            EE_PAC_RUT = value
        End Set
    End Property
    Public Property ID_ESTADO() As Integer
        Get
            Return EE_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ID_ESTADO = value
        End Set
    End Property
    Public Property ID_SEXO() As Integer
        Get
            Return EE_ID_SEXO
        End Get
        Set(ByVal value As Integer)
            EE_ID_SEXO = value
        End Set
    End Property
    Public Property ID_PACIENTE() As Integer
        Get
            Return EE_ID_PACIENTE
        End Get
        Set(ByVal value As Integer)
            EE_ID_PACIENTE = value
        End Set
    End Property

    Public Property SEXO_DESC() As String
        Get
            Return EE_SEXO_DESC
        End Get
        Set(ByVal value As String)
            EE_SEXO_DESC = value
        End Set
    End Property
    Public Property ATE_AÑO() As String
        Get
            Return EE_ATE_AÑO
        End Get
        Set(ByVal value As String)
            EE_ATE_AÑO = value
        End Set
    End Property
    Public Property ID_PROCEDENCIA() As Integer
        Get
            Return EE_ID_PROCEDENCIA
        End Get
        Set(ByVal value As Integer)
            EE_ID_PROCEDENCIA = value
        End Set
    End Property
    Public Property PROC_DESC() As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(ByVal value As String)
            EE_PROC_DESC = value
        End Set
    End Property
    Public Property PAC_APELLIDO() As String
        Get
            Return EE_PAC_APELLIDO
        End Get
        Set(ByVal value As String)
            EE_PAC_APELLIDO = value
        End Set
    End Property
    Public Property PAC_NOMBRE() As String
        Get
            Return EE_PAC_NOMBRE
        End Get
        Set(ByVal value As String)
            EE_PAC_NOMBRE = value
        End Set
    End Property
    Public Property ID_ATENCION() As Integer
        Get
            Return EE_ID_ATENCION
        End Get
        Set(ByVal value As Integer)
            EE_ID_ATENCION = value
        End Set
    End Property
    Public Property ID_CODIGO_FONASA() As Integer
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(ByVal value As Integer)
            EE_ID_CODIGO_FONASA = value
        End Set
    End Property
    Public Property CF_DESC() As String
        Get
            Return EE_CF_DESC
        End Get
        Set(ByVal value As String)
            EE_CF_DESC = value
        End Set
    End Property
    Public Property CF_COD() As String
        Get
            Return EE_CF_COD
        End Get
        Set(ByVal value As String)
            EE_CF_COD = value
        End Set
    End Property
    Public Property EST_DESCRIPCION() As String
        Get
            Return EE_EST_DESCRIPCION
        End Get
        Set(ByVal value As String)
            EE_EST_DESCRIPCION = value
        End Set
    End Property
    Public Property ATE_DET_V_ID_ESTADO() As Integer
        Get
            Return EE_ATE_DET_V_ID_ESTADO
        End Get
        Set(ByVal value As Integer)
            EE_ATE_DET_V_ID_ESTADO = value
        End Set
    End Property
    Public Property ATE_FECHA() As Date
        Get
            Return EE_ATE_FECHA
        End Get
        Set(ByVal value As Date)
            EE_ATE_FECHA = value
        End Set
    End Property
    Public Property ATE_NUM() As String
        Get
            Return EE_ATE_NUM
        End Get
        Set(ByVal value As String)
            EE_ATE_NUM = value
        End Set
    End Property

End Class
