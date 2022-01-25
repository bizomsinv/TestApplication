# TestApplication
Application Test Details
With the data contained in the attached script, you should develop a web application that works like this:
One page with a dropdown list filled with the values of Town. 
Name field; the drop-down list must be editable for fast-searching (auto-fill)
A button next to the dropdown list that, when pressed, fills a paged grid (under the dropdown list) filled with the values of: People.Name, People.Surname, Town.Name (in a grid column named “Born”), Town.Name (in a grid column named “Lives”); the column “Born” must display the value bound to column People.IDTown_born, the column “Lives” must display the value bound to column People.IDTown_lives
One page for adding record to table People: it’s composed by two text box, one for digit the Name field, one for the Surname field, one dropdown list to select the value for People.IDTown_born (dropdown list filled with values coming from Town.Name field), one dropdown list to select the value for People.IDTown_lives (dropdown list filled with values coming from Town.Name field); one button to save the record in the table
Kindly check the details and let me know if you have any queries to perform the task. It no queries, please accomplish this task and share it.

# .SLN File
The .sln file exists in TestApplication file.

# Application Architecture
Application is developed in two parts. UI and API
1. API
    Contains .net Core API with MediatR
    1.1 Test.Data
        - This project consists of DBContext and model classes. Application also uses Routing constant variables to define Restfull routes.
        - Models: folder for all DB context and table classes
        - Requests: Contain classes for Requests for the endpoints
        - Responses: Contain classes for Response for the endpoints
        - Routes: Contain class(es) for Constant routing strings for restfull URLs
    1.2 Test.Domain
        - Business logic resides in this project
        - Commands: Used for commanding purpose - to update database objects
        - Queries: Used to query database
2. UI
    Asp.Net Web application with Razor pages is used for calling APIs and binding data.
    Default JQuery AJAX Requests are used to fetch data form the API
    Default Validation in the form has been used which can be replaced with enhanced JQuery validators

# CQRS Architecture
Application is developed in CQRS architecture to seperate database queries and database object alterations. This helps application to maintain smoothley and if bifurgetated to different projects, can be used with Microservices architecture

# MediateR
API uses MedaiteR for mediator pattern which accomplish behavioral pattern to alter program's running behavior.

# Exceptions
Application does not have default commenting to maintain standards of SonarQube. 
UI application uses static URL (localhost) to call API which can be replaced reading with / from appsettings.json

# How to Run
1. Open solution in Visual Studio 2019
2. Run TestApplication web project
3. Right click on Test.API project and click on Debug >> Start New Instance
4. Refresh Main page of Web application in browser and application will function properly.