'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT
    End Sub
    Function IRIS_WEBF_BUSCA_PACIENTE_POR_RUT(ByVal RUT_PAC As String) As List(Of E_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT)
        Return DD_Data.IRIS_WEBF_BUSCA_PACIENTE_POR_RUT(RUT_PAC)
    End Function
    Function IRIS_WEBF_BUSCA_PACIENTE_POR_dni(ByVal RUT_PAC As String) As List(Of E_IRIS_WEBF_BUSCA_PACIENTE_POR_RUT)
        Return DD_Data.IRIS_WEBF_BUSCA_PACIENTE_POR_DNI(RUT_PAC)
    End Function
End Class