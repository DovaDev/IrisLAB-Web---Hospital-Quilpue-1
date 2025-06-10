'Importar Capas
Imports Datos
Imports Entidades
Public Class N_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2
    'Declaraciones Generales
    Dim DD_Data As D_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2
    Sub New()
        DD_Data = New D_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2
    End Sub

    Function IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2(ByVal FOLIO As String) As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2)
        Dim item As New List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2)
        item = DD_Data.IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2(FOLIO)
        Dim NN_LugarTM As New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        Dim Data_LugarTM As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        Data_LugarTM = NN_LugarTM.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()
        For i = 0 To item.Count - 1
            Dim PROCE As New List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2)
            PROCE = DD_Data.IRIS_WEBF_BUSCA_ID_PROC_X_COD(item(i).HO_ServicioCodigo)
            If (PROCE.Count > 0) Then
                item(i).HO_ProcedenciaCodigo = PROCE(0).ID_PREVE
                For x = 0 To Data_LugarTM.Count - 1
                    If (Data_LugarTM(x).ID_PROCEDENCIA = PROCE(0).ID_PREVE) Then
                        item(i).HO_ProcedenciaDescripcion = Data_LugarTM(x).PROC_DESC
                    End If
                Next x
            Else
                item(i).HO_ProcedenciaCodigo = 0
            End If
        Next i
        Return item
    End Function
    Function IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP(ByVal FOLIO As String) As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP)
        Dim item As New List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP)

        item = DD_Data.IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_PAP(FOLIO)

        'Dim NN_LugarTM As New N_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO
        'Dim Data_LugarTM As New List(Of E_IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO)
        'Data_LugarTM = NN_LugarTM.IRIS_WEBF_BUSCA_PROCEDENCIA_ACTIVO()


        'For i = 0 To item.Count - 1
        '    Dim PROCE As New List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2)
        '    PROCE = DD_Data.IRIS_WEBF_BUSCA_ID_PROC_X_COD(item(i).HO_ServicioCodigo)
        '    If (PROCE.Count > 0) Then
        '        item(i).HO_ProcedenciaCodigo = PROCE(0).ID_PREVE
        '        For x = 0 To Data_LugarTM.Count - 1
        '            If (Data_LugarTM(x).ID_PROCEDENCIA = PROCE(0).ID_PREVE) Then
        '                item(i).HO_ProcedenciaDescripcion = Data_LugarTM(x).PROC_DESC
        '            End If
        '        Next x
        '    Else
        '        item(i).HO_ProcedenciaCodigo = 0
        '    End If
        'Next i

        Return item
    End Function


    Function IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_global(ByVal FOLIO As String) As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2)
        Return DD_Data.IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_global(FOLIO)
    End Function
    Function IRIS_WEBF_HOST_BUSCA_PACIENTES_SIN_RUT_AVIS() As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2)
        Return DD_Data.IRIS_WEBF_HOST_BUSCA_PACIENTES_SIN_RUT_AVIS()
    End Function



    Function IRIS_WEBF_HOST_BUCA_DATOS_PACIENTE_POR_RUT_AVIS(ByVal RUT As String) As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2)
        Dim item As New List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2)
        item = DD_Data.IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2(RUT)
        For i = 0 To item.Count - 1
            Dim PROCE As New List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2)
            PROCE = DD_Data.IRIS_WEBF_BUSCA_ID_PROC_X_COD(item(i).HO_ServicioCodigo)
            If (PROCE.Count > 0) Then
                item(i).HO_ProcedenciaCodigo = PROCE(0).ID_PREVE
            Else
                item(i).HO_ProcedenciaCodigo = 0
            End If
        Next i
        Return item
    End Function
    Function IRIS_WEBF_HOST_BUCA_DATOS_PACIENTE_POR_RUT_AVIS_GLOBAL(ByVal RUT As String) As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2)
        Return DD_Data.IRIS_WEBF_HOST_BUCA_DATOS_PACIENTE_POR_RUT_AVIS_GLOBAL(RUT)
    End Function

    Function IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_global_2(ByVal FOLIO As String) As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2)
        Return DD_Data.IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2_global_2(FOLIO)
    End Function
    Function IRIS_WEBF_HOST_BUCA_DATOS_PACIENTE_POR_RUT_AVIS_2_GLOBAL_POR_NOMBRE(ByVal NOMBRE As String, ByVal APELLIDO As String, ByVal APELLIDO_MAT As String) As List(Of E_IRIS_WEBF_HOST_BUSCA_DATOS_PACIENTE_Y_EXAMENES_POR_FOLIO_AVIS_2)
        Return DD_Data.IRIS_WEBF_HOST_BUCA_DATOS_PACIENTE_POR_RUT_AVIS_2_GLOBAL_POR_NOMBRE(NOMBRE, APELLIDO, APELLIDO_MAT)
    End Function
End Class