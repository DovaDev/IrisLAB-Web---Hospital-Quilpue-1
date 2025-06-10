Imports Entidades
Imports Negocio
Imports System.Web
Imports System.Web.Script.Serialization
Public Class Programa
    Inherits System.Web.UI.Page
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_PROGRAMA() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of e_IRIS_WEBF_BUSCA_PROGRAMA)
        Dim NN As N_IRIS_WEBF_BUSCA_BANCO = New N_IRIS_WEBF_BUSCA_BANCO
        data_paciente = NN.IRIS_WEBF_BUSCA_PROGRAMA()
        If (data_paciente.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_paciente, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    '<Services.WebMethod()>
    'Public Shared Function IRIS_WEBF_BUSCA_PREVISION_ACTIVO() As String
    '    'Declaraciones del Serializador
    '    Dim Serializer As New JavaScriptSerializer
    '    Dim str_Builder As New StringBuilder
    '    Dim datas As String = ""
    '    'Declaraciones internas
    '    Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
    '    Dim NN As N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO = New N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
    '    data_paciente = NN.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()
    '    If (data_paciente.Count > 0) Then
    '        'Serializar con JSON
    '        Serializer.MaxJsonLength = 999999999
    '        Serializer.Serialize(data_paciente, str_Builder)
    '        datas = str_Builder.ToString
    '    Else
    '        datas = "null"
    '    End If
    '    Return datas
    'End Function
    '<Services.WebMethod()>
    'Public Shared Function IRIS_WEBF_BUSCA_RELACION_PROGRA_PREVI(ByVal ID_PROGRA As Integer) As String
    '    'Declaraciones del Serializador
    '    Dim Serializer As New JavaScriptSerializer
    '    Dim str_Builder As New StringBuilder
    '    Dim datas As String = ""

    '    'Declaraciones internas
    '    Dim data_rel_preve_proce As List(Of E_IRIS_WEBF_BUSCA_RELACION_PROGRA_PREVI)
    '    Dim NN As N_IRIS_WEBF_BUSCA_RELACION_PROGRA_PREVI = New N_IRIS_WEBF_BUSCA_RELACION_PROGRA_PREVI

    '    data_rel_preve_proce = NN.IRIS_WEBF_BUSCA_RELACION_PROGRA_PREVI(ID_PROGRA)

    '    If (data_rel_preve_proce.Count > 0) Then
    '        'Serializar con JSON
    '        Serializer.MaxJsonLength = 999999999
    '        Serializer.Serialize(data_rel_preve_proce, str_Builder)
    '        datas = str_Builder.ToString
    '    Else
    '        datas = "null"
    '    End If
    '    Return datas
    'End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_UPDATE_BANCOS(ByVal ID_BAN As Integer,
                                                   ByVal BAN_COD As String,
                                                   ByVal BAN_DES As String,
                                                   ByVal ID_ESTADO As Integer 'ByVal LUGARES_TM() As Object
                                                   ) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim numerin_relacion As Integer = 0
        Dim numerin_relacion_graba As Integer = 0
        Dim NN As N_IRIS_WEBF_UPDATE_BANCOS = New N_IRIS_WEBF_UPDATE_BANCOS
        Dim NN_RELACION As N_IRIS_WEBF_UPDATE_RELACION_PROG_PREVE = New N_IRIS_WEBF_UPDATE_RELACION_PROG_PREVE
        Dim NN_RELACION_GRABA As New N_IRIS_WEBF_GRABA_RELACION_PROG_PREVE

        numerin = NN.IRIS_WEBF_UPDATE_PROGRAMA(ID_BAN, BAN_COD, BAN_DES, ID_ESTADO)




        'If LUGARES_TM.Length > 0 Then
        '    For i = 0 To LUGARES_TM.Length - 1
        '        Dim ID_PROCE As Integer = LUGARES_TM(i)
        '        If ID_PROCE <> 0 Then
        '            numerin_relacion = NN_RELACION.IRIS_WEBF_UPDATE_RELACION_PROG_PREVE(ID_BAN, CInt(LUGARES_TM(i)), ID_ESTADO)
        '            If numerin_relacion = 0 Then
        '                numerin_relacion = NN_RELACION_GRABA.IRIS_WEBF_GRABA_RELACION_PROG_PREVE(ID_BAN, CInt(LUGARES_TM(i)), 1)
        '            End If
        '        End If
        '    Next i
        'End If




        'Dim data_PREVE As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        'Dim NN_PREVE As N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO = New N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        'data_PREVE = NN_PREVE.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()

        'For i = 0 To data_PREVE.Count - 1
        '    If LUGARES_TM(i) = data_PREVE(i).ID_PREVE Then
        '        numerin_relacion = NN_RELACION.IRIS_WEBF_UPDATE_RELACION_PROG_PREVE(ID_BAN, CInt(LUGARES_TM(i)), ID_ESTADO)
        '    Else
        '        numerin_relacion = NN_RELACION.IRIS_WEBF_UPDATE_RELACION_PROG_PREVE(ID_BAN, data_PREVE(i).ID_PREVE, 2)
        '    End If
        'Next i





        If (numerin > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(numerin, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_GRABA_BANCO(ByVal BAN_COD As String,
                                                 ByVal BAN_DES As String,
                                                 ByVal ID_ESTADO As Integer 'ByVal LUGARES() As Object
                                                 ) As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim numerin As Integer = 0
        Dim numm As Integer = 0
        Dim NUMMMM As Integer
        Dim NN As N_IRIS_WEBF_GRABA_BANCO = New N_IRIS_WEBF_GRABA_BANCO
        numerin = NN.IRIS_WEBF_GRABA_PROGRAMA(BAN_COD, BAN_DES, ID_ESTADO)
        Dim NN_LugarTM As New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        Dim Data_LugarTM As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Data_LugarTM = NN_LugarTM.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()
        Dim numerin_relacion As Integer = 0

        For i = 0 To Data_LugarTM.Count - 1
            numm = NN.IRIS_WEBF_INSERT_RELACION(Data_LugarTM(i).ID_PROCEDENCIA, numerin, 1)
        Next i
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_PREVISION_ACTIVO)
        Dim NN2 As N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO = New N_IRIS_WEBF_BUSCA_PREVISION_ACTIVO
        data_paciente = NN2.IRIS_WEBF_BUSCA_PREVISION_ACTIVO()

        For x = 0 To data_paciente.Count - 1
            NUMMMM = NN.IRIS_WEBF_INSERT_RELACION_ub_preve_blablabla(data_paciente(x).ID_PREVE, numerin, 1, 1)
        Next x


        'Dim NN_RELACION As New N_IRIS_WEBF_GRABA_RELACION_PROG_PREVE
        'If LUGARES.Length > 0 Then
        '    For i = 0 To LUGARES.Length - 1
        '        numerin_relacion = NN_RELACION.IRIS_WEBF_GRABA_RELACION_PROG_PREVE(numerin, CInt(LUGARES(i)), 1)
        '    Next i
        'End If

        If (numerin > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(numerin, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    '<Services.WebMethod()>
    'Public Shared Function DELETE_PRE(ByVal ID_BAN As Integer,
    '                                                  ByVal BAN_COD As String,
    '                                                  ByVal BAN_DES As String,
    '                                                  ByVal ID_ESTADO As Integer) As String
    '    'Declaraciones del Serializador
    '    Dim Serializer As New JavaScriptSerializer
    '    Dim str_Builder As New StringBuilder
    '    Dim datas As String = ""

    '    'Declaraciones internas
    '    Dim numerin As Integer = 0
    '    Dim numerin_relacion As Integer = 0
    '    Dim numerin_relacion_graba As Integer = 0

    '    Dim NN As N_IRIS_WEBF_UPDATE_BANCOS = New N_IRIS_WEBF_UPDATE_BANCOS
    '    Dim NN_RELACION As N_IRIS_WEBF_UPDATE_RELACION_PROG_PREVE = New N_IRIS_WEBF_UPDATE_RELACION_PROG_PREVE

    '    Dim NN_RELACION_GRABA As New N_IRIS_WEBF_GRABA_RELACION_PRE_PROCE

    '    Dim data_rel_preve_proce As List(Of E_IRIS_WEBF_BUSCA_RELACION_PREVI_PROCE)
    '    Dim NN_BUSCA_RELACION As N_IRIS_WEBF_BUSCA_RELACION_PREVI_PROCE = New N_IRIS_WEBF_BUSCA_RELACION_PREVI_PROCE

    '    data_rel_preve_proce = NN_BUSCA_RELACION.IRIS_WEBF_BUSCA_RELACION_PREVI_PROCE(ID_BAN)

    '    Dim PREVE_ARH As Integer = 1
    '    Dim PREVE_FACTORH = 0
    '    Dim PREVE_ARHA As Integer = 1
    '    Dim PREVE_FACTORHA As Integer = 0
    '    Dim PREVE_HOST = 0

    '    numerin = NN.IRIS_WEBF_UPDATE_PROGRAMA(ID_BAN, BAN_COD, BAN_DES, ID_ESTADO)

    '    If (numerin > 0) Then
    '        Serializer.MaxJsonLength = 999999999
    '        Serializer.Serialize(numerin, str_Builder)
    '        datas = str_Builder.ToString
    '    Else
    '        datas = "null"
    '    End If
    '    Return datas
    'End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR() As String
        'Declaraciones del Serializador
        Dim Serializer As New JavaScriptSerializer
        Dim str_Builder As New StringBuilder
        Dim datas As String = ""
        'Declaraciones internas
        Dim data_paciente As List(Of E_IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR)
        Dim NN As N_IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR = New N_IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR
        data_paciente = NN.IRIS_WEBF_BUSCA_ESTADO_MANTENEDOR()
        If (data_paciente.Count > 0) Then
            'Serializar con JSON
            Serializer.MaxJsonLength = 999999999
            Serializer.Serialize(data_paciente, str_Builder)
            datas = str_Builder.ToString
        Else
            datas = "null"
        End If
        Return datas
    End Function
    <Services.WebMethod()>
    Public Shared Function Excel(ByVal DOMAIN_URL As String) As String
        Dim NN_Excel As New N_Excel
        Dim data_paciente As List(Of e_IRIS_WEBF_BUSCA_PROGRAMA)
        Dim NN As N_IRIS_WEBF_BUSCA_BANCO = New N_IRIS_WEBF_BUSCA_BANCO
        data_paciente = NN.IRIS_WEBF_BUSCA_PROGRAMA()
        Dim titulo As String = "PROGRAMAS"
        Dim Mx(3, 0) As Object
        For y = 0 To (data_paciente.Count - 1)
            If (y > 0) Then
                ReDim Preserve Mx(3, y)
            End If
            Mx(0, y) = data_paciente(y).ID_PROGRA
            Mx(1, y) = data_paciente(y).PROGRA_COD
            Mx(2, y) = data_paciente(y).PROGRA_DESC
            Mx(3, y) = data_paciente(y).ID_ESTADO
        Next y
        Return NN_Excel.Excel(DOMAIN_URL, Mx, titulo)
    End Function

    Private Sub Init_Redirect(sender As Object, e As EventArgs) Handles Me.Load
        Dim objSession As HttpSessionState = HttpContext.Current.Session
        Dim C_P_ADMIN As HttpCookie = Request.Cookies.Get("P_ADMIN")

        If (IsNothing(C_P_ADMIN) = True) Then
            Response.Redirect("~/Index.aspx")
        End If

        Select Case (C_P_ADMIN.Value)
            Case Is <> 1
                Response.Redirect("~/Index.aspx")
        End Select
    End Sub
End Class