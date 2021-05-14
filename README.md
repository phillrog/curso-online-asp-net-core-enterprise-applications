# curso-online-asp-net-core-enterprise-applications
Curso ASP.NET Core Enterprise Applications - desenvolvedor.io

Este curso implementa diversos conceitos e boas práticas de desenvolvimento de software:

- Identity
- JWT
- MVC
- API Gateway / BFF
- CQRS
- Menssageria RabbitMQ
- Design Patterns
- Padrões de projetos
- APIs distribuidas


### Extrair a chave privada do certificado

 openssl pkcs12 -in local-certificado.pfx -nocerts -out local-certificado.pem -nodes
 
### Extrair o rsa do pem para o key

openssl rsa -in local-certificado.pem -out local-certificado.key


### Reescrever o pem com certificado

openssl pkcs12 -in local-certificado.pfx -nokeys -out local-certificado.pem 
 