# 📡 Captura de Datos de Sensores Ambientales

**Autor:** Daniel Alejandro González Gutiérrez  
**Proyecto:** Captura de Datos de Sensores Ambientales  
**Materia:** Patrones de Diseño – Examen Unidad 2  

---

## 🧠 Descripción Breve del Funcionamiento

Este proyecto implementa **dos patrones de diseño** fundamentales:  
- **Singleton**: Garantiza que solo exista una única instancia del **Centro de Control Ambiental**, la cual coordina y gestiona todos los sensores del sistema.  
- **Object Pool**: Administra un conjunto de objetos **Sensor** reutilizables, evitando la creación y destrucción constante de instancias.  

Durante la ejecución, el sistema simula la **lectura de datos de contaminación ambiental** mediante sensores.  
Cada sensor puede encontrarse en dos estados:
- **EnLectura**: cuando está tomando datos del ambiente.  
- **EnPiscina**: cuando está disponible para ser reutilizado.

El Centro de Control Ambiental se encarga de:
1. Solicitar sensores del pool para realizar lecturas.  
2. Liberarlos una vez terminada la captura, permitiendo su reutilización.  
3. Garantizar que toda la gestión de sensores se haga desde una **única instancia global**.  

Además, el programa realiza **comprobaciones de referencia** para verificar la reutilización de objetos y la existencia de una sola instancia del centro de control.

---

## ⚙️ Tecnologías Utilizadas
- Lenguaje: **C#**

---

## 🧩 Patrones Aplicados
- **Singleton** → Clase `CentroControlAmbiental`  
- **Object Pool** → Clase `SensorPool`

---
## ▶️ Cómo ejecutar el programa

### 🖥️ Requisitos previos
- Tener instalado **.NET SDK 8.0** o superior  
  👉 Puedes descargarlo desde: [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)
- Tener un entorno compatible, como:
  - **Visual Studio 2022**
  - **Visual Studio Code** con la extensión de C#

---

### 🚀 Ejecución desde Visual Studio 2022
1. Abre la solución:  
   `ExamenUnidad2Patrones_DanielAlejandroGonzalezGutierrez.sln`
2. Selecciona el menú **Depurar → Iniciar sin depurar** (`Ctrl + F5`).
3. El programa se ejecutará en la consola mostrando:
   - Lecturas simuladas de sensores ambientales.
   - Mensajes de liberación de sensores.
   - Comprobaciones de reutilización y Singleton.

---

### ⚙️ Ejecución desde la terminal (.NET CLI)
1. Abre una terminal en la carpeta raíz del proyecto.  
2. Ejecuta los siguientes comandos:
   ```bash
   dotnet build
   dotnet run

## 💡 Ejemplo de Ejecución
```
[LECTURA] Sensor #1 en EnLectura. Valor:
[LIBERADO] Sensor #1 devuelto al pool.

[LECTURA] Sensor #1 en EnLectura. Valor: 
[LIBERADO] Sensor #1 devuelto al pool.

Comprobación de referencia Sensor 1 y Sensor 2 : True


---

© 2025 Daniel Alejandro González Gutiérrez – Instituto Tecnológico de Tijuana
