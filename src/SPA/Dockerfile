# Stage 1: Compile and Build angular codebase

# Use official node image as the base image
FROM node:latest as build

# Set the working directory
WORKDIR /usr/local/spa

# Add the source code to app
COPY ./SPA /usr/local/spa/

# Install all the dependencies
RUN npm install

# Generate the build of the application
RUN npm run build


# Stage 2: Serve app with nginx server

# Use official nginx image as the base image
FROM nginx:latest

# Copy the build output to replace the default nginx contents.
COPY --from=build /usr/local/spa/dist/web-spa /usr/share/nginx/html

# Expose port 80
EXPOSE 80


# NOTA: La carpeta que contiene el proyecto se llama 'SPA' (uppercase)
