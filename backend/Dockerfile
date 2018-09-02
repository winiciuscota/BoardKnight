FROM microsoft/dotnet:2.1-sdk AS build

WORKDIR /app

# Copy csproj files first to optimize build process

COPY *.sln ./
COPY src/BoardKnight.Api/*.csproj ./src/BoardKnight.Api/
COPY src/BoardKnight.Domain/*.csproj ./src/BoardKnight.Domain/

COPY tests/BoardKnight.Tests/*.csproj ./tests/BoardKnight.Tests/

RUN dotnet restore

# Copy everything else
COPY . ./

# Build will fail if no unittest passes
RUN dotnet test tests/BoardKnight.Tests
RUN dotnet publish src/BoardKnight.Api -c Release -o out

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/src/BoardKnight.Api/out/ .

ENTRYPOINT [ "dotnet", "BoardKnight.Api.dll" ]