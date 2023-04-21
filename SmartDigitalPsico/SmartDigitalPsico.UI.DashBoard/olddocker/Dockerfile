 
FROM node:14.15.4-alpine3.10
WORKDIR /app
COPY . .
RUN npm install  --force
RUN npm run build --prod
 
EXPOSE 4209 
CMD ["npm", "start"]

 