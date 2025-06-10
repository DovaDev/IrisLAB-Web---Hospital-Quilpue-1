Imports Entidades
Imports Negocio
Public Class C_Analito
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()>
    Public Shared Function IRIS_QC_BUSCA_U_MEDIDA() As List(Of E_IRIS_QC_BUSCA_U_MEDIDA)

        Dim datas As List(Of E_IRIS_QC_BUSCA_U_MEDIDA)

        Dim NN As N_IRIS_QC_BUSCA_U_MEDIDA = New N_IRIS_QC_BUSCA_U_MEDIDA
        datas = NN.IRIS_QC_BUSCA_U_MEDIDA()

        If (datas.Count > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_GRABA_QC_ANALITO(ByVal AREA_COD As String,
                                                   ByVal AREA_DES As String,
                                                   ByVal ID_ESTADO As Integer,
                                                   ByVal ID_U_MEDIDA As Integer) As Integer

        Dim datas As Integer

        Dim NN As N_IRIS_GRABA_QC_ANALITO = New N_IRIS_GRABA_QC_ANALITO
        datas = NN.IRIS_GRABA_QC_ANALITO(AREA_COD, AREA_DES, ID_ESTADO, ID_U_MEDIDA)

        If (datas > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_UPDATE_QC_ANALITO(ByVal ID_AREA As Long,
                                                   ByVal AREA_COD As String,
                                                   ByVal AREA_DES As String,
                                                   ByVal ID_ESTADO As Integer,
                                                   ByVal ID_U_MEDIDA As Integer) As Integer

        Dim datas As Integer

        Dim NN As N_IRIS_UPDATE_QC_ANALITO = New N_IRIS_UPDATE_QC_ANALITO
        datas = NN.IRIS_UPDATE_QC_ANALITO(ID_AREA, AREA_COD, AREA_DES, ID_ESTADO, ID_U_MEDIDA)

        If (datas > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_QC_BUSCA_ANALITO() As List(Of E_IRIS_QC_BUSCA_ANALITO)

        Dim datas As List(Of E_IRIS_QC_BUSCA_ANALITO)

        Dim NN As N_IRIS_QC_BUSCA_ANALITO = New N_IRIS_QC_BUSCA_ANALITO
        datas = NN.IRIS_QC_BUSCA_ANALITO()

        If (datas.Count > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function

End Class