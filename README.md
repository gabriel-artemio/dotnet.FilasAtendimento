# API Filas de Atendimento

## 📌 Sobre o projeto

Este projeto consiste no desenvolvimento de uma API RESTful para emissão e gerenciamento de senhas de atendimento, construída com .NET e MySQL.

A API permite o controle completo das filas de atendimentos, famosas senhas, onde é possível emitir e gerenciar uma senha, de acordo com o tipo do serviço e prioridade de atendimento, além de contar com um sistema de autenticação e autorização via JWT (JSON Web Token), garantindo segurança no acesso aos endpoints.

O projeto foi desenvolvido com foco em boas práticas, organização de código e facilidade de integração com aplicações front-end ou outros sistemas corporativos.

🛠️ Tecnologias utilizadas
<ul>
  <li>⚙️ .NET</li>
  <li>🗄️ MySQL</li>
  <li>🔐 JWT (JSON Web Token)</li>
</ul>

## 🔗 Endpoints da API

A API disponibiliza endpoints REST para a emissão e gerenciamento das senhas, permitindo operações de criação, consulta, atualização e exclusão (**CRUD**).

## ⚙️ Como usar?

Segue a rotina para usar a api de controle de folha de ponto:

<ol>
  <li>Cadastre uma unidade de atendimento.</li>
  <li>Cadastre o tipo do serviço.</li>
  <li>Cadastre o tipo da prioridade.</li>
  <li>Gere a senha.</li>
  <li>Chame e faça o atendimento da senha.</li>
</ol>

---

### 🔐 Autorização

| Método        | Endpoint       | Descrição                                 |
|---------------|----------------|-------------------------------------------|
| 🟢 **POST**   | `/Auth`       | Realiza a autenticação do usuário na api  |

---

### 📝 Exemplo de POST (Auth)

```json
{
  "nm_usuario": "string",
  "senha": "string"
}
```
 <!--
### 📦 Registro Ponto

| Método         | Endpoint                                                | Descrição                                     |
|--------------- |---------------------------------------------------------|-----------------------------------------------|
| 🔵 **GET**    | `/RegistroPonto`                                         | Lista todos os registros de ponto            |
| 🔵 **GET**    | `/RegistroPonto/id`                                      | Lista um registro específico por id          |
| 🔵 **GET**    | `/RegistroPonto/byFuncionario/id`                        | Lista os registros de um funcionário         |
| 🔵 **GET**    | `/RegistroPonto/horasByFuncionario/id`                   | Lista as horas trabalhadas de um funcionário |
| 🔵 **GET**    | `/RegistroPonto/horasExtrasByFuncionario/id/status`      | Lista as horas extras de um funcionário      |
| 🟢 **POST**   | `/RegistroPonto`                                         | Cadastra uma novo registro de ponto          |

🔵 **GET** `/RegistroPonto/horasExtrasByFuncionario/id/status` : neste endpoint, o usuário informa o status, onde:

<ul>
  <li>0 = Horas extras para validar</li>
  <li>1 = Horas extras validadas</li>
</ul>

---

### 📝 Exemplo de POST (RegistroPonto)

```json
{
  "funcionario_id": 0,
  "datahora": DateTime,
  "tipo": 0,
  "status": 0
}
```
-->
📍 Observações

A API segue o padrão REST
