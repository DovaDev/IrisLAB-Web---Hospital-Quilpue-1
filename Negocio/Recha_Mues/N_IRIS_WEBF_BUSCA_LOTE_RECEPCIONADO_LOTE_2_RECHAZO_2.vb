'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_2
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_2

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_2
    End Sub

    Function IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_2(ByVal NUMLOTE As Double, ByVal ID_RECHA As Integer) As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_2)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_TM")
        Dim ID_PROC As Integer

        Try
            ID_PROC = CInt(galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try
        Return DD_Data.IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_2(NUMLOTE, ID_RECHA, ID_PROC)

    End Function
End Class