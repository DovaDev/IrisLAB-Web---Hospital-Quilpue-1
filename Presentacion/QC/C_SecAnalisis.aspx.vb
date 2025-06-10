Imports Entidades
Imports Negocio
Public Class C_SecAnalisis
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()>
    Public Shared Function IRIS_GRABA_QC_SECCIONES(ByVal AREA_COD As String,
                                                   ByVal AREA_DES As String,
                                                   ByVal ID_ESTADO As Integer) As Integer

        Dim datas As Integer

        Dim NN As N_IRIS_GRABA_QC_SECCIONES = New N_IRIS_GRABA_QC_SECCIONES
        datas = NN.IRIS_GRABA_QC_SECCIONES(AREA_COD, AREA_DES, ID_ESTADO)

        If (datas > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_UPDATE_QC_SECCIONES(ByVal ID_AREA As Long,
                                                   ByVal AREA_COD As String,
                                                   ByVal AREA_DES As String,
                                                   ByVal ID_ESTADO As Integer) As Integer

        Dim datas As Integer

        Dim NN As N_IRIS_UPDATE_QC_SECCIONES = New N_IRIS_UPDATE_QC_SECCIONES
        datas = NN.IRIS_UPDATE_QC_SECCIONES(ID_AREA, AREA_COD, AREA_DES, ID_ESTADO)

        If (datas > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_QC_BUSCA_SECCIONES() As List(Of E_IRIS_QC_BUSCA_SECCIONES)

        Dim datas As List(Of E_IRIS_QC_BUSCA_SECCIONES)

        Dim NN As N_IRIS_QC_BUSCA_SECCIONES = New N_IRIS_QC_BUSCA_SECCIONES
        datas = NN.IRIS_QC_BUSCA_SECCIONES()

        If (datas.Count > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function
End Class