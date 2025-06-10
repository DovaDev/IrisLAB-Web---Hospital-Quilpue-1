Public Class E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_R_2
    Dim EE_ID_T_MUESTRA As Integer
    Dim EE_ATE_NUM As Integer
    Dim EE_T_MUESTRA_DESC As String
    Dim EE_CB_DESC As String
    Dim EE_IDTM As Integer
    Dim EE_ID_ATENCION As Integer
    Dim EE_GMUE_DESC As String
    Dim EE_ATE_FECHA As Date
    Dim EE_ATE_NUM_INTERNO As String
    Dim EE_ATE_EST_RECEP As String
    Dim EE_EST_DESCRIPCION As String
    Dim EE_CF_DESC As String
    Dim EE_PAC_NOMBRE As String
    Dim EE_PAC_APELLIDO As String
    Dim EE_PAC_RUT As String
    Dim EE_PROC_DESC As String
    Dim EE_ID_PACIENTE As Integer
    Dim EE_ATE_AÑO As String
    Dim EE_ID_SEXO As Integer
    Dim EE_ATE_EST_RECHAZO As String
    Dim EE_ATE_EST_DERIVA As String
    Dim EE_ID_CODIGO_FONASA As Integer
    Dim EE_ATE_DET_V_ID_ESTADO As Integer
    Dim EE_ATE_DET_REV_ID_ESTADO As Integer
    Dim EE_Expr1 As String
    Dim EE_Expr2 As String
    Dim EE_SEXO_DESC As String
    Dim EE_PAC_FNAC As Date
    Dim EE_ATE_DNI As String
    Dim EE_DOC_NOMBRE As String
    Dim EE_DOC_APELLIDO As String
    Dim EE_ID_PROCEDENCIA As Integer
    Dim EE_NAC_DESC As String
    Dim EE_PROGRA_DESC As String
    Dim EE_SECTOR_DESC As String
    Dim EE_NAte As Integer
    Dim EE_NExa As Integer
    Dim EE_recSi As Integer
    Dim EE_recNo As Integer
    Dim EE_valiSi As Integer
    Dim EE_valiNo As Integer
    Dim EE_total As Integer
    Dim EE_rechSi As Integer
    Dim EE_rechNo As Integer

    Public Property rechNo() As Integer
        Get
            Return EE_rechNo
        End Get
        Set(ByVal value As Integer)
            EE_rechNo = value
        End Set
    End Property
    Public Property rechSi() As Integer
        Get
            Return EE_rechSi
        End Get
        Set(ByVal value As Integer)
            EE_rechSi = value
        End Set
    End Property
    Public Property total() As Integer
        Get
            Return EE_total
        End Get
        Set(ByVal value As Integer)
            EE_total = value
        End Set
    End Property
    Public Property valiNo() As Integer
        Get
            Return EE_valiNo
        End Get
        Set(ByVal value As Integer)
            EE_valiNo = value
        End Set
    End Property
    Public Property valiSi() As Integer
        Get
            Return EE_valiSi
        End Get
        Set(ByVal value As Integer)
            EE_valiSi = value
        End Set
    End Property
    Public Property recNo() As Integer
        Get
            Return EE_recNo
        End Get
        Set(ByVal value As Integer)
            EE_recNo = value
        End Set
    End Property
    Public Property recSi() As Integer
        Get
            Return EE_recSi
        End Get
        Set(ByVal value As Integer)
            EE_recSi = value
        End Set
    End Property
    Public Property NExa() As Integer
        Get
            Return EE_NExa
        End Get
        Set(ByVal value As Integer)
            EE_NExa = value
        End Set
    End Property
    Public Property NAte() As Integer
        Get
            Return EE_NAte
        End Get
        Set(ByVal value As Integer)
            EE_NAte = value
        End Set
    End Property
    Public Property ID_T_MUESTRA As Integer
        Get
            Return EE_ID_T_MUESTRA
        End Get
        Set(value As Integer)
            EE_ID_T_MUESTRA = value
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

    Public Property T_MUESTRA_DESC As String
        Get
            Return EE_T_MUESTRA_DESC
        End Get
        Set(value As String)
            EE_T_MUESTRA_DESC = value
        End Set
    End Property

    Public Property CB_DESC As String
        Get
            Return EE_CB_DESC
        End Get
        Set(value As String)
            EE_CB_DESC = value
        End Set
    End Property

    Public Property IDTM As Integer
        Get
            Return EE_IDTM
        End Get
        Set(value As Integer)
            EE_IDTM = value
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

    Public Property GMUE_DESC As String
        Get
            Return EE_GMUE_DESC
        End Get
        Set(value As String)
            EE_GMUE_DESC = value
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

    Public Property ATE_NUM_INTERNO As String
        Get
            Return EE_ATE_NUM_INTERNO
        End Get
        Set(value As String)
            EE_ATE_NUM_INTERNO = value
        End Set
    End Property

    Public Property ATE_EST_RECEP As String
        Get
            Return EE_ATE_EST_RECEP
        End Get
        Set(value As String)
            EE_ATE_EST_RECEP = value
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

    Public Property CF_DESC As String
        Get
            Return EE_CF_DESC
        End Get
        Set(value As String)
            EE_CF_DESC = value
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

    Public Property PAC_RUT As String
        Get
            Return EE_PAC_RUT
        End Get
        Set(value As String)
            EE_PAC_RUT = value
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

    Public Property ID_PACIENTE As Integer
        Get
            Return EE_ID_PACIENTE
        End Get
        Set(value As Integer)
            EE_ID_PACIENTE = value
        End Set
    End Property

    Public Property ATE_AÑO As String
        Get
            Return EE_ATE_AÑO
        End Get
        Set(value As String)
            EE_ATE_AÑO = value
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

    Public Property ATE_EST_RECHAZO As String
        Get
            Return EE_ATE_EST_RECHAZO
        End Get
        Set(value As String)
            EE_ATE_EST_RECHAZO = value
        End Set
    End Property

    Public Property ATE_EST_DERIVA As String
        Get
            Return EE_ATE_EST_DERIVA
        End Get
        Set(value As String)
            EE_ATE_EST_DERIVA = value
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

    Public Property ATE_DET_V_ID_ESTADO As Integer
        Get
            Return EE_ATE_DET_V_ID_ESTADO
        End Get
        Set(value As Integer)
            EE_ATE_DET_V_ID_ESTADO = value
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

    Public Property Expr1 As String
        Get
            Return EE_Expr1
        End Get
        Set(value As String)
            EE_Expr1 = value
        End Set
    End Property

    Public Property Expr2 As String
        Get
            Return EE_Expr2
        End Get
        Set(value As String)
            EE_Expr2 = value
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

    Public Property PAC_FNAC As Date
        Get
            Return EE_PAC_FNAC
        End Get
        Set(value As Date)
            EE_PAC_FNAC = value
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

    Public Property ID_PROCEDENCIA As Integer
        Get
            Return EE_ID_PROCEDENCIA
        End Get
        Set(value As Integer)
            EE_ID_PROCEDENCIA = value
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

    Public Property PROGRA_DESC As String
        Get
            Return EE_PROGRA_DESC
        End Get
        Set(value As String)
            EE_PROGRA_DESC = value
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
End Class
