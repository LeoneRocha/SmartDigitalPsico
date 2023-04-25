docker builder prune
npm run build 
docker-compose build --force-rm
docker-compose up

renomear para lowercase pasta do front models 

docker network create smartdigitalpsiconetwork

docker run --name smartdigitalpsicoSQLServer --hostname dbSQLSERVER --network smartdigitalpsiconetwork -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=docker!123" -p 1433:1433 -d mcr.microsoft.com/mssql/server:latest

docker run --network my-network <nome_da_imagem>
 
******* O IDEAL 

*** APONTAR PARA O BANCO DE DADOS DO AZURE 

*** API EM UM COMPOSE SEPARADO APRA VIRAR UMA SERVICE SEPARADO DO FRONT