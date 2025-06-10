Public Class E_IRIS_WEBF_BUSCA_TOMA_MUESTRA_FECHA_ORDEN_PROCE_TODOS_TODOS
    Private EE_ID_ATENCION As Integer
    Private EE_ATE_NUM As String
    Private EE_ATE_FECHA As DateTime
    Private EE_ATE_AÑO As Integer
    Private EE_PROC_DESC As String
    Private EE_ORD_DESC As String
    Private EE_PAC_NOMBRE As String
    Private EE_PAC_APELLIDO As String
    Private EE_PAC_FONO1 As String
    Private EE_PAC_MOVIL1 As String
    Private EE_SEXO_DESC As String
    Private EE_ID_PACIENTE As Integer
    Private EE_EST_DESCRIPCION As String
    Private EE_ESPERA As String
    Private EE_USU_NIC As String
    Private EE_ATE_ID_ESTADO_TM As Integer
    
    Private EE_PESO As String
    Private EE_TALLA As String
    Private EE_HGT As String
    Private EE_FECHA_HORA_ULTIMA_DOSIS As String
    Private EE_ATE_OBS_TM As String
    Private EE_ATE_OBS_FICHA As String
    Private EE_DIURESIS As String
    Private EE_GRAMAJE As String
    Private EE_PAC_OBS_PERMA As String

    Private EE_NOM_SOC As String

    Private EE_PAC_FNAC As String

    Private EE_FECHA_ACTUAL As String
    Private EE_ZONA_TM As String


    Private EE_GENERO_DESC As String
    Private EE_ETNIA_DESC As String


    Private EE_HORA_SEGUNDA_PTGO As String
    Private EE_TIENE_PTGO As Boolean
    Private EE_HORA_TOMA_SEGUNDA_CARGA As String
    Private EE_IS_COMPLETE_ANATO As String


    Public Property ATE_ID_ESTADO_TM() As Integer
        Get
            Return EE_ATE_ID_ESTADO_TM
        End Get
        Set(ByVal value As Integer)
            EE_ATE_ID_ESTADO_TM = value
        End Set
    End Property
    Public Property USU_NIC() As String
        Get
            Return EE_USU_NIC
        End Get
        Set(ByVal value As String)
            EE_USU_NIC = value
        End Set
    End Property
    Public Property ESPERA() As String
        Get
            Return EE_ESPERA
        End Get
        Set(ByVal value As String)
            EE_ESPERA = value
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
    Public Property PAC_MOVIL1() As String
        Get
            Return EE_PAC_MOVIL1
        End Get
        Set(ByVal value As String)
            EE_PAC_MOVIL1 = value
        End Set
    End Property
    Public Property PAC_FONO1() As String
        Get
            Return EE_PAC_FONO1
        End Get
        Set(ByVal value As String)
            EE_PAC_FONO1 = value
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
    Public Property ORD_DESC() As String
        Get
            Return EE_ORD_DESC
        End Get
        Set(ByVal value As String)
            EE_ORD_DESC = value
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
    Public Property ATE_AÑO() As Integer
        Get
            Return EE_ATE_AÑO
        End Get
        Set(ByVal value As Integer)
            EE_ATE_AÑO = value
        End Set
    End Property
    Public Property ATE_FECHA() As DateTime
        Get
            Return EE_ATE_FECHA
        End Get
        Set(ByVal value As DateTime)
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
    Public Property PESO() As String
        Get
            Return EE_PESO
        End Get
        Set(ByVal value As String)
            EE_PESO = value
        End Set
    End Property
    Public Property TALLA() As String
        Get
            Return EE_TALLA
        End Get
        Set(ByVal value As String)
            EE_TALLA = value
        End Set
    End Property
    Public Property HGT() As String
        Get
            Return EE_HGT
        End Get
        Set(ByVal value As String)
            EE_HGT = value
        End Set
    End Property
    Public Property ATE_OBS_TM() As String
        Get
            Return EE_ATE_OBS_TM
        End Get
        Set(ByVal value As String)
            EE_ATE_OBS_TM = value
        End Set
    End Property
    Public Property ATE_OBS_FICHA() As String
        Get
            Return EE_ATE_OBS_FICHA
        End Get
        Set(ByVal value As String)
            EE_ATE_OBS_FICHA = value
        End Set
    End Property
    Public Property DIURESIS() As String
        Get
            Return EE_DIURESIS
        End Get
        Set(ByVal value As String)
            EE_DIURESIS = value
        End Set
    End Property
    Public Property GRAMAJE() As String
        Get
            Return EE_GRAMAJE
        End Get
        Set(ByVal value As String)
            EE_GRAMAJE = value
        End Set
    End Property
    Public Property PAC_OBS_PERMA() As String
        Get
            Return EE_PAC_OBS_PERMA
        End Get
        Set(ByVal value As String)
            EE_PAC_OBS_PERMA = value
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

    Public Property NOM_SOC As String
        Get
            Return EE_NOM_SOC
        End Get
        Set(value As String)
            EE_NOM_SOC = value
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

    Public Property FECHA_ACTUAL As String
        Get
            Return EE_FECHA_ACTUAL
        End Get
        Set(value As String)
            EE_FECHA_ACTUAL = value
        End Set
    End Property

    Public Property ZONA_TM As String
        Get
            Return EE_ZONA_TM
        End Get
        Set(value As String)
            EE_ZONA_TM = value
        End Set
    End Property

    Public Property GENERO_DESC As String
        Get
            Return EE_GENERO_DESC
        End Get
        Set(value As String)
            EE_GENERO_DESC = value
        End Set
    End Property

    Public Property ETNIA_DESC As String
        Get
            Return EE_ETNIA_DESC
        End Get
        Set(value As String)
            EE_ETNIA_DESC = value
        End Set
    End Property

    Public Property HORA_SEGUNDA_PTGO As String
        Get
            Return EE_HORA_SEGUNDA_PTGO
        End Get
        Set(value As String)
            EE_HORA_SEGUNDA_PTGO = value
        End Set
    End Property

    Public Property TIENE_PTGO As Boolean
        Get
            Return EE_TIENE_PTGO
        End Get
        Set(value As Boolean)
            EE_TIENE_PTGO = value
        End Set
    End Property

    Public Property HORA_TOMA_SEGUNDA_CARGA As String
        Get
            Return EE_HORA_TOMA_SEGUNDA_CARGA
        End Get
        Set(value As String)
            EE_HORA_TOMA_SEGUNDA_CARGA = value
        End Set
    End Property

    Public Property FECHA_HORA_ULTIMA_DOSIS As String
        Get
            Return EE_FECHA_HORA_ULTIMA_DOSIS
        End Get
        Set(value As String)
            EE_FECHA_HORA_ULTIMA_DOSIS = value
        End Set
    End Property

    Public Property IS_COMPLETE_ANATO As String
        Get
            Return EE_IS_COMPLETE_ANATO
        End Get
        Set(value As String)
            EE_IS_COMPLETE_ANATO = value
        End Set
    End Property
End Class
