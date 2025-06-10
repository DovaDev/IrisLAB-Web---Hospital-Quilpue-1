'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_UPDATE_PACIENTES_FNAC
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_UPDATE_PACIENTES_FNAC
    Sub New()
        DD_Data = New D_IRIS_WEBF_UPDATE_PACIENTES_FNAC
    End Sub
    Function IRIS_WEBF_UPDATE_PACIENTES_FNAC(ByVal ID_PAC As Integer, ByVal FNAC_PAC As Date) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_PACIENTES_FNAC(ID_PAC, FNAC_PAC)
    End Function
End Class
