# Maze_Collect_Reward

¡Bienvenido a **Maze_Collect_Reward**! Este es un emocionante juego de laberinto de generación aleatoria con dos jugadores, donde el objetivo es recolectar la mayor cantidad de dinero posible. El juego ofrece una perspectiva diferente y entretenida con modificadores que pueden ser trampas o beneficios, y una variedad de fichas, cada una con habilidades únicas.

## Descripción

En **Maze_Collect_Reward**, los jugadores navegan a través de un laberinto generado aleatoriamente, recolectando dinero y diamantes, teniendo cuidado con los modificadores. Cada jugador recibe una ficha aleatoria con una habilidad especial.

### Características Principales

- **Generación Aleatoria de Laberintos**: Cada partida es única gracias a la generación aleatoria del laberinto.
- **Modificadores**: Trampas y beneficios repartidos aleatoriamente por el laberinto.
- **Variedad de Dinero**: Existen monedas con el valor de 1 y diamantes que valen 3 repartidos por el laberinto.
- **Variedad de Fichas**: Cada jugador recibe una ficha asignada aleatoriamente con una habilidad especial.
- **Controles Sencillos**: Usa las teclas de direcciones para moverte y la tecla `A` para usar tu habilidad.
- **Juego en Consola**:Desarrollado en C# utilizando la librería Spectre.Console.

### Cómo Jugar

- **Movimiento**: Usa las teclas de dirección (`↑`, `↓`, `←`, `→`) para moverte por el laberinto.
- **Habilidad**: Presiona la tecla `A` para usar la habilidad especial de tu ficha.
- **Objetivo**: Recolecta la mayor cantidad de dinero (monedas y diamantes) antes de que se acabe el tiempo o no queden más objetos por recolectar.

### Funcionalidades del juego

- **Chips**: Crea las fichas con su habilidad.
- **Draw**: Se encarga de dibujar el laberinto y los elementos del juego en la consola.
- **GameManager**: Gestiona el flujo del juego, incluyendo la inicialización del laberinto, los jugadores y la lógica del juego.
- **Maze**: Genera el laberinto de forma recursiva, contiene la lógica para generarlo y gestionar los objetos dentro de él.
- **Modifiers**: Crea los modifificadores.
- **Money**: Define los tipos de dinero que se pueden recolectar en el laberinto: monedas y diamantes.
- **ParametersToModifiersAndSkills**: Contenedor de dependencia para pasarle los parámetros pasa el uso de las habilidades y activar los modificadores.
- **Players**: Crea un jugador, su movimiento, lo inicializa en una posición y le asigna una ficha aleatoriamente.
- **VictoryCondition**: Determina la condición de victoria del juego.
- **VirtualPlayer**: Un jugador virtual que tiene un comportamiento automatizado para moverse por el laberinto y recolectar dinero.
- **Menu**: Maneja el menú del juego, permitiendo al usuario seleccionar el número de jugadores, el nivel de dificultad, jugar o salir.

### Instalación

Sigue estos pasos para clonar y configurar el proyecto:

1. Clona el repositorio:
   ```bash
   git clone https://github.com/heilyrodriguez225/Maze_Collect_Reward.git
2. Navega al directorio del proyecto:
   cd Maze_Collect_Reward
3. Restaura los paquetes necesarios:
   dotnet restore
4. Ejecuta el proyecto:
   dotnet run
   
## Screenshot
![Captura desde 2025-01-31 01-10-40](https://github.com/user-attachments/assets/e07fe158-8d84-4786-99fa-4fad7fe932e2)

## Tecnologías Utilizadas

- C#
- .NET
- Spectre.Console
  
## Contacto

- Email: heilyrodriguez225@gmail.com
- GitHub: https://github.com/heilyrodriguez225
