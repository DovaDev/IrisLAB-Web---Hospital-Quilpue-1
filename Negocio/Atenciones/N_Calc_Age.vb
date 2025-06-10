Public Class N_Calc_Age
    Function IrisLAB_Cal_Edad_Exacta(ByVal Fecha_Nacimiento As Date, ByVal Fecha_Actual As Date, Optional ByVal Edad_Completa As Boolean = False) As String
        Dim btn_Mensaje As Object, titulo_Mensaje As String     'VARIABLES DE LOS MENSAJES
        Dim Años_ As Integer = 0
        Dim Meses_ As Integer = 0
        Dim dias_ As Integer = 0
        Dim xaños_FechaNac As Integer, xmeses_FechaNac As Integer, xdias_FechaNac As Integer
        Dim xaños_FechaAct As Integer, xmeses_FechaAct As Integer, xdias_FechaAct As Integer
        Dim FechaTmp As Date, AñosTmp As Integer, MesesTmp As Integer, DiasTmp As Integer
        Dim TextoAños As String, TextoMeses As String, TextoDias As String
        btn_Mensaje = vbOKOnly + vbInformation + vbDefaultButton1   ' Define los botones.
        titulo_Mensaje = "Calculo Edad Exacta"   ' Define el título
        IrisLAB_Cal_Edad_Exacta = ""
        If Fecha_Nacimiento > Fecha_Actual Then
            MsgBox("La Fecha de Nacimiento no puede ser mayor a la fecha actual." & Chr(13) _
                        & "Escriba bien las fechas para poder calcular la Edad Exacta", btn_Mensaje, titulo_Mensaje)
            IrisLAB_Cal_Edad_Exacta = ""
            Exit Function
        End If
        xaños_FechaNac = Year(Fecha_Nacimiento)
        xmeses_FechaNac = Month(Fecha_Nacimiento)
        xdias_FechaNac = Day(Fecha_Nacimiento)
        xaños_FechaAct = Year(Fecha_Actual)
        xmeses_FechaAct = Month(Fecha_Actual)
        xdias_FechaAct = Day(Fecha_Actual)
        If xmeses_FechaNac < xmeses_FechaAct Then     '05/08/1999=FechaActual      02/07/1999=FechaNacimiento
            If xdias_FechaNac < xdias_FechaAct Then
                Años_ = DateDiff("yyyy", Fecha_Nacimiento, Fecha_Actual)
                FechaTmp = DateAdd("yyyy", Años_, Fecha_Nacimiento)
                Meses_ = DateDiff("m", FechaTmp, Fecha_Actual)
                FechaTmp = DateAdd("m", Meses_, FechaTmp)
                dias_ = DateDiff("d", FechaTmp, Fecha_Actual)
            Else
                If xdias_FechaNac = xdias_FechaAct Then
                    Años_ = DateDiff("yyyy", Fecha_Nacimiento, Fecha_Actual)
                    FechaTmp = DateAdd("yyyy", Años_, Fecha_Nacimiento)
                    Meses_ = DateDiff("m", FechaTmp, Fecha_Actual)
                    FechaTmp = DateAdd("m", Meses_, FechaTmp)
                    dias_ = DateDiff("d", FechaTmp, Fecha_Actual) 'Es siempre 0
                Else
                    'EJEMPLO
                    'FECHA NACIMIENTO = 29/02/1940
                    'FECHA ACTUAL = 23/05/2003
                    FechaTmp = CDate("01/" & xmeses_FechaNac & "/" & xaños_FechaNac)
                    FechaTmp = DateAdd("m", 1, FechaTmp)
                    DiasTmp = DateDiff("d", Fecha_Nacimiento, FechaTmp)
                    Años_ = DateDiff("yyyy", FechaTmp, Fecha_Actual)
                    FechaTmp = DateAdd("yyyy", Años_, FechaTmp)
                    If FechaTmp > Fecha_Actual Then
                        Años_ = Años_ - 1
                        FechaTmp = DateAdd("yyyy", -1, FechaTmp)
                    End If
                    Meses_ = DateDiff("m", FechaTmp, Fecha_Actual) ' - 1
                    FechaTmp = DateAdd("m", Meses_, FechaTmp)
                    dias_ = DateDiff("d", FechaTmp, Fecha_Actual) + DiasTmp
                End If
            End If
        Else
            If xmeses_FechaNac = xmeses_FechaAct Then
                If xdias_FechaNac <= xdias_FechaAct Then
                    'EJEMPLO
                    'FECHA NACIMIENTO = 22/05/1937
                    'FECHA ACTUAL = 23/05/2003
                    Años_ = DateDiff("yyyy", Fecha_Nacimiento, Fecha_Actual)
                    FechaTmp = DateAdd("yyyy", Años_, Fecha_Nacimiento)
                    Meses_ = DateDiff("m", FechaTmp, Fecha_Actual)      'Es siempre 0
                    FechaTmp = DateAdd("m", Meses_, FechaTmp)
                    dias_ = DateDiff("d", FechaTmp, Fecha_Actual)       'Es siempre 0
                Else
                    'EJEMPLO
                    'FECHA NACIMIENTO = 30/05/1937
                    'FECHA ACTUAL = 22/05/2003
                    FechaTmp = CDate("01/" & xmeses_FechaNac & "/" & xaños_FechaNac)
                    FechaTmp = DateAdd("m", 1, FechaTmp)
                    AñosTmp = Year(FechaTmp)
                    MesesTmp = Month(FechaTmp)
                    DiasTmp = Day(FechaTmp)
                    DiasTmp = DateDiff("d", Fecha_Nacimiento, FechaTmp)
                    Años_ = DateDiff("yyyy", FechaTmp, Fecha_Actual)
                    FechaTmp = DateAdd("yyyy", Años_, FechaTmp)
                    If FechaTmp > Fecha_Actual Then
                        Años_ = Años_ - 1
                        FechaTmp = DateAdd("yyyy", -1, FechaTmp)
                    End If
                    Meses_ = DateDiff("m", FechaTmp, Fecha_Actual)
                    FechaTmp = DateAdd("m", Meses_, FechaTmp)
                    FechaTmp = DateAdd("d", -DiasTmp, FechaTmp)
                    dias_ = DateDiff("d", FechaTmp, Fecha_Actual)
                End If
            Else
                If xdias_FechaNac <= xdias_FechaAct Then
                    Años_ = DateDiff("yyyy", Fecha_Nacimiento, Fecha_Actual) - 1
                    If Años_ > 0 Then
                        FechaTmp = DateAdd("yyyy", Años_, Fecha_Nacimiento)
                    Else
                        FechaTmp = Fecha_Nacimiento
                    End If
                    Meses_ = DateDiff("m", FechaTmp, Fecha_Actual)
                    FechaTmp = DateAdd("m", Meses_, FechaTmp)
                    dias_ = DateDiff("d", FechaTmp, Fecha_Actual)
                Else
                    'EJEMPLO
                    'FECHA NACIMIENTO = 24/12/1937
                    'FECHA ACTUAL = 23/05/2003
                    FechaTmp = CDate("01/" & xmeses_FechaNac & "/" & xaños_FechaNac)
                    FechaTmp = DateAdd("m", 1, FechaTmp)
                    DiasTmp = Day(FechaTmp)
                    dias_ = DateDiff("d", Fecha_Nacimiento, FechaTmp)
                    If DiasTmp <= xdias_FechaAct Then
                        DiasTmp = dias_
                        Años_ = DateDiff("yyyy", Fecha_Nacimiento, Fecha_Actual) - 1
                        If Años_ > 0 Then
                            FechaTmp = DateAdd("yyyy", Años_, FechaTmp)
                        End If
                        Meses_ = DateDiff("m", FechaTmp, Fecha_Actual)
                        FechaTmp = DateAdd("m", Meses_, FechaTmp)
                        dias_ = DateDiff("d", FechaTmp, Fecha_Actual) + dias_
                    End If
                End If
            End If
        End If
        TextoAños = IIf(Años_ = 1, "Año", "Años")
        TextoMeses = IIf(Meses_ = 1, "Mes", "Meses")
        TextoDias = IIf(dias_ = 1, "Día", "Dias")
        If Edad_Completa = False Then
            If Años_ > 0 Then
                Return Años_ & " " & TextoAños
            Else
                If Meses_ > 0 Then
                    Return Meses_ & " " & TextoMeses
                Else
                    If dias_ > 0 Then
                        Return dias_ & " " & TextoDias
                    End If
                End If
            End If
        Else
            Dim str_date As String = ""
            If Años_ > 0 Then
                str_date = Años_ & " " & TextoAños & " "
            End If
            If Meses_ > 0 Then
                str_date &= Meses_ & " " & TextoMeses & " "
            End If
            If dias_ > 0 Then
                str_date &= dias_ & " " & TextoDias
            End If
            Return str_date
        End If
    End Function
End Class
