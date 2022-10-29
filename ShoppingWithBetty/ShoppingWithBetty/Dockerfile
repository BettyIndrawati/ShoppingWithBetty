8#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ShoppingWithBetty/ShoppingWithBetty.csproj", "ShoppingWithBetty/"]
COPY ["ShoppingWithBetty.DataAccess/ShoppingWithBetty.DataAccess.csproj", "ShoppingWithBetty.DataAccess/"]
COPY ["ShoppingWithBetty.Models/ShoppingWithBetty.Models.csproj", "ShoppingWithBetty.Models/"]
RUN dotnet restore "ShoppingWithBetty/ShoppingWithBetty.csproj"
COPY . .
WORKDIR "/src/ShoppingWithBetty"
RUN dotnet build "ShoppingWithBetty.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShoppingWithBetty.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShoppingWithBetty.dll"]