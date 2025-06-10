<%@  language="VBSCRIPT" codepage="1252" %>
<!--#include file ="ConexionIRIS.asp" -->


<%
	Dim ID_PERFIL_NUEVO_REAL 
	Set rst_BM3 = Server.CreateObject("ADODB.RecordSet")
	Set rst_BM33 = Server.CreateObject("ADODB.RecordSet")	
	Set rst_BM4 = Server.CreateObject("ADODB.RecordSet")	
	Set rst_BM5 = Server.CreateObject("ADODB.RecordSet")
	Set rst_BM6 = Server.CreateObject("ADODB.RecordSet")
	Set rst_BM_HORA = Server.CreateObject("ADODB.RecordSet")	
	Set rst_BM4_H = Server.CreateObject("ADODB.RecordSet")		
	oid_empresa = Request.querystring("id_cliente")	
    ID_PERFIL_NUEVO_REAL = Request.querystring("id_perfil")	 'Trim(ID_PERFIL_NUEVO_REAL1)
	
    'oid_empresa1 = Request.querystring("dato1") 
	'oid_empresa2 = Request.querystring("dato2") / 5
		
	'ID_PERFIL_NUEVO_REAL1 = Request.querystring("dato3")
	'ID_PERFIL_NUEVO_REAL2 = Request.querystring("dato4") / 5
	
	'IF Trim(oid_empresa1) = Trim(oid_empresa2) THEN
	'oid_empresa = Trim(oid_empresa1)
	'END IF

	'IF Trim(ID_PERFIL_NUEVO_REAL1) = Trim(ID_PERFIL_NUEVO_REAL2) THEN
	'ID_PERFIL_NUEVO_REAL = Trim(ID_PERFIL_NUEVO_REAL1)
	'END IF 
	
	'IF ID_USUARIO_WEB <> "" THEN
	'ELSE
	'	Session.Abandon()
	'	Response.Redirect("login_Nuevo.asp")	
	'END IF
	
    'ID_USUARIO_WEB =   Request.Cookies("Datos")("nombre") 
		
	'IF ID_USUARIO_WEB <> "" THEN
	'ELSE
	'Response.Redirect("../inicio.aspx")	
	'END IF
		
%>

<%
	Dim Filename
	Dim Pdf, Doc, Page
	'IRISLABWEB_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA
	Dim w_ID_PERFIL(50), w_IMP_SOLA(50), w_IMP_NOMBREPERF(50), w_Listo(50), w_ID_CF(50), w_NOMBRE_CF(50),cont_, contfinal,contLINEA_, w_SECC_DESC(50), w_USU_NIC(50), w_NOMBRE_USU(50),w_USU_ID(50), W_ANTIB(50),w_BAC_SI(50), w_IMP_NOMBREPERF_2(50), w_ID_PACw(50), w_ID_ATENw(50)
	
	Dim DATO_TITU, Activa_Linea_Resultado, w_SECC_DESC_WW, w_USU_NIC_WW, w_ID_ATENw2, w_ID_PACw2
	Id_atencion_ = oid_empresa '319 'session("ID_ATEN")
 	'Set rst_BM3 = connBM3.execute("IRISLABWEB_GRABA_IMPRESION_FOLIO '"&Id_atencion_&"', '"& ID_USUARIO_WEB &"'  ")	


 	Set rst_BM3 = connBM3.execute("IRISLABWEB_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA3 '"&Id_atencion_&"', '"& ID_PERFIL_NUEVO_REAL &"' ")	
	'Set rst_BM3 = connBM3.execute("IRISLABWEB_BUSCA_LISTADO_DE_EXAMENES_CODIGO_FONASA '"&Id_atencion_&"' ")	

	cont_ = 1
	w_SECC_DESC_WW =""
	WHILE NOT rst_BM3.eof
	     
	    w_ID_ATENw2 = Id_atencion_
	    w_ID_PACw2 =rst_BM3("ID_PACIENTE") 
	     
		w_ID_PERFIL(cont_) = rst_BM3("ID_PER") 
		
		w_ID_CF(cont_) = rst_BM3("ID_CODIGO_FONASA") 		
		w_IMP_SOLA(cont_) = rst_BM3("CF_IMP_SOLA") 		
		w_IMP_NOMBREPERF(cont_) = rst_BM3("CF_IMP_NOM_PER")
		
	    w_IMP_NOMBREPERF_2(cont_) = rst_BM3("PER_DESC")
		
		w_NOMBRE_CF(cont_) = rst_BM3("CF_DESC")		
		w_Listo(cont_)= rst_BM3("ATE_DET_IMPRIME") 
		w_SECC_DESC(cont_)= rst_BM3("SECC_DESC") 		
		w_USU_NIC(cont_)= rst_BM3("USU_NIC") 	
		w_NOMBRE_USU(cont_)= rst_BM3("USU_NOMBRE") & " " & rst_BM3("USU_APELLIDO")	
		w_USU_ID(cont_) = rst_BM3("ID_USUARIO")		
		w_BAC_SI(cont_)= rst_BM3("CF_CULTIVOS") 		
		IF  cont_  = 1 THEN
			w_USU_NIC_WW = w_USU_NIC(cont_)
		END IF		
		
		rst_BM3.MOVENEXT
		cont_ = cont_ + 1
	WEND		
	
	contLINEA_ = 1
	Activa_Linea_Resultado =0 
	CALL CREA_HOJA_OBJETOS
	call LLENA_MARCO_HOJA()
    Dim VNom, VApe, VFnac, VRut
	CALL LLENA_ENCABEZADO(1)			
	Dim CANTIDAD_REG  
	Dim w_ID_PRUEBA, w_ID_PER_P, w_ID_UM, w_UM, w_ResultadoA, w_ResultadoN, w_Rango_DESDE, w_Rango_HASTA, w_ID_TP_RESUL, Imprime_F, w_Nom_Seccion, w_TP_Alerta, w_TXT_EXTRA, w_FORMATON
	CANTIDAD_REG  =0 
	Imprime_F = 0
	FOR A__=0 TO CONT_
		IF 	w_ID_PERFIL(A__) <> "" THEN
			Set rst_BM3 = connBM3.execute("IRISLABWEB_GRABA_IMPRESION_FOLIO_WEB '"&w_ID_ATENw2&"', '"&w_ID_CF(A__)&"' ")
			Set rst_BM3 = connBM3.execute("IRISWEB_UPDATE_CANTIDAD_DE_IMPRESION_WEB_EXAMENES '"&w_ID_ATENw2&"', '"&w_ID_CF(A__)&"' ")	
			IF w_IMP_SOLA(A__) = 0 THEN
				IF Trim(w_USU_NIC(A__)) = Trim(w_USU_NIC_WW) THEN
					w_USU_NIC_WW  = w_USU_NIC(A__)  
							Id_atencion_ = oid_empresa '319 'session("ID_ATEN")
							Set rst_BM3 = connBM3.execute("IRISLABWEB_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN '"&Id_atencion_&"', '"&w_ID_CF(A__)&"' ")					
							WHILE NOT rst_BM3.eof
								CANTIDAD_REG = CANTIDAD_REG +1 
								rst_BM3.MOVENEXT
							WEND
							rst_BM3.MOVEFIRST
							'CALL LLENA_ENCABEZADO()
							IF contLINEA_ <> 1 THEN
								'contLINEA_ = contLINEA_ + 2
								CANTIDAD_REG= CANTIDAD_REG +2
							END IF
							IF contLINEA_ <= 1 THEN
								contLINEA_ = contLINEA_ 
								'CANTIDAD_REG= CANTIDAD_REG + 2
							END IF							
							IF w_IMP_NOMBREPERF(A__) =1 THEN
								'contLINEA_ = contLINEA_ + 3
							END IF				
							IF Activa_Linea_Resultado =0 THEN
								contLINEA_ = contLINEA_ + 2	
								cont_ = cont_ + 1									
							END IF					
			
							Dim AAAA_ 
							AAAA_ = CANTIDAD_REG + contLINEA_ 
							IF (CANTIDAD_REG + contLINEA_ ) < 50 THEN
								IF w_SECC_DESC(A__) <> w_SECC_DESC_WW THEN
									w_SECC_DESC_WW =  w_SECC_DESC(A__)
								'	CALL IMPRIME_TITULO_SECCION (w_SECC_DESC(A__),contLINEA_)					
									contLINEA_ = contLINEA_ + 2.5
								END IF
			
								IF w_IMP_NOMBREPERF(A__) = 1 THEN
									CALL IMPRIME_TITULO(w_IMP_NOMBREPERF_2(A__),contLINEA_)					
									contLINEA_ = contLINEA_ + 1
								END IF										
								
									call Imprime_Linea_Datos_Resultados(contLINEA_)	
									contLINEA_ = contLINEA_ + 1				
								NPRUEBA = 0
							
								WHILE NOT rst_BM3.eof
								
								   NPRUEBA = NPRUEBA + 1
									w_ID_PRUEBA = rst_BM3("ID_PRUEBA") 
									w_ID_PER_P = rst_BM3("ID_PER") 		
									w_ID_UM = rst_BM3("ID_U_MEDIDA")
									w_UM = rst_BM3("UM_DESC")					 		
									w_ResultadoA = rst_BM3("ATE_RESULTADO") 				
									w_ResultadoN = rst_BM3("ATE_RESULTADO_NUM") 				
									w_Rango_DESDE= rst_BM3("ATE_R_DESDE") 
									w_Rango_HASTA= rst_BM3("ATE_R_HASTA") 
									w_ID_TP_RESUL= rst_BM3("ID_TP_RESULTADO") 	
									w_Nom_Seccion= rst_BM3("SECC_DESC")
									w_FORMATON = rst_BM3("PRU_FORMATON")
									w_TXT_EXTRA = rst_BM3("ATE_RES_TEXTO_EXTRA")
									w_TP_Alerta = Trim(rst_BM3("ATE_RESULTADO_ALT"))
									w_EST_RECHAZO = rst_BM3("ATE_EST_RECHAZO")				
                                    contLINEA_ = contLINEA_ + 1
    		
									CALL IMPRIME_RESULTADO(NPRUEBA,w_ID_PRUEBA, w_ID_UM, w_UM, w_ResultadoA, w_ResultadoN, w_Rango_DESDE, w_Rango_HASTA, w_ID_TP_RESUL, contLINEA_, w_Nom_Seccion, w_TP_Alerta,w_FORMATON, w_TXT_EXTRA,w_EST_RECHAZO)										
									rst_BM3.MOVENEXT
									cont_ = cont_ + 1
									'contLINEA_ = contLINEA_ + 1
								WEND
                                CALL IMPRIME_FECHA_HOY(contLINEA_,w_ID_CF(A__),w_ID_PRUEBA)

								'IMPRIME METODO

								'CALL IMPRIME_METODO_DEBAJO(w_ID_PER_P, contLINEA_)
							'	CALL IMPRIME_TIPO_MUESTRA_DEBAJO (w_ID_PER_P, contLINEA_)
								CALL IMPRIME_DERIVADO_DEBAJO(w_ID_PER_P, contLINEA_)								
																		
								IF Imprime_F = 0 THEN
									'CALL IMPRIME_FIRMA_TECNOLOGO
                                    
									CALL IMPRIME_TIPO_MUESTRA_DEBAJO2(w_ID_PER_P, contLINEA_)
									CALL IMPRIME_FIRMA_TECNOLOGO_CON_USUARIO(w_USU_ID(A__))
									CALL IMPRIME_VALIDADO_POR(w_NOMBRE_CF(A__),42, w_NOMBRE_USU(A__))	
									Imprime_F = 1
								END IF
			
							ELSE
								Activa_Linea_Resultado =0
								Imprime_F = 0
								contLINEA_ = 1
			
								CALL AGREGA_NUEVA_HOJA	
								CALL LLENA_ENCABEZADO(w_ID_PERFIL(A__))
								call LLENA_MARCO_HOJA()															
								IF w_IMP_NOMBREPERF(A__) =1 THEN
									CALL IMPRIME_TITULO(w_IMP_NOMBREPERF_2(A__),contLINEA_)					
									contLINEA_ = contLINEA_ + 1
								END IF					
							
									call Imprime_Linea_Datos_Resultados(contLINEA_)	
									contLINEA_ = contLINEA_ + 1				
							     
								 NPRUEBA = 0
								 
								WHILE NOT rst_BM3.eof
								
								NPRUEBA = NPRUEBA + 1
								
									w_ID_PRUEBA = rst_BM3("ID_PRUEBA") 
									w_ID_PER_P = rst_BM3("ID_PER") 		
									w_ID_UM = rst_BM3("ID_U_MEDIDA")
									w_UM = rst_BM3("UM_DESC")					 		
									w_ResultadoA = rst_BM3("ATE_RESULTADO") 				
									w_ResultadoN = rst_BM3("ATE_RESULTADO_NUM") 				
									w_Rango_DESDE= rst_BM3("ATE_R_DESDE") 
									w_Rango_HASTA= rst_BM3("ATE_R_HASTA") 
									w_ID_TP_RESUL= rst_BM3("ID_TP_RESULTADO") 	
									w_Nom_Seccion= rst_BM3("SECC_DESC") 	
									w_FORMATON = rst_BM3("PRU_FORMATON")
									w_TXT_EXTRA = rst_BM3("ATE_RES_TEXTO_EXTRA")
									w_TP_Alerta = rst_BM3("ATE_RESULTADO_ALT") 																
									w_EST_RECHAZO = rst_BM3("ATE_EST_RECHAZO")
									CALL IMPRIME_RESULTADO(NPRUEBA,w_ID_PRUEBA, w_ID_UM, w_UM, w_ResultadoA, w_ResultadoN, w_Rango_DESDE, w_Rango_HASTA, w_ID_TP_RESUL, contLINEA_, w_Nom_Seccion, w_TP_Alerta,w_FORMATON, w_TXT_EXTRA,w_EST_RECHAZO)										
									rst_BM3.MOVENEXT
									cont_ = cont_ + 1
									contLINEA_ = contLINEA_ + 1
								WEND
    CALL IMPRIME_FECHA_HOY(contLINEA_,w_ID_CF(A__),w_ID_PRUEBA)

								'IMPRIME METODO
							'	CALL IMPRIME_METODO_DEBAJO(w_ID_PER_P, contLINEA_)
								'CALL IMPRIME_TIPO_MUESTRA_DEBAJO (w_ID_PER_P, contLINEA_)
								CALL IMPRIME_DERIVADO_DEBAJO(w_ID_PER_P, contLINEA_)
								
																								
								IF Imprime_F = 0 THEN
									'CALL IMPRIME_FIRMA_TECNOLOGO
									CALL IMPRIME_TIPO_MUESTRA_DEBAJO2(w_ID_PER_P, contLINEA_)
									CALL IMPRIME_FIRMA_TECNOLOGO_CON_USUARIO(w_USU_ID(A__))
									CALL IMPRIME_VALIDADO_POR(w_NOMBRE_CF(A__),42, w_NOMBRE_USU(A__))	
									Imprime_F = 1
								END IF
													
							END IF				
					ELSE
									
								w_USU_NIC_WW  = w_USU_NIC(A__)  					
								Activa_Linea_Resultado =0
								Imprime_F = 0
								contLINEA_ = 1
								
								CALL AGREGA_NUEVA_HOJA	
								
								CALL LLENA_ENCABEZADO(w_ID_PERFIL(A__))
								call LLENA_MARCO_HOJA()
								w_SECC_DESC_WW =""															

								IF w_SECC_DESC(A__) <> w_SECC_DESC_WW THEN
									w_SECC_DESC_WW =  w_SECC_DESC(A__)
									'CALL IMPRIME_TITULO_SECCION (w_SECC_DESC(A__),contLINEA_)					
									contLINEA_ = contLINEA_ + 1
								END IF

								IF w_IMP_NOMBREPERF(A__) =1 THEN
									CALL IMPRIME_TITULO(w_IMP_NOMBREPERF_2(A__),contLINEA_)					
									contLINEA_ = contLINEA_ + 1
								END IF					
							
									call Imprime_Linea_Datos_Resultados(contLINEA_)	
									'contLINEA_ = contLINEA_ + 1	

                                 NPRUEBA = 0									
						
								Set rst_BM3 = connBM3.execute("IRISLABWEB_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN '"&Id_atencion_&"', '"&w_ID_CF(A__)&"' ")													
								WHILE NOT rst_BM3.eof
								
								NPRUEBA = NPRUEBA +1 
									w_ID_PRUEBA = rst_BM3("ID_PRUEBA") 
									w_ID_PER_P = rst_BM3("ID_PER") 		
									w_ID_UM = rst_BM3("ID_U_MEDIDA")
									w_UM = rst_BM3("UM_DESC")					 		
									w_ResultadoA = rst_BM3("ATE_RESULTADO") 				
									w_ResultadoN = rst_BM3("ATE_RESULTADO_NUM") 				
									w_Rango_DESDE= rst_BM3("ATE_R_DESDE") 
									w_Rango_HASTA= rst_BM3("ATE_R_HASTA") 
									w_ID_TP_RESUL= rst_BM3("ID_TP_RESULTADO") 	
									w_Nom_Seccion= rst_BM3("SECC_DESC") 	
									w_TP_Alerta = rst_BM3("ATE_RESULTADO_ALT") 		
                                    w_EST_RECHAZO = rst_BM3("ATE_EST_RECHAZO")																							
									CALL IMPRIME_RESULTADO(NPRUEBA,w_ID_PRUEBA, w_ID_UM, w_UM, w_ResultadoA, w_ResultadoN, w_Rango_DESDE, w_Rango_HASTA, w_ID_TP_RESUL, contLINEA_, w_Nom_Seccion, w_TP_Alerta,w_EST_RECHAZO)										
									rst_BM3.MOVENEXT
									cont_ = cont_ + 1
									contLINEA_ = contLINEA_ + 1
								WEND
    CALL IMPRIME_FECHA_HOY(contLINEA_,w_ID_CF(A__),w_ID_PRUEBA)

								'IMPRIME METODO
								
								'CALL IMPRIME_METODO_DEBAJO(w_ID_PER_P, contLINEA_)
							'	CALL IMPRIME_TIPO_MUESTRA_DEBAJO (w_ID_PER_P, contLINEA_)
								CALL IMPRIME_DERIVADO_DEBAJO(w_ID_PER_P, contLINEA_)
								
								IF Imprime_F = 0 THEN
									'CALL IMPRIME_FIRMA_TECNOLOGO
									CALL IMPRIME_TIPO_MUESTRA_DEBAJO2(w_ID_PER_P, contLINEA_)
									CALL IMPRIME_FIRMA_TECNOLOGO_CON_USUARIO(w_USU_ID(A__))
									CALL IMPRIME_VALIDADO_POR(w_NOMBRE_CF(A__),42, w_NOMBRE_USU(A__))	
									Imprime_F = 1
								END IF																		
					END IF
			ELSE
				IF w_IMP_SOLA(A__) = 1 THEN
					Id_atencion_ = oid_empresa '319 'session("ID_ATEN")
					Set rst_BM3 = connBM3.execute("IRISLABWEB_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN '"&Id_atencion_&"', '"&w_ID_CF(A__)&"' ")					
					WHILE NOT rst_BM3.eof
						CANTIDAD_REG = CANTIDAD_REG +1 
						rst_BM3.MOVENEXT
					WEND
					IF CANTIDAD_REG <> 0 THEN
						Set rst_BM3 = connBM3.execute("IRISLABWEB_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN '"&Id_atencion_&"', '"&w_ID_CF(A__)&"' ")					
						'rst_BM3.MOVEFIRST
					END IF
					
					IF contLINEA_ <> 1 THEN
						contLINEA_ = contLINEA_ + 2
						CANTIDAD_REG= CANTIDAD_REG +2
					END IF
					IF w_IMP_NOMBREPERF(A__) =1 THEN
					END IF				
					IF Activa_Linea_Resultado =0 THEN
						cont_ = cont_ + 1									
					END IF					
					Activa_Linea_Resultado =0					
					contLINEA_ = 1				
					IF CLng(A__) <> 1 THEN
						CALL AGREGA_NUEVA_HOJA	
						CALL LLENA_ENCABEZADO(w_ID_PERFIL(A__))	
						call LLENA_MARCO_HOJA()															
					END IF

					IF w_SECC_DESC(A__) <> w_SECC_DESC_WW THEN
						w_SECC_DESC_WW =  w_SECC_DESC(A__)
						'CALL IMPRIME_TITULO_SECCION(w_SECC_DESC(A__),contLINEA_)					
						contLINEA_ = contLINEA_ + 1
					END IF
					
					IF w_IMP_NOMBREPERF(A__) =1 THEN
						CALL IMPRIME_TITULO_1H(w_IMP_NOMBREPERF_2(A__),contLINEA_)
                        CALL Imprime_Linea_Datos_Resultados(contLINEA_)
						contLINEA_ = contLINEA_ + 1
    ELSE
    CALL Imprime_Linea_Datos_Resultados(contLINEA_)
					END IF					
					'contLINEA_=5
					
					act_nuevo_firma =false
					WHILE NOT rst_BM3.eof
						w_ID_PRUEBA = rst_BM3("ID_PRUEBA") 
						w_ID_PER_P = rst_BM3("ID_PER") 		
						w_ID_UM = rst_BM3("ID_U_MEDIDA")
						w_UM = rst_BM3("UM_DESC")					 		
						w_ResultadoA = rst_BM3("ATE_RESULTADO") 				
						w_ResultadoN = rst_BM3("ATE_RESULTADO_NUM") 				
						w_Rango_DESDE= rst_BM3("ATE_R_DESDE") 
						w_Rango_HASTA= rst_BM3("ATE_R_HASTA") 
						w_ID_TP_RESUL= rst_BM3("ID_TP_RESULTADO") 	
						w_Nom_Seccion= rst_BM3("SECC_DESC") 	
						w_FORMATON = rst_BM3("PRU_FORMATON")
						w_TP_Alerta = Trim(rst_BM3("ATE_RESULTADO_ALT")) 
                        w_EST_RECHAZO = rst_BM3("ATE_EST_RECHAZO")																									
						'CALL IMPRIME_TIPO_MUESTRA_DEBAJO2 (w_ID_PER_P, contLINEA_)
						CALL IMPRIME_RESULTADO_NUEVO(w_ID_PRUEBA, w_ID_UM, w_UM, w_ResultadoA, w_ResultadoN, w_Rango_DESDE, w_Rango_HASTA, w_ID_TP_RESUL, contLINEA_, w_Nom_Seccion, w_TP_Alerta, w_FORMATON,w_EST_RECHAZO)										
						rst_BM3.MOVENEXT
						cont_ = cont_ + 1
						'contLINEA_  =0
                        if w_ResultadoA <> "-" then
                            contLINEA_ = contLINEA_ +1.5
                        else
                            contLINEA_ = contLINEA_ +1.5
                        end if
						
						act_nuevo_firma =true
					WEND
					CALL IMPRIME_FECHA_HOY(contLINEA_,w_ID_CF(A__),w_ID_PRUEBA)

    CALL IMPRIME_DERIVADO_DEBAJO(w_ID_PER_P, contLINEA_)

					IF w_BAC_SI(A__) <> "" THEN
						IF w_BAC_SI(A__) = "1" THEN
						
        


							Set rst_BM3 = connBM3.execute("IRIS_BUSCA_CULTIVO_POR_ID_CF_ORDENADOS  '"&w_ID_CF(A__)&"','"&Id_atencion_&"' ")		
							CANTIDAD_ANT = 0
							IF not rst_BM3.eof THEN
					           'by Drap		
								MAXXX_YY =  session("anti") - 15
					        END IF
					        Dim antib
					        antib = 0
							WHILE NOT rst_BM3.eof							
								CANTIDAD_ANT = CLng(CANTIDAD_ANT) + 1 
								CF_ID = rst_BM3("ID_CF_ANTIBIOGRAMA") 
								IF CLng(CANTIDAD_ANT) = 1 THEN
									XXX_VV = MAXXX_XX
									YYY_VV = MAXXX_YY - 25
									FILAMAXX_VV = MAXXX_YY -15
									CEPA__ =  CANTIDAD_ANT
								END IF
								IF CLng(CANTIDAD_ANT) = 2 THEN
									XXX_VV = MAXXX_XX + 200
									YYY_VV = MAXXX_YY - 25
									FILAMAXX_VV = MAXXX_YY -15									
									CEPA__ =  CANTIDAD_ANT									
								END IF

								IF CLng(CANTIDAD_ANT) =3 THEN
									
									XXX_VV = MAXXX_XX + 395
									YYY_VV = MAXXX_YY - 25
									FILAMAXX_VV = MAXXX_YY -15
									CEPA__ =  CANTIDAD_ANT									
								END IF
								ID_DET_ATE = rst_BM3("ID_DET_ATE")
								ID_ATEVV_ = Id_atencion_
								IF isnull(ID_DET_ATE) THEN
								ELSE
								Set Font = Doc.Fonts("Arial")
								CALL LLAMA_IMPRESION_ANTIBIOGRAMA(CF_ID, ID_ATEVV_ ,FILAMAXX_VV, XXX_VV, YYY_VV, CEPA__,ID_DET_ATE )
								END IF
                                
								rst_BM3.MOVENEXT
							WEND	
    '//////////////////////////////////
                            IF rst_BM3.eof THEN

    Set rst_BM3= connBM3.execute("IRIS_BUSCA_ID_CF_LINK_ANTIBIOGRAMA '"&w_ID_PER_P&"' ")

							CANTIDAD_ANT = 0
							IF not rst_BM3.eof THEN
					          
								MAXXX_YY =  session("anti") - 15
					        END IF
					        
					        antib = 0
							WHILE NOT rst_BM3.eof							
								CANTIDAD_ANT = CLng(CANTIDAD_ANT) + 1 
								CF_ID = rst_BM3("Id_Antibiograma") 
								IF CLng(CANTIDAD_ANT) = 1 THEN
									XXX_VV = MAXXX_XX
									YYY_VV = MAXXX_YY - 25
									FILAMAXX_VV = MAXXX_YY -15
									CEPA__ =  CANTIDAD_ANT
								END IF
								IF CLng(CANTIDAD_ANT) = 2 THEN
									XXX_VV = MAXXX_XX + 200
									YYY_VV = MAXXX_YY - 25
									FILAMAXX_VV = MAXXX_YY -15									
									CEPA__ =  CANTIDAD_ANT									
								END IF

								IF CLng(CANTIDAD_ANT) =3 THEN
									
									XXX_VV = MAXXX_XX + 395
									YYY_VV = MAXXX_YY - 25
									FILAMAXX_VV = MAXXX_YY -15
									CEPA__ =  CANTIDAD_ANT									
								END IF
								ID_DET_ATE = "null"
								ID_ATEVV_ = Id_atencion_
								IF isnull(ID_DET_ATE) THEN
								ELSE
								Set Font = Doc.Fonts("Arial")

    

								CALL LLAMA_IMPRESION_ANTIBIOGRAMA(CF_ID, ID_ATEVV_ ,FILAMAXX_VV, XXX_VV, YYY_VV, CEPA__,"null" )
								END IF
                                
								rst_BM3.MOVENEXT
							WEND	
                            END IF 	
						END IF
					END IF
					
					CALL IMPRIME_METODO_DEBAJO_4(w_ID_PER_P, contLINEA_)
					CALL IMPRIME_TIPO_MUESTRA_DEBAJO3(w_ID_PER_P, contLINEA_)
					
					
					IF act_nuevo_firma = true THEN
						IF A__ >2 THEN
							CALL IMPRIME_FIRMA_TECNOLOGO_CON_USUARIO(w_USU_ID(A__ - 2))
							CALL IMPRIME_VALIDADO_POR(w_NOMBRE_CF(A__),42, w_NOMBRE_USU(A__ - 2))
						END IF
					END IF										
				END IF
			END IF		
		END IF
	NEXT		
	CALL IMPRIME_ULTIMA_LINEA

	'CALL IMPRIME_FIRMA_TECNOLOGO
	CALL IMPRIME_FIRMA_TECNOLOGO_CON_USUARIO(w_USU_ID(A__ - 2))	
	CALL IMPRIME_VALIDADO_POR(w_NOMBRE_CF(A__),42, w_NOMBRE_USU(A__ - 2))					
	
	CALL Imprime_Hoja
	
%>
<html>
<head>
    <title>.:::Impresion de Resultados:::.</title>
</head>
<body>

    <script language="JavaScript">
        document.location.href = "<%= "../PDF/"+ Filename%>" ;
    </script>
</body>
</html>

<%
FUNCTION LLAMA_IMPRESION_ANTIBIOGRAMA(CF_ID, ID_ATEVV_ ,FILAMAXX_VV, XXX_VVV, YYY_VV, CEPA__, ID_DET_ATE)   
    

     
Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
    IF ID_DET_ATE = "null" THEN
    Set rst_BM_HORA = connBM3.execute("IRIS_BUSCA_RESULTADO_DE_ANTIBIOGRAMAS_IMPRESION2  '"&CLng(CF_ID)&"', '"&CLng(ID_ATEVV_)&"' ")	
    ELSE
    Set rst_BM_HORA = connBM3.execute("IRIS_BUSCA_RESULTADO_DE_ANTIBIOGRAMAS_IMPRESION  '"&CF_ID&"', '"&ID_ATEVV_&"','"&ID_DET_ATE&"' ")		
    END IF
    CANTIDAD_ANT2 =0

WHILE NOT rst_BM_HORA.eof
    FILAMAXX_VV=FILAMAXX_VV-10
    IF antib = 0 THEN 
    antib = antib + 1
    								
	Set Params = Pdf.CreateParam	
	Params("x") = 10	
	Params("y") = MAXXX_YY-30 
    Params("size") = 8	
	Page.Canvas.DrawText "___________________________________________________________________________________________________________________________________", Params, Font
		                           
	MAXXX_YY =  MAXXX_YY - 10
	Set Font = Doc.Fonts("Helvetica-Bold")
	Set Params = Pdf.CreateParam	
	Params("x") = 30
	Params("y") = MAXXX_YY-35
	Params("size") = 8
	Page.Canvas.DrawText "ANTIBIOGRAMA", Params, Font
	MAXXX_YY = MAXXX_YY + 10
	 END IF 

	CANTIDAD_ANT2 = CANTIDAD_ANT2 +1 
	NOMBRE_TEST_VV = rst_BM_HORA("PRU_DESC") 
	RESULT_TEST_VV = rst_BM_HORA("ATE_RESULTADO") 	
    
    NOMBRE_TEST_VV = Replace(NOMBRE_TEST_VV,":","")

		FR_TEXTO_ = NOMBRE_TEST_VV
        Set Font = Doc.Fonts("Helvetica-Bold")
		Params("x") = XXX_VVV	+ 30
		Params("y") = (FILAMAXX_VV)-30 - ( CANTIDAD_ANT2 *2)
		Params("size") = 6.5
		Page.Canvas.DrawText FR_TEXTO_, Params, Font							

    FR_TEXTO_ = RESULT_TEST_VV
    '/////
    IF(Len(FR_TEXTO_) > 30) THEN
    ArrRes = Split(FR_TEXTO_," ")

    Dim mitad, res1, res2, res3
    mitad = UBound(ArrRes) /4
    mitad = Int(mitad)

    For y = 0 to mitad
	res1 = res1&" "&ArrRes(y)
    Next

    Set Font = Doc.Fonts("Arial")
    IF CANTIDAD_ANT =3 THEN
        Params("x") = XXX_VVV +  130
    ELSE
        Params("x") = XXX_VVV +  150
    END IF

    Params("y") = (FILAMAXX_VV)-30 - ( CANTIDAD_ANT2 *2)
		Params("size") = 6.5
		Page.Canvas.DrawText res1, Params, Font		

    For y = mitad+1 to UBound(ArrRes)
	res2 = res2&" "&ArrRes(y)
    Next 
   
        Params("x") = XXX_VVV	+ 30
        Params("y") = (FILAMAXX_VV)-37 - ( CANTIDAD_ANT2 *2)
		Params("size") = 6.5
		Page.Canvas.DrawText res2, Params, Font		
        'contfinal = 1
    ELSE

    Set Font = Doc.Fonts("Arial")
        IF CANTIDAD_ANT =3 THEN
            Params("x") = XXX_VVV +  130
        ELSE
            Params("x") = XXX_VVV +  150
        END IF
            Params("y") = (((FILAMAXX_VV)-30) - ( CANTIDAD_ANT2 *2))
		    Params("size") = 6.5
		    Page.Canvas.DrawText FR_TEXTO_, Params, Font	
   
    END IF
    '/////


		
        					
			
	'END IF
	contLINEA_=contLINEA_+2
	rst_BM_HORA.MOVENEXT
WEND
    
END FUNCTION

FUNCTION IMPRIME_ULTIMA_LINEA

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	contLINEA_ = 49
	XX =  10
	YY = 680   - (contLINEA_ * 10)		
	Params("x") = XX	
	Params("y") = YY
	Params("size") = 9
	'Page.Canvas.DrawText "Resultado", Params, Font
END FUNCTION


Function Imprime_Linea_Datos_Resultados(contLINEA_)

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	

	XX =  30
	YY = 640
	Params("x") = XX	
	Params("y") = YY 
	Params("size") = 7
	Page.Canvas.DrawText "Examen", Params, Font

	XX =  145
	YY = 640	
	Params("x") = XX	
	Params("y") = YY 
	Params("size") = 7
	Page.Canvas.DrawText "Resultado", Params, Font

	XX =  240
	YY = 640	
	Params("x") = XX	
	Params("y") = YY 
	Params("size") = 7
	Page.Canvas.DrawText "Unidad", Params, Font
	
	XX =  300
	YY = 640		
	Params("x") = XX	
	Params("y") = YY 
	Params("size") = 7
	Page.Canvas.DrawText "Valor de Referencia", Params, Font
	
	'XX =  335
	'YY = 640		
	'Params("x") = XX	
	'Params("y") = YY 
	'Params("size") = 7
	'Page.Canvas.DrawText "(Según Sexo y Edad)", Params, Font

	XX =  400
	YY = 640		
	Params("x") = XX	
	Params("y") = YY
	Params("size") = 7
	Page.Canvas.DrawText "Método", Params, Font

    'XX =  480
	'YY = 640		
	'Params("x") = XX	
	'Params("y") = YY
	'Params("size") = 7
	'Page.Canvas.DrawText "Fecha Histo", Params, Font

    'XX =  550
	'YY = 640		
	'Params("x") = XX	
	'Params("y") = YY
	'Params("size") = 7
	'Page.Canvas.DrawText "Result. Histo", Params, Font


end function



FUNCTION IMPRIME_TITULO(DATO_TITU, NLINEA)
'Response.Write("<script>alert('TITULO 1');</script>")
'Response.Write("<script>alert('"&DATO_TITU&"');</script>")	
	Set Font = Doc.Fonts("Helvetica-Bold")
	Set Params = Pdf.CreateParam	
	CANT_LEN = LEN(DATO_TITU)
	CANT_LEN2 = CANT_LEN / 2
	Width_ =  500 / 2	
	XX =  30
	YY =595 
	Params("x") = XX	
	Params("y") = YY
	Params("size") = 8
    IF DATO_TITU = "VIH"  or DATO_TITU = "Test VIH" THEN
    FR_TEXTO_= VNom&VApe&VFnac&VRut
    END IF
	Page.Canvas.DrawText DATO_TITU, Params, Font
    contLinea_ = contLinea_ +1
END FUNCTION

FUNCTION IMPRIME_TITULO_NUEVO(DATO_TITU, NLINEA)

'Response.Write("<script>alert('TITULO 2');</script>")
'Response.Write("<script>alert('"&DATO_TITU&"');</script>")

	'NLINEA= NLINEA - 2
	NLINEA= NLINEA 
	RUTA_ ="c:\windows\fonts\arialbd.ttf" 											
	Set Font = Doc.Fonts.LoadFromFile(RUTA_)
	
	Set Params = Pdf.CreateParam	
	CANT_LEN = LEN(DATO_TITU)
	CANT_LEN2 = CANT_LEN / 2
	Width_ =  500 / 2	
	XX =  20
	YY = 680  - (NLINEA * 11)
	Params("x") = XX	
	Params("y") = YY
	Params("size") = 12
    IF DATO_TITU = "VIH"  or DATO_TITU = "Test VIH" THEN
    FR_TEXTO_= VNom&VApe&VFnac&VRut
    END IF
	Page.Canvas.DrawText DATO_TITU, Params, Font
     contLinea_ = contLinea_ +1
END FUNCTION

FUNCTION IMPRIME_TITULO_1H(DATO_TITU, NLINEA)


	'NLINEA= NLINEA - 2
	NLINEA= NLINEA 
	'RUTA_ ="c:\windows\fonts\arialbd.ttf" 											
	'Set Font = Doc.Fonts.LoadFromFile(RUTA_)
	Set Font = Doc.Fonts("Helvetica-Bold")
	Set Params = Pdf.CreateParam	
	'CANT_LEN = LEN(DATO_TITU)
	'CANT_LEN2 = CANT_LEN / 2
	'Width_ =  400 / 2	
	'Params("x") = 250	

	CANT_LEN = LEN(Trim(DATO_TITU))
	CANT_LEN2 = CANT_LEN / 2
	Width_ =  500 / 2	
	XX =  30
	YY =620 
	Params("x") = XX	
	Params("y") = YY
	Params("size") = 8
    IF DATO_TITU = "VIH"  or DATO_TITU = "Test VIH" THEN
    FR_TEXTO_= VNom&VApe&VFnac&VRut
    END IF
	Page.Canvas.DrawText DATO_TITU, Params, Font
	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 10	
	Params("y") = 635
	Params("size") = 8	
	Page.Canvas.DrawText "___________________________________________________________________________________________________________________________________", Params, Font
    contLinea_ = contLinea_ +3
END FUNCTION


FUNCTION IMPRIME_VALIDADO_POR(DATO_TITU, NLINEA, NOM_VALIDA)
	Dim Datos_COMPLETO

	RUTA_ ="c:\windows\fonts\arial.ttf" 											
	Set Font = Doc.Fonts.LoadFromFile(RUTA_)
	Datos_COMPLETO = "Examen(es) Validado Por: " &  NOM_VALIDA
	Set Params = Pdf.CreateParam	
	Width_ =  500 / 2	
	XX =  17
	YY = 680  - (NLINEA * 11)
	YY = 80
	
	Params("x") = XX	
	Params("y") = YY
	Params("size") = 9
	'Page.Canvas.DrawText Datos_COMPLETO, Params, Font

END FUNCTION

FUNCTION IMPRIME_METODO_DEBAJO(WID_PERFIL, contLINEA_)
	Dim Datos_COMPLETO
	Set rst_BM33 = connBM3.execute("IRISLABWEB_BUSCA_METODO_NUEVO '"&WID_PERFIL&"' ")													
	BBBC =0
	WHILE NOT rst_BM33.eof
		BBBC = BBBC+1 
		rst_BM33.MOVENEXT
	WEND
	
	IF BBBC>0 THEN
		rst_BM33.MOVEFIRST
	END IF
	BBBC_1 =0
	contLINEA_ = contLINEA_ + 1.5
	w_METODO_NUEVO =""
	WHILE NOT rst_BM33.eof
		IF BBBC_1 =0 THEN
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.Item("Helvetica-Oblique")
			w_METODO_NUEVO = rst_BM33("METO_DESC") 
			Datos_COMPLETO =     w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  470
			YY = contLINEA_ 
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 6
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_ = contLINEA_ + 1
		ELSE
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.Item("Helvetica-Oblique")
			w_METODO_NUEVO = rst_BM33("METO_DESC") 
			Datos_COMPLETO =   w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX = 470
			YY = 700  - (contLINEA_ * 11)
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 6
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_ = contLINEA_ + 1		
		END IF
		rst_BM33.MOVENEXT
	wend
	
END FUNCTION

FUNCTION IMPRIME_METODO_DEBAJO_3(w_ID_PRUEBA, contLINEA_)
  	Dim Datos_COMPLETO
	Set rst_BM33 = connBM3.execute("IRISLABWEB_BUSCA_METODO_NUEVO_3 '"&w_ID_PRUEBA&"' ")													
	BBBC =0
	WHILE NOT rst_BM33.eof
		BBBC = BBBC+1 
		rst_BM33.MOVENEXT
	WEND
	
	IF BBBC>0 THEN
		rst_BM33.MOVEFIRST
	END IF
	BBBC_1 =0
	contLINEA_ = contLINEA_ + 1.5
	w_METODO_NUEVO =""
	WHILE NOT rst_BM33.eof
	
		IF BBBC_1 =0 THEN
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.Item("Helvetica-Oblique")
			w_METODO_NUEVO = rst_BM33("METO_DESC") 
			Datos_COMPLETO =     w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			 XX = 400
			Params("x") = XX
			 YY = 670   - (contLINEA_ * 11)_ 
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 6
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_ = contLINEA_ + 1
		ELSE
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.Item("Helvetica-Oblique")
			w_METODO_NUEVO = rst_BM33("METO_DESC") 
			Datos_COMPLETO =   w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			 XX = 400
			Params("x") = XX
			 YY = 670   - (contLINEA_ * 11)_ 
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 6
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_ = contLINEA_ + 1		
		END IF
		rst_BM33.MOVENEXT
	wend
	
END FUNCTION





FUNCTION IMPRIME_METODO_DEBAJO_2(WID_PERFIL, contLINEA_)
	Dim Datos_COMPLETO
	Set rst_BM33 = connBM3.execute("IRISLABWEB_BUSCA_METODO_NUEVO '"&WID_PERFIL&"' ")													
	BBBC =0
	WHILE NOT rst_BM33.eof
		BBBC = BBBC+1 
		rst_BM33.MOVENEXT
	WEND
	
	IF BBBC>0 THEN
		rst_BM33.MOVEFIRST
	END IF
	BBBC_1 =0
	contLINEA_ = contLINEA_ + 1.5
	w_METODO_NUEVO =""
	WHILE NOT rst_BM33.eof
		IF BBBC_1 =0 THEN
			RUTA_ ="c:\windows\fonts\arial.ttf" 
			Set Font = Doc.Fonts.Item("Helvetica-Oblique")										
			'Set Font = Doc.Fonts.LoadFromFile(RUTA_)
			w_METODO_NUEVO = rst_BM33("METO_DESC") 
			Datos_COMPLETO = "Método Analítico : " &w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  17
			YY = 120-(contLINEA_*10)
			'YY = 80			
			Params("x") = 30	
			Params("y") = YY
			Params("size") = 6
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_ = contLINEA_ + 1
		ELSE
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			'Set Font = Doc.Fonts.LoadFromFile(RUTA_)
			Set Font = DDoc.Fonts.Item("Helvetica-Oblique")
			w_METODO_NUEVO = rst_BM33("METO_DESC") 
			Datos_COMPLETO =         w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  17
			YY = 94
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 6
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_ = contLINEA_ + 1		
		END IF
		rst_BM33.MOVENEXT
	wend
	
END FUNCTION


FUNCTION IMPRIME_TIPO_MUESTRA_DEBAJO2(WID_PERFIL, contLINEA_)
	Dim Datos_COMPLETO
	Set rst_BM33 = connBM3.execute("IRISLABWEB_BUSCA_TIPO_DE_MUESTRA_ID_PER '"&WID_PERFIL&"' ")	
	Set rst_BM333 = connBM3.execute("IRISLABWEB_BUSCA_ANALIZADOR_ID_PER '"&WID_PERFIL&"' ")												
	BBBC =0
	WHILE NOT rst_BM33.eof
		BBBC = BBBC+1 
		rst_BM33.MOVENEXT
	WEND
	
	IF BBBC>0 THEN
		rst_BM33.MOVEFIRST
	END IF
	BBBC_1 =0
	contLINEA_ = contLINEA_ + 0.25
	w_METODO_NUEVO =""
    IF(w_IMP_SOLA(1) = 0) THEN
    WHILE NOT rst_BM33.eof
		IF BBBC_1 =0 THEN
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.Item("Helvetica-Oblique")
			w_METODO_NUEVO = rst_BM33("MUESTRA_SANGRE_DESC") 
		    	
			Datos_COMPLETO = "Tipo de Muestra : " &  w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  30
			YY = 623
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 6
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			
		
			'contLINEA_ = contLINEA_ + 0.25
		ELSE
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts("Arial")
			w_METODO_NUEVO = rst_BM33("MUESTRA_SANGRE_DESC") 
			Datos_COMPLETO = "                   " &  w_METODO_NUEVO
			
			Set Params = Pdf.CreateParam	
			XX =  30
			YY = 625
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 6
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			
			
			'contLINEA_ = contLINEA_ + 0.05	
		END IF
		rst_BM33.MOVENEXT	
	wend
	
	WHILE NOT rst_BM333.eof
		IF BBBC_1 =0 THEN
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.Item("Helvetica-Oblique")
			w_ANALIZADOR_NUEVO = rst_BM333("ANAL_DESC") 

	        Set Params = Pdf.CreateParam	
			XX =  30
			YY = 610
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 6
			Page.Canvas.DrawText w_ANALIZADOR_NUEVO, Params, Font
			'contLINEA_ = contLINEA_ + 0.25
		ELSE
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.Item("Helvetica-Oblique")
			w_ANALIZADOR_NUEVO = rst_BM333("ANAL_DESC") 

	        Set Params = Pdf.CreateParam	
			XX =  30
			YY = 610
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 6
			Page.Canvas.DrawText w_ANALIZADOR_NUEVO, Params, Font
			
			
			'contLINEA_ = contLINEA_ + 0.05	
		END IF
		rst_BM333.MOVENEXT
		
		
	wend
    ELSE
    'ELSE
    WHILE NOT rst_BM33.eof
		IF BBBC_1 =0 THEN
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.Item("Helvetica-Oblique")
			w_METODO_NUEVO = rst_BM33("MUESTRA_SANGRE_DESC") 
		    	
			Datos_COMPLETO = "Tipo de Muestra : " &  w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  30
			YY = 115
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 6
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			
		
			'contLINEA_ = contLINEA_ + 0.25
		ELSE
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts("Arial")
			w_METODO_NUEVO = rst_BM33("MUESTRA_SANGRE_DESC") 
			Datos_COMPLETO = "                   " &  w_METODO_NUEVO
			
			Set Params = Pdf.CreateParam	
			XX =  30
			YY = 115
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 6
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			
			
			'contLINEA_ = contLINEA_ + 0.05	
		END IF
		rst_BM33.MOVENEXT	
	wend
	
	WHILE NOT rst_BM333.eof
		IF BBBC_1 =0 THEN
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.Item("Helvetica-Oblique")
			w_ANALIZADOR_NUEVO = rst_BM333("ANAL_DESC") 

	        Set Params = Pdf.CreateParam	
			XX =  30
			YY = 105
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 6
			Page.Canvas.DrawText w_ANALIZADOR_NUEVO, Params, Font
			'contLINEA_ = contLINEA_ + 0.25
		ELSE
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.Item("Helvetica-Oblique")
			w_ANALIZADOR_NUEVO = rst_BM333("ANAL_DESC") 

	        Set Params = Pdf.CreateParam	
			XX =  30
			YY = 105
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 6
			Page.Canvas.DrawText w_ANALIZADOR_NUEVO, Params, Font
			
			
			'contLINEA_ = contLINEA_ + 0.05	
		END IF
		rst_BM333.MOVENEXT
		
		
	wend
    END IF
	
	
END FUNCTION

FUNCTION IMPRIME_TIPO_MUESTRA_DEBAJO3(WID_PERFIL, contLINEA_)
	Dim Datos_COMPLETO
	Set rst_BM33 = connBM3.execute("IRISLABWEB_BUSCA_TIPO_DE_MUESTRA_ID_PER '"&WID_PERFIL&"' ")	
	Set rst_BM333 = connBM3.execute("IRISLABWEB_BUSCA_ANALIZADOR_ID_PER '"&WID_PERFIL&"' ")												
	BBBC =0
	WHILE NOT rst_BM33.eof
		BBBC = BBBC+1 
		rst_BM33.MOVENEXT
	WEND
	
	IF BBBC>0 THEN
		rst_BM33.MOVEFIRST
	END IF
	BBBC_1 =0
	contLINEA_ = contLINEA_ + 0.25
	w_METODO_NUEVO =""
    IF(w_IMP_SOLA(1) = 0) THEN
    WHILE NOT rst_BM33.eof
		IF BBBC_1 =0 THEN
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.Item("Helvetica-Oblique")
			w_METODO_NUEVO = rst_BM33("MUESTRA_SANGRE_DESC") 
		    	
			Datos_COMPLETO = "Tipo de Muestra : " &  w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  30
			YY = 100
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY-20
			Params("size") = 6
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			
		
			'contLINEA_ = contLINEA_ + 0.25
		ELSE
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts("Arial")
			w_METODO_NUEVO = rst_BM33("MUESTRA_SANGRE_DESC") 
			Datos_COMPLETO = "                   " &  w_METODO_NUEVO
			
			Set Params = Pdf.CreateParam	
			XX =  30
			YY = 100
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY-20
			Params("size") = 6
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			
			
			'contLINEA_ = contLINEA_ + 0.05	
		END IF
		rst_BM33.MOVENEXT	
	wend
	
	WHILE NOT rst_BM333.eof
		IF BBBC_1 =0 THEN
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.Item("Helvetica-Oblique")
			w_ANALIZADOR_NUEVO = rst_BM333("ANAL_DESC") 

	        Set Params = Pdf.CreateParam	
			XX =  30
			YY = 610
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY-20
			Params("size") = 6
			Page.Canvas.DrawText w_ANALIZADOR_NUEVO, Params, Font
			'contLINEA_ = contLINEA_ + 0.25
		ELSE
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.Item("Helvetica-Oblique")
			w_ANALIZADOR_NUEVO = rst_BM333("ANAL_DESC") 

	        Set Params = Pdf.CreateParam	
			XX =  30
			YY = 610
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY-20
			Params("size") = 6
			Page.Canvas.DrawText w_ANALIZADOR_NUEVO, Params, Font
			
			
			'contLINEA_ = contLINEA_ + 0.05	
		END IF
		rst_BM333.MOVENEXT
		
		
	wend
    ELSE
    'ELSE
    WHILE NOT rst_BM33.eof
		IF BBBC_1 =0 THEN
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.Item("Helvetica-Oblique")
			w_METODO_NUEVO = rst_BM33("MUESTRA_SANGRE_DESC") 
		    	
			Datos_COMPLETO = "Tipo de Muestra : " &  w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  30
			YY = 115
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY-20
			Params("size") = 6
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			
		
			'contLINEA_ = contLINEA_ + 0.25
		ELSE
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts("Arial")
			w_METODO_NUEVO = rst_BM33("MUESTRA_SANGRE_DESC") 
			Datos_COMPLETO = "                   " &  w_METODO_NUEVO
			
			Set Params = Pdf.CreateParam	
			XX =  30
			YY = 115
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY-20
			Params("size") = 6
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			
			
			'contLINEA_ = contLINEA_ + 0.05	
		END IF
		rst_BM33.MOVENEXT	
	wend
	
	WHILE NOT rst_BM333.eof
		IF BBBC_1 =0 THEN
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.Item("Helvetica-Oblique")
			w_ANALIZADOR_NUEVO = rst_BM333("ANAL_DESC") 

	        Set Params = Pdf.CreateParam	
			XX =  30
			YY = 105
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY-20
			Params("size") = 6
			Page.Canvas.DrawText w_ANALIZADOR_NUEVO, Params, Font
			'contLINEA_ = contLINEA_ + 0.25
		ELSE
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.Item("Helvetica-Oblique")
			w_ANALIZADOR_NUEVO = rst_BM333("ANAL_DESC") 

	        Set Params = Pdf.CreateParam	
			XX =  30
			YY = 105
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY-20
			Params("size") = 6
			Page.Canvas.DrawText w_ANALIZADOR_NUEVO, Params, Font
			
			
			'contLINEA_ = contLINEA_ + 0.05	
		END IF
		rst_BM333.MOVENEXT
		
		
	wend
    END IF
	
	
END FUNCTION


FUNCTION IMPRIME_TIPO_MUESTRA_DEBAJO(WID_PERFIL, contLINEA_)
	Dim Datos_COMPLETO
	Set rst_BM33 = connBM3.execute("IRISLABWEB_BUSCA_TIPO_DE_MUESTRA_ID_PER '"&WID_PERFIL&"' ")													
	BBBC =0
	WHILE NOT rst_BM33.eof
		BBBC = BBBC+1 
		rst_BM33.MOVENEXT
	WEND
	
	IF BBBC>0 THEN
		rst_BM33.MOVEFIRST
	END IF
	BBBC_1 =0
	contLINEA_ = contLINEA_ + 0.25
	w_METODO_NUEVO =""
	WHILE NOT rst_BM33.eof
		IF BBBC_1 =0 THEN
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.Item("Helvetica-Oblique")
			w_METODO_NUEVO = rst_BM33("MUESTRA_SANGRE_DESC") 
			Datos_COMPLETO = "Tipo de Muestra : " &  w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  30
			YY = 680   - (contLINEA_ * 11)
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 6
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_ = contLINEA_ + 0.25
		ELSE
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.LoadFromFile(RUTA_)
			w_METODO_NUEVO = rst_BM33("MUESTRA_SANGRE_DESC") 
			Datos_COMPLETO = "                   " &  w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  30
			YY = 680   - (contLINEA_ * 11)
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 6
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_ = contLINEA_ + 0.05	
		END IF
		rst_BM33.MOVENEXT
	wend
	
END FUNCTION

FUNCTION IMPRIME_DERIVADO_DEBAJO(WID_PERFIL, contLINEA_)
	Dim Datos_COMPLETO
	Set rst_BM33 = connBM3.execute("IRISLABWEB_BUSCA_DERIVADOR_NUEVO '"&WID_PERFIL&"' ")													
	BBBC =0
	WHILE NOT rst_BM33.eof
		BBBC = BBBC+1 
		rst_BM33.MOVENEXT
	WEND
	
	IF BBBC>0 THEN
		rst_BM33.MOVEFIRST
	END IF
	BBBC_1 =0
	contLINEA_ = contLINEA_ + 2.5
	w_METODO_NUEVO =""


    'RUTA_ ="c:\windows\fonts\arial.ttf" 											
	'		Set Font = Doc.Fonts.LoadFromFile(RUTA_)
	'		'w_METODO_NUEVO = rst_BM33("DERI_DESC") 
	'		Datos_COMPLETO = "Derivado a : " &  w_METODO_NUEVO
	'		Set Params = Pdf.CreateParam	
	'		XX =  30
	'		YY = 680   - (contLINEA_ * 11)
	'		'YY = 80			
	'		Params("x") = XX	
	'		Params("y") = YY
	'		Params("size") = 6.5
	'		Page.Canvas.DrawText "DERIVADOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOo", Params, Font
	'		contLINEA_ = contLINEA_ + 1

	WHILE NOT rst_BM33.eof
		IF BBBC_1 =0 THEN
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.LoadFromFile(RUTA_)
			w_METODO_NUEVO = rst_BM33("DERI_DESC") 
			Datos_COMPLETO = "Derivado a : " &  w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  30
			YY = 680   - (contLINEA_ * 11)
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 6.5
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_ = contLINEA_ + 1
		ELSE
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.LoadFromFile(RUTA_)
			w_METODO_NUEVO = rst_BM33("METO_DESC") 
			Datos_COMPLETO = "            " &  w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  30
			YY = 680   - (contLINEA_ * 11)
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 6.5
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_ = contLINEA_ + 1		
		END IF
		rst_BM33.MOVENEXT
	wend
	
END FUNCTION



FUNCTION IMPRIME_TITULO_SECCION(DATO_TITU, NLINEA)

	RUTA_ ="c:\windows\fonts\arialbd.ttf" 											
	Set Font = Doc.Fonts.LoadFromFile(RUTA_)

	'Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	CANT_LEN = LEN(DATO_TITU)
	CANT_LEN2 = CANT_LEN / 2
	Width_ =  500 / 2	
	XX =  (Width_ -  CANT_LEN2)
	YY = 680  - (NLINEA * 11)
	Params("x") = XX	
	Params("y") = YY
	Params("size") = 10
	Page.Canvas.DrawText DATO_TITU, Params, Font

END FUNCTION
    
FUNCTION IMPRIME_RESULTADO(NPRUEBA, w_ID_PRUEBA, w_ID_UM, w_UM, w_ResultadoA, w_ResultadoN, w_Rango_DESDE, w_Rango_HASTA, w_ID_TP_RESUL, contLINEA_, w_Nom_Seccion, w_TP_Alerta,w_FORMATON ,w_TXT_EXTRA,w_EST_RECHAZO)
'IRISLABWEB_BUSCA_FORMATO_DE_PRUEBA
	Dim YY
    Dim YYYY 
	Set rst_BM4 = connBM3.execute("IRISLABWEB_BUSCA_FORMATO_DE_PRUEBA_2 '"&w_ID_PRUEBA&"'")	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
   
  

    IF rst_BM4.eof  THEN

    contLINEA_ = contLINEA_ -1
    END IF

	YY = 680   - (contLINEA_ * 11)
	pfila = 0
	WHILE NOT rst_BM4.eof
	
		Dim FR_OBJETO_, FR_COLUMNA_, FR_TEXTO_, FR_TAMANO_, LET_DESC_, COLUMNA_, XX, CONCATE_, NC,  wID_TP_RESUL_, VALOR_YYY 
		
		IF pfila = 0 THEN		
		IF NPRUEBA = 1 THEN
		CALL IMPRIME_METODO_DEBAJO_3(w_ID_PRUEBA, contLINEA_)
		END IF
		END IF
		pfila = pfila + 1
		FR_OBJETO_ =  rst_BM4("FR_OBJETO")
		FR_COLUMNA_ =  CLng(rst_BM4("FR_COLUMNA"))

		FR_TEXTO_ = rst_BM4("FR_TEXTO")
		FR_TAMANO_ = rst_BM4("FR_TAMANO")				
		LET_DESC_ = rst_BM4("LET_DESC")
		COLUMNA_ = CLng(FR_COLUMNA_)
		XX = CLng(rst_BM4("FR_FILA"))		
		wID_TP_RESUL_ = rst_BM4("ID_TP_RESULTADO")	
                       

		IF FR_OBJETO_ ="Iris_Nombre" THEN
			IF Trim(FR_TEXTO_) <> ":" THEN
				IF FR_COLUMNA_ < 4500 THEN
                
					IF CLng(FR_COLUMNA_) < 551 THEN
    
						XX = 30
						Params("x") = XX
				
						YY = 680   - (contLINEA_ * 11)
						Params("y") = YY
						Params("size") = 6.5
    IF FR_TEXTO_ = "VIH"  or FR_TEXTO_ = "Test VIH" THEN
    FR_TEXTO_= VNom&VApe&VFnac&VRut
    END IF
						Page.Canvas.DrawText FR_TEXTO_, Params, Doc.Fonts("Helvetica-Bold")	
						 
						VALOR_YYY =	YY
                     END IF			
					IF FR_COLUMNA_ > 550 THEN
                    IF(CLng(w_EST_RECHAZO) <> 16) THEN
                        YY = (680 - (contLINEA_+(YYYY)) * 11)
                        YYYY=YYYY+1
						XX = 290						
						Params("x") = XX	
						Params("y") = YY
						Params("size") = 6.5
						Page.Canvas.DrawText FR_TEXTO_, Params, Doc.Fonts("Arial")	
						
						
                    END IF
					END IF
				ELSE
                    IF CLng(FR_COLUMNA_) > 6199 THEN
					YY = 680   - (contLINEA_ * 11)
					IF YY = VALOR_YYY THEN
					IF(CLng(w_EST_RECHAZO) <> 16) THEN
					    XX = 400
					    Params("x") = XX
					    
					    YY = 690   - (contLINEA_ * 11)
    
					    Params("y") = YY
					    Params("size") = 6.5
						contLINEA_ = contLINEA_ + 1
					    Page.Canvas.DrawText FR_TEXTO_, Params,  Font	
					    VALOR_YYY=""
						
                         END IF
                    ELSE
                        IF(CLng(w_EST_RECHAZO) <> 16) THEN
  					    XX = 400
					    Params("x") = XX
					    
					    YY = 690   - (contLINEA_ * 11)
                        
					    Params("y") = YY
					    Params("size") = 6.5
						'contLINEA_ = contLINEA_ + 1
					    Page.Canvas.DrawText FR_TEXTO_, Params,  Font               
                        END IF
						end if
					else
					YY = 680   - (contLINEA_ * 11)
					IF YY = VALOR_YYY THEN
					IF(CLng(w_EST_RECHAZO) <> 16) THEN
					    XX = 300
					    Params("x") = XX
					    
					    YY = 680   - (contLINEA_ * 11)
    
					    Params("y") = YY
					    Params("size") = 6.5
						contLINEA_ = contLINEA_ + 1
					    Page.Canvas.DrawText FR_TEXTO_, Params,  Font	
					    VALOR_YYY=""
						
                         END IF
                    ELSE
                        IF(CLng(w_EST_RECHAZO) <> 16) THEN
  					    XX = 300
					    Params("x") = XX
					    
					    YY = 680   - (contLINEA_ * 11)
                        
					    Params("y") = YY
					    Params("size") = 6.5
						contLINEA_ = contLINEA_ + 1
					    Page.Canvas.DrawText FR_TEXTO_, Params,  Font               
                        END IF
                     End if
                    END IF									
				END IF
			ELSE
    IF(CLng(w_EST_RECHAZO) <> 16) THEN
				XX = (Clng(COLUMNA_)/10)-100					
				Params("x") = XX	
				Params("y") = 680   - (contLINEA_ * 11)
				Params("size") = 6.5
				Page.Canvas.DrawText FR_TEXTO_, Params, Font
				
    END IF
							
			END IF		
		END IF

			IF FR_OBJETO_ ="Iris_Det" THEN
            YYYY=0
			IF CLng(w_ID_TP_RESUL) = 1 THEN
			    XX = 145
				'XX = ((COLUMNA_ * 648)/8000)
				YY = 680   - (contLINEA_ * 11)	
				Params("x") = XX	
				Params("y") = YY
				Params("size") = 6.5
				
				IF ISNUMERIC(w_ResultadoA) THEN 
			    	IF ISNULL(w_FORMATON) OR (w_FORMATON) = "0"  THEN

						CANT_DECI  = rst_BM4("PRU_DECIMAL")	
						CCC_DD_ = 0
                        CCC_DD_ = InStr(w_ResultadoA, ",")
						
						IF CCC_DD_ = 0 THEN
							IF CANT_DECI=  0 THEN
								Page.Canvas.DrawText Trim(w_ResultadoA), Params, Font
							ELSE
								FOR A_B = 1 TO CANT_DECI
									DDFFG_ = DDFFG_ & "0"
								NEXT
								w_ResultadoA = w_ResultadoA &"," & DDFFG_ 
								Page.Canvas.DrawText Trim(w_ResultadoA), Params, Font	
							END IF
							
						ELSE
							CCC_DD_2 = Len(w_ResultadoA)
							CANT_DES = Mid(w_ResultadoA, CCC_DD_ + 1, CCC_DD_2)
							CANT_DES_2 = Len(CANT_DES)
							 For GHJ = CANT_DES_2 To CANT_DECI - 1
								w_ResultadoA = w_ResultadoA & "0"
							 Next										 
							Page.Canvas.DrawText Trim(w_ResultadoA), Params, Font
						END IF
					
					
					
						'Page.Canvas.DrawText Trim(w_ResultadoA), Params, Font
				ELSE 
					w_ResultadoA = REPLACE(w_ResultadoA,",","")
					w_ResultadoA = REPLACE(w_ResultadoA,".","")
					w_ResultadoA = Trim(w_ResultadoA)					
					NC = len(w_ResultadoA)
					IF NC = "4" THEN
					w_ResultadoA = MID(w_ResultadoA, 1, 1) & "." & MID(w_ResultadoA, 2, 3)
					END IF
					IF NC = "5" THEN
					w_ResultadoA = MID(w_ResultadoA, 1, 2) & "." & MID(w_ResultadoA, 3, 3)
					END IF
					IF NC = "6" THEN
					w_ResultadoA = MID(w_ResultadoA, 1, 3) & "." & MID(w_ResultadoA, 4, 3)
					END IF
					IF NC = "7" THEN
					w_ResultadoA = MID(w_ResultadoA, 1, 1) & "." & MID(w_ResultadoA, 2, 3)& "." & MID(w_ResultadoA, 5, 3)
					END IF
					IF NC = "8" THEN
					w_ResultadoA = MID(w_ResultadoA, 1, 2) & "." & MID(w_ResultadoA, 3, 3)& "." & MID(w_ResultadoA, 6, 3)
					END IF
					IF NC = "9" THEN
					w_ResultadoA = MID(w_ResultadoA, 1, 3) & "." & MID(w_ResultadoA, 4, 3)& "." & MID(w_ResultadoA, 7, 3)
					END IF
					IF NC = "10" THEN
					w_ResultadoA = MID(w_ResultadoA, 1, 1) & "." & MID(w_ResultadoA, 2, 3)& "." & MID(w_ResultadoA, 5, 3)& "." & MID(w_ResultadoA, 8, 3)
					END IF
					w_ResultadoN = MID(w_ResultadoN, 1, 1) & "." & MID(w_ResultadoN, 2, 3)
					Page.Canvas.DrawText Trim(w_ResultadoA), Params, Font
				END IF	
					
				ELSE
    IF(Len(w_ResultadoA) > 30 and Len(w_ResultadoA) < 50) THEN
    ArrRes = Split(w_ResultadoA," ")

    Dim mitad, res1, res2
    mitad = UBound(ArrRes) /2
    mitad = Int(mitad)

    For y = 0 to mitad
	res1 = res1&" "&ArrRes(y)
    Next
    Params("y") = 680   - (contLINEA_ * 11) 
    Page.Canvas.DrawText Trim(res1), Params, Font

    For y = mitad+1 to UBound(ArrRes)
	res2 = res2&" "&ArrRes(y)
    Next 
    Params("y") = 680   - ((contLINEA_+1) * 11)
	Page.Canvas.DrawText Trim(res2), Params, Font  
    contfinal = 1
    ELSE
    Page.Canvas.DrawText Trim(w_ResultadoA), Params, Font
    END IF
					
				END IF 		
				'Page.Canvas.DrawText Trim(w_ResultadoA), Params, Font
			ELSE
				XX = 145				
				Params("x") = XX	
				Params("y") = 680   - (contLINEA_ * 11)
				Params("size") = 6.5
				
				w_ResultadoN = Trim(w_ResultadoN)
				
						CANT_DECI  = rst_BM4("PRU_DECIMAL")	
						CCC_DD_ = 0
                        CCC_DD_ = InStr(w_ResultadoN, ",")
						
						IF CCC_DD_ = 0 THEN
							IF CANT_DECI=  0 THEN
								Page.Canvas.DrawText Trim(w_ResultadoN), Params, Font
							ELSE
								FOR A_B = 1 TO CANT_DECI
									DDFFG_ = DDFFG_ & "0"
								NEXT
								w_ResultadoN = w_ResultadoN &"," & DDFFG_ 
								Page.Canvas.DrawText Trim(w_ResultadoN), Params, Font	
							END IF
							
						ELSE
							CCC_DD_2 = Len(w_ResultadoN)
							CANT_DES = Mid(w_ResultadoN, CCC_DD_ + 1, CCC_DD_2)
							CANT_DES_2 = Len(CANT_DES)
							 For GHJ = CANT_DES_2 To CANT_DECI  - 1
								w_ResultadoN = w_ResultadoN & "0"
							 Next				
							Page.Canvas.DrawText Trim(w_ResultadoN), Params, Font
						END IF					
				

				
			END IF		
	        IF CLng(id_per2) <> CLng(w_ID_PER_P) THEN 
		        'call IMPRIME_METODO_DEBAJO(w_ID_PER_P, YY)
		        id_per2 = w_ID_PER_P
	        END IF 			
			
		END IF

		IF FR_OBJETO_ ="Iris_Unidad" THEN
        IF(CLng(w_EST_RECHAZO) <> 16) THEN
			IF CLng(w_ID_UM) <> 1 THEN
				IF w_UM <> "" THEN

					XX = 240
					YY = 680 - (contLINEA_  * 11)			
					Params("x") = XX	
					Params("y") = YY
					Params("size") = 6.5
					Page.Canvas.DrawText w_UM, Params, Font
				END IF		
			END IF
          END IF
		END IF
		
		''IRISLABWEB_BUSCA_HISTORICO_PRUEBA_VALIDADA
		
		IF FR_OBJETO_ ="Iris_RHisto" THEN
    IF(CLng(w_EST_RECHAZO) <> 16) THEN
		    
		    Set rst_BM4_H = connBM3.execute("IRISLABWEB_BUSCA_HISTORICO_PRUEBA_VALIDADA '"&w_ID_PACw2&"' , '"&w_ID_PRUEBA&"', '"&w_ID_ATENw2&"' ")	
		    WHILE NOT rst_BM4_H.eof
	            'w_ID_TP_RESUL = rst_BM4_H("wID_TP_RESUL_") 
	            IF wID_TP_RESUL_ ="1" OR wID_TP_RESUL_ ="3" THEN
	                RESNUM_ALFA = rst_BM4_H("ATE_RESULTADO")
	                RESNUM_ALFA_FECHA =  rst_BM4_H("ATE_FECHA")
	            ELSE
	                RESNUM_ALFA = rst_BM4_H("ATE_RESULTADO_NUM")
	                RESNUM_ALFA_FECHA =   rst_BM4_H("ATE_FECHA")	          
		        END IF 
		        rst_BM4_H.MOVENEXT
	        WEND
	    
	        IF 	RESNUM_ALFA <> "" THEN
			    XX = 550			
			    Params("x") = XX	
			    
			    YY = 680   - (contLINEA_  * 11)	
    Params("y") = YY 
			    Params("size") = 6.5
			    Page.Canvas.DrawText RESNUM_ALFA, Params, Font	    
	        END IF	  
    END IF  
		END IF
		
		IF FR_OBJETO_ ="Iris_FHisto" THEN
	    IF(CLng(w_EST_RECHAZO) <> 16) THEN
		    Set rst_BM4_H = connBM3.execute("IRISLABWEB_BUSCA_HISTORICO_PRUEBA_VALIDADA '"&w_ID_PACw2&"' , '"&w_ID_PRUEBA&"', '"&w_ID_ATENw2&"' ")	
		    WHILE NOT rst_BM4_H.eof
	            'w_ID_TP_RESUL = rst_BM4_H("wID_TP_RESUL_") 
	            IF wID_TP_RESUL_ ="1" OR wID_TP_RESUL_ ="3" THEN
	                'RESNUM_ALFA = rst_BM4_H("ATE_RESULTADO")
	                RESNUM_ALFA_FECHA =   FormatDateTime(rst_BM4_H("ATE_FECHA"),2)
	            ELSE
	                'RESNUM_ALFA = rst_BM4_H("ATE_RESULTADO_NUM")
	                RESNUM_ALFA_FECHA =   FormatDateTime(rst_BM4_H("ATE_FECHA"),2)
		        END IF 
		        rst_BM4_H.MOVENEXT
	        WEND
	    
	        IF 	RESNUM_ALFA_FECHA <> "" THEN
			    XX = 480				
			    Params("x") = XX	
			    
			    YY = 680   - (contLINEA_  * 11)	
			    Params("y") = YY
			    Params("size") = 6.5
			    Page.Canvas.DrawText RESNUM_ALFA_FECHA, Params, Font	    
	        END IF	 
    END IF   
		END IF

		
			
		IF FR_OBJETO_ ="Iris_Rango" THEN
        IF(CLng(w_EST_RECHAZO) <> 16) THEN
			IF Trim(w_Rango_DESDE) <> "" AND Trim(w_Rango_HASTA) <> "" THEN
				VALOR_COLUMNA_RANGO = COLUMNA_
				XX = 300
																	
				Params("x") = XX	
				Params("y") = 680   - (contLINEA_ * 11)
				Params("size") = 6.5
				
     

				IF ISNULL(w_FORMATON) OR (w_FORMATON) = "0" THEN
			'	Page.Canvas.DrawText Trim(w_Rango_DESDE), Params, Font
				ELSE 
				w_Rango_DESDE = REPLACE(w_Rango_DESDE,",","")
				w_Rango_DESDE = REPLACE(w_Rango_DESDE,".","")
				w_Rango_DESDE = Trim(w_Rango_DESDE)
				NC = len(w_Rango_DESDE)
				IF NC = "4" THEN
				w_Rango_DESDE = MID(w_Rango_DESDE, 1, 1) & "." & MID(w_Rango_DESDE, 2, 3)
				END IF
				IF NC = "5" THEN
				w_Rango_DESDE = MID(w_Rango_DESDE, 1, 2) & "." & MID(w_Rango_DESDE, 3, 3)
				END IF
				IF NC = "6" THEN
				w_Rango_DESDE = MID(w_Rango_DESDE, 1, 3) & "." & MID(w_Rango_DESDE, 4, 3)
				END IF
				IF NC = "7" THEN
				w_Rango_DESDE = MID(w_Rango_DESDE, 1, 1) & "." & MID(w_Rango_DESDE, 2, 3)& "." & MID(w_Rango_DESDE, 5, 3)
				END IF
				IF NC = "8" THEN
				w_Rango_DESDE = MID(w_Rango_DESDE, 1, 2) & "." & MID(w_Rango_DESDE, 3, 3)& "." & MID(w_Rango_DESDE, 6, 3)
				END IF
				IF NC = "9" THEN
				w_Rango_DESDE = MID(w_Rango_DESDE, 1, 3) & "." & MID(w_Rango_DESDE, 4, 3)& "." & MID(w_Rango_DESDE, 7, 3)
				END IF
				IF NC = "10" THEN
				w_Rango_DESDE = MID(w_Rango_DESDE, 1, 1) & "." & MID(w_Rango_DESDE, 2, 3)& "." & MID(w_Rango_DESDE, 5, 3)& "." & MID(w_Rango_DESDE, 8, 3)
				END IF
				'w_ResultadoN = MID(w_ResultadoN, 1, 1) & "." & MID(w_ResultadoN, 2, 3)
			'	Page.Canvas.DrawText Trim(w_Rango_DESDE), Params, Font
				END IF		
				
				IF ISNULL(w_FORMATON) OR (w_FORMATON) = "0" THEN
			'	Page.Canvas.DrawText Trim(w_Rango_HASTA), Params, Font
				ELSE 
				w_Rango_HASTA = REPLACE(w_Rango_HASTA,",","")
				w_Rango_HASTA = REPLACE(w_Rango_HASTA,".","")
				w_Rango_HASTA = Trim(w_Rango_HASTA)
				NC = len(w_Rango_HASTA)
				IF NC = "4" THEN
				w_Rango_HASTA = MID(w_Rango_HASTA, 1, 1) & "." & MID(w_Rango_HASTA, 2, 3)
				END IF
				IF NC = "5" THEN
				w_Rango_HASTA = MID(w_Rango_HASTA, 1, 2) & "." & MID(w_Rango_HASTA, 3, 3)
				END IF
				IF NC = "6" THEN
				w_Rango_HASTA = MID(w_Rango_HASTA, 1, 3) & "." & MID(w_Rango_HASTA, 4, 3)
				END IF
				IF NC = "7" THEN
				w_Rango_HASTA = MID(w_Rango_HASTA, 1, 1) & "." & MID(w_Rango_HASTA, 2, 3)& "." & MID(w_Rango_HASTA, 5, 3)
				END IF
				IF NC = "8" THEN
				w_Rango_HASTA = MID(w_Rango_HASTA, 1, 2) & "." & MID(w_Rango_HASTA, 3, 3)& "." & MID(w_Rango_HASTA, 6, 3)
				END IF
				IF NC = "9" THEN
				w_Rango_HASTA = MID(w_Rango_HASTA, 1, 3) & "." & MID(w_Rango_HASTA, 4, 3)& "." & MID(w_Rango_HASTA, 7, 3)
				END IF
				IF NC = "10" THEN
				w_Rango_HASTA = MID(w_Rango_HASTA, 1, 1) & "." & MID(w_Rango_HASTA, 2, 3)& "." & MID(w_Rango_HASTA, 5, 3)& "." & MID(w_Rango_HASTA, 8, 3)
				END IF
				'w_ResultadoN = MID(w_ResultadoN, 1, 1) & "." & MID(w_ResultadoN, 2, 3)
			'	Page.Canvas.DrawText Trim(w_Rango_HASTA), Params, Font
				END IF					
				
				IF Trim(w_TP_Alerta) = "A" or Trim(w_TP_Alerta) = "B" THEN
					RUTA_ ="c:\windows\fonts\arialbd.ttf" 
					Set Font = Doc.Fonts.LoadFromFile(RUTA_)
					XX = (COLUMNA_/10)- 140														
					Params("x") = 300	
					Params("y") = 680   - (contLINEA_  * 11)	
					Params("size") = 6.5
					CONCATE_ = "[ * ]" 
					Page.Canvas.DrawText CONCATE_, Params, Font				
					
					Set Font = Doc.Fonts("Arial")
					XX = 310														
					Params("x") = XX	
					Params("y") = 680   - (contLINEA_  * 11)	
					Params("size") = 6.5
												
					CONCATE_ = "[ * ]" & " " & w_Rango_DESDE & "-" & w_Rango_HASTA
					CONCATE_ =  w_Rango_DESDE & " - " & w_Rango_HASTA				
					Page.Canvas.DrawText CONCATE_, Params, Font
				
				ELSE
							
						IF Trim(w_Rango_HASTA) <>"." and Trim(w_Rango_HASTA) <> "" THEN
							Set Font = Doc.Fonts("Arial")
							XX = 300		
							
							IF XX> 355 THEN
							 XX = 350
							END IF	
																		
							Params("x") = XX	
							Params("y") = 680   - (contLINEA_  * 11)	
							Params("size") = 6.5									
							CONCATE_ = w_Rango_DESDE & " - " & w_Rango_HASTA
							Page.Canvas.DrawText CONCATE_, Params, Font					
						ELSE
							Set Font = Doc.Fonts("Arial")
							XX = 300												
							Params("x") = XX	
							Params("y") = 680   - (contLINEA_  * 11)	
							Params("size") = 6.5				
							CONCATE_ = w_Rango_DESDE 
							Page.Canvas.DrawText CONCATE_, Params, Font						
						END IF					
				END IF
               
			END IF	
        END IF
		END IF

	
		rst_BM4.MOVENEXT
    

	IF YYYY = 2 THEN
    contLINEA_ = contLINEA_ + 2
    YYYY= 0
    END IF

	WEND

    IF contfinal <> 0 THEN
    contLINEA_ = contLINEA_ + contfinal
    contfinal= 0
    END IF
    
	
	


	IF w_TXT_EXTRA <> "" AND FR_OBJETO_ <> "" THEN
    
    
		XX = (VALOR_COLUMNA_RANGO/10)- 120																		
		Params("x") = XX	
    
		contLINEA_=contLINEA_+1
		YY = 680   - (contLINEA_ * 11)
        
		Params("y") = YY
								
		Params("size") = 6.5
		Page.Canvas.DrawText w_TXT_EXTRA, Params, Font		
		VALOR_COLUMNA_RANGO =""

	
	END IF	
      

    
END FUNCTION

FUNCTION IMPRIME_FECHA_HOY(contLINEA_,w_ID_CF,w_ID_PRUEBA)

    Dim Fecha_Recep
    		 Set rst_BM4_Hora = connBM3.execute("IRISLABWEB_BUSCA_FEC_RECEP '"&w_ID_CF&"', '"&Id_atencion_&"' , '"&w_ID_PRUEBA&"'")	
		     WHILE NOT rst_BM4_Hora.eof
    IF ISNULL(rst_BM4_Hora("ATE_FEC_RECEP"))then 
    Fecha_Recep =  "Fecha no Ingresada"
    ELSE
     Fecha_Recep =   FormatDateTime(rst_BM4_Hora("ATE_FEC_RECEP"),0)
    END IF
    	               
    
		        rst_BM4_Hora.MOVENEXT
	         WEND	
    'contLINEA_ = contLINEA_ +1

      Set Params = Pdf.CreateParam							
        XX = 30																
		Params("x") = XX	
        Set Font = Doc.Fonts.Item("Helvetica-Oblique")	
		YY = 665 - (contLINEA_ * 11)
        Dim AA 
        AA= "Fecha de Recepción en el Laboratorio: "&Fecha_Recep
		Params("y") = YY					
		Params("size") = 6
		Page.Canvas.DrawText AA, Params, Font	
    END FUNCTION

Function IMPRIME_FIRMA_TECNOLOGO

	Set Image = Doc.OpenImage(Server.MapPath( "/FIRMAS/DPEREIRA.BMP" ) )		
	Set Param = Pdf.CreateParam

	Param("x") = 480	
	Param("y") = 130
	Param("ScaleX") = (0.4)
	Param("ScaleY") =(0.4)			
	Page.Canvas.DrawImage Image, Param

END FUNCTION

Function IMPRIME_FIRMA_TECNOLOGO_CON_USUARIO(w_USUARIO_2)

Set rst_BM4 = connBM3.execute("NET_IRISLABWEB_BUSCA_RUTA_IMG '"&CLng(w_USUARIO_2)&"'")

    

 	IF IsNull(rst_BM4("USU_FIRMA")) THEN
	firma = 1
     
	ELSE
	firma = 2 
    
    END IF



    IF firma = 1 THEN
	Set Image2 = Doc.OpenImage(Server.MapPath( "/FIRMAS/SINFIRMA.JPG" ) )
	Set Param = Pdf.CreateParam
	Param("x") = 300
	Param("y") = 62
	Param("ScaleX") = (0.1)
	Param("ScaleY") = (0.1)			
	'Page.Canvas.DrawImage Image2, Param
	ELSE
	
    'if(rst_BM4("USU_FIRMA").Value <> CStr("0x00")) then
    
    ''''''''''''''''''''''''
    Set rst_BM4 = connBM3.execute("NET_IRISLABWEB_BUSCA_RUTA_IMG '"&CLng(w_USUARIO_2)&"'")
    Set Image2 = Doc.OpenImageBinary( rst_BM4("USU_FIRMA").Value ) 
	Set Param = Pdf.CreateParam
	Param("x") = 400
	Param("y") = 30
	Param("ScaleX") = (5)
	Param("ScaleY") = (5)			
	Page.Canvas.DrawImage Image2, Param
    'end if
     
	END IF
	

	

END FUNCTION


FUNCTION IMPRIME_RESULTADO_NUEVO(w_ID_PRUEBA, w_ID_UM, w_UM, w_ResultadoA, w_ResultadoN, w_Rango_DESDE, w_Rango_HASTA, w_ID_TP_RESUL, contLINEA_, w_Nom_Seccion, w_TP_Alerta,w_FORMATON, w_EST_RECHAZO )
'IRISLABWEB_BUSCA_FORMATO_DE_PRUEBA
	
	Set rst_BM4 = connBM3.execute("IRISLABWEB_BUSCA_FORMATO_DE_PRUEBA_2 '"&w_ID_PRUEBA&"'")	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Dim FR_OBJETO_, FR_COLUMNA_, FR_TEXTO_, FR_TAMANO_, LET_DESC_, COLUMNA_, YY, XX, CONCATE_ , FILA_, CANT_DECI
	
    if rst_BM4.EOF Or rst_BM4.EOF then
    contLINEA_ = contLINEA_-1.5
    end if

	'YY = 680 - (contLINEA_ * 11)
	WHILE NOT rst_BM4.eof
			
		FR_OBJETO_ =  rst_BM4("FR_OBJETO")
		FR_COLUMNA_ = CLng(rst_BM4("FR_COLUMNA"))
		FR_FILA_ = CLng(rst_BM4("FR_FILA"))
		FR_TEXTO_ = rst_BM4("FR_TEXTO")
		FR_TAMANO_ = rst_BM4("FR_TAMANO")				
		LET_DESC_ = rst_BM4("LET_DESC")
		COLUMNA_ = CLng(FR_COLUMNA_)
		FILA_ =  CLng(FR_FILA_) - 1200
		CANT_DECI  = rst_BM4("PRU_DECIMAL")	
		
		IF FR_OBJETO_ ="Iris_Nombre" THEN
			IF Trim(FR_TEXTO_) <> ":" THEN
				XX = 30
				YY = 665 - (contLINEA_ * 11)				
				Params("x") = 30	
				Params("y") = YY
				Params("size") = 6.5
    IF FR_TEXTO_ = "VIH"  or FR_TEXTO_ = "Test VIH" THEN
    FR_TEXTO_= VNom&VApe&VFnac&VRut
    END IF
				Page.Canvas.DrawText FR_TEXTO_, Params, Font
				session("anti") = YY
			ELSE
				XX = 30
				YY = 665 - (contLINEA_ * 11)					
				Params("x") = 30	
				Params("y") = YY
				Params("size") = 6.5
				Page.Canvas.DrawText FR_TEXTO_, Params, Font
							
			END IF		
		END IF

		IF FR_OBJETO_ ="Iris_Titulo" THEN
			IF Trim(FR_TEXTO_) <> ":" THEN
				XX = ((COLUMNA_ * 648)/8000)
				YY = 665 - (contLINEA_ * 11)					
				Params("x") = 30	
				Params("y") = YY
				Params("size") = 6.5
				Page.Canvas.DrawText FR_TEXTO_, Params, Font
			ELSE
				XX = ((COLUMNA_ * 648)/8000) 
				YY = 665 - (contLINEA_ * 11)					
				Params("x") = 30	
				Params("y") = YY
				Params("size") = 6.5
				Page.Canvas.DrawText FR_TEXTO_, Params, Font
							
			END IF		
		END IF


		IF FR_OBJETO_ ="Iris_Det" THEN
			IF CLng(w_ID_TP_RESUL) = 1 THEN
				XX = 145
				YY = 665 - (contLINEA_ * 11)				
				Params("x") = XX	
				Params("y") = YY
				Params("size") = 6.5
				IF ISNUMERIC(w_ResultadoA) THEN 
					IF ISNULL(w_FORMATON) OR (w_FORMATON) = "0"  THEN
						CANT_DECI  = rst_BM4("PRU_DECIMAL")	
						CCC_DD_ = 0
                        CCC_DD_ = InStr(w_ResultadoA, ",")
						
						IF CCC_DD_ = 0 THEN
							IF CANT_DECI=  0 THEN
								Page.Canvas.DrawText Trim(w_ResultadoA), Params, Font
							ELSE
								FOR A_B = 1 TO CANT_DECI
									DDFFG_ = DDFFG_ & "0"
								NEXT
								w_ResultadoA = w_ResultadoA &"," & DDFFG_ 
								Page.Canvas.DrawText Trim(w_ResultadoA), Params, Font	
							END IF
							
						ELSE
							CCC_DD_2 = Len(w_ResultadoA)
							CANT_DES = Mid(w_ResultadoA, CCC_DD_ + 1, CCC_DD_2)
							CANT_DES_2 = Len(CANT_DES)
							 For GHJ = CANT_DES_2 To CANT_DECI - 1
								w_ResultadoA = w_ResultadoA & "0"
							 Next										 
							Page.Canvas.DrawText Trim(w_ResultadoA), Params, Font
						END IF
						
					ELSE 				
						w_ResultadoA = REPLACE(w_ResultadoA,",","")
						w_ResultadoA = REPLACE(w_ResultadoA,".","")				
						w_ResultadoA = Trim(w_ResultadoA)
						NC = len(w_ResultadoA)
						IF NC = "4" THEN
						w_ResultadoA = MID(w_ResultadoA, 1, 1) & "." & MID(w_ResultadoA, 2, 3)
						END IF
						IF NC = "5" THEN
						w_ResultadoA = MID(w_ResultadoA, 1, 2) & "." & MID(w_ResultadoA, 3, 3)
						END IF
						IF NC = "6" THEN
						w_ResultadoA = MID(w_ResultadoA, 1, 3) & "." & MID(w_ResultadoA, 4, 3)
						END IF
						IF NC = "7" THEN
						w_ResultadoA = MID(w_ResultadoA, 1, 1) & "." & MID(w_ResultadoA, 2, 3)& "." & MID(w_ResultadoA, 5, 3)
						END IF
						IF NC = "8" THEN
						w_ResultadoA = MID(w_ResultadoA, 1, 2) & "." & MID(w_ResultadoA, 3, 3)& "." & MID(w_ResultadoA, 6, 3)
						END IF
						IF NC = "9" THEN
						w_ResultadoA = MID(w_ResultadoA, 1, 3) & "." & MID(w_ResultadoA, 4, 3)& "." & MID(w_ResultadoA, 7, 3)
						END IF
						IF NC = "10" THEN
						w_ResultadoA = MID(w_ResultadoA, 1, 1) & "." & MID(w_ResultadoA, 2, 3)& "." & MID(w_ResultadoA, 5, 3)& "." & MID(w_ResultadoA, 8, 3)
						END IF
						'w_ResultadoN = MID(w_ResultadoN, 1, 1) & "." & MID(w_ResultadoN, 2, 3)
						Page.Canvas.DrawText Trim(w_ResultadoA), Params, Font
					END IF		
				ELSE
					IF(Len(w_ResultadoA) > 30 and Len(w_ResultadoA) < 50) THEN
    ArrRes = Split(w_ResultadoA," ")

    Dim mitad, res1, res2
    mitad = UBound(ArrRes) /2
    mitad = Int(mitad)

    For y = 0 to mitad
	res1 = res1&" "&ArrRes(y)
    Next
   
    Params("y") = 680   - ((contLINEA_+1.5) * 11) 
    Page.Canvas.DrawText Trim(res1), Params, Font

    For y = mitad+1 to UBound(ArrRes)
	res2 = res2&" "&ArrRes(y)
    Next 
    Params("y") = 680   - ((contLINEA_+2.5) * 11)
    contfinal = 1
	Page.Canvas.DrawText Trim(res2), Params, Font  
    
    ELSE
    Page.Canvas.DrawText Trim(w_ResultadoA), Params, Font
    END IF
				END IF 		
				'Page.Canvas.DrawText Trim(w_ResultadoA), Params, Font
			ELSE
    'Relleno



				XX = 145
				YY = 665 - (contLINEA_ * 11)				

				Params("x") = XX	
				Params("y") = YY
				Params("size") = 6.5
				
				w_ResultadoN = Trim(w_ResultadoN)
				
						CANT_DECI  = rst_BM4("PRU_DECIMAL")	
						CCC_DD_ = 0
                        CCC_DD_ = InStr(w_ResultadoN, ",")
						
						IF CCC_DD_ = 0 THEN
							IF CANT_DECI=  0 THEN
								Page.Canvas.DrawText Trim(w_ResultadoN), Params, Font
							ELSE
								FOR A_B = 1 TO CANT_DECI
									DDFFG_ = DDFFG_ & "0"
								NEXT
								w_ResultadoN = w_ResultadoN &"," & DDFFG_ 
								Page.Canvas.DrawText Trim(w_ResultadoN), Params, Font	
							END IF
							
						ELSE
							CCC_DD_2 = Len(w_ResultadoN)
							CANT_DES = Mid(w_ResultadoN, CCC_DD_ + 1, CCC_DD_2)
							CANT_DES_2 = Len(CANT_DES)
							 For GHJ = CANT_DES_2 To CANT_DECI  - 1
								w_ResultadoN = w_ResultadoN & "0"
							 Next				
							Page.Canvas.DrawText Trim(w_ResultadoN), Params, Font
						END IF				
				
				
				'Page.Canvas.DrawText Trim(w_ResultadoN), Params, Font						
			END IF		
		END IF

			IF FR_OBJETO_ ="Iris_Unidad" THEN
    IF(CLng(w_EST_RECHAZO) <> 16) THEN
			IF CLng(w_ID_UM) <> 1 THEN
				IF w_UM <> "" THEN
					XX = 240			
					Params("x") = XX	
					Params("y") = 665 - (contLINEA_ * 11)
					Params("size") = 6.5
					Page.Canvas.DrawText w_UM, Params, Font
				END IF		
			END IF
    END IF
		END IF
			
		IF FR_OBJETO_ ="Iris_Rango" THEN
    IF(CLng(w_EST_RECHAZO) <> 16) THEN
			IF Trim(w_Rango_DESDE) <> "" AND Trim(w_Rango_HASTA) <> "" THEN
				XX = 300
				YY = 665 - (contLINEA_ * 11)					
				Params("x") = XX	
				Params("y") = YY
				Params("size") = 6.5
				
				IF ISNULL(w_FORMATON) OR (w_FORMATON) = "0" THEN
			'	Page.Canvas.DrawText Trim(w_Rango_DESDE), Params, Font
				ELSE 
				w_Rango_DESDE = REPLACE(w_Rango_DESDE,",","")
				w_Rango_DESDE = REPLACE(w_Rango_DESDE,".","")
				w_Rango_DESDE = Trim(w_Rango_DESDE)
				NC = len(w_Rango_DESDE)
				IF NC = "4" THEN
				w_Rango_DESDE = MID(w_Rango_DESDE, 1, 1) & "." & MID(w_Rango_DESDE, 2, 3)
				END IF
				IF NC = "5" THEN
				w_Rango_DESDE = MID(w_Rango_DESDE, 1, 2) & "." & MID(w_Rango_DESDE, 3, 3)
				END IF
				IF NC = "6" THEN
				w_Rango_DESDE = MID(w_Rango_DESDE, 1, 3) & "." & MID(w_Rango_DESDE, 4, 3)
				END IF
				IF NC = "7" THEN
				w_Rango_DESDE = MID(w_Rango_DESDE, 1, 1) & "." & MID(w_Rango_DESDE, 2, 3)& "." & MID(w_Rango_DESDE, 5, 3)
				END IF
				IF NC = "8" THEN
				w_Rango_DESDE = MID(w_Rango_DESDE, 1, 2) & "." & MID(w_Rango_DESDE, 3, 3)& "." & MID(w_Rango_DESDE, 6, 3)
				END IF
				IF NC = "9" THEN
				w_Rango_DESDE = MID(w_Rango_DESDE, 1, 3) & "." & MID(w_Rango_DESDE, 4, 3)& "." & MID(w_Rango_DESDE, 7, 3)
				END IF
				IF NC = "10" THEN
				w_Rango_DESDE = MID(w_Rango_DESDE, 1, 1) & "." & MID(w_Rango_DESDE, 2, 3)& "." & MID(w_Rango_DESDE, 5, 3)& "." & MID(w_Rango_DESDE, 8, 3)
				END IF
				'w_ResultadoN = MID(w_ResultadoN, 1, 1) & "." & MID(w_ResultadoN, 2, 3)
			'	Page.Canvas.DrawText Trim(w_Rango_DESDE), Params, Font
				END IF		
				
				IF ISNULL(w_FORMATON) OR (w_FORMATON) = "0" THEN
			'	Page.Canvas.DrawText Trim(w_Rango_HASTA), Params, Font
				ELSE 
				w_Rango_HASTA = REPLACE(w_Rango_HASTA,",","")
				w_Rango_HASTA = REPLACE(w_Rango_HASTA,".","")
				w_Rango_HASTA = Trim(w_Rango_HASTA)
				NC = len(w_Rango_HASTA)
				IF NC = "4" THEN
				w_Rango_HASTA = MID(w_Rango_HASTA, 1, 1) & "." & MID(w_Rango_HASTA, 2, 3)
				END IF
				IF NC = "5" THEN
				w_Rango_HASTA = MID(w_Rango_HASTA, 1, 2) & "." & MID(w_Rango_HASTA, 3, 3)
				END IF
				IF NC = "6" THEN
				w_Rango_HASTA = MID(w_Rango_HASTA, 1, 3) & "." & MID(w_Rango_HASTA, 4, 3)
				END IF
				IF NC = "7" THEN
				w_Rango_HASTA = MID(w_Rango_HASTA, 1, 1) & "." & MID(w_Rango_HASTA, 2, 3)& "." & MID(w_Rango_HASTA, 5, 3)
				END IF
				IF NC = "8" THEN
				w_Rango_HASTA = MID(w_Rango_HASTA, 1, 2) & "." & MID(w_Rango_HASTA, 3, 3)& "." & MID(w_Rango_HASTA, 6, 3)
				END IF
				IF NC = "9" THEN
				w_Rango_HASTA = MID(w_Rango_HASTA, 1, 3) & "." & MID(w_Rango_HASTA, 4, 3)& "." & MID(w_Rango_HASTA, 7, 3)
				END IF
				IF NC = "10" THEN
				w_Rango_HASTA = MID(w_Rango_HASTA, 1, 1) & "." & MID(w_Rango_HASTA, 2, 3)& "." & MID(w_Rango_HASTA, 5, 3)& "." & MID(w_Rango_HASTA, 8, 3)
				END IF
				'w_ResultadoN = MID(w_ResultadoN, 1, 1) & "." & MID(w_ResultadoN, 2, 3)
			'	Page.Canvas.DrawText Trim(w_Rango_HASTA), Params, Font
				END IF					
				
				IF Trim(w_TP_Alerta) = "A" or Trim(w_TP_Alerta) = "B" THEN				
					XX = 300
					YY = 665 - (contLINEA_ * 11)							
					Params("x") = 300	
					Params("y") = YY
					Params("size") = 6.5				
					CONCATE_ = "[ * ]" & " " & w_Rango_DESDE & "-" & w_Rango_HASTA
					Page.Canvas.DrawText CONCATE_, Params, Font

					CONCATE_ = "" & w_Rango_DESDE & "-" & w_Rango_HASTA
					
					RUTA_ ="c:\windows\fonts\arialbd.ttf" 
					Set Font = Doc.Fonts.LoadFromFile(RUTA_)
					XX = 300
					YY = 665 - (contLINEA_ * 11)							
					Params("x") = 310	
					Params("y") = YY
					Params("size") = 6.5				
					CONCATE_ = "[ * ]" 
					Page.Canvas.DrawText CONCATE__, Params, Font										
					
				ELSE
					IF Trim(w_Rango_HASTA) <>"." and Trim(w_Rango_HASTA) <>"" THEN
						CONCATE_ = w_Rango_DESDE & " - " & w_Rango_HASTA
						Page.Canvas.DrawText CONCATE_, Params, Font					
					ELSE
							CONCATE_ = w_Rango_DESDE 
							Page.Canvas.DrawText CONCATE_, Params, Font
						
					END IF
				END IF
				
				'Page.Canvas.DrawText CONCATE_, Params, Font
			END IF		
		END IF
    END IF
	
		rst_BM4.MOVENEXT
	WEND
	IF contfinal <> 0 THEN
    contLINEA_ = contLINEA_ + contfinal
    contfinal= 0
    END IF
END FUNCTION

FUNCTION CREA_HOJA_OBJETOS
	Set Pdf = Server.CreateObject("Persits.Pdf")
	Set Doc = Pdf.CreateDocument

	Width =  612
	Height = 792
	Set Page = Doc.Pages.Add( Width, Height )	

END FUNCTION

function LLENA_MARCO_HOJA

	Set Image = Doc.OpenImage(Server.MapPath( "/Firmas/logolab.jpg" ) )		
	Set Param = Pdf.CreateParam
	Param("x") = 35
	Param("y") = 715
	Param("ScaleX") = (0.40)
	Param("ScaleY") =(0.40)			
	Page.Canvas.DrawImage Image, Param
	
	Set Font = Doc.Fonts("Helvetica-Bold")
	Set Params = Pdf.CreateParam	
	Params("x") = 258
	Params("y") = 765
	Params("size") = 12	
	Page.Canvas.DrawText "LABORATORIO CLÍNICO", Params, Font

    Set Font = Doc.Fonts("Helvetica-Bold")
	Set Params = Pdf.CreateParam	
	Params("x") = 200
	Params("y") = 750
	Params("size") = 12	
	Page.Canvas.DrawText "CORPORACIÓN MUNICIPAL VALPARAISO", Params, Font
	
    Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 192
	Params("y") = 735
	Params("size") = 11	
	Page.Canvas.DrawText "Calle Washington #32, tercer piso, Valparaiso", Params, Font

'	Set Image = Doc.OpenImage(Server.MapPath( "Firmas/15129.png" ) )		
'	Set Param = Pdf.CreateParam
'	Param("x") = 450
'	Param("y") = 725
'	Param("ScaleX") = (0.10)
'	Param("ScaleY") =(0.10)			
'	Page.Canvas.DrawImage Image, Param
	
'	Set Image = Doc.OpenImage(Server.MapPath( "Firmas/9001.png" ) )		
'	Set Param = Pdf.CreateParam
'	Param("x") = 510
'	Param("y") = 725
'	Param("ScaleX") = (0.10)
'	Param("ScaleY") =(0.10)			
'	Page.Canvas.DrawImage Image, Param


	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 10	
	Params("y") = 718
	Params("size") = 8	
	Page.Canvas.DrawText "___________________________________________________________________________________________________________________________________", Params, Font


	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 10	
	Params("y") = 655
	Params("size") = 8	
	Page.Canvas.DrawText "___________________________________________________________________________________________________________________________________", Params, Font
	
    Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 10	
	Params("y") = 635
	Params("size") = 8	
	Page.Canvas.DrawText "___________________________________________________________________________________________________________________________________", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 10	
	Params("y") = 60
	Params("size") = 8	
	Page.Canvas.DrawText "   El resultado de este examen no constituye diagnóstico. Debe ser interpretado por su médico.", Params, Font

	'Set Font = Doc.Fonts("Arial")
	'Set Params = Pdf.CreateParam	
	'Params("x") = 10	
	'Params("y") = 50
	'Params("size") = 8	
	'Page.Canvas.DrawText "   Laboratorio adscrito al programa de evaluación externa de calidad del I.S.P. de Chile (PEEC).", Params, Font
'	
'	Set Font = Doc.Fonts("Times New Roman")
'	Set Params = Pdf.CreateParam	
'	Params("x") = 90
'	Params("y") = 40
'	Params("size") = 7	
'	Page.Canvas.DrawText "Casa Matriz", Params, Font
'	
'	Set Font = Doc.Fonts("Times New Roman")
'	Set Params = Pdf.CreateParam	
'	Params("x") = 240
'	Params("y") = 40
'	Params("size") = 7	
'	Page.Canvas.DrawText "Sucursales", Params, Font
'	
'	Set Font = Doc.Fonts("Times New Roman")
'	Set Params = Pdf.CreateParam	
'	Params("x") = 90
'	Params("y") = 33
'	Params("size") = 7	
'	Page.Canvas.DrawText "Esmeralda 731", Params, Font
'	
'	Set Font = Doc.Fonts("Times New Roman")
'	Set Params = Pdf.CreateParam	
'	Params("x") = 240
'	Params("y") = 33
'	Params("size") = 7	
'	Page.Canvas.DrawText "Centro Norte Grande - Arturo Fernández 2165, Iquique.", Params, Font
'	
'	Set Font = Doc.Fonts("Times New Roman")
'	Set Params = Pdf.CreateParam	
'	Params("x") = 90
'	Params("y") = 26
'	Params("size") = 7	
'	Page.Canvas.DrawText "Fono: 57 2735002", Params, Font
'	
'	Set Font = Doc.Fonts("Times New Roman")
'	Set Params = Pdf.CreateParam	
'	Params("x") = 240
'	Params("y") = 26
'	Params("size") = 7	
'	Page.Canvas.DrawText "Centro Médico Iquique - Av. Arturo Prat 1170, piso 3, Fono: 57 2523373, Iquique.", Params, Font
'	
'	Set Font = Doc.Fonts("Times New Roman")
'	Set Params = Pdf.CreateParam	
'	Params("x") = 90
'	Params("y") = 19
'	Params("size") = 7	
'	Page.Canvas.DrawText "contacto@clinicum.cl", Params, Font
'	
'	Set Font = Doc.Fonts("Times New Roman")
'	Set Params = Pdf.CreateParam	
'	Params("x") = 240
'	Params("y") = 19
'	Params("size") = 7	
'	Page.Canvas.DrawText "Centro Diagnóstico Prat - Manuel Rodríguez N° 842, piso 2, Fono: 57 2765817, Iquique.", Params, Font
'	
'	Set Font = Doc.Fonts("Times New Roman")
'	Set Params = Pdf.CreateParam	
'	Params("x") = 90
'	Params("y") = 12
'	Params("size") = 7	
'	Page.Canvas.DrawText "www.clinicum.cl", Params, Font

	Width =  612
	Height = 792
End function


function LLENA_ENCABEZADO(ID_PER)
	Dim g_nombre,g_fecha, g_rut, g_numero, g_fnac, g_Proce, g_edad, g_sexo, g_Prevision, g_usuario_, g_Medico_, g_sector, g_FUR
	
	Id_atencion_ = oid_empresa '319 'session("ID_ATEN")
	
 	Set rst_BM5 = connBM3.execute("IRISLABWEB_BUSCA_ATENCION_CLINICUM '"&Id_atencion_&"','"&ID_PERFIL_NUEVO_REAL&"'")	
	IF not rst_BM5.eof THEN
		g_nombre= rst_BM5("PAC_NOMBRE") & " " & rst_BM5("PAC_APELLIDO")	
    VNom = Left(rst_BM5("PAC_NOMBRE"), 1)
    Dim ArrApe
    ArrApe = Split(rst_BM5("PAC_APELLIDO")," ")

    For y = 0 to UBound(ArrApe)
	VApe = VApe&Left(ArrApe(y), 1)
    Next 

    IF (UBound(ArrApe)+1 <> 2) THEN
	VApe = VApe& "#"
    END IF     
		g_fecha = rst_BM5("ATE_FECHA")
		g_rut = rst_BM5("PAC_RUT")
    IF IsNull(rst_BM5("PAC_RUT")) THEN
        VRut = "ABC-D"
        ELSE
        VRut = Right(rst_BM5("PAC_RUT"), 5)
        END IF
		g_numero = rst_BM5("ATE_NUM")
		g_fnac = rst_BM5("PAC_FNAC") 
    VFnac = rst_BM5("PAC_FNAC")
        VFnac = Replace(VFnac,"-","")
        VFnac = Left(VFnac,4)&""&Right(VFnac,2)
		g_Proce = rst_BM5("PROC_DESC")
		g_edad = rst_BM5("ATE_AÑO") & "a "& rst_BM5("ATE_MES") & "m "& rst_BM5("ATE_DIA") & "d"
		g_sexo = rst_BM5("SEXO_DESC")
		g_Prevision = rst_BM5("PREVE_DESC")
		g_usuario_ = rst_BM5("USU_NIC")		
		g_Medico_ = rst_BM5("DOC_NOMBRE") & " " &  rst_BM5("DOC_APELLIDO")
		g_programa = rst_BM5("PROGRA_DESC")
		g_V_FECHA = rst_BM5("ATE_DET_V_FECHA")
		g_R_FECHA = rst_BM5("ATE_DET_REC_FECHA")
		g_FUR = rst_BM5("ATE_FUR")
		
		'g_sector = rst_BM5("SECTOR_DESC")
				
	END IF	

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 30	
	Params("y") = 693
	Params("size") = 7	
	Page.Canvas.DrawText "RUT ", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 80	
	Params("y") = 693
	Params("size") = 7
	Page.Canvas.DrawText " : ", Params, Font
	'g_nombre

	Set Font = Doc.Fonts("Helvetica-Bold")
	Set Params = Pdf.CreateParam	
	Params("x") = 90	
	Params("y") = 693
	Params("size") = 8	
	Page.Canvas.DrawText g_rut, Params, Font
	

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 400	
	Params("y") = 705
	Params("size") = 7	
	Page.Canvas.DrawText "Folio", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 470	
	Params("y") = 705
	Params("size") = 7
	Page.Canvas.DrawText " : ", Params, Font

	Set Font = Doc.Fonts("Helvetica-Bold")
	Set Params = Pdf.CreateParam	
	Params("x") = 480
	Params("y") = 705
	Params("size") = 8
	Page.Canvas.DrawText g_numero, Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 30	
	Params("y") = 660
	Params("size") = 7
	Page.Canvas.DrawText "Médico", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 80	
	Params("y") = 660
	Params("size") = 7
	Page.Canvas.DrawText " : ", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 90	
	Params("y") = 660
	Params("size") = 8
	Page.Canvas.DrawText g_Medico_, Params, Font
	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 30
	Params("y") = 705
	Params("size") = 7	
	Page.Canvas.DrawText "Nombre", Params, Font
	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 80
	Params("y") = 705
	Params("size") = 7	
	Page.Canvas.DrawText " : ", Params, Font

	Set Font = Doc.Fonts("Helvetica-Bold")
	Set Params = Pdf.CreateParam	
	Params("x") = 90	
	Params("y") = 705
	Params("size") = 8
	Page.Canvas.DrawText g_nombre, Params, Font


	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 30
	Params("y") = 671
	Params("size") = 7	
	Page.Canvas.DrawText "Sexo", Params, Font
	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 80	
	Params("y") = 671
	Params("size") = 7
	Page.Canvas.DrawText " : ", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 90	
   Params("y") = 671
	Params("size") = 8	
	Page.Canvas.DrawText g_sexo, Params, Font
	
    IF g_FUR <> "" THEN
    FFFFUR_ = "FUR : " &  g_FUR
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 180	
    Params("y") = 671
	Params("size") = 8	
	Page.Canvas.DrawText FFFFUR_, Params, Font	
	END IF
		

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam
	Params("x") = 30	
	Params("y") = 682		
	Params("size") = 7	
	Page.Canvas.DrawText "Edad", Params, Font
	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 80	
	Params("y") = 682
	Params("size") = 7
	Page.Canvas.DrawText " : ", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 90	
	Params("y") = 682
	Params("size") = 8	
	Page.Canvas.DrawText g_edad & "", Params, Font


	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 400	
	Params("y") = 693
	Params("size") = 7
	Page.Canvas.DrawText "Fecha de Ingreso", Params, Font
	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 470	
	Params("y") = 693
	Params("size") = 7
	Page.Canvas.DrawText " : ", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 480	
	Params("y") = 693
	Params("size") = 8
	Page.Canvas.DrawText g_fecha , Params, Font
	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 400	
	Params("y") = 682	
	Params("size") = 7
	Page.Canvas.DrawText "Toma de Muestra", Params, Font
	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 470	
	Params("y") = 682	
	Params("size") = 7
	Page.Canvas.DrawText " : ", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 480	
	Params("y") = 682	
	Params("size") = 8
	IF isnull(g_R_FECHA) THEN 
	Page.Canvas.DrawText g_fecha , Params, Font
	ELSE
	Page.Canvas.DrawText g_R_FECHA , Params, Font
	END IF 
	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 400	
	Params("y") = 671	
	Params("size") = 7
	Page.Canvas.DrawText "Fecha de Validación", Params, Font
	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 470	
	Params("y") = 671
	Params("size") = 7
	Page.Canvas.DrawText " : ", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 480	
	Params("y") = 671	
	Params("size") = 8
	Page.Canvas.DrawText g_V_FECHA , Params, Font

  	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 400	
	Params("y") = 660
	Params("size") = 7	
	Page.Canvas.DrawText "Procedencia ", Params, Font

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 470
	Params("y") = 660
	Params("size") = 7
    Page.Canvas.DrawText " : ", Params, Font

	Set Font = Doc.Fonts("Helvetica-Bold")
	Set Params = Pdf.CreateParam	
	Params("x") = 480	
	Params("y") = 660
	Params("size") = 8
	Page.Canvas.DrawText g_Proce, Params, Font
    contLinea_ = contLinea_ +1.2
end function

Function Imprime_Hoja
	Dim TEXTO_PDF
	Dim TEXTO_PDF2
	Dim TEXTO_PDF3
	Dim TEXTO_PDF4
	Dim fecha
	Dim tiempo 
	
	Dim xg_caracter
	Dim xg_caracter2
	Dim xg_caracter3
	Dim xg_caracter4
	Dim xg_newpassword 
	Dim j

	Dim Actual 
	Dim min_v
	Dim seg_v

	TEXTO_PDF = Id_atencion_
	TEXTO_PDF =session("ID_ATEN")


	IF Trim(TEXTO_PDF) ="2011062200292077" THEN
		xg_caracter2 = "Resultado"+TEXTO_PDF+".PDF"
	ELSE
	Actual = Now() 
	tiempo = Trim(CLng(Minute(Actual) & Second(Actual)))
	min_v = Trim(CLng(minute(Actual)))
	seg_v = Trim(CLng(Second(Actual)))
	fecha = FormatDateTime(Actual, 2) 

	TEXTO_PDF = Id_atencion_
	TEXTO_PDF =session("ID_ATEN")

	xg_newpassword = ""
	for j=1 to len(Trim(TEXTO_PDF))
		xg_caracter = mid(TEXTO_PDF,j,1)
		xg_caracter = xg_caracter + asc(xg_caracter) 
	next
	xg_caracter = Right("00" & Hex(xg_caracter Mod 256), 2)


	xg_newpassword = ""
	for j=1 to len(Trim(tiempo))
		xg_caracter3 = mid(tiempo,j,1)
		xg_caracter3 = xg_caracter3 + asc(xg_caracter3) 
	next
	xg_caracter3 = Right("00" & Hex(xg_caracter3 Mod 256), 2)

	xg_caracter2 = "Resultado"+TEXTO_PDF+xg_caracter+min_v+seg_v+tiempo+xg_caracter3 +".PDF"
'	xg_caracter2 = "Resultado"+".PDF"
	END IF

	Filename = Doc.Save( Server.MapPath("/PDF/" + xg_caracter2), False )
'	Filename = Doc.Save( Server.MapPath("Examen.pdf"), False )
	'Filename = Doc.Save( Server.MapPath("Examen.pdf"), False )
end function


FUNCTION AGREGA_NUEVA_HOJA
	Width =  612
	Height = 792
	Set Page = Doc.Pages.Add( Width, Height )	
END FUNCTION

FUNCTION IMPRIME_METODO_DEBAJO_4(w_ID_PRUEBA, contLINEA_)
  	Dim Datos_COMPLETO
	Set rst_BM33 = connBM3.execute("IRISLABWEB_BUSCA_METODO_NUEVO '"&w_ID_PRUEBA&"' ")													
	BBBC =0
	WHILE NOT rst_BM33.eof
		BBBC = BBBC+1 
		rst_BM33.MOVENEXT
	WEND
	
	IF BBBC>0 THEN
		rst_BM33.MOVEFIRST
	END IF
	BBBC_1 =0
	contLINEA_ = contLINEA_ + 1.5
	w_METODO_NUEVO =""
	YY = 105 + (BBBC * 10)
	WHILE NOT rst_BM33.eof
	      YY = YY - 10
		IF BBBC_1 =0 THEN
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.Item("Helvetica-Oblique")
			w_METODO_NUEVO = rst_BM33("METO_DESC") 
			Datos_COMPLETO = "Método Analítico : " &    w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			 XX = 30
			Params("x") = XX
			' YY = 110
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 6
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_ = contLINEA_ + 1
		ELSE
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.Item("Helvetica-Oblique")
			w_METODO_NUEVO = rst_BM33("METO_DESC") 
			Datos_COMPLETO =   w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			 XX = 80
			Params("x") = XX
			' YY = 110
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 6
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_ = contLINEA_ + 1		
		END IF
		BBBC_1 = BBBC_1 +1
		rst_BM33.MOVENEXT
	wend
	
END FUNCTION


%>
