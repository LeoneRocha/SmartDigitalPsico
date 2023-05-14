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

PUBLICAR 

docker pull leonecr/sdpapi-imagecloud:v1

docker-compose -f docker-compose.yml build --force-rm

--------------------------- AZURE  API 
smartdigitalpsicoapi

leonecr/sdp_api_cloud_image:latest

https://smartdigitalpsicoapi.azurewebsites.net 
--------------------------- AZURE  API 
smartdigitalpsicoui

leonecr/sdp_ui_dash_cloud_image:latest
 
aws rds describe-db-instances --query "DBInstances[].VpcSecurityGroups[].VpcSecurityGroupId"
 

sg-00c8fab0fb73caabd
  
  
  
  
aws ec2 authorize-security-group-ingress --group-id sg-00c8fab0fb73caabd --protocol tcp --port 3306 --cidr 20.241.252.30 20.241.252.91 20.241.252.181 20.241.252.233 20.241.253.39 20.241.253.64 20.241.253.144 20.241.253.161 20.241.254.50 20.241.254.52 20.241.254.99 20.241.254.100 20.241.254.197 20.241.254.241 20.241.255.40 20.241.255.56 

20.241.255.76 20.241.255.81 20.241.255.137 20.241.255.193 20.241.255.207 20.241.255.210 20.241.255.239 20.253.120.17 20.119.16.31


aws ec2 authorize-security-group-ingress --group-id sg-00c8fab0fb73caabd --protocol tcp --port 3306 --cidr 20.241.252.30/32
aws ec2 authorize-security-group-ingress --group-id sg-00c8fab0fb73caabd --protocol tcp --port 3306 --cidr 20.241.252.91/32
aws ec2 authorize-security-group-ingress --group-id sg-00c8fab0fb73caabd --protocol tcp --port 3306 --cidr 20.241.252.181/32
aws ec2 authorize-security-group-ingress --group-id sg-00c8fab0fb73caabd --protocol tcp --port 3306 --cidr 20.241.252.233/32
aws ec2 authorize-security-group-ingress --group-id sg-00c8fab0fb73caabd --protocol tcp --port 3306 --cidr 20.241.253.39/32
aws ec2 authorize-security-group-ingress --group-id sg-00c8fab0fb73caabd --protocol tcp --port 3306 --cidr 20.241.253.64/32
aws ec2 authorize-security-group-ingress --group-id sg-00c8fab0fb73caabd --protocol tcp --port 3306 --cidr 20.241.253.144/32
aws ec2 authorize-security-group-ingress --group-id sg-00c8fab0fb73caabd --protocol tcp --port 3306 --cidr 20.241.253.161/32
aws ec2 authorize-security-group-ingress --group-id sg-00c8fab0fb73caabd --protocol tcp --port 3306 --cidr 20.241.254.50/32
aws ec2 authorize-security-group-ingress --group-id sg-00c8fab0fb73caabd --protocol tcp --port 3306 --cidr 20.241.254.52/32
aws ec2 authorize-security-group-ingress --group-id sg-00c8fab0fb73caabd --protocol tcp --port 3306 --cidr 20.241.254.99/32
aws ec2 authorize-security-group-ingress --group-id sg-00c8fab0fb73caabd --protocol tcp --port 3306 --cidr 20.241.254.100/32
aws ec2 authorize-security-group-ingress --group-id sg-00c8fab0fb73caabd --protocol tcp --port 3306 --cidr 20.241.254.197/32
aws ec2 authorize-security-group-ingress --group-id sg-00c8fab0fb73caabd --protocol tcp --port 3306 --cidr 20.241.254.241/32
aws ec2 authorize-security-group-ingress --group-id sg-00c8fab0fb73caabd --protocol tcp --port 3306 --cidr 20.241.255.40/32
aws ec2 authorize-security-group-ingress --group-id sg-00c8fab0fb73caabd --protocol tcp --port 3306 --cidr 20.241.255.56/32
aws ec2 authorize-security-group-ingress --group-id sg-00c8fab0fb73caabd --protocol tcp --port 3306 --cidr 20.241.255

  
aws ec2 authorize-security-group-ingress --group-id sg-00c8fab0fb73caabd --protocol tcp --port 3306 --cidr 20.241.255.76/32
aws ec2 authorize-security-group-ingress --group-id sg-00c8fab0fb73caabd --protocol tcp --port 3306 --cidr 20.241.255.81/32
aws ec2 authorize-security-group-ingress --group-id sg-00c8fab0fb73caabd --protocol tcp --port 3306 --cidr 20.241.255.137/32
aws ec2 authorize-security-group-ingress --group-id sg-00c8fab0fb73caabd --protocol tcp --port 3306 --cidr 20.241.255.193/32
aws ec2 authorize-security-group-ingress --group-id sg-00c8fab0fb73caabd --protocol tcp --port 3306 --cidr 20.241.255.207/32
aws ec2 authorize-security-group-ingress --group-id sg-00c8fab0fb73caabd --protocol tcp --port 3306 --cidr 20.241.255.210/32
aws ec2 authorize-security-group-ingress --group-id sg-00c8fab0fb73caabd --protocol tcp --port 3306 --cidr 20.241.255.239/32
aws ec2 authorize-security-group-ingress --group-id sg-00c8fab0fb73caabd --protocol tcp --port 3306 --cidr 20.253.120.17/32
aws ec2 authorize-security-group-ingress --group-id sg-00c8fab0fb73caabd --protocol tcp --port 3306 --cidr 20.119.16.31/32
  
 
