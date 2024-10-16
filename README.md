This project contains both back-end part with asp net core web api, which is build with clean architecture, and front-end part with Blazor. 
It's a online forum, where you can create your forum like "Politics in my country" and than you and other users will be able to create topics about that.
Authorized user is able to upvote relevant and likable Topic, so that it will appear at the Top.
each Topics have comment section with reply system.
Project have three Roles - Admin, Moderator, User. Admin Creates and approves Forums and Topics, Moderator can only approve Topics. User can only create Forums and Topics and comment on topic.
As I said Project's back-end part uses clean architecture. for database connection it uses Entity framework, which is configured in Infrastructe layer and injected in API/Extensions/ServiceExtension.cs
Project has seperate layers for abstraction which is called Contracts. I am using IUnitOfWork for Services and repositories seperately, IServiceManager is implemented in Application layer, IRepositoryManager is implemented in Infrastrucre Layer.
I've build Services in application Layer which works for creating, reading ,updating and deleting entity data in database.
I've configured GlobalExceptionHandler middleware as well. you will see Custume Exception in layers and GlobalExceptionHandler in API layer.
Api has Microsoft Identity configuration, User is derieved class of IdentityUser<int> and Role from IdenitityRole, Identity is configured in ServiceExtension.cs in API layer(other services are also configured and injected here) 
Authothentication is done by Jwt token you can see it's configuration as well.
Authentication and Authorization has seperate service and controller, in addition I've configured Email Verification system alongside Authentication. this system has seperate service, and email sender which is configured in infrastrucure layer.


