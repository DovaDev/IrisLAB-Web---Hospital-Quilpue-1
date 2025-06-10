Public Class E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION
    Dim EE_DOC_NOMBRE As String
    Dim EE_DOC_APELLIDO As String
    Dim EE_ID_PREINGRESO As Integer
    Dim EE_PREI_NUM As String
    Dim EE_TP_ATE_DESC As String
    Dim EE_LOCAL_DESC As String
    Dim EE_ORD_DESC As String
    Dim EE_ID_ORDEN As Integer
    Dim EE_ID_PROCEDENCIA As Integer
    Dim EE_ID_TP_PACI As Integer
    Dim EE_ID_DOCTOR As Integer
    Dim EE_ID_PREVE As Integer
    Dim EE_ID_LOCAL As Integer
    Dim EE_PREI_CAMA As String
    Dim EE_PREI_OBS_FICHA As String
    Dim EE_PROC_DESC As String
    Dim EE_PREVE_DESC As String
    Dim EE_ID_PROGRAMA As Integer
    Dim EE_ID_SECTOR As Integer
    Dim EE_ATE_NUM_INTERNO As String
    Dim EE_PREI_OBS_TM As String
    Dim EE_ID_ATENCION As Integer
    Dim EE_ID_DIAGNOSTICO As String
    Dim EE_ID_DIAGNOSTICO2 As String
    Dim EE_VIH As String
    Dim EE_Sub_atencion As Integer
    Dim EE_Sub_PROGRAMA As Integer
    Dim EE_ID_TP_PAGO As Integer
    Dim EE_ATE_NUM As Integer
    Dim EE_EMPRESA As Integer
    Dim EE_ID_GRUPO_PESQUISA As Integer

    Public Property ATE_NUM As Integer
        Get
            Return EE_ATE_NUM
        End Get
        Set(value As Integer)
            EE_ATE_NUM = value
        End Set
    End Property

    Public Property ID_TP_PAGO As Integer
        Get
            Return EE_ID_TP_PAGO
        End Get
        Set(value As Integer)
            EE_ID_TP_PAGO = value
        End Set
    End Property

    Public Property Sub_PROGRAMA As Integer
        Get
            Return EE_Sub_PROGRAMA
        End Get
        Set(value As Integer)
            EE_Sub_PROGRAMA = value
        End Set
    End Property
    Public Property Sub_atencion As Integer
        Get
            Return EE_Sub_atencion
        End Get
        Set(value As Integer)
            EE_Sub_atencion = value
        End Set
    End Property

    Dim EE_OMI As String

    Public Property OMI As String
        Get
            Return EE_OMI
        End Get
        Set(value As String)
            EE_OMI = value
        End Set
    End Property

    Public Property VIH As String
        Get
            Return EE_VIH
        End Get
        Set(value As String)
            EE_VIH = value
        End Set
    End Property

    Public Property ID_DIAGNOSTICO As String
        Get
            Return EE_ID_DIAGNOSTICO
        End Get
        Set(value As String)
            EE_ID_DIAGNOSTICO = value
        End Set
    End Property

    Public Property ID_DIAGNOSTICO2 As String
        Get
            Return EE_ID_DIAGNOSTICO2
        End Get
        Set(value As String)
            EE_ID_DIAGNOSTICO2 = value
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
    Public Property PREI_OBS_TM As String
        Get
            Return EE_PREI_OBS_TM
        End Get
        Set(value As String)
            EE_PREI_OBS_TM = value
        End Set
    End Property
    Public Property ATE_NUM_INTERNO As String
        Get
            Return EE_ATE_NUM_INTERNO
        End Get
        Set(value As String)
            EE_ATE_NUM_INTERNO = value
        End Set
    End Property
    Public Property ID_PROGRAMA As Integer
        Get
            Return EE_ID_PROGRAMA
        End Get
        Set(value As Integer)
            EE_ID_PROGRAMA = value
        End Set
    End Property
    Public Property ID_SECTOR As Integer
        Get
            Return EE_ID_SECTOR
        End Get
        Set(value As Integer)
            EE_ID_SECTOR = value
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
    Public Property ID_PREINGRESO As Integer
        Get
            Return EE_ID_PREINGRESO
        End Get
        Set(value As Integer)
            EE_ID_PREINGRESO = value
        End Set
    End Property
    Public Property PREI_NUM As String
        Get
            Return EE_PREI_NUM
        End Get
        Set(value As String)
            EE_PREI_NUM = value
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
    Public Property LOCAL_DESC As String
        Get
            Return EE_LOCAL_DESC
        End Get
        Set(value As String)
            EE_LOCAL_DESC = value
        End Set
    End Property
    Public Property ORD_DESC As String
        Get
            Return EE_ORD_DESC
        End Get
        Set(value As String)
            EE_ORD_DESC = value
        End Set
    End Property
    Public Property ID_ORDEN As Integer
        Get
            Return EE_ID_ORDEN
        End Get
        Set(value As Integer)
            EE_ID_ORDEN = value
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
    Public Property ID_TP_PACI As Integer
        Get
            Return EE_ID_TP_PACI
        End Get
        Set(value As Integer)
            EE_ID_TP_PACI = value
        End Set
    End Property
    Public Property ID_DOCTOR As Integer
        Get
            Return EE_ID_DOCTOR
        End Get
        Set(value As Integer)
            EE_ID_DOCTOR = value
        End Set
    End Property
    Public Property ID_PREVE As Integer
        Get
            Return EE_ID_PREVE
        End Get
        Set(value As Integer)
            EE_ID_PREVE = value
        End Set
    End Property
    Public Property ID_LOCAL As Integer
        Get
            Return EE_ID_LOCAL
        End Get
        Set(value As Integer)
            EE_ID_LOCAL = value
        End Set
    End Property
    Public Property PREI_CAMA As String
        Get
            Return EE_PREI_CAMA
        End Get
        Set(value As String)
            EE_PREI_CAMA = value
        End Set
    End Property
    Public Property PREI_OBS_FICHA As String
        Get
            Return EE_PREI_OBS_FICHA
        End Get
        Set(value As String)
            EE_PREI_OBS_FICHA = value
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
    Public Property PREVE_DESC As String
        Get
            Return EE_PREVE_DESC
        End Get
        Set(value As String)
            EE_PREVE_DESC = value
        End Set
    End Property

    Public Property EMPRESA As Integer
        Get
            Return EE_EMPRESA
        End Get
        Set(value As Integer)
            EE_EMPRESA = value
        End Set
    End Property

    Public Property ID_GRUPO_PESQUISA As Integer
        Get
            Return EE_ID_GRUPO_PESQUISA
        End Get
        Set(value As Integer)
            EE_ID_GRUPO_PESQUISA = value
        End Set
    End Property
End Class
