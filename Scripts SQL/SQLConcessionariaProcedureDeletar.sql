-- TODOS COMITADOS

CREATE PROCEDURE DELETAR_OPCIONAL
@OPCID INT
AS
BEGIN 
	DELETE OPCIONAL WHERE OPCID = @OPCID
END
--_____________________________________________________________________
ALTER PROCEDURE DELETAR_CARRO
@CARPLACA VARCHAR(8)
AS
BEGIN 
	DELETE CARRO WHERE CARPLACA = @CARPLACA
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
ALTER PROCEDURE DELETAR_VENDA
@VENID INT
AS
BEGIN 
	DELETE VENDA WHERE VENID = @VENID
END
--_____________________________________________________________________