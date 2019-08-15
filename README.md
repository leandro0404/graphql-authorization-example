# graphql-authorization-example
exemplo de api graphql  com authenticação  por nó {field}
 ![alt text](https://github.com/leandro0404/graphql-authorization-example/blob/master/img/authorize-code.png)

para criar um usuário  em memória e gerar o token  faça a requisição abaixo.

```graphql
//Post
http://localhost:5000/api/auth/nova-conta



{
	"email":"teste@gmail.com",
	"password":"Teste@123",
	"ConfirmPassword":"Teste@123"
}

```

se o usuário já existir receba um novo token .

```graphql
//Post
http://localhost:5001/api/auth/entrar

{
	"email":"teste@gmail.com",
	"password":"Teste@123",
	"ConfirmPassword":"Teste@123"
}

```

 ![alt text](https://github.com/leandro0404/graphql-authorization-example/blob/master/img/query-product.png)

```graphql
query {
  product{
    id,
    name,
    price
  }
}



{
  "Authorization":"Bearer SEU TOKEN JTW QUE FOI GERADO NA URL http://localhost:5000/api/auth/nova-conta OU  http://localhost:5001/api/auth/entrar "
}
````
