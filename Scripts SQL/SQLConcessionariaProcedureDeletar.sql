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
	DECLARE @STATUS INT
	SELECT @STATUS SELECT CARSTATUS FROM CARRO WHERE CARPLACA = @CARPLACA
	
	DELETE CARRO_OPCIONAL WHERE CARPLACA = @CARPLACA
	
	IF(@STATUS = 1)
	BEGIN     -- A trigger(exclui_carro_venda) ja exclui o carro automaticamente
		DELETE VENDA WHERE VENDA.CARPLACA = @CARPLACA
	END		
END

SELECT * FROM CARRO_OPCIONAL
SELECT * FROM OPCIONAL
--_____________________________________________________________________
CREATE PROCEDURE DELETAR_CARRO_OPCIONAL
@CARPLACA VARCHAR(8)
AS
BEGIN
	DELETE CARRO_OPCIONAL WHERE CARPLACA = @CARPLACA
END
--_____________________________________________________________________
CREATE PROCEDURE DELETAR_OPCIONAL_CARRO
@OPCID INT
AS
BEGIN
	DELETE CARRO_OPCIONAL WHERE OPCID = @OPCID
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
@VENID INT
AS
BEGIN 	
	DELETE VENDA WHERE VENID = @VENID
END
--_____________________________________________________________________