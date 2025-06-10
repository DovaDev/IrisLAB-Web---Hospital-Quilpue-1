Public Class E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL
    Private EE_ID_RESIDUO As Integer
    Private EE_FOLIO_RESIDUO As String
    Private EE_FECHA_RESIDUO As Date
    Private EE_COD_SECC_RESIDUO As String
    Private EE_SECC_RESIDUO_DESC As String
    Private EE_TP_RESIDUO_DESC As String
    Private EE_BOLSA_CONT_RESIDUO As String
    Private EE_KILOS_RESIDUO As String
    Private EE_RESPONSABLE_RESIDUO As String
    Private EE_ESTADO_RESIDUO As String
    Private EE_PROC_DESC As String
    Private EE_ID_SECC_RESIDUO As Integer
    Private EE_ID_TP_RESIDUO As Integer
    Private EE_ID_PROCEDENCIA As Integer
    Private EE_ID_USUARIO_UNION As Integer
    Private EE_FECHA_UNION As Date
    Private EE_ATE_AVIS_UNION As String
    Private EE_ATE_NUM_UNION As String
    Private EE_Contenedor_Envio As String
    '---------------------------------------------------
    Private EE_ATE_NUM As String
    Private EE_PAC_NOMBRE As String
    Private EE_PAC_APELLIDO As String
    Private EE_PAC_RUT As String
    Private EE_ATE_AÑO As String
    Private EE_SUPERVISOR As String
    Public Property SUPERVISOR() As String
        Get
            Return EE_SUPERVISOR
        End Get
        Set(ByVal value As String)
            EE_SUPERVISOR = value
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
    Public Property PAC_RUT() As String
        Get
            Return EE_PAC_RUT
        End Get
        Set(ByVal value As String)
            EE_PAC_RUT = value
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
    Public Property ATE_NUM() As String
        Get
            Return EE_ATE_NUM
        End Get
        Set(ByVal value As String)
            EE_ATE_NUM = value
        End Set
    End Property
    '--------------------------------------------------
    Public Property Contenedor_Envio() As String
        Get
            Return EE_Contenedor_Envio
        End Get
        Set(ByVal value As String)
            EE_Contenedor_Envio = value
        End Set
    End Property
    Public Property ATE_NUM_UNION() As String
        Get
            Return EE_ATE_NUM_UNION
        End Get
        Set(ByVal value As String)
            EE_ATE_NUM_UNION = value
        End Set
    End Property
    Public Property ATE_AVIS_UNION() As String
        Get
            Return EE_ATE_AVIS_UNION
        End Get
        Set(ByVal value As String)
            EE_ATE_AVIS_UNION = value
        End Set
    End Property
    Public Property FECHA_UNION() As Date
        Get
            Return EE_FECHA_UNION
        End Get
        Set(ByVal value As Date)
            EE_FECHA_UNION = value
        End Set
    End Property
    Public Property ID_USUARIO_UNION() As Integer
        Get
            Return EE_ID_USUARIO_UNION
        End Get
        Set(ByVal value As Integer)
            EE_ID_USUARIO_UNION = value
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
    Public Property ID_TP_RESIDUO() As Integer
        Get
            Return EE_ID_TP_RESIDUO
        End Get
        Set(ByVal value As Integer)
            EE_ID_TP_RESIDUO = value
        End Set
    End Property
    Public Property ID_SECC_RESIDUO() As Integer
        Get
            Return EE_ID_SECC_RESIDUO
        End Get
        Set(ByVal value As Integer)
            EE_ID_SECC_RESIDUO = value
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

    Public Property ESTADO_RESIDUO() As String
        Get
            Return EE_ESTADO_RESIDUO
        End Get
        Set(ByVal value As String)
            EE_ESTADO_RESIDUO = value
        End Set
    End Property

    Public Property RESPONSABLE_RESIDUO() As String
        Get
            Return EE_RESPONSABLE_RESIDUO
        End Get
        Set(ByVal value As String)
            EE_RESPONSABLE_RESIDUO = value
        End Set
    End Property

    Public Property KILOS_RESIDUO() As String
        Get
            Return EE_KILOS_RESIDUO
        End Get
        Set(ByVal value As String)
            EE_KILOS_RESIDUO = value
        End Set
    End Property

    Public Property BOLSA_CONT_RESIDUO() As String
        Get
            Return EE_BOLSA_CONT_RESIDUO
        End Get
        Set(ByVal value As String)
            EE_BOLSA_CONT_RESIDUO = value
        End Set
    End Property

    Public Property TP_RESIDUO_DESC() As String
        Get
            Return EE_TP_RESIDUO_DESC
        End Get
        Set(ByVal value As String)
            EE_TP_RESIDUO_DESC = value
        End Set
    End Property

    Public Property SECC_RESIDUO_DESC() As String
        Get
            Return EE_SECC_RESIDUO_DESC
        End Get
        Set(ByVal value As String)
            EE_SECC_RESIDUO_DESC = value
        End Set
    End Property

    Public Property COD_SECC_RESIDUO() As String
        Get
            Return EE_COD_SECC_RESIDUO
        End Get
        Set(ByVal value As String)
            EE_COD_SECC_RESIDUO = value
        End Set
    End Property

    Public Property FECHA_RESIDUO() As Date
        Get
            Return EE_FECHA_RESIDUO
        End Get
        Set(ByVal value As Date)
            EE_FECHA_RESIDUO = value
        End Set
    End Property
    Public Property FOLIO_RESIDUO() As String
        Get
            Return EE_FOLIO_RESIDUO
        End Get
        Set(ByVal value As String)
            EE_FOLIO_RESIDUO = value
        End Set
    End Property
    Public Property ID_RESIDUO() As Integer
        Get
            Return EE_ID_RESIDUO
        End Get
        Set(ByVal value As Integer)
            EE_ID_RESIDUO = value
        End Set
    End Property











    ' ------------------- RESIDUOS ------------------------

















    Private EE_Cod_Barra As String
    Public Property Cod_Barra() As String
        Get
            Return EE_Cod_Barra
        End Get
        Set(ByVal value As String)
            EE_Cod_Barra = value
        End Set
    End Property

    Private EE_Establecimiento_Contenedor As String
    Public Property Establecimiento_Contenedor() As String
        Get
            Return EE_Establecimiento_Contenedor
        End Get
        Set(ByVal value As String)
            EE_Establecimiento_Contenedor = value
        End Set
    End Property

    Private EE_Caja_Transporte As String
    Public Property Caja_Transporte() As String
        Get
            Return EE_Caja_Transporte
        End Get
        Set(ByVal value As String)
            EE_Caja_Transporte = value
        End Set
    End Property

    Private EE_Fecha_irislab As Date
    Public Property Fecha_irislab() As Date
        Get
            Return EE_Fecha_irislab
        End Get
        Set(ByVal value As Date)
            EE_Fecha_irislab = value
        End Set
    End Property

    Private EE_Muestras_recepcionadas As String
    Public Property Muestras_recepcionadas() As String
        Get
            Return EE_Muestras_recepcionadas
        End Get
        Set(ByVal value As String)
            EE_Muestras_recepcionadas = value
        End Set
    End Property

    Private EE_Muestras_enviadas As String
    Public Property Muestras_enviadas() As String
        Get
            Return EE_Muestras_enviadas
        End Get
        Set(ByVal value As String)
            EE_Muestras_enviadas = value
        End Set
    End Property

    Private EE_Folio_Hoja_trabajo As String
    Public Property Folio_Hoja_trabajo() As String
        Get
            Return EE_Folio_Hoja_trabajo
        End Get
        Set(ByVal value As String)
            EE_Folio_Hoja_trabajo = value
        End Set
    End Property

    Private EE_Fecha_envio_HGF As Date
    Public Property Fecha_envio_HGF() As Date
        Get
            Return EE_Fecha_envio_HGF
        End Get
        Set(ByVal value As Date)
            EE_Fecha_envio_HGF = value
        End Set
    End Property

    Private EE_Fecha_recepcion_Resultados As Date
    Public Property Fecha_recepcion_Resultados() As Date
        Get
            Return EE_Fecha_recepcion_Resultados
        End Get
        Set(ByVal value As Date)
            EE_Fecha_recepcion_Resultados = value
        End Set
    End Property

    Private EE_Fecha_Validacion_en_Irislab As Date
    Public Property Fecha_Validacion_en_Irislab() As Date
        Get
            Return EE_Fecha_Validacion_en_Irislab
        End Get
        Set(ByVal value As Date)
            EE_Fecha_Validacion_en_Irislab = value
        End Set
    End Property

    Private EE_num As String
    Public Property num() As String
        Get
            Return EE_num
        End Get
        Set(ByVal value As String)
            EE_num = value
        End Set
    End Property
    Private EE_ID As Integer
    Public Property ID() As Integer
        Get
            Return EE_ID
        End Get
        Set(ByVal value As Integer)
            EE_ID = value
        End Set
    End Property
End Class