Imports Datos
Imports Entidades
Public Class N_Gen_Activos
    Dim DD_Activos As D_Gen_Activos
    Sub New()
        DD_Activos = New D_Gen_Activos
    End Sub

    Function IRIS_WEBF_CMVM_BUSCA_ID_ATE_BY_ATE_NUM(ByVal ATE_NUM As String) As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Return DD_Activos.IRIS_WEBF_CMVM_BUSCA_ID_ATE_BY_ATE_NUM(ATE_NUM)
    End Function

    Function IRIS_WEBF_CMVM_BUSCA_ID_PER_BY_ID_CF(ByVal ID_CF As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Return DD_Activos.IRIS_WEBF_CMVM_BUSCA_ID_PER_BY_ID_CF(ID_CF)
    End Function
    Function IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS2(ID_ATE As Integer, ID_RLS_LS As Integer) As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Return DD_Activos.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS2(ID_ATE, ID_RLS_LS)
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_PREVISION_ACTIVO_AND_PART_WEB() As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Return DD_Activos.IRIS_WEBF_CMVM_BUSCA_PREVISION_ACTIVO_AND_PART_WEB()
    End Function
    Function IRIS_WEBF_CMVM_BUSCA_TIPO_DE_PAGO_INGRESO_ATE_SIN_EFECTIVO() As List(Of E_IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE)
        Return DD_Activos.IRIS_WEBF_CMVM_BUSCA_TIPO_DE_PAGO_INGRESO_ATE_SIN_EFECTIVO()
    End Function
    Function IRIS_WEBF_BUSCA_PREVISION_ACTIVO() As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Return DD_Activos.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()
    End Function
    ''' <summary>
    ''' Obtiene todas las procedencias a las que tiene acceso un usuario.
    ''' </summary>
    ''' <param name="ID_PREV">[opcional] ID_PREV a la cual pertenecen las Procedencias.</param>
    ''' <returns></returns>
    Function IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO_BY_ID_PREV(Optional ByVal ID_PREV As Integer = 0) As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Dim Galleta As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")

        If (IsNothing(Galleta) = True) Then
            HttpContext.Current.Response.Redirect("~/Account/Login.aspx")
        End If

        Return DD_Activos.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO_BY_ID_PREV(ID_PREV, CInt(Galleta.Value))
    End Function

    Function IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO_BY_ID_PREV(ByVal ID_PREV As Long) As List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)
        Return DD_Activos.IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO_BY_ID_PREV(ID_PREV)
    End Function


    ''' <summary>
    ''' Obtiene todas las Previsiones a las que tiene acceso un usuario.
    ''' </summary>
    ''' <param name="ID_PROC">[opcional] ID_PROC a la cual pertenecen las Previsiones</param>
    ''' <returns></returns>
    Function IRIS_WEBF_BUSCA_PREVISION_ACTIVO_BY_ID_PROC(ByVal ID_PROC As Long) As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Dim Galleta As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")

        If (IsNothing(Galleta) = True) Then
            HttpContext.Current.Response.Redirect("~/Account/Login.aspx")
        End If

        Return DD_Activos.IRIS_WEBF_BUSCA_PREVISION_ACTIVO_BY_ID_PROC(ID_PROC, CInt(Galleta.Value))
    End Function
    Function IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO() As List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Dim listIn As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Dim listOut As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Dim Galleta As HttpCookie = HttpContext.Current.Request.Cookies("USU_ID_PROC")

        listIn = DD_Activos.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()
        If (IsNothing(Galleta) = True) Then
            HttpContext.Current.Response.Redirect("~index.aspx")
        End If

        If (CInt(Galleta.Value) <> 0) Then
            For i = 0 To (listIn.Count - 1)
                Dim intProc As Integer = CInt(Galleta.Value)

                If (listIn(i).ID_PROCEDENCIA = intProc) Then
                    listOut.Add(listIn(i))
                    Exit For
                End If
            Next i
        Else
            Dim xItem As New E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
            xItem.ID_ESTADO = 1
            xItem.ID_PROCEDENCIA = 0
            xItem.PROC_DESC = "TODOS"

            listOut.Add(xItem)
            listOut.AddRange(listIn)
        End If

        Return listOut
    End Function
    Function IRIS_WEBF_BUSCA_MEDICOS_ACTIVO() As List(Of E_IRIS_WEBF_BUSCA_MEDICOS_ACTIVO)
        Return DD_Activos.IRIS_WEBF_BUSCA_MEDICOS_ACTIVO
    End Function
    Function IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO() As List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO)
        Return DD_Activos.IRIS_WEBF_BUSCA_PROGRAMA_ACTIVO
    End Function
    Function IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS() As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Return DD_Activos.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS()
    End Function
    Function IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS_ASOCIADO_PREVISION() As List(Of E_IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS)
        Return DD_Activos.IRIS_WEBF_BUSCA_EST_CODIGO_FONASA_ACTIVOS_ASOCIADO_PREVISION()
    End Function
    Function IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO() As List(Of E_IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO)
        Return DD_Activos.IRIS_WEBF_BUSCA_ORDEN_ATENCION_ACTIVO()
    End Function
    Function IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE() As List(Of E_IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE)
        Return DD_Activos.IRIS_WEBF_BUSCA_TIPO_DE_PAGO_INGRESO_ATE()
    End Function
    Function IRIS_WEBF_BUSCA_PREVE_PROG_SUBPROG(ByVal ID_PREV As Integer, ByVal ID_PROG As Integer) As List(Of E_IRIS_WEBF_BUSCA_PREVE_PROG_SUBPROG)
        Return DD_Activos.IRIS_WEBF_BUSCA_PREVE_PROG_SUBPROG(ID_PREV, ID_PROG)
    End Function
    Function IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO(ByVal ID_PR As Long) As List(Of E_IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO)
        Return DD_Activos.IRIS_WEBF_BUSCA_PROGRAMA_POR_PREVISION_NUEVO(ID_PR)
    End Function
    Function IRIS_WEBF_BUSCA_AÑO_ACTIVO() As List(Of E_IRIS_WEBF_BUSCA_AÑO_ACTIVO)
        Return DD_Activos.IRIS_WEBF_BUSCA_AÑO_ACTIVO()
    End Function
    Function IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO() As List(Of E_IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO)
        Return DD_Activos.IRIS_WEBF_BUSCA_TP_ATENCION_ACTIVO()
    End Function
    Function IRIS_WEBF_BUSCA_EST_TECNOLGOS_ACTIVOS() As List(Of E_IRIS_WEBF_BUSCA_EST_TECNOLGOS_ACTIVOS)
        Return DD_Activos.IRIS_WEBF_BUSCA_EST_TECNOLGOS_ACTIVOS()
    End Function
    Function IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO() As List(Of E_IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO)
        Return DD_Activos.IRIS_WEBF_BUSCA_RELACION_AREA_SECCION_ESTADO()
    End Function
    'Function IRIS_WEBF_BUSCA_PREVISION_ACTIVO_BY_ID_PROC(ByVal ID_PROC As Long) As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
    '    Dim List_Out As New List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
    '    List_Out = DD_Activos.IRIS_WEBF_BUSCA_PREVISION_ACTIVO_BY_ID_PROC(ID_PROC)

    '    Return List_Out
    'End Function
    Function IRIS_WEBF_BUSCA_AREA_TRABAJO_ACTIVA() As List(Of E_IRIS_WEBF_BUSCA_AREA_TRABAJO_ACTIVA)
        Return DD_Activos.IRIS_WEBF_BUSCA_AREA_TRABAJO_ACTIVA()
    End Function
    Function IRIS_WEBF_BUSCA_SECCIONES_ACTIVO() As List(Of E_IRIS_WEBF_BUSCA_SECCIONES_ACTIVO)
        Return DD_Activos.IRIS_WEBF_BUSCA_SECCIONES_ACTIVO()
    End Function
    Function IRIS_WEBF_BUSCA_USUARIO2() As List(Of E_IRIS_WEBF_BUSCA_USUARIO2)
        Return DD_Activos.IRIS_WEBF_BUSCA_USUARIO2()
    End Function
    Public Function Request_SubPrograma(ByVal ID_PREV As Integer, ByVal ID_PROG As Integer) As List(Of E_Async_SubP)
        Return DD_Activos.Request_SubPrograma(ID_PREV, ID_PROG)
    End Function
    Function Request_Ciudad_By_ID_USER() As List(Of E_IRIS_WEBF_CMVM_BUSCA_CIUDAD_BY_ID_USER)
        Dim Galleta As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")
        Dim ID_USER As Integer

        If (IsNothing(Galleta) = True) Then
            HttpContext.Current.Response.Redirect("~index.aspx")
        Else
            ID_USER = CInt(Galleta.Value)
        End If

        Return DD_Activos.Request_Ciudad_By_ID_USER(ID_USER)
    End Function

    Function Request_Comuna(ID_CIUD) As List(Of E_IRIS_WEBF_CMVM_BUSCA_COMUNA_BY_ID_USER)
        Dim Galleta As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")
        Dim ID_USER As Integer

        If (IsNothing(Galleta) = True) Then
            HttpContext.Current.Response.Redirect("~index.aspx")
        Else
            ID_USER = CInt(Galleta.Value)
        End If

        Return DD_Activos.Data_Sel_Comuna(ID_CIUD)
    End Function

    Function Request_Comuna_By_ID_USER() As List(Of E_IRIS_WEBF_CMVM_BUSCA_COMUNA_BY_ID_USER)
        Dim Galleta As HttpCookie = HttpContext.Current.Request.Cookies("ID_USER")
        Dim ID_USER As Integer

        If (IsNothing(Galleta) = True) Then
            HttpContext.Current.Response.Redirect("~index.aspx")
        Else
            ID_USER = CInt(Galleta.Value)
        End If

        Return DD_Activos.Request_Comuna_By_ID_USER(ID_USER)
    End Function

End Class

