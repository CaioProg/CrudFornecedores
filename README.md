# Akuma no Mi API


## 💻 Pré-requisitos

Antes de começar, verifique se você atendeu aos seguintes requisitos:
<!---Estes são apenas requisitos de exemplo. Adicionar, duplicar ou remover conforme necessário--->
* .NET 6 
* Visual Studio 
* Postman (recomendado)
* MySql
* Sistema Operacional Windows

<br>

## 🚀 Instalação

<h2>Para instalar a API na sua maquina, siga estas etapas:
</h2>
No terminal digite o camando abaixo dentro da pasta que deseja instalar:
<br>
<br>

```
git clone https://github.com/CaioProg/Akuma_No_Mi_API.git
```
<br>

Dentro da pasta instalada você tera um arquivo chamado 'AkumaNoMi.sln', este é o arquivo da solução, abra ele no Visual Studio.

<br>
<a href="#">
<img src="img/pastas.png" width="1000px;" alt="Imagem das pastas"/><br>
</a>

<br>

Após a abertura do Visual Studio vamos iniciar a aplicação clicando em 'AkumaNoMi' como mostrado na imagem abaixo.

<br>

<a href="#">
<img src="img/sln.png" width="1000px;" alt="Imagem do botão de iniciar"/><br>
</a>

<br>

No console que se abriu, vamos copiar a segunda URL para colocarmos no Postman.

<br>

<a href="#">
<img src="img/printcmd.png" width="1000px;" alt="Imagem do botão de iniciar"/><br>
</a>

<br>

Dentro do Postaman vamos colar a Url e acrescentar um '/Fruta' ao final dela.

<br>

<a href="#">
<img src="img/print1.png" width="1000px" alt="Imagem do botão de iniciar"/><br>
</a>

<br>

<h2>A API possui os seguintes metodos:</h2>

* Get
* Post
* Put
* Delete

## Utilizando os metodos:


Primeiramente vamos criar uma Akuma no Mi, e para isso utilizamos o metodo POST e dentro do 'Body' vamos utilizar esse modelo de JSON:
```
{
  "nome": "Nome da Fruta",
  "tipo": "Tipo da fruta",
  "usuário": "Usuário que a possui",
  "detalhes": "Detalhes sobre a fruta"
}
```

<br>

<a href="#">
<img src="img/print2.png" width="1000px;" alt="Imagem do botão de iniciar"/><br>
</a>

<br>

Para listar todas as Frutas cadastradas, utilizamos o metodo GET com a mesma URL do POST.

<br>
<a href="#">
<img src="img/print3.png" width="900px;" alt="Imagem do botão de iniciar"/><br>
</a> 

<br>

Para filtrar qual fruta trazer, utilizamos o metodo GET e colocamos um /'id' no final da URL representando qual o id da fruta que queremos consultar. 

<br>
<a href="#">
<img src="img/print4.png" width="1000px;" alt="Imagem do botão de iniciar"/><br>
</a> 

<br>

Agora vamos utilizar o metodo PUT para editar uma Akuma no Mi cadastrada, para isso vamos utlizar a URL junto com o /'id' no final, e no Body o que queremos alterar.

<br>

<a href="#">
<img src="img/print5.png" width="1000px;" alt="Imagem do botão de iniciar"/><br>
</a> 
<br>

E por fim mas não menos importante, vamos excluir uma Akuma no Mi cadastrada, para isso utilizamos o metodo Delete com o /'id' no final da URL

<br>
<a href="#">
<img src="img/print6.png" width="1000px;" alt="Imagem do botão de iniciar"/><br>
</a> 
<br>
<br>
<br>
