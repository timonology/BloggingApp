#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat


FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /app

EXPOSE 80
EXPOSE 443

COPY *.sln .
COPY BloggingApp.UI/BloggingApp.UI.csproj ./BloggingApp.UI/
COPY BloggingApp.Service/BloggingApp.Service.csproj ./BloggingApp.Service/
COPY BloggingApp.Persistence/BloggingApp.Persistence.csproj ./BloggingApp.Persistence/
COPY BloggingApp.Infrastructure/BloggingApp.Infrastructure.csproj ./BloggingApp.Infrastructure/
COPY BloggingApp.Domain/BloggingApp.Domain.csproj ./BloggingApp.Domain/
COPY BloggingApp.AutomatedUITests/BloggingApp.AutomatedUITests.csproj ./BloggingApp.AutomatedUITests/
RUN dotnet restore

COPY . .
RUN dotnet build

FROM build AS testrunner
WORKDIR /app/BloggingApp.AutomatedUITests
CMD ["dotnet", "test", "--logger:trx"]

# run the unit tests
FROM build AS test
WORKDIR /app/BloggingApp.AutomatedUITests
RUN dotnet test --logger:trx

FROM build AS publish
WORKDIR /app/BloggingApp.UI
RUN dotnet publish -c Release -o out



FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=publish /app/BloggingApp.UI/out ./
ENTRYPOINT ["dotnet", "BloggingApp.UI.dll"]


