'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_OBTENER_INFO
    'Declaraciones Generales
    Dim DD_Data As Ejemplo
    Sub New()
        DD_Data = New Ejemplo
    End Sub
    'Declaraciones Generales
    'Dim DD_Data As Ejemplo
    'Sub New()
    '    DD_Data = New Ejemplo
    'End Sub
    'Function IRIS_GRABA_ATE_DOCUMENTO_PAGO(ByVal FOLIO As String) As List(Of E_IRIS_WEBF_OBTENER_INFO)
    '    Return DD_Data.IRIS_WEBF_HOST_BUsCA_DATOS_PACIENTE_POR_RUT_OMI(FOLIO)
    'End Function
    'Function IRIS_GRABA_ATE_DOCUMENTO_PAGO_RUT(ByVal FOLIO As String) As List(Of E_IRIS_WEBF_OBTENER_INFO)
    '    Return DD_Data.IRIS_WEBF_HOST_BUsCA_DATOS_PACIENTE_POR_RUT_OMI_2(FOLIO)
    'End Function
    'Function IRIS_GRABA_ATE_DOCUMENTO_PAGO_DNI(ByVal FOLIO As String) As List(Of E_IRIS_WEBF_OBTENER_INFO)
    '    Return DD_Data.IRIS_WEBF_HOST_BUsCA_DATOS_PACIENTE_POR_DNI_OMI_2(FOLIO)
    'End Function
    'Function UPDATE_ESTADO_TEST(ByVal OC As String, ByVal CODIGO_TEST As String) As Integer
    '    Return DD_Data.UPDATE_ESTADO_TEST(OC, CODIGO_TEST)
    'End Function
    'Function UPDATE_ESTADO_TEST_NULL(ByVal OC As String, ByVal CODIGO_TEST As String) As Integer
    '    Return DD_Data.UPDATE_ESTADO_TEST_NULL(OC, CODIGO_TEST)
    'End Function
    Function UPDATE_ESTADO_TEST_NULL(ByVal OC As String, ByVal CODIGO_TEST As String) As Integer
        Return DD_Data.UPDATE_ESTADO_TEST_NULL(OC, CODIGO_TEST)
    End Function

    Function UPDATE_ESTADO_TEST(ByVal OC As String, ByVal CODIGO_TEST As String) As Integer
        Return DD_Data.UPDATE_ESTADO_TEST(OC, CODIGO_TEST)
    End Function
End Class
