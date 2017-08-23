-- COMITADOS
CREATE PROCEDURE LISTAR_OPCIONAL
AS
BEGIN 
	SELECT * FROM OPCIONAL
END
--_________________________________________________________________
ALTER PROCEDURE LISTAR_CARRO
AS
BEGIN 
	SELECT CARPLACA, CARMODEL, CARMARCA, CARCOR, CARANO, CARCOMBU, CARTIPO
	 FROM CARRO WHERE carstatus = 0
END
--______________________________________________________________

CREATE PROCEDURE LISTAR_VENDIDOS
AS
BEGIN
	SELECT * FROM CARRO 
	WHERE CARSTATUS = 1
END
--_________________________________________________________________
CREATE PROCEDURE LISTAR_LOGIN
AS
BEGIN 
	SELECT * FROM LOGIN_VENDEDOR
END
--_________________________________________________________________
CREATE PROCEDURE LISTAR_CLIENTE
AS
BEGIN 
	SELECT * FROM CLIENTE
END


--_________________________________________________________________
ALTER PROCEDURE LISTAR_VENDA
AS
BEGIN 
	SELECT	V.VENDATAV, V.VENID, V.VENVALOR, C.CARMODEL, C.CARPLACA,
			CLI.CLINOME 
	FROM VENDA V INNER JOIN CARRO C ON V.CARPLACA = C.CARPLACA
		INNER JOIN CLIENTE CLI ON V.CLICPF = CLI.CLICPF

END
--_________________________________________________________________