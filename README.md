PARA SA SQLDATABASE:  
      1. GAWA KAYO DATABASE  
      2. New Query(Ctrl + N)  
      3. paste nyo to " 

                  CREATE TABLE login (  
                        username VARCHAR(50) PRIMARY KEY,  
                        password VARCHAR(50),  
                        role VARCHAR(50))  
                  CREATE TABLE stocks (  
                        item_no VARCHAR(50) PRIMARY KEY,  
                        product_name VARCHAR(50),  
                        quatity VARCHAR(50),  
                        price VARCHAR(50)) 
      
then execute

      
4. tapos punta kayo sa Programmability then right click store procedure 
            paste nyo to  

		SET ANSI_NULLS ON
		GO
		SET QUOTED_IDENTIFIER ON
		GO
            CREATE PROCEDURE [dbo].[login1]  
	            @user varchar(50),  
	            @pass varchar(50),  
	            @result int output,  
	            @role varchar(50) output  
            AS  
            BEGIN  
	      SET NOCOUNT ON;  
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
then execute
