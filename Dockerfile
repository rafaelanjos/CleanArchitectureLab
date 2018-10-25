FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
#EXPOSE 57076 44388

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["/CleanArchitectureLab.UI/CleanArchitectureLab.UI.csproj", "CleanArchitectureLab.UI/"]
COPY ["/CleanArchitectureLab.Core/CleanArchitectureLab.Core.csproj", "CleanArchitectureLab.Core/"]
RUN dotnet restore "CleanArchitectureLab.UI/CleanArchitectureLab.UI.csproj"
COPY . .
WORKDIR "/src/CleanArchitectureLab.UI"
RUN dotnet build "CleanArchitectureLab.UI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "CleanArchitectureLab.UI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CleanArchitectureLab.UI.dll"]