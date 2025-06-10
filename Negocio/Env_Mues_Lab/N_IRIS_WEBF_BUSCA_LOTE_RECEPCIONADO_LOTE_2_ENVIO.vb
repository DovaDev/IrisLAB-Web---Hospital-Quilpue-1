'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO
    End Sub

    Function IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO(ByVal NUMLOTE As Integer) As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)
        Return DD_Data.IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO(NUMLOTE)

    End Function

    Function IRIS_WEBF_UPDATE_LOTE_RECEPCION_ENVIO_RECEP(ByVal NUMLOTE As Integer, ByVal ID_USER As Integer) As Integer
        Return DD_Data.IRIS_WEBF_UPDATE_LOTE_RECEPCION_ENVIO_RECEP(NUMLOTE, ID_USER)

    End Function

    Function IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO(ByVal NUMLOTE As Integer) As E_List_wDict2
        Dim List_In As New List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)
        Dim List_Out As New E_List_wDict2

        List_In = DD_Data.IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO(NUMLOTE)
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


    Function IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO_2(ByVal NUMLOTE As Integer) As E_List_wDict2
        Dim List_In As New List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)
        Dim List_Out As New E_List_wDict2

        List_In = DD_Data.IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO_2(NUMLOTE)
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
    Function IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO_3(ByVal NUMLOTE As Integer) As E_List_wDict2
        Dim List_In As New List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)
        Dim List_Out As New E_List_wDict2

        List_In = DD_Data.IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO_3(NUMLOTE)
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

    Function IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO_3_INFO(ByVal DESDE As Date, ByVal HASTA As Date, ByVal LUGARTM As Integer) As E_List_wDict2
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO)
        Dim NN As N_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO = New N_IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO

        Dim List_In As New List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)
        Dim List_Out As New E_List_wDict2

        data_paciente = NN.IRIS_WEBF_BUSCA_CANTIDAD_LOTE_RECEPCIONADO_ENVIO_POR_FECHA_TOTAL_DE_LOTES(DESDE, HASTA, LUGARTM)

        If data_paciente.Count > 0 Then
            For ii = 0 To data_paciente.Count - 1
                List_In = DD_Data.IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO_3_MENOS_INFO(data_paciente(ii).ENVIO_NUM)

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





            Next ii
        End If


    End Function

    Function IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO_3_INFO_2(ByVal ENVIO_NUM As Integer) As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)
        Dim NN As D_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO = New D_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO

        'Dim data_final As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO)

        Dim e_element = New E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO

        data_paciente = NN.IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO_LISTA_TUBO_3_MENOS_INFO_2(ENVIO_NUM)

        If data_paciente.Count > 0 Then


            'For Each item In data_paciente
            '    e_element = New E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_ENVIO

            '    e_element.ENVIO_FECHA = item.ENVIO_FECHA
            '    e_element.CB_DESC = item.CB_DESC
            '    e_element.T_MUESTRA_DESC = item.T_MUESTRA_DESC
            '    e_element.CANTIDAD_TUBO = item.CANTIDAD_TUBO
            'Next

            'data_final.Add(e_element)


        End If

        Return data_paciente

    End Function
End Class

Public Class E_List_wDict2
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