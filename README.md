# 📘 Sistema de Gestión de Pagos – Web API (.NET 8)

## 📝 Descripción General

El *Sistema de Gestión de Pagos* es una solución desarrollada en **.NET 8**, que expone una **Web API** con autenticación JWT para gestionar:

* Pagos de empleados
* Tipos de gasto
* Usuarios y roles
* Auditoría de operaciones
* Consultas avanzadas y reportes

La API es consumida por un **Cliente Web MVC** (proyecto separado) mediante **HttpClient**.
👉 El repositorio del cliente MVC se encuentra en:
`https://github.com/codewitheduardo/MVC-Obl-P3-ago25`

El proyecto implementa principios de **Clean Architecture**, **DDD** y buenas prácticas REST.

---

# 📂 Arquitectura de la Solución

```
/Domain              → Entidades, Value Objects, reglas de negocio
/Application         → Casos de uso, DTOs, interfaces
/Infrastructure.Data → EF Core, repositorios, migraciones
/WebAPI              → Endpoints REST + JWT
```

✔️ Capas desacopladas
✔️ Dominio independiente de infraestructura
✔️ Web API consumida exclusivamente vía HttpClient desde el MVC

---

# 🔐 Roles del Sistema

| Rol               | Permisos                                       |
| ----------------- | ---------------------------------------------- |
| **Administrador** | Gestión de usuarios, tipos de gasto, auditoría |
| **Gerente**       | Pagos, reportes, consultas específicas         |
| **Empleado**      | Registro de pagos, consulta de propios datos   |

---

# 🌐 Web API – Endpoints y Requerimientos (RF1–RF6)

---

## 🔒 RF1 – Login / Logout

### **POST `/api/Auth/Login`**

Autentica un usuario y retorna un **JWT**.

### **POST `/api/Auth/Logout`**

Finaliza la sesión (depende de la implementación).

---

## 👤 RF2 – Obtener todos los pagos de un usuario

### **GET `/api/Pagos/Usuario/{usuarioId}`**

Devuelve todos los pagos del usuario autenticado.

✔ Empleado → solo sus pagos
✔ Gerente → puede ver empleados de su equipo

Incluye:

* Monto
* Tipo de gasto
* Fecha
* Tipo de pago (único/recurrente)

---

## 🔄 RF3 – Resetear contraseña (Administradores)

### **PUT `/api/Usuarios/{id}/ResetPassword`**

Genera una **nueva contraseña aleatoria**, válida según las reglas del sistema.
La contraseña se actualiza en base (bcrypt) y se retorna como respuesta.

---

## 🧩 RF4 – Equipos con pagos únicos superiores a un monto (Gerentes)

### **GET `/api/Equipos/PagosUnicosMayorA/{monto}`**

Retorna los **equipos** cuyos empleados realizaron pagos únicos superiores al monto dado.

✔ Sin repetidos
✔ Ordenados por nombre DESC
✔ Solo Gerentes

---

## 💸 RF5 – Alta de pagos (cualquier rol autenticado)

### **POST `/api/Pagos`**

Permite registrar pagos únicos o recurrentes.

Incluye:

* Usuario
* Tipo de gasto
* Monto
* Fecha
* Datos de recurrencia (si corresponde)

---

## 📜 RF6 – Auditoría de tipos de gasto (Administradores)

### **GET `/api/Auditoria/TipoGasto/{id}`**

Listado de todas las operaciones realizadas sobre un tipo de gasto:

* Tipo de operación
* Fecha
* Usuario que la realizó

Solo Administradores pueden acceder.

---

## 🌍 Endpoint Adicional – Pago por ID (Público / Sin autenticación)

### **GET `/api/Pagos/{id}`**

Devuelve información detallada de un pago según su ID.
(No requiere autenticación porque corresponde a la primera mitad del obligatorio.)

---

# 📖 Documentación Completa (Postman)

La API cuenta con documentación completa en Postman:

👉 [https://documenter.getpostman.com/view/46822848/2sB3Wtqxcz](https://documenter.getpostman.com/view/46822848/2sB3Wtqxcz)

[![Run in Postman](https://run.pstmn.io/button.svg)](https://documenter.getpostman.com/view/46822848/2sB3Wtqxcz)

Incluye:

* Endpoints
* Parámetros
* Ejemplos JSON
* Variables
* Autenticación JWT
* Colección lista para importar

---

# 🛠️ Tecnologías Utilizadas

* .NET 8
* ASP.NET Web API
* Entity Framework Core 8
* SQL Server
* LINQ
* JWT Authentication
* Swagger / Postman

---

# ⚙️ Instalación y Configuración

### 1. Clonar el repositorio

```
git clone https://github.com/codewitheduardo/API-Obl-P3-ago25
```

### 2. Configurar `appsettings.json`

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=...;Database=...;Trusted_Connection=True;"
},
"Jwt": {
  "Key": "...",
  "Issuer": "...",
  "Audience": "..."
}
```

### 3. Ejecutar migraciones

```
update-database
```

### 4. Ejecutar la Web API

La API estará disponible en:

```
https://localhost:<puerto>/api
```

---

# ☁️ Deploy en Azure

La API fue desplegada en Azure (reemplazar con tu URL):

🌐 **Web API:**
`https://obligatoriowebapi20251119220526-e2avfegbfnh3gbda.canadacentral-01.azurewebsites.net/api`

📎 El cliente MVC consumirá esta misma URL configurada en su `appsettings.json`.

---

# 📦 Precarga de Datos

Se incluye una base completa con:

* Usuarios (Admin, Gerentes, Empleados)
* Tipos de gasto
* Equipos
* Pagos (únicos y recurrentes)
* Auditoría coherente con las acciones realizadas

Los datos fueron generados y revisados para cubrir todos los RF.

---

# 👥 Repositorios Relacionados

* **Web API (este repositorio)**
* **Cliente MVC (repositorio aparte):**
  `https://github.com/codewitheduardo/API-Obl-P3-ago25`

---
