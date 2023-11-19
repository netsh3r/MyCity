FROM node:18.13.0-alpine
WORKDIR /app/frontend
COPY ./package.json .

RUN npm install
RUN npm cache clean --force
COPY . .
CMD [ "npm", "run", "dev" ]