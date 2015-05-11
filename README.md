ASP.NET MVC Model Generator
===================
This is a simple, time-saving, C# Utility that will generate MVC Models from a database table. I've switched to mainly using Dapper ORM (instead of Entity Frameworks) for my MVC projects to take advantage of the performance gains. This utility helps me save time and avoid the tedious work of generating my models for mapping for Dapper.

This project does use my personal Data Access Layer to interact with the Database. It supports parameter queries, and is very lightweight. 

The app contains minimal error handling and assumes your database is   **online** and your [Connection String](http://www.connectionstrings.com/) is valid. I'll add error handling when and if time permits. 

----------
How to Use
-------------

> **Prerequisites** 
> You'll need a well formed SQL Connection String to connect to a database. If you need them, visit [Connectionstrings.com](http://www.connectionstrings.com/) for reference.

 1. Enter your connection string into the field and hit click Connect.
 2. Select your table name from the dropdown list.
 3. Enter your project namespace (optional)
 4. Click Generate. 

The text area will contain the generated class and the interface which you can now copy and paste.

> **Notes** 
> The app.config contains the default connectionstring under "SQL". If empty, plug one in and the application will load it up on startup. 

In Progress
----------
 Some features are a work in progress and not finalized. I'll update this readme file as features are updated or modified. Things currently in progress which should be updated shortly:
 - User Interface to be improved as features are added.
 - Dapper CRUD functionality generation is still being developed. Basic code is now available through generated business layer.

----------

Release Notes
-------------
5-10-2015

 1. Added basic dynamic parsing of the table (including determining
    primary key)
 2. CRUD generation through business layer.
 3. Split out generated code to tabs.

5-3-2015

 1. Initial Commit.  
 2. Contains the bulk of functional code, with minimal error handling. 
 3. Only tested against Microsoft SQL 2012 but should work with Microsoft SQL 2008+.
 
----------
Wish List
---------
In no particular order:
 - Generate Views
 - Generate Controllers (with CRUD functionality)
 - Map SQL table relationships and generate model Lists automatically
 - Make Database Server Agnostic
 - Export Generated Files as .CS files
 - Add command line support
 - Switch to Visual Studio Plug-in (or Resharper add-in)
 - Generate Web API code
 - Add Support for stored procedures
 - Allow generation of multiple models simultaneously
