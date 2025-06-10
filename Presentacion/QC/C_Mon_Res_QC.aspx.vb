Imports Entidades
Imports Negocio
Public Class C_Mon_Res_QC
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
    Public Shared Function IRIS_QC_BUSCA_MONITOR_CONTROLES_3(ByVal DESDE As String, ByVal HASTA As String, ByVal ID_ANA As Long) As List(Of E_IRIS_QC_BUSCA_MONITOR_CONTROLES_3)

        Dim datas As List(Of E_IRIS_QC_BUSCA_MONITOR_CONTROLES_3)

        Dim NN As N_IRIS_QC_BUSCA_MONITOR_CONTROLES_3 = New N_IRIS_QC_BUSCA_MONITOR_CONTROLES_3
        datas = NN.IRIS_QC_BUSCA_MONITOR_CONTROLES_3(DESDE, HASTA, ID_ANA)

        If (datas.Count > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function
    <Services.WebMethod()>
    Public Shared Function IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20(ByVal ID_ANA As Long, ByVal ID_LOTE As Long, ByVal ID_DET As Long) As List(Of E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20)

        Dim datas As List(Of E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20)

        Dim NN As N_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20 = New N_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20
        datas = NN.IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20(ID_ANA, ID_LOTE, ID_DET)

        If (datas.Count > 0) Then
            Return datas
        Else
            Return Nothing
        End If

    End Function

    <Services.WebMethod()>
    Public Shared Function IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2(ByVal Obj As List(Of E_OBJ_RESP)) As List(Of E_Resp)
        Dim dats As New List(Of E_Resp)
        Dim dat As E_Resp

        Dim NN As N_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20 = New N_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20

        For Each _obj As Object In Obj

            dat = New E_Resp

            Dim ID_ANA As Long = _obj.ID_ANA
            Dim ID_LOTE As Long = _obj.ID_LOTE
            Dim ID_DET As Long = _obj.ID_DET
            Dim FECHA As String = _obj.FECHA
            Dim N As Long = _obj.N
            Dim i As Long = _obj.i

            dat.LOS = NN.IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2(ID_ANA, ID_LOTE, ID_DET, FECHA, N)
            dat.i = i

            dats.Add(dat)
        Next

        If (dats.Count > 0) Then
            Return dats
        Else
            Return Nothing
        End If

    End Function
    Public Class E_OBJ_RESP
        Private EE_N As Long
        Public Property N() As Long
            Get
                Return EE_N
            End Get
            Set(ByVal value As Long)
                EE_N = value
            End Set
        End Property
        Private EE_i As Long
        Public Property i() As Long
            Get
                Return EE_i
            End Get
            Set(ByVal value As Long)
                EE_i = value
            End Set
        End Property
        Private EE_FECHA As String
        Public Property FECHA() As String
            Get
                Return EE_FECHA
            End Get
            Set(ByVal value As String)
                EE_FECHA = value
            End Set
        End Property
        Private EE_ID_DET As Long
        Public Property ID_DET() As Long
            Get
                Return EE_ID_DET
            End Get
            Set(ByVal value As Long)
                EE_ID_DET = value
            End Set
        End Property
        Private EE_ID_LOTE As Long
        Public Property ID_LOTE() As Long
            Get
                Return EE_ID_LOTE
            End Get
            Set(ByVal value As Long)
                EE_ID_LOTE = value
            End Set
        End Property
        Private EE_ID_ANA As Long
        Public Property ID_ANA() As Long
            Get
                Return EE_ID_ANA
            End Get
            Set(ByVal value As Long)
                EE_ID_ANA = value
            End Set
        End Property
    End Class
    Public Class E_Resp
        Private EE_LOS As List(Of E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2)
        Public Property LOS() As List(Of E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2)
            Get
                Return EE_LOS
            End Get
            Set(ByVal value As List(Of E_IRIS_QC_BUSCA_DATOS_RESULTADO_POR_CRITERIOS20_2))
                EE_LOS = value
            End Set
        End Property
        Private EE_i As Long
        Public Property i() As Long
            Get
                Return EE_i
            End Get
            Set(ByVal value As Long)
                EE_i = value
            End Set
        End Property
    End Class
End Class