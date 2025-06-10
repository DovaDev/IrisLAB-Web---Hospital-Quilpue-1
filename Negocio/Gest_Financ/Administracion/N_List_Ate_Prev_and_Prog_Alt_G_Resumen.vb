Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports SpreadsheetLight
Imports SpreadsheetLight.Charts
Imports Datos
Imports Entidades
Public Class N_List_Ate_Prev_and_Prog_Alt_G_Resumen
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
    Function Gen_Table(ByVal ID_PREV As Long, ByVal ID_PROG As String, ByVal DATE_str01 As String, ByVal DATE_str02 As String) As List(Of E_Ate_Prev_Prog_JSON_Output)
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim Date_01 As Date = NN_Date.strToDate(Split(DATE_str01, "/")(2), Split(DATE_str01, "/")(1), Split(DATE_str01, "/")(0))
        Dim Date_02 As Date = NN_Date.strToDate(Split(DATE_str02, "/")(2), Split(DATE_str02, "/")(1), Split(DATE_str02, "/")(0))
        'Declaraciones Consulta
        Dim NN_Search As New N_List_Ate_Prev_and_Prog_Alt_G_Resumen
        Dim Data_Search As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_PROGRAMA)
        Dim Data_OUT As New List(Of E_Ate_Prev_Prog_JSON_Output)
        'Declaraciones Hemograma/VHS
        Dim Hem_Pos As Long = -1
        Dim VHS_Pos As Long = -1
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
            If (Data_Fonasa.Count > 0) Then
                ItemList.Data_Fonasa = Data_Fonasa(0)
            Else
                Dim Fonasa_Item As New E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA_ID
                Fonasa_Item.AÑO_COD = 0
                Fonasa_Item.CF_COD = 0
                Fonasa_Item.CF_DESC = 0
                Fonasa_Item.CF_DIAS = 0
                Fonasa_Item.CF_NO_FONASA = 0
                Fonasa_Item.CF_PRECIO_AMB = 0
                Fonasa_Item.CF_PRECIO_HOS = 0
                Fonasa_Item.CF_SEL_PRUE = 0
                Fonasa_Item.ID_CF_PRECIO = 0
                Fonasa_Item.ID_CODIGO_FONASA = 0
                Fonasa_Item.ID_ESTADO = 0
                Fonasa_Item.ID_ESTADO = 0
                Fonasa_Item.ID_PER = 0
                Fonasa_Item.ID_PER = 0
                Fonasa_Item.ID_PREVE = 0
                Fonasa_Item.ID_PREVE = 0
                ItemList.Data_Fonasa = Fonasa_Item
            End If
            Data_OUT.Add(ItemList)
            'Comprobar Hemograma/VHS
            Select Case (ItemList.CF_COD)
                Case "0301086"      'VHS
                    VHS_Pos = Data_OUT.Count - 1
                Case "0301045"      'Hemograma
                    Hem_Pos = Data_OUT.Count - 1
            End Select
        Next y
        'Solo en caso de que no haya tabla de relación
        For y = 0 To (Data_OUT.Count - 1)
            Dim Data_JSON_List As New List(Of E_Ate_Prev_Prog_JSON_PROC)
            Data_OUT(y).Data_Proced = Data_JSON_List
        Next y
        ''Agregar Procedencias
        'Dim Data_Proc_Info As New List(Of E_IRIS_WEBF_BUSCA_RELACION_PREV_PROCE_POR_ID_PREV)
        'Data_Proc_Info = NN_Search.IRIS_WEBF_BUSCA_RELACION_PREV_PROCE_POR_ID_PREV(ID_PREV)
        ''Recorrer tabla de salida
        'Select Case ID_PROG
        '    Case 0
        '        For y = 0 To (Data_OUT.Count - 1)
        '            Dim Data_Proc_Val As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_LUGAR)
        '            Dim Data_JSON_List As New List(Of E_Ate_Prev_Prog_JSON_PROC)
        '            Dim strSQL As New StringBuilder
        '            strSQL.Append("declare" & vbLf)
        '            strSQL.Append("	   @ID_COD_FONASA as NUMERIC(9)," & vbLf)
        '            strSQL.Append("	   @ID_PREV as NUMERIC(9)," & vbLf)
        '            strSQL.Append("	   @DATE_01 as DATETIME," & vbLf)
        '            strSQL.Append("	   @DATE_02 as DATETIME" & vbLf)
        '            strSQL.Append("" & vbLf)
        '            strSQL.Append("SET @ID_COD_FONASA = " & Data_OUT(y).ID_CODIGO_FONASA & vbLf)
        '            strSQL.Append("SET @ID_PREV = " & ID_PREV & vbLf)
        '            strSQL.Append("SET @DATE_01 = '" & Format(Date_01, "dd/MM/yyyy") & "'" & vbLf)
        '            strSQL.Append("SET @DATE_02 = '" & Format(Date_02, "dd/MM/yyyy") & "'" & vbLf)
        '            strSQL.Append("SET @DATE_02 = DATEADD(DAY, 1, @DATE_02)" & vbLf)
        '            strSQL.Append("" & vbLf)
        '            strSQL.Append("SELECT" & vbLf)
        '            strSQL.Append("	   COUNT(DISTINCT dbo.IRIS_ATENCION.ID_ATENCION) AS TOTAL_ATE," & vbLf)
        '            strSQL.Append("	   COUNT(DISTINCT dbo.IRIS_ATENCION.ID_PREVE) AS TOTAL_PREVE," & vbLf)
        '            strSQL.Append("	   COUNT(dbo.IRIS_DET_ATENCION.ID_CODIGO_FONASA) AS TOT_FONASA," & vbLf)
        '            strSQL.Append("	   SUM(dbo.IRIS_DET_ATENCION.ATE_DET_V_PREVI) AS TOTA_SIS," & vbLf)
        '            strSQL.Append("	   SUM(dbo.IRIS_DET_ATENCION.ATE_DET_V_PAGADO) AS TOTA_USU," & vbLf)
        '            strSQL.Append("	   SUM(dbo.IRIS_DET_ATENCION.ATE_DET_V_COPAGO) AS TOTA_COPA," & vbLf)
        '            strSQL.Append("	   dbo.IRIS_CODIGO_FONASA.CF_DESC," & vbLf)
        '            strSQL.Append("	   dbo.IRIS_DET_ATENCION.ID_CODIGO_FONASA," & vbLf)
        '            strSQL.Append("	   dbo.IRIS_DET_ATENCION.ID_CODIGO_FONASA," & vbLf)
        '            strSQL.Append("	   dbo.IRIS_DET_ATENCION.ID_ESTADO," & vbLf)
        '            strSQL.Append("	   dbo.IRIS_PREVISION.ID_PREVE," & vbLf)
        '            strSQL.Append("	   dbo.IRIS_PREVISION.PREVE_DESC," & vbLf)
        '            strSQL.Append("	   dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA," & vbLf)
        '            strSQL.Append("	   dbo.IRIS_PROCEDENCIA.PROC_DESC" & vbLf)
        '            strSQL.Append("" & vbLf)
        '            strSQL.Append("FROM dbo.IRIS_ATENCION" & vbLf)
        '            strSQL.Append("" & vbLf)
        '            strSQL.Append("INNER JOIN dbo.IRIS_DET_ATENCION ON" & vbLf)
        '            strSQL.Append("	   dbo.IRIS_ATENCION.ID_ATENCION = dbo.IRIS_DET_ATENCION.ID_ATENCION" & vbLf)
        '            strSQL.Append("INNER JOIN dbo.IRIS_CODIGO_FONASA ON" & vbLf)
        '            strSQL.Append("	   dbo.IRIS_DET_ATENCION.ID_CODIGO_FONASA = dbo.IRIS_CODIGO_FONASA.ID_CODIGO_FONASA" & vbLf)
        '            strSQL.Append("INNER JOIN dbo.IRIS_PROCEDENCIA ON" & vbLf)
        '            strSQL.Append("	   dbo.IRIS_ATENCION.ID_PROCEDENCIA = dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA" & vbLf)
        '            strSQL.Append("INNER JOIN dbo.IRIS_PREVISION ON" & vbLf)
        '            strSQL.Append("	   dbo.IRIS_ATENCION.ID_PREVE = dbo.IRIS_PREVISION.ID_PREVE" & vbLf)
        '            strSQL.Append("INNER JOIN dbo.IRIS_DOCTORES ON" & vbLf)
        '            strSQL.Append("	   dbo.IRIS_ATENCION.ID_DOCTOR = dbo.IRIS_DOCTORES.ID_DOCTOR" & vbLf)
        '            strSQL.Append("" & vbLf)
        '            strSQL.Append("WHERE" & vbLf)
        '            strSQL.Append("	   	   (dbo.IRIS_ATENCION.ATE_FECHA BETWEEN CONVERT(datetime, @DATE_01, 103)" & vbLf)
        '            strSQL.Append("	   AND CONVERT(datetime, @DATE_02, 103))" & vbLf)
        '            strSQL.Append("	   AND (dbo.IRIS_DET_ATENCION.ID_CODIGO_FONASA = @ID_COD_FONASA)" & vbLf)
        '            strSQL.Append("	   AND (dbo.IRIS_ATENCION.ID_PREVE = @ID_PREV) " & vbLf)
        '            strSQL.Append("" & vbLf)
        '            strSQL.Append("	   --Procedencias" & vbLf)
        '            If (Data_Proc_Info.Count > 0) Then
        '                strSQL.Append("	   AND (" & vbLf)
        '                For yy = 0 To (Data_Proc_Info.Count - 1)
        '                    Dim Data_Proc_JSON As New E_Ate_Prev_Prog_JSON_PROC
        '                    Dim nProc As Long = Data_Proc_Info(yy).ID_PROCEDENCIA
        '                    Select Case yy
        '                        Case 0
        '                            strSQL.Append("            (dbo.IRIS_ATENCION.ID_PROCEDENCIA = " & nProc & ")" & vbLf)
        '                        Case Else
        '                            strSQL.Append("		   OR  (dbo.IRIS_ATENCION.ID_PROCEDENCIA = " & nProc & ")" & vbLf)
        '                    End Select
        '                    Data_Proc_JSON.PROC_DESC = Data_Proc_Info(yy).PROC_DESC
        '                    Data_Proc_JSON.PREVE_DESC = Data_Proc_Info(yy).PREVE_DESC
        '                    Data_Proc_JSON.ID_PREVE = ID_PREV
        '                    Data_Proc_JSON.ID_PROCEDENCIA = Data_Proc_Info(yy).ID_PROCEDENCIA
        '                    Data_JSON_List.Add(Data_Proc_JSON)
        '                Next yy
        '                strSQL.Append(")" & vbLf)
        '            End If
        '            strSQL.Append("" & vbLf)
        '            strSQL.Append("Group BY" & vbLf)
        '            strSQL.Append("    dbo.IRIS_CODIGO_FONASA.CF_COD," & vbLf)
        '            strSQL.Append("    dbo.IRIS_CODIGO_FONASA.CF_DESC," & vbLf)
        '            strSQL.Append("    dbo.IRIS_DET_ATENCION.ID_CODIGO_FONASA," & vbLf)
        '            strSQL.Append("    dbo.IRIS_DET_ATENCION.ID_ESTADO," & vbLf)
        '            strSQL.Append("    dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA," & vbLf)
        '            strSQL.Append("    dbo.IRIS_PROCEDENCIA.PROC_DESC," & vbLf)
        '            strSQL.Append("    dbo.IRIS_PREVISION.ID_PREVE," & vbLf)
        '            strSQL.Append("    dbo.IRIS_PREVISION.PREVE_DESC" & vbLf)
        '            strSQL.Append("" & vbLf)
        '            strSQL.Append("HAVING" & vbLf)
        '            strSQL.Append("    (dbo.IRIS_DET_ATENCION.ID_ESTADO = 1)" & vbLf)
        '            'Debug
        '            Debug.WriteLine("Agregar Procedencia Resultado N° " & (y + 1))
        '            If (y = 67) Then
        '                Dim aaa As String = "asdf"
        '            End If
        '            'Buscar los valores asociados a la procedencia
        '            Data_Proc_Val = NN_Search.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_LUGAR(strSQL.ToString)
        '            'Recorrer toda la tabla de Referencias de Procedencias
        '            If (Data_Proc_Val.Count > 0) Then
        '                For a = 0 To (Data_JSON_List.Count - 1)
        '                    'Comprobar si algún valor devuelto calza con las referencias
        '                    For i = 0 To (Data_Proc_Val.Count - 1)
        '                        Dim refID_PREV As Long = Data_JSON_List(a).ID_PREVE
        '                        Dim refID_PROG As Long = Data_JSON_List(a).ID_PROCEDENCIA
        '                        Dim getID_PREV As Long = Data_Proc_Val(i).ID_PREVE
        '                        Dim getID_PROG As Long = Data_Proc_Val(i).ID_PROCEDENCIA
        '                        If (refID_PREV = getID_PREV) And (refID_PROG = getID_PROG) Then
        '                            Data_JSON_List(a).TOTAL_ATE = Data_Proc_Val(i).TOTAL_ATE
        '                            Data_JSON_List(a).TOTAL_PREVE = Data_Proc_Val(i).TOTAL_PREVE
        '                            Data_JSON_List(a).TOT_FONASA = Data_Proc_Val(i).TOT_FONASA
        '                            Data_JSON_List(a).TOTA_SIS = Data_Proc_Val(i).TOTA_SIS
        '                            Data_JSON_List(a).TOTA_USU = Data_Proc_Val(i).TOTA_USU
        '                            Data_JSON_List(a).TOTA_COPA = Data_Proc_Val(i).TOTA_COPA
        '                            Exit For
        '                        End If
        '                    Next i
        '                Next a
        '            End If
        '            Data_OUT(y).Data_Proced = Data_JSON_List
        '        Next y
        'Case Else
        '        For y = 0 To (Data_OUT.Count - 1)
        '            Dim Data_Proc_Val As New List(Of E_IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_LUGAR_PROGRAMA)
        '            Dim Data_JSON_List As New List(Of E_Ate_Prev_Prog_JSON_PROC)
        '            Dim strSQL As New StringBuilder
        '            strSQL.Append("DECLARE" & vbLf)
        '            strSQL.Append("    @ID_CODF as NUMERIC(9)," & vbLf)
        '            strSQL.Append("    @ID_PREV as NUMERIC(9)," & vbLf)
        '            strSQL.Append("    @ID_PROG as NUMERIC(9)," & vbLf)
        '            strSQL.Append("    @DATE_01 as DATETIME," & vbLf)
        '            strSQL.Append("    @DATE_02 as DATETIME" & vbLf)
        '            strSQL.Append("" & vbLf)
        '            strSQL.Append("SET @ID_CODF = " & Data_OUT(y).ID_CODIGO_FONASA & vbLf)
        '            strSQL.Append("SET @ID_PREV = " & ID_PREV & vbLf)
        '            strSQL.Append("SET @ID_PROG = " & ID_PROG & vbLf)
        '            strSQL.Append("SET @DATE_01 = '" & Format(Date_01, "dd/MM/yyyy") & "'" & vbLf)
        '            strSQL.Append("SET @DATE_02 = '" & Format(Date_02, "dd/MM/yyyy") & "'" & vbLf)
        '            strSQL.Append("SET @DATE_02 = DATEADD(DAY, 1, @DATE_02)" & vbLf)
        '            strSQL.Append("" & vbLf)
        '            strSQL.Append("SELECT" & vbLf)
        '            strSQL.Append("    COUNT(DISTINCT dbo.IRIS_ATENCION.ID_ATENCION) AS TOTAL_ATE," & vbLf)
        '            strSQL.Append("    COUNT(DISTINCT dbo.IRIS_ATENCION.ID_PREVE) AS TOTAL_PREVE," & vbLf)
        '            strSQL.Append("    COUNT(dbo.IRIS_DET_ATENCION.ID_CODIGO_FONASA) AS TOT_FONASA," & vbLf)
        '            strSQL.Append("    SUM(dbo.IRIS_DET_ATENCION.ATE_DET_V_PREVI) AS TOTA_SIS," & vbLf)
        '            strSQL.Append("    dbo.IRIS_CODIGO_FONASA.CF_DESC," & vbLf)
        '            strSQL.Append("    dbo.IRIS_DET_ATENCION.ID_CODIGO_FONASA," & vbLf)
        '            strSQL.Append("    dbo.IRIS_DET_ATENCION.ID_ESTADO," & vbLf)
        '            strSQL.Append("    dbo.IRIS_CODIGO_FONASA.CF_COD," & vbLf)
        '            strSQL.Append("    dbo.IRIS_ATENCION.ID_PROGRA," & vbLf)
        '            strSQL.Append("    dbo.IRIS_PROGRAMA.PROGRA_DESC," & vbLf)
        '            strSQL.Append("	   dbo.IRIS_PREVISION.ID_PREVE," & vbLf)
        '            strSQL.Append("	   dbo.IRIS_PREVISION.PREVE_DESC," & vbLf)
        '            strSQL.Append("	   dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA," & vbLf)
        '            strSQL.Append("	   dbo.IRIS_PROCEDENCIA.PROC_DESC" & vbLf)
        '            strSQL.Append("" & vbLf)
        '            strSQL.Append("FROM dbo.IRIS_ATENCION" & vbLf)
        '            strSQL.Append("" & vbLf)
        '            strSQL.Append("INNER JOIN dbo.IRIS_DET_ATENCION ON" & vbLf)
        '            strSQL.Append("    dbo.IRIS_ATENCION.ID_ATENCION = dbo.IRIS_DET_ATENCION.ID_ATENCION" & vbLf)
        '            strSQL.Append("INNER JOIN dbo.IRIS_CODIGO_FONASA ON" & vbLf)
        '            strSQL.Append("    dbo.IRIS_DET_ATENCION.ID_CODIGO_FONASA = dbo.IRIS_CODIGO_FONASA.ID_CODIGO_FONASA" & vbLf)
        '            strSQL.Append("INNER JOIN dbo.IRIS_PROCEDENCIA ON" & vbLf)
        '            strSQL.Append("    dbo.IRIS_ATENCION.ID_PROCEDENCIA = dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA" & vbLf)
        '            strSQL.Append("INNER JOIN dbo.IRIS_PREVISION ON" & vbLf)
        '            strSQL.Append("    dbo.IRIS_ATENCION.ID_PREVE = dbo.IRIS_PREVISION.ID_PREVE" & vbLf)
        '            strSQL.Append("INNER JOIN dbo.IRIS_DOCTORES ON" & vbLf)
        '            strSQL.Append("    dbo.IRIS_ATENCION.ID_DOCTOR = dbo.IRIS_DOCTORES.ID_DOCTOR" & vbLf)
        '            strSQL.Append("" & vbLf)
        '            strSQL.Append("INNER JOIN dbo.IRIS_PROGRAMA ON" & vbLf)
        '            strSQL.Append("    dbo.IRIS_ATENCION.ID_PROGRA = dbo.IRIS_PROGRAMA.ID_PROGRA" & vbLf)
        '            strSQL.Append("" & vbLf)
        '            strSQL.Append("WHERE" & vbLf)
        '            strSQL.Append("        (dbo.IRIS_ATENCION.ATE_FECHA BETWEEN CONVERT(datetime, @DATE_01, 103)" & vbLf)
        '            strSQL.Append("    AND CONVERT(datetime, @DATE_02, 103))" & vbLf)
        '            strSQL.Append("" & vbLf)
        '            strSQL.Append("    AND (dbo.IRIS_DET_ATENCION.ID_CODIGO_FONASA = @ID_CODF)" & vbLf)
        '            strSQL.Append("    AND (dbo.IRIS_ATENCION.ID_PROGRA = @ID_PROG)" & vbLf)
        '            strSQL.Append("    AND (dbo.IRIS_ATENCION.ID_PREVE = @ID_PREV) " & vbLf)
        '            strSQL.Append("" & vbLf)
        '            strSQL.Append("    --Procedencias" & vbLf)
        '            If (Data_Proc_Info.Count > 0) Then
        '                strSQL.Append("    AND (" & vbLf)
        '                For yy = 0 To (Data_Proc_Info.Count - 1)
        '                    Dim Data_Proc_JSON As New E_Ate_Prev_Prog_JSON_PROC
        '                    Dim nProc As Long = Data_Proc_Info(yy).ID_PROCEDENCIA
        '                    Select Case yy
        '                        Case 0
        '                            strSQL.Append("        (dbo.IRIS_ATENCION.ID_PROCEDENCIA = " & nProc & ")" & vbLf)
        '                        Case Else
        '                            strSQL.Append("    OR  (dbo.IRIS_ATENCION.ID_PROCEDENCIA = " & nProc & ")" & vbLf)
        '                    End Select
        '                    Data_Proc_JSON.PROC_DESC = Data_Proc_Info(yy).PROC_DESC
        '                    Data_Proc_JSON.PREVE_DESC = Data_Proc_Info(yy).PREVE_DESC
        '                    Data_Proc_JSON.ID_PREVE = ID_PREV
        '                    Data_Proc_JSON.ID_PROCEDENCIA = Data_Proc_Info(yy).ID_PROCEDENCIA
        '                    Data_JSON_List.Add(Data_Proc_JSON)
        '                Next yy
        '                strSQL.Append("	)" & vbLf)
        '            End If
        '            strSQL.Append("" & vbLf)
        '            strSQL.Append("GROUP BY" & vbLf)
        '            strSQL.Append("    dbo.IRIS_CODIGO_FONASA.CF_COD," & vbLf)
        '            strSQL.Append("    dbo.IRIS_CODIGO_FONASA.CF_DESC," & vbLf)
        '            strSQL.Append("    dbo.IRIS_DET_ATENCION.ID_CODIGO_FONASA," & vbLf)
        '            strSQL.Append("    dbo.IRIS_DET_ATENCION.ID_ESTADO," & vbLf)
        '            strSQL.Append("    dbo.IRIS_ATENCION.ID_PROGRA," & vbLf)
        '            strSQL.Append("    dbo.IRIS_PROGRAMA.PROGRA_DESC," & vbLf)
        '            strSQL.Append("    dbo.IRIS_ATENCION.ID_ESTADO," & vbLf)
        '            strSQL.Append("    dbo.IRIS_PROCEDENCIA.ID_PROCEDENCIA," & vbLf)
        '            strSQL.Append("    dbo.IRIS_PROCEDENCIA.PROC_DESC," & vbLf)
        '            strSQL.Append("    dbo.IRIS_PREVISION.ID_PREVE," & vbLf)
        '            strSQL.Append("    dbo.IRIS_PREVISION.PREVE_DESC" & vbLf)
        '            strSQL.Append("    " & vbLf)
        '            strSQL.Append("HAVING" & vbLf)
        '            strSQL.Append("        (dbo.IRIS_DET_ATENCION.ID_ESTADO = 1)" & vbLf)
        '            strSQL.Append("    AND (dbo.IRIS_ATENCION.ID_ESTADO = '1')" & vbLf)
        '            If (y = 60) Then
        '                Dim aaaaaaa = "asdf"
        '            End If
        '            'Buscar los valores asociados a la procedencia
        '            Data_Proc_Val = NN_Search.IRIS_WEBF_BUSCA_LIS_ADM_RESU_CANT_EXAMENE_PREV_HOLANDA_LUGAR_PROGRAMA(strSQL.ToString)
        '            'Recorrer toda la tabla de Referencias de Procedencias
        '            If (Data_Proc_Val.Count > 0) Then
        '                For a = 0 To (Data_JSON_List.Count - 1)
        '                    'Comprobar si algún valor devuelto calza con las referencias
        '                    For i = 0 To (Data_Proc_Val.Count - 1)
        '                        Dim refID_PREV As Long = Data_JSON_List(a).ID_PREVE
        '                        Dim refID_PROG As Long = Data_JSON_List(a).ID_PROCEDENCIA
        '                        Dim getID_PREV As Long = Data_Proc_Val(i).ID_PREVE
        '                        Dim getID_PROG As Long = Data_Proc_Val(i).ID_PROCEDENCIA
        '                        If (refID_PREV = getID_PREV) And (refID_PROG = getID_PROG) Then
        '                            Data_JSON_List(a).TOTAL_ATE = Data_Proc_Val(i).TOTAL_ATE
        '                            Data_JSON_List(a).TOTAL_PREVE = Data_Proc_Val(i).TOTAL_PREVE
        '                            Data_JSON_List(a).TOT_FONASA = Data_Proc_Val(i).TOT_FONASA
        '                            Data_JSON_List(a).TOTA_SIS = Data_Proc_Val(i).TOTA_SIS
        '                            Data_JSON_List(a).TOTA_USU = 0
        '                            Data_JSON_List(a).TOTA_COPA = 0
        '                            Exit For
        '                        End If
        '                    Next i
        '                Next a
        '            End If
        '            Data_OUT(y).Data_Proced = Data_JSON_List
        '        Next y
        'End Select
        'Sumar Hemogramas a los VHS (Porque los Hemogramas Incluyen VHS)
        'Obtener datos del Hemograma
        If (Hem_Pos >= 0) And (VHS_Pos >= 0) Then
            Data_OUT(VHS_Pos).TOTAL_ATE += Data_OUT(Hem_Pos).TOTAL_ATE
            Data_OUT(VHS_Pos).TOTAL_PREVE += Data_OUT(Hem_Pos).TOTAL_PREVE
            Data_OUT(VHS_Pos).TOT_FONASA += Data_OUT(Hem_Pos).TOT_FONASA
            Data_OUT(VHS_Pos).TOTA_SIS += Data_OUT(Hem_Pos).TOTA_SIS
            Data_OUT(VHS_Pos).TOTA_USU += Data_OUT(Hem_Pos).TOTA_USU
            Data_OUT(VHS_Pos).TOTA_COPA += Data_OUT(Hem_Pos).TOTA_COPA
            'For yy = 0 To (Data_OUT(Hem_Pos).Data_Proced.Count - 1)
            '    Data_OUT(VHS_Pos).Data_Proced(yy).ID_PROCEDENCIA += Data_OUT(Hem_Pos).Data_Proced(yy).ID_PROCEDENCIA
            '    Data_OUT(VHS_Pos).Data_Proced(yy).TOTAL_ATE += Data_OUT(Hem_Pos).Data_Proced(yy).TOTAL_ATE
            '    Data_OUT(VHS_Pos).Data_Proced(yy).TOTAL_PREVE += Data_OUT(Hem_Pos).Data_Proced(yy).TOTAL_PREVE
            '    Data_OUT(VHS_Pos).Data_Proced(yy).TOT_FONASA += Data_OUT(Hem_Pos).Data_Proced(yy).TOT_FONASA
            '    Data_OUT(VHS_Pos).Data_Proced(yy).TOTA_SIS += Data_OUT(Hem_Pos).Data_Proced(yy).TOTA_SIS
            '    Data_OUT(VHS_Pos).Data_Proced(yy).TOTA_USU += Data_OUT(Hem_Pos).Data_Proced(yy).TOTA_USU
            '    Data_OUT(VHS_Pos).Data_Proced(yy).TOTA_COPA += Data_OUT(Hem_Pos).Data_Proced(yy).TOTA_COPA
            'Next yy
        End If
        'Ordenar
        'If (ID_PREV = 126) Then
        '    Data_OUT = Ordenar_Peñalolen(Data_OUT, Data_Proc_Info)
        'End If
        'Multiplicar x3 los valores de Electrolitos
        For y = 0 To Data_OUT.Count - 1
            If (Data_OUT(y).ID_CODIGO_FONASA = 74) Then
                Data_OUT(y).TOTAL_ATE *= 3
                Data_OUT(y).TOT_FONASA *= 3
                Data_OUT(y).Data_Fonasa.CF_PRECIO_AMB *= 3
                'For a = 0 To (Data_OUT(y).Data_Proced.Count - 1)
                '    Data_OUT(y).Data_Proced(a).TOTAL_ATE *= 3
                'Next a
            End If
        Next y
        Return Data_OUT
    End Function
    Function Gen_Excel(ByVal MAIN_URL As String, ByVal Group As Integer, ByVal ID_PREV As Long, ByVal ID_PROG As String, ByVal DATE_str01 As String, ByVal DATE_str02 As String) As String
        'Declaraciones internas
        Dim NN_Date As New N_Date_Operat
        Dim Date_01 As Date = NN_Date.strToDate(Split(DATE_str01, "/")(2), Split(DATE_str01, "/")(1), Split(DATE_str01, "/")(0))
        Dim Date_02 As Date = NN_Date.strToDate(Split(DATE_str02, "/")(2), Split(DATE_str02, "/")(1), Split(DATE_str02, "/")(0))
        'Declaraciones Consulta
        Dim Data_OUT As New List(Of E_Ate_Prev_Prog_JSON_Output)
        'Realizar consulta inicial
        Data_OUT = Gen_Table(ID_PREV, ID_PROG, DATE_str01, DATE_str02)
        If (Group <> 0) Then
            Data_OUT = Group_Elem(Data_OUT)
        End If
        'Select Case (Group)
        '    Case 0
        '        Data_OUT = Data_unGroup(ID_PREV, ID_PROG, Date_01, Date_02)
        '    Case Else
        '        Data_OUT = Data_Group(ID_PREV, ID_PROG, Date_01, Date_02)
        'End Select
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
            For a = 0 To Data_OUT(y).Data_Proced.Count - 1
                Mx_Data(5 + a, y) = Data_OUT(y).Data_Proced(a).TOTAL_ATE
            Next a
        Next y
        'Crear Tabla
        Dim Xls As New SLDocument
        Dim tablePosRow As Integer = 7
        Dim tablePosCol As Integer = 1
        'Colocar Título
        Xls.SetCellValue(1, 1, "Resumen de Atenciones por Previsión y Programa: ")
        If (Data_OUT(0).Data_Proced.Count <> 0) Then
            Xls.SetCellValue(2, 1, "Previsión: " & Data_OUT(0).Data_Proced(0).PREVE_DESC)
        End If
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
        If (Data_OUT(0).Data_Proced.Count <> 0) Then
            For y = 0 To (Data_OUT(0).Data_Proced.Count - 1)
                If (Data_OUT(0).Data_Proced(y).PROC_DESC <> Nothing) Or (Data_OUT(0).Data_Proced(y).PROC_DESC <> "") Then
                    Xls.SetCellValue(tablePosRow, tablePosCol_now, Data_OUT(0).Data_Proced(y).PROC_DESC) : tablePosCol_now += 1
                Else
                    Xls.SetCellValue(tablePosRow, tablePosCol_now, "Vacío") : tablePosCol_now += 1
                End If
            Next y
        End If
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
                If (Mx_Data(x, y) <> Nothing) Then
                    Xls.SetCellValue(tablePosRow_now, tablePosCol + x, Mx_Data(x, y))
                Else
                    Xls.SetCellValue(tablePosRow_now, tablePosCol + x, 0)
                End If
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
    Function Lista_Exa_Cod_Fonasa(ByVal VAR As String) As List(Of E_Lista_Exa_Cod_Fonasa)
        Return DD_Data.Lista_Exa_Cod_Fonasa(VAR)
    End Function
    '''<summary>
    '''Devuelve una cadena con el nombre que corresponde de acuerdo al Código Fonasa
    '''</summary>
    '''<param name="COD_FONASA">Cadena con el código de exámen según Fonasa</param>
    '''<param name="ORIG_DESCR">Nombre que trae dicho exámen desde la base de datos</param>
    '''<returns></returns>
    '''<remarks></remarks>
    ''' 
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
    Function Group_Elem(ByVal Data_OUT As List(Of E_Ate_Prev_Prog_JSON_Output)) As List(Of E_Ate_Prev_Prog_JSON_Output)
        'Agrupar los exámenes
        Dim Mx_Dtt_Grp As New List(Of E_Ate_Prev_Prog_JSON_Output)
        Dim Mx_COD As New List(Of String)
        'Crear Matrix con todos los Códigos sin repetirse
        For y = 0 To (Data_OUT.Count - 1)
            Dim CODE As String = Data_OUT(y).CF_COD
            Dim Mx_i As Long = Mx_COD.Count - 1
            If (y = 0) Then
                Mx_COD.Add(CODE)
            ElseIf (y > 0) Then
                If (CODE <> Mx_COD(Mx_i)) Then
                    Dim Exist As Boolean = False
                    For i = 0 To (Mx_COD.Count - 1)
                        If (CODE = Mx_COD(i)) Then
                            Exist = True
                            Exit For
                        End If
                    Next i
                    If (Exist = False) Then
                        Mx_COD.Add(CODE)
                    End If
                End If
            End If
        Next y
        'Recorrer Matrix de códigos
        For y = 0 To Mx_COD.Count - 1
            For yy = 0 To (Data_OUT.Count - 1)
                'Declaración de Evaluación
                Dim Curr_CODF = Mx_COD(y)
                Dim Container As New E_Ate_Prev_Prog_JSON_Output
                Container = Data_OUT(yy)
                'Buscar Coincidencia
                If (Container.CF_COD = Curr_CODF) Then
                    Dim Pos As Long = Mx_Dtt_Grp.Count - 1
                    'Cambiar Descripción
                    Select Case (Container.CF_COD)
                        Case "0302063"
                            Container.CF_DESC = "Transaminas GOT y/o GPT"
                        Case "0302032"
                            Container.CF_DESC = "Electrolitos Plasmaticos"
                        Case "0302023"
                            Container.CF_DESC = "Creatinina en Sangre"
                        Case "0309022"
                            Container.CF_DESC = "Orina Completa"
                        Case "0302060"
                            Container.CF_DESC = "Albumina y/o Proteinas Totales en Sangre"
                        Case "0302035"
                            Container.CF_DESC = "Niveles Plasmaticos"
                    End Select
                    If (Pos < 0) Then
                        Mx_Dtt_Grp.Add(Container)
                        Continue For
                    End If
                    If (Container.CF_COD <> Mx_Dtt_Grp(Pos).CF_COD) Then
                        'Cuando no existe otro ejemplar...
                        Mx_Dtt_Grp.Add(Container)
                    Else
                        'Cuando sí existe otro ejemplar...
                        Mx_Dtt_Grp(Pos).CF_COD = Container.CF_COD
                        Mx_Dtt_Grp(Pos).TOTAL_ATE += Container.TOTAL_ATE
                        For i = 0 To (Mx_Dtt_Grp(Pos).Data_Proced.Count - 1)
                            Mx_Dtt_Grp(Pos).Data_Proced(i).TOTAL_ATE += Container.Data_Proced(i).TOTAL_ATE
                        Next i
                    End If
                End If
            Next
        Next y
        Return Mx_Dtt_Grp
    End Function
    Function Ordenar_Peñalolen(ByVal obj_List As List(Of E_Ate_Prev_Prog_JSON_Output), ByVal Proced As List(Of E_IRIS_WEBF_BUSCA_RELACION_PREV_PROCE_POR_ID_PREV)) As List(Of E_Ate_Prev_Prog_JSON_Output)
        'Crear una matriz con las ID y las posiciones
        Dim Mx_Order(1, 44) As String
        Dim List_OUT As New List(Of E_Ate_Prev_Prog_JSON_Output)
        Mx_Order(0, 0) = 26 : Mx_Order(1, 0) = "Hematocrito"
        Mx_Order(0, 1) = 28 : Mx_Order(1, 1) = "Hemoglobina Glicosilada"
        Mx_Order(0, 2) = 27 : Mx_Order(1, 2) = "Hemoglobina"
        Mx_Order(0, 3) = 30 : Mx_Order(1, 3) = "Hemograma"
        Mx_Order(0, 4) = 31 : Mx_Order(1, 4) = "Tiempo de Protrombina"
        Mx_Order(0, 5) = 35 : Mx_Order(1, 5) = "Recuento de Leucocitos"
        Mx_Order(0, 6) = 38 : Mx_Order(1, 6) = "Recuento de Plaquetas"
        Mx_Order(0, 7) = 45 : Mx_Order(1, 7) = "VHS"
        Mx_Order(0, 8) = 54 : Mx_Order(1, 8) = "Acido úrico, en sangre (Uricemia)"
        Mx_Order(0, 9) = 58 : Mx_Order(1, 9) = "Bilirrubinemia (bili total y conjugada)"
        Mx_Order(0, 10) = 66 : Mx_Order(1, 10) = "Creatinina en Sangre"
        Mx_Order(0, 11) = 67 : Mx_Order(1, 11) = "Clearence de Creatinina"
        Mx_Order(0, 12) = 70 : Mx_Order(1, 12) = "Creatinquinasa CK-TOTAL"
        Mx_Order(0, 13) = 74 : Mx_Order(1, 13) = "Electrolitos Plasmaticos"
        Mx_Order(0, 14) = 76 : Mx_Order(1, 14) = "Perfil  Lipídico"
        Mx_Order(0, 15) = 86 : Mx_Order(1, 15) = "Niveles Plasmaticos"
        Mx_Order(0, 16) = 94 : Mx_Order(1, 16) = "Fosfatasas Alcalinas"
        Mx_Order(0, 17) = 97 : Mx_Order(1, 17) = "Gama Glutamil Transpeptidasa (GGT)"
        Mx_Order(0, 18) = 103 : Mx_Order(1, 18) = "Glicemia"
        Mx_Order(0, 19) = 676 : Mx_Order(1, 19) = "Test de tolerancia a la glucosa"
        Mx_Order(0, 20) = 557 : Mx_Order(1, 20) = "Nitrogeno Ureico (en sangre)"
        Mx_Order(0, 21) = 134 : Mx_Order(1, 21) = "Albumina y/o Proteinas Totales en Sangre"
        Mx_Order(0, 22) = 775 : Mx_Order(1, 22) = "Transaminas GOT y/o GPT"
        Mx_Order(0, 23) = 140 : Mx_Order(1, 23) = "Colesterol Total"
        Mx_Order(0, 24) = 668 : Mx_Order(1, 24) = "Perfil Hepático"
        Mx_Order(0, 25) = 527 : Mx_Order(1, 25) = "Hormona Tiroestimulante (TSH)"
        Mx_Order(0, 26) = 181 : Mx_Order(1, 26) = "Hormona tiroídea, Tiroxina Libre (T4L)"
        Mx_Order(0, 27) = 504 : Mx_Order(1, 27) = "Factor Reumatoideo Cuantitativo"
        Mx_Order(0, 28) = 650 : Mx_Order(1, 28) = "PSA Total"
        Mx_Order(0, 29) = 274 : Mx_Order(1, 29) = "Directo al Fresco"
        Mx_Order(0, 30) = 279 : Mx_Order(1, 30) = "Tincion de Gram"
        Mx_Order(0, 31) = 284 : Mx_Order(1, 31) = "Cultivo Corriente"
        Mx_Order(0, 32) = 292 : Mx_Order(1, 32) = "Urocultivo"
        Mx_Order(0, 33) = 296 : Mx_Order(1, 33) = "Cultivo Gonococo"
        Mx_Order(0, 34) = 315 : Mx_Order(1, 34) = "VDRL"
        Mx_Order(0, 35) = 304 : Mx_Order(1, 35) = "Antibiograma Corriente"
        Mx_Order(0, 36) = 316 : Mx_Order(1, 36) = "Coproparasitológico seriado simple"
        Mx_Order(0, 37) = 317 : Mx_Order(1, 37) = "Test de Graham"
        Mx_Order(0, 38) = 318 : Mx_Order(1, 38) = "Gusanos macroscopicos"
        Mx_Order(0, 39) = 376 : Mx_Order(1, 39) = "Hemorragias Ocultas "
        Mx_Order(0, 40) = 378 : Mx_Order(1, 40) = "Leucocitos Fecales"
        Mx_Order(0, 41) = 793 : Mx_Order(1, 41) = "Indice Mau/ Crea"
        Mx_Order(0, 42) = 462 : Mx_Order(1, 42) = "Microalbuminuria"
        Mx_Order(0, 43) = 426 : Mx_Order(1, 43) = "Orina Completa ""Con Uro"""
        Mx_Order(0, 44) = 745 : Mx_Order(1, 44) = "Orina Completa ""Sin Uro"""
        Dim str_B As New StringBuilder
        str_B.Append("Select distinct" & vbCrLf)
        str_B.Append("    dbo.IRIS_DET_ATENCION.ID_CODIGO_FONASA," & vbCrLf)
        str_B.Append("    dbo.IRIS_DET_ATENCION.ID_ESTADO," & vbCrLf)
        str_B.Append("    dbo.IRIS_CODIGO_FONASA.CF_COD," & vbCrLf)
        str_B.Append("    dbo.IRIS_CODIGO_FONASA.CF_DESC" & vbCrLf)
        str_B.Append("    FROM dbo.IRIS_DET_ATENCION" & vbCrLf)
        str_B.Append("    INNER JOIN dbo.IRIS_CODIGO_FONASA ON" & vbCrLf)
        str_B.Append("    dbo.IRIS_DET_ATENCION.ID_CODIGO_FONASA = dbo.IRIS_CODIGO_FONASA.ID_CODIGO_FONASA" & vbCrLf)
        str_B.Append("WHERE" & vbCrLf)
        str_B.Append("        (dbo.IRIS_DET_ATENCION.ID_ESTADO = 1)" & vbCrLf)
        str_B.Append("    or  (" & vbCrLf)
        For y = 0 To Mx_Order.GetUpperBound(1)
            Select Case y
                Case 0
                    str_B.Append("            (dbo.IRIS_CODIGO_FONASA.ID_CODIGO_FONASA = " & Mx_Order(0, y) & ")" & vbCrLf)
                Case Else
                    str_B.Append("        and (dbo.IRIS_CODIGO_FONASA.ID_CODIGO_FONASA = " & Mx_Order(0, y) & ")" & vbCrLf)
            End Select
        Next y
        str_B.Append("    )" & vbCrLf)
        Dim NN_Search As New N_List_Ate_Prev_and_Prog_Alt_G_Resumen
        Dim Data_T As New List(Of E_Lista_Exa_Cod_Fonasa)
        Data_T = NN_Search.Lista_Exa_Cod_Fonasa(str_B.ToString)
        'Recorrer la matrz con el orden de las celdas
        For y = 0 To (Mx_Order.GetUpperBound(1))
            Dim ID_Ref As Long = Mx_Order(0, y)
            Dim Found As Boolean = False
            Dim a As Long = 0
            'Recorrer la lista de entrada
            While (a < obj_List.Count)
                Dim ID_List As Long = obj_List(a).ID_CODIGO_FONASA
                If (ID_Ref = ID_List) Then
                    Found = True
                    List_OUT.Add(obj_List(a))
                    obj_List.RemoveAt(a)
                Else
                    a += 1
                End If
            End While
            'Agregar elemento Faltante
            If (Found = False) Then
                For ay = 0 To (Data_T.Count - 1)
                    Dim obj_Item_Null As New E_Ate_Prev_Prog_JSON_Output
                    Dim ID_List As Long = Data_T(ay).ID_CODIGO_FONASA
                    If (ID_Ref = ID_List) Then
                        'Agregar Código Fonasa sin el guión y número que le sigue
                        Select Case (InStr(Data_T(ay).CF_COD, "-"))
                            Case 0
                                obj_Item_Null.CF_COD = Data_T(ay).CF_COD
                            Case Else
                                Dim Cod_Fonasa_AAA() As String = Split(Data_T(ay).CF_COD, "-")
                                obj_Item_Null.CF_COD = Cod_Fonasa_AAA(0)
                        End Select
                        obj_Item_Null.CF_DESC = Data_T(ay).CF_DESC
                        obj_Item_Null.ID_CODIGO_FONASA = ID_List
                        obj_Item_Null.ID_ESTADO = 1
                        obj_Item_Null.ID_PROGRA = 0
                        obj_Item_Null.PROGRA_DESC = ""
                        obj_Item_Null.TOT_FONASA = 0
                        obj_Item_Null.TOTA_COPA = 0
                        obj_Item_Null.TOTA_SIS = 0
                        obj_Item_Null.TOTA_USU = 0
                        obj_Item_Null.TOTAL_ATE = 0
                        obj_Item_Null.TOTAL_PREVE = 0
                        Dim Fonasa_Item As New E_IRIS_WEBF_BUSCA_ATENCION_CODIGO_FONASA_ID
                        Fonasa_Item.AÑO_COD = 0
                        Fonasa_Item.CF_COD = 0
                        Fonasa_Item.CF_DESC = 0
                        Fonasa_Item.CF_DIAS = 0
                        Fonasa_Item.CF_NO_FONASA = 0
                        Fonasa_Item.CF_PRECIO_AMB = 0
                        Fonasa_Item.CF_PRECIO_HOS = 0
                        Fonasa_Item.CF_SEL_PRUE = 0
                        Fonasa_Item.ID_CF_PRECIO = 0
                        Fonasa_Item.ID_CODIGO_FONASA = 0
                        Fonasa_Item.ID_ESTADO = 0
                        Fonasa_Item.ID_ESTADO = 0
                        Fonasa_Item.ID_PER = 0
                        Fonasa_Item.ID_PER = 0
                        Fonasa_Item.ID_PREVE = 0
                        Fonasa_Item.ID_PREVE = 0
                        obj_Item_Null.Data_Fonasa = Fonasa_Item
                        Dim Proced_List As New List(Of E_Ate_Prev_Prog_JSON_PROC)
                        For la = 0 To (Proced.Count - 1)
                            Dim Proced_Item As New E_Ate_Prev_Prog_JSON_PROC
                            Proced_Item.ID_PROCEDENCIA = Proced(la).ID_PROCEDENCIA
                            Proced_Item.PROC_DESC = Proced(la).PROC_DESC
                            Proced_Item.ID_PREVE = Proced(la).ID_PREVE
                            Proced_Item.PREVE_DESC = Proced(la).PREVE_DESC
                            Proced_List.Add(Proced_Item)
                        Next la
                        obj_Item_Null.Data_Proced = Proced_List
                        List_OUT.Add(obj_Item_Null)
                        Exit For
                    End If
                Next ay
            End If
        Next y
        'Agregar los elementos sobrantes
        If (obj_List.Count > 0) Then
            While (obj_List.Count > 0)
                List_OUT.Add(obj_List(0))
                obj_List.RemoveAt(0)
            End While
        End If
        'Referencia orden procedencias
        Dim Mx_Proced(6) As String
        Mx_Proced(0) = 355  'CAROL URZUA
        Mx_Proced(1) = 356  'CECOF PEÑA
        Mx_Proced(2) = 358  'LA FAENA
        Mx_Proced(3) = 360  'RAUL SILVA HENRIQUEZ
        Mx_Proced(4) = 359  'LO HERMIDA
        Mx_Proced(5) = 383  'PADRE G. WHELAN
        Mx_Proced(6) = 381  'SAN LUIS
        'Ordenar las Procedencias
        For y = 0 To (List_OUT.Count - 1)
            Dim Proc_In As New List(Of E_Ate_Prev_Prog_JSON_PROC)
            Dim Proc_Ou As New List(Of E_Ate_Prev_Prog_JSON_PROC)
            Proc_In = List_OUT(y).Data_Proced
            For ayy = 0 To Mx_Proced.GetUpperBound(0)
                Dim kek = 0
                While (kek < Proc_In.Count)
                    If (Mx_Proced(ayy) = Proc_In(kek).ID_PROCEDENCIA) Then
                        Proc_Ou.Add(Proc_In(kek))
                        Proc_In.RemoveAt(kek)
                        kek = 0
                        Continue While
                    ElseIf (Proc_In(kek).PROC_DESC = "") Or (Proc_In(kek).PROC_DESC = Nothing) Then
                        Proc_In.RemoveAt(kek)
                    Else
                        kek += 1
                    End If
                End While

            Next ayy
            If (Proc_In.Count > 0) Then
                For lmao = 0 To (Proc_In.Count - 1)
                    Proc_Ou.Add(Proc_In(lmao))
                Next lmao
            End If
            List_OUT(y).Data_Proced = Proc_Ou
        Next y
        Return List_OUT
    End Function
End Class
