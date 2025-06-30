# Sistema de Configuración Global con Patrón Singleton

Aplicación WPF en C# que implementa un **Configuration Manager** usando el patrón Singleton para gestionar ajustes globales desde un archivo JSON.

## Funcionalidades
- ✅ **Carga inicial** de configuración desde `config.json` (o valores por defecto).
- ✅ **Modificación** de parámetros con persistencia automática.
- ✅ **Pantallas reactivas**:
  - *Panel de Bienvenida*: Muestra hora, idioma y tema según configuración.
  - *Simulador de Conexiones*: Usa `MaxConnections` y `EnableLogs`.
- ✅ **Menú intuitivo** con navegación entre funciones.

## Tecnologías
- C# (.NET 6+)
- WPF (Interfaz gráfica)
- Newtonsoft.Json (Manejo de JSON)
- Patrón Singleton

## Instalación
1. Clona el repositorio:
   ```bash
   git clone [URL-del-repositorio]