Imports Entidades
Imports Datos
Imports System.Data.OleDb
Imports System.Collections.Generic


Public Class N_IRIS_WEBF_BUSCA_PACK
    Dim DD_Data As D_IRIS_WEBF_BUSCA_PACK
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_PACK
    End Sub
    Function IRIS_WEBF_BUSCA_PACK() As List(Of E_IRIS_WEBF_BUSCA_PACK_CF)
        Return DD_Data.IRIS_WEBF_BUSCA_PACK()
    End Function

    Function IRIS_WEBF_BUSCA_RELACION_PACK_CF_NO_CARGADAS(ByVal ID_PACK As Integer) As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_ACTIVO)
        Return DD_Data.IRIS_WEBF_BUSCA_RELACION_PACK_CF_NO_CARGADAS(ID_PACK)
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_RELACION_PACK_CF_MANTENEDOR_REL(ByVal ID_PACK As Integer) As List(Of E_IRIS_WEBF_BUSCA_CODIGO_FONASA_ACTIVO)
        Return DD_Data.IRIS_WEBF_CMVM_BUSCA_RELACION_PACK_CF_MANTENEDOR_REL(ID_PACK)
    End Function

    Function IRIS_WEBF_UPDATE_REL_PACK_CF_QUITAR_RELACION(ByVal ARRAY_COD_FONASA As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_REL_PACK_CF_QUITAR_RELACION(ARRAY_COD_FONASA)
    End Function

    Function IRIS_WEBF_GRABA_RELACION_PACK_CF(ByVal ID_PACK As Integer, ByVal ARRAY_COD_FONASA As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_RELACION_PACK_CF(ID_PACK, ARRAY_COD_FONASA)
    End Function

    Function IRIS_WEBF_BUSCA_PACK_2023() As List(Of E_IRIS_WEBF_BUSCA_PACK_CF)
        Return DD_Data.IRIS_WEBF_BUSCA_PACK_2023()
    End Function

    Function IRIS_WEBF_GRABA_PACK(ByVal PACK_COD As String, ByVal PACK_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_GRABA_PACK(PACK_COD, PACK_DES, ID_ESTADO)
    End Function

    Function IRIS_WEBF_CMVM_UPDATE_PACK(ByVal ID_PACK As Integer, ByVal PACK_COD As String, ByVal PACK_DES As String, ByVal ID_ESTADO As Integer) As Integer
        Return DD_Data.IRIS_WEBF_CMVM_UPDATE_PACK(ID_PACK, PACK_COD, PACK_DES, ID_ESTADO)
    End Function

End Class
