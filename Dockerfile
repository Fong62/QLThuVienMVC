# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy toàn bộ solution/project vào container
COPY ["QLThuVienMVC/QLThuVienMVC.csproj", "QLThuVienMVC/"]
RUN dotnet restore "QLThuVienMVC/QLThuVienMVC.csproj"  # Đảm bảo đúng đường dẫn

COPY . .
RUN dotnet publish "QLThuVienMVC/QLThuVienMVC.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "QLThuVienMVC.dll"]