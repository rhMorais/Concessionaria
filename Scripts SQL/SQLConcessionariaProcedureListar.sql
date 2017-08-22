-- COMITADOS
CREATE PROCEDURE LISTAR_OPCIONAL
AS
BEGIN 
	SELECT * FROM OPCIONAL
END
--_________________________________________________________________
CREATE PROCEDURE LISTAR_CARRO
AS
BEGIN 
	SELECT CARPLACA, CARMODEL, CARMARCA, CARCOR, CARANO, CARCOMBU, CARTIPO
	 FROM CARRO
END
EXEC LISTAR_CARRO
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
CREATE PROCEDURE LISTAR_VENDA
AS
BEGIN 
	SELECT * FROM VENDA
END
--_________________________________________________________________