# AquiTourism

**AquiTourism** é uma API moderna desenvolvida com **.NET 8**, voltada para o gerenciamento de dados relacionados ao turismo, como atrações e operadores. O projeto segue os princípios de **Clean Architecture**, utilizando **Entity Framework Core**, **AutoMapper** e **Injeção de Dependência** para garantir modularidade, testabilidade e escalabilidade.

---

## ✅ Funcionalidades

### 🎯 Gerenciamento de Atrações
- Operações CRUD completas
- Filtros personalizáveis e paginação

### 👤 Gerenciamento de Operadores
- Cadastro com validação de **e-mail** e **CPF** únicos
- Autenticação com geração de **token JWT**
- Criação, validação e redefinição de senha
- Atualização de dados cadastrais
- Desativação e exclusão lógica de operadores

### 🧰 Recursos Técnicos
- API RESTful com **versionamento**
- Documentação interativa via **Swagger**
- Implementação do **Padrão Unit of Work** para consistência transacional
- **AutoMapper** para mapeamento de objetos
- Arquitetura extensível com separação de camadas:
  - Application
  - Domain
  - Infrastructure

---

## 🛠️ Tecnologias Utilizadas

- [.NET 8](https://dotnet.microsoft.com/download)
- C# 12
- Entity Framework Core
- AutoMapper
- Swagger (Swashbuckle)
- Dependency Injection
- SQL Server (padrão, mas configurável)

---

## 🚀 Como Começar

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) ou banco compatível

### Passo a passo

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/yourusername/AquiTourism.git
   cd AquiTourism
   ```

2. **Configure a string de conexão:**
   - Arquivo: `src/AquiTourism.API/appsettings.json`

3. **Aplique as migrações do banco de dados:**
   ```bash
   dotnet ef database update --project src/AquiTourism.Infra.Data
   ```

4. **Execute a aplicação:**
   ```bash
   dotnet run --project src/AquiTourism.API
   ```

5. **Acesse o Swagger UI:**
   - No navegador: [https://localhost:5001/swagger](https://localhost:5001/swagger)

---

## 📁 Estrutura do Projeto

```
AquiTourism
│
├── src/
│   ├── AquiTourism.API/                # Camada de API (controllers, configs)
│   ├── AquiTourism.Application/        # Serviços da aplicação, ViewModels, AutoMapper
│   ├── AquiTourism.Domain/             # Entidades e interfaces de domínio
│   ├── AquiTourism.Infra.Data/         # Repositórios, EF Core, contexto de dados
│   ├── AquiTourism.Infra.CrossCutting/ # Injeção de dependência, utilitários
│   └── AquiTourism.Core/               # Objetos de domínio, enums, helpers
```

---

## 📌 Como Utilizar

- Utilize o **Swagger UI** para testar e explorar os endpoints disponíveis.
- Realize a integração com **aplicações web ou mobile** por meio da API REST.
- O registro de operadores exige **confirmação de senha**, **CPF** e **e-mail únicos**.
- A autenticação retorna um **JWT token** necessário para acessar rotas protegidas.
- Operadores podem ser **desativados** ou ter a senha **redefinida** via endpoints dedicados.

---

## 🤝 Contribuindo

Contribuições são muito bem-vindas!  
Sinta-se à vontade para abrir issues ou enviar pull requests com sugestões, correções e melhorias.

---

## 📄 Licença

Este projeto está licenciado sob a **MIT License**.  
Consulte o arquivo [LICENSE](./LICENSE) para mais detalhes.
