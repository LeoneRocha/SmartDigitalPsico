# Use an official Node.js runtime as a parent image
FROM node:18 as node

# Set the working directory
WORKDIR /app

# Copy the rest of the application to the container
COPY . .

# Install the app dependencies
RUN npm install  --force -g @angular/cli
# Build the app for production
RUN npm run build --prod

# Expose port 4209
EXPOSE 4209
EXPOSE 8080
EXPOSE 52715
# Start the Angular application
CMD ["npm", "run", "start"]
