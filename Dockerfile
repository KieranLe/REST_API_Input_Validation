#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ASPNETCORE_URLS http://*:7175
ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PhoneBook/PhoneBook.csproj", "PhoneBook/"]
RUN dotnet restore "PhoneBook/PhoneBook.csproj"
COPY . .
WORKDIR "/src/PhoneBook"
RUN dotnet build "PhoneBook.csproj" -c Release -o /app/build

# Build stage for running unit tests
FROM build AS testrunner
WORKDIR /src/PhoneBookUnitTest
COPY ["PhoneBookUnitTest/PhoneBookUnitTest.csproj", "PhoneBookUnitTest/"]
RUN dotnet restore "PhoneBookUnitTest/PhoneBookUnitTest.csproj"
COPY . .
WORKDIR "/src/PhoneBookUnitTest"
RUN dotnet test ./PhoneBookUnitTest/PhoneBookUnitTest.csproj

FROM build AS publish
RUN dotnet publish "PhoneBook.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PhoneBook.dll"]