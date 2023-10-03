# CDNFreelancerHub
Freelancer Database For CDN

Description
A Blazor WebAssembly app for capturing Freelancer data.

Task Details

    A fictional company, CDN - Complete Developer Network is going to build a list of freelancers.
    Such that they could have a directory of contact get people for their job.
    1. Develop the RESTful API to register/delete/update/get for an user using verbs such as:
    @GET, @POST @PUT, @DELETE
    2. The following are attributes for user model:
    username, mail, phone number, skillsets, hobby
    3. Connect to any of well-known RDBMS database to demonstrate data storage.
    4. Build a simple interface for the above 4 operations (Optional):
    GET list of registered user name.
    Register a new user, delete a user, update a user details.

Tools and SDk

    Visual Studio 2022
    MS SQL Server
    .NET 6.0 SDK

How to run the project

    1.Clone the repository from GitHub git clone https://github.com/souravdas09028/CDNFreelancerHub.git

    2.Run the project in Visual Studio 2022

    3.Go to Package Manager Console

    4.Run this command in Package Manager Console.
    Update-Database -Project CDNFreelancerHub.Core -StartupProject CDNFreelancerHub.Api
    
    5.Set StartUp Projects : Multiple project -> CDNFreelancerHub.API and CDNFreelancerHub.Web  
![image](https://github.com/souravdas09028/CDNFreelancerHub/assets/59077852/f7f2ba4a-18bf-4aaa-869b-ef436e260f42)

    
    6.Run the project
