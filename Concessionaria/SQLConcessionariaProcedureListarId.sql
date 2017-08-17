-- COMITADOS
CREATE PROCEDURE LISTAR_OPCIONAL_ID
@OPCID INT
AS
BEGIN 
	SELECT * FROM OPCIONAL
	WHERE OPCID = @OPCID
END
--_________________________________________________________________
CREATE PROCEDURE LISTAR_CARRO_ID
@CARID INT
AS
BEGIN 
	SELECT * FROM CARRO
	WHERE CARID = @CARID
END
--_________________________________________________________________
CREATE PROCEDURE LISTAR_LOGIN_ID
@LOGUSUAR VARCHAR(12)
AS
BEGIN 
	SELECT * FROM LOGIN_VENDEDOR
	WHERE LOGUSUAR = @LOGUSUAR
END
--_________________________________________________________________
CREATE PROCEDURE LISTAR_CLIENTE_ID
@CLICPF VARCHAR(12)
AS
BEGIN 
	SELECT * FROM CLIENTE
	WHERE CLICPF = @CLICPF
END
--_________________________________________________________________
CREATE PROCEDURE LISTAR_VENDA_ID
@CLICPF VARCHAR(12), @CARID INT
AS
BEGIN 
	SELECT * FROM VENDA
	WHERE CLICPF = @CLICPF AND CARID = @CARID
END
--_________________________________________________________________