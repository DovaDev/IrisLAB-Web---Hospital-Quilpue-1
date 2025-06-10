
'Private Type Iris_Spread_Columnas
'ID_F As Long
'NOMBRE_F As Long
'Cargar_F As Long

'End Type

'Private Type Iris_Spread2_Columnas
'ID_D As Long
'NOMBRE_D As Long
'PRECIO_D As Long
'CARGAR_D As Long
'ID_COSTO_D As Long

''Estado_D As Long
'End Type

'Dim PosCol As Iris_Spread_Columnas
'Dim PosCol2 As Iris_Spread2_Columnas

'Private Sub Iris_Spread_Define_Columnas()
'    On Error GoTo Iris_Spread_Define_Columnas_Err

'    PosCol.ID_F = 1
'    PosCol.NOMBRE_F = 2
'    PosCol.Cargar_F = 3


'    'DEFINE LOS ANCHOS DE LAS COLUMNAS Y OCULTA OTRAS
'    Iris_Spread_1.ColWidth(PosCol.ID_F) = 1
'    Iris_Spread_1.ColWidth(PosCol.NOMBRE_F) = 26
'    Iris_Spread_1.ColWidth(PosCol.Cargar_F) = 10


'    'OCULTA COLUMNAS DEL SP_Spread01
'    Iris_Spread_1.Col = PosCol.ID_F
'    Iris_Spread_1.ColHidden = True


'    On Error GoTo 0
'    Exit Sub
'Iris_Spread_Define_Columnas_Err:
'    Call MsgBox("Ha ocurrido un error")
'End Sub
'Private Sub Iris_Spread2_Define_Columnas()
'    On Error GoTo Iris_Spread2_Define_Columnas_Err

'    PosCol2.ID_D = 1
'    PosCol2.NOMBRE_D = 2
'    PosCol2.PRECIO_D = 3
'    PosCol2.CARGAR_D = 4
'    PosCol2.ID_COSTO_D = 5

'    'DEFINE LOS ANCHOS DE LAS COLUMNAS Y OCULTA OTRAS
'    Iris_Spread_2.ColWidth(PosCol2.ID_D) = 1
'    Iris_Spread_2.ColWidth(PosCol2.NOMBRE_D) = 28
'    Iris_Spread_2.ColWidth(PosCol2.PRECIO_D) = 10
'    Iris_Spread_2.ColWidth(PosCol2.CARGAR_D) = 7
'    Iris_Spread_2.ColWidth(PosCol2.ID_COSTO_D) = 1
'    'Iris_Spread_2.ColWidth(PosCol2.Cargar_D) = 7

'    'OCULTA COLUMNAS DEL SP_Spread01
'    Iris_Spread_2.Col = PosCol2.ID_D
'    Iris_Spread_2.ColHidden = True

'    Iris_Spread_2.Col = PosCol2.ID_COSTO_D
'    Iris_Spread_2.ColHidden = True


'    On Error GoTo 0
'    Exit Sub
'Iris_Spread2_Define_Columnas_Err:
'    Call MsgBox("Ha ocurrido un error")
'End Sub


'Function LLAMA_SQL_BUSCA_CIUDAD()

'    Dim SQL_IRIS As ADODB.Recordset
'    Dim Busqueda_ As String
'    Dim Activo_SQL As String

'    Busqueda_ = ""
'    Busqueda_ = "Execute [IRIS_BUSCA_CODIGO_FONASA_ACTIVO] "
'Set SQL_IRIS = CSQLser.Execute(Busqueda_)

'Me.Combo_Ciudad.Clear
'    If Not SQL_IRIS Is Nothing Then
'        If SQL_IRIS.EOF = False Then
'            Do While SQL_IRIS.EOF = False
'                Finger_Dato = ""
'                Finger_Dato = Finger_Evalua_Text(SQL_IRIS!CF_DESC, "")
'                Finger_Dato = Finger_Dato & Space(150)
'                Finger_Dato = Finger_Dato & Finger_Separador
'                Finger_Dato = Finger_Dato & Finger_Evalua_Text(SQL_IRIS!ID_CODIGO_FONASA, "")

'                Me.Combo_Ciudad.AddItem Finger_Dato
'SQL_IRIS.MoveNext
'            Loop

'Set SQL_IRIS = Nothing
'End If
'    End If

'End Function

'Private Sub Agregar_Click()

'    Dim RECsPrue As ADODB.Recordset
'    Dim Agrega_ As Integer
'    Dim Activa_Refresh As Boolean

'    Activa_Refresh = False

'    If Me.ID_NUEVO = "" Then
'        Busqueda_ = ""
'        Busqueda_ = "Execute [IRIS_BUSCA_CORRELATIVO_CONTROL_COSTO] "
'Set SQL_IRIS = CSQLser.Execute(Busqueda_)
'If Not SQL_IRIS Is Nothing Then
'            If SQL_IRIS.EOF = False Then
'                FOLIO_ = SQL_IRIS!IDENTIFICADOR
'            End If
'        End If
'Set SQL_IRIS = Nothing

'Busqueda_ = ""
'        Busqueda_ = "Execute [IRIS_GRABA_CONTROL_COSTO] '" & Trim(Me.Txt_Cod_Ciu.Text) & "', '" & Trim(FOLIO_) & "', '" & Trim(ID_USUARIO_) & "', '" & Trim(Me.LBL_COSTO_TOTAL.Caption) & "'"
'Set SQL_IRIS = CSQLser.Execute(Busqueda_)
'If Not SQL_IRIS Is Nothing Then
'            If SQL_IRIS.EOF = False Then
'                Me.ID_NUEVO = SQL_IRIS!IDENTIFICADOR
'                FOLIO_2 = SQL_IRIS!IDENTIFICADOR

'            End If
'        End If
'Set SQL_IRIS = Nothing



'For i = 1 To Iris_Spread_1.MaxRows
'            Iris_Spread_1.Row = i
'            Iris_Spread_1.Col = PosCol.Cargar_F
'            Activa_Eliminar = Val(Iris_Spread_1.Text)
'            If Activa_Eliminar = 1 Then

'                Iris_Spread_1.Row = i
'                Iris_Spread_1.Col = PosCol.NOMBRE_F

'                dat_Secciones = Iris_Spread_1.Text

'                intResp = MsgBox("Se agregará el siguiente costo : " & dat_Secciones & "", vbQuestion + vbYesNo, Me.Caption)
'                If intResp = vbYes Then
'                    Iris_Spread_1.Row = i
'                    Iris_Spread_1.Col = 1
'                    Agrega_ = Iris_Spread_1.Text
'                    Estado_ = 1
'                    VALOR_NUEVO = 0
'                    Busqueda_ = ""
'                    Busqueda_ = "Execute [IRIS_GRABA_DET_CONTROL_COSTO] '" & Trim(FOLIO_2) & "' , '" & Trim(Agrega_) & "', '" & Trim(VALOR_NUEVO) & "','" & Trim(ID_USUARIO_) & "' "
'Set SQL_IRIS = CSQLser.Execute(Busqueda_)
'MsgBox("IrisLAB.....Datos Almacenados Correctamente.... !!! " & Chr(13)), vbExclamation, "Validación"
'Activa_Refresh = True
'                End If
'            End If
'        Next

'    Else
'        For i = 1 To Iris_Spread_1.MaxRows
'            Iris_Spread_1.Row = i
'            Iris_Spread_1.Col = PosCol.Cargar_F
'            Activa_Eliminar = Val(Iris_Spread_1.Text)
'            If Activa_Eliminar = 1 Then

'                Iris_Spread_1.Row = i
'                Iris_Spread_1.Col = PosCol.NOMBRE_F

'                dat_Secciones = Iris_Spread_1.Text

'                intResp = MsgBox("Se agregará el siguiente costo : " & dat_Secciones & "", vbQuestion + vbYesNo, Me.Caption)
'                If intResp = vbYes Then
'                    Iris_Spread_1.Row = i
'                    Iris_Spread_1.Col = 1
'                    Agrega_ = Iris_Spread_1.Text
'                    Estado_ = 1
'                    VALOR_NUEVO = 0
'                    Busqueda_ = ""
'                    Busqueda_ = "Execute [IRIS_GRABA_DET_CONTROL_COSTO] '" & Trim(Me.ID_NUEVO) & "' , '" & Trim(Agrega_) & "', '" & Trim(VALOR_NUEVO) & "','" & Trim(ID_USUARIO_) & "' "
'Set SQL_IRIS = CSQLser.Execute(Busqueda_)
'MsgBox("IrisLAB.....Datos Almacenados Correctamente.... !!! " & Chr(13)), vbExclamation, "Validación"
'Activa_Refresh = True
'                End If
'            End If
'        Next


'    End If

'    If Activa_Refresh = True Then
'        Call LLAMA_SQL_BUSCA_COSTOS_CARGADOS()
'        Call LLAMA_SQL_BUSCA_COSTOS_NO_CARGADAS()
'    End If

'End Sub

'Private Sub Btn_Guardar_Click()

'    If Me.Iris_Spread_2.MaxRows > 0 And Me.Txt_Cod_Ciu <> "" Then

'        Busqueda_ = ""
'        Busqueda_ = "Execute [IRIS_UPDATE_CONTROL_COSTOS_ELIMINA] '" & Trim(Me.ID_NUEVO) & "'"
'Set SQL_IRIS = CSQLser.Execute(Busqueda_)
'Set SQL_IRIS = Nothing



'Busqueda_ = ""
'        Busqueda_ = "Execute [IRIS_BUSCA_CORRELATIVO_CONTROL_COSTO] "
'Set SQL_IRIS = CSQLser.Execute(Busqueda_)
'If Not SQL_IRIS Is Nothing Then
'            If SQL_IRIS.EOF = False Then
'                FOLIO_ = SQL_IRIS!IDENTIFICADOR
'            End If
'        End If
'Set SQL_IRIS = Nothing

'Busqueda_ = ""
'        Busqueda_ = "Execute [IRIS_GRABA_CONTROL_COSTO] '" & Trim(Me.Txt_Cod_Ciu.Text) & "', '" & Trim(FOLIO_) & "', '" & Trim(ID_USUARIO_) & "', '" & Trim(Format(Me.LBL_COSTO_TOTAL.Caption, "#######")) & "'"
'Set SQL_IRIS = CSQLser.Execute(Busqueda_)
'If Not SQL_IRIS Is Nothing Then
'            If SQL_IRIS.EOF = False Then
'                Me.ID_NUEVO = SQL_IRIS!IDENTIFICADOR
'                FOLIO_2 = SQL_IRIS!IDENTIFICADOR
'            End If
'        End If
'Set SQL_IRIS = Nothing

'For i = 1 To Iris_Spread_2.MaxRows
'            Iris_Spread_2.Row = i
'            Iris_Spread_2.Col = PosCol2.ID_D
'            Activa_Eliminar = Iris_Spread_2.Text
'            If Activa_Eliminar <> "" Then
'                Iris_Spread_2.Row = i
'                Iris_Spread_2.Col = PosCol2.ID_COSTO_D
'                Agrega_ = Iris_Spread_2.Text

'                Estado_ = 1
'                Iris_Spread_2.Row = i
'                Iris_Spread_2.Col = PosCol2.PRECIO_D
'                VALOR_NUEVO = Format(Iris_Spread_2.Text, "########")
'                If VALOR_NUEVO = "" Then
'                    VALOR_NUEVO = 0
'                End If


'                Busqueda_ = ""
'                Busqueda_ = "Execute [IRIS_GRABA_DET_CONTROL_COSTO] '" & Trim(FOLIO_2) & "' , '" & Trim(Agrega_) & "', '" & Trim(VALOR_NUEVO) & "','" & Trim(ID_USUARIO_) & "' "
'Set SQL_IRIS = CSQLser.Execute(Busqueda_)
'Set SQL_IRIS = Nothing
''MsgBox ("IrisLAB.....Datos Almacenados Correctamente.... !!! " & Chr(13)), vbExclamation, "Validación"
'Activa_Refresh = True
'            End If
'        Next


'        Busqueda_ = ""
'        Busqueda_ = "Execute [IRIS_UPDATE_CODIGO_FONASA_CONTROL_COSTO] '" & Trim(Me.Txt_Cod_Ciu.Text) & "', '" & Trim(FOLIO_2) & "'"
'Set SQL_IRIS = CSQLser.Execute(Busqueda_)
'Set SQL_IRIS = Nothing

'MsgBox("IrisLAB.....Datos Almacenados Correctamente.... !!! " & Chr(13)), vbExclamation, "Validación"
'End If

'End Sub

'Private Sub Combo_Ciudad_Click()
'    Dim Finger_Dato_Separa

'    Finger_Dato_Separa = Me.Combo_Ciudad.Text
'    Finge_Posicion_Separador = InStr(Finger_Dato_Separa, Finger_Separador)

'    If Finge_Posicion_Separador <> 0 Then
'        Finger_Descripcion_Cargo = Mid(Finger_Dato_Separa, 1, Finge_Posicion_Separador - 1)

'        Finger_Descripcion_Cargo = Trim(Finger_Descripcion_Cargo)
'        Finger_CODIGO_Cargo = Mid(Finger_Dato_Separa, Finge_Posicion_Separador + 1)
'        Finger_CODIGO_Cargo = Trim(Finger_CODIGO_Cargo)

'        Finger_Descripcion_Cargo = Finger_Descripcion_Cargo
'        Me.Txt_Cod_Ciu.Text = Finger_CODIGO_Cargo

'        'Call LLAMA_SQL_BUSCA_SECCIONES_CARGADAS
'        'Call LLAMA_SQL_BUSCA_SECCIONES_NO_CARGADAS
'        'Me.txt
'        Me.Iris_Spread_1.MaxRows = 0
'        Me.Iris_Spread_2.MaxRows = 0
'        Me.LBL_COSTO_TOTAL.Caption = 0
'        Call LLAMA_SQL_BUSCA_ID_CONTROL_COSTO_POR_FONASA()
'        Call SUMA_DATOS_GRILLA()
'    End If

'End Sub

'Private Sub Command2_Click()
'    Unload Me
'End Sub

'Private Sub Form_Load()
'    Me.Caption = Titulo_Finger
'    Call Iris_Spread_Define_Columnas()
'    Call Iris_Spread2_Define_Columnas()
'    Call FINGER_LEER_INI

'    Call LLAMA_SQL_BUSCA_CIUDAD()


'End Sub

'Function LLAMA_SQL_BUSCA_SECCIONES_CARGADAS()

'    Dim SQL_IRIS As ADODB.Recordset
'    Dim Busqueda_ As String
'    Dim Activo_SQL As String

'    Busqueda_ = ""
'    Busqueda_ = "Execute [IRIS_BUSCA_RELACION_ANALIZADOR_FONASA] '" & Trim(Txt_Cod_Ciu) & "'"
''Busqueda_ = "Execute [IRIS_BUSCA_RELACION_AREA_SECCION] "
'Set SQL_IRIS = CSQLser.Execute(Busqueda_)

'Iris_Spread_2.MaxRows = 0
'    If Not SQL_IRIS Is Nothing Then
'        If SQL_IRIS.EOF = False Then

'            Iris_Spread_2.MaxRows = 0
'            Do While SQL_IRIS.EOF = False
'                Iris_Spread_2.MaxRows = Iris_Spread_2.MaxRows + 1
'                Iris_Spread_2.Row = Iris_Spread_2.MaxRows
'                Iris_Spread_2.RowHeight(Iris_Spread_2.Row) = 12
'                Iris_Spread_2.UserResizeRow = SS_USER_RESIZE_OFF

'                Iris_Spread_2.Col = PosCol2.ID_D
'                Iris_Spread_2.Text = Trim(IIf(IsNull(SQL_IRIS!ID_REL_MAQ_FONASA), "", SQL_IRIS!ID_REL_MAQ_FONASA))

'                Iris_Spread_2.Col = PosCol2.NOMBRE_D
'                Iris_Spread_2.Text = Trim(IIf(IsNull(SQL_IRIS!IRIS_LNK_MAQ_DESCRIPCION), "", SQL_IRIS!IRIS_LNK_MAQ_DESCRIPCION))


'                SQL_IRIS.MoveNext
'            Loop
'Set SQL_IRIS = Nothing
'End If
'    End If

'End Function
''
'Function LLAMA_SQL_BUSCA_COSTOS_CARGADOS()

'    Dim SQL_IRIS As ADODB.Recordset
'    Dim Busqueda_ As String
'    Dim Activo_SQL As String

'    Busqueda_ = ""
'    Busqueda_ = "Execute [IRIS_BUSCA_CONTROL_COSTO_RELACIONADOS] '" & Trim(Me.ID_NUEVO) & "'"
'Set SQL_IRIS = CSQLser.Execute(Busqueda_)

'Iris_Spread_2.MaxRows = 0
'    If Not SQL_IRIS Is Nothing Then
'        If SQL_IRIS.EOF = False Then

'            Iris_Spread_2.MaxRows = 0
'            Do While SQL_IRIS.EOF = False
'                Iris_Spread_2.MaxRows = Iris_Spread_2.MaxRows + 1
'                Iris_Spread_2.Row = Iris_Spread_2.MaxRows
'                Iris_Spread_2.RowHeight(Iris_Spread_2.Row) = 12
'                Iris_Spread_2.UserResizeRow = SS_USER_RESIZE_OFF

'                Iris_Spread_2.Col = PosCol2.ID_D
'                Iris_Spread_2.Text = Trim(IIf(IsNull(SQL_IRIS!ID_DET_CONT_COSTO), "", SQL_IRIS!ID_DET_CONT_COSTO))

'                Iris_Spread_2.Col = PosCol2.NOMBRE_D
'                Iris_Spread_2.Text = Trim(IIf(IsNull(SQL_IRIS!COSTO_DESC), "", SQL_IRIS!COSTO_DESC))

'                Iris_Spread_2.Col = PosCol2.PRECIO_D
'                Iris_Spread_2.Text = Trim(IIf(IsNull(SQL_IRIS!DET_CONT_COSTO_PRECIO), "", SQL_IRIS!DET_CONT_COSTO_PRECIO))

'                Iris_Spread_2.Col = PosCol2.ID_COSTO_D
'                Iris_Spread_2.Text = Trim(IIf(IsNull(SQL_IRIS!ID_COSTO), "", SQL_IRIS!ID_COSTO))

'                SQL_IRIS.MoveNext

'            Loop

'Set SQL_IRIS = Nothing
'End If
'    End If

'End Function
'Function LLAMA_SQL_BUSCA_SECCIONES_NO_CARGADAS()

'    Dim SQL_IRIS As ADODB.Recordset
'    Dim Busqueda_ As String
'    Dim Activo_SQL As String

'    Busqueda_ = ""
'    Busqueda_ = "Execute [IRIS_BUSCA_RELACION_ANALIZADOR_FONASA_NO_CARGADAS] '" & Trim(Txt_Cod_Ciu) & "'"
'Set SQL_IRIS = CSQLser.Execute(Busqueda_)

'Iris_Spread_1.MaxRows = 0
'    If Not SQL_IRIS Is Nothing Then
'        If SQL_IRIS.EOF = False Then

'            Iris_Spread_1.MaxRows = 0
'            Do While SQL_IRIS.EOF = False
'                Iris_Spread_1.MaxRows = Iris_Spread_1.MaxRows + 1
'                Iris_Spread_1.Row = Iris_Spread_1.MaxRows
'                Iris_Spread_1.RowHeight(Iris_Spread_1.Row) = 12
'                Iris_Spread_1.UserResizeRow = SS_USER_RESIZE_OFF

'                Iris_Spread_1.Col = PosCol.ID_F
'                Iris_Spread_1.Text = Trim(IIf(IsNull(SQL_IRIS!IRIS_LNK_MAQ_ID), "", SQL_IRIS!IRIS_LNK_MAQ_ID))

'                Iris_Spread_1.Col = PosCol.NOMBRE_F
'                Iris_Spread_1.Text = Trim(IIf(IsNull(SQL_IRIS!IRIS_LNK_MAQ_DESCRIPCION), "", SQL_IRIS!IRIS_LNK_MAQ_DESCRIPCION))

'                SQL_IRIS.MoveNext
'            Loop
'Set SQL_IRIS = Nothing
'End If
'    End If

'End Function
''IRIS_BUSCA_RELACION_COSTO_FONASA
'Function LLAMA_SQL_BUSCA_COSTOS_NO_CARGADAS()

'    Dim SQL_IRIS As ADODB.Recordset
'    Dim Busqueda_ As String
'    Dim Activo_SQL As String

'    Busqueda_ = ""
'    Busqueda_ = "Execute [IRIS_BUSCA_RELACION_COSTO_FONASA] '" & Trim(Me.ID_NUEVO) & "'"
'Set SQL_IRIS = CSQLser.Execute(Busqueda_)

'Iris_Spread_1.MaxRows = 0
'    If Not SQL_IRIS Is Nothing Then
'        If SQL_IRIS.EOF = False Then

'            Iris_Spread_1.MaxRows = 0
'            Do While SQL_IRIS.EOF = False
'                Iris_Spread_1.MaxRows = Iris_Spread_1.MaxRows + 1
'                Iris_Spread_1.Row = Iris_Spread_1.MaxRows
'                Iris_Spread_1.RowHeight(Iris_Spread_1.Row) = 12
'                Iris_Spread_1.UserResizeRow = SS_USER_RESIZE_OFF

'                Iris_Spread_1.Col = PosCol.ID_F
'                Iris_Spread_1.Text = Trim(IIf(IsNull(SQL_IRIS!ID_COSTO), "", SQL_IRIS!ID_COSTO))

'                Iris_Spread_1.Col = PosCol.NOMBRE_F
'                Iris_Spread_1.Text = Trim(IIf(IsNull(SQL_IRIS!COSTO_DESC), "", SQL_IRIS!COSTO_DESC))

'                SQL_IRIS.MoveNext
'            Loop
'Set SQL_IRIS = Nothing
'End If
'    End If

'End Function

'Private Sub Iris_Spread_2_EditMode(ByVal Col As Long, ByVal Row As Long, ByVal Mode As Integer, ByVal ChangeMade As Boolean)
'    v_copago = 0
'    v_previ = 0
'    v_total = 0

'    Select Case Col
'        Case PosCol2.PRECIO_D
'            If ChangeMade = True Then
'                For A_ = 1 To Me.Iris_Spread_2.MaxRows
'                    Iris_Spread_2.Row = A_
'                    Iris_Spread_2.Col = PosCol2.PRECIO_D

'                    If Iris_Spread_2.Text <> 0 Then
'                        v_previ = Format(Iris_Spread_2.Text, "#######") + v_previ
'                    Else
'                        v_previ = v_previ
'                    End If

'                Next
'                Me.LBL_COSTO_TOTAL = Format(v_previ, "####,#0")

'            End If
'    End Select

'End Sub
'Private Sub Quitar_Click()
'    Dim RECsPrue As ADODB.Recordset
'    Dim Agrega_ As Integer
'    Dim Activa_Refresh As Boolean
'    Dim ACTIVA_NUEVO_REGISTRO As Boolean
'    ACTIVA_NUEVO_REGISTRO = False
'    Activa_Refresh = False

'    For i = 1 To Iris_Spread_2.MaxRows
'        Iris_Spread_2.Row = i
'        Iris_Spread_2.Col = PosCol2.CARGAR_D
'        Activa_Eliminar = Val(Iris_Spread_2.Value)
'        If Activa_Eliminar = 1 Then
'            Iris_Spread_2.Row = i
'            Iris_Spread_2.Col = PosCol2.NOMBRE_D

'            intResp = MsgBox("Quitar la siguiente Relacion : " & Iris_Spread_2.Text & "", vbQuestion + vbYesNo, Me.Caption)
'            If intResp = vbYes Then
'                Iris_Spread_2.Row = i
'                Iris_Spread_2.Col = PosCol2.ID_D
'                Elimina_ = Iris_Spread_2.Text
'                Busqueda_ = ""
'                Busqueda_ = "Execute [IRIS_UPDATE_QUITA_DETALLE_EXAMEN_FONASA] '" & Trim(Elimina_) & "'"
'Set SQL_IRIS = CSQLser.Execute(Busqueda_)
'ACTIVA_NUEVO_REGISTRO = True
'            End If
'        End If
'    Next

'    Call SUMA_DATOS_GRILLA()

'    If ACTIVA_NUEVO_REGISTRO = True Then

'        Busqueda_ = ""
'        Busqueda_ = "Execute [IRIS_UPDATE_CONTROL_COSTOS_ELIMINA] '" & Trim(Me.ID_NUEVO) & "'"
'Set SQL_IRIS = CSQLser.Execute(Busqueda_)
'Set SQL_IRIS = Nothing

'Busqueda_ = ""
'        Busqueda_ = "Execute [IRIS_BUSCA_CORRELATIVO_CONTROL_COSTO] "
'Set SQL_IRIS = CSQLser.Execute(Busqueda_)
'If Not SQL_IRIS Is Nothing Then
'            If SQL_IRIS.EOF = False Then
'                FOLIO_ = SQL_IRIS!IDENTIFICADOR
'            End If
'        End If
'Set SQL_IRIS = Nothing

'Busqueda_ = ""
'        Busqueda_ = "Execute [IRIS_GRABA_CONTROL_COSTO] '" & Trim(Me.Txt_Cod_Ciu.Text) & "', '" & Trim(FOLIO_) & "', '" & Trim(ID_USUARIO_) & "', '" & Trim(Me.LBL_COSTO_TOTAL.Caption) & "'"
'Set SQL_IRIS = CSQLser.Execute(Busqueda_)
'If Not SQL_IRIS Is Nothing Then
'            If SQL_IRIS.EOF = False Then
'                Me.ID_NUEVO = SQL_IRIS!IDENTIFICADOR
'                FOLIO_2 = SQL_IRIS!IDENTIFICADOR

'            End If
'        End If
'Set SQL_IRIS = Nothing

'For i = 1 To Iris_Spread_1.MaxRows
'            Iris_Spread_1.Row = i
'            Iris_Spread_1.Col = PosCol.Cargar_F
'            Activa_Eliminar = Val(Iris_Spread_1.Text)
'            If Activa_Eliminar = 1 Then
'                Iris_Spread_1.Row = i
'                Iris_Spread_1.Col = PosCol.NOMBRE_F
'                dat_Secciones = Iris_Spread_1.Text
'                Iris_Spread_1.Row = i
'                Iris_Spread_1.Col = 1
'                Agrega_ = Iris_Spread_1.Text
'                Estado_ = 1
'                VALOR_NUEVO = 0
'                Busqueda_ = ""
'                Busqueda_ = "Execute [IRIS_GRABA_DET_CONTROL_COSTO] '" & Trim(FOLIO_2) & "' , '" & Trim(Agrega_) & "', '" & Trim(VALOR_NUEVO) & "','" & Trim(ID_USUARIO_) & "' "
'Set SQL_IRIS = CSQLser.Execute(Busqueda_)
'Activa_Refresh = True
'            End If
'        Next
'        Me.LBL_COSTO_TOTAL.Caption = 0
'        Call LLAMA_SQL_BUSCA_COSTOS_CARGADOS()
'        Call LLAMA_SQL_BUSCA_COSTOS_NO_CARGADAS()

'    End If

'End Sub
'Function LLAMA_SQL_COSTOS_TODOS()
'    'IRIS_BUSCA_COSTOS_ACTIVOS

'    Dim SQL_IRIS As ADODB.Recordset
'    Dim Busqueda_ As String
'    Dim Activo_SQL As String

'    Busqueda_ = ""
'    Busqueda_ = "Execute [IRIS_BUSCA_COSTOS_ACTIVOS] "
'Set SQL_IRIS = CSQLser.Execute(Busqueda_)

'Iris_Spread_1.MaxRows = 0
'    If Not SQL_IRIS Is Nothing Then
'        If SQL_IRIS.EOF = False Then

'            Iris_Spread_1.MaxRows = 0
'            Do While SQL_IRIS.EOF = False
'                Iris_Spread_1.MaxRows = Iris_Spread_1.MaxRows + 1
'                Iris_Spread_1.Row = Iris_Spread_1.MaxRows
'                Iris_Spread_1.RowHeight(Iris_Spread_1.Row) = 12
'                Iris_Spread_1.UserResizeRow = SS_USER_RESIZE_OFF

'                Iris_Spread_1.Col = PosCol.ID_F
'                Iris_Spread_1.Text = Trim(IIf(IsNull(SQL_IRIS!ID_COSTO), "", SQL_IRIS!ID_COSTO))

'                Iris_Spread_1.Col = PosCol.NOMBRE_F
'                Iris_Spread_1.Text = Trim(IIf(IsNull(SQL_IRIS!COSTO_DESC), "", SQL_IRIS!COSTO_DESC))

'                SQL_IRIS.MoveNext
'            Loop
'Set SQL_IRIS = Nothing
'End If
'    End If

'End Function
'Function LLAMA_SQL_BUSCA_ID_CONTROL_COSTO_POR_FONASA()
'    'IRIS_BUSCA_ID_CONTRO_COSTO_POR_FONASA
'    Dim SQL_IRIS As ADODB.Recordset
'    Dim Busqueda_ As String
'    Dim Activo_SQL As String

'    Busqueda_ = ""
'    Busqueda_ = "Execute [IRIS_BUSCA_ID_CONTRO_COSTO_POR_FONASA] '" & Trim(Me.Txt_Cod_Ciu.Text) & "'"
'Set SQL_IRIS = CSQLser.Execute(Busqueda_)

'If Not SQL_IRIS Is Nothing Then
'        If SQL_IRIS.EOF = False Then
'            ID_CONTROL_COSTO_VB = Trim(IIf(IsNull(SQL_IRIS!ID_CONTROL_COSTO), "", SQL_IRIS!ID_CONTROL_COSTO))
'            Me.ID_NUEVO.Caption = ID_CONTROL_COSTO_VB

'            If ID_CONTROL_COSTO_VB = "" Then
'                Call LLAMA_SQL_COSTOS_TODOS()
'            Else
'                Call LLAMA_SQL_BUSCA_COSTOS_CARGADOS()
'                Call LLAMA_SQL_BUSCA_COSTOS_NO_CARGADAS()
'            End If

'        End If
'    End If

'End Function

'Function SUMA_DATOS_GRILLA()
'    Dim v_previ As Long
'    v_previ = 0
'    For A_ = 1 To Me.Iris_Spread_2.MaxRows
'        Iris_Spread_2.Row = A_
'        Iris_Spread_2.Col = PosCol2.PRECIO_D

'        If Iris_Spread_2.Text <> 0 Then
'            v_previ = Format(Iris_Spread_2.Text, "#######") + v_previ
'        Else
'            v_previ = v_previ
'        End If

'    Next
'    Me.LBL_COSTO_TOTAL = Format(v_previ, "####,#0")
'End Function

