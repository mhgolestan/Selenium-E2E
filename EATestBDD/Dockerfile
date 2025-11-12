FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
WORKDIR /app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["EATestBDD/EATestBDD.csproj", "EATestBDD/"]
COPY ["EATestFramework/EATestFramework.csproj", "EATestFramework/"] 
COPY ["ProductAPI/ProductAPI.csproj", "ProductAPI/"]
RUN dotnet restore "EATestBDD/EATestBDD.csproj"
COPY . .
WORKDIR "/src/EATestBDD"
RUN dotnet build "EATestBDD.csproj" -c Release -0 /app/build
FROM build AS EATestBDD
WORKDIR /src/EATestBDD
CMD ["dotnet", "test"]