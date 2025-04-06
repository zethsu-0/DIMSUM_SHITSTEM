PARA SA SQLDATABASE:  
      1. GAWA KAYO DATABASE  
      2. New Query(Ctrl + N)  
      3. paste nyo to 

                  CREATE TABLE login (  
                        user_id VARCHAR(50) PRIMARY KEY,
			firstname  VARCHAR(50),
   			lastname  VARCHAR(50),
                        password VARCHAR(50),  
                        role VARCHAR(50),
			age VARCHAR(50),
   			address  VARCHAR(50),
      			phone_no  VARCHAR(50),
      			)  
                  CREATE TABLE stocks (  
                        item_no VARCHAR(50) PRIMARY KEY,  
                        product_name VARCHAR(50),  
                        quatity VARCHAR(50),  
                        price VARCHAR(50),
			taxed_price  VARCHAR(50),
   			barcode BINARY(MAX)) 
      
then execute

      
4. tapos punta kayo sa Programmability then right click store procedure 
            paste nyo to  

		SET ANSI_NULLS ON
		GO
		SET QUOTED_IDENTIFIER ON
		GO
            CREATE PROCEDURE [dbo].[login1]  
	            @user_id varchar(50),  
	            @pass varchar(50),  
	            @result int output,  
	            @role varchar(50) output  
            AS  
            BEGIN  
	      SET NOCOUNT ON;  
	            if exists(select 1 from login where user_id = @user_id and password = @pass)  
	            begin  
	            select @role = role from login where user_id = @user_id and password = @pass;
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

5. tapos sa module na babaguhin

		con.ConnectionString = "Data Source=[name ng sever];Initial Catalog=[pangalan ng database nyo];Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True"
