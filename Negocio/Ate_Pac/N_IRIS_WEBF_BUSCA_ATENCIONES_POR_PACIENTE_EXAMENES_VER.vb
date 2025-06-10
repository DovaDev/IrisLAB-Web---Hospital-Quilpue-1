'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER
    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER
    End Sub
    Function IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER(ByVal ID_PAC As Integer) As List(Of E_IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER)
        Dim objCookie As HttpCookie = HttpContext.Current.Request.Cookies("USU_ID_PROC")

        If (IsNothing(objCookie) = True) Then
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End If

        Return DD_Data.IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER(ID_PAC, CInt(objCookie.Value))
    End Function
    Function IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER_AGENDA(ByVal ID_PAC As Integer) As List(Of E_IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER)
        Return DD_Data.IRIS_WEBF_BUSCA_ATENCIONES_POR_PACIENTE_EXAMENES_VER_AGENDA(ID_PAC)
    End Function
End Class