# Cheese

## Running 

### Run `dotnet run --launch-profile https`
- The application is served at http://localhost:5207
- Swagger is served at https://localhost:7271
- Can also be run from Visual Studio via the Solution file

## Improvements 

### Docker
I was unable to get docker to fully function. As it stands the server can be stood up, but the react front end was not able to communicate with the container. I suspected that the frontend was not being bundled, but when jumping in to the container later on, it appeared that wasn't the case. 

### API
There isn't really any logic, so demonstrating any layering - such as moving database access out of the controllers - would be fairly contrived and arguably worse design for the minimal requirements.
DI to be addressed in 

### Testing
Firstly, the above made actual unit tests impossible. DI probably would have been better than the approach actually taken, but TDD evangelists must forgive me when I say the controller was created first. In the end, the approach taken did lead to writing some intergration tests. 

### Frontend
Could certainly do with more than the scant styling added, as well as some additional features to allow for full consumption of the API. The cards themselves could have also been prototyped out to their own component rather than the single use projection used.

## Final Comments
React and Docker are certainly the components that I have the least experience in, and that became obvious quickly. 
I will admit that I've rarely used Docker - while I didn't need to install it for this little project, I cannot remember what I even had it installed for. While considerably different, most of my DevOps experience lies in Azure pipelines.

I think next time I would avoid vanilla JS and go for typescript - this was an option in the template, but wanted to avoid build complications for such a small project. This was probably a misapprehension of the state of typescript support in VS on my part.

After setting up Entity Framework, the requisite C# was mostly able to be generated with the inbuilt tools in VS. Not much to say about any of that, it's an API that returns stuff from a database.