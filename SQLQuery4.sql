﻿
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[login1]
	-- Add the parameters for the stored procedure here
	@user varchar(50),
	@pass varchar(50),
	@result int output,
	@role varchar(50) output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if exists(select 1 from login where username = @user and password = @pass)
	begin
	select @role = role from login where username = @user and password = @pass;
		set @result = 1;
	end
	else
	begin
	set @result = 0;
	set @role = null;
	end
	return @result
END
