# BloggingApp
Web App for Blogging Platform

# Features for this Blogging App
- Application Built on Onion Architecture (.Net Core 3.1)
- Exception Handling
- EntityFramework Core 
- Automapper
- CQRS and Mediatr 
- Automation Testing (Selenium, xUnit)
- Logging (Serilog)
- Role Based Authorization
- Database Seeding, Migrations
- Containerized - can run on Docker
- Database - SQLSERVER

# Installation Process

- ADD MIGRATION TO DATABASEE
Add Migration for ApplicationDbContext and IdentityContext


add-migration Initial -Context IdentityContext
update-database -Context IdentityContext

- ADD CONNECTION STRINGS FOR APPLICATION DB, IDENTITY DB AND SERILOG (OPTIONAL) on appsettings

- For docker build, kindly run the below command or you can add a docker-compose file for more flexibility
docker build -t AppName .

# Pending Implementation
- Auto Import of customer post from other blog platform
  
