#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY ["EAIntegrationTest/EAIntegrationTest.csproj", "EAIntegrationTest/"]
COPY ["ProductAPI/ProductAPI.csproj", "ProductAPI/"]
RUN dotnet restore "EAIntegrationTest/EAIntegrationTest.csproj"
COPY . .
RUN dotnet build "EAIntegrationTest/EAIntegrationTest.csproj" -c Release -o /app/build

# The 'EAIntegration' stage is the final stage for running tests.
# It starts from the SDK image to have access to 'dotnet test' and other tools.
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS EAIntegration
WORKDIR /app

# Copy the built test application from the 'build' stage.
COPY --from=build /app/build .

# Copy the scripts needed to run the tests.
COPY --from=build /src/scripts ./scripts

RUN chmod +x ./scripts/WaitAndRun.sh
ENTRYPOINT [ "./scripts/WaitAndRun.sh" ]