Imports Entidades
Imports Negocio
Public Class C_Rel_Lote_Ana
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()>
    Public Shared Function IRIS_QC_BUSCA_LOTE(ByVal ID_LOTE As Long) As List(Of E_IRIS_QC_BUSCA_LOTE)

        Dim datas As List(Of E_IRIS_QC_BUSCA_LOTE)

        Dim NN As N_IRIS_QC_BUSCA_LOTE = New N_IRIS_QC_BUSCA_LOTE
        datas = NN.IRIS_QC_BUSCA_LOTE(ID_LOTE)

        If (datas.Count > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_QC_RELACION_ANALIZADOR_DET_NO_CARGADAS_POR_ANALIZAOR_LOTE(ByVal ID_ANA As Long, ByVal ID_LOTE As Long) As List(Of E_IRIS_QC_RELACION_ANALIZADOR_DET_NO_CARGADAS_POR_ANALIZAOR_LOTE)

        Dim datas As List(Of E_IRIS_QC_RELACION_ANALIZADOR_DET_NO_CARGADAS_POR_ANALIZAOR_LOTE)

        Dim NN As N_IRIS_QC_RELACION_ANALIZADOR_DET_NO_CARGADAS_POR_ANALIZAOR_LOTE = New N_IRIS_QC_RELACION_ANALIZADOR_DET_NO_CARGADAS_POR_ANALIZAOR_LOTE
        datas = NN.IRIS_QC_RELACION_ANALIZADOR_DET_NO_CARGADAS_POR_ANALIZAOR_LOTE(ID_ANA, ID_LOTE)

        If (datas.Count > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_GRABA_QC_RELACION_MAQ_LOTE_DETERMINACION2(ByVal ID_ANA As Long, ByVal ID_LOTE As Long, ByVal ID_DET As List(Of Long)) As Integer

        Dim datas As Integer

        Dim NN As N_IRIS_GRABA_QC_RELACION_MAQ_LOTE_DETERMINACION2 = New N_IRIS_GRABA_QC_RELACION_MAQ_LOTE_DETERMINACION2

        For Each item As String In ID_DET
            datas += NN.IRIS_GRABA_QC_RELACION_MAQ_LOTE_DETERMINACION2(ID_ANA, ID_LOTE, item)
        Next


        If (datas > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_UPDATE_QC_REL_ADL(ByVal ID_REL_ADL As List(Of Long)) As Integer

        Dim datas As Integer

        Dim NN As N_IRIS_UPDATE_QC_REL_ADL = New N_IRIS_UPDATE_QC_REL_ADL

        For Each item As String In ID_REL_ADL
            datas += NN.IRIS_UPDATE_QC_REL_ADL(item)
        Next


        If (datas > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_UPDATE_PARAMS_QC_REL_ADL(ByVal OBJ As List(Of E_IRIS_QC_OBJ_UPDATE)) As Integer

        Dim datas As Integer

        Dim NN As N_IRIS_UPDATE_PARAMS_QC_REL_ADL = New N_IRIS_UPDATE_PARAMS_QC_REL_ADL

        For Each _obj As Object In OBJ
            Dim ID_REL As Integer = _obj.ID_REL
            Dim LI As String = _obj.LI
            Dim LS As String = _obj.LS
            Dim MEDIA As String = _obj.MEDIA
            Dim DESVIACION As String = _obj.DESVIACION
            Dim CV As String = _obj.CV
            Dim NUM As String = _obj.NUM

            datas += NN.IRIS_UPDATE_PARAMS_QC_REL_ADL(ID_REL, LI, LS, MEDIA, DESVIACION, CV, NUM)

        Next

        If (datas > 0) Then
            Return datas
        Else
            Return Nothing
        End If


    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_QC_BUSCA_DET_CARGADAS_POR_ANA_LOTE(ByVal ID_ANA As Long, ByVal ID_LOTE As Long) As List(Of E_IRIS_QC_BUSCA_DET_CARGADAS_POR_ANA_LOTE)

        Dim datas As List(Of E_IRIS_QC_BUSCA_DET_CARGADAS_POR_ANA_LOTE)

        Dim NN As N_IRIS_QC_BUSCA_DET_CARGADAS_POR_ANA_LOTE = New N_IRIS_QC_BUSCA_DET_CARGADAS_POR_ANA_LOTE
        datas = NN.IRIS_QC_BUSCA_DET_CARGADAS_POR_ANA_LOTE(ID_ANA, ID_LOTE)

        If (datas.Count > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function
End Class