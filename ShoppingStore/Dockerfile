FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

WORKDIR /app

COPY *.csproj ./
RUN dotnet restore ShoppingStore.csproj

COPY . ./
RUN dotnet publish ShoppingStore.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
ENV ASPNETCORE_ENVIRONMENT Production
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 80

ENTRYPOINT ["dotnet", "ShoppingStore.dll", "--urls=http://0.0.0.0:80"]