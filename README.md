![alt tag](https://raw.github.com/PaulKGray/TemplateGraySkull/master/WebSite/Images/Grayskull.jpg)

TemplateGraySkull
=============

MVC Onion Architecture Template.

Technologies used 

C# .Net 4


This has a number of layers just like an onion

http://www.develop.com/onionarchitecture

Not totaly like this version but I have taken what I like about it.


Domain
--------------
The core of the application the entities 

Repository
--------------
The layer for connecting to the database / storage.

At this stage i have used SQL through Nhibernate.

I have kept this very simple and only have one repository class to access the data. This would probably need sepreate implemenations to deal with stored procedures effectively.

- Nhibernate


Database
--------------

SQL server

Needs role and membership provider setting up see this

http://msdn.microsoft.com/en-us/library/ms229862(v=vs.100).aspx


Service
--------------

This is where the core functionality will sit. It deals with making the calls to the respositories.

**What goes here**
- Calls to the repository  
- Business Logic

- Registrations for dependency resolution

**Technologies Used**
- Ninject (dependency resolution)

MVC Web Site
--------------
This is a straight up MVC site it should have no logic this should be in the service

*Need to look at how to handle the mappings effectively between view models and domain models*

**Technologies Used**
- Ninject
- MVC4
- Less
- HTML5 boiler plate (normalise the site) http://html5boilerplate.com/


