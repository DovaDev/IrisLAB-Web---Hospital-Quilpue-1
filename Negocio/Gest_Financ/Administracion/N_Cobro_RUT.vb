Imports Entidades
Imports Datos
Public Class N_Cobro_RUT

    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_ATENCION_FECHA_RUT_COBRO

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_ATENCION_FECHA_RUT_COBRO
    End Sub

    Function IRIS_WEBF_BUSCA_ATENCION_FECHA_RUT_COBRO(ByVal DESDE As String, ByVal HASTA As String, ByVal RUT_DNI As String) As List(Of E_Cobro_RUT)
        Return DD_Data.IRIS_WEBF_BUSCA_ATENCION_FECHA_RUT_COBRO(DESDE, HASTA, RUT_DNI)

    End Function
End Class
