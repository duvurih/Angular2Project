# Angular2Project
Angular 2 + Web API + Entity Framework + SQL Server + DI + Responsive Design

# Deployed in Amazon AWS
- This application is deployed in Amazon AWS
  - Steps for Deployment........
- The Application Url is http://.........../

# Virtual Demo:
![alt text](https://github.com/duvurih/Angular2Project/blob/master/OrderManagement/MultiProjectSample/Content/images/ProductsViewNavigation.gif)

# Scope of Work:
1. Products, Categories, Suppliers
2. Order Management

# High Level Business Context
![alt text](https://github.com/duvurih/Angular2Project/blob/master/OrderManagement/MultiProjectSample/Content/images/HighLevelBusinessContext.png)

# High Level Technical Context and Deployment Model
![alt text](https://github.com/duvurih/Angular2Project/blob/master/OrderManagement/MultiProjectSample/Content/images/HighLevelContext.png)

# Database Model
![alt text](https://github.com/duvurih/Angular2Project/blob/master/OrderManagement/MultiProjectSample/Content/images/Database%20Model.png)

# Technology Stack:
1. Microsoft ASP.NET MVC 5.0
2. Microsoft .NET Framework 4.5
3. Microsoft Web API 2.0
4. Angular 2.4
5. Bootstrap
7. Castle Windsor for Dependency Injection
8. Entity Framework v6.0
9. AutoMapper v6.0.2
10. SQL Server Data Tools for Database Comparison and Deployment
11. Unit Testing Framework
12. Moq for mocking DI Objects
13. Angular 2 - HighCharts
14. Redux

# Class Diagram:
1. Generic Repositories
2. Generic Services 
![alt text](https://github.com/duvurih/Angular2Project/blob/master/OrderManagement/MultiProjectSample/Content/images/ClassDiagram1.png)

# Tasks:
Features
----------------------------
Dashboard | Products | Suppliers | Customers | Categories | Orders | Search |
--------- | ---------|-----------|-----------|------------|--------|--------|
Main Dashboard | List of Products | List of Suppliers | List of Customers | View Categories | View Orders |  Search Criteria Screen
Top Menu | View Product | View Supplier | View Customer | View Category | View Order |  Search Results
Side Menu | Edit Product | Edit Supplier | Edit Customer | Edit Category | Edit Order |  Navigate Search Results
Dashboard Items | Add Product | Add Supplier | Add Customer | Add Category | Add Order |  

# Project Setup:
Environment Setup
- Visual Studio 2015
- SQL Server 2014
- NodeJS v7.9.0
- npm v4.5.0
- Typescript v2.2.1
- Gulp

Project Setup
- Clone or Download the Project
- Open the Project in Visual Studio
- Goto MultiProjectSample Folder from command prompt and execute following commands
  - bower install
  - npm install
- Now project should have resolved and compiled successfully
- Create a empty database in SQL Server with name OrderMgmt
- Publish the database by right clicking on database project in visual studio
- Change the database name/user name/password in the web.config file
