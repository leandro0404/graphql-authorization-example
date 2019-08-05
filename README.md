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
