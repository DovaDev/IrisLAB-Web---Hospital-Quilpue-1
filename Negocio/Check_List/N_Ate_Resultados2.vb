Imports Datos
Imports Entidades
Public Class N_Ate_Resultados2
    'Declaraciones generales
    Dim DD_Data As D_Ate_Resultados
    Sub New()
        DD_Data = New D_Ate_Resultados
    End Sub
    Function Num_Dec(ByVal Num As Double, ByVal dec As Integer) As String
        Dim xStr As String = "###,###,##0."
        For y = 1 To dec
            xStr = xStr & "0"
        Next y
        Return Format(Num, xStr)
    End Function
    Function Json_Item_Result_Interval(ByVal ID_Prueba As Long,
                                       ByVal SEXO As String,
                                              ByVal F_NAC As Date,
                                              ByVal Json_Item As E_Json_Result_DataTable_Values2) As E_Json_Result_DataTable_Values2
        Dim Data_Rango As List(Of E_IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA)
        Dim Date_01(2) As Double
        Dim Date_02(2) As Double
        Dim F_nacim(2) As Long
        F_nacim(0) = Format(F_NAC, "yyyy")
        F_nacim(1) = Format(F_NAC, "MM")
        F_nacim(2) = Format(F_NAC, "dd")
        Dim Date_Nac As Date = strToDate(F_nacim(0), F_nacim(1), F_nacim(2))
        Dim Date_Desde As Date = Nothing
        Dim Date_Hasta As Date = Nothing
        Dim Encontrar_Datos As Boolean = False
        Dim rel_pos As Long = 0
        Data_Rango = IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA(ID_Prueba, SEXO)
        If (Data_Rango.Count > 0) Then
            For y = 0 To (Data_Rango.Count - 1)
                Date_01(0) = Data_Rango(y).RF_ANO_DESDE
                Date_01(1) = Data_Rango(y).RF_MESES_DESDE
                Date_01(2) = Data_Rango(y).RF_DIAS_DESDE
                Date_02(0) = Data_Rango(y).RF_ANO_HASTA
                Date_02(1) = Data_Rango(y).RF_MESES_HASTA
                Date_02(2) = Data_Rango(y).RF_DIAS_HASTA
                Date_Desde = Calcular_Rango_Ref(Date.Now, Date_01(0), Date_01(1), Date_01(2))
                Date_Hasta = Calcular_Rango_Ref(Date.Now, Date_02(0), Date_02(1), Date_02(2))
                If (Date_Hasta <= Date_Nac) And (Date_Nac <= Date_Desde) Then
                    Encontrar_Datos = True
                    rel_pos = y
                    Exit For
                End If
            Next y
        End If
        If (Encontrar_Datos = True) Then
            Dim objB2 As Object     'Muy Bajo
            Dim objB1 As Object     'Bajo
            Dim objA1 As Object     'Alto
            Dim objA2 As Object     'Muy Alto
            If ((Trim(Data_Rango(rel_pos).RF_R_TEXTO).ToLower <> "null") And (Trim(Data_Rango(rel_pos).RF_R_TEXTO).ToLower <> Nothing)) Then
                objB2 = ""                                          'Muy Bajo
                objB1 = Trim(Data_Rango(rel_pos).RF_R_TEXTO)        'Bajo
                objA1 = "-"                                         'Alto
                objA2 = ""                                          'Muy Alto
            Else
                objB2 = Trim(Data_Rango(rel_pos).RF_V_B_DESDE)      'Muy Bajo
                objB1 = Trim(Data_Rango(rel_pos).RF_V_DESDE)        'Bajo
                objA1 = Trim(Data_Rango(rel_pos).RF_V_HASTA)        'Alto
                objA2 = Trim(Data_Rango(rel_pos).RF_V_A_HASTA)      'Muy Alto
            End If
            '--Muy Bajo----------------------
            If (IsNumeric(objB2) = True) Then
                Json_Item.b2 = CDbl(objB2)
            ElseIf (Trim(objB2) <> "") Then
                Json_Item.b2 = objB2
            Else
                Json_Item.b2 = Nothing
            End If
            '--Bajo--------------------------
            If (IsNumeric(objB1) = True) Then
                Json_Item.b1 = CDbl(objB1)
            ElseIf (Trim(objB1) <> "") Then
                Json_Item.b1 = objB1
            Else
                Json_Item.b1 = Nothing
            End If
            '--Alto--------------------------
            If (IsNumeric(objA1) = True) Then
                Json_Item.a1 = CDbl(objA1)
            ElseIf (Trim(objA1) <> "") Then
                Json_Item.a1 = objA1
            Else
                Json_Item.a1 = Nothing
            End If
            '--Muy Alto----------------------
            If (IsNumeric(objA2) = True) Then
                Json_Item.a2 = CDbl(objA2)
            ElseIf (Trim(objA2) <> "") Then
                Json_Item.a2 = objA2
            Else
                Json_Item.a2 = Nothing
            End If
        End If
        Return Json_Item
    End Function
    Public Function strToDate(ByVal nYear As Long, ByVal nMonth As Integer, ByVal nDay As Integer, Optional ByVal nHour As Integer = 0, Optional ByVal nMin As Integer = 0, Optional ByVal nSec As Integer = 0) As Date
        Dim strDate As String = ""
        Dim strRef As String = ""
        Dim nDate As Date
        strDate = Format(nYear, "0000") & "/" & Format(nMonth, "00") & "/" & Format(nDay, "00")
        strRef = "yyyy/MM/dd"
        strDate += " " & Format(nHour, "00")
        strRef += " HH"
        strDate += ":" & Format(nMin, "00")
        strRef += ":mm"
        strDate += ":" & Format(nSec, "00")
        strRef += ":ss"
        DateTime.TryParseExact(strDate, strRef, Nothing, Globalization.DateTimeStyles.None, nDate)
        Debug.WriteLine("Fecha actual: ")
        Debug.WriteLine(Format(nDate, "dd/MM/yyyy") & " - " & Format(nDate, "HH:mm:ss"))
        Debug.WriteLine("")
        Return nDate
    End Function
    Function IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA(ByVal ID_PRU As Long, ByVal SEXO As String) As List(Of E_IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA)
        Return DD_Data.IRIS_WEBF_BUSCA_VISOR_RANGO_REFERENCIA(ID_PRU, SEXO)
    End Function
    Function Calcular_Rango_Ref(ByVal Fecha_Ficha As Date, ByVal D_Year As Integer, ByVal D_Month As Integer, ByVal D_Day As Integer) As Date
        Dim Date_Tmp As Date = Fecha_Ficha
        Date_Tmp = Date_Tmp.AddYears(-D_Year)
        Date_Tmp = Date_Tmp.AddMonths(-D_Month)
        Date_Tmp = Date_Tmp.AddDays(-D_Day)
        Return Date_Tmp
    End Function
End Class
