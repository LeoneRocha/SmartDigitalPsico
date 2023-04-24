docker builder prune
npm run build 
docker-compose build --force-rm
docker-compose up

renomear para lowercase pasta do front models 

docker network create smartdigitalpsiconetwork

docker run --name smartdigitalpsicoSQLServer --hostname dbSQLSERVER --network smartdigitalpsiconetwork -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=docker!123" -p 1433:1433 -d mcr.microsoft.com/mssql/server:latest

docker run --network my-network <nome_da_imagem>

leonecr/sdpuidashimage:latest
 
leonecr/sdpapiimage:latest


docker run -d --name sdpapicontainer --env TZ=America/Sao_Paulo --env ASPNETCORE_ENVIRONMENT=Production --env ASPNETCORE_URLS=https://+:443;http://+:5001 -p 443:443 -p 5001:5001 --link dbSQLSERVER --network smartdigitalpsiconetwork  --volume ${APPDATA}/Microsoft/UserSecrets:/root/.microsoft/usersecrets:ro   --volume ${APPDATA}/ASP.NET/Https:/root/.aspnet/https:ro  leonecr/sdpapiimage:latest
