Imports Datos
Imports Entidades

Public Class N_Impr_Dcto2
    Dim Data As D_Impr_Dcto2

    Sub New()
        Data = New D_Impr_Dcto2
    End Sub

    Public Function IRIS_WEBF_CMVM_AGENDA_BUSCA_PACIENTES_AGENDADOS_FILTHER_1(ByVal DESDE As Date, ByVal HASTA As Date,
                                                                              ByVal ID_PROC As Long, ByVal ID_PREV As Long,
                                                                              ByVal ID_PROG As Long, ByVal ID_SUBP As Long) As List(Of E_IRIS_WEBF_CMVM_AGENDA_BUSCA_PACIENTES_AGENDADOS_FILTHER)

        Return Data.IRIS_WEBF_CMVM_AGENDA_BUSCA_PACIENTES_AGENDADOS_FILTHER_1(DESDE, HASTA, ID_PROC, ID_PREV, ID_PROG, ID_SUBP)
    End Function

    Public Function IRIS_WEBF_CMVM_AGENDA_BUSCA_PACIENTES_AGENDADOS_FILTHER_2(ByVal PRE_NUM As String, ByVal ATE_NUM As String, ByVal PAC_RUT As String,
                                                                              ByVal PAC_DNI As String, ByVal PAC_NAME As String, ByVal PAC_LAST As String) As List(Of E_IRIS_WEBF_CMVM_AGENDA_BUSCA_PACIENTES_AGENDADOS_FILTHER)

        Return Data.IRIS_WEBF_CMVM_AGENDA_BUSCA_PACIENTES_AGENDADOS_FILTHER_2(PRE_NUM, ATE_NUM, PAC_RUT, PAC_DNI, PAC_NAME, PAC_LAST)
    End Function
End Class
