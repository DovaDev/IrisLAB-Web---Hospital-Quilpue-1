'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_DERIVADOS
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_DERIVADOS

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_DERIVADOS
    End Sub

    Function IRIS_WEBF_BUSCA_DERIVADOS() As List(Of E_IRIS_WEBF_BUSCA_DERIVADOS)
        Return DD_Data.IRIS_WEBF_BUSCA_DERIVADOS()

    End Function

    Function IRIS_WEBF_CMVM_BUSCA_DERIVADO_BY_ID_PER_NO_RELACIONADAS(ByVal ID_PER As Integer) As List(Of E_IRIS_WEBF_BUSCA_DERIVADOS)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_DERIVADO_BY_ID_PER_NO_RELACIONADAS(ID_PER)
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_RELACION_ESTUDIO_DERIVADO_MANTENEDOR_REL(ByVal ID_PER As Integer) As List(Of E_IRIS_WEBF_BUSCA_RELACION_DERIVADOS_ID_PER)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_RELACION_ESTUDIO_DERIVADO_MANTENEDOR_REL(ID_PER)
    End Function

    Function IRIS_GRABA_RELACION_DERIVADO_ESTUDIO(ByVal ID_PER As Integer, ByVal ID_USER As Integer, ByVal ARRAY_ As Integer) As Integer
        Return DD_Data.IRIS_GRABA_RELACION_DERIVADO_ESTUDIO(ID_PER, ID_USER, ARRAY_)
    End Function

    Function IRIS_WEBF_UPDATE_REL_DERIVADO_ESTUDIO_QUITAR_RELACION(ByVal ARRAY_ As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_REL_DERIVADO_ESTUDIO_QUITAR_RELACION(ARRAY_)
    End Function

    '------------------------------------------------Mantenedor derivado------------------------------------------------------'
    Function IRIS_WEBF_GRABA_DERIVADO(ByVal DERI_COD As String, ByVal DERI_DESC As String, ByVal ID_ESTADO As Integer) As String
        Return DD_Data.IRIS_WEBF_GRABA_DERIVADO(DERI_COD, DERI_DESC, ID_ESTADO)
    End Function

    Function IRIS_WEBF_UPDATE_DERIVADO(ByVal ID_DERIVADO As Integer, ByVal DERI_COD As String, ByVal DERI_DESC As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_DERIVADO(ID_DERIVADO, DERI_COD, DERI_DESC, ID_ESTADO)
    End Function

End Class