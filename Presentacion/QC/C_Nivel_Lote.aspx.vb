Imports Entidades
Imports Negocio
Public Class C_Nivel_Lote
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()>
    Public Shared Function IRIS_UPDATE_QC_ESTADO_REL_LOTE_NIVEL(ByVal ID_REL As Long,
                                     ByVal ID_ESTADO As Integer) As Integer

        Dim datas As Integer

        Dim NN As N_IRIS_UPDATE_QC_ESTADO_REL_LOTE_NIVEL = New N_IRIS_UPDATE_QC_ESTADO_REL_LOTE_NIVEL
        datas = NN.IRIS_UPDATE_QC_ESTADO_REL_LOTE_NIVEL(ID_REL, ID_ESTADO)

        If (datas > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_GRABA_QC_REL_NIVEL_LOTE(ByVal N1 As Long,
                                     ByVal N2 As Long) As Integer

        Dim datas As Integer

        Dim NN As N_IRIS_GRABA_QC_REL_NIVEL_LOTE = New N_IRIS_GRABA_QC_REL_NIVEL_LOTE
        datas = NN.IRIS_GRABA_QC_REL_NIVEL_LOTE(N1, N2)

        If (datas > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_QC_BUSCA_LOTE_NIVEL_SIN_REL() As List(Of E_IRIS_QC_BUSCA_LOTE_NIVEL_SIN_REL)

        Dim datas As List(Of E_IRIS_QC_BUSCA_LOTE_NIVEL_SIN_REL)

        Dim NN As N_IRIS_QC_BUSCA_LOTE_NIVEL_SIN_REL = New N_IRIS_QC_BUSCA_LOTE_NIVEL_SIN_REL
        datas = NN.IRIS_QC_BUSCA_LOTE_NIVEL_SIN_REL()

        If (datas.Count > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_QC_BUSCA_REL_NIVEL_LOTE() As List(Of E_IRIS_QC_BUSCA_REL_NIVEL_LOTE)

        Dim datas As List(Of E_IRIS_QC_BUSCA_REL_NIVEL_LOTE)

        Dim NN As N_IRIS_QC_BUSCA_REL_NIVEL_LOTE = New N_IRIS_QC_BUSCA_REL_NIVEL_LOTE
        datas = NN.IRIS_QC_BUSCA_REL_NIVEL_LOTE()

        If (datas.Count > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function
End Class