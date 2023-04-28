//                                ADÁN ISAAC SARCEÑO FLORES
//                                      0905-22-6380
//                                  PARCIAL 2; SECCIÓN "B".
int[,] tablero = new int[5, 5];
int[,] aviones = new int[5, 5];
int[,] minas = new int[5, 5];
void asignar_posicion_aleatoria_aviones(int valor)
{
    Random rnd = new Random();
    int fila = 0;
    int columna = 0;
    do
    {
        fila = rnd.Next(0, 5);
        columna = rnd.Next(0, 5);
    } while (tablero[fila, columna] != 0 || aviones[fila, columna] != 0);
    aviones[fila, columna] = valor;
}
void asignar_posicion_aleatoria_minas(int valor)
{
    Random rnd = new Random();
    int fila = 0;
    int columna = 0;
    do
    {
        fila = rnd.Next(0, 5);
        columna = rnd.Next(0, 5);
    } while (tablero[fila, columna] != 0 || minas[fila, columna] != 0);
    minas[fila, columna] = valor;
}

void paso1_crear_tablero()
{
    for (int f = 0; f < tablero.GetLength(0); f++)
    {
        for (int c = 0; c < tablero.GetLength(1); c++)
        {
            tablero[f, c] = 0;
        }
    }
}
void paso2_colocar_barcos()
{
    asignar_posicion_aleatoria(1);
    asignar_posicion_aleatoria(1);
    asignar_posicion_aleatoria(1);
    asignar_posicion_aleatoria(1);
    asignar_posicion_aleatoria_aviones(2);
    asignar_posicion_aleatoria_minas(3);
}
void paso3_imprimir_tablero()
{
    string caracter_imprimir = "";
    for (int f = 0; f < tablero.GetLength(0); f++)
    {
        for (int c = 0; c < tablero.GetLength(1); c++)
        {
            switch (tablero[f, c])
            {
                case 0:
                    caracter_imprimir = "-";
                    break;
                case 1:
                    caracter_imprimir = "-";
                    break;
                case -1:
                    caracter_imprimir = "*";
                    break;
                case -2:
                    caracter_imprimir = "0";
                    break;
            }
            if (aviones[f, c] == 2)
            {
                switch (aviones[f, c])
                {
                    case 0:
                        caracter_imprimir = "-";
                        break;
                    case 1:
                        caracter_imprimir = "*";
                        break;
                }
            }
            if (minas[f, c] == 3)
            {
                switch (minas[f, c])
                {
                    case 0:
                        caracter_imprimir = "-";
                        break;
                    case 1:
                        caracter_imprimir = "*";
                        break;
                }
            }


            Console.Write(caracter_imprimir + " ");
        }
        Console.WriteLine();
    }
}
void paso4_ingreso_cordenadas()
{
    int fila = 0, columna = 0;
    int barcos_destruidos = 0;
    int num_barcos = 4;
    Console.Clear();
    do
    {
        Console.Write("Ingrese la fila: ");
        fila = Convert.ToInt32(Console.ReadLine());
        Console.Write("Ingrese la columna: ");
        columna = Convert.ToInt32(Console.ReadLine());

        if (tablero[fila, columna] == 1)
        {
            Console.Beep();
            tablero[fila, columna] = -1;
            Console.WriteLine("¡PUM! ¡DESTRUISTE UNA NAVE ENEMIGA!");
            barcos_destruidos++;
            if (barcos_destruidos == num_barcos)
            {
                Console.WriteLine("¡HAS FINALIZADO EL JUEGO, BIEN JUGADO SOLDADO!");
                break;
            }
            Thread.Sleep(5000);
        }
        else if (aviones[fila, columna] == 2)
        {
            Console.Beep();
            aviones[fila, columna] = -1;
            Console.WriteLine("¡PUM! ¡DESTRUISTE UN AVIÓN ENEMIGO!");
            Thread.Sleep(5000);
        }
        else if (minas[fila, columna] == 3)
        {
            Console.Beep();
            minas[fila, columna] = -1;
            Console.WriteLine("¡BOOM! ¡CAÍSTE EN UNA MINA!");
            Console.WriteLine("¡GAME OVER!");
            break;
        }
        else
        {
            tablero[fila, columna] = -2;
        }
        Console.Clear();
        paso3_imprimir_tablero();
    } while (true);
}
void asignar_posicion_aleatoria(int valor)
{
    Random rnd = new Random();
    int fila = 0;
    int columna = 0;
    do
    {
        fila = rnd.Next(0, 5);
        columna = rnd.Next(0, 5);
    } while (tablero[fila, columna] != 0);
    tablero[fila, columna] = valor;
}
paso1_crear_tablero();
paso2_colocar_barcos();
paso3_imprimir_tablero();
paso4_ingreso_cordenadas();

