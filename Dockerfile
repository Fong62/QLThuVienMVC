FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY QLThuVienMVC/QLThuVienMVC.csproj ./QLThuVienMVC/
RUN dotnet restore ./QLThuVienMVC/QLThuVienMVC.csproj
COPY . .
RUN dotnet build ./QLThuVienMVC/QLThuVienMVC.csproj -c Release

FROM build AS publish
RUN dotnet publish ./QLThuVienMVC/QLThuVienMVC.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QLThuVienMVC.dll"]