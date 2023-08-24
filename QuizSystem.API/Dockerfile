#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["QuizSystem.API/QuizSystem.API.csproj", "QuizSystem.API/"]
COPY ["Framework.api/Framework.api.csproj", "Framework.api/"]
COPY ["Framework.Core/Framework.Core.csproj", "Framework.Core/"]
COPY ["Framework.Domain/Framework.Domain.csproj", "Framework.Domain/"]
COPY ["Framework.Repository/Framework.Repository.csproj", "Framework.Repository/"]
COPY ["OnlineQuiz.Repository/QuizSystem.Repository.csproj", "OnlineQuiz.Repository/"]
COPY ["QuizSystem.Domain/QuizSystem.Domain.csproj", "QuizSystem.Domain/"]
COPY ["OnlineQuiz.Service.Contracts/QuizSystem.Service.Contracts.csproj", "OnlineQuiz.Service.Contracts/"]
COPY ["OnlineQuiz.Service/QuizSystem.Service.csproj", "OnlineQuiz.Service/"]
COPY ["Framework.Service/Framework.Service.csproj", "Framework.Service/"]
RUN dotnet restore "QuizSystem.API/QuizSystem.API.csproj"
COPY . .
WORKDIR "/src/QuizSystem.API"
RUN dotnet build "QuizSystem.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "QuizSystem.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QuizSystem.API.dll"]