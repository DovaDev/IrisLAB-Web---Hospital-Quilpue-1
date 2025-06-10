Imports Entidades
Imports Negocio
Public Class C_Rel_Ana_Det_Can
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    <Services.WebMethod()>
    Public Shared Function IRIS_QC_BUSCA_ANALIZADOR_ACTIVO() As List(Of E_IRIS_QC_BUSCA_ANALIZADOR_ACTIVO)

        Dim datas As List(Of E_IRIS_QC_BUSCA_ANALIZADOR_ACTIVO)

        Dim NN As N_IRIS_QC_BUSCA_ANALIZADOR_ACTIVO = New N_IRIS_QC_BUSCA_ANALIZADOR_ACTIVO
        datas = NN.IRIS_QC_BUSCA_ANALIZADOR_ACTIVO()

        If (datas.Count > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_BUSCA_QC_RELACION_ANALIZADOR_DET_NO_CARGADAS(ByVal ID_ANA As Long) As List(Of E_IRIS_BUSCA_QC_RELACION_ANALIZADOR_DET_NO_CARGADAS)

        Dim datas As List(Of E_IRIS_BUSCA_QC_RELACION_ANALIZADOR_DET_NO_CARGADAS)

        Dim NN As N_IRIS_BUSCA_QC_RELACION_ANALIZADOR_DET_NO_CARGADAS = New N_IRIS_BUSCA_QC_RELACION_ANALIZADOR_DET_NO_CARGADAS
        datas = NN.IRIS_BUSCA_QC_RELACION_ANALIZADOR_DET_NO_CARGADAS(ID_ANA)

        If (datas.Count > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_GRABA_QC_RELACION_ANALIZADOR_DETERMINACION_CANAL(ByVal ID_ANA As Long, ByVal ID_DET As List(Of Long)) As Integer

        Dim datas As Integer

        Dim NN As N_IRIS_GRABA_QC_RELACION_ANALIZADOR_DETERMINACION_CANAL = New N_IRIS_GRABA_QC_RELACION_ANALIZADOR_DETERMINACION_CANAL

        For Each item As String In ID_DET
            datas += NN.IRIS_GRABA_QC_RELACION_ANALIZADOR_DETERMINACION_CANAL(ID_ANA, item)
        Next


        If (datas > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_QC_BUSCA_ANALIZADORES_DETERMINACION_POR_CANAL(ByVal ID_ANA As Long) As List(Of E_IRIS_QC_BUSCA_ANALIZADORES_DETERMINACION_POR_CANAL)

        Dim datas As List(Of E_IRIS_QC_BUSCA_ANALIZADORES_DETERMINACION_POR_CANAL)

        Dim NN As N_IRIS_QC_BUSCA_ANALIZADORES_DETERMINACION_POR_CANAL = New N_IRIS_QC_BUSCA_ANALIZADORES_DETERMINACION_POR_CANAL
        datas = NN.IRIS_QC_BUSCA_ANALIZADORES_DETERMINACION_POR_CANAL(ID_ANA)

        If (datas.Count > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_UPDATE_QC_RELACION_MAQ_DETERMINACON_CANAL_QUITAR(ByVal ID_REL As List(Of Long)) As Integer

        Dim datas As Integer

        Dim NN As N_IRIS_UPDATE_QC_RELACION_MAQ_DETERMINACON_CANAL_QUITAR = New N_IRIS_UPDATE_QC_RELACION_MAQ_DETERMINACON_CANAL_QUITAR

        For Each item As String In ID_REL
            datas += NN.IRIS_UPDATE_QC_RELACION_MAQ_DETERMINACON_CANAL_QUITAR(item)
        Next


        If (datas > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_UPDATE_QC_ANALIZADOR_DETERMINACION_CANAL_UPDATE(ByVal OBJ As List(Of E_IRIS_QC_OBJ_UPDATE_CANAL)) As Integer

        Dim datas As Integer

        Dim NN As N_IRIS_UPDATE_QC_ANALIZADOR_DETERMINACION_CANAL_UPDATE = New N_IRIS_UPDATE_QC_ANALIZADOR_DETERMINACION_CANAL_UPDATE

        For Each _obj As Object In OBJ
            Dim ID_REL As Integer = _obj.ID_REL
            Dim CANAL As String = _obj.CANAL

            datas += NN.IRIS_UPDATE_QC_ANALIZADOR_DETERMINACION_CANAL_UPDATE(ID_REL, CANAL)

        Next

        If (datas > 0) Then
            Return datas
        Else
            Return Nothing
        End If


    End Function
    Public Class E_IRIS_QC_OBJ_UPDATE_CANAL
        Private EE_ID_REL As Long
        Private EE_CANAL As String
        Public Property CANAL() As String
            Get
                Return EE_CANAL
            End Get
            Set(ByVal value As String)
                EE_CANAL = value
            End Set
        End Property
        Public Property ID_REL() As Long
            Get
                Return EE_ID_REL
            End Get
            Set(ByVal value As Long)
                EE_ID_REL = value
            End Set
        End Property
    End Class

End Class