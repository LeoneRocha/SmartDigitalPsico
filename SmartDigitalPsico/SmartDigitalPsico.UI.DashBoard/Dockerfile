 ### STAGE 1: Build ###  esponsável por gerar o build da nossa aplicação  
FROM node:14 as node
WORKDIR /app
COPY package*.json /app/
RUN npm install  --force
COPY . .
##COPY package.json package-lock.json ./ 
ARG configuration=production

RUN npm run build --prod --output-path=./dist/smartdigitalpsico  --configuration $configuration

### ESTÁGIO 2: Executar ###   2 - Responsável por expor nossa aplicação smartdigitalpsico *  based on Nginx, to have only the compiled app, ready for production with Nginx
FROM nginx:latest 
## Skip this if you are using kubernetes config map 
COPY nginx.conf /etc/nginx/nginx.conf
## From ‘builder’ stage copy over the artifacts in dist folder to default nginx public folder
COPY --from=node /app/dist/smartdigitalpsico /usr/share/nginx/html
  
EXPOSE 8081
## Serve
##CMD ["nginx", "-g", "daemon off;"]

 