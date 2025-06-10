'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_5
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_5

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_5
    End Sub

    Function IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_5(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_SECC As Integer, ByVal ID_PRE As Integer) As List(Of E_IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_5)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_TM")
        Dim ID_PROC As Integer

        Try
            ID_PROC = CInt(galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try
        Return DD_Data.IRIS_WEBF_BUSCA_ACREDITACION_LISTADO_TOTAL_POR_MUESTRA_5(DESDE, HASTA, ID_SECC, ID_PRE, ID_PROC)

    End Function
End Class
