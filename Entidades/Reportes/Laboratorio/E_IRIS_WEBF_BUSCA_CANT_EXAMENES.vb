Public Class E_IRIS_WEBF_BUSCA_CANT_EXAMENES

    Private E_CF_COD_IRIS As String
    Private E_ID_CODIGO_FONASA As Integer
    Private E_CF_DESC_HOSP As String
    Private E_ID_PER As Integer
    Private E_PER_DESC As String
    Private E_CANTIDAD As Integer
    Private E_EXISTE_CF As Boolean
    Private E_ID_RLS_LS As Integer
    Private E_RLS_LS_DESC As String
    Private E_SECC_DESC As String
    Private E_ID_SECCION As Integer
    Private E_ID_PRUEBA As Integer
    Private E_PRU_DESC As String

    ' ATENCIÓN ABIERTA
    Private E_CAE As Integer
    Private E_USM_HDIURNO As Integer
    Private E_PERSONAL As Integer
    Private E_TOTAL_ABIERTA As Integer

    ' ATENCIÓN CERRADA
    Private E_MQ1 As Integer
    Private E_MQ2 As Integer
    Private E_MQ3 As Integer
    Private E_UAPQ_PABELLON As Integer
    Private E_PEDIATRIA As Integer
    Private E_NEONATOLOGIA As Integer
    Private E_UPC As Integer
    Private E_UCI_A As Integer
    Private E_UTI As Integer
    Private E_MATERNIDAD As Integer
    Private E_CMA As Integer
    Private E_HOSP_DOCIMI As Integer
    Private E_UEA_HOSP As Integer
    Private E_TOTAL_CERRADA As Integer

    ' ATENCIÓN UEA
    Private E_UEA As Integer
    Private E_UEI As Integer
    Private E_SAUD As Integer
    Private E_TOTAL_UE As Integer

    ' ATENCIÓN UEGO
    Private E_UEGO As Integer

    ' ATENCIÓN UNIDAD DE APOYO
    Private E_ANATOMIA_PATO As Integer
    Private E_IMAGENOLOGIA As Integer
    Private E_TOTAL_UNIDAD_APOYO As Integer

    ' ATENCIÓN EXTRAHOSPITALARIO
    Private E_CESFAM_IVAN_MAN As Integer
    Private E_CESFAM_AV_AC As Integer
    Private E_CESFAM_QUILPUE As Integer
    Private E_CESFAM_BELLOTO As Integer
    Private E_CONS_POMPEYA As Integer
    Private E_CECOSF_RETIRO As Integer
    Private E_CONS_BELLOTO As Integer
    Private E_CESFAM_VILLA_AL As Integer
    Private E_CESFAM_AMERICAS As Integer
    Private E_CONS_EDUARDO_FREI As Integer
    Private E_CESFAM_JUAN_BT As Integer
    Private E_CONS_AGUILAS As Integer
    Private E_SAPU_FREI As Integer
    Private E_CESFAM_LIMACHE As Integer
    Private E_CESFAM_OLMUE As Integer
    Private E_APS_CABILDO As Integer
    Private E_APS_HIJUELAS As Integer
    Private E_APS_CALERA As Integer
    Private E_APS_LIGUA As Integer
    Private E_APS_NOGALES As Integer
    Private E_APS_PETORCA As Integer
    Private E_HOSP_LIMACHE As Integer
    Private E_HOSP_GERIATRICO_LMCHE As Integer
    Private E_HOSP_MODULAR_LMCHE As Integer
    Private E_HOSP_PENBLANCA As Integer
    Private E_HOSP_GUSTAVO_FRICKE As Integer
    Private E_HOSP_CALERA As Integer
    Private E_HOSP_PETORCA As Integer
    Private E_HOSP_QUILLOTA As Integer
    Private E_HOSP_CABILDO As Integer
    Private E_HOSP_LIGUA As Integer
    Private E_HOSP_QUINTERO As Integer
    Private E_OTROS As Integer
    Private E_TOTAL_EXTRA As Integer
    ' PARTE NUEVA 
    Private E_ID_SECC_REM As Integer
    Private E_SECC_REM_DESC As String
    Private E_ID_AREA_REM As Integer
    Private E_AREA_DESC As String


    ' PARTE AUN MAS NUEVA
    Private E_ID_FONASA_REM_HOSP As Integer
    Public Property CF_COD_IRIS As String
        Get
            Return E_CF_COD_IRIS
        End Get
        Set(value As String)
            E_CF_COD_IRIS = value
        End Set
    End Property

    Public Property ID_CODIGO_FONASA As Integer
        Get
            Return E_ID_CODIGO_FONASA
        End Get
        Set(value As Integer)
            E_ID_CODIGO_FONASA = value
        End Set
    End Property

    Public Property CF_DESC_HOSP As String
        Get
            Return E_CF_DESC_HOSP
        End Get
        Set(value As String)
            E_CF_DESC_HOSP = value
        End Set
    End Property

    Public Property ID_PER As Integer
        Get
            Return E_ID_PER
        End Get
        Set(value As Integer)
            E_ID_PER = value
        End Set
    End Property

    Public Property PER_DESC As String
        Get
            Return E_PER_DESC
        End Get
        Set(value As String)
            E_PER_DESC = value
        End Set
    End Property

    Public Property CANTIDAD As Integer
        Get
            Return E_CANTIDAD
        End Get
        Set(value As Integer)
            E_CANTIDAD = value
        End Set
    End Property

    Public Property EXISTE_CF As Boolean
        Get
            Return E_EXISTE_CF
        End Get
        Set(value As Boolean)
            E_EXISTE_CF = value
        End Set
    End Property

    Public Property ID_RLS_LS As Integer
        Get
            Return E_ID_RLS_LS
        End Get
        Set(value As Integer)
            E_ID_RLS_LS = value
        End Set
    End Property

    Public Property RLS_LS_DESC As String
        Get
            Return E_RLS_LS_DESC
        End Get
        Set(value As String)
            E_RLS_LS_DESC = value
        End Set
    End Property

    Public Property SECC_DESC As String
        Get
            Return E_SECC_DESC
        End Get
        Set(value As String)
            E_SECC_DESC = value
        End Set
    End Property

    Public Property ID_SECCION As Integer
        Get
            Return E_ID_SECCION
        End Get
        Set(value As Integer)
            E_ID_SECCION = value
        End Set
    End Property

    Public Property ID_PRUEBA As Integer
        Get
            Return E_ID_PRUEBA
        End Get
        Set(value As Integer)
            E_ID_PRUEBA = value
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

    ' ATENCIÓN ABIERTA
    Public Property CAE As Integer
        Get
            Return E_CAE
        End Get
        Set(value As Integer)
            E_CAE = value
        End Set
    End Property

    Public Property USM_HDIURNO As Integer
        Get
            Return E_USM_HDIURNO
        End Get
        Set(value As Integer)
            E_USM_HDIURNO = value
        End Set
    End Property

    Public Property PERSONAL As Integer
        Get
            Return E_PERSONAL
        End Get
        Set(value As Integer)
            E_PERSONAL = value
        End Set
    End Property

    Public Property TOTAL_ABIERTA As Integer
        Get
            Return E_TOTAL_ABIERTA
        End Get
        Set(value As Integer)
            E_TOTAL_ABIERTA = value
        End Set
    End Property

    Public Property MQ1 As Integer
        Get
            Return E_MQ1
        End Get
        Set(value As Integer)
            E_MQ1 = value
        End Set
    End Property

    Public Property MQ2 As Integer
        Get
            Return E_MQ2
        End Get
        Set(value As Integer)
            E_MQ2 = value
        End Set
    End Property

    Public Property MQ3 As Integer
        Get
            Return E_MQ3
        End Get
        Set(value As Integer)
            E_MQ3 = value
        End Set
    End Property

    Public Property UAPQ_PABELLON As Integer
        Get
            Return E_UAPQ_PABELLON
        End Get
        Set(value As Integer)
            E_UAPQ_PABELLON = value
        End Set
    End Property

    Public Property PEDIATRIA As Integer
        Get
            Return E_PEDIATRIA
        End Get
        Set(value As Integer)
            E_PEDIATRIA = value
        End Set
    End Property

    Public Property NEONATOLOGIA As Integer
        Get
            Return E_NEONATOLOGIA
        End Get
        Set(value As Integer)
            E_NEONATOLOGIA = value
        End Set
    End Property

    Public Property UPC As Integer
        Get
            Return E_UPC
        End Get
        Set(value As Integer)
            E_UPC = value
        End Set
    End Property

    Public Property UCI_A As Integer
        Get
            Return E_UCI_A
        End Get
        Set(value As Integer)
            E_UCI_A = value
        End Set
    End Property

    Public Property UTI As Integer
        Get
            Return E_UTI
        End Get
        Set(value As Integer)
            E_UTI = value
        End Set
    End Property

    Public Property MATERNIDAD As Integer
        Get
            Return E_MATERNIDAD
        End Get
        Set(value As Integer)
            E_MATERNIDAD = value
        End Set
    End Property

    Public Property CMA As Integer
        Get
            Return E_CMA
        End Get
        Set(value As Integer)
            E_CMA = value
        End Set
    End Property

    Public Property HOSP_DOCIMI As Integer
        Get
            Return E_HOSP_DOCIMI
        End Get
        Set(value As Integer)
            E_HOSP_DOCIMI = value
        End Set
    End Property

    Public Property UEA_HOSP As Integer
        Get
            Return E_UEA_HOSP
        End Get
        Set(value As Integer)
            E_UEA_HOSP = value
        End Set
    End Property

    Public Property TOTAL_CERRADA As Integer
        Get
            Return E_TOTAL_CERRADA
        End Get
        Set(value As Integer)
            E_TOTAL_CERRADA = value
        End Set
    End Property

    ' ATENCIÓN UE
    Public Property UEA As Integer
        Get
            Return E_UEA
        End Get
        Set(value As Integer)
            E_UEA = value
        End Set
    End Property

    Public Property UEI As Integer
        Get
            Return E_UEI
        End Get
        Set(value As Integer)
            E_UEI = value
        End Set
    End Property

    Public Property SAUD As Integer
        Get
            Return E_SAUD
        End Get
        Set(value As Integer)
            E_SAUD = value
        End Set
    End Property

    Public Property TOTAL_UE As Integer
        Get
            Return E_TOTAL_UE
        End Get
        Set(value As Integer)
            E_TOTAL_UE = value
        End Set
    End Property

    ' UEGO
    Public Property UEGO As Integer
        Get
            Return E_UEGO
        End Get
        Set(value As Integer)
            E_UEGO = value
        End Set
    End Property

    ' UNIDAD DE APOYO

    Public Property ANATOMIA_PATO As Integer
        Get
            Return E_ANATOMIA_PATO
        End Get
        Set(value As Integer)
            E_ANATOMIA_PATO = value
        End Set
    End Property

    Public Property IMAGENOLOGIA As Integer
        Get
            Return E_IMAGENOLOGIA
        End Get
        Set(value As Integer)
            E_IMAGENOLOGIA = value
        End Set
    End Property

    Public Property TOTAL_UNIDAD_APOYO As Integer
        Get
            Return E_TOTAL_UNIDAD_APOYO
        End Get
        Set(value As Integer)
            E_TOTAL_UNIDAD_APOYO = value
        End Set
    End Property

    ' ATENCIÓN EXTRAHOSPITALARIO

    Public Property CESFAM_IVAN_MAN As Integer
        Get
            Return E_CESFAM_IVAN_MAN
        End Get
        Set(value As Integer)
            E_CESFAM_IVAN_MAN = value
        End Set
    End Property

    Public Property CESFAM_AV_AC As Integer
        Get
            Return E_CESFAM_AV_AC
        End Get
        Set(value As Integer)
            E_CESFAM_AV_AC = value
        End Set
    End Property

    Public Property CESFAM_QUILPUE As Integer
        Get
            Return E_CESFAM_QUILPUE
        End Get
        Set(value As Integer)
            E_CESFAM_QUILPUE = value
        End Set
    End Property

    Public Property CESFAM_BELLOTO As Integer
        Get
            Return E_CESFAM_BELLOTO
        End Get
        Set(value As Integer)
            E_CESFAM_BELLOTO = value
        End Set
    End Property

    Public Property CONS_POMPEYA As Integer
        Get
            Return E_CONS_POMPEYA
        End Get
        Set(value As Integer)
            E_CONS_POMPEYA = value
        End Set
    End Property

    Public Property CECOSF_RETIRO As Integer
        Get
            Return E_CECOSF_RETIRO
        End Get
        Set(value As Integer)
            E_CECOSF_RETIRO = value
        End Set
    End Property

    Public Property CONS_BELLOTO As Integer
        Get
            Return E_CONS_BELLOTO
        End Get
        Set(value As Integer)
            E_CONS_BELLOTO = value
        End Set
    End Property

    Public Property CESFAM_VILLA_AL As Integer
        Get
            Return E_CESFAM_VILLA_AL
        End Get
        Set(value As Integer)
            E_CESFAM_VILLA_AL = value
        End Set
    End Property

    Public Property CESFAM_AMERICAS As Integer
        Get
            Return E_CESFAM_AMERICAS
        End Get
        Set(value As Integer)
            E_CESFAM_AMERICAS = value
        End Set
    End Property

    Public Property CONS_EDUARDO_FREI As Integer
        Get
            Return E_CONS_EDUARDO_FREI
        End Get
        Set(value As Integer)
            E_CONS_EDUARDO_FREI = value
        End Set
    End Property

    Public Property CESFAM_JUAN_BT As Integer
        Get
            Return E_CESFAM_JUAN_BT
        End Get
        Set(value As Integer)
            E_CESFAM_JUAN_BT = value
        End Set
    End Property

    Public Property CONS_AGUILAS As Integer
        Get
            Return E_CONS_AGUILAS
        End Get
        Set(value As Integer)
            E_CONS_AGUILAS = value
        End Set
    End Property

    Public Property SAPU_FREI As Integer
        Get
            Return E_SAPU_FREI
        End Get
        Set(value As Integer)
            E_SAPU_FREI = value
        End Set
    End Property

    Public Property CESFAM_LIMACHE As Integer
        Get
            Return E_CESFAM_LIMACHE
        End Get
        Set(value As Integer)
            E_CESFAM_LIMACHE = value
        End Set
    End Property

    Public Property CESFAM_OLMUE As Integer
        Get
            Return E_CESFAM_OLMUE
        End Get
        Set(value As Integer)
            E_CESFAM_OLMUE = value
        End Set
    End Property

    Public Property APS_CABILDO As Integer
        Get
            Return E_APS_CABILDO
        End Get
        Set(value As Integer)
            E_APS_CABILDO = value
        End Set
    End Property

    Public Property APS_HIJUELAS As Integer
        Get
            Return E_APS_HIJUELAS
        End Get
        Set(value As Integer)
            E_APS_HIJUELAS = value
        End Set
    End Property

    Public Property APS_CALERA As Integer
        Get
            Return E_APS_CALERA
        End Get
        Set(value As Integer)
            E_APS_CALERA = value
        End Set
    End Property

    Public Property APS_LIGUA As Integer
        Get
            Return E_APS_LIGUA
        End Get
        Set(value As Integer)
            E_APS_LIGUA = value
        End Set
    End Property

    Public Property APS_NOGALES As Integer
        Get
            Return E_APS_NOGALES
        End Get
        Set(value As Integer)
            E_APS_NOGALES = value
        End Set
    End Property

    Public Property APS_PETORCA As Integer
        Get
            Return E_APS_PETORCA
        End Get
        Set(value As Integer)
            E_APS_PETORCA = value
        End Set
    End Property

    Public Property HOSP_LIMACHE As Integer
        Get
            Return E_HOSP_LIMACHE
        End Get
        Set(value As Integer)
            E_HOSP_LIMACHE = value
        End Set
    End Property

    Public Property HOSP_GERIATRICO_LMCHE As Integer
        Get
            Return E_HOSP_GERIATRICO_LMCHE
        End Get
        Set(value As Integer)
            E_HOSP_GERIATRICO_LMCHE = value
        End Set
    End Property

    Public Property HOSP_MODULAR_LMCHE As Integer
        Get
            Return E_HOSP_MODULAR_LMCHE
        End Get
        Set(value As Integer)
            E_HOSP_MODULAR_LMCHE = value
        End Set
    End Property

    Public Property HOSP_PENBLANCA As Integer
        Get
            Return E_HOSP_PENBLANCA
        End Get
        Set(value As Integer)
            E_HOSP_PENBLANCA = value
        End Set
    End Property

    Public Property HOSP_GUSTAVO_FRICKE As Integer
        Get
            Return E_HOSP_GUSTAVO_FRICKE
        End Get
        Set(value As Integer)
            E_HOSP_GUSTAVO_FRICKE = value
        End Set
    End Property

    Public Property HOSP_CALERA As Integer
        Get
            Return E_HOSP_CALERA
        End Get
        Set(value As Integer)
            E_HOSP_CALERA = value
        End Set
    End Property

    Public Property HOSP_PETORCA As Integer
        Get
            Return E_HOSP_PETORCA
        End Get
        Set(value As Integer)
            E_HOSP_PETORCA = value
        End Set
    End Property

    Public Property HOSP_QUILLOTA As Integer
        Get
            Return E_HOSP_QUILLOTA
        End Get
        Set(value As Integer)
            E_HOSP_QUILLOTA = value
        End Set
    End Property

    Public Property HOSP_CABILDO As Integer
        Get
            Return E_HOSP_CABILDO
        End Get
        Set(value As Integer)
            E_HOSP_CABILDO = value
        End Set
    End Property

    Public Property HOSP_LIGUA As Integer
        Get
            Return E_HOSP_LIGUA
        End Get
        Set(value As Integer)
            E_HOSP_LIGUA = value
        End Set
    End Property

    Public Property HOSP_QUINTERO As Integer
        Get
            Return E_HOSP_QUINTERO
        End Get
        Set(value As Integer)
            E_HOSP_QUINTERO = value
        End Set
    End Property

    Public Property OTROS As Integer
        Get
            Return E_OTROS
        End Get
        Set(value As Integer)
            E_OTROS = value
        End Set
    End Property

    Public Property TOTAL_EXTRA As Integer
        Get
            Return E_TOTAL_EXTRA
        End Get
        Set(value As Integer)
            E_TOTAL_EXTRA = value
        End Set
    End Property

    Public Property ID_SECC_REM As Integer
        Get
            Return E_ID_SECC_REM
        End Get
        Set(value As Integer)
            E_ID_SECC_REM = value
        End Set
    End Property

    Public Property SECC_REM_DESC As String
        Get
            Return E_SECC_REM_DESC
        End Get
        Set(value As String)
            E_SECC_REM_DESC = value
        End Set
    End Property

    Public Property ID_AREA_REM As Integer
        Get
            Return E_ID_AREA_REM
        End Get
        Set(value As Integer)
            E_ID_AREA_REM = value
        End Set
    End Property

    Public Property AREA_DESC As String
        Get
            Return E_AREA_DESC
        End Get
        Set(value As String)
            E_AREA_DESC = value
        End Set
    End Property

    Public Property ID_FONASA_REM_HOSP As Integer
        Get
            Return E_ID_FONASA_REM_HOSP
        End Get
        Set(value As Integer)
            E_ID_FONASA_REM_HOSP = value
        End Set
    End Property
End Class
