'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO
    End Sub

    Function IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO(ByVal TIPO As Integer,
                                                                                           ByVal DESDE As Date,
                                                                                           ByVal HASTA As Date,
                                                                                           ByVal ID_PRE As Integer,
                                                                                           ByVal ID_CF As Integer,
                                                                                           ByVal ID_VAL As Integer,
                                                                                           ByVal ID_NMUE As Integer,
                                                                                           ByVal ID_SECCION As Integer,
                                                                                           ByVal ATENUM As Integer,
                                                                                           ByVal ID_ENVIO As Integer,
                                                                                           ByVal ID_DERIVADO As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO)
        Return DD_Data.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO(TIPO, DESDE, HASTA, ID_PRE, ID_CF, ID_VAL, ID_NMUE, ID_SECCION, ATENUM, ID_ENVIO, ID_DERIVADO)

    End Function

    Function IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO_666_FECHAS(ByVal TIPO As Integer,
                                                                                       ByVal DESDE As Date,
                                                                                       ByVal HASTA As Date,
                                                                                       ByVal ID_PRE As Integer,
                                                                                       ByVal ID_CF As Integer,
                                                                                       ByVal ID_VAL As Integer,
                                                                                       ByVal ID_NMUE As Integer,
                                                                                       ByVal ID_SECCION As Integer,
                                                                                       ByVal ID_ENVIO As Integer,
                                                                                       ByVal ID_DERIVADO As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO)
        Return DD_Data.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO_666_FECHAS(TIPO, DESDE, HASTA, ID_PRE, ID_CF, ID_VAL, ID_NMUE, ID_SECCION, ID_ENVIO, ID_DERIVADO)

    End Function
    Function IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO_666_FECHAS_ENVIO_Y_RECEP_LAB(ByVal TIPO As Integer,
                                                                                   ByVal DESDE As Date,
                                                                                   ByVal HASTA As Date,
                                                                                   ByVal ID_ENVIO As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO)

        'Dim Galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_TM")

        'If (IsNothing(Galleta) = True) Then
        '    HttpContext.Current.Response.Redirect("~/index.aspx")
        'End If

        Return DD_Data.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO_666_FECHAS_ENVIO_Y_RECEP_LAB(TIPO, DESDE, HASTA, ID_ENVIO)

    End Function
    Function IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO_AVIS(ByVal TIPO As Integer,
                                                                                       ByVal DESDE As Date,
                                                                                       ByVal HASTA As Date,
                                                                                       ByVal ID_PRE As Integer,
                                                                                       ByVal ID_CF As Integer,
                                                                                       ByVal ID_VAL As Integer,
                                                                                       ByVal ID_NMUE As Integer,
                                                                                       ByVal ID_SECCION As Integer,
                                                                                       ByVal ATENUM As Integer,
                                                                                       ByVal ID_ENVIO As Integer,
                                                                                       ByVal ID_DERIVADO As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO)
        Return DD_Data.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO_AVIS(TIPO, DESDE, HASTA, ID_PRE, ID_CF, ID_VAL, ID_NMUE, ID_SECCION, ATENUM, ID_ENVIO, ID_DERIVADO)

    End Function





    Function IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO_666_FECHAS_ENVIO_Y_RECEP_LAB2(ByVal TIPO As Integer,
                                                                                  ByVal DESDE As Date,
                                                                                  ByVal HASTA As Date,
                                                                                  ByVal ID_ENVIO As Integer, ID_PROCEDENCIA As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO)

        'Dim Galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_TM")

        'If (IsNothing(Galleta) = True) Then
        '    HttpContext.Current.Response.Redirect("~/index.aspx")
        'End If

        Return DD_Data.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO_666_FECHAS_ENVIO_Y_RECEP_LAB2(TIPO, DESDE, HASTA, ID_ENVIO, ID_PROCEDENCIA)

    End Function
    Function IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO_666_FECHAS_ENVIO_Y_RECEP_LAB_id_ate2(DESDE As Date,
                                                                                   HASTA As Date,
                                                                                   ID_ATENCION As Integer, ID_PROCEDENCIA As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO)

        'Dim Galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_TM")

        'If (IsNothing(Galleta) = True) Then
        '    HttpContext.Current.Response.Redirect("~/index.aspx")
        'End If

        Return DD_Data.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_SECCCION_POR_FOLIO_666_FECHAS_ENVIO_Y_RECEP_LAB_id_ate2(DESDE, HASTA, ID_ATENCION, ID_PROCEDENCIA)

    End Function

End Class