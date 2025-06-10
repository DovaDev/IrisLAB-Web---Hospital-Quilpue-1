
'Importar Capas
Imports Entidades
'Importar Funciones
Imports System.Web
Imports System.Data.OleDb
Imports System.Globalization
Imports System.Data.SqlClient
Imports Datos

Public Class N_PROCEDENCIAS_Y_CANT_MAX
    'Declaraciones Generales
    Dim DD_Data As D_PROCEDENCIAS_Y_CANT_MAX
    Sub New()
        DD_Data = New D_PROCEDENCIAS_Y_CANT_MAX
    End Sub
    Function IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX(ByVal FECHA As String, Optional ByVal idsssss As String = "") As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX)
        Dim List_IN As New List(Of E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX)
        Dim examens As New List(Of E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX)
        List_IN = DD_Data.IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX()
        For y = 0 To List_IN.Count - 1
            Dim Elem_Alt As List(Of E_TOTALES_DE_PROCEDENCIA_ATENCIONES) 'total_ate
            If (idsssss = "") Then
                Elem_Alt = IRIS_WEBF_BUSCA_CANT_PREINGRESO_FECHA_ACTUAL_2_NEW(List_IN(y).ID_PROCEDENCIA, FECHA)
                examens = DD_Data.examens2(List_IN(y).ID_PROCEDENCIA, Format(CDate(FECHA), "dd/MM/yyyy"))
            Else
                Elem_Alt = IRIS_WEBF_BUSCA_CANT_PREINGRESO_FECHA_ACTUAL_2_NEW(idsssss, Format(CDate(FECHA), "dd/MM/yyyy"))
                examens = DD_Data.examens2(idsssss, Format(CDate(FECHA), "dd/MM/yyyy"))
            End If

            If (Elem_Alt.Count > 0) Then

                List_IN(y).TOTAL_AGEND_CUPO_NORMAL = Elem_Alt(0).TOTAL_AGEND_CUPO_NORMAL
                List_IN(y).TOTAL_AGEND_PRIORITARIO = Elem_Alt(0).TOTAL_AGEND_PRIORITARIO
                List_IN(y).TOTAL_AGEND_ESPONTANEO = Elem_Alt(0).TOTAL_AGEND_ESPONTANEO
            Else
                List_IN(y).TOTAL_AGEND_CUPO_NORMAL = 0
                List_IN(y).TOTAL_AGEND_PRIORITARIO = 0
                List_IN(y).TOTAL_AGEND_ESPONTANEO = 0
            End If


            If (examens.Count > 0) Then
                List_IN(y).PROC_CANT_EXA_BUSCA_DIAS = examens(0).PROC_CANT_EXA_BUSCA_DIAS
                List_IN(y).CONF_DIAS_EXA_BUSCA_DIAS = examens(0).CONF_DIAS_EXA_BUSCA_DIAS
                List_IN(y).CONF_DIAS_EXA_BUSCA_DIAS = examens(0).CONF_DIAS_EXA_BUSCA_DIAS
                List_IN(y).ID_ESTADO_BUSCA_DIAS = examens(0).ID_ESTADO_BUSCA_DIAS
                List_IN(y).ID_PROCEDENCIA_BUSCA_DIAS = examens(0).ID_PROCEDENCIA_BUSCA_DIAS
                List_IN(y).ID_CONF_DIAS_BUSCA_DIAS = examens(0).ID_CONF_DIAS_BUSCA_DIAS

                List_IN(y).AGEND_CUPO_NORMAL = examens(0).AGEND_CUPO_NORMAL
                List_IN(y).AGEND_PRIORITARIO = examens(0).AGEND_PRIORITARIO
                List_IN(y).AGEND_ESPONTANEO = examens(0).AGEND_ESPONTANEO
            End If
        Next y
        Return List_IN
    End Function
    Function examens(ByVal ID_PRE As String, ByVal FECHA As String) As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX)
        Return DD_Data.examens(ID_PRE, FECHA)
    End Function
    Function examens2(ByVal ID_PRE As String, ByVal FECHA As String) As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX)
        Return DD_Data.examens2(ID_PRE, FECHA)
    End Function
    Function IRIS_WEBF_BUSCA_CANT_PREINGRESO_FECHA_ACTUAL_2(ByVal ID_PRE As String, ByVal FECHA As String) As Integer
        Return DD_Data.IRIS_WEBF_BUSCA_CANT_PREINGRESO_FECHA_ACTUAL_2(ID_PRE, FECHA)
    End Function
    Function IRIS_WEBF_BUSCA_CANT_PREINGRESO_FECHA_ACTUAL_2_NEW(ByVal ID_PRE As String, ByVal FECHA As String) As List(Of E_TOTALES_DE_PROCEDENCIA_ATENCIONES)
        Return DD_Data.IRIS_WEBF_BUSCA_CANT_PREINGRESO_FECHA_ACTUAL_2_NEW(ID_PRE, FECHA)
    End Function
    Function IRIS_WEBF_BUSCA_CANT_PREINGRESO_FECHA_ACTUAL_2_NEW_estadistica(ByVal ID_PRE As String, ByVal FECHA As String, ByVal FECHA2 As String) As List(Of E_TOTALES_DE_PROCEDENCIA_ATENCIONES)
        Return DD_Data.IRIS_WEBF_BUSCA_CANT_PREINGRESO_FECHA_ACTUAL_2_NEW_estadistica(ID_PRE, FECHA, FECHA2)
    End Function
    Function IRIS_WEBF_BUSCA_CANT_PREINGRESO_FECHA_ACTUAL_DETALLADO(ByVal ID_PRE As String, ByVal FECHA As String, ByVal FECHA2 As String) As List(Of E_TOTALES_DE_PROCEDENCIA_ATENCIONES_DETALLE)
        Return DD_Data.IRIS_WEBF_BUSCA_CANT_PREINGRESO_FECHA_ACTUAL_DETALLADO(ID_PRE, FECHA, FECHA2)
    End Function
    Function IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA(ByVal ID_PRE As String, ByVal FECHA As String) As List(Of E_IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA)
        Return DD_Data.IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA(ID_PRE, FECHA)
    End Function
    Function IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2(ByVal ID_PRE As String, ByVal FECHA As String) As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        Dim List_IN As New List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        List_IN = DD_Data.IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2(ID_PRE, FECHA)

        For Y = 0 To List_IN.Count - 1
            If (List_IN(Y).ID_ATENCION = 0) Then
                Dim Elem_Alt As Integer = 0
                Elem_Alt = DD_Data.IRIS_WEBF_BUSCA_CANT_EXA(List_IN(Y).ID_PREINGRESO)
                List_IN(Y).CANT_EXAM = Elem_Alt
            Else
                Dim Elem_Alt As Integer = 0
                Elem_Alt = DD_Data.IRIS_WEBF_BUSCA_CANT_EXA_ATE(List_IN(Y).ID_ATENCION)
                List_IN(Y).CANT_EXAM = Elem_Alt
            End If
        Next Y



        Return List_IN
    End Function
    Function IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2_SOLO_ATENCION(ByVal ID_PRE As String, ByVal FECHA As String) As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        Dim List_IN As New List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        List_IN = DD_Data.IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2_SOLO_ATENCION(ID_PRE, FECHA)

        For Y = 0 To List_IN.Count - 1
            If (List_IN(Y).ID_ATENCION = 0) Then
                Dim Elem_Alt As Integer = 0
                Elem_Alt = DD_Data.IRIS_WEBF_BUSCA_CANT_EXA(List_IN(Y).ID_PREINGRESO)
                List_IN(Y).CANT_EXAM = Elem_Alt
            Else
                Dim Elem_Alt As Integer = 0
                Elem_Alt = DD_Data.IRIS_WEBF_BUSCA_CANT_EXA_ATE(List_IN(Y).ID_ATENCION)
                List_IN(Y).CANT_EXAM = Elem_Alt
            End If
        Next Y



        Return List_IN
    End Function
    Function IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2_SOLO_ATENCION2(ByVal ID_PRE As String, ByVal FECHA As String, ByVal FECHA2 As String) As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        Dim List_IN As New List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        List_IN = DD_Data.IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2_SOLO_ATENCION2(ID_PRE, FECHA, FECHA2)

        For Y = 0 To List_IN.Count - 1
            If (List_IN(Y).ID_ATENCION = 0) Then
                Dim Elem_Alt As Integer = 0
                Elem_Alt = DD_Data.IRIS_WEBF_BUSCA_CANT_EXA(List_IN(Y).ID_PREINGRESO)
                List_IN(Y).CANT_EXAM = Elem_Alt
            Else
                Dim Elem_Alt As Integer = 0
                Elem_Alt = DD_Data.IRIS_WEBF_BUSCA_CANT_EXA_ATE(List_IN(Y).ID_ATENCION)
                List_IN(Y).CANT_EXAM = Elem_Alt
            End If
        Next Y



        Return List_IN
    End Function
    Function IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2_ATE_DIRECTO(ByVal ID_PRE As String, ByVal FECHA As Date) As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2_ATE_DIRECTO)
        Return DD_Data.IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2_ATE_DIRECTO(ID_PRE, FECHA)
    End Function

    Function IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX_EStadi(ByVal FECHA As String, ByVal FECHA2 As String, Optional ByVal idsssss As String = "") As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX)
        Dim List_IN As New List(Of E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX)
        Dim examens As New List(Of E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX)
        Dim NN_LugarTM As New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        Dim Data_LugarTM As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Data_LugarTM = NN_LugarTM.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()

        'List_IN = DD_Data.IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX()

        If (idsssss <> 0) Then
            Dim Elem_Alt As List(Of E_TOTALES_DE_PROCEDENCIA_ATENCIONES) 'total_ate
            Elem_Alt = IRIS_WEBF_BUSCA_CANT_PREINGRESO_FECHA_ACTUAL_2_NEW_estadistica(idsssss, Format(CDate(FECHA), "dd/MM/yyyy"), Format(CDate(FECHA2), "dd/MM/yyyy"))
            If (Elem_Alt.Count <> 0) Then

                Dim item As New E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX

                item.TOTAL_AGEND_CUPO_NORMAL = Elem_Alt(0).TOTAL_AGEND_CUPO_NORMAL
                item.TOTAL_AGEND_PRIORITARIO = Elem_Alt(0).TOTAL_AGEND_PRIORITARIO
                item.TOTAL_AGEND_ESPONTANEO = Elem_Alt(0).TOTAL_AGEND_ESPONTANEO
                item.TOTAL_AGEND_PAP = Elem_Alt(0).TOTAL_AGEND_PAP
                item.TOTAL_SOBRE_CUPO = Elem_Alt(0).TOTAL_SOBRE_CUPO
                List_IN.Add(item)
            Else
                Dim item As New E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX

                item.TOTAL_AGEND_CUPO_NORMAL = 0
                item.TOTAL_AGEND_PRIORITARIO = 0
                item.TOTAL_AGEND_ESPONTANEO = 0
                item.TOTAL_AGEND_PAP = 0
                item.TOTAL_SOBRE_CUPO = 0

                List_IN.Add(item)
            End If
            For c = 0 To Data_LugarTM.Count - 1
                If (Data_LugarTM(c).ID_PROCEDENCIA = idsssss) Then
                    List_IN(0).PROC_DESC = Data_LugarTM(c).PROC_DESC
                End If
            Next c
        Else
            Dim cccc As Integer = 0
            For xx = 0 To Data_LugarTM.Count - 1
                Dim Elem_Alt As List(Of E_TOTALES_DE_PROCEDENCIA_ATENCIONES) 'total_ate
                Elem_Alt = IRIS_WEBF_BUSCA_CANT_PREINGRESO_FECHA_ACTUAL_2_NEW_estadistica(Data_LugarTM(xx).ID_PROCEDENCIA, Format(CDate(FECHA), "dd/MM/yyyy"), Format(CDate(FECHA2), "dd/MM/yyyy"))
                If (Elem_Alt.Count <> 0) Then

                    Dim item As New E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX

                    item.TOTAL_AGEND_CUPO_NORMAL = Elem_Alt(0).TOTAL_AGEND_CUPO_NORMAL
                    item.TOTAL_AGEND_PRIORITARIO = Elem_Alt(0).TOTAL_AGEND_PRIORITARIO
                    item.TOTAL_AGEND_ESPONTANEO = Elem_Alt(0).TOTAL_AGEND_ESPONTANEO
                    item.TOTAL_AGEND_PAP = Elem_Alt(0).TOTAL_AGEND_PAP
                    item.TOTAL_SOBRE_CUPO = Elem_Alt(0).TOTAL_SOBRE_CUPO


                    List_IN.Add(item)
                Else
                    Dim item As New E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX

                    item.TOTAL_AGEND_CUPO_NORMAL = 0
                    item.TOTAL_AGEND_PRIORITARIO = 0
                    item.TOTAL_AGEND_ESPONTANEO = 0
                    item.TOTAL_AGEND_PAP = 0
                    item.TOTAL_SOBRE_CUPO = 0

                    List_IN.Add(item)
                End If

                List_IN(cccc).PROC_DESC = Data_LugarTM(xx).PROC_DESC


                cccc = cccc + 1

            Next xx
        End If
        Return List_IN
    End Function

    Function IRIS_WEBF_BUSCA_LIS_PAC_TDM(ID_PROCEDENCIA As Integer, ID_PREVISION As Integer, DESDE As String, HASTA As String) As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        Return DD_Data.IRIS_WEBF_BUSCA_LIS_PAC_TDM(ID_PROCEDENCIA, ID_PREVISION, DESDE, HASTA)
    End Function
    Function IRIS_WEBF_BUSCA_LIS_PAC_TDM_TRAER_POR_ESTADO(ID_PROCEDENCIA As Integer, ID_PREVISION As Integer, DESDE As String, HASTA As String, ESTADO As Integer) As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        Return DD_Data.IRIS_WEBF_BUSCA_LIS_PAC_TDM_TRAER_POR_ESTADO(ID_PROCEDENCIA, ID_PREVISION, DESDE, HASTA, ESTADO)
    End Function

    Function IRIS_WEBF_BUSCA_LIS_PAC_TDM_CON_EXAMENES(ID_PROCEDENCIA As Integer, ID_PREVISION As Integer, DESDE As String, HASTA As String) As List(Of E_IRIS_WEBF_AGENDA_BUSCA_PACIENTES_AGENDADOS_POR_FECHA2)
        Return DD_Data.IRIS_WEBF_BUSCA_LIS_PAC_TDM_CON_EXAMENES(ID_PROCEDENCIA, ID_PREVISION, DESDE, HASTA)
    End Function

    Shared Function IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA_NEW_COMNE_PTGO_disponible(FECHA As String, ID_BLOQUE As Integer, id_proced As Integer) As E_IRIS_WEBF_AGENDA_BUSCA_PROCEDENCIAS_Y_CANT_MAX
        Return D_PROCEDENCIAS_Y_CANT_MAX.IRIS_WEBF_BUSCA_DIAS_CONF_ATENCIONES_PROCEDENCIA_NEW_COMNE_PTGO_disponible(id_proced, Format(CDate(FECHA), "dd/MM/yyyy"), ID_BLOQUE)
    End Function
    Shared Function IRIS_WEBF_UPDATE_HORA_AGENDAMIENTO(idAgendamiento As Integer, FECHA As String, ID_BLOQUE As Integer, id_proced As Integer, SUB_GRUPO_ATE As Integer) As Integer
        Return D_PROCEDENCIAS_Y_CANT_MAX.IRIS_WEBF_UPDATE_HORA_AGENDAMIENTO(idAgendamiento, id_proced, Format(CDate(FECHA), "dd/MM/yyyy"), ID_BLOQUE, SUB_GRUPO_ATE)
    End Function

End Class
