Public Class E_Res_Peñalolen_Sum_JSON
    Dim E_ID_ATENCION As Long
    Dim EE_ATE_NUM As Long
    Dim EE_PAC_NOMBRE As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_CF_DESC As String
    Dim EE_TP_RESUL_COD As String
    Dim EE_PREVE_DESC As String
    Dim EE_PROC_DESC As String
    Dim EE_PROGRA_DESC As String
    Dim EE_PAC_RUT As String
    Dim EE_SUBP_DESC As String
    Dim EE_ATE_OMI As String
    Dim EE_ATE_FECHA As Date
    Dim EE_ATE_RESULTADO As String
    Dim EE_ATE_RESULTADO_NUM As Double
    Dim EE_ID_U_MEDIDA As Long
    Dim EE_UM_DESC As String
    Dim EE_ID_PRUEBA As Long
    Dim EE_ID_SEXO As Integer
    Dim EE_PAC_FNAC As Date
    Public Property ID_ATENCION As Long
        Get
            Return E_ID_ATENCION
        End Get
        Set(value As Long)
            E_ID_ATENCION = value
        End Set
    End Property
    Public Property ATE_NUM As Long
        Get
            Return EE_ATE_NUM
        End Get
        Set(value As Long)
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
    Public Property CF_DESC As String
        Get
            Return EE_CF_DESC
        End Get
        Set(value As String)
            EE_CF_DESC = value
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
    Public Property PROGRA_DESC As String
        Get
            Return EE_PROGRA_DESC
        End Get
        Set(value As String)
            EE_PROGRA_DESC = value
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
    Public Property SUBP_DESC As String
        Get
            Return EE_SUBP_DESC
        End Get
        Set(value As String)
            EE_SUBP_DESC = value
        End Set
    End Property
    Public Property ATE_OMI As String
        Get
            Return EE_ATE_OMI
        End Get
        Set(value As String)
            EE_ATE_OMI = value
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
    Public Property ATE_RESULTADO As String
        Get
            Return EE_ATE_RESULTADO
        End Get
        Set(value As String)
            EE_ATE_RESULTADO = value
        End Set
    End Property
    Public Property ATE_RESULTADO_NUM As Double
        Get
            Return EE_ATE_RESULTADO_NUM
        End Get
        Set(value As Double)
            EE_ATE_RESULTADO_NUM = value
        End Set
    End Property
    Public Property ID_U_MEDIDA As Long
        Get
            Return EE_ID_U_MEDIDA
        End Get
        Set(value As Long)
            EE_ID_U_MEDIDA = value
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
    Public Property ID_PRUEBA As Long
        Get
            Return EE_ID_PRUEBA
        End Get
        Set(value As Long)
            EE_ID_PRUEBA = value
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
    Public Property PAC_FNAC As Date
        Get
            Return EE_PAC_FNAC
        End Get
        Set(value As Date)
            EE_PAC_FNAC = value
        End Set
    End Property
End Class
