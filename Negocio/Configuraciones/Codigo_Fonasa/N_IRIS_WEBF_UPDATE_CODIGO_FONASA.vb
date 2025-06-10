Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_UPDATE_CODIGO_FONASA
    Private DD_Data As D_IRIS_WEBF_UPDATE_CODIGO_FONASA
    Public Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_CODIGO_FONASA
    End Sub
    Function IRIS_WEBF_UPDATE_CODIGO_FONASA(ByVal ID_CF As Integer, ByVal COD_CF As String, ByVal DESC_CF As String, ByVal CORTO_CF As String, ByVal DIAS_CF As Integer, ByVal ID_ESTADO As Integer, ByVal SOLA_CF As String, ByVal IMP_NOM_CF As String, ByVal IMP_SEL_CF As String, ByVal IMP_PAR_CF As String, ByVal HOST_CF As String, ByVal ID_MUESTRA As String) As Integer
        Return DD_Data.D_IRIS_WEBF_UPDATE_CODIGO_FONASA(ID_CF, COD_CF, DESC_CF, CORTO_CF, DIAS_CF, ID_ESTADO, SOLA_CF, IMP_NOM_CF, IMP_SEL_CF, IMP_PAR_CF, HOST_CF, ID_MUESTRA)
    End Function
End Class
