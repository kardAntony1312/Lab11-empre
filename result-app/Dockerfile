# Usar una imagen base de Node.js
FROM node:14-alpine

# Establecer el directorio de trabajo
WORKDIR /app

# Copiar el archivo package.json y las dependencias
COPY package*.json ./
RUN npm install

# Copiar el resto de la aplicación
COPY . .

# Exponer el puerto
EXPOSE 3000

# Comando para ejecutar la aplicación
CMD ["npm", "start"]
