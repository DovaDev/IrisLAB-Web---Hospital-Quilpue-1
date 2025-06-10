'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO
    End Sub

    Function IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PROC As Integer, ByVal ID_CF As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_LUGAR_TM_TODOS_POR_ID_TM_POR_DERIVADO(DESDE, HASTA, ID_PROC, ID_CF)

    End Function
    Function IRIS_WEBF_BUSCA_EST_LUGAR_TM_EXCEL(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PROC As String) As List(Of E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_LUGAR_TM_EXCEL(DESDE, HASTA, ID_PROC)

    End Function
    Function IRIS_WEBF_BUSCA_EST_LUGAR_TM_EXCEL_2(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PROC As String) As List(Of E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL)
        Return DD_Data.IRIS_WEBF_BUSCA_EST_LUGAR_TM_EXCEL_2(DESDE, HASTA, ID_PROC)

    End Function

    Function IRIS_WEBF_BUSCA_EST_LUGAR_TM_EXCEL_UPDATE(ByVal ID As String, ByVal CAMBIO As String, ByVal CASILLA As String) As Integer
        Return DD_Data.IRIS_WEBF_BUSCA_EST_LUGAR_TM_EXCEL_UPDATE(ID, CAMBIO, CASILLA)

    End Function

    Function IRIS_WEBF_ELIMINAR(ByVal ID As String) As Integer
        Return DD_Data.IRIS_WEBF_ELIMINAR(ID)

    End Function
    Function IRIS_WEBF_BUSCA_DATOS_RESIDUOS(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PROC As Integer) As E_List_wDict_2

        Dim List_In As New List(Of E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL)
        Dim List_Out As New E_List_wDict_2

        List_In = DD_Data.IRIS_WEBF_BUSCA_DATOS_RESIDUOS(DESDE, HASTA, ID_PROC)

        Dim Pairs As New Dictionary(Of String, Long)

        For Each etiq In List_In
            Dim strKey As String = etiq.PROC_DESC

            If (Pairs.Keys.Contains(strKey) = False) Then
                Pairs.Item(strKey) = 0
            End If
        Next

        'For Each etiq In List_In
        '    Dim strKey As String = "[" & etiq.CB_DESC & "]" & " - " & etiq.T_MUESTRA_DESC                  'PARA CONTAR TODOS LOS EXAMENES

        '    Pairs.Item(strKey) += 1
        'Next

        Dim PROC_DESC_COMPARADOR As String = ""

        For i = 0 To List_In.Count - 1
            Dim strKey As String = List_In(i).PROC_DESC
            'If i = 0 Then

            Pairs.Item(strKey) += 1

            PROC_DESC_COMPARADOR = List_In(i).PROC_DESC

            'ElseIf ((((i > 0) And (List_In(i).PROC_DESC <> PROC_DESC_COMPARADOR)))) Then
            '    Pairs.Item(strKey) += 1

            '    PROC_DESC_COMPARADOR = List_In(i).PROC_DESC
            'End If
        Next i

        List_Out.List_Data = List_In
        List_Out.Dictionary = Pairs

        Return List_Out

    End Function
    Function IRIS_WEBF_BUSCA_DATOS_RESIDUOS_2(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PROC As Integer) As E_List_wDict_2

        Dim List_In As New List(Of E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL)
        Dim List_Out As New E_List_wDict_2

        List_In = DD_Data.IRIS_WEBF_BUSCA_DATOS_RESIDUOS_2(DESDE, HASTA, ID_PROC)

        Dim Pairs As New Dictionary(Of String, Long)

        For Each etiq In List_In
            Dim strKey As String = etiq.PROC_DESC

            If (Pairs.Keys.Contains(strKey) = False) Then
                Pairs.Item(strKey) = 0
            End If
        Next

        'For Each etiq In List_In
        '    Dim strKey As String = "[" & etiq.CB_DESC & "]" & " - " & etiq.T_MUESTRA_DESC                  'PARA CONTAR TODOS LOS EXAMENES

        '    Pairs.Item(strKey) += 1
        'Next

        Dim PROC_DESC_COMPARADOR As String = ""

        For i = 0 To List_In.Count - 1
            Dim strKey As String = List_In(i).PROC_DESC
            'If i = 0 Then

            Pairs.Item(strKey) += 1

            PROC_DESC_COMPARADOR = List_In(i).PROC_DESC

            'ElseIf ((((i > 0) And (List_In(i).PROC_DESC <> PROC_DESC_COMPARADOR)))) Then
            '    Pairs.Item(strKey) += 1

            '    PROC_DESC_COMPARADOR = List_In(i).PROC_DESC
            'End If
        Next i

        List_Out.List_Data = List_In
        List_Out.Dictionary = Pairs

        Return List_Out

    End Function
    Function IRIS_WEBF_ELIMINAR_RESIDUO(ByVal ID As String) As Integer
        Return DD_Data.IRIS_WEBF_ELIMINAR_RESIDUO(ID)

    End Function
    Function IRIS_WEBF_BUSCA_SECC_TRAZA_RESIDUO() As List(Of E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL)
        Return DD_Data.IRIS_WEBF_BUSCA_SECC_TRAZA_RESIDUO()

    End Function
    Function IRIS_WEBF_UPDATE_RESIDUOS(ByVal ID As Integer, ByVal CAMBIO As String, ByVal CASILLA As String) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_RESIDUOS(ID, CAMBIO, CASILLA)

    End Function
    Function IRIS_WEBF_UPDATE_RESIDUOS_2(ByVal ID As Integer, ByVal CAMBIO As String, ByVal CASILLA As String) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_RESIDUOS_2(ID, CAMBIO, CASILLA)

    End Function

    Function IRIS_WEBF_BUSCA_EST_LUGAR_TM_EXCEL_CONTENEDOR_ENVIO(ByVal DESDE As Date, ByVal HASTA As Date, ByVal ID_PROC As String) As List(Of E_IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL)
        Return DD_Data.IRIS_WEBF_BUSCA_DATOSEXCEL_TP_REAL_CONTENEDOR_ENVIO(DESDE, HASTA, ID_PROC)

    End Function
End Class

Public Class E_List_wDict_2
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
