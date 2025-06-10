'Importar Bibliotecas
Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts

'Importar Capas
Imports Datos
Imports Entidades

Public Class N_Check_Val_Criticos
    'Declaraciones Generales
    Dim DD_Data As D_Check_Val_Criticos

    Sub New()
        DD_Data = New D_Check_Val_Criticos
    End Sub

#Region "HELPER"
    Function EvaluaAprobacion(item As E_IRIS_WEB_BUSCA_RESULTADOS_CRITICOS_Y_TIEMPO_RESPUESTA) As String
        If item.ES_SAPU Then
            If item.APRUEBA_SAPU Then
                Return "APRUEBA"
            Else
                Return "NO APRUEBA"
            End If
        Else
            If item.APRUEBA_NORMAL Then
                Return "APRUEBA"
            Else
                Return "NO APRUEBA"
            End If
        End If
    End Function
#End Region

    Function IRIS_WEB_GET_NOTIFICATION_COUNTS(ID_ATE_RES As Integer) As E_IRIS_WEB_GET_NOTIFICATION_COUNTS
        Return DD_Data.IRIS_WEB_GET_NOTIFICATION_COUNTS(ID_ATE_RES)
    End Function
    Function Gen_Excel_FINAL(DOMAIN_URL As String, DESDE As String, HASTA As String, ID_CF As Long, ID_PRE2 As Long, ID_EST As Long, ID_TP_ATENCION As Integer, ID_RLS_LS As Integer) As String
        Debug.WriteLine("Inciando Gen_Excel_FINAL")
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim List_Activo_01 As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Dim List_Activo_02 As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)

        List_Activo_01 = NN_Activos.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        List_Activo_02 = NN_Activos.IRIS_WEBF_BUSCA_PREVISION_ACTIVO

        Dim Select_Exam As String = "Todos"
        For y = 0 To (List_Activo_01.Count - 1)
            If (List_Activo_01(y).ID_CODIGO_FONASA = ID_CF) Then
                Select_Exam = List_Activo_01(y).CF_DESC
                Exit For
            End If
        Next y

        Dim Select_Prev As String = "Todos"
        For y = 0 To (List_Activo_02.Count - 1)
            If (List_Activo_02(y).ID_PREVE = ID_PRE2) Then
                Select_Prev = List_Activo_02(y).PREVE_DESC
                Exit For
            End If
        Next y

        Dim Select_Stat As String = "Todos"
        Select Case ID_EST
            Case 1
                Select_Stat = "Bajo"
            Case 2
                Select_Stat = "Alto"
        End Select

        Dim Data_OUT = D_Check_Val_Criticos.IRIS_WEB_BUSCA_RESULTADOS_CRITICOS_Y_TIEMPO_RESPUESTA(DESDE, HASTA, ID_CF, ID_PRE2, ID_EST, ID_TP_ATENCION, ID_RLS_LS)
        'Datos recividos
        Debug.WriteLine($"Data_OUT: {Data_OUT}")
        'Armar Excel
        'Declaraciones Generales
        If (Data_OUT.Count = 0) Then
            Debug.WriteLine($"ERROR SIN DATOS {Data_OUT}")
            Return "null"
            Exit Function
        End If

        'Crear Tabla
        Dim Xls As New SLDocument
        Dim tablePosRow As Integer = 8
        Dim tablePosCol As Integer = 1

        'Colocar Título
        Xls.SetCellValue(1, 1, "Revisión de Valores Críticos: ")
        Xls.SetCellValue(2, 1, "Fecha desde: " & Format(CDate(DESDE), "dd/MM/yyyy"))
        Xls.SetCellValue(3, 1, "Fecha hasta: " & Format(CDate(HASTA), "dd/MM/yyyy"))
        Xls.SetCellValue(4, 1, "Exámen: " & Select_Exam)
        Xls.SetCellValue(5, 1, "Previsión: " & Select_Prev)
        Xls.SetCellValue(6, 1, "Estado: " & Select_Stat)

        'Crear estilo para los títulos
        Dim TitleStyle = Xls.CreateStyle()
        TitleStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        TitleStyle.Font.Bold = True
        TitleStyle.Font.FontSize = 24
        Xls.SetCellStyle(1, 1, TitleStyle)

        TitleStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        TitleStyle.Font.Bold = True
        TitleStyle.Font.FontSize = 16
        Xls.SetCellStyle(2, 1, TitleStyle)
        Xls.SetCellStyle(3, 1, TitleStyle)
        Xls.SetCellStyle(4, 1, TitleStyle)
        Xls.SetCellStyle(5, 1, TitleStyle)
        Xls.SetCellStyle(6, 1, TitleStyle)

        Xls.MergeWorksheetCells(1, 1, 1, 6)
        Xls.MergeWorksheetCells(2, 1, 2, 3)
        Xls.MergeWorksheetCells(3, 1, 3, 3)
        Xls.MergeWorksheetCells(4, 1, 4, 3)
        Xls.MergeWorksheetCells(5, 1, 5, 3)
        Xls.MergeWorksheetCells(6, 1, 6, 3)

        'Llenar Cabeceras
        Xls.RenameWorksheet("Sheet1", "Revisión de Valores Críticos")
        Dim tablePosCol_now As Integer = tablePosCol

        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Fecha Ingreso") : tablePosCol_now += 1 'FECHA INGRESO LIS    1 listo
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Hora Ingreso") : tablePosCol_now += 1 '                      2 listo
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "N° Atención") : tablePosCol_now += 1 'No. Orden / folio      3 listo
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "RUT") : tablePosCol_now += 1 'rut                            4 listo
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Nombre Paciente") : tablePosCol_now += 1 'nombre paciente    5 listo
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Edad") : tablePosCol_now += 1 ' edad                         6 listo
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "sexo") : tablePosCol_now += 1 'sexo                          7 listo
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Lugar TdeM") : tablePosCol_now += 1 'procedencia            8 listo

        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Examen") : tablePosCol_now += 1 'examen                     9 listo
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Determinación") : tablePosCol_now += 1 'Determinación       10 lsito
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Resultado") : tablePosCol_now += 1 'resultados              11 listo

        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Alarma (Bajo - Alto)") : tablePosCol_now += 1               '12 listo
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Fecha Recep.") : tablePosCol_now += 1                       '13 listo
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Hora Recep.") : tablePosCol_now += 1                        '14 listo

        Xls.SetCellValue(tablePosRow, tablePosCol_now, "unidad") : tablePosCol_now += 1 'unidad                     15 listo
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "seccion") : tablePosCol_now += 1 '                          16 listo

        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Fecha Validación") : tablePosCol_now += 1                   '17 listo
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Hora Validación") : tablePosCol_now += 1                   ' 18 listo
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "usuario valida") : tablePosCol_now += 1 'quien valida           19 listo

        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Fecha Notificación") : tablePosCol_now += 1                 '20 listo
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Hora Notificación") : tablePosCol_now += 1                 ' 21 listo 
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Usuario Notificador") : tablePosCol_now += 1                '22 listo
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Notificado A") : tablePosCol_now += 1                       '23 listo

        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Tipo de Notificación") : tablePosCol_now += 1                  ' 24  
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Diferencia Notificación - Validación") : tablePosCol_now += 1      ' 25      
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Aprueba") : tablePosCol_now += 1                                   '26
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Número de Notificaciones") : tablePosCol_now += 1                '  27

        tablePosCol_now -= 1



        Dim fila = tablePosRow + 1
        For Each item In Data_OUT
            Dim col = tablePosCol
            Xls.SetCellValue(fila, col, item.FECHA_INGRESO) : col += 1                                          '1 listo
            Xls.SetCellValue(fila, col, item.HORA_INGRESO) : col += 1                                            '2 listo               
            Xls.SetCellValue(fila, col, item.ATE_NUM) : col += 1                                                    '3 listo

            Xls.SetCellValue(fila, col, item.PAC_RUT_DNI) : col += 1                                                  '4 listo
            Xls.SetCellValue(fila, col, item.PAC_NOMBRE_COMPLETO) : col += 1                                                    '5 listo
            Xls.SetCellValue(fila, col, item.ATE_AÑO) : col += 1                                                        '6 listo
            ' Aquí está la comprobación del sexo
            Dim sexo As String = If(item.ID_SEXO = 1, "Masculino", If(item.ID_SEXO = 2, "Femenino", "Desconocido"))
            Xls.SetCellValue(fila, col, sexo) : col += 1                                                               '7 listo
            Xls.SetCellValue(fila, col, item.PROC_DESC) : col += 1                                                     ' 8 listo

            Xls.SetCellValue(fila, col, item.CF_DESC) : col += 1                                                        '9 listo
            Xls.SetCellValue(fila, col, item.PRU_DESC) : col += 1                                                       '10 listo
            Xls.SetCellValue(fila, col, item.RESULTADO) : col += 1                                                      '11 listo      

            Xls.SetCellValue(fila, col, item.ATE_RESULTADO_ALT) : col += 1                                              '12 listo
            Xls.SetCellValue(fila, col, item.FECHA_RECEPCION) : col += 1                                                '13 listo
            Xls.SetCellValue(fila, col, item.HORA_RECEPCION) : col += 1                                                         '14 listo

            Xls.SetCellValue(fila, col, item.UM_COD) : col += 1                                                 '15 listo
            Xls.SetCellValue(fila, col, item.RLS_LS_DESC) : col += 1                                            '16 listo

            Xls.SetCellValue(fila, col, item.FECHA_VALIDACION) : col += 1                                       '17 listo
            Xls.SetCellValue(fila, col, item.HORA_VALIDACION) : col += 1                                         '18 listo   
            Xls.SetCellValue(fila, col, item.USU_VALIDA) : col += 1                                                 '19 listo

            Xls.SetCellValue(fila, col, item.FECHA_NOTIFICACION) : col += 1                                     '20 listo
            Xls.SetCellValue(fila, col, item.HORA_NOTIFICACION) : col += 1                                      '21 listo
            Xls.SetCellValue(fila, col, item.QUIEN_NOTIFICA) : col += 1                                         '22 listo
            Xls.SetCellValue(fila, col, item.NOTIFICADO_A) : col += 1                                           '23 listo

            Xls.SetCellValue(fila, col, item.MEDIO_NOTIFICACION) : col += 1                                       '24 lsito  
            Xls.SetCellValue(fila, col, item.HORAS_DIFERENCIA) : col += 1                                   '25 listo

            Xls.SetCellValue(fila, col, EvaluaAprobacion(item)) : col += 1                           '26
            Xls.SetCellValue(fila, col, "Llamadas: " & item.LLAMADA & " Correos: " & item.DET_CORREO) : col += 1 '27


            fila += 1
        Next

        'Crear estilo para las cabeceras
        Dim colHeaderStyle = Xls.CreateStyle()
        colHeaderStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.CenterContinuous)
        colHeaderStyle.Font.Bold = True
        colHeaderStyle.Font.FontSize = 14

        'Asignar un estilo
        For x = tablePosCol To tablePosCol_now
            Xls.SetCellStyle(tablePosRow, x, colHeaderStyle)
            Xls.AutoFitColumn(x, 250)
            Xls.SetColumnWidth(x, Xls.GetColumnWidth(x) + 3)
        Next x

        'Agregar el contenido de la matriz
        Dim tablePosRow_now As Integer = tablePosRow
        For y = 0 To Data_OUT.Count
            'Sumar +1 a la fila seleccionada
            tablePosRow_now += 1

            ''Formato de celdas
            Dim style = Xls.CreateStyle()

            style.FormatCode = ""
            style.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol + 4, style)
        Next y

        'Determinar Tabla
        Dim Inner_Table As SLTable = Xls.CreateTable(tablePosRow, tablePosCol, tablePosRow_now, tablePosCol_now)
        Inner_Table.SetTableStyle(SLTableStyleTypeValues.Dark11)
        Xls.InsertTable(Inner_Table)

        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Revision_Val_Criticos_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        Xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
    Function IRIS_WEBF_FINALIZAR_PROCESO(ID_ATE_RES_SUPREME As Integer, S_Id_User As Integer, NOTIFICADO As String, ID_TP_CRITICO As Integer, ESTADO_NOTIFICADO As Integer) As String
        Return DD_Data.IRIS_WEBF_FINALIZAR_PROCESO(ID_ATE_RES_SUPREME, S_Id_User, NOTIFICADO, ID_TP_CRITICO, ESTADO_NOTIFICADO)
    End Function
    Function IRIS_WEBF_GRABA_DET_VALORES_CRITICOS_DESCRIPCION(ID_ATE_RES_SUPREME As Integer, S_Id_User As Integer, DATE_str01 As String, NOTIFICADO As String, ID_TP_CRITICO As Integer, CAUSA As String, LLAMADO As Integer, CORREO As Integer, ESTADO_NOTIFICADO As Integer) As String
        Return DD_Data.IRIS_WEBF_GRABA_DET_VALORES_CRITICOS_DESCRIPCION(ID_ATE_RES_SUPREME, S_Id_User, DATE_str01, NOTIFICADO, ID_TP_CRITICO, CAUSA, LLAMADO, CORREO, ESTADO_NOTIFICADO)
    End Function
    Function IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Long, ByVal ID_PRE2 As Long, ByVal ID_EST As Long) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_TM")
        Dim ID_PROC As Integer

        Try
            ID_PROC = CInt(galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try
        Return DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS(DESDE, HASTA, ID_CF, ID_PRE2, ID_EST, ID_PROC)

    End Function

    Function IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_ALTERADOS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Long, ByVal ID_PRE2 As Long, ByVal ID_EST As Long, ByVal SECCION As String) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_TM")
        Dim ID_PROC As Integer

        Try
            ID_PROC = CInt(galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try
        Return DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_ALTERADOS(DESDE, HASTA, ID_CF, ID_PRE2, ID_EST, SECCION, ID_PROC)

    End Function

    Function Gen_Excel(ByVal DOMAIN_URL As String, ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Long, ByVal ID_PRE2 As Long, ByVal ID_EST As Long) As String
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim List_Activo_01 As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Dim List_Activo_02 As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)

        List_Activo_01 = NN_Activos.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        List_Activo_02 = NN_Activos.IRIS_WEBF_BUSCA_PREVISION_ACTIVO

        Dim Select_Exam As String = "Todos"
        For y = 0 To (List_Activo_01.Count - 1)
            If (List_Activo_01(y).ID_CODIGO_FONASA = ID_CF) Then
                Select_Exam = List_Activo_01(y).CF_DESC
                Exit For
            End If
        Next y

        Dim Select_Prev As String = "Todos"
        For y = 0 To (List_Activo_02.Count - 1)
            If (List_Activo_02(y).ID_PREVE = ID_PRE2) Then
                Select_Prev = List_Activo_02(y).PREVE_DESC
                Exit For
            End If
        Next y

        Dim Select_Stat As String = "Todos"
        Select Case ID_EST
            Case 1
                Select_Stat = "Bajo"
            Case 2
                Select_Stat = "Alto"
        End Select

        'Consulta Principal
        Dim Data_OUT As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_TM")
        Dim ID_PROC As Integer

        Try
            ID_PROC = CInt(galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try
        Data_OUT = DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS(DESDE, HASTA, ID_CF, ID_PRE2, ID_EST, ID_PROC)

        'Armar Excel
        'Declaraciones Generales
        If (Data_OUT.Count = 0) Then
            Return "null"
            Exit Function
        End If

        Dim Mx_Data(0, 0) As Object
        ReDim Mx_Data(19, 0)

        'Vaciar Matriz
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x

        'Llenar Matriz
        For y = 0 To (Data_OUT.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(Mx_Data.GetUpperBound(0), y)
            End If
            Dim Calc_Age As New N_Calc_Age

            Mx_Data(0, y) = Data_OUT(y).ATE_NUM
            Mx_Data(1, y) = Data_OUT(y).PAC_RUT
            Mx_Data(2, y) = Data_OUT(y).ATE_DNI
            Mx_Data(3, y) = Data_OUT(y).NAC_DESC
            Mx_Data(4, y) = Data_OUT(y).PAC_NOMBRE & " " & Data_OUT(y).PAC_APELLIDO
            Mx_Data(5, y) = Format(Data_OUT(y).PAC_FNAC, "dd/MM/yyyy")
            Mx_Data(6, y) = Calc_Age.IrisLAB_Cal_Edad_Exacta(Data_OUT(y).PAC_FNAC, Date.Now, True)
            Mx_Data(7, y) = Format(Data_OUT(y).ATE_FECHA, "dd/MM/yyyy")
            Mx_Data(8, y) = Data_OUT(y).PROC_DESC
            Mx_Data(9, y) = Data_OUT(y).ATE_NUM_INTERNO
            Mx_Data(10, y) = Data_OUT(y).PROGRA_DESC
            Mx_Data(11, y) = Data_OUT(y).SECTOR_DESC
            Mx_Data(12, y) = Data_OUT(y).PRU_DESC

            'Seleccionar valor
            Dim Res_Num As Double = Data_OUT(y).ATE_RESULTADO_NUM
            Dim Res_Str As String = Data_OUT(y).ATE_RESULTADO
            Dim Res_Alt As String = Data_OUT(y).ATE_RESULTADO_ALT

            If (Res_Str <> Nothing) Then
                Try
                    Mx_Data(13, y) = CDbl(Res_Str)
                Catch
                    Mx_Data(13, y) = Res_Str
                End Try
            ElseIf (Res_Num <> Nothing) Then
                Mx_Data(13, y) = Res_Num
            Else
                Mx_Data(13, y) = Res_Alt
            End If

            Mx_Data(14, y) = Data_OUT(y).DOC_NOMBRE & " " & Data_OUT(y).DOC_APELLIDO

            'Comprobar Rango
            Dim Rage As Integer = Data_OUT(y).ATE_RR_ALTOBAJO
            Select Case Rage
                Case 1
                    Mx_Data(15, y) = "B"
                Case 2
                    Mx_Data(15, y) = "A"
                Case Else
                    Mx_Data(15, y) = ""
            End Select

            Try
                Mx_Data(16, y) = CDbl(Data_OUT(y).ATE_RR_DESDE)
            Catch
                Mx_Data(16, y) = Data_OUT(y).ATE_RR_DESDE
            End Try

            Try
                Mx_Data(17, y) = CDbl(Data_OUT(y).ATE_R_DESDE)
            Catch
                Mx_Data(17, y) = Data_OUT(y).ATE_R_DESDE
            End Try

            Try
                Mx_Data(18, y) = CDbl(Data_OUT(y).ATE_R_HASTA)
            Catch
                Mx_Data(18, y) = Data_OUT(y).ATE_R_HASTA
            End Try

            Try
                Mx_Data(19, y) = CDbl(Data_OUT(y).ATE_RR_HASTA)
            Catch
                Mx_Data(19, y) = Data_OUT(y).ATE_RR_HASTA
            End Try

        Next y

        'Crear Tabla
        Dim Xls As New SLDocument
        Dim tablePosRow As Integer = 8
        Dim tablePosCol As Integer = 1

        'Colocar Título
        Xls.SetCellValue(1, 1, "Revisión de Valores Críticos: ")
        Xls.SetCellValue(2, 1, "Fecha desde: " & Format(DESDE, "dd/MM/yyyy"))
        Xls.SetCellValue(3, 1, "Fecha hasta: " & Format(HASTA, "dd/MM/yyyy"))
        Xls.SetCellValue(4, 1, "Exámen: " & Select_Exam)
        Xls.SetCellValue(5, 1, "Previsión: " & Select_Prev)
        Xls.SetCellValue(6, 1, "Estado: " & Select_Stat)

        'Crear estilo para los títulos
        Dim TitleStyle = Xls.CreateStyle()
        TitleStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        TitleStyle.Font.Bold = True
        TitleStyle.Font.FontSize = 24
        Xls.SetCellStyle(1, 1, TitleStyle)

        TitleStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        TitleStyle.Font.Bold = True
        TitleStyle.Font.FontSize = 16
        Xls.SetCellStyle(2, 1, TitleStyle)
        Xls.SetCellStyle(3, 1, TitleStyle)
        Xls.SetCellStyle(4, 1, TitleStyle)
        Xls.SetCellStyle(5, 1, TitleStyle)

        Xls.MergeWorksheetCells(1, 1, 1, 6)
        Xls.MergeWorksheetCells(2, 1, 2, 3)
        Xls.MergeWorksheetCells(3, 1, 3, 3)
        Xls.MergeWorksheetCells(4, 1, 4, 3)
        Xls.MergeWorksheetCells(5, 1, 5, 3)

        'Llenar Cabeceras
        Xls.RenameWorksheet("Sheet1", "Revisión de Valores Críticos: " & Mx_Data(1, 0))
        Dim tablePosCol_now As Integer = tablePosCol

        Xls.SetCellValue(tablePosRow, tablePosCol_now, "N° Atención") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "RUT Paciente") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "DNI") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Nacionalidad") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Nombre Paciente") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Fecha Nac") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Edad") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Fecha") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Lugar de TM") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Num Interno") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Programa") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Sector") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Determinación") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Resultado") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Médico") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Alarma") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Muy Bajo") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Bajo") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Alto") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "muy Alto") : tablePosCol_now += 1
        tablePosCol_now -= 1

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
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'DNI
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 40) : tablePosCol_now += 1 'nombre
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 ' f nac
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1 'edad
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'fecha
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1 'lugar tm
        Xls.SetColumnWidth(tablePosCol_now, 15) : tablePosCol_now += 1 'num interno
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'programa
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'sector
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1 'determinacion
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'retultado
        Xls.SetColumnWidth(tablePosCol_now, 40) : tablePosCol_now += 1 'medico
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'alarma
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'muy bajo
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'bajo
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'añto
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'muy alto
        tablePosCol_now -= 1

        'Agregar el contenido de la matriz
        Dim tablePosRow_now As Integer = tablePosRow
        For y = 0 To Mx_Data.GetUpperBound(1)
            'Sumar +1 a la fila seleccionada
            tablePosRow_now += 1

            For x = 0 To Mx_Data.GetUpperBound(0)
                Xls.SetCellValue(tablePosRow_now, tablePosCol + x, Mx_Data(x, y))

            Next x

            'Formato de celdas
            Dim style = Xls.CreateStyle()
            style.FormatCode = "dd/mm/yyyy"
            Xls.SetCellStyle(tablePosRow_now, tablePosCol + 4, style)

            style.FormatCode = "###,###,##0.0###"
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 5, style)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 3, style)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 2, style)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 1, style)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 0, style)

            style.FormatCode = ""
            style.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol + 4, style)
        Next y

        'Determinar Tabla
        Dim Inner_Table As SLTable = Xls.CreateTable(tablePosRow, tablePosCol, tablePosRow_now, tablePosCol_now)
        Inner_Table.SetTableStyle(SLTableStyleTypeValues.Dark11)
        Xls.InsertTable(Inner_Table)

        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Revision_Val_Criticos_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        Xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function


    Function Gen_Excel2(ByVal DOMAIN_URL As String, ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_CF As Long, ByVal ID_PRE2 As Long, ByVal ID_EST As Long, ByVal SECCION As String) As String
        'Declaraciones Internas
        Dim NN_Activos As New N_Gen_Activos
        Dim List_Activo_01 As New List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Dim List_Activo_02 As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)

        List_Activo_01 = NN_Activos.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS
        List_Activo_02 = NN_Activos.IRIS_WEBF_BUSCA_PREVISION_ACTIVO

        Dim Select_Exam As String = "Todos"
        For y = 0 To (List_Activo_01.Count - 1)
            If (List_Activo_01(y).ID_CODIGO_FONASA = ID_CF) Then
                Select_Exam = List_Activo_01(y).CF_DESC
                Exit For
            End If
        Next y

        Dim Select_Prev As String = "Todos"
        For y = 0 To (List_Activo_02.Count - 1)
            If (List_Activo_02(y).ID_PREVE = ID_PRE2) Then
                Select_Prev = List_Activo_02(y).PREVE_DESC
                Exit For
            End If
        Next y

        Dim Select_Stat As String = "Todos"
        Select Case ID_EST
            Case 1
                Select_Stat = "Bajo"
            Case 2
                Select_Stat = "Alto"
        End Select

        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As String = HttpContext.Current.Request.Cookies("USU_TM").Value
        'Consulta Principal
        Dim Data_OUT As New List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_TM")
        Dim ID_PROC As Integer

        Try
            ID_PROC = CInt(galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try
        Data_OUT = DD_Data.IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_ALTERADOS(DESDE, HASTA, ID_CF, ID_PRE2, ID_EST, SECCION, ID_PROC)

        'Armar Excel
        'Declaraciones Generales
        If (Data_OUT.Count = 0) Then
            Return "null"
            Exit Function
        End If

        Dim Mx_Data(0, 0) As Object
        ReDim Mx_Data(19, 0)

        'Vaciar Matriz
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        Dim ccc As Integer = 0
        'Llenar Matriz
        For y = 0 To (Data_OUT.Count - 1)

            Dim Calc_Age As New N_Calc_Age
            If (C_P_ADMIN = Data_OUT(y).id_proce Or C_P_ADMIN = 0) Then
                If (ccc > 0) Then
                    ReDim Preserve Mx_Data(Mx_Data.GetUpperBound(0), ccc)
                End If

                Mx_Data(0, ccc) = Data_OUT(y).ATE_NUM
                Mx_Data(1, ccc) = Data_OUT(y).PAC_RUT
                Mx_Data(2, ccc) = Data_OUT(y).ATE_DNI
                Mx_Data(3, ccc) = Data_OUT(y).NAC_DESC
                Mx_Data(4, ccc) = Data_OUT(y).PAC_NOMBRE & " " & Data_OUT(y).PAC_APELLIDO
                Mx_Data(5, ccc) = Format(Data_OUT(y).PAC_FNAC, "dd/MM/yyyy")
                Mx_Data(6, ccc) = Calc_Age.IrisLAB_Cal_Edad_Exacta(Data_OUT(y).PAC_FNAC, Date.Now, True)
                Mx_Data(7, ccc) = Format(Data_OUT(y).ATE_FECHA, "dd/MM/yyyy")
                Mx_Data(8, ccc) = Data_OUT(y).PROC_DESC
                Mx_Data(9, ccc) = Data_OUT(y).ATE_NUM_INTERNO
                Mx_Data(10, ccc) = Data_OUT(y).PROGRA_DESC
                Mx_Data(11, ccc) = Data_OUT(y).SECTOR_DESC
                Mx_Data(12, ccc) = Data_OUT(y).PRU_DESC

                'Seleccionar valor
                Dim Res_Num As Double = Data_OUT(y).ATE_RESULTADO_NUM
                Dim Res_Str As String = Data_OUT(y).ATE_RESULTADO
                Dim Res_Alt As String = Data_OUT(y).ATE_RESULTADO_ALT

                If (Res_Str <> Nothing) Then
                    Try
                        Mx_Data(13, ccc) = CDbl(Res_Str)
                    Catch
                        Mx_Data(13, ccc) = Res_Str
                    End Try
                ElseIf (Res_Num <> Nothing) Then
                    Mx_Data(13, ccc) = Res_Num
                Else
                    Mx_Data(13, ccc) = Res_Alt
                End If

                Mx_Data(14, ccc) = Data_OUT(y).DOC_NOMBRE & " " & Data_OUT(y).DOC_APELLIDO

                'Comprobar Rango

                Mx_Data(15, ccc) = Data_OUT(y).ATE_RESULTADO_ALT

                Try
                    Mx_Data(16, ccc) = CDbl(Data_OUT(y).ATE_RR_DESDE)
                Catch
                    Mx_Data(16, ccc) = Data_OUT(y).ATE_RR_DESDE
                End Try

                Try
                    Mx_Data(17, ccc) = CDbl(Data_OUT(y).ATE_R_DESDE)
                Catch
                    Mx_Data(17, ccc) = Data_OUT(y).ATE_R_DESDE
                End Try

                Try
                    Mx_Data(18, ccc) = CDbl(Data_OUT(y).ATE_R_HASTA)
                Catch
                    Mx_Data(18, ccc) = Data_OUT(y).ATE_R_HASTA
                End Try

                Try
                    Mx_Data(19, ccc) = CDbl(Data_OUT(y).ATE_RR_HASTA)
                Catch
                    Mx_Data(19, ccc) = Data_OUT(y).ATE_RR_HASTA
                End Try


                ccc = ccc + 1
            End If


        Next y

        'Crear Tabla
        Dim Xls As New SLDocument
        Dim tablePosRow As Integer = 8
        Dim tablePosCol As Integer = 1

        'Colocar Título
        Xls.SetCellValue(1, 1, "Revisión de Valores Alterados: ")
        Xls.SetCellValue(2, 1, "Fecha desde: " & Format(DESDE, "dd/MM/yyyy"))
        Xls.SetCellValue(3, 1, "Fecha hasta: " & Format(HASTA, "dd/MM/yyyy"))
        Xls.SetCellValue(4, 1, "Exámen: " & Select_Exam)
        Xls.SetCellValue(5, 1, "Previsión: " & Select_Prev)
        Xls.SetCellValue(6, 1, "Estado: " & Select_Stat)

        'Crear estilo para los títulos
        Dim TitleStyle = Xls.CreateStyle()
        TitleStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        TitleStyle.Font.Bold = True
        TitleStyle.Font.FontSize = 24
        Xls.SetCellStyle(1, 1, TitleStyle)

        TitleStyle.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Left)
        TitleStyle.Font.Bold = True
        TitleStyle.Font.FontSize = 16
        Xls.SetCellStyle(2, 1, TitleStyle)
        Xls.SetCellStyle(3, 1, TitleStyle)
        Xls.SetCellStyle(4, 1, TitleStyle)
        Xls.SetCellStyle(5, 1, TitleStyle)
        Xls.SetCellStyle(6, 1, TitleStyle)

        Xls.MergeWorksheetCells(1, 1, 1, 6)
        Xls.MergeWorksheetCells(2, 1, 2, 3)
        Xls.MergeWorksheetCells(3, 1, 3, 3)
        Xls.MergeWorksheetCells(4, 1, 4, 3)
        Xls.MergeWorksheetCells(5, 1, 5, 3)
        Xls.MergeWorksheetCells(6, 1, 6, 3)

        'Llenar Cabeceras
        Xls.RenameWorksheet("Sheet1", "Revisión de Valores Alterados: " & Mx_Data(1, 0))
        Dim tablePosCol_now As Integer = tablePosCol

        Xls.SetCellValue(tablePosRow, tablePosCol_now, "N° Atención") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "RUT Paciente") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "DNI") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Nacionalidad") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Nombre Paciente") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Fecha Nac") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Edad") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Fecha") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Lugar de TM") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Num Interno") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Programa") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Sector") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Determinación") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Resultado") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Médico") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Alarma") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Muy Bajo") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Bajo") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Alto") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "muy Alto") : tablePosCol_now += 1
        tablePosCol_now -= 1

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
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'DNI
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 40) : tablePosCol_now += 1 'nombre
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 ' f nac
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1 'edad
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'fecha
        Xls.SetColumnWidth(tablePosCol_now, 30) : tablePosCol_now += 1 'lugar tm
        Xls.SetColumnWidth(tablePosCol_now, 15) : tablePosCol_now += 1 'num interno
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'programa
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'sector
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1 'determinacion
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'retultado
        Xls.SetColumnWidth(tablePosCol_now, 40) : tablePosCol_now += 1 'medico
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'alarma
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'muy bajo
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'bajo
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'añto
        Xls.SetColumnWidth(tablePosCol_now, 20) : tablePosCol_now += 1 'muy alto
        tablePosCol_now -= 1

        'Agregar el contenido de la matriz
        Dim tablePosRow_now As Integer = tablePosRow
        For y = 0 To Mx_Data.GetUpperBound(1)
            'Sumar +1 a la fila seleccionada
            tablePosRow_now += 1

            For x = 0 To Mx_Data.GetUpperBound(0)
                Xls.SetCellValue(tablePosRow_now, tablePosCol + x, Mx_Data(x, y))
            Next x

            'Formato de celdas
            Dim style = Xls.CreateStyle()
            style.FormatCode = "dd/mm/yyyy"
            Xls.SetCellStyle(tablePosRow_now, tablePosCol + 4, style)

            style.FormatCode = "###,###,##0.0###"
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 5, style)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 3, style)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 2, style)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 1, style)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol_now - 0, style)

            style.FormatCode = ""
            style.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol + 4, style)
        Next y

        'Determinar Tabla
        Dim Inner_Table As SLTable = Xls.CreateTable(tablePosRow, tablePosCol, tablePosRow_now, tablePosCol_now)
        Inner_Table.SetTableStyle(SLTableStyleTypeValues.Dark11)
        Xls.InsertTable(Inner_Table)

        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Revision_Val_alterados_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        Xls.SaveAs(Ruta_save_local & Relative_Path)

        'Devolver la url del archivo generado
        Return DOMAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function

    Function IRIS_WEBF_BUSCA_VALOR_CRITICO_POR_ID_ATE_RESULTADO(ByVal ID_ATE_RES As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)

        Return DD_Data.IRIS_WEBF_BUSCA_VALOR_CRITICO_POR_ID_ATE_RESULTADO(ID_ATE_RES)

    End Function

    Function IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES(ID_ATE_RES As Integer, ES_SAPU As Boolean) As List(Of E_IRIS_WEBF_BUSCA_EST_ESTADOS_VALORES_CRITICOS)

        Return DD_Data.IRIS_WEBF_BUSCA_DETALLE_VALORES_CRITICOS_QUE_SE_HIZO_POR_ID_ATE_RES(ID_ATE_RES, ES_SAPU)

    End Function
End Class