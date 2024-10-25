FROM mcr.microsoft.com/dotnet/sdk:6.0 as build

WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./


FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /app

COPY --from=build /app/out .

EXPOSE 80

ENTRYPOINT [ "dotnet", "csproj_one.dll" ]

