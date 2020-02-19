# appsettings.json

ex: 

```json
{
  "AppName": "Your App Name",
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "Dispatchers":{
    "Slack": {
      "Webhook" : "https://hooks.slack.com/services/this_is_just_a_simple_url"
    },
    "Email": {
      "To": "email@email.com",
      "From": "email@email.com",
      "Username": "username",
      "Password": "password",
      "Smtp": "smtp.email.com",
      "Port": 587
    }
  }
}
```

If you want to use Gmail as a sender, just go to https://myaccount.google.com/u/5/lesssecureapps?pli=1&pageId=none and allow less secure apps to send mail.