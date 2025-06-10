Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class REP_LAB_CANT_EXA_ARE_SECC_2_2
    Inherits System.Web.UI.Page


    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable_REM(DESDE As String, HASTA As String) As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES)
        Dim N_REM As New N_IRIS_WEBF_BUSCA_CANT_EXAMENES

        Dim List_Data As List(Of E_IRIS_WEBF_BUSCA_CANT_EXAMENES) = N_REM.IRIS_WEBF_BUSCA_CANT_EXAMENES(DESDE, HASTA)

        If List_Data.Count > 0 Then
            Return List_Data
        Else
            Return Nothing
        End If

    End Function



    <Services.WebMethod()>
    Public Shared Function Llenar_Ddl() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim Data_Prev_Activo As New List(Of E_IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO)
        'Consultar por previsiones activas
        Data_Prev_Activo = NN_Activos.IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO
        If (Data_Prev_Activo.Count > 0) Then
            'Serializar a Json
            Serializer.Serialize(Data_Prev_Activo, str_Builder)
            Return str_Builder.ToString
        Else
            Return "null"
        End If
    End Function

    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable2(ByVal ID_CODIGO_FONASA As Long, ByVal DATE_str01 As String, ByVal DATE_str02 As String) As REEE_REM
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datos As String = ""
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Dim NN_Exam_one_exam As New N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Dim NN_Exam_exams_rem As New N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Dim NN_Exam_2 As New N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Data_agregados As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Data_Prev_one_exam As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Data_Prev_2 As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Data_exam_proc As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Data_exams_rem As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Lista_REEEEEEE As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        DATE_str01 = DATE_str01.Replace("-", "/")
        DATE_str02 = DATE_str02.Replace("-", "/")
        Dim Date_01 As Date = NN_Date.strToDate(Split(DATE_str01, "/")(2), Split(DATE_str01, "/")(1), Split(DATE_str01, "/")(0))
        Dim Date_02 As Date = NN_Date.strToDate(Split(DATE_str02, "/")(2), Split(DATE_str02, "/")(1), Split(DATE_str02, "/")(0))

        'Declaraciones internas
        Dim NN_LugarTM As New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        Dim Data_LugarTM As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Dim reeeeeee As New REEE_REM
        Data_LugarTM = NN_LugarTM.IRIS_WEBF_CMVM_BUSCA_PROCEDENCIA_ACTIVO_SIN_ID_USER()

        Data_exams_rem = NN_Exam_exams_rem.IRIS_WEBF_BUSCA_EXAMS_REM()

        If Data_exams_rem.Count > 0 Then
            For i = 0 To Data_exams_rem.Count - 1
                Data_Prev_one_exam = NN_Exam_one_exam.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_EXAMES_REM(Data_exams_rem(i).CF_COD, Date_01, Date_02)
                Dim item As E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
                If Data_Prev_one_exam.Count > 0 Then

                    item.TOTAL_ATE = Data_Prev_one_exam(0).TOTAL_ATE
                    item.CF_COD = Data_exams_rem(i).CF_COD
                    item.CF_DESC = Data_exams_rem(i).CF_DESC
                    item.ORDEN = Data_exams_rem(i).ORDEN
                    item.SECC_ALT_DESC = Data_exams_rem(i).SECC_ALT_DESC
                    item.ID_SECC_ALT = Data_exams_rem(i).ID_SECC_ALT
                    item.SECC_ORDEN = Data_exams_rem(i).SECC_ORDEN

                    Data_agregados.Add(item)
                Else
                    item.TOTAL_ATE = 0
                    item.CF_COD = Data_exams_rem(i).CF_COD
                    item.CF_DESC = Data_exams_rem(i).CF_DESC
                    item.ORDEN = Data_exams_rem(i).ORDEN
                    item.SECC_ALT_DESC = Data_exams_rem(i).SECC_ALT_DESC
                    item.ID_SECC_ALT = Data_exams_rem(i).ID_SECC_ALT
                    item.SECC_ORDEN = Data_exams_rem(i).SECC_ORDEN

                    Data_agregados.Add(item)
                End If

            Next i
        Else
        End If

        'End Select

        'ORDENARRRRRRRRR
        Lista_REEEEEEE = NN_Exam.Ordenar_REEEEE(Data_agregados)

        'For i = 0 To Lista_REEEEEEE.Count - 1
        '    For ii = 0 To 10 'Data_LugarTM.Count - 1
        '        Data_Prev_2 = NN_Exam_2.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_CADA_PROCE_2(Date_01, Date_02, Data_LugarTM(ii).ID_PROCEDENCIA, Lista_REEEEEEE(i).CF_COD)
        '        Dim Item As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

        '        If Data_Prev_2.Count > 0 Then
        '            Item.TOTAL_ATE = Data_Prev_2(0).TOTAL_ATE
        '            Item.PROC_DESC = Data_LugarTM(ii).PROC_DESC
        '            Item.ID_PROCEDENCIA = Data_LugarTM(ii).ID_PROCEDENCIA
        '        Else
        '            Item.TOTAL_ATE = 0
        '            Item.PROC_DESC = Data_LugarTM(ii).PROC_DESC
        '            Item.ID_PROCEDENCIA = Data_LugarTM(ii).ID_PROCEDENCIA
        '        End If
        '        Data_exam_proc.Add(Item)
        '    Next ii
        'Next i



        reeeeeee.proparra1 = Lista_REEEEEEE
        reeeeeee.proparra2 = Data_exam_proc


        Return reeeeeee
    End Function
    <Services.WebMethod()>
    Public Shared Function Llenar_DataTable(ByVal ID_CODIGO_FONASA As Long, ByVal DATE_str01 As String, ByVal DATE_str02 As String) As REEE_REM
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datos As String = ""
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Dim NN_Exam_2 As New N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Dim Data_Prev As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Data_Prev_2 As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Data_exam_proc As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Dim Lista_REEEEEEE As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        DATE_str01 = DATE_str01.Replace("-", "/")
        DATE_str02 = DATE_str02.Replace("-", "/")
        Dim Date_01 As Date = NN_Date.strToDate(Split(DATE_str01, "/")(2), Split(DATE_str01, "/")(1), Split(DATE_str01, "/")(0))
        Dim Date_02 As Date = NN_Date.strToDate(Split(DATE_str02, "/")(2), Split(DATE_str02, "/")(1), Split(DATE_str02, "/")(0))

        'Declaraciones internas
        Dim NN_LugarTM As New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        Dim Data_LugarTM As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Dim reeeeeee As New REEE_REM
        Data_LugarTM = NN_LugarTM.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()



        Data_Prev = NN_Exam.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO(ID_CODIGO_FONASA, Date_01, Date_02)

        If (Data_Prev.Count > 0) Then


            'Select Case Data_Prev(i).ID_CODIGO_FONASA
            'Case 2
            Dim xItem As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Adenograma, mielograma, c/u"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301003"
            xItem.ORDEN = 200
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Agregación plaquetaria con diferentes agonistas"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301006"
            xItem.ORDEN = 300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Tiempo de lisis del coágulo"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301013"
            xItem.ORDEN = 700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Prueba de antiglobulina directa"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301014"
            xItem.ORDEN = 800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Tiempo de lisis de euglobulinas"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301020"
            xItem.ORDEN = 1000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Test de neutralización plaquetaria"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301022"
            xItem.ORDEN = 1200
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Factor V"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301024"
            xItem.ORDEN = 1300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Factores VII, VIII, IX, X, XI, XII, XIII, c/u"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301025"
            xItem.ORDEN = 1400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Fierro, cinética del (cada determinación)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301030"
            xItem.ORDEN = 1900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Haptoglobina cuantitativa"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301035"
            xItem.ORDEN = 2100
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Hemoglobina fetal cuantitativa en eritrocitos"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301040"
            xItem.ORDEN = 2400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Electroforesis de hemoglobina"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301044"
            xItem.ORDEN = 2700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Hemosiderina medular"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301048"
            xItem.ORDEN = 2900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Cuantificación de heparina"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301049"
            xItem.ORDEN = 3000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Metahemoglobina"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301054"
            xItem.ORDEN = 3200
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Factor Von Willebrand antigénico Cofactor Ristocetina (FVW:CoRis)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301090"
            xItem.ORDEN = 4900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Estudio de la hemoglobinuria paroxística nocturna (HPN) por citometría de flujo"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301094"
            xItem.ORDEN = 5300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Dímero-D"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301095"
            xItem.ORDEN = 5400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Inhibidor de factor de la coagulación"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301097"
            xItem.ORDEN = 5600
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Secreción plaquetaria con diferentes agonistas"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301098"
            xItem.ORDEN = 5700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Tiempo de veneno de víbora de Russell diluído"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301099"
            xItem.ORDEN = 5800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Actividad anti-factor X activado"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301101"
            xItem.ORDEN = 6000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Tiempo de tromboplastina parcial activado (TTPA) con mezcla de plasma normal"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301102"
            xItem.ORDEN = 6100
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Mioglobina"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301103"
            xItem.ORDEN = 6200
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Tromboelastografia"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301104"
            xItem.ORDEN = 6300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Mutación JAK-2"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301105"
            xItem.ORDEN = 6400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Hematocrito automatizado (en contador hematológico)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301106"
            xItem.ORDEN = 6500
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Recuento de reticulocitos (absoluto o porcentual) automatizado"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301107"
            xItem.ORDEN = 6600
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Ensayo de unión a colágeno"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301108"
            xItem.ORDEN = 6700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Multimeros del factor Von Willebrand"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301109"
            xItem.ORDEN = 6800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Factor V Leiden"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301110"
            xItem.ORDEN = 6900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Mutación G20210A del gen de la protrombina"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301111"
            xItem.ORDEN = 7000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Anticuerpos antiplaquetarios"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301112"
            xItem.ORDEN = 7100
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Folato Eritrocitario"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301113"
            xItem.ORDEN = 7200
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Proteína C antigénica"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - HEMATOLOGÍA"
            xItem.SECC_ORDEN = 1
            xItem.CF_COD = "0301114"
            xItem.ORDEN = 7300
            Data_Prev.Add(xItem)
            '-------------------------------------------------------------------------------------------SANGRE - EXÁMENES BIOQUÍMICOS

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Aminoácidos, cualitativo, en sangre"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302009"
            xItem.ORDEN = 7900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Bicarbonato (proc. aut.)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302011"
            xItem.ORDEN = 8200
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Troponina"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302027"
            xItem.ORDEN = 9700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Deshidrogenasa láctica total (LDH), con separación de isoenzimas"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302031"
            xItem.ORDEN = 9900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Enzima convertidora de angiotensina I"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302033"
            xItem.ORDEN = 10100

            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Galactosa"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302043"
            xItem.ORDEN = 10800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Leucinaminopeptidasa (LAP)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302052"
            xItem.ORDEN = 11400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Proteínas totales en sangre"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302100"
            xItem.ORDEN = 12100
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Proteínas, electroforesis (incluye cód. 03-02-060)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302061"
            xItem.ORDEN = 12300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Vitamina B12 por inmunoensayo"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302077"
            xItem.ORDEN = 12800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Vitamina B6 por HPLC"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302080"
            xItem.ORDEN = 13000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Calcio iónico. Incluye medición de pH método ión selectivo. No incluye Point of Care Testing POCT"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302081"
            xItem.ORDEN = 13100
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Fenilalanina Cuantitativa en Gotas de Sangre Seca"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302082"
            xItem.ORDEN = 13200
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Carboxihemoglobina"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302083"
            xItem.ORDEN = 13300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Plomo en sangre"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302084"
            xItem.ORDEN = 13400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Prealbumina"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302085"
            xItem.ORDEN = 13500
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Co-oximetría"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302087"
            xItem.ORDEN = 13700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Nivel de Carnitina"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302088"
            xItem.ORDEN = 13800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Lipoproteina (A)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302089"
            xItem.ORDEN = 13900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Bilirrubina neonatal"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302090"
            xItem.ORDEN = 14000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Colesterol LDL directo"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302091"
            xItem.ORDEN = 14100
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Creatinquinasa CK - MB masa"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302092"
            xItem.ORDEN = 14200
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Panel de glicemia (incluye glucosa basal, glucosa 2 horas post desayuno y glucosa 2 horas post almuerzo)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302093"
            xItem.ORDEN = 14300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "CK isoenzimas"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302094"
            xItem.ORDEN = 14400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Tiopurina metiltransferasa, actividad enzimatica"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302095"
            xItem.ORDEN = 14500
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Tirosina cuantitativa en GSS"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302096"
            xItem.ORDEN = 14600
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Hormona tiroestimulante, neonatal"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302097"
            xItem.ORDEN = 14700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Perfil de aminoácidos y acilcarnitinas"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302098"
            xItem.ORDEN = 14800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Pesquisa neonatal ampliada"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "SANGRE - EXÁMENES BIOQUÍMICOS"
            xItem.SECC_ORDEN = 51
            xItem.CF_COD = "0302099"
            xItem.ORDEN = 14900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Índice androgénico (incluye Testosterona Total y SHBG)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "HORMONAS"
            xItem.SECC_ORDEN = 101
            xItem.CF_COD = "0303123"
            xItem.ORDEN = 17300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Catecolaminas en sangre (incluye medición de Adrenalina, Noradrenalina y Dopamina por separado por métodos cromatográficos)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "HORMONAS"
            xItem.SECC_ORDEN = 101
            xItem.CF_COD = "0303049"
            xItem.ORDEN = 18100
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Peptido C"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "HORMONAS"
            xItem.SECC_ORDEN = 101
            xItem.CF_COD = "0303052"
            xItem.ORDEN = 18200
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Calcitonina"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "HORMONAS"
            xItem.SECC_ORDEN = 101
            xItem.CF_COD = "0303053"
            xItem.ORDEN = 18300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Inhibina B"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "HORMONAS"
            xItem.SECC_ORDEN = 101
            xItem.CF_COD = "0303054"
            xItem.ORDEN = 18400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Hormona antimulleriana"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "HORMONAS"
            xItem.SECC_ORDEN = 101
            xItem.CF_COD = "0303058"
            xItem.ORDEN = 18700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Angiotensina en orina"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "HORMONAS"
            xItem.SECC_ORDEN = 101
            xItem.CF_COD = "0303033"
            xItem.ORDEN = 18800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Gonadotrofina coriónica, sub-unidad Beta; titulación por (Elisa; RIA o IRMA; Quimioluminiscencia u otra técnica)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "HORMONAS"
            xItem.SECC_ORDEN = 101
            xItem.CF_COD = "0303039"
            xItem.ORDEN = 19000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Metanefrinas urinarias (incluye determinación de Metanefrina y Normetanefrina por separado por métodos cromatográficos)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "HORMONAS"
            xItem.SECC_ORDEN = 101
            xItem.CF_COD = "0303050"
            xItem.ORDEN = 19100
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Cortisol salival"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "HORMONAS"
            xItem.SECC_ORDEN = 101
            xItem.CF_COD = "0303056"
            xItem.ORDEN = 19300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Cariograma en sangre por cultivo de linfocitos (incluye mínimo 25 mitosis con bandeo G y eventualmente Q, R, C, NOR) (montaje de 3 metafases bandeadas)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "GENÉTICA"
            xItem.SECC_ORDEN = 151
            xItem.CF_COD = "0304001"
            xItem.ORDEN = 19400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Cariotipo con técnicas especiales (incluye muestra de sangre o de médula ósea, tratamiento con FUDR, bromuro de etidio, medio deficiente en ácido fólico)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "GENÉTICA"
            xItem.SECC_ORDEN = 151
            xItem.CF_COD = "0304002"
            xItem.ORDEN = 19500
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Cariotipo en fibroblastos por cultivo de trofoblasto, líquido amniótico, piel u otros bandeos G y eventualmente Q, R, C, NOR"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "GENÉTICA"
            xItem.SECC_ORDEN = 151
            xItem.CF_COD = "0304003"
            xItem.ORDEN = 19600
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "FISH Cromosomas X e Y"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "GENÉTICA"
            xItem.SECC_ORDEN = 151
            xItem.CF_COD = "0304006"
            xItem.ORDEN = 19700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Diagnóstico Genético Molecular:Displasia Tanatofórica tipo I y II"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "GENÉTICA"
            xItem.SECC_ORDEN = 151
            xItem.CF_COD = "0304007"
            xItem.ORDEN = 19800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Amplificación por PCR más análisis de fragmentos fluorescentes por electroforesis capilar (hasta 5 fragmentos) "
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "GENÉTICA"
            xItem.SECC_ORDEN = 151
            xItem.CF_COD = "0304008"
            xItem.ORDEN = 19900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Estudio de deleciones y duplicaciones por amplificación múltiple de sondas dependiente de ligación (MLPA)  (1 o varios genes) "
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "GENÉTICA"
            xItem.SECC_ORDEN = 151
            xItem.CF_COD = "0304009"
            xItem.ORDEN = 20000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Estudio de deleciones y duplicaciones por amplificación múltiple de sondas dependiente de ligación (MLPA) más estudio de metilación o segundo set de sondas  (1 o varios genes)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "GENÉTICA"
            xItem.SECC_ORDEN = 151
            xItem.CF_COD = "0304010"
            xItem.ORDEN = 20100
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "FISH en frotis frescos de médula ósea, sangre, concentrado de células plasmáticas seleccionadas o corte de tejido en parafina, búsqueda de alteraciones adquiridas"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "GENÉTICA"
            xItem.SECC_ORDEN = 151
            xItem.CF_COD = "0304011"
            xItem.ORDEN = 20200
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Amplificación por PCR en tiempo real cuantitativo con sonda"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "GENÉTICA"
            xItem.SECC_ORDEN = 151
            xItem.CF_COD = "0304012"
            xItem.ORDEN = 20300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Amplificación de ADN por PCR convencional de 1 fragmento"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "GENÉTICA"
            xItem.SECC_ORDEN = 151
            xItem.CF_COD = "0304013"
            xItem.ORDEN = 20400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = ""
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "GENÉTICA"
            xItem.SECC_ORDEN = 151
            xItem.CF_COD = ""
            xItem.ORDEN = 0
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Amplificación por PCR más análisis por restricción enzimática"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "GENÉTICA"
            xItem.SECC_ORDEN = 151
            xItem.CF_COD = "0304014"
            xItem.ORDEN = 20500
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Alfa -2- macroglobulina"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305002"
            xItem.ORDEN = 20700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Inhibidor de C1Q, C2 y C3, c/u"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305021"
            xItem.ORDEN = 22200
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Inmunofijación de inmunoglobulina, c/u"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305025"
            xItem.ORDEN = 22300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Inmunoglobulina IgA secretora"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305026"
            xItem.ORDEN = 22400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Inmunoglobulinas IgE, IgG específicas, c/u"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305029"
            xItem.ORDEN = 22700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Proteína C reactiva por técnica de látex u otras similares"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305030"
            xItem.ORDEN = 22800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Determinación de isotipos de anticuerpos anticitoplasma de neutrófilos (G-M-A-C'3), por IFI, c/u."
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305083"
            xItem.ORDEN = 23300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Anticuerpos anticardiolipinas (IgG, IgM), c/u"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305084"
            xItem.ORDEN = 23400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Detección, identificación y titulación de crioaglutininas"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305035"
            xItem.ORDEN = 23700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Criohemolisinas"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305036"
            xItem.ORDEN = 23800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Digestión fagocítica nitroblue-tetrazolium cualitativo y cuantitativo"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305037"
            xItem.ORDEN = 23900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Fagocitosis: ingestión y digestión (killing) de levaduras por polimorfonucleares"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305038"
            xItem.ORDEN = 24000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Fagocitosis: ingestión y digestión (killing) de bacterias por polimorfonucleares"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305039"
            xItem.ORDEN = 24100
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Inmunoadherencia de leucocitos macrófagos"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305040"
            xItem.ORDEN = 24200
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Intradermoreacción (PPD, histoplasmina, aspergilina, u otros, incluye el valor del antígeno y reacción de control), c/u. "
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305041"
            xItem.ORDEN = 24300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "LIF o MIF"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305042"
            xItem.ORDEN = 24400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Linfocitos B (rosetas EAC) y linfocitos T (rosetas E) c/u"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "305044"
            xItem.ORDEN = 24500
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Linfotoxinas humanas, detección de"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305047"
            xItem.ORDEN = 24600
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Transformación linfoblástica a drogas, análisis de transformación espontanea con estimulo inespecífico y con diferentes concentraciones de la droga en 1000 células"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305049"
            xItem.ORDEN = 24700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Linfocitos B totales (CD19). Técnica Citometría de Flujo"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305089"
            xItem.ORDEN = 24800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Estudio para hipersensibilidad retardada"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305080"
            xItem.ORDEN = 24900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Linfocitos T (CD3, CD4, CD8). Técnica Citometría de Flujo"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305091"
            xItem.ORDEN = 25000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Natural Killers (CD16, CD 56). Técnica Citometría de Flujo"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305092"
            xItem.ORDEN = 25100
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Inmunofenotipo en Leucemias Agudas"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305093"
            xItem.ORDEN = 25200
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Inmunofenotipo en Síndrome Linfoproliferativos"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305094"
            xItem.ORDEN = 25300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Inmunofenotipo en Síndrome Mielodisplásicos"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305095"
            xItem.ORDEN = 25400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Detección de Enfermedad Residual Mínima "
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305096"
            xItem.ORDEN = 25500
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Cuantificación de células progenitoras hematopoyéticas CD 34"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305097"
            xItem.ORDEN = 25600
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Alocross Match Linfocitos T y Linfocitos B (Citometría De Flujo)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305110"
            xItem.ORDEN = 25700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Anticuerpo Anti HLA Clase I y II Screening (Luminex)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305111"
            xItem.ORDEN = 25800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Autocrossmatch Linfocitos T y B   (Citometría De Flujo )"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305112"
            xItem.ORDEN = 25900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Especificidad De Anticuerpos HLA  Con Antígenos Individuales Clase I  (Luminex)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305113"
            xItem.ORDEN = 26000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Especificidad De Anticuerpos HLA  Con Antígenos Individuales Clase II (Luminex)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305114"
            xItem.ORDEN = 26100
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Estudio Receptor Trasplantado Con Donante Cadáver"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305115"
            xItem.ORDEN = 26200
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "HLA-AB Tipificación (Biología Molecular)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305116"
            xItem.ORDEN = 26300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "HLA-ABDR Tipificación  (Biología Molecular)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305117"
            xItem.ORDEN = 26400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "HLA-B27 Tipificación (Biología Molecular)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305118"
            xItem.ORDEN = 26500
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "HLA-C Tipificación  (Biología Molecular)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305119"
            xItem.ORDEN = 26600
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "HLA-DP Tipificación  (Biología  Molecular)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305120"
            xItem.ORDEN = 26700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "HLA-DQ Tipificación (Biología Molecular)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305121"
            xItem.ORDEN = 26800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "HLA-DR Tipificación  (Biología Molecular)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305122"
            xItem.ORDEN = 26900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Seroteca  Mensual y Mantención en Lista De Espera"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305123"
            xItem.ORDEN = 27000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Cromogranina A"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305098"
            xItem.ORDEN = 27100
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Péptido Cíclico Citrulinado, anticuerpos IgG"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305099"
            xItem.ORDEN = 27200
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Proteina C ultrasensible"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305100"
            xItem.ORDEN = 27300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Anticuerpos anti-saccharomyces cerevisiae (ASCA) IGA e IGG, c/u"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305101"
            xItem.ORDEN = 27400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Antígeno prostático total y libre "
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305104"
            xItem.ORDEN = 27500
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Estudio inmunológico de diabetes (determinación de anticuerpos anti células de islotes (ICA), auto anticuerpo insulina nativa (IAA), anti antígeno de insulinoma-2 (IA2) y anti glutamato descarboxilasa (GADA)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305106"
            xItem.ORDEN = 27700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Anticuerpos anti-MPO (mieloperoxidasa)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305107"
            xItem.ORDEN = 27800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Anticuerpos anti antígenos nucleares extractables (A-ENA): SM, RNP, SS-A/RO, SS-B/LA, SCL-70, JO-1). c/u"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305108"
            xItem.ORDEN = 27900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Anticuerpos anti-PR3 (proteasa 3)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305109"
            xItem.ORDEN = 28000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Receptor de tirotropina (TRAb), anticuerpos anti"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305124"
            xItem.ORDEN = 28100
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "CTX sérico"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "INMUNOLOGíA"
            xItem.SECC_ORDEN = 201
            xItem.CF_COD = "0305125"
            xItem.ORDEN = 28200
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Baciloscopía por método de concentración"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306001"
            xItem.ORDEN = 28300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Ultramicroscopía"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306006"
            xItem.ORDEN = 28700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Tinción de toluidina"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306102"
            xItem.ORDEN = 28800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Tinción de calcofluor"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306103"
            xItem.ORDEN = 28900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Tinción para campylobacter"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306104"
            xItem.ORDEN = 29000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Tinción tinta china"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306105"
            xItem.ORDEN = 29100
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Hemocultivo automatizado. Incluye Antibiograma con CIM"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306091"
            xItem.ORDEN = 29500
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Cultivo de Líquido de Cavidades Estériles en frasco de Hemocultivo  automatizado. Incluye Antibiograma con CIM"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306101"
            xItem.ORDEN = 29700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Hemocultivo automatizado para hongos"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306106"
            xItem.ORDEN = 29800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Cultivo para Anaerobios (incluye Cód. 03-06-008)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306012"
            xItem.ORDEN = 29900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Cultivo para Bordetella"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306013"
            xItem.ORDEN = 30000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Cultivo para hongos (levaduras y filamentosos)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306017"
            xItem.ORDEN = 30300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = ""
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = ""
            xItem.ORDEN = 0
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Cultivo para dermatofitos"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306117"
            xItem.ORDEN = 30400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Cultivo y Tipificación de micobacterias"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306022"
            xItem.ORDEN = 30700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Cultivo mycoplasma y ureaplasma, c/u."
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306023"
            xItem.ORDEN = 30800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Streptococcus Grupo B/ agalactiae en embarazada por cultivo con medio selectivo y/o enriquecido. "
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306099"
            xItem.ORDEN = 30900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Cultivo acelerado para Micobacterias"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306100"
            xItem.ORDEN = 31000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Antibiograma Bacilo de Koch (cada fármaco)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306025"
            xItem.ORDEN = 31100
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Antibiograma de estudio de sensibilidad por dilución (CIM) (mínimo 6 fármacos) (en caso de urocultivo, no corresponde su cobro; incluido en el valor código 03-06-011)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306027"
            xItem.ORDEN = 31300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Antifungigrama (mínimo 4 fármacos antihongos)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306028"
            xItem.ORDEN = 31400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Chlamydia Trachomatis y Neisseria Gonorrhoeae detección por técnica de biología molecular"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306097"
            xItem.ORDEN = 31500
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Test rápido de detección de streptococcus grupo A (Pyogenes)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306090"
            xItem.ORDEN = 31600
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Toxina Clostridium Difficile en deposiciones test rápido"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306098"
            xItem.ORDEN = 31700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Pneumocystis Jirovecci por técnica de biología molecular en tiempo real"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306107"
            xItem.ORDEN = 31800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Helicobacter pylori, detección en deposiciones, test rápido"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306108"
            xItem.ORDEN = 31900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Amplificación de DNA de Bordetella Pertussis por técnica de biología molecular en tiempo real"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306118"
            xItem.ORDEN = 32000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Streptococcus agalactiae en embarazada por biología molecular "
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306133"
            xItem.ORDEN = 32100
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Panel ETS por biología molecular"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306134"
            xItem.ORDEN = 32200
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Beta-d- glucano"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306135"
            xItem.ORDEN = 32300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Detección de antígeno capsular de cryptococcus"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306136"
            xItem.ORDEN = 32400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Brucella abortus, melitensis y suis, anticuerpos, por Aglutinación o Elisa"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306033"
            xItem.ORDEN = 32500
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Clamidias por inmunofluorescencia, peroxidasa, Elisa o similares"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306034"
            xItem.ORDEN = 32600
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Tíficas, reacciones de aglutinación  (Eberth H y O, paratyphi A y B) (Widal)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306039"
            xItem.ORDEN = 33000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Antígeno galactomanano"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306094"
            xItem.ORDEN = 33300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = ""
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = ""
            xItem.ORDEN = 0
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Antigeno de neumococo"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306114"
            xItem.ORDEN = 33400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Legionella antígeno urinario"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306115"
            xItem.ORDEN = 33500
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Interferón Gamma TBC "
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306119"
            xItem.ORDEN = 33600
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Bordetella pertussis IgG, IgM en sangre"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306131"
            xItem.ORDEN = 33700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Bartonella henselae, anticuerpos IgG o IgM, c/u"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "BACTERIAS Y HONGOS"
            xItem.SECC_ORDEN = 251
            xItem.CF_COD = "0306132"
            xItem.ORDEN = 33800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Artrópodos macroscópicos y microscópicos (imagos y/o pupas y/o larvas), diagnóstico de"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "PARÁSITOS"
            xItem.SECC_ORDEN = 301
            xItem.CF_COD = "0306043"
            xItem.ORDEN = 33900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Coproparasitario seriado con técnica  para Cryptosporidium sp o para Diantamoeba fragilis (incluye los códigos 03-06-048 y/o 03-06-059 más aplicación de técnica de frotis con tinción tricrómica o tinción Ziehl-Neelsen en por lo menos 3 muestras, según corresponda)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "PARÁSITOS"
            xItem.SECC_ORDEN = 301
            xItem.CF_COD = "0306045"
            xItem.ORDEN = 34000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Coproparasitario seriado para fasciola hepática (incluye diagnóstico de gusanos macroscópicos y examen microscópico de 10 muestras por método de Telemann y simultaneamente por técnica de Sedimentación rápida (Copa Cónica)."
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "PARÁSITOS"
            xItem.SECC_ORDEN = 301
            xItem.CF_COD = "0306046"
            xItem.ORDEN = 34100
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Coproparasitario seriado para Isospora y Sarcocystis (incluye diagnóstico de gusanos macroscópicos y examen  microscópico de 3 muestras separadas)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "PARÁSITOS"
            xItem.SECC_ORDEN = 301
            xItem.CF_COD = "0306047"
            xItem.ORDEN = 342000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Diagnostico de parásitos en jugo duodenal y/o bilis, examen macroscópico y microscópico (directo y/o concentración, c/s tinción)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "PARÁSITOS"
            xItem.SECC_ORDEN = 301
            xItem.CF_COD = "0306049"
            xItem.ORDEN = 34400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Diagnóstico parasitario en exudados, secreciones y otros líquidos orgánicos, examen macro y microscópico de (incluye concentración y/o tinción cuando proceda), c/u"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "PARÁSITOS"
            xItem.SECC_ORDEN = 301
            xItem.CF_COD = "0306050"
            xItem.ORDEN = 34500
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Hemoparásitos, diagnóstico microscópico de (mínimo 10 frotis y/o gotas gruesas, c/s examen directo al fresco), cada sesión"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "PARÁSITOS"
            xItem.SECC_ORDEN = 301
            xItem.CF_COD = "0306053"
            xItem.ORDEN = 34800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Hemoparasitos, diagnóstico por técnica de Microstrout o similar en hasta 10 tubos capilares, cada sesión (Chagas)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "PARÁSITOS"
            xItem.SECC_ORDEN = 301
            xItem.CF_COD = "0306054"
            xItem.ORDEN = 34900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Raspado de piel, examen microscópico para búsqueda de demodex"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "PARÁSITOS"
            xItem.SECC_ORDEN = 301
            xItem.CF_COD = "0306137"
            xItem.ORDEN = 35200
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Inmunofluorescencia indirecta (toxoplasmosis, Chagas, amebiasis y otras), c/u"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "PARÁSITOS"
            xItem.SECC_ORDEN = 301
            xItem.CF_COD = "0306066"
            xItem.ORDEN = 35400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Parásitos: determinación por reacción de polimerasa en cadena (PCR)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "PARÁSITOS"
            xItem.SECC_ORDEN = 301
            xItem.CF_COD = "0306095"
            xItem.ORDEN = 35500
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Parásitos: test rápido anticuerpos (Chagas y otros)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "PARÁSITOS"
            xItem.SECC_ORDEN = 301
            xItem.CF_COD = "0306096"
            xItem.ORDEN = 35600
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Aislamiento de virus (Adenovirus, Citomegalovirus, Enterovirus, Herpes, Influenza, Polio,Sarampión y otros), c/u"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "VIRUS"
            xItem.SECC_ORDEN = 351
            xItem.CF_COD = "0306068"
            xItem.ORDEN = 35700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Anticuerpos virales, determ. de H.I.V."
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "VIRUS"
            xItem.SECC_ORDEN = 351
            xItem.CF_COD = "0306169"
            xItem.ORDEN = 35900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Virus hepatitis B, anticuerpo del antígeno E del"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "VIRUS"
            xItem.SECC_ORDEN = 351
            xItem.CF_COD = "0306075"
            xItem.ORDEN = 36400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Virus hepatitis B, anticore total del (anti HBc total)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "VIRUS"
            xItem.SECC_ORDEN = 351
            xItem.CF_COD = "0306076"
            xItem.ORDEN = 36500
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Virus hepatitis B, antígeno E del (HBEAg)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "VIRUS"
            xItem.SECC_ORDEN = 351
            xItem.CF_COD = "0306078"
            xItem.ORDEN = 36700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Virus hepatitis B, antígeno de superficie (HBsAg)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "VIRUS"
            xItem.SECC_ORDEN = 351
            xItem.CF_COD = "0306079"
            xItem.ORDEN = 36800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Virus hepatitis B, anticore IgM del (anti HBc IgM)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "VIRUS"
            xItem.SECC_ORDEN = 351
            xItem.CF_COD = "0306080"
            xItem.ORDEN = 36900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Reacción de Polimerasa en cadena (P.C.R.) en tiempo real, virus Influenza, virus Herpes, citomegalovirus, hepatitis C, mycobacteria TBC, c/u (incluye toma muestra hisopado nasofaríngeo)."
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "VIRUS"
            xItem.SECC_ORDEN = 351
            xItem.CF_COD = "0306182"
            xItem.ORDEN = 37200
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Hepatitis B, carga viral"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "VIRUS"
            xItem.SECC_ORDEN = 351
            xItem.CF_COD = "0306084"
            xItem.ORDEN = 37400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Hepatitis C, carga viral"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "VIRUS"
            xItem.SECC_ORDEN = 351
            xItem.CF_COD = "0306085"
            xItem.ORDEN = 37500
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "VIH, carga viral"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "VIRUS"
            xItem.SECC_ORDEN = 351
            xItem.CF_COD = "0306086"
            xItem.ORDEN = 37600
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Virus Epstein Barr (VEB) carga viral "
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "VIRUS"
            xItem.SECC_ORDEN = 351
            xItem.CF_COD = "0306087"
            xItem.ORDEN = 37700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Polioma (BK) virus carga viral"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "VIRUS"
            xItem.SECC_ORDEN = 351
            xItem.CF_COD = "0306088"
            xItem.ORDEN = 37800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "VIH, Genotipificación antivirales"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "VIRUS"
            xItem.SECC_ORDEN = 351
            xItem.CF_COD = "0306109"
            xItem.ORDEN = 37900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "PCR metapneumovirus"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "VIRUS"
            xItem.SECC_ORDEN = 351
            xItem.CF_COD = "0306110"
            xItem.ORDEN = 38000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "HTLV I y II determinación de anticuerpos virales"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "VIRUS"
            xItem.SECC_ORDEN = 351
            xItem.CF_COD = "0306111"
            xItem.ORDEN = 38100
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "VIH, anticuerpos y antígenos virales, determ. de H.I.V."
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "VIRUS"
            xItem.SECC_ORDEN = 351
            xItem.CF_COD = "0306112"
            xItem.ORDEN = 38200
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "VIH, reacción de polimerasa en cadena (P.C.R.) en líquido cefaloraquídeo"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "VIRUS"
            xItem.SECC_ORDEN = 351
            xItem.CF_COD = "0306113"
            xItem.ORDEN = 38300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Hanta virus, anticuerpos IgM test rápido"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "VIRUS"
            xItem.SECC_ORDEN = 351
            xItem.CF_COD = "0306121"
            xItem.ORDEN = 38500
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Virus Papiloma Humano por PCR con genotipificación de papiloma de alto riesgo de Ca Cervico Uterino tipos 16 y 18"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "VIRUS"
            xItem.SECC_ORDEN = 351
            xItem.CF_COD = "0306123"
            xItem.ORDEN = 38700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Virus ARN por PCR (hanta, dengue, chikungunya, sarampión, enterovirus, parechovirus, zika) c/u"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "VIRUS"
            xItem.SECC_ORDEN = 351
            xItem.CF_COD = "0306124"
            xItem.ORDEN = 38800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Virus hepatitis C, genotipificación "
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "VIRUS"
            xItem.SECC_ORDEN = 351
            xItem.CF_COD = "0306125"
            xItem.ORDEN = 38900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Hanta virus serologia IgG/IgM c/u"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "VIRUS"
            xItem.SECC_ORDEN = 351
            xItem.CF_COD = "0306126"
            xItem.ORDEN = 39000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Panel de meningitis encefalitis por biología molecular "
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "VIRUS"
            xItem.SECC_ORDEN = 351
            xItem.CF_COD = "0306127"
            xItem.ORDEN = 39100
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Rotavirus y adenovirus detección simultanea de por inmunocromatografia"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "VIRUS"
            xItem.SECC_ORDEN = 351
            xItem.CF_COD = "0306128"
            xItem.ORDEN = 39200
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Norovirus detección por inmunocromatografia"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "VIRUS"
            xItem.SECC_ORDEN = 351
            xItem.CF_COD = "0306129"
            xItem.ORDEN = 39300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Virus hepatitis B, anticuerpos anti antígeno de superficie (títulos)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "VIRUS"
            xItem.SECC_ORDEN = 351
            xItem.CF_COD = "0306130"
            xItem.ORDEN = 39400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Test rápido de detección de antígenos SARS-CoV-2 (incluye toma de muestra)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "VIRUS"
            xItem.SECC_ORDEN = 351
            xItem.CF_COD = "0306271"
            xItem.ORDEN = 39500
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Dietilendiamina tetraacetato de sodio cromo (EDTA Cr 51)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "PROCEDIMIENTOS O DETERMINACIONES DIRECTAMENTE CON EL PACIENTE"
            xItem.SECC_ORDEN = 401
            xItem.CF_COD = "307001"
            xItem.ORDEN = 39600
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Prueba de la sed (volumen, densidad, osmolalidad seriada en sangre y orina)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "PROCEDIMIENTOS O DETERMINACIONES DIRECTAMENTE CON EL PACIENTE"
            xItem.SECC_ORDEN = 401
            xItem.CF_COD = "0307002"
            xItem.ORDEN = 39700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Reacción cutánea de parche c/u"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "PROCEDIMIENTOS O DETERMINACIONES DIRECTAMENTE CON EL PACIENTE"
            xItem.SECC_ORDEN = 401
            xItem.CF_COD = "0307005"
            xItem.ORDEN = 39800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Sobrecarga hídrica"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "PROCEDIMIENTOS O DETERMINACIONES DIRECTAMENTE CON EL PACIENTE"
            xItem.SECC_ORDEN = 401
            xItem.CF_COD = "0307006"
            xItem.ORDEN = 39900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Test del sudor (procedimiento completo)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "PROCEDIMIENTOS O DETERMINACIONES DIRECTAMENTE CON EL PACIENTE"
            xItem.SECC_ORDEN = 401
            xItem.CF_COD = "0307007"
            xItem.ORDEN = 40000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Vasopresina test o similares (incluye, además, mediciones de diuresis)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "PROCEDIMIENTOS O DETERMINACIONES DIRECTAMENTE CON EL PACIENTE"
            xItem.SECC_ORDEN = 401
            xItem.CF_COD = "0307008"
            xItem.ORDEN = 40100
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Azúcares reductores (Benedict-Fehling o similar)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308001"
            xItem.ORDEN = 41300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Grasas neutras (Sudán III)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308003"
            xItem.ORDEN = 41400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "pH en deposiciones"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308006"
            xItem.ORDEN = 41700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Elastasa fecal "
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308007"
            xItem.ORDEN = 41800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Esteatocrito"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308047"
            xItem.ORDEN = 41900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Células neoplásicas en fluidos biológicos"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308009"
            xItem.ORDEN = 42100
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Citológico c/s tinción (incluye examen al fresco, recuento celular y citológico porcentual)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308010"
            xItem.ORDEN = 42200
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Directo al fresco c/s tinción, (incluye trichomonas)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308011"
            xItem.ORDEN = 42300

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Electrolitos (sodio, potasio, cloro), en exudados, secreciones y otros líquidos, c/u"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308012"
            xItem.ORDEN = 42400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Mucina, determinación de"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308016"
            xItem.ORDEN = 42800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "pH en exudados, secreciones y otros líquidos (proc. aut.)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308017"
            xItem.ORDEN = 42900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Proteínas totales en exudados, secreciones y otros líquidos"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308050"
            xItem.ORDEN = 43000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Albúminas en exudados, secreciones y otros líquidos"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308051"
            xItem.ORDEN = 43100
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Proteínas, electroforésis de (incluye proteínas totales) en otros líquidos biológicos"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308019"
            xItem.ORDEN = 43200
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Glutamina"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308021"
            xItem.ORDEN = 43400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Índice IgG/albúmina (incluye determ. de IgG y albúmina en L.C.R. y suero)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308022"
            xItem.ORDEN = 43500
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Estudio de cristales (con luz polarizada)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308023"
            xItem.ORDEN = 43600
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Prueba de estimulación máxima con histamina, mínimo 5 muestras (no incluye la histamina ni el antihistamínico)."
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308025"
            xItem.ORDEN = 43700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Espermiograma (físico y microscópico, con o sin observación hasta 24 horas)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308029"
            xItem.ORDEN = 43800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Fosfatasa ácida prostática"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308030"
            xItem.ORDEN = 43900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Fructosa seminal"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308031"
            xItem.ORDEN = 44000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Células anaranjadas (proc. aut.)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308033"
            xItem.ORDEN = 44100
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Contaminantes (meconio y sangre) (proc. aut.)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308034"
            xItem.ORDEN = 44200
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Creatinina en exudados, secreciones y otros líquidos (proc. aut.)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308035"
            xItem.ORDEN = 44300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Fosfatidil glicerol y/o fosfatidil inositol"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308036"
            xItem.ORDEN = 44400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Índice de bilirrubina (prueba de Liley)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308037"
            xItem.ORDEN = 44500
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Índice lecitina/esfingomielina"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308038"
            xItem.ORDEN = 44600
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Madurez fetal completa (físico; células anaranjadas, bilirrubina, test de Clements, creatinina, contaminantes)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308039"
            xItem.ORDEN = 44700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Test de Clements (proc. aut.)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308040"
            xItem.ORDEN = 44800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Colpocitograma"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308041"
            xItem.ORDEN = 44900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Moco-semen, prueba de compatibilidad"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308043"
            xItem.ORDEN = 45000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Amilasa en Líquidos Biológicos"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308045"
            xItem.ORDEN = 45200
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Lipasa en  Líquidos Biológicos"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308046"
            xItem.ORDEN = 45300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Cuerpos lamelares (procedimiento automatizado) en líquido amniótico"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308048"
            xItem.ORDEN = 45400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Colesterol total en exudados, secreciones y otros líquidos"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308052"
            xItem.ORDEN = 45500
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Hematocrito automatizado (en contador hematológico) en exudados, secreciones y otros líquidos"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308053"
            xItem.ORDEN = 45600
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "LDH en exudados, secreciones y otros líquidos"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308054"
            xItem.ORDEN = 45700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Trigliceridos en exudados, secreciones y otros líquidos"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308055"
            xItem.ORDEN = 45800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Beta-2 transferrina"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308056"
            xItem.ORDEN = 45900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Acido láctico, LCR"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXAMENES DE DEPOSICIONES, EXUDADOS, SECRECIONES Y OTROS LÍQUIDOS"
            xItem.SECC_ORDEN = 501
            xItem.CF_COD = "0308057"
            xItem.ORDEN = 46000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Acido ascórbico"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXÁMENES ORINA"
            xItem.SECC_ORDEN = 551
            xItem.CF_COD = "0309001"
            xItem.ORDEN = 46100
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Acido delta aminolevulínico"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXÁMENES ORINA"
            xItem.SECC_ORDEN = 551
            xItem.CF_COD = "0309002"
            xItem.ORDEN = 46200
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Ácido úrico en orina (cuantitativo)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXÁMENES ORINA"
            xItem.SECC_ORDEN = 551
            xItem.CF_COD = "0309004"
            xItem.ORDEN = 46300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Aminoácidos (cualitativo) (excepto fenilalanina, PKU)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXÁMENES ORINA"
            xItem.SECC_ORDEN = 551
            xItem.CF_COD = "0309007"
            xItem.ORDEN = 46600
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Glucosa (cuantitativo), en orina"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXÁMENES ORINA"
            xItem.SECC_ORDEN = 551
            xItem.CF_COD = "0309016"
            xItem.ORDEN = 47500
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Hemosiderina"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXÁMENES ORINA"
            xItem.SECC_ORDEN = 551
            xItem.CF_COD = "0309035"
            xItem.ORDEN = 47600
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Mucopolisacáridos"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXÁMENES ORINA"
            xItem.SECC_ORDEN = 551
            xItem.CF_COD = "0309019"
            xItem.ORDEN = 47800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Nucleótidos cíclicos (CAMP, CGM, u otros) c/u"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXÁMENES ORINA"
            xItem.SECC_ORDEN = 551
            xItem.CF_COD = "0309021"
            xItem.ORDEN = 48000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Osmolalidad"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXÁMENES ORINA"
            xItem.SECC_ORDEN = 551
            xItem.CF_COD = "0309025"
            xItem.ORDEN = 48400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Proteína (cuantitativa), en orina"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXÁMENES ORINA"
            xItem.SECC_ORDEN = 551
            xItem.CF_COD = "0309028"
            xItem.ORDEN = 48600
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Arsenico en orina (muestra aislada)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXÁMENES ORINA"
            xItem.SECC_ORDEN = 551
            xItem.CF_COD = "0309034"
            xItem.ORDEN = 48900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Cobre en orina"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXÁMENES ORINA"
            xItem.SECC_ORDEN = 551
            xItem.CF_COD = "0309036"
            xItem.ORDEN = 49000
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Oxalato en orina"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXÁMENES ORINA"
            xItem.SECC_ORDEN = 551
            xItem.CF_COD = "0309037"
            xItem.ORDEN = 49100
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Citrato en orina (enzimático)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXÁMENES ORINA"
            xItem.SECC_ORDEN = 551
            xItem.CF_COD = "0309038"
            xItem.ORDEN = 49200
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Deoxipiridinolina (DPD)"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXÁMENES ORINA"
            xItem.SECC_ORDEN = 551
            xItem.CF_COD = "0309039"
            xItem.ORDEN = 49300
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Magnesio en orina"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXÁMENES ORINA"
            xItem.SECC_ORDEN = 551
            xItem.CF_COD = "0309040"
            xItem.ORDEN = 49400
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Sulfato en orina"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXÁMENES ORINA"
            xItem.SECC_ORDEN = 551
            xItem.CF_COD = "0309041"
            xItem.ORDEN = 49500
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "L-Cistina en orina"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXÁMENES ORINA"
            xItem.SECC_ORDEN = 551
            xItem.CF_COD = "0309042"
            xItem.ORDEN = 49600
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Ph en orina con peachimetro"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXÁMENES ORINA"
            xItem.SECC_ORDEN = 551
            xItem.CF_COD = "0309043"
            xItem.ORDEN = 49700
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Ácidos orgánicos, orina"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXÁMENES ORINA"
            xItem.SECC_ORDEN = 551
            xItem.CF_COD = "0309044"
            xItem.ORDEN = 49800
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Ácido orótico, orina"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXÁMENES ORINA"
            xItem.SECC_ORDEN = 551
            xItem.CF_COD = "0309045"
            xItem.ORDEN = 49900
            Data_Prev.Add(xItem)

            xItem = New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
            xItem.ID_CODIGO_FONASA = 0
            xItem.CF_DESC = "Screening de mucopolisacaridos"
            xItem.TOTAL_ATE = 0
            xItem.SECC_ALT_DESC = "EXÁMENES ORINA"
            xItem.SECC_ORDEN = 551
            xItem.CF_COD = "0309046"
            xItem.ORDEN = 50000
            Data_Prev.Add(xItem)



            'End Select

            'ORDENARRRRRRRRR
            'Dim Lista_REEEEEEE As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
            Lista_REEEEEEE = NN_Exam.Ordenar_REEEEE(Data_Prev)

            'For i = 0 To Lista_REEEEEEE.Count - 1
            '    For ii = 0 To 10 'Data_LugarTM.Count - 1
            '        Data_Prev_2 = NN_Exam_2.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO_CADA_PROCE(Date_01, Date_02, Data_LugarTM(ii).ID_PROCEDENCIA, Lista_REEEEEEE(i).ID_CODIGO_FONASA)
            '        Dim Item As New E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO

            '        If Data_Prev_2.Count > 0 Then
            '            Item.TOTAL_ATE = Data_Prev_2(0).TOTAL_ATE
            '            Item.PROC_DESC = Data_LugarTM(ii).PROC_DESC
            '            Item.ID_PROCEDENCIA = Data_LugarTM(ii).ID_PROCEDENCIA
            '        Else
            '            Item.TOTAL_ATE = 0
            '            Item.PROC_DESC = Data_LugarTM(ii).PROC_DESC
            '            Item.ID_PROCEDENCIA = Data_LugarTM(ii).ID_PROCEDENCIA
            '        End If
            '        Data_exam_proc.Add(Item)
            '    Next ii
            'Next i

        End If

        reeeeeee.proparra1 = Lista_REEEEEEE
        reeeeeee.proparra2 = Data_exam_proc

        Return reeeeeee
    End Function



    <Services.WebMethod()>
    Public Shared Function Gen_Excel_Desagrupado(ByVal DOMAIN_URL As String, ByVal DATE_str01 As String, ByVal DATE_str02 As String) As String
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        Return NN_Exam.Gen_Excel_Desagrupado_REM_2(DOMAIN_URL, DATE_str01, DATE_str02)
    End Function

    <Services.WebMethod()>
    Public Shared Sub Gen_Excel_Async(ByVal MAIN_URL As String,
                                      ByVal DATE_str01 As String,
                                      ByVal DATE_str02 As String,
                                      ByVal ID_CODIGO_FONASA As Integer,
                                      ByVal EMAIL As String)

        Dim strLocal As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim URL_Base As String = HttpContext.Current.Request.Url.Authority

        'Dim NN_Gen As New N_LugarTM_Det_Async(strLocal, URL_Base, N_Date.toDate(DESDE), N_Date.toDate(HASTA), ID_CF, ID_FP, ID_PREV, E_DESDE, E_HASTA, EMAIL)
        Dim NN_Gen As New N_LugarTM_Det_Async_REM(strLocal, URL_Base, DATE_str01, DATE_str02, ID_CODIGO_FONASA, EMAIL)

        Dim Hilo As Threading.Thread = New Threading.Thread(
        New Threading.ThreadStart(AddressOf NN_Gen.Gen_Excel_Async_REM)
    )
        Hilo.Start()

    End Sub
    <Services.WebMethod()>
    Public Shared Function Gen_Excel_Agrupado(ByVal DOMAIN_URL As String, ByVal DATE_str01 As String, ByVal DATE_str02 As String, ByVal ID_CODIGO_FONASA As Long) As String
        Dim NN_Exam As New N_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO
        ' Return NN_Exam.Gen_Excel_Agrupado(DOMAIN_URL, ID_CODIGO_FONASA, DATE_str01, DATE_str02)
    End Function

    Private Sub REP_LAB_CANT_EXA_ARE_SECC_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Dim objSession As HttpSessionState = HttpContext.Current.Session
        'Dim C_P_ADMIN As String = Convert.ToString(Request.Cookies.[Get]("P_ADMIN").Value)
        'If C_P_ADMIN = 0 Then
        '    Response.Redirect("~/Index.aspx")
        'End If
    End Sub
End Class
Public Class REEE_REM
    Dim arr1 As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
    Dim arr2 As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
    Dim arr3 As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION)
    Public Property proparra1 As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Get
            Return arr1
        End Get
        Set(ByVal value As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO))
            arr1 = value
        End Set
    End Property
    Public Property proparra2 As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO)
        Get
            Return arr2
        End Get
        Set(ByVal value As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENES_AREA_AGREGAR_PERFIL_BIOQUIMICO_A_ACIDO_URICO))
            arr2 = value
        End Set
    End Property
    Public Property proparra3 As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION)
        Get
            Return arr3
        End Get
        Set(ByVal value As List(Of E_IRIS_WEBF_AGENDA_BUSCA_EDITAR_PREI_DATOS_DE_ATENCION))
            arr3 = value
        End Set
    End Property
End Class