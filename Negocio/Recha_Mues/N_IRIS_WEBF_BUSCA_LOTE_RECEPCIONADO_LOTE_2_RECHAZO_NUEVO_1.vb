'Importar Capas
Imports Datos
Imports Entidades

Public Class N_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1

    Sub New()
        DD_Data = New D_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1
    End Sub

    Function IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1(ByVal NUMLOTE As Integer, ByVal ID_RECHA As Integer) As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_TM")
        Dim ID_PROC As Integer

        Try
            ID_PROC = CInt(galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try
        Return DD_Data.IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1(NUMLOTE, ID_RECHA, ID_PROC)

    End Function

    'Function IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_3(ByVal NUMLOTE As Integer, ByVal ID_RECHA As Integer) As E_List_wDict_RECHAZO

    '    Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_TM")
    '    Dim ID_PROC As Integer

    '    Try
    '        ID_PROC = CInt(galleta.Value)
    '    Catch ex As Exception
    '        HttpContext.Current.Response.Redirect("~/index.aspx")
    '    End Try

    '    Dim List_In As New List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1)
    '    Dim List_Out As New E_List_wDict_RECHAZO

    '    List_In = DD_Data.IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1(NUMLOTE, ID_RECHA, ID_PROC)
    '    Dim Pairs As New Dictionary(Of String, Long)

    '    For Each etiq In List_In
    '        Dim strKey As String = "[" & etiq.RECEP_ETI_CURVA_RECHAZO & "]" & " - " & etiq.T_MUESTRA_DESC

    '        If (Pairs.Keys.Contains(strKey) = False) Then
    '            Pairs.Item(strKey) = 0
    '        End If
    '    Next

    '    'For Each etiq In List_In
    '    '    Dim strKey As String = "[" & etiq.CB_DESC & "]" & " - " & etiq.T_MUESTRA_DESC                  'PARA CONTAR TODOS LOS EXAMENES

    '    '    Pairs.Item(strKey) += 1
    '    'Next

    '    Dim cb_desc_comparador As String = ""
    '    Dim ate_num_comparador As String = ""
    '    Dim ate_muestra_comparador As String = ""

    '    For i = 0 To List_In.Count - 1
    '        Dim strKey As String = "[" & List_In(i).RECEP_ETI_CURVA_RECHAZO & "]" & " - " & List_In(i).T_MUESTRA_DESC
    '        If i = 0 Then

    '            Pairs.Item(strKey) += 1

    '            cb_desc_comparador = List_In(i).RECEP_ETI_CURVA_RECHAZO
    '            ate_num_comparador = List_In(i).ATE_NUM
    '            ate_muestra_comparador = List_In(i).T_MUESTRA_DESC
    '        ElseIf ((((i > 0) And (List_In(i).RECEP_ETI_CURVA_RECHAZO <> cb_desc_comparador))) Or List_In(i).ATE_NUM <> ate_num_comparador Or List_In(i).T_MUESTRA_DESC <> ate_muestra_comparador) Then
    '            Pairs.Item(strKey) += 1

    '            cb_desc_comparador = List_In(i).RECEP_ETI_CURVA_RECHAZO
    '            ate_num_comparador = List_In(i).ATE_NUM
    '            ate_muestra_comparador = List_In(i).T_MUESTRA_DESC
    '        End If
    '    Next i

    '    List_Out.List_Data = List_In
    '    List_Out.Dictionary = Pairs

    '    Return List_Out

    'End Function

    Function IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_3(ByVal NUMLOTE As Integer, ByVal ID_RECHA As Integer, ByVal LUGAR_TM As Integer) As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_TM")
        Dim ID_PROC As Integer

        Try
            ID_PROC = CInt(galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try
        Return DD_Data.IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_3(NUMLOTE, ID_RECHA, LUGAR_TM)

    End Function

    Function IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1_2(ByVal NUMLOTE As Integer, ByVal ID_RECHA As Integer, ByVal ID_PROCc As Integer) As List(Of E_IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1)
        Dim galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_ID_PROC")
        Dim ID_PROC As Integer

        Try
            ID_PROC = CInt(galleta.Value)
        Catch ex As Exception
            HttpContext.Current.Response.Redirect("~/index.aspx")
        End Try
        Return DD_Data.IRIS_WEBF_BUSCA_LOTE_RECEPCIONADO_LOTE_2_RECHAZO_NUEVO_1_2(NUMLOTE, ID_RECHA, ID_PROCc)

    End Function
    Public Class E_List_wDict_RECHAZO
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
End Class