FROM mcr.microsoft.com/dotnet/core/sdk AS build-env
WORKDIR /app    
COPY *.csproj ./ 
RUN dotnet restore    
COPY . ./     
RUN dotnet publish -c Release -o out  
EXPOSE 5000
#COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "out/DesafioDotNetCoreBackEnd.dll"]  
