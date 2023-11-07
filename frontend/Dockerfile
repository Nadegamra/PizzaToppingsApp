#----------------------------
FROM node:19-alpine AS base
ENV PATH /app/node_modules/.bin:$PATH
WORKDIR /app
COPY package*.json ./
#----------------------------
FROM base AS dev
COPY ./frontend .
RUN npm i
CMD ["npm", "run", "dev"]
#-----------------------------
FROM base AS prod
COPY ./frontend .
RUN npm ci
RUN npm run build
CMD ["npm", "run", "preview"]