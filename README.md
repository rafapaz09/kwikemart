Technologies used on the battle:
  1. ASP.NET Core MVC 2.1
  2. SQLSERVER 2016
  
Libraries used on the battle:
  1. Dapper(1.60.6): ORM for mapping objects with the database
  2. Newtonsoft.Json(12.0.1)
  3. Swashbuckle.AspNet.Core(4.0.1): API Documentation

1. Configure the database
  a. Run the file DatabaseDump.sql on a local SQLSERVER2016 instance [(LocalDb)\MSSQLLocalDB] to create the database, and all the objects required for the projects to run succesfully.
  
2. Run the Projects
  a. The project Kwikemart_API will run on https://localhost:5001 you can see all the endpoints documentation on the swagger index => https://localhost:5001/swagger.
     The authentication process is pretty straighforward, you have to consume the Account EndPoint with the user credentials, and then use this token to authenticate to the others EndPoints via Bearer JWT Authentication.
	 
	 AdminAccount:	apu
	 AdminPassword: apu2019*
	 
	 UserAccount: user
	 UserPassword: user2019*
	 
  b. The project Kwikemart_APP it's the frontend application that shows a list of all the availables products this runs on https://localhost:5011 , you need to have the API running first in order to run the APP.
     You can search by product name on the top box of the datatable.
	 The products list has pagination, so everytime you click on the next page it'll ask the server for the new products based on the size filters you want to see.	 	 	
	 
3. Testing the API
  a. On the "POSTMAN" folder you'll find a file named it "PublicPOSTMANURL.txt" which contains an URL with all the EndPoints that this API has.
     Click on the top button "Run in POSTMAN" to export this file to POSTMAN and consume it from there