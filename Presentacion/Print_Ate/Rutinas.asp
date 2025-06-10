<% 


Set rsaux = Server.CreateObject("ADODB.Recordset")
Set rsaux2 = Server.CreateObject("ADODB.Recordset")

function IndiceTabla(columna,tabla)	
		sql="select isnull(max(" & columna & "),0) as maximo from " & tabla & " "
		'response.write sql
		'response.End()
		rsaux2.open sql, conn 
		if not rsaux2.eof then	
			IndiceTabla =  clng(rsaux2("maximo")) + 1			
		else
			
			IndiceTabla = 1
		end if
		rsaux2.close	
end function

function ValidaMayusculas(cadena)
	nstr = lcase(cadena)
	if nstr <> "" then
		arrcad = split(nstr," ")
		nstr = ""
		for ccar = 0 to Ubound(arrcad)
			palabra = ucase(left(arrcad(ccar),1))&mid(arrcad(ccar),2,len(arrcad(ccar)))
			nstr = nstr & palabra & " "
		next
		nstr = left(nstr, len(nstr)-1)
	end if
    ValidaMayusculas = nstr
End function

Function CambioColor(pColor)
	oColor1="#FFFFFF"
	oColor2="#DEFEE8"

	if oColor = oColor2 or oColor = "" then
		CambioColor = oColor1
    else
		CambioColor = oColor2
    end if
End Function

sub CargaMes(mes)
		Dim Meses(12)
		Meses(1)		=	"Enero"
		Meses(2)		=	"Febrero"
		Meses(3)		=	"Marzo"
		Meses(4)		=	"Abril"
		Meses(5)		=	"Mayo"
		Meses(6)		=	"Junio"
		Meses(7)		=	"Julio"
		Meses(8)		=	"Agosto"
		Meses(9)		=	"Septiembre"
		Meses(10)		=	"Octubre"
		Meses(11)		=	"Noviembre"
		Meses(12)		=	"Diciembre"

		if len(mes)=1 then
			mm	=	"0" & mes
		else
			mm	=	mes
		end if

		for i = 1 to 12

			if len(i)= 1 then
				Num	=	"0" & i
			else
				Num	=	i
			end if

			if cint(mes) = i then
			Glosa	=	Meses(i)
			%>
				<option value="<%=Num%>" selected><%=ucase(Glosa)%></option>
			<%else%>
				<option value="<%=Num%>" ><%=ucase(Meses(i))%></option>
			<%end if
		next
end sub



sub CargaAno(ano)
	for i=1996 to 2010
		if cdbl(ano)=i then%>
		<option value="<%=cint(ano)%>" selected><%=i%></option>
		<%else%>
		<option value="<%=i%>" ><%=i%></option>					
		<%end if
	next

end sub

Function ArreglaSaltos(cadena)
	cadena = Replace(cadena,vbCrLf,"</p><p style=text-indent:30;text-align:justify>")
	ArreglaSaltos = cadena
End Function

function AgregaObservacion(obs, campo, tabla, campoid, valorid, conexion)

		obsActual = ""
		obsNueva = ""		
		set rsobs = Server.CreateObject("ADODB.Recordset")
				
		'recupero iniciales del usuario		
		sqlobsNueva = "select left("&g_nom_usu&",1) + left("&g_ape_pat_usu&",1) + left("&g_ape_mat_usu&",1) iniciales  from "&tbl_usu 
		sqlobsNueva = sqlobsNueva & " where "&c_usu&" = " &c_usu_log
		rsobs.open sqlobsNueva, conn_usu 		
		if not rsobs.eof then
			iniciales = ucase(rsobs("iniciales"))
		else
			iniciales = "(Intranet)"
		end if
		rsobs.close
	
		'recupero observacion actual		
		sqlobsActual = "SELECT p."&campo&" FROM "&tabla&" p WHERE p."&campoid&" = "&valorid
		rsobs.open sqlobsActual, conn	
		if not rsobs.eof then
			obsActual = rsobs(campo)
			if trim(obs) <> "" then
				obsActual = obsActual &"ææ"				
			end if
			obsNueva = obsActual
		end if
		rsobs.close
		
		if trim(obs) <> "" then		
			dd = Day(Date())
			mm = Month(Date())
			aaaa = Year(Date())
			hor = Hour(Now())
			min = Minute(Now())			
			dd = Right("0"&dd,2)
			mm = Right("0"&mm,2)
			hor = Right("0"&hor,2)
			min = Right("0"&min,2)			
			obsNueva = obsNueva&iniciales&": "&dd&"/"&mm&"/"&aaaa&" "&hor&":"&min&"æ"&obs		
		end if 'fin obs <> ""	
		
		'response.write obsNueva
		'response.End()
		
		AgregaObservacion = obsNueva	
end function

'jlm: rutina que recibe el string completo de la observacion y lo formatea dentro de una tabla
function MuestraObs(obs)
	
	tablaobs = ""
	if trim(obs) <> "" then 
		obs = replace(obs,chr(9),"")
		arrobs = split(obs,"ææ")

		for contobs = 0 to ubound(arrobs)
			if arrobs(contobs) <> "" then 
				lineaobs = split(arrobs(contobs),"æ")
				if ubound(lineaobs) >= 1 then
					tablaobs = tablaobs & "<div><font face=""verdana"" size=""1""><b>"&lineaobs(0)&"</b></font>&nbsp;<font face=""verdana"" size=""1"">"&lineaobs(1)&"</font></div>"
				else
					if trim(lineaobs(0)) <> "" then
						tablaobs = tablaobs & "<div><font face=""verdana"" size=""1""><b>&nbsp;</b></font>&nbsp;<font face=""verdana"" size=""1"">"&lineaobs(0)&"</font></div>"
					end if
				end if
			end if
		next
	end if
	
	MuestraObs = tablaobs
end function

sub UpInicializa()
	Set ObjUpload = Server.CreateObject("aspSmartUpload.SmartUpload")
	'jlm: lo ejecuto dentro de un on error ya que si se ejecuta sin haber realizado el post, se cae
	' luego quito el control de errores
	on error resume next
	ObjUpload.Upload
	on error goto 0
end sub

function UpValor(campo)
	UpValor = ObjUpload.Form(campo).values
end function

function UpValorArchivo(campo)
	UpValorArchivo = ObjUpload.Files(campo).Filename
end function

function borraarchivo(path_arc)
	set fso = Server.CreateObject("Scripting.FileSystemObject")
	If fso.FileExists(path_arc) Then
	   fso.DeleteFile path_arc, true
	End If 
'	Response.End()
end function 

function borradir(path_dir)
	set fso = Server.CreateObject("Scripting.FileSystemObject")
	If fso.FolderExists(path_dir) Then
	   fso.DeleteFolder path_dir, true
	End If 
	set fso = nothing
'	Response.End()
end function 

sub subearchivo(archivo, path_arc)
	'jlm: por si acaso viene con slash en vez de backslash
	path_arc = Replace(path_arc,"/","\")
	
	set fso = Server.CreateObject("Scripting.FileSystemObject")
	
	path_nombre_arc = path_arc & UpValorArchivo(archivo)
	'jlm: si el archivo existe, lo elimino
	if fso.FileExists(path_nombre_arc) then
		fso.DeleteFile(path_nombre_arc)
	end if

	if not fso.FolderExists(path_arc) then
		'jlm: si el directorio no existe, ejecuto ciclo para crear todo el path, en la medida de que no exista
		arr_dirs = split(path_arc, "\")
		path_arc = arr_dirs(0)
		for i = 1 to Ubound(arr_dirs)
			path_arc = path_arc & "\" & arr_dirs(i)
			if not fso.FolderExists(path_arc) then
				fso.CreateFolder(path_arc)
			end if
		next
	end if
	set fso = nothing
	
	ObjUpload.Save(path_arc)	
end sub

Function FormateaNumero(PNumeroAux)
'	Response.Write("llegue, mto:" & pNumeroAux)
	pNumero=PNumeroAux
	Dim rLArgo, rPos, rFormateaNumero, rFraccion, rEntero, rDecimal  
	pNumero = replace(pNumero,".",",")
	rLargo=len(PNumero) 
	rPos = Instr(PNumero, ",")   
	if rPos = 1 then
		FormateaNumero= "0" & PNumero
		exit function
	end if
	if rPos = 0 then
		rEntero=PNumero
		rDecimal=""
	else
		rEntero=Mid(PNumero,1,rPos - 1)
		rDecimal=Mid(PNumero,rPos,rLargo - rPos + 1)
	end if
	rFormateaNumero = rDecimal
	rLargo=len(rEntero) 
	if rLargo <= 3 then
		FormateaNumero=rEntero & rFormateaNumero
	else
		do while rLargo > 3 
			rFraccion = Mid(rEntero, rLargo - 2, 3)
			rFormateaNumero = "." & rFraccion & rFormateaNumero
			rLargo = rLargo - 3
		loop
		rFraccion = Mid(rEntero, 1, rLargo)
		FormateaNumero  =  rFraccion & rFormateaNumero
	end if
	if mid(FormateaNumero,1,1) = "." then
		FormateaNumero  = mid(FormateaNumero,2,len(FormateaNumero))
	else    
		if mid(FormateaNumero,1,1) = "-" and mid(FormateaNumero,2,1) = "." then
			FormateaNumero  = "-" & mid(FormateaNumero,3,len(FormateaNumero))
		end if
	end if
End function

%>

<script>
function solonumeros(){
	if(window.event.keyCode != 13 && (window.event.keyCode == 32 || window.event.keyCode > 57 || window.event.keyCode < 48)){
		window.event.keyCode = 0
	}
}
</script>