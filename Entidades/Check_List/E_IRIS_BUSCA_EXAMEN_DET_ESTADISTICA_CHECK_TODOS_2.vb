Public Class E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
    Dim EE_ID_ATENCION As Integer
    Dim EE_ATE_NUM As Integer
    Dim EE_ATE_FECHA As String
    Dim EE_PAC_NOMBRE As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_CF_DESC As String
    Dim EE_CF_COD As String
    Dim EE_ATE_AÑO As Integer
    Dim EE_PRU_DESC As String
    Dim EE_ATE_RESULTADO As String
    Dim EE_ATE_RESULTADO_NUM As String
    Dim EE_ID_CODIGO_FONASA As Integer
    Dim EE_ID_PRUEBA As Integer
    Dim EE_PAC_FNAC As String
    Dim EE_ID_SEXO As Integer
    Dim EE_UM_DESC As String
    Dim EE_ID_TP_RESULTADO As Integer
    Dim EE_TP_RESUL_DESC As String
    Dim EE_TP_RESUL_COD As String
    Dim EE_ID_U_MEDIDA As Integer
    Dim EE_PAC_RUT As String
    Dim EE_ATE_EST_VALIDA As String
    Dim EE_ATE_RR_DESDE As String
    Dim EE_ATE_RR_HASTA As String
    Dim EE_ATE_R_DESDE As String
    Dim EE_ATE_R_HASTA As String
    Dim EE_PRU_DECIMAL As Double
    Dim EE_PROC_DESC As String
    Dim EE_ATE_NUM_INTERNO As String
    Dim EE_ATE_DNI As String
    Dim EE_DOC_NOMBRE As String
    Dim EE_DOC_APELLIDO As String
    Dim EE_id_proce As String
    Dim EE_NAC_DESC As String
    Dim EE_PROGRA_DESC As String
    Dim EE_SECTOR_DESC As String
    Dim EE_ATE_FUR As String
    Dim EE_ID_ATE_RES As Integer
    Dim EE_ATE_REVISION_1 As Integer
    Dim EE_ID_PER As Integer
    Dim EE_ATE_SUR_VIH As String
    Dim EE_NEW_VIH As String
    Dim EE_SEXO_DESC As String
    Dim EE_ATE_EST_RECHAZO As Integer
    Public Property ATE_EST_RECHAZO As Integer
        Get
            Return EE_ATE_EST_RECHAZO
        End Get
        Set(value As Integer)
            EE_ATE_EST_RECHAZO = value
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
    Public Property NEW_VIH As String
        Get
            Return EE_NEW_VIH
        End Get
        Set(value As String)
            EE_NEW_VIH = value
        End Set
    End Property
    Public Property ATE_SUR_VIH As String
        Get
            Return EE_ATE_SUR_VIH
        End Get
        Set(value As String)
            EE_ATE_SUR_VIH = value
        End Set
    End Property
    Public Property ID_PER As Integer
        Get
            Return EE_ID_PER
        End Get
        Set(value As Integer)
            EE_ID_PER = value
        End Set
    End Property
    Public Property ATE_REVISION_1 As Integer
        Get
            Return EE_ATE_REVISION_1
        End Get
        Set(value As Integer)
            EE_ATE_REVISION_1 = value
        End Set
    End Property
    Public Property ID_ATE_RES As Integer
        Get
            Return EE_ID_ATE_RES
        End Get
        Set(value As Integer)
            EE_ID_ATE_RES = value
        End Set
    End Property
    Public Property ATE_FUR As String
        Get
            Return EE_ATE_FUR
        End Get
        Set(value As String)
            EE_ATE_FUR = value
        End Set
    End Property
    Public Property SECTOR_DESC As String
        Get
            Return EE_SECTOR_DESC
        End Get
        Set(value As String)
            EE_SECTOR_DESC = value
        End Set
    End Property
    Public Property PROGRA_DESC As String
        Get
            Return EE_PROGRA_DESC
        End Get
        Set(value As String)
            EE_PROGRA_DESC = value
        End Set
    End Property
    Public Property NAC_DESC As String
        Get
            Return EE_NAC_DESC
        End Get
        Set(value As String)
            EE_NAC_DESC = value
        End Set
    End Property
    Public Property id_proce As String
        Get
            Return EE_id_proce
        End Get
        Set(value As String)
            EE_id_proce = value
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
    Public Property ATE_DNI As String
        Get
            Return EE_ATE_DNI
        End Get
        Set(value As String)
            EE_ATE_DNI = value
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
    Public Property PROC_DESC As String
        Get
            Return EE_PROC_DESC
        End Get
        Set(value As String)
            EE_PROC_DESC = value
        End Set
    End Property
    Public Property PRU_DECIMAL As Double
        Get
            Return EE_PRU_DECIMAL
        End Get
        Set(value As Double)
            EE_PRU_DECIMAL = value
        End Set
    End Property
    Public Property ATE_R_HASTA As String
        Get
            Return EE_ATE_R_HASTA
        End Get
        Set(value As String)
            EE_ATE_R_HASTA = value
        End Set
    End Property
    Public Property ATE_R_DESDE As String
        Get
            Return EE_ATE_R_DESDE
        End Get
        Set(value As String)
            EE_ATE_R_DESDE = value
        End Set
    End Property
    Public Property ATE_RR_HASTA As String
        Get
            Return EE_ATE_RR_HASTA
        End Get
        Set(value As String)
            EE_ATE_RR_HASTA = value
        End Set
    End Property
    Public Property ATE_RR_DESDE As String
        Get
            Return EE_ATE_RR_DESDE
        End Get
        Set(value As String)
            EE_ATE_RR_DESDE = value
        End Set
    End Property
    Public Property ATE_EST_VALIDA As String
        Get
            Return EE_ATE_EST_VALIDA
        End Get
        Set(value As String)
            EE_ATE_EST_VALIDA = value
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
    Public Property ATE_FECHA As String
        Get
            Return EE_ATE_FECHA
        End Get
        Set(value As String)
            EE_ATE_FECHA = value
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
    Public Property CF_DESC As String
        Get
            Return EE_CF_DESC
        End Get
        Set(value As String)
            EE_CF_DESC = value
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
    Public Property ATE_AÑO As Integer
        Get
            Return EE_ATE_AÑO
        End Get
        Set(value As Integer)
            EE_ATE_AÑO = value
        End Set
    End Property
    Public Property PRU_DESC As String
        Get
            Return EE_PRU_DESC
        End Get
        Set(value As String)
            EE_PRU_DESC = value
        End Set
    End Property
    Public Property ATE_RESULTADO As String
        Get
            Return EE_ATE_RESULTADO
        End Get
        Set(value As String)
            EE_ATE_RESULTADO = value
        End Set
    End Property
    Public Property ATE_RESULTADO_NUM As String
        Get
            Return EE_ATE_RESULTADO_NUM
        End Get
        Set(value As String)
            EE_ATE_RESULTADO_NUM = value
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
    Public Property ID_PRUEBA As Integer
        Get
            Return EE_ID_PRUEBA
        End Get
        Set(value As Integer)
            EE_ID_PRUEBA = value
        End Set
    End Property
    Public Property PAC_FNAC As String
        Get
            Return EE_PAC_FNAC
        End Get
        Set(value As String)
            EE_PAC_FNAC = value
        End Set
    End Property
    Public Property ID_SEXO As Integer
        Get
            Return EE_ID_SEXO
        End Get
        Set(value As Integer)
            EE_ID_SEXO = value
        End Set
    End Property
    Public Property UM_DESC As String
        Get
            Return EE_UM_DESC
        End Get
        Set(value As String)
            EE_UM_DESC = value
        End Set
    End Property
    Public Property ID_TP_RESULTADO As Integer
        Get
            Return EE_ID_TP_RESULTADO
        End Get
        Set(value As Integer)
            EE_ID_TP_RESULTADO = value
        End Set
    End Property
    Public Property TP_RESUL_DESC As String
        Get
            Return EE_TP_RESUL_DESC
        End Get
        Set(value As String)
            EE_TP_RESUL_DESC = value
        End Set
    End Property
    Public Property TP_RESUL_COD As String
        Get
            Return EE_TP_RESUL_COD
        End Get
        Set(value As String)
            EE_TP_RESUL_COD = value
        End Set
    End Property
    Public Property ID_U_MEDIDA As Integer
        Get
            Return EE_ID_U_MEDIDA
        End Get
        Set(value As Integer)
            EE_ID_U_MEDIDA = value
        End Set
    End Property
End Class
