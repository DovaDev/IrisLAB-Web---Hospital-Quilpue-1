Public Class E_IRIS_WEBF_BUSCA_EST_EXAMENES_RESULTADOS2
    Private E_ID_ATENCION As Long
    Private E_ATE_NUM As Long
    Private E_ATE_FECHA As Date
    Private E_PAC_NOMBRE As String
    Private E_PAC_APELLIDO As String
    Private E_CF_DESC As String
    Private E_CF_COD As String
    Private E_ATE_AÑO As Long
    Private E_PRU_DESC As String
    Private E_ATE_RESULTADO As String
    Private E_ATE_RESULTADO_NUM As Long
    Private E_ID_CODIGO_FONASA As Long
    Private E_ID_PRUEBA As Long
    Private E_PAC_FNAC As Date
    Private E_UM_DESC As String
    Private E_ID_TP_RESULTADO As Long
    Private E_TP_RESUL_DESC As String
    Private E_TP_RESUL_COD As String
    Private E_ID_U_MEDIDA As Long
    Private E_PREVE_DESC As String
    Private E_PROC_DESC As String
    Private E_PROGRA_DESC As String
    Private E_PAC_RUT As String
    Private E_PRU_ORDEN As Long
    Private E_SUBP_DESC As String
    Private E_ATE_OMI As String
    Private E_SEXO_DESC As String

    Public Property SEXO_DESC As String
        Get
            Return E_SEXO_DESC
        End Get
        Set(value As String)
            E_SEXO_DESC = value
        End Set
    End Property
    Public Property ATE_OMI As String
        Get
            Return E_ATE_OMI
        End Get
        Set(value As String)
            E_ATE_OMI = value
        End Set
    End Property
    Public Property SUBP_DESC As String
        Get
            Return E_SUBP_DESC
        End Get
        Set(value As String)
            E_SUBP_DESC = value
        End Set
    End Property
    Public Property PRU_ORDEN As Long
        Get
            Return E_PRU_ORDEN
        End Get
        Set(value As Long)
            E_PRU_ORDEN = value
        End Set
    End Property
    Public Property PAC_RUT As String
        Get
            Return E_PAC_RUT
        End Get
        Set(value As String)
            E_PAC_RUT = value
        End Set
    End Property
    Public Property PROGRA_DESC As String
        Get
            Return E_PROGRA_DESC
        End Get
        Set(value As String)
            E_PROGRA_DESC = value
        End Set
    End Property
    Public Property PROC_DESC As String
        Get
            Return E_PROC_DESC
        End Get
        Set(value As String)
            E_PROC_DESC = value
        End Set
    End Property
    Public Property PREVE_DESC As String
        Get
            Return E_PREVE_DESC
        End Get
        Set(value As String)
            E_PREVE_DESC = value
        End Set
    End Property
    Public Property ID_U_MEDIDA As Long
        Get
            Return E_ID_U_MEDIDA
        End Get
        Set(value As Long)
            E_ID_U_MEDIDA = value
        End Set
    End Property
    Public Property TP_RESUL_COD As String
        Get
            Return E_TP_RESUL_COD
        End Get
        Set(value As String)
            E_TP_RESUL_COD = value
        End Set
    End Property
    Public Property TP_RESUL_DESC As String
        Get
            Return E_TP_RESUL_DESC
        End Get
        Set(value As String)
            E_TP_RESUL_DESC = value
        End Set
    End Property
    Public Property ID_TP_RESULTADO As Long
        Get
            Return E_ID_TP_RESULTADO
        End Get
        Set(value As Long)
            E_ID_TP_RESULTADO = value
        End Set
    End Property
    Public Property UM_DESC As String
        Get
            Return E_UM_DESC
        End Get
        Set(value As String)
            E_UM_DESC = value
        End Set
    End Property
    Public Property PAC_FNAC As Date
        Get
            Return E_PAC_FNAC
        End Get
        Set(value As Date)
            E_PAC_FNAC = value
        End Set
    End Property
    Public Property ID_PRUEBA As Long
        Get
            Return E_ID_PRUEBA
        End Get
        Set(value As Long)
            E_ID_PRUEBA = value
        End Set
    End Property
    Public Property ID_CODIGO_FONASA As Long
        Get
            Return E_ID_CODIGO_FONASA
        End Get
        Set(value As Long)
            E_ID_CODIGO_FONASA = value
        End Set
    End Property
    Public Property ATE_RESULTADO_NUM As Long
        Get
            Return E_ATE_RESULTADO_NUM
        End Get
        Set(value As Long)
            E_ATE_RESULTADO_NUM = value
        End Set
    End Property
    Public Property ATE_RESULTADO As String
        Get
            Return E_ATE_RESULTADO
        End Get
        Set(value As String)
            E_ATE_RESULTADO = value
        End Set
    End Property
    Public Property PRU_DESC As String
        Get
            Return E_PRU_DESC
        End Get
        Set(value As String)
            E_PRU_DESC = value
        End Set
    End Property
    Public Property ATE_AÑO As Long
        Get
            Return E_ATE_AÑO
        End Get
        Set(value As Long)
            E_ATE_AÑO = value
        End Set
    End Property
    Public Property CF_COD As String
        Get
            Return E_CF_COD
        End Get
        Set(value As String)
            E_CF_COD = value
        End Set
    End Property
    Public Property CF_DESC As String
        Get
            Return E_CF_DESC
        End Get
        Set(value As String)
            E_CF_DESC = value
        End Set
    End Property
    Public Property PAC_APELLIDO As String
        Get
            Return E_PAC_APELLIDO
        End Get
        Set(value As String)
            E_PAC_APELLIDO = value
        End Set
    End Property
    Public Property PAC_NOMBRE As String
        Get
            Return E_PAC_NOMBRE
        End Get
        Set(value As String)
            E_PAC_NOMBRE = value
        End Set
    End Property
    Public Property ATE_FECHA As Date
        Get
            Return E_ATE_FECHA
        End Get
        Set(value As Date)
            E_ATE_FECHA = value
        End Set
    End Property
    Public Property ATE_NUM As Long
        Get
            Return E_ATE_NUM
        End Get
        Set(value As Long)
            E_ATE_NUM = value
        End Set
    End Property
    Public Property ID_ATENCION As Long
        Get
            Return E_ID_ATENCION
        End Get
        Set(value As Long)
            E_ID_ATENCION = value
        End Set
    End Property
End Class
