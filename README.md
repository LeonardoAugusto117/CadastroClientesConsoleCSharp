# 📋 Sistema de Cadastro de Clientes (C# Console)

Projeto desenvolvido em **C# Console** com o objetivo de praticar lógica de programação, uso de listas, estrutura de menus, validações básicas e organização de código.

Este projeto simula um **sistema simples de cadastro de clientes**, permitindo cadastrar, listar, buscar e remover clientes através do terminal.

---

## 🚀 Funcionalidades

- 📌 Cadastro de clientes (Nome, CPF e Email)
- 📄 Listagem de clientes cadastrados
- 🔍 Busca de cliente pelo CPF
- 🗑️ Remoção de cliente pelo CPF
- ✅ Validação de CPF:
  - Deve conter exatamente 11 dígitos
  - Não permite CPF duplicado
- 🧭 Menu interativo no console
- 🎨 Logo em ASCII no início do sistema

---

## 🛠️ Tecnologias Utilizadas

- C#
- .NET (Console Application)
- Visual Studio

---

## 📂 Estrutura do Projeto

O sistema utiliza **listas paralelas** para armazenar os dados:

- `List<string> clientes`
- `List<string> cpfs`
- `List<string> emails`

Os dados de um cliente são relacionados pelo **mesmo índice** em cada lista.


