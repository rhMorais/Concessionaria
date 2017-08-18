-- TODOS COMITADOS

CREATE PROCEDURE DELETAR_OPCIONAL
@OPCID INT
AS
BEGIN 
	DELETE OPCIONAL WHERE OPCID = @OPCID
END
--_____________________________________________________________________
CREATE PROCEDURE DELETAR_CARRO
@CARID INT
AS
BEGIN 
	DELETE CARRO WHERE CARID = @CARID
END
--_____________________________________________________________________
CREATE PROCEDURE DELETAR_LOGIN
@LOGUSUAR VARCHAR(12)
AS
BEGIN 
	DELETE LOGIN_VENDEDOR WHERE LOGUSUAR = @LOGUSUAR
END
--_____________________________________________________________________
CREATE PROCEDURE DELETAR_CLIENTE
@CLICPF VARCHAR(12)
AS
BEGIN 
	DELETE CLIENTE WHERE CLICPF = @CLICPF
END
--_____________________________________________________________________
CREATE PROCEDURE DELETAR_VENDA
@CLICPF VARCHAR(12), @CARID INT
AS
BEGIN 
	DELETE VENDA WHERE CLICPF = @CLICPF AND CARID = @CARID
END
--_____________________________________________________________________