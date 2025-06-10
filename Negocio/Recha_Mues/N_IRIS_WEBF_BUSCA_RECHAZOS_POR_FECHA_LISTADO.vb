'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_RECHAZOS_POR_FECHA_LISTADO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_RECHAZOS_POR_FECHA_LISTADO

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_RECHAZOS_POR_FECHA_LISTADO
    End Sub

    Function IRIS_WEBF_BUSCA_RECHAZOS_POR_FECHA_LISTADO(ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_RECHAZOS_POR_FECHA_LISTADO)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_TM")

        Return DD_Data.IRIS_WEBF_BUSCA_RECHAZOS_POR_FECHA_LISTADO(DESDE, HASTA)

    End Function
End Class