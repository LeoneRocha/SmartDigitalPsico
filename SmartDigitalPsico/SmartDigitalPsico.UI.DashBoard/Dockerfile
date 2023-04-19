 ### STAGE 1: Build ###  esponsável por gerar o build da nossa aplicação  
FROM node:14 as node
WORKDIR /app
COPY . .
##COPY package.json package-lock.json ./ 
RUN npm install  --force
RUN npm run build --prod

### ESTÁGIO 2: Executar ###   2 - Responsável por expor nossa aplicação smartdigitalpsico
FROM nginx:latest 
COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=node /app/dist/smartdigitalpsico /usr/share/nginx/html
  
EXPOSE 8081
CMD ["nginx", "-g", "daemon off;"]