# InventoryManagment
Inventory managment contains three folders InventoryManagmentAPI, InventoryManagmentAPITest and Scripts.
1. InventoryManagmentAPI is Dotnet core web api which expose endpoints to fetch the list of products from database, fetch product by id, store the new product in database and update the exising product in database.
2. InventoryManagmentAPITest is a Xunit testing project for testing InventoryManagmentAPI.
3. Scripts folder contains database scripts for creating database and tables
# How to run InventoryManagmentAPI
1. Execute the sql server script which is in Scripts folder
2. Open the InventoryManagment.sln solution in visual studio 2019
3. Update the MyConnection value in AppSettings.json file of InventoryManagmentAPI with your InventoryDB database connection string.
4. Clean and rebuild the InventoryManagmentAPI project
5. Run the InventoryManagmentAPI
6. Once the InventoryManagmentAPI project run you will see a swagger UI page where you can check all the endpoints available in InventoryManagmentAPI project.
