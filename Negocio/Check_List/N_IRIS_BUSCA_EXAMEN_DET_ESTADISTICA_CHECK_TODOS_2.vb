'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
    Sub New()

        DD_Data = New D_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2
    End Sub
    Function IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_PRUEBA As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_ID_PROC")
        Dim ID_PROC As Integer

        Try
            ID_PROC = CInt(galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try

        Return DD_Data.IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2(DESDE, HASTA, ID_CF, ID_PRUEBA, ID_PROC)
    End Function
    Function IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_GR(ByVal DESDE As Date,
                                                                ByVal HASTA As Date,
                                                                ByVal ID_CF As Integer,
                                                                ByVal ID_PRUEBA As Integer,
                                                                ByVal ID_PROC As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_TM")
        'Dim ID_PROC As Integer

        'Try
        '    ID_PROC = CInt(galleta.Value)
        'Catch ex As Exception
        '    HttpContext.Current.Response.Redirect("~/index.aspx")
        'End Try

        Return DD_Data.IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_GR(DESDE, HASTA, ID_CF, ID_PRUEBA, ID_PROC)
    End Function
    Function IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_PCR(ByVal DESDE As Date,
                                                                ByVal HASTA As Date,
                                                                ByVal ID_CF As Integer,
                                                                ByVal ID_PRUEBA As Integer,
                                                                ByVal ID_PROC As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_TM")
        'Dim ID_PROC As Integer

        'Try
        '    ID_PROC = CInt(galleta.Value)
        'Catch ex As Exception
        '    HttpContext.Current.Response.Redirect("~/index.aspx")
        'End Try

        Return DD_Data.IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_PCR(DESDE, HASTA, ID_CF, ID_PRUEBA, ID_PROC)
    End Function
    Function IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_CC(ByVal DESDE As Date,
                                                                ByVal HASTA As Date,
                                                                ByVal ID_CF As Integer,
                                                                ByVal ID_PRUEBA As Integer,
                                                                ByVal ID_PROC As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_TM")
        'Dim ID_PROC As Integer

        'Try
        '    ID_PROC = CInt(galleta.Value)
        'Catch ex As Exception
        '    HttpContext.Current.Response.Redirect("~/index.aspx")
        'End Try

        Return DD_Data.IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_CC(DESDE, HASTA, ID_CF, ID_PRUEBA, ID_PROC)
    End Function
    Function IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_AND_ID_ATE_RES(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_PRUEBA As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_ID_PROC")
        Dim ID_PROC As Integer

        Try
            ID_PROC = CInt(galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try

        Return DD_Data.IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_AND_ID_ATE_RES(DESDE, HASTA, ID_CF, ID_PRUEBA, ID_PROC)
    End Function
    Function IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_AND_ID_ATE_RES_CON_ARRAY(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal MUESTRA() As Object) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_ID_PROC")
        Dim ID_PROC As Integer

        Try
            ID_PROC = CInt(galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try

        Return DD_Data.IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_AND_ID_ATE_RES_CON_ARRAY(DESDE, HASTA, ID_CF, MUESTRA, ID_PROC)
    End Function
    Function IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_AND_ID_ATE_RES_MARCADOS(ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_ID_PROC")
        Dim ID_PROC As Integer

        Try
            ID_PROC = CInt(galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try

        Return DD_Data.IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_AND_ID_ATE_RES_MARCADOS(DESDE, HASTA, ID_PROC)
    End Function
    Function IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_AND_ID_ATE_RES_CON_ARRAY_y_MARCADOS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal MUESTRA() As Object) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_ID_PROC")
        Dim ID_PROC As Integer

        Try
            ID_PROC = CInt(galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try

        Return DD_Data.IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_AND_ID_ATE_RES_CON_ARRAY_y_MARCADOS(DESDE, HASTA, ID_CF, MUESTRA, ID_PROC)
    End Function

    Function IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_SCREENING_SIFILIS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_PRUEBA As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_ID_PROC")
        Dim ID_PROC As Integer

        Try
            ID_PROC = CInt(galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try

        Return DD_Data.IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_SCREENING_SIFILIS(DESDE, HASTA, ID_CF, ID_PRUEBA, ID_PROC)
    End Function
    Function IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_4(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal ID_PRUEBA As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_ID_PROC")
        Dim ID_PROC As Integer

        Try
            ID_PROC = CInt(galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try

        Return DD_Data.IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_4(DESDE, HASTA, ID_CF, ID_PRUEBA, ID_PROC)
    End Function
    Function IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_AND_ID_ATE_RES_CON_ARRAY_ID_PER(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Integer, ByVal MUESTRA() As Object) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_ID_PROC")
        Dim ID_PROC As Integer

        Try
            ID_PROC = CInt(galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try

        Return DD_Data.IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_AND_ID_ATE_RES_CON_ARRAY_ID_PER(DESDE, HASTA, ID_CF, MUESTRA, ID_PROC)
    End Function
    Function IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_VIH_PDF(ByVal DESDE As Date,
                                                                ByVal HASTA As Date,
                                                                ByVal ID_CF As Integer,
                                                                ByVal ID_PRUEBA As Integer,
                                                                ByVal ID_PROC As Integer) As List(Of E_IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2)
        'Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_TM")
        'Dim ID_PROC As Integer

        'Try
        '    ID_PROC = CInt(galleta.Value)
        'Catch ex As Exception
        '    HttpContext.Current.Response.Redirect("~/index.aspx")
        'End Try

        Return DD_Data.IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS_2_2_VIH_PDF(DESDE, HASTA, ID_CF, ID_PRUEBA, ID_PROC)
    End Function

End Class