## Use the official ASP.NET Core runtime as the base image
#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
## Copy the certificate files
#COPY ["certs/localhost.pfx", "/https/"]
#
## Create the Uploads directory
#RUN mkdir -p /app/Uploads
#
## Use the official .NET SDK for building the application
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#WORKDIR /src
#COPY ["ApiForReact.csproj", "./"]
#RUN dotnet restore "./ApiForReact.csproj"
#COPY . .
#WORKDIR "/src/."
#RUN dotnet build "ApiForReact.csproj" -c Release -o /app/build
#
## Publish the application
#FROM build AS publish
#RUN dotnet publish "ApiForReact.csproj" -c Release -o /app/publish
#
## Final stage to run the application
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "ApiForReact.dll"]
#