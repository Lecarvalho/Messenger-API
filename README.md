# Messenger-API
Generic Messenger REST API that receive a Message and make the dispatch for any Messengers (slack, email, whatsapp, any other api)

__Now the image is available on docker hub.__

```
docker run \
  --name "messenger-api" \
  -dp 5000:80 \
  --volume $PWD/appsettings.json:/app/appsettings.json \
  lecarvalho/messenger-api
```

See an exemple of appsettings.json on the Webapi folder

This is an open source project to help people who wants to use externalize the communication with the customers in a simple and scalable way.

To use it as simple, just clone this project and

1. Create a file appsettings.json. Follow the steps in appsettings.json.md
2. Build and run using docker: docker build -t messenger-api . && docker run -dp 80:80 messenger-api
3. Open the swagger page: http://localhost/swagger
3. Test with postman or something like. It's REST API and it's very simple.

Using .NET 5
