Public Class E_IRIS_WEBF_BUSCA_DOCUMENTOS
    Dim EE_ID_DCTO As Integer
    Dim EE_DCTO_COD As String
    Dim EE_DCTO_DESC As String
    Dim EE_DCTO_TIPO As Integer
    Dim EE_DCTO_ORDEN As Integer
    Dim EE_DCTO_FECHA As Date
    Dim EE_DCTO_RUTA As String
    Dim EE_ID_ESTADO As Integer
    Dim EE_DCTO_CATEGORIA As String
    Dim EE_DCTO_SUBCATEGORIA As String
    Dim EE_ID_TRAZA_PAP As Integer
    Dim EE_ID_USUARIO As Integer
    Dim EE_FECHA_TRAZA As Date
    Dim EE_NUM_TRAZA As Integer
    Dim EE_ID_ESTADO_USU As Integer
    Dim EE_USU_NIC As String
    Dim EE_USU_ADMIN As Integer
    Dim EE_ID_PAP_CAJA As Integer
    Dim EE_FECHA_CREACION_CAJA As Date
    Dim EE_COMENTARIO_CAJA As String
    Dim EE_TIPO_CAJA As String
    Dim EE_MATRIZ_NUM_AVIS As String
    Dim EE_PROC_DESC As String
    Dim EE_ID_ESTADO_CAJA As String

    Public Property ID_ESTADO_CAJA As String
        Get
            Return EE_ID_ESTADO_CAJA
        End Get
        Set(value As String)
            EE_ID_ESTADO_CAJA = value
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

    Public Property MATRIZ_NUM_AVIS As String
        Get
            Return EE_MATRIZ_NUM_AVIS
        End Get
        Set(value As String)
            EE_MATRIZ_NUM_AVIS = value
        End Set
    End Property

    Public Property TIPO_CAJA As String
        Get
            Return EE_TIPO_CAJA
        End Get
        Set(value As String)
            EE_TIPO_CAJA = value
        End Set
    End Property

    Public Property COMENTARIO_CAJA As String
        Get
            Return EE_COMENTARIO_CAJA
        End Get
        Set(value As String)
            EE_COMENTARIO_CAJA = value
        End Set
    End Property

    Public Property FECHA_CREACION_CAJA As Date
        Get
            Return EE_FECHA_CREACION_CAJA
        End Get
        Set(value As Date)
            EE_FECHA_CREACION_CAJA = value
        End Set
    End Property

    Public Property ID_PAP_CAJA As Integer
        Get
            Return EE_ID_PAP_CAJA
        End Get
        Set(value As Integer)
            EE_ID_PAP_CAJA = value
        End Set
    End Property

    Public Property USU_ADMIN As Integer
        Get
            Return EE_USU_ADMIN
        End Get
        Set(value As Integer)
            EE_USU_ADMIN = value
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

    Public Property ID_ESTADO_USU As Integer
        Get
            Return EE_ID_ESTADO_USU
        End Get
        Set(value As Integer)
            EE_ID_ESTADO_USU = value
        End Set
    End Property

    Public Property NUM_TRAZA As Integer
        Get
            Return EE_NUM_TRAZA
        End Get
        Set(value As Integer)
            EE_NUM_TRAZA = value
        End Set
    End Property

    Public Property FECHA_TRAZA As Date
        Get
            Return EE_FECHA_TRAZA
        End Get
        Set(value As Date)
            EE_FECHA_TRAZA = value
        End Set
    End Property

    Public Property ID_USUARIO As Integer
        Get
            Return EE_ID_USUARIO
        End Get
        Set(value As Integer)
            EE_ID_USUARIO = value
        End Set
    End Property

    Public Property ID_TRAZA_PAP As Integer
        Get
            Return EE_ID_TRAZA_PAP
        End Get
        Set(value As Integer)
            EE_ID_TRAZA_PAP = value
        End Set
    End Property

    Public Property DCTO_SUBCATEGORIA As String
        Get
            Return EE_DCTO_SUBCATEGORIA
        End Get
        Set(value As String)
            EE_DCTO_SUBCATEGORIA = value
        End Set
    End Property

    Public Property DCTO_CATEGORIA As String
        Get
            Return EE_DCTO_CATEGORIA
        End Get
        Set(value As String)
            EE_DCTO_CATEGORIA = value
        End Set
    End Property

    Public Property ID_DCTO As Integer
        Get
            Return EE_ID_DCTO
        End Get
        Set(value As Integer)
            EE_ID_DCTO = value
        End Set
    End Property

    Public Property DCTO_COD As String
        Get
            Return EE_DCTO_COD
        End Get
        Set(value As String)
            EE_DCTO_COD = value
        End Set
    End Property

    Public Property DCTO_DESC As String
        Get
            Return EE_DCTO_DESC
        End Get
        Set(value As String)
            EE_DCTO_DESC = value
        End Set
    End Property

    Public Property DCTO_TIPO As Integer
        Get
            Return EE_DCTO_TIPO
        End Get
        Set(value As Integer)
            EE_DCTO_TIPO = value
        End Set
    End Property
    Public Property DCTO_ORDEN As Integer
        Get
            Return EE_DCTO_ORDEN
        End Get
        Set(value As Integer)
            EE_DCTO_ORDEN = value
        End Set
    End Property
    Public Property DCTO_FECHA As Date
        Get
            Return EE_DCTO_FECHA
        End Get
        Set(value As Date)
            EE_DCTO_FECHA = value
        End Set
    End Property
    Public Property DCTO_RUTA As String
        Get
            Return EE_DCTO_RUTA
        End Get
        Set(value As String)
            EE_DCTO_RUTA = value
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
End Class
