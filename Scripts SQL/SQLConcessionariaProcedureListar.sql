-- COMITADOS
ALTER PROCEDURE LISTAR_OPCIONAL
	
	AS
	BEGIN 
		SELECT * FROM OPCIONAL
			ORDER BY OPCDESCR
	END

--_________________________________________________________________
ALTER PROCEDURE LISTAR_CARRO
	
	AS
	BEGIN 
		SELECT CARPLACA, CARMODEL, CARMARCA, CARCOR, CARANO, CARCOMBU, CARTIPO
			FROM CARRO 
		WHERE carstatus = 0
			ORDER BY CARMODEL
	END
--______________________________________________________________

ALTER PROCEDURE LISTAR_VENDIDOS
	
	AS
	BEGIN
		SELECT * FROM CARRO 
		WHERE CARSTATUS = 1
			ORDER BY CARMODEL
	END
--_________________________________________________________________
ALTER PROCEDURE LISTAR_LOGIN
	
	AS
	BEGIN 
		SELECT * FROM LOGIN_VENDEDOR
		ORDER BY LOGUSUAR
	END
--_________________________________________________________________
ALTER PROCEDURE LISTAR_CLIENTE
	
	AS
	BEGIN 
		SELECT * FROM CLIENTE
			ORDER BY CLINOME
	END
--_________________________________________________________________
ALTER PROCEDURE LISTAR_VENDA
	
	AS
	BEGIN 
		SELECT	V.VENDATAV, 
				V.VENID, 
				V.VENVALOR, 
				C.CARMODEL, 
				C.CARANO,
				C.CARCOR,
				C.CARPLACA,
				CLI.CLINOME,
				CLI.CLICPF 
			FROM VENDA V INNER JOIN CARRO C 
				ON V.CARPLACA = C.CARPLACA
					INNER JOIN CLIENTE CLI 
						ON V.CLICPF = CLI.CLICPF
							ORDER BY VENDATAV
	END
--_________________________________________________________________