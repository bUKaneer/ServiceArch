# ServiceArch
Domain Driven Design Service Architecture

This is a DDD approach to creating a Service Oriented Architecture, it is lightweight and supports Entity Framework or MongoDB as a datastore.

The purpose of this project was to create a simple to use system for creating robust prototypes and small applications quickly.

Components
--

 - Autofac for IoC/DI
 - AutoMapper for Entity to DTO mapping
 - FluentValidation for Domain Object (Entity) validation
 - WebAPI for exposing Service end points
 - EntityFramework/MongoDB for data storage (other providers can be added)
 
Prerequisites
--

 - You will need Visual Studio 2013/2015
 - If you wish to use MongoDB you will need to install it on your development machine

Setup
--

 - Decide whether you want to use EF or MongoDB and modify the namespace in the Api\AutofacModules\ServiceArchCore.cs file
 - Modify Connection Strings using DataProviders\Properties\Settings.settings file, though the defaults may suffice
 - Hit F5 to debug
 
Modifications
--
 
If you wish to add your own Services start by copying the DataInterfaces\TaskListService folder. 
 
Rename the folder and modify/add files into the sub-folders as required.
 
Add an Interface for your service in the DataInterfaces\Interfaces\Services folder, see ITaskListService.cs for an example.
 
Create a new Controller in the Api\Controllers folder and expose end points as required (See TaskListServiceController.cs for an example).
 
Finally add a new project of you choosing and create an interface calling the API and using the data and end points as required.

