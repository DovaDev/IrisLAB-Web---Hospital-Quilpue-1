'Importar Capas
Imports Datos
Imports Entidades
Imports ASPPDFLib

Public Class N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO
    Inherits System.Web.UI.Page
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO


    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO
    End Sub

    Function IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO(ByVal TIPO As Integer, ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PRE As Integer, ByVal ID_CF As Integer) As E_List_wDict
        Dim List_In As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO)
        Dim List_Out As New E_List_wDict

        List_In = DD_Data.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO(TIPO, DESDE, HASTA, ID_PRE, ID_CF)
        Dim Pairs As New Dictionary(Of String, Long)

        For Each etiq In List_In
            Dim strKey As String = "[" & etiq.CB_DESC & "]" & " - " & etiq.T_MUESTRA_DESC

            If (Pairs.Keys.Contains(strKey) = False) Then
                Pairs.Item(strKey) = 0
            End If
        Next

        'For Each etiq In List_In
        '    Dim strKey As String = "[" & etiq.CB_DESC & "]" & " - " & etiq.T_MUESTRA_DESC                  'PARA CONTAR TODOS LOS EXAMENES

        '    Pairs.Item(strKey) += 1
        'Next

        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""
        Dim ate_muestra_comparador As String = ""

        For i = 0 To List_In.Count - 1
            Dim strKey As String = "[" & List_In(i).CB_DESC & "]" & " - " & List_In(i).T_MUESTRA_DESC
            If i = 0 Then

                Pairs.Item(strKey) += 1

                cb_desc_comparador = List_In(i).CB_DESC
                ate_num_comparador = List_In(i).ATE_NUM
                ate_muestra_comparador = List_In(i).T_MUESTRA_DESC
            ElseIf ((((i > 0) And (List_In(i).CB_DESC <> cb_desc_comparador))) Or List_In(i).ATE_NUM <> ate_num_comparador Or List_In(i).T_MUESTRA_DESC <> ate_muestra_comparador) Then
                Pairs.Item(strKey) += 1

                cb_desc_comparador = List_In(i).CB_DESC
                ate_num_comparador = List_In(i).ATE_NUM
                ate_muestra_comparador = List_In(i).T_MUESTRA_DESC
            End If
        Next i

        List_Out.List_Data = List_In
        List_Out.Dictionary = Pairs

        Return List_Out

    End Function
    Function IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO_4(ByVal TIPO As Integer, ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PRE As Integer, ByVal ID_CF As Integer) As E_List_wDict
        Dim List_In As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO)
        Dim List_Out As New E_List_wDict

        List_In = DD_Data.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO_4(TIPO, DESDE, HASTA, ID_PRE, ID_CF)
        Dim Pairs As New Dictionary(Of String, Long)

        For Each etiq In List_In
            Dim strKey As String = "[" & etiq.CB_DESC & "]" & " - " & etiq.T_MUESTRA_DESC

            If (Pairs.Keys.Contains(strKey) = False) Then
                Pairs.Item(strKey) = 0
            End If
        Next

        'For Each etiq In List_In
        '    Dim strKey As String = "[" & etiq.CB_DESC & "]" & " - " & etiq.T_MUESTRA_DESC                  'PARA CONTAR TODOS LOS EXAMENES

        '    Pairs.Item(strKey) += 1
        'Next

        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""
        Dim ate_muestra_comparador As String = ""

        For i = 0 To List_In.Count - 1
            Dim strKey As String = "[" & List_In(i).CB_DESC & "]" & " - " & List_In(i).T_MUESTRA_DESC
            If i = 0 Then

                Pairs.Item(strKey) += 1

                cb_desc_comparador = List_In(i).CB_DESC
                ate_num_comparador = List_In(i).ATE_NUM
                ate_muestra_comparador = List_In(i).T_MUESTRA_DESC
            ElseIf ((((i > 0) And (List_In(i).CB_DESC <> cb_desc_comparador))) Or List_In(i).ATE_NUM <> ate_num_comparador Or List_In(i).T_MUESTRA_DESC <> ate_muestra_comparador) Then
                Pairs.Item(strKey) += 1

                cb_desc_comparador = List_In(i).CB_DESC
                ate_num_comparador = List_In(i).ATE_NUM
                ate_muestra_comparador = List_In(i).T_MUESTRA_DESC
            End If
        Next i

        List_Out.List_Data = List_In
        List_Out.Dictionary = Pairs

        Return List_Out

    End Function

    Function IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO_NORMAL(ByVal TIPO As Integer, ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PRE As Integer, ByVal ID_CF As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO)

        Return DD_Data.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO_NORMAL(TIPO, DESDE, HASTA, ID_PRE, ID_CF)

    End Function
    Function IRIS_WEBF_BUSCA_ESTADO_ENVIO_AVIS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PRO As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO)

        Return DD_Data.IRIS_WEBF_BUSCA_ESTADO_ENVIO_AVIS(DESDE, HASTA, ID_PRO)

    End Function
    Function IRIS_WEBF_LIS_TOT_EXAMS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PRO As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO)

        Return DD_Data.IRIS_WEBF_LIS_TOT_EXAMS(DESDE, HASTA, ID_PRO)

    End Function

    Function IRIS_WEBF_LIS_TOT_EXAMS_2(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PRO As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO)

        Return DD_Data.IRIS_WEBF_LIS_TOT_EXAMS_2(DESDE, HASTA, ID_PRO)

    End Function
    Function IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO_4_POR_TUBO(ByVal TIPO As Integer, ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PRE As Integer, ByVal ID_CF As String) As E_List_wDict
        Dim List_In As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO)
        Dim List_Out As New E_List_wDict

        List_In = DD_Data.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO_4_POR_TUBO(TIPO, DESDE, HASTA, ID_PRE, ID_CF)
        Dim Pairs As New Dictionary(Of String, Long)

        For Each etiq In List_In
            Dim strKey As String = "[" & etiq.CB_DESC & "]" & " - " & etiq.T_MUESTRA_DESC

            If (Pairs.Keys.Contains(strKey) = False) Then
                Pairs.Item(strKey) = 0
            End If
        Next

        'For Each etiq In List_In
        '    Dim strKey As String = "[" & etiq.CB_DESC & "]" & " - " & etiq.T_MUESTRA_DESC                  'PARA CONTAR TODOS LOS EXAMENES

        '    Pairs.Item(strKey) += 1
        'Next

        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""
        Dim ate_muestra_comparador As String = ""

        For i = 0 To List_In.Count - 1
            Dim strKey As String = "[" & List_In(i).CB_DESC & "]" & " - " & List_In(i).T_MUESTRA_DESC
            If i = 0 Then

                Pairs.Item(strKey) += 1

                cb_desc_comparador = List_In(i).CB_DESC
                ate_num_comparador = List_In(i).ATE_NUM
                ate_muestra_comparador = List_In(i).T_MUESTRA_DESC
            ElseIf ((((i > 0) And (List_In(i).CB_DESC <> cb_desc_comparador))) Or List_In(i).ATE_NUM <> ate_num_comparador Or List_In(i).T_MUESTRA_DESC <> ate_muestra_comparador) Then
                Pairs.Item(strKey) += 1

                cb_desc_comparador = List_In(i).CB_DESC
                ate_num_comparador = List_In(i).ATE_NUM
                ate_muestra_comparador = List_In(i).T_MUESTRA_DESC
            End If
        Next i

        List_Out.List_Data = List_In
        List_Out.Dictionary = Pairs

        Return List_Out

    End Function

    Function PDFF(ByVal DOMAIN_URL As String,
                  ByVal TIPO As Integer,
                  ByVal DESDE As String,
                  ByVal HASTA As String,
                    ByVal ID_PRE As Integer,
                    ByVal ID_CF As Integer) As String


        Dim data_det_ate As E_List_wDict
        Dim NN_Det_Ate As N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO = New N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO
        Dim list_definitiva As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO)
        Dim Item_definitivo As E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO


        Dim indice_if As Integer = 0
        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""
        Dim muestra_comparador As String = ""

        data_det_ate = NN_Det_Ate.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO_4(TIPO, DESDE, HASTA, ID_PRE, ID_CF)

        If (data_det_ate.List_Data.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim contador_saber_cantidad_filas As Integer = 0
        For Each List_Data As E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO In data_det_ate.List_Data
            Item_definitivo = New E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO

            If (indice_if = 0) Then
                indice_if += 1
                Item_definitivo.ATE_NUM = List_Data.ATE_NUM
                Item_definitivo.ATE_NUM_INTERNO = List_Data.ATE_NUM_INTERNO
                Item_definitivo.PAC_NOMBRE = List_Data.PAC_NOMBRE
                Item_definitivo.PAC_APELLIDO = List_Data.PAC_APELLIDO
                Item_definitivo.ATE_AÑO = List_Data.ATE_AÑO
                Item_definitivo.ENVIO_ETI_FECHA = List_Data.ENVIO_ETI_FECHA
                Item_definitivo.ATE_FECHA = List_Data.ATE_FECHA
                Item_definitivo.PROC_DESC = List_Data.PROC_DESC
                Item_definitivo.CB_DESC = List_Data.CB_DESC
                Item_definitivo.T_MUESTRA_DESC = List_Data.T_MUESTRA_DESC
                Item_definitivo.EST_DESCRIPCION = List_Data.EST_DESCRIPCION

                list_definitiva.Add(Item_definitivo)

                cb_desc_comparador = List_Data.CB_DESC
                ate_num_comparador = List_Data.ATE_NUM
                muestra_comparador = List_Data.T_MUESTRA_DESC

            ElseIf ((((indice_if > 0) And (List_Data.CB_DESC <> cb_desc_comparador))) Or List_Data.ATE_NUM <> ate_num_comparador Or muestra_comparador <> List_Data.T_MUESTRA_DESC) Then
                Item_definitivo.ATE_NUM = List_Data.ATE_NUM
                Item_definitivo.ATE_NUM_INTERNO = List_Data.ATE_NUM_INTERNO
                Item_definitivo.PAC_NOMBRE = List_Data.PAC_NOMBRE
                Item_definitivo.PAC_APELLIDO = List_Data.PAC_APELLIDO
                Item_definitivo.ATE_AÑO = List_Data.ATE_AÑO
                Item_definitivo.ENVIO_ETI_FECHA = List_Data.ENVIO_ETI_FECHA
                Item_definitivo.ATE_FECHA = List_Data.ATE_FECHA
                Item_definitivo.PROC_DESC = List_Data.PROC_DESC
                Item_definitivo.CB_DESC = List_Data.CB_DESC
                Item_definitivo.T_MUESTRA_DESC = List_Data.T_MUESTRA_DESC
                Item_definitivo.EST_DESCRIPCION = List_Data.EST_DESCRIPCION

                list_definitiva.Add(Item_definitivo)

                cb_desc_comparador = List_Data.CB_DESC
                ate_num_comparador = List_Data.ATE_NUM
                muestra_comparador = List_Data.T_MUESTRA_DESC
            End If
        Next

        'Nombre del archivo
        Dim FileName_str As String = "IRISPDFDERIVADOS\Estados_de_Examenes_Por_Tubos" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss")

        'Declaraciones
        Dim PDF As New PdfManager
        Dim DOC = PDF.CreateDocument

        Dim FONT_1 = DOC.Fonts("Times-Roman")
        Dim FONT_2 = DOC.Fonts("Times-Bold")

        'Creacion del documento
        PDF = Server.CreateObject("Persits.Pdf")
        DOC.Title = "Estados de Exámenes por Tubos"
        DOC.Creator = "IrisLab_Osorno"
        DOC.Author = "IrisLab_Osorno"



        Dim eje_y As Integer = 700

        Dim contador_filas As Integer = 1
        If list_definitiva.Count <= 41 Then

            Dim PAGE_1 = DOC.Pages.Add(612, 792)

            With PAGE_1.Canvas

                .SetFillColor(0, 0, 0)
                .DrawText("Estados de Exámenes por Tubos", STR_PARAM(140, 780, 300, "center", 20), FONT_2)
                .DrawText("Desde: " & DESDE, STR_PARAM(40, 760, 300, "center", 16), FONT_2)
                .DrawText("Hasta: " & HASTA, STR_PARAM(240, 760, 300, "center", 16), FONT_2)

                .DrawText("#", STR_PARAM(15, 720, 15, "left", 9), FONT_2)
                .DrawText("N° Aten.", STR_PARAM(30, 720, 50, "left", 9), FONT_2)
                .DrawText("N° Interno", STR_PARAM(80, 720, 50, "left", 9), FONT_2)
                .DrawText("Nombre Paciente", STR_PARAM(130, 720, 120, "left", 9), FONT_2)
                .DrawText("Edad", STR_PARAM(260, 720, 30, "left", 9), FONT_2)
                .DrawText("Fecha Ate.", STR_PARAM(300, 720, 30, "left", 9), FONT_2)
                .DrawText("Fecha Env.", STR_PARAM(330, 720, 30, "left", 9), FONT_2)
                .DrawText("Lugar TM", STR_PARAM(370, 720, 100, "left", 9), FONT_2)
                .DrawText("Etiqueta", STR_PARAM(465, 720, 70, "left", 9), FONT_2)
                .DrawText("Estado", STR_PARAM(540, 720, 176, "left", 9), FONT_2)

                For i = 0 To (list_definitiva.Count - 1)

                    .DrawText(contador_filas, STR_PARAM(15, eje_y, 15, "left", 8), FONT_2)
                    .DrawText(list_definitiva(i).ATE_NUM, STR_PARAM(30, eje_y, 50, "left", 7), FONT_1)
                    .DrawText(list_definitiva(i).ATE_NUM_INTERNO, STR_PARAM(80, eje_y, 50, "left", 7), FONT_1)
                    .DrawText(list_definitiva(i).PAC_NOMBRE & " " & list_definitiva(i).PAC_APELLIDO, STR_PARAM(130, eje_y, 120, "left", 7), FONT_1)
                    .DrawText(list_definitiva(i).ATE_AÑO, STR_PARAM(265, eje_y, 30, "left", 7), FONT_1)
                    .DrawText(Format(list_definitiva(i).ATE_FECHA, "dd/MM/yyyy hh:mm"), STR_PARAM(295, eje_y, 33, "left", 6), FONT_1)
                    .DrawText(Format(list_definitiva(i).ENVIO_ETI_FECHA, "dd/MM/yyyy hh:mm"), STR_PARAM(330, eje_y, 30, "left", 6), FONT_1)
                    .DrawText(list_definitiva(i).PROC_DESC, STR_PARAM(370, eje_y, 100, "left", 6), FONT_1)
                    .DrawText("[" & list_definitiva(i).CB_DESC & "]" & " - " & list_definitiva(i).T_MUESTRA_DESC, STR_PARAM(460, eje_y, 70, "left", 7), FONT_1)
                    .DrawText(list_definitiva(i).EST_DESCRIPCION, STR_PARAM(540, eje_y, 176, "left", 7), FONT_1)

                    eje_y = eje_y - 17
                    contador_filas += 1

                Next i
            End With
        Else

            Dim z = 0
            Dim i As Integer = 0

            eje_y = 700

            Dim fuck = DOC.Pages.Add(612, 792)

            With fuck.Canvas
                For z = z To list_definitiva.Count - 1
                    If i = 0 Then

                        .SetFillColor(0, 0, 0)
                        .DrawText("Estados de Exámenes por Tubos", STR_PARAM(140, 780, 300, "center", 20), FONT_2)
                        .DrawText("Desde: " & DESDE, STR_PARAM(40, 760, 300, "center", 16), FONT_2)
                        .DrawText("Hasta: " & HASTA, STR_PARAM(240, 760, 300, "center", 16), FONT_2)

                        .DrawText("#", STR_PARAM(15, 720, 15, "left", 9), FONT_2)
                        .DrawText("N° Aten.", STR_PARAM(30, 720, 50, "left", 9), FONT_2)
                        .DrawText("N° Interno", STR_PARAM(80, 720, 50, "left", 9), FONT_2)
                        .DrawText("Nombre Paciente", STR_PARAM(130, 720, 120, "left", 9), FONT_2)
                        .DrawText("Edad", STR_PARAM(260, 720, 30, "left", 9), FONT_2)
                        .DrawText("Fecha Ate.", STR_PARAM(300, 720, 30, "left", 9), FONT_2)
                        .DrawText("Fecha Env.", STR_PARAM(330, 720, 30, "left", 9), FONT_2)
                        .DrawText("Lugar TM", STR_PARAM(370, 720, 100, "left", 9), FONT_2)
                        .DrawText("Etiqueta", STR_PARAM(465, 720, 70, "left", 9), FONT_2)
                        .DrawText("Estado", STR_PARAM(540, 720, 176, "left", 9), FONT_2)

                        .DrawText(contador_filas, STR_PARAM(15, eje_y, 15, "left", 8), FONT_2)
                        .DrawText(list_definitiva(z).ATE_NUM, STR_PARAM(30, eje_y, 50, "left", 7), FONT_1)
                        .DrawText(list_definitiva(z).ATE_NUM_INTERNO, STR_PARAM(80, eje_y, 50, "left", 7), FONT_1)
                        .DrawText(list_definitiva(z).PAC_NOMBRE & " " & list_definitiva(z).PAC_APELLIDO, STR_PARAM(130, eje_y, 120, "left", 7), FONT_1)
                        .DrawText(list_definitiva(z).ATE_AÑO, STR_PARAM(265, eje_y, 30, "left", 7), FONT_1)
                        .DrawText(Format(list_definitiva(z).ATE_FECHA, "dd/MM/yyyy hh:mm"), STR_PARAM(295, eje_y, 33, "left", 6), FONT_1)
                        .DrawText(Format(list_definitiva(z).ENVIO_ETI_FECHA, "dd/MM/yyyy hh:mm"), STR_PARAM(330, eje_y, 30, "left", 6), FONT_1)
                        .DrawText(list_definitiva(z).PROC_DESC, STR_PARAM(370, eje_y, 100, "left", 6), FONT_1)
                        .DrawText("[" & list_definitiva(z).CB_DESC & "]" & " - " & list_definitiva(z).T_MUESTRA_DESC, STR_PARAM(460, eje_y, 70, "left", 7), FONT_1)
                        .DrawText(list_definitiva(z).EST_DESCRIPCION, STR_PARAM(540, eje_y, 176, "left", 7), FONT_1)

                        eje_y = eje_y - 17
                        contador_filas += 1
                        i = 1

                    Else
                        If z <> 0 Then
                            If z Mod 41 = 0 Then

                                fuck = DOC.Pages.Add(612, 792)
                                eje_y = 750

                            End If
                        End If
                        With fuck.Canvas
                            .DrawText(contador_filas, STR_PARAM(15, eje_y, 15, "left", 8), FONT_2)
                            .DrawText(list_definitiva(z).ATE_NUM, STR_PARAM(30, eje_y, 50, "left", 7), FONT_1)
                            .DrawText(list_definitiva(z).ATE_NUM_INTERNO, STR_PARAM(80, eje_y, 50, "left", 7), FONT_1)
                            .DrawText(list_definitiva(z).PAC_NOMBRE & " " & list_definitiva(z).PAC_APELLIDO, STR_PARAM(130, eje_y, 120, "left", 7), FONT_1)
                            .DrawText(list_definitiva(z).ATE_AÑO, STR_PARAM(265, eje_y, 30, "left", 7), FONT_1)
                            .DrawText(Format(list_definitiva(z).ATE_FECHA, "dd/MM/yyyy hh:mm"), STR_PARAM(295, eje_y, 33, "left", 6), FONT_1)
                            .DrawText(Format(list_definitiva(z).ENVIO_ETI_FECHA, "dd/MM/yyyy hh:mm"), STR_PARAM(330, eje_y, 30, "left", 6), FONT_1)
                            .DrawText(list_definitiva(z).PROC_DESC, STR_PARAM(370, eje_y, 100, "left", 6), FONT_1)
                            .DrawText("[" & list_definitiva(z).CB_DESC & "]" & " - " & list_definitiva(z).T_MUESTRA_DESC, STR_PARAM(460, eje_y, 70, "left", 7), FONT_1)
                            .DrawText(list_definitiva(z).EST_DESCRIPCION, STR_PARAM(540, eje_y, 176, "left", 7), FONT_1)
                            eje_y = eje_y - 17
                            contador_filas += 1
                        End With
                    End If
                Next z
            End With
        End If

        Dim super_sumador = 0
        Dim PAGE_TOTALES = DOC.Pages.Add(612, 792)

        With PAGE_TOTALES.Canvas
            eje_y = 720
            contador_filas = 1

            .DrawText("TOTALES", STR_PARAM(140, 780, 300, "center", 20), FONT_2)
            .DrawText("#", STR_PARAM(15, 740, 15, "left", 9), FONT_2)
            .DrawText("Etiqueta", STR_PARAM(200, 740, 70, "left", 9), FONT_2)
            .DrawText("TOTAL", STR_PARAM(530, 740, 176, "left", 9), FONT_2)

            For Each key In data_det_ate.Dictionary.Keys
                .DrawText(contador_filas, STR_PARAM(15, eje_y, 15, "left", 8), FONT_2)
                .DrawText(key, STR_PARAM(200, eje_y, 70, "left", 7), FONT_1)
                .DrawText(data_det_ate.Dictionary.Item(key), STR_PARAM(540, eje_y, 15, "left", 8), FONT_2)

                eje_y = eje_y - 17
                contador_filas += 1
                super_sumador += data_det_ate.Dictionary.Item(key)
            Next

            .DrawText("TOTAL", STR_PARAM(15, eje_y, 176, "left", 9), FONT_2)
            .DrawText(super_sumador, STR_PARAM(540, eje_y, 15, "left", 8), FONT_2)

        End With

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "PDF\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".pdf"

        'Devolver la url del archivo generado
        Dim Filename = DOC.Save(Ruta_save_local & Relative_Path, True)
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function

    Function PDFF_TUBO(ByVal DOMAIN_URL As String,
                  ByVal NUMLOTE As Integer) As String

        Dim data_det_ate As E_List_wDict2
        Dim NN_Det_Ate As N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO = New N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO
        Dim list_definitiva As New List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)
        Dim Item_definitivo As E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO


        Dim indice_if As Integer = 0
        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""
        Dim muestra_comparador As String = ""

        data_det_ate = NN_Det_Ate.IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO_3(NUMLOTE)

        If (data_det_ate.List_Data.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim contador_saber_cantidad_filas As Integer = 0
        For Each List_Data As E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO In data_det_ate.List_Data
            Item_definitivo = New E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO

            If (indice_if = 0) Then
                indice_if += 1
                Item_definitivo.ATE_NUM = List_Data.ATE_NUM
                Item_definitivo.ATE_NUM_INTERNO = List_Data.ATE_NUM_INTERNO
                Item_definitivo.PAC_NOMBRE = List_Data.PAC_NOMBRE
                Item_definitivo.PAC_APELLIDO = List_Data.PAC_APELLIDO
                Item_definitivo.ATE_AÑO = List_Data.ATE_AÑO
                Item_definitivo.ATE_FECHA = List_Data.ATE_FECHA
                Item_definitivo.ENVIO_ETI_FECHA = List_Data.ENVIO_ETI_FECHA
                Item_definitivo.PROC_DESC = List_Data.PROC_DESC
                Item_definitivo.CB_DESC = List_Data.CB_DESC
                Item_definitivo.T_MUESTRA_DESC = List_Data.T_MUESTRA_DESC
                Item_definitivo.EST_DESCRIPCION = List_Data.EST_DESCRIPCION
                Item_definitivo.ENVIO_NUM = List_Data.ENVIO_NUM
                Item_definitivo.ATE_OBS_TM = List_Data.ATE_OBS_TM
                Item_definitivo.PAC_RUT = List_Data.PAC_RUT
                Item_definitivo.PAC_DNI = List_Data.PAC_DNI

                list_definitiva.Add(Item_definitivo)

                cb_desc_comparador = List_Data.CB_DESC
                ate_num_comparador = List_Data.ATE_NUM
                muestra_comparador = List_Data.T_MUESTRA_DESC

            ElseIf ((((indice_if > 0) And (List_Data.CB_DESC <> cb_desc_comparador))) Or List_Data.ATE_NUM <> ate_num_comparador Or List_Data.T_MUESTRA_DESC <> muestra_comparador) Then
                Item_definitivo.ATE_NUM = List_Data.ATE_NUM
                Item_definitivo.ATE_NUM_INTERNO = List_Data.ATE_NUM_INTERNO
                Item_definitivo.PAC_NOMBRE = List_Data.PAC_NOMBRE
                Item_definitivo.PAC_APELLIDO = List_Data.PAC_APELLIDO
                Item_definitivo.ATE_AÑO = List_Data.ATE_AÑO
                Item_definitivo.ATE_FECHA = List_Data.ATE_FECHA
                Item_definitivo.ENVIO_ETI_FECHA = List_Data.ENVIO_ETI_FECHA
                Item_definitivo.PROC_DESC = List_Data.PROC_DESC
                Item_definitivo.CB_DESC = List_Data.CB_DESC
                Item_definitivo.T_MUESTRA_DESC = List_Data.T_MUESTRA_DESC
                Item_definitivo.EST_DESCRIPCION = List_Data.EST_DESCRIPCION
                Item_definitivo.ENVIO_NUM = List_Data.ENVIO_NUM
                Item_definitivo.ATE_OBS_TM = List_Data.ATE_OBS_TM
                Item_definitivo.PAC_RUT = List_Data.PAC_RUT
                Item_definitivo.PAC_DNI = List_Data.PAC_DNI

                list_definitiva.Add(Item_definitivo)

                cb_desc_comparador = List_Data.CB_DESC
                ate_num_comparador = List_Data.ATE_NUM
                muestra_comparador = List_Data.T_MUESTRA_DESC
            End If
        Next

        'Nombre del archivo
        Dim FileName_str As String = "IRISPDFDERIVADOS\Estados_de_Examenes_Por_Lote" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss")

        'Declaraciones
        Dim PDF As New PdfManager
        Dim DOC = PDF.CreateDocument

        Dim FONT_1 = DOC.Fonts("Times-Roman")
        Dim FONT_2 = DOC.Fonts("Times-Bold")

        'Creacion del documento
        PDF = Server.CreateObject("Persits.Pdf")
        DOC.Title = "Estados de Exámenes por Lote"
        DOC.Creator = "IrisLab_Osorno"
        DOC.Author = "IrisLab_Osorno"

        Dim eje_y As Integer = 700

        Dim contador_1 As Integer = 1
        Dim contador_2 As Integer = 2

        Dim contador_filas As Integer = 1
        If list_definitiva.Count <= 41 Then

            Dim PAGE_1 = DOC.Pages.Add(612, 792)

            With PAGE_1.Canvas

                .SetFillColor(0, 0, 0)
                .DrawText("Estados de Exámenes por Lote", STR_PARAM(140, 780, 300, "center", 20), FONT_2)

                .DrawText("Página " & contador_1 & " / " & contador_2, STR_PARAM(10, 780, 100, "left", 6), FONT_1)
                contador_1 += 1

                .DrawBarcode(list_definitiva(0).ENVIO_NUM, "x=460, y=758, height=20, width=100, type=22, AddCheck=true, Compress=true") ' Barcode
                .DrawText(list_definitiva(0).ENVIO_NUM, STR_PARAM(507, 758, 100, "left", 8), FONT_1)

                .DrawText("#", STR_PARAM(10, 720, 15, "left", 9), FONT_2)
                .DrawText("N° Aten.", STR_PARAM(28, 720, 50, "left", 9), FONT_2)
                .DrawText("N° Inter.", STR_PARAM(70, 720, 30, "left", 8), FONT_2)
                .DrawText("Rut/DNI", STR_PARAM(95, 720, 55, "left", 9), FONT_2)
                .DrawText("Nombre Paciente", STR_PARAM(145, 720, 120, "left", 9), FONT_2)
                .DrawText("Edad", STR_PARAM(270, 720, 30, "left", 9), FONT_2)
                .DrawText("Fecha Ate.", STR_PARAM(305, 720, 30, "left", 9), FONT_2)
                .DrawText("Fecha Env.", STR_PARAM(335, 720, 30, "left", 9), FONT_2)
                .DrawText("Lugar TM", STR_PARAM(365, 720, 100, "left", 9), FONT_2)
                .DrawText("Etiqueta", STR_PARAM(465, 720, 70, "left", 8), FONT_2)
                .DrawText("Estado", STR_PARAM(530, 720, 39, "left", 8), FONT_2)
                .DrawText("Obs.", STR_PARAM(570, 720, 176, "left", 8), FONT_2)

                For i = 0 To (list_definitiva.Count - 1)

                    .DrawText(contador_filas, STR_PARAM(10, eje_y, 15, "left", 8), FONT_2)
                    .DrawText(list_definitiva(i).ATE_NUM, STR_PARAM(28, eje_y, 50, "left", 7), FONT_1)
                    .DrawText(list_definitiva(i).ATE_NUM_INTERNO, STR_PARAM(70, eje_y, 30, "left", 6), FONT_1)

                    If list_definitiva(i).PAC_RUT = "" Then
                        .DrawText(list_definitiva(i).PAC_DNI, STR_PARAM(95, eje_y, 35, "left", 6), FONT_1)
                    Else
                        .DrawText(list_definitiva(i).PAC_RUT, STR_PARAM(95, eje_y, 35, "left", 6), FONT_1)
                    End If

                    .DrawText(list_definitiva(i).PAC_NOMBRE & " " & list_definitiva(i).PAC_APELLIDO, STR_PARAM(145, eje_y, 120, "left", 7), FONT_1)
                    .DrawText(list_definitiva(i).ATE_AÑO, STR_PARAM(275, eje_y, 30, "left", 7), FONT_1)
                    .DrawText(Format(list_definitiva(i).ATE_FECHA, "dd/MM/yyyy HH:mm"), STR_PARAM(300, eje_y, 33, "left", 6), FONT_1)
                    .DrawText(Format(list_definitiva(i).ENVIO_ETI_FECHA, "dd/MM/yyyy HH:mm"), STR_PARAM(335, eje_y, 30, "left", 6), FONT_1)
                    .DrawText(list_definitiva(i).PROC_DESC, STR_PARAM(370, eje_y, 100, "left", 6), FONT_1)
                    .DrawText("[" & list_definitiva(i).CB_DESC & "]" & " - " & list_definitiva(i).T_MUESTRA_DESC, STR_PARAM(460, eje_y, 70, "left", 6), FONT_1)
                    .DrawText(list_definitiva(i).EST_DESCRIPCION, STR_PARAM(530, eje_y, 39, "left", 5), FONT_1)
                    .DrawText(list_definitiva(i).ATE_OBS_TM, STR_PARAM(565, eje_y, 30, "left", 5), FONT_1)

                    eje_y = eje_y - 17
                    contador_filas += 1

                Next i
            End With
        Else

            Dim z = 0
            Dim i As Integer = 0

            contador_2 = (list_definitiva.Count / 41)
            contador_2 += 1
            eje_y = 700

            Dim fuck = DOC.Pages.Add(612, 792)
            Dim kkkkkk As Integer = 0
            With fuck.Canvas
                For z = z To list_definitiva.Count - 1
                    If i = 0 Then

                        .SetFillColor(0, 0, 0)
                        .DrawText("Estados de Exámenes por Lote", STR_PARAM(140, 780, 300, "center", 20), FONT_2)

                        .DrawText("Página " & contador_1 & " / " & contador_2, STR_PARAM(10, 780, 100, "left", 6), FONT_1)
                        contador_1 += 1

                        .DrawBarcode(list_definitiva(0).ENVIO_NUM, "x=460, y=758, height=20, width=100, type=22, AddCheck=true, Compress=true") ' Barcode
                        .DrawText(list_definitiva(0).ENVIO_NUM, STR_PARAM(507, 758, 100, "left", 8), FONT_1)

                        .DrawText("#", STR_PARAM(10, 720, 15, "left", 9), FONT_2)
                        .DrawText("N° Aten.", STR_PARAM(28, 720, 50, "left", 9), FONT_2)
                        .DrawText("N° Inter.", STR_PARAM(70, 720, 30, "left", 8), FONT_2)
                        .DrawText("Rut/DNI", STR_PARAM(95, 720, 55, "left", 9), FONT_2)
                        .DrawText("Nombre Paciente", STR_PARAM(145, 720, 120, "left", 9), FONT_2)
                        .DrawText("Edad", STR_PARAM(270, 720, 30, "left", 9), FONT_2)
                        .DrawText("Fecha Ate.", STR_PARAM(305, 720, 30, "left", 9), FONT_2)
                        .DrawText("Fecha Env.", STR_PARAM(335, 720, 30, "left", 9), FONT_2)
                        .DrawText("Lugar TM", STR_PARAM(365, 720, 100, "left", 9), FONT_2)
                        .DrawText("Etiqueta", STR_PARAM(465, 720, 70, "left", 8), FONT_2)
                        .DrawText("Estado", STR_PARAM(530, 720, 39, "left", 8), FONT_2)
                        .DrawText("Obs.", STR_PARAM(570, 720, 176, "left", 8), FONT_2)

                        .DrawText(contador_filas, STR_PARAM(10, eje_y, 15, "left", 8), FONT_2)
                        .DrawText(list_definitiva(z).ATE_NUM, STR_PARAM(28, eje_y, 50, "left", 7), FONT_1)
                        .DrawText(list_definitiva(z).ATE_NUM_INTERNO, STR_PARAM(70, eje_y, 30, "left", 6), FONT_1)

                        If list_definitiva(z).PAC_RUT = "" Then
                            .DrawText(list_definitiva(z).PAC_DNI, STR_PARAM(95, eje_y, 35, "left", 6), FONT_1)
                        Else
                            .DrawText(list_definitiva(z).PAC_RUT, STR_PARAM(95, eje_y, 35, "left", 6), FONT_1)
                        End If

                        .DrawText(list_definitiva(z).PAC_NOMBRE & " " & list_definitiva(z).PAC_APELLIDO, STR_PARAM(145, eje_y, 120, "left", 7), FONT_1)
                        .DrawText(list_definitiva(z).ATE_AÑO, STR_PARAM(275, eje_y, 30, "left", 7), FONT_1)
                        .DrawText(Format(list_definitiva(z).ATE_FECHA, "dd/MM/yyyy HH:mm"), STR_PARAM(300, eje_y, 33, "left", 6), FONT_1)
                        .DrawText(Format(list_definitiva(z).ENVIO_ETI_FECHA, "dd/MM/yyyy HH:mm"), STR_PARAM(335, eje_y, 30, "left", 6), FONT_1)
                        .DrawText(list_definitiva(z).PROC_DESC, STR_PARAM(370, eje_y, 100, "left", 6), FONT_1)
                        .DrawText("[" & list_definitiva(z).CB_DESC & "]" & " - " & list_definitiva(z).T_MUESTRA_DESC, STR_PARAM(460, eje_y, 70, "left", 6), FONT_1)
                        .DrawText(list_definitiva(z).EST_DESCRIPCION, STR_PARAM(530, eje_y, 39, "left", 5), FONT_1)
                        .DrawText(list_definitiva(z).ATE_OBS_TM, STR_PARAM(565, eje_y, 30, "left", 5), FONT_1)

                        eje_y = eje_y - 17
                            contador_filas += 1
                            i = 1
                            kkkkkk = 1

                        Else
                            If z <> 0 Then
                            If z Mod 41 = 0 Then
                                fuck = DOC.Pages.Add(612, 792)
                                eje_y = 750
                                kkkkkk = 0

                            End If
                        End If
                        With fuck.Canvas

                            If kkkkkk = 0 Then
                                .DrawBarcode(list_definitiva(0).ENVIO_NUM, "x=460, y=758, height=20, width=100, type=22, AddCheck=true, Compress=true") ' Barcode
                                .DrawText(list_definitiva(0).ENVIO_NUM, STR_PARAM(507, 758, 100, "left", 8), FONT_1)

                                .DrawText("Página " & contador_1 & " / " & contador_2, STR_PARAM(10, 780, 100, "left", 6), FONT_1)
                                contador_1 += 1

                                kkkkkk = 1
                            End If

                            .DrawText(contador_filas, STR_PARAM(10, eje_y, 15, "left", 8), FONT_2)
                            .DrawText(list_definitiva(z).ATE_NUM, STR_PARAM(28, eje_y, 50, "left", 7), FONT_1)
                            .DrawText(list_definitiva(z).ATE_NUM_INTERNO, STR_PARAM(70, eje_y, 30, "left", 6), FONT_1)

                            If list_definitiva(z).PAC_RUT = "" Then
                                .DrawText(list_definitiva(z).PAC_DNI, STR_PARAM(95, eje_y, 35, "left", 6), FONT_1)
                            Else
                                .DrawText(list_definitiva(z).PAC_RUT, STR_PARAM(95, eje_y, 35, "left", 6), FONT_1)
                            End If

                            .DrawText(list_definitiva(z).PAC_NOMBRE & " " & list_definitiva(z).PAC_APELLIDO, STR_PARAM(145, eje_y, 120, "left", 7), FONT_1)
                            .DrawText(list_definitiva(z).ATE_AÑO, STR_PARAM(275, eje_y, 30, "left", 7), FONT_1)
                            .DrawText(Format(list_definitiva(z).ATE_FECHA, "dd/MM/yyyy HH:mm"), STR_PARAM(300, eje_y, 33, "left", 6), FONT_1)
                            .DrawText(Format(list_definitiva(z).ENVIO_ETI_FECHA, "dd/MM/yyyy HH:mm"), STR_PARAM(335, eje_y, 30, "left", 6), FONT_1)
                            .DrawText(list_definitiva(z).PROC_DESC, STR_PARAM(370, eje_y, 100, "left", 6), FONT_1)
                            .DrawText("[" & list_definitiva(z).CB_DESC & "]" & " - " & list_definitiva(z).T_MUESTRA_DESC, STR_PARAM(460, eje_y, 70, "left", 6), FONT_1)
                            .DrawText(list_definitiva(z).EST_DESCRIPCION, STR_PARAM(530, eje_y, 39, "left", 5), FONT_1)
                            .DrawText(list_definitiva(z).ATE_OBS_TM, STR_PARAM(565, eje_y, 30, "left", 5), FONT_1)
                            eje_y = eje_y - 17
                            contador_filas += 1
                        End With
                    End If
                Next z
            End With
        End If

        Dim super_sumador = 0
        Dim PAGE_TOTALES = DOC.Pages.Add(612, 792)

        With PAGE_TOTALES.Canvas
            eje_y = 720
            contador_filas = 1

            .DrawBarcode(list_definitiva(0).ENVIO_NUM, "x=460, y=758, height=20, width=100, type=22, AddCheck=true, Compress=true") ' Barcode
            .DrawText(list_definitiva(0).ENVIO_NUM, STR_PARAM(507, 758, 100, "left", 8), FONT_1)

            .DrawText("Página " & contador_1 & " / " & contador_2, STR_PARAM(10, 780, 100, "left", 6), FONT_1)

            .DrawText("TOTALES", STR_PARAM(140, 780, 300, "center", 20), FONT_2)
            .DrawText("#", STR_PARAM(15, 740, 15, "left", 9), FONT_2)
            .DrawText("Etiqueta", STR_PARAM(200, 740, 70, "left", 9), FONT_2)
            .DrawText("TOTAL", STR_PARAM(530, 740, 176, "left", 9), FONT_2)

            For Each key In data_det_ate.Dictionary.Keys
                .DrawText(contador_filas, STR_PARAM(15, eje_y, 15, "left", 8), FONT_2)
                .DrawText(key, STR_PARAM(200, eje_y, 70, "left", 7), FONT_1)
                .DrawText(data_det_ate.Dictionary.Item(key), STR_PARAM(540, eje_y, 15, "left", 8), FONT_2)

                eje_y = eje_y - 17
                contador_filas += 1
                super_sumador += data_det_ate.Dictionary.Item(key)
            Next

            .DrawText("TOTAL", STR_PARAM(15, eje_y, 176, "left", 9), FONT_2)
            .DrawText(super_sumador, STR_PARAM(540, eje_y, 15, "left", 8), FONT_2)

        End With

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "PDF\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".pdf"

        'Devolver la url del archivo generado
        Dim Filename = DOC.Save(Ruta_save_local & Relative_Path, True)
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
    Function STR_PARAM(ByVal x As Single, ByVal y As Single, ByVal width As Single,
     ByVal alignment As String, ByVal size As Single) As String
        Dim PARAM_XX As String

        'Parámetros de la cadena
        PARAM_XX = ""
        PARAM_XX += "x=" & x & ";"                              'Posición x del cuadro de texto
        PARAM_XX += "y=" & y & ";"                              'Posición y del cuadro de texto
        PARAM_XX += "width=" & width & ";"                      'Ancho del cuadro de texto
        PARAM_XX += "alignment=" & alignment & ";"              'Alineación del cuadro de texto
        PARAM_XX += "size=" & size & ""                         'Tamaño de la fuente

        Return PARAM_XX
    End Function
    Function PDFF_tubaso(ByVal DOMAIN_URL As String,
              ByVal TIPO As Integer,
              ByVal DESDE As String,
              ByVal HASTA As String,
                ByVal ID_PRE As Integer,
                ByVal ID_CF As String) As String


        Dim data_det_ate As E_List_wDict
        Dim NN_Det_Ate As N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO = New N_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO
        Dim list_definitiva As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO)
        Dim Item_definitivo As E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO


        Dim indice_if As Integer = 0
        Dim cb_desc_comparador As String = ""
        Dim ate_num_comparador As String = ""
        Dim muestra_comparador As String = ""

        data_det_ate = NN_Det_Ate.IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO_4_POR_TUBO(TIPO, DESDE, HASTA, ID_PRE, ID_CF)

        If (data_det_ate.List_Data.Count = 0) Then
            Return Nothing
            Exit Function
        End If

        Dim contador_saber_cantidad_filas As Integer = 0
        For Each List_Data As E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO In data_det_ate.List_Data
            Item_definitivo = New E_IRIS_WEBF_BUSCA_ETIQUETAS_NO_RECEPCIONADA_Y_OTRAS_RVDR_2_2_ENVIO

            If (indice_if = 0) Then
                indice_if += 1
                Item_definitivo.ATE_NUM = List_Data.ATE_NUM
                Item_definitivo.ATE_NUM_INTERNO = List_Data.ATE_NUM_INTERNO
                Item_definitivo.PAC_NOMBRE = List_Data.PAC_NOMBRE
                Item_definitivo.PAC_APELLIDO = List_Data.PAC_APELLIDO
                Item_definitivo.ATE_AÑO = List_Data.ATE_AÑO
                Item_definitivo.ENVIO_ETI_FECHA = List_Data.ENVIO_ETI_FECHA
                Item_definitivo.ATE_FECHA = List_Data.ATE_FECHA
                Item_definitivo.PROC_DESC = List_Data.PROC_DESC
                Item_definitivo.CB_DESC = List_Data.CB_DESC
                Item_definitivo.T_MUESTRA_DESC = List_Data.T_MUESTRA_DESC
                Item_definitivo.EST_DESCRIPCION = List_Data.EST_DESCRIPCION

                list_definitiva.Add(Item_definitivo)

                cb_desc_comparador = List_Data.CB_DESC
                ate_num_comparador = List_Data.ATE_NUM
                muestra_comparador = List_Data.T_MUESTRA_DESC

            ElseIf ((((indice_if > 0) And (List_Data.CB_DESC <> cb_desc_comparador))) Or List_Data.ATE_NUM <> ate_num_comparador Or muestra_comparador <> List_Data.T_MUESTRA_DESC) Then
                Item_definitivo.ATE_NUM = List_Data.ATE_NUM
                Item_definitivo.ATE_NUM_INTERNO = List_Data.ATE_NUM_INTERNO
                Item_definitivo.PAC_NOMBRE = List_Data.PAC_NOMBRE
                Item_definitivo.PAC_APELLIDO = List_Data.PAC_APELLIDO
                Item_definitivo.ATE_AÑO = List_Data.ATE_AÑO
                Item_definitivo.ENVIO_ETI_FECHA = List_Data.ENVIO_ETI_FECHA
                Item_definitivo.ATE_FECHA = List_Data.ATE_FECHA
                Item_definitivo.PROC_DESC = List_Data.PROC_DESC
                Item_definitivo.CB_DESC = List_Data.CB_DESC
                Item_definitivo.T_MUESTRA_DESC = List_Data.T_MUESTRA_DESC
                Item_definitivo.EST_DESCRIPCION = List_Data.EST_DESCRIPCION

                list_definitiva.Add(Item_definitivo)

                cb_desc_comparador = List_Data.CB_DESC
                ate_num_comparador = List_Data.ATE_NUM
                muestra_comparador = List_Data.T_MUESTRA_DESC
            End If
        Next

        'Nombre del archivo
        Dim FileName_str As String = "IRISPDFDERIVADOS\Estados_de_Examenes_Por_Tubos" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss")

        'Declaraciones
        Dim PDF As New PdfManager
        Dim DOC = PDF.CreateDocument

        Dim FONT_1 = DOC.Fonts("Times-Roman")
        Dim FONT_2 = DOC.Fonts("Times-Bold")

        'Creacion del documento
        PDF = Server.CreateObject("Persits.Pdf")
        DOC.Title = "Estados de Exámenes por Tubos"
        DOC.Creator = "IrisLab_Osorno"
        DOC.Author = "IrisLab_Osorno"



        Dim eje_y As Integer = 700

        Dim contador_filas As Integer = 1
        If list_definitiva.Count <= 41 Then

            Dim PAGE_1 = DOC.Pages.Add(612, 792)

            With PAGE_1.Canvas

                .SetFillColor(0, 0, 0)
                .DrawText("Estados de Exámenes por Tubos", STR_PARAM(140, 780, 300, "center", 20), FONT_2)
                .DrawText("Desde: " & DESDE, STR_PARAM(40, 760, 300, "center", 16), FONT_2)
                .DrawText("Hasta: " & HASTA, STR_PARAM(240, 760, 300, "center", 16), FONT_2)

                .DrawText("#", STR_PARAM(15, 720, 15, "left", 9), FONT_2)
                .DrawText("N° Aten.", STR_PARAM(30, 720, 50, "left", 9), FONT_2)
                .DrawText("N° Interno", STR_PARAM(80, 720, 50, "left", 9), FONT_2)
                .DrawText("Nombre Paciente", STR_PARAM(130, 720, 120, "left", 9), FONT_2)
                .DrawText("Edad", STR_PARAM(260, 720, 30, "left", 9), FONT_2)
                .DrawText("Fecha Ate.", STR_PARAM(300, 720, 30, "left", 9), FONT_2)
                .DrawText("Fecha Env.", STR_PARAM(330, 720, 30, "left", 9), FONT_2)
                .DrawText("Lugar TM", STR_PARAM(370, 720, 100, "left", 9), FONT_2)
                .DrawText("Etiqueta", STR_PARAM(465, 720, 70, "left", 9), FONT_2)
                .DrawText("Estado", STR_PARAM(540, 720, 176, "left", 9), FONT_2)

                For i = 0 To (list_definitiva.Count - 1)

                    .DrawText(contador_filas, STR_PARAM(15, eje_y, 15, "left", 8), FONT_2)
                    .DrawText(list_definitiva(i).ATE_NUM, STR_PARAM(30, eje_y, 50, "left", 7), FONT_1)
                    .DrawText(list_definitiva(i).ATE_NUM_INTERNO, STR_PARAM(80, eje_y, 50, "left", 7), FONT_1)
                    .DrawText(list_definitiva(i).PAC_NOMBRE & " " & list_definitiva(i).PAC_APELLIDO, STR_PARAM(130, eje_y, 120, "left", 7), FONT_1)
                    .DrawText(list_definitiva(i).ATE_AÑO, STR_PARAM(265, eje_y, 30, "left", 7), FONT_1)
                    .DrawText(Format(list_definitiva(i).ATE_FECHA, "dd/MM/yyyy hh:mm"), STR_PARAM(295, eje_y, 33, "left", 6), FONT_1)
                    .DrawText(Format(list_definitiva(i).ENVIO_ETI_FECHA, "dd/MM/yyyy hh:mm"), STR_PARAM(330, eje_y, 30, "left", 6), FONT_1)
                    .DrawText(list_definitiva(i).PROC_DESC, STR_PARAM(370, eje_y, 100, "left", 6), FONT_1)
                    .DrawText("[" & list_definitiva(i).CB_DESC & "]" & " - " & list_definitiva(i).T_MUESTRA_DESC, STR_PARAM(460, eje_y, 70, "left", 7), FONT_1)
                    .DrawText(list_definitiva(i).EST_DESCRIPCION, STR_PARAM(540, eje_y, 176, "left", 7), FONT_1)

                    eje_y = eje_y - 17
                    contador_filas += 1

                Next i
            End With
        Else

            Dim z = 0
            Dim i As Integer = 0

            eje_y = 700

            Dim fuck = DOC.Pages.Add(612, 792)

            With fuck.Canvas
                For z = z To list_definitiva.Count - 1
                    If i = 0 Then

                        .SetFillColor(0, 0, 0)
                        .DrawText("Estados de Exámenes por Tubos", STR_PARAM(140, 780, 300, "center", 20), FONT_2)
                        .DrawText("Desde: " & DESDE, STR_PARAM(40, 760, 300, "center", 16), FONT_2)
                        .DrawText("Hasta: " & HASTA, STR_PARAM(240, 760, 300, "center", 16), FONT_2)

                        .DrawText("#", STR_PARAM(15, 720, 15, "left", 9), FONT_2)
                        .DrawText("N° Aten.", STR_PARAM(30, 720, 50, "left", 9), FONT_2)
                        .DrawText("N° Interno", STR_PARAM(80, 720, 50, "left", 9), FONT_2)
                        .DrawText("Nombre Paciente", STR_PARAM(130, 720, 120, "left", 9), FONT_2)
                        .DrawText("Edad", STR_PARAM(260, 720, 30, "left", 9), FONT_2)
                        .DrawText("Fecha Ate.", STR_PARAM(300, 720, 30, "left", 9), FONT_2)
                        .DrawText("Fecha Env.", STR_PARAM(330, 720, 30, "left", 9), FONT_2)
                        .DrawText("Lugar TM", STR_PARAM(370, 720, 100, "left", 9), FONT_2)
                        .DrawText("Etiqueta", STR_PARAM(465, 720, 70, "left", 9), FONT_2)
                        .DrawText("Estado", STR_PARAM(540, 720, 176, "left", 9), FONT_2)

                        .DrawText(contador_filas, STR_PARAM(15, eje_y, 15, "left", 8), FONT_2)
                        .DrawText(list_definitiva(z).ATE_NUM, STR_PARAM(30, eje_y, 50, "left", 7), FONT_1)
                        .DrawText(list_definitiva(z).ATE_NUM_INTERNO, STR_PARAM(80, eje_y, 50, "left", 7), FONT_1)
                        .DrawText(list_definitiva(z).PAC_NOMBRE & " " & list_definitiva(z).PAC_APELLIDO, STR_PARAM(130, eje_y, 120, "left", 7), FONT_1)
                        .DrawText(list_definitiva(z).ATE_AÑO, STR_PARAM(265, eje_y, 30, "left", 7), FONT_1)
                        .DrawText(Format(list_definitiva(z).ATE_FECHA, "dd/MM/yyyy hh:mm"), STR_PARAM(295, eje_y, 33, "left", 6), FONT_1)
                        .DrawText(Format(list_definitiva(z).ENVIO_ETI_FECHA, "dd/MM/yyyy hh:mm"), STR_PARAM(330, eje_y, 30, "left", 6), FONT_1)
                        .DrawText(list_definitiva(z).PROC_DESC, STR_PARAM(370, eje_y, 100, "left", 6), FONT_1)
                        .DrawText("[" & list_definitiva(z).CB_DESC & "]" & " - " & list_definitiva(z).T_MUESTRA_DESC, STR_PARAM(460, eje_y, 70, "left", 7), FONT_1)
                        .DrawText(list_definitiva(z).EST_DESCRIPCION, STR_PARAM(540, eje_y, 176, "left", 7), FONT_1)

                        eje_y = eje_y - 17
                        contador_filas += 1
                        i = 1

                    Else
                        If z <> 0 Then
                            If z Mod 41 = 0 Then

                                fuck = DOC.Pages.Add(612, 792)
                                eje_y = 750

                            End If
                        End If
                        With fuck.Canvas
                            .DrawText(contador_filas, STR_PARAM(15, eje_y, 15, "left", 8), FONT_2)
                            .DrawText(list_definitiva(z).ATE_NUM, STR_PARAM(30, eje_y, 50, "left", 7), FONT_1)
                            .DrawText(list_definitiva(z).ATE_NUM_INTERNO, STR_PARAM(80, eje_y, 50, "left", 7), FONT_1)
                            .DrawText(list_definitiva(z).PAC_NOMBRE & " " & list_definitiva(z).PAC_APELLIDO, STR_PARAM(130, eje_y, 120, "left", 7), FONT_1)
                            .DrawText(list_definitiva(z).ATE_AÑO, STR_PARAM(265, eje_y, 30, "left", 7), FONT_1)
                            .DrawText(Format(list_definitiva(z).ATE_FECHA, "dd/MM/yyyy hh:mm"), STR_PARAM(295, eje_y, 33, "left", 6), FONT_1)
                            .DrawText(Format(list_definitiva(z).ENVIO_ETI_FECHA, "dd/MM/yyyy hh:mm"), STR_PARAM(330, eje_y, 30, "left", 6), FONT_1)
                            .DrawText(list_definitiva(z).PROC_DESC, STR_PARAM(370, eje_y, 100, "left", 6), FONT_1)
                            .DrawText("[" & list_definitiva(z).CB_DESC & "]" & " - " & list_definitiva(z).T_MUESTRA_DESC, STR_PARAM(460, eje_y, 70, "left", 7), FONT_1)
                            .DrawText(list_definitiva(z).EST_DESCRIPCION, STR_PARAM(540, eje_y, 176, "left", 7), FONT_1)
                            eje_y = eje_y - 17
                            contador_filas += 1
                        End With
                    End If
                Next z
            End With
        End If

        Dim super_sumador = 0
        Dim PAGE_TOTALES = DOC.Pages.Add(612, 792)

        With PAGE_TOTALES.Canvas
            eje_y = 720
            contador_filas = 1

            .DrawText("TOTALES", STR_PARAM(140, 780, 300, "center", 20), FONT_2)
            .DrawText("#", STR_PARAM(15, 740, 15, "left", 9), FONT_2)
            .DrawText("Etiqueta", STR_PARAM(200, 740, 70, "left", 9), FONT_2)
            .DrawText("TOTAL", STR_PARAM(530, 740, 176, "left", 9), FONT_2)

            For Each key In data_det_ate.Dictionary.Keys
                .DrawText(contador_filas, STR_PARAM(15, eje_y, 15, "left", 8), FONT_2)
                .DrawText(key, STR_PARAM(200, eje_y, 70, "left", 7), FONT_1)
                .DrawText(data_det_ate.Dictionary.Item(key), STR_PARAM(540, eje_y, 15, "left", 8), FONT_2)

                eje_y = eje_y - 17
                contador_filas += 1
                super_sumador += data_det_ate.Dictionary.Item(key)
            Next

            .DrawText("TOTAL", STR_PARAM(15, eje_y, 176, "left", 9), FONT_2)
            .DrawText(super_sumador, STR_PARAM(540, eje_y, 15, "left", 8), FONT_2)

        End With

        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "PDF\" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".pdf"

        'Devolver la url del archivo generado
        Dim Filename = DOC.Save(Ruta_save_local & Relative_Path, True)
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
End Class


Public Class E_List_wDict
    Private EE_List_Data As IEnumerable(Of Object)
    Public Property List_Data() As IEnumerable(Of Object)
        Get
            Return EE_List_Data
        End Get
        Set(ByVal value As IEnumerable(Of Object))
            EE_List_Data = value
        End Set
    End Property

    Private EE_Dictionary As Dictionary(Of String, Long)
    Public Property Dictionary() As Dictionary(Of String, Long)
        Get
            Return EE_Dictionary
        End Get
        Set(ByVal value As Dictionary(Of String, Long))
            EE_Dictionary = value
        End Set
    End Property
End Class