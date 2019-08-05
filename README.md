# graphql-authorization-example
exemplo de api graphql  com authenticação  por nó {field}


para criar um usuário  em memória e gerar o token  faça a requisição abaixo.

```
//Post
http://localhost:5000/api/auth/nova-conta



{
	"email":"teste@gmail.com",
	"password":"Teste@123",
	"ConfirmPassword":"Teste@123"
}

```

se o usuário já existir receba um novo token .

```
//Post
http://localhost:5001/api/auth/entrar

{
	"email":"teste@gmail.com",
	"password":"Teste@123",
	"ConfirmPassword":"Teste@123"
}

```