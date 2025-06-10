Public Class E_IRIS_WEBF_BUSCA_LISTADO_EXAMENES_IMPRIMIR
    Private EE_ID_DET_ATE As Long
    Private EE_CF_DESC As String
    Private EE_USU_NIC As String
    Private EE_ID_ATENCION As Long
    Private EE_ID_ESTADO As Integer
    Private EE_CF_COD As String
    Private EE_ATE_DET_V_ID_USU As Long
    Private EE_ATE_DET_V_ID_ESTADO As Long
    Private EE_ATE_DET_V_FECHA As Date
    Private EE_ID_PER As Long
    Private EE_ATE_DET_IMPRIME As String
    Private EE_ATE_FECHA As Date
    Private EE_TP_PAGO_DESC As String
    Private EE_ID_TP_PAGO As Long
    Private EE_ATE_DET_NUM_COPIA As Integer
    Private EE_CF_DIAS As Long
    Private EE_CF_IMP_SOLA As String
    Private EE_CF_IMP_NOM_PER As String
    Private EE_CF_IMP_PARCIAL As String
    Private EE_CF_IMP_POSX As Long
    Private EE_CF_IMP_POSY As Long
    Private EE_CF_IMP_LETRA As String
    Private EE_CF_IMP_TAMANO As Integer
    Private EE_SECC_DESC As String
    Private EE_ESTADO_WEB_DERIVADO As Integer
    Private EE_ID_CODIGO_FONASA As Integer
    Private EE_CF_AVIS As String
    Private EE_ATE_NUM_AVIS As String
    Private EE_ATE_NUM As String
    Private EE_PROC_DESC As String
    Private EE_PREVE_DESC As String
    Private EE_DOC_NOMBRE As String
    Private EE_DOC_APELLIDO As String
    Private EE_ATE_ACT_WEB As String
    Private EE_ATE_DET_REV_ID_ESTADO As Integer

    Public Property ATE_ACT_WEB As String
        Get
            Return EE_ATE_ACT_WEB
        End Get
        Set(value As String)
            EE_ATE_ACT_WEB = value
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

    Public Property DOC_NOMBRE As String
        Get
            Return EE_DOC_NOMBRE
        End Get
        Set(value As String)
            EE_DOC_NOMBRE = value
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
    Public Property ATE_NUM As String
        Get
            Return EE_ATE_NUM
        End Get
        Set(value As String)
            EE_ATE_NUM = value
        End Set
    End Property
    Public Property ATE_NUM_AVIS As String
        Get
            Return EE_ATE_NUM_AVIS
        End Get
        Set(value As String)
            EE_ATE_NUM_AVIS = value
        End Set
    End Property
    Public Property CF_AVIS As String
        Get
            Return EE_CF_AVIS
        End Get
        Set(value As String)
            EE_CF_AVIS = value
        End Set
    End Property
    Public Property ID_DET_ATE As Long
        Get
            Return EE_ID_DET_ATE
        End Get
        Set(value As Long)
            EE_ID_DET_ATE = value
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
    Public Property USU_NIC As String
        Get
            Return EE_USU_NIC
        End Get
        Set(value As String)
            EE_USU_NIC = value
        End Set
    End Property
    Public Property ID_ATENCION As Long
        Get
            Return EE_ID_ATENCION
        End Get
        Set(value As Long)
            EE_ID_ATENCION = value
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
    Public Property CF_COD As String
        Get
            Return EE_CF_COD
        End Get
        Set(value As String)
            EE_CF_COD = value
        End Set
    End Property
    Public Property ATE_DET_V_ID_USU As Long
        Get
            Return EE_ATE_DET_V_ID_USU
        End Get
        Set(value As Long)
            EE_ATE_DET_V_ID_USU = value
        End Set
    End Property
    Public Property ATE_DET_V_ID_ESTADO As Long
        Get
            Return EE_ATE_DET_V_ID_ESTADO
        End Get
        Set(value As Long)
            EE_ATE_DET_V_ID_ESTADO = value
        End Set
    End Property
    Public Property ATE_DET_V_FECHA As Date
        Get
            Return EE_ATE_DET_V_FECHA
        End Get
        Set(value As Date)
            EE_ATE_DET_V_FECHA = value
        End Set
    End Property
    Public Property ID_PER As Long
        Get
            Return EE_ID_PER
        End Get
        Set(value As Long)
            EE_ID_PER = value
        End Set
    End Property
    Public Property ATE_DET_IMPRIME As String
        Get
            Return EE_ATE_DET_IMPRIME
        End Get
        Set(value As String)
            EE_ATE_DET_IMPRIME = value
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
    Public Property TP_PAGO_DESC As String
        Get
            Return EE_TP_PAGO_DESC
        End Get
        Set(value As String)
            EE_TP_PAGO_DESC = value
        End Set
    End Property
    Public Property ID_TP_PAGO As Long
        Get
            Return EE_ID_TP_PAGO
        End Get
        Set(value As Long)
            EE_ID_TP_PAGO = value
        End Set
    End Property
    Public Property ATE_DET_NUM_COPIA As Integer
        Get
            Return EE_ATE_DET_NUM_COPIA
        End Get
        Set(value As Integer)
            EE_ATE_DET_NUM_COPIA = value
        End Set
    End Property
    Public Property CF_DIAS As Long
        Get
            Return EE_CF_DIAS
        End Get
        Set(value As Long)
            EE_CF_DIAS = value
        End Set
    End Property
    Public Property CF_IMP_SOLA As String
        Get
            Return EE_CF_IMP_SOLA
        End Get
        Set(value As String)
            EE_CF_IMP_SOLA = value
        End Set
    End Property
    Public Property CF_IMP_NOM_PER As String
        Get
            Return EE_CF_IMP_NOM_PER
        End Get
        Set(value As String)
            EE_CF_IMP_NOM_PER = value
        End Set
    End Property
    Public Property CF_IMP_PARCIAL As String
        Get
            Return EE_CF_IMP_PARCIAL
        End Get
        Set(value As String)
            EE_CF_IMP_PARCIAL = value
        End Set
    End Property
    Public Property CF_IMP_POSX As Long
        Get
            Return EE_CF_IMP_POSX
        End Get
        Set(value As Long)
            EE_CF_IMP_POSX = value
        End Set
    End Property
    Public Property CF_IMP_POSY As Long
        Get
            Return EE_CF_IMP_POSY
        End Get
        Set(value As Long)
            EE_CF_IMP_POSY = value
        End Set
    End Property
    Public Property CF_IMP_LETRA As String
        Get
            Return EE_CF_IMP_LETRA
        End Get
        Set(value As String)
            EE_CF_IMP_LETRA = value
        End Set
    End Property
    Public Property CF_IMP_TAMANO As Integer
        Get
            Return EE_CF_IMP_TAMANO
        End Get
        Set(value As Integer)
            EE_CF_IMP_TAMANO = value
        End Set
    End Property
    Public Property SECC_DESC As String
        Get
            Return EE_SECC_DESC
        End Get
        Set(value As String)
            EE_SECC_DESC = value
        End Set
    End Property
    Public Property ESTADO_WEB_DERIVADO As Integer
        Get
            Return EE_ESTADO_WEB_DERIVADO
        End Get
        Set(value As Integer)
            EE_ESTADO_WEB_DERIVADO = value
        End Set
    End Property
    Public Property ID_CODIGO_FONASA As Integer
        Get
            Return EE_ID_CODIGO_FONASA
        End Get
        Set(value As Integer)
            EE_ID_CODIGO_FONASA = value
        End Set
    End Property

    Public Property ATE_DET_REV_ID_ESTADO As Integer
        Get
            Return EE_ATE_DET_REV_ID_ESTADO
        End Get
        Set(value As Integer)
            EE_ATE_DET_REV_ID_ESTADO = value
        End Set
    End Property
End Class