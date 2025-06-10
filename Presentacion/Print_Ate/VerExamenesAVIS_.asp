
<%@LANGUAGE="VBSCRIPT" CODEPAGE="1252"%>
<!--#include file ="ConexionIRIS.asp" -->


<%
	Set rst_BM3 = Server.CreateObject("ADODB.RecordSet")
	Set rst_BM33 = Server.CreateObject("ADODB.RecordSet")	
	Set rst_BM333 = Server.CreateObject("ADODB.RecordSet")	
	Set rst_BM4 = Server.CreateObject("ADODB.RecordSet")	
	Set rst_BM5 = Server.CreateObject("ADODB.RecordSet")
	Set rst_BM6 = Server.CreateObject("ADODB.RecordSet")	
	Set rst_BM_HORA = Server.CreateObject("ADODB.RecordSet")	
	Set rst_BM4_H = Server.CreateObject("ADODB.RecordSet")	
	Set rst_BM4_Hora = Server.CreateObject("ADODB.RecordSet")	

	oid_empresa1 = Request.querystring("id_cliente")
	'oid_empresa2 =	Request.querystring("dato2") / 3
	'oid_empresa3 =	Request.querystring("dato3") + 9

	'IF trim(oid_empresa1) = trim(oid_empresa2) THEN 
	'IF trim(oid_empresa1) = trim(oid_empresa3) THEN
	
	oid_empresa = oid_empresa1
	Dim id_per2 
	id_per2 = "0"
	'END IF
	'END IF
%>





<%
	Dim Filename
	Dim Pdf, Doc, Page

	Dim w_ID_PERFIL(50), w_IMP_SOLA(50), w_IMP_NOMBREPERF(50), w_Listo(50), w_ID_CF(50), w_NOMBRE_CF(50),cont_, contfinal ,contLINEA_, w_SECC_DESC(50), w_USU_NIC(50), w_NOMBRE_USU(50),w_USU_ID(50), w_BAC_SI(50), W_ANTIB(50), w_IMP_NOMBREPERF_2(50)
	
	Dim DATO_TITU, Activa_Linea_Resultado, w_SECC_DESC_WW, w_USU_NIC_WW, w_ID_ATENw2, w_ID_PACw2
	Id_atencion_  = (oid_empresa)


 	Set rst_BM3 = connBM3.execute("IRISLABWEB_BUSCA_LISTADO_EXAMENES_IMPRIMIR_ORDEN_IMPRESION_3 '"&Id_atencion_&"' ")	
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
		w_NOMBRE_USU(cont_)= rst_BM3("USU_NIC") '	
		w_USU_ID(cont_) = rst_BM3("ID_USUARIO")		
		IF  cont_  = 1 THEN
			w_USU_NIC_WW = w_USU_NIC(cont_)
		END IF		
		w_BAC_SI(cont_)= rst_BM3("CF_CULTIVOS") 	
		rst_BM3.MOVENEXT
		cont_ = cont_ + 1
	WEND		
	
	contLINEA_ = 1
	Activa_Linea_Resultado =0 
	CALL CREA_HOJA_OBJETOS
	CALL LLENA_MARCO_HOJA()

    Dim VNom, VApe, VFnac, VRut

	CALL LLENA_ENCABEZADO(w_ID_PERFIL(1))		
	Dim CANTIDAD_REG  
	Dim w_ID_PRUEBA, w_ID_PER_P, w_ID_UM, w_UM, w_ResultadoA, w_ResultadoN, w_Rango_DESDE, w_Rango_HASTA, w_ID_TP_RESUL, Imprime_F, w_Nom_Seccion, w_TP_Alerta
	CANTIDAD_REG  =0 
	Imprime_F = 0
	FOR A__=1 TO CONT_
		IF 	w_ID_PERFIL(A__) <> ""  THEN
			Set rst_BM3 = connBM3.execute("IRISLABWEB_GRABA_IMPRESION_FOLIO_WEB '"&w_ID_ATENw2&"', '"&w_ID_CF(A__)&"' ")
			Set rst_BM3 = connBM3.execute("IRISWEB_UPDATE_CANTIDAD_DE_IMPRESION_WEB_EXAMENES '"&w_ID_ATENw2&"', '"&w_ID_CF(A__)&"' ")	
			IF w_IMP_SOLA(A__) = 0 THEN
				IF TRIM(w_USU_NIC(A__)) = TRIM(w_USU_NIC_WW) THEN
							w_USU_NIC_WW  = w_USU_NIC(A__)  
							Id_atencion_ = oid_empresa 
							Set rst_BM3 = connBM3.execute("IRISLABWEB_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN '"&Id_atencion_&"', '"&w_ID_CF(A__)&"' ")		
    			
							 WHILE NOT rst_BM3.eof
								CANTIDAD_REG = CANTIDAD_REG + 1 
								rst_BM3.MOVENEXT
							WEND

							rst_BM3.MOVEFIRST
							
							IF contLINEA_ <> 1 THEN
								CANTIDAD_REG= CANTIDAD_REG + 1
							END IF

							IF contLINEA_ <= 1 THEN
								contLINEA_ = contLINEA_ 
							END IF       


							IF (CANTIDAD_REG + contLINEA_ ) < 50 THEN

								IF w_SECC_DESC(A__) <> w_SECC_DESC_WW   THEN
									w_SECC_DESC_WW =  w_SECC_DESC(A__)
    					
									IF A__ > 1 THEN									
									Imprime_F = 0
									contLINEA_ = 1																	
									CALL AGREGA_NUEVA_HOJA	
									CALL LLENA_ENCABEZADO(w_ID_PERFIL(A__))	
									CALL LLENA_MARCO_HOJA()
									END IF																								
								END IF

			                    CALL LINEAA(contLINEA_)	
                                CALL TIPO_PROCE(w_ID_PERFIL(A__))

								IF w_IMP_NOMBREPERF(A__) =1 THEN
									CALL IMPRIME_TITULO(w_IMP_NOMBREPERF_2(A__),contLINEA_)					
									contLINEA_ = contLINEA_ + 1
								END IF										
								
	                                IF Activa_Linea_Resultado = 0 THEN
									CALL Imprime_Linea_Datos_Resultados(contLINEA_)	
									'contLINEA_ = contLINEA_ + 1	
                                    Activa_Linea_Resultado = 1				
                                    END IF
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
    	                            w_TP_Alerta = trim(rst_BM3("ATE_RESULTADO_ALT"))
                                    w_EST_RECHAZO = rst_BM3("ATE_EST_RECHAZO")
									CALL IMPRIME_RESULTADO(NPRUEBA,w_ID_PRUEBA, w_ID_UM, w_UM, w_ResultadoA, w_ResultadoN, w_Rango_DESDE, w_Rango_HASTA, w_ID_TP_RESUL, contLINEA_, w_Nom_Seccion, w_TP_Alerta,w_ID_PER_P, w_FORMATON, w_TXT_EXTRA,w_EST_RECHAZO)	   
    									
									rst_BM3.MOVENEXT
									cont_ = cont_ + 1
									contLINEA_ = contLINEA_ + 1
     
								WEND
                                  CALL FECHA_HOY(contLINEA_,w_ID_CF(A__),w_ID_PRUEBA)
								CALL IMPRIME_DERIVADO_DEBAJO(w_ID_PER_P, contLINEA_)					
								IF Imprime_F = 0 THEN
									CALL IMPRIME_FIRMA_TECNOLOGO_CON_USUARIO(w_USU_ID(A__))
									CALL IMPRIME_VALIDADO_POR(w_NOMBRE_CF(A__),42, w_NOMBRE_USU(A__))	
									Imprime_F = 1
								END IF
							ELSE						
								
								Imprime_F = 0
								contLINEA_ = 1
								CALL AGREGA_NUEVA_HOJA	
								CALL LLENA_ENCABEZADO(w_ID_PERFIL(A__))	
								CALL LLENA_MARCO_HOJA()		
                                CALL LINEAA(contLINEA_)		
                                CALL TIPO_PROCE(w_ID_PERFIL(A__))	
    												
								IF w_IMP_NOMBREPERF(A__) =1 THEN
									CALL IMPRIME_TITULO(w_IMP_NOMBREPERF_2(A__),contLINEA_)					
									contLINEA_ = contLINEA_ + 1
								END IF					
								
								CALL Imprime_Linea_Datos_Resultados(contLINEA_)	
								'contLINEA_ = contLINEA_ + 1													
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
									CALL IMPRIME_RESULTADO(NPRUEBA,w_ID_PRUEBA, w_ID_UM, w_UM, w_ResultadoA, w_ResultadoN, w_Rango_DESDE, w_Rango_HASTA, w_ID_TP_RESUL, contLINEA_, w_Nom_Seccion, w_TP_Alerta,w_ID_PER_P,w_FORMATON, w_TXT_EXTRA,w_EST_RECHAZO)										
									rst_BM3.MOVENEXT
									cont_ = cont_ + 1
									contLINEA_ = contLINEA_ + 1
								WEND
							'	CALL IMPRIME_METODO_DEBAJO(w_ID_PER_P, contLINEA_)	
								CALL FECHA_HOY(contLINEA_,w_ID_CF(A__),w_ID_PRUEBA)					
								CALL IMPRIME_DERIVADO_DEBAJO(w_ID_PER_P, contLINEA_)																
								IF Imprime_F = 0 THEN
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
								CALL LLENA_MARCO_HOJA()
								w_SECC_DESC_WW =""															

								IF w_SECC_DESC(A__) <> w_SECC_DESC_WW THEN
									w_SECC_DESC_WW =  w_SECC_DESC(A__)
									
								END IF
                                CALL LINEAA(contLINEA_)		
                                CALL TIPO_PROCE(w_ID_PERFIL(A__))		
								IF w_IMP_NOMBREPERF(A__) =1 THEN
									CALL IMPRIME_TITULO(w_IMP_NOMBREPERF_2(A__),contLINEA_)					
									contLINEA_ = contLINEA_ + 1
								END IF					
							
									CALL Imprime_Linea_Datos_Resultados(contLINEA_)	
									'contLINEA_ = contLINEA_ + 1					

								Set rst_BM3 = connBM3.execute("IRISLABWEB_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN '"&Id_atencion_&"', '"&w_ID_CF(A__)&"' ")		
    								NPRUEBA = 0
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
									w_FORMATON = rst_BM3("PRU_FORMATON")	
									w_TXT_EXTRA = rst_BM3("ATE_RES_TEXTO_EXTRA")	
                                    w_TP_Alerta = rst_BM3("ATE_RESULTADO_ALT") 																							
									w_EST_RECHAZO = rst_BM3("ATE_EST_RECHAZO")
                                    CALL IMPRIME_RESULTADO(NPRUEBA,w_ID_PRUEBA, w_ID_UM, w_UM, w_ResultadoA, w_ResultadoN, w_Rango_DESDE, w_Rango_HASTA, w_ID_TP_RESUL, contLINEA_, w_Nom_Seccion, w_TP_Alerta,w_ID_PER_P, w_FORMATON, w_TXT_EXTRA,w_EST_RECHAZO)										
									rst_BM3.MOVENEXT
									cont_ = cont_ + 1
									contLINEA_ = contLINEA_ + 1
								WEND
                                 CALL FECHA_HOY(contLINEA_,w_ID_CF(A__),w_ID_PRUEBA)
							CALL IMPRIME_DERIVADO_DEBAJO(w_ID_PER_P, contLINEA_)
								IF Imprime_F = 0 THEN
									CALL IMPRIME_FIRMA_TECNOLOGO_CON_USUARIO(w_USU_ID(A__))
									CALL IMPRIME_VALIDADO_POR(w_NOMBRE_CF(A__),42, w_NOMBRE_USU(A__))	
									Imprime_F = 1
								END IF																		
					END IF
			ELSE
				IF w_IMP_SOLA(A__) = 1 THEN
					Id_atencion_ = oid_empresa 
					Set rst_BM3 = connBM3.execute("IRISLABWEB_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN '"&Id_atencion_&"', '"&w_ID_CF(A__)&"' ")	
    				
					 WHILE NOT rst_BM3.eof
						CANTIDAD_REG = CANTIDAD_REG +1 
						rst_BM3.MOVENEXT
					WEND

					IF CANTIDAD_REG <> 0 THEN
						Set rst_BM3 = connBM3.execute("IRISLABWEB_BUSCA_VISOR_DETALLE_RESULTADO_SECCION_EXAMEN '"&Id_atencion_&"', '"&w_ID_CF(A__)&"' ")					
					END IF
					
					IF contLINEA_ <> 1 THEN
						contLINEA_ = contLINEA_ + 1
						CANTIDAD_REG= CANTIDAD_REG +2
					END IF
			
					Activa_Linea_Resultado =0					
					contLINEA_ = 1	
    			
					IF (A__) <> 1 THEN
						CALL AGREGA_NUEVA_HOJA	
						CALL LLENA_ENCABEZADO(w_ID_PERFIL(A__))	
						CALL LLENA_MARCO_HOJA()															
					END IF

					IF w_SECC_DESC(A__) <> w_SECC_DESC_WW THEN
						w_SECC_DESC_WW =  w_SECC_DESC(A__)
					END IF
                    
				    CALL LINEAA(contLINEA_)	
                    CALL TIPO_PROCE_2(w_ID_PERFIL(A__))	

					IF w_IMP_NOMBREPERF(A__) =1 THEN
						CALL IMPRIME_TITULO_1H(w_IMP_NOMBREPERF_2(A__),contLINEA_)
						contLINEA_ = contLINEA_ + 1
					END IF					

					act_nuevo_firma =false
                    CALL Imprime_Linea_Datos_Resultados(contLINEA_)

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
						w_TP_Alerta = trim(rst_BM3("ATE_RESULTADO_ALT")) 		
                        w_EST_RECHAZO = rst_BM3("ATE_EST_RECHAZO")												
						CALL IMPRIME_RESULTADO_NUEVO(w_ID_PRUEBA, w_ID_UM, w_UM, w_ResultadoA, w_ResultadoN, w_Rango_DESDE, w_Rango_HASTA, w_ID_TP_RESUL, contLINEA_, w_Nom_Seccion, w_TP_Alerta,w_FORMATON, w_EST_RECHAZO)										
						rst_BM3.MOVENEXT
						cont_ = cont_ + 1
						if w_ResultadoA <> "-" then
                            contLINEA_ = contLINEA_ + 1.5
                        else
                            contLINEA_ = contLINEA_ + 1.5
                        end if
						act_nuevo_firma =true
					WEND

					CALL FECHA_HOY(contLINEA_,w_ID_CF(A__),w_ID_PRUEBA)
					CALL IMPRIME_DERIVADO_DEBAJO(w_ID_PER_P, contLINEA_)
					IF w_BAC_SI(A__) <> "" THEN
						IF w_BAC_SI(A__) = "1" THEN
						
							Set rst_BM3 = connBM3.execute("IRIS_BUSCA_CULTIVO_POR_ID_CF_ORDENADOS  '"&w_ID_CF(A__)&"','"&Id_atencion_&"' ")		
							CANTIDAD_ANT = 0
							IF NOT rst_BM3.eof THEN
							MAXXX_YY =  session("anti") - 15
					        END IF
					        Dim antib
					        antib = 0

							 WHILE NOT rst_BM3.eof
								CANTIDAD_ANT = (CANTIDAD_ANT) + 1 
								CF_ID = rst_BM3("ID_CF_ANTIBIOGRAMA") 

								IF (CANTIDAD_ANT) = 1 THEN
									XXX_VV = MAXXX_XX
									YYY_VV = MAXXX_YY - 25
									FILAMAXX_VV = MAXXX_YY -15
									CEPA__ =  CANTIDAD_ANT
								END IF

								IF (CANTIDAD_ANT) = 2 THEN
									XXX_VV = MAXXX_XX + 200
									YYY_VV = MAXXX_YY - 25
									FILAMAXX_VV = MAXXX_YY -15									
									CEPA__ =  CANTIDAD_ANT									
								END IF

								IF (CANTIDAD_ANT) =3 THEN
									
									XXX_VV = MAXXX_XX + 375
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
                            if rst_BM3.eof THEN

    Set rst_BM3= connBM3.execute("IRIS_BUSCA_ID_CF_LINK_ANTIBIOGRAMA '"&w_ID_PER_P&"' ")

							CANTIDAD_ANT = 0
							if not rst_BM3.eof THEN
					           'by Drap		
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
									
									XXX_VV = MAXXX_XX + 375
									YYY_VV = MAXXX_YY - 25
									FILAMAXX_VV = MAXXX_YY -15
									CEPA__ =  CANTIDAD_ANT									
								END IF
								ID_DET_ATE = "null"
								ID_ATEVV_ = Id_atencion_
								if isnull(ID_DET_ATE) THEN
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
					
					IF act_nuevo_firma = true THEN
						IF A__ >2 THEN						
							CALL IMPRIME_FIRMA_TECNOLOGO_CON_USUARIO(w_USU_ID(A__))							
							CALL IMPRIME_VALIDADO_POR(w_NOMBRE_CF(A__),42, w_NOMBRE_USU(A__ - 2))
						ELSE
							CALL IMPRIME_FIRMA_TECNOLOGO_CON_USUARIO(w_USU_ID(A__))							
						END IF
					END IF															
				END IF
			END IF		
		END IF
	NEXT		
	CALL IMPRIME_ULTIMA_LINEA
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
        document.location.href = "<%= "../PDF/" + Filename%>" ;
    </script>
</body>
</html>

<%
FUNCTION LINEAA(contLINEA_)
    contLINEA_=contLINEA_+ 0.5
    IF contLINEA_ < 1.6 THEN
    contLINEA_ = 2.7 
    END IF
    Set Params = Pdf.CreateParam	
    YY = 665 - (contLINEA_ * 11)
    Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 10	
	Params("y") = YY
	Params("size") = 8	
	Page.Canvas.DrawText "___________________________________________________________________________________________________________________________________", Params, Font
	contLINEA_=contLINEA_+1
END FUNCTION

FUNCTION IMPRIME_ULTIMA_LINEA

	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	contLINEA_ = 49
	XX =  10
	YY = 665 - (contLINEA_ * 11)		
	Params("x") = XX	
	Params("y") = YY
	Params("size") = 9
	'Page.Canvas.DrawText "Resultado", Params, Font
END FUNCTION

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
    contfinal = 1
    ELSE

    Set Font = Doc.Fonts("Arial")
    IF CANTIDAD_ANT =3 THEN
    Params("x") = XXX_VVV +  130
    ELSE
    Params("x") = XXX_VVV +  150
    END IF
		
		Params("y") = (FILAMAXX_VV)-30 - ( CANTIDAD_ANT2 *2)
		Params("size") = 6.5
		Page.Canvas.DrawText FR_TEXTO_, Params, Font		
    END IF
    '/////					
			
	'END IF
	contLINEA_=contLINEA_+2
	rst_BM_HORA.MOVENEXT
WEND

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
	Set Font = Doc.Fonts("Helvetica-Bold")
	Set Params = Pdf.CreateParam	
	CANT_LEN = LEN(DATO_TITU)
	CANT_LEN2 = CANT_LEN / 2
	Width_ =  500 / 2	
	XX =  30
	YY = 665 - (NLINEA * 11)
	Params("x") = XX	
	Params("y") = YY
	Params("size") = 8

    IF DATO_TITU = "VIH" or DATO_TITU = "Test VIH" THEN
    DATO_TITU = VNom&VApe&VFnac&VRut
    END IF

	Page.Canvas.DrawText DATO_TITU, Params, Font
    contLinea_ = contLinea_ +1
END FUNCTION

FUNCTION IMPRIME_TITULO_NUEVO(DATO_TITU, NLINEA)
	NLINEA= NLINEA 
	RUTA_ ="c:\windows\fonts\arialbd.ttf" 											
	Set Font = Doc.Fonts("Helvetica-Bold")

	Set Params = Pdf.CreateParam	
	CANT_LEN = LEN(DATO_TITU)
	CANT_LEN2 = CANT_LEN / 2
	Width_ =  500 / 2	
	XX =  30
	YY = 665 - (NLINEA * 11)
	Params("x") = 500	
	Params("y") = YY
	Params("size") = 8

    IF DATO_TITU = "VIH" or DATO_TITU = "Test VIH" THEN
    DATO_TITU = VNom&VApe&VFnac&VRut
    END IF

	Page.Canvas.DrawText DATO_TITU, Params, Font
	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 30	
	Params("y") =  665 - (NLINEA * 11)
	Params("size") = 8	
	Page.Canvas.DrawText "___________________________________________________________________________________________________________________________________", Params, Font
END FUNCTION

FUNCTION TIPO_PROCE(w_ID_PER_P)
    Dim Datos_COMPLETO
	Set rst_BM33 = connBM3.execute("IRISLABWEB_BUSCA_TIPO_DE_MUESTRA_ID_PER '"&CLng(w_ID_PER_P)&"' ")	
	Set rst_BM333 = connBM3.execute("IRISLABWEB_BUSCA_ANALIZADOR_ID_PER '"&CLng(w_ID_PER_P)&"' ")												
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
			Set Font = Doc.Fonts.Item("Helvetica-Oblique")	
			w_METODO_NUEVO = rst_BM33("MUESTRA_SANGRE_DESC") 
			Datos_COMPLETO = "Tipo de Muestra : " &  w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  30
			YY = 665 - (contLINEA_ * 11)		
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 6
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_=contLINEA_+1
		ELSE
			Set Font = Doc.Fonts.Item("Helvetica-Oblique")	
			w_METODO_NUEVO = rst_BM33("MUESTRA_SANGRE_DESC") 
			Datos_COMPLETO = "                   " &  w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  30
			YY = 665 - (contLINEA_ * 11)						
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 6
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_=contLINEA_+1
		END IF
		rst_BM33.MOVENEXT	
	WEND
	
	 WHILE NOT rst_BM333.eof
		IF BBBC_1 =0 THEN
			Set Font = Doc.Fonts.Item("Helvetica-Oblique")	
			w_ANALIZADOR_NUEVO = rst_BM333("ANAL_DESC") 
	        Set Params = Pdf.CreateParam	
			XX =  30
			YY = 665 - (contLINEA_ * 11)					
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 6
			Page.Canvas.DrawText w_ANALIZADOR_NUEVO, Params, Font
			contLINEA_=contLINEA_+1
		ELSE
			Set Font = Doc.Fonts.Item("Helvetica-Oblique")	
			w_ANALIZADOR_NUEVO = rst_BM333("ANAL_DESC") 
	        Set Params = Pdf.CreateParam	
			XX =  30
			YY = 665 - (contLINEA_ * 11)					
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 6
			Page.Canvas.DrawText w_ANALIZADOR_NUEVO, Params, Font			
			contLINEA_=contLINEA_+1	
		END IF
		rst_BM333.MOVENEXT	
	WEND
END FUNCTION


FUNCTION TIPO_PROCE_2(w_ID_PER_P)
    Dim Datos_COMPLETO
	Set rst_BM33 = connBM3.execute("IRISLABWEB_BUSCA_TIPO_DE_MUESTRA_ID_PER '"&CLng(w_ID_PER_P)&"' ")	
	Set rst_BM333 = connBM3.execute("IRISLABWEB_BUSCA_ANALIZADOR_ID_PER '"&CLng(w_ID_PER_P)&"' ")												
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
			Set Font = Doc.Fonts.Item("Helvetica-Oblique")	
			w_METODO_NUEVO = rst_BM33("MUESTRA_SANGRE_DESC") 
			Datos_COMPLETO = "Tipo de Muestra : " &  w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  30
			YY = 100	
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 6
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_=contLINEA_+1
		ELSE
			Set Font = Doc.Fonts.Item("Helvetica-Oblique")	
			w_METODO_NUEVO = rst_BM33("MUESTRA_SANGRE_DESC") 
			Datos_COMPLETO = "                   " &  w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  30
			YY = 100						
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 6
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_=contLINEA_+1
		END IF
		rst_BM33.MOVENEXT	
	WEND
	
	 WHILE NOT rst_BM333.eof
		IF BBBC_1 =0 THEN
			Set Font = Doc.Fonts.Item("Helvetica-Oblique")	
			w_ANALIZADOR_NUEVO = rst_BM333("ANAL_DESC") 
	        Set Params = Pdf.CreateParam	
			XX =  30
			YY = 90					
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 6
			Page.Canvas.DrawText w_ANALIZADOR_NUEVO, Params, Font
			contLINEA_=contLINEA_+1
		ELSE
			Set Font = Doc.Fonts.Item("Helvetica-Oblique")	
			w_ANALIZADOR_NUEVO = rst_BM333("ANAL_DESC") 
	        Set Params = Pdf.CreateParam	
			XX =  30
			YY = 90				
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 6
			Page.Canvas.DrawText w_ANALIZADOR_NUEVO, Params, Font			
			contLINEA_=contLINEA_+1	
		END IF
		rst_BM333.MOVENEXT	
	WEND
END FUNCTION

FUNCTION IMPRIME_TITULO_1H(DATO_TITU, NLINEA)
	NLINEA= NLINEA 
	Set Font = Doc.Fonts("Helvetica-Bold")
	Set Params = Pdf.CreateParam	
	CANT_LEN = LEN(TRIM(DATO_TITU))
	CANT_LEN2 = CANT_LEN / 2
	Width_ =  500 / 2	
	XX =  30
	YY =665 - (NLINEA * 11) 
	Params("x") = XX	
	Params("y") = YY
	Params("size") = 8

    IF DATO_TITU = "VIH" or DATO_TITU = "Test VIH" THEN
    DATO_TITU = VNom&VApe&VFnac&VRut
    END IF

	Page.Canvas.DrawText DATO_TITU, Params, Font
    contLinea_ = contLinea_ +1
END FUNCTION

FUNCTION IMPRIME_VALIDADO_POR(DATO_TITU, NLINEA, NOM_VALIDA)
	Dim Datos_COMPLETO
	RUTA_ ="c:\windows\fonts\arial.ttf" 											
	Set Font = Doc.Fonts.LoadFromFile(RUTA_)
	Datos_COMPLETO = "Examen(es) Validado Por: " &  NOM_VALIDA
	Set Params = Pdf.CreateParam	
	Width_ =  500 / 2	
	XX =  17
	YY = 665 - (NLINEA * 11)
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
			Set Font = Doc.Fonts.LoadFromFile(RUTA_)
			w_METODO_NUEVO = rst_BM33("METO_DESC") 
			Datos_COMPLETO = w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  470
			YY = contLINEA_ 		
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 7
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_ = contLINEA_ + 1
		ELSE
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.LoadFromFile(RUTA_)
			w_METODO_NUEVO = rst_BM33("METO_DESC") 
			Datos_COMPLETO =   w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX = 500
			YY = 665 - (contLINEA_ * 11)			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 7
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_ = contLINEA_ + 1		
		END IF
		rst_BM33.MOVENEXT
	WEND	
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
			Set Font = Doc.Fonts.LoadFromFile(RUTA_)
			w_METODO_NUEVO = rst_BM33("MUESTRA_SANGRE_DESC") 
			Datos_COMPLETO = "Tipo de Muestra : " &  w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  17
			YY = 665 - (contLINEA_ * 11)				
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 7
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_ = contLINEA_ + 0.25
		ELSE
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts.LoadFromFile(RUTA_)
			w_METODO_NUEVO = rst_BM33("MUESTRA_SANGRE_DESC") 
			Datos_COMPLETO = "                   " &  w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  17
			YY = 665 - (contLINEA_ * 11)					
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 7
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_ = contLINEA_ + 0.05	
		END IF
		rst_BM33.MOVENEXT
	WEND	
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
			Set Font = Doc.Fonts("Times New Roman")												
			w_METODO_NUEVO = rst_BM33("METO_DESC") 
			Datos_COMPLETO = "Método Analítico : " &w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  17
			YY = 94						
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 8
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_ = contLINEA_ + 1
		ELSE
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			
			Set Font = Doc.Fonts("Times New Roman")
			w_METODO_NUEVO = rst_BM33("METO_DESC") 
			Datos_COMPLETO =         w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  17
			YY = 94					
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 8
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
			contLINEA_ = contLINEA_ + 1		
		END IF
		rst_BM33.MOVENEXT
	WEND	
END FUNCTION

FUNCTION IMPRIME_TIPO_MUESTRA_DEBAJO2(WID_PERFIL, contLINEA_)
	Dim Datos_COMPLETO
	Set rst_BM33 = connBM3.execute("IRISLABWEB_BUSCA_TIPO_DE_MUESTRA_ID_PER '"&CLng(WID_PERFIL)&"' ")	
	Set rst_BM333 = connBM3.execute("IRISLABWEB_BUSCA_ANALIZADOR_ID_PER '"&CLng(WID_PERFIL)&"' ")												
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
			Set Font = Doc.Fonts("Times New Roman")
			w_METODO_NUEVO = rst_BM33("MUESTRA_SANGRE_DESC") 	    	
			Datos_COMPLETO = "Tipo de Muestra : " &  w_METODO_NUEVO
			Set Params = Pdf.CreateParam	
			XX =  17
			YY = 86			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 8
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font								
		ELSE
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts("Times New Roman")
			w_METODO_NUEVO = rst_BM33("MUESTRA_SANGRE_DESC") 
			Datos_COMPLETO = "                   " &  w_METODO_NUEVO			
			Set Params = Pdf.CreateParam	
			XX =  17
			YY = 86
			'YY = 80			
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 8
			Page.Canvas.DrawText Datos_COMPLETO, Params, Font
		END IF
		rst_BM33.MOVENEXT	
	WEND
	
	 WHILE NOT rst_BM333.eof
		IF BBBC_1 =0 THEN
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts("Times New Roman")
			w_ANALIZADOR_NUEVO = rst_BM333("ANAL_DESC") 
	        Set Params = Pdf.CreateParam	
			XX =  17
			YY = 78						
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 8
			Page.Canvas.DrawText w_ANALIZADOR_NUEVO, Params, Font			
		ELSE
			RUTA_ ="c:\windows\fonts\arial.ttf" 											
			Set Font = Doc.Fonts("Times New Roman")
			w_ANALIZADOR_NUEVO = rst_BM333("ANAL_DESC") 
	        Set Params = Pdf.CreateParam	
			XX =  17
			YY = 78					
			Params("x") = XX	
			Params("y") = YY
			Params("size") = 8
			Page.Canvas.DrawText w_ANALIZADOR_NUEVO, Params, Font			
		END IF
		rst_BM333.MOVENEXT	
	WEND	
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
	contLINEA_ = contLINEA_ + 1
	w_METODO_NUEVO =""


   ' RUTA_ ="c:\windows\fonts\arial.ttf" 											
	'		Set Font = Doc.Fonts.LoadFromFile(RUTA_)
	'		'w_METODO_NUEVO = rst_BM33("DERI_DESC") 
	'		Datos_COMPLETO = "Derivado a : " &  w_METODO_NUEVO
	'		Set Params = Pdf.CreateParam	
	'		XX =  30
	'		YY = 665 - (contLINEA_ * 11)
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
			YY = 665 - (contLINEA_ * 11)
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
			YY = 665 - (contLINEA_ * 11)
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
	Set Params = Pdf.CreateParam	
	CANT_LEN = LEN(DATO_TITU)
	CANT_LEN2 = CANT_LEN / 2
	Width_ =  500 / 2	
	XX =  (Width_ -  CANT_LEN2)
	YY = 665 - (NLINEA * 11)
	Params("x") = XX	
	Params("y") = YY
	Params("size") = 10

    IF DATO_TITU = "VIH" or DATO_TITU = "Test VIH" THEN
    DATO_TITU = VNom&VApe&VFnac&VRut
    END IF

	Page.Canvas.DrawText DATO_TITU, Params, Font
END FUNCTION

FUNCTION IMPRIME_RESULTADO(NPRUEBA, w_ID_PRUEBA, w_ID_UM, w_UM, w_ResultadoA, w_ResultadoN, w_Rango_DESDE, w_Rango_HASTA, w_ID_TP_RESUL, contLINEA_, w_Nom_Seccion, w_TP_Alerta,w_ID_PER_P,w_FORMATON, w_TXT_EXTRA,w_EST_RECHAZO)	
    Dim YYYY 
    Dim YY
	Set rst_BM4 = connBM3.execute("IRISLABWEB_BUSCA_FORMATO_DE_PRUEBA_2 '"&w_ID_PRUEBA&"'")	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
    YY = 665 - (contLINEA_ * 11)
   
    IF rst_BM4.eof  THEN
    contLINEA_ = contLINEA_ -1
    END IF
     pfila = 0
	 WHILE NOT rst_BM4.eof
		Dim FR_OBJETO_, FR_COLUMNA_, FR_TEXTO_, FR_TAMANO_, LET_DESC_, COLUMNA_, XX, CONCATE_, NC
		FR_OBJETO_ =  rst_BM4("FR_OBJETO")
		FR_COLUMNA_ = rst_BM4("FR_COLUMNA")
        Set Font = Doc.Fonts.Item("Helvetica")	
		FR_TEXTO_ = rst_BM4("FR_TEXTO")
        FR_TEXTO_ = Replace(FR_TEXTO_, "–","-")
		FR_TAMANO_ = rst_BM4("FR_TAMANO")				
		LET_DESC_ = rst_BM4("LET_DESC")
		COLUMNA_ = (FR_COLUMNA_)
		XX = (rst_BM4("FR_FILA"))
		wID_TP_RESUL_ = rst_BM4("ID_TP_RESULTADO")
        
		
		IF pfila = 0 THEN	        
		IF NPRUEBA = 1 THEN
		CALL IMPRIME_METODO_DEBAJO_3(w_ID_PRUEBA, contLINEA_)
		END IF
		END IF
		pfila = pfila + 1
    

		IF FR_OBJETO_ ="Iris_Nombre" THEN
			IF TRIM(FR_TEXTO_) <> ":" THEN
				IF CLng(FR_COLUMNA_) < 4500 THEN
					IF CLng(FR_COLUMNA_) < 551 THEN
						XX = 30
						Params("x") = XX				
						YY = 665  - (contLINEA_ * 11)
						Params("y") = YY
						Params("size") = 6.5
                        IF FR_TEXTO_ = "VIH" or DATO_TITU = "Test VIH" THEN
                            FR_TEXTO_= VNom&VApe&VFnac&VRut
                        END IF
						Page.Canvas.DrawText FR_TEXTO_, Params, Doc.Fonts("Helvetica-Bold")	
						VALOR_YYY =	YY
                     END IF			
					IF CLng(FR_COLUMNA_) > 550 THEN  
                       IF(CLng(w_EST_RECHAZO) <> 16) THEN
                        YY = (665 - (contLINEA_+(YYYY)) * 11)
                        YYYY=YYYY+1
						XX = 300						
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
					    
					    YY = 665   - (contLINEA_ * 11)
    
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
					    
					    YY = 665   - (contLINEA_ * 11)
                        
					    Params("y") = YY
					    Params("size") = 6.5
						'contLINEA_ = contLINEA_ + 1
					    Page.Canvas.DrawText FR_TEXTO_, Params,  Font               
                        END IF
						end if
					else
     IF(CLng(w_EST_RECHAZO) <> 16) THEN
					YY = 665 - (contLINEA_ * 11)
					IF YY = VALOR_YYY THEN	
                    				
					    XX = 300
					    Params("x") = XX					    
					    YY = 665 - (contLINEA_ * 11)
					    Params("y") = YY
					    Params("size") = 6.5						
					    Page.Canvas.DrawText FR_TEXTO_, Params,  Font	
					    VALOR_YYY=""
                    ELSE
					contLINEA_ = contLINEA_ + 1
  					    XX = 300
					    Params("x") = XX 
					    YY = 665 - (contLINEA_ * 11)                       
					    Params("y") = YY
					    Params("size") = 6.5
						'contLINEA_ = contLINEA_ + 1
					    Page.Canvas.DrawText FR_TEXTO_, Params,  Font                 
                    END IF	
    END IF											
				END IF
				end if
			ELSE
     IF(CLng(w_EST_RECHAZO) <> 16) THEN
				XX = (Clng(COLUMNA_)/10)-100					
				Params("x") = XX	
				Params("y") = 665 - (contLINEA_ * 11)
				Params("size") = 6.5
				Page.Canvas.DrawText FR_TEXTO_, Params, Font	
    END IF		
			END IF		
		END IF
			IF FR_OBJETO_ ="Iris_Det" THEN
            YYYY=0
			IF CLng(w_ID_TP_RESUL) = 1 THEN
			    XX = 145
				Params("x") = XX	
				Params("y") = 665 - (contLINEA_ * 11)
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
					w_ResultadoA = TRIM(w_ResultadoA)					
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
    Params("y") = 665   - (contLINEA_ * 11) 
    Page.Canvas.DrawText Trim(res1), Params, Font

    For y = mitad+1 to UBound(ArrRes)
	res2 = res2&" "&ArrRes(y)
    Next 
    Params("y") = 665   - ((contLINEA_+1) * 11)
	Page.Canvas.DrawText Trim(res2), Params, Font  
    contfinal = 1
    ELSE
    Page.Canvas.DrawText Trim(w_ResultadoA), Params, Font
    END IF
				END IF 		
		
			ELSE
				XX = 145				
				Params("x") = XX	
				Params("y") = 665 - (contLINEA_ * 11)
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
	        IF (CLng(id_per2) <> CLng(w_ID_PER_P)) THEN 

		        id_per2 = w_ID_PER_P
	        END IF 						
		END IF	
    			
		IF FR_OBJETO_ ="Iris_Unidad" THEN
     IF(CLng(w_EST_RECHAZO) <> 16) THEN						
			IF CLng(w_ID_UM) <> 1 THEN
				IF w_UM <> "" THEN
					XX = 240	
					
					YY = 665 - (contLINEA_ * 11)			
					Params("x") = XX	
					Params("y") = YY
					Params("size") = 6.5
					Page.Canvas.DrawText w_UM, Params, Font
				END IF		
			END IF
    END IF
		END IF

		IF FR_OBJETO_ ="Iris_RHisto" THEN
     IF(CLng(w_EST_RECHAZO) <> 16) THEN
		    Set rst_BM4_H = connBM3.execute("IRISLABWEB_BUSCA_HISTORICO_PRUEBA_VALIDADA '"&w_ID_PACw2&"' , '"&w_ID_PRUEBA&"', '"&w_ID_ATENw2&"' ")	
		     WHILE NOT rst_BM4_H.eof
	
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
			    Params("y") =  665 - (contLINEA_ * 11)	

			    Params("size") = 6.5
			    Page.Canvas.DrawText 	RESNUM_ALFA, Params, Font	    
	        END IF	
    END IF    
		END IF
		IF FR_OBJETO_ ="Iris_FHisto" THEN
     IF(CLng(w_EST_RECHAZO) <> 16) THEN
		    Set rst_BM4_H = connBM3.execute("IRISLABWEB_BUSCA_HISTORICO_PRUEBA_VALIDADA '"&w_ID_PACw2&"' , '"&w_ID_PRUEBA&"', '"&w_ID_ATENw2&"' ")	
		     WHILE NOT rst_BM4_H.eof
	            IF wID_TP_RESUL_ ="1" OR wID_TP_RESUL_ ="3" THEN
	                RESNUM_ALFA_FECHA =   FormatDateTime(rst_BM4_H("ATE_FECHA"),2)
	            ELSE
	                RESNUM_ALFA_FECHA =   FormatDateTime(rst_BM4_H("ATE_FECHA"),2)
		        END IF 
		        rst_BM4_H.MOVENEXT
	        WEND	    
	        IF 	RESNUM_ALFA_FECHA <> "" THEN
			    XX = 480			
			    Params("x") = XX				    
			    YY = 665 - (contLINEA_ * 11)
			    Params("y") = YY
			    Params("size") = 6.5
			    Page.Canvas.DrawText RESNUM_ALFA_FECHA, Params, Font	    
	        END IF	    
		END IF	
    END IF	
			IF FR_OBJETO_ ="Iris_Rango" THEN
				IF(CLng(w_EST_RECHAZO) <> 16) THEN
					IF TRIM(w_Rango_DESDE) <> "" AND TRIM(w_Rango_HASTA) <> "" THEN			
						VALOR_COLUMNA_RANGO = COLUMNA_
						XX = 300																		
						Params("x") = XX	
						Params("y") = YY
						Params("size") = 6.5				
						IF ISNULL(w_FORMATON) OR (w_FORMATON) = "0" THEN
							XX = 300														
							Params("x") = XX	
							Params("y") = 665 - (contLINEA_ * 11)						
						ELSE 
							w_Rango_DESDE = REPLACE(w_Rango_DESDE,",","")
							w_Rango_DESDE = REPLACE(w_Rango_DESDE,".","")
							w_Rango_DESDE = TRIM(w_Rango_DESDE)
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
						END IF		
						IF ISNULL(w_FORMATON) OR (w_FORMATON) = "0" THEN
							XX = 300													
							Params("x") = XX	
							Params("y") = 665 - (contLINEA_ * 11)						
						ELSE 
							w_Rango_HASTA = REPLACE(w_Rango_HASTA,",","")
							w_Rango_HASTA = REPLACE(w_Rango_HASTA,".","")
							w_Rango_HASTA = TRIM(w_Rango_HASTA)
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
						END IF					
					if trim(w_TP_Alerta) = "A" or trim(w_TP_Alerta) = "B" THEN
					RUTA_ ="c:\windows\fonts\arialbd.ttf" 
					Set Font = Doc.Fonts.LoadFromFile(RUTA_)
					'XX = (COLUMNA_/10)- 140														
					Params("x") = 300	
					Params("y") = 665   - (contLINEA_  * 11)	
					Params("size") = 6.5
					CONCATE_ = "[ * ]" 
					Page.Canvas.DrawText CONCATE_, Params, Font				
					
					Set Font = Doc.Fonts("Arial")
					XX = 310														
					Params("x") = XX	
					Params("y") = 665   - (contLINEA_  * 11)	
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
							Params("y") = 665   - (contLINEA_  * 11)	
							Params("size") = 6.5									
							CONCATE_ = w_Rango_DESDE & " - " & w_Rango_HASTA
							Page.Canvas.DrawText CONCATE_, Params, Font					
						ELSE
							Set Font = Doc.Fonts("Arial")
							XX = 300												
							Params("x") = XX	
							Params("y") = 665   - (contLINEA_  * 11)	
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
		XX = 300																		
		Params("x") = XX	
    
		contLINEA_=contLINEA_+1
		YY = 665   - (contLINEA_ * 11)
        
		Params("y") = YY
								
		Params("size") = 6.5

		VALOR_COLUMNA_RANGO =""
	END IF
    
    
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
	Param("ScaleX") = (0.45)
	Param("ScaleY") =(0.45)			
	'Page.Canvas.DrawImage Image2, Param
	ELSE

    'if(Len(rst_BM4("USU_FIRMA").Value) > 4) then
	Set rst_BM4 = connBM3.execute("NET_IRISLABWEB_BUSCA_RUTA_IMG '"&CLng(w_USUARIO_2)&"'")
	Set Image2 = Doc.OpenImageBinary( rst_BM4("USU_FIRMA").Value ) 
	Set Param = Pdf.CreateParam
	Param("x") = 400
	Param("y") = 30
	Param("ScaleX") = (5)
	Param("ScaleY") =(5)			
	Page.Canvas.DrawImage Image2, Param
    'END IF
	END IF
END FUNCTION

FUNCTION IMPRIME_RESULTADO_NUEVO(w_ID_PRUEBA, w_ID_UM, w_UM, w_ResultadoA, w_ResultadoN, w_Rango_DESDE, w_Rango_HASTA, w_ID_TP_RESUL, contLINEA_, w_Nom_Seccion, w_TP_Alerta,w_FORMATON,w_EST_RECHAZO)
	Set rst_BM4 = connBM3.execute("IRISLABWEB_BUSCA_FORMATO_DE_PRUEBA_2 '"&w_ID_PRUEBA&"'")	
	Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Dim FR_OBJETO_, FR_COLUMNA_, FR_TEXTO_, FR_TAMANO_, LET_DESC_, COLUMNA_, YY, XX, CONCATE_ , FILA_, CANT_DECI

    if rst_BM4.EOF Or rst_BM4.EOF then
    contLINEA_ = contLINEA_-1.5
    end if

	 WHILE NOT rst_BM4.eof
			
		FR_OBJETO_ =  rst_BM4("FR_OBJETO")
		FR_COLUMNA_ = (rst_BM4("FR_COLUMNA"))
		FR_FILA_ = (rst_BM4("FR_FILA"))
		FR_TEXTO_ = rst_BM4("FR_TEXTO")
		FR_TAMANO_ = rst_BM4("FR_TAMANO")				
		LET_DESC_ = rst_BM4("LET_DESC")
		COLUMNA_ = (FR_COLUMNA_)
		FILA_ =  CLng(FR_FILA_) - 1200
		CANT_DECI  = rst_BM4("PRU_DECIMAL")	
		
		IF FR_OBJETO_ ="Iris_Nombre" THEN
			IF TRIM(FR_TEXTO_) <> ":" THEN
				XX = 30
				YY = 665 - (contLINEA_ * 11)					
				Params("x") = XX	
				Params("y") = YY
				Params("size") = 6.5
    IF FR_TEXTO_ = "VIH"  or FR_TEXTO_ = "Test VIH" THEN
    FR_TEXTO_= VNom&VApe&VFnac&VRut
    END IF
				Page.Canvas.DrawText FR_TEXTO_, Params, Doc.Fonts("Helvetica-Bold")	
				session("anti") = YY
			ELSE
				XX = 30
				YY = 665 - (contLINEA_ * 11)				
				Params("x") = XX	
				Params("y") = YY
				Params("size") = 6.5
				Page.Canvas.DrawText FR_TEXTO_, Params, Doc.Fonts("Helvetica-Bold")	
							
			END IF		
		END IF

		IF FR_OBJETO_ ="Iris_Titulo" THEN
			IF TRIM(FR_TEXTO_) <> ":" THEN
				XX = ((COLUMNA_ * 648)/8000)
				YY = 665 - (contLINEA_ * 11)					
				Params("x") = XX	
				Params("y") = YY
				Params("size") = 6.5
				Page.Canvas.DrawText FR_TEXTO_, Params, Font
			ELSE
				XX = ((COLUMNA_ * 648)/8000) 
				YY = 665 - (contLINEA_ * 11)					
				Params("x") = XX	
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
						w_ResultadoA = TRIM(w_ResultadoA)
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
    Params("y") = 665   - (contLINEA_ * 11) 
    Page.Canvas.DrawText Trim(res1), Params, Font

    For y = mitad+1 to UBound(ArrRes)
	res2 = res2&" "&ArrRes(y)
    Next 
    Params("y") = 665   - ((contLINEA_+1) * 11)
        contfinal = 1
	Page.Canvas.DrawText Trim(res2), Params, Font  

    ELSE
    Page.Canvas.DrawText Trim(w_ResultadoA), Params, Font
    END IF

				END IF 		
			ELSE
				XX = 124
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
			IF TRIM(w_Rango_DESDE) <> "" AND TRIM(w_Rango_HASTA) <> "" THEN
				XX =  300	
				YY = 665 - (contLINEA_ * 11)						
				Params("x") = XX	
				Params("y") = 665 - (contLINEA_ * 11)
				Params("size") = 6.5
				IF ISNULL(w_FORMATON) OR (w_FORMATON) = "0" THEN
				ELSE 
				w_Rango_DESDE = REPLACE(w_Rango_DESDE,",","")
				w_Rango_DESDE = REPLACE(w_Rango_DESDE,".","")
				w_Rango_DESDE = TRIM(w_Rango_DESDE)
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
				END IF		
				IF ISNULL(w_FORMATON) OR (w_FORMATON) = "0" THEN
				ELSE 
				w_Rango_HASTA = REPLACE(w_Rango_HASTA,",","")
				w_Rango_HASTA = REPLACE(w_Rango_HASTA,".","")
				w_Rango_HASTA = TRIM(w_Rango_HASTA)
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
				END IF					
				IF trim(w_TP_Alerta) = "A" or trim(w_TP_Alerta) = "B" THEN				
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
				END IF
				'Page.Canvas.DrawText CONCATE_, Params, Font
			END IF		
		END IF
		rst_BM4.MOVENEXT
	WEND
    IF contfinal <> 0 THEN
    contLINEA_ = contLINEA_ + contfinal+1.5
    contfinal= 0
    END IF
	 'contLINEA_=contLINEA_+1
END FUNCTION

FUNCTION CREA_HOJA_OBJETOS
	Set Pdf = Server.CreateObject("Persits.Pdf")
	Set Doc = Pdf.CreateDocument
	Width =  612
	Height = 792
	Set Page = Doc.Pages.Add( Width, Height )	
END FUNCTION

FUNCTION FECHA_HOY(contLINEA_,w_ID_CF,w_ID_PRUEBA)
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
    
    contLINEA_=contLINEA_+1	
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
	Page.Canvas.DrawText "CORPORACIÓN MUNICIPAL VALPARAISO ", Params, Font
	
     Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 192
	Params("y") = 735
	Params("size") = 11	
	Page.Canvas.DrawText "Calle Washington #32, tercer piso, Valparaiso", Params, Font


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
	Params("y") = 60
	Params("size") = 8	
	Page.Canvas.DrawText "   El resultado de este examen no constituye diagnóstico. Debe ser interpretado por su médico.", Params, Font

    'Set Font = Doc.Fonts("Arial")
	'Set Params = Pdf.CreateParam	
	'Params("x") = 10	
	'Params("y") = 50
	'Params("size") = 8	
	'Page.Canvas.DrawText "   Laboratorio adscrito al programa de evaluación externa de calidad del I.S.P. de Chile (PEEC).", Params, Font
   
    Set Font = Doc.Fonts("Arial")
	Set Params = Pdf.CreateParam	
	Params("x") = 10	
	Params("y") = 40
	Params("size") = 8	
	Page.Canvas.DrawText hola, Params, Font

	Width =  612
	Height = 792
End function


function LLENA_ENCABEZADO(ID_PER)
	Dim g_nombre,g_fecha, g_rut, g_numero, g_fnac, g_Proce, g_edad, g_sexo, g_Prevision, g_usuario_, g_Medico_, g_sector
	Id_atencion_ = oid_empresa 
 	Set rst_BM5 = connBM3.execute("IRISLABWEB_BUSCA_ATENCION_CLINICUM '"&CLng(Id_atencion_)&"','"&CLng(ID_PER)&"'")	
	IF NOT rst_BM5.eof THEN
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

	IF trim(TEXTO_PDF) ="2011062200292077" THEN
		xg_caracter2 = "Resultado"+TEXTO_PDF+".PDF"
	ELSE
	Actual = Now() 
	tiempo = trim((Minute(Actual) & Second(Actual)))
	min_v = trim((minute(Actual)))
	seg_v = trim((Second(Actual)))
	fecha = FormatDateTime(Actual, 2)
     
	TEXTO_PDF = Id_atencion_
	TEXTO_PDF =session("ID_ATEN")
	xg_newpassword = ""
	for j=1 to len(trim(TEXTO_PDF))
		xg_caracter = mid(TEXTO_PDF,j,1)
		xg_caracter = xg_caracter + asc(xg_caracter) 
	next
	xg_caracter = Right("00" & Hex(xg_caracter Mod 256), 2)
	xg_newpassword = ""
	for j=1 to len(trim(tiempo))
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
    Activa_Linea_Resultado = 0
	Width =  612
	Height = 792
	Set Page = Doc.Pages.Add( Width, Height )	
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
			 YY = 655   - (contLINEA_ * 11)_ 
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
			 YY = 655   - (contLINEA_ * 11)_ 
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
	YY = 110 + (BBBC * 10)
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
