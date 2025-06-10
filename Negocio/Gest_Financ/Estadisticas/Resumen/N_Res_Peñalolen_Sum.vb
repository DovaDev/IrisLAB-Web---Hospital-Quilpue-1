Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
'Importar Capas
Imports Datos
Imports Entidades
Public Class N_Res_Peñalolen_Sum
    'Declaraciones Generales
    Dim DD_Data As D_Res_Peñalolen_Sum
    Sub New()
        DD_Data = New D_Res_Peñalolen_Sum
    End Sub
    Function IRIS_WEBF_BUSCA_PREVISION_POR_PROCEDENCIA_ID_PROCE(ByVal ID_PROCE As Long) As List(Of E_IRIS_WEBF_BUSCA_PREVISION_POR_PROCEDENCIA_ID_PROCE)
        Return DD_Data.IRIS_WEBF_BUSCA_PREVISION_POR_PROCEDENCIA_ID_PROCE(ID_PROCE)
    End Function
    Function IRIS_WEBF_BUSCA_REL_PREV_PRUEBA_2() As List(Of E_IRIS_WEBF_BUSCA_REL_PREV_PRUEBA_2)
        Return DD_Data.IRIS_WEBF_BUSCA_REL_PREV_PRUEBA_2()
    End Function
    Function IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Long, ByVal ID_PRUEBA As Long) As List(Of E_IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK)
        Return DD_Data.IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK(DESDE, HASTA, ID_CF, ID_PRUEBA)
    End Function
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR_PREVISION_PROGRAMA_EXAMEN_PROCE_2(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Long, ByVal ID_TM As Long, ByVal ID_PREV As Long, ByVal ID_PROG As Long, ByVal ID_SUBPROG As Long) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR_PREVISION_PROGRAMA_EXAMEN_PROCE_2)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR_PREVISION_PROGRAMA_EXAMEN_PROCE_2(DESDE, HASTA, ID_CF, ID_TM, ID_PREV, ID_PROG, ID_SUBPROG)
    End Function
    Function IRIS_WEBF_BUSCA_DET_ATENCION_POR_COD_FONASA_Y_PRUEBA(ByVal SQL_Transact As String) As List(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_COD_FONASA_Y_PRUEBA)
        Return DD_Data.IRIS_WEBF_BUSCA_DET_ATENCION_POR_COD_FONASA_Y_PRUEBA(SQL_Transact)
    End Function
    Function IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Long, ByVal ID_PRUEBA As Long) As List(Of E_IRIS_WEBF_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK)
        Return DD_Data.IRIS_BUSCA_EXAMEN_DET_ESTADISTICA_CHECK_TODOS(DESDE, HASTA, ID_CF, ID_PRUEBA)
    End Function
    Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal EMAIL As String, ByVal ALL As Boolean, ByVal DESDE As String, ByVal HASTA As String, ByVal ID_CF As Long, ByVal ID_TM As Long, ByVal ID_PREV As Long, ByVal ID_PROG As Long, ByVal ID_SUBPROG As Long) As String
        'Declaraciones Generales
        Dim Mx_Data(14, 0) As Object
        Dim NN_Date As New N_Date_Operat
        Dim NN_Exam As New N_Res_Peñalolen_Sum
        Dim Date_01 As Date = NN_Date.strToDate(Split(DESDE, "/")(2), Split(DESDE, "/")(1), Split(DESDE, "/")(0))
        Dim Date_02 As Date = NN_Date.strToDate(Split(HASTA, "/")(2), Split(HASTA, "/")(1), Split(HASTA, "/")(0))
        Dim Ddl_Text(3) As String
        'Debug
        Debug.WriteLine(">>>INICIANDO DEBUG DE CONSULTA SQL<<<")
        'Obtener Texto Ddl
        Dim NN_Activos_01 As New N_Gen_Activos
        If (ID_TM = 0) Then
            Ddl_Text(0) = "<< Todos >>"
        Else
            Dim Data_TM_01 As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
            Data_TM_01 = NN_Activos_01.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()

            If (Data_TM_01.Count > 0) Then
                For y = 0 To (Data_TM_01.Count - 1)
                    If (Data_TM_01(y).ID_PROCEDENCIA = ID_TM) Then
                        Ddl_Text(0) = Data_TM_01(y).PROC_DESC
                        Exit For
                    End If
                Next y
            End If
        End If
        If (ID_PREV = 0) Then
            Ddl_Text(1) = "<< Todos >>"
        Else
            Dim Data_Prev_01 As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
            Data_Prev_01 = NN_Activos_01.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()

            If (Data_Prev_01.Count > 0) Then
                For y = 0 To (Data_Prev_01.Count - 1)
                    If (Data_Prev_01(y).ID_PREVE = ID_PREV) Then
                        Ddl_Text(1) = Data_Prev_01(y).PREVE_DESC
                        Exit For
                    End If
                Next y
            End If
        End If
        If (ID_PROG = 0) Then
            Ddl_Text(2) = "<< Todos >>"
        Else
            Dim Data_Prog_01 As New List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)
            Data_Prog_01 = NN_Activos_01.IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO()

            If (Data_Prog_01.Count > 0) Then
                For y = 0 To (Data_Prog_01.Count - 1)
                    If (Data_Prog_01(y).ID_PROGRA = ID_PROG) Then
                        Ddl_Text(2) = Data_Prog_01(y).PROGRA_DESC
                        Exit For
                    End If
                Next y
            End If
        End If
        If (ID_SUBPROG = 0) Then
            Ddl_Text(3) = "<< Todos >>"
        Else
            Dim Data_Prog_02 As New List(Of E_IRIS_WEBF_BUSCA_PREVE_PROG_SUBPROG)
            Data_Prog_02 = NN_Activos_01.IRIS_WEBF_BUSCA_PREVE_PROG_SUBPROG(ID_PREV, ID_PROG)
            If (Data_Prog_02.Count > 0) Then
                For y = 0 To (Data_Prog_02.Count - 1)
                    If (Data_Prog_02(y).ID_SUBP = ID_SUBPROG) Then
                        Ddl_Text(3) = Data_Prog_02(y).SUBP_DESC
                        Exit For
                    End If
                Next y
            End If
        End If
        '1ra Búsqueda
        Dim Data_Prueba As New List(Of E_IRIS_WEBF_BUSCA_REL_PREV_PRUEBA_2)
        Data_Prueba = NN_Exam.IRIS_WEBF_BUSCA_REL_PREV_PRUEBA_2()
        Debug.WriteLine("Cantidad de Exámenes: " & Format(Data_Prueba.Count, "00"))
        '2da Búsqueda
        Dim JSON_List As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR_PREVISION_PROGRAMA_EXAMEN_PROCE_2)
        JSON_List = NN_Exam.IRIS_WEBF_BUSCA_EST_ESTADOS_INFORMAR_PREVISION_PROGRAMA_EXAMEN_PROCE_2(Date_01, Date_02, ID_CF, ID_TM, ID_PREV, ID_PROG, ID_SUBPROG)
        Debug.WriteLine("Cantidad de Pacientes: " & JSON_List.Count)
        Debug.WriteLine("")
        '3ra búsqueda
        For y = 0 To (JSON_List.Count - 1)
            Dim ID_yAte As Long = JSON_List(y).ID_ATENCION
            Dim ID_yCF As Long = JSON_List(y).ID_CODIGO_FONASA
            Debug.WriteLine("Consultando por Exámen N° " & Format((y + 1), "0000") & " de " & Format(JSON_List.Count, "0000"))
            Dim Data_Ate As New List(Of E_IRIS_WEBF_BUSCA_DET_ATENCION_POR_COD_FONASA_Y_PRUEBA)
            Dim strSQL As String = ""
            'Armar Consulta
            'Agregar solo la 1ra atención
            Select Case ALL
                Case True
                    strSQL &= "SELECT TOP 100 PERCENT" & vbLf
                Case Else
                    strSQL &= "SELECT TOP (1) PERCENT" & vbLf
            End Select
            strSQL &= "	dbo.IRIS_ATENCION.ID_ATENCION," & vbLf
            strSQL &= "	dbo.IRIS_ATENCION.ATE_NUM," & vbLf
            strSQL &= "	dbo.IRIS_ATENCION.ATE_FECHA," & vbLf
            strSQL &= "	dbo.IRIS_PACIENTES.PAC_NOMBRE," & vbLf
            strSQL &= "	dbo.IRIS_PACIENTES.PAC_APELLIDO," & vbLf
            strSQL &= "	dbo.IRIS_CODIGO_FONASA.CF_DESC," & vbLf
            strSQL &= "	dbo.IRIS_CODIGO_FONASA.CF_COD," & vbLf
            strSQL &= "	dbo.IRIS_ATENCION.ATE_AÑO," & vbLf
            strSQL &= "	dbo.IRIS_PRUEBAS.PRU_DESC," & vbLf
            strSQL &= "	dbo.IRIS_ATE_RESULTADO.ATE_RESULTADO," & vbLf
            strSQL &= "	dbo.IRIS_ATE_RESULTADO.ATE_RESULTADO_NUM," & vbLf
            strSQL &= "	dbo.IRIS_ATE_RESULTADO.ID_CODIGO_FONASA," & vbLf
            strSQL &= "	dbo.IRIS_ATE_RESULTADO.ID_PRUEBA," & vbLf
            strSQL &= "	dbo.IRIS_PACIENTES.PAC_FNAC," & vbLf
            strSQL &= "	dbo.IRIS_PACIENTES.ID_SEXO," & vbLf
            strSQL &= "	dbo.IRIS_UNI_MEDIDA.UM_DESC," & vbLf
            strSQL &= "	dbo.IRIS_PRUEBAS.ID_TP_RESULTADO," & vbLf
            strSQL &= "	dbo.IRIS_TP_RESULTADO.TP_RESUL_DESC," & vbLf
            strSQL &= "	dbo.IRIS_TP_RESULTADO.TP_RESUL_COD," & vbLf
            strSQL &= "	dbo.IRIS_PRUEBAS.ID_U_MEDIDA," & vbLf
            strSQL &= "	dbo.IRIS_PREVISION.PREVE_DESC," & vbLf
            strSQL &= "	dbo.IRIS_PROCEDENCIA.PROC_DESC," & vbLf
            strSQL &= "	dbo.IRIS_PROGRAMA.PROGRA_DESC," & vbLf
            strSQL &= "	dbo.IRIS_PACIENTES.PAC_RUT," & vbLf
            strSQL &= "	dbo.IRIS_PRUEBAS.PRU_ORDEN," & vbLf
            strSQL &= "	dbo.IRIS_SUBPROGRAMA.SUBP_DESC," & vbLf
            strSQL &= "	dbo.IRIS_ATENCION.ATE_OMI," & vbLf
            strSQL &= "	dbo.IRIS_ATE_RESULTADO.ATE_R_DESDE," & vbLf
            strSQL &= "	dbo.IRIS_ATE_RESULTADO.ATE_R_HASTA" & vbLf
            strSQL &= "" & vbLf
            strSQL &= "FROM dbo.IRIS_CODIGO_FONASA" & vbLf
            strSQL &= "" & vbLf
            strSQL &= "INNER JOIN dbo.IRIS_PRUEBAS" & vbLf
            strSQL &= "INNER JOIN dbo.IRIS_ATE_RESULTADO ON" & vbLf
            strSQL &= "	dbo.IRIS_PRUEBAS.ID_PRUEBA = dbo.IRIS_ATE_RESULTADO.ID_PRUEBA" & vbLf
            strSQL &= "INNER JOIN dbo.IRIS_PACIENTES" & vbLf
            strSQL &= "INNER JOIN dbo.IRIS_ATENCION ON" & vbLf
            strSQL &= "	dbo.IRIS_PACIENTES.ID_PACIENTE = dbo.IRIS_ATENCION.ID_PACIENTE ON" & vbLf
            strSQL &= "	dbo.IRIS_ATE_RESULTADO.ID_ATENCION = dbo.IRIS_ATENCION.ID_ATENCION ON" & vbLf
            strSQL &= "	dbo.IRIS_CODIGO_FONASA.ID_CODIGO_FONASA = dbo.IRIS_ATE_RESULTADO.ID_CODIGO_FONASA" & vbLf
            strSQL &= "INNER JOIN dbo.IRIS_UNI_MEDIDA ON" & vbLf
            strSQL &= "	dbo.IRIS_PRUEBAS.ID_U_MEDIDA = dbo.IRIS_UNI_MEDIDA.ID_U_MEDIDA" & vbLf
            strSQL &= "INNER JOIN dbo.IRIS_TP_RESULTADO ON" & vbLf
            strSQL &= "	dbo.IRIS_PRUEBAS.ID_TP_RESULTADO = dbo.IRIS_TP_RESULTADO.ID_TP_RESULTADO" & vbLf
            strSQL &= "INNER JOIN dbo.IRIS_PREVISION ON" & vbLf
            strSQL &= "	dbo.IRIS_ATENCION.ID_PREVE = dbo.IRIS_PREVISION.ID_PREVE" & vbLf
            strSQL &= "INNER JOIN dbo.IRIS_PROCEDENCIA ON" & vbLf
            strSQL &= "	dbo.IRIS_ATENCION.ID_PROCEDENCIA = dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA" & vbLf
            strSQL &= "INNER JOIN dbo.IRIS_PROGRAMA ON" & vbLf
            strSQL &= "	dbo.IRIS_ATENCION.ID_PROGRA = dbo.IRIS_PROGRAMA.ID_PROGRA" & vbLf
            strSQL &= "INNER JOIN dbo.IRIS_SUBPROGRAMA ON" & vbLf
            strSQL &= "	dbo.IRIS_ATENCION.ID_SUBP = dbo.IRIS_SUBPROGRAMA.ID_SUBP" & vbLf
            strSQL &= "" & vbLf
            strSQL &= "Where" & vbLf
            strSQL &= "		(dbo.IRIS_ATENCION.ID_ESTADO = 1)" & vbLf
            strSQL &= "	AND	(dbo.IRIS_ATE_RESULTADO.ID_ESTADO=1)" & vbLf
            strSQL &= "" & vbLf
            strSQL &= "	AND	(dbo.IRIS_ATENCION.ID_ATENCION =  " & ID_yAte & ")" & vbLf
            strSQL &= "	AND	(dbo.IRIS_ATE_RESULTADO.ID_CODIGO_FONASA = " & ID_yCF & ")" & vbLf
            strSQL &= "" & vbLf
            strSQL &= "	AND	(" & vbLf
            For yy = 0 To (Data_Prueba.Count - 1)
                If (yy > 0) Then
                    strSQL &= "	OR	"
                End If
                strSQL &= "(dbo.IRIS_ATE_RESULTADO.ID_PRUEBA = " & Data_Prueba(yy).ID_PRUEBA & ")" & vbLf
            Next yy
            strSQL &= "	)" & vbLf
            strSQL &= "" & vbLf
            strSQL &= "ORDER BY" & vbLf
            strSQL &= "	dbo.IRIS_ATENCION.ID_ATENCION," & vbLf
            strSQL &= "	dbo.IRIS_ATE_RESULTADO.ID_CODIGO_FONASA," & vbLf
            strSQL &= "	dbo.IRIS_PRUEBAS.PRU_ORDEN"
            Data_Ate = NN_Exam.IRIS_WEBF_BUSCA_DET_ATENCION_POR_COD_FONASA_Y_PRUEBA(strSQL)
            JSON_List(y).Data_Ate = Data_Ate
        Next y
        If (JSON_List.Count = 0) Then
            'Debug
            Debug.WriteLine("Tabla sin Datos, salir")
            Debug.WriteLine("")
            Return "null"
            Exit Function
        End If
        'Debug
        Debug.WriteLine("Tabla generada, Armnando Excel")
        Debug.WriteLine("")
        'Vaciar Matriz
        ReDim Mx_Data(15, 0)
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        Dim cc_count As Long = 0
        For y = 0 To (JSON_List.Count - 1)
            If (IsNothing(JSON_List(y).Data_Ate) = False) Then
                For i = 0 To (JSON_List(y).Data_Ate.Count - 1)
                    If (y > 0) Then
                        cc_count += 1
                        ReDim Preserve Mx_Data(Mx_Data.GetUpperBound(0), cc_count)
                    End If
                    Mx_Data(0, cc_count) = JSON_List(y).ID_ATENCION
                    Mx_Data(1, cc_count) = JSON_List(y).PAC_NOMBRE & " " & JSON_List(y).PAC_APELLIDO
                    Mx_Data(2, cc_count) = JSON_List(y).Data_Ate(i).CF_DESC
                    Mx_Data(3, cc_count) = JSON_List(y).Data_Ate(i).PRU_DESC
                    Mx_Data(4, cc_count) = JSON_List(y).Data_Ate(i).TP_RESUL_COD
                    If (JSON_List(y).Data_Ate(i).TP_RESUL_COD.ToUpper = "A") Then
                        Mx_Data(5, cc_count) = JSON_List(y).Data_Ate(i).ATE_RESULTADO
                    Else
                        Mx_Data(5, cc_count) = JSON_List(y).Data_Ate(i).ATE_RESULTADO_NUM
                    End If
                    If (JSON_List(y).Data_Ate(i).ID_U_MEDIDA <> 1) Then
                        Mx_Data(6, cc_count) = JSON_List(y).Data_Ate(i).UM_DESC
                    Else
                        Mx_Data(6, cc_count) = ""
                    End If
                    If (JSON_List(y).Data_Ate(i).TP_RESUL_COD.ToUpper <> "A") Then
                        Dim nVal As Double = Mx_Data(5, cc_count)
                        Dim nDesde As Double = JSON_List(y).Data_Ate(i).ATE_R_DESDE
                        Dim nHasta As Double = JSON_List(y).Data_Ate(i).ATE_R_HASTA
                        If (nVal < nDesde) Then
                            Mx_Data(7, cc_count) = "B"
                        ElseIf (nVal > nHasta) Then
                            Mx_Data(7, cc_count) = "A"
                        Else
                            Mx_Data(7, cc_count) = ""
                        End If
                    End If
                    Mx_Data(8, cc_count) = JSON_List(y).Data_Ate(i).ATE_R_DESDE
                    Mx_Data(9, cc_count) = JSON_List(y).Data_Ate(i).ATE_R_HASTA
                    Mx_Data(10, cc_count) = JSON_List(y).PREVE_DESC
                    Mx_Data(11, cc_count) = JSON_List(y).PROC_DESC
                    Mx_Data(12, cc_count) = JSON_List(y).PROGRA_DESC
                    Mx_Data(13, cc_count) = JSON_List(y).ATE_FECHA
                    Mx_Data(14, cc_count) = JSON_List(y).SUBP_DESC
                    Mx_Data(15, cc_count) = JSON_List(y).Data_Ate(i).ATE_OMI
                Next i
            End If
        Next y
        'Crear Tabla
        Dim Xls As New SLDocument
        Dim tablePosRow As Integer = 9
        Dim tablePosCol As Integer = 1
        'Colocar Título
        Xls.SetCellValue(1, 1, "Determinaciones Peñalolén")
        Xls.SetCellValue(2, 1, "Fecha desde: " & Format(Date_01, "dd/MM/yyyy"))
        Xls.SetCellValue(3, 1, "Fecha hasta: " & Format(Date_02, "dd/MM/yyyy"))
        Xls.SetCellValue(4, 1, "Lugar TM: " & Ddl_Text(0))
        Xls.SetCellValue(5, 1, "Previsión: " & Ddl_Text(1))
        Xls.SetCellValue(6, 1, "Programa: " & Ddl_Text(2))
        Xls.SetCellValue(7, 1, "Sub Programa: " & Ddl_Text(3))
        'Crear estilo para los títulos
        Dim TitleStyle = Xls.CreateStyle()
        TitleStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        TitleStyle.Font.Bold = True
        TitleStyle.Font.FontSize = 24
        Xls.SetCellStyle(1, 1, TitleStyle)
        Xls.MergeWorksheetCells(1, 1, 1, 6)
        TitleStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        TitleStyle.Font.Bold = True
        TitleStyle.Font.FontSize = 16
        For a = 2 To 7
            Xls.SetCellStyle(a, 1, TitleStyle)
            Xls.MergeWorksheetCells(a, 1, a, 3)
        Next a
        'Llenar Cabeceras
        Xls.RenameWorksheet("Sheet1", "Atenciones por Médico: " & Mx_Data(1, 0))
        Dim tablePosCol_now As Integer = tablePosCol
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "N° Atención") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Nombre Paciente") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Exámen") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Determinación") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "T") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Resultado") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Unidad") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "E") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Rango Desde") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Rango Hasta") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Previsión") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Lugar de TM") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Programa") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Fecha Atención") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Sub Programa") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "OC")

        'Crear estilo para las cabeceras
        Dim colHeaderStyle = Xls.CreateStyle()
        colHeaderStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.CenterContinuous)
        colHeaderStyle.Font.Bold = True
        colHeaderStyle.Font.FontSize = 14
        'Asignar un estilo
        For x = tablePosCol To tablePosCol_now
            Xls.SetCellStyle(tablePosRow, x, colHeaderStyle)
            Xls.AutoFitColumn(x, 250)
        Next x
        'Determinar ancho de Columnas
        tablePosCol_now = tablePosCol
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 40) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 40) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 40) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 10) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 50) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 10) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 20)
        'Agregar el contenido de la matriz
        Dim tablePosRow_now As Integer = tablePosRow
        For y = 0 To Mx_Data.GetUpperBound(1)
            'Sumar +1 a la fila seleccionada
            tablePosRow_now += 1
            For x = 0 To Mx_Data.GetUpperBound(0)
                If (IsNothing(Mx_Data(x, y)) = False) Then
                    Select Case x
                        Case 5, 8, 9, 15
                            Dim aaa As Integer = 0
                            If (IsNumeric(Mx_Data(x, y)) = True) Then
                                Xls.SetCellValue(tablePosRow_now, tablePosCol + x, CDbl(Mx_Data(x, y)))
                            Else
                                Xls.SetCellValue(tablePosRow_now, tablePosCol + x, Mx_Data(x, y))
                            End If
                        Case Else
                            Xls.SetCellValue(tablePosRow_now, tablePosCol + x, Mx_Data(x, y))
                    End Select
                End If
            Next x
            'Formato de celdas
            Dim style = Xls.CreateStyle()
            'If (CStr(Mx_Data(5, y)).Split(".").GetUpperBound(0) > 0) Then
            style.FormatCode = "###,###,##0.###"
            'Else
            '    style.FormatCode = "###,###,##0"
            'End If
            If (IsNumeric(Mx_Data(5, y)) = True) Then
                Xls.SetCellStyle(tablePosRow_now, tablePosCol + 5, style)
            End If
            If (IsNumeric(Mx_Data(8, y)) = True) Then
                Xls.SetCellStyle(tablePosRow_now, tablePosCol + 8, style)
            End If
            If (IsNumeric(Mx_Data(9, y)) = True) Then
                Xls.SetCellStyle(tablePosRow_now, tablePosCol + 9, style)
            End If
            'style.FormatCode = "dd/mm/yyyy h:mm:ss"
            style.FormatCode = "dd/mm/yyyy"
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 2, style)
            'style.FormatCode = "$ ###,###,##0"
            'Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 3, style)
            'Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 2, style)
            'Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 1, style)
            'Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 0, style)
        Next y
        ''Definir Estilos de "Totales"
        'tablePosRow_now += 1
        'Dim style_total = Xls.CreateStyle()
        'style_total.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Right)
        'style_total.Font.Bold = True
        'style_total.Font.FontSize = 16
        'Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 4, style_total)
        'style_total.Font.Bold = False
        'style_total.FormatCode = "$ ###,###,##0"
        'Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 3, style_total)
        'Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 2, style_total)
        'Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 1, style_total)
        'Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 0, style_total)
        ''Insertar totales
        'Dim nChar As Integer = Asc("A") - 1
        'Xls.SetCellValue(tablePosRow_now, tablePosCol_now - 4, "Total:")
        'Xls.SetCellValue(tablePosRow_now, tablePosCol_now - 3, "=SUM(" & (Chr(nChar + tablePosCol_now - 3) & tablePosRow + 1) & ":" & (Chr(nChar + tablePosCol_now - 3) & tablePosRow_now - 1) & ")")
        'Xls.SetCellValue(tablePosRow_now, tablePosCol_now - 2, "=SUM(" & (Chr(nChar + tablePosCol_now - 2) & tablePosRow + 1) & ":" & (Chr(nChar + tablePosCol_now - 2) & tablePosRow_now - 1) & ")")
        'Xls.SetCellValue(tablePosRow_now, tablePosCol_now - 1, "=SUM(" & (Chr(nChar + tablePosCol_now - 1) & tablePosRow + 1) & ":" & (Chr(nChar + tablePosCol_now - 1) & tablePosRow_now - 1) & ")")
        'Xls.SetCellValue(tablePosRow_now, tablePosCol_now - 0, "=SUM(" & (Chr(nChar + tablePosCol_now - 0) & tablePosRow + 1) & ":" & (Chr(nChar + tablePosCol_now - 0) & tablePosRow_now - 1) & ")")
        'Determinar Tabla
        Dim Inner_Table As SLTable = Xls.CreateTable(tablePosRow, tablePosCol, tablePosRow_now, tablePosCol_now)
        Inner_Table.SetTableStyle(SLTableStyleTypeValues.Dark11)
        Xls.InsertTable(Inner_Table)
        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Determ_Peñalolen" & " " & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        Xls.SaveAs(Ruta_save_local & Relative_Path)
        Dim RUTA_ZELDA As String = DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
        'Devolver la url del archivo generado
        Dim NN_CORREO As New N_EMAIL
        NN_CORREO.Set_Destinat = EMAIL
        NN_CORREO.Set_Asunto = "Resultados Peñalolén " & Format(Date_01, "dd/MM/yyyy") & " - " & Format(Date_02, "dd/MM/yyyy")
        Dim HTML As String = Write_Email(Date_01, Date_02, RUTA_ZELDA)
        Return NN_CORREO.Send_Email(HTML)
    End Function
    Private Function Write_Email(ByVal Date_01 As Date, ByVal Date_02 As Date, ByVal link As String) As String
        Dim HTML_str As String = ""
        HTML_str &= "<!DOCTYPE html>" & vbLf
        HTML_str &= "<!DOCTYPE html>" & vbLf
        HTML_str &= "<html>" & vbLf
        HTML_str &= "<head>" & vbLf
        HTML_str &= "<meta http-equiv='Content-Type' content='text/html; charset=utf-8'/>" & vbLf
        HTML_str &= "<title>Resultados Peñalolén</title>" & vbLf
        HTML_str &= "</head>" & vbLf
        HTML_str &= "<body>" & vbLf
        HTML_str &= "    <link href='https://fonts.googleapis.com/css?family=Saira' rel='stylesheet'>" & vbLf
        HTML_str &= "    <table style='width: 90%; margin: 0 auto; font-family: 'Saira', sans-serif;'>" & vbLf
        HTML_str &= "        <tr>" & vbLf
        HTML_str &= "            <th align='center' style='padding: 0;'>" & vbLf
        HTML_str &= "                <img style='width: 40%; height: auto; margin: 0; padding: 0; float: left;' src='http://miequiporemotocadel.ddns.net:8888/Resourses/Img/Logo/logo_irislab_3.jpg' />" & vbLf
        HTML_str &= "                <img style='width: 40%; height: auto; margin: 0; padding: 0; float: right;' src='http://www.labholanda.cl/img/Logo.jpg' />" & vbLf
        HTML_str &= "            </th>" & vbLf
        HTML_str &= "        </tr>" & vbLf
        HTML_str &= "        <tr>" & vbLf
        HTML_str &= "            <td style='padding: 5px; padding-top: 15px;'>" & vbLf
        HTML_str &= "                <table style='width: 100%; border-collapse: collapse; border: 2px solid #2d43d5;'>" & vbLf
        HTML_str &= "                    <tr>" & vbLf
        HTML_str &= "                        <th colspan='2' style='color: #ffffff; background: #2d43d5; font-size: 22px; padding: 5px;'>Solicitud de Documento:</th>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        HTML_str &= "                        <td>Documento Solicitado:</td>" & vbLf
        HTML_str &= "                        <td>Resultados Peñalolén.-</td>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        HTML_str &= "                        <td>Desde:</td>" & vbLf
        HTML_str &= "                        <td>" & Format(Date_01, "dd/MM/yyyy") & "</td>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        HTML_str &= "                    <tr style='border-bottom: 1px dashed #606060;'>" & vbLf
        HTML_str &= "                        <td>Hasta:</td>" & vbLf
        HTML_str &= "                        <td>" & Format(Date_02, "dd/MM/yyyy") & "</td>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        HTML_str &= "                    <tr align='center'>" & vbLf
        HTML_str &= "                        <td colspan='2'>" & vbLf
        HTML_str &= "                            <a href='" & link & "' style='text-decoration: none; font-size: 20px;'>Descargar Archivo</a>" & vbLf
        HTML_str &= "                        </td>" & vbLf
        HTML_str &= "                    </tr>" & vbLf
        HTML_str &= "                </table>" & vbLf
        HTML_str &= "            </td>" & vbLf
        HTML_str &= "        </tr>" & vbLf
        HTML_str &= "    </table>" & vbLf
        HTML_str &= "</body>" & vbLf
        HTML_str &= "</html>" & vbLf
        Return HTML_str
    End Function
End Class