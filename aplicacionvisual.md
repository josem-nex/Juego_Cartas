# Aplicación Visual

## Frontend:

La carpeta *Frontend* representa la aplicación visual del juego mediante la interfaz *IFrontendGame* que se encarga de mostrar la información del juego en la pantalla. Esta interfaz contiene el frontend del juego que a su vez contiene el de la ronda y el de la mini-ronda.

Dicha interfaz está implementada por la clase *FrontendGame* que muestra el juego a través de la consola, pero es posible implementar una interfaz gráfica para el juego.

## Game:

La carpeta *Game* representa una aplicación de consola que apoyada en la librería de clases ejecuta el juego. Además es posible definir nuevas clases y objetos para *extender* las reglas del juego, según cada estructura del juego lo permita.

## Instrucciones para jugarlo:

En tu turno debes escribir que Decisión decides realizar, las posibles decisiones serían:

- Apostar : escribe la cantidad de dinero que deseas apostar

- Igualar : iguala de ser posible a la apuesta del jugador anterior

- Pasar : no apostar en la mini-ronda.

- Abandonar : salir de la ronda, no de la partida.

- Efecto: puedes escribir que efecto deseas realizar basado en las reglas del lenguaje descrito a continuación.
  
  

### Mejoras, Ideas, Bugs:

- el mayor problema es separar la lógca del juego de la parte visual y crear interfaces para todas las acciones del juego, para que pueda venir alguien e implementar una versión del juego que no es especificamente en consola. (arreglado ???)
