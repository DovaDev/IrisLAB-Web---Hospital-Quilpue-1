'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2
    End Sub

    Function IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2(ByVal ID_USU As Integer) As E_List_wDict3
        'Return DD_Data.IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2(ID_USU)

        Dim List_In As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2)
        Dim List_Out As New E_List_wDict3

        List_In = DD_Data.IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2(ID_USU)
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

    Function IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2_CON_PENDIENTES_666(ByVal ID_USU As Integer) As List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2)
        'Return DD_Data.IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2(ID_USU)

        Dim List_In As New List(Of E_IRIS_WEBF_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2)
        List_In = DD_Data.IRIS_WEBF_CMVM_BUSCA_ETIQUETAS_RECEP_USUARIOS4____4_ENVIO2_CON_PENDIENTES_666(ID_USU)
        Return List_In
    End Function
End Class

Public Class E_List_wDict3
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