Public Class E_IRIS_WEBF_CMVM_BUSCA_IMAGENES_SCANNER
    Private EE_ID_OC As Integer
    Private EE_OC_RUTA_FOTO As String
    Public Property OC_RUTA_FOTO() As String
        Get
            Return EE_OC_RUTA_FOTO
        End Get
        Set(ByVal value As String)
            EE_OC_RUTA_FOTO = value
        End Set
    End Property
    Public Property ID_OC() As Integer
        Get
            Return EE_ID_OC
        End Get
        Set(ByVal value As Integer)
            EE_ID_OC = value
        End Set
    End Property
End Class
