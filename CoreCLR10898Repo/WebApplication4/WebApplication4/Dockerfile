FROM microsoft/aspnetcore:1.1
#FROM microsoft/dotnet:1.1-sdk
ARG source
WORKDIR /app
EXPOSE 80
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "WebApplication4.dll"]
