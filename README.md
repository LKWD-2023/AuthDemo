# AuthDemo

This is a simple demo app that shows how to use authentication in .Net Core. When the user tries to access the Secret page, they get redirected to a login page. There's also a signup page at /account/signup.

A few things to look out for:
* When referencing BCrypt in the class library, make sure to reference BCrypt.Net-Next from Nuget

<img width="1181" alt="image" src="https://user-images.githubusercontent.com/126539919/233234795-48b3d1b9-ead2-4a4d-bef3-1f6099f95a6d.png">

Here are the relevant pieces of code needed to make this work. First, you need to set up Authentication in the `Program.cs` file:

https://github.com/LKWD-2023/AuthDemo/blob/master/AuthDemo/Program.cs#L5

https://github.com/LKWD-2023/AuthDemo/blob/master/AuthDemo/Program.cs#L11-L17

https://github.com/LKWD-2023/AuthDemo/blob/master/AuthDemo/Program.cs#L36-L37

Then, to actually log a user in, here's the code needed for that (in the `AccountController.cs`):

https://github.com/LKWD-2023/AuthDemo/blob/master/AuthDemo/Controllers/AccountController.cs#L46-L54

To check if a user is logged in, you can use the `User.Identity.IsAuthenticated` property, and to get the currently logged in users email, you can do `User.Identity.Name`. This can be done either in the controller or in the view.

To log out a user, do the following:

https://github.com/LKWD-2023/AuthDemo/blob/master/AuthDemo/Controllers/AccountController.cs#L59-L63

To only give logged in users access to a specific page, use the `[Authorize]` attribute:

https://github.com/LKWD-2023/AuthDemo/blob/master/AuthDemo/Controllers/HomeController.cs#L23



