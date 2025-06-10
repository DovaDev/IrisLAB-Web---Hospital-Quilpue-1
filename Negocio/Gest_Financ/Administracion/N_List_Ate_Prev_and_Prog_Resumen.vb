Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports Datos
Imports Entidades
Public Class N_List_Ate_Prev_and_Prog_Resumen
    Dim DD_Gen_Activos As D_Gen_Activos
    Dim DD_Data As D_List_Ate_Prev_and_Prog_Summary
    Sub New()
        DD_Gen_Activos = New D_Gen_Activos
        DD_Data = New D_List_Ate_Prev_and_Prog_Summary
    End Sub
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA(ByVal ID_PRE2 As Long, ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_PROGRAMA)
        Return DD_Data.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA(ID_PRE2, DESDE, HASTA)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_PROGRAMA(ByVal ID_PRE2 As Long, ByVal ID_PRE3 As Long, ByVal DESDE As Date, ByVal HASTA As Date) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_PROGRAMA)
        Return DD_Data.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_PROGRAMA(ID_PRE2, ID_PRE3, DESDE, HASTA)
    End Function
    Function IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA_ID(ByVal ID_Previs As Long, ByVal Date_01 As Date, ByVal ID_Fonasa As Long) As List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA_ID)
        Return DD_Data.IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA_ID(ID_Previs, Format(Date_01, "yyyy"), ID_Fonasa)
    End Function
    Function IRIS_WEBF_BUSCA_RELACION_PREV_PROCE_POR_ID_PREV(ByVal ID_Prev As Long) As List(Of E_IRIS_WEBF_BUSCA_RELACION_PREV_PROCE_POR_ID_PREV)
        Return DD_Data.IRIS_WEBF_BUSCA_RELACION_PREV_PROCE_POR_ID_PREV(ID_Prev)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_LUGAR(ByVal SQL_Transact As String) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_LUGAR)
        Return DD_Data.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_LUGAR(SQL_Transact)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_LUGAR_PROGRAMA(ByVal SQL_Transact As String) As List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_LUGAR_PROGRAMA)
        Return DD_Data.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_LUGAR_PROGRAMA(SQL_Transact)
    End Function
    Function Gen_Excel(ByVal MAIN_URL As String, ByVal ID_PREV As Long, ByVal ID_PROG As String, ByVal DATE_str01 As String, ByVal DATE_str02 As String) As String
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim Date_01 As Date = NN_Date.strToDate(Split(DATE_str01, "/")(2), Split(DATE_str01, "/")(1), Split(DATE_str01, "/")(0))
        Dim Date_02 As Date = NN_Date.strToDate(Split(DATE_str02, "/")(2), Split(DATE_str02, "/")(1), Split(DATE_str02, "/")(0))
        'Declaraciones Hemograma/VHS
        Dim Hem_Pos As Long = -1
        Dim VHS_Pos As Long = -1
        'Declaraciones Internas
        Dim Data_OUT As New List(Of E_Ate_Prev_Prog_JSON_Output)
        Dim NN_Search As New N_List_Ate_Prev_and_Prog_Resumen
        Dim Data_Search As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_PROGRAMA)
        'Debug
        Debug.WriteLine(">>>TABLA DE ATENCIONES POR PREVISIÓN Y PROGRAMA<<<")
        Debug.WriteLine("Inicializar consultas a la Base de Datos.")
        'Realizar consulta inicial
        Select Case (ID_PROG)
            Case 0, "", "null", "0", Nothing
                Data_Search = NN_Search.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA(ID_PREV, Date_01, Date_02)
            Case Else
                Data_Search = NN_Search.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_PROGRAMA(ID_PREV, ID_PROG, Date_01, Date_02)
        End Select
        'Recorrer consulta general
        For y = 0 To (Data_Search.Count - 1)
            Dim ItemList As New E_Ate_Prev_Prog_JSON_Output
            Dim Data_Fonasa As New List(Of E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA_ID)
            Dim Data_Proc_N As New List(Of E_IRIS_WEBF_BUSCA_RELACION_PREV_PROCE_POR_ID_PREV)
            'Debug
            Debug.WriteLine("Armando Columnas Exámen N° " & Format(y + 1, "###,000"))
            'Realizar consultas
            Data_Fonasa = NN_Search.IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA_ID(ID_PREV, Date_02, Data_Search(y).ID_CODIGO_FONASA)
            'Agregar Código Fonasa sin el guión y número que le sigue
            Select Case (InStr(Data_Search(y).CF_COD, "-"))
                Case 0
                    ItemList.CF_COD = Data_Search(y).CF_COD
                Case Else
                    Dim Cod_Fonasa() As String = Split(Data_Search(y).CF_COD, "-")
                    Data_Search(y).CF_COD = Cod_Fonasa(0)
                    ItemList.CF_COD = Cod_Fonasa(0)
            End Select
            'Reemplazar Nombre
            'ItemList.CF_DESC = ThisClass.changeDescripc(ItemList.CF_COD, Data_Search(y).CF_DESC)
            ItemList.CF_DESC = Data_Search(y).CF_DESC
            'Agregar el resto de elementos
            ItemList.TOTAL_ATE = Data_Search(y).TOTAL_ATE
            ItemList.TOTAL_PREVE = Data_Search(y).TOTAL_PREVE
            ItemList.TOT_FONASA = Data_Search(y).TOT_FONASA
            ItemList.TOTA_SIS = Data_Search(y).TOTA_SIS
            ItemList.TOTA_USU = Data_Search(y).TOTA_USU
            ItemList.TOTA_COPA = Data_Search(y).TOTA_COPA
            ItemList.ID_CODIGO_FONASA = Data_Search(y).ID_CODIGO_FONASA
            ItemList.ID_ESTADO = Data_Search(y).ID_ESTADO
            ItemList.ID_PROGRA = Data_Search(y).ID_PROGRA
            ItemList.PROGRA_DESC = Data_Search(y).PROGRA_DESC
            'Agregar objetos
            ItemList.Data_Fonasa = Data_Fonasa(0)
            Data_OUT.Add(ItemList)
            'Comprobar Hemograma/VHS
            Select Case (ItemList.CF_COD)
                Case "0301086"      'VHS
                    VHS_Pos = Data_OUT.Count - 1
                Case "0301045"      'Hemograma
                    Hem_Pos = Data_OUT.Count - 1
            End Select
        Next y
        'Agregar Procedencias
        Dim Data_Proc_Info As New List(Of E_IRIS_WEBF_BUSCA_RELACION_PREV_PROCE_POR_ID_PREV)
        Data_Proc_Info = NN_Search.IRIS_WEBF_BUSCA_RELACION_PREV_PROCE_POR_ID_PREV(ID_PREV)
        'Recorrer tabla de salida
        Select Case ID_PROG
            Case 0
                For y = 0 To (Data_OUT.Count - 1)
                    Dim Data_Proc_Val As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_LUGAR)
                    Dim Data_JSON_List As New List(Of E_Ate_Prev_Prog_JSON_PROC)
                    Dim strSQL As New StringBuilder
                    strSQL.Append("declare" & vbLf)
                    strSQL.Append("	   @ID_COD_FONASA as NUMERIC(9)," & vbLf)
                    strSQL.Append("	   @ID_PREV as NUMERIC(9)," & vbLf)
                    strSQL.Append("	   @DATE_01 as DATETIME," & vbLf)
                    strSQL.Append("	   @DATE_02 as DATETIME" & vbLf)
                    strSQL.Append("" & vbLf)
                    strSQL.Append("SET @ID_COD_FONASA = " & Data_OUT(y).ID_CODIGO_FONASA & vbLf)
                    strSQL.Append("SET @ID_PREV = " & ID_PREV & vbLf)
                    strSQL.Append("SET @DATE_01 = '" & Format(Date_01, "dd/MM/yyyy") & "'" & vbLf)
                    strSQL.Append("SET @DATE_02 = '" & Format(Date_02, "dd/MM/yyyy") & "'" & vbLf)
                    strSQL.Append("SET @DATE_02 = DATEADD(DAY, 1, @DATE_02)" & vbLf)
                    strSQL.Append("" & vbLf)
                    strSQL.Append("SELECT" & vbLf)
                    strSQL.Append("	   COUNT(DISTINCT dbo.IRIS_ATENCION.ID_ATENCION) AS TOTAL_ATE," & vbLf)
                    strSQL.Append("	   COUNT(DISTINCT dbo.IRIS_ATENCION.ID_PREVE) AS TOTAL_PREVE," & vbLf)
                    strSQL.Append("	   COUNT(dbo.IRIS_DET_ATENCION.ID_CODIGO_FONASA) AS TOT_FONASA," & vbLf)
                    strSQL.Append("	   SUM(dbo.IRIS_DET_ATENCION.ATE_DET_V_PREVI) AS TOTA_SIS," & vbLf)
                    strSQL.Append("	   SUM(dbo.IRIS_DET_ATENCION.ATE_DET_V_PAGADO) AS TOTA_USU," & vbLf)
                    strSQL.Append("	   SUM(dbo.IRIS_DET_ATENCION.ATE_DET_V_COPAGO) AS TOTA_COPA," & vbLf)
                    strSQL.Append("	   dbo.IRIS_CODIGO_FONASA.CF_DESC," & vbLf)
                    strSQL.Append("	   dbo.IRIS_DET_ATENCION.ID_CODIGO_FONASA," & vbLf)
                    strSQL.Append("	   dbo.IRIS_DET_ATENCION.ID_CODIGO_FONASA," & vbLf)
                    strSQL.Append("	   dbo.IRIS_DET_ATENCION.ID_ESTADO," & vbLf)
                    strSQL.Append("	   dbo.IRIS_PREVISION.ID_PREVE," & vbLf)
                    strSQL.Append("	   dbo.IRIS_PREVISION.PREVE_DESC," & vbLf)
                    strSQL.Append("	   dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA," & vbLf)
                    strSQL.Append("	   dbo.IRIS_PROCEDENCIA.PROC_DESC" & vbLf)
                    strSQL.Append("" & vbLf)
                    strSQL.Append("FROM dbo.IRIS_ATENCION" & vbLf)
                    strSQL.Append("" & vbLf)
                    strSQL.Append("INNER JOIN dbo.IRIS_DET_ATENCION ON" & vbLf)
                    strSQL.Append("	   dbo.IRIS_ATENCION.ID_ATENCION = dbo.IRIS_DET_ATENCION.ID_ATENCION" & vbLf)
                    strSQL.Append("INNER JOIN dbo.IRIS_CODIGO_FONASA ON" & vbLf)
                    strSQL.Append("	   dbo.IRIS_DET_ATENCION.ID_CODIGO_FONASA = dbo.IRIS_CODIGO_FONASA.ID_CODIGO_FONASA" & vbLf)
                    strSQL.Append("INNER JOIN dbo.IRIS_PROCEDENCIA ON" & vbLf)
                    strSQL.Append("	   dbo.IRIS_ATENCION.ID_PROCEDENCIA = dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA" & vbLf)
                    strSQL.Append("INNER JOIN dbo.IRIS_PREVISION ON" & vbLf)
                    strSQL.Append("	   dbo.IRIS_ATENCION.ID_PREVE = dbo.IRIS_PREVISION.ID_PREVE" & vbLf)
                    strSQL.Append("INNER JOIN dbo.IRIS_DOCTORES ON" & vbLf)
                    strSQL.Append("	   dbo.IRIS_ATENCION.ID_DOCTOR = dbo.IRIS_DOCTORES.ID_DOCTOR" & vbLf)
                    strSQL.Append("" & vbLf)
                    strSQL.Append("WHERE" & vbLf)
                    strSQL.Append("	   	   (dbo.IRIS_ATENCION.ATE_FECHA BETWEEN CONVERT(datetime, @DATE_01, 103)" & vbLf)
                    strSQL.Append("	   AND CONVERT(datetime, @DATE_02, 103))" & vbLf)
                    strSQL.Append("	   AND (dbo.IRIS_DET_ATENCION.ID_CODIGO_FONASA = @ID_COD_FONASA)" & vbLf)
                    strSQL.Append("	   AND (dbo.IRIS_ATENCION.ID_PREVE = @ID_PREV) " & vbLf)
                    strSQL.Append("" & vbLf)
                    strSQL.Append("	   --Procedencias" & vbLf)
                    strSQL.Append("	   AND (" & vbLf)
                    For yy = 0 To (Data_Proc_Info.Count - 1)
                        Dim Data_Proc_JSON As New E_Ate_Prev_Prog_JSON_PROC
                        Dim nProc As Long = Data_Proc_Info(yy).ID_PROCEDENCIA
                        Select Case yy
                            Case 0
                                strSQL.Append("            (dbo.IRIS_ATENCION.ID_PROCEDENCIA = " & nProc & ")" & vbLf)
                            Case Else
                                strSQL.Append("		   OR  (dbo.IRIS_ATENCION.ID_PROCEDENCIA = " & nProc & ")" & vbLf)
                        End Select
                        Data_Proc_JSON.PROC_DESC = Data_Proc_Info(yy).PROC_DESC
                        Data_Proc_JSON.PREVE_DESC = Data_Proc_Info(yy).PREVE_DESC
                        Data_Proc_JSON.ID_PREVE = ID_PREV
                        Data_Proc_JSON.ID_PROCEDENCIA = Data_Proc_Info(yy).ID_PROCEDENCIA
                        Data_JSON_List.Add(Data_Proc_JSON)
                    Next yy
                    strSQL.Append(")" & vbLf)
                    strSQL.Append("" & vbLf)
                    strSQL.Append("Group BY" & vbLf)
                    strSQL.Append("    dbo.IRIS_CODIGO_FONASA.CF_COD," & vbLf)
                    strSQL.Append("    dbo.IRIS_CODIGO_FONASA.CF_DESC," & vbLf)
                    strSQL.Append("    dbo.IRIS_DET_ATENCION.ID_CODIGO_FONASA," & vbLf)
                    strSQL.Append("    dbo.IRIS_DET_ATENCION.ID_ESTADO," & vbLf)
                    strSQL.Append("    dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA," & vbLf)
                    strSQL.Append("    dbo.IRIS_PROCEDENCIA.PROC_DESC," & vbLf)
                    strSQL.Append("    dbo.IRIS_PREVISION.ID_PREVE," & vbLf)
                    strSQL.Append("    dbo.IRIS_PREVISION.PREVE_DESC" & vbLf)
                    strSQL.Append("" & vbLf)
                    strSQL.Append("HAVING" & vbLf)
                    strSQL.Append("    (dbo.IRIS_DET_ATENCION.ID_ESTADO = 1)" & vbLf)
                    'Buscar los valores asociados a la procedencia
                    Data_Proc_Val = NN_Search.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_LUGAR(strSQL.ToString)
                    'Debug
                    Debug.WriteLine("Agregar Procedencia Resultado N° " & (y + 1))
                    If (Data_Proc_Val.Count > 0) Then
                        'Recorrer toda la tabla de Referencias de Procedencias
                        For a = 0 To (Data_JSON_List.Count - 1)
                            'Comprobar si algún valor devuelto calza con las referencias
                            For i = 0 To (Data_Proc_Val.Count - 1)
                                Dim refID_PREV As Long = Data_JSON_List(a).ID_PREVE
                                Dim refID_PROG As Long = Data_JSON_List(a).ID_PROCEDENCIA
                                Dim getID_PREV As Long = Data_Proc_Val(i).ID_PREVE
                                Dim getID_PROG As Long = Data_Proc_Val(i).ID_PROCEDENCIA
                                If (refID_PREV = getID_PREV) And (refID_PROG = getID_PROG) Then
                                    Data_JSON_List(a).TOTAL_ATE = Data_Proc_Val(i).TOTAL_ATE
                                    Data_JSON_List(a).TOTAL_PREVE = Data_Proc_Val(i).TOTAL_PREVE
                                    Data_JSON_List(a).TOT_FONASA = Data_Proc_Val(i).TOT_FONASA
                                    Data_JSON_List(a).TOTA_SIS = Data_Proc_Val(i).TOTA_SIS
                                    Data_JSON_List(a).TOTA_USU = Data_Proc_Val(i).TOTA_USU
                                    Data_JSON_List(a).TOTA_COPA = Data_Proc_Val(i).TOTA_COPA
                                    Exit For
                                End If
                            Next i
                        Next a
                    End If
                    Data_OUT(y).Data_Proced = Data_JSON_List
                Next y
            Case Else
                For y = 0 To (Data_OUT.Count - 1)
                    Dim Data_Proc_Val As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_LUGAR_PROGRAMA)
                    Dim Data_JSON_List As New List(Of E_Ate_Prev_Prog_JSON_PROC)
                    Dim strSQL As New StringBuilder
                    strSQL.Append("DECLARE" & vbLf)
                    strSQL.Append("    @ID_CODF as NUMERIC(9)," & vbLf)
                    strSQL.Append("    @ID_PREV as NUMERIC(9)," & vbLf)
                    strSQL.Append("    @ID_PROG as NUMERIC(9)," & vbLf)
                    strSQL.Append("    @DATE_01 as DATETIME," & vbLf)
                    strSQL.Append("    @DATE_02 as DATETIME" & vbLf)
                    strSQL.Append("" & vbLf)
                    strSQL.Append("SET @ID_CODF = " & Data_OUT(y).ID_CODIGO_FONASA & vbLf)
                    strSQL.Append("SET @ID_PREV = " & ID_PREV & vbLf)
                    strSQL.Append("SET @ID_PROG = " & ID_PROG & vbLf)
                    strSQL.Append("SET @DATE_01 = '" & Format(Date_01, "dd/MM/yyyy") & "'" & vbLf)
                    strSQL.Append("SET @DATE_02 = '" & Format(Date_02, "dd/MM/yyyy") & "'" & vbLf)
                    strSQL.Append("SET @DATE_02 = DATEADD(DAY, 1, @DATE_02)" & vbLf)
                    strSQL.Append("" & vbLf)
                    strSQL.Append("SELECT" & vbLf)
                    strSQL.Append("    COUNT(DISTINCT dbo.IRIS_ATENCION.ID_ATENCION) AS TOTAL_ATE," & vbLf)
                    strSQL.Append("    COUNT(DISTINCT dbo.IRIS_ATENCION.ID_PREVE) AS TOTAL_PREVE," & vbLf)
                    strSQL.Append("    COUNT(dbo.IRIS_DET_ATENCION.ID_CODIGO_FONASA) AS TOT_FONASA," & vbLf)
                    strSQL.Append("    SUM(dbo.IRIS_DET_ATENCION.ATE_DET_V_PREVI) AS TOTA_SIS," & vbLf)
                    strSQL.Append("    dbo.IRIS_CODIGO_FONASA.CF_DESC," & vbLf)
                    strSQL.Append("    dbo.IRIS_DET_ATENCION.ID_CODIGO_FONASA," & vbLf)
                    strSQL.Append("    dbo.IRIS_DET_ATENCION.ID_ESTADO," & vbLf)
                    strSQL.Append("    dbo.IRIS_CODIGO_FONASA.CF_COD," & vbLf)
                    strSQL.Append("    dbo.IRIS_ATENCION.ID_PROGRA," & vbLf)
                    strSQL.Append("    dbo.IRIS_PROGRAMA.PROGRA_DESC," & vbLf)
                    strSQL.Append("	   dbo.IRIS_PREVISION.ID_PREVE," & vbLf)
                    strSQL.Append("	   dbo.IRIS_PREVISION.PREVE_DESC," & vbLf)
                    strSQL.Append("	   dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA," & vbLf)
                    strSQL.Append("	   dbo.IRIS_PROCEDENCIA.PROC_DESC" & vbLf)
                    strSQL.Append("" & vbLf)
                    strSQL.Append("FROM dbo.IRIS_ATENCION" & vbLf)
                    strSQL.Append("" & vbLf)
                    strSQL.Append("INNER JOIN dbo.IRIS_DET_ATENCION ON" & vbLf)
                    strSQL.Append("    dbo.IRIS_ATENCION.ID_ATENCION = dbo.IRIS_DET_ATENCION.ID_ATENCION" & vbLf)
                    strSQL.Append("INNER JOIN dbo.IRIS_CODIGO_FONASA ON" & vbLf)
                    strSQL.Append("    dbo.IRIS_DET_ATENCION.ID_CODIGO_FONASA = dbo.IRIS_CODIGO_FONASA.ID_CODIGO_FONASA" & vbLf)
                    strSQL.Append("INNER JOIN dbo.IRIS_PROCEDENCIA ON" & vbLf)
                    strSQL.Append("    dbo.IRIS_ATENCION.ID_PROCEDENCIA = dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA" & vbLf)
                    strSQL.Append("INNER JOIN dbo.IRIS_PREVISION ON" & vbLf)
                    strSQL.Append("    dbo.IRIS_ATENCION.ID_PREVE = dbo.IRIS_PREVISION.ID_PREVE" & vbLf)
                    strSQL.Append("INNER JOIN dbo.IRIS_DOCTORES ON" & vbLf)
                    strSQL.Append("    dbo.IRIS_ATENCION.ID_DOCTOR = dbo.IRIS_DOCTORES.ID_DOCTOR" & vbLf)
                    strSQL.Append("" & vbLf)
                    strSQL.Append("INNER JOIN dbo.IRIS_PROGRAMA ON" & vbLf)
                    strSQL.Append("    dbo.IRIS_ATENCION.ID_PROGRA = dbo.IRIS_PROGRAMA.ID_PROGRA" & vbLf)
                    strSQL.Append("" & vbLf)
                    strSQL.Append("WHERE" & vbLf)
                    strSQL.Append("        (dbo.IRIS_ATENCION.ATE_FECHA BETWEEN CONVERT(datetime, @DATE_01, 103)" & vbLf)
                    strSQL.Append("    AND CONVERT(datetime, @DATE_02, 103))" & vbLf)
                    strSQL.Append("" & vbLf)
                    strSQL.Append("    AND (dbo.IRIS_DET_ATENCION.ID_CODIGO_FONASA = @ID_CODF)" & vbLf)
                    strSQL.Append("    AND (dbo.IRIS_ATENCION.ID_PROGRA = @ID_PROG)" & vbLf)
                    strSQL.Append("    AND (dbo.IRIS_ATENCION.ID_PREVE = @ID_PREV) " & vbLf)
                    strSQL.Append("" & vbLf)
                    strSQL.Append("    --Procedencias" & vbLf)
                    strSQL.Append("    AND (" & vbLf)
                    For yy = 0 To (Data_Proc_Info.Count - 1)
                        Dim Data_Proc_JSON As New E_Ate_Prev_Prog_JSON_PROC
                        Dim nProc As Long = Data_Proc_Info(yy).ID_PROCEDENCIA
                        Select Case yy
                            Case 0
                                strSQL.Append("        (dbo.IRIS_ATENCION.ID_PROCEDENCIA = " & nProc & ")" & vbLf)
                            Case Else
                                strSQL.Append("    OR  (dbo.IRIS_ATENCION.ID_PROCEDENCIA = " & nProc & ")" & vbLf)
                        End Select
                        Data_Proc_JSON.PROC_DESC = Data_Proc_Info(yy).PROC_DESC
                        Data_Proc_JSON.PREVE_DESC = Data_Proc_Info(yy).PREVE_DESC
                        Data_Proc_JSON.ID_PREVE = ID_PREV
                        Data_Proc_JSON.ID_PROCEDENCIA = Data_Proc_Info(yy).ID_PROCEDENCIA
                        Data_JSON_List.Add(Data_Proc_JSON)
                    Next yy
                    strSQL.Append("	)" & vbLf)
                    strSQL.Append("" & vbLf)
                    strSQL.Append("GROUP BY" & vbLf)
                    strSQL.Append("    dbo.IRIS_CODIGO_FONASA.CF_COD," & vbLf)
                    strSQL.Append("    dbo.IRIS_CODIGO_FONASA.CF_DESC," & vbLf)
                    strSQL.Append("    dbo.IRIS_DET_ATENCION.ID_CODIGO_FONASA," & vbLf)
                    strSQL.Append("    dbo.IRIS_DET_ATENCION.ID_ESTADO," & vbLf)
                    strSQL.Append("    dbo.IRIS_ATENCION.ID_PROGRA," & vbLf)
                    strSQL.Append("    dbo.IRIS_PROGRAMA.PROGRA_DESC," & vbLf)
                    strSQL.Append("    dbo.IRIS_ATENCION.ID_ESTADO," & vbLf)
                    strSQL.Append("    dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA," & vbLf)
                    strSQL.Append("    dbo.IRIS_PROCEDENCIA.PROC_DESC," & vbLf)
                    strSQL.Append("    dbo.IRIS_PREVISION.ID_PREVE," & vbLf)
                    strSQL.Append("    dbo.IRIS_PREVISION.PREVE_DESC" & vbLf)
                    strSQL.Append("    " & vbLf)
                    strSQL.Append("HAVING" & vbLf)
                    strSQL.Append("        (dbo.IRIS_DET_ATENCION.ID_ESTADO = 1)" & vbLf)
                    strSQL.Append("    AND (dbo.IRIS_ATENCION.ID_ESTADO = '1')" & vbLf)
                    'Buscar los valores asociados a la procedencia
                    Data_Proc_Val = NN_Search.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_LUGAR_PROGRAMA(strSQL.ToString)
                    'Debug
                    Debug.WriteLine("Agregar Procedencia Resultado N° " & (y + 1))
                    If (Data_Proc_Val.Count > 0) Then
                        'Recorrer toda la tabla de Referencias de Procedencias
                        For a = 0 To (Data_JSON_List.Count - 1)
                            'Comprobar si algún valor devuelto calza con las referencias
                            For i = 0 To (Data_Proc_Val.Count - 1)
                                Dim refID_PREV As Long = Data_JSON_List(a).ID_PREVE
                                Dim refID_PROG As Long = Data_JSON_List(a).ID_PROCEDENCIA
                                Dim getID_PREV As Long = Data_Proc_Val(i).ID_PREVE
                                Dim getID_PROG As Long = Data_Proc_Val(i).ID_PROCEDENCIA
                                If (refID_PREV = getID_PREV) And (refID_PROG = getID_PROG) Then
                                    Data_JSON_List(a).TOTAL_ATE = Data_Proc_Val(i).TOTAL_ATE
                                    Data_JSON_List(a).TOTAL_PREVE = Data_Proc_Val(i).TOTAL_PREVE
                                    Data_JSON_List(a).TOT_FONASA = Data_Proc_Val(i).TOT_FONASA
                                    Data_JSON_List(a).TOTA_SIS = Data_Proc_Val(i).TOTA_SIS
                                    Data_JSON_List(a).TOTA_USU = 0
                                    Data_JSON_List(a).TOTA_COPA = 0
                                    Exit For
                                End If
                            Next i
                        Next a
                    End If
                    Data_OUT(y).Data_Proced = Data_JSON_List
                Next y
        End Select
        'Sumar Hemogramas a los VHS (Porque los Hemogramas Incluyen VHS)
        'Obtener datos del Hemograma
        If (Hem_Pos >= 0) And (VHS_Pos >= 0) Then
            Data_OUT(VHS_Pos).TOTAL_ATE += Data_OUT(Hem_Pos).TOTAL_ATE
            Data_OUT(VHS_Pos).TOTAL_PREVE += Data_OUT(Hem_Pos).TOTAL_PREVE
            Data_OUT(VHS_Pos).TOT_FONASA += Data_OUT(Hem_Pos).TOT_FONASA
            Data_OUT(VHS_Pos).TOTA_SIS += Data_OUT(Hem_Pos).TOTA_SIS
            Data_OUT(VHS_Pos).TOTA_USU += Data_OUT(Hem_Pos).TOTA_USU
            Data_OUT(VHS_Pos).TOTA_COPA += Data_OUT(Hem_Pos).TOTA_COPA
            For yy = 0 To (Data_OUT(Hem_Pos).Data_Proced.Count - 1)
                Data_OUT(VHS_Pos).Data_Proced(yy).ID_PROCEDENCIA += Data_OUT(Hem_Pos).Data_Proced(yy).ID_PROCEDENCIA
                Data_OUT(VHS_Pos).Data_Proced(yy).TOTAL_ATE += Data_OUT(Hem_Pos).Data_Proced(yy).TOTAL_ATE
                Data_OUT(VHS_Pos).Data_Proced(yy).TOTAL_PREVE += Data_OUT(Hem_Pos).Data_Proced(yy).TOTAL_PREVE
                Data_OUT(VHS_Pos).Data_Proced(yy).TOT_FONASA += Data_OUT(Hem_Pos).Data_Proced(yy).TOT_FONASA
                Data_OUT(VHS_Pos).Data_Proced(yy).TOTA_SIS += Data_OUT(Hem_Pos).Data_Proced(yy).TOTA_SIS
                Data_OUT(VHS_Pos).Data_Proced(yy).TOTA_USU += Data_OUT(Hem_Pos).Data_Proced(yy).TOTA_USU
                Data_OUT(VHS_Pos).Data_Proced(yy).TOTA_COPA += Data_OUT(Hem_Pos).Data_Proced(yy).TOTA_COPA
            Next yy
        End If
        'Armar Excel
        'Declaraciones Generales
        If (Data_OUT.Count = 0) Then
            Return "null"
            Exit Function
        End If
        Dim Mx_Data(0, 0) As Object
        ReDim Mx_Data(4 + Data_OUT(0).Data_Proced.Count, 0)
        'Vaciar Matriz
        For x = 0 To (Mx_Data.GetUpperBound(0))
            Mx_Data(x, 0) = Nothing
        Next x
        'Llenar Matriz
        For y = 0 To (Data_OUT.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx_Data(Mx_Data.GetUpperBound(0), y)
            End If
            Mx_Data(0, y) = Data_OUT(y).CF_COD & ".-"
            Mx_Data(1, y) = Data_OUT(y).CF_DESC
            Mx_Data(2, y) = Data_OUT(y).TOTAL_ATE
            Mx_Data(3, y) = Data_OUT(y).Data_Fonasa.CF_PRECIO_AMB
            If (Data_OUT(0).PROGRA_DESC <> Nothing) Or (Data_OUT(0).PROGRA_DESC <> "") Then
                Mx_Data(4, y) = Data_OUT(0).PROGRA_DESC
            Else
                Mx_Data(4, y) = " - "
            End If
            For a = 0 To Data_OUT(0).Data_Proced.Count - 1
                Mx_Data(5 + a, y) = Data_OUT(y).Data_Proced(a).TOTAL_ATE
            Next a
        Next y
        'Crear Tabla
        Dim Xls As New SLDocument
        Dim tablePosRow As Integer = 7
        Dim tablePosCol As Integer = 1
        'Colocar Título
        Xls.SetCellValue(1, 1, "Resumen de Atenciones por Previsión y Programa: ")
        Xls.SetCellValue(2, 1, "Previsión: " & Data_OUT(0).Data_Proced(0).PREVE_DESC)
        If (Data_OUT(0).PROGRA_DESC <> Nothing) Or (Data_OUT(0).PROGRA_DESC <> "") Then
            Xls.SetCellValue(3, 1, "Programa: " & Data_OUT(0).PROGRA_DESC)
        End If
        Xls.SetCellValue(4, 1, "Fecha desde: " & Format(Date_01, "dd/MM/yyyy"))
        Xls.SetCellValue(5, 1, "Fecha hasta: " & Format(Date_02, "dd/MM/yyyy"))
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
        Xls.RenameWorksheet("Sheet1", "Atenciones por Médico: " & Mx_Data(1, 0))
        Dim tablePosCol_now As Integer = tablePosCol
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Código") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Exámen") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Cant. Exámenes") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Precio") : tablePosCol_now += 1
        Xls.SetCellValue(tablePosRow, tablePosCol_now, "Programa") : tablePosCol_now += 1
        For y = 0 To (Data_OUT(0).Data_Proced.Count - 1)
            If (Data_OUT(0).Data_Proced(y).PROC_DESC <> Nothing) Or (Data_OUT(0).Data_Proced(y).PROC_DESC <> "") Then
                Xls.SetCellValue(tablePosRow, tablePosCol_now, Data_OUT(0).Data_Proced(y).PROC_DESC) : tablePosCol_now += 1
            Else
                Xls.SetCellValue(tablePosRow, tablePosCol_now, "Vacío") : tablePosCol_now += 1
            End If
        Next y
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
        Xls.SetColumnWidth(tablePosCol_now, 40) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1
        Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1
        For y = 0 To (Data_OUT(0).Data_Proced.Count - 1)
            Xls.SetColumnWidth(tablePosCol_now, 25) : tablePosCol_now += 1
        Next y
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
            For x = 2 To Mx_Data.GetUpperBound(0)
                'style.FormatCode = "dd/mm/yyyy h:mm:ss"
                style.FormatCode = "###,###,##0"
                Xls.SetCellStyle(tablePosRow_now, tablePosCol + x, style)
            Next x
            style.FormatCode = "$ ###,###,##0"
            Xls.SetCellStyle(tablePosRow_now, tablePosCol + 3, style)
            style.FormatCode = ""
            style.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Center)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol + 4, style)
        Next y
        'Definir Estilos de "Totales"
        tablePosRow_now += 1
        Dim style_total = Xls.CreateStyle()
        style_total.SetHorizontalAlignment(DocumentFormat.OpenXml.Spreadsheet.HorizontalAlignmentValues.Right)
        style_total.Font.Bold = True
        style_total.Font.FontSize = 16
        Xls.SetCellStyle(tablePosRow_now, tablePosCol + 1, style_total)
        Xls.SetCellValue(tablePosRow_now, tablePosCol + 1, "Total:")
        style_total.Font.Bold = False
        style_total.FormatCode = "###,###,##0"
        For a = 2 To Mx_Data.GetUpperBound(0)
            Xls.SetCellStyle(tablePosRow_now, tablePosCol + a, style_total)
            'Insertar totales
            Dim nChar As Integer = Asc("A") - 1
            Select Case a
                Case 4
                    Xls.SetCellValue(tablePosRow_now, tablePosCol + a, " ")
                Case Else
                    Xls.SetCellValue(tablePosRow_now, tablePosCol + a, "=SUM(" & (Chr(nChar + tablePosCol + a) & tablePosRow + 1) & ":" & (Chr(nChar + tablePosCol + a) & tablePosRow_now - 1) & ")")
            End Select
        Next a
        style_total.FormatCode = "$ ###,###,##0"
        Xls.SetCellStyle(tablePosRow_now, tablePosCol + 3, style_total)
        'Determinar Tabla
        Dim Inner_Table As SLTable = Xls.CreateTable(tablePosRow, tablePosCol, tablePosRow_now, tablePosCol_now)
        Inner_Table.SetTableStyle(SLTableStyleTypeValues.Dark11)
        Xls.InsertTable(Inner_Table)
        'Crear Ruta de Guardado
        Dim Ruta_save_local As String = System.Web.HttpContext.Current.Server.MapPath("~/")
        Dim Relative_Path As String = "IRISPDFDERIVADOS\Ate_Prev_Prog_" & Format(Date.Now, "dd-MM-yyyy_hh-mm-ss") & ".xlsx"
        Xls.SaveAs(Ruta_save_local & Relative_Path)
        'Devolver la url del archivo generado
        Return MAIN_URL & "/" & Replace(Relative_Path, "\", "/")
    End Function
    '''<summary>
    '''Devuelve una cadena con el nombre que corresponde de acuerdo al Código Fonasa
    '''</summary>
    '''<param name="COD_FONASA">Cadena con el código de exámen según Fonasa</param>
    '''<param name="ORIG_DESCR">Nombre que trae dicho exámen desde la base de datos</param>
    '''<returns></returns>
    '''<remarks></remarks>
    Private Function changeDescripc(ByVal COD_FONASA As String, ByVal ORIG_DESCR As String) As String
        Select Case COD_FONASA
            Case "0302063"
                Return "Transaminas GOT y/o GPT"
            Case "0302032"
                Return "Electrolitos Plasmaticos"
            Case "0302023"
                Return "Creatinina en Sangre"
            Case "0309022"
                Return "Orina Completa"
            Case "0302060"
                Return "Albumina y/o Proteinas Totales en Sangre"
            Case "0302035"
                Return "Niveles Plasmaticos"
            Case Else
                Return ORIG_DESCR
        End Select
    End Function
End Class
