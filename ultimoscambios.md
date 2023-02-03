## Separar la lógica del juego de la parte visual:
-Para lograr separar la parte lógica de la parte visual fue necesario controlar las acciones del juego de manera independiente de modo que se fuera ejecutando cada acción a la par de ir obteniendo la información necesaria de la partida para la visualización de esta por el jugador.

-Estas responsabilidades fueron añadidas al Manager donde él va controlando la ejecución de la partida y tiene la información necesaria para brindársela al jugador.

-Se separó la carpeta FrontEnd de la biblioteca de clases Poker (La lógica del juego) ya que este funciona indendiente de tal manera que se pueden hacer simulaciones para verificar la correcta ejecución de diferentes partes como el Simulador de la carpeta Game que realiza operaciones con la Ronda y verifica que no todo está correcto.

-Ahora para ejecutar el juego de manera que ofrezca información visual se hace a través de la clase Game que recibe el Manager y el FrontEnd (la interfaz de cómo se va a mostrar al usuario la información) en ella se van ejecutando todas las secciones del juego a través del Manager y se va brindando la información correspondiente a cada sección al jugador. Esta clase funciona como una API donde se recibe la información necesaria por parte del usuario y se procesa a través del Manager que tiene acceso a toda la lógica del juego.