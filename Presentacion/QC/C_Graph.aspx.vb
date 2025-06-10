Imports Entidades
Imports Negocio
Public Class C_Graph
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()>
    Public Shared Function IRIS_QC_GRABA_UPDATE_FIJA_VARIABLES(ByVal ID_ANA As Long,
                                                               ByVal ID_LOTE As Long,
                                                               ByVal ID_DET As Long,
                                                               ByVal V_LI As String,
                                                               ByVal V_LS As String,
                                                               ByVal V_ME As String,
                                                               ByVal V_DE As String,
                                                               ByVal V_CV As String,
                                                               ByVal V_N As String,
                                                               ByVal F_LI As String,
                                                               ByVal F_LS As String,
                                                               ByVal F_ME As String,
                                                               ByVal F_DE As String,
                                                               ByVal F_CV As String,
                                                               ByVal F_N As String) As Integer

        Dim dats As Integer

        Dim NN As N_IRIS_QC_GRABA_UPDATE_FIJA_VARIABLES = New N_IRIS_QC_GRABA_UPDATE_FIJA_VARIABLES


        dats += NN.IRIS_QC_GRABA_HIST_FIJA_VARIABLES(ID_ANA, ID_LOTE, ID_DET, F_LI, F_LS, F_ME, F_DE, F_CV, F_N)
        dats += NN.IRIS_QC_UPDATE_FIJA_VARIABLES(ID_ANA, ID_LOTE, ID_DET, V_LI, V_LS, V_ME, V_DE, V_CV, V_N)

        If (dats > 0) Then
            Return dats
        Else
            Return Nothing
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_UPDATE_QC_RESULTADO(ByVal ID_TP_ACCION As Long,
                                                    ByVal COMENTARIO As String,
                                                    ByVal OMITIDO As Integer,
                                                    ByVal ID_RESUL As Long) As Integer
        Dim dats As Integer

        Dim NN As N_IRIS_UPDATE_QC_RESULTADO = New N_IRIS_UPDATE_QC_RESULTADO

        dats = NN.IRIS_UPDATE_QC_RESULTADO(ID_TP_ACCION, COMENTARIO, OMITIDO, ID_RESUL)

        If (dats > 0) Then
            Return dats
        Else
            Return Nothing
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_GRABA_QC_RESULTADO_MANUAL(ByVal ID_ANA As Long,
                                                          ByVal ID_LOTE As Long,
                                                          ByVal ID_DET As Long,
                                                          ByVal FECHA As String,
                                                          ByVal ID_TP_ACCION As Long,
                                                          ByVal RESUL As String,
                                                          ByVal COMENTARIO As String) As Integer
        Dim dats As Integer

        Dim NN As N_IRIS_GRABA_QC_RESULTADO_MANUAL = New N_IRIS_GRABA_QC_RESULTADO_MANUAL

        dats = NN.IRIS_GRABA_QC_RESULTADO_MANUAL(ID_ANA, ID_LOTE, ID_DET, FECHA, ID_TP_ACCION, RESUL, COMENTARIO)

        If (dats > 0) Then
            Return dats
        Else
            Return Nothing
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2(ByVal ID_ANA As Long, ByVal ID_LOTE As Long, ByVal ID_DET As Long, ByVal FECHA As String, ByVal N As Long) As List(Of E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2)
        Dim dats As List(Of E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2)
        Dim dats_Return As New List(Of E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2)
        Dim NN As N_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20 = New N_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20


        dats = NN.IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2(ID_ANA, ID_LOTE, ID_DET, FECHA, N)

        If (dats.Count > 0) Then
            For index As Integer = dats.Count To 1 Step -1
                dats_Return.Add(dats(index - 1))
            Next
            Return dats_Return
        Else
            Return Nothing
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_FECHA(ByVal ID_ANA As Long, ByVal ID_LOTE As Long, ByVal ID_DET As Long, ByVal DESDE As String, ByVal HASTA As String) As List(Of E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2)
        Dim dats As List(Of E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2)
        Dim dats_Return As New List(Of E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2)
        Dim NN As N_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20 = New N_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20


        dats = NN.IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_FECHA(ID_ANA, ID_LOTE, ID_DET, DESDE, HASTA)


        If (dats.Count > 0) Then
            For index As Integer = dats.Count To 1 Step -1
                dats_Return.Add(dats(index - 1))
            Next
            Return dats_Return
        Else
            Return Nothing
        End If

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_QC_BUSCA_REL_ANA_DET_LOTE_POR_PARAM(ByVal ID_ANA As Long, ByVal ID_LOTE As Long, ByVal ID_DET As Long) As List(Of E_IRIS_QC_BUSCA_REL_ANA_DET_LOTE_POR_PARAM)
        Dim dats As List(Of E_IRIS_QC_BUSCA_REL_ANA_DET_LOTE_POR_PARAM)

        Dim NN As N_IRIS_QC_BUSCA_REL_ANA_DET_LOTE_POR_PARAM = New N_IRIS_QC_BUSCA_REL_ANA_DET_LOTE_POR_PARAM


        dats = NN.IRIS_QC_BUSCA_REL_ANA_DET_LOTE_POR_PARAM(ID_ANA, ID_LOTE, ID_DET)


        If (dats.Count > 0) Then
            Return dats
        Else
            Return Nothing
        End If

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_QC_BUSCA_TP_ACCION_ACTIVAS() As List(Of E_IRIS_QC_BUSCA_TP_ACCION)

        Dim datas As List(Of E_IRIS_QC_BUSCA_TP_ACCION)

        Dim NN As N_IRIS_QC_BUSCA_TP_ACCION_ACTIVAS = New N_IRIS_QC_BUSCA_TP_ACCION_ACTIVAS
        datas = NN.IRIS_QC_BUSCA_TP_ACCION_ACTIVAS()

        If (datas.Count > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function
End Class